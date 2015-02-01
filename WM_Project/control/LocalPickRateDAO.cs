using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

using WM_Project.control;

namespace WM_Project.control
{
    public class LocalPickRateDAO
    {

        /// <summary>
        /// 设置本地取件邮费
        /// </summary>
        /// <param name="base_weight"></param>
        /// <param name="base_price"></param>
        /// <param name="per_price"></param>
        /// <returns></returns>
        public bool setLocalRate(float base_weight,float base_price,float per_price)
        {
            bool flag = false;

            string sql = "select * from tb_local_pick_up where kg=" + base_weight;

            DataTable table = new DBOperateCommon().excuteQuery(sql);
            if (table.Rows.Count > 0)
            {
                string up_sql = "update tb_local_pick_up set base_price=" + base_price + ", up_per_kg=" + per_price + " where kg=" + base_weight;
                if (new DBOperateCommon().excuteNoQuery(up_sql))
                {
                    flag = true;
                }

            }
            else
            {
                string insert_sql = "insert into tb_local_pick_up values(" + base_weight + "," + base_price + "," + per_price + ")";
                if (new DBOperateCommon().excuteNoQuery(insert_sql))
                {
                    flag = true;
                }
            }

            return flag;
        }

        /// <summary>
        /// 删除本地取件邮费信息
        /// </summary>
        /// <param name="base_weight"></param>
        /// <returns></returns>
        public bool deleteLocalRate(int id) 
        {
            bool flag = false;

            string sql = "delete from tb_local_pick_up where id=" + id;
            if (new DBOperateCommon().excuteNoQuery(sql))
            {
                flag = true;
            }

            return flag;
        }

        /// <summary>
        /// 获取所有本地取件邮费信息
        /// </summary>
        /// <returns></returns>
        public DataTable getLocalRateInfoTable()
        {
            DataTable table = new DataTable();

            string sql = "select * from tb_local_pick_up ";
            table = new DBOperateCommon().excuteQuery(sql);

            return table;
        }
    }
}