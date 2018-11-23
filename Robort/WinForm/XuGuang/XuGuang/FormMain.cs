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

namespace XuGuang
{
    public partial class FormMain : Form
    {
        CustomColor customColor;

        public FormMain()
        {
            InitializeComponent();
            this.CenterToScreen();

        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            customColor.InitColor();
            InitWindowSize();
            InitCtrlColor();
        }

        //设置窗体的大小
        public void InitWindowSize()
        {
            //得到屏幕工作区域的参数，比如去除属性任务栏的高度
            int nScreenWidth = Screen.PrimaryScreen.WorkingArea.Width; 
            int nScreenHeight = Screen.PrimaryScreen.WorkingArea.Height;

            this.MaximumSize = new Size(nScreenWidth, nScreenHeight);
            this.Width = nScreenWidth;
            this.Height = nScreenHeight;
            CmdTreeView.Height = this.Height - pictureBox_Title.Height - 2;
        }

        public void InitCtrlColor()
        {
            CmdTreeView.BackColor = customColor.TreeViewColor;
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
                    }
                    break;
                case "Manual":
                    {
                    }
                    break;
                case "SystemSeting":
                    {
                    }
                    break;
                case "UserLimits":
                    {
                    }
                    break;
                case "Exit":
                    {
                        this.Close();
                    }break;
                default:
                    break;
            }
        }
    }
}
