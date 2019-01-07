using Advantech.Motion;
using RABD.DROE.SystemDefine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RobotWorkstation
{
    public partial class ManualDebugForm : Form
    {
        //机械臂
        private RobotDevice m_ManualRobot = RobotDevice.GetInstance();
        private const int RobotGlobalPointsBefore = 30;  //先加载前30个点，其余的在定时器中加载，来解决刷新缓慢的问题
        private int m_ManualRobotGlobalPointIndex = 0;  //选中的全局点位索引

        private MotionControl m_MotionControl = MotionControl.GetInstance(); //三轴机械手
        private VisionCamera m_Camera = VisionCamera.GetInstance();
        private RFID m_RFID = RFID.GetInstance();
        private QRCode m_QRCode = QRCode.GetInstance();
        private IO m_IO = IO.GetInstance();

        SynchronizationContext m_SyncContext = null;

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

        public ManualDebugForm()
        {
            InitializeComponent();

            InitRobot();
            InitCamera();  //视觉相机
            InitRfid();
            InitQRCode();
        }

        private void ManualDebug_Load(object sender, EventArgs e)
        {
            tabControlManualDebug.Width = this.Width - tabControlManualDebug.Location.X;
            tabControlManualDebug.Height = this.Height - tabControlManualDebug.Location.Y;

            radioButtonRobotDeviceJog.Checked = true;  //默认是Jog模式
            CTextBoxRobotMoveSpeed.Text = Profile.m_Config.RobotMoveSpeed.ToString();
            CTextBoxJogDistance.Text = Profile.m_Config.RobotMoveDistance.ToString();
            CTextBoxJogDistanceUm.Text = Profile.m_Config.RobotMoveDistanceUm.ToString();
            m_ManualRobot.SetRobotPamram(int.Parse(CTextBoxRobotMoveSpeed.Text), int.Parse(CTextBoxJogDistance.Text), int.Parse(CTextBoxJogDistanceUm.Text));

            //加载机械臂全局点位
            DGV_RobotGlobalPoint.Rows.Clear();
            LoadRobotGlobalPoints(0, RobotGlobalPointsBefore);
            TimerInitRobotGlobalPointDGV.Start();
        }

        //加载机械臂的全局点位信息
        public void LoadRobotGlobalPoints(int StartIndex,  int EndIndex)
        {
            for (int i = StartIndex; i < EndIndex; i++)
            {
                DGV_RobotGlobalPoint.Rows.Add("GL", (float)0 / 1000, (float)0 / 1000, (float)0 / 1000, (float)0 / 1000, 0, 0, 0);
                DGV_RobotGlobalPoint.Rows[i].HeaderCell.Value = String.Format("{0}", i + 1);
            }
        }

        public void ReadRobotGlobalPoints(int StartIndex, int EndIndex)
        {
            if (m_ManualRobot.m_PointList != null && DGV_RobotGlobalPoint.RowCount >= (EndIndex - StartIndex))
            {
                for (int i = StartIndex; i < EndIndex; i++)
                {
                    DGV_RobotGlobalPoint[0, i].Value = m_ManualRobot.m_PointList[i].Name;
                    DGV_RobotGlobalPoint[1, i].Value = m_ManualRobot.m_PointList[i][eAxisName.X] / 1000;
                    DGV_RobotGlobalPoint[2, i].Value = m_ManualRobot.m_PointList[i][eAxisName.Y] / 1000;
                    DGV_RobotGlobalPoint[3, i].Value = m_ManualRobot.m_PointList[i][eAxisName.Z] / 1000;
                    DGV_RobotGlobalPoint[4, i].Value = m_ManualRobot.m_PointList[i][eAxisName.RZ] / 1000;
                    DGV_RobotGlobalPoint[5, i].Value = m_ManualRobot.m_PointList[i].Info.Hand;
                    DGV_RobotGlobalPoint[6, i].Value = m_ManualRobot.m_PointList[i].Info.UserFrame;
                    DGV_RobotGlobalPoint[7, i].Value = m_ManualRobot.m_PointList[i].Info.ToolFrame;

                    DGV_RobotGlobalPoint.Rows[i].HeaderCell.Value = String.Format("{0}", i + 1);
                }
            }
        }

        private void timer_InitRobotGlobalPointDGV_Tick(object sender, EventArgs e)
        {
            TimerInitRobotGlobalPointDGV.Stop();
            LoadRobotGlobalPoints(RobotGlobalPointsBefore, RobotBase.MAX_GLOBAL_POINTS);    
        }

        private void CBttonServoOn_Click(object sender, EventArgs e)
        {
            if (m_ManualRobot.IsConnected())
            {
                m_ManualRobot.ServoOn();
                Thread.Sleep(100);  //必须延时, 否则反应很慢
                RefreshRobotServoPic(m_ManualRobot, pictureBoxServo);
            }
        }

        private void CButtonServoOff_Click(object sender, EventArgs e)
        {
            if (m_ManualRobot.IsConnected())
            {
                m_ManualRobot.ServoOff();
                Thread.Sleep(100);  
                RefreshRobotServoPic(m_ManualRobot, pictureBoxServo);
            }
        }

        void RefreshRobotServoPic(RobotBase robot, PictureBox pic)
        {
            Bitmap bmpGreen = Properties.Resources.SmallGreen;
            Bitmap bmpDarkGreen = Properties.Resources.SmallDarkGreen;
            pic.Image = robot.ServoState() ? bmpGreen : bmpDarkGreen;
        }

        private void CButtonReset_Click(object sender, EventArgs e)
        {
            if (m_ManualRobot.IsConnected())
            {
                m_ManualRobot.ResetAlarm();
            }
        }

        private void CButtonRobotExecRun_Click(object sender, EventArgs e)
        {
            if (m_ManualRobot.IsConnected())
            {
                m_ManualRobot.RunProgram();
            }
        }

        private void CButtonRobotExecPause_Click(object sender, EventArgs e)
        {
            if (m_ManualRobot.IsConnected())
            {
                m_ManualRobot.PauseProgram();
            }
        }

        private void CButtonRobotExecStop_Click(object sender, EventArgs e)
        {
            if (m_ManualRobot.IsConnected())
            {
                m_ManualRobot.StopProgram();
            }
        }

        //显示机器人脚本运行状态
        private void DisplayRobotState(string state, PictureBox pic)
        {
            Bitmap bmpGreen = Properties.Resources.SmallGreen;
            Bitmap bmpRed = Properties.Resources.SmallRed;
            Bitmap bmpYellow = Properties.Resources.SmallYellow;

            if (state == "暂停")
                pic.Image = bmpYellow;
            else if (state == "运行")
                pic.Image = bmpGreen;
            else
                pic.Image = bmpRed;
        }

        private void radioButtonRobotDeviceJog_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonRobotDeviceJog.Checked)
            {
                m_ManualRobot.m_IsStep = true;
            }
        }

        private void radioButtonRobotDeviceContinuous_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonRobotDeviceContinuous.Checked)
            {
                m_ManualRobot.m_IsStep = false;
            }
        }

        private void CTextBoxRobotMoveSpeed_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int speed = Convert.ToInt32(CTextBoxRobotMoveSpeed.Text);
                if (speed < RobotBase.MIN_SPEED)
                {
                    speed = RobotBase.MIN_SPEED;
                    CTextBoxRobotMoveSpeed.Text = speed.ToString();
                }
                else if (speed > RobotBase.MAX_SPEED)
                {
                    speed = RobotBase.MAX_SPEED;
                    CTextBoxRobotMoveSpeed.Text = speed.ToString();
                }
                m_ManualRobot.SetSpeed(speed);
                Profile.m_Config.RobotMoveSpeed = speed;
            }
            catch 
            {
                return;
            }
        }

        private void CTextBoxJogDistance_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int distance = Convert.ToInt32(CTextBoxJogDistance.Text);
                m_ManualRobot.SetJointDistance(distance);

                Profile.m_Config.RobotMoveDistance = distance;
            }
            catch
            {
                return;
            }         
        }

        private void CTextBoxJogDistanceUm_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int um = Convert.ToInt32(CTextBoxJogDistanceUm.Text);
                m_ManualRobot.SetCartesianDistance(um);
                Profile.m_Config.RobotMoveDistanceUm = um;
            }
            catch
            {
                return;
            }
        }

        private void CButtonRobotDistanceJ1Add_MouseDown(object sender, MouseEventArgs e)
        {
            m_ManualRobot.Move(eDirection.J1P, m_ManualRobot.m_IsStep);
        }

        private void CButtonRobotDistanceJ1Add_MouseUp(object sender, MouseEventArgs e)
        {
            m_ManualRobot.Stop(eAxisName.J1);
        }

        private void CButtonRobotDistanceJ1Sub_MouseDown(object sender, MouseEventArgs e)
        {
            m_ManualRobot.Move(eDirection.J1N, m_ManualRobot.m_IsStep);
        }

        private void CButtonRobotDistanceJ1Sub_MouseUp(object sender, MouseEventArgs e)
        {
            m_ManualRobot.Stop(eAxisName.J1);
        }

        private void CButtonRobotDistanceJ2Add_MouseDown(object sender, MouseEventArgs e)
        {
            m_ManualRobot.Move(eDirection.J2P, m_ManualRobot.m_IsStep);
        }

        private void CButtonRobotDistanceJ2Add_MouseUp(object sender, MouseEventArgs e)
        {
            m_ManualRobot.Stop(eAxisName.J2);
        }

        private void CButtonRobotDistanceJ2Sub_MouseDown(object sender, MouseEventArgs e)
        {
            m_ManualRobot.Move(eDirection.J2N, m_ManualRobot.m_IsStep);
        }

        private void CButtonRobotDistanceJ2Sub_MouseUp(object sender, MouseEventArgs e)
        {
            m_ManualRobot.Stop(eAxisName.J2);
        }

        private void CButtonRobotDistanceJ3Add_MouseDown(object sender, MouseEventArgs e)
        {
            m_ManualRobot.Move(eDirection.J3P, m_ManualRobot.m_IsStep);
        }

        private void CButtonRobotDistanceJ3Add_MouseUp(object sender, MouseEventArgs e)
        {
            m_ManualRobot.Stop(eAxisName.J3);
        }

        private void CButtonRobotDistanceJ3Sub_MouseDown(object sender, MouseEventArgs e)
        {
            m_ManualRobot.Move(eDirection.J3N, m_ManualRobot.m_IsStep);
        }

        private void CButtonRobotDistanceJ3Sub_MouseUp(object sender, MouseEventArgs e)
        {
            m_ManualRobot.Stop(eAxisName.J3);
        }

        private void CButtonRobotDistanceJ4Add_MouseDown(object sender, MouseEventArgs e)
        {
            m_ManualRobot.Move(eDirection.J4P, m_ManualRobot.m_IsStep);
        }

        private void CButtonRobotDistanceJ4Add_MouseUp(object sender, MouseEventArgs e)
        {
            m_ManualRobot.Stop(eAxisName.J4);
        }

        private void CButtonRobotDistanceJ4Sub_MouseDown(object sender, MouseEventArgs e)
        {
            m_ManualRobot.Move(eDirection.J4N, m_ManualRobot.m_IsStep);
        }

        private void CButtonRobotDistanceJ4Sub_MouseUp(object sender, MouseEventArgs e)
        {
            m_ManualRobot.Stop(eAxisName.J4);
        }

        private void CButtonRobotDistanceXAdd_MouseDown(object sender, MouseEventArgs e)
        {
            m_ManualRobot.Move(eDirection.XP, m_ManualRobot.m_IsStep);
        }

        private void CButtonRobotDistanceXAdd_MouseUp(object sender, MouseEventArgs e)
        {
            m_ManualRobot.Stop(eAxisName.X);
        }

        private void CButtonRobotDistanceXSub_MouseDown(object sender, MouseEventArgs e)
        {
            m_ManualRobot.Move(eDirection.XN, m_ManualRobot.m_IsStep);
        }

        private void CButtonRobotDistanceXSub_MouseUp(object sender, MouseEventArgs e)
        {
            m_ManualRobot.Stop(eAxisName.X);
        }

        private void CButtonRobotDistanceYAdd_MouseDown(object sender, MouseEventArgs e)
        {
            m_ManualRobot.Move(eDirection.YP, m_ManualRobot.m_IsStep);
        }

        private void CButtonRobotDistanceYAdd_MouseUp(object sender, MouseEventArgs e)
        {
            m_ManualRobot.Stop(eAxisName.Y);
        }

        private void CButtonRobotDistanceYSub_MouseDown(object sender, MouseEventArgs e)
        {
            m_ManualRobot.Move(eDirection.YN, m_ManualRobot.m_IsStep);
        }

        private void CButtonRobotDistanceYSub_MouseUp(object sender, MouseEventArgs e)
        {
            m_ManualRobot.Stop(eAxisName.Y);
        }

        private void CButtonRobotDistanceZAdd_MouseDown(object sender, MouseEventArgs e)
        {
            m_ManualRobot.Move(eDirection.ZP, m_ManualRobot.m_IsStep);
        }

        private void CButtonRobotDistanceZAdd_MouseUp(object sender, MouseEventArgs e)
        {
            m_ManualRobot.Stop(eAxisName.Z);
        }

        private void CButtonRobotDistanceZSub_MouseDown(object sender, MouseEventArgs e)
        {
            m_ManualRobot.Move(eDirection.ZN, m_ManualRobot.m_IsStep);
        }

        private void CButtonRobotDistanceZSub_MouseUp(object sender, MouseEventArgs e)
        {
            m_ManualRobot.Stop(eAxisName.Z);
        }

        private void CButtonRobotDistanceRZAdd_MouseDown(object sender, MouseEventArgs e)
        {
            m_ManualRobot.Move(eDirection.RZP, m_ManualRobot.m_IsStep);
        }

        private void CButtonRobotDistanceRZAdd_MouseUp(object sender, MouseEventArgs e)
        {
            m_ManualRobot.Stop(eAxisName.RZ);
        }

        private void CButtonRobotDistanceRZSub_MouseDown(object sender, MouseEventArgs e)
        {
            m_ManualRobot.Move(eDirection.RZN, m_ManualRobot.m_IsStep);
        }

        private void CButtonRobotDistanceRZSub_MouseUp(object sender, MouseEventArgs e)
        {
            m_ManualRobot.Stop(eAxisName.RZ);
        }

        private void UpdateRobotCurentMeas()
        {
            if (m_ManualRobot != null && m_ManualRobot.IsConnected())
            {
                cPoint pos = m_ManualRobot.GetPos();
                CTextBoxRobotDistanceJ1.Text = (pos[eAxisName.J1] / 1000).ToString("0.000");
                CTextBoxRobotDistanceJ2.Text = (pos[eAxisName.J2] / 1000).ToString("0.000");
                CTextBoxRobotDistanceJ3.Text = (pos[eAxisName.J3] / 1000).ToString("0.000");
                CTextBoxRobotDistanceJ4.Text = (pos[eAxisName.J4] / 1000).ToString("0.000");

                CTextBoxRobotDistanceX.Text = (pos[eAxisName.X] / 1000).ToString("0.000");
                CTextBoxRobotDistanceY.Text = (pos[eAxisName.Y] / 1000).ToString("0.000");
                CTextBoxRobotDistanceZ.Text = (pos[eAxisName.Z] / 1000).ToString("0.000");
                CTextBoxRobotDistanceRZ.Text = (pos[eAxisName.RZ] / 1000).ToString("0.000");

                //警报信息
                //listBoxRobotWarnMeas.Items.Clear();
                //string [,] WarnStr = m_ManualRobot.GetRobotWarnString(eLanguage.TW);
                //for (int i = 0; i < (WarnStr.Length) / 3; i++)
                //{
                //    listBoxRobotWarnMeas.Items.Add(WarnStr[i, 0]);
                //    listBoxRobotWarnMeas.Items.Add(WarnStr[i, 1]);
                //    listBoxRobotWarnMeas.Items.Add(WarnStr[i, 2]);
                //}
            }
        }

        private void CBtnRobotTestReadPoint_Click(object sender, EventArgs e)
        {
            if (m_ManualRobot.IsConnected() && m_ManualRobot.m_PointList != null)
            {
                ReadRobotGlobalPoints(0, RobotGlobalPointsBefore);
            }
            else
            {
                MessageBox.Show("机械臂未连接或未获取到点位信息！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /*加载并显示当前行的全局点位*/
        private void GetRobotGlobalPoint(RobotBase robot, DataGridView dgv, int index)
        {
            cPoint pointData = robot.GetGlobalPoint(index);
            try
            {
                dgv[0, index].Value = pointData.Name;
                dgv[1, index].Value = pointData[eAxisName.X] / 1000;
                dgv[2, index].Value = pointData[eAxisName.Y] / 1000;
                dgv[3, index].Value = pointData[eAxisName.Z] / 1000;
                dgv[4, index].Value = pointData[eAxisName.RZ] / 1000;
                dgv[5, index].Value = pointData.Info.Hand;
                dgv[6, index].Value = pointData.Info.UserFrame;
                dgv[7, index].Value = pointData.Info.ToolFrame;
                dgv.Rows[index].HeaderCell.Value = String.Format("{0}", index + 1);
            }
            catch { };
        }

        private void DGV_RobotGlobalPoint_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            m_ManualRobotGlobalPointIndex = DGV_RobotGlobalPoint.CurrentRow.Index;
        }

        private void CBtnRobotTestMoveToPoint_MouseDown(object sender, MouseEventArgs e)
        {
            if (m_ManualRobot.IsConnected())
            {
                cPoint point = new cPoint();
                point = m_ManualRobot.GetGlobalPoint(m_ManualRobotGlobalPointIndex);
                if (point != null)
                {
                    m_ManualRobot.GotoMovP(point);
                }
            }
        }

        private void CBtnRobotTestMoveToPoint_MouseUp(object sender, MouseEventArgs e)
        {
            m_ManualRobot.MovStop();
        }

        private void CBtnRobotTestTeachPoint_Click(object sender, EventArgs e)
        {
            if (m_ManualRobot.IsConnected())
            {
                int nPointIndex = m_ManualRobotGlobalPointIndex;
                m_ManualRobot.TechGlobalPoint(nPointIndex);
                GetRobotGlobalPoint(m_ManualRobot, DGV_RobotGlobalPoint, nPointIndex) ;
            }
        }

        private void CBtnRobotTestRunAction_Click(object sender, EventArgs e)
        {
            if (m_ManualRobot.IsConnected())
            {
                m_ManualRobot.RunAction((int)RobotAction.Action_Manual_Grap_1 + ComBoxRobotActions.SelectedIndex);
                int nCount = 50;
                while (nCount-- > 0)
                {
                    if (DataStruct.SysStat.RobotVacuoCheck) //监听机器人的通信线程设置此RobotVacuoCheck
                        m_ManualRobot.RunAction((int)RobotAction.Action_QRCodeScan);

                    if (VisualSortingStation.m_ScanQRCode)  //二维码格式检查在QRCodeRecvData中
                    {
                        m_ManualRobot.RunAction((int)RobotAction.Action_Manual_Put_1 + ComBoxRobotActions.SelectedIndex);
                        break;
                    }
                       
                    Thread.Sleep(100);
                }
            }
        }

        private void CBtnRobotTestTurnOver_Click(object sender, EventArgs e)
        {

        }

        private void CBtnRobotGrapGo_Click(object sender, EventArgs e)
        {
            m_ManualRobot.SetRobotIo(Robot_IO_OUT.Robot_IO_OUT_Cyl, IOValue.IOValueHigh);
        }

        private void CBtnRobotGrapBack_Click(object sender, EventArgs e)
        {
            m_ManualRobot.SetRobotIo(Robot_IO_OUT.Robot_IO_OUT_Cyl, IOValue.IOValueLow);
        }

        private void CBtnRobotGrap_Click(object sender, EventArgs e)
        {
            if (CBtnRobotGrap.Text == "抓取")
            {
                CBtnRobotGrap.Text = "放下";
                m_ManualRobot.SetRobotIo(Robot_IO_OUT.Robot_IO_OUT_Vacuo, IOValue.IOValueHigh);
            }
            else if (CBtnRobotGrap.Text == "放下")
            {
                CBtnRobotGrap.Text = "抓取";
                m_ManualRobot.SetRobotIo(Robot_IO_OUT.Robot_IO_OUT_Vacuo, IOValue.IOValueHigh);
            }
        }

        private void RefreshTimer_Tick(object sender, EventArgs e)
        {
            Bitmap bmpGreen = Properties.Resources.SmallGreen;
            Bitmap bmpDarkGreen = Properties.Resources.SmallDarkGreen;
            Bitmap bmpRed = Properties.Resources.SmallRed;
            Bitmap bmpDarkRed = Properties.Resources.SmallDarkRed;

            //Robot
            pictureBoxRobotAlarm.Image = (m_ManualRobot.HasAlarm() || m_ManualRobot.HasWarning()) ? bmpRed : bmpDarkRed;
            pictureBoxTemperature.Image = (m_ManualRobot.GetTemperatureStateString() == "过载") ? bmpRed : bmpDarkGreen;
            pictureBoxRobotMove.Image = m_ManualRobot.GetMovingState() ? bmpGreen : bmpDarkGreen;
            DisplayRobotState(m_ManualRobot.GetExecutorStateString(), pictureBoxRobotExecut);
            RefreshRobotServoPic(m_ManualRobot, pictureBoxServo);

            UpdateRobotCurentMeas();

            if (m_ManualRobot.IsConnected() && m_ManualRobot.m_PointList == null)  //读取全局点位信息，只读一次
                m_ManualRobot.m_PointList = m_ManualRobot.GetGlobalPointData();

            //抓手
            PicBoxRobotGrapGoArrive.Image = DataStruct.SysStat.RobotCylGoArrive ? bmpRed : bmpDarkGreen;
            PicBoxRobotGrapBackArrive.Image = DataStruct.SysStat.RobotCylBackArrive ? bmpRed : bmpDarkGreen;
            PicBoxRobotGrapVacuumCheck.Image = DataStruct.SysStat.RobotVacuoCheck ? bmpRed : bmpDarkGreen;

            //二维码
            if (m_QRCode != null && m_QRCode.m_IsConnect)
            {
                lock (this)
                {
                    if (m_QRCode.m_ReadQueue.Count > 0)
                        ComBoxQRCodeReadShow.Text += m_QRCode.m_ReadQueue.Dequeue();
                }
            }

            //IO 控制板指示灯更新
            Bitmap bmpYellow = Properties.Resources.SmallYellow;
            Bitmap bmpBlue = Properties.Resources.SmallBlue;

            PicBoxEmptyPlateUpArrive.Image = DataStruct.SysStat.EmptyPlateUpArrive ? bmpRed : bmpDarkGreen;
            PicBoxEmptyPlateDownArrive.Image = DataStruct.SysStat.EmptyPlateDownArrive ? bmpRed : bmpDarkGreen;
            PicBoxIoRedLed.Image = DataStruct.SysStat.RedAlarm ? bmpRed : bmpDarkGreen;
            PicBoxIoYellowLed.Image = DataStruct.SysStat.YellowAlarm ? bmpYellow : bmpDarkGreen;
            PicBoxIoGreenLed.Image = DataStruct.SysStat.LedGreen ? bmpGreen : bmpDarkGreen;
            PicBoxIoBlueLed.Image = DataStruct.SysStat.LedBlue ? bmpBlue : bmpDarkGreen;
        }

        private void ManualDebugForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            CloseRobot();
        }

        public void CloseRobot()
        {
            if (m_ManualRobot != null)
            {
                m_ManualRobot.Close();
            }
        }

        public void HideFormAndSaveConfigFile()
        {
            this.Hide();
            Profile.SaveConfigFile();
            RefreshTimer.Stop();
        }

        //当窗体第一次显示时发生
        private void ManualDebugForm_Shown(object sender, EventArgs e)
        {
            RefreshTimer.Start();
        }


        public void InitRobot()
        {
            //下面的三个页暂不使用
            PageRobotTestUserFrame.Parent = null;
            PageRobotTestToolFrame.Parent = null;
            PageRobotTestWorkSpace.Parent = null;
            ComBoxRobotActions.SelectedIndex = 0;
        }

        public void InitCamera()
        {
            if (m_Camera != null)
            {
                PictureBoxCamera = m_Camera.m_CameraPictureBox;
                ComBoxCameraDevList = m_Camera.m_CameraListComboBox;
            }        
        }

        private void CButtonFindCamera_Click(object sender, EventArgs e)
        {
            if (m_Camera != null)
                m_Camera.FindCameraDevice();
        }

        private void CButtonOpenCamera_Click(object sender, EventArgs e)
        {
            if (m_Camera != null)
                m_Camera.OpenCameraDevice();
        }

        private void CButtonCloseCamera_Click(object sender, EventArgs e)
        {
            if (m_Camera != null)
                m_Camera.CloseCameraDevice();
        }

        private void CButtonCameraSetParam_Click(object sender, EventArgs e)
        {
            CameraParamStruct param;
            param.Exposure = float.Parse(CTextBoxCameraExposure.Text);
            param.Gain = float.Parse(CTextBoxCameraGain.Text);
            param.FramRate = float.Parse(CTextBoxCameraFrameRate.Text);

            if (m_Camera != null)
                m_Camera.SetCameraParam(param);
        }

        private void CButtonCameraReadParam_Click(object sender, EventArgs e)
        {
            if (m_Camera != null)
            {
                CameraParamStruct param = m_Camera.GetCameraParam();
                CTextBoxCameraExposure.Text = param.Exposure.ToString("F1");
                CTextBoxCameraGain.Text = param.Gain.ToString("F1");
                CTextBoxCameraFrameRate.Text = param.FramRate.ToString("F1");
            }
        }

        private void tabControlManualDebug_Selected(object sender, TabControlEventArgs e)
        {
            switch (tabControlManualDebug.SelectedIndex)
            {
                case 0:  //台达机械臂
                    {
                        radioButtonRobotDeviceJog.Checked = true;  //默认是Jog模式
                        CTextBoxRobotMoveSpeed.Text = Profile.m_Config.RobotMoveSpeed.ToString();
                        CTextBoxJogDistance.Text = Profile.m_Config.RobotMoveDistance.ToString();
                        CTextBoxJogDistanceUm.Text = Profile.m_Config.RobotMoveDistanceUm.ToString();
                        m_ManualRobot.SetRobotPamram(int.Parse(CTextBoxRobotMoveSpeed.Text), int.Parse(CTextBoxJogDistance.Text), int.Parse(CTextBoxJogDistanceUm.Text));

                        TimerMotionControlGetState.Stop();
                    }
                    break;
                case 1:  //二维码读码器
                    {

                    }
                    break;
                case 2:  //RFID
                    {

                    }break;
                case 3:  //IO
                    {

                    }
                    break;
                case 4:  //相机
                    {
                        CTextBoxCameraExposure.Text = Profile.m_Config.CameraExposure.ToString("F1");
                        CTextBoxCameraGain.Text = Profile.m_Config.CameraGain.ToString("F1");
                        CTextBoxCameraFrameRate.Text = Profile.m_Config.CameraFramRate.ToString("F1");

                        TimerMotionControlGetState.Stop();
                    }
                    break;
                case 5:  //三轴机械臂
                    {
                        if (!m_MotionControl.m_bInitBoard)
                            m_MotionControl.InitMotionControl();

                        if (m_MotionControl.m_DeviceCount > 0)
                        {
                            ComBoxMotionControlDevice.Items.Clear();
                            for (int i = 0; i < m_MotionControl.m_DeviceCount; i++)
                            {
                                ComBoxMotionControlDevice.Items.Add(m_MotionControl.m_CurAvailableDevs[i].DeviceName);
                                ComBoxMotionControlDevice.SelectedIndex = 0;
                            }
                        }

                        TimerMotionControlGetState.Start();
                    }
                    break;
                default: break;
            }

            if (tabControlManualDebug.SelectedIndex == 1)  //选择二维码读码器页时
                m_QRCode.QRCodeRecvDataEvent += new EventHandler(QRCodeRecvData);
            else
                m_QRCode.QRCodeRecvDataEvent -= new EventHandler(QRCodeRecvData);
        }

        //三轴机械臂
        private void CButtonMotionControlDeviceLoadCfg_Click(object sender, EventArgs e)
        {
            if (m_MotionControl.m_bInitBoard)
            {
                this.OpenFileDialogMotionControlLoadCfg.FileName = ".cfg";
                if (OpenFileDialogMotionControlLoadCfg.ShowDialog() != DialogResult.OK)
                    return;

                m_MotionControl.LoadConfig(OpenFileDialogMotionControlLoadCfg.FileName);
            }
        }

        private void CButtonOpenMotionControlDevice_Click(object sender, EventArgs e)
        {
            if (!m_MotionControl.m_bInitBoard)
            {              
                m_MotionControl.OpenDevice();

                ComBoxMotionControlAxis.Items.Clear();
                for (int i = 0; i < m_MotionControl.m_AxisCount; i++)
                {
                    ComBoxMotionControlAxis.Items.Add(String.Format("{0:d}-Axis", i));
                }
                ComBoxMotionControlAxis.SelectedIndex = 0;
                ComBoxMotionHomeMode.SelectedIndex = 0;
            }
        }

        private void CButtonCloseMotionControlDevice_Click(object sender, EventArgs e)
        {
            if (m_MotionControl != null)
            {
                m_MotionControl.CloseDevice();
            }
        }

        private void CButtonMotionControlResetError_Click(object sender, EventArgs e)
        {
            if (m_MotionControl != null)
            {
                for (uint i = 0; i < m_MotionControl.m_AxisCount; i++)
                {
                    m_MotionControl.ResetErr(i);
                }
            }           
        }

        private void CButtonSetMotionControlSpeedParam_Click(object sender, EventArgs e)
        {
            double AxVelLow = double.Parse(CTextBoxMotionControLowSpeed.Text);
            double AxVelHigh = double.Parse(CTextBoxMotionControHighSpeed.Text);
            double AxVelAcc = double.Parse(CTextBoxMotionControAccSpeed.Text);
            double AxVelDec = double.Parse(CTextBoxMotionControDecSpeed.Text);
            int AxDistance = int.Parse(CTextBoxMotionControlDistance.Text);

            if (m_MotionControl.m_bInitBoard)
            {
                m_MotionControl.m_Distance = AxDistance;
                m_MotionControl.SetMotionAxisSpeedParam(m_MotionControl.m_CurAxis, AxVelLow, AxVelHigh, AxVelAcc, AxVelDec);
            }             
        }

        private void CButtonMotionControlUp_Click(object sender, EventArgs e)
        {
            if (m_MotionControl.m_bInitBoard)
            {
                m_MotionControl.m_CurAxis = MotionControl.AXIS_NO_Y;
                m_MotionControl.MoveMotion(MotionControl.AXIS_NO_Y, false);
            }
        }

        private void CButtonMotionControlDown_Click(object sender, EventArgs e)
        {
            if (m_MotionControl.m_bInitBoard)
            {
                m_MotionControl.m_CurAxis = MotionControl.AXIS_NO_Y;
                m_MotionControl.MoveMotion(MotionControl.AXIS_NO_Y, true);
            }
        }

        private void CButtonMotionControlLift_Click(object sender, EventArgs e)
        {
            if (m_MotionControl.m_bInitBoard)
            {
                m_MotionControl.m_CurAxis = MotionControl.AXIS_NO_X;
                m_MotionControl.MoveMotion(MotionControl.AXIS_NO_X, false);
            }
        }

        private void CButtonMotionControlRight_Click(object sender, EventArgs e)
        {
            if (m_MotionControl.m_bInitBoard)
            {
                m_MotionControl.m_CurAxis = MotionControl.AXIS_NO_X;
                m_MotionControl.MoveMotion(MotionControl.AXIS_NO_X, true);
            }
        }

        //抓取
        private void CButtonMotionControlGrasp_Click(object sender, EventArgs e)
        {
            if (m_MotionControl.m_bInitBoard)
            {
                m_MotionControl.MoveMotion(MotionControl.AXIS_NO_Z, false);

                //启动吸嘴
                Thread.Sleep(500);

                m_MotionControl.MoveMotion(MotionControl.AXIS_NO_Z, true);
            }
        }

        private void GetMotionControlIOStatus(uint IOStatus)
        {
            if (m_MotionControl != null)
            {
                if ((IOStatus & (uint)Ax_Motion_IO.AX_MOTION_IO_EZ) > 0)//ALM
                    picBoxMotionControlIoEZ.Image = Properties.Resources.SmallRed;
                else
                    picBoxMotionControlIoEZ.Image = Properties.Resources.SmallDarkGreen;

                if ((IOStatus & (uint)Ax_Motion_IO.AX_MOTION_IO_ORG) > 0)//ORG
                    picBoxMotionControlIoORG.Image = Properties.Resources.SmallRed;
                else
                    picBoxMotionControlIoORG.Image = Properties.Resources.SmallDarkGreen;

                if ((IOStatus & (uint)Ax_Motion_IO.AX_MOTION_IO_LMTP) > 0)//+EL
                    picBoxMotionControlIoPosLmit.Image = Properties.Resources.SmallRed;
                else
                    picBoxMotionControlIoPosLmit.Image = Properties.Resources.SmallDarkGreen;

                if ((IOStatus & (uint)Ax_Motion_IO.AX_MOTION_IO_LMTN) > 0)//-EL
                    picBoxMotionControlIoNegLmit.Image = Properties.Resources.SmallRed;
                else
                    picBoxMotionControlIoNegLmit.Image = Properties.Resources.SmallDarkGreen;
            }
        }

        //监控状态定时器
        private void TimerMotionControlGetState_Tick(object sender, EventArgs e)
        {
            uint IOStatus = 0;
            string AxisXState = "";
            string AxisYState = "";
            string AxisZState = "";
            string AxisCurState = "";
            m_MotionControl.GetMotionControlState(ref IOStatus, ref AxisXState, ref AxisYState, ref AxisZState, ref AxisCurState);
            GetMotionControlIOStatus(IOStatus);

            CTextBoxMotionControlState.Text = AxisCurState;
            CTextBoxMotionControlXDistance.Text = AxisXState;
            CTextBoxMotionControlYDistance.Text = AxisYState;
            CTextBoxMotionControlZDistance.Text = AxisZState;
        }

        private void CButtonMotionAxisRunNeg_Click(object sender, EventArgs e)
        {

        }

        private void CButtonMotionAxisRunPos_Click(object sender, EventArgs e)
        {

        }

        private void CButtonMotionAxisStop_Click(object sender, EventArgs e)
        {

        }

        private void CButtonMotionAxisHome_Click(object sender, EventArgs e)
        {
            if (m_MotionControl.m_bInitBoard)
            {
                m_MotionControl.m_HomeMode = (uint)ComBoxMotionHomeMode.SelectedIndex;
                m_MotionControl.GoHome();
            }
                
        }


        #region   // 二维码扫描器

        private void ComBoxQRCodeConnect_Click(object sender, EventArgs e)
        {
            string Port = (string)ComBoxQRCodeCom.Items[ComBoxQRCodeCom.SelectedIndex];
            string BandRate = (string)ComBoxQRCodeBandRate.Items[ComBoxQRCodeBandRate.SelectedIndex];
            string DataBits = (string)ComBoxQRCodeDataBit.Items[ComBoxQRCodeDataBit.SelectedIndex];
            string StopBits = (string)ComBoxQRCodeStopBit.Items[ComBoxQRCodeStopBit.SelectedIndex];
            string Parity = (string)ComBoxQRCodeParity.Items[ComBoxQRCodeParity.SelectedIndex];

            m_QRCode.QRCodeCommunParamInit(Port, BandRate, DataBits, StopBits, Parity);
            m_QRCode.QRCodeInit();

            if (m_QRCode.m_IsConnect)
            {
                ComBoxQRCodeConnect.Enabled = false;
                ComBoxQRCodeDisconnect.Enabled = true;
            }
        }

        private void ComBoxQRCodeDisconnect_Click(object sender, EventArgs e)
        {
            if (m_QRCode != null)
            {
                m_QRCode.m_SerialPort.Close();
            }
            ComBoxQRCodeConnect.Enabled = true;
            ComBoxQRCodeDisconnect.Enabled = false;
        }

        private void ComBoxQRCodeClear_Click(object sender, EventArgs e)
        {
            ComBoxQRCodeReadShow.Text = "";
        }

        private void QRCodeRecvData(object sender, EventArgs e)
        {
            if (e is QRCodeEventArgers)
            {
                QRCodeEventArgers Temp = e as QRCodeEventArgers;
                m_SyncContext.Post(SetQRCodeTextSafePost, Temp.QRCodeRecv);
            }
        }

        private void SetQRCodeTextSafePost(object text)
        {
            ComBoxQRCodeReadShow.Text += (string)text;

            ComBoxQRCodeReadShow.Focus();//获取焦点          
            ComBoxQRCodeReadShow.Select(ComBoxQRCodeReadShow.TextLength, 0);//光标定位到文本最后
            ComBoxQRCodeReadShow.ScrollToCaret();//滚动到光标处
        }

        private void ComBoxQRCodeConnect_EnabledChanged(object sender, EventArgs e)
        {
            if (ComBoxQRCodeConnect.Enabled)
                ComBoxQRCodeConnect.BackColor = CustomColor.BtnGreenColor;
            else
                ComBoxQRCodeConnect.BackColor = Color.Gray;
        }

        private void ComBoxQRCodeDisconnect_EnabledChanged(object sender, EventArgs e)
        {
            if (ComBoxQRCodeDisconnect.Enabled)
                ComBoxQRCodeDisconnect.BackColor = Color.Red;
            else
                ComBoxQRCodeDisconnect.BackColor = Color.Gray;
        }

        private void ComBoxQRCodeCom_SelectedIndexChanged(object sender, EventArgs e)
        {
            Profile.m_Config.QRCodePort = (string)ComBoxQRCodeCom.Items[ComBoxQRCodeCom.SelectedIndex];
        }

        private void ComBoxQRCodeBandRate_SelectedIndexChanged(object sender, EventArgs e)
        {
            Profile.m_Config.QRCodeBandRate = (string)ComBoxQRCodeBandRate.Items[ComBoxQRCodeBandRate.SelectedIndex];
        }

        private void ComBoxQRCodeDataBit_SelectedIndexChanged(object sender, EventArgs e)
        {
            Profile.m_Config.QRCodeDataBits = (string)ComBoxQRCodeDataBit.Items[ComBoxQRCodeDataBit.SelectedIndex];
        }

        private void ComBoxQRCodeStopBit_SelectedIndexChanged(object sender, EventArgs e)
        {
            Profile.m_Config.QRCodeStopBits = (string)ComBoxQRCodeStopBit.Items[ComBoxQRCodeStopBit.SelectedIndex];
        }

        private void ComBoxQRCodeParity_SelectedIndexChanged(object sender, EventArgs e)
        {
            Profile.m_Config.QRCodeParity = (string)ComBoxQRCodeParity.Items[ComBoxQRCodeParity.SelectedIndex];
        }

        #endregion

        #region  //RFID

        //RFID
        public void InitRfid()
        {
            ComBoxRfidCh.SelectedIndex = 0;
        }

        //二维码读取器
        public void InitQRCode()
        {
            ComBoxQRCodeDisconnect.Enabled = false;

            //获取当前的串口设备
            string[] CurPorts = SerialPort.GetPortNames();
            if (CurPorts.Length > 0)
            {
                ComBoxQRCodeCom.Items.Clear();
                foreach (string port in CurPorts)
                {
                    ComBoxQRCodeCom.Items.Add(port);
                }
            }

            ComBoxQRCodeCom.SelectedIndex = 0;
            ComBoxQRCodeBandRate.SelectedIndex = 0;
            ComBoxQRCodeDataBit.SelectedIndex = 0;
            ComBoxQRCodeStopBit.SelectedIndex = 0;
            ComBoxQRCodeParity.SelectedIndex = 0;

            m_SyncContext = SynchronizationContext.Current;
        }

        private void CBtnRfidConnect_Click(object sender, EventArgs e)
        {
            bool bCon = m_RFID.InitRFID(CTextBoxRfidIp.Text);
            if (bCon)
            {
                MessageBox.Show("RFID 连接成功！");
            }
            else
            {
                MessageBox.Show("RFID 连接失败！");
            }
        }

        private void CBtnRfidInit_Click(object sender, EventArgs e)
        {
            m_RFID.Init((ushort)ComBoxRfidCh.SelectedIndex);
        }

        private void CBtnRfidEnable_Click(object sender, EventArgs e)
        {
            m_RFID.Enable((ushort)ComBoxRfidCh.SelectedIndex);
        }

        private void CBtnRfidDisable_Click(object sender, EventArgs e)
        {
            m_RFID.Disable((ushort)ComBoxRfidCh.SelectedIndex);
        }

        private void CBtnRfidWrite_Click(object sender, EventArgs e)
        {
            m_RFID.Write((ushort)ComBoxRfidCh.SelectedIndex, "0000000000000001");
        }

        private void CBtnRfidRead_Click(object sender, EventArgs e)
        {
            CTextBoxRfidSn.Text = "";
            m_RFID.Read((ushort)ComBoxRfidCh.SelectedIndex);
            Thread.Sleep(1);
            if (m_RFID.m_QueueRead.Count > 0)
                CTextBoxRfidSn.Text = m_RFID.m_QueueRead.Dequeue();
        }

        private void CTextBoxRfidIp_TextChanged(object sender, EventArgs e)
        {
            Profile.m_Config.RfidIp = CTextBoxRfidIp.Text;
        }

        private void ComBoxRfidCh_SelectedIndexChanged(object sender, EventArgs e)
        {
            Profile.m_Config.RfidCh = ComBoxRfidCh.SelectedIndex;
        }

        private void CTextBoxRfidSn_TextChanged(object sender, EventArgs e)
        {
            Profile.m_Config.RfidSn = CTextBoxRfidSn.Text;
        }


        #endregion

        #region  //IO 控制

        private void CButtonIoEmptyPlateUp_Click(object sender, EventArgs e)
        {
            m_IO.SetControlBoardIo(IO_OUT.IO_OUT_EmptyPanelUp, IOValue.IOValueHigh);
        }

        private void CButtonIoEmptyPlateDown_Click(object sender, EventArgs e)
        {
            m_IO.SetControlBoardIo(IO_OUT.IO_OUT_EmptyPanelDown, IOValue.IOValueHigh);
        }

        private void CButtonIoRedLed_Click(object sender, EventArgs e)
        {
            m_IO.SetControlBoardIo(IO_OUT.IO_OUT_LedRed, IOValue.IOValueHigh);
        }

        private void CButtonIoYellowLed_Click(object sender, EventArgs e)
        {
            m_IO.SetControlBoardIo(IO_OUT.IO_OUT_LedYellow, IOValue.IOValueHigh);
        }

        private void CButtonIoGreenLed_Click(object sender, EventArgs e)
        {
            m_IO.SetControlBoardIo(IO_OUT.IO_OUT_LedGreen, IOValue.IOValueHigh);
        }

        private void CButtonIoBlueLed_Click(object sender, EventArgs e)
        {
            m_IO.SetControlBoardIo(IO_OUT.IO_OUT_LedBlue, IOValue.IOValueHigh);
        }

        #endregion


    }
}
