using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace WM_Project.control
{

    //邮费计算类
    public class PosCalculate
    {

        public ArrayList getFromTO(string endCountry)
        {
            ArrayList ways = new ArrayList();

            DataTable dt = new DataTable();
            string sql = "select post_way from tb_canpost where departure='UK' and destination='" + endCountry + "'";
            dt = new DBOperateCommon().excuteQuery(sql);

            foreach (DataRow dr in dt.Rows)
                ways.Add(dr["post_way"].ToString());

            return ways;
        }

        /// <summary>
        /// 通过起始国家、终止国家信息来查找通邮表，获取所有的可能邮寄方式
        /// </summary>
        /// <param name="startCountry">起始国家</param>
        /// <param name="endCountry">终止国家</param>
        /// <returns>返回的DataTable中包括 邮寄方式名 postname 、 备注 note 信息</returns>
        public DataTable getPostWays(string endCountry)
        {
            DataTable dt = new DataTable();
            string sql = "select * from tb_canpost where departure='UK' and destination='" + endCountry + "'";
            SqlConnection conn = DBConn.getConn();
            SqlDataAdapter sda = new SqlDataAdapter(sql, conn);

            sda.Fill(dt);

            return dt;
        }

        /// <summary>
        /// 通过邮寄方式名来获取该邮寄方式所对应的 图标路径
        /// </summary>
        /// <param name="postName">邮寄方式名</param>
        /// <returns></returns>
        public string getPostNameImagePath(string postName)
        {
            string imagePath = "";
            SqlConnection conn = DBConn.getConn();
            string sql = "select imagePath from tb_postway where postname='" + postName + "'";
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(sql, conn);
            sda.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                imagePath = dt.Rows[0][0].ToString();
            }

            return imagePath;
        }

        /// <summary>
        /// 获取某一种服务方式的备注
        /// </summary>
        /// <param name="post_way">服务方式</param>
        /// <returns></returns>
        public string getNote(string post_way,string endCountry)
        {
            string note = "";

            string sql = "select note from tb_canpost where post_way='" + post_way + "' and departure='UK' and destination='" + endCountry + "'";

            DataTable table = new DBOperateCommon().excuteQuery(sql);
            
            if (table.Rows.Count > 0)
            {
                note = table.Rows[0][0].ToString();
            }

            return note;
        }

    }
}