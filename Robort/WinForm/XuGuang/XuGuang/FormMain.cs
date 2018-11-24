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
        ManualDebug m_ManualDebug = new ManualDebug();  //手动调试对话框

        public FormMain()
        {
            InitializeComponent();
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

            this.MaximumSize = new Size(nScreenWidth, nScreenHeight);
            this.Width = nScreenWidth;
            this.Height = nScreenHeight;
            CmdTreeView.Height = this.Height - pictureBox_Title.Height - 2;
            if (m_ManualDebug != null)
            {
                m_ManualDebug.Location = new Point(CmdTreeView.Width, pictureBox_Title.Height);
                m_ManualDebug.Width = pictureBox_Title.Width - CmdTreeView.Width - 2;
                m_ManualDebug.Height = CmdTreeView.Height - 2;
            }
        }

        public void InitCtrlColor()
        {
            CmdTreeView.BackColor = m_CustomColor.TreeViewColor;
        }

        private void CmdTreeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            switch (e.Node.Name)
            {
                case "Login":
                    {
                    }break;
                case "Run":
                    {
                    }break;
                case "Manual":
                    {
                        if (m_ManualDebug != null)
                        {
                            m_ManualDebug.MdiParent = this;
                            //m_ManualDebug.Width = pictureBox_Title.Width - CmdTreeView.Width - 1;
                            //m_ManualDebug.Height = this.Height - pictureBox_Title.Height - 2;
                            m_ManualDebug.Show();
                        }                        
                    }break;
                case "SystemSeting":
                    {
                    }break;
                case "UserLimits":
                    {
                    } break;
                case "Exit":
                    {
                        this.Close();
                    }break;
                default:
                    break;
            }
        }

        private void FormMain_MaximumSizeChanged(object sender, EventArgs e)
        {
            InitWindowSize();
        }
    }
}
