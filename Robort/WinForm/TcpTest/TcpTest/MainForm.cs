using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TcpTest
{
    public partial class MainForm : Form
    {
        SynchronizationContext m_SyncContext = null;

        /**********************************************/
        public MyTcpServer m_MyTcpServer = null;
        public MyTcpClient m_MyTcpClient = null;
        public Thread TcpProcessClientMeasThread = null;
        public Thread TcpProcessServerMeasThread = null;
        public bool SystemRunning = true;

        /**********************************************/

        public MainForm()
        {
            InitializeComponent();
            //TextBox.CheckForIllegalCrossThreadCalls = false;
            m_SyncContext = SynchronizationContext.Current;  //获取当前线程的同步上下文，当前线程即UI线程           
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void BtnConnect_Click(object sender, EventArgs e)
        {
            m_MyTcpClient = new MyTcpClient();
            m_MyTcpClient.m_TcpParam.InitTcpParam();
            m_MyTcpClient.InitClient();
            if (m_MyTcpClient != null)
            {
                m_MyTcpClient.CreateConnect(IPAddress.Parse(textBoxIp.Text), int.Parse(textBoxPort.Text));
                if (m_MyTcpClient.m_TcpClient.Connected)
                {
                    TcpProcessClientMeasThread = new Thread(new ThreadStart(TcpProcessClientMeasThreadFunc));
                    TcpProcessClientMeasThread.Start();
                }
            }
        }

        public void TcpProcessClientMeasThreadFunc()
        {
            while (true)
            {
                if (!SystemRunning)
                    break;

                if (m_MyTcpClient != null)
                {
                    try
                    {
                        lock (this)
                        {
                            //异步的方式处理所有消息                          
                            while (m_MyTcpClient.m_RecvMeasQueue.Count > 0)
                            {
                                TcpMeas meas = m_MyTcpClient.m_RecvMeasQueue.Dequeue();
                                m_SyncContext.Post(ProcessClientMeassage, meas);
                            }
                        }
                    }
                    catch (System.Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        /*采用SynchronizationContext方法*****************************************/
        private void ProcessClientMeassage(object Meassage)
        {
            TcpMeas meas = (TcpMeas)Meassage;
            switch (meas.MeasType)
            {
                case TcpMeasType.MEAS_TYPE_ARM:
                    break;
                default: break;
            }
        }

        private void BtnSend_Click(object sender, EventArgs e)
        {
            if (m_MyTcpClient != null)
                m_MyTcpClient.ClientWrite(textBoxSend.Text);
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            textBoxRecv.Text = "";
        }

        private void BtnCreateServer_Click(object sender, EventArgs e)
        {
            m_MyTcpServer = new MyTcpServer();
            m_MyTcpServer.m_TcpParam.nIpAddress = IPAddress.Parse(textBoxIp.Text);
            m_MyTcpServer.m_TcpParam.nPort = int.Parse(textBoxPort.Text);

            bool Re = m_MyTcpServer.CreatServer();
            if (Re)
            {
                TcpProcessServerMeasThread = new Thread(new ThreadStart(TcpProcessServerMeasThreadFunc));
                TcpProcessServerMeasThread.Start();
                MessageBox.Show("服务创建成功！");
            }
        }

        public void TcpProcessServerMeasThreadFunc()
        {
            while (true)
            {
                if (!SystemRunning)
                    break;

                if (m_MyTcpServer != null)
                {
                    try
                    {
                        lock (this)
                        {
                            //异步的方式处理所有消息                          
                            while (m_MyTcpServer.m_RecvMeasQueue.Count > 0)
                            {
                                TcpMeas meas = m_MyTcpServer.m_RecvMeasQueue.Dequeue();
                                m_SyncContext.Post(ProcessServerMeassage, meas);
                            }
                        }
                    }
                    catch (System.Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        /*采用SynchronizationContext方法*****************************************/
        private void ProcessServerMeassage(object Meassage)
        {
            TcpMeas meas = (TcpMeas)Meassage;
            if (meas != null)
            {
                switch (meas.MeasType)
                {
                    case TcpMeasType.MEAS_TYPE_MIS:
                        break;
                    case TcpMeasType.MEAS_TYPE_PLC:
                        break;
                    default: break;
                }
            }
            Debug.WriteLine(Encoding.ASCII.GetString(meas.Param, 0, meas.Param.Length));         
        }
        /*////////////////////////////////////////

        /*采用Invoke方法 ***************************************/
        delegate void SetTextCallback(string text);
        private void SetText(string text)
        {
            if (this.textBoxRecv.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { text });
            }
        }
        //*******************************************/
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            SystemRunning = false;
            if (m_MyTcpServer != null)
                m_MyTcpServer.CloseServer();
        }
    }
}
