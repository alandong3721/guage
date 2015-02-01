using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using WM_Project.control;

namespace WM_Project.views.user_frame
{
    public partial class repeat_pay : System.Web.UI.Page
    {
        public static string name = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string backname = Request.QueryString["username"];
                string code = Request.QueryString["code"];
                

                if (backname != null&&code!=null)
                {
                    name = backname;

                    if (new UserDAO().isCodeRight(name,code))
                    {
                        Session["name"] = name;
                        
                    }
                    else
                    {
                        Response.Redirect("../error-page.aspx");
                    }
                    
                }
                else
                {
                    Response.Redirect("../error-page.aspx");
                }
            }
        }
    }
}