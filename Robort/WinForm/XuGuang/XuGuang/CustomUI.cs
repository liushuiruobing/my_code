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
        public CustomLabel()
        {
            AutoSize = true;
            Font = new Font("微软雅黑", 12.5F);
            ForeColor = Color.FromArgb(210, 210, 210);
        }
    }

    public class CustomTextBox : TextBox
    {
        public CustomTextBox()
        {
            BackColor = Color.FromArgb(33, 33, 33);
            BorderStyle = BorderStyle.FixedSingle;
            Font = new Font("微软雅黑", 12.5F);
            ForeColor = Color.White;
            Size = new Size(90, 29);
        }
    }

    public class CustomButton : Button
    {
        public CustomButton()
        {
            FlatStyle = FlatStyle.Popup;
            Font = new Font("微软雅黑", 12.5F);
            ForeColor = Color.Transparent;
            BackColor = Color.FromArgb(74, 74, 74);
            UseVisualStyleBackColor = false;
            Size = new Size(90, 30);
        }
    }

    public class CustomGroupBox:GroupBox
    {      
        protected override void OnPaint(PaintEventArgs e)
        {
            Color cLine, cFont;
            if (Enabled)
            {
                cLine = Color.FromArgb(100, 100, 100);
                cFont = Color.FromArgb(230, 230, 230);
            }
            else
            {
                cLine = Color.FromArgb(80, 80, 80);
                cFont = Color.FromArgb(100, 100, 100);
            }

            e.Graphics.Clear(BackColor);
            e.Graphics.DrawString(Text, Font, new SolidBrush(cFont), 10, 1);
            var vSize = e.Graphics.MeasureString(Text, Font);
            e.Graphics.DrawLine(new Pen(cLine, 1), 1, vSize.Height / 2, 8, vSize.Height / 2);
            e.Graphics.DrawLine(new Pen(cLine, 1), vSize.Width + 8, vSize.Height / 2, Width - 2, vSize.Height / 2);
            e.Graphics.DrawLine(new Pen(cLine, 1), 1, vSize.Height / 2, 1, Height - 2);
            e.Graphics.DrawLine(new Pen(cLine, 1), 1, Height - 2, Width - 2, Height - 2);
            e.Graphics.DrawLine(new Pen(cLine, 1), Width - 2, vSize.Height / 2, Width - 2, Height - 2);
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