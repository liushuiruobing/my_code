using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotWorkstation
{
    public enum IOType  //具体编号要等电气连接图出来之后与之相对应
    {
        //In
        IOTypeKeyRun = 0,
        IOTypeKeyPause,
        IOTypeKeyStop,
        IOTypeKeyReset,
        IOTypeEmptyPanelUpArrive,       //空盘气缸上升到位
        IOTypeEmptyPanelDownArrive,     //空盘气缸下降到位
        IOTypeOverturnPanelArrive,      //翻转托盘到位
        IOTypeRobotCylGoArrive,         //机械臂抓手气缸进到位
        IOTypeRobotCylBackArrive,       //机械臂抓手气缸退到位
        IOTypeRobotVacuoCheck,          //真空检测

        //Out
        IOTypeLedRed,
        IOTypeLedYellow,
        IOTypeLedGreen,
        IOTypeLedBlue,
        IOTypeBeep,
        IOTypeEmptyPanelUp,         //空盘气缸上升
        IOTypeEmptyPanelDown,       //空盘气缸下降
        IOTypeRobotCylinder,        //机械臂抓手气缸
        IOTypeRobotNozzleInhale,    //吸嘴吸
        IOTypeRobotNozzleBlow,      //吸嘴吹
    }

    public enum IOValue
    {
        IOValueLow = 0,
        IOValueHigh
    }

    public class IO  //IO的控制
    {
        private static IO m_UniqueIo = null;
        private static readonly object m_Locker = new object();

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

        public void SetRobotIo(IOType Type, IOValue Value)
        {
            //给机械臂发送消息
        }

        public void SetControlBoardIo(IOType Type, IOValue Value)
        {
            //给单片机控制板发送消息
        }

        //在与IO控制板的通信线程中调用此函数，从单片机读取到的是4个byte数据
        public void ProcessIoMeassage(byte[] data)
        {
            for (int i = 0; i < data.Length; i++)
            {
                byte temp = data[i];

                //根据解析的数据 设置不同的状态 DataStruct.SysStat 中不同的状态                
            }
        }
    }
}
