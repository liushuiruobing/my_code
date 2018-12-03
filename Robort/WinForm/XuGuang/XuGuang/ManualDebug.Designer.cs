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
            this.TimerMotionControlGetState = new System.Windows.Forms.Timer(this.components);
            this.OpenFileDialogMotionControlLoadCfg = new System.Windows.Forms.OpenFileDialog();
            this.tabControlManualDebug = new RobotWorkstation.CustomTabControl();
            this.tabPageRobot = new System.Windows.Forms.TabPage();
            this.groupBoxRobot = new RobotWorkstation.CustomGroupBox();
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
            this.customLabel10 = new RobotWorkstation.CustomLabel();
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
            this.tabPageThreeAxisRobot = new System.Windows.Forms.TabPage();
            this.customGroupBox6 = new RobotWorkstation.CustomGroupBox();
            this.CButtonMotionAxisStop = new RobotWorkstation.CustomButton();
            this.CButtonMotionAxisHome = new RobotWorkstation.CustomButton();
            this.CButtonMotionAxisRunPos = new RobotWorkstation.CustomButton();
            this.CButtonMotionAxisRunNeg = new RobotWorkstation.CustomButton();
            this.customLabel44 = new RobotWorkstation.CustomLabel();
            this.ComBoxMotionHomeMode = new System.Windows.Forms.ComboBox();
            this.customLabel43 = new RobotWorkstation.CustomLabel();
            this.ComBoxMotionControlAxis = new System.Windows.Forms.ComboBox();
            this.customLabel41 = new RobotWorkstation.CustomLabel();
            this.customGroupBox5 = new RobotWorkstation.CustomGroupBox();
            this.CTextBoxMotionControlZDistance = new RobotWorkstation.CustomTextBox();
            this.CTextBoxMotionControlYDistance = new RobotWorkstation.CustomTextBox();
            this.customLabel40 = new RobotWorkstation.CustomLabel();
            this.customLabel39 = new RobotWorkstation.CustomLabel();
            this.CTextBoxMotionControlXDistance = new RobotWorkstation.CustomTextBox();
            this.customLabel38 = new RobotWorkstation.CustomLabel();
            this.customGroupBox4 = new RobotWorkstation.CustomGroupBox();
            this.CTextBoxMotionControlDistance = new RobotWorkstation.CustomTextBox();
            this.customLabel20 = new RobotWorkstation.CustomLabel();
            this.CButtonSetMotionControlSpeedParam = new RobotWorkstation.CustomButton();
            this.CTextBoxMotionControDecSpeed = new RobotWorkstation.CustomTextBox();
            this.CTextBoxMotionControAccSpeed = new RobotWorkstation.CustomTextBox();
            this.customLabel37 = new RobotWorkstation.CustomLabel();
            this.customLabel36 = new RobotWorkstation.CustomLabel();
            this.CTextBoxMotionControHighSpeed = new RobotWorkstation.CustomTextBox();
            this.customLabel35 = new RobotWorkstation.CustomLabel();
            this.CTextBoxMotionControLowSpeed = new RobotWorkstation.CustomTextBox();
            this.customLabel34 = new RobotWorkstation.CustomLabel();
            this.customGroupBox3 = new RobotWorkstation.CustomGroupBox();
            this.CButtonMotionControlGrasp = new RobotWorkstation.CustomButton();
            this.CButtonMotionControlRight = new RobotWorkstation.CustomButton();
            this.CButtonMotionControlLift = new RobotWorkstation.CustomButton();
            this.CButtonMotionControlDown = new RobotWorkstation.CustomButton();
            this.CButtonMotionControlUp = new RobotWorkstation.CustomButton();
            this.customGroupBox2 = new RobotWorkstation.CustomGroupBox();
            this.picBoxMotionControlIoNegLmit = new System.Windows.Forms.PictureBox();
            this.customLabel33 = new RobotWorkstation.CustomLabel();
            this.picBoxMotionControlIoPosLmit = new System.Windows.Forms.PictureBox();
            this.customLabel32 = new RobotWorkstation.CustomLabel();
            this.picBoxMotionControlIoORG = new System.Windows.Forms.PictureBox();
            this.customLabel31 = new RobotWorkstation.CustomLabel();
            this.picBoxMotionControlIoEZ = new System.Windows.Forms.PictureBox();
            this.customLabel30 = new RobotWorkstation.CustomLabel();
            this.customLabel29 = new RobotWorkstation.CustomLabel();
            this.CButtonMotionControlResetError = new RobotWorkstation.CustomButton();
            this.CTextBoxMotionControlState = new RobotWorkstation.CustomTextBox();
            this.customLabel28 = new RobotWorkstation.CustomLabel();
            this.CButtonMotionControlDeviceLoadCfg = new RobotWorkstation.CustomButton();
            this.CButtonCloseMotionControlDevice = new RobotWorkstation.CustomButton();
            this.CButtonOpenMotionControlDevice = new RobotWorkstation.CustomButton();
            this.customLabel27 = new RobotWorkstation.CustomLabel();
            this.ComBoxMotionControlDevice = new System.Windows.Forms.ComboBox();
            this.customLabel26 = new RobotWorkstation.CustomLabel();
            this.tabPageCamera = new System.Windows.Forms.TabPage();
            this.customGroupBox1 = new RobotWorkstation.CustomGroupBox();
            this.PictureBoxCamera = new System.Windows.Forms.PictureBox();
            this.CGroupBoxCameraSet = new RobotWorkstation.CustomGroupBox();
            this.CButtonCameraReadParam = new RobotWorkstation.CustomButton();
            this.CButtonCameraSetParam = new RobotWorkstation.CustomButton();
            this.CTextBoxCameraFrameRate = new RobotWorkstation.CustomTextBox();
            this.CTextBoxCameraGain = new RobotWorkstation.CustomTextBox();
            this.CTextBoxCameraExposure = new RobotWorkstation.CustomTextBox();
            this.customLabel25 = new RobotWorkstation.CustomLabel();
            this.customLabel24 = new RobotWorkstation.CustomLabel();
            this.customLabel23 = new RobotWorkstation.CustomLabel();
            this.customLabel22 = new RobotWorkstation.CustomLabel();
            this.CButtonCloseCamera = new RobotWorkstation.CustomButton();
            this.CButtonOpenCamera = new RobotWorkstation.CustomButton();
            this.CButtonFindCamera = new RobotWorkstation.CustomButton();
            this.customLabel21 = new RobotWorkstation.CustomLabel();
            this.ComBoxCameraDevList = new System.Windows.Forms.ComboBox();
            this.tabControlManualDebug.SuspendLayout();
            this.tabPageRobot.SuspendLayout();
            this.groupBoxRobot.SuspendLayout();
            this.CTabControlBorderRobotTestPoints.SuspendLayout();
            this.PageRobotTestGlobalPoint.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_RobotGlobalPoint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRobotMove)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTemperature)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRobotExecut)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRobotAlarm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxServo)).BeginInit();
            this.tabPageThreeAxisRobot.SuspendLayout();
            this.customGroupBox6.SuspendLayout();
            this.customGroupBox5.SuspendLayout();
            this.customGroupBox4.SuspendLayout();
            this.customGroupBox3.SuspendLayout();
            this.customGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxMotionControlIoNegLmit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxMotionControlIoPosLmit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxMotionControlIoORG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxMotionControlIoEZ)).BeginInit();
            this.tabPageCamera.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxCamera)).BeginInit();
            this.CGroupBoxCameraSet.SuspendLayout();
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
            // TimerMotionControlGetState
            // 
            this.TimerMotionControlGetState.Interval = 200;
            this.TimerMotionControlGetState.Tick += new System.EventHandler(this.TimerMotionControlGetState_Tick);
            // 
            // OpenFileDialogMotionControlLoadCfg
            // 
            this.OpenFileDialogMotionControlLoadCfg.FileName = "导入配置";
            // 
            // tabControlManualDebug
            // 
            this.tabControlManualDebug.Controls.Add(this.tabPageRobot);
            this.tabControlManualDebug.Controls.Add(this.tabPageThreeAxisRobot);
            this.tabControlManualDebug.Controls.Add(this.tabPageCamera);
            this.tabControlManualDebug.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabControlManualDebug.ItemSize = new System.Drawing.Size(120, 26);
            this.tabControlManualDebug.Location = new System.Drawing.Point(12, 12);
            this.tabControlManualDebug.Margin = new System.Windows.Forms.Padding(0);
            this.tabControlManualDebug.Name = "tabControlManualDebug";
            this.tabControlManualDebug.Padding = new System.Drawing.Point(20, 3);
            this.tabControlManualDebug.SelectedIndex = 0;
            this.tabControlManualDebug.Size = new System.Drawing.Size(1360, 790);
            this.tabControlManualDebug.TabIndex = 0;
            this.tabControlManualDebug.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabControlManualDebug_Selected);
            // 
            // tabPageRobot
            // 
            this.tabPageRobot.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.tabPageRobot.Controls.Add(this.groupBoxRobot);
            this.tabPageRobot.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabPageRobot.Location = new System.Drawing.Point(0, 29);
            this.tabPageRobot.Name = "tabPageRobot";
            this.tabPageRobot.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageRobot.Size = new System.Drawing.Size(1360, 761);
            this.tabPageRobot.TabIndex = 0;
            this.tabPageRobot.Text = "机械臂";
            // 
            // groupBoxRobot
            // 
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
            this.groupBoxRobot.Controls.Add(this.customLabel10);
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
            this.groupBoxRobot.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBoxRobot.ForeColor = System.Drawing.Color.White;
            this.groupBoxRobot.Location = new System.Drawing.Point(10, 10);
            this.groupBoxRobot.Name = "groupBoxRobot";
            this.groupBoxRobot.Size = new System.Drawing.Size(1322, 670);
            this.groupBoxRobot.TabIndex = 0;
            this.groupBoxRobot.TabStop = false;
            this.groupBoxRobot.Text = "机械臂";
            // 
            // CBtnRobotTestTeachPoint
            // 
            this.CBtnRobotTestTeachPoint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.CBtnRobotTestTeachPoint.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CBtnRobotTestTeachPoint.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.CBtnRobotTestTeachPoint.ForeColor = System.Drawing.Color.Transparent;
            this.CBtnRobotTestTeachPoint.Location = new System.Drawing.Point(565, 622);
            this.CBtnRobotTestTeachPoint.Name = "CBtnRobotTestTeachPoint";
            this.CBtnRobotTestTeachPoint.Size = new System.Drawing.Size(90, 30);
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
            this.CBtnRobotTestMoveToPoint.Location = new System.Drawing.Point(468, 622);
            this.CBtnRobotTestMoveToPoint.Name = "CBtnRobotTestMoveToPoint";
            this.CBtnRobotTestMoveToPoint.Size = new System.Drawing.Size(90, 30);
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
            this.customLabel19.Location = new System.Drawing.Point(20, 39);
            this.customLabel19.Name = "customLabel19";
            this.customLabel19.Size = new System.Drawing.Size(61, 23);
            this.customLabel19.TabIndex = 61;
            this.customLabel19.Text = "伺服：";
            // 
            // CBtnRobotTestReadPoint
            // 
            this.CBtnRobotTestReadPoint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.CBtnRobotTestReadPoint.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CBtnRobotTestReadPoint.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.CBtnRobotTestReadPoint.ForeColor = System.Drawing.Color.Transparent;
            this.CBtnRobotTestReadPoint.Location = new System.Drawing.Point(371, 622);
            this.CBtnRobotTestReadPoint.Name = "CBtnRobotTestReadPoint";
            this.CBtnRobotTestReadPoint.Size = new System.Drawing.Size(90, 30);
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
            this.CTabControlBorderRobotTestPoints.Location = new System.Drawing.Point(372, 36);
            this.CTabControlBorderRobotTestPoints.Margin = new System.Windows.Forms.Padding(1);
            this.CTabControlBorderRobotTestPoints.Name = "CTabControlBorderRobotTestPoints";
            this.CTabControlBorderRobotTestPoints.SelectedIndex = 0;
            this.CTabControlBorderRobotTestPoints.Size = new System.Drawing.Size(720, 577);
            this.CTabControlBorderRobotTestPoints.TabIndex = 59;
            // 
            // PageRobotTestGlobalPoint
            // 
            this.PageRobotTestGlobalPoint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.PageRobotTestGlobalPoint.Controls.Add(this.DGV_RobotGlobalPoint);
            this.PageRobotTestGlobalPoint.Location = new System.Drawing.Point(1, 29);
            this.PageRobotTestGlobalPoint.Margin = new System.Windows.Forms.Padding(1);
            this.PageRobotTestGlobalPoint.Name = "PageRobotTestGlobalPoint";
            this.PageRobotTestGlobalPoint.Padding = new System.Windows.Forms.Padding(1);
            this.PageRobotTestGlobalPoint.Size = new System.Drawing.Size(718, 547);
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
            this.DGV_RobotGlobalPoint.Size = new System.Drawing.Size(719, 547);
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
            this.RobotTestName.Width = 67;
            // 
            // RobotTestX
            // 
            this.RobotTestX.HeaderText = "X";
            this.RobotTestX.Name = "RobotTestX";
            this.RobotTestX.Width = 45;
            // 
            // RobotTestY
            // 
            this.RobotTestY.HeaderText = "Y";
            this.RobotTestY.Name = "RobotTestY";
            this.RobotTestY.Width = 45;
            // 
            // RobotTestZ
            // 
            this.RobotTestZ.HeaderText = "Z";
            this.RobotTestZ.Name = "RobotTestZ";
            this.RobotTestZ.Width = 45;
            // 
            // RobotTestRZ
            // 
            this.RobotTestRZ.HeaderText = "RZ";
            this.RobotTestRZ.Name = "RobotTestRZ";
            this.RobotTestRZ.Width = 55;
            // 
            // RobotTestHand
            // 
            this.RobotTestHand.HeaderText = "手系";
            this.RobotTestHand.Name = "RobotTestHand";
            this.RobotTestHand.Width = 67;
            // 
            // RobotTestUserID
            // 
            this.RobotTestUserID.HeaderText = "UserID";
            this.RobotTestUserID.Name = "RobotTestUserID";
            this.RobotTestUserID.Width = 86;
            // 
            // RobotTestToolID
            // 
            this.RobotTestToolID.HeaderText = "ToolID";
            this.RobotTestToolID.Name = "RobotTestToolID";
            this.RobotTestToolID.Width = 85;
            // 
            // PageRobotTestUserFrame
            // 
            this.PageRobotTestUserFrame.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.PageRobotTestUserFrame.Location = new System.Drawing.Point(1, 29);
            this.PageRobotTestUserFrame.Margin = new System.Windows.Forms.Padding(1);
            this.PageRobotTestUserFrame.Name = "PageRobotTestUserFrame";
            this.PageRobotTestUserFrame.Padding = new System.Windows.Forms.Padding(1);
            this.PageRobotTestUserFrame.Size = new System.Drawing.Size(718, 547);
            this.PageRobotTestUserFrame.TabIndex = 1;
            this.PageRobotTestUserFrame.Text = "使用者坐标";
            // 
            // PageRobotTestToolFrame
            // 
            this.PageRobotTestToolFrame.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.PageRobotTestToolFrame.Location = new System.Drawing.Point(1, 29);
            this.PageRobotTestToolFrame.Margin = new System.Windows.Forms.Padding(1);
            this.PageRobotTestToolFrame.Name = "PageRobotTestToolFrame";
            this.PageRobotTestToolFrame.Padding = new System.Windows.Forms.Padding(1);
            this.PageRobotTestToolFrame.Size = new System.Drawing.Size(718, 547);
            this.PageRobotTestToolFrame.TabIndex = 2;
            this.PageRobotTestToolFrame.Text = "工具坐标";
            // 
            // PageRobotTestWorkSpace
            // 
            this.PageRobotTestWorkSpace.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.PageRobotTestWorkSpace.Location = new System.Drawing.Point(1, 29);
            this.PageRobotTestWorkSpace.Margin = new System.Windows.Forms.Padding(1);
            this.PageRobotTestWorkSpace.Name = "PageRobotTestWorkSpace";
            this.PageRobotTestWorkSpace.Padding = new System.Windows.Forms.Padding(1);
            this.PageRobotTestWorkSpace.Size = new System.Drawing.Size(718, 547);
            this.PageRobotTestWorkSpace.TabIndex = 3;
            this.PageRobotTestWorkSpace.Text = "工作空间";
            // 
            // CButtonRobotDistanceRZSub
            // 
            this.CButtonRobotDistanceRZSub.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.CButtonRobotDistanceRZSub.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CButtonRobotDistanceRZSub.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.CButtonRobotDistanceRZSub.ForeColor = System.Drawing.Color.Transparent;
            this.CButtonRobotDistanceRZSub.Location = new System.Drawing.Point(250, 585);
            this.CButtonRobotDistanceRZSub.Name = "CButtonRobotDistanceRZSub";
            this.CButtonRobotDistanceRZSub.Size = new System.Drawing.Size(90, 30);
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
            this.CButtonRobotDistanceRZAdd.Location = new System.Drawing.Point(154, 585);
            this.CButtonRobotDistanceRZAdd.Name = "CButtonRobotDistanceRZAdd";
            this.CButtonRobotDistanceRZAdd.Size = new System.Drawing.Size(90, 30);
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
            this.CTextBoxRobotDistanceRZ.Location = new System.Drawing.Point(59, 585);
            this.CTextBoxRobotDistanceRZ.Name = "CTextBoxRobotDistanceRZ";
            this.CTextBoxRobotDistanceRZ.Size = new System.Drawing.Size(90, 29);
            this.CTextBoxRobotDistanceRZ.TabIndex = 56;
            this.CTextBoxRobotDistanceRZ.Text = "0.000";
            // 
            // customLabel15
            // 
            this.customLabel15.AutoSize = true;
            this.customLabel15.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.customLabel15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.customLabel15.Location = new System.Drawing.Point(20, 591);
            this.customLabel15.Name = "customLabel15";
            this.customLabel15.Size = new System.Drawing.Size(49, 23);
            this.customLabel15.TabIndex = 55;
            this.customLabel15.Text = "RZ：";
            // 
            // CButtonRobotDistanceZSub
            // 
            this.CButtonRobotDistanceZSub.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.CButtonRobotDistanceZSub.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CButtonRobotDistanceZSub.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.CButtonRobotDistanceZSub.ForeColor = System.Drawing.Color.Transparent;
            this.CButtonRobotDistanceZSub.Location = new System.Drawing.Point(250, 552);
            this.CButtonRobotDistanceZSub.Name = "CButtonRobotDistanceZSub";
            this.CButtonRobotDistanceZSub.Size = new System.Drawing.Size(90, 30);
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
            this.CButtonRobotDistanceZAdd.Location = new System.Drawing.Point(154, 552);
            this.CButtonRobotDistanceZAdd.Name = "CButtonRobotDistanceZAdd";
            this.CButtonRobotDistanceZAdd.Size = new System.Drawing.Size(90, 30);
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
            this.CTextBoxRobotDistanceZ.Location = new System.Drawing.Point(59, 552);
            this.CTextBoxRobotDistanceZ.Name = "CTextBoxRobotDistanceZ";
            this.CTextBoxRobotDistanceZ.Size = new System.Drawing.Size(90, 29);
            this.CTextBoxRobotDistanceZ.TabIndex = 52;
            this.CTextBoxRobotDistanceZ.Text = "0.000";
            // 
            // customLabel16
            // 
            this.customLabel16.AutoSize = true;
            this.customLabel16.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.customLabel16.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.customLabel16.Location = new System.Drawing.Point(20, 556);
            this.customLabel16.Name = "customLabel16";
            this.customLabel16.Size = new System.Drawing.Size(38, 23);
            this.customLabel16.TabIndex = 51;
            this.customLabel16.Text = "Z：";
            // 
            // CButtonRobotDistanceYSub
            // 
            this.CButtonRobotDistanceYSub.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.CButtonRobotDistanceYSub.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CButtonRobotDistanceYSub.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.CButtonRobotDistanceYSub.ForeColor = System.Drawing.Color.Transparent;
            this.CButtonRobotDistanceYSub.Location = new System.Drawing.Point(250, 519);
            this.CButtonRobotDistanceYSub.Name = "CButtonRobotDistanceYSub";
            this.CButtonRobotDistanceYSub.Size = new System.Drawing.Size(90, 30);
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
            this.CButtonRobotDistanceYAdd.Location = new System.Drawing.Point(154, 519);
            this.CButtonRobotDistanceYAdd.Name = "CButtonRobotDistanceYAdd";
            this.CButtonRobotDistanceYAdd.Size = new System.Drawing.Size(90, 30);
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
            this.CTextBoxRobotDistanceY.Location = new System.Drawing.Point(59, 519);
            this.CTextBoxRobotDistanceY.Name = "CTextBoxRobotDistanceY";
            this.CTextBoxRobotDistanceY.Size = new System.Drawing.Size(90, 29);
            this.CTextBoxRobotDistanceY.TabIndex = 48;
            this.CTextBoxRobotDistanceY.Text = "0.000";
            // 
            // customLabel17
            // 
            this.customLabel17.AutoSize = true;
            this.customLabel17.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.customLabel17.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.customLabel17.Location = new System.Drawing.Point(20, 522);
            this.customLabel17.Name = "customLabel17";
            this.customLabel17.Size = new System.Drawing.Size(37, 23);
            this.customLabel17.TabIndex = 47;
            this.customLabel17.Text = "Y：";
            // 
            // CButtonRobotDistanceXSub
            // 
            this.CButtonRobotDistanceXSub.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.CButtonRobotDistanceXSub.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CButtonRobotDistanceXSub.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.CButtonRobotDistanceXSub.ForeColor = System.Drawing.Color.Transparent;
            this.CButtonRobotDistanceXSub.Location = new System.Drawing.Point(250, 486);
            this.CButtonRobotDistanceXSub.Name = "CButtonRobotDistanceXSub";
            this.CButtonRobotDistanceXSub.Size = new System.Drawing.Size(90, 30);
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
            this.CButtonRobotDistanceXAdd.Location = new System.Drawing.Point(154, 486);
            this.CButtonRobotDistanceXAdd.Name = "CButtonRobotDistanceXAdd";
            this.CButtonRobotDistanceXAdd.Size = new System.Drawing.Size(90, 30);
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
            this.CTextBoxRobotDistanceX.Location = new System.Drawing.Point(59, 486);
            this.CTextBoxRobotDistanceX.Name = "CTextBoxRobotDistanceX";
            this.CTextBoxRobotDistanceX.Size = new System.Drawing.Size(90, 29);
            this.CTextBoxRobotDistanceX.TabIndex = 44;
            this.CTextBoxRobotDistanceX.Text = "0.000";
            // 
            // customLabel18
            // 
            this.customLabel18.AutoSize = true;
            this.customLabel18.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.customLabel18.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.customLabel18.Location = new System.Drawing.Point(20, 489);
            this.customLabel18.Name = "customLabel18";
            this.customLabel18.Size = new System.Drawing.Size(38, 23);
            this.customLabel18.TabIndex = 43;
            this.customLabel18.Text = "X：";
            // 
            // CButtonRobotDistanceJ4Sub
            // 
            this.CButtonRobotDistanceJ4Sub.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.CButtonRobotDistanceJ4Sub.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CButtonRobotDistanceJ4Sub.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.CButtonRobotDistanceJ4Sub.ForeColor = System.Drawing.Color.Transparent;
            this.CButtonRobotDistanceJ4Sub.Location = new System.Drawing.Point(250, 452);
            this.CButtonRobotDistanceJ4Sub.Name = "CButtonRobotDistanceJ4Sub";
            this.CButtonRobotDistanceJ4Sub.Size = new System.Drawing.Size(90, 30);
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
            this.CButtonRobotDistanceJ4Add.Location = new System.Drawing.Point(154, 452);
            this.CButtonRobotDistanceJ4Add.Name = "CButtonRobotDistanceJ4Add";
            this.CButtonRobotDistanceJ4Add.Size = new System.Drawing.Size(90, 30);
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
            this.CTextBoxRobotDistanceJ4.Location = new System.Drawing.Point(59, 453);
            this.CTextBoxRobotDistanceJ4.Name = "CTextBoxRobotDistanceJ4";
            this.CTextBoxRobotDistanceJ4.Size = new System.Drawing.Size(90, 29);
            this.CTextBoxRobotDistanceJ4.TabIndex = 40;
            this.CTextBoxRobotDistanceJ4.Text = "0";
            // 
            // customLabel14
            // 
            this.customLabel14.AutoSize = true;
            this.customLabel14.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.customLabel14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.customLabel14.Location = new System.Drawing.Point(20, 456);
            this.customLabel14.Name = "customLabel14";
            this.customLabel14.Size = new System.Drawing.Size(44, 23);
            this.customLabel14.TabIndex = 39;
            this.customLabel14.Text = "J4：";
            // 
            // CButtonRobotDistanceJ3Sub
            // 
            this.CButtonRobotDistanceJ3Sub.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.CButtonRobotDistanceJ3Sub.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CButtonRobotDistanceJ3Sub.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.CButtonRobotDistanceJ3Sub.ForeColor = System.Drawing.Color.Transparent;
            this.CButtonRobotDistanceJ3Sub.Location = new System.Drawing.Point(250, 419);
            this.CButtonRobotDistanceJ3Sub.Name = "CButtonRobotDistanceJ3Sub";
            this.CButtonRobotDistanceJ3Sub.Size = new System.Drawing.Size(90, 30);
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
            this.CButtonRobotDistanceJ3Add.Location = new System.Drawing.Point(154, 419);
            this.CButtonRobotDistanceJ3Add.Name = "CButtonRobotDistanceJ3Add";
            this.CButtonRobotDistanceJ3Add.Size = new System.Drawing.Size(90, 30);
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
            this.CTextBoxRobotDistanceJ3.Location = new System.Drawing.Point(59, 420);
            this.CTextBoxRobotDistanceJ3.Name = "CTextBoxRobotDistanceJ3";
            this.CTextBoxRobotDistanceJ3.Size = new System.Drawing.Size(90, 29);
            this.CTextBoxRobotDistanceJ3.TabIndex = 36;
            this.CTextBoxRobotDistanceJ3.Text = "0";
            // 
            // customLabel13
            // 
            this.customLabel13.AutoSize = true;
            this.customLabel13.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.customLabel13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.customLabel13.Location = new System.Drawing.Point(20, 421);
            this.customLabel13.Name = "customLabel13";
            this.customLabel13.Size = new System.Drawing.Size(44, 23);
            this.customLabel13.TabIndex = 35;
            this.customLabel13.Text = "J3：";
            // 
            // CButtonRobotDistanceJ2Sub
            // 
            this.CButtonRobotDistanceJ2Sub.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.CButtonRobotDistanceJ2Sub.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CButtonRobotDistanceJ2Sub.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.CButtonRobotDistanceJ2Sub.ForeColor = System.Drawing.Color.Transparent;
            this.CButtonRobotDistanceJ2Sub.Location = new System.Drawing.Point(250, 386);
            this.CButtonRobotDistanceJ2Sub.Name = "CButtonRobotDistanceJ2Sub";
            this.CButtonRobotDistanceJ2Sub.Size = new System.Drawing.Size(90, 30);
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
            this.CButtonRobotDistanceJ2Add.Location = new System.Drawing.Point(154, 386);
            this.CButtonRobotDistanceJ2Add.Name = "CButtonRobotDistanceJ2Add";
            this.CButtonRobotDistanceJ2Add.Size = new System.Drawing.Size(90, 30);
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
            this.CTextBoxRobotDistanceJ2.Location = new System.Drawing.Point(59, 387);
            this.CTextBoxRobotDistanceJ2.Name = "CTextBoxRobotDistanceJ2";
            this.CTextBoxRobotDistanceJ2.Size = new System.Drawing.Size(90, 29);
            this.CTextBoxRobotDistanceJ2.TabIndex = 32;
            this.CTextBoxRobotDistanceJ2.Text = "0";
            // 
            // customLabel12
            // 
            this.customLabel12.AutoSize = true;
            this.customLabel12.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.customLabel12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.customLabel12.Location = new System.Drawing.Point(20, 387);
            this.customLabel12.Name = "customLabel12";
            this.customLabel12.Size = new System.Drawing.Size(44, 23);
            this.customLabel12.TabIndex = 31;
            this.customLabel12.Text = "J2：";
            // 
            // CButtonRobotDistanceJ1Sub
            // 
            this.CButtonRobotDistanceJ1Sub.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.CButtonRobotDistanceJ1Sub.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CButtonRobotDistanceJ1Sub.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.CButtonRobotDistanceJ1Sub.ForeColor = System.Drawing.Color.Transparent;
            this.CButtonRobotDistanceJ1Sub.Location = new System.Drawing.Point(250, 353);
            this.CButtonRobotDistanceJ1Sub.Name = "CButtonRobotDistanceJ1Sub";
            this.CButtonRobotDistanceJ1Sub.Size = new System.Drawing.Size(90, 30);
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
            this.CButtonRobotDistanceJ1Add.Location = new System.Drawing.Point(154, 353);
            this.CButtonRobotDistanceJ1Add.Name = "CButtonRobotDistanceJ1Add";
            this.CButtonRobotDistanceJ1Add.Size = new System.Drawing.Size(90, 30);
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
            this.CTextBoxRobotDistanceJ1.Location = new System.Drawing.Point(59, 354);
            this.CTextBoxRobotDistanceJ1.Name = "CTextBoxRobotDistanceJ1";
            this.CTextBoxRobotDistanceJ1.Size = new System.Drawing.Size(90, 29);
            this.CTextBoxRobotDistanceJ1.TabIndex = 28;
            this.CTextBoxRobotDistanceJ1.Text = "0";
            // 
            // customLabel11
            // 
            this.customLabel11.AutoSize = true;
            this.customLabel11.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.customLabel11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.customLabel11.Location = new System.Drawing.Point(20, 354);
            this.customLabel11.Name = "customLabel11";
            this.customLabel11.Size = new System.Drawing.Size(44, 23);
            this.customLabel11.TabIndex = 27;
            this.customLabel11.Text = "J1：";
            // 
            // radioButtonRobotDeviceContinuous
            // 
            this.radioButtonRobotDeviceContinuous.AutoSize = true;
            this.radioButtonRobotDeviceContinuous.Location = new System.Drawing.Point(173, 204);
            this.radioButtonRobotDeviceContinuous.Name = "radioButtonRobotDeviceContinuous";
            this.radioButtonRobotDeviceContinuous.Size = new System.Drawing.Size(60, 25);
            this.radioButtonRobotDeviceContinuous.TabIndex = 26;
            this.radioButtonRobotDeviceContinuous.TabStop = true;
            this.radioButtonRobotDeviceContinuous.Text = "连续";
            this.radioButtonRobotDeviceContinuous.UseVisualStyleBackColor = true;
            this.radioButtonRobotDeviceContinuous.CheckedChanged += new System.EventHandler(this.radioButtonRobotDeviceContinuous_CheckedChanged);
            // 
            // radioButtonRobotDeviceJog
            // 
            this.radioButtonRobotDeviceJog.AutoSize = true;
            this.radioButtonRobotDeviceJog.Location = new System.Drawing.Point(113, 204);
            this.radioButtonRobotDeviceJog.Name = "radioButtonRobotDeviceJog";
            this.radioButtonRobotDeviceJog.Size = new System.Drawing.Size(54, 25);
            this.radioButtonRobotDeviceJog.TabIndex = 25;
            this.radioButtonRobotDeviceJog.TabStop = true;
            this.radioButtonRobotDeviceJog.Text = "Jog";
            this.radioButtonRobotDeviceJog.UseVisualStyleBackColor = true;
            this.radioButtonRobotDeviceJog.CheckedChanged += new System.EventHandler(this.radioButtonRobotDeviceJog_CheckedChanged);
            // 
            // customLabel10
            // 
            this.customLabel10.AutoSize = true;
            this.customLabel10.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.customLabel10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.customLabel10.Location = new System.Drawing.Point(20, 203);
            this.customLabel10.Name = "customLabel10";
            this.customLabel10.Size = new System.Drawing.Size(61, 23);
            this.customLabel10.TabIndex = 24;
            this.customLabel10.Text = "模式：";
            // 
            // customLabel9
            // 
            this.customLabel9.AutoSize = true;
            this.customLabel9.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.customLabel9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.customLabel9.Location = new System.Drawing.Point(205, 238);
            this.customLabel9.Name = "customLabel9";
            this.customLabel9.Size = new System.Drawing.Size(25, 23);
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
            this.CTextBoxRobotMoveSpeed.Location = new System.Drawing.Point(113, 236);
            this.CTextBoxRobotMoveSpeed.Name = "CTextBoxRobotMoveSpeed";
            this.CTextBoxRobotMoveSpeed.Size = new System.Drawing.Size(90, 29);
            this.CTextBoxRobotMoveSpeed.TabIndex = 22;
            this.CTextBoxRobotMoveSpeed.Text = "30";
            this.CTextBoxRobotMoveSpeed.TextChanged += new System.EventHandler(this.CTextBoxRobotMoveSpeed_TextChanged);
            // 
            // customLabel8
            // 
            this.customLabel8.AutoSize = true;
            this.customLabel8.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.customLabel8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.customLabel8.Location = new System.Drawing.Point(20, 238);
            this.customLabel8.Name = "customLabel8";
            this.customLabel8.Size = new System.Drawing.Size(95, 23);
            this.customLabel8.TabIndex = 21;
            this.customLabel8.Text = "移动速度：";
            // 
            // customLabel7
            // 
            this.customLabel7.AutoSize = true;
            this.customLabel7.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.customLabel7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.customLabel7.Location = new System.Drawing.Point(205, 308);
            this.customLabel7.Name = "customLabel7";
            this.customLabel7.Size = new System.Drawing.Size(36, 23);
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
            this.CTextBoxJogDistanceUm.Location = new System.Drawing.Point(113, 306);
            this.CTextBoxJogDistanceUm.Name = "CTextBoxJogDistanceUm";
            this.CTextBoxJogDistanceUm.Size = new System.Drawing.Size(90, 29);
            this.CTextBoxJogDistanceUm.TabIndex = 19;
            this.CTextBoxJogDistanceUm.Text = "1000";
            this.CTextBoxJogDistanceUm.TextChanged += new System.EventHandler(this.CTextBoxJogDistanceUm_TextChanged);
            // 
            // customLabel6
            // 
            this.customLabel6.AutoSize = true;
            this.customLabel6.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.customLabel6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.customLabel6.Location = new System.Drawing.Point(205, 274);
            this.customLabel6.Name = "customLabel6";
            this.customLabel6.Size = new System.Drawing.Size(43, 23);
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
            this.CTextBoxJogDistance.Location = new System.Drawing.Point(113, 271);
            this.CTextBoxJogDistance.Name = "CTextBoxJogDistance";
            this.CTextBoxJogDistance.Size = new System.Drawing.Size(90, 29);
            this.CTextBoxJogDistance.TabIndex = 17;
            this.CTextBoxJogDistance.Text = "1000";
            this.CTextBoxJogDistance.TextChanged += new System.EventHandler(this.CTextBoxJogDistance_TextChanged);
            // 
            // customLabel5
            // 
            this.customLabel5.AutoSize = true;
            this.customLabel5.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.customLabel5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.customLabel5.Location = new System.Drawing.Point(20, 273);
            this.customLabel5.Name = "customLabel5";
            this.customLabel5.Size = new System.Drawing.Size(95, 23);
            this.customLabel5.TabIndex = 16;
            this.customLabel5.Text = "Jog 距离：";
            // 
            // pictureBoxRobotMove
            // 
            this.pictureBoxRobotMove.Image = global::RobotWorkstation.Properties.Resources.SmallDarkGreen;
            this.pictureBoxRobotMove.Location = new System.Drawing.Point(86, 169);
            this.pictureBoxRobotMove.Name = "pictureBoxRobotMove";
            this.pictureBoxRobotMove.Size = new System.Drawing.Size(22, 22);
            this.pictureBoxRobotMove.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxRobotMove.TabIndex = 15;
            this.pictureBoxRobotMove.TabStop = false;
            // 
            // customLabel4
            // 
            this.customLabel4.AutoSize = true;
            this.customLabel4.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.customLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.customLabel4.Location = new System.Drawing.Point(20, 168);
            this.customLabel4.Name = "customLabel4";
            this.customLabel4.Size = new System.Drawing.Size(61, 23);
            this.customLabel4.TabIndex = 14;
            this.customLabel4.Text = "移动：";
            // 
            // pictureBoxTemperature
            // 
            this.pictureBoxTemperature.Image = global::RobotWorkstation.Properties.Resources.SmallDarkGreen;
            this.pictureBoxTemperature.Location = new System.Drawing.Point(86, 137);
            this.pictureBoxTemperature.Name = "pictureBoxTemperature";
            this.pictureBoxTemperature.Size = new System.Drawing.Size(22, 22);
            this.pictureBoxTemperature.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxTemperature.TabIndex = 13;
            this.pictureBoxTemperature.TabStop = false;
            // 
            // customLabel3
            // 
            this.customLabel3.AutoSize = true;
            this.customLabel3.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.customLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.customLabel3.Location = new System.Drawing.Point(20, 135);
            this.customLabel3.Name = "customLabel3";
            this.customLabel3.Size = new System.Drawing.Size(61, 23);
            this.customLabel3.TabIndex = 12;
            this.customLabel3.Text = "温度：";
            // 
            // CButtonRobotExecStop
            // 
            this.CButtonRobotExecStop.BackColor = System.Drawing.Color.Red;
            this.CButtonRobotExecStop.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CButtonRobotExecStop.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.CButtonRobotExecStop.ForeColor = System.Drawing.Color.Transparent;
            this.CButtonRobotExecStop.Location = new System.Drawing.Point(258, 103);
            this.CButtonRobotExecStop.Name = "CButtonRobotExecStop";
            this.CButtonRobotExecStop.Size = new System.Drawing.Size(60, 30);
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
            this.CButtonRobotExecPause.Location = new System.Drawing.Point(192, 103);
            this.CButtonRobotExecPause.Name = "CButtonRobotExecPause";
            this.CButtonRobotExecPause.Size = new System.Drawing.Size(60, 30);
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
            this.CButtonRobotExecRun.Location = new System.Drawing.Point(128, 103);
            this.CButtonRobotExecRun.Name = "CButtonRobotExecRun";
            this.CButtonRobotExecRun.Size = new System.Drawing.Size(60, 30);
            this.CButtonRobotExecRun.TabIndex = 9;
            this.CButtonRobotExecRun.Text = "运行";
            this.CButtonRobotExecRun.UseVisualStyleBackColor = false;
            this.CButtonRobotExecRun.Click += new System.EventHandler(this.CButtonRobotExecRun_Click);
            // 
            // pictureBoxRobotExecut
            // 
            this.pictureBoxRobotExecut.Image = global::RobotWorkstation.Properties.Resources.SmallDarkGreen;
            this.pictureBoxRobotExecut.Location = new System.Drawing.Point(86, 105);
            this.pictureBoxRobotExecut.Name = "pictureBoxRobotExecut";
            this.pictureBoxRobotExecut.Size = new System.Drawing.Size(22, 22);
            this.pictureBoxRobotExecut.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxRobotExecut.TabIndex = 8;
            this.pictureBoxRobotExecut.TabStop = false;
            // 
            // customLabel2
            // 
            this.customLabel2.AutoSize = true;
            this.customLabel2.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.customLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.customLabel2.Location = new System.Drawing.Point(20, 103);
            this.customLabel2.Name = "customLabel2";
            this.customLabel2.Size = new System.Drawing.Size(61, 23);
            this.customLabel2.TabIndex = 7;
            this.customLabel2.Text = "脚本：";
            // 
            // CButtonReset
            // 
            this.CButtonReset.BackColor = System.Drawing.Color.SteelBlue;
            this.CButtonReset.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CButtonReset.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.CButtonReset.ForeColor = System.Drawing.Color.Transparent;
            this.CButtonReset.Location = new System.Drawing.Point(128, 69);
            this.CButtonReset.Name = "CButtonReset";
            this.CButtonReset.Size = new System.Drawing.Size(90, 30);
            this.CButtonReset.TabIndex = 6;
            this.CButtonReset.Text = "复位";
            this.CButtonReset.UseVisualStyleBackColor = false;
            this.CButtonReset.Click += new System.EventHandler(this.CButtonReset_Click);
            // 
            // pictureBoxRobotAlarm
            // 
            this.pictureBoxRobotAlarm.Image = global::RobotWorkstation.Properties.Resources.SmallDarkRed;
            this.pictureBoxRobotAlarm.Location = new System.Drawing.Point(86, 73);
            this.pictureBoxRobotAlarm.Name = "pictureBoxRobotAlarm";
            this.pictureBoxRobotAlarm.Size = new System.Drawing.Size(22, 22);
            this.pictureBoxRobotAlarm.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxRobotAlarm.TabIndex = 5;
            this.pictureBoxRobotAlarm.TabStop = false;
            // 
            // customLabel1
            // 
            this.customLabel1.AutoSize = true;
            this.customLabel1.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.customLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.customLabel1.Location = new System.Drawing.Point(20, 70);
            this.customLabel1.Name = "customLabel1";
            this.customLabel1.Size = new System.Drawing.Size(61, 23);
            this.customLabel1.TabIndex = 4;
            this.customLabel1.Text = "警告：";
            // 
            // CButtonServoOff
            // 
            this.CButtonServoOff.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.CButtonServoOff.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CButtonServoOff.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.CButtonServoOff.ForeColor = System.Drawing.Color.Transparent;
            this.CButtonServoOff.Location = new System.Drawing.Point(228, 36);
            this.CButtonServoOff.Name = "CButtonServoOff";
            this.CButtonServoOff.Size = new System.Drawing.Size(90, 30);
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
            this.CBttonServoOn.ForeColor = System.Drawing.Color.Transparent;
            this.CBttonServoOn.Location = new System.Drawing.Point(128, 35);
            this.CBttonServoOn.Name = "CBttonServoOn";
            this.CBttonServoOn.Size = new System.Drawing.Size(90, 30);
            this.CBttonServoOn.TabIndex = 2;
            this.CBttonServoOn.Text = "伺服开";
            this.CBttonServoOn.UseVisualStyleBackColor = false;
            this.CBttonServoOn.Click += new System.EventHandler(this.CBttonServoOn_Click);
            // 
            // pictureBoxServo
            // 
            this.pictureBoxServo.Image = global::RobotWorkstation.Properties.Resources.SmallDarkGreen;
            this.pictureBoxServo.Location = new System.Drawing.Point(86, 41);
            this.pictureBoxServo.Name = "pictureBoxServo";
            this.pictureBoxServo.Size = new System.Drawing.Size(22, 22);
            this.pictureBoxServo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxServo.TabIndex = 1;
            this.pictureBoxServo.TabStop = false;
            // 
            // tabPageThreeAxisRobot
            // 
            this.tabPageThreeAxisRobot.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.tabPageThreeAxisRobot.Controls.Add(this.customGroupBox6);
            this.tabPageThreeAxisRobot.Controls.Add(this.customGroupBox5);
            this.tabPageThreeAxisRobot.Controls.Add(this.customGroupBox4);
            this.tabPageThreeAxisRobot.Controls.Add(this.customGroupBox3);
            this.tabPageThreeAxisRobot.Controls.Add(this.customGroupBox2);
            this.tabPageThreeAxisRobot.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.tabPageThreeAxisRobot.Location = new System.Drawing.Point(0, 29);
            this.tabPageThreeAxisRobot.Name = "tabPageThreeAxisRobot";
            this.tabPageThreeAxisRobot.Size = new System.Drawing.Size(1360, 761);
            this.tabPageThreeAxisRobot.TabIndex = 2;
            this.tabPageThreeAxisRobot.Text = "三轴机械臂";
            // 
            // customGroupBox6
            // 
            this.customGroupBox6.Controls.Add(this.CButtonMotionAxisStop);
            this.customGroupBox6.Controls.Add(this.CButtonMotionAxisHome);
            this.customGroupBox6.Controls.Add(this.CButtonMotionAxisRunPos);
            this.customGroupBox6.Controls.Add(this.CButtonMotionAxisRunNeg);
            this.customGroupBox6.Controls.Add(this.customLabel44);
            this.customGroupBox6.Controls.Add(this.ComBoxMotionHomeMode);
            this.customGroupBox6.Controls.Add(this.customLabel43);
            this.customGroupBox6.Controls.Add(this.ComBoxMotionControlAxis);
            this.customGroupBox6.Controls.Add(this.customLabel41);
            this.customGroupBox6.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.customGroupBox6.Location = new System.Drawing.Point(10, 432);
            this.customGroupBox6.Name = "customGroupBox6";
            this.customGroupBox6.Size = new System.Drawing.Size(426, 216);
            this.customGroupBox6.TabIndex = 4;
            this.customGroupBox6.TabStop = false;
            this.customGroupBox6.Text = "轴运动";
            // 
            // CButtonMotionAxisStop
            // 
            this.CButtonMotionAxisStop.BackColor = System.Drawing.Color.Red;
            this.CButtonMotionAxisStop.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CButtonMotionAxisStop.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.CButtonMotionAxisStop.ForeColor = System.Drawing.Color.Transparent;
            this.CButtonMotionAxisStop.Location = new System.Drawing.Point(318, 159);
            this.CButtonMotionAxisStop.Name = "CButtonMotionAxisStop";
            this.CButtonMotionAxisStop.Size = new System.Drawing.Size(90, 30);
            this.CButtonMotionAxisStop.TabIndex = 10;
            this.CButtonMotionAxisStop.Text = "停止";
            this.CButtonMotionAxisStop.UseVisualStyleBackColor = false;
            this.CButtonMotionAxisStop.Click += new System.EventHandler(this.CButtonMotionAxisStop_Click);
            // 
            // CButtonMotionAxisHome
            // 
            this.CButtonMotionAxisHome.BackColor = System.Drawing.Color.Green;
            this.CButtonMotionAxisHome.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CButtonMotionAxisHome.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.CButtonMotionAxisHome.ForeColor = System.Drawing.Color.White;
            this.CButtonMotionAxisHome.Location = new System.Drawing.Point(126, 159);
            this.CButtonMotionAxisHome.Name = "CButtonMotionAxisHome";
            this.CButtonMotionAxisHome.Size = new System.Drawing.Size(90, 30);
            this.CButtonMotionAxisHome.TabIndex = 9;
            this.CButtonMotionAxisHome.Text = "回原点";
            this.CButtonMotionAxisHome.UseVisualStyleBackColor = false;
            this.CButtonMotionAxisHome.Click += new System.EventHandler(this.CButtonMotionAxisHome_Click);
            // 
            // CButtonMotionAxisRunPos
            // 
            this.CButtonMotionAxisRunPos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.CButtonMotionAxisRunPos.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CButtonMotionAxisRunPos.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.CButtonMotionAxisRunPos.ForeColor = System.Drawing.Color.Transparent;
            this.CButtonMotionAxisRunPos.Location = new System.Drawing.Point(318, 118);
            this.CButtonMotionAxisRunPos.Name = "CButtonMotionAxisRunPos";
            this.CButtonMotionAxisRunPos.Size = new System.Drawing.Size(90, 30);
            this.CButtonMotionAxisRunPos.TabIndex = 8;
            this.CButtonMotionAxisRunPos.Text = ">>>";
            this.CButtonMotionAxisRunPos.UseVisualStyleBackColor = false;
            this.CButtonMotionAxisRunPos.Click += new System.EventHandler(this.CButtonMotionAxisRunPos_Click);
            // 
            // CButtonMotionAxisRunNeg
            // 
            this.CButtonMotionAxisRunNeg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.CButtonMotionAxisRunNeg.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CButtonMotionAxisRunNeg.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.CButtonMotionAxisRunNeg.ForeColor = System.Drawing.Color.Transparent;
            this.CButtonMotionAxisRunNeg.Location = new System.Drawing.Point(126, 118);
            this.CButtonMotionAxisRunNeg.Name = "CButtonMotionAxisRunNeg";
            this.CButtonMotionAxisRunNeg.Size = new System.Drawing.Size(90, 30);
            this.CButtonMotionAxisRunNeg.TabIndex = 7;
            this.CButtonMotionAxisRunNeg.Text = "<<<";
            this.CButtonMotionAxisRunNeg.UseVisualStyleBackColor = false;
            this.CButtonMotionAxisRunNeg.Click += new System.EventHandler(this.CButtonMotionAxisRunNeg_Click);
            // 
            // customLabel44
            // 
            this.customLabel44.AutoSize = true;
            this.customLabel44.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.customLabel44.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.customLabel44.Location = new System.Drawing.Point(18, 122);
            this.customLabel44.Name = "customLabel44";
            this.customLabel44.Size = new System.Drawing.Size(95, 23);
            this.customLabel44.TabIndex = 6;
            this.customLabel44.Text = "运动控制：";
            // 
            // ComBoxMotionHomeMode
            // 
            this.ComBoxMotionHomeMode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.ComBoxMotionHomeMode.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ComBoxMotionHomeMode.ForeColor = System.Drawing.Color.White;
            this.ComBoxMotionHomeMode.FormattingEnabled = true;
            this.ComBoxMotionHomeMode.Items.AddRange(new object[] {
            "MODE1_Abs",
            "MODE2_Lmt",
            "MODE3_Ref",
            "MODE4_Abs_Ref",
            "MODE5_Abs_NegRef",
            "MODE6_Lmt_Ref",
            "MODE7_AbsSearch",
            "MODE8_LmtSearch",
            "MODE9_AbsSearch_Ref",
            "MODE10_AbsSearch_NegRef",
            "MODE11_LmtSearch_Ref",
            "MODE12_AbsSearchReFind",
            "MODE13_LmtSearchReFind",
            "MODE14_AbsSearchReFind_Ref",
            "MODE15_AbsSearchReFind_NegRef",
            "MODE16_LmtSearchReFind_Ref"});
            this.ComBoxMotionHomeMode.Location = new System.Drawing.Point(127, 76);
            this.ComBoxMotionHomeMode.Name = "ComBoxMotionHomeMode";
            this.ComBoxMotionHomeMode.Size = new System.Drawing.Size(279, 29);
            this.ComBoxMotionHomeMode.TabIndex = 5;
            // 
            // customLabel43
            // 
            this.customLabel43.AutoSize = true;
            this.customLabel43.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.customLabel43.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.customLabel43.Location = new System.Drawing.Point(18, 78);
            this.customLabel43.Name = "customLabel43";
            this.customLabel43.Size = new System.Drawing.Size(82, 23);
            this.customLabel43.TabIndex = 4;
            this.customLabel43.Text = "Home ：";
            // 
            // ComBoxMotionControlAxis
            // 
            this.ComBoxMotionControlAxis.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.ComBoxMotionControlAxis.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ComBoxMotionControlAxis.ForeColor = System.Drawing.Color.White;
            this.ComBoxMotionControlAxis.FormattingEnabled = true;
            this.ComBoxMotionControlAxis.Location = new System.Drawing.Point(127, 35);
            this.ComBoxMotionControlAxis.Name = "ComBoxMotionControlAxis";
            this.ComBoxMotionControlAxis.Size = new System.Drawing.Size(279, 29);
            this.ComBoxMotionControlAxis.TabIndex = 1;
            // 
            // customLabel41
            // 
            this.customLabel41.AutoSize = true;
            this.customLabel41.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.customLabel41.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.customLabel41.Location = new System.Drawing.Point(18, 37);
            this.customLabel41.Name = "customLabel41";
            this.customLabel41.Size = new System.Drawing.Size(95, 23);
            this.customLabel41.TabIndex = 0;
            this.customLabel41.Text = "选择轴号：";
            // 
            // customGroupBox5
            // 
            this.customGroupBox5.Controls.Add(this.CTextBoxMotionControlZDistance);
            this.customGroupBox5.Controls.Add(this.CTextBoxMotionControlYDistance);
            this.customGroupBox5.Controls.Add(this.customLabel40);
            this.customGroupBox5.Controls.Add(this.customLabel39);
            this.customGroupBox5.Controls.Add(this.CTextBoxMotionControlXDistance);
            this.customGroupBox5.Controls.Add(this.customLabel38);
            this.customGroupBox5.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.customGroupBox5.Location = new System.Drawing.Point(453, 247);
            this.customGroupBox5.Name = "customGroupBox5";
            this.customGroupBox5.Size = new System.Drawing.Size(384, 179);
            this.customGroupBox5.TabIndex = 3;
            this.customGroupBox5.TabStop = false;
            this.customGroupBox5.Text = "当前信息";
            // 
            // CTextBoxMotionControlZDistance
            // 
            this.CTextBoxMotionControlZDistance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.CTextBoxMotionControlZDistance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CTextBoxMotionControlZDistance.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.CTextBoxMotionControlZDistance.ForeColor = System.Drawing.Color.White;
            this.CTextBoxMotionControlZDistance.Location = new System.Drawing.Point(159, 119);
            this.CTextBoxMotionControlZDistance.Name = "CTextBoxMotionControlZDistance";
            this.CTextBoxMotionControlZDistance.Size = new System.Drawing.Size(90, 29);
            this.CTextBoxMotionControlZDistance.TabIndex = 5;
            this.CTextBoxMotionControlZDistance.Text = "1000";
            // 
            // CTextBoxMotionControlYDistance
            // 
            this.CTextBoxMotionControlYDistance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.CTextBoxMotionControlYDistance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CTextBoxMotionControlYDistance.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.CTextBoxMotionControlYDistance.ForeColor = System.Drawing.Color.White;
            this.CTextBoxMotionControlYDistance.Location = new System.Drawing.Point(159, 77);
            this.CTextBoxMotionControlYDistance.Name = "CTextBoxMotionControlYDistance";
            this.CTextBoxMotionControlYDistance.Size = new System.Drawing.Size(90, 29);
            this.CTextBoxMotionControlYDistance.TabIndex = 4;
            this.CTextBoxMotionControlYDistance.Text = "1000";
            // 
            // customLabel40
            // 
            this.customLabel40.AutoSize = true;
            this.customLabel40.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.customLabel40.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.customLabel40.Location = new System.Drawing.Point(37, 121);
            this.customLabel40.Name = "customLabel40";
            this.customLabel40.Size = new System.Drawing.Size(94, 23);
            this.customLabel40.TabIndex = 3;
            this.customLabel40.Text = "Z 轴距离：";
            // 
            // customLabel39
            // 
            this.customLabel39.AutoSize = true;
            this.customLabel39.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.customLabel39.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.customLabel39.Location = new System.Drawing.Point(37, 79);
            this.customLabel39.Name = "customLabel39";
            this.customLabel39.Size = new System.Drawing.Size(93, 23);
            this.customLabel39.TabIndex = 2;
            this.customLabel39.Text = "Y 轴距离：";
            // 
            // CTextBoxMotionControlXDistance
            // 
            this.CTextBoxMotionControlXDistance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.CTextBoxMotionControlXDistance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CTextBoxMotionControlXDistance.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.CTextBoxMotionControlXDistance.ForeColor = System.Drawing.Color.White;
            this.CTextBoxMotionControlXDistance.Location = new System.Drawing.Point(159, 35);
            this.CTextBoxMotionControlXDistance.Name = "CTextBoxMotionControlXDistance";
            this.CTextBoxMotionControlXDistance.Size = new System.Drawing.Size(90, 29);
            this.CTextBoxMotionControlXDistance.TabIndex = 1;
            this.CTextBoxMotionControlXDistance.Text = "1000";
            // 
            // customLabel38
            // 
            this.customLabel38.AutoSize = true;
            this.customLabel38.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.customLabel38.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.customLabel38.Location = new System.Drawing.Point(37, 37);
            this.customLabel38.Name = "customLabel38";
            this.customLabel38.Size = new System.Drawing.Size(94, 23);
            this.customLabel38.TabIndex = 0;
            this.customLabel38.Text = "X 轴距离：";
            // 
            // customGroupBox4
            // 
            this.customGroupBox4.Controls.Add(this.CTextBoxMotionControlDistance);
            this.customGroupBox4.Controls.Add(this.customLabel20);
            this.customGroupBox4.Controls.Add(this.CButtonSetMotionControlSpeedParam);
            this.customGroupBox4.Controls.Add(this.CTextBoxMotionControDecSpeed);
            this.customGroupBox4.Controls.Add(this.CTextBoxMotionControAccSpeed);
            this.customGroupBox4.Controls.Add(this.customLabel37);
            this.customGroupBox4.Controls.Add(this.customLabel36);
            this.customGroupBox4.Controls.Add(this.CTextBoxMotionControHighSpeed);
            this.customGroupBox4.Controls.Add(this.customLabel35);
            this.customGroupBox4.Controls.Add(this.CTextBoxMotionControLowSpeed);
            this.customGroupBox4.Controls.Add(this.customLabel34);
            this.customGroupBox4.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.customGroupBox4.Location = new System.Drawing.Point(10, 247);
            this.customGroupBox4.Name = "customGroupBox4";
            this.customGroupBox4.Size = new System.Drawing.Size(426, 179);
            this.customGroupBox4.TabIndex = 2;
            this.customGroupBox4.TabStop = false;
            this.customGroupBox4.Text = "参数设置";
            // 
            // CTextBoxMotionControlDistance
            // 
            this.CTextBoxMotionControlDistance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.CTextBoxMotionControlDistance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CTextBoxMotionControlDistance.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.CTextBoxMotionControlDistance.ForeColor = System.Drawing.Color.White;
            this.CTextBoxMotionControlDistance.Location = new System.Drawing.Point(118, 120);
            this.CTextBoxMotionControlDistance.Name = "CTextBoxMotionControlDistance";
            this.CTextBoxMotionControlDistance.Size = new System.Drawing.Size(90, 29);
            this.CTextBoxMotionControlDistance.TabIndex = 10;
            this.CTextBoxMotionControlDistance.Text = "1000";
            // 
            // customLabel20
            // 
            this.customLabel20.AutoSize = true;
            this.customLabel20.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.customLabel20.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.customLabel20.Location = new System.Drawing.Point(18, 122);
            this.customLabel20.Name = "customLabel20";
            this.customLabel20.Size = new System.Drawing.Size(95, 23);
            this.customLabel20.TabIndex = 9;
            this.customLabel20.Text = "运行距离：";
            // 
            // CButtonSetMotionControlSpeedParam
            // 
            this.CButtonSetMotionControlSpeedParam.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.CButtonSetMotionControlSpeedParam.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CButtonSetMotionControlSpeedParam.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.CButtonSetMotionControlSpeedParam.ForeColor = System.Drawing.Color.Transparent;
            this.CButtonSetMotionControlSpeedParam.Location = new System.Drawing.Point(316, 119);
            this.CButtonSetMotionControlSpeedParam.Name = "CButtonSetMotionControlSpeedParam";
            this.CButtonSetMotionControlSpeedParam.Size = new System.Drawing.Size(90, 30);
            this.CButtonSetMotionControlSpeedParam.TabIndex = 8;
            this.CButtonSetMotionControlSpeedParam.Text = "设置";
            this.CButtonSetMotionControlSpeedParam.UseVisualStyleBackColor = false;
            this.CButtonSetMotionControlSpeedParam.Click += new System.EventHandler(this.CButtonSetMotionControlSpeedParam_Click);
            // 
            // CTextBoxMotionControDecSpeed
            // 
            this.CTextBoxMotionControDecSpeed.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.CTextBoxMotionControDecSpeed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CTextBoxMotionControDecSpeed.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.CTextBoxMotionControDecSpeed.ForeColor = System.Drawing.Color.White;
            this.CTextBoxMotionControDecSpeed.Location = new System.Drawing.Point(316, 79);
            this.CTextBoxMotionControDecSpeed.Name = "CTextBoxMotionControDecSpeed";
            this.CTextBoxMotionControDecSpeed.Size = new System.Drawing.Size(90, 29);
            this.CTextBoxMotionControDecSpeed.TabIndex = 7;
            this.CTextBoxMotionControDecSpeed.Text = "10000";
            // 
            // CTextBoxMotionControAccSpeed
            // 
            this.CTextBoxMotionControAccSpeed.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.CTextBoxMotionControAccSpeed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CTextBoxMotionControAccSpeed.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.CTextBoxMotionControAccSpeed.ForeColor = System.Drawing.Color.White;
            this.CTextBoxMotionControAccSpeed.Location = new System.Drawing.Point(316, 38);
            this.CTextBoxMotionControAccSpeed.Name = "CTextBoxMotionControAccSpeed";
            this.CTextBoxMotionControAccSpeed.Size = new System.Drawing.Size(90, 29);
            this.CTextBoxMotionControAccSpeed.TabIndex = 6;
            this.CTextBoxMotionControAccSpeed.Text = "10000";
            // 
            // customLabel37
            // 
            this.customLabel37.AutoSize = true;
            this.customLabel37.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.customLabel37.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.customLabel37.Location = new System.Drawing.Point(235, 81);
            this.customLabel37.Name = "customLabel37";
            this.customLabel37.Size = new System.Drawing.Size(78, 23);
            this.customLabel37.TabIndex = 5;
            this.customLabel37.Text = "减速度：";
            // 
            // customLabel36
            // 
            this.customLabel36.AutoSize = true;
            this.customLabel36.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.customLabel36.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.customLabel36.Location = new System.Drawing.Point(235, 42);
            this.customLabel36.Name = "customLabel36";
            this.customLabel36.Size = new System.Drawing.Size(78, 23);
            this.customLabel36.TabIndex = 4;
            this.customLabel36.Text = "加速度：";
            // 
            // CTextBoxMotionControHighSpeed
            // 
            this.CTextBoxMotionControHighSpeed.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.CTextBoxMotionControHighSpeed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CTextBoxMotionControHighSpeed.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.CTextBoxMotionControHighSpeed.ForeColor = System.Drawing.Color.White;
            this.CTextBoxMotionControHighSpeed.Location = new System.Drawing.Point(118, 79);
            this.CTextBoxMotionControHighSpeed.Name = "CTextBoxMotionControHighSpeed";
            this.CTextBoxMotionControHighSpeed.Size = new System.Drawing.Size(90, 29);
            this.CTextBoxMotionControHighSpeed.TabIndex = 3;
            this.CTextBoxMotionControHighSpeed.Text = "8000";
            // 
            // customLabel35
            // 
            this.customLabel35.AutoSize = true;
            this.customLabel35.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.customLabel35.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.customLabel35.Location = new System.Drawing.Point(18, 81);
            this.customLabel35.Name = "customLabel35";
            this.customLabel35.Size = new System.Drawing.Size(95, 23);
            this.customLabel35.TabIndex = 2;
            this.customLabel35.Text = "运行速度：";
            // 
            // CTextBoxMotionControLowSpeed
            // 
            this.CTextBoxMotionControLowSpeed.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.CTextBoxMotionControLowSpeed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CTextBoxMotionControLowSpeed.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.CTextBoxMotionControLowSpeed.ForeColor = System.Drawing.Color.White;
            this.CTextBoxMotionControLowSpeed.Location = new System.Drawing.Point(118, 38);
            this.CTextBoxMotionControLowSpeed.Name = "CTextBoxMotionControLowSpeed";
            this.CTextBoxMotionControLowSpeed.Size = new System.Drawing.Size(90, 29);
            this.CTextBoxMotionControLowSpeed.TabIndex = 1;
            this.CTextBoxMotionControLowSpeed.Text = "2000";
            // 
            // customLabel34
            // 
            this.customLabel34.AutoSize = true;
            this.customLabel34.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.customLabel34.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.customLabel34.Location = new System.Drawing.Point(18, 42);
            this.customLabel34.Name = "customLabel34";
            this.customLabel34.Size = new System.Drawing.Size(95, 23);
            this.customLabel34.TabIndex = 0;
            this.customLabel34.Text = "初始速度：";
            // 
            // customGroupBox3
            // 
            this.customGroupBox3.Controls.Add(this.CButtonMotionControlGrasp);
            this.customGroupBox3.Controls.Add(this.CButtonMotionControlRight);
            this.customGroupBox3.Controls.Add(this.CButtonMotionControlLift);
            this.customGroupBox3.Controls.Add(this.CButtonMotionControlDown);
            this.customGroupBox3.Controls.Add(this.CButtonMotionControlUp);
            this.customGroupBox3.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.customGroupBox3.Location = new System.Drawing.Point(453, 10);
            this.customGroupBox3.Name = "customGroupBox3";
            this.customGroupBox3.Size = new System.Drawing.Size(384, 231);
            this.customGroupBox3.TabIndex = 1;
            this.customGroupBox3.TabStop = false;
            this.customGroupBox3.Text = "手动控制";
            // 
            // CButtonMotionControlGrasp
            // 
            this.CButtonMotionControlGrasp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.CButtonMotionControlGrasp.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CButtonMotionControlGrasp.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.CButtonMotionControlGrasp.ForeColor = System.Drawing.Color.Transparent;
            this.CButtonMotionControlGrasp.Location = new System.Drawing.Point(142, 101);
            this.CButtonMotionControlGrasp.Name = "CButtonMotionControlGrasp";
            this.CButtonMotionControlGrasp.Size = new System.Drawing.Size(90, 30);
            this.CButtonMotionControlGrasp.TabIndex = 5;
            this.CButtonMotionControlGrasp.Text = "抓取";
            this.CButtonMotionControlGrasp.UseVisualStyleBackColor = false;
            this.CButtonMotionControlGrasp.Click += new System.EventHandler(this.CButtonMotionControlGrasp_Click);
            // 
            // CButtonMotionControlRight
            // 
            this.CButtonMotionControlRight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.CButtonMotionControlRight.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CButtonMotionControlRight.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.CButtonMotionControlRight.ForeColor = System.Drawing.Color.Transparent;
            this.CButtonMotionControlRight.Location = new System.Drawing.Point(242, 101);
            this.CButtonMotionControlRight.Name = "CButtonMotionControlRight";
            this.CButtonMotionControlRight.Size = new System.Drawing.Size(90, 30);
            this.CButtonMotionControlRight.TabIndex = 4;
            this.CButtonMotionControlRight.Text = "右移";
            this.CButtonMotionControlRight.UseVisualStyleBackColor = false;
            this.CButtonMotionControlRight.Click += new System.EventHandler(this.CButtonMotionControlRight_Click);
            // 
            // CButtonMotionControlLift
            // 
            this.CButtonMotionControlLift.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.CButtonMotionControlLift.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CButtonMotionControlLift.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.CButtonMotionControlLift.ForeColor = System.Drawing.Color.Transparent;
            this.CButtonMotionControlLift.Location = new System.Drawing.Point(41, 101);
            this.CButtonMotionControlLift.Name = "CButtonMotionControlLift";
            this.CButtonMotionControlLift.Size = new System.Drawing.Size(90, 30);
            this.CButtonMotionControlLift.TabIndex = 3;
            this.CButtonMotionControlLift.Text = "左移";
            this.CButtonMotionControlLift.UseVisualStyleBackColor = false;
            this.CButtonMotionControlLift.Click += new System.EventHandler(this.CButtonMotionControlLift_Click);
            // 
            // CButtonMotionControlDown
            // 
            this.CButtonMotionControlDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.CButtonMotionControlDown.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CButtonMotionControlDown.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.CButtonMotionControlDown.ForeColor = System.Drawing.Color.Transparent;
            this.CButtonMotionControlDown.Location = new System.Drawing.Point(142, 161);
            this.CButtonMotionControlDown.Name = "CButtonMotionControlDown";
            this.CButtonMotionControlDown.Size = new System.Drawing.Size(90, 30);
            this.CButtonMotionControlDown.TabIndex = 2;
            this.CButtonMotionControlDown.Text = "下移";
            this.CButtonMotionControlDown.UseVisualStyleBackColor = false;
            this.CButtonMotionControlDown.Click += new System.EventHandler(this.CButtonMotionControlDown_Click);
            // 
            // CButtonMotionControlUp
            // 
            this.CButtonMotionControlUp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.CButtonMotionControlUp.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CButtonMotionControlUp.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.CButtonMotionControlUp.ForeColor = System.Drawing.Color.Transparent;
            this.CButtonMotionControlUp.Location = new System.Drawing.Point(142, 42);
            this.CButtonMotionControlUp.Name = "CButtonMotionControlUp";
            this.CButtonMotionControlUp.Size = new System.Drawing.Size(90, 30);
            this.CButtonMotionControlUp.TabIndex = 1;
            this.CButtonMotionControlUp.Text = "上移";
            this.CButtonMotionControlUp.UseVisualStyleBackColor = false;
            this.CButtonMotionControlUp.Click += new System.EventHandler(this.CButtonMotionControlUp_Click);
            // 
            // customGroupBox2
            // 
            this.customGroupBox2.Controls.Add(this.picBoxMotionControlIoNegLmit);
            this.customGroupBox2.Controls.Add(this.customLabel33);
            this.customGroupBox2.Controls.Add(this.picBoxMotionControlIoPosLmit);
            this.customGroupBox2.Controls.Add(this.customLabel32);
            this.customGroupBox2.Controls.Add(this.picBoxMotionControlIoORG);
            this.customGroupBox2.Controls.Add(this.customLabel31);
            this.customGroupBox2.Controls.Add(this.picBoxMotionControlIoEZ);
            this.customGroupBox2.Controls.Add(this.customLabel30);
            this.customGroupBox2.Controls.Add(this.customLabel29);
            this.customGroupBox2.Controls.Add(this.CButtonMotionControlResetError);
            this.customGroupBox2.Controls.Add(this.CTextBoxMotionControlState);
            this.customGroupBox2.Controls.Add(this.customLabel28);
            this.customGroupBox2.Controls.Add(this.CButtonMotionControlDeviceLoadCfg);
            this.customGroupBox2.Controls.Add(this.CButtonCloseMotionControlDevice);
            this.customGroupBox2.Controls.Add(this.CButtonOpenMotionControlDevice);
            this.customGroupBox2.Controls.Add(this.customLabel27);
            this.customGroupBox2.Controls.Add(this.ComBoxMotionControlDevice);
            this.customGroupBox2.Controls.Add(this.customLabel26);
            this.customGroupBox2.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.customGroupBox2.Location = new System.Drawing.Point(10, 10);
            this.customGroupBox2.Name = "customGroupBox2";
            this.customGroupBox2.Size = new System.Drawing.Size(426, 231);
            this.customGroupBox2.TabIndex = 0;
            this.customGroupBox2.TabStop = false;
            this.customGroupBox2.Text = "运动控制卡";
            // 
            // picBoxMotionControlIoNegLmit
            // 
            this.picBoxMotionControlIoNegLmit.Image = global::RobotWorkstation.Properties.Resources.SmallDarkGreen;
            this.picBoxMotionControlIoNegLmit.InitialImage = global::RobotWorkstation.Properties.Resources.SmallDarkGreen;
            this.picBoxMotionControlIoNegLmit.Location = new System.Drawing.Point(384, 178);
            this.picBoxMotionControlIoNegLmit.Name = "picBoxMotionControlIoNegLmit";
            this.picBoxMotionControlIoNegLmit.Size = new System.Drawing.Size(22, 22);
            this.picBoxMotionControlIoNegLmit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBoxMotionControlIoNegLmit.TabIndex = 17;
            this.picBoxMotionControlIoNegLmit.TabStop = false;
            // 
            // customLabel33
            // 
            this.customLabel33.AutoSize = true;
            this.customLabel33.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.customLabel33.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.customLabel33.Location = new System.Drawing.Point(334, 179);
            this.customLabel33.Name = "customLabel33";
            this.customLabel33.Size = new System.Drawing.Size(53, 23);
            this.customLabel33.TabIndex = 16;
            this.customLabel33.Text = "LMT-";
            // 
            // picBoxMotionControlIoPosLmit
            // 
            this.picBoxMotionControlIoPosLmit.Image = global::RobotWorkstation.Properties.Resources.SmallDarkGreen;
            this.picBoxMotionControlIoPosLmit.InitialImage = global::RobotWorkstation.Properties.Resources.SmallDarkGreen;
            this.picBoxMotionControlIoPosLmit.Location = new System.Drawing.Point(305, 178);
            this.picBoxMotionControlIoPosLmit.Name = "picBoxMotionControlIoPosLmit";
            this.picBoxMotionControlIoPosLmit.Size = new System.Drawing.Size(22, 22);
            this.picBoxMotionControlIoPosLmit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBoxMotionControlIoPosLmit.TabIndex = 15;
            this.picBoxMotionControlIoPosLmit.TabStop = false;
            // 
            // customLabel32
            // 
            this.customLabel32.AutoSize = true;
            this.customLabel32.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.customLabel32.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.customLabel32.Location = new System.Drawing.Point(250, 179);
            this.customLabel32.Name = "customLabel32";
            this.customLabel32.Size = new System.Drawing.Size(59, 23);
            this.customLabel32.TabIndex = 14;
            this.customLabel32.Text = "LMT+";
            // 
            // picBoxMotionControlIoORG
            // 
            this.picBoxMotionControlIoORG.Image = global::RobotWorkstation.Properties.Resources.SmallDarkGreen;
            this.picBoxMotionControlIoORG.InitialImage = global::RobotWorkstation.Properties.Resources.SmallDarkGreen;
            this.picBoxMotionControlIoORG.Location = new System.Drawing.Point(224, 178);
            this.picBoxMotionControlIoORG.Name = "picBoxMotionControlIoORG";
            this.picBoxMotionControlIoORG.Size = new System.Drawing.Size(22, 22);
            this.picBoxMotionControlIoORG.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBoxMotionControlIoORG.TabIndex = 13;
            this.picBoxMotionControlIoORG.TabStop = false;
            // 
            // customLabel31
            // 
            this.customLabel31.AutoSize = true;
            this.customLabel31.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.customLabel31.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.customLabel31.Location = new System.Drawing.Point(175, 177);
            this.customLabel31.Name = "customLabel31";
            this.customLabel31.Size = new System.Drawing.Size(48, 23);
            this.customLabel31.TabIndex = 12;
            this.customLabel31.Text = "ORG";
            // 
            // picBoxMotionControlIoEZ
            // 
            this.picBoxMotionControlIoEZ.Image = global::RobotWorkstation.Properties.Resources.SmallDarkGreen;
            this.picBoxMotionControlIoEZ.InitialImage = global::RobotWorkstation.Properties.Resources.SmallDarkGreen;
            this.picBoxMotionControlIoEZ.Location = new System.Drawing.Point(145, 178);
            this.picBoxMotionControlIoEZ.Name = "picBoxMotionControlIoEZ";
            this.picBoxMotionControlIoEZ.Size = new System.Drawing.Size(22, 22);
            this.picBoxMotionControlIoEZ.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBoxMotionControlIoEZ.TabIndex = 11;
            this.picBoxMotionControlIoEZ.TabStop = false;
            // 
            // customLabel30
            // 
            this.customLabel30.AutoSize = true;
            this.customLabel30.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.customLabel30.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.customLabel30.Location = new System.Drawing.Point(114, 177);
            this.customLabel30.Name = "customLabel30";
            this.customLabel30.Size = new System.Drawing.Size(30, 23);
            this.customLabel30.TabIndex = 10;
            this.customLabel30.Text = "EZ";
            // 
            // customLabel29
            // 
            this.customLabel29.AutoSize = true;
            this.customLabel29.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.customLabel29.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.customLabel29.Location = new System.Drawing.Point(18, 176);
            this.customLabel29.Name = "customLabel29";
            this.customLabel29.Size = new System.Drawing.Size(95, 23);
            this.customLabel29.TabIndex = 9;
            this.customLabel29.Text = "IO   状态：";
            // 
            // CButtonMotionControlResetError
            // 
            this.CButtonMotionControlResetError.BackColor = System.Drawing.Color.SteelBlue;
            this.CButtonMotionControlResetError.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CButtonMotionControlResetError.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.CButtonMotionControlResetError.ForeColor = System.Drawing.Color.Transparent;
            this.CButtonMotionControlResetError.Location = new System.Drawing.Point(316, 131);
            this.CButtonMotionControlResetError.Name = "CButtonMotionControlResetError";
            this.CButtonMotionControlResetError.Size = new System.Drawing.Size(90, 30);
            this.CButtonMotionControlResetError.TabIndex = 8;
            this.CButtonMotionControlResetError.Text = "错误复位";
            this.CButtonMotionControlResetError.UseVisualStyleBackColor = false;
            this.CButtonMotionControlResetError.Click += new System.EventHandler(this.CButtonMotionControlResetError_Click);
            // 
            // CTextBoxMotionControlState
            // 
            this.CTextBoxMotionControlState.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.CTextBoxMotionControlState.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CTextBoxMotionControlState.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.CTextBoxMotionControlState.ForeColor = System.Drawing.Color.White;
            this.CTextBoxMotionControlState.Location = new System.Drawing.Point(118, 131);
            this.CTextBoxMotionControlState.Name = "CTextBoxMotionControlState";
            this.CTextBoxMotionControlState.Size = new System.Drawing.Size(189, 29);
            this.CTextBoxMotionControlState.TabIndex = 7;
            // 
            // customLabel28
            // 
            this.customLabel28.AutoSize = true;
            this.customLabel28.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.customLabel28.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.customLabel28.Location = new System.Drawing.Point(18, 133);
            this.customLabel28.Name = "customLabel28";
            this.customLabel28.Size = new System.Drawing.Size(95, 23);
            this.customLabel28.TabIndex = 6;
            this.customLabel28.Text = "设备状态：";
            // 
            // CButtonMotionControlDeviceLoadCfg
            // 
            this.CButtonMotionControlDeviceLoadCfg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(148)))), ((int)(((byte)(8)))));
            this.CButtonMotionControlDeviceLoadCfg.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CButtonMotionControlDeviceLoadCfg.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.CButtonMotionControlDeviceLoadCfg.ForeColor = System.Drawing.Color.Transparent;
            this.CButtonMotionControlDeviceLoadCfg.Location = new System.Drawing.Point(217, 84);
            this.CButtonMotionControlDeviceLoadCfg.Name = "CButtonMotionControlDeviceLoadCfg";
            this.CButtonMotionControlDeviceLoadCfg.Size = new System.Drawing.Size(90, 30);
            this.CButtonMotionControlDeviceLoadCfg.TabIndex = 5;
            this.CButtonMotionControlDeviceLoadCfg.Text = "导入配置";
            this.CButtonMotionControlDeviceLoadCfg.UseVisualStyleBackColor = false;
            this.CButtonMotionControlDeviceLoadCfg.Click += new System.EventHandler(this.CButtonMotionControlDeviceLoadCfg_Click);
            // 
            // CButtonCloseMotionControlDevice
            // 
            this.CButtonCloseMotionControlDevice.BackColor = System.Drawing.Color.Red;
            this.CButtonCloseMotionControlDevice.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CButtonCloseMotionControlDevice.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.CButtonCloseMotionControlDevice.ForeColor = System.Drawing.Color.Transparent;
            this.CButtonCloseMotionControlDevice.Location = new System.Drawing.Point(316, 84);
            this.CButtonCloseMotionControlDevice.Name = "CButtonCloseMotionControlDevice";
            this.CButtonCloseMotionControlDevice.Size = new System.Drawing.Size(90, 30);
            this.CButtonCloseMotionControlDevice.TabIndex = 4;
            this.CButtonCloseMotionControlDevice.Text = "关闭设备";
            this.CButtonCloseMotionControlDevice.UseVisualStyleBackColor = false;
            this.CButtonCloseMotionControlDevice.Click += new System.EventHandler(this.CButtonCloseMotionControlDevice_Click);
            // 
            // CButtonOpenMotionControlDevice
            // 
            this.CButtonOpenMotionControlDevice.BackColor = System.Drawing.Color.Green;
            this.CButtonOpenMotionControlDevice.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CButtonOpenMotionControlDevice.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.CButtonOpenMotionControlDevice.ForeColor = System.Drawing.Color.Transparent;
            this.CButtonOpenMotionControlDevice.Location = new System.Drawing.Point(118, 84);
            this.CButtonOpenMotionControlDevice.Name = "CButtonOpenMotionControlDevice";
            this.CButtonOpenMotionControlDevice.Size = new System.Drawing.Size(90, 30);
            this.CButtonOpenMotionControlDevice.TabIndex = 3;
            this.CButtonOpenMotionControlDevice.Text = "打开设备";
            this.CButtonOpenMotionControlDevice.UseVisualStyleBackColor = false;
            this.CButtonOpenMotionControlDevice.Click += new System.EventHandler(this.CButtonOpenMotionControlDevice_Click);
            // 
            // customLabel27
            // 
            this.customLabel27.AutoSize = true;
            this.customLabel27.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.customLabel27.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.customLabel27.Location = new System.Drawing.Point(18, 88);
            this.customLabel27.Name = "customLabel27";
            this.customLabel27.Size = new System.Drawing.Size(95, 23);
            this.customLabel27.TabIndex = 2;
            this.customLabel27.Text = "设备操作：";
            // 
            // ComBoxMotionControlDevice
            // 
            this.ComBoxMotionControlDevice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.ComBoxMotionControlDevice.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ComBoxMotionControlDevice.ForeColor = System.Drawing.Color.White;
            this.ComBoxMotionControlDevice.FormattingEnabled = true;
            this.ComBoxMotionControlDevice.Location = new System.Drawing.Point(119, 40);
            this.ComBoxMotionControlDevice.Name = "ComBoxMotionControlDevice";
            this.ComBoxMotionControlDevice.Size = new System.Drawing.Size(287, 29);
            this.ComBoxMotionControlDevice.TabIndex = 1;
            // 
            // customLabel26
            // 
            this.customLabel26.AutoSize = true;
            this.customLabel26.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.customLabel26.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.customLabel26.Location = new System.Drawing.Point(18, 42);
            this.customLabel26.Name = "customLabel26";
            this.customLabel26.Size = new System.Drawing.Size(95, 23);
            this.customLabel26.TabIndex = 0;
            this.customLabel26.Text = "设备列表：";
            // 
            // tabPageCamera
            // 
            this.tabPageCamera.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.tabPageCamera.Controls.Add(this.customGroupBox1);
            this.tabPageCamera.Controls.Add(this.PictureBoxCamera);
            this.tabPageCamera.Controls.Add(this.CGroupBoxCameraSet);
            this.tabPageCamera.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabPageCamera.Location = new System.Drawing.Point(0, 29);
            this.tabPageCamera.Name = "tabPageCamera";
            this.tabPageCamera.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageCamera.Size = new System.Drawing.Size(1360, 761);
            this.tabPageCamera.TabIndex = 1;
            this.tabPageCamera.Text = "相机";
            // 
            // customGroupBox1
            // 
            this.customGroupBox1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.customGroupBox1.Location = new System.Drawing.Point(680, 273);
            this.customGroupBox1.Name = "customGroupBox1";
            this.customGroupBox1.Size = new System.Drawing.Size(424, 229);
            this.customGroupBox1.TabIndex = 2;
            this.customGroupBox1.TabStop = false;
            this.customGroupBox1.Text = "视觉测试";
            // 
            // PictureBoxCamera
            // 
            this.PictureBoxCamera.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.PictureBoxCamera.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PictureBoxCamera.Location = new System.Drawing.Point(11, 22);
            this.PictureBoxCamera.Name = "PictureBoxCamera";
            this.PictureBoxCamera.Size = new System.Drawing.Size(640, 480);
            this.PictureBoxCamera.TabIndex = 1;
            this.PictureBoxCamera.TabStop = false;
            // 
            // CGroupBoxCameraSet
            // 
            this.CGroupBoxCameraSet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.CGroupBoxCameraSet.Controls.Add(this.CButtonCameraReadParam);
            this.CGroupBoxCameraSet.Controls.Add(this.CButtonCameraSetParam);
            this.CGroupBoxCameraSet.Controls.Add(this.CTextBoxCameraFrameRate);
            this.CGroupBoxCameraSet.Controls.Add(this.CTextBoxCameraGain);
            this.CGroupBoxCameraSet.Controls.Add(this.CTextBoxCameraExposure);
            this.CGroupBoxCameraSet.Controls.Add(this.customLabel25);
            this.CGroupBoxCameraSet.Controls.Add(this.customLabel24);
            this.CGroupBoxCameraSet.Controls.Add(this.customLabel23);
            this.CGroupBoxCameraSet.Controls.Add(this.customLabel22);
            this.CGroupBoxCameraSet.Controls.Add(this.CButtonCloseCamera);
            this.CGroupBoxCameraSet.Controls.Add(this.CButtonOpenCamera);
            this.CGroupBoxCameraSet.Controls.Add(this.CButtonFindCamera);
            this.CGroupBoxCameraSet.Controls.Add(this.customLabel21);
            this.CGroupBoxCameraSet.Controls.Add(this.ComBoxCameraDevList);
            this.CGroupBoxCameraSet.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.CGroupBoxCameraSet.Location = new System.Drawing.Point(680, 10);
            this.CGroupBoxCameraSet.Name = "CGroupBoxCameraSet";
            this.CGroupBoxCameraSet.Size = new System.Drawing.Size(424, 242);
            this.CGroupBoxCameraSet.TabIndex = 0;
            this.CGroupBoxCameraSet.TabStop = false;
            this.CGroupBoxCameraSet.Text = "相机设置";
            // 
            // CButtonCameraReadParam
            // 
            this.CButtonCameraReadParam.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.CButtonCameraReadParam.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CButtonCameraReadParam.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.CButtonCameraReadParam.ForeColor = System.Drawing.Color.Transparent;
            this.CButtonCameraReadParam.Location = new System.Drawing.Point(221, 156);
            this.CButtonCameraReadParam.Name = "CButtonCameraReadParam";
            this.CButtonCameraReadParam.Size = new System.Drawing.Size(90, 30);
            this.CButtonCameraReadParam.TabIndex = 13;
            this.CButtonCameraReadParam.Text = "读取";
            this.CButtonCameraReadParam.UseVisualStyleBackColor = false;
            this.CButtonCameraReadParam.Click += new System.EventHandler(this.CButtonCameraReadParam_Click);
            // 
            // CButtonCameraSetParam
            // 
            this.CButtonCameraSetParam.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.CButtonCameraSetParam.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CButtonCameraSetParam.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.CButtonCameraSetParam.ForeColor = System.Drawing.Color.Transparent;
            this.CButtonCameraSetParam.Location = new System.Drawing.Point(221, 117);
            this.CButtonCameraSetParam.Name = "CButtonCameraSetParam";
            this.CButtonCameraSetParam.Size = new System.Drawing.Size(90, 30);
            this.CButtonCameraSetParam.TabIndex = 12;
            this.CButtonCameraSetParam.Text = "设置";
            this.CButtonCameraSetParam.UseVisualStyleBackColor = false;
            this.CButtonCameraSetParam.Click += new System.EventHandler(this.CButtonCameraSetParam_Click);
            // 
            // CTextBoxCameraFrameRate
            // 
            this.CTextBoxCameraFrameRate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.CTextBoxCameraFrameRate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CTextBoxCameraFrameRate.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.CTextBoxCameraFrameRate.ForeColor = System.Drawing.Color.White;
            this.CTextBoxCameraFrameRate.Location = new System.Drawing.Point(123, 195);
            this.CTextBoxCameraFrameRate.Name = "CTextBoxCameraFrameRate";
            this.CTextBoxCameraFrameRate.Size = new System.Drawing.Size(90, 29);
            this.CTextBoxCameraFrameRate.TabIndex = 11;
            this.CTextBoxCameraFrameRate.Text = "1000";
            // 
            // CTextBoxCameraGain
            // 
            this.CTextBoxCameraGain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.CTextBoxCameraGain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CTextBoxCameraGain.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.CTextBoxCameraGain.ForeColor = System.Drawing.Color.White;
            this.CTextBoxCameraGain.Location = new System.Drawing.Point(123, 156);
            this.CTextBoxCameraGain.Name = "CTextBoxCameraGain";
            this.CTextBoxCameraGain.Size = new System.Drawing.Size(90, 29);
            this.CTextBoxCameraGain.TabIndex = 10;
            this.CTextBoxCameraGain.Text = "1000";
            // 
            // CTextBoxCameraExposure
            // 
            this.CTextBoxCameraExposure.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.CTextBoxCameraExposure.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CTextBoxCameraExposure.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.CTextBoxCameraExposure.ForeColor = System.Drawing.Color.White;
            this.CTextBoxCameraExposure.Location = new System.Drawing.Point(123, 117);
            this.CTextBoxCameraExposure.Name = "CTextBoxCameraExposure";
            this.CTextBoxCameraExposure.Size = new System.Drawing.Size(90, 29);
            this.CTextBoxCameraExposure.TabIndex = 9;
            this.CTextBoxCameraExposure.Text = "1000";
            // 
            // customLabel25
            // 
            this.customLabel25.AutoSize = true;
            this.customLabel25.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.customLabel25.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.customLabel25.Location = new System.Drawing.Point(21, 197);
            this.customLabel25.Name = "customLabel25";
            this.customLabel25.Size = new System.Drawing.Size(96, 23);
            this.customLabel25.TabIndex = 8;
            this.customLabel25.Text = "帧       率：";
            // 
            // customLabel24
            // 
            this.customLabel24.AutoSize = true;
            this.customLabel24.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.customLabel24.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.customLabel24.Location = new System.Drawing.Point(21, 158);
            this.customLabel24.Name = "customLabel24";
            this.customLabel24.Size = new System.Drawing.Size(96, 23);
            this.customLabel24.TabIndex = 7;
            this.customLabel24.Text = "增       益：";
            // 
            // customLabel23
            // 
            this.customLabel23.AutoSize = true;
            this.customLabel23.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.customLabel23.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.customLabel23.Location = new System.Drawing.Point(21, 119);
            this.customLabel23.Name = "customLabel23";
            this.customLabel23.Size = new System.Drawing.Size(96, 23);
            this.customLabel23.TabIndex = 6;
            this.customLabel23.Text = "曝       光：";
            // 
            // customLabel22
            // 
            this.customLabel22.AutoSize = true;
            this.customLabel22.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.customLabel22.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.customLabel22.Location = new System.Drawing.Point(21, 80);
            this.customLabel22.Name = "customLabel22";
            this.customLabel22.Size = new System.Drawing.Size(95, 23);
            this.customLabel22.TabIndex = 5;
            this.customLabel22.Text = "相机操作：";
            // 
            // CButtonCloseCamera
            // 
            this.CButtonCloseCamera.BackColor = System.Drawing.Color.Red;
            this.CButtonCloseCamera.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CButtonCloseCamera.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.CButtonCloseCamera.ForeColor = System.Drawing.Color.Transparent;
            this.CButtonCloseCamera.Location = new System.Drawing.Point(318, 78);
            this.CButtonCloseCamera.Name = "CButtonCloseCamera";
            this.CButtonCloseCamera.Size = new System.Drawing.Size(90, 30);
            this.CButtonCloseCamera.TabIndex = 4;
            this.CButtonCloseCamera.Text = "关闭相机";
            this.CButtonCloseCamera.UseVisualStyleBackColor = false;
            this.CButtonCloseCamera.Click += new System.EventHandler(this.CButtonCloseCamera_Click);
            // 
            // CButtonOpenCamera
            // 
            this.CButtonOpenCamera.BackColor = System.Drawing.Color.Green;
            this.CButtonOpenCamera.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CButtonOpenCamera.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.CButtonOpenCamera.ForeColor = System.Drawing.Color.Transparent;
            this.CButtonOpenCamera.Location = new System.Drawing.Point(221, 78);
            this.CButtonOpenCamera.Name = "CButtonOpenCamera";
            this.CButtonOpenCamera.Size = new System.Drawing.Size(90, 30);
            this.CButtonOpenCamera.TabIndex = 3;
            this.CButtonOpenCamera.Text = "打开相机";
            this.CButtonOpenCamera.UseVisualStyleBackColor = false;
            this.CButtonOpenCamera.Click += new System.EventHandler(this.CButtonOpenCamera_Click);
            // 
            // CButtonFindCamera
            // 
            this.CButtonFindCamera.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(148)))), ((int)(((byte)(8)))));
            this.CButtonFindCamera.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CButtonFindCamera.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.CButtonFindCamera.ForeColor = System.Drawing.Color.Transparent;
            this.CButtonFindCamera.Location = new System.Drawing.Point(122, 78);
            this.CButtonFindCamera.Name = "CButtonFindCamera";
            this.CButtonFindCamera.Size = new System.Drawing.Size(90, 30);
            this.CButtonFindCamera.TabIndex = 2;
            this.CButtonFindCamera.Text = "查找相机";
            this.CButtonFindCamera.UseVisualStyleBackColor = false;
            this.CButtonFindCamera.Click += new System.EventHandler(this.CButtonFindCamera_Click);
            // 
            // customLabel21
            // 
            this.customLabel21.AutoSize = true;
            this.customLabel21.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.customLabel21.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.customLabel21.Location = new System.Drawing.Point(21, 41);
            this.customLabel21.Name = "customLabel21";
            this.customLabel21.Size = new System.Drawing.Size(95, 23);
            this.customLabel21.TabIndex = 1;
            this.customLabel21.Text = "相机列表：";
            // 
            // ComBoxCameraDevList
            // 
            this.ComBoxCameraDevList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.ComBoxCameraDevList.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ComBoxCameraDevList.FormattingEnabled = true;
            this.ComBoxCameraDevList.Location = new System.Drawing.Point(123, 38);
            this.ComBoxCameraDevList.Name = "ComBoxCameraDevList";
            this.ComBoxCameraDevList.Size = new System.Drawing.Size(284, 29);
            this.ComBoxCameraDevList.TabIndex = 0;
            // 
            // ManualDebugForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.ClientSize = new System.Drawing.Size(1415, 790);
            this.ControlBox = false;
            this.Controls.Add(this.tabControlManualDebug);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ManualDebugForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ManualDebugForm_FormClosing);
            this.Load += new System.EventHandler(this.ManualDebug_Load);
            this.Shown += new System.EventHandler(this.ManualDebugForm_Shown);
            this.tabControlManualDebug.ResumeLayout(false);
            this.tabPageRobot.ResumeLayout(false);
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
            this.tabPageThreeAxisRobot.ResumeLayout(false);
            this.customGroupBox6.ResumeLayout(false);
            this.customGroupBox6.PerformLayout();
            this.customGroupBox5.ResumeLayout(false);
            this.customGroupBox5.PerformLayout();
            this.customGroupBox4.ResumeLayout(false);
            this.customGroupBox4.PerformLayout();
            this.customGroupBox3.ResumeLayout(false);
            this.customGroupBox2.ResumeLayout(false);
            this.customGroupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxMotionControlIoNegLmit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxMotionControlIoPosLmit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxMotionControlIoORG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxMotionControlIoEZ)).EndInit();
            this.tabPageCamera.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxCamera)).EndInit();
            this.CGroupBoxCameraSet.ResumeLayout(false);
            this.CGroupBoxCameraSet.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private CustomTabControl tabControlManualDebug;
        private System.Windows.Forms.TabPage tabPageRobot;
        private System.Windows.Forms.TabPage tabPageCamera;
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
        private CustomLabel customLabel10;
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
        private CustomGroupBox CGroupBoxCameraSet;
        private CustomLabel customLabel21;
        private System.Windows.Forms.ComboBox ComBoxCameraDevList;
        private CustomButton CButtonFindCamera;
        private CustomLabel customLabel22;
        private CustomButton CButtonCloseCamera;
        private CustomButton CButtonOpenCamera;
        private CustomTextBox CTextBoxCameraExposure;
        private CustomLabel customLabel25;
        private CustomLabel customLabel24;
        private CustomLabel customLabel23;
        private CustomTextBox CTextBoxCameraFrameRate;
        private CustomTextBox CTextBoxCameraGain;
        private CustomButton CButtonCameraReadParam;
        private CustomButton CButtonCameraSetParam;
        private System.Windows.Forms.PictureBox PictureBoxCamera;
        private CustomGroupBox customGroupBox1;
        private System.Windows.Forms.TabPage tabPageThreeAxisRobot;
        private CustomGroupBox customGroupBox2;
        private System.Windows.Forms.ComboBox ComBoxMotionControlDevice;
        private CustomLabel customLabel26;
        private CustomLabel customLabel27;
        private CustomButton CButtonOpenMotionControlDevice;
        private CustomGroupBox customGroupBox3;
        private CustomButton CButtonMotionControlDeviceLoadCfg;
        private CustomButton CButtonCloseMotionControlDevice;
        private CustomButton CButtonMotionControlGrasp;
        private CustomButton CButtonMotionControlRight;
        private CustomButton CButtonMotionControlLift;
        private CustomButton CButtonMotionControlDown;
        private CustomButton CButtonMotionControlUp;
        private CustomButton CButtonMotionControlResetError;
        private CustomTextBox CTextBoxMotionControlState;
        private CustomLabel customLabel28;
        private System.Windows.Forms.Timer TimerMotionControlGetState;
        private System.Windows.Forms.PictureBox picBoxMotionControlIoEZ;
        private CustomLabel customLabel30;
        private CustomLabel customLabel29;
        private System.Windows.Forms.PictureBox picBoxMotionControlIoORG;
        private CustomLabel customLabel31;
        private System.Windows.Forms.PictureBox picBoxMotionControlIoNegLmit;
        private CustomLabel customLabel33;
        private System.Windows.Forms.PictureBox picBoxMotionControlIoPosLmit;
        private CustomLabel customLabel32;
        private CustomGroupBox customGroupBox4;
        private CustomTextBox CTextBoxMotionControLowSpeed;
        private CustomLabel customLabel34;
        private CustomButton CButtonSetMotionControlSpeedParam;
        private CustomTextBox CTextBoxMotionControDecSpeed;
        private CustomTextBox CTextBoxMotionControAccSpeed;
        private CustomLabel customLabel37;
        private CustomLabel customLabel36;
        private CustomTextBox CTextBoxMotionControHighSpeed;
        private CustomLabel customLabel35;
        private CustomGroupBox customGroupBox5;
        private CustomTextBox CTextBoxMotionControlXDistance;
        private CustomLabel customLabel38;
        private CustomTextBox CTextBoxMotionControlZDistance;
        private CustomTextBox CTextBoxMotionControlYDistance;
        private CustomLabel customLabel40;
        private CustomLabel customLabel39;
        private System.Windows.Forms.OpenFileDialog OpenFileDialogMotionControlLoadCfg;
        private CustomTextBox CTextBoxMotionControlDistance;
        private CustomLabel customLabel20;
        private CustomGroupBox customGroupBox6;
        private CustomButton CButtonMotionAxisStop;
        private CustomButton CButtonMotionAxisHome;
        private CustomButton CButtonMotionAxisRunPos;
        private CustomButton CButtonMotionAxisRunNeg;
        private CustomLabel customLabel44;
        private System.Windows.Forms.ComboBox ComBoxMotionHomeMode;
        private CustomLabel customLabel43;
        private System.Windows.Forms.ComboBox ComBoxMotionControlAxis;
        private CustomLabel customLabel41;
    }
}