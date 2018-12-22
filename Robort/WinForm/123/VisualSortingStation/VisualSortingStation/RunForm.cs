using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RobotWorkstation
{
    public partial class RunForm : Form
    {
        public RobotDevice m_AutoRobot = RobotDevice.GetInstance();  //机械臂            
        public VisionCamera m_Camera = VisionCamera.GetInstance();  //视觉相机     
        public RFID m_RFID = RFID.GetInstance();   //RFID      
        public QRCode m_QRCode = QRCode.GetInstance(); //二维码

        private SysAlarm m_SysAlarm = SysAlarm.GetInstance();
        private bool[] m_SysAlarmState = new bool[(int)SysAlarm.Type.Max];  //报警状态备份

        public RunForm()
        {
            InitializeComponent();

            for (int i = 0; i < (int)SysAlarm.Type.Max; i++)
            {
                m_SysAlarmState[i] = false;
            }

            TimerCheckAllStatus.Start();
        }

        private void RunForm_Load(object sender, EventArgs e)
        {
            MultiLanguage.LoadLanguage(this, typeof(RunForm));

            OriginalSalver.InitEveryGridColor(Color.Green);
        }

        public void InitRobot()
        {
            bool openRet = m_AutoRobot.Open(Profile.m_Config.RobotIp);
            if (openRet)
            {
                //读取xml配置文件然后设置机械臂
                //m_ManualRobot.SetSpeed(40);
                //m_ManualRobot.SetJointDistance(1000);
                //m_ManualRobot.SetCartesianDistance(1000);
            }
            else
            {
                Debug.WriteLine("The Robot Open Failed!");
            }
        }

        public void InitCamera()
        {

        }

        //RFID
        public void InitRfid()
        {
            //m_RFID.m_Ip = 从配置文件读取
            bool bCon = m_RFID.Connect(m_RFID.m_Ip);
            if (bCon)
            {
                ushort CurCh = 0;
                m_RFID.Enable(CurCh);
                m_RFID.Init(CurCh);
            }
        }

        //二维码读取器
        public void InitQRCode()
        {
            //从配置文件中读取
            string Port = "COM4";
            string BandRate = "115200";
            string DataBits = "8";
            string StopBits = "1";
            string Parity = "无";

            m_QRCode.QRCodeCommunParamInit(Port, BandRate, DataBits, StopBits, Parity);
            m_QRCode.QRCodeInit();

            if (m_QRCode.QRCodeConnect)
            {
                m_QRCode.QRCodeRecvDataEvent += new EventHandler(QRCodeRecvData);
            }
        }

        private void CButtonStart_Click(object sender, EventArgs e)
        {
            OriginalSalver.SetSelectedGridColor(1, Color.Green);
        }

        private void CButtonPause_Click(object sender, EventArgs e)
        {
            OriginalSalver.SetSelectedGridColor(1, Color.Red);
        }

        private void CButtonStop_Click(object sender, EventArgs e)
        {

        }

        private void CButtonReset_Click(object sender, EventArgs e)
        {

        }

        private void CButtonAutoRun_Click(object sender, EventArgs e)
        {

        }

        private void CButtonClearSysAlarm_Click(object sender, EventArgs e)
        {
            DgvSysAlarm.Rows.Clear();
            m_SysAlarm.ClearAll();
        }

        //监控所有状态
        private void TimerCheckAllStatus_Tick(object sender, EventArgs e)
        {
            Bitmap bmpGreen = Properties.Resources.SmallGreen;
            Bitmap bmpRed = Properties.Resources.SmallRed;
          
		  	PicRobot.Image = m_AutoRobot.m_IsConnected ? bmpGreen : bmpRed;
            PicCamera.Image = m_Camera.m_CameraConnect ? bmpGreen : bmpRed;
            PicQRCodeScanner.Image = m_QRCode.QRCodeConnect ? bmpGreen : bmpRed;
            PicRfid.Image = m_RFID.RfidConnect ? bmpGreen : bmpRed;

            //添加报警信息
            for (int i = 0; i < (int)SysAlarm.Type.Max; i++)
            {
                SysAlarm.StructAlarm data = m_SysAlarm.GetAlarm((SysAlarm.Type)i);
                if (data.IsAlarm)
                {
                    if (!m_SysAlarmState[i])
                    {
                        DgvSysAlarm.Rows.Add(data.ID.ToString(), data.Level.ToString(), data.Informat, data.Solution);
                    }
                }

                m_SysAlarmState[i] = data.IsAlarm;
            }

            //蜂鸣器报警
        }

        private void QRCodeRecvData(object sender, EventArgs e)
        {
            if (e is QRCodeEventArgers)
            {
                QRCodeEventArgers Temp = e as QRCodeEventArgers;
                //m_SyncContext.Post(SetQRCodeTextSafePost, Temp.QRCodeRecv);
                Debug.WriteLine(Temp.QRCodeRecv);
            }
        }

    }
}
