using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using WM_Project.control;

namespace PostNL.views
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
                string type = Request.QueryString["type"];

                if (backname != null&&code!=null&&type!=null)
                {
                    name = backname;

                    if (new UserDAO().isCodeRight(name,code))
                    {
                        Session["name"] = name;
                        if (type == "internatioin")
                        {
                            international_order.Visible = true;
                        }
                        else if(type=="local")
                        {
                            local_order.Visible = true;
                        }
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
    }
}