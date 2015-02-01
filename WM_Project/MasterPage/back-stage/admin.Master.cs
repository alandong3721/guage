using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WM_Project.MasterPage.back_stage
{
    public partial class admin : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if(Session["admin"]!=null)
                {
                    lb_user_name.Text = Session["admin"].ToString() + ",欢迎您！";
                }
            }

        }

        //安全退出
        protected void btn_exit_safe_Click(object sender, EventArgs e)
        {

            Session["admin"] = null;
            lb_user_name.Text = "";
            Response.Redirect("~/manage-system/manager-login.aspx");

        }
    }
}