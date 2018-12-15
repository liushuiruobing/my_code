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

        }

        private void BtnCreateServer_Click(object sender, EventArgs e)
        {
            m_MyTcpServer = new MyTcpServer();
            m_MyTcpServer.m_TcpParam.nIpAddress = IPAddress.Parse(textBoxIp.Text);
            m_MyTcpServer.m_TcpParam.nPort = int.Parse(textBoxPort.Text);

            bool Re = m_MyTcpServer.CreatServer();
            if (Re)
            {
                MessageBox.Show("服务创建成功！");
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
            if (m_MyTcpServer != null)
                m_MyTcpServer.CloseServer();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
