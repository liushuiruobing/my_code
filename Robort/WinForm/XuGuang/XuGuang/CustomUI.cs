using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RobotWorkstation
{
    public struct CustomColor
    {
        public Color BackGroundColor;
        public Color BtnColor;
        public Color BtnGreenColor;
        public Color TxtBoxColor;
        public Color TreeViewColor;

        public void InitColor()
        {
            BackGroundColor = Color.FromArgb(33, 33, 33);
            BtnColor = Color.FromArgb(74, 74, 74);
            BtnGreenColor = Color.FromArgb(70, 148, 8);
            TxtBoxColor = BackGroundColor;
            TreeViewColor = Color.FromArgb(44, 44, 44);
        }
    }

    public class CustomLabel : Label
    {
        protected override void OnPaint(PaintEventArgs e)
        {
            Font cFont = new Font("微软雅黑", 12.5F);
            Color cFontColor = Color.FromArgb(210, 210, 210);
            e.Graphics.DrawString(this.Text, cFont, new SolidBrush(cFontColor), 10, 1);
        }
    }

    public class CustomGroupBox:GroupBox
    {      
        protected override void OnPaint(PaintEventArgs e)
        {
            Color cLine, cFont;
            if (this.Enabled)
            {
                cLine = Color.FromArgb(100, 100, 100);
                cFont = Color.FromArgb(230, 230, 230);
            }
            else
            {
                cLine = Color.FromArgb(80, 80, 80);
                cFont = Color.FromArgb(100, 100, 100);
            }

            e.Graphics.Clear(this.BackColor);
            e.Graphics.DrawString(this.Text, this.Font, new SolidBrush(cFont), 10, 1);
            var vSize = e.Graphics.MeasureString(this.Text, this.Font);
            e.Graphics.DrawLine(new Pen(cLine, 1), 1, vSize.Height / 2, 8, vSize.Height / 2);
            e.Graphics.DrawLine(new Pen(cLine, 1), vSize.Width + 8, vSize.Height / 2, this.Width - 2, vSize.Height / 2);
            e.Graphics.DrawLine(new Pen(cLine, 1), 1, vSize.Height / 2, 1, this.Height - 2);
            e.Graphics.DrawLine(new Pen(cLine, 1), 1, this.Height - 2, this.Width - 2, this.Height - 2);
            e.Graphics.DrawLine(new Pen(cLine, 1), this.Width - 2, vSize.Height / 2, this.Width - 2, this.Height - 2);
        }
    }

    //自定义TabControl
    public class CustomTabControl : TabControl
    {
        public override Rectangle DisplayRectangle
        {
            get
            {
                Rectangle rect = base.DisplayRectangle;
                //return new Rectangle(rect.Left - 3, rect.Top - 1, rect.Width + 6, rect.Height + 4);
                return new Rectangle(rect.Left - 4, rect.Top - 1, rect.Width + 8, rect.Height + 5);
            }
        }
    }

    public class CustomTabControlBorder : TabControl
    {
        public override Rectangle DisplayRectangle
        {
            get
            {
                Rectangle rect = base.DisplayRectangle;
                return new Rectangle(rect.Left - 3, rect.Top - 1, rect.Width + 6, rect.Height + 4);
            }
        }
    }
}