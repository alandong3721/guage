using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WM_Project.manage_system
{
    public partial class manager_account_management : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["manager"] == null)
                {
                    Response.Redirect("error-page.aspx");
                }
            }
        }
    }
}