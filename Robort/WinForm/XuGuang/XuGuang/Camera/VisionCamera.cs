using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvCamCtrl.NET;  //海康相机的.Net库
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace RobotWorkstation
{
    public struct CameraParamStruct
    {
        public float Exposure;
        public float Gain;
        public float FramRate;
    }

    public class VisionCamera
    {
        /*摄像头驱动变量*/
        public ComboBox m_CameraListComboBox = new ComboBox();
        private MyCamera.MV_CC_DEVICE_INFO_LIST m_CameraList = new MyCamera.MV_CC_DEVICE_INFO_LIST();
        private CameraOperator m_CameraOperator = new CameraOperator();

        public CameraParamStruct m_CameraParam;
        public PictureBox m_CameraPictureBox = new PictureBox();

        public bool FindCameraDevice()
        {
            bool bRe = false;

            //System.GC.Collect();
            m_CameraListComboBox.Items.Clear();
            int nRet = CameraOperator.EnumDevices(MyCamera.MV_GIGE_DEVICE | MyCamera.MV_USB_DEVICE, ref m_CameraList);
            if (0 != nRet)
            {
                MessageBox.Show("枚举设备失败!");
                bRe = false ;
            }

            //在窗体列表中显示设备名
            for (int i = 0; i < m_CameraList.nDeviceNum; i++)
            {
                MyCamera.MV_CC_DEVICE_INFO device = (MyCamera.MV_CC_DEVICE_INFO)Marshal.PtrToStructure(m_CameraList.pDeviceInfo[i], typeof(MyCamera.MV_CC_DEVICE_INFO));
                if (device.nTLayerType == MyCamera.MV_GIGE_DEVICE)
                {
                    IntPtr buffer = Marshal.UnsafeAddrOfPinnedArrayElement(device.SpecialInfo.stGigEInfo, 0);
                    MyCamera.MV_GIGE_DEVICE_INFO gigeInfo = (MyCamera.MV_GIGE_DEVICE_INFO)Marshal.PtrToStructure(buffer, typeof(MyCamera.MV_GIGE_DEVICE_INFO));
                    if (gigeInfo.chUserDefinedName != "")
                    {
                        m_CameraListComboBox.Items.Add("GigE: " + gigeInfo.chUserDefinedName + " (" + gigeInfo.chSerialNumber + ")");
                    }
                    else
                    {
                        m_CameraListComboBox.Items.Add("GigE: " + gigeInfo.chManufacturerName + " " + gigeInfo.chModelName + " (" + gigeInfo.chSerialNumber + ")");
                    }
                }
                else if (device.nTLayerType == MyCamera.MV_USB_DEVICE)
                {
                    IntPtr buffer = Marshal.UnsafeAddrOfPinnedArrayElement(device.SpecialInfo.stUsb3VInfo, 0);
                    MyCamera.MV_USB3_DEVICE_INFO usbInfo = (MyCamera.MV_USB3_DEVICE_INFO)Marshal.PtrToStructure(buffer, typeof(MyCamera.MV_USB3_DEVICE_INFO));
                    if (usbInfo.chUserDefinedName != "")
                    {
                        m_CameraListComboBox.Items.Add("USB: " + usbInfo.chUserDefinedName + " (" + usbInfo.chSerialNumber + ")");
                    }
                    else
                    {
                        m_CameraListComboBox.Items.Add("USB: " + usbInfo.chManufacturerName + " " + usbInfo.chModelName + " (" + usbInfo.chSerialNumber + ")");
                    }
                }
            }

            //选择第一项
            if (m_CameraList.nDeviceNum != 0)
            {
                m_CameraListComboBox.SelectedIndex = 0;
                bRe = true;
            }

            return bRe;
        }

        public void OpenCameraDevice()
        {
            if (m_CameraList.nDeviceNum == 0 || m_CameraListComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("无设备可选择！", "警告");
                return;
            }

            //获取选择的设备信息
            MyCamera.MV_CC_DEVICE_INFO device = (MyCamera.MV_CC_DEVICE_INFO)Marshal.PtrToStructure(m_CameraList.pDeviceInfo[m_CameraListComboBox.SelectedIndex], typeof(MyCamera.MV_CC_DEVICE_INFO));
            int nRet = m_CameraOperator.Open(ref device);
            if (MyCamera.MV_OK != nRet)
            {
                MessageBox.Show("设备打开失败！", "警告");
                return;
            }

            m_CameraOperator.SetEnumValue("AcquisitionMode", 2);// 工作在连续模式
            m_CameraOperator.SetEnumValue("TriggerMode", 0);    // 连续模式

            CameraStartGrab(m_CameraPictureBox);
        }

        public void SetCameraParam(CameraParamStruct param)
        {
            int nRet = m_CameraOperator.SetFloatValue("ExposureTime", param.Exposure);
            if (nRet != CameraOperator.CO_OK)
            {
                MessageBox.Show("设置曝光时间失败！", "警告");
            }

            m_CameraOperator.SetEnumValue("GainAuto", 0);
            nRet = m_CameraOperator.SetFloatValue("Gain", param.Gain);
            if (nRet != CameraOperator.CO_OK)
            {
                MessageBox.Show("设置增益失败！", "警告");
            }

            nRet = m_CameraOperator.SetFloatValue("AcquisitionFrameRate", param.FramRate);
            if (nRet != CameraOperator.CO_OK)
            {
                MessageBox.Show("设置帧率失败！", "警告");
            }
        }

        public CameraParamStruct GetCameraParam()
        {
            CameraParamStruct param;

            float Exposure = 0;
            m_CameraOperator.GetFloatValue("ExposureTime", ref Exposure);
            param.Exposure = Exposure;

            float Gain = 0;
            m_CameraOperator.GetFloatValue("Gain", ref Gain);
            param.Gain = Gain;

            float FrameRate = 0;
            m_CameraOperator.GetFloatValue("ResultingFrameRate", ref FrameRate);
            param.FramRate = FrameRate;

            return param;
        }

        public void CameraStartGrab(PictureBox pictureBox)
        {
            int nRet = m_CameraOperator.StartGrabbing();
            if (MyCamera.MV_OK != nRet)
            {
                MessageBox.Show("开始取流失败！", "警告");
                return;
            }

            //显示
            nRet = m_CameraOperator.Display(pictureBox.Handle);
            if (MyCamera.MV_OK != nRet)
            {
                MessageBox.Show("显示失败！", "警告");
            }
        }

        public void CloseCameraDevice()
        {
            m_CameraOperator.Close();
        }
    }
}
