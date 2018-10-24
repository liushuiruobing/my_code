using DeviceSource;
using MvCamCtrl.NET;
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

namespace WPF_HikvisionCamera
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        //WPF的Image控件实现
        private void button_Image_Click(object sender, RoutedEventArgs e)
        {
            WPF_Image wpf_ImageCamera = new WPF_Image();
            wpf_ImageCamera.Show();
        }

        //WPF加载WindowsForm的PicturBox实现
        private void button_WinFormPicBox_Click(object sender, RoutedEventArgs e)
        {
            WPF_WinFormPicBoxCamera wpf_PixBoxCamera = new WPF_WinFormPicBoxCamera();
            wpf_PixBoxCamera.Show();
        }


    }
}
