using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace WM_Project.control
{
    public class InterFaceQuote
    {

        /// <summary>
        /// 计算邮费
        /// </summary>
        /// <param name="name">会员名</param>
        /// <param name="destination">目的地</param>
        /// <param name="weight">重量</param>
        /// <param name="length">长</param>
        /// <param name="width">宽</param>
        /// <param name="height">高</param>
        /// <param name="post_way">服务方式</param>
        /// <returns></returns>
        public float getQuote(string name,string destination, float weight, float length, float width, float height, string post_way)
        {
            float price = 0;

            if(post_way=="EMS")
            {
                price = getEMSPrice(name, weight, length, width, height, destination);
            }
            else if (post_way.ToLower() == "postnl")
            {
                price = getPostNLPrice(name,weight,length,width,height,destination);
            }
            else if (post_way == "PF-GPR-Collection")
            {
                price = getGPRCollectionPrice(name,weight,length,width,height,destination);
            }
            else if(post_way=="PF-GPR-Delivery")
            {
                price = getGPRDeliveryPrice(name, weight, length, width, height, destination);
            }
            else if(post_way=="PF-IPE-Collection")
            {
                price = getIPECollectionPrice(name, weight, length, width, height, destination);
            }
            else if (post_way.Trim() == "PF-IPE-Depot")
            {
                price = getIPEDepotPrice(name, weight, length, width, height, destination);
            }
            else if (post_way == "PF-IPE-Pol")
            {
                price = getIPEPolPrice(name, weight, length, width, height, destination);
            }
            else if(post_way=="PF-IPE-Trailery")
            {
                price = getIPETraileryPrice(name, weight, length, width, height, destination);
            }

            return price;
        }

        /// <summary>
        /// 计算荷兰邮政的价格
        /// </summary>
        /// <param name="name"></param>
        /// <param name="weight"></param>
        /// <param name="length"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="destionation"></param>
        /// <returns></returns>
        private float getPostNLPrice(string name,float weight,float length,float width,float height,string destionation)
        {
            float price = 0;

            string sql = "";

            float chargeable = weight > (float)(length * width * height / 5000.0) ? weight : (float)(length * width * height / 5000.0);

            if (weight <= 30.0)
            {
                if (name == "")
                {
                    sql = "select kg,rate22  from tb_rate_postnl  where kg>=" + weight + " order by kg asc";

                    DataTable table1 = new DBOperateCommon().excuteQuery(sql);

                    price = Convert.ToSingle(table1.Rows[0]["rate22"]);

                    if (chargeable > weight)
                    {
                        price += (chargeable - weight);
                    }
                }
                else
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

            }
            else
            {
                price = 9000.0f;
            }


            return price;
        }

        /// <summary>
        /// 获取 GPR-Collection 的价格
        /// </summary>
        /// <param name="name"></param>
        /// <param name="weight"></param>
        /// <param name="length"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="destination"></param>
        /// <returns></returns>
        private float getGPRCollectionPrice(string name,float weight,float length,float width,float height,string destination)
        {
            float price = 0;

            string sql = "";
            string sql1 = "";
            DataTable table = new DataTable();

            if (name != "")
            {
                sql1 = "select ratetype from tb_set_user_pf_gpr_collection_rate where username='" + name + "'";
                table = new DBOperateCommon().excuteQuery(sql1);
            }

            float chargeable = weight > (float)(length * width * height / 5000.0) ? weight : (float)(length * width * height / 5000.0);

            if (chargeable > 30)
            {
                if (name != "")
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

                    price = (float)(price + (chargeable - 30.0) * 1.75 * 2 * 1.01);
                }
                else
                {
                    sql = "select kg,rate1 from tb_rate_pf_gpr_collection  where kg>=" + 30 + " order by kg asc";

                    DataTable table1 = new DBOperateCommon().excuteQuery(sql);
                    price = Convert.ToSingle(table1.Rows[0][1]);
                    price = (float)(price + (chargeable - 30.0) * 1.75 * 2 * 1.01);
                }
            }
            else
            {
                if (name != "")
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
                else
                {
                    sql = "select kg,rate1 from tb_rate_pf_gpr_collection  where kg>=" + chargeable + " order by kg asc";

                    DataTable table1 = new DBOperateCommon().excuteQuery(sql);
                    price = Convert.ToSingle(table1.Rows[0][1]);
                }
            }


            return price;
        }

        private float getGPRDeliveryPrice(string name,float weight,float length,float width,float height,string destination)
        {
            float price = 0;

            string sql = "";
            string sql1 = "";
            DataTable table = new DataTable();

            if (name != "")
            {
                sql1 = "select ratetype from tb_set_user_pf_gpr_delivery_rate where username='" + name + "'";
                table = new DBOperateCommon().excuteQuery(sql1);
            }
           

            float chargeable = weight > (float)(length * width * height / 5000.0) ? weight :(float)(length * width * height / 5000.0);

            if (chargeable > 30)
            {
                if (name != "")
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
                if (name != "")
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
        /// 计算 PF-IPE-Collection 的价格
        /// </summary>
        /// <param name="name"></param>
        /// <param name="weight"></param>
        /// <param name="length"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="destination"></param>
        /// <returns></returns>
        private float getIPECollectionPrice(string name, float weight, float length, float width, float height, string destination)
        {
            float price = 0;

            string sql = "";
            string sql1 = "";
            DataTable table = new DataTable();

            if (name != "")
            {
                sql1 = "select ratetype from tb_set_user_pf_ipe_collection_rate where username='" + name + "'";
                table = new DBOperateCommon().excuteQuery(sql1);
            } 

            float chargeable = weight > (float)(length * width * height / 5000.0) ? weight : (float)(length * width * height / 5000.0);

            if (chargeable > 30)
            {
                if (name != "")
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
                if (name != "")
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
        /// 计算 PF-IPE-Depot 的价格
        /// </summary>
        /// <param name="name"></param>
        /// <param name="weight"></param>
        /// <param name="length"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="destination"></param>
        /// <returns></returns>
        private float getIPEDepotPrice(string name, float weight, float length, float width, float height, string destination)
        {
            float price = 0;

            string sql = "";
            string sql1 = "";
            DataTable table = new DataTable();
            
            if (name != "")
            {
                sql1 = "select ratetype from tb_set_user_pf_ipe_depot_rate where username='" + name + "'";
                table = new DBOperateCommon().excuteQuery(sql1);
            }

            float chargeable = weight > (float)(length * width * height / 5000.0) ? weight : (float)(length * width * height / 5000.0);

            if (chargeable > 30)
            {
                if (name != "")
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
                if (name != "")
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
        /// 计算 PF-IPE-Pol 的价格
        /// </summary>
        /// <param name="name"></param>
        /// <param name="weight"></param>
        /// <param name="length"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="destination"></param>
        /// <returns></returns>
        private float getIPEPolPrice(string name, float weight, float length, float width, float height, string destination)
        {
            float price = 0;

            string sql = "";
            string sql1 = "";
            DataTable table = new DataTable();

            if (name != "")
            {
                sql1 = "select ratetype from tb_set_user_pf_ipe_pol_rate where username='" + name + "'";
                table = new DBOperateCommon().excuteQuery(sql1);
            }
            

            float chargeable = weight > (float)(length * width * height / 5000.0) ? weight : (float)(length * width * height / 5000.0);

            if (chargeable > 30)
            {
                if (name != "")
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
                if (name != "")
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
        /// 计算 PF-IPE-Trailery 的价格
        /// </summary>
        /// <param name="name"></param>
        /// <param name="weight"></param>
        /// <param name="length"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="destination"></param>
        /// <returns></returns>
        private float getIPETraileryPrice(string name, float weight, float length, float width, float height, string destination)
        {
            float price = 0;

            string sql = "";
            string sql1 = "";
            DataTable table = new DataTable();

            if (name != "")
            {
                sql1 = "select ratetype from tb_set_user_pf_ipe_trailer_rate where username='" + name + "'";
                table = new DBOperateCommon().excuteQuery(sql1);
            }
            

            float chargeable = weight > (float)(length * width * height / 5000.0) ? weight : (float)(length * width * height / 5000.0);

            if (chargeable > 30)
            {
                if (name != "")
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
                if (name != "")
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
                else
                {
                    sql = "select kg,rate1 from tb_rate_pf_ipe_trailer  where kg>=" + chargeable + " order by kg asc";

                    DataTable table1 = new DBOperateCommon().excuteQuery(sql);
                    price = Convert.ToSingle(table1.Rows[0][1]);
                }
            }

            return price;
        }


        /// <summary>
        /// 计算 EMS 的价格
        /// </summary>
        /// <param name="name"></param>
        /// <param name="weight"></param>
        /// <param name="length"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="destination"></param>
        /// <returns></returns>
        private float getEMSPrice(string name, float weight, float length, float width, float height, string destination)
        {
            float price = 0;

            string sql = "";

            float chargeable = weight > (float)(length * width * height / 5000.0) ? weight : (float)(length * width * height / 5000.0);

            if (chargeable <= 30.0)
            {
                if (name != "")
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
    }
}