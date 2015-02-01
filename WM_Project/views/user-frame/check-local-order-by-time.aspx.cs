using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using WM_Project.control;

namespace WM_Project.views.user_frame
{
    public partial class check_local_order_by_time : System.Web.UI.Page
    {
        public string start_time = "";
        public string end_time = "";
        public int page_now = 1;
        public int page_size = 20;
        public int page_count = 0;
        public int record_count = 0;

        public ArrayList local_array = new ArrayList();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }


        /// <summary>
        /// 按时间查看本地订单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_query_Click(object sender, EventArgs e)
        {
            start_time = txt_from.Text.ToString();
            end_time = txt_to.Text.ToString();
            Session["name"] = "yangwang";

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
                page_now = 1;
                record_count = new LocalOrderDAO().getLocalCountByTime(Session["name"].ToString(), start_time, end_time);
                page_count = new LocalOrderDAO().getLocalOrderPageCount(record_count, page_size);
                local_array = new LocalOrderDAO().getLocalArrayListByTime( Session["name"].ToString(),start_time, end_time, page_now, page_size);
                my_local_datalist.DataSource = createTable(local_array);
                my_local_datalist.DataBind();
            }
        }


        /// <summary>
        /// 查询所有的本地订单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_query_all_Click(object sender, EventArgs e)
        {

        }


        private DataTable createTable(ArrayList array)
        {

            DataTable table = new DataTable();

            //订单号
            DataColumn dc = new DataColumn("order_number", typeof(string));
            table.Columns.Add(dc);

            //包裹个数
            dc = new DataColumn("quantity", typeof(float));
            table.Columns.Add(dc);

            //包裹个数
            dc = new DataColumn("weight", typeof(float));
            table.Columns.Add(dc);

            //发件人
            dc = new DataColumn("sender", typeof(string));
            table.Columns.Add(dc);

            //收件人
            dc = new DataColumn("receiver", typeof(string));
            table.Columns.Add(dc);

            //服务方式
            dc = new DataColumn("postway", typeof(string));
            table.Columns.Add(dc);

            //付款金额
            dc = new DataColumn("pay", typeof(string));
            table.Columns.Add(dc);

            //下单时间
            dc = new DataColumn("time", typeof(string));
            table.Columns.Add(dc);

            ArrayList local_order_array = new LocalOrderDAO().getPayLocalOrder(Session["name"].ToString());

            for (int i = 0; i < local_order_array.Count; i++)
            {
                LocalOrder local_order = (LocalOrder)local_order_array[i];

                DataRow dr = table.NewRow();
                dr["order_number"] = local_order.Order_no;
                dr["sender"] = local_order.Collectioncontactname;
                dr["receiver"] = local_order.Recipientcontactname;
                dr["postway"] = local_order.Servicecode;
                dr["quantity"] = local_order.Quantity;
                dr["weight"] = local_order.Weight;
                dr["pay"] = local_order.Pay_after_discount;
                dr["time"] = local_order.Order_time;

                table.Rows.Add(dr);
            }



            return table;
        }



        /// <summary>
        /// 弹出提示信息
        /// </summary>
        /// <param name="message"></param>
        private void alert(string message)
        {
            Response.Write(string.Format("<script language='javascript'>alert('{0}');</script>", message));
        }

        protected void my_cart_ItemCommand(object source, DataListCommandEventArgs e)
        {

        }
    }
}