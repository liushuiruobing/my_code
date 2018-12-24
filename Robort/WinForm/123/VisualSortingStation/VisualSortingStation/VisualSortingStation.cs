using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RobotWorkstation
{
    public enum AutoRunAction
    {
        AuoRunStart = 0,              //开始
        AutoRunGetGrapCoords,         //获得抓取坐标
        AutoRunMoveToGrap,            //移动到位并抓取
        AutoRunMoveToScanQRCode,      //移动到位并扫码,检查扫码格式，不正确则依然执行此动作
        AutoRunMoveToPut,             //移动到位并放下，计数后开始下一件，满总数后下一步
        AutoRunTurnOverPanel,         //计数满则翻盘运走，从头开始

    }

    class VisualSortingStation  //视觉分拣业务类
    {
        public static IO m_IO = IO.GetInstance();
        private static AutoRunAction m_AutoRunAction = AutoRunAction.AuoRunStart;
        private volatile static bool m_ShouldExit = false;
        public static bool ShouldExit
        {
            set
            {
                m_ShouldExit = value;
            }
            get
            {
                return m_ShouldExit;
            }

        }
        public static void MainThreadFunc()
        {
            DataStruct.InitSysStat();
            DataStruct.InitSysAlarm();

            //创建Server端线程

            //创建Client线程



            while (!m_ShouldExit)
            {
                if (DataStruct.SysStat.Run )
                {
                    AutoSortingRun();
                }

                Thread.Sleep(100);
            }

            m_ShouldExit = false;
        }

        public static void TcpServerRun()
        {
            //创建TCP服务端分别处理PLC和MIS系统的消息，让工作站不知道是谁的消息，只知道是某个Client的消息
        }

        public static void TcpClientRun()
        {
            //创建客户端处理与单片机的消息，让工作站不知道是谁的消息，只知道和某个Server端的消息
        }

        public static void AutoSortingRun()
        {
            //执行各动作
            switch (m_AutoRunAction)
            {
                case AutoRunAction.AuoRunStart:                 //开始
                    break;
                case AutoRunAction.AutoRunGetGrapCoords:        //获得抓取坐标          
                    break;
                case AutoRunAction.AutoRunMoveToGrap:           //移动到位并抓取       
                    break;
                case AutoRunAction.AutoRunMoveToScanQRCode:     //移动到位并扫码,检查扫码格式，不正确则依然执行此动作v          
                    break;
                case AutoRunAction.AutoRunMoveToPut:            //移动到位并放下，计数后开始下一件，满总数后下一步    
                    break;
                case AutoRunAction.AutoRunTurnOverPanel:        //计数满则翻盘运走，从头开始
                    break;
                default:
                    break;
            }
        }

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
