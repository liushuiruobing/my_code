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
            public static bool RfidOk;                                                                             
            public static bool ArmControlerOk;                                        
            public static bool ServerOk;                                        

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

            //RFID
            public static bool ReceiveSalverArrive;                 //翻转后接收盘经过RFID扫描后置true,用于自动测试中
            public static bool ManualDebugReceiveSalverArrive;      //翻转后接收盘经过RFID扫描后置true，仅用于ManualDebug的测试中

            public static bool EmptySalverObstructAirCylUpArrive;
        }

        public static void InitSysStat()
        {
            SysStat.RobotOk = false;                   
            SysStat.CameraOk = false;

            SysStat.RfidOk = false;
            SysStat.ArmControlerOk = false;
            SysStat.ServerOk = false;

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

            SysStat.EmptySalverObstructAirCylUpArrive = false;
        }

        public static void InitAirCylAndSalverAndAxis()
        {
            SysStat.ReceiveSalverArrive = false;
            SysStat.ManualDebugReceiveSalverArrive = false;
        }

        public static void InitDataStruct()
        {
            InitSysStat();
            InitAirCylAndSalverAndAxis();
        }
    }
}
