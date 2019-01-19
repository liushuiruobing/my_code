using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RobotWorkstation
{
    public partial class RunForm : Form
    {
        private SysAlarm m_SysAlarm = SysAlarm.GetInstance();
        private bool[] m_SysAlarmState = new bool[(int)SysAlarm.Type.Max];  //报警状态备份
        private MyTcpClient m_MyTcpClientArm = null;
        private IO m_IO = null;
        private byte[] SendMeas = new byte[Message.MessageLength];
        private RobotDevice m_Robot = RobotDevice.GetInstance();
        public static int m_GrapAndPutCount = -1;  //用于记录自动抓取和放置的个数
        public static int m_GrapAndPutTotal = 0;   //用于记录自动抓取和放置的总数
        public RunForm()
        {
            InitializeComponent();
            m_MyTcpClientArm = MainForm.GetMyTcpClientArm();
            m_IO = IO.GetInstance();

            for (int i = 0; i < (int)SysAlarm.Type.Max; i++)
            {
                m_SysAlarmState[i] = false;
            }

            TimerCheckAllStatus.Start();

        }

        private void RunForm_Load(object sender, EventArgs e)
        {
            MultiLanguage.LoadLanguage(this, typeof(RunForm));

            OriginalSalver.InitEveryGridColor(Salver.GridFullColor);
            AfterSortingSalver.InitEveryGridColor(Salver.GridEmptyColor);
        }

        private void CButtonStart_Click(object sender, EventArgs e)
        {
            
            if ((DataStruct.SysStat.Ready) && (!DataStruct.SysStat.Stop))
            {
                DataStruct.SysStat.Run = true;
                DataStruct.SysStat.Pause = false;
            }
        }

        private void CButtonPause_Click(object sender, EventArgs e)
        {
            if (!DataStruct.SysStat.Stop)
            {
                DataStruct.SysStat.Pause = true;
                DataStruct.SysStat.Run = false;
            }
        }

        private void CButtonStop_Click(object sender, EventArgs e)
        {
            DataStruct.SysStat.Ready = false;
            DataStruct.SysStat.Run = false;
            DataStruct.SysStat.Pause = false;
            DataStruct.SysStat.Stop = true;
        }

        private void CButtonReset_Click(object sender, EventArgs e)
        {
            //VisualSortingStation.Init_Equipment();
            int Rtn = VisualSortingStation.CheckSysAlarm();
            if (Rtn == 0)
            {
                DataStruct.SysStat.Ready = true;
                DataStruct.SysStat.Run = false;
                DataStruct.SysStat.Stop = false;
                DataStruct.SysStat.Pause = false;
            }
            else if (Rtn == 1)
            {
                DataStruct.SysStat.Pause = true;
                DataStruct.SysStat.Ready = false;
                DataStruct.SysStat.Run = false;
                DataStruct.SysStat.Stop = false;
            }
            else if (Rtn == 2)
            {
                DataStruct.SysStat.Stop = true;
                DataStruct.SysStat.Ready = false;
                DataStruct.SysStat.Run = false;
                DataStruct.SysStat.Pause = false;
            }
            else
            {
                DataStruct.SysStat.Pause = true;
                DataStruct.SysStat.Stop = false;
                DataStruct.SysStat.Ready = false;
                DataStruct.SysStat.Run = false;
            }
        }

        private void CButtonClearSysAlarm_Click(object sender, EventArgs e)
        {
            DgvSysAlarm.Rows.Clear();
            m_SysAlarm.ClearAll();
        }

        //监控所有状态
        private void TimerCheckAllStatus_Tick(object sender, EventArgs e)
        {
            //运行指示灯
            if (DataStruct.SysStat.Ready)
                PicLedReady.Image = Properties.Resources.LightBlue;
            else
                PicLedReady.Image = Properties.Resources.DarkBlue;

            if (DataStruct.SysStat.Run)
                PicLedRun.Image = Properties.Resources.LightGreen;
            else
                PicLedRun.Image = Properties.Resources.DarkGreen;

            if (DataStruct.SysStat.Pause)
                PicLedAlarm.Image = Properties.Resources.LightYellow;
            else
                PicLedAlarm.Image = Properties.Resources.DarkYellow;

            if (DataStruct.SysStat.Stop)
                PicLedStop.Image = Properties.Resources.LightRed;
            else
                PicLedStop.Image = Properties.Resources.DarkRed;

            //运行状态更新
            Bitmap bmpGreen = Properties.Resources.SmallGreen;
            Bitmap bmpRed = Properties.Resources.SmallRed;
            if (m_Robot != null && m_Robot.IsConnected())
                m_Robot.GetState();

            if (DataStruct.SysStat.Robot == 0)
                PicRobot.Image = bmpGreen;
            else
                PicRobot.Image = bmpRed;

            if (DataStruct.SysStat.Camera == 0)
                PicCamera.Image = bmpGreen;
            else
                PicCamera.Image = bmpRed;

            if (DataStruct.SysStat.QRCode == 0)
                PicQRCodeScanner.Image = bmpGreen;
            else
                PicQRCodeScanner.Image = bmpRed;

            if (DataStruct.SysStat.RFID == 0)
                PicRfid.Image = bmpGreen;
            else
                PicRfid.Image = bmpRed;

            //设置报警灯的状态
            if (DataStruct.SysStat.Run)
                VisualSortingStation.SetSysAlarmLed(0);
            else if (DataStruct.SysStat.Pause && !DataStruct.SysStat.Stop)
                VisualSortingStation.SetSysAlarmLed(1);
            else if (!DataStruct.SysStat.Pause && DataStruct.SysStat.Stop)
                VisualSortingStation.SetSysAlarmLed(2);
            else if (DataStruct.SysStat.Pause && DataStruct.SysStat.Stop)
                VisualSortingStation.SetSysAlarmLed(3);

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

            //轮询单片机的状态
            m_IO.ReadControlBoardIo((byte)Message.MessageCodeARM.GetInIo, ref SendMeas);

            //刷新盘的状态
            if (DataStruct.SysStat.GrapAndPutOneSuccessed)
            {
                DataStruct.SysStat.GrapAndPutOneSuccessed = false;
                SetOriginalSalverGridColor(m_GrapAndPutCount, Salver.GridEmptyColor);
                SetAfterSortingSalverGridColor(m_GrapAndPutCount, Salver.GridFullColor);

                if (m_GrapAndPutCount == VisualSortingStation.m_OnePanelDevicesMax)
                {
                    lock (this)
                    {
                        m_GrapAndPutCount = 0;
                    }
                    
                    OriginalSalver.InitEveryGridColor(Salver.GridFullColor);
                    AfterSortingSalver.InitEveryGridColor(Salver.GridEmptyColor);
                }
            }

            CLabelCurDevices.Text = (m_GrapAndPutCount + 1).ToString();
            CLabelTotalDeveices.Text = m_GrapAndPutTotal.ToString();
            CLabelTotalTrays.Text = (m_GrapAndPutTotal / VisualSortingStation.m_OnePanelDevicesMax).ToString();
        }

        //DeviceIndex 从0开始
        public void SetOriginalSalverGridColor(int DeviceIndex, Color color)
        {
            int Row = DeviceIndex % OriginalSalver.SalverRows;
            int Col = (OriginalSalver.SalverCols - 1) -  DeviceIndex / OriginalSalver.SalverRows;
            OriginalSalver.SetSelectedGridColor(Row, Col, color);
        }

        //DeviceIndex 从0开始
        public void SetAfterSortingSalverGridColor(int DeviceIndex, Color color)
        {
            int Row = DeviceIndex % OriginalSalver.SalverRows;
            int Col = DeviceIndex / OriginalSalver.SalverRows;
            AfterSortingSalver.SetSelectedGridColor(Row, Col, color);
        }
    }
}
