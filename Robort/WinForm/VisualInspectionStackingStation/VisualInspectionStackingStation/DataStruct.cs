using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotWorkstation
{
    public static class DataStruct
    {
        public struct SysStat
        {
            public static bool RobotOk;                                          
            public static bool CameraOk;
            public static bool QRCodeOk;
            public static bool ArmControlerOk;                                        
            public static bool ServerOk;                                        

            //系统的运行状态
            public static bool StationReady;          
            public static bool StationRun;   
            public static bool StationPause;
            public static bool StationStop;
            public static bool StationReset;

            //外部按键输入
            public static bool KeyRun;
            public static bool KeyPause;
            public static bool KeyStop;
            public static bool KeyReset;

            //塔灯
            public static bool LedRed;  
            public static bool LedOriange;
            public static bool LedGreen;
            public static bool LedBlue;        
            public static bool Beep;    //报警蜂鸣
        }

        public static void InitSysStat()
        {
            SysStat.RobotOk = false;                   
            SysStat.CameraOk = false;
            SysStat.QRCodeOk = false;
            SysStat.ArmControlerOk = false;
            SysStat.ServerOk = false;

            SysStat.StationReady = false;
            SysStat.StationRun = false;
            SysStat.StationPause = false;
            SysStat.StationStop = false;
            SysStat.StationReset = false;

            SysStat.KeyRun = false;
            SysStat.KeyPause = false;
            SysStat.KeyStop = false;
            SysStat.KeyReset = false;

            SysStat.LedRed = false;
            SysStat.LedOriange = false;
            SysStat.LedGreen = false;
            SysStat.LedBlue = false;
            SysStat.Beep = false;
        }

        public static void InitAirCylAndAxis()
        {

        }

        public static void InitDataStruct()
        {
            InitSysStat();
            InitAirCylAndAxis();
        }
    }
}
