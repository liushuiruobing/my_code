#define DebugTest

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Threading;



namespace RobotWorkstation
{
    public enum Key
    {
        Key_Run = 0,
        Key_Pause,
        Key_Stop,
        Key_Reset
    }

    public enum VisualAction
    {
        Visual_GrapPoint = 0x00,
        Visual_QRCodeScanPoint,
        Visual_PutPoint,
        Visual_RunCamera,  //让视觉拍照计算

        Visual_Error = 0x10,  //视觉出现错误
    }

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

        Action_Visual_SetPoint,

    }
	
    public enum AutoRunAction
    {
        AuoRunNone = 0,
        AuoRunStart,                        //开始
        AutoRunGetGrapCoords,               //获得抓取坐标
        AutoRunMoveToGrap,                  //移动到位并抓取
        AutoRunMoveToScanQRCode,            //移动到位并扫码,检查扫码格式，不正确则依然执行此动作
        AutoRunMoveToPut,                   //移动到位并放下，计数后开始下一件，满总数后下一步
        AutoRunLockDevices,                 //计数满则,控制翻转盘气缸锁定器件
        AutoRunTurnOverSalver,              //翻盘托盘
        AutoRunUnLockDevices,               //翻转成功则，控制托盘气缸解锁器件
        AutoRunTransportReceiveSalver       //运走接收盘
    }

    public enum StationState  //工作站状态
    {
        Stop = 0x00,
        Run,
        Pause,
        Reset  
    }

    public enum SalverState  //托盘状态
    {
        NoSalver = 0x00,
        HaveSalver,
    }

    public class VisualSortingStation  //视觉分拣业务类
    {
<<<<<<< HEAD
        public static ArmControler m_ArmControler = ArmControler.GetInstance();
=======
        public static IO m_IO = IO.GetInstance();
>>>>>>> 2e99c703d89de6b5ce7fc31142d09201938502a8
        public const int m_OnePanelDevicesMax = 16;
        private static int m_DevicesTotal = 0;
        private static int m_TempCount = 0;
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
        private static SysAlarm m_SysAlarm = SysAlarm.GetInstance();

        //Tcp
        private static MyTcpClient m_MyTcpClientArm = MainForm.GetMyTcpClientArm();
        private static MyTcpClient m_MyTcpClientCamera = MainForm.GetMyTcpClientCamera();
        private static MyTcpServer m_MyTcpServer = MyTcpServer.GetInstance();
        private static byte[] m_SendMeas = new byte[Message.MessageLength];
        private static byte[] m_IoInValue = new byte[4];  //ARM控制板IO输入的缓存 4个byte，每位代表1个IO，共32个

        //网络共享文件
        private static NsfTrayModule m_NsfTrayModuleFile = NsfTrayModule.GetInstance();

        //视觉
        public const byte MessCameraCurrentPoint = 0x00;
        public const byte MessCameraNextPoint = 0x01;
        private static short[] m_VisualCoords = new short[24];  //记录抓取点、二维码扫描点、放置点x,y,z,rz

        //线程
        private static Thread m_MainThread = null;
        public static ManualResetEvent m_MainThreadEvent = new ManualResetEvent(false);
        private static Thread m_MeassageProcessThread = null;
              
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

        public static void CreateAllThread()
        {
            //创建主线程
            m_MainThread = new Thread(new ThreadStart(VisualSortingStation.MainThreadFunc));
            m_MainThread.IsBackground = true;
            m_MainThread.Start();

            //创建消息处理线程
            m_MeassageProcessThread = new Thread(new ThreadStart(VisualSortingStation.MessageProcessThreadFunc));
            m_MeassageProcessThread.IsBackground = true;
            m_MeassageProcessThread.Start();
        }

        public static void MainThreadFunc()
        {
            m_QRCodeStr.Clear();
            m_QRCode.QRCodeRecvDataEvent += new EventHandler(QRCodeRecvData);

            while (!m_ShouldExit)
            {
                m_MainThreadEvent.WaitOne();

                if (DataStruct.SysStat.Run)
                    AutoSortingRun();

                Thread.Sleep(0);  //Sleep(0),则线程会将时间片的剩余部分让给任何已经准备好的具有同等优先级的线程

<<<<<<< HEAD
                Debug.WriteLine("MainThreadFunc Runing...");
=======
                Thread.Sleep(0);  //Sleep(0),则线程会将时间片的剩余部分让给任何已经准备好的具有同等优先级的线程
>>>>>>> 2e99c703d89de6b5ce7fc31142d09201938502a8
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
                if (m_RFID != null && m_RFID.IsConnected)
                    ProcessRFIDMessage();

                //作为客户端处理和单片机控制板、相机的消息队列
                if ((m_MyTcpClientArm != null && m_MyTcpClientArm.IsConnected) || (m_MyTcpClientCamera != null && m_MyTcpClientCamera.IsConnected))
                    ProcessTcpClientMessage();

                //作为服务端处理和MIS及PLC之间的消息
                if (m_MyTcpServer != null)
                    ProcessTcpServerMessage();

                Thread.Sleep(0);
            }

            if (m_ShouldExit)
            {
                if (m_MyTcpClientArm != null)
                    m_MyTcpClientArm.Close();

                if (m_MyTcpClientCamera != null)
                    m_MyTcpClientCamera.Close();
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
                                {
                                    DataStruct.SysStat.RobotVacuoCheck = true; //吸起
                                    m_AutoRunAction = AutoRunAction.AutoRunMoveToScanQRCode;
                                }
                                else
                                {
                                    DataStruct.SysStat.RobotVacuoCheck = false; //放下

                                    RunForm.m_GrapAndPutCount = m_TempCount;
                                    m_TempCount++;
                                    
                                    if (m_TempCount >= m_OnePanelDevicesMax)
                                    {
                                        m_AutoRunAction = AutoRunAction.AutoRunLockDevices;
                                        m_TempCount = 0;
                                    }
                                    else
                                    {
                                        m_AutoRunAction = AutoRunAction.AutoRunGetGrapCoords;
                                    }

                                    DataStruct.SysStat.GrapAndPutOneSuccessed = true;
                                }
                            }
                            break;
                        case Robot_IO_IN.Robot_WritePointSuccessed:  //机械臂写点位信息成功
                            {
                                if (IoState == IOValue.IOValueHigh)
                                    m_AutoRunAction = AutoRunAction.AutoRunMoveToGrap;
                                else
                                    m_AutoRunAction = AutoRunAction.AuoRunNone;
                            }break;
                        default:
                            break;
                    }
                }
            }
        }

        public static void ProcessRFIDMessage()
        {
            if (m_RFID != null && m_RFID.IsConnected)
            {
                m_RFID.Read(m_RFID.m_CurCh);
                Thread.Sleep(1);
                if (m_RFID.m_QueueRead.Count > 0)
                {
                    m_RfidRead = m_RFID.m_QueueRead.Dequeue();  //读取到盘，并设置盘到位

                    //检查数据格式正确，则设置标志
                    DataStruct.SysStat.ReceiveSalverArrive = true;
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
                                NetworkStream stream = TempMeas.Client.GetStream();

                                TempMeas.Param[7] = GetStationCurState();        //工作站运行状态
                                TempMeas.Param[8] = GetStationSalverState();     //物料盘的状态
                                TempMeas.Param[TempMeas.Param.Length - 2] = MyMath.CalculateSum(TempMeas.Param, TempMeas.Param.Length); //校验和
                                stream.Write(TempMeas.Param, 0, TempMeas.Param.Length);
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
                    case Message.MessageCodeARM.GetOutput:   //读取输出口缓冲区数据
                        {
                            byte data1 = meassage.Param[Message.MessageCommandIndex + 1];
                            byte data2 = meassage.Param[Message.MessageCommandIndex + 2];
                            byte data3 = meassage.Param[Message.MessageCommandIndex + 3];
                            byte data4 = meassage.Param[Message.MessageCommandIndex + 4];

                            //根据实际的接线解析所需IO的状态,对SysStat中的相应标志进行设置
                            /*
                            DataStruct.SysStat.EmptySalverAirCylUpArrive;           //空盘气缸上升到位
                            DataStruct.SysStat.EmptySalverAirCylDownArrive;         //空盘气缸下降到位
                            DataStruct.SysStat.OverturnSalverArrive;                //翻转托盘到位
                            DataStruct.SysStat.OverturnSalverAirCylGoArrive;        //翻转托盘锁定气缸进到位
                            DataStruct.SysStat.OverturnSalverAirCylBackArrive;      //翻转托盘锁定气缸退到位
                            DataStruct.SysStat.ReceiveSalverArrive;                 //翻转后接收托盘到位
                            */
                        }
                        break;
<<<<<<< HEAD
                    case Message.MessageCodeARM.GetInput:    //读取输入口的IO
=======
                    case Message.MessageCodeARM.GetInIo:    //读取输入口的IO
>>>>>>> 2e99c703d89de6b5ce7fc31142d09201938502a8
                        {
                           for (int i = 0; i < m_IoInValue.Length; i++)
                           {
                                m_IoInValue[i] = meassage.Param[(Message.MessageCommandIndex + 1) + i];
                           }

                           ProcessArmIoIn(m_IoInValue);
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
                            int CoordsStartIndex = Message.MessageCommandIndex + 3;   //参数从     Message.MessageCommandIndex + 3之后放置                  

                            //检查坐标范围,正确则Coords = true
                            if (Coords)
                            {
                                if (meassage.Param[Message.MessageCommandIndex + 2] == (byte)VisualAction.Visual_GrapPoint)  //抓取点
                                {
                                    m_VisualCoords[0] = (short)((meassage.Param[CoordsStartIndex + 1] << 8) + (meassage.Param[CoordsStartIndex + 0] & 0x00FF));
                                    m_VisualCoords[1] = (short)((meassage.Param[CoordsStartIndex + 3] << 8) + (meassage.Param[CoordsStartIndex + 2] & 0x00FF));

                                    m_VisualCoords[2] = (short)((meassage.Param[CoordsStartIndex + 5] << 8) + (meassage.Param[CoordsStartIndex + 4] & 0x00FF));
                                    m_VisualCoords[3] = (short)((meassage.Param[CoordsStartIndex + 7] << 8) + (meassage.Param[CoordsStartIndex + 6] & 0x00FF));

                                    m_VisualCoords[4] = (short)((meassage.Param[CoordsStartIndex + 9] << 8) + (meassage.Param[CoordsStartIndex + 8] & 0x00FF));
                                    m_VisualCoords[5] = (short)((meassage.Param[CoordsStartIndex + 11] << 8) + (meassage.Param[CoordsStartIndex + 10] & 0x00FF));

                                    m_VisualCoords[6] = (short)((meassage.Param[CoordsStartIndex + 13] << 8) + (meassage.Param[CoordsStartIndex + 12] & 0x00FF));
                                    m_VisualCoords[7] = (short)((meassage.Param[CoordsStartIndex + 15] << 8) + (meassage.Param[CoordsStartIndex + 14] & 0x00FF));

#if DebugTest
                                    int GrapX = (m_VisualCoords[1] << 16) + (m_VisualCoords[0] & 0x0000ffff);
                                    int Grapy = (m_VisualCoords[3] << 16) + (m_VisualCoords[2] & 0x0000ffff);
                                    int Grapz = (m_VisualCoords[5] << 16) + (m_VisualCoords[4] & 0x0000ffff);
                                    int Graprz = (m_VisualCoords[7] << 16) + (m_VisualCoords[6] & 0x0000ffff);
                                    string StrCoords = "Grap Point" + "X: " + GrapX.ToString() + "   Y: " + Grapy.ToString() + "   Z: " + Grapz.ToString() + "  RZ: " + Graprz.ToString();
                                    Debug.WriteLine(StrCoords);
#endif
                                    GetVisualCoords((int)VisualAction.Visual_QRCodeScanPoint, m_TempCount);   //Visual_QRCodeScanPoint
                                }
                                else if (meassage.Param[Message.MessageCommandIndex + 2] == (byte)VisualAction.Visual_QRCodeScanPoint)  //二维码扫描点
                                {
                                    m_VisualCoords[8] = (short)((meassage.Param[CoordsStartIndex + 1] << 8) + (meassage.Param[CoordsStartIndex + 0] & 0x00FF));
                                    m_VisualCoords[9] = (short)((meassage.Param[CoordsStartIndex + 3] << 8) + (meassage.Param[CoordsStartIndex + 2] & 0x00FF));

                                    m_VisualCoords[10] = (short)((meassage.Param[CoordsStartIndex + 5] << 8) + (meassage.Param[CoordsStartIndex + 4] & 0x00FF));
                                    m_VisualCoords[11] = (short)((meassage.Param[CoordsStartIndex + 7] << 8) + (meassage.Param[CoordsStartIndex + 6] & 0x00FF));

                                    m_VisualCoords[12] = (short)((meassage.Param[CoordsStartIndex + 9] << 8) + (meassage.Param[CoordsStartIndex + 8] & 0x00FF));
                                    m_VisualCoords[13] = (short)((meassage.Param[CoordsStartIndex + 11] << 8) + (meassage.Param[CoordsStartIndex + 10] & 0x00FF));

                                    m_VisualCoords[14] = (short)((meassage.Param[CoordsStartIndex + 13] << 8) + (meassage.Param[CoordsStartIndex + 12] & 0x00FF));
                                    m_VisualCoords[15] = (short)((meassage.Param[CoordsStartIndex + 15] << 8) + (meassage.Param[CoordsStartIndex + 14] & 0x00FF));

#if DebugTest
                                    int ScanX = (m_VisualCoords[9] << 16) + (m_VisualCoords[8] & 0x0000ffff);
                                    int Scany = (m_VisualCoords[11] << 16) + (m_VisualCoords[10] & 0x0000ffff);
                                    int Scanz = (m_VisualCoords[13] << 16) + (m_VisualCoords[12] & 0x0000ffff);
                                    int Scanrz = (m_VisualCoords[15] << 16) + (m_VisualCoords[14] & 0x0000ffff);

                                    string StrCoords = "QRCode Scan Point" + "X: " + ScanX.ToString() + "   Y: " + Scany.ToString() + "   Z: " + Scanz.ToString() + "  RZ: " + Scanrz.ToString();
                                    Debug.WriteLine(StrCoords);
#endif
                                    GetVisualCoords((int)VisualAction.Visual_PutPoint, m_TempCount);   //Visual_QRCodeScanPoint
                                }
                                else if (meassage.Param[Message.MessageCommandIndex + 2] == (byte)VisualAction.Visual_PutPoint)  //放置点
                                {
                                    m_VisualCoords[16] = (short)((meassage.Param[CoordsStartIndex + 1] << 8) + (meassage.Param[CoordsStartIndex + 0] & 0x00FF));
                                    m_VisualCoords[17] = (short)((meassage.Param[CoordsStartIndex + 3] << 8) + (meassage.Param[CoordsStartIndex + 2] & 0x00FF));

                                    m_VisualCoords[18] = (short)((meassage.Param[CoordsStartIndex + 5] << 8) + (meassage.Param[CoordsStartIndex + 4] & 0x00FF));
                                    m_VisualCoords[19] = (short)((meassage.Param[CoordsStartIndex + 7] << 8) + (meassage.Param[CoordsStartIndex + 6] & 0x00FF));

                                    m_VisualCoords[20] = (short)((meassage.Param[CoordsStartIndex + 9] << 8) + (meassage.Param[CoordsStartIndex + 8] & 0x00FF));
                                    m_VisualCoords[21] = (short)((meassage.Param[CoordsStartIndex + 11] << 8) + (meassage.Param[CoordsStartIndex + 10] & 0x00FF));

                                    m_VisualCoords[22] = (short)((meassage.Param[CoordsStartIndex + 13] << 8) + (meassage.Param[CoordsStartIndex + 12] & 0x00FF));
                                    m_VisualCoords[23] = (short)((meassage.Param[CoordsStartIndex + 15] << 8) + (meassage.Param[CoordsStartIndex + 14] & 0x00FF));

                                    int GrapPointIndex = RobotDevice.m_VisualGrapStartPoint + (RobotAction.Action_Visual_Grap - RobotAction.Action_Go_Home);
                                    int QrCodeScanPointIndex = RobotDevice.m_QRCodePoint;
                                    int PutPointIndex = RobotDevice.m_VisualPutStartPoint + (RobotAction.Action_Visual_Put - RobotAction.Action_Manual_Put_1);

                                    //给机械臂发送点位信息
                                    m_Robot.SetPointParamByModbus((short)RobotAction.Action_Visual_SetPoint, (short)GrapPointIndex, (short)QrCodeScanPointIndex, (short)PutPointIndex, m_VisualCoords);
                                    m_GetNextGrapPoint = true;
#if DebugTest
                                    int PutX = (m_VisualCoords[17] << 16) + (m_VisualCoords[16] & 0x0000ffff);
                                    int Puty = (m_VisualCoords[19] << 16) + (m_VisualCoords[18] & 0x0000ffff);
                                    int Putz = (m_VisualCoords[21] << 16) + (m_VisualCoords[20] & 0x0000ffff);
                                    int Putrz = (m_VisualCoords[23] << 16) + (m_VisualCoords[22] & 0x0000ffff);

                                    string StrCoords = "Put Point" + "X: " + PutX.ToString() + "   Y: " + Puty.ToString() + "   Z: " + Putz.ToString() + "  RZ: " + Putrz.ToString();
                                    Debug.WriteLine(StrCoords);
#endif
                                }
                                else if (meassage.Param[Message.MessageCommandIndex + 2] == (byte)VisualAction.Visual_Error)  //视觉出现错误
                                {
#if DebugTest
                                    System.Windows.Forms.MessageBox.Show("视觉出现错误！");
#endif
                                    DataStruct.SysStat.Camera = 1;
                                    m_SysAlarm.SetAlarm(SysAlarm.Type.Camera, true);
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

#if DebugTest  //测试执行时间
        public static DateTime T1 = DateTime.Now;
        public static DateTime T2 = DateTime.Now;
        public static DateTime T3 = DateTime.Now;
        public static DateTime T4 = DateTime.Now;
#endif

        public static void AutoSortingRun()
        {
            SortMode CurSortMode = Profile.m_Config.SelectedSortMode;  //获取当前抓取模式

            //执行各动作
            switch (m_AutoRunAction)
            {
                case AutoRunAction.AuoRunStart:                 //开始
                    {
                        bool Start = true;
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
#if DebugTest
                        T1 = DateTime.Now;
                        if (m_TempCount > 0)
                            Debug.WriteLine("T1 - T4:  " + (T1 - T4).TotalMilliseconds);
#endif
                        if (m_MyTcpClientCamera != null && m_MyTcpClientCamera.IsConnected)
                        {
                            GetVisualCoords((int)VisualAction.Visual_GrapPoint, m_TempCount);   //Visual_QRCodeScanPoint  和 Visual_PutPoint在ProcessCameraMessage中获取
                            m_AutoRunAction = AutoRunAction.AuoRunNone;
                        }
                    }break;
                case AutoRunAction.AutoRunMoveToGrap:           //移动到位并抓取   
                    {
#if DebugTest
                        T2 = DateTime.Now;
                        Debug.WriteLine("T2:  " + (T2 - T1).TotalMilliseconds);
                        if(m_TempCount > 0)
                            Debug.WriteLine("T2 - T4:  " + (T2 - T4).TotalMilliseconds);
#endif
                        Debug.Assert(m_TempCount <= m_OnePanelDevicesMax);

                        //移动到指定位置抓手气缸进到位，后吸起器件，上位机发指令，机械臂脚本解析，执行动作
                        if(CurSortMode == SortMode.SortWithVisual)
                            m_Robot.RunAction((short)RobotAction.Action_Visual_Grap);
                        else if (CurSortMode == SortMode.SortWithNoVisual)
                            m_Robot.RunAction((short)RobotAction.Action_Manual_Grap_1 + m_TempCount);

                        m_AutoRunAction = AutoRunAction.AuoRunNone;
                    }break;
                case AutoRunAction.AutoRunMoveToScanQRCode:     //移动到位并扫码,检查扫码格式，不正确则依然执行此动作v          
                    {
#if DebugTest
                        T3 = DateTime.Now;
                        Debug.WriteLine("T3:  " + (T3 - T2).TotalMilliseconds);
#endif
                        m_Robot.RunAction((short)RobotAction.Action_QRCodeScan);  //移动到位,读取二维码
                        m_AutoRunAction = AutoRunAction.AuoRunNone;
                    }
                    break;
                case AutoRunAction.AutoRunMoveToPut:    //移动到位并放下，计数后开始下一个，满总数后下一步    
                    {
#if DebugTest
                        T4 = DateTime.Now;
                        Debug.WriteLine("T4:  " + (T4 - T3).TotalMilliseconds);
#endif
                        Debug.Assert(m_TempCount <= m_OnePanelDevicesMax);
                        if (m_TempCount == m_OnePanelDevicesMax - 1)
                        {
                            GetVisualCoords((int)VisualAction.Visual_RunCamera, 0);  //下一盘时
                        }
                        else
                        {
                            GetVisualCoords((int)VisualAction.Visual_RunCamera, m_TempCount + 1);
                        }

                        if (CurSortMode == SortMode.SortWithVisual)
                            m_Robot.RunAction((short)RobotAction.Action_Visual_Put);
                        else if (CurSortMode == SortMode.SortWithNoVisual)
                            m_Robot.RunAction((short)RobotAction.Action_Manual_Put_1 + m_TempCount);

                        m_AutoRunAction = AutoRunAction.AuoRunNone;
                    }
                    break;
                case AutoRunAction.AutoRunLockDevices:        //计数满则锁定翻转盘器件
                    {
                        bool Re = m_ArmControler.SetControlBoardIo(Board.Conveyor, ControlBord_IO_OUT.IO_OUT_OverturnSalverAirCyl, IOValue.IOValueHigh);
                        if (Re)
                            m_AutoRunAction = AutoRunAction.AuoRunNone;
                    }break;
                case AutoRunAction.AutoRunTurnOverSalver:         //翻盘托盘
                    {
                        //给单片机发消息，控制翻转电机翻转，翻转180度后，回复上位机，并设置 m_AutoRunAction = AutoRunAction.AutoRunUnLockDevices;

                    }break;
                case AutoRunAction.AutoRunUnLockDevices:          //翻转成功，解锁器件
                    {
                        bool Re = m_ArmControler.SetControlBoardIo(Board.Conveyor, ControlBord_IO_OUT.IO_OUT_OverturnSalverAirCyl, IOValue.IOValueLow);
                        if(Re)
                            m_AutoRunAction = AutoRunAction.AuoRunNone;
                    } break;
                case AutoRunAction.AutoRunTransportReceiveSalver:  //存储文件，通知运走接收盘
                    {
                        if (m_QRCodeStr.Count >= m_OnePanelDevicesMax) //
                        {
                            List<string> QRCodeTemp = m_QRCodeStr.Distinct().ToList(); //却掉重复扫描的 
                            if (QRCodeTemp.Count() == m_OnePanelDevicesMax)
                            {
                                //创建共享文件.xml,并写入到文件中
                                int TrayNum = m_DevicesTotal / m_OnePanelDevicesMax + 1;  //当前测试为第几盘
                                bool Re = m_NsfTrayModuleFile.CreateAndWriteFile(QRCodeTemp, TrayNum);
                                if (Re)
                                {
                                    m_AutoRunAction = AutoRunAction.AuoRunStart;
                                    m_DevicesTotal += m_OnePanelDevicesMax;
                                    RunForm.m_GrapAndPutTotal = m_DevicesTotal;
                                    //清除掉之前的各到位信号，在AuoRunStart时重新检查

                                    //让单片机控制运输电机来运走托盘
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
            else if (DataStruct.SysStat.Reset)
                State = StationState.Reset;

            return (byte)State;
        }

        public static byte GetStationSalverState()
        {
            SalverState State = SalverState.NoSalver;
            if (DataStruct.SysStat.ReceiveSalverArrive)
                State = SalverState.HaveSalver;

            return (byte)State;
        }

        //UI上的灯
        public static int CheckSysAlarm()
        {
            // check robot
            if (DataStruct.SysStateAlarm.Robot >= 1)
            {
                if (DataStruct.SysStateAlarm.Robot == 2)
                {
                    DataStruct.SysStat.LedRed = true;
                }
                else if (DataStruct.SysStateAlarm.Robot == 1)
                {
                    DataStruct.SysStat.LedOriange = true;
                }
            }

            //check camera
            if (DataStruct.SysStateAlarm.Camera == 1)
            {
                DataStruct.SysStat.Camera = 1;
                DataStruct.SysStat.LedRed = true;
            }

            //check QRCode
            if (DataStruct.SysStateAlarm.QRCode == 1)
            {
                DataStruct.SysStat.QRCode = 1;
                DataStruct.SysStat.LedRed = true;
            }

            //check RFID
            if (DataStruct.SysStateAlarm.RFID == 1)
            {
                DataStruct.SysStat.RFID = 1;
                DataStruct.SysStat.LedRed = true;
            }

            //check IO Control Board
            if (DataStruct.SysStateAlarm.ARM == 1)
            {
                DataStruct.SysStat.ARM = 1;
<<<<<<< HEAD
                DataStruct.SysStat.LedRed = true;
=======
                DataStruct.SysStat.RedAlarm = true;
>>>>>>> 2e99c703d89de6b5ce7fc31142d09201938502a8
            }

            //check Salver
            if (DataStruct.SysStateAlarm.Salver == 1)
            {
                DataStruct.SysStat.Salver = 1;
<<<<<<< HEAD
                DataStruct.SysStat.LedRed = true;
=======
                DataStruct.SysStat.RedAlarm = true;
>>>>>>> 2e99c703d89de6b5ce7fc31142d09201938502a8
            }

            //check Server
            if (DataStruct.SysStateAlarm.Server == 1)
            {
                DataStruct.SysStat.Server = 1;
<<<<<<< HEAD
                DataStruct.SysStat.LedRed = true;
=======
                DataStruct.SysStat.RedAlarm = true;
>>>>>>> 2e99c703d89de6b5ce7fc31142d09201938502a8
            }

            if ((!DataStruct.SysStat.LedOriange) && (!DataStruct.SysStat.LedRed))
                return 0;
            else if (DataStruct.SysStat.LedOriange && !DataStruct.SysStat.LedRed)
                return 1;
            else if (DataStruct.SysStat.LedRed && !DataStruct.SysStat.LedOriange)
                return 2;
            else
                return 3;
        }

        //工作站的塔灯 Alarm type , 0 = Green ; 1 = Yellow ; 2 = Red ; 3 = Red & Yellow
        public static void SetSysAlarmLed(byte AlarmType)
        {
            if (AlarmType == 0)
            {
                m_ArmControler.SetControlBoardIo(Board.Conveyor, ControlBord_IO_OUT.IO_OUT_LedGreen, IOValue.IOValueHigh);
                m_ArmControler.SetControlBoardIo(Board.Conveyor, ControlBord_IO_OUT.IO_OUT_LedOriange, IOValue.IOValueLow);
                m_ArmControler.SetControlBoardIo(Board.Conveyor, ControlBord_IO_OUT.IO_OUT_LedRed, IOValue.IOValueLow);
            }
            else if (AlarmType == 1)
            {
                m_ArmControler.SetControlBoardIo(Board.Conveyor, ControlBord_IO_OUT.IO_OUT_LedGreen, IOValue.IOValueLow);
                m_ArmControler.SetControlBoardIo(Board.Conveyor, ControlBord_IO_OUT.IO_OUT_LedOriange, IOValue.IOValueHigh);
                m_ArmControler.SetControlBoardIo(Board.Conveyor, ControlBord_IO_OUT.IO_OUT_LedRed, IOValue.IOValueLow);
            }
            else if (AlarmType == 2)
            {
                m_ArmControler.SetControlBoardIo(Board.Conveyor, ControlBord_IO_OUT.IO_OUT_LedGreen, IOValue.IOValueLow);
                m_ArmControler.SetControlBoardIo(Board.Conveyor, ControlBord_IO_OUT.IO_OUT_LedOriange, IOValue.IOValueLow);
                m_ArmControler.SetControlBoardIo(Board.Conveyor, ControlBord_IO_OUT.IO_OUT_LedRed, IOValue.IOValueHigh);
            }
            else if (AlarmType == 3)
            {
                m_ArmControler.SetControlBoardIo(Board.Conveyor, ControlBord_IO_OUT.IO_OUT_LedGreen, IOValue.IOValueLow);
                m_ArmControler.SetControlBoardIo(Board.Conveyor, ControlBord_IO_OUT.IO_OUT_LedOriange, IOValue.IOValueHigh);
                m_ArmControler.SetControlBoardIo(Board.Conveyor, ControlBord_IO_OUT.IO_OUT_LedRed, IOValue.IOValueHigh);
            }
        }

        public static void QRCodeRecvData(object sender, EventArgs e)
        {
            if (e is QRCodeEventArgers)
            {
                QRCodeEventArgers Temp = e as QRCodeEventArgers;
                bool Check = CheckAndSaveQRCodeReadData(Temp.QRCodeRecv);
                if (Check)
                {
                    if (m_AutoRunAction == AutoRunAction.AuoRunNone)
                    {
                        m_ScanQRCode = true;
                        m_AutoRunAction = AutoRunAction.AutoRunMoveToPut;
                    }                     
                }                    
                else
                {
                    if (m_AutoRunAction == AutoRunAction.AuoRunNone)   //防止正确读取到后，再去放置的时候误触发时又要求重新去扫描
                    {
                        m_ScanQRCode = false;
                        m_AutoRunAction = AutoRunAction.AutoRunMoveToScanQRCode;
                    }                  
                }
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

        //VisualActionIndex VisualAction枚举 0x00抓取点, 0x01二维码扫描点, 0x02 放置点, 0x03让视觉相机拍照计算
        //PutPointIndex 是要放置点的索引 0-15 
        public static void GetVisualCoords(int VisualActionIndex, int PutPointIndex)
        {
            Message.MakeSendArrayByCode((byte)Message.MessageCodeCamera.GetCameraCoords, ref m_SendMeas);
            if (m_GetNextGrapPoint)
                m_SendMeas[Message.MessageCommandIndex + 1] = MessCameraNextPoint;

            m_SendMeas[Message.MessageCommandIndex + 2] = (byte)VisualActionIndex;
            m_SendMeas[Message.MessageCommandIndex + 3] = (byte)PutPointIndex;  //把要放置的索引传递给视觉

            //重新计算校验和
<<<<<<< HEAD
            m_SendMeas[Message.MessageSumCheck] = MyMath.CalculateSum(m_SendMeas, Message.MessageLength);
=======
            m_SendMeas[Message.MessageLength - 2] = 0x00;
            byte Sum = 0;
            foreach (byte Temp in m_SendMeas)
                Sum += Temp;
            m_SendMeas[Message.MessageLength - 2] = (byte)(0 - Sum);  //校验和
>>>>>>> 2e99c703d89de6b5ce7fc31142d09201938502a8

            string StrSend = BitConverter.ToString(m_SendMeas);

            if(m_MyTcpClientCamera != null && m_MyTcpClientCamera.IsConnected)
                m_MyTcpClientCamera.ClientWrite(StrSend);
        }

        public static void ProcessArmIoIn(byte[] IoIn)
        {
            //解析IoIn

            //根据实际的接线解析所需IO的状态,对SysStat中的相应标志进行设置
            /*
            DataStruct.SysStat.EmptySalverAirCylUpArrive;           //空盘气缸上升到位
            DataStruct.SysStat.EmptySalverAirCylDownArrive;         //空盘气缸下降到位
            DataStruct.SysStat.OverturnSalverArrive;                //翻转托盘到位
            DataStruct.SysStat.OverturnSalverAirCylGoArrive;        //翻转托盘锁定气缸进到位
            DataStruct.SysStat.OverturnSalverAirCylBackArrive;      //翻转托盘锁定气缸退到位
            DataStruct.SysStat.ReceiveSalverArrive;                 //翻转后接收托盘到位
            */

            //设置按键灯
<<<<<<< HEAD
            //ProcessKey(Key.Key_Run);
            //SetKeyLedByKey(ControlBord_IO_IN.IO_IN_KeyRun, LED_State.LED_ON);
        }

        public static void ProcessKey(Key key)
        {
            switch (key)
            {
                case Key.Key_Run:
                    {
                        int Re = CheckSysAlarm();
                        if (Re == 0)
                            m_MainThreadEvent.Set();

                        if ((DataStruct.SysStat.Ready) && (!DataStruct.SysStat.Stop))
                        {
                            DataStruct.SysStat.Run = true;
                            DataStruct.SysStat.Pause = false;
                        }
                    }
                    break;
                case Key.Key_Pause:
                    {
                        m_MainThreadEvent.Reset();

                        if (!DataStruct.SysStat.Stop)
                        {
                            DataStruct.SysStat.Pause = true;
                            DataStruct.SysStat.Run = false;
                        }
                    }
                    break;
                case Key.Key_Stop:
                    {
                        m_MainThreadEvent.Reset();

                        DataStruct.SysStat.Ready = false;
                        DataStruct.SysStat.Run = false;
                        DataStruct.SysStat.Pause = false;
                        DataStruct.SysStat.Stop = true;
                    }
                    break;
                case Key.Key_Reset:
                    {
                        DataStruct.InitDataStruct();

                        int Rtn = CheckSysAlarm();
                        if (Rtn == 0)
                        {
                            DataStruct.SysStat.Ready = true;
                            DataStruct.SysStat.Run = false;
                            DataStruct.SysStat.Stop = false;
                            DataStruct.SysStat.Pause = false;
                        }
                        else if (Rtn == 1)
                        {
                            DataStruct.SysStat.Pause = true;
                            DataStruct.SysStat.Ready = false;
                            DataStruct.SysStat.Run = false;
                            DataStruct.SysStat.Stop = false;
                        }
                        else if (Rtn == 2)
                        {
                            DataStruct.SysStat.Stop = true;
                            DataStruct.SysStat.Ready = false;
                            DataStruct.SysStat.Run = false;
                            DataStruct.SysStat.Pause = false;
                        }
                        else
                        {
                            DataStruct.SysStat.Pause = true;
                            DataStruct.SysStat.Stop = false;
                            DataStruct.SysStat.Ready = false;
                            DataStruct.SysStat.Run = false;
                        }
                    }
                    break;
                default:
                    break;
            }
        }
=======
            //SetKeyLedByKey(ControlBord_IO_IN.IO_IN_KeyRun, LED_State.LED_ON);
        }
>>>>>>> 2e99c703d89de6b5ce7fc31142d09201938502a8
    }
}
