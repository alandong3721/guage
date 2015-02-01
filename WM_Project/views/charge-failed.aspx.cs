using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using WM_Project.control;

namespace WM_Project.views
{
    public partial class charge_failed : System.Web.UI.Page
    {
        public static string username = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                username = Request.QueryString["username"];
                string code = Request.QueryString["code"];

                if (username != null && code != null)
                {

                    if (new UserDAO().isCodeRight(username, code))
                    {
                        Session["name"] = username;
                    }
                    else
                    {
                        Response.Redirect("error-page.aspx");
                    }

                }
                else
                {
                    Response.Redirect("error-page.aspx");
                }
            }

        }

        protected void btn_go_my_Click(object sender, EventArgs e)
        {
            Response.Redirect("my-account.aspx");
        }
    }
}