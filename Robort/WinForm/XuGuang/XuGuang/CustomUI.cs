using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    class CustomUI
    {

    }
}
