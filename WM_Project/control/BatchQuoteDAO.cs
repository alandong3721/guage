using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

using WM_Project.control;

namespace WM_Project.control
{
    public class BatchQuoteDAO
    {
        public float getQuote(string name, string servicecode, float weight, float chargeable)
        {
            float price = 0;

            if (servicecode.Equals("PostNL"))
            {
                price = getPostNLPrice(name, weight, chargeable);
            }
            else if(servicecode.Equals("EMS"))
            {
                price = getEMSPrice(name, weight, chargeable);
            }
            else if(servicecode.Equals("PF-GPR-Collection"))
            {
                price = getPFGPRCollectionPrice(name, weight, chargeable);

            }
            else if(servicecode.Equals("PF-GPR-Delivery"))
            {
                price = getPFGPRDeliveryPrice(name, weight, chargeable);
            }
            else if(servicecode.Equals("PF-IPE-Collection"))
            {
                price = getPFIPECollectionPrice(name, weight, chargeable);
            }
            else if(servicecode.Equals("PF-IPE-Depot"))
            {
                price = getPFIPEDepotPrice(name, weight, chargeable);
            }
            else if(servicecode.Equals("PF-IPE-Pol"))
            {
                price = getPFIPEPolPrice(name, weight, chargeable);
            }
            else if(servicecode.Equals("PF-IPE-Trailer"))
            {
                price = getPFIPETrailerPrice(name, weight, chargeable);
            }

            price = (float)Math.Round(price, 2);

            return price;

        }

        /// <summary>
        /// 获取荷兰邮政的费用
        /// </summary>
        /// <param name="name"></param>
        /// <param name="weight"></param>
        /// <param name="volumertic_weight"></param>
        /// <returns></returns>
        private float getPostNLPrice(string name,float weight,float chargeable)
        {

            float price = 0;
            string sql = "";

            if (weight <= 30.0)
            {
                string sql1 = "select ratetype from tb_set_user_postnl_rate where username='" + name + "'";
                DataTable table = new DBOperateCommon().excuteQuery(sql1);
                if (table.Rows.Count > 0)
                {
                    sql = "select kg," + table.Rows[0][0].ToString() + " from tb_rate_postnl  where kg>=" + weight + " order by kg asc";

                    DataTable table1 = new DBOperateCommon().excuteQuery(sql);
                    price = Convert.ToSingle(table1.Rows[0][1]);
                    if (chargeable > weight)
                    {
                        price += (chargeable - weight);
                    }
                }
                else
                {
                    sql = "select kg,rate22  from tb_rate_postnl  where kg>=" + weight + " order by kg asc";

                    DataTable table1 = new DBOperateCommon().excuteQuery(sql);

                    price = Convert.ToSingle(table1.Rows[0]["rate22"]);

                    if (chargeable > weight)
                    {
                        price += (chargeable - weight);
                    }
                }

            }
            else
            {
                price = 9000.0f;
            }

            return price;

        }


        /// <summary>
        /// 计算EMS的邮费
        /// </summary>
        /// <param name="name">用户名</param>
        /// <param name="weight">重量</param>
        /// <param name="chargeable">实际计算的重量</param>
        /// <returns>价格</returns>
        private float getEMSPrice(string name,float weight,float chargeable)
        {
            float price = 0;
            string sql = "";

            if (chargeable <= 30.0)
            {
                string sql1 = "select ratetype from tb_set_user_ems_rate where username='" + name + "'";
                DataTable table = new DBOperateCommon().excuteQuery(sql1);

                if (table.Rows.Count > 0)
                {
                    sql = "select kg," + table.Rows[0][0].ToString() + " from tb_rate_ems  where kg>=" + chargeable + " order by kg asc";

                    DataTable table1 = new DBOperateCommon().excuteQuery(sql);
                    price = Convert.ToSingle(table1.Rows[0][1]);
                    
                }
                else
                {
                    sql = "select kg,rate1 from tb_rate_ems  where kg>=" + chargeable + " order by kg asc";

                    DataTable table1 = new DBOperateCommon().excuteQuery(sql);
                    price = Convert.ToSingle(table1.Rows[0][1]);
                }

            }
            else
            {
                price = 9000.0f;
            }

            return price;
        }


        /// <summary>
        /// 计算PF-GPR-Collection的邮费
        /// </summary>
        /// <param name="name">用户名</param>
        /// <param name="weight">重量</param>
        /// <param name="chargeable">计算价格的重量</param>
        /// <returns></returns>
        private float getPFGPRCollectionPrice(string name,float weight,float chargeable)
        {
            float price = 0;
            string sql = "";
            string sql1 = "select ratetype from tb_set_user_pf_gpr_collection_rate where username='" + name + "'";
            DataTable table = new DBOperateCommon().excuteQuery(sql1);

            if (chargeable > 30)
            {
                if (table.Rows.Count > 0)
                {
                    sql = "select kg," + table.Rows[0][0].ToString() + " from tb_rate_pf_gpr_collection  where kg>=" + 30 + " order by kg asc";

                    DataTable table1 = new DBOperateCommon().excuteQuery(sql);
                    price = Convert.ToSingle(table1.Rows[0][1]);
                }
                else
                {
                    sql = "select kg,rate1 from tb_rate_pf_gpr_collection  where kg>=" + 30 + " order by kg asc";

                    DataTable table1 = new DBOperateCommon().excuteQuery(sql);
                    price = Convert.ToSingle(table1.Rows[0][1]);
                }

                price = (float)(price+(chargeable - 30.0) * 1.75 * 2 * 1.01);
            }
            else
            {
                if (table.Rows.Count > 0)
                {
                    sql = "select kg," + table.Rows[0][0].ToString() + " from tb_rate_pf_gpr_collection  where kg>=" + chargeable + " order by kg asc";

                    DataTable table1 = new DBOperateCommon().excuteQuery(sql);
                    price = Convert.ToSingle(table1.Rows[0][1]);
                }
                else
                {
                    sql = "select kg,rate1 from tb_rate_pf_gpr_collection  where kg>=" + chargeable + " order by kg asc";

                    DataTable table1 = new DBOperateCommon().excuteQuery(sql);
                    price = Convert.ToSingle(table1.Rows[0][1]);
                }
            }

            return price;
        }


        /// <summary>
        /// 计算PF-GPR-Delivery的邮费
        /// </summary>
        /// <param name="name">用户名</param>
        /// <param name="weight">重量</param>
        /// <param name="chargeable">计算价格的重量</param>
        /// <returns></returns>
        private float getPFGPRDeliveryPrice(string name, float weight, float chargeable)
        {
            float price = 0;
            string sql = "";
            string sql1 = "select ratetype from tb_set_user_pf_gpr_delivery_rate where username='" + name + "'";
            DataTable table = new DBOperateCommon().excuteQuery(sql1);

            if (chargeable > 30)
            {
                if (table.Rows.Count > 0)
                {
                    sql = "select kg," + table.Rows[0][0].ToString() + " from tb_rate_pf_gpr_delivery  where kg>=" + 30 + " order by kg asc";

                    DataTable table1 = new DBOperateCommon().excuteQuery(sql);
                    price = Convert.ToSingle(table1.Rows[0][1]);
                }
                else
                {
                    sql = "select kg,rate1 from tb_rate_pf_gpr_delivery  where kg>=" + 30 + " order by kg asc";

                    DataTable table1 = new DBOperateCommon().excuteQuery(sql);
                    price = Convert.ToSingle(table1.Rows[0][1]);
                }

                price = (float)(price + (chargeable - 30.0) * 1.75 * 2 * 1.01);
            }
            else
            {
                if (table.Rows.Count > 0)
                {
                    sql = "select kg," + table.Rows[0][0].ToString() + " from tb_rate_pf_gpr_delivery  where kg>=" + chargeable + " order by kg asc";

                    DataTable table1 = new DBOperateCommon().excuteQuery(sql);
                    price = Convert.ToSingle(table1.Rows[0][1]);
                }
                else
                {
                    sql = "select kg,rate1 from tb_rate_pf_gpr_delivery  where kg>=" + chargeable + " order by kg asc";

                    DataTable table1 = new DBOperateCommon().excuteQuery(sql);
                    price = Convert.ToSingle(table1.Rows[0][1]);
                }
            }
            return price;
        }


        /// <summary>
        /// 计算PF-IPE-Collection的邮费
        /// </summary>
        /// <param name="name">用户名</param>
        /// <param name="weight">重量</param>
        /// <param name="chargeable">计算价格的重量</param>
        /// <returns></returns>
        private float getPFIPECollectionPrice(string name, float weight, float chargeable)
        {
            float price = 0;
            string sql = "";
            string sql1 = "select ratetype from tb_set_user_pf_ipe_collection_rate where username='" + name + "'";
            DataTable table = new DBOperateCommon().excuteQuery(sql1);

            if (chargeable > 30)
            {
                if (table.Rows.Count > 0)
                {
                    sql = "select kg," + table.Rows[0][0].ToString() + " from tb_rate_pf_ipe_collection  where kg>=" + 30 + " order by kg asc";

                    DataTable table1 = new DBOperateCommon().excuteQuery(sql);
                    price = Convert.ToSingle(table1.Rows[0][1]);
                }
                else
                {
                    sql = "select kg,rate1 from tb_rate_pf_ipe_collection  where kg>=" + 30 + " order by kg asc";

                    DataTable table1 = new DBOperateCommon().excuteQuery(sql);
                    price = Convert.ToSingle(table1.Rows[0][1]);
                }

                price = (float)(price + (chargeable - 30.0) * 1.75 * 2 * 1.01);
            }
            else
            {
                if (table.Rows.Count > 0)
                {
                    sql = "select kg," + table.Rows[0][0].ToString() + " from tb_rate_pf_ipe_collection  where kg>=" + chargeable + " order by kg asc";

                    DataTable table1 = new DBOperateCommon().excuteQuery(sql);
                    price = Convert.ToSingle(table1.Rows[0][1]);
                }
                else
                {
                    sql = "select kg,rate1 from tb_rate_pf_ipe_collection  where kg>=" + chargeable + " order by kg asc";

                    DataTable table1 = new DBOperateCommon().excuteQuery(sql);
                    price = Convert.ToSingle(table1.Rows[0][1]);
                }
            }

            return price;
        }


        /// <summary>
        /// 计算PF-IPE-Depot Drop Off的邮费
        /// </summary>
        /// <param name="name">用户名</param>
        /// <param name="weight">重量</param>
        /// <param name="chargeable">计算价格的重量</param>
        /// <returns></returns>
        private float getPFIPEDepotPrice(string name, float weight, float chargeable)
        {
            float price = 0;
            string sql = "";
            string sql1 = "select ratetype from tb_set_user_pf_ipe_depot_rate where username='" + name + "'";
            DataTable table = new DBOperateCommon().excuteQuery(sql1);

            if (chargeable > 30)
            {
                if (table.Rows.Count > 0)
                {
                    sql = "select kg," + table.Rows[0][0].ToString() + " from tb_rate_pf_ipe_depot  where kg>=" + 30 + " order by kg asc";

                    DataTable table1 = new DBOperateCommon().excuteQuery(sql);
                    price = Convert.ToSingle(table1.Rows[0][1]);
                }
                else
                {
                    sql = "select kg,rate1 from tb_rate_pf_ipe_depot  where kg>=" + 30 + " order by kg asc";

                    DataTable table1 = new DBOperateCommon().excuteQuery(sql);
                    price = Convert.ToSingle(table1.Rows[0][1]);
                }

                price = (float)(price + (chargeable - 30.0) * 1.75 * 2 * 1.01);
            }
            else
            {
                if (table.Rows.Count > 0)
                {
                    sql = "select kg," + table.Rows[0][0].ToString() + " from tb_rate_pf_ipe_depot  where kg>=" + chargeable + " order by kg asc";

                    DataTable table1 = new DBOperateCommon().excuteQuery(sql);
                    price = Convert.ToSingle(table1.Rows[0][1]);
                }
                else
                {
                    sql = "select kg,rate1 from tb_rate_pf_ipe_depot  where kg>=" + chargeable + " order by kg asc";

                    DataTable table1 = new DBOperateCommon().excuteQuery(sql);
                    price = Convert.ToSingle(table1.Rows[0][1]);
                }
            }
            return price;
        }

        /// <summary>
        /// 计算PF-IPE-Pol Drop Off 邮费
        /// </summary>
        /// <param name="name">用户名</param>
        /// <param name="weight">重量</param>
        /// <param name="chargeable">计算价格的重量</param>
        /// <returns></returns>
        private float getPFIPEPolPrice(string name, float weight, float chargeable)
        {
            float price = 0;
            string sql = "";
            string sql1 = "select ratetype from tb_set_user_pf_ipe_pol_rate where username='" + name + "'";
            DataTable table = new DBOperateCommon().excuteQuery(sql1);

            if (chargeable > 30)
            {
                if (table.Rows.Count > 0)
                {
                    sql = "select kg," + table.Rows[0][0].ToString() + " from tb_rate_pf_ipe_pol  where kg>=" + 30 + " order by kg asc";

                    DataTable table1 = new DBOperateCommon().excuteQuery(sql);
                    price = Convert.ToSingle(table1.Rows[0][1]);
                }
                else
                {
                    sql = "select kg,rate1 from tb_rate_pf_ipe_pol  where kg>=" + 30 + " order by kg asc";

                    DataTable table1 = new DBOperateCommon().excuteQuery(sql);
                    price = Convert.ToSingle(table1.Rows[0][1]);
                }

                price = (float)(price + (chargeable - 30.0) * 1.75 * 2 * 1.01);
            }
            else
            {
                if (table.Rows.Count > 0)
                {
                    sql = "select kg," + table.Rows[0][0].ToString() + " from tb_rate_pf_ipe_pol  where kg>=" + chargeable + " order by kg asc";

                    DataTable table1 = new DBOperateCommon().excuteQuery(sql);
                    price = Convert.ToSingle(table1.Rows[0][1]);
                }
                else
                {
                    sql = "select kg,rate1 from tb_rate_pf_ipe_pol  where kg>=" + chargeable + " order by kg asc";

                    DataTable table1 = new DBOperateCommon().excuteQuery(sql);
                    price = Convert.ToSingle(table1.Rows[0][1]);
                }
            }

            return price;
        }


        /// <summary>
        /// 计算PE-IPE-Trailer 的邮费
        /// </summary>
        /// <param name="name">用户名</param>
        /// <param name="weight">重量</param>
        /// <param name="chargeable">计算价格的重量</param>
        /// <returns></returns>
        private float getPFIPETrailerPrice(string name, float weight, float chargeable)
        {
            float price = 0;
            string sql = "";
            string sql1 = "select ratetype from tb_set_user_pf_ipe_trailer_rate where username='" + name + "'";
            DataTable table = new DBOperateCommon().excuteQuery(sql1);

            if (chargeable > 30)
            {
                if (table.Rows.Count > 0)
                {
                    sql = "select kg," + table.Rows[0][0].ToString() + " from tb_rate_pf_ipe_trailer  where kg>=" + 30 + " order by kg asc";

                    DataTable table1 = new DBOperateCommon().excuteQuery(sql);
                    price = Convert.ToSingle(table1.Rows[0][1]);
                }
                else
                {
                    sql = "select kg,rate1 from tb_rate_pf_ipe_trailer  where kg>=" + 30 + " order by kg asc";

                    DataTable table1 = new DBOperateCommon().excuteQuery(sql);
                    price = Convert.ToSingle(table1.Rows[0][1]);
                }

                price = (float)(price + (chargeable - 30.0) * 1.75 * 2 * 1.01);
            }
            else
            {
                if (table.Rows.Count > 0)
                {
                    sql = "select kg," + table.Rows[0][0].ToString() + " from tb_rate_pf_ipe_trailer  where kg>=" + chargeable + " order by kg asc";

                    DataTable table1 = new DBOperateCommon().excuteQuery(sql);
                    price = Convert.ToSingle(table1.Rows[0][1]);
                }
                else
                {
                    sql = "select kg,rate1 from tb_rate_pf_ipe_trailer  where kg>=" + chargeable + " order by kg asc";

                    DataTable table1 = new DBOperateCommon().excuteQuery(sql);
                    price = Convert.ToSingle(table1.Rows[0][1]);
                }
            }

            return price;
        }

    }
}