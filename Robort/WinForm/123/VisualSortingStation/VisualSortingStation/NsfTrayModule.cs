using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace RobotWorkstation
{
    public class ModuleInfo
    {
        public int Number;  //序号
        public string Model;  //型号
        public string MAC1;  //MAC地址1
        public string MAC2;  //MAC地址2
        public string MAC3;  //MAC地址3
        public string MAC4;  //MAC地址4

        public ModuleInfo()
        {
            Number = 0;
            Model = " ";
            MAC1 = " ";
            MAC2 = " ";
            MAC3 = " ";
            MAC4 = " ";
        }
    }

    public class TrayModuleInfo
    {
        //模块编号
        public enum ModuleNumber
        {
            N1 = 0,  //1#模块
            N2 = 1,  //2#模块
            N3 = 2,  //3#模块
            N4 = 3,  //4#模块
            N5 = 4,  //5#模块
            N6 = 5,  //6#模块
            N7 = 6,  //7#模块
            N8 = 7,  //8#模块
            N9 = 8,  //9#模块
            N10 = 9,  //10#模块
            N11 = 10,  //11#模块
            N12 = 11,  //12#模块
            N13 = 12,  //13#模块
            N14 = 13,  //14#模块
            N15 = 14,  //15#模块
            N16 = 15,  //16#模块
            N17 = 16,  //17#模块
            N18 = 17,  //18#模块

            Max = 18,  //最大值
        }

        //文件状态
        public enum FileState
        {
            None,  //空,不使用
            Created,  //视觉分拣站已建立完成
            Modified,  //性能站已修改完成
        }

        public FileState State;  //文件状态
        public ModuleInfo[] Module = new ModuleInfo[(int)ModuleNumber.Max];  //模块

        public TrayModuleInfo()
        {
            State = FileState.Created;

            for (int i = 0; i < (int)ModuleNumber.Max; i++)
            {
                Module[i] = new ModuleInfo();
                Module[i].Number = i + 1;
            }
        }
    }

    /*网路共享文件-托盘的RFID与托盘内18个模块MAC地址的对应关系文件*/
    public class NsfTrayModule
    {
        public const string m_FileFolder = @"D:\ShareFolder";
        private string m_FileName = "1_RFID_20181206_100149.xml";  //文件名
        private TrayModuleInfo m_NetShareFile = new TrayModuleInfo();  //配置数据

        private static NsfTrayModule m_UniqueInstance;  // 定义一个静态变量来保存类的实例
        private static readonly object m_locker = new object();  // 定义一个标识确保线程同步

        private NsfTrayModule()
        {

        }

        /// <summary>
        /// 定义公有方法提供一个全局访问点,同时你也可以定义公有属性来提供全局访问点
        /// </summary>
        /// <returns></returns>
        public static NsfTrayModule GetInstance()
        {
            if (m_UniqueInstance == null)
            {
                lock (m_locker)
                {
                    if (m_UniqueInstance == null)  // 如果类的实例不存在则创建，否则直接返回
                    {
                        m_UniqueInstance = new NsfTrayModule();
                    }
                }
            }

            return m_UniqueInstance;
        }

        public TrayModuleInfo.FileState State
        {
            get
            {
                return m_NetShareFile.State;
            }
            set
            {
                m_NetShareFile.State = value;
            }
        }

        public string GetSaveFileName(int TrayNum)
        {
            DateTime CurentDate = DateTime.Now;

            string Header = TrayNum.ToString() + "_RFID_";
            string Date = CurentDate.Year.ToString() + CurentDate.Month.ToString("D2") + CurentDate.Day.ToString("D2") + "_";
            string Time = CurentDate.Hour.ToString("D2") + CurentDate.Minute.ToString("D2") + CurentDate.Second.ToString("D2");
            string FileSuffix = ".xml";
            m_FileName = m_FileFolder + "\\" + Header + Date + Time + FileSuffix;

            return m_FileName;
        }

        public void SetModuleModel(TrayModuleInfo.ModuleNumber index, string model)
        {
            if (index < TrayModuleInfo.ModuleNumber.Max)
            {
                m_NetShareFile.Module[(int)index].Model = model;
            }
        }

        public string GetModuleModel(TrayModuleInfo.ModuleNumber index)
        {
            if (index < TrayModuleInfo.ModuleNumber.Max)
            {
                return m_NetShareFile.Module[(int)index].Model;
            }
            else
            {
                return " ";
            }
        }

        public void SetModuleMAC1(TrayModuleInfo.ModuleNumber index, string MAC)
        {
            if (index < TrayModuleInfo.ModuleNumber.Max)
            {
                m_NetShareFile.Module[(int)index].MAC1 = MAC;
            }
        }

        public string GetModuleMAC1(TrayModuleInfo.ModuleNumber index)
        {
            if (index < TrayModuleInfo.ModuleNumber.Max)
            {
                return m_NetShareFile.Module[(int)index].MAC1;
            }
            else
            {
                return " ";
            }
        }

        public void SetModuleMAC2(TrayModuleInfo.ModuleNumber index, string MAC)
        {
            if (index < TrayModuleInfo.ModuleNumber.Max)
            {
                m_NetShareFile.Module[(int)index].MAC2 = MAC;
            }
        }

        public string GetModuleMAC2(TrayModuleInfo.ModuleNumber index)
        {
            if (index < TrayModuleInfo.ModuleNumber.Max)
            {
                return m_NetShareFile.Module[(int)index].MAC2;
            }
            else
            {
                return " ";
            }
        }

        public void SetModuleMAC3(TrayModuleInfo.ModuleNumber index, string MAC)
        {
            if (index < TrayModuleInfo.ModuleNumber.Max)
            {
                m_NetShareFile.Module[(int)index].MAC3 = MAC;
            }
        }

        public string GetModuleMAC3(TrayModuleInfo.ModuleNumber index)
        {
            if (index < TrayModuleInfo.ModuleNumber.Max)
            {
                return m_NetShareFile.Module[(int)index].MAC3;
            }
            else
            {
                return " ";
            }
        }

        public void SetModuleMAC4(TrayModuleInfo.ModuleNumber index, string MAC)
        {
            if (index < TrayModuleInfo.ModuleNumber.Max)
            {
                m_NetShareFile.Module[(int)index].MAC4 = MAC;
            }
        }

        public string GetModuleMAC4(TrayModuleInfo.ModuleNumber index)
        {
            if (index < TrayModuleInfo.ModuleNumber.Max)
            {
                return m_NetShareFile.Module[(int)index].MAC4;
            }
            else
            {
                return " ";
            }
        }

        public void LoadTrayModuleFile()
        {
            string strName = m_FileName;
            if (!File.Exists(strName))
                return;

            FileStream fs = new FileStream(strName, FileMode.Open);
            XmlSerializer xs = new XmlSerializer(typeof(TrayModuleInfo));
            try
            {
                m_NetShareFile = xs.Deserialize(fs) as TrayModuleInfo;
            }
            catch
            {
                fs.Close();
                return;
            }

            fs.Close();
        }

        public void SaveTrayModuleFile(int nTrayNum)
        {
            string strName = GetSaveFileName(nTrayNum);

            FileStream fs = new FileStream(strName, FileMode.Create);
            XmlSerializer xs = new XmlSerializer(typeof(TrayModuleInfo));
            xs.Serialize(fs, m_NetShareFile);
            fs.Close();
        }

        public bool CreateAndWriteFile(List<string> Data, int nTrayNum)
        {
            bool Re = true;

            for (int i = 0; i < Data.Count; i++)
            {
                string str = Data[i];
                string[] StrSplit = str.Split(',');
                if (StrSplit.Length != 3)  //目前一个器件的二维码信息是3个字符串
                {
                    Re = false;
                    break;
                }

                SetModuleModel((TrayModuleInfo.ModuleNumber)i, StrSplit[0]);
                SetModuleMAC1((TrayModuleInfo.ModuleNumber)i, StrSplit[1]);
                SetModuleMAC2((TrayModuleInfo.ModuleNumber)i, StrSplit[2]);
            }

            SaveTrayModuleFile(nTrayNum);

            return Re;
        }
    }
}
