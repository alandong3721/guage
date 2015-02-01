using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace WM_Project.control
{
    public class CanPostDAO
    {

        /// <summary>
        /// 获取发件国家信息
        /// </summary>
        /// <returns>将所有能发送快件的国家名存放至ArrayList中</returns>
        public ArrayList getFromCountry()
        {
            ArrayList countrys = new ArrayList();
            DataTable dt = new DataTable();
            
            string sql = "select distinct startcountry from tb_canpost";

            dt = new DBOperateCommon().excuteQuery(sql);

            foreach (DataRow dr in dt.Rows)
                countrys.Add(dr["startcountry"].ToString());

            return countrys;
        }


        /// <summary>
        /// 获取发件国家信息
        /// </summary>
        /// <returns>将所有能发送快件的国家名存放至ArrayList中</returns>
        public ArrayList getToCountry(string startcountry)
        {
            ArrayList countrys = new ArrayList();
            DataTable dt = new DataTable();

            string sql = "select distinct endcountry from tb_canpost where startcountry='" + startcountry + "'";

            dt = new DBOperateCommon().excuteQuery(sql);

            foreach (DataRow dr in dt.Rows)
                countrys.Add(dr["endcountry"].ToString());

            return countrys;
        }



        /// <summary>
        /// 获取发件国家信息
        /// </summary>
        /// <returns>将所有能发送快件的国家名放在 DataTable 表中</returns>
        public DataTable getSendCountry()
        {
            DataTable dt = new DataTable();
            SqlConnection conn = DBConn.getConn();
            string sql = "select distinct startcountry from tb_canpost";
            SqlDataAdapter sda = new SqlDataAdapter(sql, conn);
            sda.Fill(dt);
            return dt;
        }

        /// <summary>
        /// 通过发件国家信息查找收件国家信息
        /// </summary>
        /// <param name="startcountry">发件国家名</param>
        /// <returns>将发件国家所能到达的所有国家名放在DataTable表中</returns>
        public DataTable getReceiveCountry(string startcountry)
        {
            DataTable dt = new DataTable();
            SqlConnection conn = DBConn.getConn();
            string sql = "select distinct endcountry from tb_canpost where startcountry='" + startcountry + "'";
            SqlDataAdapter sda = new SqlDataAdapter(sql, conn);
            sda.Fill(dt);
            return dt;
        }
    }
}