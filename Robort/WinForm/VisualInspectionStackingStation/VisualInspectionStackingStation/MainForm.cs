//#define WithVisual

using System;
using System.Drawing;
using System.Net;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

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
        private Process m_VisualProcess = new Process();       
        private RFID m_RFID = null;   //RFID      
        public static ArmControler m_ArmControler = ArmControler.GetInstance();
        private static MyTcpClient m_MyTcpClientArm = null;
        private static MyTcpClient m_MyTcpClientCamera = null;
        private MyTcpServer m_MyTcpServer = null;
        private SysAlarm m_SysAlarm = SysAlarm.GetInstance();


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

            //初始化
            InitWorkStation();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            CustomColor.InitColor();
            InitWindowSize();
            InitCtrlColor();

            MultiLanguage.LoadLanguage(this, typeof(MainForm));
        }

        public static MyTcpClient GetMyTcpClientCamera()
        {
            return m_MyTcpClientCamera;
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
                            m_ManualDebugForm.InitUIControlEnableState();
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
                        WorkStation.ShouldExit = true;
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

#if WithVisual

            if (m_VisualProcess != null)
                m_VisualProcess.Dispose();

#endif
            Profile.SaveConfigFile();
            this.Close();

            
        }

        public void InitWorkStation()
        {
            DataStruct.InitDataStruct();
            Profile.LoadConfigFile();

            InitAndRunVisualService();
            //InitTcp();
            //InitWorkstatiionAndStart();
            InitAndCreateAllThread();  //创建所有线程
        }

        //启动视觉服务程序
        public void InitAndRunVisualService()
        {
#if WithVisual
            const string VisualService = "VisualService.exe";
            string VisualServicePath = AppDomain.CurrentDomain.BaseDirectory + "VisualService\\" + VisualService;

            if (File.Exists(VisualServicePath))
            {
                m_VisualProcess.StartInfo.FileName = VisualService;
                m_VisualProcess.StartInfo.WorkingDirectory = AppDomain.CurrentDomain.BaseDirectory + "VisualService";
                m_VisualProcess.StartInfo.CreateNoWindow = true;
                m_VisualProcess.Start();
            }
            else
            {
                Global.MessageBoxShow(Global.StrStartVisualServiceError);
            }
#endif

        }

        public void InitTcp()
        {
            //和Camera通信
            m_MyTcpClientCamera = new MyTcpClient();
            if (m_MyTcpClientCamera != null)
            {
                IPAddress CameraIp = IPAddress.Parse(Profile.m_Config.CameraIp);
                int CameraPort = Profile.m_Config.CameraPort;
                m_MyTcpClientCamera.CreateConnect(CameraIp, CameraPort);
                if (!m_MyTcpClientCamera.IsConnected)
                {
                    DataStruct.SysStat.CameraOk = false;
                    m_SysAlarm.SetAlarm(SysAlarm.Type.Camera, true);
                }
                else
                {
                    DataStruct.SysStat.CameraOk = true;
                    m_SysAlarm.SetAlarm(SysAlarm.Type.Camera, false);
                }
            }

            //和单片机通信
            m_ArmControler.Open();
            m_MyTcpClientArm = m_ArmControler.m_MyTcpClientArm[(int)Board.Controler];
            if (!m_MyTcpClientArm.IsConnected)
            {
                DataStruct.SysStat.ArmControlerOk = false;
                m_SysAlarm.SetAlarm(SysAlarm.Type.ARM, true);
            }
            else
            {
                DataStruct.SysStat.ArmControlerOk = true;
                m_SysAlarm.SetAlarm(SysAlarm.Type.ARM, false);

                //设置电机默认参数
                InitArmControlerAxisPamera();
            }

            //创建Tcp Server
            m_MyTcpServer = MyTcpServer.GetInstance();
            if (m_MyTcpServer != null)
            {
                IPAddress ServerIp = IPAddress.Parse(Profile.m_Config.VisualStationServerIp);
                int ServerPort = Profile.m_Config.VisualStationServerPort;
                bool Re = m_MyTcpServer.CreatServer(ServerIp, ServerPort);
                if (!Re)
                {
                    DataStruct.SysStat.ServerOk = false;
                    m_SysAlarm.SetAlarm(SysAlarm.Type.Server, true);
                }
                else
                {
                    DataStruct.SysStat.ServerOk = true;
                    m_SysAlarm.SetAlarm(SysAlarm.Type.Server, false);
                }
            }
        }

        public void InitWorkstatiionAndStart()
        {
            //RFID
            m_RFID = RFID.GetInstance();
            bool Re = m_RFID.Connect(Profile.m_Config.RfidIp);
            if (!Re)
            {
                DataStruct.SysStat.RfidOk = false;
                m_SysAlarm.SetAlarm(SysAlarm.Type.RFID, true);
            }
            else
            {
                m_RFID.m_CurCh = Profile.m_Config.RfidCh;
                m_RFID.Init(m_RFID.m_CurCh);
                m_RFID.Enable(m_RFID.m_CurCh);

                DataStruct.SysStat.RfidOk = true;
                m_SysAlarm.SetAlarm(SysAlarm.Type.RFID, false);
            }
        }

        public void InitAndCreateAllThread()
        {
            WorkStation.CreateAllThread();
        }

        public void InitArmControlerAxisPamera()
        {
            ArmControler.m_ConveyorAxisMaxStep = Profile.m_Config.ConveyorAxisMaxStep;
            ArmControler.m_OverturnAxisMaxStep = Profile.m_Config.OverturnAxisMaxStep;

            int StartSpeed = Profile.m_Config.AxisStartSpeed;
            int AddSpeed = Profile.m_Config.AxisAddSpeed;
            int DecSpeed = Profile.m_Config.AxisDecSpeed;

            for (int i = 0; i < (int)Axis.Max; i++)
            {
                Axis axis = (Axis)i;
                switch (axis)
                {
                    case Axis.Conveyor:
                        {
                            int RunSpeed = Profile.m_Config.ConveyorAxisRunSpeed;
                            m_ArmControler.SetSpeedParam(Axis.Conveyor, StartSpeed, RunSpeed, AddSpeed, DecSpeed, true);
                        }
                        break;
                    case Axis.OverTurn:
                        {
                            int RunSpeed = Profile.m_Config.OverturnAxisRunSpeed;
                            m_ArmControler.SetSpeedParam(Axis.OverTurn, StartSpeed, RunSpeed, AddSpeed, DecSpeed, true);
                        }
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
