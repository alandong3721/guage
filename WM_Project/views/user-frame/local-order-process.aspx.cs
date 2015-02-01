using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


using WM_Project.logical.common;
using WM_Project.control;

namespace WM_Project.views.user_frame
{
    public partial class local_order_process : System.Web.UI.Page
    {
        public ArrayList autoorder_array = new ArrayList();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["name"] == null)
                {
                    Response.Redirect("error-page.aspx");
                }
                else
                {
   
                    if (Session["way"] == null)
                    {
                        part_one.Visible = true;
                        part_two.Visible = false;

                        local_postway.DataSource = createTable();
                        local_postway.DataBind();

                    }
                    else
                    {
                        part_one.Visible = false;
                        part_two.Visible = true;

                        autoorder_array.Clear();

                        ArrayList order_array = (ArrayList)Session["local_order"];

                        if (Session["local_order"] == null)
                        {
                            Response.Redirect("error.aspx");
                        }
                        else
                        {

                            AutoOrderList orderlist = new AutoOrderListDAO().getAutoOrderList(order_array[0].ToString());
                            initLocalPickUpAddr(orderlist);
                        }
                    }
                    

                }
            }
        }



        protected void local_postway_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName.ToString() == "buy")
            {
                string postway = e.CommandArgument.ToString();
                Session["way"] = postway;
                Response.Redirect("local-order-process.aspx");
            }
        }

        /// <summary>
        /// 产生数据绑定表    
        /// </summary>
        /// <returns></returns>
        private DataTable createTable()
        {
            DataTable table = new DataTable();

            DataColumn dc = new DataColumn("postway",typeof(string));
            table.Columns.Add(dc);
            
            dc = new DataColumn("image", typeof(string));
            table.Columns.Add(dc);

            dc = new DataColumn("money", typeof(float));
            table.Columns.Add(dc);

            dc = new DataColumn("note", typeof(string));
            table.Columns.Add(dc);

            for (int i = 0; i < 2;i++ )
            {
                DataRow dr = table.NewRow();
                dr["image"] = "Express24";
                dr["postway"] = "Express24";
                dr["money"] = 100.0;
                dr["note"] = "Express24";
                table.Rows.Add(dr);

            }

            return table;
        }

        /// <summary>
        /// 去购物车结算的实现  将要本地区间的订单信息添加到本地取件订单表中
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_goto_cart_Click(object sender, EventArgs e)
        {
            string c_companyname = txt_send_addr_company.Text;
            string c_contactname = txt_send_addr_contact.Text;
            string c_town = txt_send_addr_city.Text;
            string c_addressline = txt_send_addr_line1.Text + " " + txt_send_addr_line2.Text + " " + txt_send_addr_line3.Text;
            string c_phone = txt_send_addr_phone.Text;
            string c_postcode = txt_send_addr_postcode.Text;
            string c_shipdate = txt_shipdate.Text;

            ArrayList order_array = (ArrayList)Session["local_order"];
            for (int i = 0; i < order_array.Count; i++)
            {
                AutoOrderList orderlist = new AutoOrderListDAO().getAutoOrderList(order_array[i].ToString());
                autoorder_array.Add(orderlist);
            }

            LocalOrder local_order = new LocalOrder();

            Application.Lock();
            string orderNo = Application["orderNo"].ToString();
            Application["orderNo"] = (int)Application["orderNo"] + 1;
            Application.UnLock();

            local_order.Order_no ="WL"+DateTime.Now.ToString("yyMMddHHmm")+orderNo.PadLeft(8, '0');
            local_order.Collectioncompanyname = c_companyname;
            local_order.Collectioncontactname = c_contactname;
            local_order.Collectionaddressline = c_addressline;
            local_order.Collectionpostcode = c_postcode;
            local_order.Collectiontown = c_town;
            local_order.Collectionphone = c_phone;
            local_order.Collectioncountry = "UK";

            local_order.Recipientcompanyname = "华盟快递";
            local_order.Recipientcontactname = "华盟";
            local_order.Recipientaddressline = "华盟";
            local_order.Recipientpostcode = "br sdf";
            local_order.Recipienttown = "Birmihan";
            local_order.Recipientcountry = "UK";
            local_order.Recipientphone = "2384sdf";
            local_order.Name = Session["name"].ToString();
            local_order.Delivery_date = c_shipdate;
            local_order.Servicecode = Session["way"].ToString();
            local_order.Order_time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            local_order.Quantity = autoorder_array.Count;
            local_order.Is_pay = "unpay";


            for (int i = 0; i < autoorder_array.Count; i++)
            {
 
                AutoOrderList orderlist = (AutoOrderList)autoorder_array[i];
                LocalPackage local_package = new LocalPackage();
                local_package.Name = Session["name"].ToString();
                local_package.Order_number = local_order.Order_no;
                local_package.Wm_track_no = orderlist.Order_no;
                local_package.Shipmentpurpose = orderlist.Shippingpurpose;
                local_package.Packagedescription = orderlist.PackageDescription;
                local_package.Packagevalue = orderlist.PackageValue;
                local_package.Weight = orderlist.Weight;
                local_package.Servicecode = local_order.Servicecode;
                local_package.Is_pay = "unpay";
                local_package.Insurance = orderlist.Insurance;
                local_package.Pay_before_discount = 100;
                local_package.Discount = 0;
                local_package.Pay_after_discount = local_package.Pay_before_discount;
                local_package.Less_pay = 0;
                local_package.True_weight = 0;


                local_order.Pay_before_discount += local_package.Pay_before_discount;
                if (local_order.Wm_track_no != "")
                {
                    local_order.Wm_track_no = local_order.Wm_track_no + "," + local_package.Wm_track_no; 
                }
                else{
                    local_order.Wm_track_no += local_package.Wm_track_no;
                }

                new LocalPackageDAO().addLocalPackage(local_package);

            }

            local_order.Pay_after_discount = local_order.Pay_before_discount;
            local_order.Discount = 0;

            new LocalOrderDAO().addLocalOrder(local_order);

            Response.Redirect("my-local-pick-up-cart.aspx");
        }

        private void initLocalPickUpAddr(AutoOrderList auto_orderlist)
        {
            txt_send_addr_contact.Text = auto_orderlist.CollectionContactName;
            txt_send_addr_company.Text = auto_orderlist.CollectionCompanyName;
            txt_send_addr_line1.Text = auto_orderlist.CollectionAddressLine;
            txt_send_addr_phone.Text = auto_orderlist.CollectionPhone;
            txt_send_addr_postcode.Text = auto_orderlist.CollectionPostCode;
            txt_send_addr_city.Text = auto_orderlist.CollectionTown;
            txt_send_addr_country.Text = "UK";
            string today_time = DateTime.Now.ToString("yyyy-MM-dd");
            //判断今天星期 几
            int k = (int)DateTime.Parse(today_time).DayOfWeek;
            
            if(k==5)
            {
                txt_shipdate.Text = DateTime.Now.AddDays(3).ToString("yyyy-MM-dd");
            }
            else if (k == 6)
            {
                txt_shipdate.Text = DateTime.Now.AddDays(2).ToString("yyyy-MM-dd");
            }
            else
            {
                txt_shipdate.Text = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd");
            }
        }

        
       
    }
}