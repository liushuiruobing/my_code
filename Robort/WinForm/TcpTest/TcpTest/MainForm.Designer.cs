namespace TcpTest
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxIp = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxPort = new System.Windows.Forms.TextBox();
            this.BtnConnect = new System.Windows.Forms.Button();
            this.BtnDisConnect = new System.Windows.Forms.Button();
            this.textBoxSend = new System.Windows.Forms.TextBox();
            this.textBoxRecv = new System.Windows.Forms.TextBox();
            this.BtnSend = new System.Windows.Forms.Button();
            this.BtnClear = new System.Windows.Forms.Button();
            this.BtnCreateServer = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(55, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "IP:";
            // 
            // textBoxIp
            // 
            this.textBoxIp.Location = new System.Drawing.Point(84, 27);
            this.textBoxIp.Name = "textBoxIp";
            this.textBoxIp.Size = new System.Drawing.Size(100, 21);
            this.textBoxIp.TabIndex = 1;
            this.textBoxIp.Text = "192.168.81.11";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(43, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "Port:";
            // 
            // textBoxPort
            // 
            this.textBoxPort.Location = new System.Drawing.Point(84, 61);
            this.textBoxPort.Name = "textBoxPort";
            this.textBoxPort.Size = new System.Drawing.Size(100, 21);
            this.textBoxPort.TabIndex = 3;
            this.textBoxPort.Text = "5025";
            // 
            // BtnConnect
            // 
            this.BtnConnect.Location = new System.Drawing.Point(366, 29);
            this.BtnConnect.Name = "BtnConnect";
            this.BtnConnect.Size = new System.Drawing.Size(75, 23);
            this.BtnConnect.TabIndex = 4;
            this.BtnConnect.Text = "连接";
            this.BtnConnect.UseVisualStyleBackColor = true;
            this.BtnConnect.Click += new System.EventHandler(this.BtnConnect_Click);
            // 
            // BtnDisConnect
            // 
            this.BtnDisConnect.Location = new System.Drawing.Point(464, 29);
            this.BtnDisConnect.Name = "BtnDisConnect";
            this.BtnDisConnect.Size = new System.Drawing.Size(75, 23);
            this.BtnDisConnect.TabIndex = 5;
            this.BtnDisConnect.Text = "断开";
            this.BtnDisConnect.UseVisualStyleBackColor = true;
            this.BtnDisConnect.Click += new System.EventHandler(this.BtnDisConnect_Click);
            // 
            // textBoxSend
            // 
            this.textBoxSend.Location = new System.Drawing.Point(45, 121);
            this.textBoxSend.Multiline = true;
            this.textBoxSend.Name = "textBoxSend";
            this.textBoxSend.Size = new System.Drawing.Size(303, 177);
            this.textBoxSend.TabIndex = 6;
            // 
            // textBoxRecv
            // 
            this.textBoxRecv.Location = new System.Drawing.Point(366, 121);
            this.textBoxRecv.Multiline = true;
            this.textBoxRecv.Name = "textBoxRecv";
            this.textBoxRecv.Size = new System.Drawing.Size(296, 177);
            this.textBoxRecv.TabIndex = 7;
            // 
            // BtnSend
            // 
            this.BtnSend.Location = new System.Drawing.Point(142, 325);
            this.BtnSend.Name = "BtnSend";
            this.BtnSend.Size = new System.Drawing.Size(75, 23);
            this.BtnSend.TabIndex = 8;
            this.BtnSend.Text = "发送";
            this.BtnSend.UseVisualStyleBackColor = true;
            this.BtnSend.Click += new System.EventHandler(this.BtnSend_Click);
            // 
            // BtnClear
            // 
            this.BtnClear.Location = new System.Drawing.Point(498, 325);
            this.BtnClear.Name = "BtnClear";
            this.BtnClear.Size = new System.Drawing.Size(75, 23);
            this.BtnClear.TabIndex = 9;
            this.BtnClear.Text = "清除";
            this.BtnClear.UseVisualStyleBackColor = true;
            this.BtnClear.Click += new System.EventHandler(this.BtnClear_Click);
            // 
            // BtnCreateServer
            // 
            this.BtnCreateServer.Location = new System.Drawing.Point(563, 29);
            this.BtnCreateServer.Name = "BtnCreateServer";
            this.BtnCreateServer.Size = new System.Drawing.Size(75, 23);
            this.BtnCreateServer.TabIndex = 10;
            this.BtnCreateServer.Text = "创建服务器";
            this.BtnCreateServer.UseVisualStyleBackColor = true;
            this.BtnCreateServer.Click += new System.EventHandler(this.BtnCreateServer_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(710, 373);
            this.Controls.Add(this.BtnCreateServer);
            this.Controls.Add(this.BtnClear);
            this.Controls.Add(this.BtnSend);
            this.Controls.Add(this.textBoxRecv);
            this.Controls.Add(this.textBoxSend);
            this.Controls.Add(this.BtnDisConnect);
            this.Controls.Add(this.BtnConnect);
            this.Controls.Add(this.textBoxPort);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxIp);
            this.Controls.Add(this.label1);
            this.Name = "MainForm";
            this.Text = "Tcp测试";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxIp;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxPort;
        private System.Windows.Forms.Button BtnConnect;
        private System.Windows.Forms.Button BtnDisConnect;
        private System.Windows.Forms.TextBox textBoxSend;
        private System.Windows.Forms.TextBox textBoxRecv;
        private System.Windows.Forms.Button BtnSend;
        private System.Windows.Forms.Button BtnClear;
        private System.Windows.Forms.Button BtnCreateServer;
    }
}

