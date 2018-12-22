using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RobotWorkstation
{
    public struct TcpParam
    {
        public IPAddress nIpAddress;
        public int nPort;

        public void InitTcpParam()
        {
            nIpAddress = IPAddress.Parse("127.0.0.1");
            nPort = 20000;
        }
    }

    public enum TcpMeasType
    {
        MEAS_TYPE_NONE = 0,
        MEAS_TYPE_MIS,
        MEAS_TYPE_PLC,
        MEAS_TYPE_ARM
    }

    public enum TcpMeasCode
    {
        MEAS_CODE_NONE = 0,
        //...........命令码
    }

    //Tcp Meassage Class
    public class TcpMeas
    {
        public TcpClient Client;
        public TcpMeasType MeasType;
        public int MeasCode;
        public byte[] Param;       
    }

    //Tcp Client Class
    public partial class MyTcpClient
    {
        public TcpClient m_TcpClient = null;
        public TcpParam m_TcpParam;
        public int RecvTimeOut = 100; 
        public int SendTimeOut = 100;        
        public Queue<TcpMeas> m_RecvMeasQueue = new Queue<TcpMeas>();
        public byte[] m_SendBack = System.Text.Encoding.ASCII.GetBytes("Received:OK");

        private Byte[] m_RecvBytes = new Byte[8192];
        public const int m_SendBytesMax = 1024;

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
                        bool Process = false;
                        lock (this)
                        {
                            //主线程创建1个任务来处理客户端接收到的数据
                            Process = ProcessAndAddMessageToQueue(m_RecvBytes);                           
                            if(Process)
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
                    MessageBox.Show(e.Message);
                    continue;
                }
            }
        }

        public bool ProcessAndAddMessageToQueue(byte[] RecvBytes)
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
                TempMeas.Client = m_TcpClient;
                TempMeas.MeasType = MeasType;
                TempMeas.MeasCode = MeasCode;
                TempMeas.Param = System.Text.Encoding.ASCII.GetBytes("Just for test !");

                if (TempMeas != null)
                    m_RecvMeasQueue.Enqueue(TempMeas);

                Re = true;
            }

            return Re;
        }

        public async void ClientWrite(string line)
        {
            if (m_TcpClient.Connected)
            {
                try
                {
                    NetworkStream stream = m_TcpClient.GetStream();
                    using (var writer = new StreamWriter(stream, Encoding.ASCII, m_SendBytesMax, leaveOpen: true))
                    {
                        writer.AutoFlush = true;
                        await writer.WriteLineAsync(line);
                    }
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
            }
        }
    }

    //Tcp Server Class
    public partial class MyTcpServer
    {
        public TcpListener m_TcpListener = null;
        public TcpParam m_TcpParam;
        public Queue<TcpMeas> m_RecvMeasQueue = new Queue<TcpMeas>();
        public byte[] m_SendBack = System.Text.Encoding.ASCII.GetBytes("Received:OK");
        public const int m_SendBytesMax = 1024;

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
                        TcpClient tempClient = m_TcpListener.AcceptTcpClient();
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
                            //主线程创建不同的线程来分别异步的方式处理不同类型的消息
                            Process = ProcessAndAddMessageToQueue(m_RecvBytes, CurClient);
                            if (Process)
                                stream.Write(m_SendBack, 0, m_SendBack.Length);
                        }
                    }
                                      
                    stream.Close(); // Shutdown and end connection
                    CurClient.Close();
                    break;
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                    break;
                }
            }
        }

        public bool ProcessAndAddMessageToQueue(byte[] RecvBytes, TcpClient Client)
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

                if (TempMeas != null)
                    m_RecvMeasQueue.Enqueue(TempMeas);

                Re = true;
            }

            return Re;
        }
    }
}
