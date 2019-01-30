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
    public enum AxisNum
    {
        Axis_X = 0,
        Axis_Y,
        Axis_Z,
        Axis_Total
    }

    public enum AxisRunDir
    {
        Dir_Forward = 0,
        Dir_Reverse
    }

    public enum AxisCurState
    {
        AxisState_Wrong = 0,
        AxisState_Ready,
        AxisState_ErrorStop,
        AxisState_Busy,
    }

    public class MotionControler
    {
        public enum HomeMode
        {
            MODE1_Abs = 0,
            MODE2_Lmt,
            MODE3_Ref,
            MODE4_Abs_Ref,
            MODE5_Abs_NegRef,
            MODE6_Lmt_Ref,
            MODE7_AbsSearch,
            MODE8_LmtSearch,
            MODE9_AbsSearch_Ref,
            MODE10_AbsSearch_NegRef,
            MODE11_LmtSearch_Ref,
            MODE12_AbsSearchReFind,
            MODE13_LmtSearchReFind,
            MODE14_AbsSearchReFind_Ref,
            MODE15_AbsSearchReFind_NegRef,
            MODE16_LmtSearchReFind_Ref
        }

        private static MotionControler m_UniqueMotionControler = null;
        private static readonly object m_Locker = new object();

        public DEV_LIST[] m_CurAvailableDevs = new DEV_LIST[Motion.MAX_DEVICES];
        public IntPtr m_DeviceHandle = IntPtr.Zero;  //运动卡设备句柄
        public IntPtr[] m_AxisHandle = new IntPtr[32];  //轴句柄 
        public bool m_InitBoard = false;  //是否初始化了运动卡
        public uint m_DeviceCount = 0;
        private uint m_DeviceNum = 0;       //设备编号
        public uint m_AxisCount = 0;       //运动卡支持的轴数量
        public AxisNum m_CurAxis = 0;
        public uint m_HomeMode = (uint)HomeMode.MODE8_LmtSearch;
        public int m_Distance = 1000;  //跨越距离


        // 定义私有构造函数，使外界不能创建该类实例
        private MotionControler()
        {

        }

        /// <summary>
        /// 定义公有方法提供一个全局访问点,同时你也可以定义公有属性来提供全局访问点
        /// </summary>
        /// <returns></returns>
        public static MotionControler GetInstance()
        {
            if (m_UniqueMotionControler == null)
            {
                lock (m_Locker)
                {
                    if (m_UniqueMotionControler == null)
                        m_UniqueMotionControler = new MotionControler();
                }
            }
            return m_UniqueMotionControler;
        }

        public void InitMotionControler()
        {
            //加载设备
            //Get the list of available device numbers and names of devices, of which driver has been loaded successfully 
            //If you have two/more board,the device list(m_avaDevs) may be changed when the slot of the boards changed,for example:m_avaDevs[0].szDeviceName to PCI-1245
            //m_avaDevs[1].szDeviceName to PCI-1245L,changing the slot，Perhaps the opposite 

            int Result = Motion.mAcm_GetAvailableDevs(m_CurAvailableDevs, Motion.MAX_DEVICES, ref m_DeviceCount);
            if (Result != (int)ErrorCode.SUCCESS)
            {
                string strTemp = "Get Device Numbers Failed With Error Code: [0x" + Convert.ToString(Result, 16) + "]";
                MessageBox.Show(strTemp);
                return;
            }

            if (m_DeviceCount > 0)
            {
                m_DeviceNum = m_CurAvailableDevs[0].DeviceNum;
            }
        }

        public void LoadMotionControlerConfig(string FileName)
        {
            //Set all configurations for the device according to the loaded file
            uint Result = Motion.mAcm_DevLoadConfig(m_DeviceHandle, FileName);
            if (Result != (uint)ErrorCode.SUCCESS)
            {
                string strTemp = "Load Config Failed With Error Code: [0x" + Convert.ToString(Result, 16) + "]";
                MessageBox.Show(strTemp);
                return;
            }
        }

        public bool OpenDevice()
        {
            //Open a specified device to get device handle
            //you can call GetDevNum() API to get the devcie number of fixed equipment in this,as follow
            //DeviceNum = GetDevNum((uint)DevTypeID.PCI1285, 15, 0, 0);
            uint Result = Motion.mAcm_DevOpen(m_DeviceNum, ref m_DeviceHandle);
            if (Result != (uint)ErrorCode.SUCCESS)
            {
                string strTemp = "Open Device Failed With Error Code: [0x" + Convert.ToString(Result, 16) + "]";
                MessageBox.Show(strTemp);
                return false;
            }
            //FT_DevAxesCount:Get axis number of this device.
            //if you device is fixed(for example: PCI-1245),You can not get FT_DevAxesCount property value
            //This step is not necessary
            //You can also use the old API: Motion.mAcm_GetProperty(m_DeviceHandle, (uint)PropertyID.FT_DevAxesCount, ref AxesPerDev, ref BufferLength);
            // UInt32 BufferLength;
            //BufferLength =4;  buffer size for the property
            uint AxesPerDev = new uint();
            Result = Motion.mAcm_GetU32Property(m_DeviceHandle, (uint)PropertyID.FT_DevAxesCount, ref AxesPerDev);
            if (Result != (uint)ErrorCode.SUCCESS)
            {
                string strTemp = "Get Axis Number Failed With Error Code: [0x" + Convert.ToString(Result, 16) + "]";
                MessageBox.Show(strTemp);
                return false;
            }
            m_AxisCount = AxesPerDev;

            //if you device is fixed,for example: PCI-1245 m_AxisCount =4
            for (int i = 0; i < m_AxisCount; i++)
            {
                //Open every Axis and get the each Axis Handle
                //And Initial property for each Axis 		
                //Open Axis 
                Result = Motion.mAcm_AxOpen(m_DeviceHandle, (UInt16)i, ref m_AxisHandle[i]);
                if (Result != (uint)ErrorCode.SUCCESS)
                {
                    string strTemp = "Open Axis Failed With Error Code: [0x" + Convert.ToString(Result, 16) + "]";
                    MessageBox.Show(strTemp);
                    return false;
                }

                // CmbAxes.Items.Add(String.Format("{0:d}-Axis", i));
                double cmdPosition = 0;
                //Set command position for the specified axis
                Motion.mAcm_AxSetCmdPosition(m_AxisHandle[i], cmdPosition);
                //Set actual position for the specified axis
                Motion.mAcm_AxSetActualPosition(m_AxisHandle[i], cmdPosition);
            }

            m_InitBoard = true;
            return m_InitBoard;
        }

        public void SetMotionAxisSpeedParam(AxisNum axis, double AxVelLow, double AxVelHigh, double AxAcc, double AxDec)
        {
            if (!m_InitBoard || axis < AxisNum.Axis_Total || axis > AxisNum.Axis_Total)
            {
                return;
            }

            string strTemp;

            //Set low velocity (start velocity) of this axis (Unit: PPU/S).
            //This property value must be smaller than or equal to PAR_AxVelHigh
            //You can also use the old API:Motion.mAcm_SetProperty(m_AxisHandle[CmbAxes.SelectedIndex], (uint)PropertyID.PAR_AxVelLow, ref AxVelLow, BufferLength);
            // UInt32  BufferLength;
            //BufferLength =8; buffer size for the property
            UInt32 Result = Motion.mAcm_SetF64Property(m_AxisHandle[(int)axis], (uint)PropertyID.PAR_AxVelLow, AxVelLow);
            if (Result != (uint)ErrorCode.SUCCESS)
            {
                strTemp = "Set low velocity failed with error code: [0x" + Convert.ToString(Result, 16) + "]";
                MessageBox.Show(strTemp);
                return;
            }

            // Set high velocity (driving velocity) of this axis (Unit: PPU/s).
            //This property value must be smaller than CFG_AxMaxVel and greater than PAR_AxVelLow
            //You can also use the old API:Motion.mAcm_SetProperty(m_AxisHandle[CmbAxes.SelectedIndex], (uint)PropertyID.PAR_AxVelHigh,ref AxVelHigh,BufferLength)
            // UInt32  BufferLength;
            //BufferLength =8; buffer size for the property
            Result = Motion.mAcm_SetF64Property(m_AxisHandle[(int)axis], (uint)PropertyID.PAR_AxVelHigh, AxVelHigh);
            if (Result != (uint)ErrorCode.SUCCESS)
            {
                strTemp = "Set high velocity failed with error code: [0x" + Convert.ToString(Result, 16) + "]";
                MessageBox.Show(strTemp);
                return;
            }

            // Set acceleration of this axis (Unit: PPU/s2).
            //This property value must be smaller than or equal to CFG_AxMaxAcc
            //You can also use the old API:Motion.mAcm_SetProperty(m_AxisHandle[CmbAxes.SelectedIndex], (uint)PropertyID.PAR_AxAcc,ref AxAcc,BufferLength)
            // UInt32  BufferLength;
            //BufferLength =8; buffer size for the property
            Result = Motion.mAcm_SetF64Property(m_AxisHandle[(int)axis], (uint)PropertyID.PAR_AxAcc, AxAcc);
            if (Result != (uint)ErrorCode.SUCCESS)
            {
                strTemp = "Set acceleration failed with error code: [0x" + Convert.ToString(Result, 16) + "]";
                MessageBox.Show(strTemp);
                return;
            }

            //Set deceleration of this axis (Unit: PPU/s2).
            //This property value must be smaller than or equal to CFG_AxMaxDec
            //You can also use the old API:Motion.mAcm_SetProperty(m_AxisHandle[CmbAxes.SelectedIndex], (uint)PropertyID.PAR_AxDcc,ref AxDec,BufferLength)
            // UInt32  BufferLength;
            //BufferLength =8; buffer size for the property
            Result = Motion.mAcm_SetF64Property(m_AxisHandle[(int)axis], (uint)PropertyID.PAR_AxDec, AxDec);
            if (Result != (uint)ErrorCode.SUCCESS)
            {
                strTemp = "Set deceleration failed with error code: [0x" + Convert.ToString(Result, 16) + "]";
                MessageBox.Show(strTemp);
                return;
            }

            //GetAxisVelParam();
        }

        public void CloseDevice()
        {
            UInt16[] usAxisState = new UInt16[32];
            uint AxisNum = 0;

            if (m_InitBoard == true) //Stop Every Axes
            {
                for (AxisNum = 0; AxisNum < m_AxisCount; AxisNum++)
                {
                    //Get the axis's current state
                    Motion.mAcm_AxGetState(m_AxisHandle[AxisNum], ref usAxisState[AxisNum]);
                    if (usAxisState[AxisNum] == (uint)AxisState.STA_AX_ERROR_STOP)
                    {
                        // Reset the axis' state. If the axis is in ErrorStop state, the state will be changed to Ready after calling this function
                        Motion.mAcm_AxResetError(m_AxisHandle[AxisNum]);
                    }

                    Motion.mAcm_AxStopDec(m_AxisHandle[AxisNum]); //To command axis to decelerate to stop.
                }
                for (AxisNum = 0; AxisNum < m_AxisCount; AxisNum++)
                {
                    Motion.mAcm_AxClose(ref m_AxisHandle[AxisNum]);  //Close Axes
                }
                m_AxisCount = 0;
                Motion.mAcm_DevClose(ref m_DeviceHandle); //Close Device
                m_DeviceHandle = IntPtr.Zero;
                m_InitBoard = false;
            }
        }

        //XY   DirMode 0, 1代表正反防线由实际轴决定
        public void GoHome(AxisNum Axis, AxisRunDir DirMode)
        {
            string strTemp;
            uint result;
            uint propertyVal = m_HomeMode;
            double crossDistance = (double)m_Distance;

            //Setting the stopping condition of Acm_AxHomeEx
            //You can also use the old API: Motion.mAcm_SetProperty(m_AxisHandle[CmbAxes.SelectedIndex], (uint)PropertyID.PAR_AxHomeExSwitchMode, ref PropertyVal, (uint)Marshal.SizeOf(typeof(UInt32)));
            result = Motion.mAcm_SetU32Property(m_AxisHandle[(int)Axis], (uint)PropertyID.PAR_AxHomeExSwitchMode, propertyVal);
            if (result != (uint)ErrorCode.SUCCESS)
            {
                strTemp = "Set Property-PAR_AxHomeExSwitchMode Failed With Error Code: [0x" + Convert.ToString(result, 16) + "]";
                MessageBox.Show(strTemp);
                return;
            }

            //Set the home cross distance (Unit: PPU). This property must be greater than 0. The default value is 10000
            //You can also use the old API: Motion.mAcm_SetProperty(m_AxisHandle[CmbAxes.SelectedIndex], (uint)PropertyID.PAR_AxHomeCrossDistance, ref CrossDistance, (uint)Marshal.SizeOf(typeof(double)));
            result = Motion.mAcm_SetF64Property(m_AxisHandle[(int)Axis], (uint)PropertyID.PAR_AxHomeCrossDistance, crossDistance);
            if (result != (uint)ErrorCode.SUCCESS)
            {
                strTemp = "Set Property-AxHomeCrossDistance Failed With Error Code: [0x" + Convert.ToString(result, 16) + "]";
                MessageBox.Show(strTemp);
                return;
            }

            //To command axis to start typical home motion. The 15 types of typical
            //home motion are composed of extended home
            result = Motion.mAcm_AxHome(m_AxisHandle[(int)Axis], m_HomeMode, (uint)DirMode);
            if (result != (uint)ErrorCode.SUCCESS)
            {
                strTemp = "AxHome Failed With Error Code: [0x" + Convert.ToString(result, 16) + "]";
                MessageBox.Show(strTemp);
            }
        }

        public AxisCurState GetAxisCurState(AxisNum Axis)
        {
            AxisCurState CurState = AxisCurState.AxisState_Wrong;
            ushort State = (ushort)AxisState.STA_AX_DISABLE;
            Motion.mAcm_AxGetState(m_AxisHandle[(int)Axis], ref State);
            switch ((AxisState)State)
            {
                case AxisState.STA_AX_READY:
                    CurState = AxisCurState.AxisState_Ready;
                    break;
                case AxisState.STA_AX_ERROR_STOP:
                    CurState = AxisCurState.AxisState_ErrorStop;
                    break;
                case AxisState.STA_AX_BUSY:
                    CurState = AxisCurState.AxisState_Busy;
                    break;
                default:
                    break;
            }

            return CurState;
        }

        public void ResetErr(AxisNum CurAxis)
        {
            if (!m_InitBoard || CurAxis < AxisNum.Axis_X || CurAxis > AxisNum.Axis_Total)
            {
                return;
            }

            //Reset the axis' state. If the axis is in ErrorStop state, the state will
            //be changed to Ready after calling this function.
            UInt32 Result = Motion.mAcm_AxResetError(m_AxisHandle[(int)CurAxis]);
            if (Result != (uint)ErrorCode.SUCCESS)
            {
                string strTemp = "Reset axis's error failed With Error Code: [0x" + Convert.ToString(Result, 16) + "]";
                MessageBox.Show(strTemp);
                return;
            }
        }

        //获取运动控制卡的状态
        public void GetMotionControlState(ref uint IOStatus, ref string AxisXState, ref string AxisYState, ref string AxisZState, ref string AxisCurState)
        {
            double CurCmdX = new double();
            double CurCmdY = new double();
            double CurCmdZ = new double();

            //double ActCmd = new double();
            UInt16 AxState = new UInt16();
            if (m_InitBoard)
            {
                //Get the motion I/ O status of the axis.
                Motion.mAcm_AxGetMotionIO(m_AxisHandle[(int)m_CurAxis], ref IOStatus);

                //Get current command position of the specified axis
                Motion.mAcm_AxGetCmdPosition(m_AxisHandle[(int)AxisNum.Axis_X], ref CurCmdX);
                AxisXState = Convert.ToString(CurCmdX);

                Motion.mAcm_AxGetCmdPosition(m_AxisHandle[(int)AxisNum.Axis_Y], ref CurCmdY);
                AxisYState = Convert.ToString(CurCmdY);

                //Get actual position of the specified axis
                Motion.mAcm_AxGetActualPosition(m_AxisHandle[(int)AxisNum.Axis_Z], ref CurCmdZ);
                AxisZState = Convert.ToString(CurCmdZ);

                //Get the Axis's current state		
                Motion.mAcm_AxGetState(m_AxisHandle[(int)m_CurAxis], ref AxState);
                AxisCurState = ((AxisState)AxState).ToString();
            }
        }

        //移动机械臂  axis是轴的编号， PositiveDirection ，true为正方向，false反方向
        public void MoveMotion(AxisNum CurAxis, AxisRunDir Dir)
        {
            if (!m_InitBoard || CurAxis < AxisNum.Axis_X || CurAxis > AxisNum.Axis_Total)
                return;

            ResetErr(CurAxis);

            double Distance = m_Distance;
            if (Dir == AxisRunDir.Dir_Reverse)
                Distance = -Distance;

            uint result = Motion.mAcm_AxMoveRel(m_AxisHandle[(int)CurAxis], Distance);
            if (result != (uint)ErrorCode.SUCCESS)
            {
                string strTemp = "PTP Move Failed With Error Code: [0x" + Convert.ToString(result, 16) + "]";
                MessageBox.Show(strTemp);
            }
        }

        public void StopMotion(uint CurAxis)
        {
            //To command axis to decelerate to stop.
            uint Result = Motion.mAcm_AxStopDec(m_AxisHandle[CurAxis]);
            if (Result != (uint)ErrorCode.SUCCESS)
            {
                string strTemp = "Axis To decelerate Stop Failed With Error Code: [0x" + Convert.ToString(Result, 16) + "]";
                MessageBox.Show(strTemp);
                return;
            }
        }

        public void SetMotionIo(AxisNum axis, ushort DiChannel, byte value)
        {
            Motion.mAcm_AxDoSetBit(m_AxisHandle[(int)axis], DiChannel, value);
        }

        public byte GetMotionIo(AxisNum axis, ushort DiChannel)
        {
            byte IOStatus = 0;

            Motion.mAcm_AxDiGetBit(m_AxisHandle[(int)axis], DiChannel, ref IOStatus);

            return IOStatus;
        }
    }
}
