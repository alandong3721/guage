using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;


using WM_Project.control;
using WM_Project.logical.common;
using WM_Project.logical.user;


namespace WM_Project.views.inter_express
{
    public partial class batch_import : System.Web.UI.Page
    {

        public  string intablename = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["name"] == null)
                {
                    page_one.Visible = true;
                    alert("请先登录!");
                }
                else
                {
                    page_two.Visible = true;
                }
            }
        }


        /// <summary>
        /// 登陆按钮的实现
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
                    page_one.Visible = false;
                    Session["name"] = name;
                    page_two.Visible = true;
                    Response.Redirect("batch-import.aspx");
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
        /// 弹出提示信息
        /// </summary>
        /// <param name="message">所要弹出的信息</param>
        private void alert(string message)
        {
            Response.Write(string.Format("<script language='javascript'>alert('{0}');</script>", message));
        }


        //上传Excel文件的实现
        protected void btn_upload_Click(object sender, EventArgs e)
        {
            int line_count = 0;
            string username = "";

            string path = upload_ems_excel.FileName;

            if (path == "")
            {
                alert("请选择文件！！");
                return;
            }
            else
            {
         
                username = Session["name"].ToString();

                string file_path = saveUploadFile();

                if (file_path == "error")
                {
                    return;
                }

                DataSet ds = new DataSet();

                string strConn = "Provider=ACE.OLEDB.12.0;" + "Data Source=" + file_path + ";" + "Extended Properties='Excel 8.0;HDR=Yes;IMEX=1;'";
                OleDbConnection conn = new OleDbConnection(strConn);
                conn.Open();
                string strExcel = "";
                OleDbDataAdapter myCommand = null;
                OleDbCommandBuilder cb = new OleDbCommandBuilder(myCommand);
                strExcel = "select  * from [Sheet1$] ";

                myCommand = new OleDbDataAdapter(strExcel, strConn);
                myCommand.Fill(ds, "table1");

                ArrayList order_array = new ArrayList();
                ArrayList package_array = new ArrayList();
                DateTime temp_time = DateTime.Now;

                AutoOrder order = new AutoOrder();
                DateTime time = DateTime.Now;

                Application.Lock();
                string autoOrderNo = Application["orderNo"].ToString();
                Application["orderNo"] = (int)Application["orderNo"] + 1;
                Application.UnLock();

                string auto_no = "AU" + time.ToString("yyMMddHHmm") + autoOrderNo.PadLeft(8, '0');

                order.Auto_no = auto_no;
                order.Name = Session["name"].ToString();
                order.Order_time = time.ToString("yyyy-MM-dd HH:mm");
                order.Is_pay = "unpay";
                order.Pay_before_discount = 0;
                order.Excel_path = intablename;

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    if (ds.Tables[0].Rows[i][4].ToString().Trim() != "" && (!ds.Tables[0].Rows[i][0].ToString().Trim().Contains("取件还是投送") && !ds.Tables[0].Rows[i][1].ToString().Trim().Contains("发件时间")))
                    {
                        //判断Excel是否为空

                        string delivery_way = ds.Tables[0].Rows[i][0].ToString().Trim();
                        string delivery_time = ds.Tables[0].Rows[i][1].ToString().Trim();
                        string receive_company = ds.Tables[0].Rows[i][2].ToString().Trim();
                        string receive_name = ds.Tables[0].Rows[i][3].ToString().Trim();
                        string receive_phone = ds.Tables[0].Rows[i][4].ToString().Trim();
                        string receive_address_line = ds.Tables[0].Rows[i][5].ToString().Trim();
                        string receive_city = ds.Tables[0].Rows[i][6].ToString().Trim();
                        string receive_postcode = ds.Tables[0].Rows[i][7].ToString().Trim();
                        string receive_country = ds.Tables[0].Rows[i][8].ToString().Trim();
                        string send_company = ds.Tables[0].Rows[i][9].ToString().Trim();
                        string send_name = ds.Tables[0].Rows[i][10].ToString().Trim();
                        string send_phone = ds.Tables[0].Rows[i][11].ToString().Trim();
                        string send_addressline = ds.Tables[0].Rows[i][12].ToString().Trim();
                        string send_city = ds.Tables[0].Rows[i][13].ToString().Trim();
                        string send_postcode = ds.Tables[0].Rows[i][14].ToString().Trim();
                        string insurance = ds.Tables[0].Rows[i][15].ToString().Trim();
                        string comment = ds.Tables[0].Rows[i][16].ToString().Trim();
                        string parcel_number = ds.Tables[0].Rows[i][17].ToString().Trim();
                        string weight = ds.Tables[0].Rows[i][18].ToString().Trim();
                        string length = ds.Tables[0].Rows[i][19].ToString().Trim();
                        string width = ds.Tables[0].Rows[i][20].ToString().Trim();
                        string height = ds.Tables[0].Rows[i][21].ToString().Trim();
                        string description = ds.Tables[0].Rows[i][22].ToString().Trim();
                        string package_value = ds.Tables[0].Rows[i][23].ToString().Trim();

                        //判断重量、长、宽、高是否有效


                        {

                            if (delivery_way == "")
                            {
                                alert("您好，包裹的取件方式不能为空，请仔细检查 Excel ！！");
                                return;
                            }
                            else if (delivery_time == "")
                            {
                                alert("您好，包裹的取件时间不能为空,请仔细检查 Excel！！");
                                return;
                            }
                            else if (receive_company == "")
                            {
                                alert("您好，收件公司不能为空，如果没有收件公司，请写上收件人名 ！！");
                                return;
                            }
                            else if (receive_name == "")
                            {
                                alert("您好，收件人名不能为空,请仔细检查 Excel！！");
                                return;
                            }
                            else if (receive_phone == "")
                            {
                                alert("您好，收件人 号码 不能为空,请仔细检查 Excel！！");
                                return;
                            }
                            else if (receive_address_line == "")
                            {
                                alert("您好，收件 地址 不能为空 ,请仔细检查 Excel！！");
                                return;
                            }
                            else if (receive_city == "")
                            {
                                alert("您好，收件人 城市 不能为空,请仔细检查 Excel！！");
                                return;
                            }
                            else if (receive_postcode == "")
                            {
                                alert("您好，收件人 邮编不能为空,请仔细检查 Excel ！！");
                                return;
                            }
                            else if (receive_country == "")
                            {
                                alert("您好，收件人国家不能为空,必须是 China-NL 、 China-IPE 、 China-GPR , 请仔细检查 Excel ！！");
                                return;
                            }
                            else if (send_company == "")
                            {
                                alert("您好，发件人公司不能为空，如果无发件人公司 就 填写发件人名 ！！");
                                return;
                            }
                            else if (send_name == "")
                            {
                                alert("发件人名不能为空 , 请仔细检查 Excel！！");
                                return;
                            }
                            else if (send_phone == "")
                            {
                                alert("您好，发件人 电话 不能为空，请仔细检查！！");
                                return;
                            }
                            else if (send_addressline == "")
                            {
                                alert("您好，发件人地址不能为空，请仔细检查 ！！ ");
                                return;
                            }
                            else if (send_city == "")
                            {
                                alert("您好，发件人城市不能为空，请仔细检查 ！！");
                                return;
                            }
                            else if (send_postcode == "")
                            {
                                alert("您好，发件人 邮编不能为空， 请仔细检查 ！！ ");
                                return;
                            }
                            else if (insurance == "")
                            {
                                alert("您好，是否购买保险字段不能为空，请填上 0 ");
                            }
                            else if (comment == "")
                            {
                                alert("您好，发货目的不能为空 , 请仔细检查 Excel！！");
                                return;
                            }
                            else if (weight == "")
                            {
                                alert("您好，包裹的重量不能为空 , 请仔细检查 Excel！！");
                                return;
                            }
                            else if (length == "")
                            {
                                alert("您好，包裹的长度不能为空 , 请仔细检查 Excel！！");
                                return;
                            }
                            else if (width == "")
                            {
                                alert("您好，包裹的宽度不能为空 , 请仔细检查 Excel！！");
                                return;
                            }
                            else if (height == "")
                            {
                                alert("您好，包裹的 高度不能为空，请仔细检查 ！！");
                                return;
                            }
                            else if (description == "")
                            {
                                alert("您好，包裹的 描述不能为空，请仔细检查！！");
                                return;
                            }
                            else if (package_value == "")
                            {
                                alert("您好，包裹的价值不能为空，请仔细检查 ！！");
                                return;
                            }



                        }


                        //判断中文字符 。


                        {
                            receive_company = receive_company.Replace('。', '.');
                            receive_name = receive_name.Replace('。', '.');
                            receive_address_line = receive_address_line.Replace('。', '.');
                            receive_city = receive_city.Replace('。', '.');
                            receive_postcode = receive_postcode.Replace('。', '.');
                            receive_country = receive_country.Replace('。', '.');
                            send_company = send_company.Replace('。', '.');
                            send_name = send_name.Replace('。', '.');
                            send_addressline = send_addressline.Replace('。', '.');
                            send_city = send_city.Replace('。', '.');
                            send_postcode = send_postcode.Replace('。', '.');
                            description = description.Replace('。', '.');
                           
                        }



                        try
                        {
                            Convert.ToSingle(weight);
                            Convert.ToSingle(length);
                            Convert.ToSingle(width);
                            Convert.ToSingle(height);
                            Convert.ToSingle(package_value);

                        }
                        catch (System.Exception ex)
                        {
                            alert("包裹的重量、长、宽、高、价值 信息必须位数字");
                            return;
                        }

                        if (receive_postcode.Length != 6)
                        {
                            alert("收件人邮编必须为 6 位！！");
                            return;
                        }

                 
                        try
                        {
                            if (receive_phone.Contains("e")||send_phone.Contains("e"))
                            {
                                receive_phone = Convert.ToInt64(Convert.ToSingle(receive_phone)).ToString();
                                send_phone = Convert.ToInt64(Convert.ToSingle(send_phone)).ToString();
                            }
                        }
                        catch (System.Exception ex)
                        {
                            alert("收件人或者发件人电话格式错误");
                            return ;
                        }

                        AutoOrderList package = new AutoOrderList();

                        //如果是 PostNL
                        if (receive_country.ToLower().Equals("china-nl"))
                        {
                            line_count++;

                            Application.Lock();
                            string orderNo = Application["packageNo"].ToString();
                            Application["packageNo"] = (int)Application["packageNo"] + 1;
                            Application.UnLock();

                            package.Auto_no = auto_no;
                            package.Order_no = "WA" + time.ToString("yyMMddHHmm") + orderNo.PadLeft(8, '0');
                            package.Name = Session["name"].ToString();
                            package.CollectionCompanyName = send_company;
                            package.CollectionContactName = send_name;
                            package.CollectionPhone = send_phone;
                            package.CollectionAddressLine = send_addressline;
                            package.CollectionTown = send_city;
                            package.CollectionPostCode = send_postcode;
                            package.CollectionCountry = "UK";
                            package.RecipientCompanyName = receive_company;
                            package.RecipientContactName = receive_name;
                            package.RecipientPhone = receive_phone;
                            package.RecipientAddressLine = receive_address_line;
                            package.RecipientTown = receive_city;
                            package.RecipeintPostCode = receive_postcode;
                            package.RecipientCountry = "China";
                            package.Shippingdate = delivery_time;
                            package.Shippingtype = delivery_way;

                            package.Shippingpurpose = comment;
                            package.PackageDescription = description;
                            package.PackageValue = Convert.ToSingle(package_value);
                            package.Insurance = Convert.ToSingle(insurance);
                            package.ServiceCode = "PostNL";
                            package.Weight = Convert.ToSingle(weight);
                            package.Length = Convert.ToSingle(length);
                            package.Width = Convert.ToSingle(width);
                            package.Height = Convert.ToSingle(height);

                            if (package.PackageDescription.Contains("推车") || package.PackageDescription.Contains("trolly") || package.PackageDescription.Contains("坐椅") || package.PackageDescription.Contains("baby sit") || package.PackageDescription.Contains("babysit") || package.PackageDescription.Contains("sit"))
                            {
                                package.Volumetric = package.Length * package.Width * package.Height / 6000;
                            }
                            else
                            {
                                package.Volumetric = package.Weight;
                            }

                            if (package.Weight >= package.Volumetric)
                            {
                                package.Chargeable = package.Weight;
                            }
                            else
                            {
                                package.Chargeable = package.Volumetric;
                            }
                            package.Pay_status = "unpay";
                            package.Pay_before_discount = new BatchQuoteDAO().getQuote(username, package.ServiceCode, package.Weight, package.Chargeable);
                            package.Pay_before_discount += package.Insurance;
                            package.Discount = 0;

                            package.Pay_after_discount = package.Pay_before_discount;
                            package.Order_time = order.Order_time;
                            package.Less_pay = 0;
                            package.Is_delivery = 0;

                            order.Pay_before_discount += package.Pay_before_discount;
                            package_array.Add(package);

                        }

                        //如果是 PF-IPE 类别
                        else if (receive_country.ToLower().Equals("china-ipe"))
                        {
                            line_count++;


                            if ((Hz2Py.Convert(receive_company)).Length > 24)
                            {
                                alert("第"+line_count+"个包裹的收件公司长度超过了24字节，请更改!!");
                                return;
                            }
                            if ((Hz2Py.Convert(receive_name)).Length > 24)
                            {
                                alert("第" + line_count + "个包裹的收件人英文名长度或者中文名转化为拼音后超过了24字符，请更改!!");
                                return;
                            }
                            if ((Hz2Py.Convert(receive_phone)).Length > 15)
                            {
                                alert("第" + line_count + "个包裹的收件人电话长度超过了15字符，ParcelForce 不能处理，请缩短!!");
                                return;
                            }
                            if ((Hz2Py.Convert(receive_address_line)).Length > 67)
                            {
                                alert("抱歉，您的第 " + line_count + " 个订单由于英文收件地址或者中文收件地址转化为拼音后超过66个字符，ParcelForce 不能处理，请缩短地址，请更改!!");
                                return;
                            }
                            if ((Hz2Py.Convert(receive_city)).Length > 24)
                            {
                                alert("第" + line_count + "个包裹的收件人 City 长度超过了24个字符，ParcelForce 不能处理，请缩短!!");
                                return;
                            }

                            if ((Hz2Py.Convert(send_company)).Length > 24)
                            {
                                alert("第" + line_count + "个包裹的发件人公司英文长度或中文转换为拼音后长度超过了24字节，ParcelForce 不能处理，请缩短!!");
                                return;
                            }
                            if ((Hz2Py.Convert(send_name)).Length > 24)
                            {
                                alert("第" + line_count + "个包裹的发件人名长度超过了24字节，ParcelForce 不能处理，请缩短!!");
                                return;
                            }
                            if ((Hz2Py.Convert(send_phone)).Length > 15)
                            {
                                alert("第" + line_count + "个包裹的发件人手机号码长度超过了15个字符，ParcelForce 不能处理，请缩短!!");
                                return;
                            }
                            if ((Hz2Py.Convert(send_addressline)).Length > 67)
                            {
                                alert("第" + line_count + "个包裹的英文发件地址或者中文收件地址转化为拼音后长度超过了67字节，ParcelForce 不能处理，请缩短!!");
                                return;
                            }
                            if ((Hz2Py.Convert(send_city)).Length > 24)
                            {
                                alert("第" + line_count + "个包裹的发件 City 英文长度或中文转换为拼音后长度超过了24字符，ParcelForce 不能处理，请缩短!!");
                                return;
                            }
                            if ((Hz2Py.Convert(send_postcode)).Length > 16)
                            {
                                alert("第" + line_count + "个包裹的发件邮编长度超过了16字符，ParcelForce 不能处理，请缩短!!");
                                return;
                            }
                            if ((Hz2Py.Convert(description)).Length > 30)
                            {
                                alert("第" + line_count + "个包裹的 Description 字段 英文后中文转换为拼音后 长度超过了30字符，ParcelForce 不能处理，请缩短!!");
                                return;
                            }
                            if (weight.ToString().Length > 8)
                            {
                                alert("第" + line_count + "个包裹的重量 值 超过了 8 位，ParcelForce 不能处理，请缩短!!");
                                return;
                            }
                            if (height.ToString().Length > 8)
                            {
                                alert("第" + line_count + "个包裹的高度值超过了 8 位，ParcelForce 不能处理，请缩短!!");
                                return;
                            }
                            if (length.ToString().Length > 8)
                            {
                                alert("第" + line_count + "个包裹的长度值超过了 8 位，ParcelForce 不能处理，请缩短!!");
                                return;
                            }
                            if (package_value.ToString().Length > 8)
                            {
                                alert("第" + line_count + "个包裹的 包裹价值 长度超过了8位，ParcelForce 不能处理，请缩短!!");
                                return;
                            }
                            if (width.ToString().Length > 8)
                            {
                                alert("第" + line_count + "个包裹的 宽度 长度超过了 8 位，ParcelForce 不能处理，请缩短!!");
                                return;
                            }
                            if ((Hz2Py.Convert(comment)).Length > 16)
                            {
                                alert("第" + line_count + "个包裹的 Purpose Of Shipment 字段的英文长度或中文转换为英文后的长度超过了24字符，ParcelForce 不能处理，请缩短!!");
                                return;
                            }



                            string nowtime = DateTime.Now.ToString("yyyy-MM-dd");

                            Regex reg = new Regex(@"[0-9]{4}-[0-9]{2}-[0-9]{2}");

                            if (!reg.Match(delivery_time).Success)
                            {
                                alert("China-IPE 的发件时间格式必须为 YYYY-MM-DD，并且发件时间必须是明天以后");
                                return;
                            }

                            int k = (int)DateTime.Parse(delivery_time).DayOfWeek;

                            if (delivery_time.CompareTo(nowtime) == -1)
                            {
                                alert("China-IPE 的发件时间格式必须为 YYYY-MM-DD，并且发件时间必须是第二天及以后");
                                return;
                            }
                            else if ((delivery_time.CompareTo(nowtime) == 0) && k != 6 && k != 0)
                            {
                                string nowminute = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
                                string temp = nowtime + " 11:30";

                                if (nowminute.CompareTo(temp) == 1)
                                {
                                    if (k == 5)
                                    {
                                        delivery_time = Convert.ToDateTime(delivery_time).AddDays(3).ToString("yyyy-MM-dd");
                                    }
                                    else
                                    {
                                        delivery_time = Convert.ToDateTime(delivery_time).AddDays(1).ToString("yyyy-MM-dd");
                                    }
                                } 

                            }

                            if (delivery_time.CompareTo(DateTime.Now.AddDays(21).ToString("yyyy-MM-dd")) >= 0)
                            {
                                alert("取件时间不能离现在太远，最好不要超过 两个星期！！");
                                return;
                            }

                            if (k == 6)
                            {
                                delivery_time = Convert.ToDateTime(delivery_time).AddDays(2).ToString("yyyy-MM-dd");
                            }
                            else if (k == 0)
                            {
                                delivery_time = Convert.ToDateTime(delivery_time).AddDays(1).ToString("yyyy-MM-dd");
                            }



                            Application.Lock();
                            string orderNo = Application["packageNo"].ToString();
                            Application["packageNo"] = (int)Application["packageNo"] + 1;
                            Application.UnLock();

                            package.Auto_no = auto_no;
                            package.Order_no = "WA" + time.ToString("yyMMddHHmm") + orderNo.PadLeft(8, '0');
                            package.Name = Session["name"].ToString();
                            package.CollectionCompanyName = send_company;
                            package.CollectionContactName = send_name;
                            package.CollectionPhone = send_phone;
                            package.CollectionAddressLine = send_addressline;
                            package.CollectionTown = send_city;
                            package.CollectionPostCode = send_postcode;
                            package.CollectionCountry = "UK";
                            package.RecipientCompanyName = receive_company;
                            package.RecipientContactName = receive_name;
                            package.RecipientPhone = receive_phone;
                            package.RecipientAddressLine = receive_address_line;
                            package.RecipientTown = receive_city;
                            package.RecipeintPostCode = receive_postcode;
                            package.RecipientCountry = "China";
                            package.Shippingdate = delivery_time;
                            package.Shippingtype = delivery_way;

                            package.Shippingpurpose = comment;
                            package.PackageDescription = description;
                            package.PackageValue = Convert.ToSingle(package_value);
                            package.Insurance = Convert.ToSingle(insurance);
                            if (package.Shippingtype.ToLower().Contains("ollec"))
                                package.ServiceCode = "PF-IPE-Collection";
                            else if (package.Shippingtype.ToLower().Contains("epot"))
                                package.ServiceCode = "PF-IPE-Depot";
                            else if (package.Shippingtype.ToLower().Contains("railer"))
                                package.ServiceCode = "PF-IPE-Trailer";
                            else if (package.Shippingtype.ToLower().Contains("pol"))
                                package.ServiceCode = "PF-IPE-Pol";

                            package.Weight = Convert.ToSingle(weight);
                            package.Length = Convert.ToSingle(length);
                            package.Width = Convert.ToSingle(width);
                            package.Height = Convert.ToSingle(height);


                            package.Volumetric = (float)((package.Length * package.Width * package.Height) / 5000.0);

                            if (package.Weight >= package.Volumetric)
                            {
                                package.Chargeable = package.Weight;
                            }
                            else
                            {
                                package.Chargeable = package.Volumetric;
                            }

                            package.Pay_status = "unpay";

                            //此处Pay_before_discount设置为100，以后要计算价格

                            package.Pay_before_discount = new BatchQuoteDAO().getQuote(username, package.ServiceCode, package.Weight, package.Chargeable);// new Quote().getQuote("UK", "China", package.Weight, package.Chargeable, "PostNL", Session["name"].ToString());
                            package.Pay_before_discount += package.Insurance;
                            package.Discount = 0;

                            package.Pay_after_discount = package.Pay_before_discount;
                            package.Order_time = order.Order_time;
                            package.Less_pay = 0;
                            package.Is_delivery = 0;

                            order.Pay_before_discount += package.Pay_before_discount;


                            package_array.Add(package);

                        }

                        // 如果是 PF-GPR类型
                        else if (receive_country.ToLower().Equals("china-gpr"))
                        {
                            line_count++;


                            if ((Hz2Py.Convert(receive_company)).Length > 24)
                            {
                                alert("第" + line_count + "个包裹的收件公司长度超过了24字节，请更改!!");
                                return;
                            }
                            if ((Hz2Py.Convert(receive_name)).Length > 24)
                            {
                                alert("第" + line_count + "个包裹的收件人名长度超过了24字节，请更改!!");
                                return;
                            }
                            if ((Hz2Py.Convert(receive_phone)).Length > 15)
                            {
                                alert("第" + line_count + "个包裹的收件人电话长度超过了15字节，请更改!!");
                                return;
                            }
                            if ((Hz2Py.Convert(receive_address_line)).Length > 67)
                            {
                                alert("第" + line_count + "个包裹的收件人地址长度超过了67字节，请更改!!");
                                return;
                            }
                            if ((Hz2Py.Convert(receive_city)).Length > 24)
                            {
                                alert("第" + line_count + "个包裹的收件人 City 长度超过了24字节，请更改!!");
                                return;
                            }

                            if ((Hz2Py.Convert(send_company)).Length > 24)
                            {
                                alert("第" + line_count + "个包裹的发件人公司长度超过了24字节，请更改!!");
                                return;
                            }
                            if ((Hz2Py.Convert(send_name)).Length > 24)
                            {
                                alert("第" + line_count + "个包裹的发件人名长度超过了24字节，请更改!!");
                                return;
                            }
                            if ((Hz2Py.Convert(send_phone)).Length > 15)
                            {
                                alert("第" + line_count + "个包裹的发件人手机号码长度超过了15字节，请更改!!");
                                return;
                            }
                            if ((Hz2Py.Convert(send_addressline)).Length > 67)
                            {
                                alert("第" + line_count + "个包裹的收件公司长度超过了67字节，请更改!!");
                                return;
                            }
                            if ((Hz2Py.Convert(send_city)).Length > 24)
                            {
                                alert("第" + line_count + "个包裹的收件公司长度超过了24字节，请更改!!");
                                return;
                            }
                            if ((Hz2Py.Convert(send_postcode)).Length > 16)
                            {
                                alert("第" + line_count + "个包裹的收件公司长度超过了16字节，请更改!!");
                                return;
                            }
                            if ((Hz2Py.Convert(description)).Length > 30)
                            {
                                alert("第" + line_count + "个包裹的 Description字段 长度超过了30字节，请更改!!");
                                return;
                            }
                            if (weight.ToString().Length > 8)
                            {
                                alert("第" + line_count + "个包裹的重量 值 超过了 8 位，请更改!!");
                                return;
                            }
                            if (height.ToString().Length > 8)
                            {
                                alert("第" + line_count + "个包裹的高度值超过了 8 位，请更改!!");
                                return;
                            }
                            if (length.ToString().Length > 8)
                            {
                                alert("第" + line_count + "个包裹的长度值超过了 8 位，请更改!!");
                                return;
                            }
                            if (package_value.ToString().Length > 8)
                            {
                                alert("第" + line_count + "个包裹的 包裹价值 长度超过了8位，请更改!!");
                                return;
                            }
                            if (width.ToString().Length > 8)
                            {
                                alert("第" + line_count + "个包裹的 宽度 长度超过了 8 位，请更改!!");
                                return;
                            }
                            if ((Hz2Py.Convert(comment)).Length > 16)
                            {
                                alert("第" + line_count + "个包裹的Purpose Of Shipment长度超过了24字节，请更改!!");
                                return;
                            }


                            string nowtime = DateTime.Now.ToString("yyyy-MM-dd");

                            Regex reg = new Regex(@"[0-9]{4}-[0-9]{2}-[0-9]{2}");

                            if (!reg.Match(delivery_time).Success)
                            {
                                alert("China-IPE,China-GPR 的发件时间格式必须为 YYYY-MM-DD，并且发件时间必须是明天以后，请从 PostNL首页下载模板！！");
                                return;
                            }

                            int k = (int)DateTime.Parse(delivery_time).DayOfWeek;

                            if (delivery_time.CompareTo(nowtime) == -1)
                            {
                                alert("China-IPE,China-GPR 的发件时间格式必须为 YYYY-MM-DD，并且发件时间必须是明天以后");
                                return;
                            }
                            else if (delivery_time.CompareTo(nowtime) == 0)
                            {
                                string nowminute = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
                                string temp = nowtime + " 11:30";

                                if (nowminute.CompareTo(temp) == 1)
                                {
                                    if (k == 5)
                                    {
                                        delivery_time = Convert.ToDateTime(delivery_time).AddDays(3).ToString("yyyy-MM-dd");
                                    }
                                }

                                delivery_time = Convert.ToDateTime(delivery_time).AddDays(1).ToString("yyyy-MM-dd");
                            }


                            if (delivery_time.CompareTo(DateTime.Now.AddDays(21).ToString("yyyy-MM-dd")) >= 0)
                            {
                                alert("取件时间不能离现在太远，最好不要超过 两个星期！！");
                                return;
                            }

                            if (k == 6)
                            {
                                delivery_time = Convert.ToDateTime(delivery_time).AddDays(2).ToString("yyyy-MM-dd");
                            }
                            else if (k == 0)
                            {
                                delivery_time = Convert.ToDateTime(delivery_time).AddDays(1).ToString("yyyy-MM-dd");
                            }




                            Application.Lock();
                            string orderNo = Application["packageNo"].ToString();
                            Application["packageNo"] = (int)Application["packageNo"] + 1;
                            Application.UnLock();

                            package.Auto_no = auto_no;
                            package.Order_no = "WA" + time.ToString("yyyyMMddHHmm") + orderNo.PadLeft(8, '0');
                            package.Name = Session["name"].ToString();
                            package.CollectionCompanyName = send_company;
                            package.CollectionContactName = send_name;
                            package.CollectionPhone = send_phone;
                            package.CollectionAddressLine = send_addressline;
                            package.CollectionTown = send_city;
                            package.CollectionPostCode = send_postcode;
                            package.CollectionCountry = "UK";
                            package.RecipientCompanyName = receive_company;
                            package.RecipientContactName = receive_name;
                            package.RecipientPhone = receive_phone;
                            package.RecipientAddressLine = receive_address_line;
                            package.RecipientTown = receive_city;
                            package.RecipeintPostCode = receive_postcode;
                            package.RecipientCountry = "China";
                            package.Shippingdate = delivery_time;
                            package.Shippingtype = delivery_way;

                            package.Shippingpurpose = comment;
                            package.PackageDescription = description;
                            package.PackageValue = Convert.ToSingle(package_value);
                            package.Insurance = Convert.ToSingle(insurance);
                            if (package.Shippingtype.ToLower().Contains("ollec"))
                                package.ServiceCode = "PF-GPR-Collection";
                            else
                                package.ServiceCode = "PF-GPR-Delivery";
                            package.Weight = Convert.ToSingle(weight);
                            package.Length = Convert.ToSingle(length);
                            package.Width = Convert.ToSingle(width);
                            package.Height = Convert.ToSingle(height);

                            package.Volumetric = (float)((package.Length * package.Width * package.Height) / 5000.0);

                            if (package.Weight >= package.Volumetric)
                            {
                                package.Chargeable = package.Weight;
                            }
                            else
                            {
                                package.Chargeable = package.Volumetric;
                            }

                            package.Pay_status = "unpay";

                            //此处Pay_before_discount设置为100，以后要计算价格


                            package.Pay_before_discount = new BatchQuoteDAO().getQuote(username, package.ServiceCode, package.Weight, package.Chargeable);// new Quote().getQuote("UK", "China", package.Weight, package.Chargeable, "PostNL", Session["name"].ToString());
                            package.Pay_before_discount += package.Insurance;
                            package.Discount = 0;

                            package.Pay_after_discount = package.Pay_before_discount;
                            package.Order_time = order.Order_time;
                            package.Less_pay = 0;
                            package.Is_delivery = 0;

                            order.Pay_before_discount += package.Pay_before_discount;


                            package_array.Add(package);

                        }


                        // 如果是 EMS
                        else if (receive_country.ToLower().Equals("china-ems"))
                        {
                            line_count++;

                            Application.Lock();
                            string orderNo = Application["packageNo"].ToString();
                            Application["packageNo"] = (int)Application["packageNo"] + 1;
                            Application.UnLock();

                            package.Auto_no = auto_no;
                            package.Order_no = "WA" + time.ToString("yyyyMMddHHmm") + orderNo.PadLeft(8, '0');
                            package.Name = Session["name"].ToString();
                            package.CollectionCompanyName = send_company;
                            package.CollectionContactName = send_name;
                            package.CollectionPhone = send_phone;
                            package.CollectionAddressLine = send_addressline;
                            package.CollectionTown = send_city;
                            package.CollectionPostCode = send_postcode;
                            package.CollectionCountry = "UK";
                            package.RecipientCompanyName = receive_company;
                            package.RecipientContactName = receive_name;
                            package.RecipientPhone = receive_phone;
                            package.RecipientAddressLine = receive_address_line;
                            package.RecipientTown = receive_city;
                            package.RecipeintPostCode = receive_postcode;
                            package.RecipientCountry = "China";
                            package.Shippingdate = delivery_time;
                            package.Shippingtype = delivery_way;

                            package.Shippingpurpose = comment;
                            package.PackageDescription = description;
                            package.PackageValue = Convert.ToSingle(package_value);
                            package.Insurance = Convert.ToSingle(insurance);
                            package.ServiceCode = "EMS";
                            package.Weight = Convert.ToSingle(weight);
                            package.Length = Convert.ToSingle(length);
                            package.Width = Convert.ToSingle(width);
                            package.Height = Convert.ToSingle(height);

                            package.Volumetric = (float)((package.Length * package.Width * package.Height) / 5000.0);

                            if (package.Weight >= package.Volumetric)
                            {
                                package.Chargeable = package.Weight;
                            }
                            else
                            {
                                package.Chargeable = package.Volumetric;
                            }

                            package.Pay_status = "unpay";

                            //此处Pay_before_discount设置为100，以后要计算价格

                            package.Pay_before_discount = new BatchQuoteDAO().getQuote(username, package.ServiceCode, package.Weight, package.Chargeable);// new Quote().getQuote("UK", "China", package.Weight, package.Chargeable, "PostNL", Session["name"].ToString());
                            package.Pay_before_discount += package.Insurance;
                            package.Discount = 0;

                            package.Pay_after_discount = package.Pay_before_discount;
                            package.Order_time = order.Order_time;
                            package.Less_pay = 0;
                            package.Is_delivery = 0;

                            order.Pay_before_discount += package.Pay_before_discount;


                            package_array.Add(package);
                        }
                        else
                        {
                            alert("收件国家必须是 China-NL、China-IPE、China-GPR 到 港澳台 也一样也是 China-NL、China-IPE、China-GPR ");
                            return;
                        }

                    }
                    

                }

                order.Discount = 0;
                order.Pay_after_discount = order.Pay_before_discount;
                order.Order_count = line_count;

                //确实有包裹
                if (line_count != 0)
                {
                    //添加订单的详细信息
                    for (int i = 0; i < package_array.Count; i++)
                    {
                        AutoOrderList temp_package = (AutoOrderList)package_array[i];
                        new AutoOrderListDAO().addAutoOrderList(temp_package);

                    }

                    //添加订单
                    new AutoOrderDAO().addAutoOrder(order);
                }

            }

            if (line_count == 0)
            {
                alert("Excel不能为空！！！");
            }
            else
            {
                Response.Redirect("../my-shopping-cart.aspx?flag=excel");
            }


        }


        /// <summary>
        /// 保存上传的文件
        /// </summary>
        /// <returns>返回文件的路径</returns>
        private string saveUploadFile()
        {
            intablename = "";

            string file = Path.GetFileName(this.upload_ems_excel.PostedFile.FileName);//用于保存到数据库中的上传文件URL路径
            int ij = file.LastIndexOf("."); //取得文件扩展名
            if (ij > 0)
            {
                string newext = file.Substring(ij).ToLower();//将文件扩展名转换为小写
                if (newext != ".xls")
                {
                    Response.Write("<script language='javascript'>alert('对不起,文件类型不符,不能上传!上传文件扩展必须为(.xls) ')</script>");
                    return "error";
                }
            }
            else
            {
                Response.Write("<script language='javascript'>alert('对不起,上传失败,找不到文件!')</script>");

            }

            intablename = Session["name"].ToString() + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls";
            string pathFile = Server.MapPath("~/views/excel-upload/" + intablename);

            this.upload_ems_excel.PostedFile.SaveAs(pathFile); //文件上传保存 
            return pathFile;

        }
    }
}