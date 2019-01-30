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
        private ArmControler m_ArmControler = ArmControler.GetInstance();
        private GraspRobot m_GraspRobot = GraspRobot.GetInstance();
        private QRCode m_QRCode = QRCode.GetInstance();

        SynchronizationContext m_SyncContext = null;  //更新二维码数据

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
        }

        private void ManualDebug_Load(object sender, EventArgs e)
        {
            tabControlManualDebug.Width = this.Width - tabControlManualDebug.Location.X;
            tabControlManualDebug.Height = this.Height - tabControlManualDebug.Location.Y;
        }

        private void RefreshTimer_Tick(object sender, EventArgs e)
        {
            InitUIControlEnableState();

            Bitmap bmpGreen = Properties.Resources.SmallGreen;
            Bitmap bmpDarkGreen = Properties.Resources.SmallDarkGreen;
            Bitmap bmpRed = Properties.Resources.SmallRed;
            Bitmap bmpDarkRed = Properties.Resources.SmallDarkRed;

            //按键
            PicKeyRun.Image = DataStruct.SysStat.KeyRun ? bmpGreen : bmpDarkGreen;
            PicKeyPause.Image = DataStruct.SysStat.KeyPause ? bmpGreen : bmpDarkGreen;
            PicKeyStop.Image = DataStruct.SysStat.KeyStop ? bmpGreen : bmpDarkGreen;
            PicKeyReset.Image = DataStruct.SysStat.KeyReset ? bmpGreen : bmpDarkGreen;

            if (m_ArmControler.IsBoardConnected(Board.Conveyor_Empty))
            {
                //CTxtAxisConveyorCurPos.Text = Convert.ToString(m_ArmControler.ReadAxisPostion(Axis.Conveyor));

                //TextBox[] txtState = new TextBox[(int)Axis.Max] { CTxtAxisConveyorrState, CTxtAxisConveyorrState };
                //for (int i = 0; i < (int)Axis.Max; i++)
                //{
                //    txtState[i].Text = m_ArmControler.ReadAxisStateString((Axis)i);
                //}
            }

            //二维码
            if (m_QRCode != null && m_QRCode.m_IsConnect)
            {
                lock (this)
                {
                    if (m_QRCode.m_ReadQueue.Count > 0)
                        ComBoxQRCodeReadShow.Text += m_QRCode.m_ReadQueue.Dequeue();
                }
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

        private void tabControlManualDebug_Selected(object sender, TabControlEventArgs e)
        {
            switch (tabControlManualDebug.SelectedIndex)
            {
                case 0:  //相机
                    break;
                case 1:  //四轴模组
                    {
                        //if (!m_GraspRobot.m_bInitBoard)
                        //    m_GraspRobot.InitMotionControler();

                        //if (m_GraspRobot.m_DeviceCount > 0)
                        //{
                        //    ComBoxMotionControlDevice.Items.Clear();
                        //    for (int i = 0; i < m_GraspRobot.m_DeviceCount; i++)
                        //    {
                        //        ComBoxMotionControlDevice.Items.Add(m_GraspRobot.m_CurAvailableDevs[i].DeviceName);
                        //        ComBoxMotionControlDevice.SelectedIndex = 0;
                        //    }
                        //}

                        //TimerMotionControlGetState.Start();
                    }
                    break;

                default: break;
            }

            if (tabControlManualDebug.SelectedIndex == 4)  //选择其他页时
                m_QRCode.QRCodeRecvDataEvent += new EventHandler(QRCodeRecvData);
            else
                m_QRCode.QRCodeRecvDataEvent -= new EventHandler(QRCodeRecvData);
        }
        public void InitUIControlEnableState()
        {
            //ArmControler
            bool ArmConnectState = m_ArmControler.IsBoardConnected(Board.Conveyor_Empty);
            if (CGroupBoxArmTowerLight.Enabled != ArmConnectState)
                CGroupBoxArmTowerLight.Enabled = ArmConnectState;

            if (CGroupBoxArmAireCyl.Enabled != ArmConnectState)
                CGroupBoxArmAireCyl.Enabled = ArmConnectState;

            if (CGroupBoxArmKeyIn.Enabled != ArmConnectState)
                CGroupBoxArmKeyIn.Enabled = ArmConnectState;

            if (CGrpAxisConveyor.Enabled != ArmConnectState)
                CGrpAxisConveyor.Enabled = ArmConnectState;

            //QRCode
            bool QRCodeConnectState = m_QRCode.m_IsConnect;
            if (CGroupBoxQRCode.Enabled != QRCodeConnectState)
                CGroupBoxQRCode.Enabled = QRCodeConnectState;

        }

        #region  //IO 控制

        private void BtnLampRedOn_Click(object sender, EventArgs e)
        {
            m_ArmControler.SetArmControlBoardIo(Board.Conveyor_Empty, ARM_OutputPoint.IO_OUT_LedRed, IOValue.IOValueHigh);
        }

        private void BtnLampRedOff_Click(object sender, EventArgs e)
        {
            m_ArmControler.SetArmControlBoardIo(Board.Conveyor_Empty, ARM_OutputPoint.IO_OUT_LedRed, IOValue.IOValueLow);
        }

        private void BtnLampOrangeOn_Click(object sender, EventArgs e)
        {
            m_ArmControler.SetArmControlBoardIo(Board.Conveyor_Empty, ARM_OutputPoint.IO_OUT_LedOriange, IOValue.IOValueHigh);
        }

        private void BtnLampOrangeOff_Click(object sender, EventArgs e)
        {
            m_ArmControler.SetArmControlBoardIo(Board.Conveyor_Empty, ARM_OutputPoint.IO_OUT_LedOriange, IOValue.IOValueLow);
        }

        private void BtnLampGreenOn_Click(object sender, EventArgs e)
        {
            m_ArmControler.SetArmControlBoardIo(Board.Conveyor_Empty, ARM_OutputPoint.IO_OUT_LedGreen, IOValue.IOValueHigh);
        }

        private void BtnLampGreenOff_Click(object sender, EventArgs e)
        {
            m_ArmControler.SetArmControlBoardIo(Board.Conveyor_Empty, ARM_OutputPoint.IO_OUT_LedGreen, IOValue.IOValueLow);
        }

        private void BtnLampBlueOn_Click(object sender, EventArgs e)
        {
            m_ArmControler.SetArmControlBoardIo(Board.Conveyor_Empty, ARM_OutputPoint.IO_OUT_LedBlue, IOValue.IOValueHigh);
        }

        private void BtnLampBlueOff_Click(object sender, EventArgs e)
        {
            m_ArmControler.SetArmControlBoardIo(Board.Conveyor_Empty, ARM_OutputPoint.IO_OUT_LedBlue, IOValue.IOValueLow);
        }

        private void BtnBeepOn_Click(object sender, EventArgs e)
        {
            m_ArmControler.SetArmControlBoardIo(Board.Conveyor_Empty, ARM_OutputPoint.IO_OUT_Beep, IOValue.IOValueHigh);
        }

        private void BtnBeepOff_Click(object sender, EventArgs e)
        {
            m_ArmControler.SetArmControlBoardIo(Board.Conveyor_Empty, ARM_OutputPoint.IO_OUT_Beep, IOValue.IOValueLow);
        }

        private void CButtonEmptySalverObstructUp_Click(object sender, EventArgs e)
        {
           
        }

        private void CButtonEmptySalverObstructDown_Click(object sender, EventArgs e)
        {
           
        }

        private void CButtonIoEmptySalverLiftingUp_Click(object sender, EventArgs e)
        {
           
        }

        private void CButtonIoEmptySalverLiftingDown_Click(object sender, EventArgs e)
        {
           
        }

        private void CButtonConveyorUp_Click(object sender, EventArgs e)
        {
            
        }

        private void CButtonConveyorDown_Click(object sender, EventArgs e)
        {
            
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
            //SetSpeedParamConveyorAxis(Axis.Conveyor, velStart, velRun, velAdd, velDec, Default);
        }

        private void CBtnAxisConveyorMoveForward_Click(object sender, EventArgs e)
        {
            //Axis AxisIndex = Axis.Conveyor;
            //m_ArmControler.ResetError(AxisIndex);
            //SetConveyorAxisParamWithInput(false);
            //m_ArmControler.MoveContinuous(AxisIndex, AxisDir.Forward);
        }

        private void CBtnAxisConveyorMoveReverse_Click(object sender, EventArgs e)
        {
            ////Axis AxisIndex = Axis.Conveyor;
            //m_ArmControler.ResetError(AxisIndex);
            //SetConveyorAxisParamWithInput(false);
            //m_ArmControler.MoveContinuous(AxisIndex, AxisDir.Reverse);
        }

        private void CBtnAxisConveyorStop_Click(object sender, EventArgs e)
        {
            ////Axis AxisIndex = Axis.Conveyor;
            //m_ArmControler.ResetError(AxisIndex);
            //m_ArmControler.Stop(AxisIndex);
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
            //Axis AxisIndex = Axis.Conveyor;
            //MoveMaual(AxisIndex, CTxtAxisConveyorrStepPpu, true);
        }

        private void BtnAxisConveyorDec_Click(object sender, EventArgs e)
        {
            //Axis AxisIndex = Axis.Conveyor;
            //MoveMaual(AxisIndex, CTxtAxisConveyorrStepPpu, false);
        }

        private void BtnAxisConveyorResetError_Click(object sender, EventArgs e)
        {
            //Axis AxisIndex = Axis.Conveyor;
            //m_ArmControler.ResetError(AxisIndex);
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

        #region //四轴模组机器人

        private void CButtonSetMotionControlSpeedParam_Click(object sender, EventArgs e)
        {
            double AxVelLow = double.Parse(CTextBoxMotionControLowSpeed.Text);
            double AxVelHigh = double.Parse(CTextBoxMotionControHighSpeed.Text);
            double AxVelAcc = double.Parse(CTextBoxMotionControAccSpeed.Text);
            double AxVelDec = double.Parse(CTextBoxMotionControDecSpeed.Text);
            int AxDistance = int.Parse(CTextBoxMotionControlDistance.Text);

            if (m_GraspRobot.m_IsConnected)
            {
                m_GraspRobot.m_Distance = AxDistance;
                m_GraspRobot.SetSpeed((AxisNum)ComBoxGraspRobotAxis.SelectedIndex, AxVelLow, AxVelHigh, AxVelAcc, AxVelDec);
            }
        }

        private void CButtonRobotMoveLift_Click(object sender, EventArgs e)
        {
            if (m_GraspRobot.m_IsConnected)
            {
                m_GraspRobot.MoveAxis(AxisNum.Axis_X, AxisRunDir.Dir_Forward);
            }
        }

        private void CButtonRobotMoveRight_Click(object sender, EventArgs e)
        {
            if (m_GraspRobot.m_IsConnected)
            {
                m_GraspRobot.MoveAxis(AxisNum.Axis_X, AxisRunDir.Dir_Reverse);
            }
        }

        private void CButtonRobotMoveForward_Click(object sender, EventArgs e)
        {
            if (m_GraspRobot.m_IsConnected)
            {
                m_GraspRobot.MoveAxis(AxisNum.Axis_Y, AxisRunDir.Dir_Forward);
            }
        }

        private void CButtonRobotMoveBack_Click(object sender, EventArgs e)
        {
            if (m_GraspRobot.m_IsConnected)
            {
                m_GraspRobot.MoveAxis(AxisNum.Axis_Y, AxisRunDir.Dir_Reverse);
            }
        }

        private void CButtonRobotMoveUp_Click(object sender, EventArgs e)
        {
            if (m_GraspRobot.m_IsConnected)
            {
                m_GraspRobot.MoveAxis(AxisNum.Axis_Z, AxisRunDir.Dir_Forward);
            }
        }

        private void CButtonMotionControlDown_Click(object sender, EventArgs e)
        {
            if (m_GraspRobot.m_IsConnected)
            {
                m_GraspRobot.MoveAxis(AxisNum.Axis_Z, AxisRunDir.Dir_Reverse);
            }
        }

        //抓件
        private void CButtonRobotGrasp_Click(object sender, EventArgs e)
        {
            //if (m_GraspRobot.m_bInitBoard)
            //{
            //    m_GraspRobot.MoveMotion(GraspRobot.AxisNum.Axis_Z, false);

            //    //启动吸嘴
            //    Thread.Sleep(500);

            //    m_GraspRobot.MoveMotion(GraspRobot.AxisNum.Axis_Z, true);
            //}
        }

        //抓盘
        private void CButtonRobotGrapSalver_Click(object sender, EventArgs e)
        {

        }

        private void CButtonMotionAxisRunNeg_Click(object sender, EventArgs e)
        {

        }

        private void CButtonMotionAxisRunPos_Click(object sender, EventArgs e)
        {

        }

        private void CButtonMotionAxisHome_Click(object sender, EventArgs e)
        {

        }

        private void CButtonMotionAxisStop_Click(object sender, EventArgs e)
        {

        }

        private void CButtonMotionControlResetError_Click(object sender, EventArgs e)
        {
            if (m_GraspRobot != null && m_GraspRobot.m_IsConnected)
            {
                for (int i = 0; i < (int)AxisNum.Axis_Total; i++)
                {
                    m_GraspRobot.ResetError((AxisNum)i);
                }
            }
        }

        #endregion

        #region //二维码
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

                bool Check = WorkStation.CheckAndSaveQRCodeReadData(Temp.QRCodeRecv);
                if (Check)
                {
                    WorkStation.m_ScanQRCode = true;
                }
                else
                {
                    WorkStation.m_ScanQRCode = false;
                    //再次扫描
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
    }
}
