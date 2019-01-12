using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RobotWorkstation
{

    public partial class Salver : UserControl
    {
        public static Color GridEmptyColor = Color.Gray;
        public static Color GridFullColor = Color.Green;
        public static Color GridErrorColor = Color.Red;

        public Salver()
        {
            InitializeComponent();
            InitEveryGridColor(Color.Gray);
        }

        public void InitEveryGridColor(Color color)
        {
            SalverPanelPic1.BackColor = color;
            SalverPanelPic2.BackColor = color;
            SalverPanelPic3.BackColor = color;
            SalverPanelPic4.BackColor = color;
            SalverPanelPic5.BackColor = color;
            SalverPanelPic6.BackColor = color;
            SalverPanelPic7.BackColor = color;
            SalverPanelPic8.BackColor = color;
            SalverPanelPic9.BackColor = color;
            SalverPanelPic10.BackColor = color;
            SalverPanelPic11.BackColor = color;
            SalverPanelPic12.BackColor = color;
            SalverPanelPic13.BackColor = color;
            SalverPanelPic14.BackColor = color;
            SalverPanelPic15.BackColor = color;
            SalverPanelPic16.BackColor = color;
            SalverPanelPic17.BackColor = color;
            SalverPanelPic18.BackColor = color;
        }

        public void SetSelectedGridColor(int Index, Color color)
        {
            switch (Index)
            {
                case 1:
                    SalverPanelPic1.BackColor = color;
                    break;
                case 2:
                    SalverPanelPic2.BackColor = color;
                    break;
                case 3:
                    SalverPanelPic3.BackColor = color;
                    break;
                case 4:
                    SalverPanelPic4.BackColor = color;
                    break;
                case 5:
                    SalverPanelPic5.BackColor = color;
                    break;
                case 6:
                    SalverPanelPic6.BackColor = color;
                    break;
                case 7:
                    SalverPanelPic7.BackColor = color;
                    break;
                case 8:
                    SalverPanelPic8.BackColor = color;
                    break;
                case 9:
                    SalverPanelPic9.BackColor = color;
                    break;
                case 10:
                    SalverPanelPic10.BackColor = color;
                    break;
                case 11:
                    SalverPanelPic11.BackColor = color;
                    break;
                case 12:
                    SalverPanelPic12.BackColor = color;
                    break;
                case 13:
                    SalverPanelPic13.BackColor = color;
                    break;
                case 14:
                    SalverPanelPic14.BackColor = color;
                    break;
                case 15:
                    SalverPanelPic15.BackColor = color;
                    break;
                case 16:
                    SalverPanelPic16.BackColor = color;
                    break;
                case 17:
                    SalverPanelPic17.BackColor = color;
                    break;
                case 18:
                    SalverPanelPic18.BackColor = color;
                    break;
                default:
                    break;
            }
        }
    }
}
