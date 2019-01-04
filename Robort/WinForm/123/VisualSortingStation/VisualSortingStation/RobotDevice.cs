using RABD.DROE.SystemDefine;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotWorkstation
{
    public class RobotDevice : RobotBase
    {
        private static RobotDevice m_UniqueRobot = null;  //定义类的静态成员对象，实现单例模式
        private static readonly object m_Locker = new object();

        public bool m_IsStep = true;  //默认是Jog模式
        public List<cPoint> m_PointList = null;

        //自动运行点位信息  
        //1-10点 系统点位 1,原点  2，二维码扫描点
        //11-30  原始品盘点位，如果有视觉则只用 11点作为坐标临时存储点
        //31-50  分拣后装盘点位 
        public const int m_HomePoint = 1;  //对应机械臂的第0个点
        public const int m_QRCodePoint = 2;
        public const int m_GrapStartPoint =11;
        public const int m_PutStartPoint = 31;

        // 定义私有构造函数，使外界不能创建该类实例
        private RobotDevice()
        {

        }

        /// <summary>
        /// 定义公有方法提供一个全局访问点,同时你也可以定义公有属性来提供全局访问点
        /// </summary>
        /// <returns></returns>
        public static RobotDevice GetInstance()
        {
            if (m_UniqueRobot == null)
            {
                lock (m_Locker)
                {
                    if (m_UniqueRobot == null)
                        m_UniqueRobot = new RobotDevice();
                }
            }

            return m_UniqueRobot;
        }

        public bool InitRobot()
        {
            bool bOpen = m_UniqueRobot.Open(Profile.m_Config.RobotIp);

            return bOpen;
        }

        public void SetRobotPamram(int Speed, int JointDistance, int CartesianDistance)
        {
            if (m_UniqueRobot.IsConnected())
            {
                m_UniqueRobot.SetSpeed(Speed);
                m_UniqueRobot.SetJointDistance(JointDistance);
                m_UniqueRobot.SetCartesianDistance(CartesianDistance);
            }
        }

        public void SetGrapPointCoords(int PointIndex, float x, float y, float z, float rz)
        {
            if (m_UniqueRobot != null)
            {
                cPoint TempPoint = m_UniqueRobot.GetGlobalPoint(PointIndex);
                if (TempPoint != null)
                {
                    TempPoint[eAxisName.X] = x * 1000;
                    TempPoint[eAxisName.Y] = y * 1000;
                    TempPoint[eAxisName.Z] = z * 1000;
                    TempPoint[eAxisName.RZ] = rz * 1000;

                    m_UniqueRobot.SetGlobalPoint(PointIndex, TempPoint);
                }
            }
        }

        public void ReadMulitModbus(ushort Addr, short ReadCount, ref short[] InBuf)
        {
            InBuf = m_Robot.ReadMulitModbus(Addr, ReadCount);
        }

        public void SetRobotIo(Robot_IO_OUT Io, IOValue Value)
        {
            bool State = (Value == IOValue.IOValueLow ? true : false);
            m_Robot.SetOutputState((int)Io, State);
        }
    }
}
