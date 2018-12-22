using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotWorkstation
{   
    public class SysAlarm
    {
        public int Language = (int)LanguageId.Language_CN;

        public enum LanguageId
        {
            Language_CN = 0,
            Language_EN,
            Language_Total
        }

        /*告警数据结构*/
        public struct StructAlarm
        {
            public int ID;  //ID号
            public int Level;  //级别
            public bool IsAlarm;  //是否报警
            public string Informat;  //告警信息
            public string Solution;  //解决方法
        }

        /*告警类型*/
        public enum Type
        {
            Robot,  
            Camera,  
            QRCode,  //二维码读码器
            RFID,    //RFID读码器
            Server,  //服务器
            Salver,  //物料盘      
            Max,
        }

        /*告警级别*/
        public static readonly int[] TABLE_INIT_LEVEL = new int[(int)Type.Max]
        {
            1,  //Robot
            1,  //Camera
            1,  //QRCode
            1,  //RFID
            1,  //Salver
            1,  //Server
        };

        /*告警信息字符串*/
        public static readonly string[,] TABLE_INIT_INFORMAT = new string[(int)Type.Max, (int)LanguageId.Language_Total]
        {
            {"机械臂未连接！", "机械臂未连接！"},
            {"相机未连接！", "相机未连接！"},
            {"二维码读码器未连接！", "二维码读码器未连接！"},
            {"RFID读码器未连接！", "RFID读码器未连接！"},
            {"服务器未连接！", "服务器未连接！"},
            {"缺少物料盘！", "缺少物料盘！"}
        };

        /*解决方法字符串*/
        public static readonly string[,] TABLE_INIT_SOLUTION = new string[(int)Type.Max, (int)LanguageId.Language_Total]
        {
            {"请检查机械臂！", "请检查机械臂！"},
            {"请检查相机！", "请检查相机！"},
            {"请检查二维码读码器！", "请检查二维码读码器！"},
            {"请检查RFID读码器！", "请检查RFID读码器！"},
            {"请检查服务器！", "请检查服务器！"},
            {"请检查物料盘！", "请检查物料盘！"}
        };
        
        private static SysAlarm m_UniqueSysAlarm;  // 定义一个静态变量来保存类的实例
        private static readonly object m_locker = new object();  // 定义一个标识确保线程同步

        StructAlarm[] m_Alarm = new StructAlarm[(int)Type.Max];  //报警信息

        // 定义私有构造函数，使外界不能创建该类实例
        private SysAlarm()
        {
            InitData();
        }

        /// <summary>
        /// 定义公有方法提供一个全局访问点,同时你也可以定义公有属性来提供全局访问点
        /// </summary>
        /// <returns></returns>
        public static SysAlarm GetInstance()
        {
            // 当第一个线程运行到这里时，此时会对locker对象 "加锁"，
            // 当第二个线程运行该方法时，首先检测到locker对象为"加锁"状态，该线程就会挂起等待第一个线程解锁
            // lock语句运行完之后（即线程运行完之后）会对该对象"解锁"
            // 双重锁定只需要一句判断就可以了
            if (m_UniqueSysAlarm == null)
            {
                lock (m_locker)
                {
                    if (m_UniqueSysAlarm == null)  // 如果类的实例不存在则创建，否则直接返回
                    {
                        m_UniqueSysAlarm = new SysAlarm();
                    }
                }
            }

            return m_UniqueSysAlarm;
        }

        /*初始化*/
        private void InitData()
        {
            for (int i = 0; i < (int)Type.Max; i++)
            {
                m_Alarm[i].ID = i + 1;
                m_Alarm[i].IsAlarm = false;
                m_Alarm[i].Level = TABLE_INIT_LEVEL[i];
                m_Alarm[i].Informat = TABLE_INIT_INFORMAT[i,Language];
                m_Alarm[i].Solution = TABLE_INIT_SOLUTION[i,Language];
            }
        }

        /*获取报警信息*/
        public StructAlarm GetAlarm(Type type)
        {
            return m_Alarm[(int)type];
        }

        /*获取报警信息*/
        public void SetAlarm(Type type, bool isAlarm)
        {
            m_Alarm[(int)type].IsAlarm = isAlarm;
        }

        /*清除所有*/
        public void ClearAll()
        {
            for (int i = 0; i < (int)SysAlarm.Type.Max; i++)
            {
                m_Alarm[i].IsAlarm = false;
            }
        }
    }
}
