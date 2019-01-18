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
        public const Parity m_Parity = Parity.None;
        public const int m_DataBits = 8;
        public const StopBits m_StopBits = StopBits.One;
        public int m_ReadTimeOut = 100;     
        public event EventHandler QRCodeRecvDataEvent;
        public string m_ReadString = "";
        private const int m_QRCodeCount = 52;  //"KR12BN5901299ABPVKBSM965,00C3F41A134C,000000000000\r\n"

        public bool m_IsConnect
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

        public void QRCodeCommunParamInit(string Port, string BandRate)
        {
            m_StrPort = Port;
            m_BaudRate = int.Parse(BandRate);
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
                m_ReadString += ((SerialPort)sender).ReadExisting();

                if (m_ReadString == m_ReadNone)
                    m_ReadString = string.Empty;

                if (m_ReadString.Length == m_QRCodeCount)  //二维码+\r\n
                {
                    ev.QRCodeRecv = (string)m_ReadString.Clone();
                    m_ReadString = string.Empty;
                    QRCodeRecvDataEvent?.Invoke(this, ev);              
                }       
                    
            }
            catch (System.TimeoutException)
            {
                return;
            }
        }

    }
}
