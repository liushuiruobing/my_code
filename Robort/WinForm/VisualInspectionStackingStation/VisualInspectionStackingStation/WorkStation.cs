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

    public enum AlarmLed
    {
        AlarmLed_Green = 0,
        AlarmLed_Oriange,
        AlarmLed_Red,
        AlarmLed_OriangeAndRed
    }

    public enum AutoRunAction
    {
        AuoRunNone = 0,
        AuoRunStart,                        //开始
        AutoRunMoveToGrap,                  //移动到位并抓取
        AutoRunMoveToScanQRCode,            //移动到位并扫码,检查扫码格式，不正确则依然执行此动作
        AutoRunMoveToPut,                   //移动到位并放下，计数后开始下一件，满总数后下一步
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

    public class WorkStation  //工作站业务类
    {
        private volatile static bool m_ShouldExit = false;
        private static StationAlarmState m_StationAlarmState = StationAlarmState.RedAlarm;
        private static SysAlarm m_SysAlarm = SysAlarm.GetInstance();
        private static AutoRunAction m_AutoRunAction = AutoRunAction.AuoRunStart;

        //各模块
        private static ArmControler m_ArmControler = ArmControler.GetInstance();
        private static QRCode m_QRCode = QRCode.GetInstance();
        public static bool m_ScanQRCode = false;
        public static List<string> m_QRCodeStr = new List<string>();

        //Tcp
        private static MyTcpClient m_MyTcpClientVisual = MainForm.GetMyTcpClientVisual();
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

                if (DataStruct.SysStat.StationRun)
                    AutoRun();

                Thread.Sleep(100);  //Sleep(0),则线程会将时间片的剩余部分让给任何已经准备好的具有同等优先级的线程
            }
        }

        public static void MessageThreadFunc()
        {
            while (!m_ShouldExit)
            {                  
                ProcessTcpClientMessage();  //作为客户端处理和单片机控制板、相机的消息队列            
                ProcessTcpServerMessage();  //作为服务端处理和MIS及PLC之间的消息
               
                
                CheckStationCurrentAlarmState();         //轮询工作站的状态
                m_ArmControler.SendCommandToReadAllArmController();     //轮询单片机

                Thread.Sleep(0);
            }

            if (m_ShouldExit)
            {
                foreach (MyTcpClient Client in m_ArmControler.m_MyTcpClientArm)
                {
                    if (Client != null)
                        Client.Close();
                }

                if (m_MyTcpClientVisual != null)
                    m_MyTcpClientVisual.Close();
            }
        }

        public static void AutoRun()
        {
            switch (m_AutoRunAction)
            {
                case AutoRunAction.AuoRunStart:
                    break;
                default:
                    break;
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
            if (m_MyTcpClientVisual != null && m_MyTcpClientVisual.IsConnected)
            {
                while (m_MyTcpClientVisual.m_RecvMeasQueue.Count != 0)
                {
                    TcpMeas TempMeas = m_MyTcpClientVisual.m_RecvMeasQueue.Dequeue();
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
                    case Axis.Conveyor_EmptyOuterBasket:
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
                        if (DataStruct.SysStat.StationReady && !DataStruct.SysStat.StationStop)
                        {
                            m_ThreadEvent.Set();
                            DataStruct.SysStat.StationRun = true;
                            DataStruct.SysStat.StationPause = false;
                        }
                        else
                        {
                            Global.MessageBoxShow(Global.StrRunError);
                        }
                    }
                    break;
                case Key.Key_Pause:
                    {
                        if (DataStruct.SysStat.StationRun && !DataStruct.SysStat.StationStop)
                        {
                            m_ThreadEvent.Reset();
                            DataStruct.SysStat.StationPause = true;
                            DataStruct.SysStat.StationRun = false;
                        }
                    }
                    break;
                case Key.Key_Stop:
                    {
                        m_ThreadEvent.Reset();
                        DataStruct.SysStat.StationReady = false;
                        DataStruct.SysStat.StationRun = false;
                        DataStruct.SysStat.StationPause = false;
                        DataStruct.SysStat.StationStop = true;
                    }
                    break;
                case Key.Key_Reset:
                    {
                        ResetWorkStation();
                        if (m_StationAlarmState == StationAlarmState.NoAlarm)
                        {
                            DataStruct.SysStat.StationReady = true;
                            DataStruct.SysStat.StationRun = false;
                            DataStruct.SysStat.StationPause = false;
                            DataStruct.SysStat.StationStop = false;
                            DataStruct.SysStat.StationReset = false;
                        }
                        else  //存在警告
                        {
                            DataStruct.SysStat.StationReady = false;
                            DataStruct.SysStat.StationRun = false;
                            DataStruct.SysStat.StationPause = false;
                            DataStruct.SysStat.StationStop = true;
                            DataStruct.SysStat.StationReset = true;
                        }
                    }
                    break;
                default:
                    break;
            }
        }

        public static void ResetWorkStation()
        {
            DataStruct.InitDataStruct();
            InitPrepareBeforeStart();

            //if (m_ArmControler.IsBoardConnected(Board.Conveyor_Empty))
            //{
            //    m_ArmControler.BackHome(Axis.OverTurn, AxisDir.Reverse);
            //}
        }

        public static byte GetStationCurState()    
        {
            StationWorkState State = StationWorkState.Stop;

            if (DataStruct.SysStat.StationRun)
                State = StationWorkState.Run;
            else if (DataStruct.SysStat.StationPause)
                State = StationWorkState.Pause;
            else if (DataStruct.SysStat.StationStop)
                State = StationWorkState.Stop;
            else if (DataStruct.SysStat.StationReset)
                State = StationWorkState.Reset;

            return (byte)State;
        }

        public static byte GetStationSalverState()
        {
            SalverState State = SalverState.NoSalver;

            return (byte)State;
        }

        public static void CheckStationCurrentAlarmState()
        {
            //Check Robot Camera、 QRCode、 RFID、 ARM、 Salver、 Server
            if (!DataStruct.SysStat.RobotOk || !DataStruct.SysStat.CameraOk || !DataStruct.SysStat.QRCodeOk ||
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
                DataStruct.SysStat.StationReady = true;
            else
                DataStruct.SysStat.StationReady = false;
        }

        public static void SetSysAlarmTowerLed(AlarmLed LedType)
        {
            switch (LedType)
            {
                case AlarmLed.AlarmLed_Green:
                    {
                        m_ArmControler.SetArmControlBoardIo(Board.Conveyor_Empty, ARM_OutputPoint.IO_OUT_LedGreen, IOValue.IOValueHigh);
                        m_ArmControler.SetArmControlBoardIo(Board.Conveyor_Empty, ARM_OutputPoint.IO_OUT_LedOriange, IOValue.IOValueLow);
                        m_ArmControler.SetArmControlBoardIo(Board.Conveyor_Empty, ARM_OutputPoint.IO_OUT_LedRed, IOValue.IOValueLow);
                    }
                    break;
                case AlarmLed.AlarmLed_Oriange:
                    {
                        m_ArmControler.SetArmControlBoardIo(Board.Conveyor_Empty, ARM_OutputPoint.IO_OUT_LedGreen, IOValue.IOValueLow);
                        m_ArmControler.SetArmControlBoardIo(Board.Conveyor_Empty, ARM_OutputPoint.IO_OUT_LedOriange, IOValue.IOValueHigh);
                        m_ArmControler.SetArmControlBoardIo(Board.Conveyor_Empty, ARM_OutputPoint.IO_OUT_LedRed, IOValue.IOValueLow);
                    }
                    break;
                case AlarmLed.AlarmLed_Red:
                    {
                        m_ArmControler.SetArmControlBoardIo(Board.Conveyor_Empty, ARM_OutputPoint.IO_OUT_LedGreen, IOValue.IOValueLow);
                        m_ArmControler.SetArmControlBoardIo(Board.Conveyor_Empty, ARM_OutputPoint.IO_OUT_LedOriange, IOValue.IOValueLow);
                        m_ArmControler.SetArmControlBoardIo(Board.Conveyor_Empty, ARM_OutputPoint.IO_OUT_LedRed, IOValue.IOValueHigh);
                    }
                    break;
                case AlarmLed.AlarmLed_OriangeAndRed:
                    {
                        m_ArmControler.SetArmControlBoardIo(Board.Conveyor_Empty, ARM_OutputPoint.IO_OUT_LedGreen, IOValue.IOValueLow);
                        m_ArmControler.SetArmControlBoardIo(Board.Conveyor_Empty, ARM_OutputPoint.IO_OUT_LedOriange, IOValue.IOValueHigh);
                        m_ArmControler.SetArmControlBoardIo(Board.Conveyor_Empty, ARM_OutputPoint.IO_OUT_LedRed, IOValue.IOValueHigh);
                    }
                    break;
                default:
                    break;
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

        public static bool CheckAndSaveQRCodeReadData(string Code)
        {
            bool Check = false;

            char[] EndChar = { '\r', '\n' };
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
