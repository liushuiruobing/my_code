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
    }
}
