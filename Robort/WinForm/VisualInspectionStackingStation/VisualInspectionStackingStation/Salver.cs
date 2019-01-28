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

        private PictureBox[,] SalverPics;

        private int GridWidth = 40;
        private int GridHeight = 35;

        public int SalverRows
        {
            get { return SalverPanel.RowCount; }
        }

        public int SalverCols
        {
            get { return SalverPanel.ColumnCount; }
        }

        public Salver()
        {
            InitializeComponent();

            InitSalverPictures();
            InitEveryGridColor(Color.Gray);
        }

        private void Salver_Load(object sender, EventArgs e)
        {
            this.Width = GridWidth * SalverPanel.ColumnCount;
            this.Height = GridHeight * SalverPanel.RowCount;
        }

        public void InitSalverPictures()
        {
            SalverPics = new PictureBox[SalverPanel.RowCount, SalverPanel.ColumnCount];

            for (int i = 0; i < SalverPanel.RowCount; i++)
            {
                for (int j = 0; j < SalverPanel.ColumnCount; j++)
                {
                    SalverPics[i, j] = new PictureBox();

                    SalverPics[i, j].BackColor = System.Drawing.Color.Gray;
                    SalverPics[i, j].Dock = System.Windows.Forms.DockStyle.Fill;
                    SalverPics[i, j].Size = new System.Drawing.Size(GridWidth, GridHeight);

                    SalverPanel.Controls.Add(SalverPics[i,j], j, i);
                }
            }          
        }

        public void InitEveryGridColor(Color color)
        {
            for (int i = 0; i < SalverPanel.RowCount; i++)
            {
                for (int j = 0; j < SalverPanel.ColumnCount; j++)
                {
                    SalverPics[i, j].BackColor = color;
                }
            }
        }

        public void SetSelectedGridColor(int Row, int Col, Color color)
        {
            SalverPics[Row, Col].BackColor = color;          
        }
    }
}
