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
    public partial class RunForm : Form
    {
        public RunForm()
        {
            InitializeComponent();
        }

        private void CButtonStart_Click(object sender, EventArgs e)
        {
            OriginalSalver.SetSelectedGridColor(1, Color.Green);
        }

        private void CButtonPause_Click(object sender, EventArgs e)
        {
            OriginalSalver.SetSelectedGridColor(1, Color.Red);
        }

        private void CButtonStop_Click(object sender, EventArgs e)
        {

        }

        private void CButtonReset_Click(object sender, EventArgs e)
        {

        }

        private void CButtonAutoRun_Click(object sender, EventArgs e)
        {

        }
    }
}
