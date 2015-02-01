using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using WM_Project.logical.common;
using WM_Project.logical.user;
using WM_Project.control;

namespace WM_Project.views.inter_express
{
    public partial class batch_purchase_process : System.Web.UI.Page
    {
        
        public  ArrayList packages_to_SameAddress = new ArrayList();
        public  float[] postages;

        //插入到数据库中的订单信息
        public  ArrayList order_array = new ArrayList() ;
        //插入到数据库中的包裹信息
        public  ArrayList package_array = new ArrayList();

  

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["name"] == null)
                {
                    Response.Redirect("batch-order.aspx");
                }
                else if (Session["packageTOSameAddress"] != null)
                {
                    packages_to_SameAddress = (ArrayList)Session["packageTOSameAddress"];
                    postages = (float[])Session["postages"];

                }
                else
                {
                    Response.Redirect("batch-order.aspx");
                }

            }

        }

        //填写完包裹详细信息后的下一步的实现
        protected void btn_next_step_Click(object sender, EventArgs e)
        {
            //发件地址、收件地址
            string sendAddr = Request.Form["txt_send"];
            string receiveAddr = Request.Form["txt_receive"];
            
            //购买保险、及取件日期
            string insurance = Request.Form["insurance_select"];
            string collectiondate = Request.Form["collection_date"];

            //包裹描述及包裹价值
            string description = Request.Form["content"];
            string value = Request.Form["value"];

            // 发件地址字符串数组、收件地址字符串数组、是否购买保险数组、取件日期数组
            string[] sendAddr_array = sendAddr.Split(',');
            string[] receiveAddr_array = receiveAddr.Split(',');
            string[] insurance_array = insurance.Split(',');
            string[] collectiondate_array = collectiondate.Split(',');

            //包裹描述数组、包裹价值数组
            string[] description_array = description.Split(',');
            string[] value_array = value.Split(',');

            order_array = new ArrayList();
            package_array = new ArrayList();
   
            int package_count = 0;

            packages_to_SameAddress = (ArrayList)Session["packageTOSameAddress"];
            
            for (int i = 0; i < packages_to_SameAddress.Count; i++)
            {
                PackagesToSameAddress package_to_same_address = (PackagesToSameAddress)packages_to_SameAddress[i];
                
                string departure = package_to_same_address.Departure;
                string destination = package_to_same_address.Destination;
                string postway = package_to_same_address.Postway;


                Order order = new Order();
                DateTime temp_time = DateTime.Now;

                Application.Lock();
                string interfaceOrderNo = Application["orderNo"].ToString();
                Application["orderNo"] = (int)Application["orderNo"] + 1;
                Application.UnLock();

                string order_number = "WM" + temp_time.ToString("yyMMddhhmm") + interfaceOrderNo.PadLeft(8,'0');
                
                order.Order_number = order_number;
                order.Name = Session["name"].ToString();
                order.Order_time = temp_time;
                order.Is_pay = "unpay";
                order.Is_show = "true";
                order.Post_way = postway;
                
                //订单的发件地址
                string[] send_array = sendAddr_array[i].Split(';');
                order.CollectionContactName = send_array[0];
                order.CollectionCompanyName = send_array[1];
                order.CollectionAddressLine = send_array[2];
                order.CollectionTown = send_array[3];
                order.CollectionPostCode = send_array[4];
                order.CollectionCountry = send_array[5];
                order.CollectionPhone = send_array[6];

                //订单的收件地址
                string[] receive_array = receiveAddr_array[i].Split(';');
                order.RecipientContactName = receive_array[0];
                order.RecipientCompanyName = receive_array[1];
                order.RecipientAddressLine = receive_array[2];
                order.RecipientTown = receive_array[3];
                order.RecipientPostCode = receive_array[4];
                order.RecipientCountry = receive_array[5];
                order.RecipientPhone = receive_array[6];

                //订单的保险
                order.Insurance = Convert.ToSingle(insurance_array[i]);
                //订单的取件日期
                order.Delivery_date = collectiondate_array[i];

                if (Session["delivery_way"] != null)
                {
                    order.Delivery_way = Session["delivery_way"].ToString();
                }
                else
                {
                    order.Delivery_way = "Collection";
                }

                order.Weight = 0;
                order.Pay_after_discount = 0;

                int quantity = 0;
                string wp_track_no = "";

                ArrayList package_measure_array = package_to_same_address.Package_Array;

                //处理订单中的包裹
                for (int j = 0; j < package_measure_array.Count; j++)
                {
                    PackageMeasure package_measure = (PackageMeasure)package_measure_array[j];
                    
                    quantity += package_measure.Count;

                    for (int k = 0; k < package_measure.Count; k++)
                    {
                        Package package = new Package();

                        Application.Lock();
                        string interfacepackageno = Application["packageNo"].ToString();
                        Application["packageNo"] = (int)Application["packageNo"] + 1;
                        Application.UnLock();

                        package.Description = description_array[package_count];
                        package.Package_value = Convert.ToSingle(value_array[package_count]);
                        package.Order_number = order_number;
                        package.Wp_track_no = "WP" + temp_time.ToString("yyMMddhhmm") + interfacepackageno.PadLeft(8, '0');
                        package.Weight = package_measure.Weight;
                        package.Length = package_measure.Length;
                        package.Width = package_measure.Width;
                        package.Height = package_measure.Height;

                        

                        package.Name = Session["name"].ToString();
                        package.Post_way = postway;
                        package.Pay = new InterFaceQuote().getQuote(package.Name,destination, package.Weight, package.Length, package.Width, package.Height, postway);
                        package.Departure = departure;
                        package.Destination = destination;
                        package.Is_pay = "unpay";

                        if (wp_track_no != "")
                        {
                            wp_track_no += "," + package.Wp_track_no;
                        }
                        else
                        {
                            wp_track_no += package.Wp_track_no;
                        }

                        //判断是不是PF，如果是PF则要进行中文转换
                        if (package.Post_way.ToUpper().Contains("PF"))
                        {
                            package.Description = Hz2Py.Convert(package.Description);

                            if (package.Package_value.ToString().Length > 8)
                            {
                                alert("第" + (i + 1) + "个订单的第" + (j + 1) + "个包裹的报过价值长度超过了 8 位，Parcelforce 不能处理，请更改！！");
                                return;
                            }

                        }

                        if (package.Post_way.ToUpper().Contains("POSTNL"))
                        {
                            if (package.Description.Contains("座椅") || package.Description.Contains("车座"))
                            {
                                package.Volumetric = (package.Length * package.Width * package.Height) / 6000.0f;
                            }

                            package.Chargeable = package.Weight > package.Volumetric ? package.Weight : package.Volumetric;

                        }
                        else
                        {
                            package.Volumetric = (package.Length * package.Width * package.Height) / 5000.0f;
                            package.Chargeable = package.Weight > package.Volumetric ? package.Weight : package.Volumetric;
                        }

                        //订单中包裹的总重
                        order.Weight += package.Chargeable;
                        order.Pay_after_discount += package.Pay;

                        //包裹个数 ++
                        package_count++;

                        package_array.Add(package);
                    }
                }

                order.Quantity = quantity;
                order.Pay_before_discount = order.Pay_after_discount;
                order.Discount = 0;

                order.Wp_track_no = wp_track_no;


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

                        order.RecipientContactName = order.RecipientContactName.Replace("。", "");
                        order.RecipientCompanyName = order.RecipientCompanyName.Replace("。", "");
                        order.RecipientAddressLine = order.RecipientAddressLine.Replace("。", "");
                        order.RecipientTown = order.RecipientTown.Replace("。", "");
                        order.RecipientPostCode = order.RecipientPostCode.Replace("。", "");
                        order.RecipientCountry = order.RecipientCountry.Replace("。", "");

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
                        alert("第" + (i + 1) + "个订单的收件公司长度超过了24字节，请更改!!");
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
                        alert("第" + (i + 1) + "个订单的英文发件地址或者中文收件地址转化为拼音后长度超过了67字节，ParcelForce 不能处理，请缩短!!");
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

                order_array.Add(order);

            }

            //向数据库中添加包谷信息
            for (int i = 0; i < package_array.Count; i++)
            {
                Package package = (Package)package_array[i];
                new PackageDAO().addPackage(package);
            }


            //向数据库中添加订单信息
            for (int i = 0; i < order_array.Count; i++)
            {
                Order order = (Order)order_array[i];
                new OrderDAO().addOrder(order);
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

    
        //弹出提示信息
        private void alert(string message)
        {
            Response.Write(string.Format("<script language='javascript'>alert('{0}')</script>", message));
        }
        
    }
}