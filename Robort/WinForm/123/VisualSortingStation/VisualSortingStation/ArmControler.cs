using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RobotWorkstation
{
    //单片机板卡定义
    public enum Board
    {
        Controler = 0,   //控制板卡，IO、翻转电机、传输线电机
        Max              //板卡总数
    }

    #region  //IO相关

    public enum ARM_InputPoint  //具体编号要等电气连接图出来之后与之相对应，机械臂的IO由机械臂的脚本处理，上位机只查询标志
    {
        //In
        IO_IN_KeyRun = 0 + Board.Controler * ArmControler.MAX_IO_CHANNEL,
        IO_IN_KeyPause = 1 + Board.Controler * ArmControler.MAX_IO_CHANNEL,
        IO_IN_KeyStop = 2 + Board.Controler * ArmControler.MAX_IO_CHANNEL,
        IO_IN_KeyReset = 3 + Board.Controler * ArmControler.MAX_IO_CHANNEL,
        IO_IN_EmptySalverObstructAirCylUpArrive = 4 + Board.Controler * ArmControler.MAX_IO_CHANNEL,         //空盘阻挡气缸上升到位
        IO_IN_EmptySalverObstructAirCylDownArrive = 5 + Board.Controler * ArmControler.MAX_IO_CHANNEL,       //空盘阻挡气缸下降到位
        IO_IN_EmptySalverObstructSensor = 6 + Board.Controler * ArmControler.MAX_IO_CHANNEL,           //空盘阻挡传感器
        IO_IN_EmptySalverLiftingAirCylUpArrive = 7 + Board.Controler * ArmControler.MAX_IO_CHANNEL,          //空盘升降气缸上升到位
        IO_IN_EmptySalverLiftingAirCylDownArrive = 8 + Board.Controler * ArmControler.MAX_IO_CHANNEL,        //空盘升降气缸下降到位
        IO_IN_ConveyorLiftingAirCylUpArrive = 9 + Board.Controler * ArmControler.MAX_IO_CHANNEL,             //站内传输线升降气缸上升到位
        IO_IN_ConveyorLiftingAirCylDownArrive = 10 + Board.Controler * ArmControler.MAX_IO_CHANNEL,          //站内传输线升降气缸下降到位
        IO_IN_OverturnSalverTurnArrive = 11 + Board.Controler * ArmControler.MAX_IO_CHANNEL,                 //翻转托盘翻转到位
        IO_IN_OverturnSalverLockAirCylGoArrive = 12 + Board.Controler * ArmControler.MAX_IO_CHANNEL,        //翻转托盘进到位
        IO_IN_OverturnSalverLockAirCylBackArrive = 13 + Board.Controler * ArmControler.MAX_IO_CHANNEL,      //翻转托盘退到位    
        IO_IN_SalverRunOutStationSensor = 14 + Board.Controler * ArmControler.MAX_IO_CHANNEL,           //物料盘已出站传感器   
        IO_IN_MAX
    }

    public enum ARM_OutputPoint   //具体编号要等电气连接图出来之后与之相对应，
    {
        //Out
        IO_OUT_LedRed = 0 + Board.Controler * ArmControler.MAX_IO_CHANNEL,
        IO_OUT_LedOriange = 1 + Board.Controler * ArmControler.MAX_IO_CHANNEL,
        IO_OUT_LedGreen = 2 + Board.Controler * ArmControler.MAX_IO_CHANNEL,
        IO_OUT_LedBlue = 3 + Board.Controler * ArmControler.MAX_IO_CHANNEL,
        IO_OUT_LedKeyRun = 4 + Board.Controler * ArmControler.MAX_IO_CHANNEL,
        IO_OUT_LedKeyPause = 5 + Board.Controler * ArmControler.MAX_IO_CHANNEL,
        IO_OUT_LedKeyStop = 6 + Board.Controler * ArmControler.MAX_IO_CHANNEL,
        IO_OUT_LedKeyReset = 7 + Board.Controler * ArmControler.MAX_IO_CHANNEL,
        IO_OUT_Beep = 8 + Board.Controler * ArmControler.MAX_IO_CHANNEL,
        IO_OUT_EmptySalverObstructAirCylRun = 9 + Board.Controler * ArmControler.MAX_IO_CHANNEL,         //底层空盘阻挡气缸
        IO_OUT_EmptySalverLiftingAirCylRun = 10 + Board.Controler * ArmControler.MAX_IO_CHANNEL,      //空盘顶升气缸
        IO_OUT_ConveyorLiftingAirCylRun = 11 + Board.Controler * ArmControler.MAX_IO_CHANNEL,         //站内传输线顶升气缸
        IO_OUT_OverturnSalverLockAirCyl = 12 + Board.Controler * ArmControler.MAX_IO_CHANNEL,             //翻转托盘气缸
        IO_OUT_MAX
    }

    public enum IOValue
    {
        IOValueLow = 0,
        IOValueHigh
    }

    public enum LED_State
    {
        LED_OFF = 0,
        LED_ON
    }

    #endregion

    #region   //电机相关

    //电机轴定义
    public enum Axis
    {
        Conveyor = 0,   //传输线轴
        OverTurn,       //翻转电机轴
        Max             //总轴数
    }

    //电机轴运动方向
    public enum AxisDir
    {
        Forward = 0,  //正转
        Reverse = 1,  //反转
    }

    //电机驱动状态
    public enum AxisState
    {
        Ready = 0,      //轴已准备就绪
        ErrorStop = 1,  //出现错误，轴停止
        Motion = 2,     //轴正在执行运动
    }
    #endregion

    public class ArmControler
    {
        private static ArmControler m_UniqueIo = null;
        private static readonly object m_Locker = new object();
        private byte[] m_SendMeas = new byte[Message.MessageLength];
        public MyTcpClient[] m_MyTcpClientArm = new MyTcpClient[(int)Board.Max];

        public const int MAX_IO_CHANNEL = 4 * 8;  //一块板卡包括32/32个隔离数字量输入/输出通道 
        public const int MAX_AXIS_CHANNEL = 8;    //一块板卡包括8个电机轴

        private uint[] m_InputValue = new uint[(int)Board.Max];  //ARM控制板IO输入的缓存 4个byte，每位代表1个IO，共32个,从而用uint来表示，32位每个位代表1个IO  
        private bool[] m_InputPointStateBackups = new bool[(int)ARM_InputPoint.IO_IN_MAX];  //输入点状态备份
        private int[,] m_AxisState = new int[(int)Board.Max, MAX_AXIS_CHANNEL]{ { 0, 0, 0, 0, 0, 0, 0, 0, } };  //电机轴状态
        private int[,] m_AxisPostion = new int[(int)Board.Max, MAX_AXIS_CHANNEL] { { 0, 0, 0, 0, 0, 0, 0, 0, } };  //电机轴当前位置

        public const int m_ConveyorAxisMaxStep = 100;   //传输线电机把盘送到位，所要运行的步数
        public const int m_OverturnAxisMaxStep = 100;   //翻转电机,翻转所需的步数

        private ArmControler()
        { 
            for (int i = 0; i < (int)ARM_InputPoint.IO_IN_MAX; i++)
            {
                m_InputPointStateBackups[i] = false;
            }
        }

        /// <summary>
        /// 定义公有方法提供一个全局访问点,同时你也可以定义公有属性来提供全局访问点
        /// </summary>
        /// <returns></returns>
        public static ArmControler GetInstance()
        {
            if (m_UniqueIo == null)
            {
                lock (m_Locker)
                {
                    if (m_UniqueIo == null)
                        m_UniqueIo = new ArmControler();
                }
            }
            return m_UniqueIo;
        }

        /// <summary>
        /// 打开ARM卡
        /// </summary>
        public void Open()
        {
            //传输线上的Arm控制板
            m_MyTcpClientArm[(int)Board.Controler] = new MyTcpClient();
            IPAddress ControlIp = IPAddress.Parse(Profile.m_Config.ControlerArmIp);
            int ControlPort = Profile.m_Config.ControlerArmPort;
            m_MyTcpClientArm[(int)Board.Controler].CreateConnect(ControlIp, ControlPort);

            //其他Arm控制板

        }

        /// <summary>
        /// 关闭ARM卡
        /// </summary>
        public void Close()
        {
            for (int i = 0; i < (int)Board.Max; i++)
            {
                if (IsBoardConnected((Board)i))
                {
                    m_MyTcpClientArm[i].Close();
                }
            }
        }

        public bool IsBoardConnected(Board board)
        {
            if (m_MyTcpClientArm[(int)board] != null)
                return m_MyTcpClientArm[(int)board].IsConnected;
            else
                return false;
        }

        //给单片机发送非电机轴的指令，仅指令，无参数
        public void SendCommandToArm(Board board, byte Code)
        {
            if (!IsBoardConnected(board))
                return;

            Message.MakeSendArrayByCode(Code, ref m_SendMeas);
            m_MyTcpClientArm[(int)board].ClientWrite(m_SendMeas);
        }

        //给单片机发送电机轴相关的指令，axis 轴号， code命令
        public bool SendCommandToArmWithAxis(Axis axis, byte Code)
        {
            int indexBoard = (int)axis / MAX_AXIS_CHANNEL;  //板卡索引
            int indexAxis = (int)axis % MAX_AXIS_CHANNEL;  //板卡内轴号索引

            if (!IsBoardConnected((Board)indexBoard))
                return false;

            Message.MakeSendArrayByCode(Code, ref m_SendMeas);
            m_SendMeas[Message.MessageCommandIndex + 1] = (byte)indexAxis;
            m_SendMeas[Message.MessageSumCheck] = MyMath.CalculateSum(m_SendMeas, Message.MessageLength);

            m_MyTcpClientArm[indexBoard].ClientWrite(m_SendMeas);

            return true;
        }

        /// <summary>
        /// 发送读取输入点指令
        /// </summary>
        /// <param name="board">板卡类型</param>
        public void SendReadInputPoint(Board board)
        {
            SendCommandToArm(board, (byte)Message.MessageCodeARM.GetInput);
        }

        /// <summary>
        /// 设置输入口
        /// </summary>
        /// <param name="board">板卡号/param>
        /// <param name="InputData">输入点位数据</param>
        /// <returns></returns>
        public void SetInputPoint(Board board, uint InputData)
        {
            m_InputValue[(int)board] = InputData;
        }

        /// <summary>
        /// 读取输入口
        /// </summary>
        /// <param name="point">输入点位</param>
        /// <returns></returns>
        public bool ReadInputPoint(ARM_InputPoint point)
        {
            int indexBoard = (int)point / MAX_IO_CHANNEL;  //板卡索引
            int indexPoint = (int)point % MAX_IO_CHANNEL;  //板卡内端口号索引
            uint mask = (uint)1 << indexPoint;

            return (m_InputValue[indexBoard] & mask) > 0;
        }

        /// <summary>
        /// 设置IO输入点的状态备份
        /// </summary>
        /// <param name="Point">输入点位</param>
        /// <param name="State">点位状态</param>
        public void SetInputPointStateBackups(ARM_InputPoint Point, bool State)
        {
            m_InputPointStateBackups[(int)Point] = State;
        }

        /// <summary>
        /// 读取IO输入点的状态备份
        /// </summary>
        /// <param name="Point">输入点位</param>
        /// <returns></returns>
        public bool ReadInputPointStateBackups(ARM_InputPoint Point)
        {
           return m_InputPointStateBackups[(int)Point];
        }

        /// <summary>
        /// 发送读取轴当前位置命令
        /// </summary>
        /// <param name="axis">轴号</param>
        public void SendReadAxisPostion(Axis axis)
        {
            SendCommandToArmWithAxis(axis, (byte)Message.MessageCodeARM.GetAxisStepsAbs);
        }

        /// <summary>
        /// 设置当前位置
        /// </summary>
        /// <param name="axis">轴号</param>
        /// <param name="steps">步数</param>
        public void SetAxisPostion(Axis axis, uint steps)
        {
            int indexBoard = (int)axis / MAX_AXIS_CHANNEL;  //板卡索引
            int indexAxis = (int)axis % MAX_AXIS_CHANNEL;  //板卡内轴号索引

            m_AxisPostion[indexBoard, indexAxis] = (int)steps;  //有负值
        }

        /// <summary>
        /// 读取轴当前位置
        /// </summary>
        /// <param name="axis">轴号</param>
        /// <returns></returns>
        public int ReadAxisPostion(Axis axis)
        {
            int indexBoard = (int)axis / MAX_AXIS_CHANNEL;  //板卡索引
            int indexAxis = (int)axis % MAX_AXIS_CHANNEL;  //板卡内轴号索引

            if (!IsBoardConnected((Board)indexBoard))
                return 0;

            return m_AxisPostion[indexBoard, indexAxis];
        }

        /// <summary>
        /// 发送读取轴状态命令
        /// </summary>
        /// <param name="axis">轴号</param>
        public void SendReadAxisState(Axis axis)
        {
            SendCommandToArmWithAxis(axis, (byte)Message.MessageCodeARM.GetAxisState);
        }

        /// <summary>
        /// 设置轴状态
        /// </summary>
        /// <param name="axis">轴号</param>
        /// <param name="State">状态</param>
        public void SetAxisState(Axis axis, int State)
        {
            int indexBoard = (int)axis / MAX_AXIS_CHANNEL;  //板卡索引
            int indexAxis = (int)axis % MAX_AXIS_CHANNEL;  //板卡内轴号索引

            m_AxisState[(int)indexBoard, (int)indexAxis] = State;  //m_AxisState 中轴的索引为DataIndex - 1
        }

        /// <summary>
        /// 读取轴状态
        /// </summary>
        /// <param name="axis">轴号</param>
        /// <returns>状态</returns>
        public AxisState ReadAxisState(Axis axis)
        {
            int indexBoard = (int)axis / MAX_AXIS_CHANNEL;  //板卡索引
            int indexAxis = (int)axis % MAX_AXIS_CHANNEL;  //板卡内轴号索引

            return (AxisState)m_AxisState[indexBoard, indexAxis]; //m_AxisState 中轴的索引为DataIndex - 1
        }

        /// <summary>
        /// 读取轴状态
        /// </summary>
        /// <param name="axis">轴号</param>
        /// <returns>状态字符串</returns>
        public string ReadAxisStateString(Axis axis)
        {
            int indexBoard = (int)axis / MAX_AXIS_CHANNEL;  //板卡索引
            int indexAxis = (int)axis % MAX_AXIS_CHANNEL;  //板卡内轴号索引

            if (!IsBoardConnected((Board)indexBoard))
                return " ";

            string retStr = " ";
            AxisState State = (AxisState)m_AxisState[indexBoard, indexAxis];
            switch (State)
            {
                case AxisState.Ready:
                    retStr = "轴已准备就绪";
                    break;
                case AxisState.ErrorStop:
                    retStr = "出现错误，轴停止";
                    break;
                case AxisState.Motion:
                    retStr = "轴正在执行运动...";
                    break;
            }

            return retStr;
        }

        /// <summary>
        /// 设置电机轴速度参数
        /// </summary>
        /// <param name="axis">轴号</param>
        /// <param name="velLow">初速度</param>
        /// <param name="velHigh">运行速度</param>
        /// <param name="acc">加速度</param>
        /// <param name="dec">减速度</param>
        /// <param name="Default">是否为默认值</param>
        public bool SetSpeedParam(Axis axis, int velLow, int velHigh, int acc, int dec, bool Default)
        {
            int indexBoard = (int)axis / MAX_AXIS_CHANNEL;  //板卡索引
            int indexAxis = (int)axis % MAX_AXIS_CHANNEL;  //板卡内轴号索引

            if (!IsBoardConnected((Board)indexBoard))
                return false;

            Message.MessageCodeARM Code = Default ? Message.MessageCodeARM.SetAxisParametersDefault : Message.MessageCodeARM.SetAxisParameters;
            Message.MakeSendArrayByCode((byte)Code, ref m_SendMeas);

            int DataIndex = Message.MessageCommandIndex + 1;
            m_SendMeas[DataIndex] = (byte)indexAxis;

            m_SendMeas[DataIndex + 1] = (byte)(velLow & 0xffU);
            m_SendMeas[DataIndex + 2] = (byte)((velLow >> 8) & 0xffU);
            m_SendMeas[DataIndex + 3] = (byte)((velLow >> 16) & 0xffU);
            m_SendMeas[DataIndex + 4] = (byte)((velLow >> 24) & 0xffU);
            m_SendMeas[DataIndex + 5] = (byte)(velHigh & 0xffU);
            m_SendMeas[DataIndex + 6] = (byte)((velHigh >> 8) & 0xffU);
            m_SendMeas[DataIndex + 7] = (byte)((velHigh >> 16) & 0xffU);
            m_SendMeas[DataIndex + 8] = (byte)((velHigh >> 24) & 0xffU);
            m_SendMeas[DataIndex + 9] = (byte)(acc & 0xffU);
            m_SendMeas[DataIndex + 10] = (byte)((acc >> 8) & 0xffU);
            m_SendMeas[DataIndex + 11] = (byte)((acc >> 16) & 0xffU);
            m_SendMeas[DataIndex + 12] = (byte)((acc >> 24) & 0xffU);
            m_SendMeas[DataIndex + 13] = (byte)(dec & 0xffU);
            m_SendMeas[DataIndex + 14] = (byte)((dec >> 8) & 0xffU);
            m_SendMeas[DataIndex + 15] = (byte)((dec >> 16) & 0xffU);
            m_SendMeas[DataIndex + 16] = (byte)((dec >> 24) & 0xffU);

            m_SendMeas[Message.MessageSumCheck] = MyMath.CalculateSum(m_SendMeas, Message.MessageLength);

            m_MyTcpClientArm[indexBoard].ClientWrite(m_SendMeas);

            return true;
        }

        /// <summary>
        /// 移动 -- 绝对位置  （以原点为参照）
        /// </summary>
        /// <param name="axis">电机轴</param>
        /// <param name="steps">步数</param>
        /// <returns></returns>
        public bool MoveAbs(Axis axis, int steps)
        {
            int indexBoard = (int)axis / MAX_AXIS_CHANNEL;  //板卡索引
            int indexAxis = (int)axis % MAX_AXIS_CHANNEL;   //板卡内轴号索引

            if (!IsBoardConnected((Board)indexBoard))
                return false;

            Message.MakeSendArrayByCode((byte)Message.MessageCodeARM.SetAxisStepsAbs, ref m_SendMeas);

            int DataIndex = Message.MessageCommandIndex + 1;

            m_SendMeas[DataIndex] = (byte)indexAxis;
            m_SendMeas[DataIndex + 1] = (byte)(steps & 0xffU);
            m_SendMeas[DataIndex + 2] = (byte)((steps >> 8) & 0xffU);
            m_SendMeas[DataIndex + 3] = (byte)((steps >> 16) & 0xffU);
            m_SendMeas[DataIndex + 4] = (byte)((steps >> 24) & 0xffU);

            m_SendMeas[Message.MessageSumCheck] = MyMath.CalculateSum(m_SendMeas, Message.MessageLength);

            m_MyTcpClientArm[indexBoard].ClientWrite(m_SendMeas);

            return true;
        }

        /// <summary>
        /// 移动 -- 相对位置 （以当前步数为基础）
        /// </summary>
        /// <param name="axis">电机轴</param>
        /// <param name="steps">步数</param>
        /// <returns></returns>
        public bool MoveRef(Axis axis, int steps)
        {
            int indexBoard = (int)axis / MAX_AXIS_CHANNEL;  //板卡索引
            int indexAxis = (int)axis % MAX_AXIS_CHANNEL;  //板卡内轴号索引

            if (!IsBoardConnected((Board)indexBoard))
                return false;

            Message.MakeSendArrayByCode((byte)Message.MessageCodeARM.SetAxisStepsRef, ref m_SendMeas);

            int DataIndex = Message.MessageCommandIndex + 1;

            m_SendMeas[DataIndex] = (byte)indexAxis;
            m_SendMeas[DataIndex + 1] = (byte)(steps & 0xffU);
            m_SendMeas[DataIndex + 2] = (byte)((steps >> 8) & 0xffU);
            m_SendMeas[DataIndex + 3] = (byte)((steps >> 16) & 0xffU);
            m_SendMeas[DataIndex + 4] = (byte)((steps >> 24) & 0xffU);

            m_SendMeas[Message.MessageSumCheck] = MyMath.CalculateSum(m_SendMeas, Message.MessageLength);

            m_MyTcpClientArm[indexBoard].ClientWrite(m_SendMeas);

            return true;
        }

        /// <summary>
        /// 电机轴连续运动
        /// </summary>
        /// <param name="axis">电机轴</param>
        /// <param name="dir">运行方向</param>
        /// <returns></returns>
        public bool MoveContinuous(Axis axis, AxisDir dir)
        {
            bool Re = SendCommandToArmWithAxis(axis, (byte)Message.MessageCodeARM.SetAxisMoveContinuous);
            return Re;
        }

        /// <summary>
        /// 回原点
        /// </summary>
        /// <param name="axis">电机轴</param>
        /// <param name="dir">回原点方向</param>
        /// <returns></returns>
        public bool BackHome(Axis axis, AxisDir dir)
        {
            bool Re = SendCommandToArmWithAxis(axis, (byte)Message.MessageCodeARM.AxisGoHome);
            return Re;
        }

        /// <summary>
        /// 停止
        /// </summary>
        /// <param name="axis">电机轴</param>
        /// <returns></returns>
        public bool Stop(Axis axis)
        {
            bool Re = SendCommandToArmWithAxis(axis, (byte)Message.MessageCodeARM.StopAxis);
            return Re;
        }

        //复位轴错误状态，如果轴处于ErrorStop状态，则在调用此函数后状态将更改为Ready。
        public bool ResetError(Axis axis)
        {
            bool Re = SendCommandToArmWithAxis(axis, (byte)Message.MessageCodeARM.ResetAxisError);
            return Re;
        }

        //设置单片机控制板的IO
        public bool SetArmControlBoardIo(Board board, ARM_OutputPoint Io, IOValue Value)
        {
            if (!IsBoardConnected(board))
                return false;

            int data1 = 8;  //1~8输出口使能控制字节, 最大是0x80
            int data2 = 16;
            int data3 = 24;
            int data4 = 32;

            const int CommandIndex = Message.MessageCommandIndex;
            Message.MakeSendArrayByCode((byte)Message.MessageCodeARM.SetOutput, ref m_SendMeas);

            //根据Type， Value 设置使能位和数据
            int TempIo = (int)Io;
            int ControlIndex = CommandIndex + 1;
            byte ControlValue = 0;
            byte IoData = 0;

            if (TempIo <= data1)
            {
                ControlIndex = CommandIndex + 1;
                ControlValue = (byte)(0x01 << (TempIo - 1));
                IoData = (byte)(((byte)Value) << (TempIo - 1));
            }
            else if (TempIo > data1 && TempIo <= data2)
            {
                ControlIndex = CommandIndex + 2;
                ControlValue = (byte)(0x01 << (TempIo - data1 - 1));
                IoData = (byte)(((byte)Value) << (TempIo - data1 - 1));
            }
            else if (TempIo > data2 && TempIo <= data3)
            {
                ControlIndex = CommandIndex + 3;
                ControlValue = (byte)(0x01 << (TempIo - data2 - 1));
                IoData = (byte)(((byte)Value) << (TempIo - data2 - 1));
            }
            else if (TempIo > data3 && TempIo <= data4)
            {
                ControlIndex = CommandIndex + 4;
                ControlValue = (byte)(0x01 << (TempIo - data3 - 1));
                IoData = (byte)(((byte)Value) << (TempIo - data3 - 1));
            }

            m_SendMeas[ControlIndex] = ControlValue;
            m_SendMeas[ControlIndex + 4] = IoData;
            m_SendMeas[Message.MessageSumCheck] = MyMath.CalculateSum(m_SendMeas, Message.MessageLength);

            m_MyTcpClientArm[(int)board].ClientWrite(m_SendMeas);

            return true;
        }

        //设置单片机控制板控制的按键灯
        public void SetKeyLedByKey(Board board, ARM_InputPoint Key, LED_State LedState)
        {
            IOValue Value = LedState == (LED_State.LED_ON) ? IOValue.IOValueHigh : IOValue.IOValueLow;
            ARM_OutputPoint KeyLed = ARM_OutputPoint.IO_OUT_LedKeyRun;

            switch (Key)
            {
                case ARM_InputPoint.IO_IN_KeyRun:
                    KeyLed = ARM_OutputPoint.IO_OUT_LedKeyRun;
                    break;
                case ARM_InputPoint.IO_IN_KeyPause:
                    KeyLed = ARM_OutputPoint.IO_OUT_LedKeyPause;
                    break;
                case ARM_InputPoint.IO_IN_KeyStop:
                    KeyLed = ARM_OutputPoint.IO_OUT_LedKeyStop;
                    break;
                case ARM_InputPoint.IO_IN_KeyReset:
                    KeyLed = ARM_OutputPoint.IO_OUT_LedKeyReset;
                    break;
                default:
                    break;
            }

            SetArmControlBoardIo(board, KeyLed, Value);
        }
    }
}
