using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using WM_Project.control;

namespace WM_Project.manage_system.super_admin_frame
{
    public partial class check_debt_user : System.Web.UI.Page
    {

        //欠债用户的分页实现
        public static ArrayList userdebts = new ArrayList();
        public static int pageNow = 1;
        public static int pageSize = 20;
        public static int debt_count = 0;
        public static int debt_page_count = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["admin"] == null&&Session["manager"]==null&&Session["staff"]==null)
                {
                    Response.Redirect("../error-page.aspx");
                }
                else
                {
                    string page = Request.QueryString["pageNow"];

                    if (page == null)
                    {
                        pageNow = 1;
                        debt_count = new UserDebtDAO().getUserDebtCount();
                        debt_page_count = new UserDebtDAO().getPageCount(debt_count, pageSize);
                        userdebts = new UserDebtDAO().getUserDebts(pageNow, pageSize);
                    }
                    else
                    {
                        pageNow = Convert.ToInt32(page);
                        debt_count = new UserDebtDAO().getUserDebtCount();
                        debt_page_count = new UserDebtDAO().getPageCount(debt_count, pageSize);
                        userdebts = new UserDebtDAO().getUserDebts(pageNow, pageSize);
                    }

                }
            }
        }
    }
}