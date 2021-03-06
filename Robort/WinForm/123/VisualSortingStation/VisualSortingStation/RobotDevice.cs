﻿using RABD.DROE.SystemDefine;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotWorkstation
{
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
        public const int m_HomePoint = 0;                //对应机械臂的第0个点
        public const int m_QRCodePoint = 1;              //二维码扫描点
        public const int m_VisualGrapStartPoint =10;     //视觉开始抓取点,  注意和机器人脚本软件相对应，+100后是抓取点上空
        public const int m_VisualPutStartPoint = 30;     //视觉开始放置点， 注意和机器人脚本软件相对应，+100后是放置点上空

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
