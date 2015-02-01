using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using WM_Project.control;
using WM_Project.logical.common;
using WM_Project.logical.user;

namespace WM_Project.views
{
    public partial class my_cart_order_detail_info : System.Web.UI.Page
    {
       
        public  int pacakge_count = 0;
        public  ArrayList package_array = new ArrayList();
        public string first = "";
        public string order_number = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                order_number = Request.QueryString["order_number"];
                first = Request.QueryString["flag"];

                if (order_number == null || first == null)
                {
                    Response.Redirect("exception/error-page.aspx");
                }
                else if (order_number.Contains("WM"))
                {
                    // 界面下单
                    lb_which_first.Text = first;

                    Order order = new OrderDAO().getOrder(order_number);

                    if (order.Order_number == null||order.Name!=Session["name"].ToString())
                    {
                        Response.Redirect("exception/order-number-error.aspx");
                    }
                    else
                    {
                        initInterfaceAddress(order);
                        has_addr_id.Visible = true;
                        unpay_operation.Visible = true;
                        package_array = new PackageDAO().getPackageCartInfo(order_number);
                    }

                }
                else if (order_number.Contains("WA"))
                {



                    lb_which_first.Text = first;
                    // Excel下单
                    AutoOrderList autolist = new AutoOrderListDAO().getAutoOrderList(order_number);

                    if (autolist.Order_no == null || autolist.Name != Session["name"].ToString())
                    {
                        Response.Redirect("exception/order-number-error.aspx");
                    }
                    else
                    {
                        initExcelAddress(autolist);
                        has_addr_id.Visible = true;
                        unpay_operation.Visible = true;
                        package_array = getCartPackageInfo(autolist);
                    }
                    
                }
            }
        }

        private ArrayList getCartPackageInfo(AutoOrderList autoorder)
        {
            ArrayList packages = new ArrayList();

            PackageCartInfo cartinfo = new PackageCartInfo();
            cartinfo.Description = autoorder.PackageDescription;
            cartinfo.Value = autoorder.PackageValue;
            cartinfo.Weight = autoorder.Weight;
            cartinfo.Length = autoorder.Length;
            cartinfo.Width = autoorder.Width;
            cartinfo.Height = autoorder.Height;
            packages.Add(cartinfo);

            return packages;
        }



        /// <summary>
        /// 初始化界面下单的地址信息
        /// </summary>
        /// <param name="order"></param>
        private void initInterfaceAddress(Order order)
        {
            
            txt_send_addr_contact.Text = order.CollectionContactName;
            txt_send_addr_company.Text = order.CollectionCompanyName;
            txt_send_addr_line1.Text = order.CollectionAddressLine;
            txt_send_addr_line2.Text = "";
            txt_send_addr_line3.Text = "";
            txt_send_addr_city.Text = order.CollectionTown;
            txt_send_addr_postcode.Text = order.CollectionPostCode;
            txt_send_addr_country.Text = order.CollectionCountry;
            txt_send_addr_phone.Text = order.CollectionPhone;

            txt_receive_addr_contact.Text = order.RecipientContactName;
            txt_receive_addr_company.Text = order.RecipientCompanyName;
            txt_receive_addr_line1.Text = order.RecipientAddressLine;
            txt_receive_addr_line2.Text = "";
            txt_receive_addr_line3.Text = "";
            txt_receive_addr_city.Text = order.RecipientTown;
            txt_receive_addr_postcode.Text = order.RecipientPostCode;
            txt_receive_addr_country.Text = order.RecipientCountry;
            txt_receive_addr_phone.Text = order.RecipientPhone;

        }



        /// <summary>
        /// 初始化Excel导入时的地址
        /// </summary>
        /// <param name="autolist"></param>
        private void initExcelAddress(AutoOrderList autolist)
        {
            txt_send_addr_contact.Text = autolist.CollectionContactName;
            txt_send_addr_company.Text = autolist.CollectionCompanyName;
            txt_send_addr_line1.Text = autolist.CollectionAddressLine;
            txt_send_addr_line2.Text = "";
            txt_send_addr_line3.Text = "";
            txt_send_addr_city.Text = autolist.CollectionTown;
            txt_send_addr_postcode.Text = autolist.CollectionPostCode;
            txt_send_addr_country.Text = autolist.CollectionCountry;
            txt_send_addr_phone.Text = autolist.CollectionPhone;
            txt_receive_addr_contact.Text = autolist.RecipientContactName;
            txt_receive_addr_company.Text = autolist.RecipientCompanyName;
            txt_receive_addr_line1.Text = autolist.RecipientAddressLine;
            txt_receive_addr_line2.Text = "";
            txt_receive_addr_line3.Text = "";
            txt_receive_addr_city.Text = autolist.RecipientTown;
            txt_receive_addr_postcode.Text = autolist.RecipeintPostCode;
            txt_receive_addr_country.Text = autolist.RecipientCountry;
            txt_receive_addr_phone.Text = autolist.RecipientPhone;
        }


        
        /// <summary>
        /// 跟新按钮的响应事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_update_Click(object sender, EventArgs e)
        {
            string order_number = Request.Form["order_number"];
            first = lb_which_first.Text;

            string package_id = Request.Form["package_id"];
            string weight = Request.Form["weight"];
            string length = Request.Form["length"];
            string width = Request.Form["width"];
            string height = Request.Form["height"];
            string descrition = Request.Form["description"];
            string value = Request.Form["value"];

            string[] package_id_array = package_id.Split(',');
            string[] weight_array = weight.Split(',');
            string[] length_array = length.Split(',');
            string[] width_array = width.Split(',');
            string[] height_array = height.Split(',');
            string[] description_array = descrition.Split(',');
            string[] value_array = value.Split(',');

            if (order_number.Contains("WM"))
            {
                // 先跟新订单信息
                Order order = new OrderDAO().getOrder(order_number);
                
                order.CollectionContactName = txt_send_addr_contact.Text;
                order.CollectionCompanyName = txt_send_addr_company.Text;
                order.CollectionAddressLine = txt_send_addr_line1.Text + " " + txt_send_addr_line2.Text + " " + txt_send_addr_line3;
                order.CollectionTown = txt_send_addr_city.Text;
                order.CollectionPostCode = txt_send_addr_postcode.Text;
                order.CollectionCountry = txt_send_addr_country.Text;
                order.CollectionPhone = txt_send_addr_phone.Text;

                order.RecipientContactName = txt_receive_addr_contact.Text;
                order.RecipientCompanyName = txt_receive_addr_company.Text;
                order.RecipientAddressLine = txt_receive_addr_line1.Text + " " +txt_receive_addr_line2.Text +" " +txt_receive_addr_line3.Text;
                order.RecipientTown = txt_receive_addr_city.Text;
                order.RecipientPostCode = txt_receive_addr_postcode.Text;
                order.RecipientCountry = txt_receive_addr_country.Text;
                order.RecipientPhone = txt_receive_addr_phone.Text;


                // 跟新该订单对应的包裹信息
                for (int i = 0; i < weight_array.Length; i++)
                {

                    Package package = new PackageDAO().getPackage(Convert.ToInt32(package_id_array[i]));

                    package.Weight = Convert.ToSingle(weight_array[i]);
                    package.Length = Convert.ToSingle(length_array[i]);
                    package.Width = Convert.ToSingle(width_array[i]);
                    package.Height = Convert.ToSingle(height_array[i]);
                    package.Pay = new Quote().getQuote(package.Departure, package.Destination, package.Weight, package.Length, package.Width, package.Height, package.Post_way);
                    package.Description = description_array[i];
                    package.Package_value = Convert.ToSingle(value_array[i]);

                    if (order.Post_way == "PF-IPE-Collection" || order.Post_way == "PF-IPE-Depot" || order.Post_way == "China-IPE-Pol" || order.Post_way == "PF-IPE-Trailer" || order.Post_way == "PF-GPR-Collection" || order.Post_way == "PF-GPR-Delivery")
                    {
                        package.Volumetric = (float)(package.Length * package.Width * package.Height / 5000.0f);
                        package.Chargeable = package.Weight > package.Volumetric ? package.Weight : package.Volumetric;

                    }
                    else if (order.Post_way == "PostNL")
                    {
                        if (package.Description.Contains("推车") || package.Description.Contains("座椅"))
                        {
                            package.Volumetric = package.Length * package.Width * package.Height / 6000.0f;
                        }
                        else
                        {
                            package.Volumetric = 0;
                        }

                        package.Chargeable = package.Weight > package.Volumetric ? package.Weight : package.Volumetric;
                    }
                    else if (order.Post_way == "EMS")
                    {
                        package.Volumetric = (float)((package.Length * package.Width * package.Height) / 5000.0);
                        package.Chargeable = package.Weight > package.Volumetric ? package.Weight : package.Volumetric;
                    }

                    package.Pay = new BatchQuoteDAO().getQuote(Session["name"].ToString(),order.Post_way, package.Weight, package.Chargeable);
                    order.Pay_before_discount += package.Pay;


                    //跟新package表
                    updatePackage(package);
                }

                order.Pay_after_discount = order.Pay_before_discount;

                updateOrder(order);
            }
            else if (order_number.Contains("WA"))
            {
                AutoOrderList autolist = new AutoOrderListDAO().getAutoOrderList(order_number);

                autolist.CollectionContactName = txt_send_addr_contact.Text;
                autolist.CollectionCompanyName = txt_send_addr_company.Text;
                autolist.CollectionAddressLine = txt_send_addr_line1.Text + " " + txt_send_addr_line2.Text + " " + txt_send_addr_line3.Text;
                autolist.CollectionTown = txt_send_addr_city.Text;
                autolist.CollectionPostCode = txt_send_addr_postcode.Text;
                autolist.CollectionCountry = txt_send_addr_country.Text;
                autolist.CollectionPhone = txt_send_addr_phone.Text;

                autolist.RecipientContactName = txt_receive_addr_contact.Text;
                autolist.RecipientCompanyName = txt_receive_addr_company.Text;
                autolist.RecipientAddressLine = txt_receive_addr_line1.Text + " " + txt_receive_addr_line2.Text + " " + txt_receive_addr_line3.Text;
                autolist.RecipientTown = txt_receive_addr_city.Text;
                autolist.RecipeintPostCode = txt_receive_addr_postcode.Text;
                autolist.RecipientCountry = txt_receive_addr_country.Text;
                autolist.RecipientPhone = txt_receive_addr_phone.Text;

                autolist.Weight = Convert.ToSingle(weight_array[0]);
                autolist.Length = Convert.ToSingle(length_array[0]);
                autolist.Width = Convert.ToSingle(width_array[0]);
                autolist.Height = Convert.ToSingle(height_array[0]);
                autolist.PackageDescription = description_array[0];
                autolist.PackageValue = Convert.ToSingle(value_array[0]);

                if (autolist.ServiceCode == "PF-IPE-Collection" || autolist.ServiceCode == "PF-IPE-Depot" || autolist.ServiceCode == "PF-IPE-Pol" || autolist.ServiceCode == "PF-IPE-Trailery" || autolist.ServiceCode == "PF-GPR-Collection" || autolist.ServiceCode == "PF-GPR-Delivery")
                {
                    autolist.Volumetric = (float)(autolist.Length * autolist.Width * autolist.Height / 5000.0f);
                    autolist.Chargeable = autolist.Weight > autolist.Volumetric ? autolist.Weight : autolist.Volumetric;
                    
                }
                else if(autolist.ServiceCode == "PostNL")
                {
                    if (autolist.PackageDescription.Contains("推车") || autolist.PackageDescription.Contains("座椅"))
                    {
                        autolist.Volumetric = autolist.Length * autolist.Width * autolist.Height / 6000.0f;
                    }
                    else
                    {
                        autolist.Volumetric = 0;
                    }

                    autolist.Chargeable = autolist.Weight > autolist.Volumetric ? autolist.Weight : autolist.Volumetric;
                }
                else if(autolist.ServiceCode=="EMS")
                {
                    autolist.Volumetric = (float)((autolist.Length * autolist.Width * autolist.Height) / 5000.0);
                    autolist.Chargeable = autolist.Weight > autolist.Volumetric ? autolist.Weight : autolist.Volumetric;
                }

                autolist.Pay_before_discount = new BatchQuoteDAO().getQuote(Session["name"].ToString(), autolist.ServiceCode, autolist.Weight, autolist.Chargeable);
                autolist.Pay_after_discount = autolist.Pay_before_discount;
                //跟新订单
                new AutoOrderListDAO().updateAutoOrderList(autolist); 
                     

            }

            Response.Redirect("my-shopping-cart.aspx?flag=" + first);

        }

        //跟新订单
        private bool updateOrder(Order order)
        {
            bool flag = false;
            
            string update = "update tb_orders set collectioncompanyname='"+order.CollectionCompanyName+"',collectioncontactname='"+order.CollectionContactName+"',collectionphone='"+order.CollectionPhone+"',collectionaddressline='"+order.CollectionAddressLine+"',collectiontown='"+order.CollectionTown+"',collectionpostcode='"+order.CollectionPostCode+"',collectioncountry='"+order.CollectionCountry+"',recipientcompanyname='"
                +order.RecipientCompanyName+"',recipientcontactname='"+order.RecipientContactName+"',recipientphone='"+order.RecipientPhone+"',recipientaddressline='"+order.RecipientAddressLine+"',recipienttown='"+order.RecipientTown+"',recipientpostcode='"+order.RecipientPostCode+"',recipientcountry='"+order.RecipientCountry+"' where order_number='"+order.Order_number+"'";
            if (new DBOperateCommon().excuteNoQuery(update))
            {
                flag = true;
            }


            return flag;
        }

        //跟新包裹信息
        private bool updatePackage(Package package)
        {
            bool flag = false;

            string update = "update tb_package set description='" + package.Description + "',package_value=" + package.Package_value + ", weight=" + package.Weight + ",length=" + package.Length + ",width=" + package.Width + ",height=" + package.Height + ",pay=" + package.Pay + " where package_id =" + package.Package_id;

            if (new DBOperateCommon().excuteNoQuery(update))
            {
                flag = true;
            }

            return flag;
        }


        //返回购物车
        protected void btn_back_Click(object sender, EventArgs e)
        {
            first = lb_which_first.Text;
            
            if (first == "")
            {
                first = "interface";
            }

            Response.Redirect("my-shopping-cart.aspx?flag=" + first);
        }

    }
}