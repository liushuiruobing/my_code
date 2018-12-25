using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace RobotWorkstation
{
    //配置类
    public class Configuration
    {
        //机械臂
        public string RobotIp;
        public int RobotMoveSpeed;
        public int RobotMoveDistance;
        public int RobotMoveDistanceUm;

        //相机
        public float CameraExposure;
        public float CameraGain;
        public float CameraFramRate;

        public Configuration()
        {
            RobotIp = "192.168.1.1";
            RobotMoveSpeed = 20;
            RobotMoveDistance = 1000;
            RobotMoveDistanceUm = 1000;

            CameraExposure = 1000;
            CameraGain = 1000;
            CameraFramRate = 1000;
        }
    }

    //配置文件
    public static class Profile
    {
        private static readonly string m_FileName = "config.xml";  //配置文件名
        public static Configuration m_Config = new Configuration();

        public static void LoadConfigFile()
        {
            string strFile = AppDomain.CurrentDomain.BaseDirectory + m_FileName;
            if (!File.Exists(strFile))
            {
                return;
            }

            using (FileStream fStream = new FileStream(strFile, FileMode.Open))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(Configuration));
                try
                {
                    m_Config = (Configuration)xmlSerializer.Deserialize(fStream);
                }
                catch //(InvalidOperationException)
                {
                    System.Windows.Forms.MessageBox.Show("加载配置文件失败！", "警告");
                    //return;
                }
            }
        }

        public static void SaveConfigFile()
        {
            string strFile = AppDomain.CurrentDomain.BaseDirectory + m_FileName;
            if (!File.Exists(strFile))
            {
                return;
            }

            using(FileStream fStream = new FileStream(strFile, FileMode.OpenOrCreate))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(Configuration));
                try
                {
                    xmlSerializer.Serialize(fStream, m_Config);
                }
                catch
                {
                    System.Windows.Forms.MessageBox.Show("保存配置文件失败！", "警告");
                    //return;
                }
            }
        }
    }
}
