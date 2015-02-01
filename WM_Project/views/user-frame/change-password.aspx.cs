using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using WM_Project.control;
using WM_Project.logical.user;

namespace WM_Project.views.user_frame
{
    public partial class change_password : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["name"] == null)
                {
                    Response.Redirect("../error-page.aspx");
                }
                
            }
            
        }

        protected void btn_change_pwd_Click(object sender, EventArgs e)
        {
            string name = Session["name"].ToString();
            string oldpwd = Request.Form["oldpwd"];
            string newpwd = Request.Form["newpwd"];

            if (new UserDAO().checkUser(name, oldpwd) == 1)
            {
                if (new UserDAO().resetPassword(name, newpwd))
                {
                    alert("修改成功!!");
                }
            }
            else
            {
                alert("旧密码错误！！");
            }
        }

        /// <summary>
        /// 弹出提示信息框
        /// </summary>
        /// <param name="message"></param>
        private void alert(string message)
        {
            Response.Redirect(string.Format("<script language='javascript'>alert('{0}');<script>", message));
        }
    }
}