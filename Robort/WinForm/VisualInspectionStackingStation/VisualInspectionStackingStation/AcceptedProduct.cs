using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotWorkstation
{
    class AcceptedProduct  //合格品类,处理所有合格品的操作
    {
        private static AcceptedProduct m_AcceptedProduct = null;
        private static readonly object m_Locker = new object();




        // 定义私有构造函数，使外界不能创建该类实例
        private AcceptedProduct()
        {

        }

        /// <summary>
        /// 定义公有方法提供一个全局访问点,同时你也可以定义公有属性来提供全局访问点
        /// </summary>
        /// <returns></returns>
        /// 
        public static AcceptedProduct GetInstance()
        {
            if (m_AcceptedProduct == null)
            {
                lock (m_Locker)
                {
                    if (m_AcceptedProduct == null)
                        m_AcceptedProduct = new AcceptedProduct();
                }

            }

            return m_AcceptedProduct;
        }
    }
}
