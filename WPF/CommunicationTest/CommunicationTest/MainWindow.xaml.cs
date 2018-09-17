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

namespace CommunicationTest
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        MySocket mySocket = null;
        public MainWindow()
        {
            InitializeComponent();
            mySocket = new MySocket();

            button_TcpDisConnect.IsEnabled = false;
            button_TcpSend.IsEnabled = false;
        }

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

        private void button_SerialConnect_Click(object sender, RoutedEventArgs e)
        {

        }

        private void button_SerialDisConnect_Click(object sender, RoutedEventArgs e)
        {

        }

        private void button_SerialSend_Click(object sender, RoutedEventArgs e)
        {

        }

        private void button_SerialClear_Click(object sender, RoutedEventArgs e)
        {

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
}
