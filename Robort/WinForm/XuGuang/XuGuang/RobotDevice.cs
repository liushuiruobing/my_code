using RABD.DROE.SystemDefine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotWorkstation
{
    public class RobotDevice : RobotBase
    {
        public bool m_IsStep = true;  //默认是Jog模式
        public List<cPoint> m_PointList = null;
    }
}
