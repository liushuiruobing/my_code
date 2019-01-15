namespace ArmController
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.TextBoxIp = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TextBoxPort = new System.Windows.Forms.TextBox();
            this.BtnCreateServer = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.UpdateProcessBar = new System.Windows.Forms.ProgressBar();
            this.UpdateOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.TimerConnectServer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 55);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "IP:";
            // 
            // TextBoxIp
            // 
            this.TextBoxIp.Location = new System.Drawing.Point(81, 51);
            this.TextBoxIp.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TextBoxIp.Name = "TextBoxIp";
            this.TextBoxIp.Size = new System.Drawing.Size(148, 25);
            this.TextBoxIp.TabIndex = 1;
            this.TextBoxIp.Text = "127.0.0.1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(251, 55);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Port:";
            // 
            // TextBoxPort
            // 
            this.TextBoxPort.Location = new System.Drawing.Point(305, 51);
            this.TextBoxPort.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TextBoxPort.Name = "TextBoxPort";
            this.TextBoxPort.Size = new System.Drawing.Size(108, 25);
            this.TextBoxPort.TabIndex = 3;
            this.TextBoxPort.Text = "20001";
            // 
            // BtnCreateServer
            // 
            this.BtnCreateServer.Location = new System.Drawing.Point(460, 49);
            this.BtnCreateServer.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BtnCreateServer.Name = "BtnCreateServer";
            this.BtnCreateServer.Size = new System.Drawing.Size(100, 29);
            this.BtnCreateServer.TabIndex = 4;
            this.BtnCreateServer.Text = "创建服务";
            this.BtnCreateServer.UseVisualStyleBackColor = true;
            this.BtnCreateServer.Click += new System.EventHandler(this.BtnCreateServer_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(43, 110);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "进度：";
            // 
            // UpdateProcessBar
            // 
            this.UpdateProcessBar.Location = new System.Drawing.Point(105, 104);
            this.UpdateProcessBar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.UpdateProcessBar.Name = "UpdateProcessBar";
            this.UpdateProcessBar.Size = new System.Drawing.Size(455, 29);
            this.UpdateProcessBar.TabIndex = 6;
            // 
            // UpdateOpenFileDialog
            // 
            this.UpdateOpenFileDialog.FileName = ".bin";
            // 
            // TimerConnectServer
            // 
            this.TimerConnectServer.Interval = 500;
            this.TimerConnectServer.Tick += new System.EventHandler(this.TimerConnectServer_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(597, 222);
            this.Controls.Add(this.UpdateProcessBar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.BtnCreateServer);
            this.Controls.Add(this.TextBoxPort);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TextBoxIp);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "MainForm";
            this.Text = "模拟单片机服务器";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TextBoxIp;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TextBoxPort;
        private System.Windows.Forms.Button BtnCreateServer;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ProgressBar UpdateProcessBar;
        private System.Windows.Forms.OpenFileDialog UpdateOpenFileDialog;
        private System.Windows.Forms.Timer TimerConnectServer;
    }
}

