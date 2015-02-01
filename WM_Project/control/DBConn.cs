using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace WM_Project.control
{
    public class DBConn
    {
        #region //数据库连接串
        private static readonly string database = ConfigurationManager.AppSettings["database"].ToString();
        private static readonly string uid = ConfigurationManager.AppSettings["uid"].ToString();
        private static readonly string pwd = ConfigurationManager.AppSettings["pwd"].ToString();
        private static readonly string server = ConfigurationManager.AppSettings["server"].ToString();
        private static readonly string condb = "server='" + server + "';database='" + database + "';uid='" + uid + "';pwd='" + pwd + "';Max Pool Size=100000;Min Pool Size=0;Connection Lifetime=0;packet size=32767;Connection Reset=false; async=true";
        #endregion
        public static SqlConnection getConn()
        {
            //string connString = "server='localhost';database='db_WMGlobal';uid='sa';pwd='19891102'";

            SqlConnection conn = new SqlConnection(condb);

            return conn;
        }
    }
}