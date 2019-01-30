using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotWorkstation
{
    class UnAcceptedProduct  //不合格品类，处理所有不合格品的操作
    {
        private static UnAcceptedProduct m_UnAcceptedProduct = null;
        private static readonly object m_Locker = new object();




        // 定义私有构造函数，使外界不能创建该类实例
        private UnAcceptedProduct()
        {

        }

        /// <summary>
        /// 定义公有方法提供一个全局访问点,同时你也可以定义公有属性来提供全局访问点
        /// </summary>
        /// <returns></returns>
        /// 
        public static UnAcceptedProduct GetInstance()
        {
            if (m_UnAcceptedProduct == null)
            {
                lock (m_Locker)
                {
                    if (m_UnAcceptedProduct == null)
                        m_UnAcceptedProduct = new UnAcceptedProduct();
                }

            }

            return m_UnAcceptedProduct;
        }
    }
}
