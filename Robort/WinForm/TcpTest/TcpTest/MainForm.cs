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

        /****************************************************/
        public MyTcpServer m_MyTcpServer = null;
        public MyTcpClient m_MyTcpClient = null;
        public Thread TcpMeasProcessThread = null;
        public bool SystemRunning = true;

        /**********************************************/

        public MainForm()
        {
            InitializeComponent();
            //TextBox.CheckForIllegalCrossThreadCalls = false;
            m_SyncContext = SynchronizationContext.Current;  //获取当前线程的同步上下文，当前线程即UI线程

            
        }

        private void BtnConnect_Click(object sender, EventArgs e)
        {
            m_MyTcpClient = new MyTcpClient();
            m_MyTcpClient.m_TcpParam.InitTcpParam();
            m_MyTcpClient.InitClient();
            if (m_MyTcpClient != null)
            {
                m_MyTcpClient.CreateConnect(IPAddress.Parse(textBoxIp.Text), int.Parse(textBoxPort.Text));
            }
        }

        private void BtnDisConnect_Click(object sender, EventArgs e)
        {

        }

        private void BtnSend_Click(object sender, EventArgs e)
        {

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
                TcpMeasProcessThread = new Thread(new ThreadStart(TcpMeasProcessThreadFunc));
                TcpMeasProcessThread.Start();
                MessageBox.Show("服务创建成功！");
            }
        }

        public void TcpMeasProcessThreadFunc()
        {
            while (true)
            {
                Thread.Sleep(10);
                if (!SystemRunning)
                    break;

                if (m_MyTcpServer != null)
                {
                    try
                    {
                        lock (this)
                        {
                            //异步的方式处理所有消息
                            
                            for (int i = 0; i < m_MyTcpServer.m_TcpMeas.Count; i++)
                            {
                                TcpMeas meas = m_MyTcpServer.m_TcpMeas[i];
                                 m_SyncContext.Post(SetTextSafePost, Encoding.ASCII.GetString(meas.Param, 0, meas.Param.Length));
                            }

                            m_MyTcpServer.m_TcpMeas.Clear();
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
        private void SetTextSafePost(object str)
        {
            textBoxRecv.Text += str.ToString();  //考虑线程安全性，多线程访问
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

        private void MainForm_Load(object sender, EventArgs e)
        {
 
        }

        private void TimerRefresh_Tick(object sender, EventArgs e)
        {
            if (m_MyTcpClient != null)
            {
                //textBoxRecv.Text += m_MyTcpClient.m_StrRecv;
            }


        }
    }
}
