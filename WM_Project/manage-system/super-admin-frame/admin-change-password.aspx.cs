using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using WM_Project.control;

namespace WM_Project.manage_system.super_admin_frame
{
    public partial class admin_change_password : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["admin"] == null)
                {
                    Response.Redirect("../error-page.aspx");
                }
            }
        }

        protected void btn_change_pwd_Click(object sender, EventArgs e)
        {
            string oldpwd = Request.Form["oldpwd"];
            string newpwd = Request.Form["newpwd"];
            string name = Session["admin"].ToString();

            string str = "select password from tb_staff where name='" + name + "'";
            DataTable table = new DBOperateCommon().excuteQuery(str);

            if (table.Rows[0]["password"].ToString().Equals(oldpwd))
            {
                string update = "update tb_staff set password='" + newpwd + "' where name='" + name + "' and type=1";

                if (new DBOperateCommon().excuteNoQuery(update))
                {
                    alert("修改成功！！");
                }
                else
                {
                    alert("修改失败！！");
                }
            }
            else
            {
                alert("旧密码错误！！");
            }


        }

        //弹出提示信息
        private void alert(string message)
        {
            Response.Write(string.Format("<script>alert('{0}')</script>", message));

        }
    }
}