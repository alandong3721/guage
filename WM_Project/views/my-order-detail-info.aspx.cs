using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using WM_Project.logical.common;
using WM_Project.logical.user;
using WM_Project.control;

namespace WM_Project.views
{
    public partial class my_order_detail_info : System.Web.UI.Page
    {
        public static string order_number = null;
        public static int pacakge_count = 0;
        public static ArrayList package_array = new ArrayList();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                order_number = Request.QueryString["order_number"];
                string status = Request.QueryString["status"];

                if (order_number == null || status == null)
                {
                     
                    has_not_addr_id.Visible = true;
                    pay_operation.Visible = true;
                }
                else if (order_number.Contains("WP"))
                {

                }
                else if (order_number.Contains("WM"))
                {
                    if (status == "unpay")
                    {
                        Order order = new OrderDAO().getOrder(order_number);
                        //int send_addr_id = order.Send_addr_id;
                        //int receive_addr_id = order.Receive_addr_id;

                        //if (send_addr_id != 0)  //是普通下单
                        //{
                        //    has_addr_id.Visible = true;
                        //    unpay_operation.Visible = true;
                        //    Address send = new AddressDAO().getAddress(send_addr_id);
                        //    initSendAddress(send);
                        //    Address receive = new AddressDAO().getAddress(receive_addr_id);
                        //    initReceiveAddress(receive);
                        //    package_array = new PackageDAO().getPackage(order_number);
                        //}
                        //else   //导入下单
                        //{
                        //    has_not_addr_id.Visible = true;
                        //    unpay_operation.Visible = true;

                            

                        //    package_array = new PackageDAO().getPackage(order_number);
                        //}

                    }
                   
                }



            }

        }

        //初始化发件地址信息
        private void initSendAddress(Address send)
        {
            lb_send_addr_id.Text = send.Addr_id.ToString();
            txt_send_addr_contact.Text = send.Addr_contact;
            txt_send_addr_company.Text = send.Company_name;
            txt_send_addr_line1.Text = send.Addr_line1;
            txt_send_addr_line2.Text = send.Addr_line2;
            txt_send_addr_line3.Text = send.Addr_line3;
            txt_send_addr_city.Text = send.City;
            txt_send_addr_postcode.Text = send.Post_code;
            txt_send_addr_country.Text = send.Country;
            txt_send_addr_phone.Text = send.Phone;
            txt_send_addr_email.Text = send.Email;

        }


        //初始化收件地址信息
        private void initReceiveAddress(Address receive)
        {
            lb_receive_addr_id.Text = receive.Addr_id.ToString();
            txt_receive_addr_contact.Text = receive.Addr_contact;
            txt_receive_addr_company.Text = receive.Company_name;
            txt_receive_addr_line1.Text = receive.Addr_line1;
            txt_receive_addr_line2.Text = receive.Addr_line2;
            txt_receive_addr_line3.Text = receive.Addr_line3;
            txt_receive_addr_city.Text = receive.City;
            txt_receive_addr_postcode.Text = receive.Post_code;
            txt_receive_addr_country.Text = receive.Country;
            txt_receive_addr_phone.Text = receive.Phone;
            txt_receive_addr_email.Text = receive.Email;
        }


        //跟新按钮的响应事件
        protected void btn_update_Click(object sender, EventArgs e)
        {
            string order_number = Request.Form["order_number"];
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
                //跟新package表
                updatePackage(package);
            }


            Address send = getSendAddress();
            Address receive = getReceiveAddress();

            Order order = new Order();

            order.CollectionContactName = send.Addr_contact;

            if (send.Company_name.Equals(send.Addr_contact))
            {
                order.CollectionAddressLine = send.Country + " " + send.City + " " + send.Addr_line3 + send.Addr_line2 + send.Addr_line1 + " " + send.Post_code + "," + send.Phone + " " + send.Addr_contact;
            }
            else
            {
                order.CollectionAddressLine = send.Country + " " + send.City + " " + send.Addr_line3 + send.Addr_line2 + send.Addr_line1 + " " + send.Company_name + send.Post_code + "," + send.Phone + " " + send.Addr_contact;
            }

            order.RecipientContactName = receive.Addr_contact;
            if (receive.Company_name.Equals(receive.Addr_contact))
            {
                order.RecipientAddressLine = receive.Country + " " + receive.City + " " + receive.Addr_line3 + receive.Addr_line2 + receive.Addr_line1 + " " + receive.Post_code + "," + receive.Phone + " " + receive.Addr_contact;
            }
            else
            {
                order.RecipientAddressLine = receive.Country + " " + receive.City + " " + receive.Addr_line3 + receive.Addr_line2 + receive.Addr_line1 + " " + receive.Company_name + " " + receive.Post_code + "," + receive.Phone + " " + receive.Addr_contact;
            }
            //跟新订单表
            updateOrder(order);
            //跟新地址簿
            updateAddress(send);
            updateAddress(receive);


            Response.Redirect("my-shopping-cart.aspx");

        }

        //跟新订单
        private bool updateOrder(Order order)
        {
            bool flag = false;
            string update = "update tb_orders set sender_name='" + order.CollectionContactName + "',send_address='" + order.CollectionAddressLine + "',receiver_name='" + order.RecipientContactName + "',receive_address='" + order.RecipientAddressLine + "' where order_number='" + order.Order_number + "'";

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

        //跟新地址信息
        private bool updateAddress(Address address)
        {
            bool flag = false;

            string update = "update tb_addr_book set user_name='" + address.User_name + "',company_name='" + address.Company_name + "',addr_type='" + address.Addr_type + "',addr_contact='" + address.Addr_contact + "',addr_line1='" +
                address.Addr_line1 + "',addr_line2='" + address.Addr_line2 + "',addr_line3='" + address.Addr_line3 + "',city='" + address.City + "',post_code='" + address.Post_code + "',country='" + address.Country + "',phone='" + address.Phone + "',email='" +
                address.Email + "',time='" + address.Time + "' where addr_id=" + address.Addr_id;

            if (new DBOperateCommon().excuteNoQuery(update))
            {
                flag = true;
            }

            return flag;
        }
        //获取发件地址信息
        private Address getSendAddress()
        {
            Address send = new Address();
            send.Addr_id = Convert.ToInt32(lb_send_addr_id.Text);
            send.Addr_contact = txt_send_addr_contact.Text;
            send.Company_name = txt_send_addr_company.Text;
            send.Addr_line1 = txt_send_addr_line1.Text;
            send.Addr_line2 = txt_send_addr_line2.Text;
            send.Addr_line3 = txt_send_addr_line3.Text;
            send.City = txt_send_addr_city.Text;
            send.Post_code = txt_send_addr_postcode.Text;
            send.Country = txt_send_addr_country.Text;
            send.Phone = txt_send_addr_phone.Text;
            send.Email = txt_send_addr_email.Text;
            send.Addr_type = "S";
            send.Time = DateTime.Now;
            return send;
        }
        //获取收件地址信息
        private Address getReceiveAddress()
        {
            Address receive = new Address();
            receive.Addr_id = Convert.ToInt32(lb_receive_addr_id.Text);
            receive.Addr_contact = txt_receive_addr_contact.Text;
            receive.Company_name = txt_receive_addr_company.Text;
            receive.Addr_line1 = txt_receive_addr_line1.Text;
            receive.Addr_line2 = txt_receive_addr_line2.Text;
            receive.Addr_line3 = txt_receive_addr_line3.Text;
            receive.City = txt_receive_addr_city.Text;
            receive.Post_code = txt_receive_addr_postcode.Text;
            receive.Country = txt_receive_addr_country.Text;
            receive.Phone = txt_receive_addr_phone.Text;
            receive.Email = txt_receive_addr_email.Text;
            receive.Time = DateTime.Now;
            receive.Addr_type = "R";
            return receive;
        }
        //返回购物车
        protected void btn_back_Click(object sender, EventArgs e)
        {
            Response.Redirect("my-shopping-cart.aspx");
        }


        //返回到订单管理页面
        protected void btn_back_order_management_Click(object sender, EventArgs e)
        {
            Response.Redirect("my-account.aspx?part=3&action=time");
        }

        //继续下单的实现
        protected void btn_book_order_Click(object sender, EventArgs e)
        {
            string order_number = Request.Form["order_number"];
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

            DateTime temp = DateTime.Now;

            Order order = new OrderDAO().getOrder(order_number);
           
            order.Order_time = temp;
            order.Is_pay = "unpay";
            order.Pay_way = null;
            order.Pay_time = null;
            
            order.Order_number = "WM" + temp.ToString("yyyyMMddhhmmss") + new Random().Next(100, 1000);
            order.Wp_track_no = "";

            ArrayList packages = new ArrayList();

            for (int i = 0; i < package_id_array.Length; i++)
            {
                int pk_id = Convert.ToInt32(package_id_array[i].ToString());
                Package old = new PackageDAO().getPackage(pk_id);

                Package package = new Package();

                package.Post_way = old.Post_way;
                package.Order_number = order.Order_number;
                package.Departure = old.Departure;
                package.Destination = old.Destination;

                package.Weight = Convert.ToSingle(weight_array[i]);
                package.Length = Convert.ToSingle(length_array[i]);
                package.Width = Convert.ToSingle(width_array[i]);
                package.Height = Convert.ToSingle(height_array[i]);

                package.Pay = new Quote().getQuote(package.Departure, package.Destination, package.Weight, package.Length, package.Width, package.Height, package.Post_way);
                package.Description = description_array[i];
                package.Package_value = Convert.ToSingle(value_array[i]);

                string wp_track_no = "WP" + temp.ToString("yyyyMMddhhmmss") + new Random(i).Next(10, 100) + i % 10;
                package.Wp_track_no = wp_track_no;
                package.Is_pay = "unpay";

                order.Wp_track_no += wp_track_no;

                packages.Add(package);
            }

            //添加订单
            new OrderDAO().addOrder(order);
            //添加包裹
            for (int i = 0; i < packages.Count; i++)
            {
                Package temp_pack = (Package)packages[i];

                //添加包裹
                new PackageDAO().addPackage(temp_pack);

            }

            Response.Redirect("my-shopping-cart.aspx");
        }
    }
}