using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using WM_Project.control;

namespace WM_Project.MasterPage.back_stage
{
    public partial class home : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        /// <summary>
        /// 快件查询的实现
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void img_btn_track_Click(object sender, ImageClickEventArgs e)
        {
            string track_no = Request.Form["txt_fast_track_no"];

            Response.Redirect("~/views/order-tracking.aspx?step=2&track="+track_no);

        }

        //弹出提示信息
        private void alert(string message)
        {
            Response.Write(string.Format("<script language='javascript'>alert('{0}');</script>", message));
        }

    }
}