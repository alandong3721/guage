using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


using WM_Project.logical.common;
using WM_Project.logical.user;
using WM_Project.control;

namespace WM_Project.views.user_frame
{
    public partial class pay_by_wm_account : System.Web.UI.Page
    {
        public  float money = 0;
        public  string name = "";
        public  MyAccount myaccount = new MyAccount();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["name"] == null || Session["money_pay"] == null)
            {
                Response.Redirect("error-page.aspx");
            }
            else
            {
                name = Session["name"].ToString();
                money = Convert.ToSingle(Session["money_pay"].ToString());
                myaccount = new MyAccountDAO().getMyAccount(name);
               
                if (myaccount == null)
                {
                    Response.Redirect("error-page.aspx");
                }
                else if (myaccount.Balance < money)
                {
                    Response.Redirect("error-page.aspx");
                }
                else
                {

                    if (Session["success_code"] == null)
                    {
                        Response.Redirect("error-page.aspx");
                    }
                }
            }

        }


        //确认支付
        protected void btn_pay_Click(object sender, EventArgs e)
        {
            float money_pay = Convert.ToSingle(Session["money_pay"].ToString());
            name = Session["name"].ToString();
            string code = Session["success_code"].ToString();
            //更新我的账户表

            if (new MyAccountDAO().userPayUseMyAccount(name, money))
            {
                User user = new UserDAO().getUser(name);
             
                Response.Redirect("pay-success.aspx?username=" + name + "&code=" + code + "&paymethod=my-account");
            }
            else
            {
                Response.Redirect("repeat-pay.aspx?username=" + name+"&code="+code);
            }

        }
    }
}