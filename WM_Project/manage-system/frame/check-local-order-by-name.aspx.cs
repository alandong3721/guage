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
    public partial class check_local_order_by_name : System.Web.UI.Page
    {
        public  ArrayList orders = new ArrayList();
        public  string message = "";

        //分页所用变量
        public  int pageNow = 0;   //当前页
        public  int record_count = 0;  //记录总条数
        public  int page_count = 0;    //总页数
        public  int pageSize = 20;

        public static string name = "";


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["admin"] == null && Session["staff"] == null && Session["manager"] == null)
                {
                    Response.Redirect("../error-page.aspx");
                }
                else
                {
                    string page = Request.QueryString["pageNow"];
                    message = "";

                    if (page != null)
                    {
                        pageNow = Convert.ToInt32(page);
                        record_count = new AutoOrderDAO().getAUtoOrdersCount(name, "paied");

                        page_count = new AutoOrderDAO().getPageCount(record_count, pageSize);
                        orders = new AutoOrderDAO().getOrdersArray(name, "paied", pageNow, pageSize);

                    }

                }



            }
        }


        /// <summary>
        /// 按用户名查找订单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_query_order_Click(object sender, EventArgs e)
        {

            string name = txt_name.Text;
            pageNow = 1;
            record_count = new AutoOrderDAO().getAUtoOrdersCount(name, "paied");

            page_count = new AutoOrderDAO().getPageCount(record_count, pageSize);

            orders = new AutoOrderDAO().getOrdersArray(name, "paied", pageNow, pageSize);

            if (!(orders.Count > 0))
            {
                message = name + ",没下过单！";
            }


        }


        //弹出提示信息
        private void alert(string message)
        {
            Response.Write(string.Format("<script>alert('{0}')</script>", message));

        }
    }
}