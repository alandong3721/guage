using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WM_Project.MasterPage.reception_stage
{
    public partial class home_old : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["name"] != null)
            {
                lb_user_name.Text = Session["name"].ToString() + ",欢迎您！";
                after_login.Visible = true;
                before_login.Visible = false;
            }
            else
            {
                before_login.Visible = true;
                after_login.Visible = false;
            }
        }

        /// <summary>
        /// 快件查询的实现
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void img_btn_track_Click(object sender, ImageClickEventArgs e)
        {
            string track_no = Request.Form["txt_fast_track_no"];

            Response.Redirect("~/views/order-tracking.aspx?step=2&track=" + track_no);

        }

        //弹出提示信息
        private void alert(string message)
        {
            Response.Write(string.Format("<script language='javascript'>alert('{0}');</script>", message));
        }

        protected void exit_security_Click(object sender, EventArgs e)
        {
            Session["name"] = null;
            lb_user_name.Text = "";
            before_login.Visible = true;
            after_login.Visible = false;
        }

        protected void btn_safe_exit_Click(object sender, EventArgs e)
        {
            lb_user_name.Text = "";
            Session["name"] = null;
            Response.Redirect("~/index.aspx");
        }
    }
}