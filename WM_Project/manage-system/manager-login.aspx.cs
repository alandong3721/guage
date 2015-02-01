using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WM_Project.control;

using System.IO;


namespace WM_Project.manage_system
{
    public partial class manager_login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //登陆按钮的实现
        protected void btn_login_Click(object sender, EventArgs e)
        {

            string name = Request.Form["txt_username"];
            string password = Request.Form["txt_password"];
            string type = Request.Form["type"];

            //身份验证

            int flag = new StaffDAO().checkStaff(name, password, type);

            //身份验证通过
            if (flag == 1)
            {
                //通过身份验证
                if (type == "admin")
                {
                    Session["admin"] = name;
                    Response.Redirect("super-admin-home.aspx");
                }
                else if(type=="manager")
                {
                    Session["manager"] = name;
                    Response.Redirect("manager-home.aspx");
                }
                else if(type=="staff")
                {
                    Session["staff"] = name;
                    Response.Redirect("staff-home.aspx");
                }

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

        //弹出提示信息框
        private void alert(string message)
        {
            Response.Write(string.Format("<script language='javascript'>alert('{0}');</script>", message));
        }
    }
}