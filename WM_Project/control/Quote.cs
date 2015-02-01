using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

using WM_Project.logical.common;

namespace WM_Project.control
{
    public class Quote
    {
        //获得邮费
        public float getQuote(string departure, string destination, float weight, float length, float width, float height, string post_way)
        {
            float price = 0;

            //如果是Parcelforce优先包 自动包
            if (post_way == "Parcelforce priority auto")
            {
                price = getPriceParcelforceAuto(departure, destination, weight, length, width, height);
            }
            else if (post_way == "Parcelforce economy")   //如果是Parcelforce 经济包
            {
                price = getPriceParcelforceEconomy(departure, destination, weight, length, width, height);
            }
            else if (post_way == "EMS")
            {
                price = getPriceEMS(weight, length, width, height);
            }

            return price;
        }

        /// <summary>
        /// 获取邮费
        /// </summary>
        /// <param name="departure">发件国家</param>
        /// <param name="destination">收件国家</param>
        /// <param name="weight">重量</param>
        /// <param name="postway">服务方式</param>
        /// <returns></returns>
        public float getQuote(string departure, string destination, float weight,float vloumetric_weight, string postway, string name)
        {
            float money = 0;

            money = getPricePostNL(weight,vloumetric_weight, name);

            return money;
        }

        //////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// 计算包裹的价格
        /// </summary>
        /// <param name="departure">发件地</param>
        /// <param name="destination">收件地</param>
        /// <param name="weight">重量</param>
        /// <param name="length">长度</param>
        /// <param name="width">宽度</param>
        /// <param name="height">高度</param>
        /// <returns></returns>
        private float getPriceParcelforceAuto(string departure, string destination, float weight, float length, float width, float height)
        {
            float price = 0;

            if (departure == "UK" && destination == "UK")
            {
                price = parcelforceAutoFromUKToUK(weight);
            }
            else if (departure == "UK" && destination == "China")
            {
                price = parcelforceAutoFromUKToChina(weight, length, width, height);
            }
            else if (departure == "UK" && destination == "HongKong")
            {
                price = parcelforceAutoFromUKToHongKong(weight, length, width, height);
            }
            else if (departure == "UK" && destination == "TaiWan")
            {
                price = parcelforceAutoFromUKToTaiWan(weight, length, width, height);
            }

            return price;

        }

        //////////////////////////////////////////////////////////////////////////
        //Parcelforce 优先自动包 邮费的计算
        /// <summary>
        /// 快件从英国发送到英国，只与重量有关
        /// </summary>
        /// <param name="weight">重量</param>
        /// <returns>返回邮寄费用</returns>
        private float parcelforceAutoFromUKToUK(float weight)
        {
            float price = 0;

            Postage postage = new PostageDAO().getPostage(weight, "UK", "UK", "Parcelforce priority auto");

            if (weight >= postage.Weight)
            {
                weight = postage.Weight;
            }

            price = weight * postage.Rate;

            return price;
        }

        /// <summary>
        /// 计算从英国寄到中国的包裹费用
        /// </summary>
        /// <param name="weight">重量</param>
        /// <param name="length">长度</param>
        /// <param name="width">宽度</param>
        /// <param name="height">高度</param>
        /// <returns></returns>
        private float parcelforceAutoFromUKToChina(float weight, float length, float width, float height)
        {
            Postage rate = new Postage();
            float price = 0;

            //获得包裹的实际重量，如果体积过大就计算体积重
            weight = (float)Math.Max(weight, ((length * width * height) / 5000.0));

            if (weight <= 30.0)
            {
                rate = new PostageDAO().getPostage(weight, "UK", "China", "Parcelforce priority auto");
                price = 1.01f * rate.Rate / rate.Per;
            }
            else
            {
                rate = new PostageDAO().getPostage(30.0f, "UK", "China", "Parcelforce priority auto");
                price = (float)(rate.Rate + (weight - 30.0) * 1.78 * 2 * 1.01);
            }

            return price;
        }

        /// <summary>
        /// 计算从英国寄往香港的包裹费用
        /// </summary>
        /// <param name="weight">重量</param>
        /// <param name="length">长度</param>
        /// <param name="width">宽度</param>
        /// <param name="height">高度</param>
        /// <returns></returns>
        private float parcelforceAutoFromUKToHongKong(float weight, float length, float width, float height)
        {
            Postage rate = new Postage();
            float price = 0;

            //获得包裹的实际重量，如果体积过大就计算体积重
            weight = (float)Math.Max(weight, ((length * width * height) / 5000.0));

            if (weight <= 30.0)
            {
                rate = new PostageDAO().getPostage(weight, "UK", "HongKong", "Parcelforce priority auto");
                price = rate.Rate;
            }
            else
            {
                rate = new PostageDAO().getPostage(30.0f, "UK", "HongKong", "Parcelforce priority auto");
                price = (float)(rate.Rate + (weight - 30.0) * 1.78 * 2 * 1.01);
            }

            return price;
        }


        /// <summary>
        /// 计算从英国寄往台湾的包裹费用
        /// </summary>
        /// <param name="weight">重量</param>
        /// <param name="length">长度</param>
        /// <param name="width">宽度</param>
        /// <param name="height">高度</param>
        /// <returns></returns>
        private float parcelforceAutoFromUKToTaiWan(float weight, float length, float width, float height)
        {
            Postage rate = new Postage();
            float price = 0;

            //获得包裹的实际重量，如果体积过大就计算体积重
            weight = (float)Math.Max(weight, ((length * width * height) / 5000.0));

            if (weight <= 30.0)
            {
                rate = new PostageDAO().getPostage(weight, "UK", "TaiWan", "Parcelforce priority auto");
                price = rate.Rate;
            }
            else
            {
                rate = new PostageDAO().getPostage(30.0f, "UK", "TaiWan", "Parcelforce priority auto");
                price = (float)(rate.Rate + (weight - 30.0) * 1.78 * 2 * 1.01);
            }

            return price;
        }


        //////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////
        //Parcelforce economy计算邮费的实现
        public float getPriceParcelforceEconomy(string departure, string destination, float weight, float length, float width, float height)
        {
            float price = 0;
            if (departure == "UK" && destination == "UK")
            {
                price = parcelforceEconomyFromUKToUK(weight, length, width, height);
            }
            else if (departure == "UK" && destination == "China")
            {
                price = parcelforceEconomyFromUKToChina(weight, length, width, height);
            }
            else if (departure == "UK" && destination == "HongKong")
            {
                price = parcelforceEconomyFromUKToHongKong(weight, length, width, height);
            }
            else if (departure == "UK" && destination == "TaiWan")
            {
                price = parcelforceEconomyFromUKToTaiWan(weight, length, width, height);
            }
            return price;
        }

        /// <summary>
        /// 计算从英国寄到英国的包裹
        /// </summary>
        /// <param name="weight">重量</param>
        /// <param name="length">长度</param>
        /// <param name="width">宽度</param>
        /// <param name="height">高度</param>
        /// <returns></returns>
        private float parcelforceEconomyFromUKToUK(float weight, float length, float width, float height)
        {
            float price = 0;

            Postage postage = new PostageDAO().getPostage(weight, "UK", "UK", "Parcelforce economy");

            if (weight >= postage.Weight)
            {
                weight = postage.Weight;
            }

            price = weight * postage.Rate;

            return price;
        }

        /// <summary>
        /// 计算从英国寄到中国大陆邮费
        /// </summary>
        /// <param name="weight">重量</param>
        /// <param name="length">长度</param>
        /// <param name="width">宽度</param>
        /// <param name="height">高度</param>
        /// <returns></returns>
        private float parcelforceEconomyFromUKToChina(float weight, float length, float width, float height)
        {
            float price = 0;

            Postage postage = new Postage();

            //获得包裹的实际重量，如果体积过大就计算体积重
            weight = (float)Math.Max(weight, ((length * width * height) / 5000.0));

            if (weight <= 30.0)
            {
                postage = new PostageDAO().getPostage(weight, "UK", "China", "Parcelforce economy");
                price = postage.Rate;
            }
            else
            {
                postage = new PostageDAO().getPostage(30.0f, "UK", "China", "Parcelforce economy");
                price = (float)(postage.Rate + (weight - 30.0) * 1.75 * 2 * 1.01);
            }

            return price;
        }

        /// <summary>
        /// 计算从英国寄到香港的邮费
        /// </summary>
        /// <param name="weight">重量</param>
        /// <param name="length">长度</param>
        /// <param name="width">宽度</param>
        /// <param name="height">高度</param>
        /// <returns></returns>
        private float parcelforceEconomyFromUKToHongKong(float weight, float length, float width, float height)
        {
            float price = 0;

            Postage postage = new Postage();

            //获得包裹的实际重量，如果体积过大就计算体积重
            weight = (float)Math.Max(weight, ((length * width * height) / 5000.0));

            if (weight <= 30.0)
            {
                postage = new PostageDAO().getPostage(weight, "UK", "HongKong", "Parcelforce economy");
                price = postage.Rate;
            }
            else
            {
                postage = new PostageDAO().getPostage(30.0f, "UK", "HongKong", "Parcelforce economy");
                price = (float)(postage.Rate + (weight - 30.0) * 1.75 * 2 * 1.01);
            }

            return price;
        }

        /// <summary>
        /// 计算从英国寄到台湾的邮费
        /// </summary>
        /// <param name="weight">重量</param>
        /// <param name="length">长度</param>
        /// <param name="width">宽度</param>
        /// <param name="height">高度</param>
        /// <returns></returns>
        private float parcelforceEconomyFromUKToTaiWan(float weight, float length, float width, float height)
        {
            float price = 0;

            Postage postage = new Postage();

            //获得包裹的实际重量，如果体积过大就计算体积重
            weight = (float)Math.Max(weight, ((length * width * height) / 5000.0));

            if (weight <= 30.0)
            {
                postage = new PostageDAO().getPostage(weight, "UK", "TaiWan", "Parcelforce economy");
                price = postage.Rate;
            }
            else
            {
                postage = new PostageDAO().getPostage(30.0f, "UK", "TaiWan", "Parcelforce economy");
                price = (float)(postage.Rate + (weight - 30.0) * 1.75 * 2 * 1.01);
            }

            return price;
        }

        /// <summary>
        /// 从英国到中国的 EMS方式的运费计算
        /// </summary>
        /// <param name="weight">重量</param>
        /// <param name="length">长度</param>
        /// <param name="width">宽度</param>
        /// <param name="height">高度</param>
        /// <returns>返回价格</returns>
        private float getPriceEMS(float weight, float length, float width, float height)
        {
            float price = 0;
            string sql = "";
            //获得包裹的实际重量，如果体积过大就计算体积重
            weight = (float)Math.Max(weight, ((length * width * height) / 5000.0));

            if (weight <= 30.0)
            {
                sql = "select * from tb_rate_ems  where kg>=" + weight + " order by kg asc";

                DataTable table = new DBOperateCommon().excuteQuery(sql);

                if (table.Rows.Count > 0)
                {
                    price = Convert.ToSingle(table.Rows[0]["rate1"]);
                }

            }
            else
            {
                price = 9000.0f;
            }

            return price;
        }


        /// <summary>
        /// 通过重量获取
        /// </summary>
        /// <param name="weight"></param>
        /// <returns></returns>
        public float getPricePostNL(float weight, float volumetric_weight,string username)
        {
            float price = 0;
            string sql = "";

            string sql1 = "select ratetype from tb_set_user_postnl_rate where username='" + username + "'";
            DataTable table = new DBOperateCommon().excuteQuery(sql1);

            if (weight <= 30.0)
            {

                if (table.Rows.Count > 0)
                {
                    sql = "select kg," + table.Rows[0][0].ToString() + " from tb_rate_postnl  where kg>=" + weight + " order by kg asc";

                    DataTable table1 = new DBOperateCommon().excuteQuery(sql);
                    price = Convert.ToSingle(table1.Rows[0][1]);
                    if (volumetric_weight > weight)
                    {
                        price += (volumetric_weight - weight);
                    }
                }
                else
                {
                    sql = "select kg,rate1  from tb_rate_postnl  where kg>=" + weight + " order by kg asc";

                    DataTable table1 = new DBOperateCommon().excuteQuery(sql);
                    
                    price = Convert.ToSingle(table1.Rows[0]["rate1"]);

                    if(volumetric_weight>weight){
                         price += (volumetric_weight - weight);
                    }
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