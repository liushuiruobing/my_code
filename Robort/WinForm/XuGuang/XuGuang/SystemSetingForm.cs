using RobotWorkstation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RobotWorkstation
{
    public partial class SystemSetingForm : Form
    {
        //防止闪屏
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }

        public SystemSetingForm()
        {
            InitializeComponent();
        }

        private void SystemSeting_Load(object sender, EventArgs e)
        {
            tabControlSystemSeting.Width = this.Width - tabControlSystemSeting.Location.X;
            tabControlSystemSeting.Height = this.Height - tabControlSystemSeting.Location.Y;

            CTextBoxSysSetRobotIP.Text = Profile.m_Config.RobotIp;
        }

        private void CTextBoxSysSetRobotIP_TextChanged(object sender, EventArgs e)
        {
            Profile.m_Config.RobotIp = CTextBoxSysSetRobotIP.Text;
        }

        public void HideFormAndSaveConfigFile()
        {
            this.Hide();
            Profile.SaveConfigFile();
        }
    }
}
