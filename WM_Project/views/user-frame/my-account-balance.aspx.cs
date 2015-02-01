using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using WM_Project.control;
using WM_Project.logical.user;


namespace WM_Project.views.user_frame
{
    public partial class my_account_balance : System.Web.UI.Page
    {
        public static MyAccount myaccount = new MyAccount();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["name"] = "yangwang";

                if (Session["name"] == null)
                {
                    Response.Redirect("../error-page.aspx");
                }
                else
                {
                    MyAccount temp = new MyAccountDAO().getMyAccount(Session["name"].ToString());
                    if (temp == null)
                    {
                        myaccount.Balance = 0;
                        myaccount.Name = Session["name"].ToString();
                    }
                    else
                    {
                        myaccount = temp;
                    }
                }

            }
        }
    }
}