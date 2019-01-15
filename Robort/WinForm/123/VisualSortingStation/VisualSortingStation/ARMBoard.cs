//#define __HAS_ARM_BOARD  //具备ARM板卡
#define _DEBUG_ARM_BOARD

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace RobotWorkstation
{
    //ARM驱动板驱动驱动
    public class ARMBoard
    {
        public const int MAX_IO_CHANNEL = 4 * 8;    //一块板卡包括32/32个隔离数字量输入/输出通道 
        public const int MAX_AXIS_CHANNEL = 8;      //一块板卡包括8个电机轴

        //板卡定义
        public enum Board
        {
            Conveyor = 0,  //传输线
            Fail = 1,  //不合格品模组
            Pc1to8 = 2,  //PC机1到8
            Pc9to16 = 3,  //PC机9到16
            Max = 4,  //4块板卡
        }

        //电机轴定义
        public enum Axis
        {
            Upper1 = 0 + Board.Conveyor * MAX_AXIS_CHANNEL,  //上层传输线电机轴1
            Upper2 = 1 + Board.Conveyor * MAX_AXIS_CHANNEL,  //上层传输线电机轴2
            Lower1 = 2 + Board.Conveyor * MAX_AXIS_CHANNEL,  //下层传输线电机轴1
            Lower2 = 3 + Board.Conveyor * MAX_AXIS_CHANNEL,  //下层传输线电机轴2
            Fail = 0 + Board.Fail * MAX_AXIS_CHANNEL,  //不合格品模组

            Max = 5,  //5个电机轴
        }

        //电机驱动状态
        public enum AxisState
        {
            Ready = 0,  //轴已准备就绪
            ErrorStop = 1,  //出现错误，轴停止
            Motion = 2,  //轴正在执行运动
        }

        //输出点位
        public enum OutputPoint
        {
            CylDeviceALeft = 0 + Board.Conveyor * MAX_IO_CHANNEL,  //物料托盘A左气缸
            CylDeviceARight = 1 + Board.Conveyor * MAX_IO_CHANNEL,  //物料托盘A右气缸
            CylDeviceARise = 2 + Board.Conveyor * MAX_IO_CHANNEL,  //物料托盘A顶升气缸
            CylDeviceAStop = 3 + Board.Conveyor * MAX_IO_CHANNEL,  //物料托盘A阻挡气缸

            CylDeviceBLeft = 4 + Board.Conveyor * MAX_IO_CHANNEL,  //物料托盘B左气缸
            CylDeviceBRight = 5 + Board.Conveyor * MAX_IO_CHANNEL,  //物料托盘B右气缸
            CylDeviceBRise = 6 + Board.Conveyor * MAX_IO_CHANNEL,  //物料托盘B顶升气缸
            CylDeviceBStop = 7 + Board.Conveyor * MAX_IO_CHANNEL,  //物料托盘B阻挡气缸

            LampRed = 8 + Board.Conveyor * MAX_IO_CHANNEL,  //红色塔灯亮
            LampOrange = 9 + Board.Conveyor * MAX_IO_CHANNEL,  //橙色塔灯亮
            LampGreen = 10 + Board.Conveyor * MAX_IO_CHANNEL,  //绿色塔灯亮
            LampBlue = 11 + Board.Conveyor * MAX_IO_CHANNEL,  //蓝色塔灯亮
            Beep = 12 + Board.Conveyor * MAX_IO_CHANNEL,  //峰鸣

            CylFailEmptyLeft = 0 + Board.Fail * MAX_IO_CHANNEL,  //不合格品空盘左气缸
            CylFailEmptyRight = 1 + Board.Fail * MAX_IO_CHANNEL,  //不合格品空盘右气缸
            CylFailEmptyRise = 2 + Board.Fail * MAX_IO_CHANNEL,  //不合格品空盘顶升气缸

            Pc1Reset = 1 + Board.Pc1to8 * MAX_IO_CHANNEL,  //1#WiFi测试仪的驱动工控机复位控制
            Pc2Reset = 2 + Board.Pc1to8 * MAX_IO_CHANNEL,  //2#WiFi测试仪的驱动工控机复位控制
            Pc3Reset = 3 + Board.Pc1to8 * MAX_IO_CHANNEL,  //3#WiFi测试仪的驱动工控机复位控制
            Pc4Reset = 4 + Board.Pc1to8 * MAX_IO_CHANNEL,  //4#WiFi测试仪的驱动工控机复位控制
            Pc5Reset = 5 + Board.Pc1to8 * MAX_IO_CHANNEL,  //5#WiFi测试仪的驱动工控机复位控制
            Pc6Reset = 6 + Board.Pc1to8 * MAX_IO_CHANNEL,  //6#WiFi测试仪的驱动工控机复位控制
            Pc7Reset = 7 + Board.Pc1to8 * MAX_IO_CHANNEL,  //7#WiFi测试仪的驱动工控机复位控制
            Pc8Reset = 8 + Board.Pc1to8 * MAX_IO_CHANNEL,  //8#WiFi测试仪的驱动工控机复位控制

            Pc9Reset = 1 + Board.Pc9to16 * MAX_IO_CHANNEL,  //9#WiFi测试仪的驱动工控机复位控制
            Pc10Reset = 2 + Board.Pc9to16 * MAX_IO_CHANNEL,  //10#WiFi测试仪的驱动工控机复位控制
            Pc11Reset = 3 + Board.Pc9to16 * MAX_IO_CHANNEL,  //11#WiFi测试仪的驱动工控机复位控制
            Pc12Reset = 4 + Board.Pc9to16 * MAX_IO_CHANNEL,  //12#WiFi测试仪的驱动工控机复位控制
            Pc13Reset = 5 + Board.Pc9to16 * MAX_IO_CHANNEL,  //13#WiFi测试仪的驱动工控机复位控制
            Pc14Reset = 6 + Board.Pc9to16 * MAX_IO_CHANNEL,  //14#WiFi测试仪的驱动工控机复位控制
            Pc15Reset = 7 + Board.Pc9to16 * MAX_IO_CHANNEL,  //15#WiFi测试仪的驱动工控机复位控制
            Pc16Reset = 8 + Board.Pc9to16 * MAX_IO_CHANNEL,  //16#WiFi测试仪的驱动工控机复位控制
        }

        //气缸控制信号
        public const bool OUTPUT_CYL_GO = false;  //气缸进
        public const bool OUTPUT_CYL_BACK = true;  //气缸退

        //输入点位
        public enum InputPoint
        {
            CylDeviceALeftGo = 0 + Board.Conveyor * MAX_IO_CHANNEL,  //物料托盘A左气缸进到位
            CylDeviceALeftBack = 1 + Board.Conveyor * MAX_IO_CHANNEL,  //物料托盘A左气缸退到位
            CylDeviceARightGo = 2 + Board.Conveyor * MAX_IO_CHANNEL,  //物料托盘A右气缸进到位
            CylDeviceARightBack = 3 + Board.Conveyor * MAX_IO_CHANNEL,  //物料托盘A右气缸退到位
            CylDeviceAUp = 4 + Board.Conveyor * MAX_IO_CHANNEL,  //物料托盘A顶升气缸进到位
            CylDeviceADown = 5 + Board.Conveyor * MAX_IO_CHANNEL,  //物料托盘A顶升气缸退到位
            CylDeviceAStopGo = 6 + Board.Conveyor * MAX_IO_CHANNEL,  //物料托盘A阻挡气缸进到位
            CylDeviceAStopBack = 7 + Board.Conveyor * MAX_IO_CHANNEL,  //物料托盘A阻挡气缸退到位

            CylDeviceBLeftGo = 8 + Board.Conveyor * MAX_IO_CHANNEL,  //物料托盘B左气缸进到位
            CylDeviceBLeftBack = 9 + Board.Conveyor * MAX_IO_CHANNEL,  //物料托盘B左气缸退到位
            CylDeviceBRightGo = 10 + Board.Conveyor * MAX_IO_CHANNEL,  //物料托盘B右气缸进到位
            CylDeviceBRightBack = 11 + Board.Conveyor * MAX_IO_CHANNEL,  //物料托盘B右气缸退到位
            CylDeviceBUp = 12 + Board.Conveyor * MAX_IO_CHANNEL,  //物料托盘B顶升气缸进到位
            CylDeviceBDown = 13 + Board.Conveyor * MAX_IO_CHANNEL,  //物料托盘B顶升气缸退到位
            CylDeviceBStopGo = 14 + Board.Conveyor * MAX_IO_CHANNEL,  //物料托盘B阻挡气缸进到位
            CylDeviceBStopBack = 15 + Board.Conveyor * MAX_IO_CHANNEL,  //物料托盘B阻挡气缸退到位

            TrayDeviceIn = 16 + Board.Conveyor * MAX_IO_CHANNEL,  //上层传输线物料托盘进入到位
            TrayDeviceMiddle = 17 + Board.Conveyor * MAX_IO_CHANNEL,  //上层传输线物料托盘中间到位
            TrayDeviceOut = 18 + Board.Conveyor * MAX_IO_CHANNEL,  //上层传输线物料托盘送出到位
            TrayEmptyIn = 19 + Board.Conveyor * MAX_IO_CHANNEL,  //下层传输线空托盘进入到位
            TrayEmptyMiddle = 20 + Board.Conveyor * MAX_IO_CHANNEL,  //下层传输线空托盘中间到位
            TrayEmptyOut = 21 + Board.Conveyor * MAX_IO_CHANNEL,  //下层传输线空托盘送出到位
            TrayDeviceInRFID = 22 + Board.Conveyor * MAX_IO_CHANNEL,  //RFID读码器前托盘到位

            KeyRun = 23 + Board.Conveyor * MAX_IO_CHANNEL,  //按键,运行 IDI25
            KeyPause = 24 + Board.Conveyor * MAX_IO_CHANNEL,  //按键,暂停 IDI27
            KeyStop = 25 + Board.Conveyor * MAX_IO_CHANNEL,  //按键,停止 IDI29
            KeyReset = 26 + Board.Conveyor * MAX_IO_CHANNEL,  //按键,复位  IDI31

            CylFailEmptyLeftGo = 0 + Board.Fail * MAX_IO_CHANNEL,  //不合格品空盘左气缸进到位
            CylFailEmptyLeftBack = 1 + Board.Fail * MAX_IO_CHANNEL,  //不合格品空盘左气缸退到位
            CylFailEmptyRightGo = 2 + Board.Fail * MAX_IO_CHANNEL,  //不合格品空盘右气缸进到位
            CylFailEmptyRightBack = 3 + Board.Fail * MAX_IO_CHANNEL,  //不合格品空盘右气缸退到位
            CylFailEmptyUp = 4 + Board.Fail * MAX_IO_CHANNEL,  //不合格品空盘顶升气缸进到位
            CylFailEmptyDown = 5 + Board.Fail * MAX_IO_CHANNEL,  //不合格品空盘顶升气缸退到位

            AxisFailHome = 6 + Board.Fail * MAX_IO_CHANNEL,  //不合格品轴原点位置到位信号
            AxisFailFull = 7 + Board.Fail * MAX_IO_CHANNEL,  //不合格品轴满盘位置到位信号
            AxisFailWork = 8 + Board.Fail * MAX_IO_CHANNEL,  //不合格品轴工作位置到位信号

            TrayFailEmptyLack = 9 + Board.Fail * MAX_IO_CHANNEL,  //不合格品空盘缺盘
            TrayFailFullFill = 10 + Board.Fail * MAX_IO_CHANNEL,  //不合格品满盘堆满

            MAX = 100,  //最大值
        }

        public const bool INPUT_STATE_OK = false;  //输入信号到位
        public const bool INPUT_STATE_NO = true;  //输入信号不到位

        private uint[] m_InputBuffer = new uint[(int)Board.Max] { 0, 0, 0, 0, };  //输入口缓冲区
        private uint[] m_OutputBuffer = new uint[(int)Board.Max] { 0, 0, 0, 0, };  //输出口缓冲区
        private bool[] m_ShouldWriteOutput = new bool[(int)Board.Max] { false, false, false, false, };  //需要写入输出端口

        private int[,] m_AxisState = new int[(int)Board.Max, MAX_AXIS_CHANNEL]
        {
            { 0, 0, 0, 0, 0, 0, 0, 0, },
            { 0, 0, 0, 0, 0, 0, 0, 0, },
            { 0, 0, 0, 0, 0, 0, 0, 0, },
            { 0, 0, 0, 0, 0, 0, 0, 0, },
        };  //电机轴状态

        private int[,] m_AxisPostion = new int[(int)Board.Max, MAX_AXIS_CHANNEL]
        {
            { 0, 0, 0, 0, 0, 0, 0, 0, },
            { 0, 0, 0, 0, 0, 0, 0, 0, },
            { 0, 0, 0, 0, 0, 0, 0, 0, },
            { 0, 0, 0, 0, 0, 0, 0, 0, },
        };  //电机轴当前位置

        private bool[] m_IsOpened = new bool[(int)Board.Max] { false, false, false, false, };  //IO卡已经打开

        private MyTcpClient[] m_MyTcpClient = new MyTcpClient[(int)Board.Max];

        private static ARMBoard m_UniqueInstance;  //定义一个静态变量来保存类的实例
        private static readonly object m_locker = new object();  //定义一个标识确保线程同步

        /// <summary>
        /// 定义私有构造函数，使外界不能创建该类实例
        /// </summary>
        private ARMBoard()
        {
        }

        /// <summary>
        /// 定义公有方法提供一个全局访问点,同时你也可以定义公有属性来提供全局访问点
        /// </summary>
        /// <returns></returns>
        public static ARMBoard GetInstance()
        {
            // 当第一个线程运行到这里时，此时会对locker对象 "加锁"，
            // 当第二个线程运行该方法时，首先检测到locker对象为"加锁"状态，该线程就会挂起等待第一个线程解锁
            // lock语句运行完之后（即线程运行完之后）会对该对象"解锁"
            // 双重锁定只需要一句判断就可以了
            if (m_UniqueInstance == null)
            {
                lock (m_locker)
                {
                    if (m_UniqueInstance == null)  // 如果类的实例不存在则创建，否则直接返回
                    {
                        m_UniqueInstance = new ARMBoard();
                    }
                }
            }

            return m_UniqueInstance;
        }

        /// <summary>
        /// 打开ARM卡
        /// </summary>
        public void Open()
        {
#if __HAS_ARM_BOARD

            if (!m_IsOpened[(int)Board.Conveyor])
            {
                Profiles profiles = Profiles.GetInstance();

                m_MyTcpClient[(int)Board.Conveyor] = new MyTcpClient(profiles.IpLocal);
                m_MyTcpClient[(int)Board.Conveyor].InitClient();
                m_MyTcpClient[(int)Board.Conveyor].CreateConnect(IPAddress.Parse(profiles.IpARMBoardConveyor), profiles.PortARMBoardConveyor);

                m_MyTcpClient[(int)Board.Fail] = new MyTcpClient(profiles.IpLocal);
                m_MyTcpClient[(int)Board.Fail].InitClient();
                m_MyTcpClient[(int)Board.Fail].CreateConnect(IPAddress.Parse(profiles.IpARMBoardFail), profiles.PortARMBoardFail);

                m_MyTcpClient[(int)Board.Pc1to8] = new MyTcpClient(profiles.IpLocal);
                m_MyTcpClient[(int)Board.Pc1to8].InitClient();
                m_MyTcpClient[(int)Board.Pc1to8].CreateConnect(IPAddress.Parse(profiles.IpARMBoardPc1to8), profiles.PortARMBoardPc1to8);

                m_MyTcpClient[(int)Board.Pc9to16] = new MyTcpClient(profiles.IpLocal);
                m_MyTcpClient[(int)Board.Pc9to16].InitClient();
                m_MyTcpClient[(int)Board.Pc9to16].CreateConnect(IPAddress.Parse(profiles.IpARMBoardPc9to16), profiles.PortARMBoardPc9to16);

                for (int i = 0; i < (int)Board.Max; i++)
                {
                    if (m_MyTcpClient[i].IsConnected())
                    {
                        m_IsOpened[i] = true;
                    }
                }

                /*
                //Get the list of available device numbers and names of devices, of which driver has been loaded successfully 
                //If you have two/more board,the device list(m_avaDevs) may be changed when the slot of the boards changed,for example:m_avaDevs[0].szDeviceName to PCI-1245
                //m_avaDevs[1].szDeviceName to PCI-1245L,changing the slot，Perhaps the opposite 
                uint m_deviceCount = 0;
                int result = Motion.mAcm_GetAvailableDevs(m_CurAvailableDevs, Motion.MAX_DEVICES, ref m_deviceCount);
                if (result != (int)ErrorCode.SUCCESS)
                {
                    //string strTemp = "Get Device Numbers Failed With Error Code: [0x" + Convert.ToString(result, 16) + "]";
                    return false;
                }

                if (m_deviceCount > 0)
                {
                    m_DeviceNum = m_CurAvailableDevs[0].DeviceNum;
                }
                else
                {
                    return false;
                }

                //打开指定的设备以获取设备句柄
                if (Motion.mAcm_DevOpen(m_DeviceNum, ref m_DeviceHandle) != (uint)ErrorCode.SUCCESS)
                {
                    //string strTemp = "Open Device Failed With Error Code: [0x" + Convert.ToString(result, 16) + "]";
                    return false;
                }

                //读取支持的轴数量
                uint axesPerDev = new uint();
                if (Motion.mAcm_GetU32Property(m_DeviceHandle, (uint)PropertyID.FT_DevAxesCount, ref axesPerDev) != (uint)ErrorCode.SUCCESS)
                {
                    //string strTemp = "Get Axis Number Failed With Error Code: [0x" + Convert.ToString(result, 16) + "]";
                    return false;
                }

                m_AxisCount = (int)axesPerDev;

                uint mode = (uint)HomeExSwitchMode.EdgeOn;  //回原点模式
                double crossDistance = 1000;

                for (int i = 0; i < m_AxisCount; i++)
                {
                    //打开每个轴并获取每个轴的句柄
                    if (Motion.mAcm_AxOpen(m_DeviceHandle, (UInt16)i, ref m_AxisHandle[i]) != (uint)ErrorCode.SUCCESS)
                    {
                        //string strTemp = "Open Axis Failed With Error Code: [0x" + Convert.ToString(result, 16) + "]";
                        return false;
                    }

                    //CmbAxes.Items.Add(String.Format("{0:d}-Axis", i));
                    double cmdPosition = 0;
                    //Set command position for the specified axis
                    Motion.mAcm_AxSetCmdPosition(m_AxisHandle[i], cmdPosition);
                    //Set actual position for the specified axis
                    Motion.mAcm_AxSetActualPosition(m_AxisHandle[i], cmdPosition);

                    //Setting the stopping condition of Acm_AxHomeEx
                    if (Motion.mAcm_SetU32Property(m_AxisHandle[i], (uint)PropertyID.PAR_AxHomeExSwitchMode, mode) != (uint)ErrorCode.SUCCESS)
                    {
                        //string strTemp = "Set Property-PAR_AxHomeExSwitchMode Failed With Error Code: [0x" + Convert.ToString(result, 16) + "]";
                        return false;
                    }

                    //设置原点跨越距离
                    if (Motion.mAcm_SetF64Property(m_AxisHandle[i], (uint)PropertyID.PAR_AxHomeCrossDistance, crossDistance) != (uint)ErrorCode.SUCCESS)
                    {
                        //string strTemp = "Set Property-AxHomeCrossDistance Failed With Error Code: [0x" + Convert.ToString(result, 16) + "]";
                        return false;
                    }
                }

                m_bInitBoard = true;

                SetSpeedParam(Axis.A, 10000, 100000, 20000, 20000);
                SetSpeedParam(Axis.B, 10000, 100000, 20000, 20000);
                //SetSpeedParam(3, 10000, 100000, 20000, 20000);
                */
            }
#endif
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

        /// <summary>
        /// 获取板卡是否打开
        /// </summary>
        /// <param name="type">板卡类型</param>
        /// <returns>=true已经打开</returns>
        public bool IsOpened(Board type)
        {
            return m_IsOpened[(int)type];
        }

        /// <summary>
        /// 设置输出口
        /// </summary>
        /// <param name="point"></param>
        /// <param name="value"></param>
        public void WritePoint(OutputPoint point, bool value)
        {
#if _DEBUG_ARM_BOARD
            Console.WriteLine(point.ToString() + " " + value);
#else
            int indexBoard = (int)point / MAX_IO_CHANNEL;  //板卡索引
            int indexPoint = (int)point % MAX_IO_CHANNEL;  //板卡内端口号索引
            if (value)
            {
                m_OutputBuffer[indexBoard] |= (uint)((uint)1 << indexPoint);
            }
            else
            {
                m_OutputBuffer[indexBoard] &= (uint)(~((uint)1 << indexPoint));
            }
            m_ShouldWriteOutput[indexBoard] = true;
#endif
        }

        /// <summary>
        /// 读取输入口
        /// </summary>
        /// <param name="point">输入点位</param>
        /// <returns></returns>
        public bool ReadPoint(InputPoint point)
        {
            int indexBoard = (int)point / MAX_IO_CHANNEL;  //板卡索引
            int indexPoint = (int)point % MAX_IO_CHANNEL;  //板卡内端口号索引
            uint mask = (uint)1 << indexPoint;
            return (m_InputBuffer[indexBoard] & mask) > 0;
        }

        /// <summary>
        /// 手动设置输入口状态, 手动联调使用
        /// </summary>
        /// <param name="point"></param>
        /// <param name="value"></param>
        public void SetInputPoint(InputPoint point, bool value)
        {
            int indexBoard = (int)point / MAX_IO_CHANNEL;  //板卡索引
            int indexPoint = (int)point % MAX_IO_CHANNEL;  //板卡内端口号索引
            if (value)
            {
                m_InputBuffer[indexBoard] |= (uint)((uint)1 << indexPoint);
            }
            else
            {
                m_InputBuffer[indexBoard] &= (uint)(~((uint)1 << indexPoint));
            }
        }

        /// <summary>
        /// 设置输出口
        /// </summary>
        /// <param name="point"></param>
        /// <param name="value"></param>
        public void SendWritePoint(Board type)
        {
#if _DEBUG_ARM_BOARD
            //Console.WriteLine(point.ToString() + " " + value);
#else
            if (!m_IsOpened[(int)type] || !m_ShouldWriteOutput[(int)type])
            {
                return;
            }

            byte[] sendBuffer = new byte[MyTcpClient.PACKAGE_LENGTH]
            {
                0x7e, (byte)'D', (byte)'R', 0x01, 0x01, (byte)CommandCode.SetOutput, 0x00, 0x00,
                0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x0d,
            };

            uint data = m_OutputBuffer[(int)type];
            sendBuffer[(int)IndexCode.Data1] = 0xff;
            sendBuffer[(int)IndexCode.Data2] = 0xff;
            sendBuffer[(int)IndexCode.Data3] = 0xff;
            sendBuffer[(int)IndexCode.Data4] = 0xff;
            sendBuffer[(int)IndexCode.Data5] = (byte)(data & 0xffU);
            sendBuffer[(int)IndexCode.Data6] = (byte)((data / 0x100) & 0xffU);
            sendBuffer[(int)IndexCode.Data7] = (byte)((data / 0x10000) & 0xffU);
            sendBuffer[(int)IndexCode.Data8] = (byte)((data / 0x1000000) & 0xffU);
            SendCommand(type, sendBuffer);

            Console.WriteLine("SendWritePoint");
#endif
        }

        /// <summary>
        /// 发送读取输入点指令
        /// </summary>
        /// <param name="type">板卡类型</param>
        public void SendReadPoint(Board type)
        {
            if (!m_IsOpened[(int)type])
            {
                return;
            }

            byte[] sendBuffer = new byte[Message.MessageLength]
            {
                0x7e, (byte)'D', (byte)'R', 0x01, 0x01, (byte)CommandCode.GetInput, 0x00, 0x00,
                0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x0d,
            };
            SendCommand(type, sendBuffer);
        }

        /// <summary>
        /// 向板卡发送命令
        /// </summary>
        /// <param name="type">板卡类型</param>
        /// <param name="sendBuffer">发送缓冲区</param>
        public void SendCommand(Board type, byte[] sendBuffer)
        {
            //if (!m_IsOpened[(int)type])
            //{
            //    return;
            //}

            //sendBuffer[(int)IndexCode.Check] = MyMath.CalculateSum(sendBuffer, MyTcpClient.PACKAGE_LENGTH);
            //m_MyTcpClient[(int)type].Write(sendBuffer);
        }

        /// <summary>
        /// 处理接收消息队列
        /// </summary>
        /// <param name="type">板卡类型</param>
        public void ProcessMeasQueue(Board type)
        {
#if __HAS_ARM_BOARD
            if (m_MyTcpClient[(int)type].m_RecvMeasQueue.Count() == 0)
            {
                return;
            }

            TcpMeas TempMeas = m_MyTcpClient[(int)type].m_RecvMeasQueue.Dequeue();
            if (TempMeas != null && TempMeas.Client != null)
            {
                switch ((CommandCode)TempMeas.MeasCode)
                {
                    case CommandCode.GetInput:
                        uint data = (uint)TempMeas.Param[(int)IndexCode.Data4] * 0x1000000
                            + (uint)TempMeas.Param[(int)IndexCode.Data3] * 0x10000
                            + (uint)TempMeas.Param[(int)IndexCode.Data2] * 0x100
                            + (uint)TempMeas.Param[(int)IndexCode.Data1];
                        m_InputBuffer[(int)type] = data;

                        //Console.WriteLine(TempMeas.Param[(int)IndexCode.Data1]);
                        break;

                    case CommandCode.SetOutput:
                        m_ShouldWriteOutput[(int)type] = false;
                        break;

                    case CommandCode.GetAxisState:
                        m_AxisState[(int)type, TempMeas.Param[(int)IndexCode.Data1]] = TempMeas.Param[(int)IndexCode.Data2];
                        break;

                    case CommandCode.GetAxisStep:
                        int dataPostion = (int)TempMeas.Param[(int)IndexCode.Data5] * 0x1000000
                            + (int)TempMeas.Param[(int)IndexCode.Data4] * 0x10000
                            + (int)TempMeas.Param[(int)IndexCode.Data3] * 0x100
                            + (int)TempMeas.Param[(int)IndexCode.Data2];
                        m_AxisPostion[(int)type, TempMeas.Param[(int)IndexCode.Data1]] = dataPostion;
                        break;

                    default:
                        break;
                }
            }
#endif
        }

        /// <summary>
        /// 读取轴当前位置
        /// </summary>
        /// <param name="axis">轴号</param>
        /// <returns></returns>
        public int ReadPostion(Axis axis)
        {
            int indexBoard = (int)axis / MAX_AXIS_CHANNEL;  //板卡索引
            int indexAxis = (int)axis % MAX_AXIS_CHANNEL;  //板卡内轴号索引

            if (!m_IsOpened[indexBoard])
            {
                return 0;
            }

            return m_AxisPostion[indexBoard, indexAxis];
        }

        /// <summary>
        /// 发送读取轴当前位置命令
        /// </summary>
        /// <param name="axis">轴号</param>
        public void SendReadPostion(Axis axis)
        {
            int indexBoard = (int)axis / MAX_AXIS_CHANNEL;  //板卡索引
            int indexAxis = (int)axis % MAX_AXIS_CHANNEL;  //板卡内轴号索引

            if (!m_IsOpened[indexBoard])
            {
                return;
            }

            byte[] sendBuffer = new byte[MyTcpClient.PACKAGE_LENGTH]
            {
                0x7e, (byte)'D', (byte)'R', 0x01, 0x01, (byte)CommandCode.GetAxisStep, (byte)indexAxis, 0x00,
                0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x0d,
            };
            SendCommand((Board)indexBoard, sendBuffer);
        }

        /// <summary>
        /// 读取轴状态
        /// </summary>
        /// <param name="axis">轴号</param>
        /// <returns>状态字符串</returns>
        public string ReadState(Axis axis)
        {
            int indexBoard = (int)axis / MAX_AXIS_CHANNEL;  //板卡索引
            int indexAxis = (int)axis % MAX_AXIS_CHANNEL;  //板卡内轴号索引

            if (!m_IsOpened[indexBoard])
            {
                return " ";
            }

            string retStr = " ";
            switch ((AxisState)m_AxisState[indexBoard, indexAxis])
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
        /// 发送读取轴状态命令
        /// </summary>
        /// <param name="axis">轴号</param>
        public void SendReadState(Axis axis)
        {
            int indexBoard = (int)axis / MAX_AXIS_CHANNEL;  //板卡索引
            int indexAxis = (int)axis % MAX_AXIS_CHANNEL;  //板卡内轴号索引

            if (!m_IsOpened[indexBoard])
            {
                return;
            }

            byte[] sendBuffer = new byte[MyTcpClient.PACKAGE_LENGTH]
            {
                0x7e, (byte)'D', (byte)'R', 0x01, 0x01, (byte)CommandCode.GetAxisState, (byte)indexAxis, 0x00,
                0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x0d,
            };
            SendCommand((Board)indexBoard, sendBuffer);
        }

        /*移动 -- 绝对位置
        axis 运动轴
        position 位置
        */
        public bool Move(Axis axis, int position)
        {
#if _DEBUG_MOTION
            Console.WriteLine("Axis " + axis.ToString() + "Move " + position);
            return true;
#else
            int indexBoard = (int)axis / MAX_AXIS_CHANNEL;  //板卡索引
            int indexAxis = (int)axis % MAX_AXIS_CHANNEL;  //板卡内轴号索引

            if (!m_IsOpened[indexBoard])
            {
                return false;
            }

            byte[] sendBuffer = new byte[MyTcpClient.PACKAGE_LENGTH]
            {
                0x7e, (byte)'D', (byte)'R', 0x01, 0x01, (byte)CommandCode.SetAxisStep, (byte)indexAxis, 0x00,
                0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x0d,
            };
            //sendBuffer[(int)IndexCode.Data2] = (byte)(position & 0xffU);
            //sendBuffer[(int)IndexCode.Data3] = (byte)((position / 0x100) & 0xffU);
            //sendBuffer[(int)IndexCode.Data4] = (byte)((position / 0x10000) & 0xffU);
            //sendBuffer[(int)IndexCode.Data5] = (byte)((position / 0x1000000) & 0xffU);
            SendCommand((Board)indexBoard, sendBuffer);

            return true;
#endif
        }

        /*手动移动 -- 参考位置
        axis 运动轴
        position 位置
        dir 方向
        */
        public bool MoveMaual(Axis axis, int step, bool dir)
        {
            int indexBoard = (int)axis / MAX_AXIS_CHANNEL;  //板卡索引
            int indexAxis = (int)axis % MAX_AXIS_CHANNEL;  //板卡内轴号索引

            if (!m_IsOpened[indexBoard])
            {
                return false;
            }

            if (dir)
            {
                step = -step;
            }

            byte[] sendBuffer = new byte[MyTcpClient.PACKAGE_LENGTH]
            {
                0x7e, (byte)'D', (byte)'R', 0x01, 0x01, (byte)CommandCode.SetAxisStep, (byte)indexAxis, 0x00,
                0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x0d,
            };
            int position = m_AxisPostion[indexBoard, indexAxis] + step;
            //sendBuffer[(int)IndexCode.Data2] = (byte)(position & 0xffU);
            //sendBuffer[(int)IndexCode.Data3] = (byte)((position / 0x100) & 0xffU);
            //sendBuffer[(int)IndexCode.Data4] = (byte)((position / 0x10000) & 0xffU);
            //sendBuffer[(int)IndexCode.Data5] = (byte)((position / 0x1000000) & 0xffU);
            SendCommand((Board)indexBoard, sendBuffer);

            return true;
        }

        /*停止
         * axis 运动轴
         */
        public bool Stop(Axis axis)
        {
            int indexBoard = (int)axis / MAX_AXIS_CHANNEL;  //板卡索引
            int indexAxis = (int)axis % MAX_AXIS_CHANNEL;  //板卡内轴号索引

            if (!m_IsOpened[indexBoard])
            {
                return false;
            }

            byte[] sendBuffer = new byte[MyTcpClient.PACKAGE_LENGTH]
            {
                0x7e, (byte)'D', (byte)'R', 0x01, 0x01, (byte)CommandCode.StopAxis, (byte)indexAxis, 0x00,
                0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x0d,
            };
            SendCommand((Board)indexBoard, sendBuffer);

            return true;
        }

        public void WaitDone(Axis axis)
        {
#if _DEBUG_MOTION
            Console.WriteLine("轴" + axis.ToString() + "等待移动完成.");
            return;
#else
            int indexBoard = (int)axis / MAX_AXIS_CHANNEL;  //板卡索引
            int indexAxis = (int)axis % MAX_AXIS_CHANNEL;  //板卡内轴号索引

            if (!m_IsOpened[indexBoard])
            {
                return;
            }

            /*
            UInt16 axState = new UInt16();
            int cnt = 0;
            while ((++cnt) < 80)  //等待运行完成
            {
                Motion.mAcm_AxGetState(m_AxisHandle[(int)axis], ref axState);
                if (axState == (UInt16)(AxisState.STA_AX_READY))
                {
                    break;
                }

                Thread.Sleep(100);
            }
            */
#endif
        }

        /*查询移动是否完成*/
        public bool QueryMoveDone(Axis axis)
        {
#if _DEBUG_MOTION
            Console.WriteLine("轴" + axis.ToString() + "查询等待移动完成.");
            return true;
#else
            int indexBoard = (int)axis / MAX_AXIS_CHANNEL;  //板卡索引
            int indexAxis = (int)axis % MAX_AXIS_CHANNEL;  //板卡内轴号索引

            if (!m_IsOpened[indexBoard])
            {
                return false;
            }

            UInt16 axState = new UInt16();
            //Motion.mAcm_AxGetState(m_AxisHandle[(int)axis], ref axState);
            return (axState == (UInt16)(AxisState.Ready));
#endif
        }

        /*复位轴错误状态，如果轴处于ErrorStop状态，则在调用此函数后状态将更改为Ready。
         */
        public bool ResetError(Axis axis)
        {
            int indexBoard = (int)axis / MAX_AXIS_CHANNEL;  //板卡索引
            int indexAxis = (int)axis % MAX_AXIS_CHANNEL;  //板卡内轴号索引

            if (!m_IsOpened[indexBoard])
            {
                return false;
            }

            byte[] sendBuffer = new byte[MyTcpClient.PACKAGE_LENGTH]
            {
                0x7e, (byte)'D', (byte)'R', 0x01, 0x01, (byte)CommandCode.ResetAxisError, (byte)indexAxis, 0x00,
                0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x0d,
            };
            SendCommand((Board)indexBoard, sendBuffer);

            return true;
        }

        /*回原点*/
        public bool BackHome(Axis axis)
        {
            int indexBoard = (int)axis / MAX_AXIS_CHANNEL;  //板卡索引
            int indexAxis = (int)axis % MAX_AXIS_CHANNEL;  //板卡内轴号索引

            if (!m_IsOpened[indexBoard])
            {
                return false;
            }

            byte[] sendBuffer = new byte[MyTcpClient.PACKAGE_LENGTH]
            {
                0x7e, (byte)'D', (byte)'R', 0x01, 0x01, (byte)CommandCode.AxisGoHome, (byte)indexAxis, 0x00,
                0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x0d,
            };
            SendCommand((Board)indexBoard, sendBuffer);

            return true;
        }

        /// <summary>
        /// 设置电机轴速度参数
        /// </summary>
        /// <param name="axis">轴号</param>
        /// <param name="velLow">初速度</param>
        /// <param name="velHigh">运行速度</param>
        /// <param name="acc">加速度</param>
        /// <param name="dec">减速度</param>
        public void SetSpeedParam(Axis axis, int velLow, int velHigh, int acc, int dec)
        {
            int indexBoard = (int)axis / MAX_AXIS_CHANNEL;  //板卡索引
            int indexAxis = (int)axis % MAX_AXIS_CHANNEL;  //板卡内轴号索引

            if (!m_IsOpened[indexBoard])
            {
                return;
            }

            byte[] sendBuffer = new byte[MyTcpClient.PACKAGE_LENGTH]
            {
                0x7e, (byte)'D', (byte)'R', 0x01, 0x01, (byte)CommandCode.AxisGoHome, (byte)indexAxis, 0x00,
                0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x0d,
            };
            //sendBuffer[(int)IndexCode.Data2] = (byte)(velLow & 0xffU);
            //sendBuffer[(int)IndexCode.Data3] = (byte)((velLow / 0x100) & 0xffU);
            //sendBuffer[(int)IndexCode.Data4] = (byte)(velHigh & 0xffU);
            //sendBuffer[(int)IndexCode.Data5] = (byte)((velHigh / 0x100) & 0xffU);
            //sendBuffer[(int)IndexCode.Data6] = (byte)(acc & 0xffU);
            //sendBuffer[(int)IndexCode.Data7] = (byte)((acc / 0x100) & 0xffU);
            //sendBuffer[(int)IndexCode.Data8] = (byte)(dec & 0xffU);
            //sendBuffer[(int)IndexCode.Data9] = (byte)((dec / 0x100) & 0xffU);
            SendCommand((Board)indexBoard, sendBuffer);
        }
    }
}