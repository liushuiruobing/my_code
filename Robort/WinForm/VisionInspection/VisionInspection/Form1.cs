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
using VisionInspection.Camera;

namespace VisionInspection
{
    public partial class FormMain : System.Windows.Forms.Form
    {
        VisionCamera m_VisionCamera = new VisionCamera();

        private const string m_DefaultImage = "image.bmp";
        private bool m_SelectTestArea = false;  //=true 鼠标移动选取测量区域
        private Bitmap m_BitmapBak;
        private Bitmap m_BitmapTemp;
        private Point m_StartPoint = new Point(0, 0);
        private Point m_EndPoint = new Point(0, 0);
        private Rectangle m_DrawRect = new Rectangle();
        private Pen m_RectPen = new Pen(Color.Red, 2);
        private bool m_bDrawing = false;

        public FormMain()
        {
            InitializeComponent();
            this.CenterToScreen();

            m_VisionCamera.m_CameraPictureBox = CameraPictureBox;


        }

        private void FormMain_Load(object sender, EventArgs e)
        {

        }

        private void button_FindCamera_Click(object sender, EventArgs e)
        {
            if (m_VisionCamera != null)
                m_VisionCamera.FindCameraDevice();
        }

        private void button_OpenCamera_Click(object sender, EventArgs e)
        {
            if (m_VisionCamera != null)
                m_VisionCamera.OpenCameraDevice();
        }

        private void button_CloseCamera_Click(object sender, EventArgs e)
        {
            if (m_VisionCamera != null)
                m_VisionCamera.CloseCameraDevice();
        }

        private void button_SetCameraParam_Click(object sender, EventArgs e)
        {
            CameraParamStruct param;
            param.Exposure = float.Parse(textBox_Exposure.Text);
            param.Gain = float.Parse(textBox_Gain.Text);
            param.FramRate = float.Parse(textBox_FrameRate.Text);

            if (m_VisionCamera != null)
                m_VisionCamera.SetCameraParam(param);
        }

        private void button_GetCarmeraParam_Click(object sender, EventArgs e)
        {
            if (m_VisionCamera != null)
            {
                CameraParamStruct param = m_VisionCamera.GetCameraParam();
                textBox_Exposure.Text = param.Exposure.ToString("F1");
                textBox_Gain.Text = param.Gain.ToString("F1");
                textBox_FrameRate.Text = param.FramRate.ToString("F1");
            }          
        }

        private void button_LoadPicture_Click(object sender, EventArgs e)
        {
            CameraPictureBox.Load(m_DefaultImage);
        }

        //分析区域
        private void button_AnalyzeArea_Click(object sender, EventArgs e)
        {
            if (m_SelectTestArea)
            {
                m_SelectTestArea = false;
                button_AnalyzeArea.BackColor = SystemColors.Control;
            }
            else
            {
                m_SelectTestArea = true;
                button_AnalyzeArea.BackColor = Color.Turquoise;
                ClearTestAreaCoord();
            }
        }

        private void CameraPictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (!m_SelectTestArea || CameraPictureBox.Image == null)
                return;

            CameraPictureBox.Load(m_DefaultImage);

            if (m_BitmapBak == null)
                m_BitmapBak = new Bitmap(CameraPictureBox.Image, CameraPictureBox.Width * 2, CameraPictureBox.Height * 2);

            m_StartPoint.X = e.X;
            m_StartPoint.Y = e.Y; 

            textBox_TestStartX.Text = e.X.ToString();
            textBox_TestStartY.Text = e.Y.ToString();

            m_bDrawing = true;
        }

        private void CameraPictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (!m_SelectTestArea || CameraPictureBox.Image == null || !m_bDrawing)
                return;

            m_EndPoint.X = e.X;
            m_EndPoint.Y = e.Y;

            textBox_TestEndX.Text = e.X.ToString();
            textBox_TestEndY.Text = e.Y.ToString();

            //pictureBox2.Invalidate();
            DrawSelectedRect(true);
        }

        private void CameraPictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (!m_SelectTestArea || m_StartPoint == m_EndPoint)
                return;

            //SaveBmp();
            m_bDrawing = false;
            m_BitmapBak = null;
            //button_AnalyzeArea_Click(null, null);
        }

        private void DrawSelectedRect(bool bDrawCenterPoint)
        {
            m_BitmapTemp = m_BitmapBak.Clone(new Rectangle(0, 0, m_BitmapBak.Width, m_BitmapBak.Height), m_BitmapBak.PixelFormat);
            Graphics g = Graphics.FromImage(m_BitmapTemp);

            m_DrawRect.X = Math.Min(m_StartPoint.X, m_EndPoint.X);
            m_DrawRect.Y = Math.Min(m_StartPoint.Y, m_EndPoint.Y);
            m_DrawRect.Width = Math.Abs(m_StartPoint.X - m_EndPoint.X);
            m_DrawRect.Height = Math.Abs(m_StartPoint.Y - m_EndPoint.Y);

            //小图像的坐标转换为大图像的坐标
            m_DrawRect.X = m_DrawRect.X * 2;
            m_DrawRect.Y = m_DrawRect.Y * 2;
            m_DrawRect.Width = m_DrawRect.Width * 2;
            m_DrawRect.Height = m_DrawRect.Height * 2;
            g.DrawRectangle(m_RectPen, m_DrawRect);

            if (bDrawCenterPoint)
            {
                Point CenterPoint = new Point(m_DrawRect.X + m_DrawRect.Width / 2, m_DrawRect.Y + m_DrawRect.Height / 2);
                g.FillEllipse(Brushes.Red, CenterPoint.X, CenterPoint.Y, 5, 5);
            }

            g.Dispose();

            CameraPictureBox.Image = m_BitmapTemp;
        }

        public void ClearTestAreaCoord()
        {
            m_StartPoint.X = 0;
            m_StartPoint.Y = 0;
            m_EndPoint.X = 0;
            m_EndPoint.Y = 0;
        }
    }
}
