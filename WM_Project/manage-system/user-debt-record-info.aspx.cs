using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using WM_Project.control;

namespace WM_Project.manage_system
{
    public partial class user_debt_record_info : System.Web.UI.Page
    {
        public static string username = "";
        public static ArrayList userdebt_array = new ArrayList();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                username = Request.QueryString["username"];

                if (username == null)
                {
                    Response.Redirect("error-page.aspx");
                }
                else
                {
                    userdebt_array = new UserDebtTransDAO().getUserDebtTransInfo(username);

                }
            }
        }
    }
}