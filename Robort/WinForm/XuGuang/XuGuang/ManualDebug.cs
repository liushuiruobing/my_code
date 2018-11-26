using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RobotWorkstation
{
    public partial class ManualDebug : Form
    {
        private const int RobotGlobalPointsBefore = 30;  //先加载前30个点，其余的在定时器中加载，来解决刷新缓慢的问题

        public ManualDebug()
        {
            InitializeComponent();

            //下面的三个页暂不使用
            PageRobotTestUserFrame.Parent = null;
            PageRobotTestToolFrame.Parent = null;
            PageRobotTestWorkSpace.Parent = null;
        }

        private void ManualDebug_Load(object sender, EventArgs e)
        {
            tabControlManualDebug.Width = this.Width;
            tabControlManualDebug.Height = this.Height;

            //加载机械臂全局点位
            DGV_RobotGlobalPoint.Rows.Clear();
            LoadRobotGlobalPoints(0, RobotGlobalPointsBefore);
            TimerLoadRobotOtherGlobalPoints.Start();
        }

        public void InitFormSizeAndLoction(int Width, int Height)
        {
            this.Width = Width;
            this.Height = Height;
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

        }

        private void CButtonServoOff_Click(object sender, EventArgs e)
        {

        }

        private void CButtonReset_Click(object sender, EventArgs e)
        {

        }

        private void CButtonRobotExecRun_Click(object sender, EventArgs e)
        {

        }

        private void CButtonRobotExecPause_Click(object sender, EventArgs e)
        {

        }

        private void CButtonRobotExecStop_Click(object sender, EventArgs e)
        {

        }

        private void radioButtonRobotDeviceJog_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButtonRobotDeviceContinuous_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void CButtonRobotDistanceJ1Add_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void CButtonRobotDistanceJ1Add_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void CButtonRobotDistanceJ1Sub_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void CButtonRobotDistanceJ1Sub_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void CButtonRobotDistanceJ2Add_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void CButtonRobotDistanceJ2Add_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void CButtonRobotDistanceJ2Sub_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void CButtonRobotDistanceJ2Sub_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void CButtonRobotDistanceJ3Add_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void CButtonRobotDistanceJ3Add_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void CButtonRobotDistanceJ3Sub_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void CButtonRobotDistanceJ3Sub_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void CButtonRobotDistanceJ4Add_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void CButtonRobotDistanceJ4Add_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void CButtonRobotDistanceJ4Sub_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void CButtonRobotDistanceJ4Sub_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void CButtonRobotDistanceXAdd_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void CButtonRobotDistanceXAdd_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void CButtonRobotDistanceXSub_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void CButtonRobotDistanceXSub_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void CButtonRobotDistanceYAdd_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void CButtonRobotDistanceYAdd_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void CButtonRobotDistanceYSub_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void CButtonRobotDistanceYSub_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void CButtonRobotDistanceZAdd_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void CButtonRobotDistanceZAdd_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void CButtonRobotDistanceZSub_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void CButtonRobotDistanceZSub_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void CButtonRobotDistanceRZAdd_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void CButtonRobotDistanceRZAdd_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void CButtonRobotDistanceRZSub_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void CButtonRobotDistanceRZSub_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void CBtnRobotTestReadPoint_Click(object sender, EventArgs e)
        {

        }

        private void CBtnRobotTestMoveToPoint_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void CBtnRobotTestMoveToPoint_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void CBtnRobotTestTeachPoint_Click(object sender, EventArgs e)
        {

        }

    }
}
