namespace RobotWorkstation
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
            this.CGroupBoxSysLanguage = new RobotWorkstation.CustomGroupBox();
            this.customLabel2 = new RobotWorkstation.CustomLabel();
            this.ComBoxSysLanguage = new System.Windows.Forms.ComboBox();
            this.SystemSetPageOthers = new System.Windows.Forms.TabPage();
            this.tabControlSystemSeting.SuspendLayout();
            this.SystemSetPageRobot.SuspendLayout();
            this.CGroupBoxSysLanguage.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlSystemSeting
            // 
            this.tabControlSystemSeting.Controls.Add(this.SystemSetPageRobot);
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
            this.SystemSetPageRobot.Controls.Add(this.CGroupBoxSysLanguage);
            this.SystemSetPageRobot.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.SystemSetPageRobot.ForeColor = System.Drawing.Color.White;
            this.SystemSetPageRobot.Location = new System.Drawing.Point(0, 29);
            this.SystemSetPageRobot.Margin = new System.Windows.Forms.Padding(0);
            this.SystemSetPageRobot.Name = "SystemSetPageRobot";
            this.SystemSetPageRobot.Padding = new System.Windows.Forms.Padding(2);
            this.SystemSetPageRobot.Size = new System.Drawing.Size(777, 547);
            this.SystemSetPageRobot.TabIndex = 0;
            this.SystemSetPageRobot.Text = "系统设置";
            // 
            // CGroupBoxSysLanguage
            // 
            this.CGroupBoxSysLanguage.Controls.Add(this.customLabel2);
            this.CGroupBoxSysLanguage.Controls.Add(this.ComBoxSysLanguage);
            this.CGroupBoxSysLanguage.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.CGroupBoxSysLanguage.Location = new System.Drawing.Point(5, 21);
            this.CGroupBoxSysLanguage.Name = "CGroupBoxSysLanguage";
            this.CGroupBoxSysLanguage.Size = new System.Drawing.Size(282, 91);
            this.CGroupBoxSysLanguage.TabIndex = 5;
            this.CGroupBoxSysLanguage.TabStop = false;
            this.CGroupBoxSysLanguage.Text = "系统语言";
            // 
            // customLabel2
            // 
            this.customLabel2.AutoSize = true;
            this.customLabel2.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.customLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.customLabel2.Location = new System.Drawing.Point(18, 40);
            this.customLabel2.Name = "customLabel2";
            this.customLabel2.Size = new System.Drawing.Size(95, 23);
            this.customLabel2.TabIndex = 3;
            this.customLabel2.Text = "系统语言：";
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
            this.ComBoxSysLanguage.Location = new System.Drawing.Point(125, 38);
            this.ComBoxSysLanguage.Name = "ComBoxSysLanguage";
            this.ComBoxSysLanguage.Size = new System.Drawing.Size(131, 29);
            this.ComBoxSysLanguage.TabIndex = 2;
            this.ComBoxSysLanguage.SelectedIndexChanged += new System.EventHandler(this.ComBoxSysLanguage_SelectedIndexChanged);
            // 
            // SystemSetPageOthers
            // 
            this.SystemSetPageOthers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.SystemSetPageOthers.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.SystemSetPageOthers.ForeColor = System.Drawing.Color.White;
            this.SystemSetPageOthers.Location = new System.Drawing.Point(0, 29);
            this.SystemSetPageOthers.Name = "SystemSetPageOthers";
            this.SystemSetPageOthers.Size = new System.Drawing.Size(777, 547);
            this.SystemSetPageOthers.TabIndex = 2;
            this.SystemSetPageOthers.Text = "其他";
            // 
            // SystemSetingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.ClientSize = new System.Drawing.Size(1260, 830);
            this.ControlBox = false;
            this.Controls.Add(this.tabControlSystemSeting);
            this.Font = new System.Drawing.Font("宋体", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Location = new System.Drawing.Point(180, 70);
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SystemSetingForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "SystemSeting";
            this.Load += new System.EventHandler(this.SystemSeting_Load);
            this.tabControlSystemSeting.ResumeLayout(false);
            this.SystemSetPageRobot.ResumeLayout(false);
            this.CGroupBoxSysLanguage.ResumeLayout(false);
            this.CGroupBoxSysLanguage.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private CustomTabControl tabControlSystemSeting;
        private System.Windows.Forms.TabPage SystemSetPageRobot;
        private System.Windows.Forms.TabPage SystemSetPageOthers;
        private CustomGroupBox CGroupBoxSysLanguage;
        private System.Windows.Forms.ComboBox ComBoxSysLanguage;
        private CustomLabel customLabel2;
    }
}