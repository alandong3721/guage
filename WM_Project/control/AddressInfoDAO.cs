using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace WM_Project.control
{
    public class AddressInfoDAO
    {
        /// <summary>
        /// 从国家信息表中国获取国家信息
        /// </summary>
        /// <returns>将获取到的国家信息存放在DataTable中</returns>
        public DataTable getCoutryInfo()
        {
            DataTable dt = new DataTable();
            SqlConnection conn = DBConn.getConn();
            //  code为国家代码  name为国家名
            string sql = "select code,name from tb_country";
            SqlDataAdapter sda = new SqlDataAdapter(sql, conn);
            sda.Fill(dt);
            return dt;
        }

        /// <summary>
        /// 通过国家代码省份（包括直辖市）表中查找省份信息
        /// </summary>
        /// <param name="countrycode">国家代码</param>
        /// <returns>将所得到的省份信息存放在表中并返回</returns>
        public DataTable getProvinceInfo(string countrycode)
        {
            DataTable dt = new DataTable();
            SqlConnection conn = DBConn.getConn();
            //  code为省份代码   name为省份名
            string sql = "select code,name from tb_province where countrycode='" + countrycode + "'";
            SqlDataAdapter sda = new SqlDataAdapter(sql, conn);
            sda.Fill(dt);
            return dt;

        }

        /// <summary>
        /// 通过省份代码获得该省的城市信息
        /// </summary>
        /// <param name="provincecode">省份代码</param>
        /// <returns>将所得到的城市信息村放下DataTable中并返回</returns>
        public DataTable getCityInfo(string provincecode)
        {
            DataTable dt = new DataTable();
            SqlConnection conn = DBConn.getConn();
            string sql = "select code,name from tb_city where provincecode='" + provincecode + "'";
            SqlDataAdapter sda = new SqlDataAdapter(sql, conn);
            sda.Fill(dt);
            return dt;
        }

        /// <summary>
        /// 通过城市代码从城市信息表中获取该城市的区域信息
        /// </summary>
        /// <returns></returns>
        public DataTable getAreaInfo(string citycode)
        {
            DataTable dt = new DataTable();
            SqlConnection conn = DBConn.getConn();
            string sql = "select code,name from tb_area where citycode='" + citycode + "'";
            SqlDataAdapter sda = new SqlDataAdapter(sql, conn);
            sda.Fill(dt);
            return dt;
        }

        /// <summary>
        /// 通过国家名在国家表中获取国家代码
        /// </summary>
        /// <param name="country">国家名</param>
        /// <returns>返回国家代码</returns>
        public string getCountryCode(string country)
        {
            string code = "";

            SqlConnection conn = DBConn.getConn();
            string sql = "select code from tb_country where name='" + country + "'";
            SqlDataAdapter sda = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                code = dt.Rows[0]["code"].ToString();
            }
            return code;
        }

        /// <summary>
        /// 通过省份名在省份表中获取省份代码
        /// </summary>
        /// <param name="province">省份名</param>
        /// <returns>省份代码</returns>
        public string getProvinceCode(string province)
        {
            string code = "";

            SqlConnection conn = DBConn.getConn();
            string sql = "select code from tb_province where name='" + province + "'";
            SqlDataAdapter sda = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                code = dt.Rows[0]["code"].ToString();
            }

            return code;
        }


        /// <summary>
        /// 通过城市名在城市表中获取城市代码
        /// </summary>
        /// <param name="city">城市名</param>
        /// <returns>城市代码</returns>
        public string getCityCode(string city)
        {
            string code = "";

            SqlConnection conn = DBConn.getConn();
            string sql = "select code from tb_city where name='" + city + "'";
            SqlDataAdapter sda = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                code = dt.Rows[0]["code"].ToString();
            }

            return code;
        }

        /// <summary>
        /// 通过区域名在区域表中获取区域代码
        /// </summary>
        /// <param name="area">区域名</param>
        /// <returns>区域代码</returns>
        public string getAreaCode(string area,string citycode) 
        {
            string code = "";

            SqlConnection conn = DBConn.getConn();
            string sql = "select code from tb_area where name='" + area + "' and citycode='"+citycode+"'";
            SqlDataAdapter sda = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                code = dt.Rows[0]["code"].ToString();
            }

            return code;
        }
    }
}