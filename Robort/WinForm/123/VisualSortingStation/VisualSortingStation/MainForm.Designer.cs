namespace RobotWorkstation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.SplitContainerFromMain = new System.Windows.Forms.SplitContainer();
            this.pictureBoxTitle = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CmdTreeView = new System.Windows.Forms.TreeView();
            this.CmdIcoList = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainerFromMain)).BeginInit();
            this.SplitContainerFromMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // SplitContainerFromMain
            // 
            resources.ApplyResources(this.SplitContainerFromMain, "SplitContainerFromMain");
            this.SplitContainerFromMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.SplitContainerFromMain.Name = "SplitContainerFromMain";
            // 
            // SplitContainerFromMain.Panel1
            // 
            resources.ApplyResources(this.SplitContainerFromMain.Panel1, "SplitContainerFromMain.Panel1");
            this.SplitContainerFromMain.Panel1.BackColor = System.Drawing.Color.Transparent;
            // 
            // SplitContainerFromMain.Panel2
            // 
            resources.ApplyResources(this.SplitContainerFromMain.Panel2, "SplitContainerFromMain.Panel2");
            this.SplitContainerFromMain.Panel2Collapsed = true;
            // 
            // pictureBoxTitle
            // 
            resources.ApplyResources(this.pictureBoxTitle, "pictureBoxTitle");
            this.pictureBoxTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxTitle.Name = "pictureBoxTitle";
            this.pictureBoxTitle.TabStop = false;
            // 
            // pictureBox1
            // 
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.label1.Name = "label1";
            // 
            // CmdTreeView
            // 
            resources.ApplyResources(this.CmdTreeView, "CmdTreeView");
            this.CmdTreeView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.CmdTreeView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CmdTreeView.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(207)))), ((int)(((byte)(215)))));
            this.CmdTreeView.FullRowSelect = true;
            this.CmdTreeView.HotTracking = true;
            this.CmdTreeView.ImageList = this.CmdIcoList;
            this.CmdTreeView.ItemHeight = 48;
            this.CmdTreeView.Name = "CmdTreeView";
            this.CmdTreeView.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            ((System.Windows.Forms.TreeNode)(resources.GetObject("CmdTreeView.Nodes"))),
            ((System.Windows.Forms.TreeNode)(resources.GetObject("CmdTreeView.Nodes1"))),
            ((System.Windows.Forms.TreeNode)(resources.GetObject("CmdTreeView.Nodes2"))),
            ((System.Windows.Forms.TreeNode)(resources.GetObject("CmdTreeView.Nodes3"))),
            ((System.Windows.Forms.TreeNode)(resources.GetObject("CmdTreeView.Nodes4"))),
            ((System.Windows.Forms.TreeNode)(resources.GetObject("CmdTreeView.Nodes5")))});
            this.CmdTreeView.Scrollable = false;
            this.CmdTreeView.ShowLines = false;
            this.CmdTreeView.ShowNodeToolTips = true;
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
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.BackgroundImage = global::RobotWorkstation.Properties.Resources.Backcolor;
            this.ControlBox = false;
            this.Controls.Add(this.SplitContainerFromMain);
            this.Controls.Add(this.CmdTreeView);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pictureBoxTitle);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.IsMdiContainer = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.TransparencyKey = System.Drawing.Color.White;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.MaximumSizeChanged += new System.EventHandler(this.FormMain_MaximumSizeChanged);
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainerFromMain)).EndInit();
            this.SplitContainerFromMain.ResumeLayout(false);
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
        private System.Windows.Forms.SplitContainer SplitContainerFromMain;
    }
}

