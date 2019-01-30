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
            public static bool RobotAlarm;
            public static bool RobotWarning;
            public static bool RobotOk;                                          
            public static bool CameraOk;                                        
            public static bool QRCodeOk;                                         
            public static bool RfidOk;                                           
            public static bool OverturnSalverOk;                                         
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

            //单片机控制的气缸和托盘
            public static bool EmptySalverObstructAirCylUpArrive;           //空盘阻挡气缸上升到位
            public static bool EmptySalverObstructAirCylDownArrive;         //空盘阻挡气缸下降到位
            public static bool EmptySalverObstructSensor;                   //空盘阻挡传感器
            public static bool ReceiveSalverLiftingAirCylUpArrive;          //空盘升降气缸上升到位
            public static bool ReceiveSalverLiftingAirCylDownArrive;        //空盘升降气缸下降到位
            public static bool ConveyorLiftingAirCylUpArrive;               //传输线升降气缸上升到位
            public static bool ConveyorLiftingAirCylDownArrive;             //传输线升降气缸下降到位  
            public static bool OverturnSalverHomeArrive;                    //翻转托盘在原点         
            public static bool OverturnSalverTurnArrive;                    //翻转托盘翻转到位
            public static bool OverturnSalverLockAirCylGoArrive;            //翻转托盘锁定气缸进到位
            public static bool OverturnSalverLockAirCylBackArrive;          //翻转托盘锁定气缸退到位
            public static bool SalverRunOutStationSensor;                   //物料盘出站传感器

            //RFID
            public static bool ReceiveSalverArrive;                 //翻转后接收盘经过RFID扫描后置true,用于自动测试中
            public static bool ManualDebugReceiveSalverArrive;      //翻转后接收盘经过RFID扫描后置true，仅用于ManualDebug的测试中

            //机械臂
            public static bool RobotCylGoArrive;        //机械臂抓手气缸进到位
            public static bool RobotCylBackArrive;      //机械臂抓手气缸退到位
            public static bool RobotVacuoCheck;         //真空检测

            //抓取放置操作
            public static bool GrapAndPutOneSuccessed;
        }

        public static void InitSysStat()
        {
            SysStat.RobotAlarm = false;
            SysStat.RobotWarning = false;
            SysStat.RobotOk = false;                   
            SysStat.CameraOk = false;
            SysStat.QRCodeOk = false;
            SysStat.RfidOk = false;
            SysStat.OverturnSalverOk = false;
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

        public static void InitAirCylAndSalverAndAxis()
        {
            SysStat.EmptySalverObstructAirCylUpArrive = false;
            SysStat.EmptySalverObstructAirCylDownArrive = false;
            SysStat.EmptySalverObstructSensor = false;
            SysStat.ReceiveSalverLiftingAirCylUpArrive = false;
            SysStat.ReceiveSalverLiftingAirCylDownArrive = false;
            SysStat.ConveyorLiftingAirCylUpArrive = false;
            SysStat.ConveyorLiftingAirCylDownArrive = false;
            SysStat.OverturnSalverHomeArrive = false;
            SysStat.OverturnSalverTurnArrive = false;
            SysStat.OverturnSalverLockAirCylGoArrive = false;
            SysStat.OverturnSalverLockAirCylBackArrive = false;
            SysStat.SalverRunOutStationSensor = false;

            SysStat.ReceiveSalverArrive = false;
            SysStat.ManualDebugReceiveSalverArrive = false;

            SysStat.RobotCylGoArrive = false;
            SysStat.RobotCylBackArrive = false;
            SysStat.RobotVacuoCheck = false;

            SysStat.GrapAndPutOneSuccessed = false;
        }

        public static void InitDataStruct()
        {
            InitSysStat();
            InitAirCylAndSalverAndAxis();
        }
    }
}
