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
        private ArmControler m_ArmControler = null;
        private byte[] m_SendMeas = new byte[Message.MessageLength];
        private RobotDevice m_Robot = RobotDevice.GetInstance();
        public static int m_GrapAndPutCount = -1;  //用于记录自动抓取和放置的个数
        public static int m_GrapAndPutTotal = 0;   //用于记录自动抓取和放置的总数
        public RunForm()
        {
            InitializeComponent();

            m_ArmControler = ArmControler.GetInstance();

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
            VisualSortingStation.ProcessKey(Key.Key_Run);
        }

        private void CButtonPause_Click(object sender, EventArgs e)
        {
            VisualSortingStation.ProcessKey(Key.Key_Pause);
        }

        private void CButtonStop_Click(object sender, EventArgs e)
        {
            VisualSortingStation.ProcessKey(Key.Key_Stop);
        }

        private void CButtonReset_Click(object sender, EventArgs e)
        {
            VisualSortingStation.ProcessKey(Key.Key_Reset);
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

            PicLedReady.Image = DataStruct.SysStat.StationReady ? Properties.Resources.LightBlue : Properties.Resources.DarkBlue;
            PicLedRun.Image = DataStruct.SysStat.StationRun ? Properties.Resources.LightGreen : Properties.Resources.DarkGreen;
            PicLedAlarm.Image = DataStruct.SysStat.StationPause ? Properties.Resources.LightYellow : Properties.Resources.DarkYellow;
            PicLedStop.Image = DataStruct.SysStat.StationStop ? Properties.Resources.LightRed : Properties.Resources.DarkRed;

            //设置报警灯的状态
            if (DataStruct.SysStat.StationRun)
                VisualSortingStation.SetSysAlarmTowerLed(AlarmLed.AlarmLed_Green);
            else if (DataStruct.SysStat.StationPause && !DataStruct.SysStat.StationStop)
                VisualSortingStation.SetSysAlarmTowerLed(AlarmLed.AlarmLed_Oriange);
            else if (!DataStruct.SysStat.StationPause && DataStruct.SysStat.StationStop)
                VisualSortingStation.SetSysAlarmTowerLed(AlarmLed.AlarmLed_Red);
            else if (DataStruct.SysStat.StationPause && DataStruct.SysStat.StationStop)
                VisualSortingStation.SetSysAlarmTowerLed(AlarmLed.AlarmLed_OriangeAndRed);

            //运行状态更新
            Bitmap bmpGreen = Properties.Resources.SmallGreen;
            Bitmap bmpRed = Properties.Resources.SmallRed;

            PicRobot.Image = DataStruct.SysStat.RobotOk ? bmpGreen : bmpRed;
            PicCamera.Image = DataStruct.SysStat.CameraOk? bmpGreen : bmpRed;
            PicQRCodeScanner.Image = DataStruct.SysStat.QRCodeOk ? bmpGreen : bmpRed;
            PicRfid.Image = DataStruct.SysStat.RfidOk ? bmpGreen : bmpRed;
            PicArm.Image = DataStruct.SysStat.ArmControlerOk ? bmpGreen : bmpRed;
            PicOverturnSalver.Image = DataStruct.SysStat.OverturnSalverOk ? bmpGreen : bmpRed;

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

            //刷新模拟物料盘的状态
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
