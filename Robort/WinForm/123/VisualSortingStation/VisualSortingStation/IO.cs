using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotWorkstation
{
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

    public enum Robot_IO_IN  //要与实际的接线对应
    {
        Robot_IO_IN_CylGoArrive = 0x01,     //抓手气缸进到位
        Robot_IO_IN_CylBackArrive,          //抓手气缸退到位
        Robot_IO_IN_VacuoCheck,             //吸嘴真空检测
        Robot_WritePointSuccessed           //机械臂写点位成功
    }

    public enum Robot_IO_OUT  //要与实际的接线对应
    {
        Robot_IO_OUT_Cyl = 0x01,    //抓手气缸
        Robot_IO_OUT_Vacuo          //吸嘴
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

    public class IO  //IO的控制
    {
        private static IO m_UniqueIo = null;
        private static readonly object m_Locker = new object();
        private static MyTcpClient m_MyTcpClientArm = MainForm.GetMyTcpClientArm();

        private IO()
        {

        }

        /// <summary>
        /// 定义公有方法提供一个全局访问点,同时你也可以定义公有属性来提供全局访问点
        /// </summary>
        /// <returns></returns>
        public static IO GetInstance()
        {
            if (m_UniqueIo == null)
            {
                lock (m_Locker)
                {
                    if (m_UniqueIo == null)
                        m_UniqueIo = new IO();
                }
            }
            return m_UniqueIo;
        }

        public bool SetControlBoardIo(ControlBord_IO_OUT Io, IOValue Value)
        {
            bool Re = false;

            int data1 = 8;  //1~8输出口使能控制字节, 最大是0x80
            int data2 = 16;
            int data3 = 24;
            int data4 = 32;

            //给单片机控制板发送消息
            if (m_MyTcpClientArm != null && m_MyTcpClientArm.IsConnected)
            {
                byte[] SendMeas = new byte[Message.MessageLength];
                const int CommandIndex = Message.MessageCommandIndex;

                SendMeas[0] = Message.MessStartCode;
                SendMeas[1] = Message.MessVID1;
                SendMeas[2] = Message.MessVID2;
                SendMeas[3] = Message.MessVer;
                SendMeas[Message.MessageStateIndex] = Message.MessRightState;
                SendMeas[CommandIndex] = (byte)Message.MessageCodeARM.SetOutIo;

                //其余位先填充0x00
                for (int i = CommandIndex + 1; i < Message.MessageLength - 1; i++)
                    SendMeas[i] = 0x00;

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

                SendMeas[ControlIndex] = ControlValue;
                SendMeas[ControlIndex + 4] = IoData;

                SendMeas[Message.MessageLength - 1] = Message.MessEndCode;

                byte Sum = 0;
                foreach (byte Temp in SendMeas)
                    Sum += Temp;

                SendMeas[Message.MessageLength - 2] = (byte)(0 - Sum);  //校验和
                
                m_MyTcpClientArm.ClientWrite(SendMeas);

                Re = true;
            }

            return Re;
        }

        public void ReadControlBoardIo(byte Code, ref byte[] SendMeas)
        {
            if (m_MyTcpClientArm != null && m_MyTcpClientArm.IsConnected)
            {
                Message.MakeSendArrayByCode(Code, ref SendMeas);
                m_MyTcpClientArm.ClientWrite(SendMeas);
            }
        }

        public void SetKeyLedByKey(ControlBord_IO_IN Key, LED_State LedState)
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

            SetControlBoardIo(KeyLed, Value);
        }
    }
}
