using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

using WM_Project.control;

namespace WM_Project.control
{
    public class PostNLDiscountDAO
    {
        /// <summary>
        /// 通过重量和打折值来获取对应的折扣
        /// </summary>
        /// <param name="weight">重量</param>
        /// <param name="discount_array">折扣数组</param>
        /// <returns></returns>
        public float getDiscount(float weight,float[] discount_array )
        {
            float discount = 0;

            int wt = (int)weight;

            discount = discount_array[wt];

            return discount;

        }

        //
        /// <summary>
        /// 验证打折码是否有效
        /// </summary>
        /// <param name="discountCode">打折码</param>
        /// <param name="name">用户名</param>
        /// <returns>有效返回 true</returns>
        public bool checkDiscountCode(string discountCode,string name)
        {
            bool flag = false;

            string sql = "select * from tb_postnl_discount where name='" + name + "'";

            DataTable table = new DBOperateCommon().excuteQuery(sql);

            for (int i = 0; i < table.Rows.Count; i++)
            {
                if (table.Rows[i]["discount_code"].ToString().Equals(discountCode))
                {
                    flag = true;
                    return flag;
                }
            }

            return flag;
        }

        
        public DataTable getDiscountArray(string discountCode,string name)
        {
            
            string sql = "select * from tb_postnl_discount where discount_code='" + discountCode + "' and name='"+name+"'";

            DataTable table = new DBOperateCommon().excuteQuery(sql);

            return table;
        }
    }
}