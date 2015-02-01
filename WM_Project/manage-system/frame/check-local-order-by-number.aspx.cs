using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using WM_Project.control;
using WM_Project.logical.common;

namespace WM_Project.manage_system.frame
{
    public partial class check_local_order_by_number : System.Web.UI.Page
    {
        public  ArrayList packages = new ArrayList();


        //分页所用变量
        public  int pageNow = 1;   //当前页
        public  int record_count = 0;  //记录总条数
        public  int page_count = 0;    //总页数
        public  int pageSize = 20;
        public  string message = "";

        public static string auto_no = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["staff"] == null && Session["admin"] == null && Session["manager"] == null)
                {
                    Response.Redirect("../error-page.aspx");
                }
                else
                {

                    string page = Request.QueryString["pageNow"];

                    if (page != null)
                    {
                        pageNow = Convert.ToInt32(page);
                        record_count = new AutoOrderListDAO().getRecordCount(auto_no);
                        page_count = new AutoOrderListDAO().getPageCount(record_count, pageSize);
                        packages = new AutoOrderListDAO().getAutoOrderListArray(auto_no, pageNow, pageSize);
                    }
                    else
                    {
                        packages.Clear();
                        auto_no = "";
                    }

                }

            }
        }

        /// <summary>
        /// 弹出提示信息
        /// </summary>
        /// <param name="message">提示信息</param>
        private void alert(string message)
        {
            Response.Write(string.Format("<script language='javascript'>alert('{0}');</script>", message));
        }



        /// <summary>
        /// 根据订单号查找订单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_query_order_Click(object sender, EventArgs e)
        {
            auto_no = txt_number.Text;

            if (auto_no.Contains("AU"))
            {
                pageNow = 1;
                record_count = new AutoOrderListDAO().getRecordCount(auto_no);
                page_count = new AutoOrderListDAO().getPageCount(record_count, pageSize);
                packages = new AutoOrderListDAO().getAutoOrderListArray(auto_no, pageNow, pageSize);
            }
            else if (auto_no.Contains("WP"))
            {
                packages.Clear();

                pageNow = 1;
                record_count = 1;
                page_count = 1;
                AutoOrderList orderlist = new AutoOrderListDAO().getAutoOrderList(auto_no);
                packages.Add(orderlist);
            }
            else
            {
                alert("订单号有误!!");
            }

        }
    }
}