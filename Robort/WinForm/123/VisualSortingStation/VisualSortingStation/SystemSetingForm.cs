using RobotWorkstation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
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

            //根据默认的属性配置来设置当前语言项
            if (MultiLanguage.GetLanguage() == "zh-CN")
                ComBoxSysLanguage.SelectedIndex = 0;
            else if (MultiLanguage.GetLanguage() == "en-US")
                ComBoxSysLanguage.SelectedIndex = 1;
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

        private void ComBoxSysLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            string language = MultiLanguage.GetLanguage();
            switch (ComBoxSysLanguage.SelectedIndex)
            {
                case 0:
                    language = "zh-CN";
                    break;
                case 1:
                    language = "en-US";
                    break;
                default:
                    break;
            }

            MultiLanguage.SetLanguage(language);

            //改变所有打开窗体的语言
            foreach (Form form in Application.OpenForms)
            {
                ChangeOpenedForm(form);
            }
        }

        private void ChangeOpenedForm(Form form)
        {
            switch (form.Name)
            {
                case "MainForm":
                    MultiLanguage.LoadLanguage(form, typeof(MainForm));
                    break;
                case "RunForm":
                    MultiLanguage.LoadLanguage(form, typeof(RunForm));
                    break;
                case "ManualDebugForm":
                    MultiLanguage.LoadLanguage(form, typeof(ManualDebugForm));
                    break;
                case "SystemSetingForm":
                    MultiLanguage.LoadLanguage(form, typeof(SystemSetingForm));
                    break;
                case "UserLimitsForm":
                    MultiLanguage.LoadLanguage(form, typeof(UserLimitsForm));
                    break;
                default:
                    break;
            }
        }
    }
}
