namespace RobotWorkstation
{
    partial class ManualDebug
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
            this.tabControl_ManualDebug = new RobotWorkstation.CustomTabControl();
            this.tabPage_Robot = new System.Windows.Forms.TabPage();
            this.groupBox_Robot = new RobotWorkstation.CustomGroupBox();
            this.pictureBox_Servo = new System.Windows.Forms.PictureBox();
            this.label1 = new RobotWorkstation.CustomLabel();
            this.tabPage_Camera = new System.Windows.Forms.TabPage();
            this.tabControl_ManualDebug.SuspendLayout();
            this.tabPage_Robot.SuspendLayout();
            this.groupBox_Robot.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Servo)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl_ManualDebug
            // 
            this.tabControl_ManualDebug.Controls.Add(this.tabPage_Robot);
            this.tabControl_ManualDebug.Controls.Add(this.tabPage_Camera);
            this.tabControl_ManualDebug.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabControl_ManualDebug.ItemSize = new System.Drawing.Size(120, 26);
            this.tabControl_ManualDebug.Location = new System.Drawing.Point(12, 12);
            this.tabControl_ManualDebug.Margin = new System.Windows.Forms.Padding(0);
            this.tabControl_ManualDebug.Name = "tabControl_ManualDebug";
            this.tabControl_ManualDebug.Padding = new System.Drawing.Point(20, 3);
            this.tabControl_ManualDebug.SelectedIndex = 0;
            this.tabControl_ManualDebug.Size = new System.Drawing.Size(1410, 790);
            this.tabControl_ManualDebug.TabIndex = 0;
            // 
            // tabPage_Robot
            // 
            this.tabPage_Robot.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.tabPage_Robot.Controls.Add(this.groupBox_Robot);
            this.tabPage_Robot.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabPage_Robot.Location = new System.Drawing.Point(0, 29);
            this.tabPage_Robot.Name = "tabPage_Robot";
            this.tabPage_Robot.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Robot.Size = new System.Drawing.Size(1410, 761);
            this.tabPage_Robot.TabIndex = 0;
            this.tabPage_Robot.Text = "机械臂";
            // 
            // groupBox_Robot
            // 
            this.groupBox_Robot.Controls.Add(this.pictureBox_Servo);
            this.groupBox_Robot.Controls.Add(this.label1);
            this.groupBox_Robot.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox_Robot.ForeColor = System.Drawing.Color.White;
            this.groupBox_Robot.Location = new System.Drawing.Point(10, 10);
            this.groupBox_Robot.Name = "groupBox_Robot";
            this.groupBox_Robot.Size = new System.Drawing.Size(1200, 600);
            this.groupBox_Robot.TabIndex = 0;
            this.groupBox_Robot.TabStop = false;
            this.groupBox_Robot.Text = "机械臂";
            // 
            // pictureBox_Servo
            // 
            this.pictureBox_Servo.Image = global::RobotWorkstation.Properties.Resources.SmallDarkGreen;
            this.pictureBox_Servo.Location = new System.Drawing.Point(110, 54);
            this.pictureBox_Servo.Name = "pictureBox_Servo";
            this.pictureBox_Servo.Size = new System.Drawing.Size(22, 22);
            this.pictureBox_Servo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_Servo.TabIndex = 1;
            this.pictureBox_Servo.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.label1.Location = new System.Drawing.Point(44, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "伺服：";
            // 
            // tabPage_Camera
            // 
            this.tabPage_Camera.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.tabPage_Camera.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabPage_Camera.Location = new System.Drawing.Point(0, 29);
            this.tabPage_Camera.Name = "tabPage_Camera";
            this.tabPage_Camera.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Camera.Size = new System.Drawing.Size(1410, 761);
            this.tabPage_Camera.TabIndex = 1;
            this.tabPage_Camera.Text = "相机";
            // 
            // ManualDebug
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.ClientSize = new System.Drawing.Size(1410, 790);
            this.ControlBox = false;
            this.Controls.Add(this.tabControl_ManualDebug);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Location = new System.Drawing.Point(180, 70);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ManualDebug";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Load += new System.EventHandler(this.ManualDebug_Load);
            this.tabControl_ManualDebug.ResumeLayout(false);
            this.tabPage_Robot.ResumeLayout(false);
            this.groupBox_Robot.ResumeLayout(false);
            this.groupBox_Robot.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Servo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CustomTabControl tabControl_ManualDebug;
        private System.Windows.Forms.TabPage tabPage_Robot;
        private System.Windows.Forms.TabPage tabPage_Camera;
        private CustomGroupBox groupBox_Robot;
        private CustomLabel label1;
        private System.Windows.Forms.PictureBox pictureBox_Servo;
    }
}