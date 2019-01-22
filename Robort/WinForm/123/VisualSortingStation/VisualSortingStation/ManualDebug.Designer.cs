namespace RobotWorkstation
{
    partial class ManualDebugForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.TimerInitRobotGlobalPointDGV = new System.Windows.Forms.Timer(this.components);
            this.RefreshTimer = new System.Windows.Forms.Timer(this.components);
            this.OpenFileDialogMotionControlLoadCfg = new System.Windows.Forms.OpenFileDialog();
            this.TimerRobotTestRunAction = new System.Windows.Forms.Timer(this.components);
            this.tabControlManualDebug = new RobotWorkstation.CustomTabControl();
            this.tabPageRobot = new System.Windows.Forms.TabPage();
            this.customGroupBoxRobotGrap = new RobotWorkstation.CustomGroupBox();
            this.CBtnRobotPut = new RobotWorkstation.CustomButton();
            this.CBtnRobotGrap = new RobotWorkstation.CustomButton();
            this.CBtnRobotGrapBack = new RobotWorkstation.CustomButton();
            this.CBtnRobotGrapGo = new RobotWorkstation.CustomButton();
            this.PicBoxRobotGrapVacuumCheck = new System.Windows.Forms.PictureBox();
            this.customLabel53 = new RobotWorkstation.CustomLabel();
            this.PicBoxRobotGrapBackArrive = new System.Windows.Forms.PictureBox();
            this.CLabelRobotGrapBackArrive = new RobotWorkstation.CustomLabel();
            this.PicBoxRobotGrapGoArrive = new System.Windows.Forms.PictureBox();
            this.CLabelRobotGrapGoArrive = new RobotWorkstation.CustomLabel();
            this.groupBoxRobot = new RobotWorkstation.CustomGroupBox();
            this.CBtnRobotTestTurnOver = new RobotWorkstation.CustomButton();
            this.CBtnRobotTestRunAction = new RobotWorkstation.CustomButton();
            this.ComBoxRobotActions = new System.Windows.Forms.ComboBox();
            this.CBtnRobotTestTeachPoint = new RobotWorkstation.CustomButton();
            this.CBtnRobotTestMoveToPoint = new RobotWorkstation.CustomButton();
            this.customLabel19 = new RobotWorkstation.CustomLabel();
            this.CBtnRobotTestReadPoint = new RobotWorkstation.CustomButton();
            this.CTabControlBorderRobotTestPoints = new RobotWorkstation.CustomTabControlBorder();
            this.PageRobotTestGlobalPoint = new System.Windows.Forms.TabPage();
            this.DGV_RobotGlobalPoint = new System.Windows.Forms.DataGridView();
            this.RobotTestName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RobotTestX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RobotTestY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RobotTestZ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RobotTestRZ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RobotTestHand = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RobotTestUserID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RobotTestToolID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PageRobotTestUserFrame = new System.Windows.Forms.TabPage();
            this.PageRobotTestToolFrame = new System.Windows.Forms.TabPage();
            this.PageRobotTestWorkSpace = new System.Windows.Forms.TabPage();
            this.CButtonRobotDistanceRZSub = new RobotWorkstation.CustomButton();
            this.CButtonRobotDistanceRZAdd = new RobotWorkstation.CustomButton();
            this.CTextBoxRobotDistanceRZ = new RobotWorkstation.CustomTextBox();
            this.customLabel15 = new RobotWorkstation.CustomLabel();
            this.CButtonRobotDistanceZSub = new RobotWorkstation.CustomButton();
            this.CButtonRobotDistanceZAdd = new RobotWorkstation.CustomButton();
            this.CTextBoxRobotDistanceZ = new RobotWorkstation.CustomTextBox();
            this.customLabel16 = new RobotWorkstation.CustomLabel();
            this.CButtonRobotDistanceYSub = new RobotWorkstation.CustomButton();
            this.CButtonRobotDistanceYAdd = new RobotWorkstation.CustomButton();
            this.CTextBoxRobotDistanceY = new RobotWorkstation.CustomTextBox();
            this.customLabel17 = new RobotWorkstation.CustomLabel();
            this.CButtonRobotDistanceXSub = new RobotWorkstation.CustomButton();
            this.CButtonRobotDistanceXAdd = new RobotWorkstation.CustomButton();
            this.CTextBoxRobotDistanceX = new RobotWorkstation.CustomTextBox();
            this.customLabel18 = new RobotWorkstation.CustomLabel();
            this.CButtonRobotDistanceJ4Sub = new RobotWorkstation.CustomButton();
            this.CButtonRobotDistanceJ4Add = new RobotWorkstation.CustomButton();
            this.CTextBoxRobotDistanceJ4 = new RobotWorkstation.CustomTextBox();
            this.customLabel14 = new RobotWorkstation.CustomLabel();
            this.CButtonRobotDistanceJ3Sub = new RobotWorkstation.CustomButton();
            this.CButtonRobotDistanceJ3Add = new RobotWorkstation.CustomButton();
            this.CTextBoxRobotDistanceJ3 = new RobotWorkstation.CustomTextBox();
            this.customLabel13 = new RobotWorkstation.CustomLabel();
            this.CButtonRobotDistanceJ2Sub = new RobotWorkstation.CustomButton();
            this.CButtonRobotDistanceJ2Add = new RobotWorkstation.CustomButton();
            this.CTextBoxRobotDistanceJ2 = new RobotWorkstation.CustomTextBox();
            this.customLabel12 = new RobotWorkstation.CustomLabel();
            this.CButtonRobotDistanceJ1Sub = new RobotWorkstation.CustomButton();
            this.CButtonRobotDistanceJ1Add = new RobotWorkstation.CustomButton();
            this.CTextBoxRobotDistanceJ1 = new RobotWorkstation.CustomTextBox();
            this.customLabel11 = new RobotWorkstation.CustomLabel();
            this.radioButtonRobotDeviceContinuous = new System.Windows.Forms.RadioButton();
            this.radioButtonRobotDeviceJog = new System.Windows.Forms.RadioButton();
            this.customLabel9 = new RobotWorkstation.CustomLabel();
            this.CTextBoxRobotMoveSpeed = new RobotWorkstation.CustomTextBox();
            this.customLabel8 = new RobotWorkstation.CustomLabel();
            this.customLabel7 = new RobotWorkstation.CustomLabel();
            this.CTextBoxJogDistanceUm = new RobotWorkstation.CustomTextBox();
            this.customLabel6 = new RobotWorkstation.CustomLabel();
            this.CTextBoxJogDistance = new RobotWorkstation.CustomTextBox();
            this.customLabel5 = new RobotWorkstation.CustomLabel();
            this.pictureBoxRobotMove = new System.Windows.Forms.PictureBox();
            this.customLabel4 = new RobotWorkstation.CustomLabel();
            this.pictureBoxTemperature = new System.Windows.Forms.PictureBox();
            this.customLabel3 = new RobotWorkstation.CustomLabel();
            this.CButtonRobotExecStop = new RobotWorkstation.CustomButton();
            this.CButtonRobotExecPause = new RobotWorkstation.CustomButton();
            this.CButtonRobotExecRun = new RobotWorkstation.CustomButton();
            this.pictureBoxRobotExecut = new System.Windows.Forms.PictureBox();
            this.customLabel2 = new RobotWorkstation.CustomLabel();
            this.CButtonReset = new RobotWorkstation.CustomButton();
            this.pictureBoxRobotAlarm = new System.Windows.Forms.PictureBox();
            this.customLabel1 = new RobotWorkstation.CustomLabel();
            this.CButtonServoOff = new RobotWorkstation.CustomButton();
            this.CBttonServoOn = new RobotWorkstation.CustomButton();
            this.pictureBoxServo = new System.Windows.Forms.PictureBox();
            this.tabPageOthers = new System.Windows.Forms.TabPage();
            this.CGrpTurnOver = new RobotWorkstation.CustomGroupBox();
            this.CBtnTurnOverAxisErrorReset = new RobotWorkstation.CustomButton();
            this.CTxtAxisTurnOverState = new RobotWorkstation.CustomTextBox();
            this.customLabel34 = new RobotWorkstation.CustomLabel();
            this.PicOverturnCylUnLock = new System.Windows.Forms.PictureBox();
            this.PicOverturnCylLock = new System.Windows.Forms.PictureBox();
            this.PicOverturn = new System.Windows.Forms.PictureBox();
            this.customLabel31 = new RobotWorkstation.CustomLabel();
            this.customLabel30 = new RobotWorkstation.CustomLabel();
            this.customLabel29 = new RobotWorkstation.CustomLabel();
            this.CBtnTurnOverReset = new RobotWorkstation.CustomButton();
            this.CBtnTurnOverLockCylClose = new RobotWorkstation.CustomButton();
            this.CBtnTurnOverLockCylOpen = new RobotWorkstation.CustomButton();
            this.CBtnTurnOver = new RobotWorkstation.CustomButton();
            this.CTxtAxisTurnOverStep = new RobotWorkstation.CustomTextBox();
            this.customLabel28 = new RobotWorkstation.CustomLabel();
            this.CTxtAxisTurnOverSpeed = new RobotWorkstation.CustomTextBox();
            this.customLabel27 = new RobotWorkstation.CustomLabel();
            this.CGrpAxisConveyor = new RobotWorkstation.CustomGroupBox();
            this.BtnAxisConveyorResetError = new RobotWorkstation.CustomButton();
            this.CTxtAxisConveyorrState = new RobotWorkstation.CustomTextBox();
            this.customLabel26 = new RobotWorkstation.CustomLabel();
            this.BtnAxisConveyorDec = new RobotWorkstation.CustomButton();
            this.BtnAxisConveyorAdd = new RobotWorkstation.CustomButton();
            this.CBtnAxisConveyorStop = new RobotWorkstation.CustomButton();
            this.CBtnAxisConveyorMoveReverse = new RobotWorkstation.CustomButton();
            this.CBtnAxisConveyorMoveForward = new RobotWorkstation.CustomButton();
            this.customLabel25 = new RobotWorkstation.CustomLabel();
            this.CTxtAxisConveyorrStepPpu = new RobotWorkstation.CustomTextBox();
            this.customLabel22 = new RobotWorkstation.CustomLabel();
            this.CTxtAxisConveyorSpeedDec = new RobotWorkstation.CustomTextBox();
            this.customLabel23 = new RobotWorkstation.CustomLabel();
            this.CTxtAxisConveyorSpeedAdd = new RobotWorkstation.CustomTextBox();
            this.customLabel24 = new RobotWorkstation.CustomLabel();
            this.CTxtAxisConveyorCurPos = new RobotWorkstation.CustomTextBox();
            this.customLabel21 = new RobotWorkstation.CustomLabel();
            this.CTxtAxisConveyorSpeedRun = new RobotWorkstation.CustomTextBox();
            this.customLabel20 = new RobotWorkstation.CustomLabel();
            this.CTxtAxisConveyorSpeedStart = new RobotWorkstation.CustomTextBox();
            this.customLabel10 = new RobotWorkstation.CustomLabel();
            this.customGroupBox13 = new RobotWorkstation.CustomGroupBox();
            this.PicKeyReset = new System.Windows.Forms.PictureBox();
            this.PicKeyStop = new System.Windows.Forms.PictureBox();
            this.PicKeyPause = new System.Windows.Forms.PictureBox();
            this.PicKeyRun = new System.Windows.Forms.PictureBox();
            this.customLabel52 = new RobotWorkstation.CustomLabel();
            this.customLabel51 = new RobotWorkstation.CustomLabel();
            this.customLabel50 = new RobotWorkstation.CustomLabel();
            this.customLabel49 = new RobotWorkstation.CustomLabel();
            this.customGroupBox12 = new RobotWorkstation.CustomGroupBox();
            this.customLabel33 = new RobotWorkstation.CustomLabel();
            this.customLabel32 = new RobotWorkstation.CustomLabel();
            this.PicBoxEmptySalverDownArrive = new System.Windows.Forms.PictureBox();
            this.PicBoxEmptySalverUpArrive = new System.Windows.Forms.PictureBox();
            this.CButtonIoEmptyPlateUp = new RobotWorkstation.CustomButton();
            this.CButtonIoEmptyPlateDown = new RobotWorkstation.CustomButton();
            this.customGroupBox11 = new RobotWorkstation.CustomGroupBox();
            this.BtnBeepOff = new RobotWorkstation.CustomButton();
            this.BtnBeepOn = new RobotWorkstation.CustomButton();
            this.BtnLampBlueOff = new RobotWorkstation.CustomButton();
            this.BtnLampBlueOn = new RobotWorkstation.CustomButton();
            this.BtnLampGreenOff = new RobotWorkstation.CustomButton();
            this.BtnLampGreenOn = new RobotWorkstation.CustomButton();
            this.BtnLampOrangeOff = new RobotWorkstation.CustomButton();
            this.BtnLampOrangeOn = new RobotWorkstation.CustomButton();
            this.BtnLampRedOff = new RobotWorkstation.CustomButton();
            this.BtnLampRedOn = new RobotWorkstation.CustomButton();
            this.customGroupBox10 = new RobotWorkstation.CustomGroupBox();
            this.CTextBoxTrayDeviceRfidSn = new RobotWorkstation.CustomTextBox();
            this.customLabel48 = new RobotWorkstation.CustomLabel();
            this.PicTrayDeviceInRFID = new System.Windows.Forms.PictureBox();
            this.customLabel42 = new RobotWorkstation.CustomLabel();
            this.customGroupBox7 = new RobotWorkstation.CustomGroupBox();
            this.ComBoxQRCodeClear = new RobotWorkstation.CustomButton();
            this.customLabel47 = new RobotWorkstation.CustomLabel();
            this.ComBoxQRCodeReadShow = new RobotWorkstation.CustomTextBox();
            this.ComBoxQRCodeDisconnect = new RobotWorkstation.CustomButton();
            this.ComBoxQRCodeConnect = new RobotWorkstation.CustomButton();
            this.ComBoxQRCodeCom = new System.Windows.Forms.ComboBox();
            this.tabControlManualDebug.SuspendLayout();
            this.tabPageRobot.SuspendLayout();
            this.customGroupBoxRobotGrap.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxRobotGrapVacuumCheck)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxRobotGrapBackArrive)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxRobotGrapGoArrive)).BeginInit();
            this.groupBoxRobot.SuspendLayout();
            this.CTabControlBorderRobotTestPoints.SuspendLayout();
            this.PageRobotTestGlobalPoint.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_RobotGlobalPoint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRobotMove)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTemperature)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRobotExecut)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRobotAlarm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxServo)).BeginInit();
            this.tabPageOthers.SuspendLayout();
            this.CGrpTurnOver.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicOverturnCylUnLock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicOverturnCylLock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicOverturn)).BeginInit();
            this.CGrpAxisConveyor.SuspendLayout();
            this.customGroupBox13.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicKeyReset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicKeyStop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicKeyPause)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicKeyRun)).BeginInit();
            this.customGroupBox12.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxEmptySalverDownArrive)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxEmptySalverUpArrive)).BeginInit();
            this.customGroupBox11.SuspendLayout();
            this.customGroupBox10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicTrayDeviceInRFID)).BeginInit();
            this.customGroupBox7.SuspendLayout();
            this.SuspendLayout();
            // 
            // TimerInitRobotGlobalPointDGV
            // 
            this.TimerInitRobotGlobalPointDGV.Interval = 10;
            this.TimerInitRobotGlobalPointDGV.Tick += new System.EventHandler(this.timer_InitRobotGlobalPointDGV_Tick);
            // 
            // RefreshTimer
            // 
            this.RefreshTimer.Interval = 200;
            this.RefreshTimer.Tick += new System.EventHandler(this.RefreshTimer_Tick);
            // 
            // OpenFileDialogMotionControlLoadCfg
            // 
            this.OpenFileDialogMotionControlLoadCfg.FileName = "导入配置";
            // 
            // TimerRobotTestRunAction
            // 
            this.TimerRobotTestRunAction.Tick += new System.EventHandler(this.TimerRobotTestRunAction_Tick);
            // 
            // tabControlManualDebug
            // 
            this.tabControlManualDebug.Controls.Add(this.tabPageRobot);
            this.tabControlManualDebug.Controls.Add(this.tabPageOthers);
            this.tabControlManualDebug.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabControlManualDebug.ItemSize = new System.Drawing.Size(120, 26);
            this.tabControlManualDebug.Location = new System.Drawing.Point(16, 15);
            this.tabControlManualDebug.Margin = new System.Windows.Forms.Padding(0);
            this.tabControlManualDebug.Name = "tabControlManualDebug";
            this.tabControlManualDebug.Padding = new System.Drawing.Point(20, 3);
            this.tabControlManualDebug.SelectedIndex = 0;
            this.tabControlManualDebug.Size = new System.Drawing.Size(1664, 1022);
            this.tabControlManualDebug.TabIndex = 0;
            this.tabControlManualDebug.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabControlManualDebug_Selected);
            // 
            // tabPageRobot
            // 
            this.tabPageRobot.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.tabPageRobot.Controls.Add(this.customGroupBoxRobotGrap);
            this.tabPageRobot.Controls.Add(this.groupBoxRobot);
            this.tabPageRobot.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabPageRobot.Location = new System.Drawing.Point(0, 29);
            this.tabPageRobot.Margin = new System.Windows.Forms.Padding(4);
            this.tabPageRobot.Name = "tabPageRobot";
            this.tabPageRobot.Padding = new System.Windows.Forms.Padding(4);
            this.tabPageRobot.Size = new System.Drawing.Size(1664, 993);
            this.tabPageRobot.TabIndex = 0;
            this.tabPageRobot.Text = "机器人";
            // 
            // customGroupBoxRobotGrap
            // 
            this.customGroupBoxRobotGrap.Controls.Add(this.CBtnRobotPut);
            this.customGroupBoxRobotGrap.Controls.Add(this.CBtnRobotGrap);
            this.customGroupBoxRobotGrap.Controls.Add(this.CBtnRobotGrapBack);
            this.customGroupBoxRobotGrap.Controls.Add(this.CBtnRobotGrapGo);
            this.customGroupBoxRobotGrap.Controls.Add(this.PicBoxRobotGrapVacuumCheck);
            this.customGroupBoxRobotGrap.Controls.Add(this.customLabel53);
            this.customGroupBoxRobotGrap.Controls.Add(this.PicBoxRobotGrapBackArrive);
            this.customGroupBoxRobotGrap.Controls.Add(this.CLabelRobotGrapBackArrive);
            this.customGroupBoxRobotGrap.Controls.Add(this.PicBoxRobotGrapGoArrive);
            this.customGroupBoxRobotGrap.Controls.Add(this.CLabelRobotGrapGoArrive);
            this.customGroupBoxRobotGrap.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.customGroupBoxRobotGrap.Location = new System.Drawing.Point(8, 836);
            this.customGroupBoxRobotGrap.Margin = new System.Windows.Forms.Padding(4);
            this.customGroupBoxRobotGrap.Name = "customGroupBoxRobotGrap";
            this.customGroupBoxRobotGrap.Padding = new System.Windows.Forms.Padding(4);
            this.customGroupBoxRobotGrap.Size = new System.Drawing.Size(544, 142);
            this.customGroupBoxRobotGrap.TabIndex = 1;
            this.customGroupBoxRobotGrap.TabStop = false;
            this.customGroupBoxRobotGrap.Text = "抓手";
            // 
            // CBtnRobotPut
            // 
            this.CBtnRobotPut.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.CBtnRobotPut.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CBtnRobotPut.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.CBtnRobotPut.ForeColor = System.Drawing.Color.Transparent;
            this.CBtnRobotPut.Location = new System.Drawing.Point(407, 75);
            this.CBtnRobotPut.Margin = new System.Windows.Forms.Padding(4);
            this.CBtnRobotPut.Name = "CBtnRobotPut";
            this.CBtnRobotPut.Size = new System.Drawing.Size(120, 45);
            this.CBtnRobotPut.TabIndex = 24;
            this.CBtnRobotPut.Text = "放下";
            this.CBtnRobotPut.UseVisualStyleBackColor = false;
            this.CBtnRobotPut.Click += new System.EventHandler(this.CBtnRobotPut_Click);
            // 
            // CBtnRobotGrap
            // 
            this.CBtnRobotGrap.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.CBtnRobotGrap.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CBtnRobotGrap.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.CBtnRobotGrap.ForeColor = System.Drawing.Color.Transparent;
            this.CBtnRobotGrap.Location = new System.Drawing.Point(275, 75);
            this.CBtnRobotGrap.Margin = new System.Windows.Forms.Padding(4);
            this.CBtnRobotGrap.Name = "CBtnRobotGrap";
            this.CBtnRobotGrap.Size = new System.Drawing.Size(120, 45);
            this.CBtnRobotGrap.TabIndex = 23;
            this.CBtnRobotGrap.Text = "抓取";
            this.CBtnRobotGrap.UseVisualStyleBackColor = false;
            this.CBtnRobotGrap.Click += new System.EventHandler(this.CBtnRobotGrap_Click);
            // 
            // CBtnRobotGrapBack
            // 
            this.CBtnRobotGrapBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.CBtnRobotGrapBack.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CBtnRobotGrapBack.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.CBtnRobotGrapBack.ForeColor = System.Drawing.Color.Transparent;
            this.CBtnRobotGrapBack.Location = new System.Drawing.Point(143, 75);
            this.CBtnRobotGrapBack.Margin = new System.Windows.Forms.Padding(4);
            this.CBtnRobotGrapBack.Name = "CBtnRobotGrapBack";
            this.CBtnRobotGrapBack.Size = new System.Drawing.Size(120, 45);
            this.CBtnRobotGrapBack.TabIndex = 22;
            this.CBtnRobotGrapBack.Text = "后退";
            this.CBtnRobotGrapBack.UseVisualStyleBackColor = false;
            this.CBtnRobotGrapBack.Click += new System.EventHandler(this.CBtnRobotGrapBack_Click);
            // 
            // CBtnRobotGrapGo
            // 
            this.CBtnRobotGrapGo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.CBtnRobotGrapGo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CBtnRobotGrapGo.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.CBtnRobotGrapGo.ForeColor = System.Drawing.Color.Transparent;
            this.CBtnRobotGrapGo.Location = new System.Drawing.Point(11, 75);
            this.CBtnRobotGrapGo.Margin = new System.Windows.Forms.Padding(4);
            this.CBtnRobotGrapGo.Name = "CBtnRobotGrapGo";
            this.CBtnRobotGrapGo.Size = new System.Drawing.Size(120, 45);
            this.CBtnRobotGrapGo.TabIndex = 21;
            this.CBtnRobotGrapGo.Text = "前进";
            this.CBtnRobotGrapGo.UseVisualStyleBackColor = false;
            this.CBtnRobotGrapGo.Click += new System.EventHandler(this.CBtnRobotGrapGo_Click);
            // 
            // PicBoxRobotGrapVacuumCheck
            // 
            this.PicBoxRobotGrapVacuumCheck.Image = global::RobotWorkstation.Properties.Resources.SmallDarkGreen;
            this.PicBoxRobotGrapVacuumCheck.Location = new System.Drawing.Point(369, 41);
            this.PicBoxRobotGrapVacuumCheck.Margin = new System.Windows.Forms.Padding(4);
            this.PicBoxRobotGrapVacuumCheck.Name = "PicBoxRobotGrapVacuumCheck";
            this.PicBoxRobotGrapVacuumCheck.Size = new System.Drawing.Size(29, 28);
            this.PicBoxRobotGrapVacuumCheck.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PicBoxRobotGrapVacuumCheck.TabIndex = 20;
            this.PicBoxRobotGrapVacuumCheck.TabStop = false;
            // 
            // customLabel53
            // 
            this.customLabel53.AutoSize = true;
            this.customLabel53.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.customLabel53.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.customLabel53.Location = new System.Drawing.Point(295, 39);
            this.customLabel53.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.customLabel53.Name = "customLabel53";
            this.customLabel53.Size = new System.Drawing.Size(75, 28);
            this.customLabel53.TabIndex = 19;
            this.customLabel53.Text = "真空：";
            // 
            // PicBoxRobotGrapBackArrive
            // 
            this.PicBoxRobotGrapBackArrive.Image = global::RobotWorkstation.Properties.Resources.SmallDarkGreen;
            this.PicBoxRobotGrapBackArrive.Location = new System.Drawing.Point(237, 41);
            this.PicBoxRobotGrapBackArrive.Margin = new System.Windows.Forms.Padding(4);
            this.PicBoxRobotGrapBackArrive.Name = "PicBoxRobotGrapBackArrive";
            this.PicBoxRobotGrapBackArrive.Size = new System.Drawing.Size(29, 28);
            this.PicBoxRobotGrapBackArrive.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PicBoxRobotGrapBackArrive.TabIndex = 18;
            this.PicBoxRobotGrapBackArrive.TabStop = false;
            // 
            // CLabelRobotGrapBackArrive
            // 
            this.CLabelRobotGrapBackArrive.AutoSize = true;
            this.CLabelRobotGrapBackArrive.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.CLabelRobotGrapBackArrive.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.CLabelRobotGrapBackArrive.Location = new System.Drawing.Point(143, 40);
            this.CLabelRobotGrapBackArrive.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.CLabelRobotGrapBackArrive.Name = "CLabelRobotGrapBackArrive";
            this.CLabelRobotGrapBackArrive.Size = new System.Drawing.Size(96, 28);
            this.CLabelRobotGrapBackArrive.TabIndex = 17;
            this.CLabelRobotGrapBackArrive.Text = "退到位：";
            // 
            // PicBoxRobotGrapGoArrive
            // 
            this.PicBoxRobotGrapGoArrive.Image = global::RobotWorkstation.Properties.Resources.SmallDarkGreen;
            this.PicBoxRobotGrapGoArrive.Location = new System.Drawing.Point(101, 40);
            this.PicBoxRobotGrapGoArrive.Margin = new System.Windows.Forms.Padding(4);
            this.PicBoxRobotGrapGoArrive.Name = "PicBoxRobotGrapGoArrive";
            this.PicBoxRobotGrapGoArrive.Size = new System.Drawing.Size(29, 28);
            this.PicBoxRobotGrapGoArrive.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PicBoxRobotGrapGoArrive.TabIndex = 16;
            this.PicBoxRobotGrapGoArrive.TabStop = false;
            // 
            // CLabelRobotGrapGoArrive
            // 
            this.CLabelRobotGrapGoArrive.AutoSize = true;
            this.CLabelRobotGrapGoArrive.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.CLabelRobotGrapGoArrive.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.CLabelRobotGrapGoArrive.Location = new System.Drawing.Point(11, 39);
            this.CLabelRobotGrapGoArrive.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.CLabelRobotGrapGoArrive.Name = "CLabelRobotGrapGoArrive";
            this.CLabelRobotGrapGoArrive.Size = new System.Drawing.Size(96, 28);
            this.CLabelRobotGrapGoArrive.TabIndex = 0;
            this.CLabelRobotGrapGoArrive.Text = "进到位：";
            // 
            // groupBoxRobot
            // 
            this.groupBoxRobot.Controls.Add(this.CBtnRobotTestTurnOver);
            this.groupBoxRobot.Controls.Add(this.CBtnRobotTestRunAction);
            this.groupBoxRobot.Controls.Add(this.ComBoxRobotActions);
            this.groupBoxRobot.Controls.Add(this.CBtnRobotTestTeachPoint);
            this.groupBoxRobot.Controls.Add(this.CBtnRobotTestMoveToPoint);
            this.groupBoxRobot.Controls.Add(this.customLabel19);
            this.groupBoxRobot.Controls.Add(this.CBtnRobotTestReadPoint);
            this.groupBoxRobot.Controls.Add(this.CTabControlBorderRobotTestPoints);
            this.groupBoxRobot.Controls.Add(this.CButtonRobotDistanceRZSub);
            this.groupBoxRobot.Controls.Add(this.CButtonRobotDistanceRZAdd);
            this.groupBoxRobot.Controls.Add(this.CTextBoxRobotDistanceRZ);
            this.groupBoxRobot.Controls.Add(this.customLabel15);
            this.groupBoxRobot.Controls.Add(this.CButtonRobotDistanceZSub);
            this.groupBoxRobot.Controls.Add(this.CButtonRobotDistanceZAdd);
            this.groupBoxRobot.Controls.Add(this.CTextBoxRobotDistanceZ);
            this.groupBoxRobot.Controls.Add(this.customLabel16);
            this.groupBoxRobot.Controls.Add(this.CButtonRobotDistanceYSub);
            this.groupBoxRobot.Controls.Add(this.CButtonRobotDistanceYAdd);
            this.groupBoxRobot.Controls.Add(this.CTextBoxRobotDistanceY);
            this.groupBoxRobot.Controls.Add(this.customLabel17);
            this.groupBoxRobot.Controls.Add(this.CButtonRobotDistanceXSub);
            this.groupBoxRobot.Controls.Add(this.CButtonRobotDistanceXAdd);
            this.groupBoxRobot.Controls.Add(this.CTextBoxRobotDistanceX);
            this.groupBoxRobot.Controls.Add(this.customLabel18);
            this.groupBoxRobot.Controls.Add(this.CButtonRobotDistanceJ4Sub);
            this.groupBoxRobot.Controls.Add(this.CButtonRobotDistanceJ4Add);
            this.groupBoxRobot.Controls.Add(this.CTextBoxRobotDistanceJ4);
            this.groupBoxRobot.Controls.Add(this.customLabel14);
            this.groupBoxRobot.Controls.Add(this.CButtonRobotDistanceJ3Sub);
            this.groupBoxRobot.Controls.Add(this.CButtonRobotDistanceJ3Add);
            this.groupBoxRobot.Controls.Add(this.CTextBoxRobotDistanceJ3);
            this.groupBoxRobot.Controls.Add(this.customLabel13);
            this.groupBoxRobot.Controls.Add(this.CButtonRobotDistanceJ2Sub);
            this.groupBoxRobot.Controls.Add(this.CButtonRobotDistanceJ2Add);
            this.groupBoxRobot.Controls.Add(this.CTextBoxRobotDistanceJ2);
            this.groupBoxRobot.Controls.Add(this.customLabel12);
            this.groupBoxRobot.Controls.Add(this.CButtonRobotDistanceJ1Sub);
            this.groupBoxRobot.Controls.Add(this.CButtonRobotDistanceJ1Add);
            this.groupBoxRobot.Controls.Add(this.CTextBoxRobotDistanceJ1);
            this.groupBoxRobot.Controls.Add(this.customLabel11);
            this.groupBoxRobot.Controls.Add(this.radioButtonRobotDeviceContinuous);
            this.groupBoxRobot.Controls.Add(this.radioButtonRobotDeviceJog);
            this.groupBoxRobot.Controls.Add(this.customLabel9);
            this.groupBoxRobot.Controls.Add(this.CTextBoxRobotMoveSpeed);
            this.groupBoxRobot.Controls.Add(this.customLabel8);
            this.groupBoxRobot.Controls.Add(this.customLabel7);
            this.groupBoxRobot.Controls.Add(this.CTextBoxJogDistanceUm);
            this.groupBoxRobot.Controls.Add(this.customLabel6);
            this.groupBoxRobot.Controls.Add(this.CTextBoxJogDistance);
            this.groupBoxRobot.Controls.Add(this.customLabel5);
            this.groupBoxRobot.Controls.Add(this.pictureBoxRobotMove);
            this.groupBoxRobot.Controls.Add(this.customLabel4);
            this.groupBoxRobot.Controls.Add(this.pictureBoxTemperature);
            this.groupBoxRobot.Controls.Add(this.customLabel3);
            this.groupBoxRobot.Controls.Add(this.CButtonRobotExecStop);
            this.groupBoxRobot.Controls.Add(this.CButtonRobotExecPause);
            this.groupBoxRobot.Controls.Add(this.CButtonRobotExecRun);
            this.groupBoxRobot.Controls.Add(this.pictureBoxRobotExecut);
            this.groupBoxRobot.Controls.Add(this.customLabel2);
            this.groupBoxRobot.Controls.Add(this.CButtonReset);
            this.groupBoxRobot.Controls.Add(this.pictureBoxRobotAlarm);
            this.groupBoxRobot.Controls.Add(this.customLabel1);
            this.groupBoxRobot.Controls.Add(this.CButtonServoOff);
            this.groupBoxRobot.Controls.Add(this.CBttonServoOn);
            this.groupBoxRobot.Controls.Add(this.pictureBoxServo);
            this.groupBoxRobot.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxRobot.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBoxRobot.ForeColor = System.Drawing.Color.White;
            this.groupBoxRobot.Location = new System.Drawing.Point(4, 4);
            this.groupBoxRobot.Margin = new System.Windows.Forms.Padding(4);
            this.groupBoxRobot.Name = "groupBoxRobot";
            this.groupBoxRobot.Padding = new System.Windows.Forms.Padding(4);
            this.groupBoxRobot.Size = new System.Drawing.Size(1656, 825);
            this.groupBoxRobot.TabIndex = 0;
            this.groupBoxRobot.TabStop = false;
            this.groupBoxRobot.Text = "机器人";
            // 
            // CBtnRobotTestTurnOver
            // 
            this.CBtnRobotTestTurnOver.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.CBtnRobotTestTurnOver.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CBtnRobotTestTurnOver.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.CBtnRobotTestTurnOver.ForeColor = System.Drawing.Color.Transparent;
            this.CBtnRobotTestTurnOver.Location = new System.Drawing.Point(1413, 764);
            this.CBtnRobotTestTurnOver.Margin = new System.Windows.Forms.Padding(4);
            this.CBtnRobotTestTurnOver.Name = "CBtnRobotTestTurnOver";
            this.CBtnRobotTestTurnOver.Size = new System.Drawing.Size(120, 45);
            this.CBtnRobotTestTurnOver.TabIndex = 67;
            this.CBtnRobotTestTurnOver.Text = "翻转";
            this.CBtnRobotTestTurnOver.UseVisualStyleBackColor = false;
            this.CBtnRobotTestTurnOver.Click += new System.EventHandler(this.CBtnRobotTestTurnOver_Click);
            // 
            // CBtnRobotTestRunAction
            // 
            this.CBtnRobotTestRunAction.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.CBtnRobotTestRunAction.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CBtnRobotTestRunAction.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.CBtnRobotTestRunAction.ForeColor = System.Drawing.Color.Transparent;
            this.CBtnRobotTestRunAction.Location = new System.Drawing.Point(1285, 764);
            this.CBtnRobotTestRunAction.Margin = new System.Windows.Forms.Padding(4);
            this.CBtnRobotTestRunAction.Name = "CBtnRobotTestRunAction";
            this.CBtnRobotTestRunAction.Size = new System.Drawing.Size(120, 45);
            this.CBtnRobotTestRunAction.TabIndex = 66;
            this.CBtnRobotTestRunAction.Text = "执行动作";
            this.CBtnRobotTestRunAction.UseVisualStyleBackColor = false;
            this.CBtnRobotTestRunAction.Click += new System.EventHandler(this.CBtnRobotTestRunAction_Click);
            // 
            // ComBoxRobotActions
            // 
            this.ComBoxRobotActions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.ComBoxRobotActions.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ComBoxRobotActions.ForeColor = System.Drawing.Color.White;
            this.ComBoxRobotActions.FormattingEnabled = true;
            this.ComBoxRobotActions.Items.AddRange(new object[] {
            "抓取器件 1 扫码放置",
            "抓取器件 2 扫码放置",
            "抓取器件 3 扫码放置",
            "抓取器件 4 扫码放置",
            "抓取器件 5 扫码放置",
            "抓取器件 6 扫码放置",
            "抓取器件 7 扫码放置",
            "抓取器件 8 扫码放置",
            "抓取器件 9 扫码放置",
            "抓取器件 10 扫码放置",
            "抓取器件 11 扫码放置",
            "抓取器件 12 扫码放置",
            "抓取器件 13 扫码放置",
            "抓取器件 14 扫码放置",
            "抓取器件 15 扫码放置",
            "抓取器件 16 扫码放置"});
            this.ComBoxRobotActions.Location = new System.Drawing.Point(1007, 769);
            this.ComBoxRobotActions.Margin = new System.Windows.Forms.Padding(4);
            this.ComBoxRobotActions.Name = "ComBoxRobotActions";
            this.ComBoxRobotActions.Size = new System.Drawing.Size(269, 35);
            this.ComBoxRobotActions.TabIndex = 65;
            // 
            // CBtnRobotTestTeachPoint
            // 
            this.CBtnRobotTestTeachPoint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.CBtnRobotTestTeachPoint.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CBtnRobotTestTeachPoint.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.CBtnRobotTestTeachPoint.ForeColor = System.Drawing.Color.Transparent;
            this.CBtnRobotTestTeachPoint.Location = new System.Drawing.Point(828, 765);
            this.CBtnRobotTestTeachPoint.Margin = new System.Windows.Forms.Padding(4);
            this.CBtnRobotTestTeachPoint.Name = "CBtnRobotTestTeachPoint";
            this.CBtnRobotTestTeachPoint.Size = new System.Drawing.Size(120, 45);
            this.CBtnRobotTestTeachPoint.TabIndex = 63;
            this.CBtnRobotTestTeachPoint.Text = "学习点位";
            this.CBtnRobotTestTeachPoint.UseVisualStyleBackColor = false;
            this.CBtnRobotTestTeachPoint.Click += new System.EventHandler(this.CBtnRobotTestTeachPoint_Click);
            // 
            // CBtnRobotTestMoveToPoint
            // 
            this.CBtnRobotTestMoveToPoint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.CBtnRobotTestMoveToPoint.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CBtnRobotTestMoveToPoint.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.CBtnRobotTestMoveToPoint.ForeColor = System.Drawing.Color.Transparent;
            this.CBtnRobotTestMoveToPoint.Location = new System.Drawing.Point(699, 765);
            this.CBtnRobotTestMoveToPoint.Margin = new System.Windows.Forms.Padding(4);
            this.CBtnRobotTestMoveToPoint.Name = "CBtnRobotTestMoveToPoint";
            this.CBtnRobotTestMoveToPoint.Size = new System.Drawing.Size(120, 45);
            this.CBtnRobotTestMoveToPoint.TabIndex = 62;
            this.CBtnRobotTestMoveToPoint.Text = "移到点位";
            this.CBtnRobotTestMoveToPoint.UseVisualStyleBackColor = false;
            this.CBtnRobotTestMoveToPoint.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CBtnRobotTestMoveToPoint_MouseDown);
            this.CBtnRobotTestMoveToPoint.MouseUp += new System.Windows.Forms.MouseEventHandler(this.CBtnRobotTestMoveToPoint_MouseUp);
            // 
            // customLabel19
            // 
            this.customLabel19.AutoSize = true;
            this.customLabel19.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.customLabel19.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.customLabel19.Location = new System.Drawing.Point(27, 44);
            this.customLabel19.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.customLabel19.Name = "customLabel19";
            this.customLabel19.Size = new System.Drawing.Size(75, 28);
            this.customLabel19.TabIndex = 61;
            this.customLabel19.Text = "伺服：";
            // 
            // CBtnRobotTestReadPoint
            // 
            this.CBtnRobotTestReadPoint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.CBtnRobotTestReadPoint.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CBtnRobotTestReadPoint.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.CBtnRobotTestReadPoint.ForeColor = System.Drawing.Color.Transparent;
            this.CBtnRobotTestReadPoint.Location = new System.Drawing.Point(569, 765);
            this.CBtnRobotTestReadPoint.Margin = new System.Windows.Forms.Padding(4);
            this.CBtnRobotTestReadPoint.Name = "CBtnRobotTestReadPoint";
            this.CBtnRobotTestReadPoint.Size = new System.Drawing.Size(120, 45);
            this.CBtnRobotTestReadPoint.TabIndex = 60;
            this.CBtnRobotTestReadPoint.Text = "读取点位";
            this.CBtnRobotTestReadPoint.UseVisualStyleBackColor = false;
            this.CBtnRobotTestReadPoint.Click += new System.EventHandler(this.CBtnRobotTestReadPoint_Click);
            // 
            // CTabControlBorderRobotTestPoints
            // 
            this.CTabControlBorderRobotTestPoints.Controls.Add(this.PageRobotTestGlobalPoint);
            this.CTabControlBorderRobotTestPoints.Controls.Add(this.PageRobotTestUserFrame);
            this.CTabControlBorderRobotTestPoints.Controls.Add(this.PageRobotTestToolFrame);
            this.CTabControlBorderRobotTestPoints.Controls.Add(this.PageRobotTestWorkSpace);
            this.CTabControlBorderRobotTestPoints.Location = new System.Drawing.Point(572, 40);
            this.CTabControlBorderRobotTestPoints.Margin = new System.Windows.Forms.Padding(1);
            this.CTabControlBorderRobotTestPoints.Name = "CTabControlBorderRobotTestPoints";
            this.CTabControlBorderRobotTestPoints.SelectedIndex = 0;
            this.CTabControlBorderRobotTestPoints.Size = new System.Drawing.Size(960, 721);
            this.CTabControlBorderRobotTestPoints.TabIndex = 59;
            // 
            // PageRobotTestGlobalPoint
            // 
            this.PageRobotTestGlobalPoint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.PageRobotTestGlobalPoint.Controls.Add(this.DGV_RobotGlobalPoint);
            this.PageRobotTestGlobalPoint.Location = new System.Drawing.Point(1, 35);
            this.PageRobotTestGlobalPoint.Margin = new System.Windows.Forms.Padding(1);
            this.PageRobotTestGlobalPoint.Name = "PageRobotTestGlobalPoint";
            this.PageRobotTestGlobalPoint.Padding = new System.Windows.Forms.Padding(1);
            this.PageRobotTestGlobalPoint.Size = new System.Drawing.Size(958, 685);
            this.PageRobotTestGlobalPoint.TabIndex = 0;
            this.PageRobotTestGlobalPoint.Text = "全局点位";
            // 
            // DGV_RobotGlobalPoint
            // 
            this.DGV_RobotGlobalPoint.AllowDrop = true;
            this.DGV_RobotGlobalPoint.AllowUserToAddRows = false;
            this.DGV_RobotGlobalPoint.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DGV_RobotGlobalPoint.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DGV_RobotGlobalPoint.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DGV_RobotGlobalPoint.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.DGV_RobotGlobalPoint.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGV_RobotGlobalPoint.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DGV_RobotGlobalPoint.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DGV_RobotGlobalPoint.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RobotTestName,
            this.RobotTestX,
            this.RobotTestY,
            this.RobotTestZ,
            this.RobotTestRZ,
            this.RobotTestHand,
            this.RobotTestUserID,
            this.RobotTestToolID});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGV_RobotGlobalPoint.DefaultCellStyle = dataGridViewCellStyle3;
            this.DGV_RobotGlobalPoint.EnableHeadersVisualStyles = false;
            this.DGV_RobotGlobalPoint.GridColor = System.Drawing.Color.DarkGray;
            this.DGV_RobotGlobalPoint.Location = new System.Drawing.Point(0, 0);
            this.DGV_RobotGlobalPoint.Margin = new System.Windows.Forms.Padding(1);
            this.DGV_RobotGlobalPoint.Name = "DGV_RobotGlobalPoint";
            this.DGV_RobotGlobalPoint.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGV_RobotGlobalPoint.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.DGV_RobotGlobalPoint.RowHeadersWidth = 80;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.DGV_RobotGlobalPoint.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.DGV_RobotGlobalPoint.RowTemplate.Height = 23;
            this.DGV_RobotGlobalPoint.Size = new System.Drawing.Size(959, 675);
            this.DGV_RobotGlobalPoint.TabIndex = 0;
            this.DGV_RobotGlobalPoint.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_RobotGlobalPoint_CellClick);
            // 
            // RobotTestName
            // 
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.RobotTestName.DefaultCellStyle = dataGridViewCellStyle2;
            this.RobotTestName.HeaderText = "名称";
            this.RobotTestName.Name = "RobotTestName";
            this.RobotTestName.Width = 81;
            // 
            // RobotTestX
            // 
            this.RobotTestX.HeaderText = "X";
            this.RobotTestX.Name = "RobotTestX";
            this.RobotTestX.Width = 54;
            // 
            // RobotTestY
            // 
            this.RobotTestY.HeaderText = "Y";
            this.RobotTestY.Name = "RobotTestY";
            this.RobotTestY.Width = 53;
            // 
            // RobotTestZ
            // 
            this.RobotTestZ.HeaderText = "Z";
            this.RobotTestZ.Name = "RobotTestZ";
            this.RobotTestZ.Width = 53;
            // 
            // RobotTestRZ
            // 
            this.RobotTestRZ.HeaderText = "RZ";
            this.RobotTestRZ.Name = "RobotTestRZ";
            this.RobotTestRZ.Width = 66;
            // 
            // RobotTestHand
            // 
            this.RobotTestHand.HeaderText = "手系";
            this.RobotTestHand.Name = "RobotTestHand";
            this.RobotTestHand.Width = 81;
            // 
            // RobotTestUserID
            // 
            this.RobotTestUserID.HeaderText = "UserID";
            this.RobotTestUserID.Name = "RobotTestUserID";
            this.RobotTestUserID.Width = 105;
            // 
            // RobotTestToolID
            // 
            this.RobotTestToolID.HeaderText = "ToolID";
            this.RobotTestToolID.Name = "RobotTestToolID";
            this.RobotTestToolID.Width = 104;
            // 
            // PageRobotTestUserFrame
            // 
            this.PageRobotTestUserFrame.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.PageRobotTestUserFrame.Location = new System.Drawing.Point(1, 35);
            this.PageRobotTestUserFrame.Margin = new System.Windows.Forms.Padding(1);
            this.PageRobotTestUserFrame.Name = "PageRobotTestUserFrame";
            this.PageRobotTestUserFrame.Padding = new System.Windows.Forms.Padding(1);
            this.PageRobotTestUserFrame.Size = new System.Drawing.Size(958, 685);
            this.PageRobotTestUserFrame.TabIndex = 1;
            this.PageRobotTestUserFrame.Text = "使用者坐标";
            // 
            // PageRobotTestToolFrame
            // 
            this.PageRobotTestToolFrame.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.PageRobotTestToolFrame.Location = new System.Drawing.Point(1, 35);
            this.PageRobotTestToolFrame.Margin = new System.Windows.Forms.Padding(1);
            this.PageRobotTestToolFrame.Name = "PageRobotTestToolFrame";
            this.PageRobotTestToolFrame.Padding = new System.Windows.Forms.Padding(1);
            this.PageRobotTestToolFrame.Size = new System.Drawing.Size(958, 685);
            this.PageRobotTestToolFrame.TabIndex = 2;
            this.PageRobotTestToolFrame.Text = "工具坐标";
            // 
            // PageRobotTestWorkSpace
            // 
            this.PageRobotTestWorkSpace.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.PageRobotTestWorkSpace.Location = new System.Drawing.Point(1, 35);
            this.PageRobotTestWorkSpace.Margin = new System.Windows.Forms.Padding(1);
            this.PageRobotTestWorkSpace.Name = "PageRobotTestWorkSpace";
            this.PageRobotTestWorkSpace.Padding = new System.Windows.Forms.Padding(1);
            this.PageRobotTestWorkSpace.Size = new System.Drawing.Size(958, 685);
            this.PageRobotTestWorkSpace.TabIndex = 3;
            this.PageRobotTestWorkSpace.Text = "工作空间";
            // 
            // CButtonRobotDistanceRZSub
            // 
            this.CButtonRobotDistanceRZSub.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.CButtonRobotDistanceRZSub.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CButtonRobotDistanceRZSub.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.CButtonRobotDistanceRZSub.ForeColor = System.Drawing.Color.Transparent;
            this.CButtonRobotDistanceRZSub.Location = new System.Drawing.Point(379, 765);
            this.CButtonRobotDistanceRZSub.Margin = new System.Windows.Forms.Padding(4);
            this.CButtonRobotDistanceRZSub.Name = "CButtonRobotDistanceRZSub";
            this.CButtonRobotDistanceRZSub.Size = new System.Drawing.Size(120, 45);
            this.CButtonRobotDistanceRZSub.TabIndex = 58;
            this.CButtonRobotDistanceRZSub.Text = "RZ -";
            this.CButtonRobotDistanceRZSub.UseVisualStyleBackColor = false;
            this.CButtonRobotDistanceRZSub.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CButtonRobotDistanceRZSub_MouseDown);
            this.CButtonRobotDistanceRZSub.MouseUp += new System.Windows.Forms.MouseEventHandler(this.CButtonRobotDistanceRZSub_MouseUp);
            // 
            // CButtonRobotDistanceRZAdd
            // 
            this.CButtonRobotDistanceRZAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.CButtonRobotDistanceRZAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CButtonRobotDistanceRZAdd.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.CButtonRobotDistanceRZAdd.ForeColor = System.Drawing.Color.Transparent;
            this.CButtonRobotDistanceRZAdd.Location = new System.Drawing.Point(251, 765);
            this.CButtonRobotDistanceRZAdd.Margin = new System.Windows.Forms.Padding(4);
            this.CButtonRobotDistanceRZAdd.Name = "CButtonRobotDistanceRZAdd";
            this.CButtonRobotDistanceRZAdd.Size = new System.Drawing.Size(120, 45);
            this.CButtonRobotDistanceRZAdd.TabIndex = 57;
            this.CButtonRobotDistanceRZAdd.Text = "RZ +";
            this.CButtonRobotDistanceRZAdd.UseVisualStyleBackColor = false;
            this.CButtonRobotDistanceRZAdd.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CButtonRobotDistanceRZAdd_MouseDown);
            this.CButtonRobotDistanceRZAdd.MouseUp += new System.Windows.Forms.MouseEventHandler(this.CButtonRobotDistanceRZAdd_MouseUp);
            // 
            // CTextBoxRobotDistanceRZ
            // 
            this.CTextBoxRobotDistanceRZ.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.CTextBoxRobotDistanceRZ.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CTextBoxRobotDistanceRZ.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.CTextBoxRobotDistanceRZ.ForeColor = System.Drawing.Color.White;
            this.CTextBoxRobotDistanceRZ.Location = new System.Drawing.Point(96, 769);
            this.CTextBoxRobotDistanceRZ.Margin = new System.Windows.Forms.Padding(4);
            this.CTextBoxRobotDistanceRZ.Multiline = true;
            this.CTextBoxRobotDistanceRZ.Name = "CTextBoxRobotDistanceRZ";
            this.CTextBoxRobotDistanceRZ.Size = new System.Drawing.Size(139, 40);
            this.CTextBoxRobotDistanceRZ.TabIndex = 56;
            this.CTextBoxRobotDistanceRZ.Text = "0.000";
            // 
            // customLabel15
            // 
            this.customLabel15.AutoSize = true;
            this.customLabel15.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.customLabel15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.customLabel15.Location = new System.Drawing.Point(27, 774);
            this.customLabel15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.customLabel15.Name = "customLabel15";
            this.customLabel15.Size = new System.Drawing.Size(60, 28);
            this.customLabel15.TabIndex = 55;
            this.customLabel15.Text = "RZ：";
            // 
            // CButtonRobotDistanceZSub
            // 
            this.CButtonRobotDistanceZSub.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.CButtonRobotDistanceZSub.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CButtonRobotDistanceZSub.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.CButtonRobotDistanceZSub.ForeColor = System.Drawing.Color.Transparent;
            this.CButtonRobotDistanceZSub.Location = new System.Drawing.Point(379, 719);
            this.CButtonRobotDistanceZSub.Margin = new System.Windows.Forms.Padding(4);
            this.CButtonRobotDistanceZSub.Name = "CButtonRobotDistanceZSub";
            this.CButtonRobotDistanceZSub.Size = new System.Drawing.Size(120, 45);
            this.CButtonRobotDistanceZSub.TabIndex = 54;
            this.CButtonRobotDistanceZSub.Text = "Z -";
            this.CButtonRobotDistanceZSub.UseVisualStyleBackColor = false;
            this.CButtonRobotDistanceZSub.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CButtonRobotDistanceZSub_MouseDown);
            this.CButtonRobotDistanceZSub.MouseUp += new System.Windows.Forms.MouseEventHandler(this.CButtonRobotDistanceZSub_MouseUp);
            // 
            // CButtonRobotDistanceZAdd
            // 
            this.CButtonRobotDistanceZAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.CButtonRobotDistanceZAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CButtonRobotDistanceZAdd.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.CButtonRobotDistanceZAdd.ForeColor = System.Drawing.Color.Transparent;
            this.CButtonRobotDistanceZAdd.Location = new System.Drawing.Point(251, 719);
            this.CButtonRobotDistanceZAdd.Margin = new System.Windows.Forms.Padding(4);
            this.CButtonRobotDistanceZAdd.Name = "CButtonRobotDistanceZAdd";
            this.CButtonRobotDistanceZAdd.Size = new System.Drawing.Size(120, 45);
            this.CButtonRobotDistanceZAdd.TabIndex = 53;
            this.CButtonRobotDistanceZAdd.Text = "Z +";
            this.CButtonRobotDistanceZAdd.UseVisualStyleBackColor = false;
            this.CButtonRobotDistanceZAdd.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CButtonRobotDistanceZAdd_MouseDown);
            this.CButtonRobotDistanceZAdd.MouseUp += new System.Windows.Forms.MouseEventHandler(this.CButtonRobotDistanceZAdd_MouseUp);
            // 
            // CTextBoxRobotDistanceZ
            // 
            this.CTextBoxRobotDistanceZ.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.CTextBoxRobotDistanceZ.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CTextBoxRobotDistanceZ.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.CTextBoxRobotDistanceZ.ForeColor = System.Drawing.Color.White;
            this.CTextBoxRobotDistanceZ.Location = new System.Drawing.Point(96, 722);
            this.CTextBoxRobotDistanceZ.Margin = new System.Windows.Forms.Padding(4);
            this.CTextBoxRobotDistanceZ.Multiline = true;
            this.CTextBoxRobotDistanceZ.Name = "CTextBoxRobotDistanceZ";
            this.CTextBoxRobotDistanceZ.Size = new System.Drawing.Size(139, 40);
            this.CTextBoxRobotDistanceZ.TabIndex = 52;
            this.CTextBoxRobotDistanceZ.Text = "0.000";
            // 
            // customLabel16
            // 
            this.customLabel16.AutoSize = true;
            this.customLabel16.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.customLabel16.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.customLabel16.Location = new System.Drawing.Point(27, 728);
            this.customLabel16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.customLabel16.Name = "customLabel16";
            this.customLabel16.Size = new System.Drawing.Size(46, 28);
            this.customLabel16.TabIndex = 51;
            this.customLabel16.Text = "Z：";
            // 
            // CButtonRobotDistanceYSub
            // 
            this.CButtonRobotDistanceYSub.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.CButtonRobotDistanceYSub.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CButtonRobotDistanceYSub.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.CButtonRobotDistanceYSub.ForeColor = System.Drawing.Color.Transparent;
            this.CButtonRobotDistanceYSub.Location = new System.Drawing.Point(379, 672);
            this.CButtonRobotDistanceYSub.Margin = new System.Windows.Forms.Padding(4);
            this.CButtonRobotDistanceYSub.Name = "CButtonRobotDistanceYSub";
            this.CButtonRobotDistanceYSub.Size = new System.Drawing.Size(120, 45);
            this.CButtonRobotDistanceYSub.TabIndex = 50;
            this.CButtonRobotDistanceYSub.Text = "Y -";
            this.CButtonRobotDistanceYSub.UseVisualStyleBackColor = false;
            this.CButtonRobotDistanceYSub.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CButtonRobotDistanceYSub_MouseDown);
            this.CButtonRobotDistanceYSub.MouseUp += new System.Windows.Forms.MouseEventHandler(this.CButtonRobotDistanceYSub_MouseUp);
            // 
            // CButtonRobotDistanceYAdd
            // 
            this.CButtonRobotDistanceYAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.CButtonRobotDistanceYAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CButtonRobotDistanceYAdd.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.CButtonRobotDistanceYAdd.ForeColor = System.Drawing.Color.Transparent;
            this.CButtonRobotDistanceYAdd.Location = new System.Drawing.Point(251, 672);
            this.CButtonRobotDistanceYAdd.Margin = new System.Windows.Forms.Padding(4);
            this.CButtonRobotDistanceYAdd.Name = "CButtonRobotDistanceYAdd";
            this.CButtonRobotDistanceYAdd.Size = new System.Drawing.Size(120, 45);
            this.CButtonRobotDistanceYAdd.TabIndex = 49;
            this.CButtonRobotDistanceYAdd.Text = "Y +";
            this.CButtonRobotDistanceYAdd.UseVisualStyleBackColor = false;
            this.CButtonRobotDistanceYAdd.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CButtonRobotDistanceYAdd_MouseDown);
            this.CButtonRobotDistanceYAdd.MouseUp += new System.Windows.Forms.MouseEventHandler(this.CButtonRobotDistanceYAdd_MouseUp);
            // 
            // CTextBoxRobotDistanceY
            // 
            this.CTextBoxRobotDistanceY.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.CTextBoxRobotDistanceY.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CTextBoxRobotDistanceY.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.CTextBoxRobotDistanceY.ForeColor = System.Drawing.Color.White;
            this.CTextBoxRobotDistanceY.Location = new System.Drawing.Point(96, 676);
            this.CTextBoxRobotDistanceY.Margin = new System.Windows.Forms.Padding(4);
            this.CTextBoxRobotDistanceY.Multiline = true;
            this.CTextBoxRobotDistanceY.Name = "CTextBoxRobotDistanceY";
            this.CTextBoxRobotDistanceY.Size = new System.Drawing.Size(139, 40);
            this.CTextBoxRobotDistanceY.TabIndex = 48;
            this.CTextBoxRobotDistanceY.Text = "0.000";
            // 
            // customLabel17
            // 
            this.customLabel17.AutoSize = true;
            this.customLabel17.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.customLabel17.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.customLabel17.Location = new System.Drawing.Point(27, 681);
            this.customLabel17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.customLabel17.Name = "customLabel17";
            this.customLabel17.Size = new System.Drawing.Size(46, 28);
            this.customLabel17.TabIndex = 47;
            this.customLabel17.Text = "Y：";
            // 
            // CButtonRobotDistanceXSub
            // 
            this.CButtonRobotDistanceXSub.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.CButtonRobotDistanceXSub.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CButtonRobotDistanceXSub.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.CButtonRobotDistanceXSub.ForeColor = System.Drawing.Color.Transparent;
            this.CButtonRobotDistanceXSub.Location = new System.Drawing.Point(379, 626);
            this.CButtonRobotDistanceXSub.Margin = new System.Windows.Forms.Padding(4);
            this.CButtonRobotDistanceXSub.Name = "CButtonRobotDistanceXSub";
            this.CButtonRobotDistanceXSub.Size = new System.Drawing.Size(120, 45);
            this.CButtonRobotDistanceXSub.TabIndex = 46;
            this.CButtonRobotDistanceXSub.Text = "X -";
            this.CButtonRobotDistanceXSub.UseVisualStyleBackColor = false;
            this.CButtonRobotDistanceXSub.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CButtonRobotDistanceXSub_MouseDown);
            this.CButtonRobotDistanceXSub.MouseUp += new System.Windows.Forms.MouseEventHandler(this.CButtonRobotDistanceXSub_MouseUp);
            // 
            // CButtonRobotDistanceXAdd
            // 
            this.CButtonRobotDistanceXAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.CButtonRobotDistanceXAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CButtonRobotDistanceXAdd.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.CButtonRobotDistanceXAdd.ForeColor = System.Drawing.Color.Transparent;
            this.CButtonRobotDistanceXAdd.Location = new System.Drawing.Point(251, 626);
            this.CButtonRobotDistanceXAdd.Margin = new System.Windows.Forms.Padding(4);
            this.CButtonRobotDistanceXAdd.Name = "CButtonRobotDistanceXAdd";
            this.CButtonRobotDistanceXAdd.Size = new System.Drawing.Size(120, 45);
            this.CButtonRobotDistanceXAdd.TabIndex = 45;
            this.CButtonRobotDistanceXAdd.Text = "X +";
            this.CButtonRobotDistanceXAdd.UseVisualStyleBackColor = false;
            this.CButtonRobotDistanceXAdd.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CButtonRobotDistanceXAdd_MouseDown);
            this.CButtonRobotDistanceXAdd.MouseUp += new System.Windows.Forms.MouseEventHandler(this.CButtonRobotDistanceXAdd_MouseUp);
            // 
            // CTextBoxRobotDistanceX
            // 
            this.CTextBoxRobotDistanceX.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.CTextBoxRobotDistanceX.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CTextBoxRobotDistanceX.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.CTextBoxRobotDistanceX.ForeColor = System.Drawing.Color.White;
            this.CTextBoxRobotDistanceX.Location = new System.Drawing.Point(96, 630);
            this.CTextBoxRobotDistanceX.Margin = new System.Windows.Forms.Padding(4);
            this.CTextBoxRobotDistanceX.Multiline = true;
            this.CTextBoxRobotDistanceX.Name = "CTextBoxRobotDistanceX";
            this.CTextBoxRobotDistanceX.Size = new System.Drawing.Size(139, 40);
            this.CTextBoxRobotDistanceX.TabIndex = 44;
            this.CTextBoxRobotDistanceX.Text = "0.000";
            // 
            // customLabel18
            // 
            this.customLabel18.AutoSize = true;
            this.customLabel18.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.customLabel18.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.customLabel18.Location = new System.Drawing.Point(27, 635);
            this.customLabel18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.customLabel18.Name = "customLabel18";
            this.customLabel18.Size = new System.Drawing.Size(47, 28);
            this.customLabel18.TabIndex = 43;
            this.customLabel18.Text = "X：";
            // 
            // CButtonRobotDistanceJ4Sub
            // 
            this.CButtonRobotDistanceJ4Sub.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.CButtonRobotDistanceJ4Sub.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CButtonRobotDistanceJ4Sub.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.CButtonRobotDistanceJ4Sub.ForeColor = System.Drawing.Color.Transparent;
            this.CButtonRobotDistanceJ4Sub.Location = new System.Drawing.Point(379, 580);
            this.CButtonRobotDistanceJ4Sub.Margin = new System.Windows.Forms.Padding(4);
            this.CButtonRobotDistanceJ4Sub.Name = "CButtonRobotDistanceJ4Sub";
            this.CButtonRobotDistanceJ4Sub.Size = new System.Drawing.Size(120, 45);
            this.CButtonRobotDistanceJ4Sub.TabIndex = 42;
            this.CButtonRobotDistanceJ4Sub.Text = "J4 -";
            this.CButtonRobotDistanceJ4Sub.UseVisualStyleBackColor = false;
            this.CButtonRobotDistanceJ4Sub.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CButtonRobotDistanceJ4Sub_MouseDown);
            this.CButtonRobotDistanceJ4Sub.MouseUp += new System.Windows.Forms.MouseEventHandler(this.CButtonRobotDistanceJ4Sub_MouseUp);
            // 
            // CButtonRobotDistanceJ4Add
            // 
            this.CButtonRobotDistanceJ4Add.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.CButtonRobotDistanceJ4Add.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CButtonRobotDistanceJ4Add.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.CButtonRobotDistanceJ4Add.ForeColor = System.Drawing.Color.Transparent;
            this.CButtonRobotDistanceJ4Add.Location = new System.Drawing.Point(251, 580);
            this.CButtonRobotDistanceJ4Add.Margin = new System.Windows.Forms.Padding(4);
            this.CButtonRobotDistanceJ4Add.Name = "CButtonRobotDistanceJ4Add";
            this.CButtonRobotDistanceJ4Add.Size = new System.Drawing.Size(120, 45);
            this.CButtonRobotDistanceJ4Add.TabIndex = 41;
            this.CButtonRobotDistanceJ4Add.Text = "J4 +";
            this.CButtonRobotDistanceJ4Add.UseVisualStyleBackColor = false;
            this.CButtonRobotDistanceJ4Add.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CButtonRobotDistanceJ4Add_MouseDown);
            this.CButtonRobotDistanceJ4Add.MouseUp += new System.Windows.Forms.MouseEventHandler(this.CButtonRobotDistanceJ4Add_MouseUp);
            // 
            // CTextBoxRobotDistanceJ4
            // 
            this.CTextBoxRobotDistanceJ4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.CTextBoxRobotDistanceJ4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CTextBoxRobotDistanceJ4.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.CTextBoxRobotDistanceJ4.ForeColor = System.Drawing.Color.White;
            this.CTextBoxRobotDistanceJ4.Location = new System.Drawing.Point(96, 584);
            this.CTextBoxRobotDistanceJ4.Margin = new System.Windows.Forms.Padding(4);
            this.CTextBoxRobotDistanceJ4.Multiline = true;
            this.CTextBoxRobotDistanceJ4.Name = "CTextBoxRobotDistanceJ4";
            this.CTextBoxRobotDistanceJ4.Size = new System.Drawing.Size(139, 40);
            this.CTextBoxRobotDistanceJ4.TabIndex = 40;
            this.CTextBoxRobotDistanceJ4.Text = "0";
            // 
            // customLabel14
            // 
            this.customLabel14.AutoSize = true;
            this.customLabel14.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.customLabel14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.customLabel14.Location = new System.Drawing.Point(27, 589);
            this.customLabel14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.customLabel14.Name = "customLabel14";
            this.customLabel14.Size = new System.Drawing.Size(53, 28);
            this.customLabel14.TabIndex = 39;
            this.customLabel14.Text = "J4：";
            // 
            // CButtonRobotDistanceJ3Sub
            // 
            this.CButtonRobotDistanceJ3Sub.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.CButtonRobotDistanceJ3Sub.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CButtonRobotDistanceJ3Sub.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.CButtonRobotDistanceJ3Sub.ForeColor = System.Drawing.Color.Transparent;
            this.CButtonRobotDistanceJ3Sub.Location = new System.Drawing.Point(379, 534);
            this.CButtonRobotDistanceJ3Sub.Margin = new System.Windows.Forms.Padding(4);
            this.CButtonRobotDistanceJ3Sub.Name = "CButtonRobotDistanceJ3Sub";
            this.CButtonRobotDistanceJ3Sub.Size = new System.Drawing.Size(120, 45);
            this.CButtonRobotDistanceJ3Sub.TabIndex = 38;
            this.CButtonRobotDistanceJ3Sub.Text = "J3 -";
            this.CButtonRobotDistanceJ3Sub.UseVisualStyleBackColor = false;
            this.CButtonRobotDistanceJ3Sub.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CButtonRobotDistanceJ3Sub_MouseDown);
            this.CButtonRobotDistanceJ3Sub.MouseUp += new System.Windows.Forms.MouseEventHandler(this.CButtonRobotDistanceJ3Sub_MouseUp);
            // 
            // CButtonRobotDistanceJ3Add
            // 
            this.CButtonRobotDistanceJ3Add.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.CButtonRobotDistanceJ3Add.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CButtonRobotDistanceJ3Add.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.CButtonRobotDistanceJ3Add.ForeColor = System.Drawing.Color.Transparent;
            this.CButtonRobotDistanceJ3Add.Location = new System.Drawing.Point(251, 534);
            this.CButtonRobotDistanceJ3Add.Margin = new System.Windows.Forms.Padding(4);
            this.CButtonRobotDistanceJ3Add.Name = "CButtonRobotDistanceJ3Add";
            this.CButtonRobotDistanceJ3Add.Size = new System.Drawing.Size(120, 45);
            this.CButtonRobotDistanceJ3Add.TabIndex = 37;
            this.CButtonRobotDistanceJ3Add.Text = "J3 +";
            this.CButtonRobotDistanceJ3Add.UseVisualStyleBackColor = false;
            this.CButtonRobotDistanceJ3Add.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CButtonRobotDistanceJ3Add_MouseDown);
            this.CButtonRobotDistanceJ3Add.MouseUp += new System.Windows.Forms.MouseEventHandler(this.CButtonRobotDistanceJ3Add_MouseUp);
            // 
            // CTextBoxRobotDistanceJ3
            // 
            this.CTextBoxRobotDistanceJ3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.CTextBoxRobotDistanceJ3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CTextBoxRobotDistanceJ3.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.CTextBoxRobotDistanceJ3.ForeColor = System.Drawing.Color.White;
            this.CTextBoxRobotDistanceJ3.Location = new System.Drawing.Point(96, 538);
            this.CTextBoxRobotDistanceJ3.Margin = new System.Windows.Forms.Padding(4);
            this.CTextBoxRobotDistanceJ3.Multiline = true;
            this.CTextBoxRobotDistanceJ3.Name = "CTextBoxRobotDistanceJ3";
            this.CTextBoxRobotDistanceJ3.Size = new System.Drawing.Size(139, 40);
            this.CTextBoxRobotDistanceJ3.TabIndex = 36;
            this.CTextBoxRobotDistanceJ3.Text = "0";
            // 
            // customLabel13
            // 
            this.customLabel13.AutoSize = true;
            this.customLabel13.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.customLabel13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.customLabel13.Location = new System.Drawing.Point(27, 542);
            this.customLabel13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.customLabel13.Name = "customLabel13";
            this.customLabel13.Size = new System.Drawing.Size(53, 28);
            this.customLabel13.TabIndex = 35;
            this.customLabel13.Text = "J3：";
            // 
            // CButtonRobotDistanceJ2Sub
            // 
            this.CButtonRobotDistanceJ2Sub.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.CButtonRobotDistanceJ2Sub.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CButtonRobotDistanceJ2Sub.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.CButtonRobotDistanceJ2Sub.ForeColor = System.Drawing.Color.Transparent;
            this.CButtonRobotDistanceJ2Sub.Location = new System.Drawing.Point(379, 488);
            this.CButtonRobotDistanceJ2Sub.Margin = new System.Windows.Forms.Padding(4);
            this.CButtonRobotDistanceJ2Sub.Name = "CButtonRobotDistanceJ2Sub";
            this.CButtonRobotDistanceJ2Sub.Size = new System.Drawing.Size(120, 45);
            this.CButtonRobotDistanceJ2Sub.TabIndex = 34;
            this.CButtonRobotDistanceJ2Sub.Text = "J2 -";
            this.CButtonRobotDistanceJ2Sub.UseVisualStyleBackColor = false;
            this.CButtonRobotDistanceJ2Sub.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CButtonRobotDistanceJ2Sub_MouseDown);
            this.CButtonRobotDistanceJ2Sub.MouseUp += new System.Windows.Forms.MouseEventHandler(this.CButtonRobotDistanceJ2Sub_MouseUp);
            // 
            // CButtonRobotDistanceJ2Add
            // 
            this.CButtonRobotDistanceJ2Add.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.CButtonRobotDistanceJ2Add.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CButtonRobotDistanceJ2Add.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.CButtonRobotDistanceJ2Add.ForeColor = System.Drawing.Color.Transparent;
            this.CButtonRobotDistanceJ2Add.Location = new System.Drawing.Point(251, 488);
            this.CButtonRobotDistanceJ2Add.Margin = new System.Windows.Forms.Padding(4);
            this.CButtonRobotDistanceJ2Add.Name = "CButtonRobotDistanceJ2Add";
            this.CButtonRobotDistanceJ2Add.Size = new System.Drawing.Size(120, 45);
            this.CButtonRobotDistanceJ2Add.TabIndex = 33;
            this.CButtonRobotDistanceJ2Add.Text = "J2 +";
            this.CButtonRobotDistanceJ2Add.UseVisualStyleBackColor = false;
            this.CButtonRobotDistanceJ2Add.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CButtonRobotDistanceJ2Add_MouseDown);
            this.CButtonRobotDistanceJ2Add.MouseUp += new System.Windows.Forms.MouseEventHandler(this.CButtonRobotDistanceJ2Add_MouseUp);
            // 
            // CTextBoxRobotDistanceJ2
            // 
            this.CTextBoxRobotDistanceJ2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.CTextBoxRobotDistanceJ2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CTextBoxRobotDistanceJ2.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.CTextBoxRobotDistanceJ2.ForeColor = System.Drawing.Color.White;
            this.CTextBoxRobotDistanceJ2.Location = new System.Drawing.Point(96, 491);
            this.CTextBoxRobotDistanceJ2.Margin = new System.Windows.Forms.Padding(4);
            this.CTextBoxRobotDistanceJ2.Multiline = true;
            this.CTextBoxRobotDistanceJ2.Name = "CTextBoxRobotDistanceJ2";
            this.CTextBoxRobotDistanceJ2.Size = new System.Drawing.Size(139, 40);
            this.CTextBoxRobotDistanceJ2.TabIndex = 32;
            this.CTextBoxRobotDistanceJ2.Text = "0";
            // 
            // customLabel12
            // 
            this.customLabel12.AutoSize = true;
            this.customLabel12.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.customLabel12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.customLabel12.Location = new System.Drawing.Point(27, 496);
            this.customLabel12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.customLabel12.Name = "customLabel12";
            this.customLabel12.Size = new System.Drawing.Size(53, 28);
            this.customLabel12.TabIndex = 31;
            this.customLabel12.Text = "J2：";
            // 
            // CButtonRobotDistanceJ1Sub
            // 
            this.CButtonRobotDistanceJ1Sub.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.CButtonRobotDistanceJ1Sub.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CButtonRobotDistanceJ1Sub.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.CButtonRobotDistanceJ1Sub.ForeColor = System.Drawing.Color.Transparent;
            this.CButtonRobotDistanceJ1Sub.Location = new System.Drawing.Point(379, 441);
            this.CButtonRobotDistanceJ1Sub.Margin = new System.Windows.Forms.Padding(4);
            this.CButtonRobotDistanceJ1Sub.Name = "CButtonRobotDistanceJ1Sub";
            this.CButtonRobotDistanceJ1Sub.Size = new System.Drawing.Size(120, 45);
            this.CButtonRobotDistanceJ1Sub.TabIndex = 30;
            this.CButtonRobotDistanceJ1Sub.Text = "J1 -";
            this.CButtonRobotDistanceJ1Sub.UseVisualStyleBackColor = false;
            this.CButtonRobotDistanceJ1Sub.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CButtonRobotDistanceJ1Sub_MouseDown);
            this.CButtonRobotDistanceJ1Sub.MouseUp += new System.Windows.Forms.MouseEventHandler(this.CButtonRobotDistanceJ1Sub_MouseUp);
            // 
            // CButtonRobotDistanceJ1Add
            // 
            this.CButtonRobotDistanceJ1Add.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.CButtonRobotDistanceJ1Add.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CButtonRobotDistanceJ1Add.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.CButtonRobotDistanceJ1Add.ForeColor = System.Drawing.Color.Transparent;
            this.CButtonRobotDistanceJ1Add.Location = new System.Drawing.Point(251, 441);
            this.CButtonRobotDistanceJ1Add.Margin = new System.Windows.Forms.Padding(4);
            this.CButtonRobotDistanceJ1Add.Name = "CButtonRobotDistanceJ1Add";
            this.CButtonRobotDistanceJ1Add.Size = new System.Drawing.Size(120, 45);
            this.CButtonRobotDistanceJ1Add.TabIndex = 29;
            this.CButtonRobotDistanceJ1Add.Text = "J1 +";
            this.CButtonRobotDistanceJ1Add.UseVisualStyleBackColor = false;
            this.CButtonRobotDistanceJ1Add.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CButtonRobotDistanceJ1Add_MouseDown);
            this.CButtonRobotDistanceJ1Add.MouseUp += new System.Windows.Forms.MouseEventHandler(this.CButtonRobotDistanceJ1Add_MouseUp);
            // 
            // CTextBoxRobotDistanceJ1
            // 
            this.CTextBoxRobotDistanceJ1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.CTextBoxRobotDistanceJ1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CTextBoxRobotDistanceJ1.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.CTextBoxRobotDistanceJ1.ForeColor = System.Drawing.Color.White;
            this.CTextBoxRobotDistanceJ1.Location = new System.Drawing.Point(96, 445);
            this.CTextBoxRobotDistanceJ1.Margin = new System.Windows.Forms.Padding(4);
            this.CTextBoxRobotDistanceJ1.Multiline = true;
            this.CTextBoxRobotDistanceJ1.Name = "CTextBoxRobotDistanceJ1";
            this.CTextBoxRobotDistanceJ1.Size = new System.Drawing.Size(139, 40);
            this.CTextBoxRobotDistanceJ1.TabIndex = 28;
            this.CTextBoxRobotDistanceJ1.Text = "0";
            // 
            // customLabel11
            // 
            this.customLabel11.AutoSize = true;
            this.customLabel11.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.customLabel11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.customLabel11.Location = new System.Drawing.Point(27, 450);
            this.customLabel11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.customLabel11.Name = "customLabel11";
            this.customLabel11.Size = new System.Drawing.Size(53, 28);
            this.customLabel11.TabIndex = 27;
            this.customLabel11.Text = "J1：";
            // 
            // radioButtonRobotDeviceContinuous
            // 
            this.radioButtonRobotDeviceContinuous.AutoSize = true;
            this.radioButtonRobotDeviceContinuous.Location = new System.Drawing.Point(372, 351);
            this.radioButtonRobotDeviceContinuous.Margin = new System.Windows.Forms.Padding(4);
            this.radioButtonRobotDeviceContinuous.Name = "radioButtonRobotDeviceContinuous";
            this.radioButtonRobotDeviceContinuous.Size = new System.Drawing.Size(73, 31);
            this.radioButtonRobotDeviceContinuous.TabIndex = 26;
            this.radioButtonRobotDeviceContinuous.TabStop = true;
            this.radioButtonRobotDeviceContinuous.Text = "连续";
            this.radioButtonRobotDeviceContinuous.UseVisualStyleBackColor = true;
            this.radioButtonRobotDeviceContinuous.CheckedChanged += new System.EventHandler(this.radioButtonRobotDeviceContinuous_CheckedChanged);
            // 
            // radioButtonRobotDeviceJog
            // 
            this.radioButtonRobotDeviceJog.AutoSize = true;
            this.radioButtonRobotDeviceJog.Location = new System.Drawing.Point(373, 281);
            this.radioButtonRobotDeviceJog.Margin = new System.Windows.Forms.Padding(4);
            this.radioButtonRobotDeviceJog.Name = "radioButtonRobotDeviceJog";
            this.radioButtonRobotDeviceJog.Size = new System.Drawing.Size(72, 31);
            this.radioButtonRobotDeviceJog.TabIndex = 25;
            this.radioButtonRobotDeviceJog.TabStop = true;
            this.radioButtonRobotDeviceJog.Text = "JOG";
            this.radioButtonRobotDeviceJog.UseVisualStyleBackColor = true;
            this.radioButtonRobotDeviceJog.CheckedChanged += new System.EventHandler(this.radioButtonRobotDeviceJog_CheckedChanged);
            // 
            // customLabel9
            // 
            this.customLabel9.AutoSize = true;
            this.customLabel9.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.customLabel9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.customLabel9.Location = new System.Drawing.Point(273, 281);
            this.customLabel9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.customLabel9.Name = "customLabel9";
            this.customLabel9.Size = new System.Drawing.Size(31, 28);
            this.customLabel9.TabIndex = 23;
            this.customLabel9.Text = "%";
            this.customLabel9.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // CTextBoxRobotMoveSpeed
            // 
            this.CTextBoxRobotMoveSpeed.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.CTextBoxRobotMoveSpeed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CTextBoxRobotMoveSpeed.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.CTextBoxRobotMoveSpeed.ForeColor = System.Drawing.Color.White;
            this.CTextBoxRobotMoveSpeed.Location = new System.Drawing.Point(151, 279);
            this.CTextBoxRobotMoveSpeed.Margin = new System.Windows.Forms.Padding(4);
            this.CTextBoxRobotMoveSpeed.Multiline = true;
            this.CTextBoxRobotMoveSpeed.Name = "CTextBoxRobotMoveSpeed";
            this.CTextBoxRobotMoveSpeed.Size = new System.Drawing.Size(119, 40);
            this.CTextBoxRobotMoveSpeed.TabIndex = 22;
            this.CTextBoxRobotMoveSpeed.Text = "30";
            this.CTextBoxRobotMoveSpeed.TextChanged += new System.EventHandler(this.CTextBoxRobotMoveSpeed_TextChanged);
            // 
            // customLabel8
            // 
            this.customLabel8.AutoSize = true;
            this.customLabel8.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.customLabel8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.customLabel8.Location = new System.Drawing.Point(27, 281);
            this.customLabel8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.customLabel8.Name = "customLabel8";
            this.customLabel8.Size = new System.Drawing.Size(117, 28);
            this.customLabel8.TabIndex = 21;
            this.customLabel8.Text = "移动速度：";
            // 
            // customLabel7
            // 
            this.customLabel7.AutoSize = true;
            this.customLabel7.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.customLabel7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.customLabel7.Location = new System.Drawing.Point(279, 379);
            this.customLabel7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.customLabel7.Name = "customLabel7";
            this.customLabel7.Size = new System.Drawing.Size(45, 28);
            this.customLabel7.TabIndex = 20;
            this.customLabel7.Text = "um";
            this.customLabel7.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // CTextBoxJogDistanceUm
            // 
            this.CTextBoxJogDistanceUm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.CTextBoxJogDistanceUm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CTextBoxJogDistanceUm.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.CTextBoxJogDistanceUm.ForeColor = System.Drawing.Color.White;
            this.CTextBoxJogDistanceUm.Location = new System.Drawing.Point(151, 376);
            this.CTextBoxJogDistanceUm.Margin = new System.Windows.Forms.Padding(4);
            this.CTextBoxJogDistanceUm.Multiline = true;
            this.CTextBoxJogDistanceUm.Name = "CTextBoxJogDistanceUm";
            this.CTextBoxJogDistanceUm.Size = new System.Drawing.Size(119, 40);
            this.CTextBoxJogDistanceUm.TabIndex = 19;
            this.CTextBoxJogDistanceUm.Text = "1000";
            this.CTextBoxJogDistanceUm.TextChanged += new System.EventHandler(this.CTextBoxJogDistanceUm_TextChanged);
            // 
            // customLabel6
            // 
            this.customLabel6.AutoSize = true;
            this.customLabel6.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.customLabel6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.customLabel6.Location = new System.Drawing.Point(279, 330);
            this.customLabel6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.customLabel6.Name = "customLabel6";
            this.customLabel6.Size = new System.Drawing.Size(54, 28);
            this.customLabel6.TabIndex = 18;
            this.customLabel6.Text = "PPU";
            this.customLabel6.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // CTextBoxJogDistance
            // 
            this.CTextBoxJogDistance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.CTextBoxJogDistance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CTextBoxJogDistance.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.CTextBoxJogDistance.ForeColor = System.Drawing.Color.White;
            this.CTextBoxJogDistance.Location = new System.Drawing.Point(151, 328);
            this.CTextBoxJogDistance.Margin = new System.Windows.Forms.Padding(4);
            this.CTextBoxJogDistance.Multiline = true;
            this.CTextBoxJogDistance.Name = "CTextBoxJogDistance";
            this.CTextBoxJogDistance.Size = new System.Drawing.Size(119, 40);
            this.CTextBoxJogDistance.TabIndex = 17;
            this.CTextBoxJogDistance.Text = "1000";
            this.CTextBoxJogDistance.TextChanged += new System.EventHandler(this.CTextBoxJogDistance_TextChanged);
            // 
            // customLabel5
            // 
            this.customLabel5.AutoSize = true;
            this.customLabel5.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.customLabel5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.customLabel5.Location = new System.Drawing.Point(27, 325);
            this.customLabel5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.customLabel5.Name = "customLabel5";
            this.customLabel5.Size = new System.Drawing.Size(115, 28);
            this.customLabel5.TabIndex = 16;
            this.customLabel5.Text = "Jog 距离：";
            // 
            // pictureBoxRobotMove
            // 
            this.pictureBoxRobotMove.Image = global::RobotWorkstation.Properties.Resources.SmallDarkGreen;
            this.pictureBoxRobotMove.Location = new System.Drawing.Point(115, 231);
            this.pictureBoxRobotMove.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBoxRobotMove.Name = "pictureBoxRobotMove";
            this.pictureBoxRobotMove.Size = new System.Drawing.Size(29, 28);
            this.pictureBoxRobotMove.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxRobotMove.TabIndex = 15;
            this.pictureBoxRobotMove.TabStop = false;
            // 
            // customLabel4
            // 
            this.customLabel4.AutoSize = true;
            this.customLabel4.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.customLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.customLabel4.Location = new System.Drawing.Point(27, 229);
            this.customLabel4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.customLabel4.Name = "customLabel4";
            this.customLabel4.Size = new System.Drawing.Size(75, 28);
            this.customLabel4.TabIndex = 14;
            this.customLabel4.Text = "移动：";
            // 
            // pictureBoxTemperature
            // 
            this.pictureBoxTemperature.Image = global::RobotWorkstation.Properties.Resources.SmallDarkGreen;
            this.pictureBoxTemperature.Location = new System.Drawing.Point(115, 185);
            this.pictureBoxTemperature.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBoxTemperature.Name = "pictureBoxTemperature";
            this.pictureBoxTemperature.Size = new System.Drawing.Size(29, 28);
            this.pictureBoxTemperature.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxTemperature.TabIndex = 13;
            this.pictureBoxTemperature.TabStop = false;
            // 
            // customLabel3
            // 
            this.customLabel3.AutoSize = true;
            this.customLabel3.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.customLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.customLabel3.Location = new System.Drawing.Point(27, 182);
            this.customLabel3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.customLabel3.Name = "customLabel3";
            this.customLabel3.Size = new System.Drawing.Size(75, 28);
            this.customLabel3.TabIndex = 12;
            this.customLabel3.Text = "温度：";
            // 
            // CButtonRobotExecStop
            // 
            this.CButtonRobotExecStop.BackColor = System.Drawing.Color.Red;
            this.CButtonRobotExecStop.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CButtonRobotExecStop.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.CButtonRobotExecStop.ForeColor = System.Drawing.Color.Transparent;
            this.CButtonRobotExecStop.Location = new System.Drawing.Point(432, 130);
            this.CButtonRobotExecStop.Margin = new System.Windows.Forms.Padding(4);
            this.CButtonRobotExecStop.Name = "CButtonRobotExecStop";
            this.CButtonRobotExecStop.Size = new System.Drawing.Size(120, 45);
            this.CButtonRobotExecStop.TabIndex = 11;
            this.CButtonRobotExecStop.Text = "停止";
            this.CButtonRobotExecStop.UseVisualStyleBackColor = false;
            this.CButtonRobotExecStop.Click += new System.EventHandler(this.CButtonRobotExecStop_Click);
            // 
            // CButtonRobotExecPause
            // 
            this.CButtonRobotExecPause.BackColor = System.Drawing.Color.Orange;
            this.CButtonRobotExecPause.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CButtonRobotExecPause.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.CButtonRobotExecPause.ForeColor = System.Drawing.Color.Transparent;
            this.CButtonRobotExecPause.Location = new System.Drawing.Point(301, 130);
            this.CButtonRobotExecPause.Margin = new System.Windows.Forms.Padding(4);
            this.CButtonRobotExecPause.Name = "CButtonRobotExecPause";
            this.CButtonRobotExecPause.Size = new System.Drawing.Size(120, 45);
            this.CButtonRobotExecPause.TabIndex = 10;
            this.CButtonRobotExecPause.Text = "暂停";
            this.CButtonRobotExecPause.UseVisualStyleBackColor = false;
            this.CButtonRobotExecPause.Click += new System.EventHandler(this.CButtonRobotExecPause_Click);
            // 
            // CButtonRobotExecRun
            // 
            this.CButtonRobotExecRun.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(148)))), ((int)(((byte)(8)))));
            this.CButtonRobotExecRun.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CButtonRobotExecRun.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.CButtonRobotExecRun.ForeColor = System.Drawing.Color.Transparent;
            this.CButtonRobotExecRun.Location = new System.Drawing.Point(171, 130);
            this.CButtonRobotExecRun.Margin = new System.Windows.Forms.Padding(4);
            this.CButtonRobotExecRun.Name = "CButtonRobotExecRun";
            this.CButtonRobotExecRun.Size = new System.Drawing.Size(120, 45);
            this.CButtonRobotExecRun.TabIndex = 9;
            this.CButtonRobotExecRun.Text = "运行";
            this.CButtonRobotExecRun.UseVisualStyleBackColor = false;
            this.CButtonRobotExecRun.Click += new System.EventHandler(this.CButtonRobotExecRun_Click);
            // 
            // pictureBoxRobotExecut
            // 
            this.pictureBoxRobotExecut.Image = global::RobotWorkstation.Properties.Resources.SmallDarkGreen;
            this.pictureBoxRobotExecut.Location = new System.Drawing.Point(115, 139);
            this.pictureBoxRobotExecut.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBoxRobotExecut.Name = "pictureBoxRobotExecut";
            this.pictureBoxRobotExecut.Size = new System.Drawing.Size(29, 28);
            this.pictureBoxRobotExecut.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxRobotExecut.TabIndex = 8;
            this.pictureBoxRobotExecut.TabStop = false;
            // 
            // customLabel2
            // 
            this.customLabel2.AutoSize = true;
            this.customLabel2.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.customLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.customLabel2.Location = new System.Drawing.Point(27, 136);
            this.customLabel2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.customLabel2.Name = "customLabel2";
            this.customLabel2.Size = new System.Drawing.Size(75, 28);
            this.customLabel2.TabIndex = 7;
            this.customLabel2.Text = "脚本：";
            // 
            // CButtonReset
            // 
            this.CButtonReset.BackColor = System.Drawing.Color.SteelBlue;
            this.CButtonReset.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CButtonReset.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.CButtonReset.ForeColor = System.Drawing.Color.Transparent;
            this.CButtonReset.Location = new System.Drawing.Point(171, 82);
            this.CButtonReset.Margin = new System.Windows.Forms.Padding(4);
            this.CButtonReset.Name = "CButtonReset";
            this.CButtonReset.Size = new System.Drawing.Size(120, 45);
            this.CButtonReset.TabIndex = 6;
            this.CButtonReset.Text = "复位";
            this.CButtonReset.UseVisualStyleBackColor = false;
            this.CButtonReset.Click += new System.EventHandler(this.CButtonReset_Click);
            // 
            // pictureBoxRobotAlarm
            // 
            this.pictureBoxRobotAlarm.Image = global::RobotWorkstation.Properties.Resources.SmallDarkRed;
            this.pictureBoxRobotAlarm.Location = new System.Drawing.Point(115, 92);
            this.pictureBoxRobotAlarm.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBoxRobotAlarm.Name = "pictureBoxRobotAlarm";
            this.pictureBoxRobotAlarm.Size = new System.Drawing.Size(29, 28);
            this.pictureBoxRobotAlarm.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxRobotAlarm.TabIndex = 5;
            this.pictureBoxRobotAlarm.TabStop = false;
            // 
            // customLabel1
            // 
            this.customLabel1.AutoSize = true;
            this.customLabel1.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.customLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.customLabel1.Location = new System.Drawing.Point(27, 90);
            this.customLabel1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.customLabel1.Name = "customLabel1";
            this.customLabel1.Size = new System.Drawing.Size(75, 28);
            this.customLabel1.TabIndex = 4;
            this.customLabel1.Text = "警告：";
            // 
            // CButtonServoOff
            // 
            this.CButtonServoOff.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.CButtonServoOff.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CButtonServoOff.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.CButtonServoOff.ForeColor = System.Drawing.Color.Transparent;
            this.CButtonServoOff.Location = new System.Drawing.Point(301, 35);
            this.CButtonServoOff.Margin = new System.Windows.Forms.Padding(4);
            this.CButtonServoOff.Name = "CButtonServoOff";
            this.CButtonServoOff.Size = new System.Drawing.Size(120, 45);
            this.CButtonServoOff.TabIndex = 3;
            this.CButtonServoOff.Text = "伺服关";
            this.CButtonServoOff.UseVisualStyleBackColor = false;
            this.CButtonServoOff.Click += new System.EventHandler(this.CButtonServoOff_Click);
            // 
            // CBttonServoOn
            // 
            this.CBttonServoOn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.CBttonServoOn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CBttonServoOn.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.CBttonServoOn.ForeColor = System.Drawing.Color.White;
            this.CBttonServoOn.Location = new System.Drawing.Point(171, 35);
            this.CBttonServoOn.Margin = new System.Windows.Forms.Padding(4);
            this.CBttonServoOn.Name = "CBttonServoOn";
            this.CBttonServoOn.Size = new System.Drawing.Size(120, 45);
            this.CBttonServoOn.TabIndex = 2;
            this.CBttonServoOn.Text = "伺服开";
            this.CBttonServoOn.UseVisualStyleBackColor = false;
            this.CBttonServoOn.Click += new System.EventHandler(this.CBttonServoOn_Click);
            // 
            // pictureBoxServo
            // 
            this.pictureBoxServo.Image = global::RobotWorkstation.Properties.Resources.SmallDarkGreen;
            this.pictureBoxServo.Location = new System.Drawing.Point(115, 46);
            this.pictureBoxServo.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBoxServo.Name = "pictureBoxServo";
            this.pictureBoxServo.Size = new System.Drawing.Size(29, 28);
            this.pictureBoxServo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxServo.TabIndex = 1;
            this.pictureBoxServo.TabStop = false;
            // 
            // tabPageOthers
            // 
            this.tabPageOthers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.tabPageOthers.Controls.Add(this.CGrpTurnOver);
            this.tabPageOthers.Controls.Add(this.CGrpAxisConveyor);
            this.tabPageOthers.Controls.Add(this.customGroupBox13);
            this.tabPageOthers.Controls.Add(this.customGroupBox12);
            this.tabPageOthers.Controls.Add(this.customGroupBox11);
            this.tabPageOthers.Controls.Add(this.customGroupBox10);
            this.tabPageOthers.Controls.Add(this.customGroupBox7);
            this.tabPageOthers.ForeColor = System.Drawing.Color.White;
            this.tabPageOthers.Location = new System.Drawing.Point(0, 29);
            this.tabPageOthers.Margin = new System.Windows.Forms.Padding(4);
            this.tabPageOthers.Name = "tabPageOthers";
            this.tabPageOthers.Size = new System.Drawing.Size(1664, 993);
            this.tabPageOthers.TabIndex = 3;
            this.tabPageOthers.Text = "其他";
            // 
            // CGrpTurnOver
            // 
            this.CGrpTurnOver.Controls.Add(this.CBtnTurnOverAxisErrorReset);
            this.CGrpTurnOver.Controls.Add(this.CTxtAxisTurnOverState);
            this.CGrpTurnOver.Controls.Add(this.customLabel34);
            this.CGrpTurnOver.Controls.Add(this.PicOverturnCylUnLock);
            this.CGrpTurnOver.Controls.Add(this.PicOverturnCylLock);
            this.CGrpTurnOver.Controls.Add(this.PicOverturn);
            this.CGrpTurnOver.Controls.Add(this.customLabel31);
            this.CGrpTurnOver.Controls.Add(this.customLabel30);
            this.CGrpTurnOver.Controls.Add(this.customLabel29);
            this.CGrpTurnOver.Controls.Add(this.CBtnTurnOverReset);
            this.CGrpTurnOver.Controls.Add(this.CBtnTurnOverLockCylClose);
            this.CGrpTurnOver.Controls.Add(this.CBtnTurnOverLockCylOpen);
            this.CGrpTurnOver.Controls.Add(this.CBtnTurnOver);
            this.CGrpTurnOver.Controls.Add(this.CTxtAxisTurnOverStep);
            this.CGrpTurnOver.Controls.Add(this.customLabel28);
            this.CGrpTurnOver.Controls.Add(this.CTxtAxisTurnOverSpeed);
            this.CGrpTurnOver.Controls.Add(this.customLabel27);
            this.CGrpTurnOver.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.CGrpTurnOver.Location = new System.Drawing.Point(885, 434);
            this.CGrpTurnOver.Margin = new System.Windows.Forms.Padding(4);
            this.CGrpTurnOver.Name = "CGrpTurnOver";
            this.CGrpTurnOver.Padding = new System.Windows.Forms.Padding(4);
            this.CGrpTurnOver.Size = new System.Drawing.Size(675, 271);
            this.CGrpTurnOver.TabIndex = 21;
            this.CGrpTurnOver.TabStop = false;
            this.CGrpTurnOver.Text = "翻转机构";
            // 
            // CBtnTurnOverAxisErrorReset
            // 
            this.CBtnTurnOverAxisErrorReset.BackColor = System.Drawing.Color.SteelBlue;
            this.CBtnTurnOverAxisErrorReset.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CBtnTurnOverAxisErrorReset.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.CBtnTurnOverAxisErrorReset.ForeColor = System.Drawing.Color.Transparent;
            this.CBtnTurnOverAxisErrorReset.Location = new System.Drawing.Point(403, 198);
            this.CBtnTurnOverAxisErrorReset.Margin = new System.Windows.Forms.Padding(4);
            this.CBtnTurnOverAxisErrorReset.Name = "CBtnTurnOverAxisErrorReset";
            this.CBtnTurnOverAxisErrorReset.Size = new System.Drawing.Size(120, 45);
            this.CBtnTurnOverAxisErrorReset.TabIndex = 23;
            this.CBtnTurnOverAxisErrorReset.Text = "错误复位";
            this.CBtnTurnOverAxisErrorReset.UseVisualStyleBackColor = false;
            this.CBtnTurnOverAxisErrorReset.Click += new System.EventHandler(this.CBtnTurnOverAxisErrorReset_Click);
            // 
            // CTxtAxisTurnOverState
            // 
            this.CTxtAxisTurnOverState.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.CTxtAxisTurnOverState.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CTxtAxisTurnOverState.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.CTxtAxisTurnOverState.ForeColor = System.Drawing.Color.White;
            this.CTxtAxisTurnOverState.Location = new System.Drawing.Point(141, 201);
            this.CTxtAxisTurnOverState.Margin = new System.Windows.Forms.Padding(4);
            this.CTxtAxisTurnOverState.Multiline = true;
            this.CTxtAxisTurnOverState.Name = "CTxtAxisTurnOverState";
            this.CTxtAxisTurnOverState.Size = new System.Drawing.Size(246, 40);
            this.CTxtAxisTurnOverState.TabIndex = 22;
            // 
            // customLabel34
            // 
            this.customLabel34.AutoSize = true;
            this.customLabel34.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.customLabel34.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.customLabel34.Location = new System.Drawing.Point(12, 204);
            this.customLabel34.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.customLabel34.Name = "customLabel34";
            this.customLabel34.Size = new System.Drawing.Size(117, 28);
            this.customLabel34.TabIndex = 21;
            this.customLabel34.Text = "电机状态：";
            // 
            // PicOverturnCylUnLock
            // 
            this.PicOverturnCylUnLock.Image = global::RobotWorkstation.Properties.Resources.SmallDarkGreen;
            this.PicOverturnCylUnLock.Location = new System.Drawing.Point(615, 44);
            this.PicOverturnCylUnLock.Margin = new System.Windows.Forms.Padding(4);
            this.PicOverturnCylUnLock.Name = "PicOverturnCylUnLock";
            this.PicOverturnCylUnLock.Size = new System.Drawing.Size(29, 28);
            this.PicOverturnCylUnLock.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PicOverturnCylUnLock.TabIndex = 20;
            this.PicOverturnCylUnLock.TabStop = false;
            // 
            // PicOverturnCylLock
            // 
            this.PicOverturnCylLock.Image = global::RobotWorkstation.Properties.Resources.SmallDarkGreen;
            this.PicOverturnCylLock.Location = new System.Drawing.Point(377, 44);
            this.PicOverturnCylLock.Margin = new System.Windows.Forms.Padding(4);
            this.PicOverturnCylLock.Name = "PicOverturnCylLock";
            this.PicOverturnCylLock.Size = new System.Drawing.Size(29, 28);
            this.PicOverturnCylLock.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PicOverturnCylLock.TabIndex = 19;
            this.PicOverturnCylLock.TabStop = false;
            // 
            // PicOverturn
            // 
            this.PicOverturn.Image = global::RobotWorkstation.Properties.Resources.SmallDarkGreen;
            this.PicOverturn.Location = new System.Drawing.Point(141, 44);
            this.PicOverturn.Margin = new System.Windows.Forms.Padding(4);
            this.PicOverturn.Name = "PicOverturn";
            this.PicOverturn.Size = new System.Drawing.Size(29, 28);
            this.PicOverturn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PicOverturn.TabIndex = 18;
            this.PicOverturn.TabStop = false;
            // 
            // customLabel31
            // 
            this.customLabel31.AutoSize = true;
            this.customLabel31.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.customLabel31.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.customLabel31.Location = new System.Drawing.Point(492, 42);
            this.customLabel31.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.customLabel31.Name = "customLabel31";
            this.customLabel31.Size = new System.Drawing.Size(117, 28);
            this.customLabel31.TabIndex = 10;
            this.customLabel31.Text = "解锁到位：";
            // 
            // customLabel30
            // 
            this.customLabel30.AutoSize = true;
            this.customLabel30.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.customLabel30.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.customLabel30.Location = new System.Drawing.Point(255, 44);
            this.customLabel30.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.customLabel30.Name = "customLabel30";
            this.customLabel30.Size = new System.Drawing.Size(117, 28);
            this.customLabel30.TabIndex = 9;
            this.customLabel30.Text = "锁定到位：";
            // 
            // customLabel29
            // 
            this.customLabel29.AutoSize = true;
            this.customLabel29.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.customLabel29.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.customLabel29.Location = new System.Drawing.Point(13, 42);
            this.customLabel29.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.customLabel29.Name = "customLabel29";
            this.customLabel29.Size = new System.Drawing.Size(117, 28);
            this.customLabel29.TabIndex = 8;
            this.customLabel29.Text = "翻转到位：";
            // 
            // CBtnTurnOverReset
            // 
            this.CBtnTurnOverReset.BackColor = System.Drawing.Color.SteelBlue;
            this.CBtnTurnOverReset.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CBtnTurnOverReset.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.CBtnTurnOverReset.ForeColor = System.Drawing.Color.Transparent;
            this.CBtnTurnOverReset.Location = new System.Drawing.Point(531, 90);
            this.CBtnTurnOverReset.Margin = new System.Windows.Forms.Padding(4);
            this.CBtnTurnOverReset.Name = "CBtnTurnOverReset";
            this.CBtnTurnOverReset.Size = new System.Drawing.Size(120, 45);
            this.CBtnTurnOverReset.TabIndex = 7;
            this.CBtnTurnOverReset.Text = "复位";
            this.CBtnTurnOverReset.UseVisualStyleBackColor = false;
            this.CBtnTurnOverReset.Click += new System.EventHandler(this.CBtnTurnOverReset_Click);
            // 
            // CBtnTurnOverLockCylClose
            // 
            this.CBtnTurnOverLockCylClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.CBtnTurnOverLockCylClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CBtnTurnOverLockCylClose.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.CBtnTurnOverLockCylClose.ForeColor = System.Drawing.Color.Transparent;
            this.CBtnTurnOverLockCylClose.Location = new System.Drawing.Point(531, 144);
            this.CBtnTurnOverLockCylClose.Margin = new System.Windows.Forms.Padding(4);
            this.CBtnTurnOverLockCylClose.Name = "CBtnTurnOverLockCylClose";
            this.CBtnTurnOverLockCylClose.Size = new System.Drawing.Size(120, 45);
            this.CBtnTurnOverLockCylClose.TabIndex = 6;
            this.CBtnTurnOverLockCylClose.Text = "锁气缸关";
            this.CBtnTurnOverLockCylClose.UseVisualStyleBackColor = false;
            this.CBtnTurnOverLockCylClose.Click += new System.EventHandler(this.CBtnTurnOverLockCylClose_Click);
            // 
            // CBtnTurnOverLockCylOpen
            // 
            this.CBtnTurnOverLockCylOpen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.CBtnTurnOverLockCylOpen.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CBtnTurnOverLockCylOpen.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.CBtnTurnOverLockCylOpen.ForeColor = System.Drawing.Color.Transparent;
            this.CBtnTurnOverLockCylOpen.Location = new System.Drawing.Point(403, 144);
            this.CBtnTurnOverLockCylOpen.Margin = new System.Windows.Forms.Padding(4);
            this.CBtnTurnOverLockCylOpen.Name = "CBtnTurnOverLockCylOpen";
            this.CBtnTurnOverLockCylOpen.Size = new System.Drawing.Size(120, 45);
            this.CBtnTurnOverLockCylOpen.TabIndex = 5;
            this.CBtnTurnOverLockCylOpen.Text = "锁气缸开";
            this.CBtnTurnOverLockCylOpen.UseVisualStyleBackColor = false;
            this.CBtnTurnOverLockCylOpen.Click += new System.EventHandler(this.CBtnTurnOverLockCylOpen_Click);
            // 
            // CBtnTurnOver
            // 
            this.CBtnTurnOver.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.CBtnTurnOver.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CBtnTurnOver.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.CBtnTurnOver.ForeColor = System.Drawing.Color.Transparent;
            this.CBtnTurnOver.Location = new System.Drawing.Point(403, 91);
            this.CBtnTurnOver.Margin = new System.Windows.Forms.Padding(4);
            this.CBtnTurnOver.Name = "CBtnTurnOver";
            this.CBtnTurnOver.Size = new System.Drawing.Size(120, 45);
            this.CBtnTurnOver.TabIndex = 4;
            this.CBtnTurnOver.Text = "翻转";
            this.CBtnTurnOver.UseVisualStyleBackColor = false;
            this.CBtnTurnOver.Click += new System.EventHandler(this.CBtnTurnOver_Click);
            // 
            // CTxtAxisTurnOverStep
            // 
            this.CTxtAxisTurnOverStep.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.CTxtAxisTurnOverStep.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CTxtAxisTurnOverStep.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.CTxtAxisTurnOverStep.ForeColor = System.Drawing.Color.White;
            this.CTxtAxisTurnOverStep.Location = new System.Drawing.Point(141, 149);
            this.CTxtAxisTurnOverStep.Margin = new System.Windows.Forms.Padding(4);
            this.CTxtAxisTurnOverStep.Multiline = true;
            this.CTxtAxisTurnOverStep.Name = "CTxtAxisTurnOverStep";
            this.CTxtAxisTurnOverStep.Size = new System.Drawing.Size(119, 40);
            this.CTxtAxisTurnOverStep.TabIndex = 3;
            this.CTxtAxisTurnOverStep.Text = "5000";
            // 
            // customLabel28
            // 
            this.customLabel28.AutoSize = true;
            this.customLabel28.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.customLabel28.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.customLabel28.Location = new System.Drawing.Point(13, 150);
            this.customLabel28.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.customLabel28.Name = "customLabel28";
            this.customLabel28.Size = new System.Drawing.Size(117, 28);
            this.customLabel28.TabIndex = 2;
            this.customLabel28.Text = "翻转步进：";
            // 
            // CTxtAxisTurnOverSpeed
            // 
            this.CTxtAxisTurnOverSpeed.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.CTxtAxisTurnOverSpeed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CTxtAxisTurnOverSpeed.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.CTxtAxisTurnOverSpeed.ForeColor = System.Drawing.Color.White;
            this.CTxtAxisTurnOverSpeed.Location = new System.Drawing.Point(141, 95);
            this.CTxtAxisTurnOverSpeed.Margin = new System.Windows.Forms.Padding(4);
            this.CTxtAxisTurnOverSpeed.Multiline = true;
            this.CTxtAxisTurnOverSpeed.Name = "CTxtAxisTurnOverSpeed";
            this.CTxtAxisTurnOverSpeed.Size = new System.Drawing.Size(119, 40);
            this.CTxtAxisTurnOverSpeed.TabIndex = 1;
            this.CTxtAxisTurnOverSpeed.Text = "8000";
            // 
            // customLabel27
            // 
            this.customLabel27.AutoSize = true;
            this.customLabel27.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.customLabel27.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.customLabel27.Location = new System.Drawing.Point(13, 96);
            this.customLabel27.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.customLabel27.Name = "customLabel27";
            this.customLabel27.Size = new System.Drawing.Size(117, 28);
            this.customLabel27.TabIndex = 0;
            this.customLabel27.Text = "翻转速度：";
            // 
            // CGrpAxisConveyor
            // 
            this.CGrpAxisConveyor.Controls.Add(this.BtnAxisConveyorResetError);
            this.CGrpAxisConveyor.Controls.Add(this.CTxtAxisConveyorrState);
            this.CGrpAxisConveyor.Controls.Add(this.customLabel26);
            this.CGrpAxisConveyor.Controls.Add(this.BtnAxisConveyorDec);
            this.CGrpAxisConveyor.Controls.Add(this.BtnAxisConveyorAdd);
            this.CGrpAxisConveyor.Controls.Add(this.CBtnAxisConveyorStop);
            this.CGrpAxisConveyor.Controls.Add(this.CBtnAxisConveyorMoveReverse);
            this.CGrpAxisConveyor.Controls.Add(this.CBtnAxisConveyorMoveForward);
            this.CGrpAxisConveyor.Controls.Add(this.customLabel25);
            this.CGrpAxisConveyor.Controls.Add(this.CTxtAxisConveyorrStepPpu);
            this.CGrpAxisConveyor.Controls.Add(this.customLabel22);
            this.CGrpAxisConveyor.Controls.Add(this.CTxtAxisConveyorSpeedDec);
            this.CGrpAxisConveyor.Controls.Add(this.customLabel23);
            this.CGrpAxisConveyor.Controls.Add(this.CTxtAxisConveyorSpeedAdd);
            this.CGrpAxisConveyor.Controls.Add(this.customLabel24);
            this.CGrpAxisConveyor.Controls.Add(this.CTxtAxisConveyorCurPos);
            this.CGrpAxisConveyor.Controls.Add(this.customLabel21);
            this.CGrpAxisConveyor.Controls.Add(this.CTxtAxisConveyorSpeedRun);
            this.CGrpAxisConveyor.Controls.Add(this.customLabel20);
            this.CGrpAxisConveyor.Controls.Add(this.CTxtAxisConveyorSpeedStart);
            this.CGrpAxisConveyor.Controls.Add(this.customLabel10);
            this.CGrpAxisConveyor.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.CGrpAxisConveyor.Location = new System.Drawing.Point(4, 434);
            this.CGrpAxisConveyor.Margin = new System.Windows.Forms.Padding(4);
            this.CGrpAxisConveyor.Name = "CGrpAxisConveyor";
            this.CGrpAxisConveyor.Padding = new System.Windows.Forms.Padding(4);
            this.CGrpAxisConveyor.Size = new System.Drawing.Size(852, 271);
            this.CGrpAxisConveyor.TabIndex = 20;
            this.CGrpAxisConveyor.TabStop = false;
            this.CGrpAxisConveyor.Text = "传输线电机轴";
            // 
            // BtnAxisConveyorResetError
            // 
            this.BtnAxisConveyorResetError.BackColor = System.Drawing.Color.SteelBlue;
            this.BtnAxisConveyorResetError.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnAxisConveyorResetError.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.BtnAxisConveyorResetError.ForeColor = System.Drawing.Color.Transparent;
            this.BtnAxisConveyorResetError.Location = new System.Drawing.Point(529, 198);
            this.BtnAxisConveyorResetError.Margin = new System.Windows.Forms.Padding(4);
            this.BtnAxisConveyorResetError.Name = "BtnAxisConveyorResetError";
            this.BtnAxisConveyorResetError.Size = new System.Drawing.Size(120, 45);
            this.BtnAxisConveyorResetError.TabIndex = 20;
            this.BtnAxisConveyorResetError.Text = "错误复位";
            this.BtnAxisConveyorResetError.UseVisualStyleBackColor = false;
            this.BtnAxisConveyorResetError.Click += new System.EventHandler(this.BtnAxisConveyorResetError_Click);
            // 
            // CTxtAxisConveyorrState
            // 
            this.CTxtAxisConveyorrState.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.CTxtAxisConveyorrState.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CTxtAxisConveyorrState.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.CTxtAxisConveyorrState.ForeColor = System.Drawing.Color.White;
            this.CTxtAxisConveyorrState.Location = new System.Drawing.Point(143, 204);
            this.CTxtAxisConveyorrState.Margin = new System.Windows.Forms.Padding(4);
            this.CTxtAxisConveyorrState.Multiline = true;
            this.CTxtAxisConveyorrState.Name = "CTxtAxisConveyorrState";
            this.CTxtAxisConveyorrState.Size = new System.Drawing.Size(246, 40);
            this.CTxtAxisConveyorrState.TabIndex = 19;
            // 
            // customLabel26
            // 
            this.customLabel26.AutoSize = true;
            this.customLabel26.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.customLabel26.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.customLabel26.Location = new System.Drawing.Point(8, 206);
            this.customLabel26.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.customLabel26.Name = "customLabel26";
            this.customLabel26.Size = new System.Drawing.Size(117, 28);
            this.customLabel26.TabIndex = 18;
            this.customLabel26.Text = "电机状态：";
            // 
            // BtnAxisConveyorDec
            // 
            this.BtnAxisConveyorDec.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.BtnAxisConveyorDec.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnAxisConveyorDec.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.BtnAxisConveyorDec.ForeColor = System.Drawing.Color.Transparent;
            this.BtnAxisConveyorDec.Location = new System.Drawing.Point(657, 141);
            this.BtnAxisConveyorDec.Margin = new System.Windows.Forms.Padding(4);
            this.BtnAxisConveyorDec.Name = "BtnAxisConveyorDec";
            this.BtnAxisConveyorDec.Size = new System.Drawing.Size(120, 45);
            this.BtnAxisConveyorDec.TabIndex = 17;
            this.BtnAxisConveyorDec.Text = "移动 -";
            this.BtnAxisConveyorDec.UseVisualStyleBackColor = false;
            this.BtnAxisConveyorDec.Click += new System.EventHandler(this.BtnAxisConveyorDec_Click);
            // 
            // BtnAxisConveyorAdd
            // 
            this.BtnAxisConveyorAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.BtnAxisConveyorAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnAxisConveyorAdd.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.BtnAxisConveyorAdd.ForeColor = System.Drawing.Color.Transparent;
            this.BtnAxisConveyorAdd.Location = new System.Drawing.Point(529, 141);
            this.BtnAxisConveyorAdd.Margin = new System.Windows.Forms.Padding(4);
            this.BtnAxisConveyorAdd.Name = "BtnAxisConveyorAdd";
            this.BtnAxisConveyorAdd.Size = new System.Drawing.Size(120, 45);
            this.BtnAxisConveyorAdd.TabIndex = 16;
            this.BtnAxisConveyorAdd.Text = "移动 +";
            this.BtnAxisConveyorAdd.UseVisualStyleBackColor = false;
            this.BtnAxisConveyorAdd.Click += new System.EventHandler(this.BtnAxisConveyorAdd_Click);
            // 
            // CBtnAxisConveyorStop
            // 
            this.CBtnAxisConveyorStop.BackColor = System.Drawing.Color.Red;
            this.CBtnAxisConveyorStop.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CBtnAxisConveyorStop.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.CBtnAxisConveyorStop.ForeColor = System.Drawing.Color.Transparent;
            this.CBtnAxisConveyorStop.Location = new System.Drawing.Point(269, 141);
            this.CBtnAxisConveyorStop.Margin = new System.Windows.Forms.Padding(4);
            this.CBtnAxisConveyorStop.Name = "CBtnAxisConveyorStop";
            this.CBtnAxisConveyorStop.Size = new System.Drawing.Size(120, 45);
            this.CBtnAxisConveyorStop.TabIndex = 15;
            this.CBtnAxisConveyorStop.Text = "停止";
            this.CBtnAxisConveyorStop.UseVisualStyleBackColor = false;
            this.CBtnAxisConveyorStop.Click += new System.EventHandler(this.CBtnAxisConveyorStop_Click);
            // 
            // CBtnAxisConveyorMoveReverse
            // 
            this.CBtnAxisConveyorMoveReverse.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.CBtnAxisConveyorMoveReverse.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CBtnAxisConveyorMoveReverse.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.CBtnAxisConveyorMoveReverse.ForeColor = System.Drawing.Color.Transparent;
            this.CBtnAxisConveyorMoveReverse.Location = new System.Drawing.Point(141, 141);
            this.CBtnAxisConveyorMoveReverse.Margin = new System.Windows.Forms.Padding(4);
            this.CBtnAxisConveyorMoveReverse.Name = "CBtnAxisConveyorMoveReverse";
            this.CBtnAxisConveyorMoveReverse.Size = new System.Drawing.Size(120, 45);
            this.CBtnAxisConveyorMoveReverse.TabIndex = 14;
            this.CBtnAxisConveyorMoveReverse.Text = "连续反转";
            this.CBtnAxisConveyorMoveReverse.UseVisualStyleBackColor = false;
            this.CBtnAxisConveyorMoveReverse.Click += new System.EventHandler(this.CBtnAxisConveyorMoveReverse_Click);
            // 
            // CBtnAxisConveyorMoveForward
            // 
            this.CBtnAxisConveyorMoveForward.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.CBtnAxisConveyorMoveForward.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CBtnAxisConveyorMoveForward.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.CBtnAxisConveyorMoveForward.ForeColor = System.Drawing.Color.Transparent;
            this.CBtnAxisConveyorMoveForward.Location = new System.Drawing.Point(13, 141);
            this.CBtnAxisConveyorMoveForward.Margin = new System.Windows.Forms.Padding(4);
            this.CBtnAxisConveyorMoveForward.Name = "CBtnAxisConveyorMoveForward";
            this.CBtnAxisConveyorMoveForward.Size = new System.Drawing.Size(120, 45);
            this.CBtnAxisConveyorMoveForward.TabIndex = 13;
            this.CBtnAxisConveyorMoveForward.Text = "连续正转";
            this.CBtnAxisConveyorMoveForward.UseVisualStyleBackColor = false;
            this.CBtnAxisConveyorMoveForward.Click += new System.EventHandler(this.CBtnAxisConveyorMoveForward_Click);
            // 
            // customLabel25
            // 
            this.customLabel25.AutoSize = true;
            this.customLabel25.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.customLabel25.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.customLabel25.Location = new System.Drawing.Point(785, 94);
            this.customLabel25.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.customLabel25.Name = "customLabel25";
            this.customLabel25.Size = new System.Drawing.Size(54, 28);
            this.customLabel25.TabIndex = 12;
            this.customLabel25.Text = "PPU";
            // 
            // CTxtAxisConveyorrStepPpu
            // 
            this.CTxtAxisConveyorrStepPpu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.CTxtAxisConveyorrStepPpu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CTxtAxisConveyorrStepPpu.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.CTxtAxisConveyorrStepPpu.ForeColor = System.Drawing.Color.White;
            this.CTxtAxisConveyorrStepPpu.Location = new System.Drawing.Point(657, 88);
            this.CTxtAxisConveyorrStepPpu.Margin = new System.Windows.Forms.Padding(4);
            this.CTxtAxisConveyorrStepPpu.Multiline = true;
            this.CTxtAxisConveyorrStepPpu.Name = "CTxtAxisConveyorrStepPpu";
            this.CTxtAxisConveyorrStepPpu.Size = new System.Drawing.Size(119, 40);
            this.CTxtAxisConveyorrStepPpu.TabIndex = 11;
            this.CTxtAxisConveyorrStepPpu.Text = "5000";
            // 
            // customLabel22
            // 
            this.customLabel22.AutoSize = true;
            this.customLabel22.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.customLabel22.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.customLabel22.Location = new System.Drawing.Point(537, 91);
            this.customLabel22.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.customLabel22.Name = "customLabel22";
            this.customLabel22.Size = new System.Drawing.Size(117, 28);
            this.customLabel22.TabIndex = 10;
            this.customLabel22.Text = "步进距离：";
            // 
            // CTxtAxisConveyorSpeedDec
            // 
            this.CTxtAxisConveyorSpeedDec.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.CTxtAxisConveyorSpeedDec.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CTxtAxisConveyorSpeedDec.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.CTxtAxisConveyorSpeedDec.ForeColor = System.Drawing.Color.White;
            this.CTxtAxisConveyorSpeedDec.Location = new System.Drawing.Point(404, 88);
            this.CTxtAxisConveyorSpeedDec.Margin = new System.Windows.Forms.Padding(4);
            this.CTxtAxisConveyorSpeedDec.Multiline = true;
            this.CTxtAxisConveyorSpeedDec.Name = "CTxtAxisConveyorSpeedDec";
            this.CTxtAxisConveyorSpeedDec.Size = new System.Drawing.Size(119, 40);
            this.CTxtAxisConveyorSpeedDec.TabIndex = 9;
            this.CTxtAxisConveyorSpeedDec.Text = "10000";
            // 
            // customLabel23
            // 
            this.customLabel23.AutoSize = true;
            this.customLabel23.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.customLabel23.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.customLabel23.Location = new System.Drawing.Point(292, 91);
            this.customLabel23.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.customLabel23.Name = "customLabel23";
            this.customLabel23.Size = new System.Drawing.Size(96, 28);
            this.customLabel23.TabIndex = 8;
            this.customLabel23.Text = "减速度：";
            // 
            // CTxtAxisConveyorSpeedAdd
            // 
            this.CTxtAxisConveyorSpeedAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.CTxtAxisConveyorSpeedAdd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CTxtAxisConveyorSpeedAdd.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.CTxtAxisConveyorSpeedAdd.ForeColor = System.Drawing.Color.White;
            this.CTxtAxisConveyorSpeedAdd.Location = new System.Drawing.Point(137, 88);
            this.CTxtAxisConveyorSpeedAdd.Margin = new System.Windows.Forms.Padding(4);
            this.CTxtAxisConveyorSpeedAdd.Multiline = true;
            this.CTxtAxisConveyorSpeedAdd.Name = "CTxtAxisConveyorSpeedAdd";
            this.CTxtAxisConveyorSpeedAdd.Size = new System.Drawing.Size(119, 40);
            this.CTxtAxisConveyorSpeedAdd.TabIndex = 7;
            this.CTxtAxisConveyorSpeedAdd.Text = "10000";
            // 
            // customLabel24
            // 
            this.customLabel24.AutoSize = true;
            this.customLabel24.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.customLabel24.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.customLabel24.Location = new System.Drawing.Point(31, 91);
            this.customLabel24.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.customLabel24.Name = "customLabel24";
            this.customLabel24.Size = new System.Drawing.Size(96, 28);
            this.customLabel24.TabIndex = 6;
            this.customLabel24.Text = "加速度：";
            // 
            // CTxtAxisConveyorCurPos
            // 
            this.CTxtAxisConveyorCurPos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.CTxtAxisConveyorCurPos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CTxtAxisConveyorCurPos.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.CTxtAxisConveyorCurPos.ForeColor = System.Drawing.Color.White;
            this.CTxtAxisConveyorCurPos.Location = new System.Drawing.Point(657, 40);
            this.CTxtAxisConveyorCurPos.Margin = new System.Windows.Forms.Padding(4);
            this.CTxtAxisConveyorCurPos.Multiline = true;
            this.CTxtAxisConveyorCurPos.Name = "CTxtAxisConveyorCurPos";
            this.CTxtAxisConveyorCurPos.Size = new System.Drawing.Size(119, 40);
            this.CTxtAxisConveyorCurPos.TabIndex = 5;
            this.CTxtAxisConveyorCurPos.Text = "0";
            // 
            // customLabel21
            // 
            this.customLabel21.AutoSize = true;
            this.customLabel21.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.customLabel21.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.customLabel21.Location = new System.Drawing.Point(537, 42);
            this.customLabel21.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.customLabel21.Name = "customLabel21";
            this.customLabel21.Size = new System.Drawing.Size(117, 28);
            this.customLabel21.TabIndex = 4;
            this.customLabel21.Text = "当前位置：";
            // 
            // CTxtAxisConveyorSpeedRun
            // 
            this.CTxtAxisConveyorSpeedRun.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.CTxtAxisConveyorSpeedRun.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CTxtAxisConveyorSpeedRun.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.CTxtAxisConveyorSpeedRun.ForeColor = System.Drawing.Color.White;
            this.CTxtAxisConveyorSpeedRun.Location = new System.Drawing.Point(404, 40);
            this.CTxtAxisConveyorSpeedRun.Margin = new System.Windows.Forms.Padding(4);
            this.CTxtAxisConveyorSpeedRun.Multiline = true;
            this.CTxtAxisConveyorSpeedRun.Name = "CTxtAxisConveyorSpeedRun";
            this.CTxtAxisConveyorSpeedRun.Size = new System.Drawing.Size(119, 40);
            this.CTxtAxisConveyorSpeedRun.TabIndex = 3;
            this.CTxtAxisConveyorSpeedRun.Text = "8000";
            // 
            // customLabel20
            // 
            this.customLabel20.AutoSize = true;
            this.customLabel20.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.customLabel20.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.customLabel20.Location = new System.Drawing.Point(269, 42);
            this.customLabel20.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.customLabel20.Name = "customLabel20";
            this.customLabel20.Size = new System.Drawing.Size(117, 28);
            this.customLabel20.TabIndex = 2;
            this.customLabel20.Text = "运行速度：";
            // 
            // CTxtAxisConveyorSpeedStart
            // 
            this.CTxtAxisConveyorSpeedStart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.CTxtAxisConveyorSpeedStart.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CTxtAxisConveyorSpeedStart.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.CTxtAxisConveyorSpeedStart.ForeColor = System.Drawing.Color.White;
            this.CTxtAxisConveyorSpeedStart.Location = new System.Drawing.Point(137, 40);
            this.CTxtAxisConveyorSpeedStart.Margin = new System.Windows.Forms.Padding(4);
            this.CTxtAxisConveyorSpeedStart.Multiline = true;
            this.CTxtAxisConveyorSpeedStart.Name = "CTxtAxisConveyorSpeedStart";
            this.CTxtAxisConveyorSpeedStart.Size = new System.Drawing.Size(119, 40);
            this.CTxtAxisConveyorSpeedStart.TabIndex = 1;
            this.CTxtAxisConveyorSpeedStart.Text = "2000";
            // 
            // customLabel10
            // 
            this.customLabel10.AutoSize = true;
            this.customLabel10.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.customLabel10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.customLabel10.Location = new System.Drawing.Point(8, 42);
            this.customLabel10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.customLabel10.Name = "customLabel10";
            this.customLabel10.Size = new System.Drawing.Size(117, 28);
            this.customLabel10.TabIndex = 0;
            this.customLabel10.Text = "初始速度：";
            // 
            // customGroupBox13
            // 
            this.customGroupBox13.Controls.Add(this.PicKeyReset);
            this.customGroupBox13.Controls.Add(this.PicKeyStop);
            this.customGroupBox13.Controls.Add(this.PicKeyPause);
            this.customGroupBox13.Controls.Add(this.PicKeyRun);
            this.customGroupBox13.Controls.Add(this.customLabel52);
            this.customGroupBox13.Controls.Add(this.customLabel51);
            this.customGroupBox13.Controls.Add(this.customLabel50);
            this.customGroupBox13.Controls.Add(this.customLabel49);
            this.customGroupBox13.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.customGroupBox13.Location = new System.Drawing.Point(1384, 192);
            this.customGroupBox13.Margin = new System.Windows.Forms.Padding(4);
            this.customGroupBox13.Name = "customGroupBox13";
            this.customGroupBox13.Padding = new System.Windows.Forms.Padding(4);
            this.customGroupBox13.Size = new System.Drawing.Size(176, 234);
            this.customGroupBox13.TabIndex = 19;
            this.customGroupBox13.TabStop = false;
            this.customGroupBox13.Text = "按键";
            // 
            // PicKeyReset
            // 
            this.PicKeyReset.Image = global::RobotWorkstation.Properties.Resources.SmallDarkGreen;
            this.PicKeyReset.Location = new System.Drawing.Point(116, 184);
            this.PicKeyReset.Margin = new System.Windows.Forms.Padding(4);
            this.PicKeyReset.Name = "PicKeyReset";
            this.PicKeyReset.Size = new System.Drawing.Size(29, 28);
            this.PicKeyReset.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PicKeyReset.TabIndex = 17;
            this.PicKeyReset.TabStop = false;
            // 
            // PicKeyStop
            // 
            this.PicKeyStop.Image = global::RobotWorkstation.Properties.Resources.SmallDarkGreen;
            this.PicKeyStop.Location = new System.Drawing.Point(116, 136);
            this.PicKeyStop.Margin = new System.Windows.Forms.Padding(4);
            this.PicKeyStop.Name = "PicKeyStop";
            this.PicKeyStop.Size = new System.Drawing.Size(29, 28);
            this.PicKeyStop.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PicKeyStop.TabIndex = 16;
            this.PicKeyStop.TabStop = false;
            // 
            // PicKeyPause
            // 
            this.PicKeyPause.Image = global::RobotWorkstation.Properties.Resources.SmallDarkGreen;
            this.PicKeyPause.Location = new System.Drawing.Point(116, 90);
            this.PicKeyPause.Margin = new System.Windows.Forms.Padding(4);
            this.PicKeyPause.Name = "PicKeyPause";
            this.PicKeyPause.Size = new System.Drawing.Size(29, 28);
            this.PicKeyPause.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PicKeyPause.TabIndex = 15;
            this.PicKeyPause.TabStop = false;
            // 
            // PicKeyRun
            // 
            this.PicKeyRun.Image = global::RobotWorkstation.Properties.Resources.SmallDarkGreen;
            this.PicKeyRun.Location = new System.Drawing.Point(116, 41);
            this.PicKeyRun.Margin = new System.Windows.Forms.Padding(4);
            this.PicKeyRun.Name = "PicKeyRun";
            this.PicKeyRun.Size = new System.Drawing.Size(29, 28);
            this.PicKeyRun.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PicKeyRun.TabIndex = 14;
            this.PicKeyRun.TabStop = false;
            // 
            // customLabel52
            // 
            this.customLabel52.AutoSize = true;
            this.customLabel52.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.customLabel52.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.customLabel52.Location = new System.Drawing.Point(12, 184);
            this.customLabel52.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.customLabel52.Name = "customLabel52";
            this.customLabel52.Size = new System.Drawing.Size(75, 28);
            this.customLabel52.TabIndex = 3;
            this.customLabel52.Text = "复位：";
            // 
            // customLabel51
            // 
            this.customLabel51.AutoSize = true;
            this.customLabel51.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.customLabel51.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.customLabel51.Location = new System.Drawing.Point(12, 136);
            this.customLabel51.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.customLabel51.Name = "customLabel51";
            this.customLabel51.Size = new System.Drawing.Size(75, 28);
            this.customLabel51.TabIndex = 2;
            this.customLabel51.Text = "停止：";
            // 
            // customLabel50
            // 
            this.customLabel50.AutoSize = true;
            this.customLabel50.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.customLabel50.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.customLabel50.Location = new System.Drawing.Point(12, 89);
            this.customLabel50.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.customLabel50.Name = "customLabel50";
            this.customLabel50.Size = new System.Drawing.Size(75, 28);
            this.customLabel50.TabIndex = 1;
            this.customLabel50.Text = "暂停：";
            // 
            // customLabel49
            // 
            this.customLabel49.AutoSize = true;
            this.customLabel49.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.customLabel49.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.customLabel49.Location = new System.Drawing.Point(12, 41);
            this.customLabel49.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.customLabel49.Name = "customLabel49";
            this.customLabel49.Size = new System.Drawing.Size(75, 28);
            this.customLabel49.TabIndex = 0;
            this.customLabel49.Text = "运行：";
            // 
            // customGroupBox12
            // 
            this.customGroupBox12.Controls.Add(this.customLabel33);
            this.customGroupBox12.Controls.Add(this.customLabel32);
            this.customGroupBox12.Controls.Add(this.PicBoxEmptySalverDownArrive);
            this.customGroupBox12.Controls.Add(this.PicBoxEmptySalverUpArrive);
            this.customGroupBox12.Controls.Add(this.CButtonIoEmptyPlateUp);
            this.customGroupBox12.Controls.Add(this.CButtonIoEmptyPlateDown);
            this.customGroupBox12.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.customGroupBox12.Location = new System.Drawing.Point(885, 192);
            this.customGroupBox12.Margin = new System.Windows.Forms.Padding(4);
            this.customGroupBox12.Name = "customGroupBox12";
            this.customGroupBox12.Padding = new System.Windows.Forms.Padding(4);
            this.customGroupBox12.Size = new System.Drawing.Size(477, 234);
            this.customGroupBox12.TabIndex = 18;
            this.customGroupBox12.TabStop = false;
            this.customGroupBox12.Text = "气缸";
            // 
            // customLabel33
            // 
            this.customLabel33.AutoSize = true;
            this.customLabel33.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.customLabel33.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.customLabel33.Location = new System.Drawing.Point(35, 102);
            this.customLabel33.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.customLabel33.Name = "customLabel33";
            this.customLabel33.Size = new System.Drawing.Size(180, 28);
            this.customLabel33.TabIndex = 16;
            this.customLabel33.Text = "空盘气缸降到位：";
            // 
            // customLabel32
            // 
            this.customLabel32.AutoSize = true;
            this.customLabel32.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.customLabel32.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.customLabel32.Location = new System.Drawing.Point(35, 50);
            this.customLabel32.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.customLabel32.Name = "customLabel32";
            this.customLabel32.Size = new System.Drawing.Size(180, 28);
            this.customLabel32.TabIndex = 15;
            this.customLabel32.Text = "空盘气缸升到位：";
            // 
            // PicBoxEmptySalverDownArrive
            // 
            this.PicBoxEmptySalverDownArrive.Image = global::RobotWorkstation.Properties.Resources.SmallDarkGreen;
            this.PicBoxEmptySalverDownArrive.Location = new System.Drawing.Point(237, 104);
            this.PicBoxEmptySalverDownArrive.Margin = new System.Windows.Forms.Padding(4);
            this.PicBoxEmptySalverDownArrive.Name = "PicBoxEmptySalverDownArrive";
            this.PicBoxEmptySalverDownArrive.Size = new System.Drawing.Size(29, 28);
            this.PicBoxEmptySalverDownArrive.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PicBoxEmptySalverDownArrive.TabIndex = 14;
            this.PicBoxEmptySalverDownArrive.TabStop = false;
            // 
            // PicBoxEmptySalverUpArrive
            // 
            this.PicBoxEmptySalverUpArrive.Image = global::RobotWorkstation.Properties.Resources.SmallDarkGreen;
            this.PicBoxEmptySalverUpArrive.Location = new System.Drawing.Point(237, 51);
            this.PicBoxEmptySalverUpArrive.Margin = new System.Windows.Forms.Padding(4);
            this.PicBoxEmptySalverUpArrive.Name = "PicBoxEmptySalverUpArrive";
            this.PicBoxEmptySalverUpArrive.Size = new System.Drawing.Size(29, 28);
            this.PicBoxEmptySalverUpArrive.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PicBoxEmptySalverUpArrive.TabIndex = 13;
            this.PicBoxEmptySalverUpArrive.TabStop = false;
            // 
            // CButtonIoEmptyPlateUp
            // 
            this.CButtonIoEmptyPlateUp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.CButtonIoEmptyPlateUp.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CButtonIoEmptyPlateUp.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.CButtonIoEmptyPlateUp.ForeColor = System.Drawing.Color.Transparent;
            this.CButtonIoEmptyPlateUp.Location = new System.Drawing.Point(293, 41);
            this.CButtonIoEmptyPlateUp.Margin = new System.Windows.Forms.Padding(4);
            this.CButtonIoEmptyPlateUp.Name = "CButtonIoEmptyPlateUp";
            this.CButtonIoEmptyPlateUp.Size = new System.Drawing.Size(140, 45);
            this.CButtonIoEmptyPlateUp.TabIndex = 11;
            this.CButtonIoEmptyPlateUp.Text = "空盘气缸升";
            this.CButtonIoEmptyPlateUp.UseVisualStyleBackColor = false;
            this.CButtonIoEmptyPlateUp.Click += new System.EventHandler(this.CButtonIoEmptyPlateUp_Click_1);
            // 
            // CButtonIoEmptyPlateDown
            // 
            this.CButtonIoEmptyPlateDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.CButtonIoEmptyPlateDown.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CButtonIoEmptyPlateDown.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.CButtonIoEmptyPlateDown.ForeColor = System.Drawing.Color.Transparent;
            this.CButtonIoEmptyPlateDown.Location = new System.Drawing.Point(293, 94);
            this.CButtonIoEmptyPlateDown.Margin = new System.Windows.Forms.Padding(4);
            this.CButtonIoEmptyPlateDown.Name = "CButtonIoEmptyPlateDown";
            this.CButtonIoEmptyPlateDown.Size = new System.Drawing.Size(140, 45);
            this.CButtonIoEmptyPlateDown.TabIndex = 12;
            this.CButtonIoEmptyPlateDown.Text = "空盘气缸降";
            this.CButtonIoEmptyPlateDown.UseVisualStyleBackColor = false;
            this.CButtonIoEmptyPlateDown.Click += new System.EventHandler(this.CButtonIoEmptyPlateDown_Click_1);
            // 
            // customGroupBox11
            // 
            this.customGroupBox11.Controls.Add(this.BtnBeepOff);
            this.customGroupBox11.Controls.Add(this.BtnBeepOn);
            this.customGroupBox11.Controls.Add(this.BtnLampBlueOff);
            this.customGroupBox11.Controls.Add(this.BtnLampBlueOn);
            this.customGroupBox11.Controls.Add(this.BtnLampGreenOff);
            this.customGroupBox11.Controls.Add(this.BtnLampGreenOn);
            this.customGroupBox11.Controls.Add(this.BtnLampOrangeOff);
            this.customGroupBox11.Controls.Add(this.BtnLampOrangeOn);
            this.customGroupBox11.Controls.Add(this.BtnLampRedOff);
            this.customGroupBox11.Controls.Add(this.BtnLampRedOn);
            this.customGroupBox11.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.customGroupBox11.Location = new System.Drawing.Point(883, 4);
            this.customGroupBox11.Margin = new System.Windows.Forms.Padding(4);
            this.customGroupBox11.Name = "customGroupBox11";
            this.customGroupBox11.Padding = new System.Windows.Forms.Padding(4);
            this.customGroupBox11.Size = new System.Drawing.Size(677, 181);
            this.customGroupBox11.TabIndex = 17;
            this.customGroupBox11.TabStop = false;
            this.customGroupBox11.Text = "塔灯";
            // 
            // BtnBeepOff
            // 
            this.BtnBeepOff.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.BtnBeepOff.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnBeepOff.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.BtnBeepOff.ForeColor = System.Drawing.Color.Transparent;
            this.BtnBeepOff.Location = new System.Drawing.Point(533, 100);
            this.BtnBeepOff.Margin = new System.Windows.Forms.Padding(4);
            this.BtnBeepOff.Name = "BtnBeepOff";
            this.BtnBeepOff.Size = new System.Drawing.Size(120, 45);
            this.BtnBeepOff.TabIndex = 9;
            this.BtnBeepOff.Text = "蜂鸣关";
            this.BtnBeepOff.UseVisualStyleBackColor = false;
            this.BtnBeepOff.Click += new System.EventHandler(this.BtnBeepOff_Click);
            // 
            // BtnBeepOn
            // 
            this.BtnBeepOn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.BtnBeepOn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnBeepOn.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.BtnBeepOn.ForeColor = System.Drawing.Color.Transparent;
            this.BtnBeepOn.Location = new System.Drawing.Point(533, 45);
            this.BtnBeepOn.Margin = new System.Windows.Forms.Padding(4);
            this.BtnBeepOn.Name = "BtnBeepOn";
            this.BtnBeepOn.Size = new System.Drawing.Size(120, 45);
            this.BtnBeepOn.TabIndex = 8;
            this.BtnBeepOn.Text = "蜂鸣开";
            this.BtnBeepOn.UseVisualStyleBackColor = false;
            this.BtnBeepOn.Click += new System.EventHandler(this.BtnBeepOn_Click);
            // 
            // BtnLampBlueOff
            // 
            this.BtnLampBlueOff.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(96)))));
            this.BtnLampBlueOff.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnLampBlueOff.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.BtnLampBlueOff.ForeColor = System.Drawing.Color.Transparent;
            this.BtnLampBlueOff.Location = new System.Drawing.Point(405, 100);
            this.BtnLampBlueOff.Margin = new System.Windows.Forms.Padding(4);
            this.BtnLampBlueOff.Name = "BtnLampBlueOff";
            this.BtnLampBlueOff.Size = new System.Drawing.Size(120, 45);
            this.BtnLampBlueOff.TabIndex = 7;
            this.BtnLampBlueOff.Text = "关";
            this.BtnLampBlueOff.UseVisualStyleBackColor = false;
            this.BtnLampBlueOff.Click += new System.EventHandler(this.BtnLampBlueOff_Click);
            // 
            // BtnLampBlueOn
            // 
            this.BtnLampBlueOn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.BtnLampBlueOn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnLampBlueOn.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.BtnLampBlueOn.ForeColor = System.Drawing.Color.Transparent;
            this.BtnLampBlueOn.Location = new System.Drawing.Point(405, 45);
            this.BtnLampBlueOn.Margin = new System.Windows.Forms.Padding(4);
            this.BtnLampBlueOn.Name = "BtnLampBlueOn";
            this.BtnLampBlueOn.Size = new System.Drawing.Size(120, 45);
            this.BtnLampBlueOn.TabIndex = 6;
            this.BtnLampBlueOn.Text = "开";
            this.BtnLampBlueOn.UseVisualStyleBackColor = false;
            this.BtnLampBlueOn.Click += new System.EventHandler(this.BtnLampBlueOn_Click);
            // 
            // BtnLampGreenOff
            // 
            this.BtnLampGreenOff.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.BtnLampGreenOff.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnLampGreenOff.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.BtnLampGreenOff.ForeColor = System.Drawing.Color.Transparent;
            this.BtnLampGreenOff.Location = new System.Drawing.Point(277, 100);
            this.BtnLampGreenOff.Margin = new System.Windows.Forms.Padding(4);
            this.BtnLampGreenOff.Name = "BtnLampGreenOff";
            this.BtnLampGreenOff.Size = new System.Drawing.Size(120, 45);
            this.BtnLampGreenOff.TabIndex = 5;
            this.BtnLampGreenOff.Text = "关";
            this.BtnLampGreenOff.UseVisualStyleBackColor = false;
            this.BtnLampGreenOff.Click += new System.EventHandler(this.BtnLampGreenOff_Click);
            // 
            // BtnLampGreenOn
            // 
            this.BtnLampGreenOn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.BtnLampGreenOn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnLampGreenOn.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.BtnLampGreenOn.ForeColor = System.Drawing.Color.Transparent;
            this.BtnLampGreenOn.Location = new System.Drawing.Point(277, 45);
            this.BtnLampGreenOn.Margin = new System.Windows.Forms.Padding(4);
            this.BtnLampGreenOn.Name = "BtnLampGreenOn";
            this.BtnLampGreenOn.Size = new System.Drawing.Size(120, 45);
            this.BtnLampGreenOn.TabIndex = 4;
            this.BtnLampGreenOn.Text = "开";
            this.BtnLampGreenOn.UseVisualStyleBackColor = false;
            this.BtnLampGreenOn.Click += new System.EventHandler(this.BtnLampGreenOn_Click);
            // 
            // BtnLampOrangeOff
            // 
            this.BtnLampOrangeOff.BackColor = System.Drawing.Color.SaddleBrown;
            this.BtnLampOrangeOff.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnLampOrangeOff.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.BtnLampOrangeOff.ForeColor = System.Drawing.Color.Transparent;
            this.BtnLampOrangeOff.Location = new System.Drawing.Point(149, 100);
            this.BtnLampOrangeOff.Margin = new System.Windows.Forms.Padding(4);
            this.BtnLampOrangeOff.Name = "BtnLampOrangeOff";
            this.BtnLampOrangeOff.Size = new System.Drawing.Size(120, 45);
            this.BtnLampOrangeOff.TabIndex = 3;
            this.BtnLampOrangeOff.Text = "关";
            this.BtnLampOrangeOff.UseVisualStyleBackColor = false;
            this.BtnLampOrangeOff.Click += new System.EventHandler(this.BtnLampOrangeOff_Click);
            // 
            // BtnLampOrangeOn
            // 
            this.BtnLampOrangeOn.BackColor = System.Drawing.Color.DarkOrange;
            this.BtnLampOrangeOn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnLampOrangeOn.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.BtnLampOrangeOn.ForeColor = System.Drawing.Color.Transparent;
            this.BtnLampOrangeOn.Location = new System.Drawing.Point(149, 45);
            this.BtnLampOrangeOn.Margin = new System.Windows.Forms.Padding(4);
            this.BtnLampOrangeOn.Name = "BtnLampOrangeOn";
            this.BtnLampOrangeOn.Size = new System.Drawing.Size(120, 45);
            this.BtnLampOrangeOn.TabIndex = 2;
            this.BtnLampOrangeOn.Text = "开";
            this.BtnLampOrangeOn.UseVisualStyleBackColor = false;
            this.BtnLampOrangeOn.Click += new System.EventHandler(this.BtnLampOrangeOn_Click);
            // 
            // BtnLampRedOff
            // 
            this.BtnLampRedOff.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.BtnLampRedOff.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnLampRedOff.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.BtnLampRedOff.ForeColor = System.Drawing.Color.Transparent;
            this.BtnLampRedOff.Location = new System.Drawing.Point(21, 100);
            this.BtnLampRedOff.Margin = new System.Windows.Forms.Padding(4);
            this.BtnLampRedOff.Name = "BtnLampRedOff";
            this.BtnLampRedOff.Size = new System.Drawing.Size(120, 45);
            this.BtnLampRedOff.TabIndex = 1;
            this.BtnLampRedOff.Text = "关";
            this.BtnLampRedOff.UseVisualStyleBackColor = false;
            this.BtnLampRedOff.Click += new System.EventHandler(this.BtnLampRedOff_Click);
            // 
            // BtnLampRedOn
            // 
            this.BtnLampRedOn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.BtnLampRedOn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnLampRedOn.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.BtnLampRedOn.ForeColor = System.Drawing.Color.Transparent;
            this.BtnLampRedOn.Location = new System.Drawing.Point(21, 45);
            this.BtnLampRedOn.Margin = new System.Windows.Forms.Padding(4);
            this.BtnLampRedOn.Name = "BtnLampRedOn";
            this.BtnLampRedOn.Size = new System.Drawing.Size(120, 45);
            this.BtnLampRedOn.TabIndex = 0;
            this.BtnLampRedOn.Text = "开";
            this.BtnLampRedOn.UseVisualStyleBackColor = false;
            this.BtnLampRedOn.Click += new System.EventHandler(this.BtnLampRedOn_Click);
            // 
            // customGroupBox10
            // 
            this.customGroupBox10.Controls.Add(this.CTextBoxTrayDeviceRfidSn);
            this.customGroupBox10.Controls.Add(this.customLabel48);
            this.customGroupBox10.Controls.Add(this.PicTrayDeviceInRFID);
            this.customGroupBox10.Controls.Add(this.customLabel42);
            this.customGroupBox10.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.customGroupBox10.Location = new System.Drawing.Point(4, 712);
            this.customGroupBox10.Margin = new System.Windows.Forms.Padding(4);
            this.customGroupBox10.Name = "customGroupBox10";
            this.customGroupBox10.Padding = new System.Windows.Forms.Padding(4);
            this.customGroupBox10.Size = new System.Drawing.Size(852, 118);
            this.customGroupBox10.TabIndex = 15;
            this.customGroupBox10.TabStop = false;
            this.customGroupBox10.Text = "RFID 读码器";
            // 
            // CTextBoxTrayDeviceRfidSn
            // 
            this.CTextBoxTrayDeviceRfidSn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.CTextBoxTrayDeviceRfidSn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CTextBoxTrayDeviceRfidSn.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.CTextBoxTrayDeviceRfidSn.ForeColor = System.Drawing.Color.White;
            this.CTextBoxTrayDeviceRfidSn.Location = new System.Drawing.Point(452, 42);
            this.CTextBoxTrayDeviceRfidSn.Margin = new System.Windows.Forms.Padding(4);
            this.CTextBoxTrayDeviceRfidSn.Multiline = true;
            this.CTextBoxTrayDeviceRfidSn.Name = "CTextBoxTrayDeviceRfidSn";
            this.CTextBoxTrayDeviceRfidSn.ReadOnly = true;
            this.CTextBoxTrayDeviceRfidSn.Size = new System.Drawing.Size(349, 40);
            this.CTextBoxTrayDeviceRfidSn.TabIndex = 12;
            // 
            // customLabel48
            // 
            this.customLabel48.AutoSize = true;
            this.customLabel48.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.customLabel48.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.customLabel48.Location = new System.Drawing.Point(260, 52);
            this.customLabel48.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.customLabel48.Name = "customLabel48";
            this.customLabel48.Size = new System.Drawing.Size(180, 28);
            this.customLabel48.TabIndex = 11;
            this.customLabel48.Text = "物料托盘序列号：";
            // 
            // PicTrayDeviceInRFID
            // 
            this.PicTrayDeviceInRFID.Image = global::RobotWorkstation.Properties.Resources.SmallDarkGreen;
            this.PicTrayDeviceInRFID.Location = new System.Drawing.Point(196, 54);
            this.PicTrayDeviceInRFID.Margin = new System.Windows.Forms.Padding(4);
            this.PicTrayDeviceInRFID.Name = "PicTrayDeviceInRFID";
            this.PicTrayDeviceInRFID.Size = new System.Drawing.Size(29, 28);
            this.PicTrayDeviceInRFID.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PicTrayDeviceInRFID.TabIndex = 10;
            this.PicTrayDeviceInRFID.TabStop = false;
            // 
            // customLabel42
            // 
            this.customLabel42.AutoSize = true;
            this.customLabel42.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.customLabel42.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.customLabel42.Location = new System.Drawing.Point(33, 54);
            this.customLabel42.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.customLabel42.Name = "customLabel42";
            this.customLabel42.Size = new System.Drawing.Size(143, 28);
            this.customLabel42.TabIndex = 0;
            this.customLabel42.Text = "物料托盘到位:";
            // 
            // customGroupBox7
            // 
            this.customGroupBox7.Controls.Add(this.ComBoxQRCodeClear);
            this.customGroupBox7.Controls.Add(this.customLabel47);
            this.customGroupBox7.Controls.Add(this.ComBoxQRCodeReadShow);
            this.customGroupBox7.Controls.Add(this.ComBoxQRCodeDisconnect);
            this.customGroupBox7.Controls.Add(this.ComBoxQRCodeConnect);
            this.customGroupBox7.Controls.Add(this.ComBoxQRCodeCom);
            this.customGroupBox7.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.customGroupBox7.Location = new System.Drawing.Point(4, 4);
            this.customGroupBox7.Margin = new System.Windows.Forms.Padding(4);
            this.customGroupBox7.Name = "customGroupBox7";
            this.customGroupBox7.Padding = new System.Windows.Forms.Padding(4);
            this.customGroupBox7.Size = new System.Drawing.Size(852, 422);
            this.customGroupBox7.TabIndex = 14;
            this.customGroupBox7.TabStop = false;
            this.customGroupBox7.Text = "二维码读码器";
            // 
            // ComBoxQRCodeClear
            // 
            this.ComBoxQRCodeClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.ComBoxQRCodeClear.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ComBoxQRCodeClear.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.ComBoxQRCodeClear.ForeColor = System.Drawing.Color.Transparent;
            this.ComBoxQRCodeClear.Location = new System.Drawing.Point(691, 36);
            this.ComBoxQRCodeClear.Margin = new System.Windows.Forms.Padding(4);
            this.ComBoxQRCodeClear.Name = "ComBoxQRCodeClear";
            this.ComBoxQRCodeClear.Size = new System.Drawing.Size(120, 45);
            this.ComBoxQRCodeClear.TabIndex = 13;
            this.ComBoxQRCodeClear.Text = "清除";
            this.ComBoxQRCodeClear.UseVisualStyleBackColor = false;
            this.ComBoxQRCodeClear.Click += new System.EventHandler(this.ComBoxQRCodeClear_Click);
            // 
            // customLabel47
            // 
            this.customLabel47.AutoSize = true;
            this.customLabel47.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.customLabel47.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.customLabel47.Location = new System.Drawing.Point(33, 45);
            this.customLabel47.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.customLabel47.Name = "customLabel47";
            this.customLabel47.Size = new System.Drawing.Size(96, 28);
            this.customLabel47.TabIndex = 0;
            this.customLabel47.Text = "端口号：";
            // 
            // ComBoxQRCodeReadShow
            // 
            this.ComBoxQRCodeReadShow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.ComBoxQRCodeReadShow.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ComBoxQRCodeReadShow.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.ComBoxQRCodeReadShow.ForeColor = System.Drawing.Color.White;
            this.ComBoxQRCodeReadShow.Location = new System.Drawing.Point(39, 98);
            this.ComBoxQRCodeReadShow.Margin = new System.Windows.Forms.Padding(4);
            this.ComBoxQRCodeReadShow.Multiline = true;
            this.ComBoxQRCodeReadShow.Name = "ComBoxQRCodeReadShow";
            this.ComBoxQRCodeReadShow.ReadOnly = true;
            this.ComBoxQRCodeReadShow.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ComBoxQRCodeReadShow.Size = new System.Drawing.Size(771, 303);
            this.ComBoxQRCodeReadShow.TabIndex = 12;
            // 
            // ComBoxQRCodeDisconnect
            // 
            this.ComBoxQRCodeDisconnect.BackColor = System.Drawing.Color.Red;
            this.ComBoxQRCodeDisconnect.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ComBoxQRCodeDisconnect.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.ComBoxQRCodeDisconnect.ForeColor = System.Drawing.Color.Transparent;
            this.ComBoxQRCodeDisconnect.Location = new System.Drawing.Point(519, 36);
            this.ComBoxQRCodeDisconnect.Margin = new System.Windows.Forms.Padding(4);
            this.ComBoxQRCodeDisconnect.Name = "ComBoxQRCodeDisconnect";
            this.ComBoxQRCodeDisconnect.Size = new System.Drawing.Size(120, 45);
            this.ComBoxQRCodeDisconnect.TabIndex = 11;
            this.ComBoxQRCodeDisconnect.Text = "断开";
            this.ComBoxQRCodeDisconnect.UseVisualStyleBackColor = false;
            this.ComBoxQRCodeDisconnect.EnabledChanged += new System.EventHandler(this.ComBoxQRCodeDisconnect_EnabledChanged);
            this.ComBoxQRCodeDisconnect.Click += new System.EventHandler(this.ComBoxQRCodeDisconnect_Click);
            // 
            // ComBoxQRCodeConnect
            // 
            this.ComBoxQRCodeConnect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(148)))), ((int)(((byte)(8)))));
            this.ComBoxQRCodeConnect.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ComBoxQRCodeConnect.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.ComBoxQRCodeConnect.ForeColor = System.Drawing.Color.Transparent;
            this.ComBoxQRCodeConnect.Location = new System.Drawing.Point(347, 36);
            this.ComBoxQRCodeConnect.Margin = new System.Windows.Forms.Padding(4);
            this.ComBoxQRCodeConnect.Name = "ComBoxQRCodeConnect";
            this.ComBoxQRCodeConnect.Size = new System.Drawing.Size(120, 45);
            this.ComBoxQRCodeConnect.TabIndex = 10;
            this.ComBoxQRCodeConnect.Text = "连接";
            this.ComBoxQRCodeConnect.UseVisualStyleBackColor = false;
            this.ComBoxQRCodeConnect.EnabledChanged += new System.EventHandler(this.ComBoxQRCodeConnect_EnabledChanged);
            this.ComBoxQRCodeConnect.Click += new System.EventHandler(this.ComBoxQRCodeConnect_Click);
            // 
            // ComBoxQRCodeCom
            // 
            this.ComBoxQRCodeCom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.ComBoxQRCodeCom.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ComBoxQRCodeCom.ForeColor = System.Drawing.Color.White;
            this.ComBoxQRCodeCom.FormattingEnabled = true;
            this.ComBoxQRCodeCom.Items.AddRange(new object[] {
            "COM1",
            "COM2",
            "COM3",
            "COM4",
            "COM5",
            "COM6",
            "COM7",
            "COM8",
            "COM9",
            "COM10"});
            this.ComBoxQRCodeCom.Location = new System.Drawing.Point(137, 42);
            this.ComBoxQRCodeCom.Margin = new System.Windows.Forms.Padding(4);
            this.ComBoxQRCodeCom.Name = "ComBoxQRCodeCom";
            this.ComBoxQRCodeCom.Size = new System.Drawing.Size(160, 35);
            this.ComBoxQRCodeCom.TabIndex = 1;
            this.ComBoxQRCodeCom.SelectedIndexChanged += new System.EventHandler(this.ComBoxQRCodeCom_SelectedIndexChanged);
            // 
            // ManualDebugForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.ClientSize = new System.Drawing.Size(1680, 1038);
            this.ControlBox = false;
            this.Controls.Add(this.tabControlManualDebug);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ManualDebugForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ManualDebugForm_FormClosing);
            this.Load += new System.EventHandler(this.ManualDebug_Load);
            this.Shown += new System.EventHandler(this.ManualDebugForm_Shown);
            this.tabControlManualDebug.ResumeLayout(false);
            this.tabPageRobot.ResumeLayout(false);
            this.customGroupBoxRobotGrap.ResumeLayout(false);
            this.customGroupBoxRobotGrap.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxRobotGrapVacuumCheck)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxRobotGrapBackArrive)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxRobotGrapGoArrive)).EndInit();
            this.groupBoxRobot.ResumeLayout(false);
            this.groupBoxRobot.PerformLayout();
            this.CTabControlBorderRobotTestPoints.ResumeLayout(false);
            this.PageRobotTestGlobalPoint.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_RobotGlobalPoint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRobotMove)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTemperature)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRobotExecut)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRobotAlarm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxServo)).EndInit();
            this.tabPageOthers.ResumeLayout(false);
            this.CGrpTurnOver.ResumeLayout(false);
            this.CGrpTurnOver.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicOverturnCylUnLock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicOverturnCylLock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicOverturn)).EndInit();
            this.CGrpAxisConveyor.ResumeLayout(false);
            this.CGrpAxisConveyor.PerformLayout();
            this.customGroupBox13.ResumeLayout(false);
            this.customGroupBox13.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicKeyReset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicKeyStop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicKeyPause)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicKeyRun)).EndInit();
            this.customGroupBox12.ResumeLayout(false);
            this.customGroupBox12.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxEmptySalverDownArrive)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxEmptySalverUpArrive)).EndInit();
            this.customGroupBox11.ResumeLayout(false);
            this.customGroupBox10.ResumeLayout(false);
            this.customGroupBox10.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicTrayDeviceInRFID)).EndInit();
            this.customGroupBox7.ResumeLayout(false);
            this.customGroupBox7.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private CustomTabControl tabControlManualDebug;
        private System.Windows.Forms.TabPage tabPageRobot;
        private CustomGroupBox groupBoxRobot;
        private System.Windows.Forms.PictureBox pictureBoxServo;
        private CustomButton CBttonServoOn;
        private CustomButton CButtonServoOff;
        private CustomLabel customLabel1;
        private System.Windows.Forms.PictureBox pictureBoxRobotAlarm;
        private CustomButton CButtonReset;
        private CustomLabel customLabel2;
        private System.Windows.Forms.PictureBox pictureBoxRobotExecut;
        private CustomButton CButtonRobotExecPause;
        private CustomButton CButtonRobotExecRun;
        private CustomButton CButtonRobotExecStop;
        private System.Windows.Forms.PictureBox pictureBoxRobotMove;
        private CustomLabel customLabel4;
        private System.Windows.Forms.PictureBox pictureBoxTemperature;
        private CustomLabel customLabel3;
        private CustomLabel customLabel5;
        private CustomTextBox CTextBoxJogDistance;
        private CustomLabel customLabel6;
        private CustomLabel customLabel7;
        private CustomTextBox CTextBoxJogDistanceUm;
        private System.Windows.Forms.RadioButton radioButtonRobotDeviceJog;
        private CustomLabel customLabel9;
        private CustomTextBox CTextBoxRobotMoveSpeed;
        private CustomLabel customLabel8;
        private System.Windows.Forms.RadioButton radioButtonRobotDeviceContinuous;
        private CustomButton CButtonRobotDistanceJ1Sub;
        private CustomButton CButtonRobotDistanceJ1Add;
        private CustomTextBox CTextBoxRobotDistanceJ1;
        private CustomLabel customLabel11;
        private CustomButton CButtonRobotDistanceJ3Sub;
        private CustomButton CButtonRobotDistanceJ3Add;
        private CustomTextBox CTextBoxRobotDistanceJ3;
        private CustomLabel customLabel13;
        private CustomButton CButtonRobotDistanceJ2Sub;
        private CustomButton CButtonRobotDistanceJ2Add;
        private CustomTextBox CTextBoxRobotDistanceJ2;
        private CustomLabel customLabel12;
        private CustomButton CButtonRobotDistanceRZSub;
        private CustomButton CButtonRobotDistanceRZAdd;
        private CustomTextBox CTextBoxRobotDistanceRZ;
        private CustomLabel customLabel15;
        private CustomButton CButtonRobotDistanceZSub;
        private CustomButton CButtonRobotDistanceZAdd;
        private CustomTextBox CTextBoxRobotDistanceZ;
        private CustomLabel customLabel16;
        private CustomButton CButtonRobotDistanceYSub;
        private CustomButton CButtonRobotDistanceYAdd;
        private CustomTextBox CTextBoxRobotDistanceY;
        private CustomLabel customLabel17;
        private CustomButton CButtonRobotDistanceXSub;
        private CustomButton CButtonRobotDistanceXAdd;
        private CustomTextBox CTextBoxRobotDistanceX;
        private CustomLabel customLabel18;
        private CustomButton CButtonRobotDistanceJ4Sub;
        private CustomButton CButtonRobotDistanceJ4Add;
        private CustomTextBox CTextBoxRobotDistanceJ4;
        private CustomLabel customLabel14;
        private CustomTabControlBorder CTabControlBorderRobotTestPoints;
        private System.Windows.Forms.TabPage PageRobotTestGlobalPoint;
        private System.Windows.Forms.TabPage PageRobotTestUserFrame;
        private System.Windows.Forms.TabPage PageRobotTestToolFrame;
        private System.Windows.Forms.TabPage PageRobotTestWorkSpace;
        public System.Windows.Forms.DataGridView DGV_RobotGlobalPoint;
        private System.Windows.Forms.DataGridViewTextBoxColumn RobotTestName;
        private System.Windows.Forms.DataGridViewTextBoxColumn RobotTestX;
        private System.Windows.Forms.DataGridViewTextBoxColumn RobotTestY;
        private System.Windows.Forms.DataGridViewTextBoxColumn RobotTestZ;
        private System.Windows.Forms.DataGridViewTextBoxColumn RobotTestRZ;
        private System.Windows.Forms.DataGridViewTextBoxColumn RobotTestHand;
        private System.Windows.Forms.DataGridViewTextBoxColumn RobotTestUserID;
        private System.Windows.Forms.DataGridViewTextBoxColumn RobotTestToolID;
        private System.Windows.Forms.Timer TimerInitRobotGlobalPointDGV;
        private CustomButton CBtnRobotTestReadPoint;
        private CustomLabel customLabel19;
        private CustomButton CBtnRobotTestMoveToPoint;
        private CustomButton CBtnRobotTestTeachPoint;
        private System.Windows.Forms.Timer RefreshTimer;
        private System.Windows.Forms.OpenFileDialog OpenFileDialogMotionControlLoadCfg;
        private System.Windows.Forms.TabPage tabPageOthers;
        private System.Windows.Forms.ComboBox ComBoxRobotActions;
        private CustomButton CBtnRobotTestRunAction;
        private System.Windows.Forms.ComboBox ComBoxQRCodeCom;
        private CustomLabel customLabel47;
        private CustomTextBox ComBoxQRCodeReadShow;
        private CustomButton ComBoxQRCodeDisconnect;
        private CustomButton ComBoxQRCodeConnect;
        private CustomButton ComBoxQRCodeClear;
        private CustomGroupBox customGroupBox7;
        private CustomButton CBtnRobotTestTurnOver;
        private CustomGroupBox customGroupBoxRobotGrap;
        private CustomButton CBtnRobotGrap;
        private CustomButton CBtnRobotGrapBack;
        private CustomButton CBtnRobotGrapGo;
        private System.Windows.Forms.PictureBox PicBoxRobotGrapVacuumCheck;
        private CustomLabel customLabel53;
        private System.Windows.Forms.PictureBox PicBoxRobotGrapBackArrive;
        private CustomLabel CLabelRobotGrapBackArrive;
        private System.Windows.Forms.PictureBox PicBoxRobotGrapGoArrive;
        private CustomLabel CLabelRobotGrapGoArrive;
        private CustomButton CBtnRobotPut;
        private CustomGroupBox customGroupBox10;
        private CustomLabel customLabel42;
        private CustomTextBox CTextBoxTrayDeviceRfidSn;
        private CustomLabel customLabel48;
        private System.Windows.Forms.PictureBox PicTrayDeviceInRFID;
        private CustomGroupBox customGroupBox11;
        private CustomGroupBox customGroupBox13;
        private System.Windows.Forms.PictureBox PicKeyReset;
        private System.Windows.Forms.PictureBox PicKeyStop;
        private System.Windows.Forms.PictureBox PicKeyPause;
        private System.Windows.Forms.PictureBox PicKeyRun;
        private CustomLabel customLabel52;
        private CustomLabel customLabel51;
        private CustomLabel customLabel50;
        private CustomLabel customLabel49;
        private CustomGroupBox customGroupBox12;
        private System.Windows.Forms.PictureBox PicBoxEmptySalverDownArrive;
        private System.Windows.Forms.PictureBox PicBoxEmptySalverUpArrive;
        private CustomButton CButtonIoEmptyPlateUp;
        private CustomButton CButtonIoEmptyPlateDown;
        private CustomButton BtnBeepOff;
        private CustomButton BtnBeepOn;
        private CustomButton BtnLampBlueOff;
        private CustomButton BtnLampBlueOn;
        private CustomButton BtnLampGreenOff;
        private CustomButton BtnLampGreenOn;
        private CustomButton BtnLampOrangeOff;
        private CustomButton BtnLampOrangeOn;
        private CustomButton BtnLampRedOff;
        private CustomButton BtnLampRedOn;
        private System.Windows.Forms.Timer TimerRobotTestRunAction;
        private CustomGroupBox CGrpTurnOver;
        private CustomButton CBtnTurnOver;
        private CustomTextBox CTxtAxisTurnOverStep;
        private CustomLabel customLabel28;
        private CustomTextBox CTxtAxisTurnOverSpeed;
        private CustomLabel customLabel27;
        private CustomGroupBox CGrpAxisConveyor;
        private CustomButton BtnAxisConveyorResetError;
        private CustomTextBox CTxtAxisConveyorrState;
        private CustomLabel customLabel26;
        private CustomButton BtnAxisConveyorDec;
        private CustomButton BtnAxisConveyorAdd;
        private CustomButton CBtnAxisConveyorStop;
        private CustomButton CBtnAxisConveyorMoveReverse;
        private CustomButton CBtnAxisConveyorMoveForward;
        private CustomLabel customLabel25;
        private CustomTextBox CTxtAxisConveyorrStepPpu;
        private CustomLabel customLabel22;
        private CustomTextBox CTxtAxisConveyorSpeedDec;
        private CustomLabel customLabel23;
        private CustomTextBox CTxtAxisConveyorSpeedAdd;
        private CustomLabel customLabel24;
        private CustomTextBox CTxtAxisConveyorCurPos;
        private CustomLabel customLabel21;
        private CustomTextBox CTxtAxisConveyorSpeedRun;
        private CustomLabel customLabel20;
        private CustomTextBox CTxtAxisConveyorSpeedStart;
        private CustomLabel customLabel10;
        private System.Windows.Forms.PictureBox PicOverturnCylUnLock;
        private System.Windows.Forms.PictureBox PicOverturnCylLock;
        private System.Windows.Forms.PictureBox PicOverturn;
        private CustomLabel customLabel31;
        private CustomLabel customLabel30;
        private CustomLabel customLabel29;
        private CustomButton CBtnTurnOverReset;
        private CustomButton CBtnTurnOverLockCylClose;
        private CustomButton CBtnTurnOverLockCylOpen;
        private CustomLabel customLabel33;
        private CustomLabel customLabel32;
        private CustomButton CBtnTurnOverAxisErrorReset;
        private CustomTextBox CTxtAxisTurnOverState;
        private CustomLabel customLabel34;
    }
}