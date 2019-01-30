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
            "插针检测堆垛站", "Visual Inspection Stacking Station"
        };

        public static readonly string[] StrRunError = new string[(int)LanguageId.Language_Total]
        {
            "无法正常启动，请进行检查！",  "Could not start normally, please check!"
        };

        public static readonly string[] StrRobotInitError = new string[(int)LanguageId.Language_Total]
        {
             "机器人初始化错误！", "Robot initialization error!"
        };

        public static readonly string[] StrStartVisualServiceError = new string[(int)LanguageId.Language_Total]
        {
             "视觉检测服务启动失败！", "Visual detection service failed to start!"
        };

        public static readonly string[] StrInputError = new string[(int)LanguageId.Language_Total]
        {
             "请输入正确的数值！",  "Please Input the right data!"
        };

        public static readonly string[] StrLoadConfigFailed = new string[(int)LanguageId.Language_Total]
        {
            "加载配置文件失败！",  "Failed to load configuration file!"
        };

        public static readonly string[] StrSaveConfigFailed = new string[(int)LanguageId.Language_Total]
        {
             "保存配置文件失败！", "Failed to save configuration file!"
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
