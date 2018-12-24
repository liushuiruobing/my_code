using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotWorkstation
{
    class VisualSortingStation  //视觉分拣业务类
    {
        public static IO m_IO = IO.GetInstance();

        // 0 -- run , 1 -- stop , 2 -- pause
        public static int CheckSysAlarm()
        {
            //DeviceRobot.Get_Rbt_Stat();

            // check robot
            if (DataStruct.SysAlarm.Robot >= 1)
            {
                if (DataStruct.SysAlarm.Robot == 2)
                {
                    DataStruct.SysStat.RedAlarm = true;
                }
                else if (DataStruct.SysAlarm.Robot == 1)
                {
                    DataStruct.SysStat.YellowAlarm = true;
                }
                DataStruct.SysStat.Robot = 1;
            }

            //check camera
            if (DataStruct.SysAlarm.Camera == 1)
            {
                DataStruct.SysStat.Camera = 1;
                DataStruct.SysStat.RedAlarm = true;
            }

            //check QRCode
            if (DataStruct.SysAlarm.QRCode == 1)
            {
                DataStruct.SysStat.QRCode = 1;
                DataStruct.SysStat.RedAlarm = true;
            }

            //check RFID
            if (DataStruct.SysAlarm.RFID == 1)
            {
                DataStruct.SysStat.RFID = 1;
                DataStruct.SysStat.RedAlarm = true;
            }

            //check PLC

            //check IO Control Board


            if ((!DataStruct.SysStat.YellowAlarm) && (!DataStruct.SysStat.RedAlarm))
            {
                return 0;
            }
            else if (DataStruct.SysStat.YellowAlarm && !DataStruct.SysStat.RedAlarm)
            {
                return 1;
            }
            else if (DataStruct.SysStat.RedAlarm && !DataStruct.SysStat.YellowAlarm)
            {
                return 2;
            }
            else
            {
                return 3;
            }
        }

        //Alarm type , 0 = Green ; 1 = Yellow ; 2 = Red ; 3 = Red & Yellow
        public static void SetSysAlarm(byte AlarmType)
        {
            if (AlarmType == 0)
            {
                m_IO.SetControlBoardIo(IOType.IOTypeLedGreen, IOValue.IOValueHigh);
                m_IO.SetControlBoardIo(IOType.IOTypeLedYellow, IOValue.IOValueLow);
                m_IO.SetControlBoardIo(IOType.IOTypeLedRed, IOValue.IOValueLow);
            }
            else if (AlarmType == 1)
            {
                m_IO.SetControlBoardIo(IOType.IOTypeLedGreen, IOValue.IOValueLow);
                m_IO.SetControlBoardIo(IOType.IOTypeLedYellow, IOValue.IOValueHigh);
                m_IO.SetControlBoardIo(IOType.IOTypeLedRed, IOValue.IOValueLow);
            }
            else if (AlarmType == 2)
            {
                m_IO.SetControlBoardIo(IOType.IOTypeLedGreen, IOValue.IOValueLow);
                m_IO.SetControlBoardIo(IOType.IOTypeLedYellow, IOValue.IOValueLow);
                m_IO.SetControlBoardIo(IOType.IOTypeLedRed, IOValue.IOValueHigh);
            }
            else if (AlarmType == 3)
            {
                m_IO.SetControlBoardIo(IOType.IOTypeLedGreen, IOValue.IOValueLow);
                m_IO.SetControlBoardIo(IOType.IOTypeLedYellow, IOValue.IOValueHigh);
                m_IO.SetControlBoardIo(IOType.IOTypeLedRed, IOValue.IOValueHigh);
            }
        }
    }
}
