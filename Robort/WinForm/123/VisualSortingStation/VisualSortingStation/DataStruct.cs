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
            public static byte WorkMode;                                        // 0 -- Auto，1 -- manul
            public static byte Robot;                                           // 0 -- not , 1 -- device robot alarm
            public static byte Camera;                                          // 0 -- not , 1 -- Camera alarm
            public static byte QRCode;                                          // 0 -- not , 1 -- QRCode alarm
            public static byte RFID;                                            // 0 -- not , 1 -- RFID alarm

            //按键
            public static bool Ready;
            public static bool Run;
            public static bool Pause;
            public static bool Stop;
            public static bool Scram; //急停
            public static bool Reset;

            //塔灯
            public static bool RedAlarm;
            public static bool OriangeAlarm;
            public static bool LedGreen;
            public static bool LedBlue;        
            public static bool Beep;    //报警蜂鸣

            //单片机控制的气缸和托盘
            public static bool EmptySalverAirCylUpArrive;           //空盘气缸上升到位
            public static bool EmptySalverAirCylDownArrive;         //空盘气缸下降到位
            public static bool OverturnSalverArrive;                //翻转托盘到位
            public static bool OverturnSalverAirCylGoArrive;        //翻转托盘锁定气缸进到位
            public static bool OverturnSalverAirCylBackArrive;      //翻转托盘锁定气缸退到位
            public static bool ReceiveSalverArrive;                 //翻转后接收托盘到位

            //机械臂
            public static bool RobotCylGoArrive;        //机械臂抓手气缸进到位
            public static bool RobotCylBackArrive;      //机械臂抓手气缸退到位
            public static bool RobotVacuoCheck;         //真空检测

            //抓取放置操作
            public static bool GrapAndPutOneSuccessed;
        }

        public struct SysAlarm
        {
            public static ushort Robot;                                         // ID = 1 , Level = 1 ; 0 -- normal , 1 -- pause(ID = 2) , 2 -- Alarm
            public static ushort Camera;                                        // ID = 2 , Level = 1 ; 0 -- normal , 1 -- Alarm
            public static ushort QRCode;                                        // ID = 3 , Level = 2 ; 0 -- normal , 1 -- Alarm
            public static ushort RFID;                                          // ID = 3 , Level = 2 ; 0 -- normal , 1 -- Alarm
        }

        public static void InitSysStat()
        {
            SysStat.WorkMode = 0x01;                // 0 -- Auto，1 -- manul
            SysStat.Robot = 1;                   // 0 -- not , 1 -- device robot alarm
            SysStat.Camera = 1;
            SysStat.QRCode = 0;
            SysStat.RFID = 1;

            SysStat.Ready = false;
            SysStat.Run = false;
            SysStat.Pause = false;
            SysStat.Stop = false;
            SysStat.Scram = false;
            SysStat.Reset = false;

            SysStat.RedAlarm = false;
            SysStat.OriangeAlarm = false;
            SysStat.LedGreen = false;
            SysStat.LedBlue = false;
            SysStat.Beep = false;

            SysStat.EmptySalverAirCylUpArrive = false;
            SysStat.EmptySalverAirCylDownArrive = false;
            SysStat.OverturnSalverArrive = false;
            SysStat.OverturnSalverAirCylGoArrive = false;
            SysStat.OverturnSalverAirCylBackArrive = false;
            SysStat.ReceiveSalverArrive = false;

            SysStat.RobotCylGoArrive = false;
            SysStat.RobotCylBackArrive = false;
            SysStat.RobotVacuoCheck = false;

            SysStat.GrapAndPutOneSuccessed = false;
        }

        public static void InitSysAlarm()
        {
            SysAlarm.Robot = 0x00;                                         // ID = 1 , Level = 1 ; 0 -- normal , 1 -- pause(ID = 2) , 2 -- Alarm
            SysAlarm.Camera = 0x00;
            SysAlarm.QRCode = 0x00;
            SysAlarm.RFID = 0x00;
        }
    }
}
