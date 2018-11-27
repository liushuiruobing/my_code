using RABD.DROE.SystemDefine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RobotWorkstation
{
    public partial class ManualDebugForm : Form
    {
        public RobotDevice m_ManualRobot = new RobotDevice();
        private const int RobotGlobalPointsBefore = 30;  //先加载前30个点，其余的在定时器中加载，来解决刷新缓慢的问题
        private int m_ManualRobotGlobalPointIndex = 0;  //选中的全局点位索引

        //防止闪屏
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED，将一个窗体的所有子窗口使用双缓冲按照从低到高方式绘制出来。
                return cp;
            }
        }

        public ManualDebugForm()
        {
            InitializeComponent();

            //下面的三个页暂不使用
            PageRobotTestUserFrame.Parent = null;
            PageRobotTestToolFrame.Parent = null;
            PageRobotTestWorkSpace.Parent = null;

            bool openRet = m_ManualRobot.Open("192.168.1.124");
            if (!openRet)
            {
                Debug.WriteLine("The Robot Open Failed!");
            }
        }

        private void ManualDebug_Load(object sender, EventArgs e)
        {
            tabControlManualDebug.Width = this.Width;
            tabControlManualDebug.Height = this.Height;

            radioButtonRobotDeviceJog.Checked = true;  //默认是Jog模式

            //加载机械臂全局点位
            DGV_RobotGlobalPoint.Rows.Clear();
            LoadRobotGlobalPoints(0, RobotGlobalPointsBefore);
            TimerLoadRobotOtherGlobalPoints.Start();
        }

        //加载机械臂的全局点位信息
        public void LoadRobotGlobalPoints(int StartIndex,  int EndIndex)
        {
            for (int i = StartIndex; i < EndIndex; i++)
            {
                DGV_RobotGlobalPoint.Rows.Add("GL", (float)0 / 1000, (float)0 / 1000, (float)0 / 1000, (float)0 / 1000, 0, 0, 0);
                DGV_RobotGlobalPoint.Rows[i].HeaderCell.Value = String.Format("{0}", i + 1);
            }
        }

        private void timer_LoadRobotOtherGlobalPoints_Tick(object sender, EventArgs e)
        {
            TimerLoadRobotOtherGlobalPoints.Stop();
            LoadRobotGlobalPoints(RobotGlobalPointsBefore, RobotBase.MAX_GLOBAL_POINTS);
        }

        private void CBttonServoOn_Click(object sender, EventArgs e)
        {
            if (m_ManualRobot.IsConnected())
            {
                m_ManualRobot.ServoOn();
                Thread.Sleep(100);  //必须延时, 否则反应很慢
                RefreshRobotServoPic(m_ManualRobot, pictureBoxServo);
            }
        }

        private void CButtonServoOff_Click(object sender, EventArgs e)
        {
            if (m_ManualRobot.IsConnected())
            {
                m_ManualRobot.ServoOff();
                Thread.Sleep(100);  
                RefreshRobotServoPic(m_ManualRobot, pictureBoxServo);
            }
        }

        void RefreshRobotServoPic(RobotBase robot, PictureBox pic)
        {
            Bitmap bmpGreen = Properties.Resources.SmallGreen;
            Bitmap bmpDarkGreen = Properties.Resources.SmallDarkGreen;
            pic.Image = robot.ServoState() ? bmpGreen : bmpDarkGreen;
        }

        private void CButtonReset_Click(object sender, EventArgs e)
        {
            if (m_ManualRobot.IsConnected())
            {
                m_ManualRobot.ResetAlarm();
            }
        }

        private void CButtonRobotExecRun_Click(object sender, EventArgs e)
        {
            if (m_ManualRobot.IsConnected())
            {
                m_ManualRobot.RunProgram();
            }
        }

        private void CButtonRobotExecPause_Click(object sender, EventArgs e)
        {
            if (m_ManualRobot.IsConnected())
            {
                m_ManualRobot.PauseProgram();
            }
        }

        private void CButtonRobotExecStop_Click(object sender, EventArgs e)
        {
            if (m_ManualRobot.IsConnected())
            {
                m_ManualRobot.StopProgram();
            }
        }

        //显示机器人脚本运行状态
        private void DisplayRobotState(string state, PictureBox pic)
        {
            Bitmap bmpGreen = Properties.Resources.SmallGreen;
            Bitmap bmpRed = Properties.Resources.SmallRed;
            Bitmap bmpYellow = Properties.Resources.SmallYellow;

            if (state == "暂停")
                pic.Image = bmpYellow;
            else if (state == "运行")
                pic.Image = bmpGreen;
            else
                pic.Image = bmpRed;
        }

        private void radioButtonRobotDeviceJog_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonRobotDeviceJog.Checked)
            {
                m_ManualRobot.m_IsStep = true;
            }
        }

        private void radioButtonRobotDeviceContinuous_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonRobotDeviceContinuous.Checked)
            {
                m_ManualRobot.m_IsStep = false;
            }
        }

        private void CTextBoxRobotMoveSpeed_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int speed = Convert.ToInt32(CTextBoxRobotMoveSpeed.Text);
                if (speed < RobotBase.MIN_SPEED)
                {
                    speed = RobotBase.MIN_SPEED;
                    CTextBoxRobotMoveSpeed.Text = speed.ToString();
                }
                else if (speed > RobotBase.MAX_SPEED)
                {
                    speed = RobotBase.MAX_SPEED;
                    CTextBoxRobotMoveSpeed.Text = speed.ToString();
                }
                m_ManualRobot.SetSpeed(speed);
            }
            catch (System.Exception ex)
            {
                return;
            }
        }

        private void CTextBoxJogDistance_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int distance = Convert.ToInt32(CTextBoxJogDistance.Text);
                m_ManualRobot.SetJointDistance(distance);
            }
            catch
            {
                return;
            }         
        }

        private void CTextBoxJogDistanceUm_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int um = Convert.ToInt32(CTextBoxJogDistanceUm.Text);
                m_ManualRobot.SetCartesianDistance(um);
            }
            catch
            {
                return;
            }
        }

        private void CButtonRobotDistanceJ1Add_MouseDown(object sender, MouseEventArgs e)
        {
            m_ManualRobot.Move(eDirection.J1P, m_ManualRobot.m_IsStep);
        }

        private void CButtonRobotDistanceJ1Add_MouseUp(object sender, MouseEventArgs e)
        {
            m_ManualRobot.Stop(eAxisName.J1);
        }

        private void CButtonRobotDistanceJ1Sub_MouseDown(object sender, MouseEventArgs e)
        {
            m_ManualRobot.Move(eDirection.J1N, m_ManualRobot.m_IsStep);
        }

        private void CButtonRobotDistanceJ1Sub_MouseUp(object sender, MouseEventArgs e)
        {
            m_ManualRobot.Stop(eAxisName.J1);
        }

        private void CButtonRobotDistanceJ2Add_MouseDown(object sender, MouseEventArgs e)
        {
            m_ManualRobot.Move(eDirection.J2P, m_ManualRobot.m_IsStep);
        }

        private void CButtonRobotDistanceJ2Add_MouseUp(object sender, MouseEventArgs e)
        {
            m_ManualRobot.Stop(eAxisName.J2);
        }

        private void CButtonRobotDistanceJ2Sub_MouseDown(object sender, MouseEventArgs e)
        {
            m_ManualRobot.Move(eDirection.J2N, m_ManualRobot.m_IsStep);
        }

        private void CButtonRobotDistanceJ2Sub_MouseUp(object sender, MouseEventArgs e)
        {
            m_ManualRobot.Stop(eAxisName.J2);
        }

        private void CButtonRobotDistanceJ3Add_MouseDown(object sender, MouseEventArgs e)
        {
            m_ManualRobot.Move(eDirection.J3P, m_ManualRobot.m_IsStep);
        }

        private void CButtonRobotDistanceJ3Add_MouseUp(object sender, MouseEventArgs e)
        {
            m_ManualRobot.Stop(eAxisName.J3);
        }

        private void CButtonRobotDistanceJ3Sub_MouseDown(object sender, MouseEventArgs e)
        {
            m_ManualRobot.Move(eDirection.J3N, m_ManualRobot.m_IsStep);
        }

        private void CButtonRobotDistanceJ3Sub_MouseUp(object sender, MouseEventArgs e)
        {
            m_ManualRobot.Stop(eAxisName.J3);
        }

        private void CButtonRobotDistanceJ4Add_MouseDown(object sender, MouseEventArgs e)
        {
            m_ManualRobot.Move(eDirection.J4P, m_ManualRobot.m_IsStep);
        }

        private void CButtonRobotDistanceJ4Add_MouseUp(object sender, MouseEventArgs e)
        {
            m_ManualRobot.Stop(eAxisName.J4);
        }

        private void CButtonRobotDistanceJ4Sub_MouseDown(object sender, MouseEventArgs e)
        {
            m_ManualRobot.Move(eDirection.J4N, m_ManualRobot.m_IsStep);
        }

        private void CButtonRobotDistanceJ4Sub_MouseUp(object sender, MouseEventArgs e)
        {
            m_ManualRobot.Stop(eAxisName.J4);
        }

        private void CButtonRobotDistanceXAdd_MouseDown(object sender, MouseEventArgs e)
        {
            m_ManualRobot.Move(eDirection.XP, m_ManualRobot.m_IsStep);
        }

        private void CButtonRobotDistanceXAdd_MouseUp(object sender, MouseEventArgs e)
        {
            m_ManualRobot.Stop(eAxisName.X);
        }

        private void CButtonRobotDistanceXSub_MouseDown(object sender, MouseEventArgs e)
        {
            m_ManualRobot.Move(eDirection.XN, m_ManualRobot.m_IsStep);
        }

        private void CButtonRobotDistanceXSub_MouseUp(object sender, MouseEventArgs e)
        {
            m_ManualRobot.Stop(eAxisName.X);
        }

        private void CButtonRobotDistanceYAdd_MouseDown(object sender, MouseEventArgs e)
        {
            m_ManualRobot.Move(eDirection.YP, m_ManualRobot.m_IsStep);
        }

        private void CButtonRobotDistanceYAdd_MouseUp(object sender, MouseEventArgs e)
        {
            m_ManualRobot.Stop(eAxisName.Y);
        }

        private void CButtonRobotDistanceYSub_MouseDown(object sender, MouseEventArgs e)
        {
            m_ManualRobot.Move(eDirection.YN, m_ManualRobot.m_IsStep);
        }

        private void CButtonRobotDistanceYSub_MouseUp(object sender, MouseEventArgs e)
        {
            m_ManualRobot.Stop(eAxisName.Y);
        }

        private void CButtonRobotDistanceZAdd_MouseDown(object sender, MouseEventArgs e)
        {
            m_ManualRobot.Move(eDirection.ZP, m_ManualRobot.m_IsStep);
        }

        private void CButtonRobotDistanceZAdd_MouseUp(object sender, MouseEventArgs e)
        {
            m_ManualRobot.Stop(eAxisName.Z);
        }

        private void CButtonRobotDistanceZSub_MouseDown(object sender, MouseEventArgs e)
        {
            m_ManualRobot.Move(eDirection.ZN, m_ManualRobot.m_IsStep);
        }

        private void CButtonRobotDistanceZSub_MouseUp(object sender, MouseEventArgs e)
        {
            m_ManualRobot.Stop(eAxisName.Z);
        }

        private void CButtonRobotDistanceRZAdd_MouseDown(object sender, MouseEventArgs e)
        {
            m_ManualRobot.Move(eDirection.RZP, m_ManualRobot.m_IsStep);
        }

        private void CButtonRobotDistanceRZAdd_MouseUp(object sender, MouseEventArgs e)
        {
            m_ManualRobot.Stop(eAxisName.RZ);
        }

        private void CButtonRobotDistanceRZSub_MouseDown(object sender, MouseEventArgs e)
        {
            m_ManualRobot.Move(eDirection.RZN, m_ManualRobot.m_IsStep);
        }

        private void CButtonRobotDistanceRZSub_MouseUp(object sender, MouseEventArgs e)
        {
            m_ManualRobot.Stop(eAxisName.RZ);
        }

        private void CBtnRobotTestReadPoint_Click(object sender, EventArgs e)
        {
            LoadRobotGlobalPoint(m_ManualRobot, DGV_RobotGlobalPoint);
        }

        /*加载并显示全部全局点位*/
        private void LoadRobotGlobalPoint(RobotBase robot, DataGridView dgv)
        {
            if (m_ManualRobot.IsConnected())
            {
                List<cPoint> pointList = robot.GetGlobalPointData();
                if (pointList == null)
                    return;

                for (int i = 0; i < RobotBase.MAX_GLOBAL_POINTS; i++)
                {
                    dgv[0, i].Value = pointList[i].Name;
                    dgv[1, i].Value = pointList[i][eAxisName.X] / 1000;
                    dgv[2, i].Value = pointList[i][eAxisName.Y] / 1000;
                    dgv[3, i].Value = pointList[i][eAxisName.Z] / 1000;
                    dgv[4, i].Value = pointList[i][eAxisName.RZ] / 1000;
                    dgv[5, i].Value = pointList[i].Info.Hand;
                    dgv[6, i].Value = pointList[i].Info.UserFrame;
                    dgv[7, i].Value = pointList[i].Info.ToolFrame;

                    dgv.Rows[i].HeaderCell.Value = String.Format("{0}", i + 1);
                }
            }
            else
            {
                MessageBox.Show("机械臂未连接！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /*加载并显示当前行的全局点位*/
        private void GetRobotGlobalPoint(RobotBase robot, DataGridView dgv, int index)
        {
            cPoint pointData = robot.GetGlobalPoint(index);
            try
            {
                dgv[0, index].Value = pointData.Name;
                dgv[1, index].Value = pointData[eAxisName.X] / 1000;
                dgv[2, index].Value = pointData[eAxisName.Y] / 1000;
                dgv[3, index].Value = pointData[eAxisName.Z] / 1000;
                dgv[4, index].Value = pointData[eAxisName.RZ] / 1000;
                dgv[5, index].Value = pointData.Info.Hand;
                dgv[6, index].Value = pointData.Info.UserFrame;
                dgv[7, index].Value = pointData.Info.ToolFrame;
            }
            catch { };
        }

        private void DGV_RobotGlobalPoint_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            m_ManualRobotGlobalPointIndex = DGV_RobotGlobalPoint.CurrentRow.Index;
        }

        private void CBtnRobotTestMoveToPoint_MouseDown(object sender, MouseEventArgs e)
        {
            if (m_ManualRobot.IsConnected())
            {
                cPoint point = new cPoint();
                point = m_ManualRobot.GetGlobalPoint(m_ManualRobotGlobalPointIndex);
                if (point != null)
                {
                    m_ManualRobot.GotoMovP(point);
                }
            }
        }

        private void CBtnRobotTestMoveToPoint_MouseUp(object sender, MouseEventArgs e)
        {
            m_ManualRobot.MovStop();
        }

        private void CBtnRobotTestTeachPoint_Click(object sender, EventArgs e)
        {
            if (m_ManualRobot.IsConnected())
            {
                int nPointIndex = m_ManualRobotGlobalPointIndex;
                m_ManualRobot.TechGlobalPoint(nPointIndex);
                GetRobotGlobalPoint(m_ManualRobot, DGV_RobotGlobalPoint, nPointIndex) ;
            }
        }

        private void RefreshTimer_Tick(object sender, EventArgs e)
        {
            Bitmap bmpGreen = Properties.Resources.SmallGreen;
            Bitmap bmpDarkGreen = Properties.Resources.SmallDarkGreen;
            Bitmap bmpRed = Properties.Resources.SmallRed;
            Bitmap bmpDarkRed = Properties.Resources.SmallDarkRed;

            pictureBoxRobotAlarm.Image = m_ManualRobot.HasAlarm() ? bmpRed : bmpDarkRed;
            pictureBoxTemperature.Image = (m_ManualRobot.GetTemperatureStateString() == "过载") ? bmpRed : bmpDarkGreen;
            pictureBoxRobotMove.Image = m_ManualRobot.GetMovingState() ? bmpGreen : bmpDarkGreen;
            DisplayRobotState(m_ManualRobot.GetExecutorStateString(), pictureBoxRobotExecut);

        }
    }
}
