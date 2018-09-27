using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.IO.Ports;
using System.Threading;
using System.Diagnostics;
using LibUsbDotNet.DeviceNotify;
using System.ComponentModel;
using LibUsbDotNet.Main;
using LibUsbDotNet;


namespace CommunicationTest
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        //网络
        public  MySocket mySocket = null;

        //Usb
        public MyUsb myUsb = null;
        public Thread readUsbThread = null;
        private AutoResetEvent readUsbThreadexitEvent;
        public int nVID = 0x1234;
        public int nPID = 0x5677;
        public string strUsbRead = "";

        //串口
        public MySerial MySerial = null;
        public Thread readSerialThread = null;
        private AutoResetEvent readSerialThreadexitEvent;
        private int nWaitTime = 10;

        SynchronizationContext m_SyncContext = null;

        public MainWindow()
        {
            InitializeComponent();
            mySocket = new MySocket();
            myUsb = new MyUsb(nVID, nPID);
            MySerial = new MySerial();

            //网络
            button_TcpDisConnect.IsEnabled = false;
            button_TcpSend.IsEnabled = false;

            //Usb
            Binding binding = new Binding();
            binding.Source = myUsb;
            binding.Path = new PropertyPath("USB_State");
            ////使用Binding 连接数据源与绑定目标
            BindingOperations.SetBinding(textBlock_UbsState, TextBlock.TextProperty, binding);

            Binding bdColor = new Binding();
            bdColor.Source = myUsb;
            bdColor.Path = new PropertyPath("USB_StateColor");
            BindingOperations.SetBinding(textBlock_UbsState, TextBlock.ForegroundProperty, bdColor);

            textBox_UsbRecv.SetBinding(TextBox.TextProperty, new Binding("USB_ReadString") { Source = myUsb });

            //串口
            button_SerialDisConnect.IsEnabled = false;
            button_SerialSend.IsEnabled = false;
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            if (readSerialThread != null)
            {
                readSerialThread.Abort();
                readSerialThread.Join();
            }
        }

        //网络相关操作
        private void button_TcpConnect_Click(object sender, RoutedEventArgs e)
        {
            string strIp = textBox_Ip.Text;
            int nPort = int.Parse(textBox_Port.Text);
            mySocket.socket = mySocket.ConnectSocket(strIp, nPort);
            button_TcpConnect.IsEnabled = false;
            button_TcpDisConnect.IsEnabled = true;
            button_TcpSend.IsEnabled = true;
        }

        private void button_TcpDisConnect_Click(object sender, RoutedEventArgs e)
        {
            if (mySocket.socket != null)
                mySocket.socket.Close();

            button_TcpConnect.IsEnabled = true;
            button_TcpDisConnect.IsEnabled = false;
            button_TcpSend.IsEnabled = false;
        }

        private void button_TcpSend_Click(object sender, RoutedEventArgs e)
        {
            if (mySocket.socket != null)
            {
                string strRecv = mySocket.SocketSendAndReceive(ref mySocket.socket, textBox_TcpSend.Text);
                textBox_TcpRecv.Text += strRecv;
            }
            else
            {
                MessageBox.Show("请检查网络连接！");
            }
        }

        private void button_TcpClear_Click(object sender, RoutedEventArgs e)
        {
            textBox_TcpRecv.Clear();
        }

        //USB的相关操作
        private void button_UsbStart_Click(object sender, RoutedEventArgs e)
        {
            if (myUsb != null)
            {
                myUsb.OpenDevice();
                if (myUsb.MyUsbDevice != null && myUsb.MyUsbDevice.IsOpen)
                {
                    if (textBlock_UbsState.Text != "连接")
                    {
                        myUsb.USB_State = "连接";
                        myUsb.USB_StateColor = new SolidColorBrush(Colors.Blue);
                    }

                    readUsbThreadexitEvent = new AutoResetEvent(false);
                    readUsbThread = new Thread(UsbReadThreadFunc);
                    readUsbThread.Start();
                }
                else
                    MessageBox.Show("请连接USB设备！");
            }
            
        }

        private void button_UsbSend_Click(object sender, RoutedEventArgs e)
        {
            if (myUsb != null && myUsb.MyUsbDevice != null && myUsb.MyUsbDevice.IsOpen)
            {
                int nWrite = -1;
                myUsb.Write(textBox_UsbSend.Text, ref nWrite);
            }
        }

        private void button_UsbClear_Click(object sender, RoutedEventArgs e)
        {
            textBox_UsbRecv.Text = "";
        }

        public void UsbReadThreadFunc()
        {
            while (true)
            {               
                myUsb.Read(); //已经把myUsb.USB_ReadString绑定到 textBox_UsbRecv上

                if (readUsbThreadexitEvent.WaitOne(nWaitTime))
                {
                    break;
                }
            }
        }

        //串口相关操作
        private void button_SerialConnect_Click(object sender, RoutedEventArgs e)
        {
            MySerial.strPort = textBox_SerialPort.Text;
            MySerial.nBaudRate = int.Parse(textBox_BaudRate.Text);
            MySerial.nParity = (Parity)Enum.Parse(typeof(Parity), textBox_CheckBit.Text, true); 
            MySerial.nDataBits = int.Parse(textBox_DataBit.Text);
            MySerial.StopBits = (StopBits)Enum.Parse(typeof(StopBits), textBox_StopBit.Text, true);

            MySerial.Connect(ref MySerial.serialPort);
            
            if (MySerial != null && MySerial.serialPort.IsOpen)
            {
                m_SyncContext = SynchronizationContext.Current;
                readSerialThreadexitEvent = new AutoResetEvent(false);
                readSerialThread = new Thread(SerialReadFunc);
                readSerialThread.Start();
            }

            button_SerialConnect.IsEnabled = false;
            button_SerialDisConnect.IsEnabled = true;
            button_SerialSend.IsEnabled = true;
        }

        private void button_SerialDisConnect_Click(object sender, RoutedEventArgs e)
        {           
            if (readSerialThread != null)
            {
                readSerialThreadexitEvent.Set();
                readSerialThread.Join();
                readSerialThread = null;
            }

            MySerial.serialPort.Close();
            button_SerialConnect.IsEnabled = true;
            button_SerialDisConnect.IsEnabled = false;
            button_SerialSend.IsEnabled = false;
        }

        private void button_SerialSend_Click(object sender, RoutedEventArgs e)
        {
            if(MySerial != null)
                MySerial.SerialWrite(textBox_SerialSend.Text);
        }

        private void button_SerialClear_Click(object sender, RoutedEventArgs e)
        {
            textBox_SerialRecv.Text = "清除！";
        }

        public void SerialReadFunc()
        {
            while (true)
            {
                MySerial.SerialRead();
                m_SyncContext.Post(UpdateSerialRecv, MySerial.strRead);
                if (readSerialThreadexitEvent.WaitOne(nWaitTime))
                {
                    break;
                }             
            }
        }

        private void UpdateSerialRecv(object text)
        {
            textBox_SerialRecv.Text += text.ToString();
        }




    }

    public partial class MySocket
    {
        public Socket socket = null;
        public const int nRecvBuf = 8192;
        public const int nReadTimeOut = 100;

        public Socket ConnectSocket(string strIp, int nPort)
        {
            Socket socket = null;
            //IPHostEntry myIpHostEntry = Dns.GetHostEntry(textBox_Ip.Text);  //获得主机信息

            //使用指定的地址和端口号来实例化IPEndPoint
            IPAddress address = IPAddress.Parse(strIp);
            IPEndPoint myIpEndPoint = new IPEndPoint(address, nPort);
            //Socket newSocket = new Socket(myIpEndPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            Socket newSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                newSocket.Connect(myIpEndPoint);
                if (newSocket.Connected)
                {
                    newSocket.ReceiveTimeout = nReadTimeOut;  //设置超时，超时后会抛出SocketException的异常
                    socket = newSocket;
                }

                return socket;
            }
            catch (SocketException)
            {
                MessageBox.Show("请检查网络连接！");
                return socket;
            }         
        }

        public string SocketSendAndReceive(ref Socket socket, string strSend)
        {
            strSend += Environment.NewLine;
            string strRecv = "";
            Byte[] byteSend = Encoding.ASCII.GetBytes(strSend);
            Byte[] byteRecv = new Byte[nRecvBuf];

            int nRecvTemp = 0;
            int nSendTemp = socket.Send(byteSend);
            do
            {
                try
                {
                    nRecvTemp = socket.Receive(byteRecv);
                }
                catch (SocketException)  //捕获因超时引发的异常
                {
                    break;
                }
                
                strRecv += Encoding.ASCII.GetString(byteRecv, 0, nRecvTemp);
            }
            while (nRecvTemp > 0);

            return strRecv;
        }
    }

    public partial class MyUsb : INotifyPropertyChanged
    {
        //USB 通断监控
        private string strMyUsbState = "无设备";
        private Brush strMyUsbStateColor = new SolidColorBrush(Colors.Black);
        public event PropertyChangedEventHandler PropertyChanged;
        public IDeviceNotifier UsbDeviceNotifier = DeviceNotifier.OpenDeviceNotifier();

        //USB参数
        public int nVid = 0;
        public int nPid = 0;
        public int nWriteTimeOut = 2000;
        public int nReadTimeOut = 100;
        public readonly int nReadBufSize = 64;
        public UsbDevice MyUsbDevice = null;
        public UsbDeviceFinder MyUsbFinder = null;
        public UsbEndpointReader reader = null;
        public UsbEndpointWriter writer = null;
        private string strUsbRead = "";
        

        public MyUsb(int nVId, int nPId)
        {
            UsbDeviceNotifier.OnDeviceNotify += OnDeviceNotifyEvent;

            nVid = nVId;
            nPid = nPId;
            MyUsbFinder = new UsbDeviceFinder(nVId, nPId);
           
        }

        public string USB_State
        {
            get { return strMyUsbState; }
            set
            {
                strMyUsbState = value;
                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged.Invoke(this, new PropertyChangedEventArgs("USB_State"));
                }
            }
        }

        public Brush USB_StateColor
        {
            get { return strMyUsbStateColor; }
            set
            {
                strMyUsbStateColor = value;
                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged.Invoke(this, new PropertyChangedEventArgs("USB_StateColor"));
                }
            }
        }

        public string USB_ReadString
        {
            get { return strUsbRead; }
            set
            {
                strUsbRead = value;
                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged.Invoke(this, new PropertyChangedEventArgs("USB_ReadString"));
                }
            }
        }

        public void OnDeviceNotifyEvent(object sender, DeviceNotifyEventArgs e)
        {
            // A Device system-level event has occured
            if (e.EventType == EventType.DeviceArrival)
            {
                USB_State = "连接";
                USB_StateColor = new SolidColorBrush(Colors.Blue);
            }
            else if (e.EventType == EventType.DeviceRemoveComplete)
            {
                USB_State = "断开";
                USB_StateColor = new SolidColorBrush(Colors.Red);
            }
        }

        public bool OpenDevice()
        {
            MyUsbDevice = UsbDevice.OpenUsbDevice(MyUsbFinder);
            if (MyUsbDevice == null)
            {
                return false;
            }

            #region   当设备是一个 "whole" USB 时，我们的设备一般不会是此情况
            // If this is a "whole" usb device (libusb-win32, linux libusb)
            // it will have an IUsbDevice interface. If not (WinUSB) the 
            // variable will be null indicating this is an interface of a 
            // device.
            IUsbDevice wholeUsbDevice = MyUsbDevice as IUsbDevice;
            if (!ReferenceEquals(wholeUsbDevice, null))
            {
                // This is a "whole" USB device. Before it can be used, 
                // the desired configuration and interface must be selected.

                // Select config #1
                wholeUsbDevice.SetConfiguration(1);

                // Claim interface #0.
                wholeUsbDevice.ClaimInterface(0);
            }
            #endregion

            reader = MyUsbDevice.OpenEndpointReader(ReadEndpointID.Ep02);
            reader.ReadBufferSize = nReadBufSize;

            writer = MyUsbDevice.OpenEndpointWriter(WriteEndpointID.Ep01);
            return true;
        }

        public bool Write(string strWrite, ref int bytesWritten)
        {
            bool bRe = false;
            
            if (!String.IsNullOrEmpty(strWrite))
            {
                ErrorCode ec = writer.Write(Encoding.Default.GetBytes(strWrite), nWriteTimeOut, out bytesWritten);
                if (ec != ErrorCode.None)
                    bRe = false;
            }

            return bRe;
        }

        public bool Read()
        {
            bool bRe = false;
            int nReadCount = 0;
            byte[] readBuffer = new byte[nReadBufSize];

            ErrorCode ec = ErrorCode.None;
            while (true)
            {
                int bytesRead = -1;

                // If the device hasn't sent data in the last nReadTimeOut milliseconds,
                // a timeout error (ec = IoTimedOut) will occur. 
                ec = reader.Read(readBuffer, nReadTimeOut, out bytesRead);

                nReadCount += bytesRead;
                if (nReadCount != 0 && (bytesRead == 0 && ec == ErrorCode.IoTimedOut))
                    break;
            }

            USB_ReadString += byteToHexStr(readBuffer);

            //USB_ReadString += Encoding.Default.GetString(readBuffer, 0, nReadCount).TrimEnd('\0');
            nReadCount = 0;

            if (ec == ErrorCode.None)
                bRe = true;

            return bRe;
        }

        public bool WriteAndRead(string strWrite, ref string strRead)
        {
            bool bRe = false;
            if (!String.IsNullOrEmpty(strWrite))
            {
                ErrorCode ec = ErrorCode.None;
                int bytesWritten;
                ec = writer.Write(Encoding.Default.GetBytes(strWrite), nWriteTimeOut, out bytesWritten);
                if (ec != ErrorCode.None)
                    return false;

                int nReadCount = 0;
                byte[] readBuffer = new byte[nReadBufSize];
                while (true)
                {
                    int bytesRead = -1;

                    // If the device hasn't sent data in the last nReadTimeOut milliseconds,
                    // a timeout error (ec = IoTimedOut) will occur. 
                    ec = reader.Read(readBuffer, nReadTimeOut, out bytesRead);

                    nReadCount += bytesRead;
                    if (nReadCount != 0 && (bytesRead == 0 && ec == ErrorCode.IoTimedOut))
                        break;
                }

                strRead = Encoding.Default.GetString(readBuffer, 0, nReadCount);

                if (ec == ErrorCode.None)
                    bRe = true;
            }

            return bRe;
        }

        //字节数组转16进制字符串
        public static string byteToHexStr(byte[] bytes)
        {
            string returnStr = "";
            if (bytes != null)
            {
                for (int i = 0; i < bytes.Length; i++)
                {
                    returnStr += bytes[i].ToString("X2") + " ";
                }
            }
            return returnStr;
        }
    }

    public partial class MySerial
    {
        public SerialPort serialPort = null;
        public string strRead = " ";
        public string strWrite;
        public string strPort;
        public int nBaudRate;
        public Parity nParity;
        public int nDataBits;
        public StopBits StopBits;
        public int nReadTimeOut = 500;
        public int nWriteTimeOut = 500;

        public bool Connect(ref SerialPort tempSerial)
        {
            bool bRe = false;
            tempSerial = new SerialPort(strPort, nBaudRate, nParity, nDataBits, StopBits);

            //默认是InfiniteTimeout
            tempSerial.ReadTimeout = nReadTimeOut;
            //tempSerial.WriteTimeout = nWriteTimeOut;

            try
            {
                serialPort.Open();
                bRe = true;
            }
            catch
            {
                MessageBox.Show("打开串口失败！");
            }

            return bRe;
        }

        public void SerialRead()
        {
            try
            {
                strRead = serialPort.ReadLine();
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("指定端口未打开！");
            }
            catch (TimeoutException)
            {
                strRead = "";
            }
            Debug.WriteLine(strRead);
        }

        public void SerialWrite(string strWrite)
        {
            try
            {
                serialPort.Write(strWrite);
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("指定端口未打开！");
            }
            catch (TimeoutException)
            {
                //MessageBox.Show("写入超时！");
            }
        }
    }
}
