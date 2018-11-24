using System;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RobotWorkstation
{
    public struct NetParam
    {
        public string StrIp;
        public int Port;

        public void InitNetParam()
        {
            StrIp = "192.168.81.11";
            Port = 5025;
        }
    }

    class NetCommu : AbstractCommunication
    {
        public NetParam m_NetParam;
        public Socket m_Socket = null;
        public bool m_bConnect = false;
 
        public const int m_RecvBufSize = 8192;
        public const int m_ReadTimeOut = 1;
        private Byte[] byteRecv = new Byte[m_RecvBufSize];

        public override bool InitializeCommu()
        {
            //IPHostEntry myIpHostEntry = Dns.GetHostEntry(textBox_Ip.Text);  //获得主机信息

            //使用指定的地址和端口号来实例化 Socket
            IPAddress address = IPAddress.Parse(m_NetParam.StrIp);
            IPEndPoint myIpEndPoint = new IPEndPoint(address, m_NetParam.Port);
            Socket newSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            try
            {              
                newSocket.Connect(myIpEndPoint);
                if (newSocket.Connected)
                {
                    newSocket.ReceiveTimeout = m_ReadTimeOut;  //设置超时，超时后会抛出SocketException的异常
                    m_Socket = newSocket;
                }
                m_bConnect = true;
                return true;
            }
            catch(Exception ex) //(SocketException)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "警告");
                Debug.WriteLine(ex.Message);
                return false;
            }
        }

        public override bool Write(byte[] WrBuf, int WrCount)
        {
            bool bRe = false;
            int nSendCount = 0;
            if (m_bConnect && m_Socket != null)
            {
                nSendCount = m_Socket.Send(WrBuf);
                if (nSendCount == WrCount)
                    bRe = true;
            }
            
            return bRe;
        }

        public override bool Read(ref string RdBuf, ref int RdCount)
        {
            bool bRe = false;
            int nRecvTemp = 0;
            if (m_bConnect && m_Socket != null)
            {                
                while(true)
                {
                    nRecvTemp = 0;
                    try
                    {
                        nRecvTemp = m_Socket.Receive(byteRecv);
                        if (nRecvTemp == 0)
                            break;

                        RdBuf += Encoding.ASCII.GetString(byteRecv, 0, nRecvTemp);
                        RdCount += nRecvTemp;

                        bRe = true;
                        if (byteRecv[nRecvTemp - 1] == '\n') //接收到\n退出
                            break;

                    }
                    catch //(SocketException)  //捕获因超时引发的异常
                    {
                        break;
                    }
                }                
            }            
            return bRe;
        }

        public override bool Query(byte[] WrBuf, int WrCount, ref string RdBuf, ref int RdCount)
        {
            bool bRe = false;
            bRe = Write(WrBuf, WrCount);
            if (bRe)
            {
                bRe = Read(ref RdBuf, ref RdCount);
            }

            return bRe;
        }

        public override void Close()
        {
            if (m_Socket != null)
                m_Socket.Close();
        }
    }
}

