using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotWorkstation
{

    class ConstString
    {
        public static readonly string [] StrLoadConfigFailed = new string[(int)LanguageId.Language_Total]
        {
            "加载配置文件失败！", "加载配置文件失败！",  //后面一个应该是英文
        };

        public static readonly string[] StrSaveConfigFailed = new string[(int)LanguageId.Language_Total]
        {
             "保存配置文件失败！", "保存配置文件失败！",  //后面一个应该是英文
        };
    }
}
