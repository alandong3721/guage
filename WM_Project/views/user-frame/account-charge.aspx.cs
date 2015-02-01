using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WM_Project.views.user_frame
{
    public partial class account_charge : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["name"] == null)
                {
                    Response.Redirect("exception/error-page.aspx");
                }
                else 
                {
                    charge_account.Text = Session["name"].ToString();
                }
            }
        }


        protected void btn_charge_now_Click(object sender, EventArgs e)
        {

            float money = Convert.ToSingle(Request.Form["charge_amount"].Trim());

            //跳转到支付页面
            Session["charge_money"] = money;
            Response.Redirect("select-charge-way.aspx");
            //Response.Write("<script language='Javascript'>parent.location='../select-charge-way.aspx'</script>");

        }
    }
}