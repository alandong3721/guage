using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WM_Project.control;
using WM_Project.logical.user;
using System.Collections;

namespace WM_Project.manage_system.super_admin_frame
{
    public partial class user_account_trans_info : System.Web.UI.Page
    {
        public MyAccount myaccount = new MyAccount();

        public ArrayList transarray = new ArrayList();
        public int record_count = 0;
        public int pageSize = 20;
        public int page_count = 0;
        public int pageNow = 0;
        public string name = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["admin"] == null)
                {
                    Response.Redirect("../error-page.aspx");
                }
                else
                {
                    name = Request.QueryString["name"];
                    string page = Request.QueryString["pageNow"];
                    if (page != null && name != null)
                    {
                        pageNow = Convert.ToInt32(page);
                        record_count = new MyAccountTransDAO().getMyAccountTransCount(name);
                        page_count = new MyAccountTransDAO().getPageCount(record_count, pageSize);
                        transarray = new MyAccountTransDAO().getMyAccountTrans(pageNow, pageSize, name);
                    }
                    else if (name != null)
                    {
                        pageNow = 1;
                        record_count = new MyAccountTransDAO().getMyAccountTransCount(name);
                        page_count = new MyAccountTransDAO().getPageCount(record_count, pageSize);
                        transarray = new MyAccountTransDAO().getMyAccountTrans(pageNow, pageSize, name);
                    }
                }

            }
        }
    }
}