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
            public static byte Robot;                                           // 0 -- not , 1 -- device robot alarm
            public static byte Camera;                                          // 0 -- not , 1 -- Camera alarm
            public static byte QRCode;                                          // 0 -- not , 1 -- QRCode alarm
            public static byte RFID;                                            // 0 -- not , 1 -- RFID alarm
            public static byte Salver;                                          // 0 -- not , 1 -- RFID alarm
            public static byte ARM;                                             // 0 -- not , 1 -- ARM alarm
            public static byte Server;                                          // 0 -- not , 1 -- Server alarm

            //系统的运行状态
            public static bool Ready;          
            public static bool Run;   
            public static bool Pause;
            public static bool Stop;
            public static bool Reset;

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

            //单片机控制的气缸和托盘
            public static bool EmptySalverAirCylUpArrive;           //空盘气缸上升到位
            public static bool EmptySalverAirCylDownArrive;         //空盘气缸下降到位
            public static bool OverturnSalverArrive;                //翻转托盘到位
            public static bool OverturnSalverAirCylGoArrive;        //翻转托盘锁定气缸进到位
            public static bool OverturnSalverAirCylBackArrive;      //翻转托盘锁定气缸退到位
            public static bool ReceiveSalverArrive;                 //翻转后接收盘经过RFID扫描后置true,用于自动测试中
            public static bool ManualDebugReceiveSalverArrive;      //翻转后接收盘经过RFID扫描后置true，仅用于ManualDebug的测试中

            //机械臂
            public static bool RobotCylGoArrive;        //机械臂抓手气缸进到位
            public static bool RobotCylBackArrive;      //机械臂抓手气缸退到位
            public static bool RobotVacuoCheck;         //真空检测

            //抓取放置操作
            public static bool GrapAndPutOneSuccessed;
        }

        public struct SysStateAlarm
        {
            public static ushort Robot;        // ID = 1 , Level = 1 ; 0 -- normal , 1 -- pause(ID = 2) , 2 -- Alarm
            public static ushort Camera;       // ID = 2 , Level = 1 ; 0 -- normal , 1 -- Alarm
            public static ushort QRCode;       // ID = 3 , Level = 1 ; 0 -- normal , 1 -- Alarm
            public static ushort RFID;         // ID = 4 , Level = 2 ; 0 -- normal , 1 -- Alarm
            public static ushort Salver;       // ID = 5 , Level = 2 ; 0 -- normal , 1 -- Alarm
            public static ushort ARM;          // ID = 6 , Level = 2 ; 0 -- normal , 1 -- Alarm
            public static ushort Server;       // ID = 7 , Level = 2 ; 0 -- normal , 1 -- Alarm
        }

        public static void InitSysStat()
        {
            SysStat.Robot = 1;                   // 0 -- not , 1 -- device robot alarm
            SysStat.Camera = 1;
            SysStat.QRCode = 1;
            SysStat.RFID = 1;
            SysStat.Salver = 1;
            SysStat.ARM = 1;
            SysStat.Server = 1;

            SysStat.Ready = false;
            SysStat.Run = false;
            SysStat.Pause = false;
            SysStat.Stop = false;
            SysStat.Reset = false;

            SysStat.KeyRun = false;
            SysStat.KeyPause = false;
            SysStat.KeyStop = false;
            SysStat.KeyReset = false;

            SysStat.LedRed = false;
            SysStat.LedOriange = false;
            SysStat.LedGreen = false;
            SysStat.LedBlue = false;
            SysStat.Beep = false;

            SysStat.EmptySalverAirCylUpArrive = false;
            SysStat.EmptySalverAirCylDownArrive = false;
            SysStat.OverturnSalverArrive = false;
            SysStat.OverturnSalverAirCylGoArrive = false;
            SysStat.OverturnSalverAirCylBackArrive = false;
            SysStat.ReceiveSalverArrive = false;
            SysStat.ManualDebugReceiveSalverArrive = false;

            SysStat.RobotCylGoArrive = false;
            SysStat.RobotCylBackArrive = false;
            SysStat.RobotVacuoCheck = false;

            SysStat.GrapAndPutOneSuccessed = false;
        }

        public static void InitSysStateAlarm()
        {
            SysStateAlarm.Robot = 0x00;      // ID = 1 , Level = 1 ; 0 -- normal , 1 -- pause(ID = 2) , 2 -- Alarm
            SysStateAlarm.Camera = 0x00;
            SysStateAlarm.QRCode = 0x00;
            SysStateAlarm.RFID = 0x00;
            SysStateAlarm.Salver = 0x00;       // ID = 5 , Level = 2 ; 0 -- normal , 1 -- Alarm
            SysStateAlarm.ARM = 0x00;          // ID = 6 , Level = 2 ; 0 -- normal , 1 -- Alarm
            SysStateAlarm.Server = 0x00;       // ID = 7 , Level = 2 ; 0 -- normal , 1 -- Alarm
        }

        public static void InitDataStruct()
        {
            InitSysStat();
            InitSysStateAlarm();
        }
    }
}
