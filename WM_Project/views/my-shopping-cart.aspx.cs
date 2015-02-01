using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Collections;

using WM_Project.control;
using WM_Project.logical.common;

namespace WM_Project.views
{
    public partial class my_shopping_cart : System.Web.UI.Page
    {
        public DataTable table_source = new DataTable();
        public ArrayList pay_orders = new ArrayList();
        public  string first = "";

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                if (Session["name"] == null)
                {
                    shooping_cart_user_login_part.Visible = true;
                    shooping_cart_part.Visible = false;
                }
                else
                {
                    first = Request.QueryString["flag"];

                    if (first == null)
                    {
                        //如果 flag=null 则将界面下单显示在前
                        first = "interface";
                       
                    }
                    hidfiled_first.Value = first;
                    
                    initMyCart(first);
                    
                    
                }     
            }
        }


        /// <summary>
        /// 登陆的实现
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_login_Click(object sender, EventArgs e)
        {
            string name = Request.Form["txt_username"];
            string password = Request.Form["txt_password"];
            string code = Request.Form["txt_code"].ToLower();

            string session_code = Session["code"].ToString().ToLower();

            //身份验证
            if (code.Equals(session_code))
            {
                int flag = new UserDAO().checkUser(name, password);

                //身份验证通过
                if (flag == 1)
                {
                    //通过身份验证
                    Session["name"] = name;
                    
                    Response.Redirect("my-shopping-cart.aspx");
                    
                }
                else if (flag == 0)
                {
                    alert("密码错误！");
                }
                else if (flag == -1)
                {
                    alert("用户名不存在！");
                }
            }
            else
            {
                alert("验证码错误！");
            }
        }


        /// <summary>
        /// 购物车中的响应事件
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        protected void my_cart_ItemCommand(object source, DataListCommandEventArgs e)
        {
            first = hidfiled_first.Value;

            if (e.CommandName.Equals("delete"))
            {
                //删除未付款的订单
                string order_no = e.CommandArgument.ToString();

                if (order_no.Contains("WM"))
                {
                    new OrderDAO().deleteUnPayOrder(order_no);
                }
                else if(order_no.Contains("WA"))
                {
                    new AutoOrderListDAO().deleteAutoOrderList(order_no);
                }

                initMyCart(first);

            }
            else if (e.CommandName.Equals("detail"))
            {
                string order_no = e.CommandArgument.ToString();
                Response.Redirect("my-cart-order-detail-info.aspx?order_number=" + order_no+"&flag="+first);
            }

        }
       
        //选中所有CheckBox
        protected void checked_All(object sender, EventArgs e)
        {
            CheckBox check = (CheckBox)sender;

            float total = 0;


            for (int i = 0; i < my_cart_datalist.Items.Count; i++)
            {
                CheckBox temp_check = (CheckBox)my_cart_datalist.Items[i].FindControl("checkbox");
                temp_check.Checked = check.Checked;
                if (check.Checked == true)
                {
                    Label label = (Label)my_cart_datalist.Items[i].FindControl("item_money");
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
        protected void initMyCart(string flag)
        {
            table_source = createMyCartTable(flag);

            if (table_source.Rows.Count == 0)
            {
                cart_part.Visible = false;
                no_order.Visible = true;
            }
            else
            {
                my_cart_datalist.DataSource = table_source;
                my_cart_datalist.DataBind();

                float pay = 0;

                for (int i = 0; i < my_cart_datalist.Items.Count; i++)
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

                ArrayList auto_array = new AutoOrderDAO().getOrdersArray(Session["name"].ToString(), "unpay");
                

                lb_money.Text = pay.ToString();

                initNoticeInfo(my_cart_datalist, "delete");
            }

            
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


        private DataTable createMyCartTable(string flag)
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

            //收件人电话
            dc = new DataColumn("phone", typeof(string));
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

            if (flag == "excel")
            {
                ArrayList auto_orders = new AutoOrderListDAO().getAutoOrderListArray(Session["name"].ToString(), "unpay");

                for (int i = 0; i < auto_orders.Count; i++)
                {
                    AutoOrderList order = (AutoOrderList)auto_orders[i];

                    DataRow dr = table.NewRow();

                    dr["order_number"] = order.Order_no;
                    dr["quantity"] = 1;
                    dr["weight"] = order.Weight;
                    dr["sender"] = order.CollectionContactName;
                    dr["receiver"] = order.RecipientContactName;
                    dr["phone"] = order.RecipientPhone;
                    dr["postway"] = getPostWay(order.ServiceCode);
                    dr["pay"] = order.Pay_after_discount;
                    dr["time"] = order.Order_time;

                    table.Rows.Add(dr);
                }

                ArrayList orders = new OrderDAO().getOrders(Session["name"].ToString(), "unpay");

                for (int i = 0; i < orders.Count; i++)
                {
                    Order order = (Order)orders[i];

                    DataRow dr = table.NewRow();

                    dr["order_number"] = order.Order_number;
                    dr["quantity"] = order.Quantity;
                    dr["weight"] = order.Weight;
                    dr["sender"] = order.CollectionContactName;
                    dr["receiver"] = order.RecipientContactName;
                    dr["phone"] = order.RecipientPhone;
                    dr["postway"] = getPostWay(order.Post_way);
                    dr["pay"] = order.Pay_after_discount;
                    dr["time"] = order.Order_time.ToString("yyyy-MM-dd hh:mm");

                    table.Rows.Add(dr);
                }

            }
            else if(flag=="interface")
            {
                ArrayList orders = new OrderDAO().getOrders(Session["name"].ToString(), "unpay");

                for (int i = 0; i < orders.Count; i++)
                {
                    Order order = (Order)orders[i];

                    DataRow dr = table.NewRow();

                    dr["order_number"] = order.Order_number;
                    dr["quantity"] = order.Quantity;
                    dr["weight"] = order.Weight;
                    dr["sender"] = order.CollectionContactName;
                    dr["receiver"] = order.RecipientContactName;
                    dr["phone"] = order.RecipientPhone;
                    dr["postway"] = getPostWay(order.Post_way);
                    dr["pay"] = order.Pay_after_discount;
                    dr["time"] = order.Order_time.ToString("yyyy-MM-dd hh:mm");

                    table.Rows.Add(dr);
                }

                ArrayList auro_orders = new AutoOrderListDAO().getAutoOrderListArray(Session["name"].ToString(), "unpay");

                for (int i = 0; i < auro_orders.Count; i++)
                {
                    AutoOrderList order = (AutoOrderList)auro_orders[i];

                    DataRow dr = table.NewRow();

                    dr["order_number"] = order.Order_no;
                    dr["quantity"] = 1;
                    dr["weight"] = order.Weight;
                    dr["sender"] = order.CollectionContactName;
                    dr["receiver"] = order.RecipientContactName;
                    dr["phone"] = order.RecipientPhone;
                    dr["postway"] = getPostWay(order.ServiceCode);
                    dr["pay"] = order.Pay_after_discount;
                    dr["time"] = order.Order_time;

                    table.Rows.Add(dr);
                }
            }
            


            return table;
        }



        protected void btn_pay_Click(object sender, EventArgs e)
        {
           
            Session["money_pay"] = lb_money.Text;
            Response.Redirect("../views/order-pay.aspx");
        }

        //清空购物车
        protected void btn_clear_cart_Click(object sender, EventArgs e)
        {
            try
            {
                new AutoOrderDAO().deleteUpayAutoOrder(Session["name"].ToString());

                new AutoOrderListDAO().deleteUpayOrderlist(Session["name"].ToString());

                initMyCart(first);
            }
            catch (System.Exception ex)
            {
                alert("请重新登陆");
            }
            
        }


        private string getPostWay(string postway)
        {
            string way = "";

            if (postway.Trim() == "PF-IPE-Collection")
            {
                way = "皇家邮政经济包（上门取件）";
            }
            else if (postway.Trim() == "PF-IPE-Depot")
            {
                way = "皇家邮政经济包（自行送投至Depot）";
            }
            else if (postway.Trim() == "PF-IPE-Pol")
            {
                way = "皇家邮政经济包（自行送投至邮局）";
            }
            else if (postway.Trim() == "PF-GPR-Collection")
            {
                way = "皇家邮政优先包(上门取件)";
            }
            else if (postway.Trim() == "PF-GPR-Delivery")
            {
                way = "皇家邮政优先包(自行送投至邮局或Depot)";
            }
            else if (postway.Trim() == "EMS")
            {
                way = "华盟EMS专线";
            }
            else if (postway.Trim() == "PostNL")
            {
                way = "荷兰邮政优先包";
            }


            return way;
        }

        //弹出提示信息框
        private void alert(string message)
        {
            Response.Write(string.Format("<script language='javascript'>alert('{0}');</script>", message));
        }

       
    }
}