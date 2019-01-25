#define DebugTest
#define HasObstructAirCyl

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
        AutoRunSaveNetShareFile,            //保存网络共享文件
        AutoRunTransportReceiveSalver       //运走接收盘
    }

    public enum StationAlarmState  //工作站状态
    {
        NoAlarm = 0,
        OrangeAlarm,
        RedAlarm,
    }

    public enum StationWorkState  //工作站状态
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
        public const int m_OnePanelDevicesMax = 16;
        private static int m_DevicesTotal = 0;
        private static int m_TempCount = 0;
        private static StationAlarmState m_StationAlarmState = StationAlarmState.RedAlarm;
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

        //Arm Controller
        private static ArmControler m_ArmControler = ArmControler.GetInstance();
        public static int m_ConveyorAxisCurPos = 0;       //站内传输线电机轴的当前位置
        public static int m_OverTurnAxisCurPos = 0;       //翻转电机轴的当前位置
        private static int m_ConveyorAxisAbsStep = 0;     //站内传输线电机在运动前的绝对位置

        //Tcp
        private static MyTcpClient m_MyTcpClientCamera = MainForm.GetMyTcpClientCamera();
        private static MyTcpServer m_MyTcpServer = MyTcpServer.GetInstance();
        private static byte[] m_SendMeas = new byte[Message.MessageLength];      

        //网络共享文件
        private static NsfTrayModule m_NsfTrayModuleFile = NsfTrayModule.GetInstance();

        //视觉
        public const byte MessCameraCurrentPoint = 0x00;
        public const byte MessCameraNextPoint = 0x01;
        private static short[] m_VisualCoords = new short[24];  //记录抓取点、二维码扫描点、放置点x,y,z,rz

        //线程
        private static Thread m_MainThread = null;
        private static Thread m_MeassageThread = null;
        public static ManualResetEvent m_ThreadEvent = new ManualResetEvent(false);

        private static bool m_FirstPrepareBeforeStart = false;    //开始前准备工作1，翻转盘回到Home点，并且锁定气缸退到位后置true
        private static bool m_SecondPrepareBeforeStart = false;   //开始前准备工作2，传输线降低到位并且空盘顶升气缸降低到位后置true
        private static bool m_ThirdPrepareBeforeStart = false;    //开始前准备工作3，阻挡气缸升起到位，并且电机运转到位,保证盘到后置true

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

        public static void InitPrepareBeforeStart()
        {
            m_FirstPrepareBeforeStart = false;
            m_SecondPrepareBeforeStart = false;
            m_ThirdPrepareBeforeStart = false;

            m_ConveyorAxisCurPos = 0;       //站内传输线电机轴的当前位置
            m_OverTurnAxisCurPos = 0;       //翻转电机轴的当前位置
            m_ConveyorAxisAbsStep = 0;     //站内传输线电机在运动前的绝对位置

            m_ScanQRCode = false;
            m_QRCodeStr.Clear();
            m_RfidRead = "";
            m_TempCount = 0;
            m_GetNextGrapPoint = false;
            Array.Clear(m_VisualCoords, 0, m_VisualCoords.Length);
            m_StationAlarmState = StationAlarmState.RedAlarm;            
            m_AutoRunAction = AutoRunAction.AuoRunStart;
        }

        public static void CreateAllThread()
        {
            //创建主线程
            m_MainThread = new Thread(new ThreadStart(MainThreadFunc));
            m_MainThread.IsBackground = true;
            m_MainThread.Start();

            //创建消息处理线程
            m_MeassageThread = new Thread(new ThreadStart(MessageThreadFunc));
            m_MeassageThread.IsBackground = true;
            m_MeassageThread.Start();
        }

        public static void MainThreadFunc()
        {
            m_QRCodeStr.Clear();
            m_QRCode.QRCodeRecvDataEvent += new EventHandler(QRCodeRecvData);

            InitPrepareBeforeStart();

            while (!m_ShouldExit)
            {
                m_ThreadEvent.WaitOne();

                if (DataStruct.SysStat.Run)
                    AutoSortingRun();

                Thread.Sleep(0);  //Sleep(0),则线程会将时间片的剩余部分让给任何已经准备好的具有同等优先级的线程
            }
        }

        public static void MessageThreadFunc()
        {
            while (!m_ShouldExit)
            {
                ProcessRobotMessage();              
                ProcessRFIDMessage();               
                ProcessTcpClientMessage();  //作为客户端处理和单片机控制板、相机的消息队列            
                ProcessTcpServerMessage();  //作为服务端处理和MIS及PLC之间的消息
               
                
                CheckStationCurrentAlarmState();         //轮询工作站的状态
                SendCommandToReadAllArmController();     //轮询单片机

                Thread.Sleep(0);
            }

            if (m_ShouldExit)
            {
                foreach (MyTcpClient Client in m_ArmControler.m_MyTcpClientArm)
                {
                    if (Client != null)
                        Client.Close();
                }

                if (m_MyTcpClientCamera != null)
                    m_MyTcpClientCamera.Close();
            }
        }

        //轮询机器人的状态
        public static void CheckRobotState()
        {
            if (m_Robot != null && m_Robot.IsConnected())
            {
                DataStruct.SysStat.RobotAlarm = m_Robot.HasAlarm();
                DataStruct.SysStat.RobotWarning = m_Robot.HasWarning();

                if(!DataStruct.SysStat.RobotAlarm && !DataStruct.SysStat.RobotWarning)
                    DataStruct.SysStat.RobotOk = true;
                else
                    DataStruct.SysStat.RobotOk = false;
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
                    DataStruct.SysStat.ReceiveSalverArrive = true;  //在使用完成后置false
                    DataStruct.SysStat.ManualDebugReceiveSalverArrive = true;
                }
                else
                {
                    DataStruct.SysStat.ManualDebugReceiveSalverArrive = false;
                }
            }
        }

        public static void ProcessTcpClientMessage()
        {
            //作为客户端处理所有Arm控制板的消息
            for(int i = 0; i < m_ArmControler.m_MyTcpClientArm.Length; i++)
            {
                MyTcpClient Client = m_ArmControler.m_MyTcpClientArm[i];
                if (Client != null && Client.IsConnected)
                {
                    while (Client.m_RecvMeasQueue.Count != 0)
                    {
                        TcpMeas TempMeas = Client.m_RecvMeasQueue.Dequeue();
                        if (TempMeas != null && TempMeas.Client != null)
                        {
                            if (TempMeas.MeasType == TcpMeasType.MEAS_TYPE_ARM)  // 处理和ARM之间的消息
                            {
                                ProcessArmMessage((Board)i, TempMeas);
                            }
                        }
#if DebugTest
                        Debug.WriteLine(BitConverter.ToString(TempMeas.Param));
#endif

                    }
                }
            }

            //作为客户端处理相机的消息
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

        //轮询所有单片机控制板的状态
        public static void SendCommandToReadAllArmController()
        {
            for (int i = 0; i < (int)Board.Max; i++)
            {
                if (m_ArmControler.IsBoardConnected((Board)i))
                {
                    m_ArmControler.SendReadInputPoint((Board)i);   //读取IO输入点的状态

                    for (int j = 0; j < (int)Axis.Max; j++)
                    {
                        m_ArmControler.SendReadAxisPostion((Axis)j);   //读取传输线各电机的当前位置
                        m_ArmControler.SendReadAxisState((Axis)j);
                    }
                }
            }
        }

        //处理和单片机控制板的消息
        public static void ProcessArmMessage(Board board, TcpMeas meassage)
        {
            if (meassage != null)
            {
                Message.MessageCodeARM Code = (Message.MessageCodeARM)meassage.MeasCode;
                switch (Code)
                {
                    case Message.MessageCodeARM.GetOutput:   //读取输出口缓冲区数据
                        {

                        }break;
                    case Message.MessageCodeARM.GetInput:    //读取输入口的IO
                        {
                            int DataIndex = Message.MessageCommandIndex + 1;
                            uint dataInput =  (uint)meassage.Param[DataIndex + 3] * 0x1000000
                                            + (uint)meassage.Param[DataIndex + 2] * 0x10000
                                            + (uint)meassage.Param[DataIndex + 1] * 0x100
                                            + (uint)meassage.Param[DataIndex + 0];

                            m_ArmControler.SetInputPoint(board, dataInput);
                            ProcessArmControlerInputPoint(board);
                        }break;
                    case Message.MessageCodeARM.GetAxisStepsAbs:
                        {
                            int DataIndex = Message.MessageCommandIndex + 2;
                            uint steps = (uint)meassage.Param[DataIndex + 3] * 0x1000000
                                + (uint)meassage.Param[DataIndex + 2] * 0x10000
                                + (uint)meassage.Param[DataIndex + 1] * 0x100
                                + (uint)meassage.Param[DataIndex + 0];

                            Axis axis = (Axis)meassage.Param[Message.MessageCommandIndex + 1];
                            m_ArmControler.SetAxisPostion(axis, steps);
                            ProcessArmControlerAxisPosition(board);
                        }
                        break;
                    case Message.MessageCodeARM.GetAxisState:
                        {
                            Axis AxisNum = (Axis)meassage.Param[Message.MessageCommandIndex + 1];
                            byte State = meassage.Param[Message.MessageCommandIndex + 2];
                            m_ArmControler.SetAxisState(AxisNum, State);
                        }
                        break;
                    default:
                        break;
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
                                    Global.MessageBoxShow(Global.StrVisualError);
#endif
                                    DataStruct.SysStat.CameraOk = false;
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

        public static void AutoSortingRun()
        {
            SortMode CurSortMode = Profile.m_Config.SelectedSortMode;  //获取当前抓取模式

            switch (m_AutoRunAction)
            {
                case AutoRunAction.AuoRunStart:             
                    {
                        bool Start = CheckAndTryToLoadSalverBeforeSorting();  //检查各盘是否到位，都无误后 Start = true
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
                            GetVisualCoords((int)VisualAction.Visual_GrapPoint, m_TempCount);   //Visual_QRCodeScanPoint  和 Visual_PutPoint在ProcessCameraMessage中获取
                            m_AutoRunAction = AutoRunAction.AuoRunNone;
                        }
                    }break;
                case AutoRunAction.AutoRunMoveToGrap:           //移动到位并抓取   
                    {
                        Debug.Assert(m_TempCount <= m_OnePanelDevicesMax);

                        //移动到指定位置抓手气缸进到位，后吸起器件，上位机发指令，机械臂脚本解析，执行动作
                        if(CurSortMode == SortMode.SortWithVisual)
                            m_Robot.RunAction((short)RobotAction.Action_Visual_Grap);
                        else if (CurSortMode == SortMode.SortWithNoVisual)
                            m_Robot.RunAction((short)RobotAction.Action_Manual_Grap_1 + m_TempCount);

                        m_AutoRunAction = AutoRunAction.AuoRunNone;
                    }break;
                case AutoRunAction.AutoRunMoveToScanQRCode:    
                    {
                        m_Robot.RunAction((short)RobotAction.Action_QRCodeScan);  
                        m_AutoRunAction = AutoRunAction.AuoRunNone;
                    }
                    break;
                case AutoRunAction.AutoRunMoveToPut:    //移动到位并放下，计数后开始下一个，满总数后下一步    
                    {
                        Debug.Assert(m_TempCount <= m_OnePanelDevicesMax);
                        if (m_TempCount == m_OnePanelDevicesMax - 1)
                            GetVisualCoords((int)VisualAction.Visual_RunCamera, 0);  //下一盘时
                        else
                            GetVisualCoords((int)VisualAction.Visual_RunCamera, m_TempCount + 1);

                        if (CurSortMode == SortMode.SortWithVisual)
                            m_Robot.RunAction((short)RobotAction.Action_Visual_Put);
                        else if (CurSortMode == SortMode.SortWithNoVisual)
                            m_Robot.RunAction((short)RobotAction.Action_Manual_Put_1 + m_TempCount);

                        m_AutoRunAction = AutoRunAction.AuoRunNone;
                    }
                    break;
                case AutoRunAction.AutoRunLockDevices:        //计数满则锁定翻转盘器件
                    {
                        bool Re = m_ArmControler.SetArmControlBoardIo(Board.Controler, ARM_OutputPoint.IO_OUT_OverturnSalverLockAirCyl, IOValue.IOValueHigh);
                        if (Re)
                            m_AutoRunAction = AutoRunAction.AuoRunNone;
                    }break;
                case AutoRunAction.AutoRunTurnOverSalver:         //翻盘托盘
                    {
                        //给单片机发消息，控制翻转电机翻转，运行绝对步数，
                        AxisState CurState = m_ArmControler.ReadAxisState(Axis.OverTurn);
                        if (CurState == AxisState.Ready)
                        {
                            bool Re = m_ArmControler.MoveAbs(Axis.OverTurn, ArmControler.m_OverturnAxisMaxStep);
                            if(Re)
                                m_AutoRunAction = AutoRunAction.AuoRunNone;
                        }                         
                    }
                    break;
                case AutoRunAction.AutoRunUnLockDevices:          //翻转成功，解锁器件
                    {
                        bool Re = m_ArmControler.SetArmControlBoardIo(Board.Controler, ARM_OutputPoint.IO_OUT_OverturnSalverLockAirCyl, IOValue.IOValueLow);
                        if(Re)
                            m_AutoRunAction = AutoRunAction.AuoRunNone;
                    } break;
                case AutoRunAction.AutoRunSaveNetShareFile:  //存储文件，通知运走接收盘
                    {
                        if (m_QRCodeStr.Count >= m_OnePanelDevicesMax) //
                        {
                            List<string> QRCodeTemp = m_QRCodeStr.Distinct().ToList(); //却掉重复扫描的 
                            if (QRCodeTemp.Count() == m_OnePanelDevicesMax)
                            {
                                int TraySn = int.Parse(m_RfidRead);
                                bool Re = m_NsfTrayModuleFile.CreateAndWriteFile(QRCodeTemp, TraySn);  //创建共享文件.xml,并写入到文件中
                                if (Re)
                                {                             
                                    m_DevicesTotal += m_OnePanelDevicesMax;
                                    RunForm.m_GrapAndPutTotal = m_DevicesTotal;
                                    m_AutoRunAction = AutoRunAction.AutoRunTransportReceiveSalver;
                                }
                            }
                        }
                    }break;
                case AutoRunAction.AutoRunTransportReceiveSalver:
                    {                     
                        bool Re = TryToTransportReceiveSalverAfterSorting();
                        if (Re)
                        {
                            //清除掉之前的各到位信号，在AuoRunStart时重新检查
                            DataStruct.InitAirCylAndSalverAndAxis();
                            InitPrepareBeforeStart();
                            m_AutoRunAction = AutoRunAction.AuoRunStart;
                        }
                    }
                    break;
                default:
                    break;
            }
        }

        //进行抓取前，检查接收盘是都到位，未到位则控制其运动到位
        public static bool CheckAndTryToLoadSalverBeforeSorting()
        {
            bool Re = false;

            if (!m_FirstPrepareBeforeStart)
            {
                if (!DataStruct.SysStat.OverturnSalverHomeArrive)  //翻转托盘未在原点
                {
                    m_ArmControler.BackHome(Axis.OverTurn, AxisDir.Reverse);
                }
                else
                {
                    if (!DataStruct.SysStat.OverturnSalverLockAirCylBackArrive)  //翻转托盘锁气缸未退到位
                        m_ArmControler.SetArmControlBoardIo(Board.Controler, ARM_OutputPoint.IO_OUT_OverturnSalverLockAirCyl, IOValue.IOValueLow);
                    else
                        m_FirstPrepareBeforeStart = true;
                }
            }

            if (m_FirstPrepareBeforeStart && !m_SecondPrepareBeforeStart)
            {
                if (!DataStruct.SysStat.ConveyorLiftingAirCylDownArrive)  //传输线未降低到位
                {
                    m_ArmControler.SetArmControlBoardIo(Board.Controler, ARM_OutputPoint.IO_OUT_ConveyorLiftingAirCylRun, IOValue.IOValueLow);
                }
                else
                {
                    if (!DataStruct.SysStat.ReceiveSalverLiftingAirCylDownArrive)  //空盘顶升气缸未降低到位             
                        m_ArmControler.SetArmControlBoardIo(Board.Controler, ARM_OutputPoint.IO_OUT_EmptySalverLiftingAirCylRun, IOValue.IOValueLow);
                    else
                        m_SecondPrepareBeforeStart = true;
                }
            }

            if (m_SecondPrepareBeforeStart && !m_ThirdPrepareBeforeStart)
            {
                SalverState State = (SalverState)GetStationSalverState();
                if (State == SalverState.HaveSalver)  //无盘时PLC会去调度盘，只要控制好ReceiveSalverArrive的标志位即可
                {
                    if (DataStruct.SysStat.EmptySalverObstructSensor)  //阻挡传感器被触发
                    {

#if HasObstructAirCyl  //有阻挡气缸
                        if (!DataStruct.SysStat.EmptySalverObstructAirCylUpArrive)  //阻挡气缸未升到位
                        {
                            m_ArmControler.SetArmControlBoardIo(Board.Controler, ARM_OutputPoint.IO_OUT_EmptySalverObstructAirCylRun, IOValue.IOValueHigh);//升起阻挡气缸
                        }
                        else
                        {
                            //电机运行到位后设置
                            AxisState CurState = m_ArmControler.ReadAxisState(Axis.Conveyor);
                            if (CurState == AxisState.Ready && m_ConveyorAxisCurPos == m_ConveyorAxisAbsStep + ArmControler.m_ConveyorAxisMaxStep) //运动后停止
                                m_ThirdPrepareBeforeStart = true;
                        }
#else
                            //电机运行到位后设置
                            AxisState CurState = m_ArmControler.ReadAxisState(Axis.Conveyor);
                            if (CurState == AxisState.Ready && m_ConveyorAxisCurPos == m_ConveyorAxisAbsStep + ArmControler.m_ConveyorAxisMaxStep) //运动后停止
                                m_ThirdPrepareBeforeStart = true;
#endif
                    }
                    else  //阻挡传感器未触发，控制电机向前运动输送空盘
                    {
                        AxisState CurState = m_ArmControler.ReadAxisState(Axis.Conveyor);
                        if (CurState == AxisState.Ready)
                        {
                            m_ConveyorAxisAbsStep = m_ConveyorAxisCurPos;
                            m_ArmControler.MoveAbs(Axis.Conveyor, m_ConveyorAxisAbsStep + ArmControler.m_ConveyorAxisMaxStep);
                        }
                    }
                }
            }

            if (m_FirstPrepareBeforeStart && m_SecondPrepareBeforeStart && m_ThirdPrepareBeforeStart)
            {            
                if (!DataStruct.SysStat.ReceiveSalverLiftingAirCylUpArrive)  //空盘顶升气缸未升到位
                    m_ArmControler.SetArmControlBoardIo(Board.Controler, ARM_OutputPoint.IO_OUT_EmptySalverLiftingAirCylRun, IOValue.IOValueHigh);//
                else              
                    Re = true; 
            }

            return Re;
        }

        //分拣完成后运走接收盘
        public static bool TryToTransportReceiveSalverAfterSorting()
        {
            bool Re = false;

            if (DataStruct.SysStat.ReceiveSalverLiftingAirCylDownArrive)  //接收盘顶升气缸未降到位
            {
                if (DataStruct.SysStat.ConveyorLiftingAirCylUpArrive)   //传输线气缸未升到位
                {
                    if (DataStruct.SysStat.SalverRunOutStationSensor)   //物料盘送出站
                    {
                        Re = true;
                    }
                    else
                    {
                        AxisState CurState = m_ArmControler.ReadAxisState(Axis.Conveyor);
                        if (CurState == AxisState.Ready)
                        {
                            m_ArmControler.MoveAbs(Axis.Conveyor, m_ConveyorAxisCurPos + ArmControler.m_ConveyorAxisMaxStep);
                        }
                    }
                }
                else
                {
                    m_ArmControler.SetArmControlBoardIo(Board.Controler, ARM_OutputPoint.IO_OUT_ConveyorLiftingAirCylRun, IOValue.IOValueHigh);
                }
            }
            else
            {
                m_ArmControler.SetArmControlBoardIo(Board.Controler, ARM_OutputPoint.IO_OUT_EmptySalverLiftingAirCylRun, IOValue.IOValueLow);
            }

            return Re;
        }

        public static void ResetWorkStation()
        {
            DataStruct.InitDataStruct();
            InitPrepareBeforeStart();

            if(m_Robot.IsConnected())
                m_Robot.RunAction((short)RobotAction.Action_Go_Home);

            if (m_ArmControler.IsBoardConnected(Board.Controler))
            {
                m_ArmControler.BackHome(Axis.OverTurn, AxisDir.Reverse);
                m_ArmControler.SetArmControlBoardIo(Board.Controler, ARM_OutputPoint.IO_OUT_OverturnSalverLockAirCyl, IOValue.IOValueLow);
                m_ArmControler.SetArmControlBoardIo(Board.Controler, ARM_OutputPoint.IO_OUT_ConveyorLiftingAirCylRun, IOValue.IOValueLow);
                m_ArmControler.SetArmControlBoardIo(Board.Controler, ARM_OutputPoint.IO_OUT_EmptySalverLiftingAirCylRun, IOValue.IOValueLow);
            }
        }

        //获取工作站当前的运行状态
        public static byte GetStationCurState()    
        {
            StationWorkState State = StationWorkState.Stop;

            if (DataStruct.SysStat.Run)
                State = StationWorkState.Run;
            else if (DataStruct.SysStat.Pause)
                State = StationWorkState.Pause;
            else if (DataStruct.SysStat.Stop)
                State = StationWorkState.Stop;
            else if (DataStruct.SysStat.Reset)
                State = StationWorkState.Reset;

            return (byte)State;
        }

        //检查工作站接收盘的状态
        public static byte GetStationSalverState()
        {
            SalverState State = SalverState.NoSalver;
            if (DataStruct.SysStat.ReceiveSalverArrive)
                State = SalverState.HaveSalver;

            return (byte)State;
        }

        //UI上的灯
        public static void CheckStationCurrentAlarmState()
        {
            CheckRobotState();  //轮询机械臂

            if (DataStruct.SysStat.RobotAlarm)
                DataStruct.SysStat.LedRed = true;
            else if (DataStruct.SysStat.RobotWarning)
                DataStruct.SysStat.LedOriange = true;

            //Check Robot Camera、 QRCode、 RFID、 ARM、 Salver、 Server
            if (!DataStruct.SysStat.RobotOk || !DataStruct.SysStat.CameraOk || !DataStruct.SysStat.QRCodeOk || !DataStruct.SysStat.RfidOk ||
                !DataStruct.SysStat.ArmControlerOk || !DataStruct.SysStat.OverturnSalverOk || !DataStruct.SysStat.ServerOk)
            {
                DataStruct.SysStat.LedRed = true;
            }

            if ((!DataStruct.SysStat.LedOriange) && (!DataStruct.SysStat.LedRed))
                m_StationAlarmState =  StationAlarmState.NoAlarm;
            else if (DataStruct.SysStat.LedOriange && !DataStruct.SysStat.LedRed)
                m_StationAlarmState = StationAlarmState.OrangeAlarm;
            else if (DataStruct.SysStat.LedRed)
                m_StationAlarmState = StationAlarmState.RedAlarm;

            if (m_StationAlarmState == StationAlarmState.NoAlarm)
                DataStruct.SysStat.Ready = true;
            else
                DataStruct.SysStat.Ready = false;
        }

        //工作站的塔灯 Alarm type , 0 = Green ; 1 = Yellow ; 2 = Red ; 3 = Red & Yellow
        public static void SetSysAlarmLed(byte AlarmType)
        {
            if (AlarmType == 0)
            {
                m_ArmControler.SetArmControlBoardIo(Board.Controler, ARM_OutputPoint.IO_OUT_LedGreen, IOValue.IOValueHigh);
                m_ArmControler.SetArmControlBoardIo(Board.Controler, ARM_OutputPoint.IO_OUT_LedOriange, IOValue.IOValueLow);
                m_ArmControler.SetArmControlBoardIo(Board.Controler, ARM_OutputPoint.IO_OUT_LedRed, IOValue.IOValueLow);
            }
            else if (AlarmType == 1)
            {
                m_ArmControler.SetArmControlBoardIo(Board.Controler, ARM_OutputPoint.IO_OUT_LedGreen, IOValue.IOValueLow);
                m_ArmControler.SetArmControlBoardIo(Board.Controler, ARM_OutputPoint.IO_OUT_LedOriange, IOValue.IOValueHigh);
                m_ArmControler.SetArmControlBoardIo(Board.Controler, ARM_OutputPoint.IO_OUT_LedRed, IOValue.IOValueLow);
            }
            else if (AlarmType == 2)
            {
                m_ArmControler.SetArmControlBoardIo(Board.Controler, ARM_OutputPoint.IO_OUT_LedGreen, IOValue.IOValueLow);
                m_ArmControler.SetArmControlBoardIo(Board.Controler, ARM_OutputPoint.IO_OUT_LedOriange, IOValue.IOValueLow);
                m_ArmControler.SetArmControlBoardIo(Board.Controler, ARM_OutputPoint.IO_OUT_LedRed, IOValue.IOValueHigh);
            }
            else if (AlarmType == 3)
            {
                m_ArmControler.SetArmControlBoardIo(Board.Controler, ARM_OutputPoint.IO_OUT_LedGreen, IOValue.IOValueLow);
                m_ArmControler.SetArmControlBoardIo(Board.Controler, ARM_OutputPoint.IO_OUT_LedOriange, IOValue.IOValueHigh);
                m_ArmControler.SetArmControlBoardIo(Board.Controler, ARM_OutputPoint.IO_OUT_LedRed, IOValue.IOValueHigh);
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
            m_SendMeas[Message.MessageSumCheck] = MyMath.CalculateSum(m_SendMeas, Message.MessageLength);

            string StrSend = BitConverter.ToString(m_SendMeas);

            if(m_MyTcpClientCamera != null && m_MyTcpClientCamera.IsConnected)
                m_MyTcpClientCamera.ClientWrite(StrSend);
        }

        public static void ProcessArmControlerInputPoint(Board board)
        {
            //解析IoIn
            for (int i = 0; i < (int) ARM_InputPoint.IO_IN_MAX; i++)
            {
                bool State = m_ArmControler.ReadInputPoint((ARM_InputPoint)i);
                LED_State LedState = State ? LED_State.LED_ON : LED_State.LED_OFF;
                if (State != m_ArmControler.ReadInputPointStateBackups((ARM_InputPoint)i))
                {
                    m_ArmControler.SetInputPointStateBackups((ARM_InputPoint)i, State);

                    ARM_InputPoint temp = (ARM_InputPoint)i;
                    switch (temp)
                    {
                        case ARM_InputPoint.IO_IN_KeyRun:
                            {
                                if (State)
                                    ProcessKey(Key.Key_Run);

                                DataStruct.SysStat.KeyRun = State;
                                m_ArmControler.SetKeyLedByKey(board, ARM_InputPoint.IO_IN_KeyRun, LedState);
                            }
                            break;
                        case ARM_InputPoint.IO_IN_KeyPause:
                            {
                                if (State)
                                    ProcessKey(Key.Key_Pause);

                                DataStruct.SysStat.KeyPause = State;
                                m_ArmControler.SetKeyLedByKey(board, ARM_InputPoint.IO_IN_KeyPause, LedState);
                            }
                            break;
                        case ARM_InputPoint.IO_IN_KeyStop:
                            {
                                if (State)
                                    ProcessKey(Key.Key_Stop);

                                DataStruct.SysStat.KeyStop = State;
                                m_ArmControler.SetKeyLedByKey(board, ARM_InputPoint.IO_IN_KeyStop, LedState);
                            }
                            break;
                        case ARM_InputPoint.IO_IN_KeyReset:
                            {
                                if (State)
                                    ProcessKey(Key.Key_Reset);

                                DataStruct.SysStat.KeyReset = State;
                                m_ArmControler.SetKeyLedByKey(board, ARM_InputPoint.IO_IN_KeyReset, LedState);
                            }
                            break;
                        case ARM_InputPoint.IO_IN_EmptySalverObstructAirCylUpArrive:
                            {
                                DataStruct.SysStat.EmptySalverObstructAirCylUpArrive = State;
                            }
                            break;
                        case ARM_InputPoint.IO_IN_EmptySalverObstructAirCylDownArrive:
                            {
                                DataStruct.SysStat.EmptySalverObstructAirCylDownArrive = State;
                            }
                            break;
                        case ARM_InputPoint.IO_IN_EmptySalverObstructSensor:
                            {
                                DataStruct.SysStat.EmptySalverObstructSensor = State;
                            }
                            break;
                        case ARM_InputPoint.IO_IN_EmptySalverLiftingAirCylUpArrive:
                            {
                                DataStruct.SysStat.ReceiveSalverLiftingAirCylUpArrive = State;
                            }
                            break;
                        case ARM_InputPoint.IO_IN_EmptySalverLiftingAirCylDownArrive:
                            {
                                DataStruct.SysStat.ReceiveSalverLiftingAirCylDownArrive    = State;
                            }
                            break;
                        case ARM_InputPoint.IO_IN_ConveyorLiftingAirCylUpArrive:
                            {
                                DataStruct.SysStat.ConveyorLiftingAirCylUpArrive = State;
                            }
                            break;
                        case ARM_InputPoint.IO_IN_ConveyorLiftingAirCylDownArrive:
                            {
                                DataStruct.SysStat.ConveyorLiftingAirCylDownArrive = State;
                            }
                            break;
                        case ARM_InputPoint.IO_IN_OverturnSalverTurnArrive:
                            {
                                DataStruct.SysStat.OverturnSalverTurnArrive = State;
                            }
                            break;
                        case ARM_InputPoint.IO_IN_OverturnSalverLockAirCylGoArrive:
                            {
                                DataStruct.SysStat.OverturnSalverLockAirCylGoArrive = State;
                                if (State)
                                    m_AutoRunAction = AutoRunAction.AutoRunTurnOverSalver;   //锁定成功后翻转
                            }
                            break;
                        case ARM_InputPoint.IO_IN_OverturnSalverLockAirCylBackArrive:
                            {
                                DataStruct.SysStat.OverturnSalverLockAirCylBackArrive = State;
                                if (State)
                                    m_AutoRunAction = AutoRunAction.AutoRunSaveNetShareFile;  //解锁成功后保存文件                     
                            }
                            break;
                        case ARM_InputPoint.IO_IN_SalverRunOutStationSensor:
                            {
                                DataStruct.SysStat.SalverRunOutStationSensor = State;
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        public static void ProcessArmControlerAxisPosition(Board board)
        {
            for (int i = 0; i < (int)Axis.Max; i++)  //处理需要处理轴的位置
            {
                switch ((Axis)i)
                {
                    case Axis.Conveyor:
                        {
                            m_ConveyorAxisCurPos = m_ArmControler.ReadAxisPostion(Axis.Conveyor);
                        }
                        break;
                    case Axis.OverTurn:
                        {
                            m_OverTurnAxisCurPos = m_ArmControler.ReadAxisPostion(Axis.OverTurn);
                            if (m_OverTurnAxisCurPos == 0)  //翻转托盘在原点位置
                            {
                                DataStruct.SysStat.OverturnSalverHomeArrive = true;
                                DataStruct.SysStat.OverturnSalverOk = true;
                            }
                            else if (m_OverTurnAxisCurPos == ArmControler.m_OverturnAxisMaxStep && DataStruct.SysStat.OverturnSalverTurnArrive)
                            {
                                m_AutoRunAction = AutoRunAction.AutoRunUnLockDevices;
                            }
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        public static void ProcessKey(Key key)
        {
            switch (key)
            {
                case Key.Key_Run:  //开始启动和暂停启动
                    {
                        if (DataStruct.SysStat.Ready && !DataStruct.SysStat.Stop)
                        {
                            m_ThreadEvent.Set();
                            DataStruct.SysStat.Run = true;
                            DataStruct.SysStat.Pause = false;
                        }
                        else
                        {
                            Global.MessageBoxShow(Global.StrRunError);
                        }
                    }
                    break;
                case Key.Key_Pause:
                    {                     
                        if (DataStruct.SysStat.Run && !DataStruct.SysStat.Stop)
                        {
                            m_ThreadEvent.Reset();
                            DataStruct.SysStat.Pause = true;
                            DataStruct.SysStat.Run = false;
                        }
                    }
                    break;
                case Key.Key_Stop:
                    {
                        m_ThreadEvent.Reset();
                        DataStruct.SysStat.Ready = false;
                        DataStruct.SysStat.Run = false;
                        DataStruct.SysStat.Pause = false;
                        DataStruct.SysStat.Stop = true;
                    }
                    break;
                case Key.Key_Reset:
                    {                        
                        ResetWorkStation();
                        if (m_StationAlarmState == StationAlarmState.NoAlarm)
                        {
                            DataStruct.SysStat.Ready = true;
                            DataStruct.SysStat.Run = false;
                            DataStruct.SysStat.Pause = false;
                            DataStruct.SysStat.Stop = false;
                            DataStruct.SysStat.Reset = false;
                        }
                        else  //存在警告
                        {
                            DataStruct.SysStat.Ready = false;
                            DataStruct.SysStat.Run = false;
                            DataStruct.SysStat.Pause = false;                                                       
                            DataStruct.SysStat.Stop = true;
                            DataStruct.SysStat.Reset = true;
                        }
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
