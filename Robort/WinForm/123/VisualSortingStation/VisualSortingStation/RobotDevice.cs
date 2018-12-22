using RABD.DROE.SystemDefine;
using System;
using System.Collections.Generic;
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
    }
}
