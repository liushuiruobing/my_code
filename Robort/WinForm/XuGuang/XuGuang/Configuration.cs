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
        public string RobotIp;
        public int RobotMoveSpeed;
        public int RobotMoveDistance;
        public int RobotMoveDistanceUm;

        public Configuration()
        {
            RobotIp = "192.168.1.124";
            RobotMoveSpeed = 20;
            RobotMoveDistance = 1000;
            RobotMoveDistanceUm = 1000;
        }
    }

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
                    m_Config = xmlSerializer.Deserialize(fStream) as Configuration;
                }
                catch
                {
                    System.Windows.Forms.MessageBox.Show("加载配置文件失败！", "警告");
                    return;
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
                    return;
                }
            }
        }
    }
}
