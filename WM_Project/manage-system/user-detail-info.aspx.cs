using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using WM_Project.logical.user;
using WM_Project.control;

namespace WM_Project.manage_system
{
    public partial class user_detail_info : System.Web.UI.Page
    {
        public static User user = new User();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string name = Request.QueryString["username"];
                if (name == null)
                {
                    Response.Redirect("error-page.aspx");
                }
                else
                {
                    user = new UserDAO().getUser(name);
                }
            }
            
        }
    }
}