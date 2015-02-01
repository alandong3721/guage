using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WM_Project.MasterPage.reception_stage
{
    
    public partial class batch : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["name"] != null)
            {
                lb_user_name.Text = Session["name"].ToString() + ",欢迎您！";
            }
           
        }

        protected void btn_safe_exit_Click(object sender, EventArgs e)
        {
            lb_user_name.Text = "";
            Session["name"] = null;
            Response.Redirect("~/index.aspx");
        }
    }
}