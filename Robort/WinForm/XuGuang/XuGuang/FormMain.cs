using System;
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
        ManualDebugForm m_ManualDebugForm = null;  //手动调试对话框
        SystemSetingForm m_SystemSetingForm = null;

        public FormMain()
        {
            InitializeComponent();
            InitOtherForm();
            this.CenterToScreen();
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

            //这两行代码是避免手动控制等子窗体出来时，主窗体被加上滚动条
            AutoScrollMinSize = new Size(nScreenWidth+100, nScreenHeight+100);
            IsMdiContainer = true;

            //调整主窗体控件
            this.MaximumSize = new Size(nScreenWidth, nScreenHeight);
            this.Width = nScreenWidth;
            this.Height = nScreenHeight;
            CmdTreeView.Height = this.Height - pictureBoxTitle.Height - 2;

            //调整其他窗体
            if (m_ManualDebugForm != null)
            {
                m_ManualDebugForm.Location = new Point(CmdTreeView.Width, pictureBoxTitle.Height);
                m_ManualDebugForm.Width = pictureBoxTitle.Width - CmdTreeView.Width - 2;
                m_ManualDebugForm.Height = CmdTreeView.Height - 2;
            }

            if (m_SystemSetingForm != null)
            {
                m_SystemSetingForm.Location = new Point(CmdTreeView.Width, pictureBoxTitle.Height);
                m_SystemSetingForm.Width = pictureBoxTitle.Width - CmdTreeView.Width - 2;
                m_SystemSetingForm.Height = CmdTreeView.Height - 2;
            }
        }

        public void InitCtrlColor()
        {
            CmdTreeView.BackColor = m_CustomColor.TreeViewColor;
        }

        //创建其他窗体的实例对象
        public void InitOtherForm()
        {
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
                            m_ManualDebugForm.Hide();
                    }break;
                case "Run":
                    {
                        if (m_ManualDebugForm != null)
                            m_ManualDebugForm.Hide();
                    }
                    break;
                case "Manual":
                    {
                        if (m_SystemSetingForm != null)
                            m_SystemSetingForm.Hide();

                        if (m_ManualDebugForm != null)
                        {
                            m_ManualDebugForm.Show();
                        }
                        else
                        {
                            m_ManualDebugForm = new ManualDebugForm();
                            m_ManualDebugForm.MdiParent = this;
                            m_ManualDebugForm.Show();
                        }                     
                    }break;
                case "SystemSeting":
                    {
                        if (m_ManualDebugForm != null)
                            m_ManualDebugForm.Hide();

                        if (m_SystemSetingForm != null)
                        {
                            m_SystemSetingForm.Show();
                        }
                        else
                        {
                            m_SystemSetingForm = new SystemSetingForm();
                            m_SystemSetingForm.MdiParent = this;
                            m_SystemSetingForm.Show();
                        }
                    }
                    break;
                case "UserLimits":
                    {
                        if (m_ManualDebugForm != null)
                            m_ManualDebugForm.Hide();
                    } break;
                case "Exit":
                    {
                        CloseForm();                     
                    }break;
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

            this.Close();
        }
    }
}
