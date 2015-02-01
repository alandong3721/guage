using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using WM_Project.control;

namespace WM_Project.views
{
    public partial class user_login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //登陆按钮的实现
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
                    //通过身份验证
                    Session["name"] = name;
                    if (Session["package_array"] == null)
                    {
                        Response.Redirect("../views/index.aspx");
                    }
                    else
                    {
                        Response.Redirect("../views/index.aspx?step=2");
                    }
                }
                else if(flag == 0)
                {
                    alert("密码错误！");
                }
                else if(flag == -1)
                {
                    alert("用户名不存在！");
                }
            }
            else
            {
                alert("验证码错误！");
            }
        }

        //弹出提示信息框
        private void alert(string message)
        {
            Response.Write(string.Format("<script language='javascript'>alert('{0}');</script>", message));
        }
    }
}