using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RobotWorkstation
{
    public enum RobotAction
    {
        Action_Grap = 0,
        Action_QRCodeScan,
        Action_Put
    }
	
    public enum AutoRunAction
    {
        AuoRunStart = 0,              //开始
        AutoRunGetGrapCoords,         //获得抓取坐标
        AutoRunMoveToGrap,            //移动到位并抓取
        AutoRunMoveToScanQRCode,      //移动到位并扫码,检查扫码格式，不正确则依然执行此动作
        AutoRunMoveToPut,             //移动到位并放下，计数后开始下一件，满总数后下一步
        AutoRunTurnOverPanel,         //计数满则翻盘运走，从头开始

    }

    public enum StationState
    {
        Stop = 0x00,
        Run,
        Pause,
        Scram  //急停
    }

    public enum PlateState
    {
        NoPlate = 0x00,
        HavePlate,
    }

    public class VisualSortingStation  //视觉分拣业务类
    {
        public static IO m_IO = IO.GetInstance();               
        public static int m_DevicesTotal = 0;
        private const int m_OnePanelDevicesMax = 16;
        private static AutoRunAction m_AutoRunAction = AutoRunAction.AuoRunStart;
        private volatile static bool m_ShouldExit = false;

        private static RobotDevice m_Robot = RobotDevice.GetInstance();
        private static short[] m_RobotRead = new short[RobotBase.MODBUS_RD_LEN];
        private static RFID m_RFID = RFID.GetInstance();
        public static string m_RfidRead = "";
        private static QRCode m_QRCode = QRCode.GetInstance();
        private static bool m_ScanQRCode = false;
        public static List<string> m_QRCodeStr = new List<string>();

        private static MyTcpClient m_MyTcpClient = MyTcpClient.GetInstance();
        private static MyTcpServer m_MyTcpServer = MyTcpServer.GetInstance();

        public static bool ShouldExit
        {
            set
            {
                m_ShouldExit = value;
            }
            get
            {
                return m_ShouldExit;
            }
        }

        public static void MainThreadFunc()
        {
            DataStruct.InitSysStat();
            DataStruct.InitSysAlarm();
            m_QRCodeStr.Clear();
            m_QRCode.QRCodeRecvDataEvent += new EventHandler(QRCodeRecvData);

            //创建网络共享文件

            while (!m_ShouldExit)
            {
                if (DataStruct.SysStat.Run )
                {
                    AutoSortingRun();
                }

                Thread.Sleep(100);
            }
        }

        public static void MessageProcessThreadFunc()
        {
            while (!m_ShouldExit)
            {
                //处理Robot消息
                if (m_Robot != null && m_Robot.m_IsConnected)
                    ProcessRobotMessage();

                //处理RFID的数据
                if (m_RFID != null && m_RFID.m_IsConnected)
                    ProcessRFIDMessage();

                //作为客户端处理和单片机控制板的消息队列
                if (m_MyTcpClient != null && m_MyTcpClient.IsConnected)
                    ProcessTcpClientMessage();

                //作为服务端处理和MIS及PLC之间的消息
                if (m_MyTcpServer != null)
                    ProcessTcpServerMessage();

                Thread.Sleep(100);
            }
        }

        public static void ProcessRobotMessage()
        {
            if (m_Robot != null && m_Robot.m_IsConnected)
            {
                const short ReadLen = RobotBase.MODBUS_RD_LEN;
                Array.Clear(m_RobotRead, 0, m_RobotRead.Length);
                m_Robot.ReadMulitModbus(RobotBase.MODBUS_ADDR, ReadLen, ref m_RobotRead);

                //校验协议，并给DataStruct.SysStat中的各状态赋值
                if (Message.CheckRobotMessage(m_RobotRead, ReadLen))
                {
                    RobotIo Io = (RobotIo)m_RobotRead[5];
                    IOValue IoState = (IOValue)m_RobotRead[6];
                    switch (Io)
                    {
                        case RobotIo.RobotIoCylGoArrive: //抓手气缸进到位，正确在机械臂处理，错误在上位机处理进行重试
                            {
                                if (IoState == IOValue.IOValueHigh)
                                    DataStruct.SysStat.RobotCylGoArrive = true;
                                else
                                    DataStruct.SysStat.RobotCylGoArrive = false;
                            }
                            break;
                        case RobotIo.RobotIoCylBackArrive: //抓手气缸退到位，正确在机械臂处理，错误在上位机处理进行重试
                            {
                                if (IoState == IOValue.IOValueHigh)
                                    DataStruct.SysStat.RobotCylBackArrive = true;
                                else
                                    DataStruct.SysStat.RobotCylBackArrive = false;
                            }
                            break;
                        case RobotIo.RobotIoVacuoCheck: //吸嘴真空检测
                            {
                                if (IoState == IOValue.IOValueHigh)
                                    DataStruct.SysStat.RobotVacuoCheck = true;
                                else
                                    DataStruct.SysStat.RobotVacuoCheck = false;
                            }break;
                        default:
                            break;
                    }
                }
            }
        }

        public static void ProcessRFIDMessage()
        {
            if (m_RFID != null && m_RFID.m_IsConnected)
            {
                m_RFID.Read(m_RFID.m_CurCh);
                Thread.Sleep(1);
                if (m_RFID.m_QueueRead.Count > 0)
                {
                    m_RfidRead = m_RFID.m_QueueRead.Dequeue();  //读取到盘，并设置盘到位

                    //检查数据格式正确，则设置标志
                    DataStruct.SysStat.ReceivePlateArrive = true;
                }
            }
        }

        public static void ProcessTcpClientMessage()
        {
            if (m_MyTcpClient != null && m_MyTcpClient.IsConnected)
            {
                while (m_MyTcpClient.m_RecvMeasQueue.Count != 0)
                {
                    TcpMeas TempMeas = m_MyTcpClient.m_RecvMeasQueue.Dequeue();
                    if (TempMeas != null && TempMeas.Client != null)
                    {
                        if (TempMeas.MeasType == TcpMeasType.MEAS_TYPE_ARM)  // 处理和ARM之间的消息
                        {
                            ProcessArmMessage(TempMeas);
                        }
                    }
                }
            }
        }

        public static void ProcessTcpServerMessage()
        {
            if (m_MyTcpServer != null)
            {
                while (m_MyTcpServer.m_RecvMeasQueue.Count != 0)
                {
                    TcpMeas TempMeas = m_MyTcpServer.m_RecvMeasQueue.Dequeue();
                    if (TempMeas != null && TempMeas.Client != null)
                    {
                        if (TempMeas.MeasType == TcpMeasType.MEAS_TYPE_PLC)  // 处理和PLC之间的消息
                        {
                            if (TempMeas.MeasCode == (byte)Message.MessageCodePLC.GetCurStationState)
                            {
                                using (NetworkStream stream = TempMeas.Client.GetStream())
                                {
                                    TempMeas.Param[7] = GetStationCurState();       //工作站运行状态
                                    TempMeas.Param[8] = GetStationPlateState();     //物料盘的状态
                                    TempMeas.Param[TempMeas.Param.Length - 2] = MyMath.CalculateSum(TempMeas.Param, TempMeas.Param.Length); //校验和
                                    stream.Write(TempMeas.Param, 0, TempMeas.Param.Length);
                                }
                            }
                        }
                        else if (TempMeas.MeasType == TcpMeasType.MEAS_TYPE_MIS)  //处理和MIS之间的消息
                        {

                        }
                    }
                }
            }
        }

        //处理和单片机控制板的消息
        public static void ProcessArmMessage(TcpMeas meassage)
        {
            if (meassage != null)
            {
                Message.MessageCodeARM Code = (Message.MessageCodeARM)meassage.MeasCode;
                switch (Code)
                {
                    case Message.MessageCodeARM.GetOutIo:   //读取输出口缓冲区数据
                        {
                            byte data1 = meassage.Param[Message.MessageCommandIndex + 1];
                            byte data2 = meassage.Param[Message.MessageCommandIndex + 2];
                            byte data3 = meassage.Param[Message.MessageCommandIndex + 3];
                            byte data4 = meassage.Param[Message.MessageCommandIndex + 4];

                            //根据实际的接线解析所需IO的状态,对SysStat中的相应标志进行设置
                            /*
                            //气缸
                            DataStruct.SysStat.EmptyPlateUp;            //空盘气缸上升
                            DataStruct.SysStat.EmptyPlateUpArrive;      //空盘气缸上升到位
                            DataStruct.SysStat.EmptyPlateDown;          //空盘气缸下降
                            DataStruct.SysStat.EmptyPlateDownArrive;    //空盘气缸下降到位

                            //托盘
                            DataStruct.SysStat.OverturnPlateArrive;     //翻转托盘到位
                            DataStruct.SysStat.ReceivePlateArrive;      //翻转后接收托盘到位
                            */
                        }
                        break;
                    case Message.MessageCodeARM.GetInIo:    //读取输入口的IO
                        {                         
                            byte data1 = meassage.Param[Message.MessageCommandIndex + 1];
                            byte data2 = meassage.Param[Message.MessageCommandIndex + 2];
                            byte data3 = meassage.Param[Message.MessageCommandIndex + 3];
                            byte data4 = meassage.Param[Message.MessageCommandIndex + 4];

                            //根据实际的接线解析所需IO的状态,对SysStat中的相应标志进行设置

                        }
                        break;
                    default: break;
                }
            }
        }

        public static void AutoSortingRun()
        {
            //执行各动作
            switch (m_AutoRunAction)
            {
                case AutoRunAction.AuoRunStart:                 //开始
                    {
                        bool Start = false;
                        //检查各盘是否到位，都无误后 Start = true

                        if (Start)
                        {
                            m_AutoRunAction = AutoRunAction.AutoRunGetGrapCoords;
                        }                            
                    }break;
                case AutoRunAction.AutoRunGetGrapCoords:        //获得抓取坐标
                    {
                        bool Coords = false;

                        //调用视觉算法获取坐标
                        double x = 0;
                        double y = 0;
                        double z = 0;
                        double rz = 0;

                        //检查坐标范围,正确则Coords = true
                        m_Robot.SetGrapPointCoords(x, y, z, rz);
                        Coords = true;

                        if (Coords)
                            m_AutoRunAction = AutoRunAction.AutoRunMoveToGrap;
                        else
                            m_AutoRunAction = AutoRunAction.AutoRunGetGrapCoords;

                    }break;
                case AutoRunAction.AutoRunMoveToGrap:           //移动到位并抓取   
                    {
                        //移动到指定位置抓手气缸进到位，后吸起器件，上位机发指令，机械臂脚本解析，执行动作
                        //m_IO.SetRobotIo();
                        m_Robot.RunAction((short)RobotAction.Action_Grap);

                        //吸嘴真空检查，true为吸气抓取，false 为放气放下
                        if (DataStruct.SysStat.RobotVacuoCheck) //监听机器人的通信线程设置此RobotVacuoCheck
                            m_AutoRunAction = AutoRunAction.AutoRunMoveToScanQRCode;
                        else
                            m_AutoRunAction = AutoRunAction.AutoRunMoveToGrap;

                    }break;
                case AutoRunAction.AutoRunMoveToScanQRCode:     //移动到位并扫码,检查扫码格式，不正确则依然执行此动作v          
                    {                      
                        m_Robot.RunAction((short)RobotAction.Action_QRCodeScan);  //移动到位,读取二维码

                        if (m_ScanQRCode)  //二维码格式检查在QRCodeRecvData中
                            m_AutoRunAction = AutoRunAction.AutoRunMoveToPut;
                        else
                            m_AutoRunAction = AutoRunAction.AutoRunMoveToScanQRCode;
                    }break;
                case AutoRunAction.AutoRunMoveToPut:    //移动到位并放下，计数后开始下一个，满总数后下一步    
                    {
                        int TempCount = 0;
                        m_Robot.RunAction((short)RobotAction.Action_Put);

                        if (!DataStruct.SysStat.RobotVacuoCheck) //检查真空是否真的放下，真放下则TempCount+1;                        
                        {                            
                            TempCount++;
                            if (TempCount >= m_OnePanelDevicesMax)
                            {
                                m_AutoRunAction = AutoRunAction.AutoRunTurnOverPanel;
                                TempCount = 0;
                            }
                            else
                            {
                                m_AutoRunAction = AutoRunAction.AutoRunGetGrapCoords;
                            }
                        }
                        else
                        {
                            m_AutoRunAction = AutoRunAction.AutoRunMoveToPut;
                        }                                                  
                    }break;
                case AutoRunAction.AutoRunTurnOverPanel:        //计数满则翻盘运走，从头开始
                    {
                        bool TurnOver = false;
                        //设置气缸锁定器件

                        //翻转

                        //翻转成功，解锁器件，延时，通知运走
                        if (TurnOver)
                        {
                            //存储文件，通知运走
                            if (m_QRCodeStr.Count >= m_OnePanelDevicesMax) //
                            {
                                var temp = m_QRCodeStr.Distinct(); //却掉重复扫描的 
                                if (temp.Count() == m_OnePanelDevicesMax)
                                {
                                    //写入到网络共享文件中

                                    m_AutoRunAction = AutoRunAction.AuoRunStart;
                                    m_DevicesTotal += m_OnePanelDevicesMax;

                                    //清除掉之前的各到位信号，在AuoRunStart时重新检查
                                }
                            }
                        }                     
                    }break;
                default:
                    break;
            }
        }

        //获取工作站当前的运行状态
        public static byte GetStationCurState()    
        {
            StationState State = StationState.Stop;

            if (DataStruct.SysStat.Run)
                State = StationState.Run;
            else if (DataStruct.SysStat.Pause)
                State = StationState.Pause;
            else if (DataStruct.SysStat.Stop)
                State = StationState.Stop;
            else if (DataStruct.SysStat.Scram)
                State = StationState.Scram;

            return (byte)State;
        }

        public static byte GetStationPlateState()
        {
            PlateState State = PlateState.NoPlate;
            if (DataStruct.SysStat.ReceivePlateArrive)
                State = PlateState.HavePlate;

            return (byte)State;
        }

        // 0 -- run , 1 -- stop , 2 -- pause
        public static int CheckSysAlarm()
        {
            //DeviceRobot.Get_Rbt_Stat();

            // check robot
            if (DataStruct.SysAlarm.Robot >= 1)
            {
                if (DataStruct.SysAlarm.Robot == 2)
                {
                    DataStruct.SysStat.RedAlarm = true;
                }
                else if (DataStruct.SysAlarm.Robot == 1)
                {
                    DataStruct.SysStat.YellowAlarm = true;
                }
                DataStruct.SysStat.Robot = 1;
            }

            //check camera
            if (DataStruct.SysAlarm.Camera == 1)
            {
                DataStruct.SysStat.Camera = 1;
                DataStruct.SysStat.RedAlarm = true;
            }

            //check QRCode
            if (DataStruct.SysAlarm.QRCode == 1)
            {
                DataStruct.SysStat.QRCode = 1;
                DataStruct.SysStat.RedAlarm = true;
            }

            //check RFID
            if (DataStruct.SysAlarm.RFID == 1)
            {
                DataStruct.SysStat.RFID = 1;
                DataStruct.SysStat.RedAlarm = true;
            }

            //check PLC

            //check IO Control Board


            if ((!DataStruct.SysStat.YellowAlarm) && (!DataStruct.SysStat.RedAlarm))
                return 0;
            else if (DataStruct.SysStat.YellowAlarm && !DataStruct.SysStat.RedAlarm)
                return 1;
            else if (DataStruct.SysStat.RedAlarm && !DataStruct.SysStat.YellowAlarm)
                return 2;
            else
                return 3;
        }

        //Alarm type , 0 = Green ; 1 = Yellow ; 2 = Red ; 3 = Red & Yellow
        public static void SetSysAlarm(byte AlarmType)
        {
            if (AlarmType == 0)
            {
                m_IO.SetControlBoardIo(IOType.IOTypeLedGreen, IOValue.IOValueHigh);
                m_IO.SetControlBoardIo(IOType.IOTypeLedYellow, IOValue.IOValueLow);
                m_IO.SetControlBoardIo(IOType.IOTypeLedRed, IOValue.IOValueLow);
            }
            else if (AlarmType == 1)
            {
                m_IO.SetControlBoardIo(IOType.IOTypeLedGreen, IOValue.IOValueLow);
                m_IO.SetControlBoardIo(IOType.IOTypeLedYellow, IOValue.IOValueHigh);
                m_IO.SetControlBoardIo(IOType.IOTypeLedRed, IOValue.IOValueLow);
            }
            else if (AlarmType == 2)
            {
                m_IO.SetControlBoardIo(IOType.IOTypeLedGreen, IOValue.IOValueLow);
                m_IO.SetControlBoardIo(IOType.IOTypeLedYellow, IOValue.IOValueLow);
                m_IO.SetControlBoardIo(IOType.IOTypeLedRed, IOValue.IOValueHigh);
            }
            else if (AlarmType == 3)
            {
                m_IO.SetControlBoardIo(IOType.IOTypeLedGreen, IOValue.IOValueLow);
                m_IO.SetControlBoardIo(IOType.IOTypeLedYellow, IOValue.IOValueHigh);
                m_IO.SetControlBoardIo(IOType.IOTypeLedRed, IOValue.IOValueHigh);
            }
        }

        public static void QRCodeRecvData(object sender, EventArgs e)
        {
            if (e is QRCodeEventArgers)
            {
                QRCodeEventArgers Temp = e as QRCodeEventArgers;
                bool Check = CheckAndSaveReadData(Temp.QRCodeRecv);
                if (Check)
                    m_ScanQRCode = true;
                else
                    m_ScanQRCode = false;                
            }
        }

        //校验读取数据的准确性
        public static bool CheckAndSaveReadData(string Code)
        {
            bool Check = false;
            string temp = String.Copy(Code);

            //检查读取到的数据格式是否正确 “24个，12个，12个”KR12BN5901313ABPVKBF0238,00C3F413543E,00C3F413543F
            const char SplitChar = ',';         
            var StrAfterSplit = temp.Split(SplitChar);
            if (StrAfterSplit.Length == 3 && StrAfterSplit[0].Length == 24 && StrAfterSplit[1].Length == 12 && StrAfterSplit[2].Length == 12)
            {
                Check = true;
                m_QRCodeStr.Add(Code);
            }

            return Check;
        } 
    }
}
