using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TcpTest
{
    public enum TcpMeasType
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
        public TcpClient Client;
        public TcpMeasType MeasType;
        public int MeasCode;
        public byte[] Param;       
    }

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

    //Client Class
    public partial class MyTcpClient
    {
        public TcpClient m_TcpClient = null;
        public TcpParam m_TcpParam;
        public int RecvTimeOut = 100; //ms  不使用超时，使用异步通信方式呢？
        public int SendTimeOut = 100;        
        public List<TcpMeas> m_RecvMeasList = new List<TcpMeas>();
        public byte[] m_SendBack = System.Text.Encoding.ASCII.GetBytes("Received:OK");

        private Byte[] m_RecvBytes = new Byte[8192];

        public MyTcpClient()
        {
            m_TcpParam.InitTcpParam();
        }

        public void InitClient()
        {
            //IPEndPoint EndPoint = new IPEndPoint(m_TcpParam.nIpAddress, m_TcpParam.nPort);
            //m_TcpClient = new TcpClient(EndPoint);

            m_TcpClient = new TcpClient();
            m_TcpClient.ReceiveTimeout = RecvTimeOut;
            m_TcpClient.SendTimeout = SendTimeOut;
        }

        public void CreateConnect(IPAddress nIpAddress, int nPort)
        {
            if (m_TcpClient != null)
            {
                try
                {
                    m_TcpClient.Connect(nIpAddress, nPort);
                    if (m_TcpClient.Connected)
                    {
                        NetworkStream stream = m_TcpClient.GetStream();
                        Task RecvTask = new Task(TcpClientRecvTask, stream);
                        RecvTask.Start();
                    }
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void TcpClientRecvTask(object Client)
        {
            NetworkStream stream = (NetworkStream)(Client);
            int RecvCount = 0;
            while (true)
            {
                try
                {
                    while ((RecvCount = stream.Read(m_RecvBytes, 0, m_RecvBytes.Length)) != 0)
                    {
                        // Translate data bytes to a ASCII string.
                        lock (this)
                        {
                            string data = System.Text.Encoding.ASCII.GetString(m_RecvBytes, 0, RecvCount);
                            Console.WriteLine("Received: {0}", data);

                            //主线程创建1个任务来处理客户端接收到的数据

                            //当即回复收到指令，如果是查询的指令，则在主线程的任务中去回复查询的内容
                            stream.Write(m_SendBack, 0, m_SendBack.Length);
                        }                                         
                    }

                    // Shutdown and end connection
                    stream.Close();
                    m_TcpClient.Close();
                    break;
                }
                catch (Exception e)
                {
                    //MessageBox.Show(e.Message);
                    continue;
                }
            }
        }

        public async void ClientWrite(string line)
        {
            if (m_TcpClient.Connected)
            {
                NetworkStream stream = m_TcpClient.GetStream();
                using (var writer = new StreamWriter(stream, Encoding.ASCII, 1024, leaveOpen: true))
                {
                    writer.AutoFlush = true;
                    await writer.WriteLineAsync(line);
                }
            }
        }
    }

    //Server Class
    public partial class MyTcpServer
    {
        public TcpListener m_TcpListener = null;
        public TcpParam m_TcpParam;
        public List<TcpMeas> m_TcpMeas = new List<TcpMeas>();
        public byte[] m_SendBack = System.Text.Encoding.ASCII.GetBytes("Received:OK");

        private bool m_ThreadExit = false;
        private Thread m_TcpServerListenThread = null;      
        private Byte[] m_RecvBytes = new Byte[8192];

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

        private void TcpListenThread()
        {
            while (true)
            {
                if (m_ThreadExit)
                    break;

                try
                {
                    while (m_TcpListener != null && m_TcpListener.Pending())  
                    {
                        TcpClient tempClient = new TcpClient();
                        tempClient = m_TcpListener.AcceptTcpClient();
                        
                        //下面三行是测试代码
                        Socket s = tempClient.Client;
                        IPEndPoint clientipe = (IPEndPoint)s.RemoteEndPoint;
                        //Console.WriteLine("[" + clientipe.Address.ToString() + "]" + " Connected");

                        Task RecvTask = new Task(TcpListenRecvTask, tempClient);
                        RecvTask.Start();
                    }
                }
                catch (SocketException e)
                {
                    MessageBox.Show("SocketException: {0}", e.Message);
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
                        bool Process = false;
                        lock (this)
                        {
                            //接收到数据之后把消息存放到消息队列，
                            //根据数据中不同的消息类型来存储在队列的不同位置中
                            //主线程创建2个任务来分别处理不同类型的消息，任务应该以异步的方式创建
                            Process = ProcessAddMessageToList(m_RecvBytes, CurClient);
                        }

                        //just for test
                        string data = System.Text.Encoding.ASCII.GetString(m_RecvBytes, 0, RecvCount);
                        Console.WriteLine("Received: {0}", data);

                        //当即回复收到指令，如果是查询的指令，则在主线程的任务中去回复查询的内容
                        if (Process)
                            stream.Write(m_SendBack, 0, m_SendBack.Length);
                    }

                    // Shutdown and end connection
                    stream.Close();
                    CurClient.Close();
                    break;
                }
                catch (Exception e)
                {
                    //stream.Close();
                    //CurClient.Close();
                    MessageBox.Show(e.Message);
                }
            }
        }

        public bool ProcessAddMessageToList(byte[] RecvBytes, TcpClient Client)
        {
            bool Re = false;
            bool CheckData = false;
            TcpMeasType MeasType = TcpMeasType.MEAS_TYPE_NONE;
            int MeasCode = 0;

            //根据制定的协议校验数据
            //..........
            CheckData = true;

            //分析数据，把数据添加到队列m_TcpMeas
            if (CheckData)
            {
                TcpMeas TempMeas = new TcpMeas();
                TempMeas.Client = Client;
                TempMeas.MeasType = MeasType;
                TempMeas.MeasCode = MeasCode;
                TempMeas.Param = System.Text.Encoding.ASCII.GetBytes("Just for test !");

                m_TcpMeas.Add(TempMeas);

                Re = true;
            }

            return Re;
        }
    }
}
