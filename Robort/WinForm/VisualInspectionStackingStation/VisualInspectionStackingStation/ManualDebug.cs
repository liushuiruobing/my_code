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
        private RFID m_RFID = RFID.GetInstance();
        private ArmControler m_ArmControler = ArmControler.GetInstance();

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

            //RFID
            if (m_RFID.IsConnected)
            {
                if (DataStruct.SysStat.ManualDebugReceiveSalverArrive)
                {
                    PicTrayDeviceInRFID.Image = bmpGreen;
                    CTextBoxTrayDeviceRfidSn.Text = WorkStation.m_RfidRead;
                }
                else
                {
                    PicTrayDeviceInRFID.Image = bmpDarkGreen;
                    CTextBoxTrayDeviceRfidSn.Text = "";
                }
            }

            //按键
            PicKeyRun.Image = DataStruct.SysStat.KeyRun ? bmpGreen : bmpDarkGreen;
            PicKeyPause.Image = DataStruct.SysStat.KeyPause ? bmpGreen : bmpDarkGreen;
            PicKeyStop.Image = DataStruct.SysStat.KeyStop ? bmpGreen : bmpDarkGreen;
            PicKeyReset.Image = DataStruct.SysStat.KeyReset ? bmpGreen : bmpDarkGreen;

            if (m_ArmControler.IsBoardConnected(Board.Controler))
            {
                CTxtAxisConveyorCurPos.Text = Convert.ToString(m_ArmControler.ReadAxisPostion(Axis.Conveyor));

                TextBox[] txtState = new TextBox[(int)Axis.Max] { CTxtAxisConveyorrState, CTxtAxisTurnOverState };
                for (int i = 0; i < (int)Axis.Max; i++)
                {
                    txtState[i].Text = m_ArmControler.ReadAxisStateString((Axis)i);
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

        public void InitUIControlEnableState()
        {
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
