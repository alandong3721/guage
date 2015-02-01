using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using WM_Project.control;

namespace WM_Project.manage_system.frame
{
    public partial class check_interface_order_by_time : System.Web.UI.Page
    {
        public ArrayList orders = new ArrayList();
        public string message = "";

        //分页所用变量
        public int pageNow = 0;   //当前页
        public int record_count = 0;  //记录总条数
        public int page_count = 0;    //总页数
        public int pageSize = 20;

        public string start_time = "";
        public string end_time = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["admin"] = "admin";

                if (Session["admin"] == null && Session["manager"] == null && Session["staff"] == null)
                {
                    Response.Redirect("../error-page.aspx");
                }
                else
                {
                    string page = Request.QueryString["pageNow"];

                    if (page == null)
                    {
                        pageNow = 1;
                        record_count = 0;
                        page_count = 0;

                        string start = DateTime.Now.ToString("yyyy-MM-dd");
                        string end = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd");

                        // 界面下单
                        orders = new OrderDAO().getOrderByTime(start, end, "paied", pageNow, pageSize);

                        if (!(orders.Count > 0))
                        {
                            message = "今天到目前为止还没有人下单！！";
                        }
                        else
                        {
                            notice.Visible = true;
                        }
                    }
                    else
                    {
                        pageNow = Convert.ToInt32(page);

                        if (Session["start"] == null)
                        {
                            pageNow = Convert.ToInt32(page);
                            record_count = new OrderDAO().getRecordCount("paied");
                            page_count = new OrderDAO().getPageCount(record_count, pageSize);
                            orders = new OrderDAO().getOrders("paied", pageSize, pageNow);
                        }
                        else if (Session["start"] != null)
                        {
                            start_time = txt_from.Text = Session["start"].ToString();
                            end_time = txt_to.Text = Session["end"].ToString();

                            pageNow = Convert.ToInt32(page);
                            record_count = new OrderDAO().getRecordCount(start_time, end_time, "paied");
                            page_count = new OrderDAO().getPageCount(record_count, pageSize);
                            orders = new OrderDAO().getOrderByTime(start_time, end_time, "paied", pageNow, pageSize);
                        }

                    }
                }

            }
        }

        protected void btn_query_Click(object sender, EventArgs e)
        {
            start_time = txt_from.Text.ToString();
            end_time = txt_to.Text.ToString();

            int i = end_time.CompareTo(start_time);

            if (start_time == "" || end_time == "")
            {
                alert("请选择所查询的时间段");
                return;
            }
            else if (end_time.CompareTo(start_time) != 1)
            {
                alert("起始时间不能大于等于终止时间!!");
                return;
            }
            else
            {
                Session["start"] = start_time;
                Session["end"] = end_time;

                pageNow = 1;
                record_count = new OrderDAO().getRecordCount(start_time, end_time, "paied");
                page_count = new OrderDAO().getPageCount(record_count, pageSize);
                orders = new OrderDAO().getOrderByTime(start_time, end_time, "paied", pageNow, pageSize);

                if (!(orders.Count > 0))
                {
                    message = "该查询时间段内没人下单";
                }

            }
        }

        protected void btn_query_all_Click(object sender, EventArgs e)
        {
            txt_from.Text = start_time = "";
            txt_to.Text = end_time = "";

            Session["start"] = null;
            Session["end"] = null;

            pageNow = 1;
            record_count = new OrderDAO().getRecordCount("paied");
            page_count = new OrderDAO().getPageCount(record_count, pageSize);
            orders = new OrderDAO().getOrders("paied", pageSize, pageNow);

            if (!(orders.Count > 0))
            {
                message = "到目前为止还没有人下单！！";
            }
        }

        //弹出提示信息
        private void alert(string message)
        {
            Response.Write(string.Format("<script>alert('{0}')</script>", message));

        }
    }
}