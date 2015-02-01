using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;


namespace WM_Project.control
{
    public class DBOperateCommon
    {
        //更新数据库（增加、删除、更新）
        /// <summary>
        /// 执行数据库的 增加、删除、更新 操作
        /// </summary>
        /// <param name="sql">执行的SQL 语句</param>
        /// <returns>SQL语句正确执行返回True，否则返回 false</returns>
        public bool excuteNoQuery(string sql)
        {
            bool flag = false;

            SqlConnection conn = DBConn.getConn();
            conn.Open();
            SqlCommand scmd = new SqlCommand(sql, conn);

            if (scmd.ExecuteNonQuery() > 0)
            {
                flag = true;
            }
            conn.Close();

            return flag;
        }

        /// <summary>
        /// 执行数据库的查询语句
        /// </summary>
        /// <param name="sql">所要执行的SQL语句</param>
        /// <returns>成功执行则返回所获得的DataTable表</returns>
        public DataTable excuteQuery(string sql)
        {
            DataTable dt = new DataTable();
            SqlConnection conn = DBConn.getConn();
            SqlDataAdapter sda = new SqlDataAdapter(sql,conn);
            sda.Fill(dt);
            conn.Close();
            return dt;
        }

    }
}