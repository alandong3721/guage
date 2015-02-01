using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using WM_Project.control;

namespace WM_Project.views
{
    public partial class my_goods : System.Web.UI.Page
    {
        public static string user;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["name"] == null)
                {
                    page_one.Visible = true;
                    alert("请先登录!");
                }
                else
                {
                    page_two.Visible = true;
                }
            }
            
        }
        
        /// <summary>
        /// 登陆按钮的实现
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_login_Click(object sender, EventArgs e)
        {
            string name = Request.Form["txt_username"];
            string password = Request.Form["txt_password"];
            string code = Request.Form["txt_code"].ToLower();

            string session_code = Session["code"].ToString().ToLower();

            //身份验证
            if (code.Equals(session_code))
            {
                int flag = new UserDAO().checkUser(name, password);

                //身份验证通过
                if (flag == 1)
                {
                    page_one.Visible = false;
                    Session["name"] = name;
                    user = name;
                    Response.Redirect("my-goods.aspx");
                }
                else if (flag == 0)
                {
                    alert("密码错误！");
                }
                else if (flag == -1)
                {
                    alert("用户名不存在！");
                }
            }
            else
            {
                alert("验证码错误！");
            }
        }

        /// <summary>
        /// 弹出提示信息
        /// </summary>
        /// <param name="message">所要弹出的信息</param>
        private void alert(string message)
        {
            Response.Write(string.Format("<script language='javascript'>alert('{0}');</script>", message));
        }
    }
}