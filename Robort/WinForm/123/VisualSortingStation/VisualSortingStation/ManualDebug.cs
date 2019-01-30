using RABD.DROE.SystemDefine;
using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using System.IO.Ports;

namespace RobotWorkstation
{
    public partial class ManualDebugForm : Form
    {
        //机械臂
        private RobotDevice m_ManualRobot = RobotDevice.GetInstance();
        private const int RobotGlobalPointsBefore = 30;  //先加载前30个点，其余的在定时器中加载，来解决刷新缓慢的问题
        private int m_ManualRobotGlobalPointIndex = 0;  //选中的全局点位索引

        private RFID m_RFID = RFID.GetInstance();
        private QRCode m_QRCode = QRCode.GetInstance();
        private ArmControler m_ArmControler = ArmControler.GetInstance();

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

        private void RefreshTimer_Tick(object sender, EventArgs e)
        {
            InitUIControlEnableState();

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
            PicBoxRobotGrapGoArrive.Image = DataStruct.SysStat.RobotCylGoArrive ? bmpGreen : bmpDarkGreen;
            PicBoxRobotGrapBackArrive.Image = DataStruct.SysStat.RobotCylBackArrive ? bmpGreen : bmpDarkGreen;
            PicBoxRobotGrapVacuumCheck.Image = DataStruct.SysStat.RobotVacuoCheck ? bmpGreen : bmpDarkGreen;

            //二维码
            if (m_QRCode != null && m_QRCode.m_IsConnect)
            {
                lock (this)
                {
                    if (m_QRCode.m_ReadQueue.Count > 0)
                        ComBoxQRCodeReadShow.Text += m_QRCode.m_ReadQueue.Dequeue();
                }
            }

            //RFID
            if (m_RFID.IsConnected)
            {
                if (DataStruct.SysStat.ManualDebugReceiveSalverArrive)
                {
                    PicTrayDeviceInRFID.Image = bmpGreen;
                    CTextBoxTrayDeviceRfidSn.Text = VisualSortingStation.m_RfidRead;
                }
                else
                {
                    PicTrayDeviceInRFID.Image = bmpDarkGreen;
                    CTextBoxTrayDeviceRfidSn.Text = "";
                }
            }

            //Arm Controler
            //气缸
            PicBoxEmptySalverObstructUpArrive.Image = DataStruct.SysStat.EmptySalverObstructAirCylUpArrive ? bmpGreen : bmpDarkGreen;
            PicBoxEmptySalverObstructDownArrive.Image = DataStruct.SysStat.EmptySalverObstructAirCylDownArrive ? bmpGreen : bmpDarkGreen;
            PicBoxEmptySalverUpArrive.Image = DataStruct.SysStat.ReceiveSalverLiftingAirCylUpArrive ? bmpGreen : bmpDarkGreen;
            PicBoxEmptySalverDownArrive.Image = DataStruct.SysStat.ReceiveSalverLiftingAirCylDownArrive ? bmpGreen : bmpDarkGreen;
            PicBoxConveyorUpArrive.Image = DataStruct.SysStat.ConveyorLiftingAirCylUpArrive ? bmpGreen : bmpDarkGreen;
            PicBoxConveyorDownArrive.Image = DataStruct.SysStat.ConveyorLiftingAirCylDownArrive ? bmpGreen : bmpDarkGreen;

            //按键
            PicKeyRun.Image = DataStruct.SysStat.KeyRun ? bmpGreen : bmpDarkGreen;
            PicKeyPause.Image = DataStruct.SysStat.KeyPause ? bmpGreen : bmpDarkGreen;
            PicKeyStop.Image = DataStruct.SysStat.KeyStop ? bmpGreen : bmpDarkGreen;
            PicKeyReset.Image = DataStruct.SysStat.KeyReset ? bmpGreen : bmpDarkGreen;

            //传感器
            PicBoxEmptySalverObstructSensor.Image = DataStruct.SysStat.EmptySalverObstructSensor ? bmpGreen : bmpDarkGreen;
            PicBoxSalverRunOutStationSensor.Image = DataStruct.SysStat.SalverRunOutStationSensor ? bmpGreen : bmpDarkGreen;

            //翻转机构
            PicOverturn.Image = DataStruct.SysStat.OverturnSalverTurnArrive ? bmpGreen : bmpDarkGreen;
            PicOverturnCylLock.Image = DataStruct.SysStat.OverturnSalverLockAirCylGoArrive ? bmpGreen : bmpDarkGreen;
            PicOverturnCylUnLock.Image = DataStruct.SysStat.OverturnSalverLockAirCylBackArrive ? bmpGreen : bmpDarkGreen;

            if (m_ArmControler.IsBoardConnected(Board.Controler))
            {
                CTxtAxisConveyorCurPos.Text = Convert.ToString(VisualSortingStation.m_ConveyorAxisCurPos);

                TextBox[] txtState = new TextBox[(int)Axis.Max] { CTxtAxisConveyorrState, CTxtAxisTurnOverState };
                for (int i = 0; i < (int)Axis.Max; i++)
                {
                    txtState[i].Text = m_ArmControler.ReadAxisStateString((Axis)i);
                }
            }
        }

        private void ManualDebugForm_FormClosing(object sender, FormClosingEventArgs e)
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

        public void InitUIControlEnableState()
        {
            //Robot
            bool RobotConnectState = m_ManualRobot.IsConnected();
            if (tabPageRobot.Enabled != RobotConnectState)
                tabPageRobot.Enabled = RobotConnectState;

            //QRCode
            bool QRCodeConnectState = m_QRCode.m_IsConnect;
            if (CGroupBoxQRCode.Enabled != QRCodeConnectState)
                CGroupBoxQRCode.Enabled = QRCodeConnectState;

            //ArmControler
            bool ArmConnectState = m_ArmControler.IsBoardConnected(Board.Controler);
            if (CGroupBoxArmTowerLight.Enabled != ArmConnectState)
                CGroupBoxArmTowerLight.Enabled = ArmConnectState;

            if (CGroupBoxArmAireCyl.Enabled != ArmConnectState)
                CGroupBoxArmAireCyl.Enabled = ArmConnectState;

            if (CGroupBoxArmKeyIn.Enabled != ArmConnectState)
                CGroupBoxArmKeyIn.Enabled = ArmConnectState;

            if (CGroupBoxArmSensor.Enabled != ArmConnectState)
                CGroupBoxArmSensor.Enabled = ArmConnectState;

            if (CGrpAxisConveyor.Enabled != ArmConnectState)
                CGrpAxisConveyor.Enabled = ArmConnectState;

            if (CGrpTurnOver.Enabled != ArmConnectState)
                CGrpTurnOver.Enabled = ArmConnectState;
        }

        public void InitRobot()
        {
            //下面的三个页暂不使用
            PageRobotTestUserFrame.Parent = null;
            PageRobotTestToolFrame.Parent = null;
            PageRobotTestWorkSpace.Parent = null;
            ComBoxRobotActions.SelectedIndex = 0;
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
                    }
                    break;
                case 1:  //其他
                    {

                    }
                    break;

                default: break;
            }

            if (tabControlManualDebug.SelectedIndex == 1)  //选择其他页时
                m_QRCode.QRCodeRecvDataEvent += new EventHandler(QRCodeRecvData);
            else
                m_QRCode.QRCodeRecvDataEvent -= new EventHandler(QRCodeRecvData);
        }

        #region  //机械臂

        //加载机械臂的全局点位信息
        public void LoadRobotGlobalPoints(int StartIndex, int EndIndex)
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
                    DGV_RobotGlobalPoint[1, i].Value = (m_ManualRobot.m_PointList[i][eAxisName.X] / 1000).ToString("0.000");
                    DGV_RobotGlobalPoint[2, i].Value = (m_ManualRobot.m_PointList[i][eAxisName.Y] / 1000).ToString("0.000");
                    DGV_RobotGlobalPoint[3, i].Value = (m_ManualRobot.m_PointList[i][eAxisName.Z] / 1000).ToString("0.000");
                    DGV_RobotGlobalPoint[4, i].Value = (m_ManualRobot.m_PointList[i][eAxisName.RZ] / 1000).ToString("0.000"); 
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

        private void CBtnRobotGoHome_Click(object sender, EventArgs e)
        {
            if (m_ManualRobot.IsConnected())
            {
                m_ManualRobot.RunAction((int)RobotAction.Action_Go_Home);
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
            if (m_ManualRobot.IsConnected() /*&& m_ManualRobot.m_PointList != null*/)
            {
                ReadRobotGlobalPoints(0, RobotGlobalPointsBefore);
            }
            else
            {
                Global.MessageBoxShow(Global.StrRobotGetPointsError);              
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
                GetRobotGlobalPoint(m_ManualRobot, DGV_RobotGlobalPoint, nPointIndex);
            }
        }

        private void CBtnRobotTestRunAction_Click(object sender, EventArgs e)
        {
            DataStruct.SysStat.RobotVacuoCheck = false;
            VisualSortingStation.m_ScanQRCode = false;
            TimerRobotTestRunAction.Stop();

            if (m_ManualRobot.IsConnected())
            {
                m_ManualRobot.RunAction((int)RobotAction.Action_Manual_Grap_1 + ComBoxRobotActions.SelectedIndex);
                TimerRobotTestRunAction.Start();
            }
        }

        private void TimerRobotTestRunAction_Tick(object sender, EventArgs e)
        {
            if (DataStruct.SysStat.RobotVacuoCheck) //监听机器人的通信线程设置此RobotVacuoCheck
            {
                DataStruct.SysStat.RobotVacuoCheck = false;
                m_ManualRobot.RunAction((int)RobotAction.Action_QRCodeScan);
            }

            if (VisualSortingStation.m_ScanQRCode)  //二维码格式检查在QRCodeRecvData中
            {
                VisualSortingStation.m_ScanQRCode = false;
                m_ManualRobot.RunAction((int)RobotAction.Action_Manual_Put_1 + ComBoxRobotActions.SelectedIndex);
            }

            if (DataStruct.SysStat.RobotVacuoCheck) //监听机器人的通信线程设置此RobotVacuoCheck
            {
                TimerRobotTestRunAction.Stop();
                Global.MessageBoxShow(Global.StrRobotSortFinished);
            }
        }

        private void CBtnRobotTestTurnOver_Click(object sender, EventArgs e)
        {
            AxisState CurState = m_ArmControler.ReadAxisState(Axis.OverTurn);
            if (CurState == AxisState.Ready)
            {
                m_ArmControler.MoveAbs(Axis.OverTurn, ArmControler.m_OverturnAxisMaxStep);
            }
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
            m_ManualRobot.SetRobotIo(Robot_IO_OUT.Robot_IO_OUT_Vacuo, IOValue.IOValueHigh);
        }

        private void CBtnRobotPut_Click(object sender, EventArgs e)
        {
            m_ManualRobot.SetRobotIo(Robot_IO_OUT.Robot_IO_OUT_Vacuo, IOValue.IOValueLow);
        }

        #endregion

        #region   // 二维码扫描器

        //二维码读取器
        public void InitQRCode()
        {
            ComBoxQRCodeDisconnect.Enabled = false;

            //获取当前的串口设备
            string[] CurPorts = SerialPort.GetPortNames();
            if (CurPorts.Length > 0)
            {
                ComBoxQRCodeCom.Items.Clear();
                for (int i = 0; i < CurPorts.Length; i++)
                {
                    ComBoxQRCodeCom.Items.Add(CurPorts[i]);
                    if (CurPorts[i] == Profile.m_Config.QRCodePort)
                    {
                        ComBoxQRCodeCom.SelectedIndex = i;
                    }
                }
            }
        
            m_SyncContext = SynchronizationContext.Current;
        }

        private void ComBoxQRCodeConnect_Click(object sender, EventArgs e)
        {
            string Port = (string)ComBoxQRCodeCom.Items[ComBoxQRCodeCom.SelectedIndex];
            string BandRate = Profile.m_Config.QRCodeBandRate;

            m_QRCode.QRCodeCommunParamInit(Port, BandRate);
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

                bool Check = VisualSortingStation.CheckAndSaveQRCodeReadData(Temp.QRCodeRecv);
                if (Check)
                {
                    VisualSortingStation.m_ScanQRCode = true;
                }
                else
                {
                    VisualSortingStation.m_ScanQRCode = false;
                    m_ManualRobot.RunAction((int)RobotAction.Action_QRCodeScan);  //再次扫描
                }

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
            //Profile.m_Config.QRCodePort = (string)ComBoxQRCodeCom.Items[ComBoxQRCodeCom.SelectedIndex];
        }

        #endregion

        #region  //IO 控制

        private void BtnLampRedOn_Click(object sender, EventArgs e)
        {
            m_ArmControler.SetArmControlBoardIo(Board.Controler, ARM_OutputPoint.IO_OUT_LedRed, IOValue.IOValueHigh);
        }

        private void BtnLampRedOff_Click(object sender, EventArgs e)
        {
            m_ArmControler.SetArmControlBoardIo(Board.Controler, ARM_OutputPoint.IO_OUT_LedRed, IOValue.IOValueLow);
        }

        private void BtnLampOrangeOn_Click(object sender, EventArgs e)
        {
            m_ArmControler.SetArmControlBoardIo(Board.Controler, ARM_OutputPoint.IO_OUT_LedOriange, IOValue.IOValueHigh);
        }

        private void BtnLampOrangeOff_Click(object sender, EventArgs e)
        {
            m_ArmControler.SetArmControlBoardIo(Board.Controler, ARM_OutputPoint.IO_OUT_LedOriange, IOValue.IOValueLow);
        }

        private void BtnLampGreenOn_Click(object sender, EventArgs e)
        {
            m_ArmControler.SetArmControlBoardIo(Board.Controler, ARM_OutputPoint.IO_OUT_LedGreen, IOValue.IOValueHigh);
        }

        private void BtnLampGreenOff_Click(object sender, EventArgs e)
        {
            m_ArmControler.SetArmControlBoardIo(Board.Controler, ARM_OutputPoint.IO_OUT_LedGreen, IOValue.IOValueLow);
        }

        private void BtnLampBlueOn_Click(object sender, EventArgs e)
        {
            m_ArmControler.SetArmControlBoardIo(Board.Controler, ARM_OutputPoint.IO_OUT_LedBlue, IOValue.IOValueHigh);
        }

        private void BtnLampBlueOff_Click(object sender, EventArgs e)
        {
            m_ArmControler.SetArmControlBoardIo(Board.Controler, ARM_OutputPoint.IO_OUT_LedBlue, IOValue.IOValueLow);
        }

        private void BtnBeepOn_Click(object sender, EventArgs e)
        {
            m_ArmControler.SetArmControlBoardIo(Board.Controler, ARM_OutputPoint.IO_OUT_Beep, IOValue.IOValueHigh);
        }

        private void BtnBeepOff_Click(object sender, EventArgs e)
        {
            m_ArmControler.SetArmControlBoardIo(Board.Controler, ARM_OutputPoint.IO_OUT_Beep, IOValue.IOValueLow);
        }

        private void CButtonEmptySalverObstructUp_Click(object sender, EventArgs e)
        {
            m_ArmControler.SetArmControlBoardIo(Board.Controler, ARM_OutputPoint.IO_OUT_EmptySalverObstructAirCylRun, IOValue.IOValueHigh);
        }

        private void CButtonEmptySalverObstructDown_Click(object sender, EventArgs e)
        {
            m_ArmControler.SetArmControlBoardIo(Board.Controler, ARM_OutputPoint.IO_OUT_EmptySalverObstructAirCylRun, IOValue.IOValueLow);
        }

        private void CButtonIoEmptySalverLiftingUp_Click(object sender, EventArgs e)
        {
            m_ArmControler.SetArmControlBoardIo(Board.Controler, ARM_OutputPoint.IO_OUT_EmptySalverLiftingAirCylRun, IOValue.IOValueHigh);
        }

        private void CButtonIoEmptySalverLiftingDown_Click(object sender, EventArgs e)
        {
            m_ArmControler.SetArmControlBoardIo(Board.Controler, ARM_OutputPoint.IO_OUT_EmptySalverLiftingAirCylRun, IOValue.IOValueLow);
        }

        private void CButtonConveyorUp_Click(object sender, EventArgs e)
        {
            m_ArmControler.SetArmControlBoardIo(Board.Controler, ARM_OutputPoint.IO_OUT_ConveyorLiftingAirCylRun, IOValue.IOValueHigh);
        }

        private void CButtonConveyorDown_Click(object sender, EventArgs e)
        {
            m_ArmControler.SetArmControlBoardIo(Board.Controler, ARM_OutputPoint.IO_OUT_ConveyorLiftingAirCylRun, IOValue.IOValueLow);
        }

        #endregion

        #region  //传输线电机轴

        public void SetConveyorAxisParamWithInput(bool Default)
        {
            int velStart, velRun, velAdd, velDec;
            try
            {
                velStart = Convert.ToInt32(CTxtAxisConveyorSpeedStart.Text);
                velRun = Convert.ToInt32(CTxtAxisConveyorSpeedRun.Text);
                velAdd = Convert.ToInt32(CTxtAxisConveyorSpeedAdd.Text);
                velDec = Convert.ToInt32(CTxtAxisConveyorSpeedDec.Text);
            }
            catch
            {
                Global.MessageBoxShow(Global.StrInputError);
                return;
            }
            SetSpeedParamConveyorAxis(Axis.Conveyor, velStart, velRun, velAdd, velDec, Default);
        }

        private void CBtnAxisConveyorMoveForward_Click(object sender, EventArgs e)
        {
            Axis AxisIndex = Axis.Conveyor;
            m_ArmControler.ResetError(AxisIndex);
            SetConveyorAxisParamWithInput(false);
            m_ArmControler.MoveContinuous(AxisIndex, AxisDir.Forward);
        }

        private void CBtnAxisConveyorMoveReverse_Click(object sender, EventArgs e)
        {
            Axis AxisIndex = Axis.Conveyor;
            m_ArmControler.ResetError(AxisIndex);
            SetConveyorAxisParamWithInput(false);
            m_ArmControler.MoveContinuous(AxisIndex, AxisDir.Reverse);
        }

        private void CBtnAxisConveyorStop_Click(object sender, EventArgs e)
        {
            Axis AxisIndex = Axis.Conveyor;
            m_ArmControler.ResetError(AxisIndex);
            m_ArmControler.Stop(AxisIndex);
        }

        private void MoveMaual(Axis axis, TextBox txt, bool dir)
        {
            int step;

            try
            {
                step = Convert.ToInt32(txt.Text);
            }
            catch
            {
                Global.MessageBoxShow(Global.StrInputError);
                return;
            }

            if (!dir)
            {
                step = -step;
            }

            m_ArmControler.ResetError(axis);
            SetConveyorAxisParamWithInput(false);
            m_ArmControler.MoveRef(axis, step);
        }

        private void BtnAxisConveyorAdd_Click(object sender, EventArgs e)
        {
            Axis AxisIndex = Axis.Conveyor;
            MoveMaual(AxisIndex, CTxtAxisConveyorrStepPpu, true);
        }

        private void BtnAxisConveyorDec_Click(object sender, EventArgs e)
        {
            Axis AxisIndex = Axis.Conveyor;
            MoveMaual(AxisIndex, CTxtAxisConveyorrStepPpu, false);
        }

        private void BtnAxisConveyorResetError_Click(object sender, EventArgs e)
        {
            Axis AxisIndex = Axis.Conveyor;
            m_ArmControler.ResetError(AxisIndex);
        }

        /// <summary>
        /// 设置传输线电机轴速度
        /// </summary>
        /// <param name="axis">轴号</param>
        private void SetSpeedParamConveyorAxis(Axis axis, int Start, int Run, int Add, int Dec, bool Default)
        {
            m_ArmControler.SetSpeedParam(axis, Start, Run, Add, Dec, Default);
        }

        private void BtnAxisConveyorSetDefaultParam_Click(object sender, EventArgs e)
        {
            Profile.m_Config.AxisStartSpeed = int.Parse(CTxtAxisConveyorSpeedStart.Text);
            Profile.m_Config.AxisAddSpeed = int.Parse(CTxtAxisConveyorSpeedAdd.Text);
            Profile.m_Config.AxisDecSpeed = int.Parse(CTxtAxisConveyorSpeedDec.Text);

            Profile.m_Config.ConveyorAxisRunSpeed = int.Parse(CTxtAxisConveyorSpeedRun.Text);
            Profile.m_Config.ConveyorAxisMaxStep = int.Parse(CTxtAxisConveyorrStepPpu.Text);
            ArmControler.m_ConveyorAxisMaxStep = Profile.m_Config.ConveyorAxisMaxStep;

            SetConveyorAxisParamWithInput(true);
        }

        #endregion

        #region  //翻转机构

        /// <summary>
        /// 设置翻转电机轴速度
        /// </summary>
        /// <param name="axis">轴号</param>
        private void SetSpeedParamTurnOverAxis(Axis axis, int Speed, bool Default)
        {
            int velStart, velRun, velAdd, velDec;
            try
            {
                velStart = 2000;
                velRun = Speed;
                velAdd = 10000;
                velDec = 10000;
            }
            catch
            {
                Global.MessageBoxShow(Global.StrInputError);
                return;
            }

            m_ArmControler.SetSpeedParam(axis, velStart, velRun, velAdd, velDec, Default);
        }

        private void CBtnTurnOver_Click(object sender, EventArgs e)
        {
            Axis AxisIndex = Axis.OverTurn;
            m_ArmControler.ResetError(AxisIndex);
            SetSpeedParamTurnOverAxis(AxisIndex, int.Parse((CTxtAxisTurnOverSpeed.Text)), false);
            MoveMaual(AxisIndex, CTxtAxisTurnOverStep, true);
        }

        private void CBtnTurnOverReset_Click(object sender, EventArgs e)
        {
            Axis AxisIndex = Axis.OverTurn;
            m_ArmControler.ResetError(AxisIndex);
            m_ArmControler.BackHome(AxisIndex, AxisDir.Reverse);
        }

        private void CBtnTurnOverLockCylOpen_Click(object sender, EventArgs e)
        {
            m_ArmControler.SetArmControlBoardIo(Board.Controler, ARM_OutputPoint.IO_OUT_OverturnSalverLockAirCyl, IOValue.IOValueHigh);
        }

        private void CBtnTurnOverLockCylClose_Click(object sender, EventArgs e)
        {
            m_ArmControler.SetArmControlBoardIo(Board.Controler, ARM_OutputPoint.IO_OUT_OverturnSalverLockAirCyl, IOValue.IOValueLow);
        }

        private void CBtnTurnOverAxisErrorReset_Click(object sender, EventArgs e)
        {
            m_ArmControler.ResetError(Axis.OverTurn);
        }

        private void BtnAxisOverturnSetDefaultParam_Click(object sender, EventArgs e)
        {
            Profile.m_Config.OverturnAxisRunSpeed = int.Parse(CTxtAxisTurnOverSpeed.Text);
            Profile.m_Config.OverturnAxisMaxStep = int.Parse(CTxtAxisTurnOverStep.Text); ;

            ArmControler.m_OverturnAxisMaxStep = Profile.m_Config.OverturnAxisMaxStep;

            SetSpeedParamTurnOverAxis(Axis.OverTurn, int.Parse((CTxtAxisTurnOverSpeed.Text)), true);
        }

        #endregion

    }
}
