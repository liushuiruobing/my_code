using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RobotWorkstation
{   
    public partial class MainForm : Form
    {
        //UI
        private LoginForm m_LoginForm = null;
        private RunForm m_RunForm = null;
        private ManualDebugForm m_ManualDebugForm = null;  //手动调试对话框
        private SystemSetingForm m_SystemSetingForm = null;
        private UserLimitsForm m_UserLimitsForm = null;

        //所需模块
        private RobotDevice m_Robot = null;  //机械臂            
        private VisionCamera m_Camera = null;  //视觉相机     
        private RFID m_RFID = null;   //RFID      
        private QRCode m_QRCode = null; //二维码
        private MyTcpClient m_MyTcpClient = null;
        private MyTcpServer m_MyTcpServer = null;

        //线程
        private Thread m_MainThread = null;
        private Thread m_MeassageProcessThread = null;

        //防止闪屏
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED，将一个窗体的所有子窗口使用双缓冲按照从低到高方式绘制出来。
                return cp;
            }
        }

        public MainForm()
        {
            InitializeComponent();
            InitOtherForm();
            this.CenterToScreen();           
            Profile.LoadConfigFile();

            //检查各模块的状态
            InitTcp();
            InitWorkstatiionAndStart();

            //创建所有线程
            InitAndCreateAllThread();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            CustomColor.InitColor();
            InitWindowSize();
            InitCtrlColor();

           MultiLanguage.LoadLanguage(this, typeof(MainForm));
        }

        public void InitWindowSize()
        {
            //得到屏幕工作区域的参数，比如去除属性任务栏的高度
            int nScreenWidth = Screen.PrimaryScreen.WorkingArea.Width; 
            int nScreenHeight = Screen.PrimaryScreen.WorkingArea.Height;

            //调整主窗体控件
            this.MaximumSize = new Size(nScreenWidth, nScreenHeight);
            this.Width = nScreenWidth;
            this.Height = nScreenHeight;
        }

        public void InitCtrlColor()
        {
            CmdTreeView.BackColor = CustomColor.TreeViewColor;
        }

        //创建其他窗体的实例对象
        public void InitOtherForm()
        {
            m_LoginForm = new LoginForm();
            m_LoginForm.MdiParent = this;

            m_RunForm = new RunForm();
            m_RunForm.MdiParent = this;

            m_ManualDebugForm = new ManualDebugForm();
            m_ManualDebugForm.MdiParent = this;

            m_SystemSetingForm = new SystemSetingForm();
            m_SystemSetingForm.MdiParent = this;

            m_UserLimitsForm = new UserLimitsForm();
            m_UserLimitsForm.MdiParent = this;
        }

        private void CmdTreeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            switch (e.Node.Name)
            {
                case "Login":
                    {
                        if (m_RunForm != null)
                            m_RunForm.Hide();

                        if (m_ManualDebugForm != null)
                            m_ManualDebugForm.HideFormAndSaveConfigFile();

                        if (m_SystemSetingForm != null)
                            m_SystemSetingForm.HideFormAndSaveConfigFile();

                        if (m_UserLimitsForm != null)
                            m_UserLimitsForm.Hide();

                        if (m_LoginForm != null)
                        {
                            SplitContainerFromMain.Panel1.Controls.Add(m_LoginForm);
                            m_LoginForm.Dock = DockStyle.Fill;
                            m_LoginForm.Show();
                        }
                    }
                    break;
                case "Run":
                    {
                        if (m_LoginForm != null)
                            m_LoginForm.Hide();

                        if (m_ManualDebugForm != null)
                            m_ManualDebugForm.HideFormAndSaveConfigFile();

                        if (m_SystemSetingForm != null)
                            m_SystemSetingForm.HideFormAndSaveConfigFile();

                        if (m_UserLimitsForm != null)
                            m_UserLimitsForm.Hide();

                        if (m_RunForm != null)
                        {
                            SplitContainerFromMain.Panel1.Controls.Add(m_RunForm);
                            m_RunForm.Dock = DockStyle.Fill;
                            m_RunForm.Show();
                        }
                    }
                    break;
                case "Manual":
                    {
                        if (m_LoginForm != null)
                            m_LoginForm.Hide();

                        if (m_RunForm != null)
                            m_RunForm.Hide();

                        if (m_SystemSetingForm != null)
                            m_SystemSetingForm.HideFormAndSaveConfigFile();

                        if (m_UserLimitsForm != null)
                            m_UserLimitsForm.Hide();

                        if (m_ManualDebugForm != null)
                        {
                            SplitContainerFromMain.Panel1.Controls.Add(m_ManualDebugForm);
                            m_ManualDebugForm.Dock = DockStyle.Fill;
                            m_ManualDebugForm.Show();
                        }
                    }
                    break;
                case "SystemSeting":
                    {
                        if (m_LoginForm != null)
                            m_LoginForm.Hide();

                        if (m_RunForm != null)
                            m_RunForm.Hide();

                        if (m_ManualDebugForm != null)
                            m_ManualDebugForm.HideFormAndSaveConfigFile();

                        if (m_UserLimitsForm != null)
                            m_UserLimitsForm.Hide();

                        if (m_SystemSetingForm != null)
                        {
                            SplitContainerFromMain.Panel1.Controls.Add(m_SystemSetingForm);
                            m_SystemSetingForm.Dock = DockStyle.Fill;
                            m_SystemSetingForm.Show();
                        }
                    }
                    break;
                case "UserLimits":
                    {
                        if (m_LoginForm != null)
                            m_LoginForm.Hide();

                        if (m_RunForm != null)
                            m_RunForm.Hide();

                        if (m_ManualDebugForm != null)
                            m_ManualDebugForm.HideFormAndSaveConfigFile();

                        if (m_SystemSetingForm != null)
                            m_SystemSetingForm.HideFormAndSaveConfigFile();

                        if (m_UserLimitsForm != null)
                        {
                            SplitContainerFromMain.Panel1.Controls.Add(m_UserLimitsForm);
                            m_UserLimitsForm.Dock = DockStyle.Fill;
                            m_UserLimitsForm.Show();
                        }
                    }
                    break;
                case "Exit":
                    {
                        VisualSortingStation.ShouldExit = true;
                        if (m_MyTcpServer != null)
                            m_MyTcpServer.CloseServer();

                        CloseForm();
                    }
                    break;
                default:
                    break;
            }
        }

        private void FormMain_MaximumSizeChanged(object sender, EventArgs e)
        {
            InitWindowSize();
        }

        public void CloseForm()
        {
            if (m_ManualDebugForm != null)
                m_ManualDebugForm.CloseRobot();

            Profile.SaveConfigFile();
            this.Close();
        }

        public void InitWorkstatiionAndStart()
        {
            SysAlarm sysAlarm = SysAlarm.GetInstance();
            m_Robot = RobotDevice.GetInstance();  //机械臂
            //bool Re = m_Robot.InitRobot();
            //if (!Re)
            //{
            //    DataStruct.SysStat.Robot = 1;
            //    sysAlarm.SetAlarm(SysAlarm.Type.Robot, true);
            //    MessageBox.Show("机械臂初始化错误！");
            //}

            //m_Camera = VisionCamera.GetInstance();  //视觉相机  
            //Re = m_Camera.InitCamera();
            //if (!Re)
            //{
            //    DataStruct.SysStat.Camera = 1;
            //    sysAlarm.SetAlarm(SysAlarm.Type.Camera, true);
            //}

            //m_RFID = RFID.GetInstance();   //RFID    
            //Re = m_RFID.InitRFID();
            //if (!Re)
            //{
            //    DataStruct.SysStat.RFID = 1;
            //    sysAlarm.SetAlarm(SysAlarm.Type.RFID, true);
            //}

            //m_QRCode = QRCode.GetInstance(); //二维码
            //Re = m_QRCode.QRCodeInit();
            //if (!Re)
            //{
            //    DataStruct.SysStat.QRCode = 1;
            //    sysAlarm.SetAlarm(SysAlarm.Type.QRCode, true);
            //}
        }

        public void InitTcp()
        {
            SysAlarm sysAlarm = SysAlarm.GetInstance();
            m_MyTcpClient = MyTcpClient.GetInstance();
            if (m_MyTcpClient != null)
            {
                m_MyTcpClient.InitClient();

                //从配置中获取单片机控制板的IP和端口号
                m_MyTcpClient.CreateConnect(IPAddress.Parse("192.168.81.114"), 8080);
            }

            m_MyTcpServer = MyTcpServer.GetInstance();
            if (m_MyTcpServer != null)
            {
                m_MyTcpServer.CreatServer();
            }
        }

        public void InitAndCreateAllThread()
        {
            //创建主线程
            m_MainThread = new Thread(new ThreadStart(VisualSortingStation.MainThreadFunc));
            m_MainThread.IsBackground = true;
            m_MainThread.Start();

            //创建消息处理线程
            m_MeassageProcessThread = new Thread(new ThreadStart(VisualSortingStation.MessageProcessThreadFunc));
            m_MeassageProcessThread.IsBackground = true;
            m_MeassageProcessThread.Start();
        }
    }
}
