using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using WM_Project.control;
using WM_Project.logical.common;

namespace WM_Project.views.inter_express
{
    public partial class my_local_pick_up_cart : System.Web.UI.Page
    {
        public DataTable table_source = new DataTable();
        public ArrayList pay_orders = new ArrayList();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                if (Session["name"] == null)
                {
                    Response.Redirect("../index.aspx");
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

                
                initMyCart();

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
        protected void initMyCart()
        {
            table_source = createMyCartTable();

            if (table_source.Rows.Count == 0)
            {
                cart_part.Visible = false;
               
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


        private DataTable createMyCartTable()
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

            ArrayList local_order_array = new LocalOrderDAO().getUnPayLocalOrder(Session["name"].ToString());
            for (int i = 0; i < local_order_array.Count; i++)
            {
                LocalOrder local_order = (LocalOrder)local_order_array[i];

                ArrayList local_packages_array = new LocalPackageDAO().getLocalPackageByOrderNo(local_order.Order_no);

                for (int j = 0; j < local_order.Quantity;j++ )
                {
                    DataRow dr = table.NewRow();
                    LocalPackage local_package = (LocalPackage)local_packages_array[j];
                    dr["order_number"] = local_package.Ea_track_no;
                    dr["sender"] = local_order.Collectioncontactname;
                    dr["receiver"] = local_order.Recipientcontactname;
                    dr["postway"] = local_order.Servicecode;
                    dr["quantity"] = 1;
                    dr["weight"] = local_package.Weight;
                    dr["pay"] = local_package.Pay_after_discount;
                    dr["time"] = local_order.Order_time;
                    table.Rows.Add(dr);

                }
  
            }

            
           
            return table;
        }



        protected void btn_pay_Click(object sender, EventArgs e)
        {
            pay_orders = new ArrayList();

            for (int i = 0; i < my_cart_datalist.Items.Count; i++)
            {

                HiddenField hidden = (HiddenField)my_cart_datalist.Items[i].FindControl("hidden");
                string order = hidden.Value.ToString();
                pay_orders.Add(order);

            }

            Session["money_pay"] = lb_money.Text;
            Session["type"] = "local";
            Response.Redirect("order-pay.aspx");
        }

        //清空购物车
        protected void btn_clear_cart_Click(object sender, EventArgs e)
        {
            try
            {
                // 清空购物车
                new LocalOrderDAO().clearMyShoppingCart(Session["name"].ToString());
                cart_part.Visible = false;
                no_local_order.Visible = true;

            }
            catch (System.Exception ex)
            {
                alert("请重新下单！！");
            }

        }


        //弹出提示信息框
        private void alert(string message)
        {
            Response.Write(string.Format("<script language='javascript'>alert('{0}');</script>", message));
        }

    }
}