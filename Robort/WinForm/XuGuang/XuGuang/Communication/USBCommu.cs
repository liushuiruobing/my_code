using LibUsbDotNet;
using LibUsbDotNet.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotWorkstation
{
    public struct USBParam
    {
        public int Vid;
        public int Pid;

        public void InitUsbParam()
        {
            Vid = 0x1234;
            Pid = 0x5677;
        }
    }

    class USBCommu : AbstractCommunication
    {
        //USB参数
        private int nWriteTimeOut = 1000;
        private int nReadTimeOut = 10;
        private const int nReadBufSize = 64;
        private byte[] byteRecv = new byte[nReadBufSize];

        USBParam m_USBParam;
        public UsbDevice m_UsbDevice = null;
        public UsbDeviceFinder m_UsbFinder = null;
        public UsbEndpointReader m_UsbReader = null;
        public UsbEndpointWriter m_UsbWriter = null;

        public override bool InitializeCommu()
        {
            m_USBParam.InitUsbParam();
            m_UsbFinder = new UsbDeviceFinder(m_USBParam.Vid, m_USBParam.Pid);
            m_UsbDevice = UsbDevice.OpenUsbDevice(m_UsbFinder);
            if (m_UsbDevice == null)
                return false;

            #region  // 当设备是一个 "whole" USB 时，我们的设备一般不会是此情况
            // If this is a "whole" usb device (libusb-win32, linux libusb)
            // it will have an IUsbDevice interface. If not (WinUSB) the 
            // variable will be null indicating this is an interface of a 
            // device.
            IUsbDevice wholeUsbDevice = m_UsbDevice as IUsbDevice;
            if (!ReferenceEquals(wholeUsbDevice, null))
            {
                // This is a "whole" USB device. Before it can be used, 
                // the desired configuration and interface must be selected.

                // Select config #1
                wholeUsbDevice.SetConfiguration(1);

                // Claim interface #0.
                wholeUsbDevice.ClaimInterface(0);
            }
            #endregion

            m_UsbReader = m_UsbDevice.OpenEndpointReader(ReadEndpointID.Ep02);
            m_UsbReader.ReadBufferSize = nReadBufSize;

            m_UsbWriter = m_UsbDevice.OpenEndpointWriter(WriteEndpointID.Ep01);

            return true;
        }

        public override bool Write(byte[] WrBuf, int WrCount)
        {
            bool bRe = false;

            ErrorCode ec = m_UsbWriter.Write(WrBuf, nWriteTimeOut, out WrCount);
            if (ec != ErrorCode.None)
                bRe = false;

            return bRe;
        }

        public override bool Read(ref string RdBuf, ref int RdCount)
        {
            bool bRe = false;
            ErrorCode ec = ErrorCode.None;
            while (true)
            {
                int bytesRead = -1;

                // If the device hasn't sent data in the last nReadTimeOut milliseconds,
                // a timeout error (ec = IoTimedOut) will occur. 
                ec = m_UsbReader.Read(byteRecv, nReadTimeOut, out bytesRead);

                RdBuf += Encoding.ASCII.GetString(byteRecv, 0, bytesRead);
                RdCount += bytesRead;
                if (bytesRead == 0 && ec == ErrorCode.IoTimedOut)
                    break;
            }
            if (ec == ErrorCode.None)
                bRe = true;

            return bRe;
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
            if (m_UsbDevice != null)
            {
                m_UsbDevice.Close();
                m_UsbDevice = null;

                UsbDevice.Exit(); // Free usb resources
            }
        }
    }
}
