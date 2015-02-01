
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;


using WM_Project.logical.common;

namespace WM_Project.control
{
    public class PostageDAO
    {
        /// <summary>
        /// 获取邮费对象
        /// </summary>
        /// <param name="weight">包裹重量</param>
        /// <param name="departure">发件地址</param>
        /// <param name="destination">收件地址</param>
        /// <returns>邮费对象</returns>
        public Postage getPostage(float weight, string departure, string destination,string post_way)
        {
            Postage postage = new Postage();

            string sql = "select * from tb_rate where kg>=" + weight + " and departure='"+departure+"' and destination='"+destination+"' and post_way='"+post_way+"' order by kg asc";

            postage = getPostage(sql);

            return postage;
        }


        /// <summary>
        /// 通过sql在数据库中获取计算所要用到的 计算率 语句
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        private Postage getPostage(string sql)
        {
            Postage postage = new Postage();

            DataTable table = new DBOperateCommon().excuteQuery(sql);

            if (table.Rows.Count > 0)
            {
                postage.Rate = Convert.ToSingle(table.Rows[0]["rate"].ToString());
                postage.Weight = Convert.ToSingle(table.Rows[0]["kg"].ToString());
                postage.Departure = table.Rows[0]["departure"].ToString();
                postage.Destination = table.Rows[0]["destination"].ToString();
                postage.Pickup_fees = Convert.ToSingle(table.Rows[0]["pickup_fees"].ToString());
                postage.Per = Convert.ToInt32(table.Rows[0]["per"].ToString());
            }

            return postage;
        }

        /// <summary>
        /// 通过订单号删除包裹
        /// </summary>
        /// <param name="order_number">订单号</param>
        /// <returns></returns>
        public bool deletePostage(string order_number)
        {
            bool flag = false;
            string sql = "delete from tb_package_info where order_number='" + order_number + "'";
            if (new DBOperateCommon().excuteNoQuery(sql))
            {
                flag = true;
            }
            return flag;
        }
    }
}