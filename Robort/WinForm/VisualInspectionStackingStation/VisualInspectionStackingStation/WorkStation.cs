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

    public enum StationAlarmState  //工作站警告状态
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

    public class WorkStation  //视觉分拣业务类
    {
        private static StationAlarmState m_StationAlarmState = StationAlarmState.RedAlarm;
        private static AutoRunAction m_AutoRunAction = AutoRunAction.AuoRunStart;
        private volatile static bool m_ShouldExit = false;

        private static RFID m_RFID = RFID.GetInstance();
        public static string m_RfidRead = "";
        private static SysAlarm m_SysAlarm = SysAlarm.GetInstance();

        //Arm Controller
        private static ArmControler m_ArmControler = ArmControler.GetInstance();

        //Tcp
        private static MyTcpClient m_MyTcpClientCamera = MainForm.GetMyTcpClientCamera();
        private static MyTcpServer m_MyTcpServer = MyTcpServer.GetInstance();
        private static byte[] m_SendMeas = new byte[Message.MessageLength];      

        //线程
        private static Thread m_MainThread = null;
        private static Thread m_MeassageThread = null;
        public static ManualResetEvent m_ThreadEvent = new ManualResetEvent(false);

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
            m_RfidRead = "";

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
                                ProcessArmControlerMessage((Board)i, TempMeas);
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

        public static void ProcessCameraMessage(TcpMeas meassage)
        {
            if (meassage != null)
            {
                Message.MessageCodeCamera Code = (Message.MessageCodeCamera)meassage.MeasCode;
                switch (Code)
                {
                    case Message.MessageCodeCamera.GetCameraCoords:
                        break;
                    default:
                        break;
                }
            }
        }

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

        public static void ProcessArmControlerMessage(Board board, TcpMeas meassage)
        {
            if (meassage != null)
            {
                ArmCommandCode Code = (ArmCommandCode)meassage.MeasCode;
                switch (Code)
                {
                    case ArmCommandCode.GetOutput:   //读取输出口缓冲区数据
                        {

                        }break;
                    case ArmCommandCode.GetInput:    //读取输入口的IO
                        {
                            int DataIndex = Message.MessageCommandIndex + 1;
                            uint dataInput =  (uint)meassage.Param[DataIndex + 3] * 0x1000000
                                            + (uint)meassage.Param[DataIndex + 2] * 0x10000
                                            + (uint)meassage.Param[DataIndex + 1] * 0x100
                                            + (uint)meassage.Param[DataIndex + 0];

                            m_ArmControler.SetInputPoint(board, dataInput);
                            ProcessArmControlerInputPoint(board);
                        }break;
                    case ArmCommandCode.GetAxisStepsAbs:
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
                    case ArmCommandCode.GetAxisState:
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

        public static void ProcessArmControlerInputPoint(Board board)
        {
            //解析IoIn
            for (int i = 0; i < (int)ARM_InputPoint.IO_IN_MAX; i++)
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

                        }
                        break;
                    case Axis.OverTurn:
                        {

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

        public static void AutoSortingRun()
        {
            switch (m_AutoRunAction)
            {
                case AutoRunAction.AuoRunStart:
                    break;
                default:
                    break;
            }
        }

        public static void ResetWorkStation()
        {
            DataStruct.InitDataStruct();
            InitPrepareBeforeStart();

            if (m_ArmControler.IsBoardConnected(Board.Controler))
            {
                m_ArmControler.BackHome(Axis.OverTurn, AxisDir.Reverse);
                m_ArmControler.SetArmControlBoardIo(Board.Controler, ARM_OutputPoint.IO_OUT_OverturnSalverLockAirCyl, IOValue.IOValueLow);
                m_ArmControler.SetArmControlBoardIo(Board.Controler, ARM_OutputPoint.IO_OUT_ConveyorLiftingAirCylRun, IOValue.IOValueLow);
                m_ArmControler.SetArmControlBoardIo(Board.Controler, ARM_OutputPoint.IO_OUT_EmptySalverLiftingAirCylRun, IOValue.IOValueLow);
            }
        }

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

        public static byte GetStationSalverState()
        {
            SalverState State = SalverState.NoSalver;
            if (DataStruct.SysStat.ReceiveSalverArrive)
                State = SalverState.HaveSalver;

            return (byte)State;
        }

        public static void CheckStationCurrentAlarmState()
        {
            //Check Robot Camera、 QRCode、 RFID、 ARM、 Salver、 Server
            if (!DataStruct.SysStat.RobotOk || !DataStruct.SysStat.CameraOk || !DataStruct.SysStat.RfidOk ||
                !DataStruct.SysStat.ArmControlerOk ||  !DataStruct.SysStat.ServerOk)
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
    }
}
