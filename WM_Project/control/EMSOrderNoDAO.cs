using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace WM_Project.control
{
    public class EMSOrderNoDAO
    {

        /// <summary>
        /// 获取一个 EMS 单号
        /// </summary>
        /// <returns></returns>
        public string getTopOneEMSOrderNo()
        {
            string order_no = "";

            string sql = "select top 1 * from tb_ems_order_no where ems_status='0'";

            DataTable table = new DBOperateCommon().excuteQuery(sql);

            if (table.Rows.Count > 0)
            {
                order_no = table.Rows[0]["ems_number"].ToString();
            }

            return order_no;
        }


        /// <summary>
        /// 添加 EMS 单号
        /// </summary>
        /// <param name="order_no"></param>
        /// <returns></returns>
        public bool addEMSOrderNo(string order_no)
        {
            bool flag = false;

            string sql = "insert into tb_ems_order_no values('" + order_no + "','0')";

            if (new DBOperateCommon().excuteNoQuery(sql))
            {
                flag = true;
            }

            return flag;
        }


        /// <summary>
        /// 获取可用的 EMS 单号的个数
        /// </summary>
        /// <returns></returns>
        public int getEMSOrderNoLast()
        {
            int count = 0;

            string sql = "select count(*) from tb_ems_order_no where ems_status='0'";

            DataTable table = new DBOperateCommon().excuteQuery(sql);

            if (table.Rows.Count>0)
            {
                count = Convert.ToInt32(table.Rows[0][0].ToString());
            }

            return count;
        }
    }
}