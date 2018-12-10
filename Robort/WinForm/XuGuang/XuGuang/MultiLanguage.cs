using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RobotWorkstation
{
    static class MultiLanguage
    {
        //设置默认语言
        public static void SetLanguage(string language)
        {
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(language);
            Properties.Settings.Default.DefaultLanguage = language;
            Properties.Settings.Default.Save();
        }

        public static string GetLanguage()
        {
            return Properties.Settings.Default.DefaultLanguage;
        }

        // 对指定窗体加载语言
        public static void LoadLanguage(Form form, Type formType)
        {
            if (form != null)
            {
                System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(formType);
                resources.ApplyResources(form, "$this");
                Loading(form, resources);
            }
        }

        /// 加载语言
        private static void Loading(Control control, System.ComponentModel.ComponentResourceManager resources)
        {
            if (control is MenuStrip)
            {
                //将资源与控件对应
                resources.ApplyResources(control, control.Name);
                MenuStrip ms = (MenuStrip)control;
                if (ms.Items.Count > 0)
                {
                    foreach (ToolStripMenuItem c in ms.Items)
                    {
                        LoadingMenu(c, resources);
                    }
                }
            }

            foreach (Control c in control.Controls)
            {
                resources.ApplyResources(c, c.Name);
                Loading(c, resources);
            }
        }

        /// 遍历菜单
        private static void LoadingMenu(ToolStripMenuItem item, System.ComponentModel.ComponentResourceManager resources)
        {
            if (item is ToolStripMenuItem)
            {
                resources.ApplyResources(item, item.Name);
                ToolStripMenuItem tsmi = item;
                if (tsmi.DropDownItems.Count > 0)
                {
                    foreach (ToolStripMenuItem temp in tsmi.DropDownItems)
                    {
                        LoadingMenu(temp, resources);
                    }
                }
            }
        }
    }
}
