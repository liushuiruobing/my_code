using Advantech.Motion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RobotWorkstation
{
    public struct PointInfo
    {
        double X;
        double Y;
        double Z;

        public PointInfo(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }
    }

    public class GraspRobot  //运动控制卡控制
    {
        public enum Robot_Out  //具体编号要等电气连接图出来之后与之相对应，接到运动控制卡上
        {
            //In
            IO_OUT_AirCyl = 0,          //使用IO卡的 X_OUT4
            IO_OUT_GraspDeviceNozzle,   //使用IO卡的 X_OUT5
            IO_OUT_GraspSalverNozzle1,  //使用IO卡的 Y_OUT4
            IO_OUT_GraspSalverNozzle2,  //使用IO卡的 Y_OUT5
            IO_OUT_GraspSalverNozzle3,  //使用IO卡的 Z_OUT4
            IO_OUT_GraspSalverNozzle4,  //使用IO卡的 Z_OUT5
        }

        public enum Robot_In  //具体编号要等电气连接图出来之后与之相对应，接到运动控制卡上
        {
            //In
            IO_IN_AirCylGoArrive = 0,       //使用IO卡的 X_IN1
            IO_IN_AirCylBackArrive,         //使用IO卡的 X_IN4
            IO_IN_GraspDeviceNozzleCheck,   //使用IO卡的 X_IN5
            IO_IN_GraspSalverNozzleCheck1,  //使用IO卡的 Y_IN1
            IO_IN_GraspSalverNozzleCheck2,  //使用IO卡的 X_IN4
            IO_IN_GraspSalverNozzleCheck3,  //使用IO卡的 X_IN5
            IO_IN_GraspSalverNozzleCheck4,  //使用IO卡的 Z_IN1
        }

        public enum PointInforType
        {
            DeviceGraps = 0,
            EmptySalverAcceptsGraps,
            EmptySalverUnAcceptsGraps,
            FullSalverAcceptsPut,
            FullSalverUnAcceptsPut
        }

        public enum GraspAndPutType
        {
            Device = 0,
            Salver
        }

        private static GraspRobot m_UniqueFourAxisRobot = null;
        private static readonly object m_Locker = new object();
        private MotionControler m_MotionControler = MotionControler.GetInstance();

        //点位信息
        private PointInfo[,] DeviceAcceptsPutPoints = new PointInfo[Product.SalverRow, Product.SalverCol];   //合格品、不合格品放置点均按照最大盘的行列数定义
        private PointInfo[,] DeviceUnAcceptsPutPoints = new PointInfo[Product.SalverRow, Product.SalverCol];
        private PointInfo FullSalverAcceptsPutPoint = new PointInfo();     //满盘合格品放置点位
        private PointInfo FullSalverUnAcceptsPutPoint = new PointInfo();   //满盘不合格品放置点位
        private PointInfo DeviceGrapsPoint = new PointInfo();                //器件抓取点
        private PointInfo EmptySalverAcceptsGrapsPoint = new PointInfo();    //空盘合格品盘抓取点
        private PointInfo EmptySalverUnAcceptsGrapsPoint = new PointInfo();  //空盘不合格品盘抓取点

        public bool m_IsConnected
        {
            get
            {
                return m_MotionControler.m_InitBoard;
            }
        }

        public int m_Distance
        {
            set
            {
                m_MotionControler.m_Distance = value;
            }
            get
            {
                return m_MotionControler.m_Distance;
            }
        }

        // 定义私有构造函数，使外界不能创建该类实例
        private GraspRobot()
        {

        }

        /// <summary>
        /// 定义公有方法提供一个全局访问点,同时你也可以定义公有属性来提供全局访问点
        /// </summary>
        /// <returns></returns>
        public static GraspRobot GetInstance()
        {
            if (m_UniqueFourAxisRobot == null)
            {
                lock (m_Locker)
                {
                    if (m_UniqueFourAxisRobot == null)
                        m_UniqueFourAxisRobot = new GraspRobot();
                }
            }
            return m_UniqueFourAxisRobot;
        }

        public bool InitRobot()
        {
            bool Re = false;

            if (!m_IsConnected)
            {
                m_MotionControler.InitMotionControler();
                Re = OpenRobot();
            }
                
            return Re;
        }

        public bool OpenRobot()
        {
            bool Re = false;
            if (!m_IsConnected)
            {
                Re = m_MotionControler.OpenDevice();
            }

            return Re;
        }

        public void LoadRobotConfig(string FileName)
        {
            if (m_IsConnected)
            {
                m_MotionControler.LoadMotionControlerConfig(FileName);
            }
        }

        public void CloseRobot()
        {
            if (m_IsConnected)
            {
                m_MotionControler.CloseDevice();
            }
        }

        //让轴回原点要通过GetAxisCurState()来判断是否回归到原点
        public void GoHome(AxisNum Axis, AxisRunDir Dir)
        {
            if (m_IsConnected)
            {
                m_MotionControler.GoHome(Axis, Dir);
            }
        }

        public AxisCurState GetAxisCurState(AxisNum Axis)
        {
            AxisCurState CurState = AxisCurState.AxisState_Wrong;
            if (m_IsConnected)
            {
                CurState = m_MotionControler.GetAxisCurState(Axis);
            }

            return CurState;
        }

        public void SetSpeed(AxisNum axis, double AxVelLow, double AxVelHigh, double AxAcc, double AxDec)
        {
            if (m_IsConnected)
            {
                m_MotionControler.SetMotionAxisSpeedParam(axis, AxVelLow, AxVelHigh, AxAcc, AxDec);
            }
        }

        public void MoveAxis(AxisNum CurAxis, AxisRunDir Dir)
        {
            if (m_IsConnected)
            {
                m_MotionControler.MoveMotion(CurAxis, Dir);
            }
        }

        public void MoveToPoint(PointInfo Point)
        {
            GoHome(AxisNum.Axis_Z, AxisRunDir.Dir_Reverse);  //先让Z轴回原点，再移动臂，避免底部碰撞
            
            MoveAxis(AxisNum.Axis_X, AxisRunDir.Dir_Forward);
            MoveAxis(AxisNum.Axis_Y, AxisRunDir.Dir_Forward);
            MoveAxis(AxisNum.Axis_Z, AxisRunDir.Dir_Forward);
        }

        public void Stop(uint CurAxis)
        {
            if (m_IsConnected)
            {
                m_MotionControler.StopMotion(CurAxis);
            }
        }

        public void ResetError(AxisNum Axis)
        {
            if (m_IsConnected)
            {
                m_MotionControler.ResetErr(Axis);
            }
        }

        public void SetDevicePutPoints(Product.ProductType product, Product.SalverType salver, ref PointInfo[,] Points)
        {
            if (product == Product.ProductType.Accepts)  //合格品
            {
                for (int i = 0; i < Product.SalverRow; i++)
                {
                    for (int j = 0; j < Product.SalverCol; j++)
                    {
                        DeviceAcceptsPutPoints[i, j] = Points[i, j];
                    }
                }
            }
            else if (product == Product.ProductType.UnAccepts)  //不合格品
            {
                for (int i = 0; i < Product.SalverRow; i++)
                {
                    for (int j = 0; j < Product.SalverCol; j++)
                    {
                        DeviceUnAcceptsPutPoints[i, j] = Points[i, j];
                    }
                }
            }
        }

        //设置单个点位信息
        public void SetPoint(PointInforType type, ref PointInfo Point)
        {
            switch (type)
            {
                case PointInforType.DeviceGraps:
                    DeviceGrapsPoint = Point;
                    break;
                case PointInforType.EmptySalverAcceptsGraps:
                    EmptySalverAcceptsGrapsPoint = Point;
                    break;
                case PointInforType.EmptySalverUnAcceptsGraps:
                    EmptySalverUnAcceptsGrapsPoint = Point;
                    break;
                case PointInforType.FullSalverAcceptsPut:
                    FullSalverAcceptsPutPoint = Point;
                    break;
                case PointInforType.FullSalverUnAcceptsPut:
                    FullSalverUnAcceptsPutPoint = Point;
                    break;
                default:
                    break;
            }
        }

        public void GetAxisAndChannelByRobotOut(Robot_Out Io, ref AxisNum Axis, ref ushort Channel )
        {
            switch (Io)
            {
                case Robot_Out.IO_OUT_AirCyl:
                    {
                        Axis = AxisNum.Axis_X;   //使用IO卡的 X_OUT4
                        Channel = 4;
                    }
                    break;
                case Robot_Out.IO_OUT_GraspDeviceNozzle:
                    {
                        Axis = AxisNum.Axis_X;   //使用IO卡的 X_OUT5
                        Channel = 5;
                    }
                    break;
                case Robot_Out.IO_OUT_GraspSalverNozzle1:
                    {
                        Axis = AxisNum.Axis_Y;   //使用IO卡的 Y_OUT4
                        Channel = 4;
                    }
                    break;
                case Robot_Out.IO_OUT_GraspSalverNozzle2:
                    {
                        Axis = AxisNum.Axis_Y;   //使用IO卡的 Y_OUT5
                        Channel = 5;
                    }
                    break;
                case Robot_Out.IO_OUT_GraspSalverNozzle3:
                    {
                        Axis = AxisNum.Axis_Z;   //使用IO卡的 Z_OUT4
                        Channel = 4;
                    }
                    break;
                case Robot_Out.IO_OUT_GraspSalverNozzle4:
                    {
                        Axis = AxisNum.Axis_Z;   //使用IO卡的 Z_OUT5
                        Channel = 5;
                    }
                    break;
                default:
                    break;
            }
        }

        public void GetAxisAndChannelByRobotIn(Robot_In Io, ref AxisNum Axis, ref ushort Channel)
        {
            switch (Io)
            {
                case Robot_In.IO_IN_AirCylGoArrive:
                    {
                        Axis = AxisNum.Axis_X;   //使用IO卡的 X_IN1
                        Channel = 1;
                    }
                    break;
                case Robot_In.IO_IN_AirCylBackArrive:
                    {
                        Axis = AxisNum.Axis_X;   //使用IO卡的 X_IN4
                        Channel = 4;
                    }
                    break;
                case Robot_In.IO_IN_GraspDeviceNozzleCheck:
                    {
                        Axis = AxisNum.Axis_X;   //使用IO卡的 X_IN5
                        Channel = 5;
                    }
                    break;
                case Robot_In.IO_IN_GraspSalverNozzleCheck1:
                    {
                        Axis = AxisNum.Axis_Y;   //使用IO卡的 Y_IN1
                        Channel = 1;
                    }
                    break;
                case Robot_In.IO_IN_GraspSalverNozzleCheck2:
                    {
                        Axis = AxisNum.Axis_Y;   //使用IO卡的 Y_IN4
                        Channel = 4;
                    }
                    break;
                case Robot_In.IO_IN_GraspSalverNozzleCheck3:
                    {
                        Axis = AxisNum.Axis_Y;   //使用IO卡的 Y_IN5
                        Channel = 5;
                    }
                    break;
                case Robot_In.IO_IN_GraspSalverNozzleCheck4:
                    {
                        Axis = AxisNum.Axis_Z;   //使用IO卡的 Z_IN1
                        Channel = 1;
                    }
                    break;
                default:
                    break;
            }
        }

        public void SetRobotIo(Robot_Out Io, IOValue Value)
        {
            if (m_IsConnected)
            {
                AxisNum axis = 0;
                ushort channel = 0;
                GetAxisAndChannelByRobotOut(Io, ref axis, ref channel);
                m_MotionControler.SetMotionIo(axis, channel, (byte)Value);
            }
        }

        public IOValue GetRobotIo(Robot_In Io)
        {
            IOValue Value = IOValue.IOValueLow;

            if (m_IsConnected)
            {
                AxisNum axis = 0;
                ushort channel = 0;
                GetAxisAndChannelByRobotIn(Io, ref axis, ref channel);
                Value = (IOValue)m_MotionControler.GetMotionIo(axis, channel);
            }

            return Value;
        }

        public bool CheckGraspAndPutIo(GraspAndPutType type, IOValue value)
        {
            bool Re = false;

            if (m_IsConnected)
            {
                if (type == GraspAndPutType.Device)
                {
                    Re = (GetRobotIo(Robot_In.IO_IN_GraspDeviceNozzleCheck) == value);
                }
                else
                {
                    Re = ((GetRobotIo(Robot_In.IO_IN_GraspSalverNozzleCheck1) == value) &&
                          (GetRobotIo(Robot_In.IO_IN_GraspSalverNozzleCheck2) == value) &&
                          (GetRobotIo(Robot_In.IO_IN_GraspSalverNozzleCheck3) == value) &&
                          (GetRobotIo(Robot_In.IO_IN_GraspSalverNozzleCheck4) == value));
                }
            }

            return Re;
        }

        //抓取
        public bool Grasp(GraspAndPutType type, PointInfo Point)
        {
            bool Re = false;

            if (m_IsConnected)
            {
                MoveToPoint(Point);

                if (type == GraspAndPutType.Device)
                {
                    SetRobotIo(Robot_Out.IO_OUT_GraspDeviceNozzle, IOValue.IOValueHigh);
                } 
                else
                {
                    SetRobotIo(Robot_Out.IO_OUT_GraspSalverNozzle1, IOValue.IOValueHigh);
                    SetRobotIo(Robot_Out.IO_OUT_GraspSalverNozzle2, IOValue.IOValueHigh);
                    SetRobotIo(Robot_Out.IO_OUT_GraspSalverNozzle3, IOValue.IOValueHigh);
                    SetRobotIo(Robot_Out.IO_OUT_GraspSalverNozzle4, IOValue.IOValueHigh);
                }

                Re = CheckGraspAndPutIo(type, IOValue.IOValueHigh);
            }

            return Re;       
        }

        //放置
        public bool Put(GraspAndPutType type, PointInfo Point)
        {
            bool Re = false;
            if (m_IsConnected)
            {
                MoveToPoint(Point);

                if (type == GraspAndPutType.Device)
                {
                    SetRobotIo(Robot_Out.IO_OUT_GraspDeviceNozzle, IOValue.IOValueLow);
                }
                else
                {
                    SetRobotIo(Robot_Out.IO_OUT_GraspSalverNozzle1, IOValue.IOValueLow);
                    SetRobotIo(Robot_Out.IO_OUT_GraspSalverNozzle2, IOValue.IOValueLow);
                    SetRobotIo(Robot_Out.IO_OUT_GraspSalverNozzle3, IOValue.IOValueLow);
                    SetRobotIo(Robot_Out.IO_OUT_GraspSalverNozzle4, IOValue.IOValueLow);
                }

                Re = CheckGraspAndPutIo(type, IOValue.IOValueLow);
            }

            return Re;
        }
    }
}
