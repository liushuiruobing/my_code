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
        Conveyor = 0,   //传输线
        Max,            //板卡总数
    }

    #region  //IO相关

    public enum ControlBord_IO_IN  //具体编号要等电气连接图出来之后与之相对应，机械臂的IO由机械臂的脚本处理，上位机只查询标志
    {
        //In
        IO_IN_KeyRun = 0,
        IO_IN_KeyPause,
        IO_IN_KeyStop,
        IO_IN_KeyReset,
        IO_IN_EmptySalverAirCylUpArrive,         //空盘气缸上升到位
        IO_IN_EmptySalverAirCylDownArrive,       //空盘气缸下降到位
        IO_IN_ReceiveSalverArrive,               //接收盘到位
        IO_IN_OverturnSalverArrive,              //翻转托盘到位
        IO_IN_OverturnSalverAirCylGoArrive,      //翻转托盘进到位
        IO_IN_OverturnSalverAirCylBackArrive,    //翻转托盘退到位       
    }

    public enum ControlBord_IO_OUT   //具体编号要等电气连接图出来之后与之相对应，
    {
        //Out
        IO_OUT_LedRed = 0,
        IO_OUT_LedOriange,
        IO_OUT_LedGreen,
        IO_OUT_LedBlue,
        IO_OUT_LedKeyRun,
        IO_OUT_LedKeyPause,
        IO_OUT_LedKeyStop,
        IO_OUT_LedKeyReset,
        IO_OUT_Beep,
        IO_OUT_EmptySalverAirCylUp,         //空盘气缸上升
        IO_OUT_EmptySalverAirCylDown,       //空盘气缸下降
        IO_OUT_OverturnSalverAirCyl,        //翻转托盘气缸
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
        Upper1 = 0,
        Max = 5,  //5个电机轴
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

        public const int MAX_IO_CHANNEL = 4 * 8;  //一块板卡包括32/32个隔离数字量输入/输出通道 
        public const int MAX_AXIS_CHANNEL = 8;    //一块板卡包括8个电机轴

        public MyTcpClient[] m_MyTcpClient = new MyTcpClient[(int)Board.Max];
        private bool[] m_IsOpened = new bool[(int)Board.Max];
        private byte[] m_SendMeas = new byte[Message.MessageLength];

        private ArmControler()
        {
            for (int i = 0; i < m_IsOpened.Length; i++)
            {
                m_IsOpened[i] = false;
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
            if (!m_IsOpened[(int)Board.Conveyor])
            {
                m_MyTcpClient[(int)Board.Conveyor] = new MyTcpClient();
                IPAddress ControlIp = IPAddress.Parse(Profile.m_Config.ControlerArmIp);
                int ControlPort = Profile.m_Config.ControlerArmPort;
                m_MyTcpClient[(int)Board.Conveyor].CreateConnect(ControlIp, ControlPort);
            }

            //其他Arm控制板


            for (int i = 0; i < (int)Board.Max; i++)
            {
                if (m_MyTcpClient[i].IsConnected)
                {
                    m_IsOpened[i] = true;
                }
            }
        }

        /// <summary>
        /// 关闭ARM卡
        /// </summary>
        public void Close()
        {
            for (int i = 0; i < (int)Board.Max; i++)
            {
                if (m_IsOpened[i])
                {
                    m_MyTcpClient[i].Close();
                }
            }
        }

        public bool SetControlBoardIo(Board board, ControlBord_IO_OUT Io, IOValue Value)
        {
            if (!m_IsOpened[(int)board])
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

            m_MyTcpClient[(int)board].ClientWrite(m_SendMeas);

            return true;
        }

        public void SendCommandToArm(Board board, byte Code)
        {
            if (!m_IsOpened[(int)board])
                return;

            Message.MakeSendArrayByCode(Code, ref m_SendMeas);
            m_MyTcpClient[(int)board].ClientWrite(m_SendMeas);
        }

        public bool SendCommandToArmWithAxis(Axis axis, byte Code)
        {
            int indexBoard = (int)axis / MAX_AXIS_CHANNEL;  //板卡索引
            int indexAxis = (int)axis % MAX_AXIS_CHANNEL;  //板卡内轴号索引

            if (!m_IsOpened[indexBoard])
                return false;

            Message.MakeSendArrayByCode(Code, ref m_SendMeas);
            m_SendMeas[Message.MessageCommandIndex + 1] = (byte)indexAxis;
            m_SendMeas[Message.MessageSumCheck] = MyMath.CalculateSum(m_SendMeas, Message.MessageLength);

            m_MyTcpClient[indexBoard].ClientWrite(m_SendMeas);

            return true;
        }

        /// <summary>
        /// 发送读取输入点指令
        /// </summary>
        /// <param name="board">板卡类型</param>
        public void SendReadPoint(Board board)
        {
            SendCommandToArm(board, (byte)Message.MessageCodeARM.GetInput);
        }

        /// <summary>
        /// 发送读取轴当前位置命令
        /// </summary>
        /// <param name="axis">轴号</param>
        public void SendReadPostion(Axis axis)
        {
            SendCommandToArmWithAxis(axis, (byte)Message.MessageCodeARM.GetAxisStepsAbs);
        }

        /// <summary>
        /// 发送读取轴状态命令
        /// </summary>
        /// <param name="axis">轴号</param>
        public void SendReadState(Axis axis)
        {
            SendCommandToArmWithAxis(axis, (byte)Message.MessageCodeARM.GetAxisState);
        }
        
        /// <summary>
        /// 移动 -- 绝对位置
        /// </summary>
        /// <param name="axis">电机轴</param>
        /// <param name="steps">步数</param>
        /// <returns></returns>
        public bool MoveAbs(Axis axis, int steps)
        {
            int indexBoard = (int)axis / MAX_AXIS_CHANNEL;  //板卡索引
            int indexAxis = (int)axis % MAX_AXIS_CHANNEL;  //板卡内轴号索引

            if (!m_IsOpened[indexBoard])
                return false;

            Message.MakeSendArrayByCode((byte)Message.MessageCodeARM.SetAxisStepsAbs, ref m_SendMeas);

            int DataIndex = Message.MessageCommandIndex + 1;

            m_SendMeas[DataIndex] = (byte)indexAxis;
            m_SendMeas[DataIndex + 1] = (byte)(steps & 0xffU);
            m_SendMeas[DataIndex + 2] = (byte)((steps >> 8) & 0xffU);
            m_SendMeas[DataIndex + 3] = (byte)((steps >> 16) & 0xffU);
            m_SendMeas[DataIndex + 4] = (byte)((steps >> 24) & 0xffU);

            m_SendMeas[Message.MessageSumCheck] = MyMath.CalculateSum(m_SendMeas, Message.MessageLength);

            m_MyTcpClient[indexBoard].ClientWrite(m_SendMeas);

            return true;
        }

        /// <summary>
        /// 移动 -- 相对位置
        /// </summary>
        /// <param name="axis">电机轴</param>
        /// <param name="steps">步数</param>
        /// <returns></returns>
        public bool MoveRef(Axis axis, int steps)
        {
            int indexBoard = (int)axis / MAX_AXIS_CHANNEL;  //板卡索引
            int indexAxis = (int)axis % MAX_AXIS_CHANNEL;  //板卡内轴号索引

            if (!m_IsOpened[indexBoard])
                return false;


            Message.MakeSendArrayByCode((byte)Message.MessageCodeARM.SetAxisStepsRef, ref m_SendMeas);

            int DataIndex = Message.MessageCommandIndex + 1;

            m_SendMeas[DataIndex] = (byte)indexAxis;
            m_SendMeas[DataIndex + 1] = (byte)(steps & 0xffU);
            m_SendMeas[DataIndex + 2] = (byte)((steps >> 8) & 0xffU);
            m_SendMeas[DataIndex + 3] = (byte)((steps >> 16) & 0xffU);
            m_SendMeas[DataIndex + 4] = (byte)((steps >> 24) & 0xffU);

            m_SendMeas[Message.MessageSumCheck] = MyMath.CalculateSum(m_SendMeas, Message.MessageLength);

            m_MyTcpClient[indexBoard].ClientWrite(m_SendMeas);

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
        /// 停止
        /// </summary>
        /// <param name="axis">电机轴</param>
        /// <returns></returns>
        public bool Stop(Axis axis)
        {
            bool Re = SendCommandToArmWithAxis(axis, (byte)Message.MessageCodeARM.StopAxis);
            return Re;
        }

        /*复位轴错误状态，如果轴处于ErrorStop状态，则在调用此函数后状态将更改为Ready。
 */
        public bool ResetError(Axis axis)
        {
            bool Re = SendCommandToArmWithAxis(axis, (byte)Message.MessageCodeARM.ResetAxisError);
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
        /// 设置电机轴速度参数
        /// </summary>
        /// <param name="axis">轴号</param>
        /// <param name="velLow">初速度</param>
        /// <param name="velHigh">运行速度</param>
        /// <param name="acc">加速度</param>
        /// <param name="dec">减速度</param>
        public bool SetSpeedParam(Axis axis, int velLow, int velHigh, int acc, int dec)
        {
            int indexBoard = (int)axis / MAX_AXIS_CHANNEL;  //板卡索引
            int indexAxis = (int)axis % MAX_AXIS_CHANNEL;  //板卡内轴号索引

            if (!m_IsOpened[indexBoard])
                return false;

            Message.MakeSendArrayByCode((byte)Message.MessageCodeARM.SetAxisParameters, ref m_SendMeas);

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

            m_MyTcpClient[indexBoard].ClientWrite(m_SendMeas);

            return true;
        }

         public void SetKeyLedByKey(Board board, ControlBord_IO_IN Key, LED_State LedState)
        {
            IOValue Value = LedState == (LED_State.LED_ON) ? IOValue.IOValueHigh : IOValue.IOValueLow;
            ControlBord_IO_OUT KeyLed = ControlBord_IO_OUT.IO_OUT_LedKeyRun;

            switch (Key)
            {
                case ControlBord_IO_IN.IO_IN_KeyRun:
                    KeyLed = ControlBord_IO_OUT.IO_OUT_LedKeyRun;
                    break;
                case ControlBord_IO_IN.IO_IN_KeyPause:
                    KeyLed = ControlBord_IO_OUT.IO_OUT_LedKeyPause;
                    break;
                case ControlBord_IO_IN.IO_IN_KeyStop:
                    KeyLed = ControlBord_IO_OUT.IO_OUT_LedKeyStop;
                    break;
                case ControlBord_IO_IN.IO_IN_KeyReset:
                    KeyLed = ControlBord_IO_OUT.IO_OUT_LedKeyReset;
                    break;
                default:
                    break;
            }

            SetControlBoardIo(board, KeyLed, Value);
        }
    }
}
