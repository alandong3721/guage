using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using WM_Project.control;
using WM_Project.logical.common;
using WM_Project.logical.user;


namespace WM_Project.manage_system.super_admin_frame
{
    public partial class charge_for_user : System.Web.UI.Page
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

        /// <summary>
        /// 确认充值的具体实现
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_affirm_charge_Click(object sender, EventArgs e)
        {
            string account = Request.Form["charge_account"];
            string money = Request.Form["charge_money"];

            User user = new UserDAO().getUser(account);

            if (user != null)
            {
                if (new MyAccountDAO().chargeForUser(account, Convert.ToSingle(money)))
                {

                    alert("充值成功！！");
                }
                else
                {
                    alert("充值失败，请稍后重试!!");
                }
            }
            else
            {
                alert("该账户不存在，请确认后再充值！！");
            }


        }

        //弹出提示信息框
        private void alert(string message)
        {
            Response.Write(string.Format("<script language='javascript'>alert('{0}');</script>", message));
        }
    }
}