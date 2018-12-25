using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RobotWorkstation
{
    public class QRCodeEventArgers : EventArgs
    {
        public string QRCodeRecv = null;
    }

    public class QRCode  //二维码读取器类
    {
        private static QRCode m_UniqueQRCode = null;
        private static readonly object m_Locker = new object();

        public SerialPort m_SerialPort = null;
        public Queue<string> m_ReadQueue = new Queue<string>();
        private string m_ReadNone = "None";
        public string m_StrPort = "COM3";
        public int m_BaudRate = 115200;
        public Parity m_Parity = Parity.None;
        public int m_DataBits = 8;
        public StopBits m_StopBits = StopBits.One;
        public int m_ReadTimeOut = 100;     
        public event EventHandler QRCodeRecvDataEvent;

        public bool QRCodeConnect
        {
            get
            {
                if (m_SerialPort != null)
                    return m_SerialPort.IsOpen;
                else
                    return false;
            }          
        }

        // 定义私有构造函数，使外界不能创建该类实例
        private QRCode()
        {

        }

        /// <summary>
        /// 定义公有方法提供一个全局访问点,同时你也可以定义公有属性来提供全局访问点
        /// </summary>
        /// <returns></returns>
        public static QRCode GetInstance()
        {
            if (m_UniqueQRCode == null)
            {
                lock (m_Locker)
                {
                    if (m_UniqueQRCode == null)
                        m_UniqueQRCode = new QRCode();
                }
            }
            return m_UniqueQRCode;
        }

        public StopBits GetStopBits(string strStopBits)
        {
            StopBits TempStopBits = StopBits.One;

            switch (strStopBits)
            {
                case "1":
                    TempStopBits = StopBits.One;
                    break;
                case "1.5":
                    TempStopBits = StopBits.OnePointFive;
                    break;
                case "2":
                    TempStopBits = StopBits.Two;
                    break;
                default:
                    break;
            }
            return TempStopBits;
        }

        public Parity GetParity(string strParity)
        {
            Parity tempParity = Parity.None;

            switch (strParity)
            {
                case "无":
                    tempParity = Parity.None;
                    break;
                case "奇校验":
                    tempParity = Parity.Odd;
                    break;
                case "偶校验":
                    tempParity = Parity.Even;
                    break;
                default:
                    break;
            }
            return tempParity;
        }

        public void QRCodeCommunParamInit(string Port, string BandRate, string DataBits, string StopBits, string Parity)
        {
            m_StrPort = Port;
            m_BaudRate = int.Parse(BandRate);
            m_DataBits = int.Parse(DataBits);
            m_StopBits = GetStopBits(StopBits);
            m_Parity = GetParity(Parity);
        }

        public bool QRCodeInit()
        {
            bool bRe = false;

            m_SerialPort = new SerialPort(m_StrPort, m_BaudRate, m_Parity, m_DataBits, m_StopBits);
            m_SerialPort.DtrEnable = true;  //不设置则串口读取不到二维码读码器的数据
            m_SerialPort.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
            m_SerialPort.ReadTimeout = m_ReadTimeOut;  //默认是InfiniteTimeout

            try
            {
                m_SerialPort.Open();
                if (m_SerialPort.IsOpen)
                    bRe = true;
            }
            catch
            {
                return false;
            }

            return bRe;
        }

        private void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                QRCodeEventArgers ev = new QRCodeEventArgers();
                ev.QRCodeRecv = ((SerialPort)sender).ReadExisting();
                if (ev.QRCodeRecv != m_ReadNone)       
                    QRCodeRecvDataEvent?.Invoke(this, ev);
            }
            catch (System.TimeoutException)
            {
                return;
            }
        }

    }
}
