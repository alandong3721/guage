using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;


namespace WM_Project.control
{
    public class DeliveryRateDAO
    {
        /// <summary>
        /// 获取取件费用
        /// </summary>
        /// <param name="count">包裹个数</param>
        /// <returns>取件费用</returns>
        public float getDeliveryRate(int count)
        {
            float money = 0;
            string sql = "select * from tb_delivery_rate where package_count ="+count;
            DataTable table = new DBOperateCommon().excuteQuery(sql);
            if(table.Rows.Count>0){
                money = Convert.ToSingle(table.Rows[0]["retailrate1"].ToString());
            }
            return money;
        }
    }
}