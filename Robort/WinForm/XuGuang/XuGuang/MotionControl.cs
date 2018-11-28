using Advantech.Motion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RobotWorkstation
{
    //运动控制卡
    class MotionControl
    {
        private DEV_LIST[] m_CurAvailableDevs = new DEV_LIST[Motion.MAX_DEVICES];
        private IntPtr m_DeviceHandle = IntPtr.Zero;  //运动卡设备句柄
        private IntPtr[] m_AxisHandle = new IntPtr[32];  //轴句柄 
        private bool m_bInitBoard = false;  //是否初始化了运动卡
        private uint m_DeviceNum = 0;       //设备编号
        private uint m_AxisCount = 0;       //运动卡支持的轴数量

        private const int AXIS_NO_X = 3;    //X轴编号
        private const int AXIS_NO_Y = 0;    //Y轴编号
        private const int AXIS_NO_Z = 2;    //Z轴编号
        private const int AXIS_NO_MIN = 0;  //轴最小编号
        private const int AXIS_NO_MAX = 3;  //轴最大编号

        public void InitMotionControl()
        {
            //Get the list of available device numbers and names of devices, of which driver has been loaded successfully 
            //If you have two/more board,the device list(m_avaDevs) may be changed when the slot of the boards changed,for example:m_avaDevs[0].szDeviceName to PCI-1245
            //m_avaDevs[1].szDeviceName to PCI-1245L,changing the slot，Perhaps the opposite 
            uint m_deviceCount = 0;
            int Result = Motion.mAcm_GetAvailableDevs(m_CurAvailableDevs, Motion.MAX_DEVICES, ref m_deviceCount);
            if (Result != (int)ErrorCode.SUCCESS)
            {
                string strTemp = "Get Device Numbers Failed With Error Code: [0x" + Convert.ToString(Result, 16) + "]";
                MessageBox.Show(strTemp);
                return;
            }

            if (m_deviceCount > 0)
            {
                m_DeviceNum = m_CurAvailableDevs[0].DeviceNum;
            }
        }

        public void OpenDevice()
        {
            //Open a specified device to get device handle
            //you can call GetDevNum() API to get the devcie number of fixed equipment in this,as follow
            //DeviceNum = GetDevNum((uint)DevTypeID.PCI1285, 15, 0, 0);
            uint Result = Motion.mAcm_DevOpen(m_DeviceNum, ref m_DeviceHandle);
            if (Result != (uint)ErrorCode.SUCCESS)
            {
                string strTemp = "Open Device Failed With Error Code: [0x" + Convert.ToString(Result, 16) + "]";
                MessageBox.Show(strTemp);
                return;
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
                return;
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
                    return;
                }

               // CmbAxes.Items.Add(String.Format("{0:d}-Axis", i));
                double cmdPosition = 0;
                //Set command position for the specified axis
                Motion.mAcm_AxSetCmdPosition(m_AxisHandle[i], cmdPosition);
                //Set actual position for the specified axis
                Motion.mAcm_AxSetActualPosition(m_AxisHandle[i], cmdPosition);
            }

            m_bInitBoard = true;

            SetMotionAxisSpeedParam(0, 10000, 100000, 20000, 20000);
            SetMotionAxisSpeedParam(2, 30000, 300000, 30000, 30000);
            SetMotionAxisSpeedParam(3, 10000, 100000, 20000, 20000);
        }

        private void SetMotionAxisSpeedParam(int axis, double AxVelLow, double AxVelHigh, double AxAcc, double AxDec)
        {
            if (!m_bInitBoard || axis < AXIS_NO_MIN || axis > AXIS_NO_MAX)
            {
                return;
            }

            string strTemp;

            //Set low velocity (start velocity) of this axis (Unit: PPU/S).
            //This property value must be smaller than or equal to PAR_AxVelHigh
            //You can also use the old API:Motion.mAcm_SetProperty(m_AxisHandle[CmbAxes.SelectedIndex], (uint)PropertyID.PAR_AxVelLow, ref AxVelLow, BufferLength);
            // UInt32  BufferLength;
            //BufferLength =8; buffer size for the property
            UInt32 Result = Motion.mAcm_SetF64Property(m_AxisHandle[axis], (uint)PropertyID.PAR_AxVelLow, AxVelLow);
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
            Result = Motion.mAcm_SetF64Property(m_AxisHandle[axis], (uint)PropertyID.PAR_AxVelHigh, AxVelHigh);
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
            Result = Motion.mAcm_SetF64Property(m_AxisHandle[axis], (uint)PropertyID.PAR_AxAcc, AxAcc);
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
            Result = Motion.mAcm_SetF64Property(m_AxisHandle[axis], (uint)PropertyID.PAR_AxDec, AxDec);
            if (Result != (uint)ErrorCode.SUCCESS)
            {
                strTemp = "Set deceleration failed with error code: [0x" + Convert.ToString(Result, 16) + "]";
                MessageBox.Show(strTemp);
                return;
            }

            //GetAxisVelParam();
        }

    }
}
