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

        private void CButtonStart_Click(object sender, EventArgs e)
        {
            //OriginalSalver.SetSelectedGridColor(1, Color.Green);
            //if ((DataStruct.SysStat.Ready == 1) && (DataStruct.SysStat.Stop == 0))
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

            //设置报警灯的状态
            if (DataStruct.SysStat.Run)
                VisualSortingStation.SetSysAlarm(0);
            else if (DataStruct.SysStat.Pause && !DataStruct.SysStat.Stop)
                VisualSortingStation.SetSysAlarm(1);
            else if (!DataStruct.SysStat.Pause && DataStruct.SysStat.Stop)
                VisualSortingStation.SetSysAlarm(2);
            else if (DataStruct.SysStat.Pause && DataStruct.SysStat.Stop)
                VisualSortingStation.SetSysAlarm(3);
        }

    }
}
