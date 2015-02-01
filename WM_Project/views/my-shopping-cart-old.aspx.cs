using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WM_Project.control;
using System.Collections;
using WM_Project.logical.common;

namespace WM_Project.views
{
    public partial class my_shopping_cart_old : System.Web.UI.Page
    {
        public DataTable table_source = new DataTable();
        public static ArrayList pay_orders = new ArrayList();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                if (Session["name"] == null)
                {
                    Response.Redirect("user-login.aspx");
                }
                else
                {
                    initMyCart();
                }
               
            }
                
            

        }


        /// <summary>
        /// 购物车中的响应事件
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        protected void my_cart_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName.Equals("delete"))
            {
                //删除未付款的订单
                string order_no = e.CommandArgument.ToString();
                new OrderDAO().deleteUnPayOrder(order_no);

                initMyCart();

            }
            else if (e.CommandName.Equals("detail"))
            {
                string order_no = e.CommandArgument.ToString();
                Response.Redirect("my-order-detail-info.aspx?status=unpay&order_number=" + order_no);
            }

        }
        //CheckBox的响应事件
        protected void checkbox_CheckChanged(object sender, EventArgs e)
        {
            float total = 0;

            for (int i = 0; i < my_cart.Items.Count; i++)
            {
                CheckBox check = (CheckBox)my_cart.Items[i].FindControl("checkbox");

                if (check.Checked == true)
                {
                    Label label = (Label)my_cart.Items[i].FindControl("item_money");
                    total += Convert.ToSingle(label.Text.ToString());
                }
                else
                {
                    select_all.Checked = false;
                }
            }

            if (total == 0)
            {
                btn_pay.Enabled = false;
            }
            else
            {
                btn_pay.Enabled = true;
            }

            lb_money.Text = total.ToString();

        }


        //选中所有CheckBox
        protected void checked_All(object sender, EventArgs e)
        {
            CheckBox check = (CheckBox)sender;

            float total = 0;


            for (int i = 0; i < my_cart.Items.Count; i++)
            {
                CheckBox temp_check = (CheckBox)my_cart.Items[i].FindControl("checkbox");
                temp_check.Checked = check.Checked;
                if (check.Checked == true)
                {
                    Label label = (Label)my_cart.Items[i].FindControl("item_money");
                    total += Convert.ToSingle(label.Text.ToString());
                }
            }

            if (total == 0)
            {
                btn_pay.Enabled = false;
            }
            else
            {
                btn_pay.Enabled = true;
            }

            lb_money.Text = total.ToString();
        }

        //初始化购物车信息
        protected void initMyCart()
        {
            table_source = createMyCartTable();

            my_cart.DataSource = table_source;
            my_cart.DataBind();

            float pay = 0;

            for (int i = 0; i < my_cart.Items.Count; i++)
            {
                pay += Convert.ToSingle(table_source.Rows[i]["pay"].ToString());
            }

            if (pay == 0)
            {
                btn_pay.Enabled = false;
            }
            else
            {
                btn_pay.Enabled = true;
            }

            lb_money.Text = pay.ToString();

            initNoticeInfo(my_cart, "delete");
        }


        /// <summary>
        /// 初始化DataList删除时弹出确认框
        /// </summary>
        /// <param name="datalist"></param>
        /// <param name="control_id"></param>
        private void initNoticeInfo(DataList datalist, string control_id)
        {
            foreach (DataListItem item in datalist.Items)
            {
                ((ImageButton)item.FindControl(control_id)).Attributes["OnClick"] = "return confirm('您确定删除吗？')";
            }
        }


        private DataTable createMyCartTable()
        {
            DataTable table = new DataTable();

            //订单号
            DataColumn dc = new DataColumn("order_number", typeof(string));
            table.Columns.Add(dc);

            //重量
            dc = new DataColumn("quantity", typeof(int));
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

            ArrayList orders = new OrderDAO().getOrders(Session["name"].ToString(), "failed");
            
            for (int i = 0; i < orders.Count; i++)
            {
                Order order = (Order)orders[i];

                DataRow dr = table.NewRow();

                dr["order_number"] = order.Order_number;
                dr["quantity"] = order.Quantity;
                dr["sender"] = order.CollectionContactName;
                dr["receiver"] = order.RecipientContactName;
                dr["postway"] = order.Post_way;
                dr["pay"] = new PackageDAO().getSumMoney(order.Order_number);
                dr["time"] = order.Order_time.ToString("yy-MM-dd hh:mm");

                table.Rows.Add(dr);
            }


            return table;
        }



        protected void btn_pay_Click(object sender, EventArgs e)
        {
            pay_orders = new ArrayList();

            for (int i = 0; i < my_cart.Items.Count; i++)
            {
                CheckBox check = (CheckBox)my_cart.Items[i].FindControl("checkbox");

                if (check.Checked == true)
                {
                    HiddenField hidden = (HiddenField)my_cart.Items[i].FindControl("hidden");
                    string order = hidden.Value.ToString();
                    pay_orders.Add(order);

                }
            }
            
            Response.Redirect("../views/order-pay.aspx");
        }


        //输入打折码后的确定事件
        protected void btn_confirm_Click(object sender, EventArgs e)
        {
            lb_money_discount.Text = "<font color='#3A83C2'>折扣 £ -20.0 </font>";
            lb_money_after_discount.Text = "<font>您还需付款 £ 660.0</font>";
        }

    }
}