using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Controls;
using System.Runtime.InteropServices;
using MvCamCtrl.NET;
using DeviceSource;


namespace DR30A_CS_WPF_
{
    public struct CustomColor
    {
        public Brush BackGroundColor;
        public Brush BtnColor;
        public Brush BtnGreenColor;
        public Brush TxtBoxColor;
        public Brush TextColor;
        public Brush ListViewBackGround;
        public Brush ListViewHeader;
        public Brush ListViewSelected;

        public void InitColor()
        {
            BackGroundColor = new SolidColorBrush(Color.FromRgb(33, 33, 33));
            BtnColor = new SolidColorBrush(Color.FromRgb(74, 74, 74));
            BtnGreenColor = new SolidColorBrush(Color.FromRgb(70, 148, 8));
            TxtBoxColor = BackGroundColor;
            TextColor = new SolidColorBrush(Colors.White);
            ListViewBackGround = BackGroundColor;
            ListViewHeader = BtnColor;
            ListViewSelected = new SolidColorBrush(Color.FromRgb(51, 153, 255));
        }
    }

    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        CustomColor customColor;

        //摄像头相关
        CameraOperator m_pOperator;
        ComboBox m_CameraDeviceList;
        MyCamera.MV_CC_DEVICE_INFO_LIST m_pDeviceList;
        System.Windows.Forms.PictureBox m_CameraPicBox = null;

        public MainWindow()
        {
            InitializeComponent();
            InitWindowSize();
            InitControlColor();
            InitCamera();

            SystemParameters.StaticPropertyChanged += SystemParameters_StaticPropertyChanged;  //监控任务栏变化
        }

        //设置窗体的大小
        public void InitWindowSize()
        {
            //得到屏幕整体参数，如1600*900
            //double nScreenWidth = SystemParameters.PrimaryScreenWidth;//
            //double nScreenHeight = SystemParameters.PrimaryScreenHeight;

            //得到屏幕工作区域的参数，比如去除属性任务栏的高度
            double nScreenWidth = SystemParameters.WorkArea.Width;//
            double nScreenHeight = SystemParameters.WorkArea.Height; 

            this.MinWidth = this.MaxWidth = nScreenWidth;
            this.MinHeight = this.MaxHeight = nScreenHeight;         
        }

        //设置控件背景色
        public void InitControlColor()
        {
            customColor.InitColor();
            this.Background = customColor.BackGroundColor;
            label_Title.Foreground = customColor.TextColor;
            tabControl.Background = customColor.BackGroundColor;
            tabControl.SelectedIndex = 1;
            listView_TestExample.Background = customColor.BackGroundColor;
            listView_TestAction.Background = customColor.BackGroundColor;
        }

        private void InitCamera()
        {
            m_CameraPicBox = pictureHost.Child as System.Windows.Forms.PictureBox;
            m_CameraDeviceList = new ComboBox();
            m_pDeviceList = new MyCamera.MV_CC_DEVICE_INFO_LIST();
            m_pOperator = new CameraOperator();

            CarmerDeviceListAcq();
        }

        private void image_Close_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        //鼠标左键按下后可移动窗体
        private void DragWindow(object sender, MouseButtonEventArgs e)
        {
            //this.DragMove();
        }

        private void SystemParameters_StaticPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            //系统任务栏自动隐藏后自动调整软件的高度
            if (e.PropertyName == "WorkArea")
            {
                this.MinHeight = this.MaxHeight = SystemParameters.WorkArea.Height;
            }
        }

        private void button_CheckCarmer_Click(object sender, RoutedEventArgs e)
        {
            CarmerDeviceListAcq();
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

        //打开设备
        private void button_OpenCarmer_Click(object sender, RoutedEventArgs e)
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
            CarmeraStartGrab();

            SetCtrlWhenOpen();            
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

        //关闭摄像头设备
        private void button_CloseCarmer_Click(object sender, RoutedEventArgs e)
        {
            m_pOperator.Close();
            SetCtrlWhenClose();
        }

        //开启摄像头时，设置控件状态
        private void SetCtrlWhenOpen( )
        {
            button_OpenCarmer.IsEnabled = false;
            button_CloseCarmer.IsEnabled = true;
            button_SetParam.IsEnabled = true;
            button_GetParam.IsEnabled = true;
        }

        //关闭摄像头时，设置控件状态
        private void SetCtrlWhenClose()
        {
            button_OpenCarmer.IsEnabled = true;
            button_CloseCarmer.IsEnabled = false;
            button_SetParam.IsEnabled = false;
            button_GetParam.IsEnabled = false;
        }

        private void button_SetParam_Click(object sender, RoutedEventArgs e)
        {

        }

        private void button_GetParam_Click(object sender, RoutedEventArgs e)
        {

        }

        private void button_TestExampleImport_Click(object sender, RoutedEventArgs e)
        {

        }

        private void button_TestExampleExport_Click(object sender, RoutedEventArgs e)
        {

        }

        private void button_TestExampleUp_Click(object sender, RoutedEventArgs e)
        {

        }

        private void button_TestExampleDown_Click(object sender, RoutedEventArgs e)
        {

        }

        private void button_TestExampleDeleteSelected_Click(object sender, RoutedEventArgs e)
        {

        }

        private void button_TestExampleDeleteAll_Click(object sender, RoutedEventArgs e)
        {

        }

        private void button_AddExample_Click(object sender, RoutedEventArgs e)
        {

        }

        private void button_TestActionRebortHome_Click(object sender, RoutedEventArgs e)
        {

        }

        private void button_TestActionImportImage_Click(object sender, RoutedEventArgs e)
        {

        }

        private void button_TestActionUp_Click(object sender, RoutedEventArgs e)
        {

        }

        private void button_TestActionDown_Click(object sender, RoutedEventArgs e)
        {

        }

        private void button_TestActionDeleteSelected_Click(object sender, RoutedEventArgs e)
        {

        }

        private void button_TestActionDeleteAll_Click(object sender, RoutedEventArgs e)
        {

        }

        private void button_TestActionSetDelay_Click(object sender, RoutedEventArgs e)
        {

        }

        private void button_TestActionCollectPicture_Click(object sender, RoutedEventArgs e)
        {

        }

        private void button_TestActionArea_Click(object sender, RoutedEventArgs e)
        {

        }

        private void button_Run_Click(object sender, RoutedEventArgs e)
        {

        }

        private void button_Suspend_Click(object sender, RoutedEventArgs e)
        {

        }

        private void button_Stop_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            m_pOperator.Close();
        }
    }
}
