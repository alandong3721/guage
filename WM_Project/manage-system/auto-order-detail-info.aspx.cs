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
    public partial class auto_order_detail_info : System.Web.UI.Page
    {

        public static ArrayList packages = new ArrayList();


        //分页所用变量
        public static int pageNow = 1;   //当前页
        public static int record_count = 0;  //记录总条数
        public static int page_count = 0;    //总页数
        public static int pageSize = 20;
        public static string message = "";

        public static string auto_no = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["staff"] == null && Session["admin"] == null&&Session["manager"]==null)
                {
                    Response.Redirect("error-page.aspx");
                }
                else
                {
                    auto_no = Request.QueryString["auto_no"];
                    string page = Request.QueryString["pageNow"];

                    if (auto_no != null && page == null)
                    {

                        pageNow = 1;
                        record_count = new AutoOrderListDAO().getRecordCount(auto_no);
                        page_count = new AutoOrderListDAO().getPageCount(record_count, pageSize);
                        packages = new AutoOrderListDAO().getAutoOrderListArray(auto_no, pageNow, pageSize);
                    }
                    else if (auto_no != null && page != null)
                    {
                        pageNow = Convert.ToInt32(page);
                        packages = new AutoOrderListDAO().getAutoOrderListArray(auto_no, pageNow, pageSize);
                    }
                    else
                    {
                        Response.Redirect("error-page.aspx");
                    }
                
                }
                

            }
        }

       
    }
}