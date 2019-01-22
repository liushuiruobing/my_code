using System;
using System.Xml.Serialization;
using System.IO;
using System.Windows.Forms;

namespace RobotWorkstation
{
    //配置类
    public class Configuration
    {
        //Visual Sorting Station
        public string VisualStationClientIp;
        public string VisualStationServerIp;
        public int VisualStationServerPort;

        //Robot
        public string RobotIp;
        public int RobotMoveSpeed;
        public int RobotMoveDistance;
        public int RobotMoveDistanceUm;

        //Camera
        public string CameraIp;
        public int CameraPort;

        //QRCode
        public string QRCodePort;
        public string QRCodeBandRate;

        //RFID
        public string RfidIp;
        public int RfidCh;
        public string RfidSn;

        //Controler Arm
        public string ControlerArmIp;
        public string ControlerArmMac;
        public int ControlerArmPort;
        
        //Sort Mode
        public SortMode SelectedSortMode;

        public Configuration()
        {
            //Visual Sorting Station
            VisualStationClientIp = "192.168.1.40";
            VisualStationServerIp = "192.168.1.10";
            VisualStationServerPort = 20000;

            //Robot
            RobotIp = "192.168.1.48";
            RobotMoveSpeed = 20;
            RobotMoveDistance = 1000;
            RobotMoveDistanceUm = 1000;

            //Camera
            CameraIp = "192.168.1.46";
            CameraPort = 20002;

            //QRCode
            QRCodePort = "COM1";
            QRCodeBandRate = "115200";

            //RFID
            RfidIp = "192.168.1.24";
            RfidCh = 0;
            RfidSn = "00000000000000001";

            //Controler Arm
            ControlerArmIp = "192.168.1.42";
            ControlerArmPort = 20001;
            ControlerArmMac = "94-F7-20-01-BD-10";

            SelectedSortMode = SortMode.SortWithVisual;
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
                return;           

            using (FileStream fStream = new FileStream(strFile, FileMode.Open))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(Configuration));
                try
                {
                    m_Config = xmlSerializer.Deserialize(fStream) as Configuration;
                }
                catch //(InvalidOperationException)
                {
                    MessageBox.Show(ConstString.StrLoadConfigFailed[0], Global.StationName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //return;
                }
            }
        }

        public static void SaveConfigFile()
        {
            string strFile = AppDomain.CurrentDomain.BaseDirectory + m_FileName;
            using(FileStream fStream = new FileStream(strFile, FileMode.Create))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(Configuration));
                try
                {
                    xmlSerializer.Serialize(fStream, m_Config);
                }
                catch
                {
                    MessageBox.Show(ConstString.StrSaveConfigFailed[0], Global.StationName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //return;
                }
            }
        }
    }
}
