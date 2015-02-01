using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WM_Project
{
    public partial class test : System.Web.UI.Page
    {

        public static string message = "";


        protected void Page_Load(object sender, EventArgs e)
        {
            //删除tb_users表中重复的用户

            //string connString = "server='localhost';database='wmglobal';uid='sa';pwd='19891102'";

            //SqlConnection conn = new SqlConnection(connString);

            //string sql = "select * from wp_users";
            //DataTable table = new DataTable();

            //SqlDataAdapter sda = new SqlDataAdapter(sql, conn);
            //sda.Fill(table);

            //SqlConnection temp_conn = new SqlConnection(connString);
            //temp_conn.Open();

            //for (int i = table.Rows.Count - 1; i>=0 ; i--)
            //{
            //    string user_login = table.Rows[i]["user_login"].ToString().ToLower();

            //    for (int j = 0; j < i; j++)
            //    {
            //        string name = table.Rows[j]["user_login"].ToString().ToLower();
            //        int id = Convert.ToInt32(table.Rows[j]["ID"].ToString());

            //        if (user_login.Equals(name))
            //        {
            //            string delete = "delete from wp_users where ID=" + id;
            //            SqlCommand cmd = new SqlCommand(delete,temp_conn);
            //            cmd.ExecuteNonQuery();
            //        }
            //    }
            //}

            message = "<table style='width:200px;border:2px solid #DADADA;margin-top:200px'><tr><td>dakfdsjf </td></tr></table>";
        }
    }
}