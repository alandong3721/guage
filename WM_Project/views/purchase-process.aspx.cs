using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using WM_Project.control;
using WM_Project.logical.user;
using WM_Project.logical.common;


namespace WM_Project.views
{
    public partial class purchase_process : System.Web.UI.Page
    {
        public ArrayList package_array = new ArrayList();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["package_array"] != null&&Session["name"]!=null)
                {
                    // 绑定取件时间
                    //collection_time_dropdown.DataSource = createCollectionTimeTable();
                    //collection_time_dropdown.DataTextField = "note";
                    //collection_time_dropdown.DataValueField = "time";
                    //collection_time_dropdown.DataBind();

                    // 初始化包裹信息
                    package_array = (ArrayList)Session["package_array"];

                    // 绑定发件地址
                    send_addr_dropdown_list.DataSource = createSendAddrTable(Session["name"].ToString());
                    send_addr_dropdown_list.DataTextField = "address";
                    send_addr_dropdown_list.DataValueField = "addr_id";
                    send_addr_dropdown_list.DataBind();

                    //初始化发件地址
                    initSendAddrNull();

                    //绑定收件地址
                    receive_addr_dropdown_list.DataSource = createReceiveAddrTable(Session["name"].ToString());
                    receive_addr_dropdown_list.DataTextField = "address";
                    receive_addr_dropdown_list.DataValueField = "addr_id";
                    receive_addr_dropdown_list.DataBind();

                    //初始化收件地址
                    initReceiveAddrNull();

                    if (Session["postname"].ToString().Contains("PF"))
                    {
                        parcelforce.Visible = true;
                    }
                    
                }
                else
                {
                    Response.Redirect("user-login.aspx");
                }

            }
        }


        /// <summary>
        /// 创建绑定取件时间表
        /// </summary>
        /// <returns></returns>
        private DataTable createCollectionTimeTable()
        {
            DataTable table = new DataTable();

            DataColumn dc = new DataColumn("time",typeof(string));
            table.Columns.Add(dc);

            dc = new DataColumn("note", typeof(string));
            table.Columns.Add(dc);

            int k = (int)DateTime.Parse(DateTime.Now.ToString()).DayOfWeek;

            if (k == 0)
            {
                DataRow dr = table.NewRow();
                dr["note"] =DateTime.Now.AddDays(1).ToString("yyyy-MM-dd");
                dr["time"] = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd");
                table.Rows.Add(dr);

                dr = table.NewRow();
                dr["note"] = DateTime.Now.AddDays(2).ToString("yyyy-MM-dd");
                dr["time"] = DateTime.Now.AddDays(2).ToString("yyyy-MM-dd");
                table.Rows.Add(dr);

            }
            else if(k==1)
            {
                DataRow dr = table.NewRow();
                dr["time"] = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd");
                dr["note"] = "上门取件(下个工作日)" + DateTime.Now.AddDays(1).ToString("yyyy-MM-dd") + "星期二";
                table.Rows.Add(dr);

                dr = table.NewRow();
                dr["time"] = DateTime.Now.AddDays(2).ToString("yyyy-MM-dd");
                dr["note"] = "上门取件(第二个工作日)" + DateTime.Now.AddDays(2).ToString("yyyy-MM-dd") + "星期三";
                table.Rows.Add(dr);

                
            }
            else if(k==2)
            {
                DataRow dr = table.NewRow();
                dr["time"] = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd");
                dr["note"] = "上门取件(下个工作日)" + DateTime.Now.AddDays(1).ToString("yyyy-MM-dd") + "星期三";
                table.Rows.Add(dr);

                dr = table.NewRow();
                dr["time"] = DateTime.Now.AddDays(2).ToString("yyyy-MM-dd");
                dr["note"] = "上门取件(第二个工作日)" + DateTime.Now.AddDays(2).ToString("yyyy-MM-dd") + "星期四";
                table.Rows.Add(dr);

                
            }
            else if (k == 3)
            {
                DataRow dr = table.NewRow();
                dr["time"] = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd");
                dr["note"] = "上门取件(下个工作日)" + DateTime.Now.AddDays(1).ToString("yyyy-MM-dd") + "星期四";
                table.Rows.Add(dr);

                dr = table.NewRow();
                dr["time"] = DateTime.Now.AddDays(2).ToString("yyyy-MM-dd");
                dr["note"] = "上门取件(第二个工作日)" + DateTime.Now.AddDays(2).ToString("yyyy-MM-dd") + "星期五";
                table.Rows.Add(dr);
              
            }
            else if (k == 4)
            {
                DataRow dr = table.NewRow();
                dr["time"] = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd");
                dr["note"] = "上门取件(下个工作日)" + DateTime.Now.AddDays(1).ToString("yyyy-MM-dd") + "星期五";
                table.Rows.Add(dr);

                dr = table.NewRow();
                dr["time"] = DateTime.Now.AddDays(4).ToString("yyyy-MM-dd");
                dr["note"] = "上门取件(第二个工作日)" + DateTime.Now.AddDays(4).ToString("yyyy-MM-dd") + "星期一";
                table.Rows.Add(dr);

            }
            else if (k == 5)
            {
                DataRow dr = table.NewRow();
                dr["time"] = DateTime.Now.AddDays(3).ToString("yyyy-MM-dd");
                dr["note"] = "上门取件(下个工作日)" + DateTime.Now.AddDays(3).ToString("yyyy-MM-dd") + "星期一";
                table.Rows.Add(dr);

                dr = table.NewRow();
                dr["time"] = DateTime.Now.AddDays(4).ToString("yyyy-MM-dd");
                dr["note"] = "上门取件(第二个工作日)" + DateTime.Now.AddDays(4).ToString("yyyy-MM-dd") + "星期二";
                table.Rows.Add(dr);
  
            }
            else if (k == 6)
            {
                DataRow dr = table.NewRow();
                dr["time"] = DateTime.Now.AddDays(2).ToString("yyyy-MM-dd");
                dr["note"] = "上门取件(下个工作日)" + DateTime.Now.AddDays(2).ToString("yyyy-MM-dd") + "星期一";
                table.Rows.Add(dr);

                dr = table.NewRow();
                dr["time"] = DateTime.Now.AddDays(3).ToString("yyyy-MM-dd");
                dr["note"] = "上门取件(第二个工作日)" + DateTime.Now.AddDays(3).ToString("yyyy-MM-dd") + "星期二";
                table.Rows.Add(dr);

            }

            return table;
        }


       

        /// <summary>
        /// 从发件人地址簿中选择地址的实现
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void send_addr_dropdown_list_SelectedIndexChanged(object sender, EventArgs e)
        {
            string addr = send_addr_dropdown_list.SelectedValue;
            if (addr == "-1")
            {
                initSendAddrNull();
            }
            else
            {
                int addr_id = Convert.ToInt32(addr);
                Address address = new AddressDAO().getAddress(addr_id);
                initSendAddr(address);
            }
        }

        /// <summary>
        /// 收件人下拉列表响应事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void receive_addr_dropdown_list_SelectedIndexChanged(object sender, EventArgs e)
        {
            string addr = receive_addr_dropdown_list.SelectedValue;
            if (addr == "-1")
            {
                initReceiveAddrNull();
            }
            else
            {
                int addr_id = Convert.ToInt32(addr);
                Address address = new AddressDAO().getAddress(addr_id);
                initReceiveAddr(address);
            }
        }
        /// <summary>
        /// 创建发件人地址绑定表
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        private DataTable createSendAddrTable(string name)
        {
            DataTable table = new DataTable();

            DataColumn dc = new DataColumn("address",typeof(string));
            table.Columns.Add(dc);

            dc = new DataColumn("addr_id", typeof(int));
            table.Columns.Add(dc);

            DataTable addr_table = new AddressDAO().getSendAddressTable(name);
            
            DataRow dr = table.NewRow();
            dr["addr_id"] = -1;
            dr["address"] = "从地址簿中选择地址";
            table.Rows.Add(dr);


            for (int i = 0; i < addr_table.Rows.Count; i++)
            {
                dr = table.NewRow();
                dr["addr_id"] = addr_table.Rows[i]["addr_id"];
                dr["address"] = addr_table.Rows[i]["addr_contact"].ToString() + " " + addr_table.Rows[i]["addr_line1"] + addr_table.Rows[i]["addr_line2"] + addr_table.Rows[i]["addr_line3"] + " " + addr_table.Rows[i]["city"] + " " + addr_table.Rows[i]["post_code"] + addr_table.Rows[i]["country"] + " " + addr_table.Rows[i]["phone"];

                table.Rows.Add(dr);
            }

            return table;
        }

        /// <summary>
        /// 创建收件人地址绑定表
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        private DataTable createReceiveAddrTable(string name)
        {
            DataTable table = new DataTable();

            DataColumn dc = new DataColumn("address", typeof(string));
            table.Columns.Add(dc);

            dc = new DataColumn("addr_id", typeof(int));
            table.Columns.Add(dc);

            DataTable addr_table = new AddressDAO().getReceiveAddressTable(name);

            DataRow dr = table.NewRow();
            dr["addr_id"] = -1;
            dr["address"] = "从地址簿中选择地址";
            table.Rows.Add(dr);


            for (int i = 0; i < addr_table.Rows.Count; i++)
            {
                dr = table.NewRow();
                dr["addr_id"] = addr_table.Rows[i]["addr_id"];
                dr["address"] = addr_table.Rows[i]["addr_contact"].ToString() + " " + addr_table.Rows[i]["addr_line1"] + addr_table.Rows[i]["addr_line2"] + addr_table.Rows[i]["addr_line3"] + " " + addr_table.Rows[i]["city"] + " " + addr_table.Rows[i]["post_code"] + addr_table.Rows[i]["country"] + " " + addr_table.Rows[i]["phone"];

                table.Rows.Add(dr);
            }

            return table;
        }

        private void initSendAddr(Address address)
        {
            txt_send_addr_contact.Text = address.Addr_contact;
            txt_send_addr_company.Text = address.Company_name;
            txt_send_addr_line1.Text = address.Addr_line1;
            txt_send_addr_line2.Text = address.Addr_line2;
            txt_send_addr_line3.Text = address.Addr_line3;
            txt_send_addr_city.Text = address.City;
            txt_send_addr_postcode.Text = address.Post_code;
            txt_send_addr_country.Text = "UK";
            txt_send_addr_phone.Text = address.Phone;
            txt_send_addr_email.Text = address.Email;
        }
        private void initSendAddrNull()
        {
            txt_send_addr_contact.Text = "";
            txt_send_addr_company.Text = "";
            txt_send_addr_line1.Text = "";
            txt_send_addr_line2.Text = "";
            txt_send_addr_line3.Text = "";
            txt_send_addr_city.Text = "";
            txt_send_addr_postcode.Text = "";
            txt_send_addr_country.Text = "UK";
            txt_send_addr_phone.Text = "";
            txt_send_addr_email.Text = "";
        }

        private void initReceiveAddr(Address address)
        {
            txt_receive_addr_contact.Text = address.Addr_contact;
            txt_receive_addr_company.Text = address.Company_name;
            txt_receive_addr_line1.Text = address.Addr_line1;
            txt_receive_addr_line2.Text = address.Addr_line2;
            txt_receive_addr_line3.Text = address.Addr_line3;
            txt_receive_addr_city.Text = address.City;
            txt_receive_addr_postcode.Text = address.Post_code;
            txt_receive_addr_country.Text = Session["to"].ToString();
            txt_receive_addr_phone.Text = address.Phone;
            txt_receive_addr_email.Text = address.Email;
        }

        private void initReceiveAddrNull()
        {
            txt_receive_addr_contact.Text = "";
            txt_receive_addr_company.Text = "";
            txt_receive_addr_line1.Text = "";
            txt_receive_addr_line2.Text = "";
            txt_receive_addr_line3.Text = "";
            txt_receive_addr_city.Text = "";
            txt_receive_addr_postcode.Text = "";
            txt_receive_addr_country.Text = Session["to"].ToString();
            txt_receive_addr_phone.Text = "";
            txt_receive_addr_email.Text = "";
        }

        /// <summary>
        /// 去购物车结算
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_step_two_Click(object sender, EventArgs e)
        {
            
            string insurance = Request.Form["select_insurance"];
            string delivery_time = Request.Form["collection_time"];

            //获取包裹信息
            ArrayList packages = new ArrayList();
            string description = Request.Form["description"];
            string values = Request.Form["package_value"];
        
            string[] description_array = description.Split(',');
            string[] value_array = values.Split(',');

            int j = 0;
            string destination = Session["to"].ToString();
            string postway = Session["postname"].ToString().Trim();

            string receive_company = txt_receive_addr_company.Text.Replace("'","");
            string receive_name = txt_receive_addr_contact.Text.Replace("'","");
            string receive_address_line = txt_receive_addr_line1.Text.Replace("'","") + txt_receive_addr_line2.Text.Replace("'","") + txt_receive_addr_line3.Text.Replace("'","");
            string receive_city = txt_receive_addr_city.Text.Replace("'","");
            string receive_postcode = txt_receive_addr_postcode.Text.Replace("'","");
            string receive_phone = txt_receive_addr_phone.Text.Replace("'","");

            string send_company = txt_send_addr_company.Text.Replace("'","");
            string send_name = txt_send_addr_contact.Text.Replace("'","");
            string send_addressline = txt_send_addr_line1.Text.Replace("'","") + txt_send_addr_line2.Text.Replace("'","") + txt_send_addr_line3.Text.Replace("'","");
            string send_city = txt_send_addr_city.Text.Replace("'","");
            string send_postcode = txt_send_addr_postcode.Text.Replace("'","");
            string send_phone = txt_send_addr_phone.Text.Replace("'","");

            // 判断
            if (receive_addr.Checked == true && receive_addr_dropdown_list.SelectedValue=="-1")
            {
                Address address = new Address();

                address.User_name = Session["name"].ToString();
                address.Addr_contact = receive_name;
                address.Company_name = receive_company;
                address.City = receive_city;
                address.Addr_line1 = txt_receive_addr_line1.Text.Replace("'", "");
                address.Addr_line2 = txt_receive_addr_line2.Text.Replace("'", "");
                address.Addr_line3 = txt_receive_addr_line3.Text.Replace("'", "");
                address.Email = txt_receive_addr_email.Text.Replace("'", "");
                address.Phone = receive_phone.Replace("'","");
                address.Post_code = receive_postcode.Replace("'", "");
                address.Country = txt_receive_addr_country.Text;
                address.Is_default = "0";
                address.Time = DateTime.Now;
                address.Addr_type = "R";

                //向地址簿中添加地址
                new AddressDAO().addAddress(address);

            }

            if (send_addr.Checked == true && send_addr_dropdown_list.SelectedValue == "-1")
            {
                Address address = new Address();

                address.User_name = Session["name"].ToString();
                address.Company_name = send_company.Replace("'", "");
                address.Addr_contact = send_name.Replace("'", "");
                address.City = send_city.Replace("'", "");
                address.Addr_line1 = txt_send_addr_line1.Text.Replace("'", "");
                address.Addr_line2 = txt_send_addr_line2.Text.Replace("'", "");
                address.Addr_line3 = txt_send_addr_line3.Text.Replace("'", "");
                address.Email = txt_send_addr_email.Text.Replace("'", "");
                address.Post_code = send_postcode.Replace("'", "");
                address.Country = txt_send_addr_country.Text.Replace("'","");
                address.Phone = send_phone.Replace("'", "");

                address.Addr_type = "S";
                address.Time = DateTime.Now;
                address.Is_default = "0";
                //添加发件地址
                new AddressDAO().addAddress(address);
            }

            if(postway.ToLower()!="ems"&&postway.ToLower()!="postnl")
            {

                {
                    receive_company = receive_company.Replace("。", "");
                    receive_name = receive_name.Replace("。", "");
                    receive_address_line = receive_address_line.Replace("。", "");
                    receive_city = receive_city.Replace("。", "");
                    receive_postcode = receive_postcode.Replace("。", "");
                    receive_phone = send_phone.Replace("。", "");

                    send_company = send_company.Replace("。", "");
                    send_name = send_name.Replace("。", "");
                    send_addressline = send_addressline.Replace("。", "");
                    send_city = send_city.Replace("。", "");
                    send_postcode = send_postcode.Replace("。", "");
                    send_phone = send_phone.Replace("。", "");

                    receive_company = receive_company.Replace("（", "");
                    receive_name = receive_name.Replace("（", "");
                    receive_address_line = receive_address_line.Replace("（", "");
                    receive_city = receive_city.Replace("（", "");
                    receive_postcode = receive_postcode.Replace("（", "");
                    receive_phone = send_phone.Replace("（", "");
                    receive_company = receive_company.Replace("）", "");
                    receive_name = receive_name.Replace("）", "");
                    receive_address_line = receive_address_line.Replace("）", "");
                    receive_city = receive_city.Replace("）", "");
                    receive_postcode = receive_postcode.Replace("）", "");
                    receive_phone = send_phone.Replace("）", "");


                    send_company = send_company.Replace("（", "");
                    send_name = send_name.Replace("（", "");
                    send_addressline = send_addressline.Replace("（", "");
                    send_city = send_city.Replace("（", "");
                    send_postcode = send_postcode.Replace("（", "");
                    send_phone = send_phone.Replace("（", "");
                    send_company = send_company.Replace("）", "");
                    send_name = send_name.Replace("）", "");
                    send_addressline = send_addressline.Replace("）", "");
                    send_city = send_city.Replace("）", "");
                    send_postcode = send_postcode.Replace("）", "");
                    send_phone = send_phone.Replace("）", "");

                    receive_company = receive_company.Replace("-", "");
                    receive_name = receive_name.Replace("-", "");
                    receive_address_line = receive_address_line.Replace("-", "");
                    receive_city = receive_city.Replace("-", "");
                    receive_postcode = receive_postcode.Replace("-", "");
                   
                    receive_phone = receive_phone.Replace("-", "");
                    receive_phone = receive_phone.Replace("-", "");
                    receive_phone = receive_phone.Replace("—", "");

                    send_company = send_company.Replace("-", "");
                    send_name = send_name.Replace("-", "");
                    send_addressline = send_addressline.Replace("-", "");
                    send_city = send_city.Replace("-", "");
                    send_postcode = send_postcode.Replace("-", "");

                    send_phone = send_phone.Replace("-", "");
                    send_phone = send_phone.Replace("-", "");
                    send_phone = send_phone.Replace("—", "");
                    
                    receive_company = receive_company.Replace("—", "");
                    receive_name = receive_name.Replace("—", "");
                    receive_address_line = receive_address_line.Replace("—", "");
                    receive_city = receive_city.Replace("—", "");
                    receive_postcode = receive_postcode.Replace("—", "");
                   

                    send_company = send_company.Replace("—", "");
                    send_name = send_name.Replace("—", "");
                    send_addressline = send_addressline.Replace("—", "");
                    send_city = send_city.Replace("—", "");
                    send_postcode = send_postcode.Replace("—", "");
                   
                    description = description.Replace("—", "");



                  
                    receive_company = receive_company.Replace("'", "");
                    receive_name = receive_name.Replace("'", "");
                    receive_address_line = receive_address_line.Replace("'", "");
                    receive_city = receive_city.Replace("'", "");
                    receive_postcode = receive_postcode.Replace("'", "");
                    receive_phone = receive_phone.Replace("'", "");

                    send_company = send_company.Replace("'", "");
                    send_name = send_name.Replace("'", "");
                    send_addressline = send_addressline.Replace("'", "");
                    send_city = send_city.Replace("'", "");
                    send_postcode = send_postcode.Replace("'", "");
                    send_phone = send_phone.Replace("'", "");
                    description = description.Replace("'", "");

                }





                if (( PinYinHelpers.ToPinYin(send_company)).Length > 24)
                {
                    alert("发件公司英文名长度或中文转换为拼音后长度超过了24个字符，请更改!!");
                    return;
                }
                if (( PinYinHelpers.ToPinYin(send_name)).Length > 24)
                {
                    alert("发件人英文名长度或者中文名转化为拼音后超过了24字符，请更改!!");
                    return;
                }
                if (( PinYinHelpers.ToPinYin(send_phone)).Length > 15)
                {
                    alert("发件人电话长度超过了15字符，ParcelForce 不能处理，请缩短!!");
                    return;
                }
                if (( PinYinHelpers.ToPinYin(send_addressline)).Length > 67)
                {
                    alert("英文发件地址或者中文收件地址转化为拼音后长度超过了67字节，ParcelForce 不能处理，请缩短!!");
                    return;
                }
                if (( PinYinHelpers.ToPinYin(send_city)).Length > 24)
                {
                    alert("发件 City 英文长度或中文转换为拼音后长度超过了24字符，ParcelForce 不能处理，请缩短!!");
                    return;
                }
                if (( PinYinHelpers.ToPinYin(send_postcode)).Length > 16)
                {
                    alert("第个包裹的发件邮编长度超过了16字符，ParcelForce 不能处理，请缩短!!");
                    return;
                }


                if (( PinYinHelpers.ToPinYin(receive_company)).Length > 67)
                {
                    alert("抱歉，英文收件地址长度或者中文收件地址转化为拼音后长度超过66个字符，ParcelForce 不能处理，请缩短地址，请更改!!");
                    return;
                }
                if (( PinYinHelpers.ToPinYin(receive_name)).Length > 24)
                {
                    alert("发件人英文名长度或者中文名转化为拼音后超过了24字符，请更改!!");
                    return;
                }
                if (( PinYinHelpers.ToPinYin(receive_phone)).Length > 15)
                {
                    alert("收件人电话长度超过了15字符，ParcelForce 不能处理，请缩短!!");
                    return;
                }
                if (( PinYinHelpers.ToPinYin(receive_address_line)).Length > 67)
                {
                    alert("英文收件地址或者中文收件地址转化为拼音后长度超过了67字节，ParcelForce 不能处理，请缩短!!");
                    return;
                }
                if (( PinYinHelpers.ToPinYin(receive_city)).Length > 24)
                {
                    alert("收件人 City 长度超过了24个字符，ParcelForce 不能处理，请缩短!!");
                    return;
                }
                if(receive_postcode.Length!=6)
                {
                    alert("收件人 邮编 有误，请修改 ！！");
                    return;
                }



                receive_company =  PinYinHelpers.ToPinYin(receive_company);
                receive_name =  PinYinHelpers.ToPinYin(receive_name);
                receive_address_line =  PinYinHelpers.ToPinYin(receive_address_line);
                receive_city =  PinYinHelpers.ToPinYin(receive_city);
                receive_postcode =  PinYinHelpers.ToPinYin(receive_postcode);
                receive_phone =  PinYinHelpers.ToPinYin(receive_phone);

                send_company =  PinYinHelpers.ToPinYin(send_company);
                send_name =  PinYinHelpers.ToPinYin(send_name);
                send_addressline =  PinYinHelpers.ToPinYin(send_addressline);
                send_city =  PinYinHelpers.ToPinYin(send_city);
                send_postcode =  PinYinHelpers.ToPinYin(send_postcode);
                send_phone =  PinYinHelpers.ToPinYin(send_phone);
                

            }


            ArrayList good_arrays = (ArrayList)Session["package_array"];

            for (int i = 0; i < good_arrays.Count; i++)
            {
                PackageMeasure good = (PackageMeasure)good_arrays[i];

                for (int k = 0; k < good.Count; k++)
                {
                    Package package = new Package();
                    package.Name = Session["name"].ToString();
                    package.Description = description_array[j];
                    package.Package_value = Convert.ToSingle(value_array[j]);
                    package.Weight = good.Weight;
                    package.Height = good.Height;
                    package.Length = good.Length;
                    package.Width = good.Width;
                    package.Pay = new InterFaceQuote().getQuote(package.Name, destination, good.Weight, good.Length, good.Width, good.Height, postway);
                    package.Departure = "UK";
                    package.Destination = destination;

                    if(postway.ToLower()=="postnl")
                    {
                        if (package.Description.Contains("推车") || package.Description.Contains("trolly") || package.Description.Contains("坐椅") )
                        {
                            package.Volumetric = package.Length * package.Width * package.Height / 6000.0f;
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
                    }
                    else
                    {
                        package.Volumetric = (float)((package.Length * package.Width * package.Height) / 5000.0);

                        if (package.Weight >= package.Volumetric)
                        {
                            package.Chargeable = package.Weight;
                        }
                        else
                        {
                            package.Chargeable = package.Volumetric;
                        }

                    }

                    package.Post_way = postway;
                    j++;
                    packages.Add(package);
                }
            }

            //处理订单
            Order order = new Order();
            

            Application.Lock();
            string interfaceOrderNo = Application["orderNo"].ToString();
            Application["orderNo"] = (int)Application["orderNo"] + 1;
            Application.UnLock();

            DateTime time = DateTime.Now;
            string order_number = "WM" + time.ToString("yyMMddHHmm") + interfaceOrderNo.PadLeft(8, '0');
            
            order.Order_number = order_number;
            order.Name = Session["name"].ToString();

            order.CollectionContactName = send_name;
            order.CollectionCompanyName = send_company;
            order.CollectionPhone = send_phone;
            order.CollectionAddressLine = send_addressline;
            order.CollectionTown = send_city;
            order.CollectionPostCode = send_postcode;
            order.CollectionCountry = "UK";

            order.RecipientCompanyName = receive_company;
            order.RecipientContactName = receive_name;
            order.RecipientAddressLine = receive_address_line;
            order.RecipientCountry = Session["to"].ToString();
            order.RecipientPhone = receive_phone;
            order.RecipientPostCode = receive_postcode;
            order.RecipientTown = receive_city;

            if (Session["delivery_way"] == null)
            {
                order.Delivery_way = "Collection";
            }
            else
            {
                order.Delivery_way = Session["delivery_way"].ToString();
            }

            order.Delivery_date = delivery_time;

            order.Insurance = Convert.ToSingle(insurance);

            order.Post_way = Session["postname"].ToString();
            order.Quantity = packages.Count;
            order.Order_time = time;
            order.Is_pay = "unpay";
            order.Is_show = "true";
            order.Wp_track_no = "";

            // 向数据库中添加包裹
            for (int i = 0; i < packages.Count; i++)
            {
                Package temp_package = (Package)packages[i];

                Application.Lock();
                string wm_track_no = Application["packageNo"].ToString();
                Application["packageNo"] = (int)Application["packageNo"] + 1;
                Application.UnLock();

                temp_package.Wp_track_no ="WP" + DateTime.Now.ToString("yyMMddHHmm") + wm_track_no.PadLeft(8, '0');
                temp_package.Order_number = order.Order_number;
                temp_package.Name = order.Name;
                temp_package.Is_pay = "unpay";

                order.Weight += temp_package.Weight;
                order.Pay_after_discount += temp_package.Pay;
                
                if (order.Wp_track_no != "")
                {
                    order.Wp_track_no = order.Wp_track_no + "," + temp_package.Wp_track_no;
                }
                else
                {
                    order.Wp_track_no = temp_package.Wp_track_no;
                }

                new PackageDAO().addPackage(temp_package);
                

            }

            order.Pay_before_discount = order.Pay_after_discount;
            order.Discount = 0;

            new OrderDAO().addOrder(order);



            Response.Redirect("my-shopping-cart.aspx?flag=interface");

        }


        private void alert(string message)
        {
            Response.Write(string.Format("<script language='javascript'>alert('{0}');</script>", message));
        }


        /// <summary>
        /// 将中文地址转换为拼音
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_to_pinyin_Click(object sender, EventArgs e)
        {

            txt_receive_addr_contact.Text = PinYinHelpers.ToPinYin(replaceChar(txt_receive_addr_contact.Text));
            txt_receive_addr_contact.Text = PinYinHelpers.ToPinYin(replaceChar(txt_receive_addr_contact.Text));
            txt_receive_addr_company.Text =  PinYinHelpers.ToPinYin(replaceChar(txt_receive_addr_company.Text));
            txt_receive_addr_line1.Text =  PinYinHelpers.ToPinYin(replaceChar(txt_receive_addr_line1.Text));
            txt_receive_addr_line2.Text =  PinYinHelpers.ToPinYin(replaceChar(txt_receive_addr_line2.Text));
            txt_receive_addr_line3.Text =  PinYinHelpers.ToPinYin(replaceChar(txt_receive_addr_line3.Text));
            txt_receive_addr_city.Text =  PinYinHelpers.ToPinYin(replaceChar(txt_receive_addr_city.Text));
            txt_receive_addr_postcode.Text =  PinYinHelpers.ToPinYin(replaceChar(txt_receive_addr_postcode.Text));
            txt_receive_addr_country.Text =  PinYinHelpers.ToPinYin(replaceChar(txt_receive_addr_country.Text));
            txt_receive_addr_phone.Text =  PinYinHelpers.ToPinYin(replaceChar(txt_receive_addr_phone.Text));
            txt_receive_addr_email.Text =  PinYinHelpers.ToPinYin(replaceChar(txt_receive_addr_email.Text));
        }

        /// <summary>
        /// 替换字符串中的部分中文字符
        /// </summary>
        /// <param name="oldstr">原来的字符串</param>
        /// <returns></returns>
        private string replaceChar(string oldstr)
        {
            string newstr = "";

            newstr = oldstr.Replace("（", "(");
            newstr = newstr.Replace("）", ")");
            newstr = newstr.Replace("。", "");
            newstr = newstr.Replace("！", "");
            newstr = newstr.Replace("—", "");
            newstr = newstr.Replace("，", "");

            return newstr;
        }
        
    
    }
}