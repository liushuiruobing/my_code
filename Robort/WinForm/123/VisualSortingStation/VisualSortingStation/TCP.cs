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
    public enum TcpMeasType
    {
        MEAS_TYPE_NONE = 0,
        MEAS_TYPE_MIS,
        MEAS_TYPE_PLC,
        MEAS_TYPE_ARM,
        MEAS_TYPE_CAMERA
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
        public byte MeasCode;
        public byte[] Param = new byte[Message.MessageLength];

        public TcpMeas()
        {
            Array.Clear(Param, 0, Param.Length);
        }
    }

    //Tcp Client Class
    public partial class MyTcpClient
    {
        private TcpClient m_TcpClient = null;

        private int RecvTimeOut = 100;
        private int SendTimeOut = 100;        
        public Queue<TcpMeas> m_RecvMeasQueue = new Queue<TcpMeas>();
        private Byte[] m_RecvBytes = new Byte[8192];

        public MyTcpClient()
        {
            m_TcpClient = new TcpClient();
        }

        public bool IsConnected
       {
            get
            {
                return m_TcpClient.Connected;
            }
       }

        public void InitClient()
        {
            //IPEndPoint EndPoint = new IPEndPoint(m_TcpParam.nIpAddress, m_TcpParam.nPort);
            //m_TcpClient = new TcpClient(EndPoint);
          
            //m_TcpClient.ReceiveTimeout = RecvTimeOut;
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

        public void Close()
        {
            if (m_TcpClient != null && m_TcpClient.Connected)
            {
                m_TcpClient.Close();
            }
            
        }

        private void TcpClientRecvTask(object Client)
        {
            NetworkStream stream = (NetworkStream)(Client);
            int RecvCount = 0;
            int parseCount = 0;  //解析计数器
            byte[] arrayParse = new byte[Message.MessageLength];  //解析缓冲区

            while (true)
            {
                try
                {
                    while ((RecvCount = stream.Read(m_RecvBytes, 0, m_RecvBytes.Length)) != 0)
                    {
                        lock (this)
                        {
                            //主线程创建消息处理的线程处理消息
                            ParseAndAddMessageToQueue(m_RecvBytes, RecvCount, m_TcpClient, ref parseCount, arrayParse);
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

        public void ParseAndAddMessageToQueue(byte[] RecvBytes, int RecvCount, TcpClient Client, ref int parseCount, byte[] arrayParse)
        {
            //匹配比较数组, -1表示不需要比较,忽略
            int[] arrayCompare = new int[Message.MessageLength]
            {
                Message.MessStartCode, Message.MessVID1, Message.MessVID2, -1, Message.MessRightState, -1, -1, -1,
                -1, -1, -1, -1, -1, -1, -1, -1,
                -1, -1, -1, -1, -1, -1, -1, -1,
                -1, -1, -1, -1, -1, -1, -1, Message.MessEndCode,
            };

            for (int i = 0; i < RecvCount; i++)
            {
                if (arrayCompare[parseCount] != -1)  //需要匹配
                {
                    if (RecvBytes[i] == arrayCompare[parseCount])  //相等
                    {
                        arrayParse[parseCount++] = RecvBytes[i];
                    }
                    else  //不相等,复位计数器
                    {
                        parseCount = 0;
                    }
                }
                else  //不需要比较,直接赋值,并更新计数器
                {
                    arrayParse[parseCount++] = RecvBytes[i];
                }

                if (parseCount >= Message.MessageLength)
                {
                    parseCount = 0; //和校验

                    if (MyMath.CheckSum(arrayParse, Message.MessageLength))  //分析数据，把数据添加到队列m_TcpMeas
                    {

                        TcpMeasType MeasType = TcpMeasType.MEAS_TYPE_ARM;
                        byte MeasCode = arrayParse[Message.MessageCommandIndex];
                        if (MeasCode == (byte)Message.MessageCodeCamera.GetCameraCoords)
                        {
                            MeasType = TcpMeasType.MEAS_TYPE_CAMERA;
                        }

                        TcpMeas TempMeas = new TcpMeas();
                        if (TempMeas != null)
                        {
                            TempMeas.Client = Client;
                            TempMeas.MeasType = MeasType;
                            TempMeas.MeasCode = MeasCode;
                            Array.Copy(RecvBytes, TempMeas.Param, TempMeas.Param.Length);
                            m_RecvMeasQueue.Enqueue(TempMeas);
                        }

                        Array.Clear(arrayParse, 0, arrayParse.Length);
                    }
                    else  //校验和错误,则更新错误码后发回
                    {
                        arrayParse[Message.MessageStateIndex] = Message.MessErrorState;
                        using (NetworkStream stream = Client.GetStream())
                        {
                            stream.Write(arrayParse, 0, arrayParse.Length);
                        }
                    }
                }
            }
        }

        public async void ClientWrite(byte[] WriteBytes)
        {
            if (m_TcpClient.Connected)
            {
                try
                {
                    NetworkStream stream = m_TcpClient.GetStream();
                    await stream.WriteAsync(WriteBytes, 0, WriteBytes.Length);
                    await stream.FlushAsync();
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
            }
        }

        public async void ClientWrite(string StrSend)
        {
            if (m_TcpClient.Connected)
            {
                try
                {
                    NetworkStream stream = m_TcpClient.GetStream();
                    StreamWriter s = new StreamWriter(stream);
                    await s.WriteAsync(StrSend);
                    await s.FlushAsync();
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
        private static MyTcpServer m_UniqueTcpServer = null;
        private static readonly object m_Locker = new object();
        private TcpListener m_TcpListener = null;
        public Queue<TcpMeas> m_RecvMeasQueue = new Queue<TcpMeas>();
        
        private bool m_ThreadExit = false;
        private Thread m_TcpServerListenThread = null;      
        private Byte[] m_RecvBytes = new Byte[8192];

        private MyTcpServer()
        {

        }

        /// <summary>
        /// 定义公有方法提供一个全局访问点,同时你也可以定义公有属性来提供全局访问点
        /// </summary>
        /// <returns></returns>
        public static MyTcpServer GetInstance()
        {
            if (m_UniqueTcpServer == null)
            {
                lock (m_Locker)
                {
                    if (m_UniqueTcpServer == null)
                        m_UniqueTcpServer = new MyTcpServer();
                }
            }

            return m_UniqueTcpServer;
        }

        public bool CreatServer(IPAddress ServerIp, int ServerPort)
        {
            try
            {
                m_TcpListener = new TcpListener(ServerIp, ServerPort);
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
            int parseCount = 0;  //解析计数器
            byte[] arrayParse = new byte[Message.MessageLength];  //解析缓冲区

            while (true)
            {
                try
                {
                    while ((RecvCount = stream.Read(m_RecvBytes, 0, m_RecvBytes.Length)) != 0)
                    {
                        lock (this)
                        {
                            //接收到数据之后把消息存放到消息队列，
                            //主线程创建不同的线程来分别异步的方式处理不同类型的消息
                            ParseAndAddMessageToQueue(m_RecvBytes, RecvCount, CurClient, ref parseCount, arrayParse);
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

        public void ParseAndAddMessageToQueue(byte[] RecvBytes, int RecvCount, TcpClient Client, ref int parseCount, byte[] arrayParse)
        {
            //匹配比较数组, -1表示不需要比较,忽略
            int[] arrayCompare = new int[Message.MessageLength]
            {
                Message.MessStartCode, Message.MessVID1, Message.MessVID2, -1, Message.MessRightState, -1, Message.MessStationCode, -1,
                -1, -1, -1, -1, -1, -1, -1, -1,
                -1, -1, -1, -1, -1, -1, -1, -1,
                -1, -1, -1, -1, -1, -1, -1, Message.MessEndCode,
            };

            for (int i = 0; i < RecvCount; i++)
            {
                if (arrayCompare[parseCount] != -1)  //需要匹配
                {
                    if (RecvBytes[i] == arrayCompare[parseCount])  //相等
                    {
                        arrayParse[parseCount++] = RecvBytes[i];
                    }
                    else  //不相等,复位计数器
                    {
                        parseCount = 0;
                    }
                }
                else  //不需要比较,直接赋值,并更新计数器
                {
                    arrayParse[parseCount++] = RecvBytes[i];
                }

                if (parseCount >= Message.MessageLength)
                {                   
                    parseCount = 0; //和校验

                    if (MyMath.CheckSum(arrayParse, Message.MessageLength))  //分析数据，把数据添加到队列m_TcpMeas
                    {
                        TcpMeasType MeasType = TcpMeasType.MEAS_TYPE_NONE;
                        byte MeasCode = 0;

                        if (arrayParse[Message.MessageCommandIndex] == (byte)Message.MessageCodePLC.GetCurStationState)  //根据命令码区分消息类型
                        {
                            MeasType = TcpMeasType.MEAS_TYPE_PLC;
                            MeasCode = arrayParse[Message.MessageCommandIndex];
                        }

                        TcpMeas TempMeas = new TcpMeas();
                        if (TempMeas != null)
                        {
                            TempMeas.Client = Client;
                            TempMeas.MeasType = MeasType;
                            TempMeas.MeasCode = MeasCode;
                            Array.Copy(RecvBytes, TempMeas.Param, TempMeas.Param.Length);                                           
                            m_RecvMeasQueue.Enqueue(TempMeas);
                        }
                    }
                    else  //校验和错误,则更新错误码后发回
                    {
                        arrayParse[Message.MessageStateIndex] = Message.MessErrorState;
                        using (NetworkStream stream = Client.GetStream())
                        {
                            stream.Write(arrayParse, 0, arrayParse.Length);
                        }                                                    
                    }
                }
            }
        }
    }
}
