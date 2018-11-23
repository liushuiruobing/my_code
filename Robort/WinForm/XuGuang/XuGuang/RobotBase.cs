#define _DEBUG_ROBOT

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RABD.Lib;
using RABD.DROE.SystemDefine;
using System.Threading;

namespace RobotWorkstation
{
    //机器人
    public abstract class RobotBase
    {
        //public static double Speed;  //未使用
        public const ushort MODBUS_ADDR = 0x1110;
        public const short COM_LEN = 13;
        public const short TIMEOUT = 6000;  // 6000 * 10ms
        public const short MAX_GLOBAL_POINTS = 1000;  //最大1000个全局点位

        public const short MIN_SPEED = 0;  //最小速度
        public const short MAX_SPEED = 100;  //最大速度
        
        public short[] m_SendBuf = new short[13];
        //public static short ActNum;  // 0 -- reset action 
        // 1 to DEVICEBOX_ROW for uploading devices
        // DEVICEBOX_ROW + 1 to 2*DEVICEBOX_ROW for download OK devices
        // 2*DEVICEBOX_ROW + 1 to 2*DEVICEBOX_ROW + DEVICEBOX_ROW*DEVICEBOX_COL
        //public static DataStruct.Robot_Pos Point;
        //public static DataStruct.Robot_Pos Tst_Pos;
        //public static DataStruct.Robot_Pos[] DeviceBox_Pos = new DataStruct.Robot_Pos[DataStruct.DEVICEBOX_ROW];
        //public static DataStruct.Robot_Pos[,] FailBox_Pos = new DataStruct.Robot_Pos[DataStruct.DEVICEBOX_COL, DataStruct.DEVICEBOX_COL];

        public Robot m_Robot = new Robot();
        public bool m_IsConnected = false;

        public bool m_Ready = false;

        public RobotBase()
        {
        }

        /*开启机器人
         IP 格式 "192.168.1.124"
         return true -> succefully ; return false -> communication broken
        */
        public bool Open(string IP)
        {
            m_IsConnected = m_Robot.ConnectRobot(IP);
            if (m_IsConnected)
            {
                if (!m_Robot.IsConnected())
                {
                    return false;
                }
                else
                {
                    //ServoOn();
                    //m_Robot.RunProgram();
                    return true;
                }
            }
            else
            {
                return false;
            }
        }

        //关闭机器人
        public void Close()
        {
            if (m_IsConnected)
            {
                m_IsConnected = false;
                m_Robot.ServoOff();
                m_Robot.DisConnectRobot();
            }
        }

        /*运行脚本*/
        public void RunProgram()
        {
            if (!m_IsConnected)
            {
                return;
            }

            m_Robot.RunProgram();
        }

        /*暂停运行脚本*/
        public void PauseProgram()
        {
            if (!m_IsConnected)
            {
                return;
            }

            m_Robot.PauseProgram();
        }

        /*停止运行脚本*/
        public void StopProgram()
        {
            if (!m_IsConnected)
            {
                return;
            }

            m_Robot.StopProgram();
        }

        public string GetExecutorStateString()
        {
            RABD.Lib.eExecutorState state = RABD.Lib.eExecutorState.Close;
            if (m_IsConnected)
            {
                state = m_Robot.ExecutorState();
            }

            string strState = " ";
            switch (state)
            {
                case RABD.Lib.eExecutorState.Close:
                    strState = "关闭";
                    break;
                case RABD.Lib.eExecutorState.Pause:
                    strState = "暂停";
                    break;
                case RABD.Lib.eExecutorState.Running:
                    strState = "运行";
                    break;
                case RABD.Lib.eExecutorState.BreakPoint:
                    strState = "断点";
                    break;
            }

            return strState;
        }

        /*获取温度状态字符串*/
        public string GetTemperatureStateString()
        {
            RABD.Lib.eRobotTemperatureStatus state = RABD.Lib.eRobotTemperatureStatus.Normal;
            if (m_IsConnected)
            {
                state = m_Robot.TemperatureStatus();
            }

            string strState = " ";
            switch (state)
            {
                case RABD.Lib.eRobotTemperatureStatus.Normal:
                    strState = "正常";
                    break;
                case RABD.Lib.eRobotTemperatureStatus.OverHeat:
                    strState = "过热";
                    break;
                case RABD.Lib.eRobotTemperatureStatus.Modify:
                    strState = "测量";
                    break;
            }

            return strState;
        }

        public bool GetMovingState()
        {
            bool state = false;
            if (m_IsConnected)
            {
                state = m_Robot.RobotMovingStatus();
            }

            return state;
        }

        /*伺服开*/
        public void ServoOn()
        {
            if (!m_IsConnected)
            {
                return;
            }

            m_Robot.ServoOn();
        }

        /*伺服关*/
        public void ServoOff()
        {
            if (!m_IsConnected)
            {
                return;
            }

            m_Robot.ServoOff();
        }

        public void ResetAlarm()
        {
            if (!m_IsConnected)
            {
                return;
            }

            m_Robot.ResetAlarm();
        }

        public bool HasAlarm()
        {
            if (!m_IsConnected)
            {
                return false;
            }

            return m_Robot.HasAlarm();
        }

        public void SetJointDistance(int Dist)
        {
            if (!m_IsConnected)
            {
                return;
            }

            m_Robot.SetJointDistance(Dist);
            Thread.Sleep(100);
        }

        public void SetCartesianDistance(int Dist)
        {
            if (!m_IsConnected)
            {
                return;
            }

            m_Robot.SetCartesianDistance(Dist);
            Thread.Sleep(100);
        }

        /*设置速度 0~100%*/
        public void SetSpeed(int speed)
        {
            if (!m_IsConnected)
            {
                return;
            }

            m_Robot.SetSpeed(speed);
            Thread.Sleep(100);
        }

        public bool ServoState()
        {
            if (!m_IsConnected)
            {
                return false;
            }

            return m_Robot.ServoState();
        }

        public bool IsConnected()
        {
            return m_IsConnected;
        }


        public void Move(eDirection dir, bool IsStep)
        {
            if (!m_IsConnected)
            {
                return;
            }

            if (IsStep)
            {
                m_Robot.Step(dir);
            }
            else
            {
                m_Robot.Jog(dir);
            }
            m_Robot.Ready();
        }

        public void Stop(eAxisName J)
        {
            if (!m_IsConnected)
            {
                return;
            }

            m_Robot.MovStop(J);
        }

        public cPoint GetPos()
        {
            if (!m_IsConnected)
            {
                return new cPoint();
            }

            return m_Robot.GetPos();
        }

        public List<cPoint> GetGlobalPointData()
        {
            if (!m_IsConnected)
            {
                return null;
            }

            Thread.Sleep(100);  //必须延时,否则反应特别慢
            return m_Robot.GetGlobalPointData();
        }

        public cPoint GetGlobalPoint(int index)
        {
            if (!m_IsConnected)
            {
                return null;
            }

            return m_Robot.GetGlobalPoint(index);
        }

        public void GotoMovP(cPoint p)
        {
            if (!m_IsConnected)
            {
                return;
            }

            m_Robot.GotoMovP(p);
        }

        public void MovStop()
        {
            if (!m_IsConnected)
            {
                return;
            }

            m_Robot.MovStop();
        }

        public void TechGlobalPoint(int index)
        {
            if (!m_IsConnected)
            {
                return;
            }

            m_Robot.TechGlobalPoint(index);
        }

        public void SetOutputState(int index, bool TOnFOff)
        {
            if (!m_IsConnected)
            {
                return;
            }

            m_Robot.SetOutputState(index, TOnFOff);
        }

        public bool GetInputState(int index)
        {
            if (!m_IsConnected)
            {
                return false;
            }

            return m_Robot.GetInputState(index);
        }

        //设置机器人动作
        public short RunAction(int Action)
        {
            if (!m_IsConnected)
            {
                return 0;
            }

            short Cntr, Tmp;
            //short[] InBuf = new short[COM_LEN];

            //System.Diagnostics.Debug.WriteLine(Action);
            //System.Diagnostics.Debug.WriteLine("#");

            m_SendBuf[0] = 0x7e;
            // for Delta scara robot
            m_SendBuf[1] = 0x54;
            m_SendBuf[2] = 0x44;
            // 4 axis robot
            m_SendBuf[3] = 0x04;
            // robot address
            m_SendBuf[4] = 0x01;
            // command
            m_SendBuf[5] = 0x02;
            // parameter
            m_SendBuf[6] = (short)Action;
            m_SendBuf[7] = 0x00;
            m_SendBuf[8] = 0x00;
            m_SendBuf[9] = 0x00;
            m_SendBuf[10] = 0x00;
            // end
            Tmp = m_SendBuf[12] = 0x0d;
            // CRC
            m_SendBuf[10] = 0x00;
            for (Cntr = 0; Cntr < 10; Cntr++)
            {
                Tmp += m_SendBuf[Cntr];
            }

            //Tmp = (short)(~Tmp + 1);
            m_SendBuf[11] = Tmp;

            m_Robot.WriteMulitModbus(MODBUS_ADDR, m_SendBuf);
            m_Ready = false;

            return 0;
        }

        public bool QueryActionDone()
        {
#if _DEBUG_ROBOT
            Console.WriteLine("Query Action Done");
            return true;
#else

            if (!m_IsConnected)
            {
                return false;
            }

            if (!m_Ready)
            {
                if (!m_Robot.Ready())
                {
                    Console.WriteLine("m_Robot.Ready() false");
                    return false;
                }
                else
                {
                    Console.WriteLine("m_Robot.Ready() true");
                    m_Ready = true;
                }
            }

            short[] InBuf = new short[COM_LEN];
            InBuf = m_Robot.ReadMulitModbus(MODBUS_ADDR, COM_LEN);

            /*
            for (int i = 0; i < COM_LEN; i++)
            {
                Console.WriteLine(i + " " + InBuf[i] + " ");
            }
            */

            /*CRC 校验,机器人程序有问题,暂不能支持
            short Tmp = InBuf[COM_LEN - 3 - 1];
            for (int i = 0; i <= 6; i++)
            {
                Tmp += InBuf[Cntr];
            }
            */

            if ((InBuf[0] == 0x7e) && (InBuf[6] == 0x00) && (InBuf[9] == 0x0d))  // && (Tmp == InBuf[8])
            {
                Console.WriteLine("m_Robot.ReadMulitModbus() true");
                return true;
            }
            else
            {
                Console.WriteLine("m_Robot.ReadMulitModbus() false");
                return false;
            }
#endif
        }

        /*
        * **********************************************************************************************************************
        * Hand , 0 -> right hand, 1 -> left hand
        * X,Y,Z unit is mm
        * **********************************************************************************************************************
        */
        //public void GetState()
        //{
        //    if (m_Robot.HasAlarm())
        //    {
        //        DataStruct.SysStat.Robot = 2;
        //        DataStruct.SysAlarm.Robot = 2;  // alarm
        //    }
        //    else
        //    {
        //        if (m_Robot.HasWarning())
        //        {
        //            DataStruct.SysStat.Robot = 1;
        //            DataStruct.SysAlarm.Robot = 1;  // warn
        //        }
        //        else
        //        {
        //            DataStruct.SysStat.Robot = 0;
        //            DataStruct.SysAlarm.Robot = 0;
        //        }
        //    }
        //}

        /*设置机器人报警消息*/
        //public void SetAlarm(SysAlarm.Type type)
        //{
        //    SysAlarm sa = SysAlarm.GetInstance();
        //    sa.SetAlarm(type, true);
        //}
    }
}
