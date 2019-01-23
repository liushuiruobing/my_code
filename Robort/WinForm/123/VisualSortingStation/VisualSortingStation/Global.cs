using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RobotWorkstation
{
    class Global
    {
       
        public const string Version = "0.0.1";  //版本号

        public static readonly string[] StationName = new string[(int)LanguageId.Language_Total]
        {
            "视觉分拣站", "Visual Sorting Station"
        };

        public static readonly string[] StrInputError = new string[(int)LanguageId.Language_Total]
        {
             "请输入正确的数值！",  "Please Input the right data!"
        };

        public static readonly string[] StrVisualError = new string[(int)LanguageId.Language_Total]
        {
              "视觉计算出现错误！",  "A visual calculation error occurred!"
        };

        public static readonly string[] StrLoadConfigFailed = new string[(int)LanguageId.Language_Total]
        {
            "加载配置文件失败！",  "Failed to load configuration file!"
        };

        public static readonly string[] StrSaveConfigFailed = new string[(int)LanguageId.Language_Total]
        {
             "保存配置文件失败！", "Failed to save configuration file!"
        };

        public static readonly string[] StrCreateShareFolder = new string[(int)LanguageId.Language_Total]
        {
             "请在D盘创建名为ShareFolder的网络共享文件夹！", "Please create a network Shared folder named \"ShareFolder\" on the D disk!"
        };

        public static readonly string[] StrRobotInitError = new string[(int)LanguageId.Language_Total]
        {
              "机器人初始化错误！", "Robot initialization error!"
        };

        public static readonly string[] StrRobotGetPointsError = new string[(int)LanguageId.Language_Total]
        {
               "机械臂未连接或未获取到点位信息！",  "The robot is not connected or does not obtain the points information!"
        };
        
        public static readonly string[] StrRobotSortFinished = new string[(int)LanguageId.Language_Total]
        {
                "器件分拣完成！",  "Device sorting complete!"
        };

        public static readonly string[] StrRFIDReadError = new string[(int)LanguageId.Language_Total]
        {
               "请将载码体放在读写区域中！", "Please place the payload in the read and write area!"
        };

        public static readonly string[] StrRFIDInputError = new string[(int)LanguageId.Language_Total]
        {
               "请输入16个字节的数据,并确保载码体在感应范围内！", "Please input 16 bytes of data and make sure the carrier body is in the sensing range!"
        };

        public static void MessageBoxShow(string[] StrMessage)
        {
            int Language = (int)LanguageId.Language_CN;
            if (MultiLanguage.GetLanguage() == "en-US")
                Language = (int)LanguageId.Language_EN;

            MessageBox.Show(StrMessage[Language], StationName[Language], MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
   }
}
