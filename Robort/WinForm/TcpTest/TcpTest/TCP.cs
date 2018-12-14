using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TcpTest
{
    public struct TcpParam
    {
        public IPAddress nIpAddress;
        public int nPort;

        public void InitTcpParam()
        {
            nIpAddress = IPAddress.Parse("127.0.0.1");
            nPort = 5025;
        }
    }

    public  enum TcpMeasType
    {
        MEAS_TYPE_NONE = 0,
        MEAS_TYPE_MIS,
        MEAS_TYPE_PLC
    }

    public enum TcpMeasCode
    {
        MEAS_CODE_NONE = 0,
    }

    public struct TcpMeas
    {
        public TcpMeasType MeasType;
        public int MeasCode;
        public byte[] Param;
        public TcpClient Client;
    }

    public partial class MyTcpClient
    {
        public TcpClient m_TcpClient = new TcpClient();
    }

    public partial class MyTcpServer
    {
        public TcpListener m_TcpListener = null;
        public TcpParam m_TcpParam;
        public List<TcpMeas> m_TcpMeas = new List<TcpMeas>();

        public Thread m_TcpServerListenThread = null;
        public bool m_ThreadExit = false;  //标志还是信号？
        private Byte[] m_RecvBytes = new Byte[256];

        public MyTcpServer()
        {
            m_TcpParam.InitTcpParam();
        }

        public bool CreatServer()
        {
            try
            {
                m_TcpListener = new TcpListener(m_TcpParam.nIpAddress, m_TcpParam.nPort);
                m_TcpListener.Start();

                m_TcpServerListenThread = new Thread(new ThreadStart(TcpListenThread));
                m_TcpServerListenThread.Start();

                if (m_TcpListener != null && m_TcpServerListenThread != null)
                    return true;
                else
                    return false;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
        }

        public void CloseServer()
        {
            m_ThreadExit = true;
            if (m_TcpListener != null)
                m_TcpListener.Stop();
        }

        public void TcpListenThread()
        {
            while (true)
            {
                if (m_ThreadExit)
                    break;

                try
                {
                    while (m_TcpListener != null && m_TcpListener.Pending())  //跳开阻塞，用这个在关闭服务器程序时不会出现异常
                    {
                        TcpClient tempClient = new TcpClient();
                        tempClient = m_TcpListener.AcceptTcpClient();
                        
                        //下面三行是测试代码
                        Socket s = tempClient.Client;
                        IPEndPoint clientipe = (IPEndPoint)s.RemoteEndPoint;
                        Console.WriteLine("[" + clientipe.Address.ToString() + "]" + " Connected");

                        Task RecvTask = new Task(TcpListenRecvTask, tempClient);
                        RecvTask.Start();
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                    break;
                }
            }
        }

        private void TcpListenRecvTask(object Client)
        {
            TcpClient CurClient = (TcpClient)Client;
            NetworkStream stream = CurClient.GetStream();
            int RecvCount = 0;
            while (true)
            {
                try
                {
                    while ((RecvCount = stream.Read(m_RecvBytes, 0, m_RecvBytes.Length)) != 0)
                    {
                        // Translate data bytes to a ASCII string.
                        String data = System.Text.Encoding.ASCII.GetString(m_RecvBytes, 0, RecvCount);
                        Console.WriteLine("Received: {0}", data);


                        //接收到数据之后把消息存放到消息队列，
                        //根据数据中不同的消息类型来存储在队列的不同位置中
                        //主线程创建2个任务来分别处理不同类型的消息，任务应该以异步的方式创建
                        
                        //write message list


                        //当即回复收到指令，如果是查询的指令，则在主线程的任务中去回复查询的内容
                        byte[] SendBack = System.Text.Encoding.ASCII.GetBytes(data);  //再把数据返回
                        stream.Write(SendBack, 0, SendBack.Length);
                        Console.WriteLine("Sent: {0}", data);
                    }

                    // Shutdown and end connection
                    CurClient.Close();
                    break;
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }

        }
    }
}
