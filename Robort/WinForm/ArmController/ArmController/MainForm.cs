using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
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
        UpdateAction_Result,
    }

    public partial class MainForm : Form
    {
        public bool m_UpdateResult = false;
        public string m_UpdateFileName = null;
        public short m_CurrentPage = 0;
        public int m_TotalPages = 0;
        public const short m_OnePageMaxBytes = 512;
        public byte[] m_SendFileDataTemp = new byte[m_OnePageMaxBytes];  //10个协议字节，256个数据字节
        public byte[] m_SendFileData = new byte[m_OnePageMaxBytes + 10];  //10个协议字节，256个数据字节
        public byte[] m_SendCommand = new byte[Message.MessageLength];
        private FileStream m_InputStream = null;
        private BinaryReader m_Reader = null;

        private MyTcpClient m_MyTcpClientArm = null;
        private Thread m_MainThread = null;
        private volatile static bool m_ShouldExit = false;
        private UpdateAction m_UpdateAction = UpdateAction.UpdateAction_None;

        public MainForm()
        {
            InitializeComponent();

            m_MyTcpClientArm = new MyTcpClient();

            if (m_OnePageMaxBytes < 256)
            {
                m_SendFileData = new byte[Message.MessageLength];
            }
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            this.UpdateOpenFileDialog.FileName = ".bin";
            if (UpdateOpenFileDialog.ShowDialog() != DialogResult.OK)
                return;

            m_UpdateFileName = UpdateOpenFileDialog.FileName;
            m_InputStream = File.Open(m_UpdateFileName, FileMode.Open);
            m_Reader = new BinaryReader(m_InputStream);

            if (m_MyTcpClientArm != null)
            {
                m_MyTcpClientArm.InitClient();

                IPAddress ControlIp = IPAddress.Parse(TextBoxIp.Text);
                int ControlPort = int.Parse(TextBoxPort.Text);
                m_MyTcpClientArm.CreateConnect(ControlIp, ControlPort);
            }

            //发送升级指令
            Array.Clear(m_SendCommand, 0, m_SendCommand.Length);
            Message.MakeSendArrayByCode((byte)Message.MessageCodeARM.ArmUpdate, ref m_SendCommand);
            if (m_MyTcpClientArm != null && m_MyTcpClientArm.IsConnected)
            {
                m_MyTcpClientArm.ClientWrite(m_SendCommand);
            }

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
                ProcessArmMessage();
                RunUpdate();
                Thread.Sleep(200);
            }
        }

        public void ProcessArmMessage()
        {
            if (m_MyTcpClientArm != null && m_MyTcpClientArm.IsConnected)
            {
                while (m_MyTcpClientArm.m_RecvMeasQueue.Count != 0)
                {
                    TcpMeas TempMeas = m_MyTcpClientArm.m_RecvMeasQueue.Dequeue();
                    if (TempMeas != null && TempMeas.Client != null)
                    {
                        if (TempMeas.MeasType == TcpMeasType.MEAS_TYPE_ARM)  // 处理和ARM之间的消息
                        {
                            Message.MessageCodeARM Code = (Message.MessageCodeARM)TempMeas.MeasCode;
                            switch (Code)
                            {
                                case Message.MessageCodeARM.ArmUpdate:   //收到升级指令回复
                                    {
                                        m_UpdateAction = UpdateAction.UpdateAction_Update;
                                        //m_UpdateAction = UpdateAction.UpdateAction_SendFileLength;
                                    }
                                    break;
                                case Message.MessageCodeARM.ArmUpdateFileLength:    //收到升级文件长度指令回复
                                    {
                                        m_UpdateAction = UpdateAction.UpdateAction_SendFileData;
                                    }
                                    break;
                                case Message.MessageCodeARM.ArmUpdateFileData:      //收到升级文件每包数据指令回复
                                    {
                                        m_CurrentPage++;
                                        m_UpdateAction = UpdateAction.UpdateAction_SendFileData;
                                    }
                                    break;
                                case Message.MessageCodeARM.ArmUpdateSucceed:       //升级成功回复
                                    {
                                        byte Result = TempMeas.Param[Message.MessageCommandIndex + 1];
                                        if (Result == 0x01)                                      
                                            m_UpdateResult = true;
                                        else
                                            m_UpdateResult = false;

                                        m_UpdateAction = UpdateAction.UpdateAction_Result;
                                    }
                                    break;
                                default: break;
                            }
                        }
                    }
                }
            }
        }

        public void RunUpdate()
        {
            Debug.WriteLine(m_UpdateAction);
            switch (m_UpdateAction)
            {
                case UpdateAction.UpdateAction_Update:
                    {
                        //尝试重新建立连接
                        this.Invoke((MethodInvoker)delegate
                        {
                            TimerConnectServer.Enabled = true;
                        });

                        m_UpdateAction = UpdateAction.UpdateAction_None;
                    }
                    break;
                case UpdateAction.UpdateAction_SendFileLength:
                    {
                        //发送文件长度
                        FileInfo temp = new FileInfo(m_UpdateFileName);

                        if (temp.Length % m_OnePageMaxBytes != 0)
                            m_TotalPages = (int)(temp.Length / m_OnePageMaxBytes + 1);
                        else
                            m_TotalPages = (int)(temp.Length / m_OnePageMaxBytes);

                        byte[] SendLength = BitConverter.GetBytes((int)temp.Length);
                    
                        //发送升级指令
                        Array.Clear(m_SendCommand, 0, m_SendCommand.Length);
                        Message.MakeSendArrayByCode((byte)Message.MessageCodeARM.ArmUpdateFileLength, ref m_SendCommand);

                        for (int i = 0; i < SendLength.Length; i++)
                        {
                            m_SendCommand[Message.MessageCommandIndex + 1 + i] = SendLength[i];
                        }

                        byte[] DataPageLength = BitConverter.GetBytes(m_OnePageMaxBytes);
                        m_SendCommand[Message.MessageCommandIndex + 1 + SendLength.Length] = DataPageLength[0];      //数据包长度低字节
                        m_SendCommand[Message.MessageCommandIndex + 1 + SendLength.Length + 1] = DataPageLength[1];  //数据包长度高字节

                        //重新计算校验和
                        m_SendCommand[Message.MessageLength - 2] = 0x00;
                        byte Sum = 0;
                        foreach (byte Temp in m_SendCommand)
                            Sum += Temp;
                        m_SendCommand[Message.MessageLength - 2] = (byte)(0 - Sum);  //校验和

                        if (m_MyTcpClientArm != null && m_MyTcpClientArm.IsConnected)
                        {
                            m_MyTcpClientArm.ClientWrite(m_SendCommand);
                        }
                        m_UpdateAction = UpdateAction.UpdateAction_None;
                    }
                    break;
                case UpdateAction.UpdateAction_SendFileData:
                    {
                        int ReadCount = m_Reader.Read(m_SendFileDataTemp, 0, m_SendFileDataTemp.Length);

                        if (ReadCount != 0)
                        {
                            byte[] CurrentPage = BitConverter.GetBytes(m_CurrentPage);
                            MakeSendFileDataByCode(ref m_SendFileData, CurrentPage, m_SendFileDataTemp);

                            if (m_MyTcpClientArm != null && m_MyTcpClientArm.IsConnected)
                            {
                                m_MyTcpClientArm.ClientWrite(m_SendFileData);
                            }

                            this.Invoke((MethodInvoker)delegate
                            {
                                UpdateProcessBar.Value = (m_CurrentPage * 100) / m_TotalPages;
                            });                         
                        }
                        m_UpdateAction = UpdateAction.UpdateAction_None;
                    }
                    break;
                case UpdateAction.UpdateAction_Result:
                    {
                        string StrResult = "升级失败！";
                        if (m_UpdateResult)
                            StrResult = "升级成功！";

                        this.Invoke((MethodInvoker)delegate
                        {
                            UpdateProcessBar.Value = UpdateProcessBar.Maximum;
                            MessageBox.Show(this, StrResult);
                        });
                                              
                        if (m_Reader != null)
                        {
                            m_Reader.Close();
                            m_Reader.Dispose();
                        }

                        if (m_InputStream != null)
                        {
                            m_InputStream.Close();
                            m_InputStream.Dispose();
                        }

                        m_CurrentPage = 0;
                        m_UpdateAction = UpdateAction.UpdateAction_None;
                        m_ShouldExit = true;
                    }
                    break;
                default: break;
            }
        }

        public static void MakeSendFileDataByCode(ref byte[] SendMeas, byte[] CurrentPage, byte[] FileData)
        {
            Array.Clear(SendMeas, 0, SendMeas.Length);

            if (SendMeas.Length >= Message.MessageLength)
            {
                SendMeas[0] = Message.MessStartCode;
                SendMeas[1] = Message.MessVID1;
                SendMeas[2] = Message.MessVID2;
                SendMeas[3] = Message.MessVer;
                SendMeas[Message.MessageStateIndex] = Message.MessRightState;
                SendMeas[Message.MessageCommandIndex] = (byte)Message.MessageCodeARM.ArmUpdateFileData;

                //当前包数
                for (int i = 0; i < CurrentPage.Length; i++)
                {
                    SendMeas[Message.MessageCommandIndex + 1 + i] = CurrentPage[i];
                }

                //实际数据
                int FileDataIndex = Message.MessageCommandIndex + CurrentPage.Length + 1;
                Array.Copy(FileData, 0, SendMeas, FileDataIndex, FileData.Length);

                //结束码
                SendMeas[SendMeas.Length - 1] = Message.MessEndCode;

                //校验和
                byte Sum = 0;
                foreach (byte Temp in SendMeas)
                    Sum += Temp;
                SendMeas[SendMeas.Length - 2] = (byte)(0 - Sum);  //校验和
            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            m_ShouldExit = true;

            if (m_Reader != null)
            {
                m_Reader.Close();
                m_Reader.Dispose();
            }

            if (m_InputStream != null)
            {
                m_InputStream.Close();
                m_InputStream.Dispose();
            }              
        }

        private void TimerConnectServer_Tick(object sender, EventArgs e)
        {
            Debug.WriteLine("Timer!");

            if (m_MyTcpClientArm != null && !m_MyTcpClientArm.IsConnected)
            {
                m_MyTcpClientArm.Close();

                m_MyTcpClientArm = new MyTcpClient();
                IPAddress ControlIp = IPAddress.Parse(TextBoxIp.Text);
                int ControlPort = int.Parse(TextBoxPort.Text);
                m_MyTcpClientArm.CreateConnect(ControlIp, ControlPort);
            }

            if (m_MyTcpClientArm != null && m_MyTcpClientArm.IsConnected)
            {
                TimerConnectServer.Stop();
                m_UpdateAction = UpdateAction.UpdateAction_SendFileLength;
            }
        }
    }
}
