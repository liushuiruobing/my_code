using DeviceSource;
using MvCamCtrl.NET;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace WPF_HikvisionCamera
{
    /// <summary>
    /// WPF_Image.xaml 的交互逻辑
    /// </summary>
    public partial class WPF_Image : Window
    {
        //摄像头相关
        CameraOperator m_pOperator;
        MyCamera.MV_CC_DEVICE_INFO_LIST m_pDeviceList;
        MyCamera.cbOutputdelegate ImageCallback;
        bool m_bGrabbing = false;
        uint m_nBufSizeForSaveImage = 3072 * 2048 * 3 * 3 + 2048;
        byte[] m_pBufForSaveImage = new byte[3072 * 2048 * 3 * 3 + 2048]; //用于保存图像的缓存
        ImageSourceConverter imageSourceConverter = new ImageSourceConverter();

        public WPF_Image()
        {
            InitializeComponent();
            InitCamera();
            CarmerDeviceListAcq();
        }

        private void InitCamera()
        {
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


            ImageCallback = new MyCamera.cbOutputdelegate(SaveImageCallBack);
            nRet = m_pOperator.RegisterImageCallBack(ImageCallback, IntPtr.Zero);
            if (CameraOperator.CO_OK != nRet)
            {
                MessageBox.Show("注册回调失败!");
            }
            button_Open.IsEnabled = false;
        }

        //回调函数
        private void SaveImageCallBack(IntPtr pData, ref MyCamera.MV_FRAME_OUT_INFO pFrameInfo, IntPtr pUser)
        {
            DateTime dataTime1 = DateTime.Now;
            if ((3 * pFrameInfo.nFrameLen + 2048) > m_nBufSizeForSaveImage)
            {
                m_nBufSizeForSaveImage = 3 * pFrameInfo.nFrameLen + 2048;
                m_pBufForSaveImage = new byte[m_nBufSizeForSaveImage];
            }

            IntPtr pImage = Marshal.UnsafeAddrOfPinnedArrayElement(m_pBufForSaveImage, 0);
            MyCamera.MV_SAVE_IMAGE_PARAM stSaveParam = new MyCamera.MV_SAVE_IMAGE_PARAM();
            stSaveParam.enImageType = MyCamera.MV_SAVE_IAMGE_TYPE.MV_Image_Bmp;
            stSaveParam.enPixelType = pFrameInfo.enPixelType;
            stSaveParam.pData = pData;
            stSaveParam.nDataLen = pFrameInfo.nFrameLen;
            stSaveParam.nHeight = pFrameInfo.nHeight;
            stSaveParam.nWidth = pFrameInfo.nWidth;
            stSaveParam.pImageBuffer = pImage;
            stSaveParam.nBufferSize = m_nBufSizeForSaveImage;
            stSaveParam.nImageLen = 0;
            int nRet = m_pOperator.SaveImage(ref stSaveParam);

            MemoryStream ms = new MemoryStream(); //新建内存流        
            ms.Write(m_pBufForSaveImage, 0, (int)stSaveParam.nImageLen); //附值

            this.Dispatcher.Invoke(DispatcherPriority.Normal,
            (ThreadStart)delegate ()
            {
                image_Camera.Source = imageSourceConverter.ConvertFrom(ms) as BitmapFrame;
                GC.Collect(); //强制回收资源
            }
            );

            Thread.Sleep(500);   //这个延时可以让UI的响应更为流畅，但是图片的刷新较慢，打印的事件lTime在40ms内
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
        }

        private void button_Start_Click(object sender, RoutedEventArgs e)
        {
            //设置采集连续模式
            m_pOperator.SetEnumValue("AcquisitionMode", 2);// 工作在连续模式
            m_pOperator.SetEnumValue("TriggerMode", 0);    // 连续模式
            CarmeraStartGrab();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            m_pOperator.Close();
        }
    }
}
