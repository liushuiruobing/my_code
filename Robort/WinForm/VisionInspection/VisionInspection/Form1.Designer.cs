namespace VisionInspection
{
    partial class FormMain
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
            this.CameraPictureBox = new System.Windows.Forms.PictureBox();
            this.button_FindCamera = new System.Windows.Forms.Button();
            this.groupBox_Camera = new System.Windows.Forms.GroupBox();
            this.button_GetCarmeraParam = new System.Windows.Forms.Button();
            this.button_SetCameraParam = new System.Windows.Forms.Button();
            this.textBox_FrameRate = new System.Windows.Forms.TextBox();
            this.textBox_Gain = new System.Windows.Forms.TextBox();
            this.textBox_Exposure = new System.Windows.Forms.TextBox();
            this.label_FrameRate = new System.Windows.Forms.Label();
            this.label_Gain = new System.Windows.Forms.Label();
            this.label_Exposure = new System.Windows.Forms.Label();
            this.button_CloseCamera = new System.Windows.Forms.Button();
            this.button_OpenCamera = new System.Windows.Forms.Button();
            this.groupBox_VisionTest = new System.Windows.Forms.GroupBox();
            this.textBox_TestEndY = new System.Windows.Forms.TextBox();
            this.button_AnalyzeArea = new System.Windows.Forms.Button();
            this.textBox_TestEndX = new System.Windows.Forms.TextBox();
            this.button_LoadPicture = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_TestStartX = new System.Windows.Forms.TextBox();
            this.textBox_TestStartY = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox_Meas = new System.Windows.Forms.GroupBox();
            this.label_HintMeas = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.textBox_CurZ = new System.Windows.Forms.TextBox();
            this.textBox_CurY = new System.Windows.Forms.TextBox();
            this.textBox_CurX = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.button_RobotRun = new System.Windows.Forms.Button();
            this.textBox_Robot_Z = new System.Windows.Forms.TextBox();
            this.textBox_Robot_Y = new System.Windows.Forms.TextBox();
            this.textBox_Robot_X = new System.Windows.Forms.TextBox();
            this.lablez = new System.Windows.Forms.Label();
            this.lable = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.timer_Robot = new System.Windows.Forms.Timer(this.components);
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.textBox_CurRZ = new System.Windows.Forms.TextBox();
            this.textBox_Robot_RZ = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.CameraPictureBox)).BeginInit();
            this.groupBox_Camera.SuspendLayout();
            this.groupBox_VisionTest.SuspendLayout();
            this.groupBox_Meas.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // CameraPictureBox
            // 
            this.CameraPictureBox.BackColor = System.Drawing.Color.Gray;
            this.CameraPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CameraPictureBox.Location = new System.Drawing.Point(1, 2);
            this.CameraPictureBox.Name = "CameraPictureBox";
            this.CameraPictureBox.Size = new System.Drawing.Size(700, 660);
            this.CameraPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.CameraPictureBox.TabIndex = 0;
            this.CameraPictureBox.TabStop = false;
            this.CameraPictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CameraPictureBox_MouseDown);
            this.CameraPictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.CameraPictureBox_MouseMove);
            this.CameraPictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.CameraPictureBox_MouseUp);
            // 
            // button_FindCamera
            // 
            this.button_FindCamera.Location = new System.Drawing.Point(24, 20);
            this.button_FindCamera.Name = "button_FindCamera";
            this.button_FindCamera.Size = new System.Drawing.Size(79, 23);
            this.button_FindCamera.TabIndex = 1;
            this.button_FindCamera.Text = "查找设备";
            this.button_FindCamera.UseVisualStyleBackColor = true;
            this.button_FindCamera.Click += new System.EventHandler(this.button_FindCamera_Click);
            // 
            // groupBox_Camera
            // 
            this.groupBox_Camera.Controls.Add(this.button_GetCarmeraParam);
            this.groupBox_Camera.Controls.Add(this.button_SetCameraParam);
            this.groupBox_Camera.Controls.Add(this.textBox_FrameRate);
            this.groupBox_Camera.Controls.Add(this.textBox_Gain);
            this.groupBox_Camera.Controls.Add(this.textBox_Exposure);
            this.groupBox_Camera.Controls.Add(this.label_FrameRate);
            this.groupBox_Camera.Controls.Add(this.label_Gain);
            this.groupBox_Camera.Controls.Add(this.label_Exposure);
            this.groupBox_Camera.Controls.Add(this.button_CloseCamera);
            this.groupBox_Camera.Controls.Add(this.button_OpenCamera);
            this.groupBox_Camera.Controls.Add(this.button_FindCamera);
            this.groupBox_Camera.Location = new System.Drawing.Point(709, 12);
            this.groupBox_Camera.Name = "groupBox_Camera";
            this.groupBox_Camera.Size = new System.Drawing.Size(287, 153);
            this.groupBox_Camera.TabIndex = 2;
            this.groupBox_Camera.TabStop = false;
            this.groupBox_Camera.Text = "相机设置";
            // 
            // button_GetCarmeraParam
            // 
            this.button_GetCarmeraParam.Location = new System.Drawing.Point(219, 115);
            this.button_GetCarmeraParam.Name = "button_GetCarmeraParam";
            this.button_GetCarmeraParam.Size = new System.Drawing.Size(54, 23);
            this.button_GetCarmeraParam.TabIndex = 11;
            this.button_GetCarmeraParam.Text = "获取";
            this.button_GetCarmeraParam.UseVisualStyleBackColor = true;
            this.button_GetCarmeraParam.Click += new System.EventHandler(this.button_GetCarmeraParam_Click);
            // 
            // button_SetCameraParam
            // 
            this.button_SetCameraParam.Location = new System.Drawing.Point(137, 115);
            this.button_SetCameraParam.Name = "button_SetCameraParam";
            this.button_SetCameraParam.Size = new System.Drawing.Size(54, 23);
            this.button_SetCameraParam.TabIndex = 10;
            this.button_SetCameraParam.Text = "设置";
            this.button_SetCameraParam.UseVisualStyleBackColor = true;
            this.button_SetCameraParam.Click += new System.EventHandler(this.button_SetCameraParam_Click);
            // 
            // textBox_FrameRate
            // 
            this.textBox_FrameRate.Location = new System.Drawing.Point(173, 82);
            this.textBox_FrameRate.Name = "textBox_FrameRate";
            this.textBox_FrameRate.Size = new System.Drawing.Size(100, 21);
            this.textBox_FrameRate.TabIndex = 9;
            this.textBox_FrameRate.Text = "1000";
            // 
            // textBox_Gain
            // 
            this.textBox_Gain.Location = new System.Drawing.Point(173, 51);
            this.textBox_Gain.Name = "textBox_Gain";
            this.textBox_Gain.Size = new System.Drawing.Size(100, 21);
            this.textBox_Gain.TabIndex = 8;
            this.textBox_Gain.Text = "1000";
            // 
            // textBox_Exposure
            // 
            this.textBox_Exposure.Location = new System.Drawing.Point(173, 22);
            this.textBox_Exposure.Name = "textBox_Exposure";
            this.textBox_Exposure.Size = new System.Drawing.Size(100, 21);
            this.textBox_Exposure.TabIndex = 7;
            this.textBox_Exposure.Text = "1000";
            // 
            // label_FrameRate
            // 
            this.label_FrameRate.AutoSize = true;
            this.label_FrameRate.Location = new System.Drawing.Point(134, 86);
            this.label_FrameRate.Name = "label_FrameRate";
            this.label_FrameRate.Size = new System.Drawing.Size(41, 12);
            this.label_FrameRate.TabIndex = 6;
            this.label_FrameRate.Text = "帧率：";
            // 
            // label_Gain
            // 
            this.label_Gain.AutoSize = true;
            this.label_Gain.Location = new System.Drawing.Point(134, 54);
            this.label_Gain.Name = "label_Gain";
            this.label_Gain.Size = new System.Drawing.Size(41, 12);
            this.label_Gain.TabIndex = 5;
            this.label_Gain.Text = "增益：";
            // 
            // label_Exposure
            // 
            this.label_Exposure.AutoSize = true;
            this.label_Exposure.Location = new System.Drawing.Point(134, 25);
            this.label_Exposure.Name = "label_Exposure";
            this.label_Exposure.Size = new System.Drawing.Size(41, 12);
            this.label_Exposure.TabIndex = 4;
            this.label_Exposure.Text = "曝光：";
            // 
            // button_CloseCamera
            // 
            this.button_CloseCamera.Location = new System.Drawing.Point(24, 115);
            this.button_CloseCamera.Name = "button_CloseCamera";
            this.button_CloseCamera.Size = new System.Drawing.Size(79, 23);
            this.button_CloseCamera.TabIndex = 3;
            this.button_CloseCamera.Text = "关闭设备";
            this.button_CloseCamera.UseVisualStyleBackColor = true;
            this.button_CloseCamera.Click += new System.EventHandler(this.button_CloseCamera_Click);
            // 
            // button_OpenCamera
            // 
            this.button_OpenCamera.Location = new System.Drawing.Point(24, 67);
            this.button_OpenCamera.Name = "button_OpenCamera";
            this.button_OpenCamera.Size = new System.Drawing.Size(79, 23);
            this.button_OpenCamera.TabIndex = 2;
            this.button_OpenCamera.Text = "打开设备";
            this.button_OpenCamera.UseVisualStyleBackColor = true;
            this.button_OpenCamera.Click += new System.EventHandler(this.button_OpenCamera_Click);
            // 
            // groupBox_VisionTest
            // 
            this.groupBox_VisionTest.Controls.Add(this.textBox_TestEndY);
            this.groupBox_VisionTest.Controls.Add(this.button_AnalyzeArea);
            this.groupBox_VisionTest.Controls.Add(this.textBox_TestEndX);
            this.groupBox_VisionTest.Controls.Add(this.button_LoadPicture);
            this.groupBox_VisionTest.Controls.Add(this.label6);
            this.groupBox_VisionTest.Controls.Add(this.label1);
            this.groupBox_VisionTest.Controls.Add(this.label5);
            this.groupBox_VisionTest.Controls.Add(this.label2);
            this.groupBox_VisionTest.Controls.Add(this.label4);
            this.groupBox_VisionTest.Controls.Add(this.textBox_TestStartX);
            this.groupBox_VisionTest.Controls.Add(this.textBox_TestStartY);
            this.groupBox_VisionTest.Controls.Add(this.label3);
            this.groupBox_VisionTest.Location = new System.Drawing.Point(709, 171);
            this.groupBox_VisionTest.Name = "groupBox_VisionTest";
            this.groupBox_VisionTest.Size = new System.Drawing.Size(287, 155);
            this.groupBox_VisionTest.TabIndex = 3;
            this.groupBox_VisionTest.TabStop = false;
            this.groupBox_VisionTest.Text = "视觉测试";
            // 
            // textBox_TestEndY
            // 
            this.textBox_TestEndY.Location = new System.Drawing.Point(193, 74);
            this.textBox_TestEndY.Name = "textBox_TestEndY";
            this.textBox_TestEndY.Size = new System.Drawing.Size(56, 21);
            this.textBox_TestEndY.TabIndex = 9;
            // 
            // button_AnalyzeArea
            // 
            this.button_AnalyzeArea.Location = new System.Drawing.Point(177, 114);
            this.button_AnalyzeArea.Name = "button_AnalyzeArea";
            this.button_AnalyzeArea.Size = new System.Drawing.Size(75, 23);
            this.button_AnalyzeArea.TabIndex = 1;
            this.button_AnalyzeArea.Text = "分析区域";
            this.button_AnalyzeArea.UseVisualStyleBackColor = true;
            this.button_AnalyzeArea.Click += new System.EventHandler(this.button_AnalyzeArea_Click);
            // 
            // textBox_TestEndX
            // 
            this.textBox_TestEndX.Location = new System.Drawing.Point(108, 74);
            this.textBox_TestEndX.Name = "textBox_TestEndX";
            this.textBox_TestEndX.Size = new System.Drawing.Size(56, 21);
            this.textBox_TestEndX.TabIndex = 8;
            // 
            // button_LoadPicture
            // 
            this.button_LoadPicture.Location = new System.Drawing.Point(35, 114);
            this.button_LoadPicture.Name = "button_LoadPicture";
            this.button_LoadPicture.Size = new System.Drawing.Size(75, 23);
            this.button_LoadPicture.TabIndex = 0;
            this.button_LoadPicture.Text = "载入图片";
            this.button_LoadPicture.UseVisualStyleBackColor = true;
            this.button_LoadPicture.Click += new System.EventHandler(this.button_LoadPicture_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(175, 78);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(11, 12);
            this.label6.TabIndex = 7;
            this.label6.Text = "Y";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "起始点：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(92, 78);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(11, 12);
            this.label5.TabIndex = 6;
            this.label5.Text = "X";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(92, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(11, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "X";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(33, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 5;
            this.label4.Text = "终止点：";
            // 
            // textBox_TestStartX
            // 
            this.textBox_TestStartX.Location = new System.Drawing.Point(109, 35);
            this.textBox_TestStartX.Name = "textBox_TestStartX";
            this.textBox_TestStartX.Size = new System.Drawing.Size(56, 21);
            this.textBox_TestStartX.TabIndex = 2;
            // 
            // textBox_TestStartY
            // 
            this.textBox_TestStartY.Location = new System.Drawing.Point(195, 35);
            this.textBox_TestStartY.Name = "textBox_TestStartY";
            this.textBox_TestStartY.Size = new System.Drawing.Size(56, 21);
            this.textBox_TestStartY.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(178, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(11, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "Y";
            // 
            // groupBox_Meas
            // 
            this.groupBox_Meas.Controls.Add(this.label_HintMeas);
            this.groupBox_Meas.Controls.Add(this.label7);
            this.groupBox_Meas.Location = new System.Drawing.Point(1, 668);
            this.groupBox_Meas.Name = "groupBox_Meas";
            this.groupBox_Meas.Size = new System.Drawing.Size(700, 50);
            this.groupBox_Meas.TabIndex = 4;
            this.groupBox_Meas.TabStop = false;
            this.groupBox_Meas.Text = "提示信息";
            // 
            // label_HintMeas
            // 
            this.label_HintMeas.AutoSize = true;
            this.label_HintMeas.Location = new System.Drawing.Point(61, 26);
            this.label_HintMeas.Name = "label_HintMeas";
            this.label_HintMeas.Size = new System.Drawing.Size(29, 12);
            this.label_HintMeas.TabIndex = 1;
            this.label_HintMeas.Text = "None";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(11, 26);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 0;
            this.label7.Text = "当前：";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox_Robot_RZ);
            this.groupBox1.Controls.Add(this.textBox_CurRZ);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.textBox_CurZ);
            this.groupBox1.Controls.Add(this.textBox_CurY);
            this.groupBox1.Controls.Add(this.textBox_CurX);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.button_RobotRun);
            this.groupBox1.Controls.Add(this.textBox_Robot_Z);
            this.groupBox1.Controls.Add(this.textBox_Robot_Y);
            this.groupBox1.Controls.Add(this.textBox_Robot_X);
            this.groupBox1.Controls.Add(this.lablez);
            this.groupBox1.Controls.Add(this.lable);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Location = new System.Drawing.Point(709, 348);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(287, 210);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "机械臂测试";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(193, 26);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(53, 12);
            this.label13.TabIndex = 14;
            this.label13.Text = "当前点位";
            // 
            // textBox_CurZ
            // 
            this.textBox_CurZ.Location = new System.Drawing.Point(192, 106);
            this.textBox_CurZ.Name = "textBox_CurZ";
            this.textBox_CurZ.ReadOnly = true;
            this.textBox_CurZ.Size = new System.Drawing.Size(85, 21);
            this.textBox_CurZ.TabIndex = 13;
            // 
            // textBox_CurY
            // 
            this.textBox_CurY.Location = new System.Drawing.Point(192, 78);
            this.textBox_CurY.Name = "textBox_CurY";
            this.textBox_CurY.ReadOnly = true;
            this.textBox_CurY.Size = new System.Drawing.Size(85, 21);
            this.textBox_CurY.TabIndex = 12;
            // 
            // textBox_CurX
            // 
            this.textBox_CurX.Location = new System.Drawing.Point(192, 50);
            this.textBox_CurX.Name = "textBox_CurX";
            this.textBox_CurX.ReadOnly = true;
            this.textBox_CurX.Size = new System.Drawing.Size(85, 21);
            this.textBox_CurX.TabIndex = 11;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(169, 110);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(17, 12);
            this.label10.TabIndex = 10;
            this.label10.Text = "Z:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(169, 82);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(17, 12);
            this.label11.TabIndex = 9;
            this.label11.Text = "Y:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(169, 53);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(17, 12);
            this.label12.TabIndex = 8;
            this.label12.Text = "X:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(45, 26);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 7;
            this.label9.Text = "目的点位";
            // 
            // button_RobotRun
            // 
            this.button_RobotRun.Location = new System.Drawing.Point(51, 168);
            this.button_RobotRun.Name = "button_RobotRun";
            this.button_RobotRun.Size = new System.Drawing.Size(75, 23);
            this.button_RobotRun.TabIndex = 6;
            this.button_RobotRun.Text = "运动";
            this.button_RobotRun.UseVisualStyleBackColor = true;
            this.button_RobotRun.Click += new System.EventHandler(this.button_RobotRun_Click);
            this.button_RobotRun.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button_RobotRun_MouseDown);
            this.button_RobotRun.MouseUp += new System.Windows.Forms.MouseEventHandler(this.button_RobotRun_MouseUp);
            // 
            // textBox_Robot_Z
            // 
            this.textBox_Robot_Z.Location = new System.Drawing.Point(47, 107);
            this.textBox_Robot_Z.Name = "textBox_Robot_Z";
            this.textBox_Robot_Z.Size = new System.Drawing.Size(85, 21);
            this.textBox_Robot_Z.TabIndex = 5;
            this.textBox_Robot_Z.Text = "-70.00";
            // 
            // textBox_Robot_Y
            // 
            this.textBox_Robot_Y.Location = new System.Drawing.Point(47, 78);
            this.textBox_Robot_Y.Name = "textBox_Robot_Y";
            this.textBox_Robot_Y.Size = new System.Drawing.Size(85, 21);
            this.textBox_Robot_Y.TabIndex = 4;
            this.textBox_Robot_Y.Text = "-536.00";
            // 
            // textBox_Robot_X
            // 
            this.textBox_Robot_X.Location = new System.Drawing.Point(47, 50);
            this.textBox_Robot_X.Name = "textBox_Robot_X";
            this.textBox_Robot_X.Size = new System.Drawing.Size(85, 21);
            this.textBox_Robot_X.TabIndex = 3;
            this.textBox_Robot_X.Text = "-204.00";
            // 
            // lablez
            // 
            this.lablez.AutoSize = true;
            this.lablez.Location = new System.Drawing.Point(24, 110);
            this.lablez.Name = "lablez";
            this.lablez.Size = new System.Drawing.Size(17, 12);
            this.lablez.TabIndex = 2;
            this.lablez.Text = "Z:";
            // 
            // lable
            // 
            this.lable.AutoSize = true;
            this.lable.Location = new System.Drawing.Point(24, 82);
            this.lable.Name = "lable";
            this.lable.Size = new System.Drawing.Size(17, 12);
            this.lable.TabIndex = 1;
            this.lable.Text = "Y:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(24, 53);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(17, 12);
            this.label8.TabIndex = 0;
            this.label8.Text = "X:";
            // 
            // timer_Robot
            // 
            this.timer_Robot.Enabled = true;
            this.timer_Robot.Tick += new System.EventHandler(this.timer_Robot_Tick);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(25, 138);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(23, 12);
            this.label14.TabIndex = 16;
            this.label14.Text = "RZ:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(170, 139);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(23, 12);
            this.label15.TabIndex = 17;
            this.label15.Text = "RZ:";
            // 
            // textBox_CurRZ
            // 
            this.textBox_CurRZ.Location = new System.Drawing.Point(192, 134);
            this.textBox_CurRZ.Name = "textBox_CurRZ";
            this.textBox_CurRZ.ReadOnly = true;
            this.textBox_CurRZ.Size = new System.Drawing.Size(85, 21);
            this.textBox_CurRZ.TabIndex = 18;
            // 
            // textBox_Robot_RZ
            // 
            this.textBox_Robot_RZ.Location = new System.Drawing.Point(47, 134);
            this.textBox_Robot_RZ.Name = "textBox_Robot_RZ";
            this.textBox_Robot_RZ.Size = new System.Drawing.Size(85, 21);
            this.textBox_Robot_RZ.TabIndex = 19;
            this.textBox_Robot_RZ.Text = "-267.00";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 730);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox_Meas);
            this.Controls.Add(this.groupBox_VisionTest);
            this.Controls.Add(this.groupBox_Camera);
            this.Controls.Add(this.CameraPictureBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.Text = "视觉检测";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormMain_FormClosed);
            this.Load += new System.EventHandler(this.FormMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.CameraPictureBox)).EndInit();
            this.groupBox_Camera.ResumeLayout(false);
            this.groupBox_Camera.PerformLayout();
            this.groupBox_VisionTest.ResumeLayout(false);
            this.groupBox_VisionTest.PerformLayout();
            this.groupBox_Meas.ResumeLayout(false);
            this.groupBox_Meas.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox CameraPictureBox;
        private System.Windows.Forms.Button button_FindCamera;
        private System.Windows.Forms.GroupBox groupBox_Camera;
        private System.Windows.Forms.Button button_CloseCamera;
        private System.Windows.Forms.Button button_OpenCamera;
        private System.Windows.Forms.Label label_FrameRate;
        private System.Windows.Forms.Label label_Gain;
        private System.Windows.Forms.Label label_Exposure;
        private System.Windows.Forms.TextBox textBox_FrameRate;
        private System.Windows.Forms.TextBox textBox_Gain;
        private System.Windows.Forms.TextBox textBox_Exposure;
        private System.Windows.Forms.Button button_GetCarmeraParam;
        private System.Windows.Forms.Button button_SetCameraParam;
        private System.Windows.Forms.GroupBox groupBox_VisionTest;
        private System.Windows.Forms.Button button_LoadPicture;
        private System.Windows.Forms.Button button_AnalyzeArea;
        private System.Windows.Forms.GroupBox groupBox_Meas;
        private System.Windows.Forms.TextBox textBox_TestEndY;
        private System.Windows.Forms.TextBox textBox_TestEndX;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_TestStartY;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_TestStartX;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_HintMeas;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button_RobotRun;
        private System.Windows.Forms.TextBox textBox_Robot_Z;
        private System.Windows.Forms.TextBox textBox_Robot_Y;
        private System.Windows.Forms.TextBox textBox_Robot_X;
        private System.Windows.Forms.Label lablez;
        private System.Windows.Forms.Label lable;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Timer timer_Robot;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox textBox_CurZ;
        private System.Windows.Forms.TextBox textBox_CurY;
        private System.Windows.Forms.TextBox textBox_CurX;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBox_Robot_RZ;
        private System.Windows.Forms.TextBox textBox_CurRZ;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
    }
}

