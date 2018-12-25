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

    public class VisualSortingStation  //视觉分拣业务类
    {
        public static IO m_IO = IO.GetInstance();               
        public static int m_DevicesTotal = 0;
        private const int m_OnePanelDevicesMax = 16;
        private static AutoRunAction m_AutoRunAction = AutoRunAction.AuoRunStart;
        private volatile static bool m_ShouldExit = false;

        private static RobotDevice m_Robot = RobotDevice.GetInstance();
        private static QRCode m_QRCode = QRCode.GetInstance();
        private static bool m_ScanQRCode = false;
        public static List<string> m_QRCodeStr = new List<string>();

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
            m_QRCodeStr.Clear();
            m_QRCode.QRCodeRecvDataEvent += new EventHandler(QRCodeRecvData);

            //创建Server端线程

            //创建Client线程

            //创建网络共享文件

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
                    {
                        bool Start = false;
                        //检查各盘是否到位，都无误后 Start = true

                        if(Start)
                            m_AutoRunAction = AutoRunAction.AutoRunGetGrapCoords;
                    }break;
                case AutoRunAction.AutoRunGetGrapCoords:        //获得抓取坐标
                    {
                        bool Coords = false;

                        //调用视觉算法获取坐标
                        double x = 0;
                        double y = 0;
                        double z = 0;
                        double rz = 0;

                        //检查坐标范围,正确则Coords = true
                        if (true)
                        {
                            m_Robot.SetGrapPointCoords(x, y, z, rz);
                            Coords = true;
                        }

                        if (Coords)
                            m_AutoRunAction = AutoRunAction.AutoRunMoveToGrap;
                        else
                            m_AutoRunAction = AutoRunAction.AutoRunGetGrapCoords;

                    }break;
                case AutoRunAction.AutoRunMoveToGrap:           //移动到位并抓取   
                    {
                        //移动到指定位置抓手气缸进到位，后吸起器件，上位机发指令，机械臂脚本解析，执行动作
                        //m_IO.SetRobotIo();

                        //吸嘴真空检查是否真的抓取成功 Grap = true
                        if (DataStruct.SysStat.RobotVacuoCheck) //监听机器人的通信线程设置此RobotVacuoCheck
                            m_AutoRunAction = AutoRunAction.AutoRunMoveToScanQRCode;
                        else
                            m_AutoRunAction = AutoRunAction.AutoRunMoveToGrap;

                    }break;
                case AutoRunAction.AutoRunMoveToScanQRCode:     //移动到位并扫码,检查扫码格式，不正确则依然执行此动作v          
                    {                       
                        //移动到位

                        //读取二维码

                        //检查二维码，不为None,格式正确，则ScanQRCode = true,否则重新识别

                        if (m_ScanQRCode)
                            m_AutoRunAction = AutoRunAction.AutoRunMoveToPut;
                        else
                            m_AutoRunAction = AutoRunAction.AutoRunMoveToScanQRCode;
                    }break;
                case AutoRunAction.AutoRunMoveToPut:            //移动到位并放下，计数后开始下一件，满总数后下一步    
                    {
                        bool Put = false;
                        int TempCount = 0;

                        //放下件

                        //检查真空是否真的放下，真放下则Put = true, TempCount+1;
                        if (Put)
                            TempCount++;
                        else
                            m_AutoRunAction = AutoRunAction.AutoRunMoveToPut;

                        if (TempCount >= m_OnePanelDevicesMax)
                        {
                            m_AutoRunAction = AutoRunAction.AutoRunTurnOverPanel;
                            TempCount = 0;
                        }
                        else
                        {
                            m_AutoRunAction = AutoRunAction.AutoRunGetGrapCoords;
                        }                           
                    }break;
                case AutoRunAction.AutoRunTurnOverPanel:        //计数满则翻盘运走，从头开始
                    {
                        bool TurnOver = false;
                        //设置气缸锁定器件

                        //翻转

                        //翻转成功，解锁器件，延时，通知运走
                        if (TurnOver)
                        {
                            //存储文件，通知运走
                            if (m_QRCodeStr.Count >= m_OnePanelDevicesMax) //
                            {
                                var temp = m_QRCodeStr.Distinct(); //却掉重复扫描的 
                                if (temp.Count() == m_OnePanelDevicesMax)
                                {
                                    //写入到网络共享文件中

                                    m_AutoRunAction = AutoRunAction.AuoRunStart;
                                    m_DevicesTotal += m_OnePanelDevicesMax;
                                }                         
                            }
                        }                     
                    }break;
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
                return 0;
            else if (DataStruct.SysStat.YellowAlarm && !DataStruct.SysStat.RedAlarm)
                return 1;
            else if (DataStruct.SysStat.RedAlarm && !DataStruct.SysStat.YellowAlarm)
                return 2;
            else
                return 3;
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

        public static void QRCodeRecvData(object sender, EventArgs e)
        {
            if (e is QRCodeEventArgers)
            {
                QRCodeEventArgers Temp = e as QRCodeEventArgers;
                bool Check = CheckAndSaveReadData(Temp.QRCodeRecv);
                if (Check)
                    m_ScanQRCode = true;
                else
                    m_ScanQRCode = false;                
            }
        }

        //校验读取数据的准确性
        public static bool CheckAndSaveReadData(string Code)
        {
            bool Check = false;
            string temp = String.Copy(Code);

            //检查读取到的数据格式是否正确 “24个，12个，12个”KR12BN5901313ABPVKBF0238,00C3F413543E,00C3F413543F
            const char SplitChar = ',';         
            var StrAfterSplit = temp.Split(SplitChar);
            if (StrAfterSplit.Length == 3 && StrAfterSplit[0].Length == 24 && StrAfterSplit[1].Length == 12 && StrAfterSplit[2].Length == 12)
            {
                Check = true;
                m_QRCodeStr.Add(Code);
            }

            return Check;
        }
    }
}
