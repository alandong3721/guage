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
using WM_Project.logical.user;

namespace WM_Project.views.inter_express
{
    public partial class simple_batch_purchase_process : System.Web.UI.Page
    {
        public  ArrayList batchOrders = new ArrayList();    //发件地址 
        public  float[] postages;         //每个订单的费用

       

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["name"] == null)
                {
                    Response.Redirect("simple-batch-order.aspx");
                }
                else if(Session["batch_orders"]!=null)
                {
                    

                        batchOrders = (ArrayList)Session["batch_orders"];
                        postages = (float[])Session["postages"];
                        page_one.Visible = true;
                    
                }
                else
                {
                    Response.Redirect("simple-batch-order.aspx");
                }
            }
            
        }

        //////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////
        //填写包裹详细信息的实现
        protected void btn_toMyShoopingCart_Click(object sender, EventArgs e)
        {
            ArrayList order_array = new ArrayList();
            ArrayList package_array = new ArrayList();
            // 发件地址
            string sendAddr = Request.Form["txt_send_addr"];
            //收件地址
            string receiveStr = Request.Form["receiveAddr"];

            //是否购买保险
            string insuranceStr = Request.Form["insurance_select"];

            //取件时间
            string date = Request.Form["collection_date"];
           
            //包裹描述
            string content = Request.Form["content"];

            //包裹价值
            string value = Request.Form["value"];

            //所有订单共一个发件地址
            string[] sendaddress = sendAddr.Split(';');
            
            //收件地址字符串数组
            string[] receiveAddr_array = receiveStr.Split(',');
            //购买保险字符串数组
            string[] insurance_array = insuranceStr.Split(',');
            //取件时间字符串数组
            string[] date_array = date.Split(',');


            //下面的不一样
            string[] content_array = content.Split(',');
            string[] value_array = value.Split(',');

            
            int description_count = 0;

            batchOrders = (ArrayList)Session["batch_orders"];


            for (int i = 0; i < batchOrders.Count;i++ )
            {
                BatchOrder batchorder = (BatchOrder)batchOrders[i];
                Order order = new Order();
                DateTime temp_time = DateTime.Now;

                Application.Lock();
                string interfaceOrderNo = Application["orderNo"].ToString();
                Application["orderNo"] = (int)Application["orderNo"] + 1;
                Application.UnLock();

                string order_number = "WM" + temp_time.ToString("yyMMddhhmm") + interfaceOrderNo.PadLeft(8,'0');

                order.Name = Session["name"].ToString();
                order.Order_number = order_number;

                //发件地址
                order.CollectionContactName = sendaddress[0];
                order.CollectionCompanyName = sendaddress[1];
                order.CollectionAddressLine = sendaddress[2];
                order.CollectionTown = sendaddress[3];
                order.CollectionPostCode = sendaddress[4];
                order.CollectionCountry = sendaddress[5];
                order.CollectionPhone = sendaddress[6];

                //收件地址
                string[] receiveaddress = receiveAddr_array[i].Split(';');
                order.RecipientContactName = receiveaddress[0];
                order.RecipientCompanyName = receiveaddress[1];
                order.RecipientAddressLine = receiveaddress[2];
                order.RecipientTown = receiveaddress[3];
                order.RecipientPostCode = receiveaddress[4];
                order.RecipientCountry = receiveaddress[5];
                order.RecipientPhone = receiveaddress[6];

                order.Order_time = temp_time;
                order.Is_pay = "unpay";
                order.Is_show = "true";
                order.Post_way = batchorder.PostWay;
                order.Quantity = batchorder.Count;
                
                //订单本地取件费用
                order.Local_pick_pay = 100;

                order.Insurance = Convert.ToSingle(insurance_array[i]);
                order.Delivery_date = date_array[i];

                if (Session["delivery_way"] != null)
                {
                    order.Delivery_way = Session["delivery_way"].ToString();
                }
                else
                {
                    order.Delivery_way = "Collection";
                }
                
                order.Weight = 0;
                order.Pay_before_discount = 0;

                //处理取件时间
                {
                    int k = (int)DateTime.Parse(order.Delivery_date).DayOfWeek;
                    string nowtime = DateTime.Now.ToString("yyyy-MM-dd");
                    
                    if ((order.Delivery_date.CompareTo(nowtime) <= 0) && k != 6 && k != 0)
                    {
                        string nowminute = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
                        string temp = nowtime + " 11:30";

                        if (nowminute.CompareTo(temp) == 1)
                        {
                            if (k == 5)
                            {
                                order.Delivery_date = Convert.ToDateTime(order.Delivery_date).AddDays(3).ToString("yyyy-MM-dd");
                            }
                            else
                            {
                                order.Delivery_date = Convert.ToDateTime(order.Delivery_date).AddDays(1).ToString("yyyy-MM-dd");
                            }
                        }

                    }

                    if (k == 6)
                    {
                        order.Delivery_date = Convert.ToDateTime(order.Delivery_date).AddDays(2).ToString("yyyy-MM-dd");
                    }
                    else if (k == 0)
                    {
                        order.Delivery_date = Convert.ToDateTime(order.Delivery_date).AddDays(1).ToString("yyyy-MM-dd");
                    }

                    if (order.Delivery_date.CompareTo(DateTime.Now.AddDays(21).ToString("yyyy-MM-dd")) >= 0)
                    {
                        alert("取件时间不能离现在太远，最好不要超过 两个星期！！");
                        return;
                    }
                }

                

                string order_wp_track_no = "";

                for (int j = 0; j < batchorder.Count; j++)
                {
                    Package package = new Package();

                    Application.Lock();
                    string interfacepackageno = Application["packageNo"].ToString();
                    Application["packageNo"] = (int)Application["packageNo"] + 1;
                    Application.UnLock();

                    string wp_track_no = "WP" + temp_time.ToString("yyMMddhhmm") + interfacepackageno.PadLeft(8,'0');
                    package.Name = Session["name"].ToString();
                    package.Order_number = order_number;
                    
                    package.Wp_track_no = wp_track_no;
                    package.Weight = batchorder.Weight;
                    package.Length = batchorder.Length;
                    package.Width = batchorder.Width;
                    package.Height = batchorder.Height;
                    package.Departure = batchorder.Departure;
                    package.Destination = batchorder.Destination;
                    package.Post_way = batchorder.PostWay;
                    package.Pay = new InterFaceQuote().getQuote(package.Name, batchorder.Destination, batchorder.Weight, batchorder.Length, batchorder.Width, batchorder.Height, batchorder.PostWay);
                    package.Description = content_array[description_count];
                    package.Package_value = Convert.ToSingle(value_array[description_count]);
                    package.Is_pay = "unpay";
                    description_count++;

                    if (order_wp_track_no != "")
                    {
                        order_wp_track_no += "," + wp_track_no;
                    }
                    else
                    {
                        order_wp_track_no += wp_track_no;
                    }

                    //判断是不是PF，如果是PF则要进行中文转换
                    if (package.Post_way.ToUpper().Contains("PF"))
                    {
                        package.Description = Hz2Py.Convert(package.Description);
                        
                        if (package.Package_value.ToString().Length > 8)
                        {
                            alert("第"+(i+1)+"个订单的第"+(j+1)+"个包裹的报过价值长度超过了 8 位，Parcelforce 不能处理，请更改！！");
                            return;
                        }

                    }

                    if (package.Post_way.ToUpper().Contains("POSTNL"))
                    {
                        if (package.Description.Contains("座椅")||package.Description.Contains("车座"))
                        {
                            package.Volumetric = (package.Length * package.Width * package.Height) / 6000.0f;
                        }

                        package.Chargeable = package.Weight > package.Volumetric ? package.Weight : package.Volumetric;

                    }
                    else
                    {
                        package.Volumetric = (package.Length*package.Width*package.Height)/5000.0f;
                        package.Chargeable = package.Weight>package.Volumetric?package.Weight:package.Volumetric;
                    }


                    
                    //订单总重量
                    order.Weight +=  package.Chargeable;
                    //订单总共付款
                    order.Pay_before_discount += package.Pay;

                    package_array.Add(package);
                }


                if (order.Post_way.ToUpper().Contains("PF"))
                {
                    {
                        // 替换字符

                        // 替换手机号码中的 “—”、“-”
                        order.RecipientPhone = order.RecipientPhone.Replace("-", "");
                        order.RecipientPhone = order.RecipientPhone.Replace("-", "");
                        order.RecipientPhone = order.RecipientPhone.Replace("—", "");
                        order.CollectionPhone = order.CollectionPhone.Replace("—", "");
                        order.CollectionPhone = order.CollectionPhone.Replace("-", "");
                        order.CollectionPhone = order.CollectionPhone.Replace("-", "");

                        order.CollectionCompanyName = order.CollectionCompanyName.Replace("。", "");
                        order.CollectionContactName = order.CollectionContactName.Replace("。", "");
                        order.CollectionAddressLine = order.CollectionAddressLine.Replace("。", "");
                        order.CollectionTown = order.CollectionTown.Replace("。", "");
                        order.CollectionPostCode = order.CollectionPostCode.Replace("。", "");
                        order.CollectionCountry = order.CollectionCountry.Replace("。", "");
                        order.CollectionPhone = order.CollectionPhone.Replace("。", "");

                        order.RecipientContactName = order.RecipientContactName.Replace("。", "");
                        order.RecipientCompanyName = order.RecipientCompanyName.Replace("。", "");
                        order.RecipientAddressLine = order.RecipientAddressLine.Replace("。", "");
                        order.RecipientTown = order.RecipientTown.Replace("。", "");
                        order.RecipientPostCode = order.RecipientPostCode.Replace("。", "");
                        order.RecipientCountry = order.RecipientCountry.Replace("。", "");
                        order.RecipientPhone = order.RecipientPhone.Replace("。", "");

                        order.CollectionCompanyName = order.CollectionCompanyName.Replace("—", "");
                        order.CollectionContactName = order.CollectionContactName.Replace("—", "");
                        order.CollectionAddressLine = order.CollectionAddressLine.Replace("—", "");
                        order.CollectionTown = order.CollectionTown.Replace("—", "");
                        order.CollectionPostCode = order.CollectionPostCode.Replace("—", "");
                        order.CollectionCountry = order.CollectionCountry.Replace("—", "");

                        order.RecipientContactName = order.RecipientContactName.Replace("—", "");
                        order.RecipientCompanyName = order.RecipientCompanyName.Replace("—", "");
                        order.RecipientAddressLine = order.RecipientAddressLine.Replace("—", "");
                        order.RecipientTown = order.RecipientTown.Replace("—", "");
                        order.RecipientPostCode = order.RecipientPostCode.Replace("—", "");
                        order.RecipientCountry = order.RecipientCountry.Replace("—", "");

                        order.CollectionCompanyName = order.CollectionCompanyName.Replace("-", "");
                        order.CollectionContactName = order.CollectionContactName.Replace("-", "");
                        order.CollectionAddressLine = order.CollectionAddressLine.Replace("-", "");
                        order.CollectionTown = order.CollectionTown.Replace("-", "");
                        order.CollectionPostCode = order.CollectionPostCode.Replace("-", "");
                        order.CollectionCountry = order.CollectionCountry.Replace("-", "");

                        order.RecipientContactName = order.RecipientContactName.Replace("-", "");
                        order.RecipientCompanyName = order.RecipientCompanyName.Replace("-", "");
                        order.RecipientAddressLine = order.RecipientAddressLine.Replace("-", "");
                        order.RecipientTown = order.RecipientTown.Replace("-", "");
                        order.RecipientPostCode = order.RecipientPostCode.Replace("-", "");
                        order.RecipientCountry = order.RecipientCountry.Replace("-", "");


                        order.CollectionCompanyName = order.CollectionCompanyName.Replace("（", "");
                        order.CollectionContactName = order.CollectionContactName.Replace("（", "");
                        order.CollectionAddressLine = order.CollectionAddressLine.Replace("（", "");
                        order.CollectionTown = order.CollectionTown.Replace("（", "");
                        order.CollectionPostCode = order.CollectionPostCode.Replace("（", "");
                        order.CollectionCountry = order.CollectionCountry.Replace("（", "");
                        order.CollectionPhone = order.CollectionPhone.Replace("（", "");

                        order.RecipientContactName = order.RecipientContactName.Replace("（", "");
                        order.RecipientCompanyName = order.RecipientCompanyName.Replace("（", "");
                        order.RecipientAddressLine = order.RecipientAddressLine.Replace("（", "");
                        order.RecipientTown = order.RecipientTown.Replace("（", "");
                        order.RecipientPostCode = order.RecipientPostCode.Replace("（", "");
                        order.RecipientCountry = order.RecipientCountry.Replace("（", "");
                        order.RecipientPhone = order.RecipientPhone.Replace("（", "");

                        order.CollectionCompanyName = order.CollectionCompanyName.Replace("）", "");
                        order.CollectionContactName = order.CollectionContactName.Replace("）", "");
                        order.CollectionAddressLine = order.CollectionAddressLine.Replace("）", "");
                        order.CollectionTown = order.CollectionTown.Replace("）", "");
                        order.CollectionPostCode = order.CollectionPostCode.Replace("）", "");
                        order.CollectionCountry = order.CollectionCountry.Replace("）", "");
                        order.CollectionPhone = order.CollectionPhone.Replace("）", "");

                        order.RecipientContactName = order.RecipientContactName.Replace("）", "");
                        order.RecipientCompanyName = order.RecipientCompanyName.Replace("）", "");
                        order.RecipientAddressLine = order.RecipientAddressLine.Replace("）", "");
                        order.RecipientTown = order.RecipientTown.Replace("）", "");
                        order.RecipientPostCode = order.RecipientPostCode.Replace("）", "");
                        order.RecipientCountry = order.RecipientCountry.Replace("）", "");
                        order.RecipientPhone = order.RecipientPhone.Replace("）", "");

                    }

                    order.CollectionContactName = Hz2Py.Convert(order.RecipientCompanyName);
                    order.CollectionCompanyName = Hz2Py.Convert(order.CollectionCompanyName);
                    order.CollectionAddressLine = Hz2Py.Convert(order.CollectionAddressLine);
                    order.CollectionCountry = Hz2Py.Convert(order.CollectionCountry);
                    order.CollectionTown = Hz2Py.Convert(order.CollectionTown);
                    order.CollectionPostCode = Hz2Py.Convert(order.CollectionPostCode);

                    order.RecipientContactName = Hz2Py.Convert(order.RecipientContactName);
                    order.RecipientCompanyName = Hz2Py.Convert(order.RecipientCompanyName);
                    order.RecipientCountry = Hz2Py.Convert(order.RecipientCountry);
                    order.RecipientTown = Hz2Py.Convert(order.RecipientTown);
                    order.RecipientPhone = Hz2Py.Convert(order.RecipientPhone);
                    order.RecipientPostCode = Hz2Py.Convert(order.RecipientPostCode);
                    order.RecipientAddressLine = Hz2Py.Convert(order.RecipientAddressLine);


                    if (order.RecipientCompanyName.Length > 24)
                    {
                        alert("第" + (i+1) + "个订单的收件公司长度超过了24字节，请更改!!");
                        return;
                    }
                    if (order.RecipientContactName.Length > 24)
                    {
                        alert("第" + (i + 1) + "个订单的收件人英文名长度或者中文名转化为拼音后超过了24字符，请更改!!");
                        return;
                    }
                    if (order.RecipientPhone.Length > 15)
                    {
                        alert("第" + (i + 1) + "个订单的收件人电话长度超过了15字符，ParcelForce 不能处理，请缩短!!");
                        return;
                    }
                    if (order.RecipientAddressLine.Length > 67)
                    {
                        alert("抱歉，您的第 " + i + " 个订单由于英文收件地址或者中文收件地址转化为拼音后超过66个字符，ParcelForce 不能处理，请缩短地址，请更改!!");
                        return;
                    }
                    if (order.RecipientTown.Length > 24)
                    {
                        alert("第" + (i + 1) + "个订单的收件人 City 长度超过了24个字符，ParcelForce 不能处理，请缩短!!");
                        return;
                    }

                    if (order.CollectionCompanyName.Length > 24)
                    {
                        alert("第" + (i + 1) + "个订单的发件人公司英文长度或中文转换为拼音后长度超过了24字节，ParcelForce 不能处理，请缩短!!");
                        return;
                    }
                    if (order.CollectionContactName.Length > 24)
                    {
                        alert("第" + (i + 1) + "个订单的发件人名长度超过了24字节，ParcelForce 不能处理，请缩短!!");
                        return;
                    }
                    if (order.CollectionPhone.Length > 15)
                    {
                        alert("第" + (i + 1) + "个包裹的发件人手机号码长度超过了15个字符，ParcelForce 不能处理，请缩短!!");
                        return;
                    }
                    if (order.CollectionAddressLine.Length > 67)
                    {
                        alert("第" + (i+1) +"个订单的英文发件地址或者中文收件地址转化为拼音后长度超过了67字节，ParcelForce 不能处理，请缩短!!");
                        return;
                    }
                    if (order.CollectionTown.Length > 24)
                    {
                        alert("第" + (i + 1) + "个订单的发件 City 英文长度或中文转换为拼音后长度超过了24字符，ParcelForce 不能处理，请缩短!!");
                        return;
                    }
                    if (order.CollectionPostCode.Length > 16)
                    {
                        alert("第" + (i + 1) + "个订单的发件邮编长度超过了16字符，ParcelForce 不能处理，请缩短!!");
                        return;
                    }
                    

                }

                order.Wp_track_no = order_wp_track_no;
                order.Pay_after_discount = order.Pay_before_discount;

                order_array.Add(order);

            }

            //添加包裹
            for (int j = 0; j < package_array.Count; j++)
            {
                Package package = (Package)package_array[j];
                new PackageDAO().addPackage(package);
            }
            //添加订单
            for (int k = 0; k < order_array.Count; k++)
            {
                Order addorder = (Order)order_array[k];
                new OrderDAO().addOrder(addorder);
            }



                Response.Redirect("../my-shopping-cart.aspx?flag=interface");
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
        /// <summary>
        /// 弹出提示信息
        /// </summary>
        /// <param name="message"></param>
        private void alert(string message)
        {
            Response.Write(string.Format("<script language='javascript'>alert('{0}');</script>", message));
        }
    }
}