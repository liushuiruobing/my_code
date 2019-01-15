using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArmController
{
    public enum UpdateAction
    {
        UpdateAction_None = 0x00,
        UpdateAction_Update,
        UpdateAction_SendFileLength,
        UpdateAction_SendFileData,
        UpdateAction_Succeed,
    }

    public partial class MainForm : Form
    {
        private string m_UpdateFileName = null;
        private short m_CurrentPage = 0;
        private int m_TotalPages = 0;
        private int m_FileSize = 0;
        private const short m_OnePageMaxBytes = 16;
        private byte[] m_SendFileDataTemp = new byte[m_OnePageMaxBytes];  //10个协议字节，256个数据字节
        private byte[] m_SendFileData = new byte[m_OnePageMaxBytes + 10];  //10个协议字节，256个数据字节
        private byte[] m_SendCommand = new byte[Message.MessageLength];
        private FileStream m_OutStream = null;
        private BinaryWriter m_Writer = null;

        private MyTcpServer m_MyTcpServerArm = null;
        private Thread m_MainThread = null;
        private volatile static bool m_ShouldExit = false;
        private UpdateAction m_UpdateAction = UpdateAction.UpdateAction_None;

        public MainForm()
        {
            InitializeComponent();


            m_UpdateFileName = AppDomain.CurrentDomain.BaseDirectory + "Update.bin";
        }

        private void BtnCreateServer_Click(object sender, EventArgs e)
        {
            m_MyTcpServerArm = MyTcpServer.GetInstance();
            if (m_MyTcpServerArm != null)
            {
                IPAddress ServerIp = IPAddress.Parse(TextBoxIp.Text);
                int ServerPort = int.Parse(TextBoxPort.Text);
                m_MyTcpServerArm.CreatServer(ServerIp, ServerPort);
            }

            m_OutStream = File.Open(m_UpdateFileName, FileMode.OpenOrCreate);
            m_Writer = new BinaryWriter(m_OutStream);

            //创建升级线程
            m_MainThread = new Thread(new ThreadStart(MainThreadFunc));
            m_MainThread.IsBackground = true;
            m_MainThread.Start();

            UpdateProcessBar.Value = UpdateProcessBar.Minimum;
        }

        public void MainThreadFunc()
        {
            while (!m_ShouldExit)
            {
                ProcessTcpServerMessage();;
                Thread.Sleep(200);
            }
        }


        public void ProcessTcpServerMessage()
        {
            if (m_MyTcpServerArm != null)
            {
                while (m_MyTcpServerArm.m_RecvMeasQueue.Count != 0)
                {
                    TcpMeas TempMeas = m_MyTcpServerArm.m_RecvMeasQueue.Dequeue();
                    if (TempMeas != null && TempMeas.Client != null)
                    {
                        if (TempMeas.MeasType == TcpMeasType.MEAS_TYPE_ARM)  // 处理和PLC之间的消息
                        {
                            Message.MessageCodeARM Code = (Message.MessageCodeARM)TempMeas.MeasCode;

                            Debug.WriteLine(Code);

                            switch (Code)
                            {
                                case Message.MessageCodeARM.ArmUpdate:
                                case Message.MessageCodeARM.ArmUpdateFileLength:
                                case Message.MessageCodeARM.ArmUpdateFileData:
                                    {
                                        if (Code == Message.MessageCodeARM.ArmUpdateFileLength)
                                        {
                                            m_FileSize = BitConverter.ToInt32(TempMeas.Param, Message.MessageCommandIndex + 1);
                                        }

                                        if (Code == Message.MessageCodeARM.ArmUpdateFileData)
                                        {
                                            m_TotalPages++;

                                            if (m_TotalPages != 0 && m_TotalPages * 16 >= m_FileSize)
                                                m_Writer.Write(TempMeas.Param, Message.MessageCommandIndex + 3, (m_TotalPages * 16 - m_FileSize));
                                            else
                                                m_Writer.Write(TempMeas.Param, Message.MessageCommandIndex + 3, 16);
                                            
                                            m_CurrentPage = BitConverter.ToInt16(TempMeas.Param, Message.MessageCommandIndex + 1);
                                            Debug.WriteLine("Current Page: " + m_CurrentPage);
                                        }

                                        if (m_TotalPages != 0 && m_TotalPages * 16 >= m_FileSize)
                                        {
                                            TempMeas.Param[Message.MessageCommandIndex] = (byte)Message.MessageCodeARM.ArmUpdateSucceed;
                                            TempMeas.Param[TempMeas.Param.Length - 2] = 0x00;

                                            byte Sum = MyMath.CalculateSum(TempMeas.Param, TempMeas.Param.Length);
                                            TempMeas.Param[TempMeas.Param.Length - 2] = Sum;
                                        }
                                            

                                        NetworkStream stream = TempMeas.Client.GetStream();
                                        stream.Write(TempMeas.Param, 0, TempMeas.Param.Length);                                      
                                    }
                                    break;
                                default:break;
                            }
                        }

                    }
                }
            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            m_ShouldExit = true;

            if (m_MyTcpServerArm != null)
            {
                m_MyTcpServerArm.CloseServer();
            }

            if (m_Writer != null)
            {
                m_Writer.Close();
                m_Writer.Dispose();
            }

            if (m_OutStream != null)
            {
                m_OutStream.Close();
                m_OutStream.Dispose();
            }              
        }

        private void TimerConnectServer_Tick(object sender, EventArgs e)
        {
            Debug.WriteLine("Timer!");
        }
    }
}
