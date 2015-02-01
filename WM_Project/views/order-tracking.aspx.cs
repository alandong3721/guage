using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WM_Project.views
{
    public partial class order_tracking : System.Web.UI.Page
    {
        public static string track_no;

        protected void Page_Load(object sender, EventArgs e)
        {
            string step = Request.QueryString["step"];
            
            track_no = Request.QueryString["track"];

            if (step == "2"&&track_no!=null)
            {
                page_two.Visible = true;
            }
            else
            {
                page_one.Visible = true;
            }
        }

        //订单追踪的实现
        protected void btn_track_Click(object sender, EventArgs e)
        {
            string track_no = Request.Form["txt_track_no"];
            Response.Redirect("order-tracking.aspx?step=2&track="+track_no);
        }
    }
}