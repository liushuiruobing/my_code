using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RobotWorkstation
{
    public struct RFID_STATUS 
    {
        public bool Done;
        public bool Busy;
        public bool Error;
        public bool XcvrCon;
        public bool XcvrOn;
        public bool Tp;
        public bool Tfr;

        public void InitStatus()
        {
            Done = false;
            Busy = false;
            Error = false;
            XcvrCon = false;
            XcvrOn = false;
            Tp = false;
            Tfr = false;
        }
    }

    public class RFID
    {
        private static RFID m_UniqueRFID = null;
        private static readonly object m_Locker = new object();

        public Master m_ModbusMaster;
        public string m_Ip = "192.168.1.21";
        private readonly ushort m_Port = 502;  //默认502不允许修改
        public ushort m_CurCh = 0;
        RFID_STATUS[] m_RfidStatus = new RFID_STATUS[2];  //两个通道
        private byte[] data;
        private byte cmdByte;
        public string m_StrReadTemp = null;
        public Queue<string> m_QueueRead = new Queue<string>();
        private System.Timers.Timer m_CheckStatusTimer = new System.Timers.Timer();
        private readonly ushort m_Ch0Addr = 2048;

        public bool m_IsConnected
        {
            get
            {
                if (m_ModbusMaster != null)
                    return m_ModbusMaster.connected;
                else
                    return false;
            }
        }

        // 定义私有构造函数，使外界不能创建该类实例
        private RFID()
        {
            for (int i = 0; i < m_RfidStatus.Length; i++)
            {
                m_RfidStatus[i].InitStatus();
            } 
            if (m_CheckStatusTimer != null)
                m_CheckStatusTimer.Elapsed += OnTimedCheckStatus;
        }

        /// <summary>
        /// 定义公有方法提供一个全局访问点,同时你也可以定义公有属性来提供全局访问点
        /// </summary>
        /// <returns></returns>
        public static RFID GetInstance()
        {
            if (m_UniqueRFID == null)
            {
                lock (m_Locker)
                {
                    if (m_UniqueRFID == null)
                        m_UniqueRFID = new RFID();
                }
            }
            return m_UniqueRFID;
        }

        public bool InitRFID()
        {
            return Connect();             
        }

        public bool Connect()  // Create new modbus master and add event functions
        {
            try
            {             
                m_ModbusMaster = new Master(m_Ip, m_Port);
                m_ModbusMaster.OnResponseData += new Master.ResponseData(ModbusMaster_OnResponseData);
                if (m_ModbusMaster.connected == true)
                {
                    //创建定时器读取状态
                    m_CheckStatusTimer.Interval = 10;
                    m_CheckStatusTimer.Start();
                }
                return m_ModbusMaster.connected;
            }
            catch (SystemException error)
            {
                MessageBox.Show(error.Message);
                return false;
            }
        }

        public void Enable(ushort Ch)
        {         
            ushort ID = 1;
            byte unit = 0;
            ushort StartAddress = (ushort)(2048 + Ch * 6);
            byte[] sendCmdData = new byte[2];
            cmdByte = Set_bit(cmdByte, 8, true);
            sendCmdData[0] = 7;
            sendCmdData[1] = cmdByte;
            m_ModbusMaster.WriteSingleRegister(ID, unit, StartAddress, sendCmdData);
        }

        public void Disable(ushort Ch)
        {          
            ushort ID = 1;
            byte unit = 0;
            ushort StartAddress = (ushort)(2048 + Ch * 6);
            byte[] sendCmdData = new byte[2];
            cmdByte = Set_bit(cmdByte, 8, false);
            sendCmdData[0] = 7;
            sendCmdData[1] = cmdByte;
            m_ModbusMaster.WriteSingleRegister(ID, unit, StartAddress, sendCmdData);
        }

        public void Init(ushort Ch)
        {           
            ushort ID = 1;
            byte unit = 1;//初始化
            ushort StartAddress = (ushort)(2048 + Ch * 6);

            byte[] sendCmdData = new byte[2];
            cmdByte = Set_bit(cmdByte, 1, true);
            sendCmdData[0] = 7;
            sendCmdData[1] = cmdByte;
            m_ModbusMaster.WriteSingleRegister(ID, unit, StartAddress, sendCmdData);
            Thread.Sleep(30);

            cmdByte = Set_bit(cmdByte, 1, false);
            sendCmdData[0] = 7;
            sendCmdData[1] = cmdByte;
            m_ModbusMaster.WriteSingleRegister(ID, unit, StartAddress, sendCmdData);
        }

        public void Write(ushort Ch, string  str)
        {
            byte[] sendData = new byte[10];
            byte[] sendCmdData = new byte[2];
            char[] tmp = str.ToCharArray();

            ushort ID;
            byte unit;
            ushort StartAddress;

            if ((str == "") || (str.Length != 16) || (m_RfidStatus[Ch].Tp != true))
            {
                MessageBox.Show("请输入要写入的16个字节的数据,并确保载码体在感应范围内！");
            }
            else
            {

                for (int i = 0; i < 8; i++)
                {
                    sendData[i + 2] = (byte)tmp[i];
                }
                ID = 2;
                unit = 0;
                StartAddress = (ushort)(2049 + Ch * 6);
                sendData[0] = 0; //起始地址
                sendData[1] = 0;
                m_ModbusMaster.WriteMultipleRegister(ID, unit, StartAddress, sendData);
                Thread.Sleep(30);

                StartAddress = (ushort)(2048 + Ch * 6);
                cmdByte = Set_bit(cmdByte, 4, true);
                sendCmdData[0] = 7;
                sendCmdData[1] = cmdByte;
                m_ModbusMaster.WriteSingleRegister(ID, unit, StartAddress, sendCmdData);
                Thread.Sleep(30);

                cmdByte = Set_bit(cmdByte, 4, false);
                sendCmdData[0] = 7;
                sendCmdData[1] = cmdByte;
                m_ModbusMaster.WriteSingleRegister(ID, unit, StartAddress, sendCmdData);
                Thread.Sleep(30);

                for (int i = 0; i < 8; i++)
                {
                    sendData[i + 2] = (byte)tmp[i + 8];
                }
                ID = 2;
                unit = 0;
                StartAddress = (ushort)(2049 + Ch * 6);
                sendData[0] = 8; //起始地址
                sendData[1] = 0;
                m_ModbusMaster.WriteMultipleRegister(ID, unit, StartAddress, sendData);
                Thread.Sleep(30);

                StartAddress = (ushort)(2048 + Ch * 6);
                cmdByte = Set_bit(cmdByte, 4, true);
                sendCmdData[0] = 7;
                sendCmdData[1] = cmdByte;
                m_ModbusMaster.WriteSingleRegister(ID, unit, StartAddress, sendCmdData);
                Thread.Sleep(30);

                cmdByte = Set_bit(cmdByte, 4, false);
                sendCmdData[0] = 7;
                sendCmdData[1] = cmdByte;
                m_ModbusMaster.WriteSingleRegister(ID, unit, StartAddress, sendCmdData);
            }
        }

        public void Read(ushort Ch)
        {
            ushort ID;
            byte unit;
            ushort StartAddress;
            byte[] sendCmdData;

            if (m_RfidStatus[Ch].Tp  == true)
            {
                ID = 3;
                unit = 0;
                StartAddress = (ushort)(2049 + Ch * 6);
                sendCmdData = new byte[2];
                sendCmdData[0] = 0;//起始地址
                sendCmdData[1] = 0;
                m_ModbusMaster.WriteSingleRegister(ID, unit, StartAddress, sendCmdData);
                Thread.Sleep(30);

                cmdByte = Set_bit(cmdByte, 5, true);
                ID = 3;
                unit = 0;
                StartAddress = (ushort)(2048 + Ch * 6);

                sendCmdData[0] = 7;
                sendCmdData[1] = cmdByte;
                //sendCmdData[2] = 0;//起始地址
                //sendCmdData[3] = 0;
                m_ModbusMaster.WriteSingleRegister(ID, unit, StartAddress, sendCmdData);
                Thread.Sleep(30);

                cmdByte = Set_bit(cmdByte, 5, false);
                sendCmdData[0] = 7;
                sendCmdData[1] = cmdByte;
                m_ModbusMaster.WriteSingleRegister(ID, unit, StartAddress, sendCmdData);
                Thread.Sleep(30);

                ID = 6;
                StartAddress = 2;
                byte Length = 4;

                m_ModbusMaster.ReadInputRegister(ID, unit, StartAddress, Length);
                Thread.Sleep(30);

                ID = 3;
                unit = 0;
                StartAddress = (ushort)(2049 + Ch * 6);
                sendCmdData = new byte[2];
                sendCmdData[0] = 8;//起始地址
                sendCmdData[1] = 0;
                m_ModbusMaster.WriteSingleRegister(ID, unit, StartAddress, sendCmdData);
                Thread.Sleep(30);

                cmdByte = Set_bit(cmdByte, 5, true);
                ID = 3;
                unit = 0;
                StartAddress = (ushort)(2048 + Ch * 6);
                sendCmdData = new byte[4];
                sendCmdData[0] = 7;
                sendCmdData[1] = cmdByte;
                //sendCmdData[2] = 8;//起始地址
                //sendCmdData[3] = 0;
                m_ModbusMaster.WriteSingleRegister(ID, unit, StartAddress, sendCmdData);
                Thread.Sleep(30);

                cmdByte = Set_bit(cmdByte, 5, false);
                sendCmdData[0] = 7;
                sendCmdData[1] = cmdByte;
                m_ModbusMaster.WriteSingleRegister(ID, unit, StartAddress, sendCmdData);
                Thread.Sleep(30);

                ID = 5;

                StartAddress = 2;
                Length = 4;

                m_ModbusMaster.ReadInputRegister(ID, unit, StartAddress, Length);

            }
            else
            {
                MessageBox.Show("请先将载码体放入读写区域！");
            }
        }

        private void ModbusMaster_OnResponseData(ushort ID, byte unit, byte function, byte[] values)
        {
            // Identify requested data
            switch (ID)
            {
                case 1:
                    {
                        if (unit == 3)
                        {
                            data = values;
                            string a = null;
                            string b = null;
                            for (int i = 0; i < data.Length; i++)
                            {
                                a = Convert.ToString(data[i], 16).ToUpper();
                                if (a.Length == 1)
                                {
                                    b += "0" + a;
                                }
                                else
                                {
                                    b += a;
                                }
                            }
                            MessageBox.Show(b);
                        }
                    }break;
                case 4:
                    {
                        if (unit == 0)//状态读取
                        {
                            data = values;
                            //this.textBox3.Dispatcher.Invoke(new Action(delegate() { textBox3.Text = data[1].ToString(); }));
                            
                            //ch0 DONE
                            if ((data[1] & 128) == 128)
                                m_RfidStatus[0].Done = true;
                            else
                                m_RfidStatus[0].Done = false;

                            //ch1 DONE
                            if ((data[13] & 128) == 128)
                                m_RfidStatus[1].Done = true;
                            else
                                m_RfidStatus[1].Done = false;

                            //ch0 BUSY
                            if ((data[1] & 64) == 64)
                                m_RfidStatus[0].Busy = true;
                            else
                                m_RfidStatus[0].Busy = false;

                            //ch1 BUSY
                            if ((data[13] & 64) == 64)
                                m_RfidStatus[1].Busy = true;
                            else
                                m_RfidStatus[1].Busy = false;

                            //ch0 ERROR
                            if ((data[1] & 32) == 32)
                                m_RfidStatus[0].Error = true;
                            else
                                m_RfidStatus[0].Error = false;

                            //ch1 ERROR
                            if ((data[13] & 32) == 32)
                                m_RfidStatus[1].Error = true;
                            else
                                m_RfidStatus[1].Error = false;

                            //ch0 XCVR CON
                            if ((data[1] & 16) == 16)
                                m_RfidStatus[0].XcvrCon = true;
                            else
                                m_RfidStatus[0].XcvrCon = false;

                            //ch1 XCVR CON
                            if ((data[13] & 16) == 16)
                                m_RfidStatus[1].XcvrCon = true;
                            else
                                m_RfidStatus[1].XcvrCon = false;
                      
                            //ch0 XCVR ON
                            if ((data[1] & 8) == 8)
                                m_RfidStatus[0].XcvrOn = true;
                            else
                                m_RfidStatus[0].XcvrOn = false;

                            //ch1 XCVR ON
                            if ((data[13] & 8) == 8)
                                m_RfidStatus[1].XcvrOn = true;
                            else
                                m_RfidStatus[1].XcvrOn = false;

                            //ch0 TP  checkBox6
                            if ((data[1] & 4) == 4)
                                m_RfidStatus[0].Tp = true;
                            else
                                m_RfidStatus[0].Tp = false;

                            //ch1 TP
                            if ((data[13] & 4) == 4)
                                m_RfidStatus[1].Tp = true;
                            else
                                m_RfidStatus[1].Tp = false;

                            //ch0 TFR
                            if ((data[1] & 2) == 2)
                                m_RfidStatus[0].Tfr = true;
                            else
                                m_RfidStatus[0].Tfr = false;

                            //ch1 TFR
                            if ((data[13] & 2) == 2)
                                m_RfidStatus[1].Tfr = true;
                            else
                                m_RfidStatus[1].Tfr = false;
                        }
                    }break;
                case 5:
                    {
                        data = values;
                        char[] tmp1 = new char[data.Length];

                        for (int i = 0; i < data.Length; i++)
                        {
                            tmp1[i] = (char)data[i];
                            m_StrReadTemp = m_StrReadTemp + tmp1[i].ToString();
                        }
                        m_QueueRead.Enqueue(m_StrReadTemp);
                        m_StrReadTemp = "";
                    }
                    break;
                case 6:
                    {
                        data = null;
                        data = values;
                        char[] tmp = new char[data.Length];

                        for (int i = 0; i < data.Length; i++)
                        {
                            tmp[i] = (char)data[i];
                            m_StrReadTemp = m_StrReadTemp + tmp[i].ToString();
                        }
                    }break;
                default: break;
            }
        }

        byte Set_bit(byte data, int index, bool flag)
        {
            if (index > 8 || index < 1)
                throw new ArgumentOutOfRangeException();
            int v = index < 2 ? index : (2 << (index - 2));
            return flag ? (byte)(data | v) : (byte)(data & ~v);
        }

        private void OnTimedCheckStatus(Object source, System.Timers.ElapsedEventArgs e)
        {
            ushort ID = 4;
            byte unit = 0;
            ushort StartAddress = 0;
            byte Length = 7; //每个通道占6个字,即后续各通道可按顺序每个通道增加6个字

            m_ModbusMaster.ReadInputRegister(ID, unit, StartAddress, Length);
        }

        public void Close()
        {
            m_CheckStatusTimer.Stop();
            if (m_ModbusMaster != null)
            {
                m_ModbusMaster.Dispose();
                m_ModbusMaster = null;
            }
        }
    }
}
