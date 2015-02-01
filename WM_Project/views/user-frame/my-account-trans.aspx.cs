using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using WM_Project.control;

namespace WM_Project.views.user_frame
{
    public partial class my_account_trans : System.Web.UI.Page
    {

        public static ArrayList transarray = new ArrayList();
        public static int record_count = 0;
        public static int pageSize = 20;
        public static int page_count = 0;
        public static int pageNow = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                if (Session["name"] == null)
                {
                    Response.Redirect("../error-page.aspx");
                }
                else
                {
                    string page = Request.QueryString["pageNow"];

                    if (page != null)
                    {
                        pageNow = Convert.ToInt32(page);
                        transarray = new MyAccountTransDAO().getMyAccountTrans(pageNow, pageSize, Session["name"].ToString());
                    }
                    else
                    {
                        pageNow = 1;
                        record_count = new MyAccountTransDAO().getMyAccountTransCount(Session["name"].ToString());
                        page_count = new MyAccountTransDAO().getPageCount(record_count, pageSize);
                        transarray = new MyAccountTransDAO().getMyAccountTrans(pageNow, pageSize, Session["name"].ToString());
                    }
                   
                }
                
            }
        }
    }
}