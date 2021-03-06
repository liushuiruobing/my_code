﻿namespace RobotWorkstation
{
    partial class SystemSetingForm
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
            this.tabControlSystemSeting = new RobotWorkstation.CustomTabControl();
            this.SystemSetPageRobot = new System.Windows.Forms.TabPage();
            this.CTextBoxSysSetRobotIP = new RobotWorkstation.CustomTextBox();
            this.customLabel1 = new RobotWorkstation.CustomLabel();
            this.SystemSetPageCamera = new System.Windows.Forms.TabPage();
            this.SystemSetPageOthers = new System.Windows.Forms.TabPage();
            this.ComBoxSysLanguage = new System.Windows.Forms.ComboBox();
            this.CLabelSysLanguage = new RobotWorkstation.CustomLabel();
            this.tabControlSystemSeting.SuspendLayout();
            this.SystemSetPageRobot.SuspendLayout();
            this.SystemSetPageOthers.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlSystemSeting
            // 
            this.tabControlSystemSeting.Controls.Add(this.SystemSetPageRobot);
            this.tabControlSystemSeting.Controls.Add(this.SystemSetPageCamera);
            this.tabControlSystemSeting.Controls.Add(this.SystemSetPageOthers);
            this.tabControlSystemSeting.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.tabControlSystemSeting.ItemSize = new System.Drawing.Size(120, 26);
            this.tabControlSystemSeting.Location = new System.Drawing.Point(12, 12);
            this.tabControlSystemSeting.Margin = new System.Windows.Forms.Padding(1);
            this.tabControlSystemSeting.Name = "tabControlSystemSeting";
            this.tabControlSystemSeting.Padding = new System.Drawing.Point(20, 3);
            this.tabControlSystemSeting.SelectedIndex = 0;
            this.tabControlSystemSeting.Size = new System.Drawing.Size(777, 576);
            this.tabControlSystemSeting.TabIndex = 0;
            // 
            // SystemSetPageRobot
            // 
            this.SystemSetPageRobot.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.SystemSetPageRobot.Controls.Add(this.CTextBoxSysSetRobotIP);
            this.SystemSetPageRobot.Controls.Add(this.customLabel1);
            this.SystemSetPageRobot.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.SystemSetPageRobot.ForeColor = System.Drawing.Color.White;
            this.SystemSetPageRobot.Location = new System.Drawing.Point(0, 29);
            this.SystemSetPageRobot.Margin = new System.Windows.Forms.Padding(0);
            this.SystemSetPageRobot.Name = "SystemSetPageRobot";
            this.SystemSetPageRobot.Padding = new System.Windows.Forms.Padding(2);
            this.SystemSetPageRobot.Size = new System.Drawing.Size(777, 547);
            this.SystemSetPageRobot.TabIndex = 0;
            this.SystemSetPageRobot.Text = "机械臂";
            // 
            // CTextBoxSysSetRobotIP
            // 
            this.CTextBoxSysSetRobotIP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.CTextBoxSysSetRobotIP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CTextBoxSysSetRobotIP.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.CTextBoxSysSetRobotIP.ForeColor = System.Drawing.Color.White;
            this.CTextBoxSysSetRobotIP.Location = new System.Drawing.Point(136, 43);
            this.CTextBoxSysSetRobotIP.Multiline = true;
            this.CTextBoxSysSetRobotIP.Name = "CTextBoxSysSetRobotIP";
            this.CTextBoxSysSetRobotIP.Size = new System.Drawing.Size(131, 29);
            this.CTextBoxSysSetRobotIP.TabIndex = 1;
            this.CTextBoxSysSetRobotIP.Text = "192.168.1.124";
            this.CTextBoxSysSetRobotIP.TextChanged += new System.EventHandler(this.CTextBoxSysSetRobotIP_TextChanged);
            // 
            // customLabel1
            // 
            this.customLabel1.AutoSize = true;
            this.customLabel1.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.customLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.customLabel1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.customLabel1.Location = new System.Drawing.Point(52, 45);
            this.customLabel1.Name = "customLabel1";
            this.customLabel1.Size = new System.Drawing.Size(81, 23);
            this.customLabel1.TabIndex = 0;
            this.customLabel1.Text = "IP 地址：";
            // 
            // SystemSetPageCamera
            // 
            this.SystemSetPageCamera.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.SystemSetPageCamera.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.SystemSetPageCamera.ForeColor = System.Drawing.Color.White;
            this.SystemSetPageCamera.Location = new System.Drawing.Point(0, 29);
            this.SystemSetPageCamera.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.SystemSetPageCamera.Name = "SystemSetPageCamera";
            this.SystemSetPageCamera.Size = new System.Drawing.Size(777, 547);
            this.SystemSetPageCamera.TabIndex = 1;
            this.SystemSetPageCamera.Text = "相机";
            // 
            // SystemSetPageOthers
            // 
            this.SystemSetPageOthers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.SystemSetPageOthers.Controls.Add(this.ComBoxSysLanguage);
            this.SystemSetPageOthers.Controls.Add(this.CLabelSysLanguage);
            this.SystemSetPageOthers.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.SystemSetPageOthers.ForeColor = System.Drawing.Color.White;
            this.SystemSetPageOthers.Location = new System.Drawing.Point(0, 29);
            this.SystemSetPageOthers.Name = "SystemSetPageOthers";
            this.SystemSetPageOthers.Size = new System.Drawing.Size(777, 547);
            this.SystemSetPageOthers.TabIndex = 2;
            this.SystemSetPageOthers.Text = "其他";
            // 
            // ComBoxSysLanguage
            // 
            this.ComBoxSysLanguage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.ComBoxSysLanguage.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ComBoxSysLanguage.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.ComBoxSysLanguage.ForeColor = System.Drawing.Color.White;
            this.ComBoxSysLanguage.FormattingEnabled = true;
            this.ComBoxSysLanguage.Items.AddRange(new object[] {
            "中文",
            "英文"});
            this.ComBoxSysLanguage.Location = new System.Drawing.Point(125, 20);
            this.ComBoxSysLanguage.Name = "ComBoxSysLanguage";
            this.ComBoxSysLanguage.Size = new System.Drawing.Size(121, 29);
            this.ComBoxSysLanguage.TabIndex = 1;
            this.ComBoxSysLanguage.SelectedIndexChanged += new System.EventHandler(this.ComBoxSysLanguage_SelectedIndexChanged);
            // 
            // CLabelSysLanguage
            // 
            this.CLabelSysLanguage.AutoSize = true;
            this.CLabelSysLanguage.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.CLabelSysLanguage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.CLabelSysLanguage.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.CLabelSysLanguage.Location = new System.Drawing.Point(24, 21);
            this.CLabelSysLanguage.Name = "CLabelSysLanguage";
            this.CLabelSysLanguage.Size = new System.Drawing.Size(95, 23);
            this.CLabelSysLanguage.TabIndex = 0;
            this.CLabelSysLanguage.Text = "系统语言：";
            // 
            // SystemSetingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.ClientSize = new System.Drawing.Size(1260, 830);
            this.ControlBox = false;
            this.Controls.Add(this.tabControlSystemSeting);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("宋体", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Location = new System.Drawing.Point(180, 70);
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SystemSetingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "SystemSeting";
            this.Load += new System.EventHandler(this.SystemSeting_Load);
            this.tabControlSystemSeting.ResumeLayout(false);
            this.SystemSetPageRobot.ResumeLayout(false);
            this.SystemSetPageRobot.PerformLayout();
            this.SystemSetPageOthers.ResumeLayout(false);
            this.SystemSetPageOthers.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private CustomTabControl tabControlSystemSeting;
        private System.Windows.Forms.TabPage SystemSetPageRobot;
        private System.Windows.Forms.TabPage SystemSetPageCamera;
        private CustomTextBox CTextBoxSysSetRobotIP;
        private CustomLabel customLabel1;
        private System.Windows.Forms.TabPage SystemSetPageOthers;
        private System.Windows.Forms.ComboBox ComBoxSysLanguage;
        private CustomLabel CLabelSysLanguage;
    }
}