using DeviceSource;
using MvCamCtrl.NET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WPF_HikvisionCamera
{
    /// <summary>
    /// WPF_WinFormPicBoxCamera.xaml 的交互逻辑
    /// </summary>
    public partial class WPF_WinFormPicBoxCamera : Window
    {
        //摄像头相关
        CameraOperator m_pOperator;
        MyCamera.MV_CC_DEVICE_INFO_LIST m_pDeviceList;
        System.Windows.Forms.PictureBox m_CameraPicBox = null;

        public WPF_WinFormPicBoxCamera()
        {
            InitializeComponent();
            InitCamera();
            CarmerDeviceListAcq();
        }

        private void InitCamera()
        {
            m_CameraPicBox = pictureHost.Child as System.Windows.Forms.PictureBox;
            m_pDeviceList = new MyCamera.MV_CC_DEVICE_INFO_LIST();
            m_pOperator = new CameraOperator();           
        }

        //查找摄像头
        private void CarmerDeviceListAcq()
        {
            //System.GC.Collect();
            m_CameraDeviceList.Items.Clear();
            int nRet = CameraOperator.EnumDevices(MyCamera.MV_GIGE_DEVICE | MyCamera.MV_USB_DEVICE, ref m_pDeviceList);
            if (0 != nRet)
            {
                MessageBox.Show("枚举设备失败!");
                return;
            }

            //在窗体列表中显示设备名
            for (int i = 0; i < m_pDeviceList.nDeviceNum; i++)
            {
                MyCamera.MV_CC_DEVICE_INFO device = (MyCamera.MV_CC_DEVICE_INFO)Marshal.PtrToStructure(m_pDeviceList.pDeviceInfo[i], typeof(MyCamera.MV_CC_DEVICE_INFO));
                if (device.nTLayerType == MyCamera.MV_GIGE_DEVICE)
                {
                    IntPtr buffer = Marshal.UnsafeAddrOfPinnedArrayElement(device.SpecialInfo.stGigEInfo, 0);
                    MyCamera.MV_GIGE_DEVICE_INFO gigeInfo = (MyCamera.MV_GIGE_DEVICE_INFO)Marshal.PtrToStructure(buffer, typeof(MyCamera.MV_GIGE_DEVICE_INFO));
                    if (gigeInfo.chUserDefinedName != "")
                    {
                        m_CameraDeviceList.Items.Add("GigE: " + gigeInfo.chUserDefinedName + " (" + gigeInfo.chSerialNumber + ")");
                    }
                    else
                    {
                        m_CameraDeviceList.Items.Add("GigE: " + gigeInfo.chManufacturerName + " " + gigeInfo.chModelName + " (" + gigeInfo.chSerialNumber + ")");
                    }
                }
                else if (device.nTLayerType == MyCamera.MV_USB_DEVICE)
                {
                    IntPtr buffer = Marshal.UnsafeAddrOfPinnedArrayElement(device.SpecialInfo.stUsb3VInfo, 0);
                    MyCamera.MV_USB3_DEVICE_INFO usbInfo = (MyCamera.MV_USB3_DEVICE_INFO)Marshal.PtrToStructure(buffer, typeof(MyCamera.MV_USB3_DEVICE_INFO));
                    if (usbInfo.chUserDefinedName != "")
                    {
                        m_CameraDeviceList.Items.Add("USB: " + usbInfo.chUserDefinedName + " (" + usbInfo.chSerialNumber + ")");
                    }
                    else
                    {
                        m_CameraDeviceList.Items.Add("USB: " + usbInfo.chManufacturerName + " " + usbInfo.chModelName + " (" + usbInfo.chSerialNumber + ")");
                    }
                }
            }
            //选择第一项
            if (m_pDeviceList.nDeviceNum != 0)
            {
                m_CameraDeviceList.SelectedIndex = 0;
            }
        }

        private void button_Open_Click(object sender, RoutedEventArgs e)
        {
            if (m_pDeviceList.nDeviceNum == 0 || m_CameraDeviceList.SelectedIndex == -1)
            {
                MessageBox.Show("无设备，请选择");
                return;
            }

            //获取选择的设备信息
            MyCamera.MV_CC_DEVICE_INFO device = (MyCamera.MV_CC_DEVICE_INFO)Marshal.PtrToStructure(m_pDeviceList.pDeviceInfo[m_CameraDeviceList.SelectedIndex], typeof(MyCamera.MV_CC_DEVICE_INFO));
            int nRet = m_pOperator.Open(ref device);   //打开设备
            if (MyCamera.MV_OK != nRet)
            {
                MessageBox.Show("设备打开失败!");
                return;
            }

            //设置采集连续模式
            m_pOperator.SetEnumValue("AcquisitionMode", 2);// 工作在连续模式
            m_pOperator.SetEnumValue("TriggerMode", 0);    // 连续模式

            button_Open.IsEnabled = false;
        }

        private void button_Start_Click(object sender, RoutedEventArgs e)
        {
            CarmeraStartGrab();
        }

        //开始采集
        private void CarmeraStartGrab()
        {
            int nRet = m_pOperator.StartGrabbing();
            if (MyCamera.MV_OK != nRet)
            {
                MessageBox.Show("开始取流失败！");
                return;
            }

            //显示
            nRet = m_pOperator.Display(m_CameraPicBox.Handle);
            if (MyCamera.MV_OK != nRet)
            {
                MessageBox.Show("显示失败！");
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            m_pOperator.Close();
        }
    }
}
