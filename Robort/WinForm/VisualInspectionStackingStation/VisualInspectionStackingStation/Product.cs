using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotWorkstation
{
    public static class Product  //产品信息类
    {
        public enum ProductType
        {
            Accepts = 0,  //合格品
            UnAccepts,
            Total
        }

        public enum SalverType  //盘的类型
        {
            Salver_3_4 = 0,   //3 * 4的盘
            Salver_4_6,
            Total
        }

        //按照最大盘定义行列数
        public static int SalverRow = 4;  
        public static int SalverCol = 6;

        public static void SetSalver(int Row, int Col)
        {
            SalverRow = Row;
            SalverCol = Col;
        }
    }
}
