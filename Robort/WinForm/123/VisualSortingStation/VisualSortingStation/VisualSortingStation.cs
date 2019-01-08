using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RobotWorkstation
{
    public enum RobotAction  //Action_Auto_Visual_Grap是视觉抓取和视觉放置时所用的索引，具体看使用的地方
    {
        Action_Go_Home = 0,
        Action_Manual_Grap_1,
        Action_Manual_Grap_2,
        Action_Manual_Grap_3,
        Action_Manual_Grap_4,
        Action_Manual_Grap_5,
        Action_Manual_Grap_6,
        Action_Manual_Grap_7,
        Action_Manual_Grap_8,
        Action_Manual_Grap_9,
        Action_Manual_Grap_10,
        Action_Manual_Grap_11,
        Action_Manual_Grap_12,
        Action_Manual_Grap_13,
        Action_Manual_Grap_14,
        Action_Manual_Grap_15,
        Action_Manual_Grap_16,
        Action_Visual_Grap,

        Action_QRCodeScan,

        Action_Manual_Put_1,
        Action_Manual_Put_2,
        Action_Manual_Put_3,
        Action_Manual_Put_4,
        Action_Manual_Put_5,
        Action_Manual_Put_6,
        Action_Manual_Put_7,
        Action_Manual_Put_8,
        Action_Manual_Put_9,
        Action_Manual_Put_10,
        Action_Manual_Put_11,
        Action_Manual_Put_12,
        Action_Manual_Put_13,
        Action_Manual_Put_14,
        Action_Manual_Put_15,
        Action_Manual_Put_16,
        Action_Visual_Put,
        
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
        private static int m_TempCount = 0;
        private const int m_OnePanelDevicesMax = 16;
        private static AutoRunAction m_AutoRunAction = AutoRunAction.AuoRunStart;
        private volatile static bool m_ShouldExit = false;
        private static bool m_GetNextGrapPoint = false;

        private static RobotDevice m_Robot = RobotDevice.GetInstance();
        private static short[] m_RobotRead = new short[RobotBase.MODBUS_RD_LEN];
        private static RFID m_RFID = RFID.GetInstance();
        public static string m_RfidRead = "";
        private static QRCode m_QRCode = QRCode.GetInstance();
        public static bool m_ScanQRCode = false;
        public static List<string> m_QRCodeStr = new List<string>();

        //Tcp
        private static MyTcpClient m_MyTcpClientArm = MainForm.GetMyTcpClientArm();
        private static MyTcpClient m_MyTcpClientCamera = MainForm.GetMyTcpClientCamera();
        private static MyTcpServer m_MyTcpServer = MyTcpServer.GetInstance();
        private static byte[] SendMeas = new byte[Message.MessageLength];
        
        //网络共享文件
        private static NsfTrayModule m_NsfTrayModuleFile = NsfTrayModule.GetInstance();
        private static NetShare m_NetShare = NetShare.GetInstance();
        private static string m_CreateShare = "CreateShare.bat";

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

                //作为客户端处理和单片机控制板、相机的消息队列
                if ((m_MyTcpClientArm != null && m_MyTcpClientArm.IsConnected) || (m_MyTcpClientCamera != null && m_MyTcpClientCamera.IsConnected))
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
                m_Robot.ReadMulitModbus(RobotBase.MODBUS_RD_ADDR, ReadLen, ref m_RobotRead);

                //校验协议，并给DataStruct.SysStat中的各状态赋值
                if (Message.CheckRobotMessage(m_RobotRead, ReadLen))
                {
                    m_Robot.ClearModbusReadAddr();

                    Robot_IO_IN Io = (Robot_IO_IN)m_RobotRead[5];
                    IOValue IoState = (IOValue)m_RobotRead[6];
                    switch (Io)
                    {
                        case Robot_IO_IN.Robot_IO_IN_CylGoArrive: //抓手气缸进到位，正确在机械臂处理，错误在上位机处理进行重试
                            {
                                if (IoState == IOValue.IOValueHigh)
                                    DataStruct.SysStat.RobotCylGoArrive = true;
                                else
                                    DataStruct.SysStat.RobotCylGoArrive = false;
                            }
                            break;
                        case Robot_IO_IN.Robot_IO_IN_CylBackArrive: //抓手气缸退到位，正确在机械臂处理，错误在上位机处理进行重试
                            {
                                if (IoState == IOValue.IOValueHigh)
                                    DataStruct.SysStat.RobotCylBackArrive = true;
                                else
                                    DataStruct.SysStat.RobotCylBackArrive = false;
                            }
                            break;
                        case Robot_IO_IN.Robot_IO_IN_VacuoCheck: //吸嘴真空检测
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
            if (m_MyTcpClientArm != null && m_MyTcpClientArm.IsConnected)
            {
                while (m_MyTcpClientArm.m_RecvMeasQueue.Count != 0)
                {
                    TcpMeas TempMeas = m_MyTcpClientArm.m_RecvMeasQueue.Dequeue();
                    if (TempMeas != null && TempMeas.Client != null)
                    {
                        if (TempMeas.MeasType == TcpMeasType.MEAS_TYPE_ARM)  // 处理和ARM之间的消息
                        {
                            ProcessArmMessage(TempMeas);
                        }
                    }
                }
            }

            if (m_MyTcpClientCamera != null && m_MyTcpClientCamera.IsConnected)
            {
                while (m_MyTcpClientCamera.m_RecvMeasQueue.Count != 0)
                {
                    TcpMeas TempMeas = m_MyTcpClientCamera.m_RecvMeasQueue.Dequeue();
                    if (TempMeas != null && TempMeas.Client != null)
                    {
                        if (TempMeas.MeasType == TcpMeasType.MEAS_TYPE_CAMERA)  // 处理和相机之间的消息
                        {
                            ProcessCameraMessage(TempMeas);
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

        //处理和相机机控制板的消息
        public static void ProcessCameraMessage(TcpMeas meassage)
        {
            if (meassage != null)
            {
                Message.MessageCodeCamera Code = (Message.MessageCodeCamera)meassage.MeasCode;
                switch (Code)
                {
                    case Message.MessageCodeCamera.GetCameraCoords:
                        {
                            bool Coords = true;

                            float x = BitConverter.ToSingle(meassage.Param, Message.MessageCommandIndex + 1);
                            float y = BitConverter.ToSingle(meassage.Param, Message.MessageCommandIndex + 5);
                            float z = BitConverter.ToSingle(meassage.Param, Message.MessageCommandIndex + 9);
                            float rz = BitConverter.ToSingle(meassage.Param, Message.MessageCommandIndex + 13);

                            //检查坐标范围,正确则Coords = true
                            if (Coords)
                            {
                                if (meassage.Param[Message.MessageCommandIndex + 2] == Message.MessCameraGrapPoint)  //抓取点
                                {
                                    m_Robot.SetGrapPointCoords(RobotDevice.m_VisualGrapStartPoint + (RobotAction.Action_Visual_Grap - RobotAction.Action_Manual_Grap_1), x, y, z, rz);
                                }
                                else if (meassage.Param[Message.MessageCommandIndex + 2] == Message.MessCameraPutPoint)  //放置点
                                {
                                    m_Robot.SetGrapPointCoords(RobotDevice.m_VisualPutStartPoint + (RobotAction.Action_Visual_Put - RobotAction.Action_Manual_Put_1), x, y, z, rz);
                                    m_AutoRunAction = AutoRunAction.AutoRunMoveToGrap;
                                    m_GetNextGrapPoint = true;
                                }
                            }
                            else
                            {
                                m_AutoRunAction = AutoRunAction.AutoRunGetGrapCoords;
                            }                              
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        public static void AutoSortingRun()
        {
            SortMode CurSortMode = Profile.m_Config.SelectedSortMode;  //获取当前抓取模式

            //执行各动作
            switch (m_AutoRunAction)
            {
                case AutoRunAction.AuoRunStart:                 //开始
                    {
                        bool Start = false;
                        //检查各盘是否到位，都无误后 Start = true

                        if (Start)
                        {
                            m_GetNextGrapPoint = false;

                            if (CurSortMode == SortMode.SortWithVisual)
                                m_AutoRunAction = AutoRunAction.AutoRunGetGrapCoords;
                            else if (CurSortMode == SortMode.SortWithNoVisual)
                                m_AutoRunAction = AutoRunAction.AutoRunMoveToGrap;                         
                        }                            
                    }break;
                case AutoRunAction.AutoRunGetGrapCoords:        //获得抓取坐标
                    {
                        if (m_MyTcpClientCamera != null && m_MyTcpClientCamera.IsConnected)
                        {
                            Message.MakeSendArrayByCode((byte)Message.MessageCodeCamera.GetCameraCoords, ref SendMeas);
                            if (m_GetNextGrapPoint)
                                SendMeas[Message.MessageCommandIndex + 1] = Message.MessCameraPutPoint;

                            string StrSend = BitConverter.ToString(SendMeas);
                            m_MyTcpClientCamera.ClientWrite(StrSend);
                        }
                    }break;
                case AutoRunAction.AutoRunMoveToGrap:           //移动到位并抓取   
                    {
                        Debug.Assert(m_TempCount <= m_OnePanelDevicesMax);

                        //移动到指定位置抓手气缸进到位，后吸起器件，上位机发指令，机械臂脚本解析，执行动作
                        //m_IO.SetRobotIo();
                        if(CurSortMode == SortMode.SortWithVisual)
                            m_Robot.RunAction((short)RobotAction.Action_Visual_Grap);
                        else if (CurSortMode == SortMode.SortWithNoVisual)
                            m_Robot.RunAction((short)RobotAction.Action_Manual_Grap_1 + m_TempCount);

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
                        Debug.Assert(m_TempCount <= m_OnePanelDevicesMax);

                        if (CurSortMode == SortMode.SortWithVisual)
                            m_Robot.RunAction((short)RobotAction.Action_Visual_Put);
                        else if (CurSortMode == SortMode.SortWithNoVisual)
                            m_Robot.RunAction((short)RobotAction.Action_Manual_Put_1 + m_TempCount);

                        if (!DataStruct.SysStat.RobotVacuoCheck) //检查真空是否真的放下，真放下则TempCount+1;                        
                        {
                            m_TempCount++;
                            if (m_TempCount >= m_OnePanelDevicesMax)
                            {
                                m_AutoRunAction = AutoRunAction.AutoRunTurnOverPanel;
                                m_TempCount = 0;
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
                                List<string> QRCodeTemp = m_QRCodeStr.Distinct().ToList(); //却掉重复扫描的 
                                if (QRCodeTemp.Count() == m_OnePanelDevicesMax)
                                {
                                    //检查共享文件夹是否存在，存在则直接存储文件，不存在则创建共享文件夹
                                    if (!Directory.Exists(NsfTrayModule.m_FileFolder))
                                    {
                                        Directory.CreateDirectory(NsfTrayModule.m_FileFolder);
                                        m_NetShare.CallShareBatFile(m_CreateShare);
                                    }

                                    //创建共享文件.xml,并写入到文件中
                                    int TrayNum = m_DevicesTotal / m_OnePanelDevicesMax + 1;  //当前测试为第几盘
                                    bool Re = m_NsfTrayModuleFile.CreateAndWriteFile(QRCodeTemp, TrayNum);
                                    if (Re)
                                    {
                                        m_AutoRunAction = AutoRunAction.AuoRunStart;
                                        m_DevicesTotal += m_OnePanelDevicesMax;

                                        //清除掉之前的各到位信号，在AuoRunStart时重新检查

                                        //通知运走
                                    }


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
                m_IO.SetControlBoardIo(IO_OUT.IO_OUT_LedGreen, IOValue.IOValueHigh);
                m_IO.SetControlBoardIo(IO_OUT.IO_OUT_LedYellow, IOValue.IOValueLow);
                m_IO.SetControlBoardIo(IO_OUT.IO_OUT_LedRed, IOValue.IOValueLow);
            }
            else if (AlarmType == 1)
            {
                m_IO.SetControlBoardIo(IO_OUT.IO_OUT_LedGreen, IOValue.IOValueLow);
                m_IO.SetControlBoardIo(IO_OUT.IO_OUT_LedYellow, IOValue.IOValueHigh);
                m_IO.SetControlBoardIo(IO_OUT.IO_OUT_LedRed, IOValue.IOValueLow);
            }
            else if (AlarmType == 2)
            {
                m_IO.SetControlBoardIo(IO_OUT.IO_OUT_LedGreen, IOValue.IOValueLow);
                m_IO.SetControlBoardIo(IO_OUT.IO_OUT_LedYellow, IOValue.IOValueLow);
                m_IO.SetControlBoardIo(IO_OUT.IO_OUT_LedRed, IOValue.IOValueHigh);
            }
            else if (AlarmType == 3)
            {
                m_IO.SetControlBoardIo(IO_OUT.IO_OUT_LedGreen, IOValue.IOValueLow);
                m_IO.SetControlBoardIo(IO_OUT.IO_OUT_LedYellow, IOValue.IOValueHigh);
                m_IO.SetControlBoardIo(IO_OUT.IO_OUT_LedRed, IOValue.IOValueHigh);
            }
        }

        public static void QRCodeRecvData(object sender, EventArgs e)
        {
            if (e is QRCodeEventArgers)
            {
                QRCodeEventArgers Temp = e as QRCodeEventArgers;
                bool Check = CheckAndSaveQRCodeReadData(Temp.QRCodeRecv);
                if (Check)
                    m_ScanQRCode = true;
                else
                    m_ScanQRCode = false;                
            }
        }

        //校验读取数据的准确性
        public static bool CheckAndSaveQRCodeReadData(string Code)
        {
            bool Check = false;

            char[] EndChar = {'\r', '\n'};
            Code = Code.TrimEnd(EndChar);  //去掉结尾符
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
