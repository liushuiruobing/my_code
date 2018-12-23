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
          
		  	//PicRobot.Image = m_AutoRobot.m_IsConnected ? bmpGreen : bmpRed;
     //       PicCamera.Image = m_Camera.m_CameraConnect ? bmpGreen : bmpRed;
     //       PicQRCodeScanner.Image = m_QRCode.QRCodeConnect ? bmpGreen : bmpRed;
     //       PicRfid.Image = m_RFID.RfidConnect ? bmpGreen : bmpRed;

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

    }
}
