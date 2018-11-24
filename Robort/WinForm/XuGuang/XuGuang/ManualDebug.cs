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
    public partial class ManualDebug : Form
    {
        public ManualDebug()
        {
            InitializeComponent();
        }

        private void ManualDebug_Load(object sender, EventArgs e)
        {
            tabControl_ManualDebug.Width = this.Width;
            tabControl_ManualDebug.Height = this.Height;
        }

        public void InitFormSizeAndLoction(int Width, int Height)
        {
            this.Width = Width;
            this.Height = Height;
        }
    }
}
