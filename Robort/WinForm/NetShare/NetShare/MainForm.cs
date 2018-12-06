using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static NetShare.NetShareClass;

namespace NetShare
{
    public partial class MainForm : Form
    {
        NetShareClass m_NetShare = new NetShareClass();
        string m_SharePath = @"\\";
        string m_ShareFolderName = @"\Share";
        string m_ShareDeviceName = "Guest";
        string m_SharePassWord = "";
        string m_ShareFileName = @"\test.txt";
        string m_Localpath = "Z:"; ////映射到本地的盘符，如"z:",不做驱动器映射，可为空
        int m_ConnectShareStatus = -1;

        public MainForm()
        {
            InitializeComponent();
        }

        private void BtnCreate_Click(object sender, EventArgs e)
        {
            //创建网络共享
            string CreateShare = "CreateShare.bat";
            string SetSharePermission = "SetShareFilePermission.bat";
            string FolderPath = @"F:\ShareFolder";  //映射到本地的文件夹

            if (!Directory.Exists(FolderPath))
            {
                Directory.CreateDirectory(FolderPath);
                m_NetShare.CallShareBatFile(CreateShare);
            }

            string file = FolderPath + m_ShareFileName;
            if (!File.Exists(file))
            {
                FileStream fs = File.Create(file);
                fs.Close();
                m_NetShare.CallShareBatFile(SetSharePermission); //设置新创建的文件属性
            }
        }

        private void BtnConnect_Click(object sender, EventArgs e)
        {
            m_SharePath = @"\\";
            m_SharePath = m_SharePath + TextBoxIP.Text + m_ShareFolderName;
            m_ShareDeviceName = TextBoxUser.Text;
            m_SharePassWord = TextBoxPassword.Text;

            m_ConnectShareStatus = m_NetShare.Connect(m_SharePath, m_Localpath, m_ShareDeviceName, m_SharePassWord);
            if (m_ConnectShareStatus == (int)ERROR_ID.ERROR_SUCCESS)
            {
                BtnConnect.Enabled = false;
                MessageBox.Show("连接成功！");
            }
            else if (m_ConnectShareStatus == (int)ERROR_ID.ERROR_SESSION_CREDENTIAL_CONFLICT)
            {
                m_NetShare.Disconnect(m_Localpath);
                MessageBox.Show("请关闭已经存在的连接！");
            }
            else
            {
                MessageBox.Show($"连接失败！ErrorCode = {m_ConnectShareStatus}");
            }
        }

        private void BtnWriter_Click(object sender, EventArgs e)
        {
            if (m_ConnectShareStatus == (int)ERROR_ID.ERROR_SUCCESS)
            {
                FileStream fs = new FileStream(m_Localpath + m_ShareFileName, FileMode.Append);
                using (StreamWriter stream = new StreamWriter(fs))
                {
                    stream.WriteLine("测试代码！");
                    stream.Flush();
                    stream.Close();
                }
                fs.Close();
            }
            else
            {
                MessageBox.Show("请建立连接后写入！");
            }
        }

        private void BtnRead_Click(object sender, EventArgs e)
        {
            if (m_ConnectShareStatus == (int)ERROR_ID.ERROR_SUCCESS)
            {
                if (File.Exists(m_Localpath + m_ShareFileName))
                {
                   // FileStream fs = new FileStream(m_Localpath + m_ShareFileName, FileMode.Open);
                    //using (StreamReader stream = new StreamReader(fs))
                    using (StreamReader stream = new StreamReader(m_Localpath + m_ShareFileName))
                    {
                        string str = stream.ReadLine();
                        TextBoxShow.Text += str;
                        stream.Close();
                    }
                    //fs.Close();
                }
            }
            else
            {
                MessageBox.Show("请建立连接后读取！");
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (m_ConnectShareStatus == (int)ERROR_ID.ERROR_SUCCESS)
            {
                File.Delete(m_Localpath + m_ShareFileName);
                TextBoxShow.Text = "";
            }               
            else
            {
                MessageBox.Show("未建立连接！");
            }

        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (m_ConnectShareStatus == (int)ERROR_ID.ERROR_SUCCESS)
                m_NetShare.Disconnect(m_Localpath);
        }
    }
}
