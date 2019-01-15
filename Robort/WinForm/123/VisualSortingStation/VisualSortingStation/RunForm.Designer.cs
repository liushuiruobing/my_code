namespace RobotWorkstation
{
    partial class RunForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.PicLedStop = new System.Windows.Forms.PictureBox();
            this.PicLedAlarm = new System.Windows.Forms.PictureBox();
            this.PicLedRun = new System.Windows.Forms.PictureBox();
            this.PicLedReady = new System.Windows.Forms.PictureBox();
            this.TimerCheckAllStatus = new System.Windows.Forms.Timer(this.components);
            this.CLabelTotalTrays = new RobotWorkstation.CustomLabel();
            this.CLabelTotalDeveices = new RobotWorkstation.CustomLabel();
            this.customLabel13 = new RobotWorkstation.CustomLabel();
            this.customLabel12 = new RobotWorkstation.CustomLabel();
            this.customLabel11 = new RobotWorkstation.CustomLabel();
            this.AfterSortingSalver = new RobotWorkstation.Salver();
            this.OriginalSalver = new RobotWorkstation.Salver();
            this.customLabel10 = new RobotWorkstation.CustomLabel();
            this.customLabel9 = new RobotWorkstation.CustomLabel();
            this.customLabel8 = new RobotWorkstation.CustomLabel();
            this.customLabel7 = new RobotWorkstation.CustomLabel();
            this.customLabel6 = new RobotWorkstation.CustomLabel();
            this.customGroupBox1 = new RobotWorkstation.CustomGroupBox();
            this.CButtonClearSysAlarm = new RobotWorkstation.CustomButton();
            this.DgvSysAlarm = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Level = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AlarmText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dealwith = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PicRfid = new System.Windows.Forms.PictureBox();
            this.customLabel5 = new RobotWorkstation.CustomLabel();
            this.PicQRCodeScanner = new System.Windows.Forms.PictureBox();
            this.customLabel4 = new RobotWorkstation.CustomLabel();
            this.PicTrayEmpty = new System.Windows.Forms.PictureBox();
            this.customLabel3 = new RobotWorkstation.CustomLabel();
            this.PicCamera = new System.Windows.Forms.PictureBox();
            this.customLabel2 = new RobotWorkstation.CustomLabel();
            this.PicRobot = new System.Windows.Forms.PictureBox();
            this.customLabel1 = new RobotWorkstation.CustomLabel();
            this.CButtonAutoRun = new RobotWorkstation.CustomButton();
            this.CButtonReset = new RobotWorkstation.CustomButton();
            this.CButtonStop = new RobotWorkstation.CustomButton();
            this.CButtonPause = new RobotWorkstation.CustomButton();
            this.CButtonRun = new RobotWorkstation.CustomButton();
            ((System.ComponentModel.ISupportInitialize)(this.PicLedStop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicLedAlarm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicLedRun)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicLedReady)).BeginInit();
            this.customGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvSysAlarm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicRfid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicQRCodeScanner)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicTrayEmpty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicCamera)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicRobot)).BeginInit();
            this.SuspendLayout();
            // 
            // PicLedStop
            // 
            this.PicLedStop.BackColor = System.Drawing.Color.Transparent;
            this.PicLedStop.ErrorImage = null;
            this.PicLedStop.Image = global::RobotWorkstation.Properties.Resources.DarkRed;
            this.PicLedStop.Location = new System.Drawing.Point(981, 10);
            this.PicLedStop.Name = "PicLedStop";
            this.PicLedStop.Size = new System.Drawing.Size(128, 128);
            this.PicLedStop.TabIndex = 3;
            this.PicLedStop.TabStop = false;
            // 
            // PicLedAlarm
            // 
            this.PicLedAlarm.BackColor = System.Drawing.Color.Transparent;
            this.PicLedAlarm.Image = global::RobotWorkstation.Properties.Resources.DarkYellow;
            this.PicLedAlarm.Location = new System.Drawing.Point(704, 10);
            this.PicLedAlarm.Name = "PicLedAlarm";
            this.PicLedAlarm.Size = new System.Drawing.Size(128, 128);
            this.PicLedAlarm.TabIndex = 2;
            this.PicLedAlarm.TabStop = false;
            // 
            // PicLedRun
            // 
            this.PicLedRun.BackColor = System.Drawing.Color.Transparent;
            this.PicLedRun.Image = global::RobotWorkstation.Properties.Resources.DarkGreen;
            this.PicLedRun.Location = new System.Drawing.Point(427, 10);
            this.PicLedRun.Name = "PicLedRun";
            this.PicLedRun.Size = new System.Drawing.Size(128, 128);
            this.PicLedRun.TabIndex = 1;
            this.PicLedRun.TabStop = false;
            // 
            // PicLedReady
            // 
            this.PicLedReady.BackColor = System.Drawing.Color.Transparent;
            this.PicLedReady.Image = global::RobotWorkstation.Properties.Resources.DarkBlue;
            this.PicLedReady.Location = new System.Drawing.Point(150, 10);
            this.PicLedReady.Name = "PicLedReady";
            this.PicLedReady.Size = new System.Drawing.Size(128, 128);
            this.PicLedReady.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PicLedReady.TabIndex = 0;
            this.PicLedReady.TabStop = false;
            // 
            // TimerCheckAllStatus
            // 
            this.TimerCheckAllStatus.Tick += new System.EventHandler(this.TimerCheckAllStatus_Tick);
            // 
            // CLabelTotalTrays
            // 
            this.CLabelTotalTrays.AutoSize = true;
            this.CLabelTotalTrays.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.CLabelTotalTrays.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.CLabelTotalTrays.Location = new System.Drawing.Point(1151, 276);
            this.CLabelTotalTrays.Name = "CLabelTotalTrays";
            this.CLabelTotalTrays.Size = new System.Drawing.Size(20, 23);
            this.CLabelTotalTrays.TabIndex = 21;
            this.CLabelTotalTrays.Text = "0";
            // 
            // CLabelTotalDeveices
            // 
            this.CLabelTotalDeveices.AutoSize = true;
            this.CLabelTotalDeveices.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.CLabelTotalDeveices.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.CLabelTotalDeveices.Location = new System.Drawing.Point(1151, 233);
            this.CLabelTotalDeveices.Name = "CLabelTotalDeveices";
            this.CLabelTotalDeveices.Size = new System.Drawing.Size(20, 23);
            this.CLabelTotalDeveices.TabIndex = 20;
            this.CLabelTotalDeveices.Text = "0";
            // 
            // customLabel13
            // 
            this.customLabel13.AutoSize = true;
            this.customLabel13.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.customLabel13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.customLabel13.Location = new System.Drawing.Point(788, 387);
            this.customLabel13.Name = "customLabel13";
            this.customLabel13.Size = new System.Drawing.Size(78, 23);
            this.customLabel13.TabIndex = 19;
            this.customLabel13.Text = "分拣物料";
            // 
            // customLabel12
            // 
            this.customLabel12.AutoSize = true;
            this.customLabel12.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.customLabel12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.customLabel12.Location = new System.Drawing.Point(397, 390);
            this.customLabel12.Name = "customLabel12";
            this.customLabel12.Size = new System.Drawing.Size(78, 23);
            this.customLabel12.TabIndex = 18;
            this.customLabel12.Text = "原始物料";
            // 
            // customLabel11
            // 
            this.customLabel11.AutoSize = true;
            this.customLabel11.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.customLabel11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.customLabel11.Location = new System.Drawing.Point(84, 316);
            this.customLabel11.Name = "customLabel11";
            this.customLabel11.Size = new System.Drawing.Size(112, 23);
            this.customLabel11.TabIndex = 17;
            this.customLabel11.Text = "其他显示信息";
            // 
            // AfterSortingSalver
            // 
            this.AfterSortingSalver.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.AfterSortingSalver.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AfterSortingSalver.Location = new System.Drawing.Point(704, 280);
            this.AfterSortingSalver.Margin = new System.Windows.Forms.Padding(2);
            this.AfterSortingSalver.Name = "AfterSortingSalver";
            this.AfterSortingSalver.Size = new System.Drawing.Size(240, 105);
            this.AfterSortingSalver.TabIndex = 16;
            // 
            // OriginalSalver
            // 
            this.OriginalSalver.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.OriginalSalver.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.OriginalSalver.Location = new System.Drawing.Point(331, 280);
            this.OriginalSalver.Margin = new System.Windows.Forms.Padding(2);
            this.OriginalSalver.Name = "OriginalSalver";
            this.OriginalSalver.Size = new System.Drawing.Size(240, 105);
            this.OriginalSalver.TabIndex = 15;
            // 
            // customLabel10
            // 
            this.customLabel10.AutoSize = true;
            this.customLabel10.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.customLabel10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.customLabel10.Location = new System.Drawing.Point(1067, 318);
            this.customLabel10.Name = "customLabel10";
            this.customLabel10.Size = new System.Drawing.Size(78, 23);
            this.customLabel10.TabIndex = 14;
            this.customLabel10.Text = "空盘数：";
            // 
            // customLabel9
            // 
            this.customLabel9.AutoSize = true;
            this.customLabel9.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.customLabel9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.customLabel9.Location = new System.Drawing.Point(1067, 403);
            this.customLabel9.Name = "customLabel9";
            this.customLabel9.Size = new System.Drawing.Size(78, 23);
            this.customLabel9.TabIndex = 13;
            this.customLabel9.Text = "当前件：";
            // 
            // customLabel8
            // 
            this.customLabel8.AutoSize = true;
            this.customLabel8.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.customLabel8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.customLabel8.Location = new System.Drawing.Point(1067, 360);
            this.customLabel8.Name = "customLabel8";
            this.customLabel8.Size = new System.Drawing.Size(78, 23);
            this.customLabel8.TabIndex = 12;
            this.customLabel8.Text = "当前盘：";
            // 
            // customLabel7
            // 
            this.customLabel7.AutoSize = true;
            this.customLabel7.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.customLabel7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.customLabel7.Location = new System.Drawing.Point(1067, 274);
            this.customLabel7.Name = "customLabel7";
            this.customLabel7.Size = new System.Drawing.Size(78, 23);
            this.customLabel7.TabIndex = 11;
            this.customLabel7.Text = "总盘数：";
            // 
            // customLabel6
            // 
            this.customLabel6.AutoSize = true;
            this.customLabel6.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.customLabel6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.customLabel6.Location = new System.Drawing.Point(1067, 231);
            this.customLabel6.Name = "customLabel6";
            this.customLabel6.Size = new System.Drawing.Size(78, 23);
            this.customLabel6.TabIndex = 10;
            this.customLabel6.Text = "总件数：";
            // 
            // customGroupBox1
            // 
            this.customGroupBox1.Controls.Add(this.CButtonClearSysAlarm);
            this.customGroupBox1.Controls.Add(this.DgvSysAlarm);
            this.customGroupBox1.Controls.Add(this.PicRfid);
            this.customGroupBox1.Controls.Add(this.customLabel5);
            this.customGroupBox1.Controls.Add(this.PicQRCodeScanner);
            this.customGroupBox1.Controls.Add(this.customLabel4);
            this.customGroupBox1.Controls.Add(this.PicTrayEmpty);
            this.customGroupBox1.Controls.Add(this.PicCamera);
            this.customGroupBox1.Controls.Add(this.customLabel2);
            this.customGroupBox1.Controls.Add(this.customLabel3);
            this.customGroupBox1.Controls.Add(this.PicRobot);
            this.customGroupBox1.Controls.Add(this.customLabel1);
            this.customGroupBox1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.customGroupBox1.Location = new System.Drawing.Point(75, 550);
            this.customGroupBox1.Name = "customGroupBox1";
            this.customGroupBox1.Size = new System.Drawing.Size(1110, 150);
            this.customGroupBox1.TabIndex = 9;
            this.customGroupBox1.TabStop = false;
            this.customGroupBox1.Text = "运行状态";
            // 
            // CButtonClearSysAlarm
            // 
            this.CButtonClearSysAlarm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.CButtonClearSysAlarm.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CButtonClearSysAlarm.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.CButtonClearSysAlarm.ForeColor = System.Drawing.Color.Transparent;
            this.CButtonClearSysAlarm.Location = new System.Drawing.Point(1049, 76);
            this.CButtonClearSysAlarm.Name = "CButtonClearSysAlarm";
            this.CButtonClearSysAlarm.Size = new System.Drawing.Size(55, 45);
            this.CButtonClearSysAlarm.TabIndex = 11;
            this.CButtonClearSysAlarm.Text = "清除";
            this.CButtonClearSysAlarm.UseVisualStyleBackColor = false;
            this.CButtonClearSysAlarm.Click += new System.EventHandler(this.CButtonClearSysAlarm_Click);
            // 
            // DgvSysAlarm
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DgvSysAlarm.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DgvSysAlarm.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.DgvSysAlarm.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 12F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DgvSysAlarm.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DgvSysAlarm.ColumnHeadersHeight = 25;
            this.DgvSysAlarm.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DgvSysAlarm.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Level,
            this.AlarmText,
            this.Dealwith});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("微软雅黑", 12F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DgvSysAlarm.DefaultCellStyle = dataGridViewCellStyle4;
            this.DgvSysAlarm.EnableHeadersVisualStyles = false;
            this.DgvSysAlarm.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.DgvSysAlarm.Location = new System.Drawing.Point(43, 52);
            this.DgvSysAlarm.Name = "DgvSysAlarm";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("微软雅黑", 12F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DgvSysAlarm.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.DgvSysAlarm.RowHeadersVisible = false;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.White;
            this.DgvSysAlarm.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.DgvSysAlarm.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.DgvSysAlarm.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.Black;
            this.DgvSysAlarm.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.DgvSysAlarm.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.Black;
            this.DgvSysAlarm.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
            this.DgvSysAlarm.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DgvSysAlarm.RowTemplate.Height = 23;
            this.DgvSysAlarm.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.DgvSysAlarm.Size = new System.Drawing.Size(1000, 92);
            this.DgvSysAlarm.TabIndex = 10;
            // 
            // ID
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ID.DefaultCellStyle = dataGridViewCellStyle3;
            this.ID.DividerWidth = 1;
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.Width = 75;
            // 
            // Level
            // 
            this.Level.DividerWidth = 1;
            this.Level.HeaderText = "等级";
            this.Level.Name = "Level";
            this.Level.Width = 75;
            // 
            // AlarmText
            // 
            this.AlarmText.DividerWidth = 1;
            this.AlarmText.HeaderText = "报警描述";
            this.AlarmText.MinimumWidth = 20;
            this.AlarmText.Name = "AlarmText";
            this.AlarmText.Width = 360;
            // 
            // Dealwith
            // 
            this.Dealwith.DividerWidth = 1;
            this.Dealwith.HeaderText = "处理方法";
            this.Dealwith.MinimumWidth = 10;
            this.Dealwith.Name = "Dealwith";
            this.Dealwith.Width = 500;
            // 
            // PicRfid
            // 
            this.PicRfid.Image = global::RobotWorkstation.Properties.Resources.SmallGreen;
            this.PicRfid.Location = new System.Drawing.Point(832, 21);
            this.PicRfid.Name = "PicRfid";
            this.PicRfid.Size = new System.Drawing.Size(24, 24);
            this.PicRfid.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PicRfid.TabIndex = 9;
            this.PicRfid.TabStop = false;
            // 
            // customLabel5
            // 
            this.customLabel5.AutoSize = true;
            this.customLabel5.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.customLabel5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.customLabel5.Location = new System.Drawing.Point(722, 22);
            this.customLabel5.Name = "customLabel5";
            this.customLabel5.Size = new System.Drawing.Size(99, 23);
            this.customLabel5.TabIndex = 8;
            this.customLabel5.Text = "RFID读码器";
            // 
            // PicQRCodeScanner
            // 
            this.PicQRCodeScanner.Image = global::RobotWorkstation.Properties.Resources.SmallGreen;
            this.PicQRCodeScanner.Location = new System.Drawing.Point(584, 23);
            this.PicQRCodeScanner.Name = "PicQRCodeScanner";
            this.PicQRCodeScanner.Size = new System.Drawing.Size(24, 24);
            this.PicQRCodeScanner.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PicQRCodeScanner.TabIndex = 7;
            this.PicQRCodeScanner.TabStop = false;
            // 
            // customLabel4
            // 
            this.customLabel4.AutoSize = true;
            this.customLabel4.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.customLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.customLabel4.Location = new System.Drawing.Point(466, 22);
            this.customLabel4.Name = "customLabel4";
            this.customLabel4.Size = new System.Drawing.Size(112, 23);
            this.customLabel4.TabIndex = 6;
            this.customLabel4.Text = "二维码读码器";
            // 
            // PicTrayEmpty
            // 
            this.PicTrayEmpty.Image = global::RobotWorkstation.Properties.Resources.SmallGreen;
            this.PicTrayEmpty.Location = new System.Drawing.Point(1015, 21);
            this.PicTrayEmpty.Name = "PicTrayEmpty";
            this.PicTrayEmpty.Size = new System.Drawing.Size(24, 24);
            this.PicTrayEmpty.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PicTrayEmpty.TabIndex = 5;
            this.PicTrayEmpty.TabStop = false;
            // 
            // customLabel3
            // 
            this.customLabel3.AutoSize = true;
            this.customLabel3.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.customLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.customLabel3.Location = new System.Drawing.Point(965, 22);
            this.customLabel3.Name = "customLabel3";
            this.customLabel3.Size = new System.Drawing.Size(44, 23);
            this.customLabel3.TabIndex = 4;
            this.customLabel3.Text = "缺盘";
            // 
            // PicCamera
            // 
            this.PicCamera.Image = global::RobotWorkstation.Properties.Resources.SmallGreen;
            this.PicCamera.Location = new System.Drawing.Point(328, 23);
            this.PicCamera.Name = "PicCamera";
            this.PicCamera.Size = new System.Drawing.Size(24, 24);
            this.PicCamera.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PicCamera.TabIndex = 3;
            this.PicCamera.TabStop = false;
            // 
            // customLabel2
            // 
            this.customLabel2.AutoSize = true;
            this.customLabel2.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.customLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.customLabel2.Location = new System.Drawing.Point(278, 23);
            this.customLabel2.Name = "customLabel2";
            this.customLabel2.Size = new System.Drawing.Size(44, 23);
            this.customLabel2.TabIndex = 2;
            this.customLabel2.Text = "相机";
            // 
            // PicRobot
            // 
            this.PicRobot.Image = global::RobotWorkstation.Properties.Resources.SmallGreen;
            this.PicRobot.Location = new System.Drawing.Point(140, 22);
            this.PicRobot.Name = "PicRobot";
            this.PicRobot.Size = new System.Drawing.Size(24, 24);
            this.PicRobot.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PicRobot.TabIndex = 1;
            this.PicRobot.TabStop = false;
            // 
            // customLabel1
            // 
            this.customLabel1.AutoSize = true;
            this.customLabel1.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.customLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.customLabel1.Location = new System.Drawing.Point(73, 23);
            this.customLabel1.Name = "customLabel1";
            this.customLabel1.Size = new System.Drawing.Size(61, 23);
            this.customLabel1.TabIndex = 0;
            this.customLabel1.Text = "机械臂";
            // 
            // CButtonAutoRun
            // 
            this.CButtonAutoRun.BackColor = System.Drawing.Color.DimGray;
            this.CButtonAutoRun.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CButtonAutoRun.Font = new System.Drawing.Font("微软雅黑", 21.75F);
            this.CButtonAutoRun.ForeColor = System.Drawing.Color.Transparent;
            this.CButtonAutoRun.Location = new System.Drawing.Point(1085, 728);
            this.CButtonAutoRun.Name = "CButtonAutoRun";
            this.CButtonAutoRun.Size = new System.Drawing.Size(100, 80);
            this.CButtonAutoRun.TabIndex = 8;
            this.CButtonAutoRun.Text = "自动";
            this.CButtonAutoRun.UseVisualStyleBackColor = false;
            this.CButtonAutoRun.Click += new System.EventHandler(this.CButtonAutoRun_Click);
            // 
            // CButtonReset
            // 
            this.CButtonReset.BackColor = System.Drawing.Color.SteelBlue;
            this.CButtonReset.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CButtonReset.Font = new System.Drawing.Font("微软雅黑", 21.75F);
            this.CButtonReset.ForeColor = System.Drawing.Color.Transparent;
            this.CButtonReset.Location = new System.Drawing.Point(831, 728);
            this.CButtonReset.Name = "CButtonReset";
            this.CButtonReset.Size = new System.Drawing.Size(100, 80);
            this.CButtonReset.TabIndex = 7;
            this.CButtonReset.Text = "复位";
            this.CButtonReset.UseVisualStyleBackColor = false;
            this.CButtonReset.Click += new System.EventHandler(this.CButtonReset_Click);
            // 
            // CButtonStop
            // 
            this.CButtonStop.BackColor = System.Drawing.Color.Red;
            this.CButtonStop.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CButtonStop.Font = new System.Drawing.Font("微软雅黑", 21.75F);
            this.CButtonStop.ForeColor = System.Drawing.Color.Transparent;
            this.CButtonStop.Location = new System.Drawing.Point(579, 728);
            this.CButtonStop.Name = "CButtonStop";
            this.CButtonStop.Size = new System.Drawing.Size(100, 80);
            this.CButtonStop.TabIndex = 6;
            this.CButtonStop.Text = "停止";
            this.CButtonStop.UseVisualStyleBackColor = false;
            this.CButtonStop.Click += new System.EventHandler(this.CButtonStop_Click);
            // 
            // CButtonPause
            // 
            this.CButtonPause.BackColor = System.Drawing.Color.Orange;
            this.CButtonPause.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CButtonPause.Font = new System.Drawing.Font("微软雅黑", 21.75F);
            this.CButtonPause.ForeColor = System.Drawing.Color.Transparent;
            this.CButtonPause.Location = new System.Drawing.Point(327, 728);
            this.CButtonPause.Name = "CButtonPause";
            this.CButtonPause.Size = new System.Drawing.Size(100, 80);
            this.CButtonPause.TabIndex = 5;
            this.CButtonPause.Text = "暂停";
            this.CButtonPause.UseVisualStyleBackColor = false;
            this.CButtonPause.Click += new System.EventHandler(this.CButtonPause_Click);
            // 
            // CButtonRun
            // 
            this.CButtonRun.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.CButtonRun.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CButtonRun.Font = new System.Drawing.Font("微软雅黑", 21.75F);
            this.CButtonRun.ForeColor = System.Drawing.Color.Transparent;
            this.CButtonRun.Location = new System.Drawing.Point(75, 728);
            this.CButtonRun.Name = "CButtonRun";
            this.CButtonRun.Size = new System.Drawing.Size(100, 80);
            this.CButtonRun.TabIndex = 4;
            this.CButtonRun.Text = "启动";
            this.CButtonRun.UseVisualStyleBackColor = false;
            this.CButtonRun.Click += new System.EventHandler(this.CButtonStart_Click);
            // 
            // RunForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.ClientSize = new System.Drawing.Size(1260, 830);
            this.ControlBox = false;
            this.Controls.Add(this.CLabelTotalTrays);
            this.Controls.Add(this.CLabelTotalDeveices);
            this.Controls.Add(this.customLabel13);
            this.Controls.Add(this.customLabel12);
            this.Controls.Add(this.customLabel11);
            this.Controls.Add(this.AfterSortingSalver);
            this.Controls.Add(this.OriginalSalver);
            this.Controls.Add(this.customLabel10);
            this.Controls.Add(this.customLabel9);
            this.Controls.Add(this.customLabel8);
            this.Controls.Add(this.customLabel7);
            this.Controls.Add(this.customLabel6);
            this.Controls.Add(this.customGroupBox1);
            this.Controls.Add(this.CButtonAutoRun);
            this.Controls.Add(this.CButtonReset);
            this.Controls.Add(this.CButtonStop);
            this.Controls.Add(this.CButtonPause);
            this.Controls.Add(this.CButtonRun);
            this.Controls.Add(this.PicLedStop);
            this.Controls.Add(this.PicLedAlarm);
            this.Controls.Add(this.PicLedRun);
            this.Controls.Add(this.PicLedReady);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RunForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "RunForm";
            this.Load += new System.EventHandler(this.RunForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PicLedStop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicLedAlarm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicLedRun)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicLedReady)).EndInit();
            this.customGroupBox1.ResumeLayout(false);
            this.customGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvSysAlarm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicRfid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicQRCodeScanner)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicTrayEmpty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicCamera)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicRobot)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.PictureBox PicLedReady;
        public System.Windows.Forms.PictureBox PicLedRun;
        public System.Windows.Forms.PictureBox PicLedAlarm;
        public System.Windows.Forms.PictureBox PicLedStop;
        private CustomButton CButtonRun;
        private CustomButton CButtonPause;
        private CustomButton CButtonStop;
        private CustomButton CButtonReset;
        private CustomButton CButtonAutoRun;
        private CustomGroupBox customGroupBox1;
        private System.Windows.Forms.PictureBox PicTrayEmpty;
        private CustomLabel customLabel3;
        private System.Windows.Forms.PictureBox PicCamera;
        private CustomLabel customLabel2;
        private System.Windows.Forms.PictureBox PicRobot;
        private CustomLabel customLabel1;
        private CustomLabel customLabel4;
        private System.Windows.Forms.PictureBox PicRfid;
        private CustomLabel customLabel5;
        private System.Windows.Forms.PictureBox PicQRCodeScanner;
        private System.Windows.Forms.DataGridView DgvSysAlarm;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Level;
        private System.Windows.Forms.DataGridViewTextBoxColumn AlarmText;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dealwith;
        private CustomButton CButtonClearSysAlarm;
        private CustomLabel customLabel6;
        private CustomLabel customLabel7;
        private CustomLabel customLabel8;
        private CustomLabel customLabel9;
        private CustomLabel customLabel10;
        private Salver OriginalSalver;
        private Salver AfterSortingSalver;
        private System.Windows.Forms.Timer TimerCheckAllStatus;
        private CustomLabel customLabel11;
        private CustomLabel customLabel12;
        private CustomLabel customLabel13;
        private CustomLabel CLabelTotalDeveices;
        private CustomLabel CLabelTotalTrays;
    }
}