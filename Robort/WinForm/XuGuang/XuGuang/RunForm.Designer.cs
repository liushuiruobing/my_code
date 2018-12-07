﻿namespace RobotWorkstation
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.PicLedReady = new System.Windows.Forms.PictureBox();
            this.PicLedRun = new System.Windows.Forms.PictureBox();
            this.PicLedAlarm = new System.Windows.Forms.PictureBox();
            this.PicLedStop = new System.Windows.Forms.PictureBox();
            this.CButtonStart = new RobotWorkstation.CustomButton();
            this.CButtonPause = new RobotWorkstation.CustomButton();
            this.CButtonStop = new RobotWorkstation.CustomButton();
            this.CButtonReset = new RobotWorkstation.CustomButton();
            this.CButtonAutoRun = new RobotWorkstation.CustomButton();
            this.customGroupBox1 = new RobotWorkstation.CustomGroupBox();
            this.customLabel1 = new RobotWorkstation.CustomLabel();
            this.PicRobot = new System.Windows.Forms.PictureBox();
            this.customLabel2 = new RobotWorkstation.CustomLabel();
            this.PicCamera = new System.Windows.Forms.PictureBox();
            this.customLabel3 = new RobotWorkstation.CustomLabel();
            this.PicTrayEmpty = new System.Windows.Forms.PictureBox();
            this.customLabel4 = new RobotWorkstation.CustomLabel();
            this.PicTwoDimensionalCodeScanner = new System.Windows.Forms.PictureBox();
            this.customLabel5 = new RobotWorkstation.CustomLabel();
            this.PicRfid = new System.Windows.Forms.PictureBox();
            this.DgvSysAlarm = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Level = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AlarmText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dealwith = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CButtonClearSysAlarm = new RobotWorkstation.CustomButton();
            ((System.ComponentModel.ISupportInitialize)(this.PicLedReady)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicLedRun)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicLedAlarm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicLedStop)).BeginInit();
            this.customGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicRobot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicCamera)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicTrayEmpty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicTwoDimensionalCodeScanner)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicRfid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvSysAlarm)).BeginInit();
            this.SuspendLayout();
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
            // CButtonStart
            // 
            this.CButtonStart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.CButtonStart.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CButtonStart.Font = new System.Drawing.Font("微软雅黑", 21.75F);
            this.CButtonStart.ForeColor = System.Drawing.Color.Transparent;
            this.CButtonStart.Location = new System.Drawing.Point(75, 728);
            this.CButtonStart.Name = "CButtonStart";
            this.CButtonStart.Size = new System.Drawing.Size(100, 80);
            this.CButtonStart.TabIndex = 4;
            this.CButtonStart.Text = "启动";
            this.CButtonStart.UseVisualStyleBackColor = false;
            this.CButtonStart.Click += new System.EventHandler(this.CButtonStart_Click);
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
            // customGroupBox1
            // 
            this.customGroupBox1.Controls.Add(this.CButtonClearSysAlarm);
            this.customGroupBox1.Controls.Add(this.DgvSysAlarm);
            this.customGroupBox1.Controls.Add(this.PicRfid);
            this.customGroupBox1.Controls.Add(this.customLabel5);
            this.customGroupBox1.Controls.Add(this.PicTwoDimensionalCodeScanner);
            this.customGroupBox1.Controls.Add(this.customLabel4);
            this.customGroupBox1.Controls.Add(this.PicTrayEmpty);
            this.customGroupBox1.Controls.Add(this.customLabel3);
            this.customGroupBox1.Controls.Add(this.PicCamera);
            this.customGroupBox1.Controls.Add(this.customLabel2);
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
            // customLabel2
            // 
            this.customLabel2.AutoSize = true;
            this.customLabel2.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.customLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.customLabel2.Location = new System.Drawing.Point(304, 23);
            this.customLabel2.Name = "customLabel2";
            this.customLabel2.Size = new System.Drawing.Size(44, 23);
            this.customLabel2.TabIndex = 2;
            this.customLabel2.Text = "相机";
            // 
            // PicCamera
            // 
            this.PicCamera.Image = global::RobotWorkstation.Properties.Resources.SmallGreen;
            this.PicCamera.Location = new System.Drawing.Point(354, 22);
            this.PicCamera.Name = "PicCamera";
            this.PicCamera.Size = new System.Drawing.Size(24, 24);
            this.PicCamera.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PicCamera.TabIndex = 3;
            this.PicCamera.TabStop = false;
            // 
            // customLabel3
            // 
            this.customLabel3.AutoSize = true;
            this.customLabel3.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.customLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.customLabel3.Location = new System.Drawing.Point(518, 23);
            this.customLabel3.Name = "customLabel3";
            this.customLabel3.Size = new System.Drawing.Size(44, 23);
            this.customLabel3.TabIndex = 4;
            this.customLabel3.Text = "缺盘";
            // 
            // PicTrayEmpty
            // 
            this.PicTrayEmpty.Image = global::RobotWorkstation.Properties.Resources.SmallGreen;
            this.PicTrayEmpty.Location = new System.Drawing.Point(568, 22);
            this.PicTrayEmpty.Name = "PicTrayEmpty";
            this.PicTrayEmpty.Size = new System.Drawing.Size(24, 24);
            this.PicTrayEmpty.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PicTrayEmpty.TabIndex = 5;
            this.PicTrayEmpty.TabStop = false;
            // 
            // customLabel4
            // 
            this.customLabel4.AutoSize = true;
            this.customLabel4.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.customLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.customLabel4.Location = new System.Drawing.Point(664, 23);
            this.customLabel4.Name = "customLabel4";
            this.customLabel4.Size = new System.Drawing.Size(112, 23);
            this.customLabel4.TabIndex = 6;
            this.customLabel4.Text = "二维码扫描器";
            // 
            // PicTwoDimensionalCodeScanner
            // 
            this.PicTwoDimensionalCodeScanner.Image = global::RobotWorkstation.Properties.Resources.SmallGreen;
            this.PicTwoDimensionalCodeScanner.Location = new System.Drawing.Point(782, 22);
            this.PicTwoDimensionalCodeScanner.Name = "PicTwoDimensionalCodeScanner";
            this.PicTwoDimensionalCodeScanner.Size = new System.Drawing.Size(24, 24);
            this.PicTwoDimensionalCodeScanner.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PicTwoDimensionalCodeScanner.TabIndex = 7;
            this.PicTwoDimensionalCodeScanner.TabStop = false;
            // 
            // customLabel5
            // 
            this.customLabel5.AutoSize = true;
            this.customLabel5.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.customLabel5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.customLabel5.Location = new System.Drawing.Point(891, 23);
            this.customLabel5.Name = "customLabel5";
            this.customLabel5.Size = new System.Drawing.Size(99, 23);
            this.customLabel5.TabIndex = 8;
            this.customLabel5.Text = "RFID扫描器";
            // 
            // PicRfid
            // 
            this.PicRfid.Image = global::RobotWorkstation.Properties.Resources.SmallGreen;
            this.PicRfid.Location = new System.Drawing.Point(996, 22);
            this.PicRfid.Name = "PicRfid";
            this.PicRfid.Size = new System.Drawing.Size(24, 24);
            this.PicRfid.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PicRfid.TabIndex = 9;
            this.PicRfid.TabStop = false;
            // 
            // DgvSysAlarm
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DgvSysAlarm.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            this.DgvSysAlarm.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.DgvSysAlarm.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("微软雅黑", 12F);
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DgvSysAlarm.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.DgvSysAlarm.ColumnHeadersHeight = 25;
            this.DgvSysAlarm.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DgvSysAlarm.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Level,
            this.AlarmText,
            this.Dealwith});
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("微软雅黑", 12F);
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DgvSysAlarm.DefaultCellStyle = dataGridViewCellStyle10;
            this.DgvSysAlarm.EnableHeadersVisualStyles = false;
            this.DgvSysAlarm.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.DgvSysAlarm.Location = new System.Drawing.Point(43, 52);
            this.DgvSysAlarm.Name = "DgvSysAlarm";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("微软雅黑", 12F);
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DgvSysAlarm.RowHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.DgvSysAlarm.RowHeadersVisible = false;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle12.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.White;
            this.DgvSysAlarm.RowsDefaultCellStyle = dataGridViewCellStyle12;
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
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ID.DefaultCellStyle = dataGridViewCellStyle9;
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
            // 
            // RunForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.ClientSize = new System.Drawing.Size(1260, 830);
            this.Controls.Add(this.customGroupBox1);
            this.Controls.Add(this.CButtonAutoRun);
            this.Controls.Add(this.CButtonReset);
            this.Controls.Add(this.CButtonStop);
            this.Controls.Add(this.CButtonPause);
            this.Controls.Add(this.CButtonStart);
            this.Controls.Add(this.PicLedStop);
            this.Controls.Add(this.PicLedAlarm);
            this.Controls.Add(this.PicLedRun);
            this.Controls.Add(this.PicLedReady);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RunForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "RunForm";
            ((System.ComponentModel.ISupportInitialize)(this.PicLedReady)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicLedRun)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicLedAlarm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicLedStop)).EndInit();
            this.customGroupBox1.ResumeLayout(false);
            this.customGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicRobot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicCamera)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicTrayEmpty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicTwoDimensionalCodeScanner)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicRfid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvSysAlarm)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.PictureBox PicLedReady;
        public System.Windows.Forms.PictureBox PicLedRun;
        public System.Windows.Forms.PictureBox PicLedAlarm;
        public System.Windows.Forms.PictureBox PicLedStop;
        private CustomButton CButtonStart;
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
        private System.Windows.Forms.PictureBox PicTwoDimensionalCodeScanner;
        private System.Windows.Forms.DataGridView DgvSysAlarm;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Level;
        private System.Windows.Forms.DataGridViewTextBoxColumn AlarmText;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dealwith;
        private CustomButton CButtonClearSysAlarm;
    }
}