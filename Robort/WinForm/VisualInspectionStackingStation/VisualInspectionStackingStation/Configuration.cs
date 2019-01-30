using System;
using System.Xml.Serialization;
using System.IO;


namespace RobotWorkstation
{
    //配置类
    public class Configuration
    {
        //Visual Sorting Station
        public string VisualStationClientIp;
        public string VisualStationServerIp;
        public int VisualStationServerPort;

        //Camera
        public string CameraIp;
        public int CameraPort;

        //QRCode
        public string QRCodePort;
        public string QRCodeBandRate;

        //Conveyor_Empty Arm
        public string ControlerArmIp;
        public string ControlerArmMac;
        public int ControlerArmPort;

        public int AxisStartSpeed;
        public int AxisAddSpeed;
        public int AxisDecSpeed;
        public int ConveyorAxisRunSpeed;
        public int ConveyorAxisMaxStep;     //传输线电机把盘送到位，所要运行的步数
        public int OverturnAxisRunSpeed;
        public int OverturnAxisMaxStep;      //翻转电机,翻转所需的步数

        public Configuration()
        {
            //Visual Sorting Station
            VisualStationClientIp = "192.168.1.40";
            VisualStationServerIp = "192.168.1.10";
            VisualStationServerPort = 20000;

            //Camera
            CameraIp = "192.168.1.46";
            CameraPort = 20002;

            //QRCode
            QRCodePort = "COM1";
            QRCodeBandRate = "115200";

            //Conveyor_Empty Arm
            ControlerArmIp = "192.168.1.42";
            ControlerArmPort = 20001;
            ControlerArmMac = "94-F7-20-01-BD-10";

            AxisStartSpeed = 2000;
            AxisAddSpeed = 10000;
            AxisDecSpeed = 10000;

            OverturnAxisRunSpeed = 8000;
            ConveyorAxisRunSpeed = 8000;
            OverturnAxisMaxStep = 1000;      //翻转电机,翻转所需的步数            
            ConveyorAxisMaxStep = 1000;      //传输线电机把盘送到位，所要运行的步数
        }
    }

    //配置文件
    public static class Profile
    {
        private static readonly string m_FileName = "Config.xml";  //配置文件名
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
                    Global.MessageBoxShow(Global.StrLoadConfigFailed);
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
                    Global.MessageBoxShow(Global.StrSaveConfigFailed);
                    //return;
                }
            }
        }
    }
}
