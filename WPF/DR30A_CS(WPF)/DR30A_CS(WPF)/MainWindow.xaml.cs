using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DR30A_CS_WPF_
{
    public struct CustomColor
    {
        public Brush BackGroundColor;
        public Brush BtnColor;
        public Brush BtnGreenColor;
        public Brush TxtBoxColor;
        public Brush TextColor;
        public Brush ListViewBackGround;
        public Brush ListViewHeader;
        public Brush ListViewSelected;

        public void InitColor()
        {
            BackGroundColor = new SolidColorBrush(Color.FromRgb(33, 33, 33));
            BtnColor = new SolidColorBrush(Color.FromRgb(74, 74, 74));
            BtnGreenColor = new SolidColorBrush(Color.FromRgb(70, 148, 8));
            TxtBoxColor = BackGroundColor;
            TextColor = new SolidColorBrush(Colors.White);
            ListViewBackGround = BackGroundColor;
            ListViewHeader = BtnColor;
            ListViewSelected = new SolidColorBrush(Color.FromRgb(51, 153, 255));
        }
    }

    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {

        CustomColor customColor;
        public MainWindow()
        {
            InitializeComponent();
            InitWindowSize();
            InitControlColor();
        }

        //设置窗体的大小
        public void InitWindowSize()
        {
            //得到屏幕整体参数，如1600*900
            //double nScreenWidth = SystemParameters.PrimaryScreenWidth;//
            //double nScreenHeight = SystemParameters.PrimaryScreenHeight;

            //得到屏幕工作区域的参数，比如去除属性任务栏的高度
            double nScreenWidth = SystemParameters.WorkArea.Width;//
            double nScreenHeight = SystemParameters.WorkArea.Height; 

            this.MinWidth = this.MaxWidth = nScreenWidth;
            this.MinHeight = this.MaxHeight = nScreenHeight;  
        }

        //设置控件背景色
        public void InitControlColor()
        {
            customColor.InitColor();
            this.Background = customColor.BackGroundColor;
            label_Title.Foreground = customColor.TextColor;
            tabControl.Background = customColor.BackGroundColor;
            tabControl.SelectedIndex = 1;
        }

        private void image_Close_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }
      
        //鼠标左键按下后可移动窗体
        private void DragWindow(object sender, MouseButtonEventArgs e)
        {
            //this.DragMove();
        }
    }
}
