namespace RobotWorkstation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("登录");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("运行", 1, 1);
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("手动控制", 2, 2);
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("系统设置", 3, 3);
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("权限管理", 4, 4);
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("退出", 5, 5);
            this.pictureBoxTitle = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CmdTreeView = new System.Windows.Forms.TreeView();
            this.CmdIcoList = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxTitle
            // 
            this.pictureBoxTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxTitle.Location = new System.Drawing.Point(1, 1);
            this.pictureBoxTitle.Name = "pictureBoxTitle";
            this.pictureBoxTitle.Size = new System.Drawing.Size(1600, 70);
            this.pictureBoxTitle.TabIndex = 1;
            this.pictureBoxTitle.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(14, 26);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(128, 22);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.label1.Location = new System.Drawing.Point(700, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(220, 38);
            this.label1.TabIndex = 3;
            this.label1.Text = "视觉分拣工作站";
            // 
            // CmdTreeView
            // 
            this.CmdTreeView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.CmdTreeView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CmdTreeView.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CmdTreeView.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(207)))), ((int)(((byte)(215)))));
            this.CmdTreeView.FullRowSelect = true;
            this.CmdTreeView.HotTracking = true;
            this.CmdTreeView.ImageIndex = 0;
            this.CmdTreeView.ImageList = this.CmdIcoList;
            this.CmdTreeView.Indent = 20;
            this.CmdTreeView.ItemHeight = 48;
            this.CmdTreeView.Location = new System.Drawing.Point(1, 70);
            this.CmdTreeView.Name = "CmdTreeView";
            treeNode1.Name = "Login";
            treeNode1.NodeFont = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            treeNode1.Text = "登录";
            treeNode2.ImageIndex = 1;
            treeNode2.Name = "Run";
            treeNode2.NodeFont = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            treeNode2.SelectedImageIndex = 1;
            treeNode2.Text = "运行";
            treeNode3.ImageIndex = 2;
            treeNode3.Name = "Manual";
            treeNode3.NodeFont = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            treeNode3.SelectedImageIndex = 2;
            treeNode3.Text = "手动控制";
            treeNode4.ImageIndex = 3;
            treeNode4.Name = "SystemSeting";
            treeNode4.NodeFont = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            treeNode4.SelectedImageIndex = 3;
            treeNode4.Text = "系统设置";
            treeNode5.ImageIndex = 4;
            treeNode5.Name = "UserLimits";
            treeNode5.NodeFont = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            treeNode5.SelectedImageIndex = 4;
            treeNode5.Text = "权限管理";
            treeNode6.ImageIndex = 5;
            treeNode6.Name = "Exit";
            treeNode6.NodeFont = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            treeNode6.SelectedImageIndex = 5;
            treeNode6.Text = "退出";
            this.CmdTreeView.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4,
            treeNode5,
            treeNode6});
            this.CmdTreeView.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.CmdTreeView.Scrollable = false;
            this.CmdTreeView.SelectedImageIndex = 0;
            this.CmdTreeView.ShowLines = false;
            this.CmdTreeView.ShowNodeToolTips = true;
            this.CmdTreeView.Size = new System.Drawing.Size(180, 790);
            this.CmdTreeView.TabIndex = 4;
            this.CmdTreeView.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.CmdTreeView_NodeMouseClick);
            // 
            // CmdIcoList
            // 
            this.CmdIcoList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("CmdIcoList.ImageStream")));
            this.CmdIcoList.TransparentColor = System.Drawing.Color.Transparent;
            this.CmdIcoList.Images.SetKeyName(0, "Login.png");
            this.CmdIcoList.Images.SetKeyName(1, "Run.png");
            this.CmdIcoList.Images.SetKeyName(2, "debug.png");
            this.CmdIcoList.Images.SetKeyName(3, "Set.png");
            this.CmdIcoList.Images.SetKeyName(4, "User.png");
            this.CmdIcoList.Images.SetKeyName(5, "Exit.png");
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.BackgroundImage = global::RobotWorkstation.Properties.Resources.Backcolor;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1600, 860);
            this.ControlBox = false;
            this.Controls.Add(this.CmdTreeView);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pictureBoxTitle);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1600, 900);
            this.MinimizeBox = false;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.TransparencyKey = System.Drawing.Color.White;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.MaximumSizeChanged += new System.EventHandler(this.FormMain_MaximumSizeChanged);
            this.Load += new System.EventHandler(this.FormMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxTitle;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TreeView CmdTreeView;
        private System.Windows.Forms.ImageList CmdIcoList;
    }
}

