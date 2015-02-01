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
    public partial class charge_repay_record : System.Web.UI.Page
    {
        //充值还款记录分页实现
        public static ArrayList chargerecords = new ArrayList();
        public static int pageNow = 0;
        public static int pageSize = 20;
        public static int record_count = 0;
        public static int record_page_count = 0;

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
                        record_count = new UserDebtTransDAO().getRecordCount();
                        record_page_count = new UserDebtTransDAO().getPageCount(pageSize, record_count);
                        chargerecords = new UserDebtTransDAO().getChargeRecords(pageNow, pageSize);
                    }
                    else
                    {
                        pageNow = Convert.ToInt32(page);
                        chargerecords = new UserDebtTransDAO().getChargeRecords(pageNow, pageSize);
                    }
                }
                
            }
        }
    }
}