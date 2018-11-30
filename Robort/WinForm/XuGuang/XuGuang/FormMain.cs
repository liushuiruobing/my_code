﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RobotWorkstation
{
    
    public partial class FormMain : Form
    {
        CustomColor m_CustomColor;
        LoginForm m_LoginForm = null;
        ManualDebugForm m_ManualDebugForm = null;  //手动调试对话框
        SystemSetingForm m_SystemSetingForm = null;

        //防止闪屏
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED，将一个窗体的所有子窗口使用双缓冲按照从低到高方式绘制出来。
                return cp;
            }
        }

        public FormMain()
        {
            InitializeComponent();
            InitOtherForm();
            this.CenterToScreen();
            
            Profile.LoadConfigFile();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            m_CustomColor.InitColor();
            InitWindowSize();
            InitCtrlColor();
        }

        public void InitWindowSize()
        {
            //得到屏幕工作区域的参数，比如去除属性任务栏的高度
            int nScreenWidth = Screen.PrimaryScreen.WorkingArea.Width; 
            int nScreenHeight = Screen.PrimaryScreen.WorkingArea.Height;

            //调整主窗体控件
            this.MaximumSize = new Size(nScreenWidth, nScreenHeight);
            this.Width = nScreenWidth;
            this.Height = nScreenHeight;
        }

        public void InitCtrlColor()
        {
            CmdTreeView.BackColor = m_CustomColor.TreeViewColor;
        }

        //创建其他窗体的实例对象
        public void InitOtherForm()
        {
            m_LoginForm = new LoginForm();
            m_LoginForm.MdiParent = this;

            m_ManualDebugForm = new ManualDebugForm();
            m_ManualDebugForm.MdiParent = this;

            m_SystemSetingForm = new SystemSetingForm();
            m_SystemSetingForm.MdiParent = this;


        }

        private void CmdTreeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            switch (e.Node.Name)
            {
                case "Login":
                    {
                        if (m_ManualDebugForm != null)
                            m_ManualDebugForm.HideFormAndSaveConfigFile();

                        if (m_LoginForm != null)
                        {
                            SplitContainerFromMain.Panel1.Controls.Add(m_LoginForm);
                            m_LoginForm.Dock = DockStyle.Fill;
                            m_LoginForm.Show();
                        }
                    }
                    break;
                case "Run":
                    {
                        if (m_ManualDebugForm != null)
                            m_ManualDebugForm.HideFormAndSaveConfigFile();
                    }
                    break;
                case "Manual":
                    {
                        if (m_LoginForm != null)
                            m_LoginForm.Hide();

                        if (m_SystemSetingForm != null)
                            m_SystemSetingForm.HideFormAndSaveConfigFile();

                        if (m_ManualDebugForm != null)
                        {
                            SplitContainerFromMain.Panel1.Controls.Add(m_ManualDebugForm);
                            m_ManualDebugForm.Dock = DockStyle.Fill;
                            m_ManualDebugForm.Show();
                        }
                    }
                    break;
                case "SystemSeting":
                    {
                        if (m_ManualDebugForm != null)
                            m_ManualDebugForm.HideFormAndSaveConfigFile();

                        if (m_SystemSetingForm != null)
                        {
                            SplitContainerFromMain.Panel1.Controls.Add(m_SystemSetingForm);
                            m_SystemSetingForm.Dock = DockStyle.Fill;
                            m_SystemSetingForm.Show();
                        }
                    }
                    break;
                case "UserLimits":
                    {
                        if (m_ManualDebugForm != null)
                            m_ManualDebugForm.HideFormAndSaveConfigFile();
                    }
                    break;
                case "Exit":
                    {
                        CloseForm();
                    }
                    break;
                default:
                    break;
            }
        }

        private void FormMain_MaximumSizeChanged(object sender, EventArgs e)
        {
            InitWindowSize();
        }

        public void CloseForm()
        {
            if (m_ManualDebugForm != null)
                m_ManualDebugForm.CloseRobot();

            Profile.SaveConfigFile();
            this.Close();
        }
    }
}
