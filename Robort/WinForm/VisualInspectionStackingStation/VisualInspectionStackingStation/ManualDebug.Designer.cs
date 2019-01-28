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
            this.RefreshTimer = new System.Windows.Forms.Timer(this.components);
            this.OpenFileDialogMotionControlLoadCfg = new System.Windows.Forms.OpenFileDialog();
            this.tabControlManualDebug = new RobotWorkstation.CustomTabControl();
            this.tabPageRobot = new System.Windows.Forms.TabPage();
            this.tabPageOthers = new System.Windows.Forms.TabPage();
            this.CGroupBoxArmSensor = new RobotWorkstation.CustomGroupBox();
            this.PicBoxSalverRunOutStationSensor = new System.Windows.Forms.PictureBox();
            this.PicBoxEmptySalverObstructSensor = new System.Windows.Forms.PictureBox();
            this.customLabel40 = new RobotWorkstation.CustomLabel();
            this.customLabel39 = new RobotWorkstation.CustomLabel();
            this.CGrpTurnOver = new RobotWorkstation.CustomGroupBox();
            this.BtnAxisOverturnSetDefaultParam = new RobotWorkstation.CustomButton();
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
            this.BtnAxisConveyorSetDefaultParam = new RobotWorkstation.CustomButton();
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
            this.CGroupBoxArmKeyIn = new RobotWorkstation.CustomGroupBox();
            this.PicKeyReset = new System.Windows.Forms.PictureBox();
            this.PicKeyStop = new System.Windows.Forms.PictureBox();
            this.PicKeyPause = new System.Windows.Forms.PictureBox();
            this.PicKeyRun = new System.Windows.Forms.PictureBox();
            this.customLabel52 = new RobotWorkstation.CustomLabel();
            this.customLabel51 = new RobotWorkstation.CustomLabel();
            this.customLabel50 = new RobotWorkstation.CustomLabel();
            this.customLabel49 = new RobotWorkstation.CustomLabel();
            this.CGroupBoxArmAireCyl = new RobotWorkstation.CustomGroupBox();
            this.PicBoxConveyorDownArrive = new System.Windows.Forms.PictureBox();
            this.PicBoxConveyorUpArrive = new System.Windows.Forms.PictureBox();
            this.PicBoxEmptySalverObstructDownArrive = new System.Windows.Forms.PictureBox();
            this.PicBoxEmptySalverObstructUpArrive = new System.Windows.Forms.PictureBox();
            this.customLabel38 = new RobotWorkstation.CustomLabel();
            this.customLabel37 = new RobotWorkstation.CustomLabel();
            this.customLabel36 = new RobotWorkstation.CustomLabel();
            this.customLabel35 = new RobotWorkstation.CustomLabel();
            this.CButtonConveyorDown = new RobotWorkstation.CustomButton();
            this.CButtonConveyorUp = new RobotWorkstation.CustomButton();
            this.CButtonEmptySalverObstructDown = new RobotWorkstation.CustomButton();
            this.CButtonEmptySalverObstructUp = new RobotWorkstation.CustomButton();
            this.customLabel33 = new RobotWorkstation.CustomLabel();
            this.customLabel32 = new RobotWorkstation.CustomLabel();
            this.PicBoxEmptySalverDownArrive = new System.Windows.Forms.PictureBox();
            this.PicBoxEmptySalverUpArrive = new System.Windows.Forms.PictureBox();
            this.CButtonIoEmptySalverLiftingUp = new RobotWorkstation.CustomButton();
            this.CButtonIoEmptySalverLiftingDown = new RobotWorkstation.CustomButton();
            this.CGroupBoxArmTowerLight = new RobotWorkstation.CustomGroupBox();
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
            this.tabControlManualDebug.SuspendLayout();
            this.tabPageOthers.SuspendLayout();
            this.CGroupBoxArmSensor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxSalverRunOutStationSensor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxEmptySalverObstructSensor)).BeginInit();
            this.CGrpTurnOver.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicOverturnCylUnLock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicOverturnCylLock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicOverturn)).BeginInit();
            this.CGrpAxisConveyor.SuspendLayout();
            this.CGroupBoxArmKeyIn.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicKeyReset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicKeyStop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicKeyPause)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicKeyRun)).BeginInit();
            this.CGroupBoxArmAireCyl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxConveyorDownArrive)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxConveyorUpArrive)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxEmptySalverObstructDownArrive)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxEmptySalverObstructUpArrive)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxEmptySalverDownArrive)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxEmptySalverUpArrive)).BeginInit();
            this.CGroupBoxArmTowerLight.SuspendLayout();
            this.customGroupBox10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicTrayDeviceInRFID)).BeginInit();
            this.SuspendLayout();
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
            // tabControlManualDebug
            // 
            this.tabControlManualDebug.Controls.Add(this.tabPageRobot);
            this.tabControlManualDebug.Controls.Add(this.tabPageOthers);
            this.tabControlManualDebug.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabControlManualDebug.ItemSize = new System.Drawing.Size(120, 26);
            this.tabControlManualDebug.Location = new System.Drawing.Point(12, 12);
            this.tabControlManualDebug.Margin = new System.Windows.Forms.Padding(0);
            this.tabControlManualDebug.Name = "tabControlManualDebug";
            this.tabControlManualDebug.Padding = new System.Drawing.Point(20, 3);
            this.tabControlManualDebug.SelectedIndex = 0;
            this.tabControlManualDebug.Size = new System.Drawing.Size(1248, 818);
            this.tabControlManualDebug.TabIndex = 0;
 
            // tabPageRobot
            // 
            this.tabPageRobot.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.tabPageRobot.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabPageRobot.Location = new System.Drawing.Point(0, 29);
            this.tabPageRobot.Name = "tabPageRobot";
            this.tabPageRobot.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageRobot.Size = new System.Drawing.Size(1248, 789);
            this.tabPageRobot.TabIndex = 0;
            this.tabPageRobot.Text = "机器人";
            // 
            // tabPageOthers
            // 
            this.tabPageOthers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.tabPageOthers.Controls.Add(this.CGroupBoxArmSensor);
            this.tabPageOthers.Controls.Add(this.CGrpTurnOver);
            this.tabPageOthers.Controls.Add(this.CGrpAxisConveyor);
            this.tabPageOthers.Controls.Add(this.CGroupBoxArmKeyIn);
            this.tabPageOthers.Controls.Add(this.CGroupBoxArmAireCyl);
            this.tabPageOthers.Controls.Add(this.CGroupBoxArmTowerLight);
            this.tabPageOthers.Controls.Add(this.customGroupBox10);
            this.tabPageOthers.ForeColor = System.Drawing.Color.White;
            this.tabPageOthers.Location = new System.Drawing.Point(0, 29);
            this.tabPageOthers.Name = "tabPageOthers";
            this.tabPageOthers.Size = new System.Drawing.Size(1248, 789);
            this.tabPageOthers.TabIndex = 3;
            this.tabPageOthers.Text = "其他";
            // 
            // CGroupBoxArmSensor
            // 
            this.CGroupBoxArmSensor.Controls.Add(this.PicBoxSalverRunOutStationSensor);
            this.CGroupBoxArmSensor.Controls.Add(this.PicBoxEmptySalverObstructSensor);
            this.CGroupBoxArmSensor.Controls.Add(this.customLabel40);
            this.CGroupBoxArmSensor.Controls.Add(this.customLabel39);
            this.CGroupBoxArmSensor.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.CGroupBoxArmSensor.Location = new System.Drawing.Point(1037, 300);
            this.CGroupBoxArmSensor.Name = "CGroupBoxArmSensor";
            this.CGroupBoxArmSensor.Size = new System.Drawing.Size(133, 90);
            this.CGroupBoxArmSensor.TabIndex = 22;
            this.CGroupBoxArmSensor.TabStop = false;
            this.CGroupBoxArmSensor.Text = "传感器";
            // 
            // PicBoxSalverRunOutStationSensor
            // 
            this.PicBoxSalverRunOutStationSensor.Image = global::RobotWorkstation.Properties.Resources.SmallDarkGreen;
            this.PicBoxSalverRunOutStationSensor.Location = new System.Drawing.Point(87, 55);
            this.PicBoxSalverRunOutStationSensor.Name = "PicBoxSalverRunOutStationSensor";
            this.PicBoxSalverRunOutStationSensor.Size = new System.Drawing.Size(22, 22);
            this.PicBoxSalverRunOutStationSensor.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PicBoxSalverRunOutStationSensor.TabIndex = 24;
            this.PicBoxSalverRunOutStationSensor.TabStop = false;
            // 
            // PicBoxEmptySalverObstructSensor
            // 
            this.PicBoxEmptySalverObstructSensor.Image = global::RobotWorkstation.Properties.Resources.SmallDarkGreen;
            this.PicBoxEmptySalverObstructSensor.Location = new System.Drawing.Point(87, 26);
            this.PicBoxEmptySalverObstructSensor.Name = "PicBoxEmptySalverObstructSensor";
            this.PicBoxEmptySalverObstructSensor.Size = new System.Drawing.Size(22, 22);
            this.PicBoxEmptySalverObstructSensor.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PicBoxEmptySalverObstructSensor.TabIndex = 23;
            this.PicBoxEmptySalverObstructSensor.TabStop = false;
            // 
            // customLabel40
            // 
            this.customLabel40.AutoSize = true;
            this.customLabel40.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.customLabel40.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.customLabel40.Location = new System.Drawing.Point(9, 53);
            this.customLabel40.Name = "customLabel40";
            this.customLabel40.Size = new System.Drawing.Size(61, 23);
            this.customLabel40.TabIndex = 1;
            this.customLabel40.Text = "出站：";
            // 
            // customLabel39
            // 
            this.customLabel39.AutoSize = true;
            this.customLabel39.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.customLabel39.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.customLabel39.Location = new System.Drawing.Point(9, 25);
            this.customLabel39.Name = "customLabel39";
            this.customLabel39.Size = new System.Drawing.Size(61, 23);
            this.customLabel39.TabIndex = 0;
            this.customLabel39.Text = "阻挡：";
            // 
            // CGrpTurnOver
            // 
            this.CGrpTurnOver.Controls.Add(this.BtnAxisOverturnSetDefaultParam);
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
            this.CGrpTurnOver.Location = new System.Drawing.Point(661, 396);
            this.CGrpTurnOver.Name = "CGrpTurnOver";
            this.CGrpTurnOver.Size = new System.Drawing.Size(506, 217);
            this.CGrpTurnOver.TabIndex = 21;
            this.CGrpTurnOver.TabStop = false;
            this.CGrpTurnOver.Text = "翻转机构";
            // 
            // BtnAxisOverturnSetDefaultParam
            // 
            this.BtnAxisOverturnSetDefaultParam.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.BtnAxisOverturnSetDefaultParam.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnAxisOverturnSetDefaultParam.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.BtnAxisOverturnSetDefaultParam.ForeColor = System.Drawing.Color.Transparent;
            this.BtnAxisOverturnSetDefaultParam.Location = new System.Drawing.Point(398, 159);
            this.BtnAxisOverturnSetDefaultParam.Name = "BtnAxisOverturnSetDefaultParam";
            this.BtnAxisOverturnSetDefaultParam.Size = new System.Drawing.Size(90, 36);
            this.BtnAxisOverturnSetDefaultParam.TabIndex = 24;
            this.BtnAxisOverturnSetDefaultParam.Text = "设为默认";
            this.BtnAxisOverturnSetDefaultParam.UseVisualStyleBackColor = false;
            this.BtnAxisOverturnSetDefaultParam.Click += new System.EventHandler(this.BtnAxisOverturnSetDefaultParam_Click);
            // 
            // CBtnTurnOverAxisErrorReset
            // 
            this.CBtnTurnOverAxisErrorReset.BackColor = System.Drawing.Color.SteelBlue;
            this.CBtnTurnOverAxisErrorReset.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CBtnTurnOverAxisErrorReset.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.CBtnTurnOverAxisErrorReset.ForeColor = System.Drawing.Color.Transparent;
            this.CBtnTurnOverAxisErrorReset.Location = new System.Drawing.Point(302, 158);
            this.CBtnTurnOverAxisErrorReset.Name = "CBtnTurnOverAxisErrorReset";
            this.CBtnTurnOverAxisErrorReset.Size = new System.Drawing.Size(90, 36);
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
            this.CTxtAxisTurnOverState.Location = new System.Drawing.Point(106, 161);
            this.CTxtAxisTurnOverState.Multiline = true;
            this.CTxtAxisTurnOverState.Name = "CTxtAxisTurnOverState";
            this.CTxtAxisTurnOverState.Size = new System.Drawing.Size(185, 32);
            this.CTxtAxisTurnOverState.TabIndex = 22;
            // 
            // customLabel34
            // 
            this.customLabel34.AutoSize = true;
            this.customLabel34.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.customLabel34.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.customLabel34.Location = new System.Drawing.Point(9, 163);
            this.customLabel34.Name = "customLabel34";
            this.customLabel34.Size = new System.Drawing.Size(95, 23);
            this.customLabel34.TabIndex = 21;
            this.customLabel34.Text = "电机状态：";
            // 
            // PicOverturnCylUnLock
            // 
            this.PicOverturnCylUnLock.Image = global::RobotWorkstation.Properties.Resources.SmallDarkGreen;
            this.PicOverturnCylUnLock.Location = new System.Drawing.Point(461, 35);
            this.PicOverturnCylUnLock.Name = "PicOverturnCylUnLock";
            this.PicOverturnCylUnLock.Size = new System.Drawing.Size(22, 22);
            this.PicOverturnCylUnLock.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PicOverturnCylUnLock.TabIndex = 20;
            this.PicOverturnCylUnLock.TabStop = false;
            // 
            // PicOverturnCylLock
            // 
            this.PicOverturnCylLock.Image = global::RobotWorkstation.Properties.Resources.SmallDarkGreen;
            this.PicOverturnCylLock.Location = new System.Drawing.Point(283, 35);
            this.PicOverturnCylLock.Name = "PicOverturnCylLock";
            this.PicOverturnCylLock.Size = new System.Drawing.Size(22, 22);
            this.PicOverturnCylLock.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PicOverturnCylLock.TabIndex = 19;
            this.PicOverturnCylLock.TabStop = false;
            // 
            // PicOverturn
            // 
            this.PicOverturn.Image = global::RobotWorkstation.Properties.Resources.SmallDarkGreen;
            this.PicOverturn.Location = new System.Drawing.Point(106, 35);
            this.PicOverturn.Name = "PicOverturn";
            this.PicOverturn.Size = new System.Drawing.Size(22, 22);
            this.PicOverturn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PicOverturn.TabIndex = 18;
            this.PicOverturn.TabStop = false;
            // 
            // customLabel31
            // 
            this.customLabel31.AutoSize = true;
            this.customLabel31.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.customLabel31.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.customLabel31.Location = new System.Drawing.Point(369, 34);
            this.customLabel31.Name = "customLabel31";
            this.customLabel31.Size = new System.Drawing.Size(95, 23);
            this.customLabel31.TabIndex = 10;
            this.customLabel31.Text = "解锁到位：";
            // 
            // customLabel30
            // 
            this.customLabel30.AutoSize = true;
            this.customLabel30.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.customLabel30.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.customLabel30.Location = new System.Drawing.Point(191, 35);
            this.customLabel30.Name = "customLabel30";
            this.customLabel30.Size = new System.Drawing.Size(95, 23);
            this.customLabel30.TabIndex = 9;
            this.customLabel30.Text = "锁定到位：";
            // 
            // customLabel29
            // 
            this.customLabel29.AutoSize = true;
            this.customLabel29.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.customLabel29.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.customLabel29.Location = new System.Drawing.Point(10, 34);
            this.customLabel29.Name = "customLabel29";
            this.customLabel29.Size = new System.Drawing.Size(95, 23);
            this.customLabel29.TabIndex = 8;
            this.customLabel29.Text = "翻转到位：";
            // 
            // CBtnTurnOverReset
            // 
            this.CBtnTurnOverReset.BackColor = System.Drawing.Color.SteelBlue;
            this.CBtnTurnOverReset.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CBtnTurnOverReset.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.CBtnTurnOverReset.ForeColor = System.Drawing.Color.Transparent;
            this.CBtnTurnOverReset.Location = new System.Drawing.Point(398, 72);
            this.CBtnTurnOverReset.Name = "CBtnTurnOverReset";
            this.CBtnTurnOverReset.Size = new System.Drawing.Size(90, 36);
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
            this.CBtnTurnOverLockCylClose.Location = new System.Drawing.Point(398, 115);
            this.CBtnTurnOverLockCylClose.Name = "CBtnTurnOverLockCylClose";
            this.CBtnTurnOverLockCylClose.Size = new System.Drawing.Size(90, 36);
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
            this.CBtnTurnOverLockCylOpen.Location = new System.Drawing.Point(302, 115);
            this.CBtnTurnOverLockCylOpen.Name = "CBtnTurnOverLockCylOpen";
            this.CBtnTurnOverLockCylOpen.Size = new System.Drawing.Size(90, 36);
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
            this.CBtnTurnOver.Location = new System.Drawing.Point(302, 73);
            this.CBtnTurnOver.Name = "CBtnTurnOver";
            this.CBtnTurnOver.Size = new System.Drawing.Size(90, 36);
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
            this.CTxtAxisTurnOverStep.Location = new System.Drawing.Point(106, 119);
            this.CTxtAxisTurnOverStep.Multiline = true;
            this.CTxtAxisTurnOverStep.Name = "CTxtAxisTurnOverStep";
            this.CTxtAxisTurnOverStep.Size = new System.Drawing.Size(90, 32);
            this.CTxtAxisTurnOverStep.TabIndex = 3;
            this.CTxtAxisTurnOverStep.Text = "5000";
            // 
            // customLabel28
            // 
            this.customLabel28.AutoSize = true;
            this.customLabel28.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.customLabel28.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.customLabel28.Location = new System.Drawing.Point(10, 120);
            this.customLabel28.Name = "customLabel28";
            this.customLabel28.Size = new System.Drawing.Size(95, 23);
            this.customLabel28.TabIndex = 2;
            this.customLabel28.Text = "翻转步进：";
            // 
            // CTxtAxisTurnOverSpeed
            // 
            this.CTxtAxisTurnOverSpeed.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.CTxtAxisTurnOverSpeed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CTxtAxisTurnOverSpeed.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.CTxtAxisTurnOverSpeed.ForeColor = System.Drawing.Color.White;
            this.CTxtAxisTurnOverSpeed.Location = new System.Drawing.Point(106, 76);
            this.CTxtAxisTurnOverSpeed.Multiline = true;
            this.CTxtAxisTurnOverSpeed.Name = "CTxtAxisTurnOverSpeed";
            this.CTxtAxisTurnOverSpeed.Size = new System.Drawing.Size(90, 32);
            this.CTxtAxisTurnOverSpeed.TabIndex = 1;
            this.CTxtAxisTurnOverSpeed.Text = "8000";
            // 
            // customLabel27
            // 
            this.customLabel27.AutoSize = true;
            this.customLabel27.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.customLabel27.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.customLabel27.Location = new System.Drawing.Point(10, 77);
            this.customLabel27.Name = "customLabel27";
            this.customLabel27.Size = new System.Drawing.Size(95, 23);
            this.customLabel27.TabIndex = 0;
            this.customLabel27.Text = "翻转速度：";
            // 
            // CGrpAxisConveyor
            // 
            this.CGrpAxisConveyor.Controls.Add(this.BtnAxisConveyorSetDefaultParam);
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
            this.CGrpAxisConveyor.Location = new System.Drawing.Point(3, 3);
            this.CGrpAxisConveyor.Name = "CGrpAxisConveyor";
            this.CGrpAxisConveyor.Size = new System.Drawing.Size(639, 217);
            this.CGrpAxisConveyor.TabIndex = 20;
            this.CGrpAxisConveyor.TabStop = false;
            this.CGrpAxisConveyor.Text = "传输线电机轴";
            // 
            // BtnAxisConveyorSetDefaultParam
            // 
            this.BtnAxisConveyorSetDefaultParam.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.BtnAxisConveyorSetDefaultParam.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnAxisConveyorSetDefaultParam.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.BtnAxisConveyorSetDefaultParam.ForeColor = System.Drawing.Color.Transparent;
            this.BtnAxisConveyorSetDefaultParam.Location = new System.Drawing.Point(493, 158);
            this.BtnAxisConveyorSetDefaultParam.Name = "BtnAxisConveyorSetDefaultParam";
            this.BtnAxisConveyorSetDefaultParam.Size = new System.Drawing.Size(90, 36);
            this.BtnAxisConveyorSetDefaultParam.TabIndex = 21;
            this.BtnAxisConveyorSetDefaultParam.Text = "设为默认";
            this.BtnAxisConveyorSetDefaultParam.UseVisualStyleBackColor = false;
            this.BtnAxisConveyorSetDefaultParam.Click += new System.EventHandler(this.BtnAxisConveyorSetDefaultParam_Click);
            // 
            // BtnAxisConveyorResetError
            // 
            this.BtnAxisConveyorResetError.BackColor = System.Drawing.Color.SteelBlue;
            this.BtnAxisConveyorResetError.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnAxisConveyorResetError.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.BtnAxisConveyorResetError.ForeColor = System.Drawing.Color.Transparent;
            this.BtnAxisConveyorResetError.Location = new System.Drawing.Point(397, 158);
            this.BtnAxisConveyorResetError.Name = "BtnAxisConveyorResetError";
            this.BtnAxisConveyorResetError.Size = new System.Drawing.Size(90, 36);
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
            this.CTxtAxisConveyorrState.Location = new System.Drawing.Point(107, 163);
            this.CTxtAxisConveyorrState.Multiline = true;
            this.CTxtAxisConveyorrState.Name = "CTxtAxisConveyorrState";
            this.CTxtAxisConveyorrState.Size = new System.Drawing.Size(185, 32);
            this.CTxtAxisConveyorrState.TabIndex = 19;
            // 
            // customLabel26
            // 
            this.customLabel26.AutoSize = true;
            this.customLabel26.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.customLabel26.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.customLabel26.Location = new System.Drawing.Point(6, 165);
            this.customLabel26.Name = "customLabel26";
            this.customLabel26.Size = new System.Drawing.Size(95, 23);
            this.customLabel26.TabIndex = 18;
            this.customLabel26.Text = "电机状态：";
            // 
            // BtnAxisConveyorDec
            // 
            this.BtnAxisConveyorDec.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.BtnAxisConveyorDec.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnAxisConveyorDec.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.BtnAxisConveyorDec.ForeColor = System.Drawing.Color.Transparent;
            this.BtnAxisConveyorDec.Location = new System.Drawing.Point(493, 113);
            this.BtnAxisConveyorDec.Name = "BtnAxisConveyorDec";
            this.BtnAxisConveyorDec.Size = new System.Drawing.Size(90, 36);
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
            this.BtnAxisConveyorAdd.Location = new System.Drawing.Point(397, 113);
            this.BtnAxisConveyorAdd.Name = "BtnAxisConveyorAdd";
            this.BtnAxisConveyorAdd.Size = new System.Drawing.Size(90, 36);
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
            this.CBtnAxisConveyorStop.Location = new System.Drawing.Point(202, 113);
            this.CBtnAxisConveyorStop.Name = "CBtnAxisConveyorStop";
            this.CBtnAxisConveyorStop.Size = new System.Drawing.Size(90, 36);
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
            this.CBtnAxisConveyorMoveReverse.Location = new System.Drawing.Point(106, 113);
            this.CBtnAxisConveyorMoveReverse.Name = "CBtnAxisConveyorMoveReverse";
            this.CBtnAxisConveyorMoveReverse.Size = new System.Drawing.Size(90, 36);
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
            this.CBtnAxisConveyorMoveForward.Location = new System.Drawing.Point(10, 113);
            this.CBtnAxisConveyorMoveForward.Name = "CBtnAxisConveyorMoveForward";
            this.CBtnAxisConveyorMoveForward.Size = new System.Drawing.Size(90, 36);
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
            this.customLabel25.Location = new System.Drawing.Point(589, 75);
            this.customLabel25.Name = "customLabel25";
            this.customLabel25.Size = new System.Drawing.Size(43, 23);
            this.customLabel25.TabIndex = 12;
            this.customLabel25.Text = "PPU";
            // 
            // CTxtAxisConveyorrStepPpu
            // 
            this.CTxtAxisConveyorrStepPpu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.CTxtAxisConveyorrStepPpu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CTxtAxisConveyorrStepPpu.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.CTxtAxisConveyorrStepPpu.ForeColor = System.Drawing.Color.White;
            this.CTxtAxisConveyorrStepPpu.Location = new System.Drawing.Point(493, 70);
            this.CTxtAxisConveyorrStepPpu.Multiline = true;
            this.CTxtAxisConveyorrStepPpu.Name = "CTxtAxisConveyorrStepPpu";
            this.CTxtAxisConveyorrStepPpu.Size = new System.Drawing.Size(90, 32);
            this.CTxtAxisConveyorrStepPpu.TabIndex = 11;
            this.CTxtAxisConveyorrStepPpu.Text = "5000";
            // 
            // customLabel22
            // 
            this.customLabel22.AutoSize = true;
            this.customLabel22.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.customLabel22.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.customLabel22.Location = new System.Drawing.Point(403, 73);
            this.customLabel22.Name = "customLabel22";
            this.customLabel22.Size = new System.Drawing.Size(95, 23);
            this.customLabel22.TabIndex = 10;
            this.customLabel22.Text = "步进距离：";
            // 
            // CTxtAxisConveyorSpeedDec
            // 
            this.CTxtAxisConveyorSpeedDec.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.CTxtAxisConveyorSpeedDec.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CTxtAxisConveyorSpeedDec.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.CTxtAxisConveyorSpeedDec.ForeColor = System.Drawing.Color.White;
            this.CTxtAxisConveyorSpeedDec.Location = new System.Drawing.Point(303, 70);
            this.CTxtAxisConveyorSpeedDec.Multiline = true;
            this.CTxtAxisConveyorSpeedDec.Name = "CTxtAxisConveyorSpeedDec";
            this.CTxtAxisConveyorSpeedDec.Size = new System.Drawing.Size(90, 32);
            this.CTxtAxisConveyorSpeedDec.TabIndex = 9;
            this.CTxtAxisConveyorSpeedDec.Text = "10000";
            // 
            // customLabel23
            // 
            this.customLabel23.AutoSize = true;
            this.customLabel23.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.customLabel23.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.customLabel23.Location = new System.Drawing.Point(219, 73);
            this.customLabel23.Name = "customLabel23";
            this.customLabel23.Size = new System.Drawing.Size(78, 23);
            this.customLabel23.TabIndex = 8;
            this.customLabel23.Text = "减速度：";
            // 
            // CTxtAxisConveyorSpeedAdd
            // 
            this.CTxtAxisConveyorSpeedAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.CTxtAxisConveyorSpeedAdd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CTxtAxisConveyorSpeedAdd.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.CTxtAxisConveyorSpeedAdd.ForeColor = System.Drawing.Color.White;
            this.CTxtAxisConveyorSpeedAdd.Location = new System.Drawing.Point(103, 70);
            this.CTxtAxisConveyorSpeedAdd.Multiline = true;
            this.CTxtAxisConveyorSpeedAdd.Name = "CTxtAxisConveyorSpeedAdd";
            this.CTxtAxisConveyorSpeedAdd.Size = new System.Drawing.Size(90, 32);
            this.CTxtAxisConveyorSpeedAdd.TabIndex = 7;
            this.CTxtAxisConveyorSpeedAdd.Text = "10000";
            // 
            // customLabel24
            // 
            this.customLabel24.AutoSize = true;
            this.customLabel24.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.customLabel24.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.customLabel24.Location = new System.Drawing.Point(23, 73);
            this.customLabel24.Name = "customLabel24";
            this.customLabel24.Size = new System.Drawing.Size(78, 23);
            this.customLabel24.TabIndex = 6;
            this.customLabel24.Text = "加速度：";
            // 
            // CTxtAxisConveyorCurPos
            // 
            this.CTxtAxisConveyorCurPos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.CTxtAxisConveyorCurPos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CTxtAxisConveyorCurPos.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.CTxtAxisConveyorCurPos.ForeColor = System.Drawing.Color.White;
            this.CTxtAxisConveyorCurPos.Location = new System.Drawing.Point(493, 32);
            this.CTxtAxisConveyorCurPos.Multiline = true;
            this.CTxtAxisConveyorCurPos.Name = "CTxtAxisConveyorCurPos";
            this.CTxtAxisConveyorCurPos.Size = new System.Drawing.Size(90, 32);
            this.CTxtAxisConveyorCurPos.TabIndex = 5;
            this.CTxtAxisConveyorCurPos.Text = "0";
            // 
            // customLabel21
            // 
            this.customLabel21.AutoSize = true;
            this.customLabel21.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.customLabel21.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.customLabel21.Location = new System.Drawing.Point(403, 34);
            this.customLabel21.Name = "customLabel21";
            this.customLabel21.Size = new System.Drawing.Size(95, 23);
            this.customLabel21.TabIndex = 4;
            this.customLabel21.Text = "当前位置：";
            // 
            // CTxtAxisConveyorSpeedRun
            // 
            this.CTxtAxisConveyorSpeedRun.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.CTxtAxisConveyorSpeedRun.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CTxtAxisConveyorSpeedRun.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.CTxtAxisConveyorSpeedRun.ForeColor = System.Drawing.Color.White;
            this.CTxtAxisConveyorSpeedRun.Location = new System.Drawing.Point(303, 32);
            this.CTxtAxisConveyorSpeedRun.Multiline = true;
            this.CTxtAxisConveyorSpeedRun.Name = "CTxtAxisConveyorSpeedRun";
            this.CTxtAxisConveyorSpeedRun.Size = new System.Drawing.Size(90, 32);
            this.CTxtAxisConveyorSpeedRun.TabIndex = 3;
            this.CTxtAxisConveyorSpeedRun.Text = "8000";
            // 
            // customLabel20
            // 
            this.customLabel20.AutoSize = true;
            this.customLabel20.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.customLabel20.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.customLabel20.Location = new System.Drawing.Point(202, 34);
            this.customLabel20.Name = "customLabel20";
            this.customLabel20.Size = new System.Drawing.Size(95, 23);
            this.customLabel20.TabIndex = 2;
            this.customLabel20.Text = "运行速度：";
            // 
            // CTxtAxisConveyorSpeedStart
            // 
            this.CTxtAxisConveyorSpeedStart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.CTxtAxisConveyorSpeedStart.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CTxtAxisConveyorSpeedStart.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.CTxtAxisConveyorSpeedStart.ForeColor = System.Drawing.Color.White;
            this.CTxtAxisConveyorSpeedStart.Location = new System.Drawing.Point(103, 32);
            this.CTxtAxisConveyorSpeedStart.Multiline = true;
            this.CTxtAxisConveyorSpeedStart.Name = "CTxtAxisConveyorSpeedStart";
            this.CTxtAxisConveyorSpeedStart.Size = new System.Drawing.Size(90, 32);
            this.CTxtAxisConveyorSpeedStart.TabIndex = 1;
            this.CTxtAxisConveyorSpeedStart.Text = "2000";
            // 
            // customLabel10
            // 
            this.customLabel10.AutoSize = true;
            this.customLabel10.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.customLabel10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.customLabel10.Location = new System.Drawing.Point(6, 34);
            this.customLabel10.Name = "customLabel10";
            this.customLabel10.Size = new System.Drawing.Size(95, 23);
            this.customLabel10.TabIndex = 0;
            this.customLabel10.Text = "初始速度：";
            // 
            // CGroupBoxArmKeyIn
            // 
            this.CGroupBoxArmKeyIn.Controls.Add(this.PicKeyReset);
            this.CGroupBoxArmKeyIn.Controls.Add(this.PicKeyStop);
            this.CGroupBoxArmKeyIn.Controls.Add(this.PicKeyPause);
            this.CGroupBoxArmKeyIn.Controls.Add(this.PicKeyRun);
            this.CGroupBoxArmKeyIn.Controls.Add(this.customLabel52);
            this.CGroupBoxArmKeyIn.Controls.Add(this.customLabel51);
            this.CGroupBoxArmKeyIn.Controls.Add(this.customLabel50);
            this.CGroupBoxArmKeyIn.Controls.Add(this.customLabel49);
            this.CGroupBoxArmKeyIn.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.CGroupBoxArmKeyIn.Location = new System.Drawing.Point(1037, 133);
            this.CGroupBoxArmKeyIn.Name = "CGroupBoxArmKeyIn";
            this.CGroupBoxArmKeyIn.Size = new System.Drawing.Size(132, 161);
            this.CGroupBoxArmKeyIn.TabIndex = 19;
            this.CGroupBoxArmKeyIn.TabStop = false;
            this.CGroupBoxArmKeyIn.Text = "按键";
            // 
            // PicKeyReset
            // 
            this.PicKeyReset.Image = global::RobotWorkstation.Properties.Resources.SmallDarkGreen;
            this.PicKeyReset.Location = new System.Drawing.Point(87, 123);
            this.PicKeyReset.Name = "PicKeyReset";
            this.PicKeyReset.Size = new System.Drawing.Size(22, 22);
            this.PicKeyReset.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PicKeyReset.TabIndex = 17;
            this.PicKeyReset.TabStop = false;
            // 
            // PicKeyStop
            // 
            this.PicKeyStop.Image = global::RobotWorkstation.Properties.Resources.SmallDarkGreen;
            this.PicKeyStop.Location = new System.Drawing.Point(87, 93);
            this.PicKeyStop.Name = "PicKeyStop";
            this.PicKeyStop.Size = new System.Drawing.Size(22, 22);
            this.PicKeyStop.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PicKeyStop.TabIndex = 16;
            this.PicKeyStop.TabStop = false;
            // 
            // PicKeyPause
            // 
            this.PicKeyPause.Image = global::RobotWorkstation.Properties.Resources.SmallDarkGreen;
            this.PicKeyPause.Location = new System.Drawing.Point(87, 63);
            this.PicKeyPause.Name = "PicKeyPause";
            this.PicKeyPause.Size = new System.Drawing.Size(22, 22);
            this.PicKeyPause.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PicKeyPause.TabIndex = 15;
            this.PicKeyPause.TabStop = false;
            // 
            // PicKeyRun
            // 
            this.PicKeyRun.Image = global::RobotWorkstation.Properties.Resources.SmallDarkGreen;
            this.PicKeyRun.Location = new System.Drawing.Point(87, 33);
            this.PicKeyRun.Name = "PicKeyRun";
            this.PicKeyRun.Size = new System.Drawing.Size(22, 22);
            this.PicKeyRun.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PicKeyRun.TabIndex = 14;
            this.PicKeyRun.TabStop = false;
            // 
            // customLabel52
            // 
            this.customLabel52.AutoSize = true;
            this.customLabel52.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.customLabel52.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.customLabel52.Location = new System.Drawing.Point(9, 122);
            this.customLabel52.Name = "customLabel52";
            this.customLabel52.Size = new System.Drawing.Size(61, 23);
            this.customLabel52.TabIndex = 3;
            this.customLabel52.Text = "复位：";
            // 
            // customLabel51
            // 
            this.customLabel51.AutoSize = true;
            this.customLabel51.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.customLabel51.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.customLabel51.Location = new System.Drawing.Point(9, 92);
            this.customLabel51.Name = "customLabel51";
            this.customLabel51.Size = new System.Drawing.Size(61, 23);
            this.customLabel51.TabIndex = 2;
            this.customLabel51.Text = "停止：";
            // 
            // customLabel50
            // 
            this.customLabel50.AutoSize = true;
            this.customLabel50.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.customLabel50.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.customLabel50.Location = new System.Drawing.Point(9, 62);
            this.customLabel50.Name = "customLabel50";
            this.customLabel50.Size = new System.Drawing.Size(61, 23);
            this.customLabel50.TabIndex = 1;
            this.customLabel50.Text = "暂停：";
            // 
            // customLabel49
            // 
            this.customLabel49.AutoSize = true;
            this.customLabel49.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.customLabel49.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.customLabel49.Location = new System.Drawing.Point(9, 33);
            this.customLabel49.Name = "customLabel49";
            this.customLabel49.Size = new System.Drawing.Size(61, 23);
            this.customLabel49.TabIndex = 0;
            this.customLabel49.Text = "运行：";
            // 
            // CGroupBoxArmAireCyl
            // 
            this.CGroupBoxArmAireCyl.Controls.Add(this.PicBoxConveyorDownArrive);
            this.CGroupBoxArmAireCyl.Controls.Add(this.PicBoxConveyorUpArrive);
            this.CGroupBoxArmAireCyl.Controls.Add(this.PicBoxEmptySalverObstructDownArrive);
            this.CGroupBoxArmAireCyl.Controls.Add(this.PicBoxEmptySalverObstructUpArrive);
            this.CGroupBoxArmAireCyl.Controls.Add(this.customLabel38);
            this.CGroupBoxArmAireCyl.Controls.Add(this.customLabel37);
            this.CGroupBoxArmAireCyl.Controls.Add(this.customLabel36);
            this.CGroupBoxArmAireCyl.Controls.Add(this.customLabel35);
            this.CGroupBoxArmAireCyl.Controls.Add(this.CButtonConveyorDown);
            this.CGroupBoxArmAireCyl.Controls.Add(this.CButtonConveyorUp);
            this.CGroupBoxArmAireCyl.Controls.Add(this.CButtonEmptySalverObstructDown);
            this.CGroupBoxArmAireCyl.Controls.Add(this.CButtonEmptySalverObstructUp);
            this.CGroupBoxArmAireCyl.Controls.Add(this.customLabel33);
            this.CGroupBoxArmAireCyl.Controls.Add(this.customLabel32);
            this.CGroupBoxArmAireCyl.Controls.Add(this.PicBoxEmptySalverDownArrive);
            this.CGroupBoxArmAireCyl.Controls.Add(this.PicBoxEmptySalverUpArrive);
            this.CGroupBoxArmAireCyl.Controls.Add(this.CButtonIoEmptySalverLiftingUp);
            this.CGroupBoxArmAireCyl.Controls.Add(this.CButtonIoEmptySalverLiftingDown);
            this.CGroupBoxArmAireCyl.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.CGroupBoxArmAireCyl.Location = new System.Drawing.Point(662, 133);
            this.CGroupBoxArmAireCyl.Name = "CGroupBoxArmAireCyl";
            this.CGroupBoxArmAireCyl.Size = new System.Drawing.Size(358, 257);
            this.CGroupBoxArmAireCyl.TabIndex = 18;
            this.CGroupBoxArmAireCyl.TabStop = false;
            this.CGroupBoxArmAireCyl.Text = "气缸";
            // 
            // PicBoxConveyorDownArrive
            // 
            this.PicBoxConveyorDownArrive.Image = global::RobotWorkstation.Properties.Resources.SmallDarkGreen;
            this.PicBoxConveyorDownArrive.Location = new System.Drawing.Point(182, 215);
            this.PicBoxConveyorDownArrive.Name = "PicBoxConveyorDownArrive";
            this.PicBoxConveyorDownArrive.Size = new System.Drawing.Size(22, 22);
            this.PicBoxConveyorDownArrive.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PicBoxConveyorDownArrive.TabIndex = 28;
            this.PicBoxConveyorDownArrive.TabStop = false;
            // 
            // PicBoxConveyorUpArrive
            // 
            this.PicBoxConveyorUpArrive.Image = global::RobotWorkstation.Properties.Resources.SmallDarkGreen;
            this.PicBoxConveyorUpArrive.Location = new System.Drawing.Point(182, 178);
            this.PicBoxConveyorUpArrive.Name = "PicBoxConveyorUpArrive";
            this.PicBoxConveyorUpArrive.Size = new System.Drawing.Size(22, 22);
            this.PicBoxConveyorUpArrive.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PicBoxConveyorUpArrive.TabIndex = 27;
            this.PicBoxConveyorUpArrive.TabStop = false;
            // 
            // PicBoxEmptySalverObstructDownArrive
            // 
            this.PicBoxEmptySalverObstructDownArrive.Image = global::RobotWorkstation.Properties.Resources.SmallDarkGreen;
            this.PicBoxEmptySalverObstructDownArrive.Location = new System.Drawing.Point(182, 66);
            this.PicBoxEmptySalverObstructDownArrive.Name = "PicBoxEmptySalverObstructDownArrive";
            this.PicBoxEmptySalverObstructDownArrive.Size = new System.Drawing.Size(22, 22);
            this.PicBoxEmptySalverObstructDownArrive.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PicBoxEmptySalverObstructDownArrive.TabIndex = 26;
            this.PicBoxEmptySalverObstructDownArrive.TabStop = false;
            // 
            // PicBoxEmptySalverObstructUpArrive
            // 
            this.PicBoxEmptySalverObstructUpArrive.Image = global::RobotWorkstation.Properties.Resources.SmallDarkGreen;
            this.PicBoxEmptySalverObstructUpArrive.Location = new System.Drawing.Point(182, 30);
            this.PicBoxEmptySalverObstructUpArrive.Name = "PicBoxEmptySalverObstructUpArrive";
            this.PicBoxEmptySalverObstructUpArrive.Size = new System.Drawing.Size(22, 22);
            this.PicBoxEmptySalverObstructUpArrive.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PicBoxEmptySalverObstructUpArrive.TabIndex = 25;
            this.PicBoxEmptySalverObstructUpArrive.TabStop = false;
            // 
            // customLabel38
            // 
            this.customLabel38.AutoSize = true;
            this.customLabel38.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.customLabel38.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.customLabel38.Location = new System.Drawing.Point(30, 213);
            this.customLabel38.Name = "customLabel38";
            this.customLabel38.Size = new System.Drawing.Size(146, 23);
            this.customLabel38.TabIndex = 24;
            this.customLabel38.Text = "传输线降落到位：";
            // 
            // customLabel37
            // 
            this.customLabel37.AutoSize = true;
            this.customLabel37.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.customLabel37.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.customLabel37.Location = new System.Drawing.Point(30, 177);
            this.customLabel37.Name = "customLabel37";
            this.customLabel37.Size = new System.Drawing.Size(146, 23);
            this.customLabel37.TabIndex = 23;
            this.customLabel37.Text = "传输线升起到位：";
            // 
            // customLabel36
            // 
            this.customLabel36.AutoSize = true;
            this.customLabel36.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.customLabel36.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.customLabel36.Location = new System.Drawing.Point(30, 63);
            this.customLabel36.Name = "customLabel36";
            this.customLabel36.Size = new System.Drawing.Size(146, 23);
            this.customLabel36.TabIndex = 22;
            this.customLabel36.Text = "阻挡气缸升到位：";
            // 
            // customLabel35
            // 
            this.customLabel35.AutoSize = true;
            this.customLabel35.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.customLabel35.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.customLabel35.Location = new System.Drawing.Point(30, 29);
            this.customLabel35.Name = "customLabel35";
            this.customLabel35.Size = new System.Drawing.Size(146, 23);
            this.customLabel35.TabIndex = 21;
            this.customLabel35.Text = "阻挡气缸升到位：";
            // 
            // CButtonConveyorDown
            // 
            this.CButtonConveyorDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.CButtonConveyorDown.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CButtonConveyorDown.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.CButtonConveyorDown.ForeColor = System.Drawing.Color.Transparent;
            this.CButtonConveyorDown.Location = new System.Drawing.Point(224, 207);
            this.CButtonConveyorDown.Name = "CButtonConveyorDown";
            this.CButtonConveyorDown.Size = new System.Drawing.Size(105, 36);
            this.CButtonConveyorDown.TabIndex = 20;
            this.CButtonConveyorDown.Text = "传输线降落";
            this.CButtonConveyorDown.UseVisualStyleBackColor = false;
            this.CButtonConveyorDown.Click += new System.EventHandler(this.CButtonConveyorDown_Click);
            // 
            // CButtonConveyorUp
            // 
            this.CButtonConveyorUp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.CButtonConveyorUp.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CButtonConveyorUp.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.CButtonConveyorUp.ForeColor = System.Drawing.Color.Transparent;
            this.CButtonConveyorUp.Location = new System.Drawing.Point(224, 170);
            this.CButtonConveyorUp.Name = "CButtonConveyorUp";
            this.CButtonConveyorUp.Size = new System.Drawing.Size(105, 36);
            this.CButtonConveyorUp.TabIndex = 19;
            this.CButtonConveyorUp.Text = "传输线升起";
            this.CButtonConveyorUp.UseVisualStyleBackColor = false;
            this.CButtonConveyorUp.Click += new System.EventHandler(this.CButtonConveyorUp_Click);
            // 
            // CButtonEmptySalverObstructDown
            // 
            this.CButtonEmptySalverObstructDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.CButtonEmptySalverObstructDown.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CButtonEmptySalverObstructDown.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.CButtonEmptySalverObstructDown.ForeColor = System.Drawing.Color.Transparent;
            this.CButtonEmptySalverObstructDown.Location = new System.Drawing.Point(224, 59);
            this.CButtonEmptySalverObstructDown.Name = "CButtonEmptySalverObstructDown";
            this.CButtonEmptySalverObstructDown.Size = new System.Drawing.Size(105, 36);
            this.CButtonEmptySalverObstructDown.TabIndex = 18;
            this.CButtonEmptySalverObstructDown.Text = "阻挡气缸降";
            this.CButtonEmptySalverObstructDown.UseVisualStyleBackColor = false;
            this.CButtonEmptySalverObstructDown.Click += new System.EventHandler(this.CButtonEmptySalverObstructDown_Click);
            // 
            // CButtonEmptySalverObstructUp
            // 
            this.CButtonEmptySalverObstructUp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.CButtonEmptySalverObstructUp.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CButtonEmptySalverObstructUp.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.CButtonEmptySalverObstructUp.ForeColor = System.Drawing.Color.Transparent;
            this.CButtonEmptySalverObstructUp.Location = new System.Drawing.Point(224, 22);
            this.CButtonEmptySalverObstructUp.Name = "CButtonEmptySalverObstructUp";
            this.CButtonEmptySalverObstructUp.Size = new System.Drawing.Size(105, 36);
            this.CButtonEmptySalverObstructUp.TabIndex = 17;
            this.CButtonEmptySalverObstructUp.Text = "阻挡气缸升";
            this.CButtonEmptySalverObstructUp.UseVisualStyleBackColor = false;
            this.CButtonEmptySalverObstructUp.Click += new System.EventHandler(this.CButtonEmptySalverObstructUp_Click);
            // 
            // customLabel33
            // 
            this.customLabel33.AutoSize = true;
            this.customLabel33.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.customLabel33.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.customLabel33.Location = new System.Drawing.Point(30, 138);
            this.customLabel33.Name = "customLabel33";
            this.customLabel33.Size = new System.Drawing.Size(146, 23);
            this.customLabel33.TabIndex = 16;
            this.customLabel33.Text = "空盘气缸降到位：";
            // 
            // customLabel32
            // 
            this.customLabel32.AutoSize = true;
            this.customLabel32.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.customLabel32.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.customLabel32.Location = new System.Drawing.Point(30, 102);
            this.customLabel32.Name = "customLabel32";
            this.customLabel32.Size = new System.Drawing.Size(146, 23);
            this.customLabel32.TabIndex = 15;
            this.customLabel32.Text = "空盘气缸升到位：";
            // 
            // PicBoxEmptySalverDownArrive
            // 
            this.PicBoxEmptySalverDownArrive.Image = global::RobotWorkstation.Properties.Resources.SmallDarkGreen;
            this.PicBoxEmptySalverDownArrive.Location = new System.Drawing.Point(182, 140);
            this.PicBoxEmptySalverDownArrive.Name = "PicBoxEmptySalverDownArrive";
            this.PicBoxEmptySalverDownArrive.Size = new System.Drawing.Size(22, 22);
            this.PicBoxEmptySalverDownArrive.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PicBoxEmptySalverDownArrive.TabIndex = 14;
            this.PicBoxEmptySalverDownArrive.TabStop = false;
            // 
            // PicBoxEmptySalverUpArrive
            // 
            this.PicBoxEmptySalverUpArrive.Image = global::RobotWorkstation.Properties.Resources.SmallDarkGreen;
            this.PicBoxEmptySalverUpArrive.Location = new System.Drawing.Point(182, 103);
            this.PicBoxEmptySalverUpArrive.Name = "PicBoxEmptySalverUpArrive";
            this.PicBoxEmptySalverUpArrive.Size = new System.Drawing.Size(22, 22);
            this.PicBoxEmptySalverUpArrive.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PicBoxEmptySalverUpArrive.TabIndex = 13;
            this.PicBoxEmptySalverUpArrive.TabStop = false;
            // 
            // CButtonIoEmptySalverLiftingUp
            // 
            this.CButtonIoEmptySalverLiftingUp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.CButtonIoEmptySalverLiftingUp.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CButtonIoEmptySalverLiftingUp.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.CButtonIoEmptySalverLiftingUp.ForeColor = System.Drawing.Color.Transparent;
            this.CButtonIoEmptySalverLiftingUp.Location = new System.Drawing.Point(224, 96);
            this.CButtonIoEmptySalverLiftingUp.Name = "CButtonIoEmptySalverLiftingUp";
            this.CButtonIoEmptySalverLiftingUp.Size = new System.Drawing.Size(105, 36);
            this.CButtonIoEmptySalverLiftingUp.TabIndex = 11;
            this.CButtonIoEmptySalverLiftingUp.Text = "空盘气缸升";
            this.CButtonIoEmptySalverLiftingUp.UseVisualStyleBackColor = false;
            this.CButtonIoEmptySalverLiftingUp.Click += new System.EventHandler(this.CButtonIoEmptySalverLiftingUp_Click);
            // 
            // CButtonIoEmptySalverLiftingDown
            // 
            this.CButtonIoEmptySalverLiftingDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.CButtonIoEmptySalverLiftingDown.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CButtonIoEmptySalverLiftingDown.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.CButtonIoEmptySalverLiftingDown.ForeColor = System.Drawing.Color.Transparent;
            this.CButtonIoEmptySalverLiftingDown.Location = new System.Drawing.Point(224, 133);
            this.CButtonIoEmptySalverLiftingDown.Name = "CButtonIoEmptySalverLiftingDown";
            this.CButtonIoEmptySalverLiftingDown.Size = new System.Drawing.Size(105, 36);
            this.CButtonIoEmptySalverLiftingDown.TabIndex = 12;
            this.CButtonIoEmptySalverLiftingDown.Text = "空盘气缸降";
            this.CButtonIoEmptySalverLiftingDown.UseVisualStyleBackColor = false;
            this.CButtonIoEmptySalverLiftingDown.Click += new System.EventHandler(this.CButtonIoEmptySalverLiftingDown_Click);
            // 
            // CGroupBoxArmTowerLight
            // 
            this.CGroupBoxArmTowerLight.Controls.Add(this.BtnBeepOff);
            this.CGroupBoxArmTowerLight.Controls.Add(this.BtnBeepOn);
            this.CGroupBoxArmTowerLight.Controls.Add(this.BtnLampBlueOff);
            this.CGroupBoxArmTowerLight.Controls.Add(this.BtnLampBlueOn);
            this.CGroupBoxArmTowerLight.Controls.Add(this.BtnLampGreenOff);
            this.CGroupBoxArmTowerLight.Controls.Add(this.BtnLampGreenOn);
            this.CGroupBoxArmTowerLight.Controls.Add(this.BtnLampOrangeOff);
            this.CGroupBoxArmTowerLight.Controls.Add(this.BtnLampOrangeOn);
            this.CGroupBoxArmTowerLight.Controls.Add(this.BtnLampRedOff);
            this.CGroupBoxArmTowerLight.Controls.Add(this.BtnLampRedOn);
            this.CGroupBoxArmTowerLight.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.CGroupBoxArmTowerLight.Location = new System.Drawing.Point(661, 3);
            this.CGroupBoxArmTowerLight.Name = "CGroupBoxArmTowerLight";
            this.CGroupBoxArmTowerLight.Size = new System.Drawing.Size(508, 124);
            this.CGroupBoxArmTowerLight.TabIndex = 17;
            this.CGroupBoxArmTowerLight.TabStop = false;
            this.CGroupBoxArmTowerLight.Text = "塔灯";
            // 
            // BtnBeepOff
            // 
            this.BtnBeepOff.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.BtnBeepOff.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnBeepOff.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.BtnBeepOff.ForeColor = System.Drawing.Color.Transparent;
            this.BtnBeepOff.Location = new System.Drawing.Point(400, 71);
            this.BtnBeepOff.Name = "BtnBeepOff";
            this.BtnBeepOff.Size = new System.Drawing.Size(90, 36);
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
            this.BtnBeepOn.Location = new System.Drawing.Point(400, 29);
            this.BtnBeepOn.Name = "BtnBeepOn";
            this.BtnBeepOn.Size = new System.Drawing.Size(90, 36);
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
            this.BtnLampBlueOff.Location = new System.Drawing.Point(304, 71);
            this.BtnLampBlueOff.Name = "BtnLampBlueOff";
            this.BtnLampBlueOff.Size = new System.Drawing.Size(90, 36);
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
            this.BtnLampBlueOn.Location = new System.Drawing.Point(304, 29);
            this.BtnLampBlueOn.Name = "BtnLampBlueOn";
            this.BtnLampBlueOn.Size = new System.Drawing.Size(90, 36);
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
            this.BtnLampGreenOff.Location = new System.Drawing.Point(208, 71);
            this.BtnLampGreenOff.Name = "BtnLampGreenOff";
            this.BtnLampGreenOff.Size = new System.Drawing.Size(90, 36);
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
            this.BtnLampGreenOn.Location = new System.Drawing.Point(208, 29);
            this.BtnLampGreenOn.Name = "BtnLampGreenOn";
            this.BtnLampGreenOn.Size = new System.Drawing.Size(90, 36);
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
            this.BtnLampOrangeOff.Location = new System.Drawing.Point(112, 71);
            this.BtnLampOrangeOff.Name = "BtnLampOrangeOff";
            this.BtnLampOrangeOff.Size = new System.Drawing.Size(90, 36);
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
            this.BtnLampOrangeOn.Location = new System.Drawing.Point(112, 29);
            this.BtnLampOrangeOn.Name = "BtnLampOrangeOn";
            this.BtnLampOrangeOn.Size = new System.Drawing.Size(90, 36);
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
            this.BtnLampRedOff.Location = new System.Drawing.Point(15, 71);
            this.BtnLampRedOff.Name = "BtnLampRedOff";
            this.BtnLampRedOff.Size = new System.Drawing.Size(90, 36);
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
            this.BtnLampRedOn.Location = new System.Drawing.Point(15, 29);
            this.BtnLampRedOn.Name = "BtnLampRedOn";
            this.BtnLampRedOn.Size = new System.Drawing.Size(90, 36);
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
            this.customGroupBox10.Location = new System.Drawing.Point(3, 239);
            this.customGroupBox10.Name = "customGroupBox10";
            this.customGroupBox10.Size = new System.Drawing.Size(639, 94);
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
            this.CTextBoxTrayDeviceRfidSn.Location = new System.Drawing.Point(339, 40);
            this.CTextBoxTrayDeviceRfidSn.Multiline = true;
            this.CTextBoxTrayDeviceRfidSn.Name = "CTextBoxTrayDeviceRfidSn";
            this.CTextBoxTrayDeviceRfidSn.ReadOnly = true;
            this.CTextBoxTrayDeviceRfidSn.Size = new System.Drawing.Size(244, 32);
            this.CTextBoxTrayDeviceRfidSn.TabIndex = 12;
            // 
            // customLabel48
            // 
            this.customLabel48.AutoSize = true;
            this.customLabel48.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.customLabel48.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.customLabel48.Location = new System.Drawing.Point(195, 42);
            this.customLabel48.Name = "customLabel48";
            this.customLabel48.Size = new System.Drawing.Size(146, 23);
            this.customLabel48.TabIndex = 11;
            this.customLabel48.Text = "物料托盘序列号：";
            // 
            // PicTrayDeviceInRFID
            // 
            this.PicTrayDeviceInRFID.Image = global::RobotWorkstation.Properties.Resources.SmallDarkGreen;
            this.PicTrayDeviceInRFID.Location = new System.Drawing.Point(147, 43);
            this.PicTrayDeviceInRFID.Name = "PicTrayDeviceInRFID";
            this.PicTrayDeviceInRFID.Size = new System.Drawing.Size(22, 22);
            this.PicTrayDeviceInRFID.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PicTrayDeviceInRFID.TabIndex = 10;
            this.PicTrayDeviceInRFID.TabStop = false;
            // 
            // customLabel42
            // 
            this.customLabel42.AutoSize = true;
            this.customLabel42.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.customLabel42.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.customLabel42.Location = new System.Drawing.Point(25, 43);
            this.customLabel42.Name = "customLabel42";
            this.customLabel42.Size = new System.Drawing.Size(116, 23);
            this.customLabel42.TabIndex = 0;
            this.customLabel42.Text = "物料托盘到位:";
            // 
            // ManualDebugForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.ClientSize = new System.Drawing.Size(1260, 830);
            this.ControlBox = false;
            this.Controls.Add(this.tabControlManualDebug);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ManualDebugForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Load += new System.EventHandler(this.ManualDebug_Load);
            this.Shown += new System.EventHandler(this.ManualDebugForm_Shown);
            this.tabControlManualDebug.ResumeLayout(false);
            this.tabPageOthers.ResumeLayout(false);
            this.CGroupBoxArmSensor.ResumeLayout(false);
            this.CGroupBoxArmSensor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxSalverRunOutStationSensor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxEmptySalverObstructSensor)).EndInit();
            this.CGrpTurnOver.ResumeLayout(false);
            this.CGrpTurnOver.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicOverturnCylUnLock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicOverturnCylLock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicOverturn)).EndInit();
            this.CGrpAxisConveyor.ResumeLayout(false);
            this.CGrpAxisConveyor.PerformLayout();
            this.CGroupBoxArmKeyIn.ResumeLayout(false);
            this.CGroupBoxArmKeyIn.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicKeyReset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicKeyStop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicKeyPause)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicKeyRun)).EndInit();
            this.CGroupBoxArmAireCyl.ResumeLayout(false);
            this.CGroupBoxArmAireCyl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxConveyorDownArrive)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxConveyorUpArrive)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxEmptySalverObstructDownArrive)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxEmptySalverObstructUpArrive)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxEmptySalverDownArrive)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxEmptySalverUpArrive)).EndInit();
            this.CGroupBoxArmTowerLight.ResumeLayout(false);
            this.customGroupBox10.ResumeLayout(false);
            this.customGroupBox10.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicTrayDeviceInRFID)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CustomTabControl tabControlManualDebug;
        private System.Windows.Forms.TabPage tabPageRobot;
        private System.Windows.Forms.Timer RefreshTimer;
        private System.Windows.Forms.OpenFileDialog OpenFileDialogMotionControlLoadCfg;
        private System.Windows.Forms.TabPage tabPageOthers;
        private CustomGroupBox customGroupBox10;
        private CustomLabel customLabel42;
        private CustomTextBox CTextBoxTrayDeviceRfidSn;
        private CustomLabel customLabel48;
        private System.Windows.Forms.PictureBox PicTrayDeviceInRFID;
        private CustomGroupBox CGroupBoxArmTowerLight;
        private CustomGroupBox CGroupBoxArmKeyIn;
        private System.Windows.Forms.PictureBox PicKeyReset;
        private System.Windows.Forms.PictureBox PicKeyStop;
        private System.Windows.Forms.PictureBox PicKeyPause;
        private System.Windows.Forms.PictureBox PicKeyRun;
        private CustomLabel customLabel52;
        private CustomLabel customLabel51;
        private CustomLabel customLabel50;
        private CustomLabel customLabel49;
        private CustomGroupBox CGroupBoxArmAireCyl;
        private System.Windows.Forms.PictureBox PicBoxEmptySalverDownArrive;
        private System.Windows.Forms.PictureBox PicBoxEmptySalverUpArrive;
        private CustomButton CButtonIoEmptySalverLiftingUp;
        private CustomButton CButtonIoEmptySalverLiftingDown;
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
        private CustomButton CButtonConveyorDown;
        private CustomButton CButtonConveyorUp;
        private CustomButton CButtonEmptySalverObstructDown;
        private CustomButton CButtonEmptySalverObstructUp;
        private System.Windows.Forms.PictureBox PicBoxConveyorDownArrive;
        private System.Windows.Forms.PictureBox PicBoxConveyorUpArrive;
        private System.Windows.Forms.PictureBox PicBoxEmptySalverObstructDownArrive;
        private System.Windows.Forms.PictureBox PicBoxEmptySalverObstructUpArrive;
        private CustomLabel customLabel38;
        private CustomLabel customLabel37;
        private CustomLabel customLabel36;
        private CustomLabel customLabel35;
        private CustomGroupBox CGroupBoxArmSensor;
        private System.Windows.Forms.PictureBox PicBoxSalverRunOutStationSensor;
        private System.Windows.Forms.PictureBox PicBoxEmptySalverObstructSensor;
        private CustomLabel customLabel40;
        private CustomLabel customLabel39;
        private CustomButton BtnAxisOverturnSetDefaultParam;
        private CustomButton BtnAxisConveyorSetDefaultParam;
    }
}