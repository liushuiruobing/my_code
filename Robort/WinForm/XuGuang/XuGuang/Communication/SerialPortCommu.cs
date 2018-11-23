using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RobotWorkstation
{
    public struct SerialPortParam
    {
        public string StrPort;
        public int BaudRate;
        public Parity Parity;  //奇偶校验位
        public int DataBits;
        public StopBits StopBits;  //停止位

        public void InitSerialPortParam()
        {
            StrPort = "COM1";
            BaudRate = 9600;
            Parity = Parity.None;  //奇偶校验位
            DataBits = 8;
            StopBits = StopBits.One;  //停止位
        }
    }

    class SerialPortCommu : AbstractCommunication
    {
        //成员变量
        private SerialPort m_SerialPort = null;
        public SerialPortParam m_SerialPortParam;

        public bool m_bConnect = false;
        public string m_StrRead = " ";
        public string m_StrWrite = " ";
        private int m_ReadTimeOut = 1;
       // private int m_WriteTimeOut = 500;

        public override bool InitializeCommu()
        {
            try
            {
                m_SerialPort = new SerialPort(m_SerialPortParam.StrPort, m_SerialPortParam.BaudRate, m_SerialPortParam.Parity, m_SerialPortParam.DataBits, m_SerialPortParam.StopBits);
                m_SerialPort.ReadTimeout = m_ReadTimeOut; //默认是InfiniteTimeout                                                         //m_SerialPort.WriteTimeout = nWriteTimeOut;
                m_SerialPort.Open();
                m_bConnect = true;
                return true;
            }
            catch
            {
                m_bConnect = false;            
                return false;
            }
        }

        public override bool Write(byte[] WrBuf, int WrCount)
        {
            bool bRe = false;
            if (m_bConnect)
            {
                m_SerialPort.Write(WrBuf, 0, WrCount);
                bRe = true;
            }

            return bRe;
        }

        public override bool Read(ref string RdBuf, ref int RdCount)
        {
            try
            {
                RdBuf = m_SerialPort.ReadLine();
                RdCount = RdBuf.Length;
                return true;
            }
            catch //(InvalidOperationException\TimeoutException)
            {
                RdBuf = "";
                return false;
            }
        }

        public override bool Query(byte[] WrBuf, int WrCount, ref string RdBuf, ref int RdCount)
        {
            bool bRe = false;
            bRe = Write(WrBuf, WrCount);
            if (bRe)
            {
                bRe = Read(ref RdBuf, ref RdCount);
            }

            return bRe;
        }

        public override void Close()
        {
            m_SerialPort.Close();
        }
    }
}
