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

    public class Profile
    {
        private const string m_FileName = "config.xml";  //配置文件名
        private Configuration m_Config = new Configuration();

        public string RobotIp
        {
            get
            {
                return m_Config.RobotIp;
            }
            set
            {
                m_Config.RobotIp = value;
            }
        }

        public int RobotMoveSpeed
        {
            get
            {
                return m_Config.RobotMoveSpeed;
            }
            set
            {
                m_Config.RobotMoveSpeed = value;
            }
        }

        public int RobotMoveDistance
        {
            get
            {
                return m_Config.RobotMoveDistance;
            }
            set
            {
                m_Config.RobotMoveDistance = value;
            }
        }

        public int RobotMoveDistanceUm
        {
            get
            {
                return m_Config.RobotMoveDistanceUm;
            }
            set
            {
                m_Config.RobotMoveDistanceUm = value;
            }
        }

        public void LoadConfigFile()
        {
            string strFile = AppDomain.CurrentDomain.BaseDirectory + m_FileName;
            if (!File.Exists(strFile))
                return;
            
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

        public void SaveConfigFile()
        {
            string strFile = AppDomain.CurrentDomain.BaseDirectory + m_FileName;
            if (!File.Exists(strFile))
                return;

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
