using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO.Ports;
using System.Threading;
using System.Diagnostics;

namespace CommunicationTest
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public  MySocket mySocket = null;
        public MySerial MySerial = null;
        public Thread readSerialThread = null;
        private AutoResetEvent readSerialThreadexitEvent;
        private int nWaitTime = 10;

        SynchronizationContext m_SyncContext = null; 

        public MainWindow()
        {
            InitializeComponent();
            mySocket = new MySocket();
            MySerial = new MySerial();

            button_TcpDisConnect.IsEnabled = false;
            button_TcpSend.IsEnabled = false;

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
        private void button_UsbConnect_Click(object sender, RoutedEventArgs e)
        {

        }

        private void button_UsbDisConnect_Click(object sender, RoutedEventArgs e)
        {

        }

        private void button_UsbSend_Click(object sender, RoutedEventArgs e)
        {

        }

        private void button_UsbClear_Click(object sender, RoutedEventArgs e)
        {

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

    public partial class MyUsb
    {

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
