using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WM_Project.views
{
    public partial class contact_us : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //提交留言信息的实现
        protected void btn_submit_Click(object sender, EventArgs e)
        {
            string name = Request.Form["name"];
            string telephone = Request.Form["telephone"];
            string e_mail = Request.Form["e_mail"];
            string detail_info = Request.Form["detail_info"];

            alert("留言成功，我们将尽快回复您！");

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