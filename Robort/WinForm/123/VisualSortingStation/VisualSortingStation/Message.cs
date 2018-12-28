using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotWorkstation
{
    public static class Message
    {
        public const byte MessStartCode  = 0x7e;     //起始同步码
        public const byte MessEndCode    = 0x0d;     //终止同步码
        public const byte MessVID1       = 0x44;     //厂商标识符1 字母‘D’
        public const byte MessVID2       = 0x52;     //厂商标识符2 字母‘R’
        public const byte MessVer        = 0x01;     //通信协议版本号
        public const byte MessRightState = 0x01;     //状态码，发送时初始为0x01，正确返回为0x01，错误返回为0x81
        public const byte MessErrorState = 0x81;
        public const byte MessRobotVID1  = 0x54;     //台达：‘T’，‘D’
        public const byte MessRobotVID2  = 0x44;
        public const byte MessRobotAxle4 = 0x04;     //4轴机械臂
        public const byte MessRobotAxle6 = 0x06;     //6轴机械臂
        public const byte MessRobotAddr  = 0x01;     //机械臂地址

        public static bool CheckMessage(byte[] message)
        {
            bool Re = false;

            return Re;
        }
    }
}
