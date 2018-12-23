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
            public static byte Ready;                                           // 0 -- not , 1 -- ready
            public static byte Run;                                             // 0 -- not , 1 -- run
            public static byte YellowAlarm;                                     // 0 -- not , 1 -- yellow alarm
            public static byte RedAlarm;                                        // 0 -- not , 1 -- red alarm
            public static byte Pause;                                           // 0 -- run , 1 -- pause
            public static byte Stop;                                            // 0 -- not , 1 -- stop
            public static byte WorkMode;                                        // 0 -- Auto，1 -- manul
            public static byte Robot;                                           // 0 -- not , 1 -- device robot alarm
            public static byte Camera;                                          // 0 -- not , 1 -- Camera alarm
            public static byte QRCode;                                          // 0 -- not , 1 -- QRCode alarm
            public static byte RFID;                                            // 0 -- not , 1 -- RFID alarm
        }

        public struct SysAlarm
        {
            public static ushort Robot;                                         // ID = 1 , Level = 1 ; 0 -- normal , 1 -- pause(ID = 2) , 2 -- Alarm
            public static ushort Camera;                                        // ID = 2 , Level = 1 ; 0 -- normal , 1 -- Alarm
            public static ushort QRCode;                                        // ID = 3 , Level = 2 ; 0 -- normal , 1 -- Alarm
            public static ushort RFID;                                          // ID = 3 , Level = 2 ; 0 -- normal , 1 -- Alarm
        }
    }
}
