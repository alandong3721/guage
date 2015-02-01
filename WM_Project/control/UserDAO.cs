using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Data;
using System.Data.SqlClient;

using WM_Project.logical.user;

namespace WM_Project.control
{
    public class UserDAO
    {
        public SqlConnection conn = null;
        public SqlCommand scmd = null;


        /// <summary>
        /// 检测用户是否存在 
        /// </summary>
        /// <param name="userName"></param>
        /// <returns>用户存在返回True，否则返回false</returns>
        public bool isUserExist(string userName)
        {
            bool flag = false;
            User user = new UserDAO().getUser(userName);

            if (user != null)
            {
                flag = true;
            }
            return flag;
        }

        /// <summary>
        /// 添加会员
        /// </summary>
        /// <param name="user"></param>
        /// <returns>添加成功返回 True， 否则 返回 false</returns>
        public bool addUser(User user)
        {
            bool flag = false;
            string pwd = FormsAuthentication.HashPasswordForStoringInConfigFile(user.Password, "MD5");

            string sql = "insert into tb_user values('" + user.Name + "','" + user.Email + "','" + user.RecommandUser + "','" +
                          user.Website + "','" + user.CompanyName + "','" +user.Telephone + "','" +pwd + "','"+DateTime.Now.ToString()+"','"+user.Delivery+"','"+user.Success_code+"',"+user.Charge_amount+")";

            if (new DBOperateCommon().excuteNoQuery(sql) == true)
            {
                flag = true;
            }

            return flag;
        }

        /// <summary>
        /// user 登陆时进行身份验证
        /// </summary>
        /// <param name="userName">用户名</param> 
        /// <param name="password">密码</param>
        /// <returns>用户名、密码正确返回 1；用户名存在而密码错误返回 0；用户名不存在返回 -1</returns>
        public int checkUser(string userName, string password)
        {
            int flag = -1;

            string pwd = FormsAuthentication.HashPasswordForStoringInConfigFile(password, "MD5");

            User user = getUser(userName);

            if (user != null)
            {
                if (user.Password.Length == 32)
                {
                    //密码正确
                    if (user.Password.Equals(pwd))
                    {
                        flag = 1;
                    }
                    else
                    {
                        flag = 0;   //密码错误
                    }
                }
                else
                {
                    if (CheckLogin.CheckPassword(password, user.Password))
                    {
                        flag = 1;
                    }
                    else
                    {
                        flag = 0;
                    }
                }
                
            }

            return flag;
        }


        /// <summary>
        /// 跟新用户的取件是否免费
        /// </summary>
        /// <param name="username"></param>
        /// <param name="delivery"></param>
        /// <returns></returns>
        public bool updateDelivery(string username,string delivery)
        {
            bool flag = false;

            string update = "update tb_user set delivery='" + delivery + "' where name='" + username + "'";
            if (new DBOperateCommon().excuteNoQuery(update))
            {
                flag = true;
            }

            return flag;

        }


        /// <summary>
        /// 分页获取取件免费的用户信息
        /// </summary>
        /// <param name="pageNow">当前页</param>
        /// <param name="pageSize">每页显示的条数</param>
        /// <returns></returns>
        public DataTable getUserDeliveryFree(int pageNow,int pageSize)
        {
            DataTable table = new DataTable();
            string sql = "select top " + pageSize + " name,delivery from tb_user where delivery='free' and name not in(select top " + (pageNow - 1) * pageSize + " name from tb_user where delivery='free' )";
            table = new DBOperateCommon().excuteQuery(sql);
            return table;
        }
        
        /// <summary>
        /// 获取取件免费的用户的纪录条数
        /// </summary>
        /// <returns></returns>
        public int getDeliveryFreeCount()
        {
            int count = 0;

            string sql = "select count(*) from tb_user where delivery='free' ";
            DataTable table = new DBOperateCommon().excuteQuery(sql);

            if(table.Rows.Count>0)
            {
                count = Convert.ToInt32(table.Rows[0][0].ToString());
            }

            return count;
        }

        /// <summary>
        /// 获取免费取件用户的页数
        /// </summary>
        /// <param name="recordCount">纪录的条数</param>
        /// <param name="pageSize">每页显示的页数</param>
        /// <returns></returns>
        public int getDeliveryFreePageCount(int recordCount,int pageSize)
        {
            int page_Count = 0;

            if (recordCount % pageSize == 0)
            {
                page_Count = recordCount / pageSize;
            }
            else
            {
                page_Count = recordCount / pageSize + 1;
            }

            return page_Count;
        }


        /// <summary>
        /// 重置密码
        /// </summary>
        /// <param name="name">用户名</param>
        /// <param name="password">新密码</param>
        /// <returns>重置成功返回 True，否则返回 False</returns>
        public bool resetPassword(string name, string password)
        {
            bool flag = false;
            string pwd = FormsAuthentication.HashPasswordForStoringInConfigFile(password, "MD5");

            string sql = "update tb_user set password='" + pwd + "' where name='" + name + "'";

            if (new DBOperateCommon().excuteNoQuery(sql) == true)
            {
                flag = true;
            }
            return flag;
        }

       

        /// <summary>
        /// 通过用户名来获取User对象
        /// </summary>
        /// <param name="name">用户名</param>
        /// <returns>User 对象</returns>
        public User getUser(string name)
        {
            User user = null;

            String sql = "select * from tb_user where name='" + name + "'";
            conn = DBConn.getConn();
            SqlDataAdapter sda = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                user = new User();
                user.Name = dt.Rows[0]["name"].ToString();
                user.Email = dt.Rows[0]["email"].ToString();
                user.RecommandUser = dt.Rows[0]["recommendUser"].ToString();
                user.Website = dt.Rows[0]["website"].ToString();
                user.CompanyName = dt.Rows[0]["companyName"].ToString();
                user.Telephone = dt.Rows[0]["telephone"].ToString();
                user.Password = dt.Rows[0]["password"].ToString();
                user.Regist_time = Convert.ToDateTime(dt.Rows[0]["regist_time"].ToString());
                user.Delivery = dt.Rows[0]["delivery"].ToString();
                user.Success_code = dt.Rows[0]["success_code"].ToString();
                user.Charge_amount = Convert.ToSingle(dt.Rows[0]["charge_amount"]);
            }

            return user;
        }

        /// <summary>
        /// 更新用户的支付成功码
        /// </summary>
        /// <param name="name">用户名</param>
        /// <param name="code">支付码</param>
        /// <returns></returns>
        public bool updateSuccessCode(string name,string code)
        {
            bool flag = false;

            string sql = "update tb_user set success_code='" + code + "' where name='" + name + "'";

            if (new DBOperateCommon().excuteNoQuery(sql))
            {
                flag = false;
            }

            return flag;
        }


        /// <summary>
        /// 更新用户的支付成功码
        /// </summary>
        /// <param name="name">用户名</param>
        /// <param name="code">支付码</param>
        /// <returns></returns>
        public bool updateChargeCode(string name, string code, float money)
        {
            bool flag = false;

            string sql = "update tb_user set success_code='" + code + "',charge_amount=" + money + " where name='" + name + "'";

            if (new DBOperateCommon().excuteNoQuery(sql))
            {
                flag = false;
            }

            return flag;
        }


        /// <summary>
        /// 检测用户的支付码是否正确
        /// </summary>
        /// <param name="name">用户名</param>
        /// <param name="code">支付码</param>
        /// <returns>支付码正确返回 true，否则返回 false</returns>
        public bool isCodeRight(string name,string code)
        {
            bool flag = false;

            string sql = "select success_code from tb_user where name='" + name + "'";
            DataTable table = new DBOperateCommon().excuteQuery(sql);
            if (table.Rows.Count > 0)
            {
                if(table.Rows[0][0].ToString().Equals(code))
                {
                    flag = true;
                }
            }

            return flag;

        }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="name">用户名</param>
        /// <returns>删除成功返回True，否则返回 False</returns>
        public bool deleteUser(string name)
        {
            bool flag = false;
            string sql = "delete from tb_user where name='" + name + "'";

            if (new DBOperateCommon().excuteNoQuery(sql) == true)
            {
                flag = true;
            }
            return flag;
        }

        /// <summary>
        /// 更新会员表
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool updateUser(User user) 
        {
            bool flag = false;

            string sql = "update tb_user set website='" + user.Website + "',companyName ='" + user.CompanyName +
                   "',telephone='" + user.Telephone + "' where name='" + user.Name + "'";

            if(new DBOperateCommon().excuteNoQuery(sql))
                flag = true;

            return flag;
        }
    }
}