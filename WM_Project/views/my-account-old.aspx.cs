using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using WM_Project.control;
using WM_Project.logical.user;
using WM_Project.logical.common;

namespace WM_Project.views
{
    public partial class my_account_old : System.Web.UI.Page
    {

        /*全局变量部分*/
        public static User user = new User();

        public static int address_page_count = 0; //地址页数
        public static int address_record_count = 0; //地址记录条数
        public static int address_page_size = 16;    //地址每页显示的条数
        public static int address_page_now = 0;     //当前页

        public static DataTable tb_send;
        public static DataTable tb_receive;
        public static string name = "";
        public static string flag = "";

        public static ArrayList orders = new ArrayList();

        //分页所用变量
        public static int pageNow = 0;   //当前页
        public static int record_count = 0;  //记录总条数
        public static int page_count = 0;    //总页数
        public static int pageSize = 20;

        public static string start_time = "";
        public static string end_time = "";


        public static string message = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["name"] == null)
                {
                    alert("请先登录!");

                    login_first.Visible = true;
                    after_login.Visible = false;
                }
                else
                {

                    name = Session["name"].ToString();

                    string part = Request.QueryString["part"];
                    string action = Request.QueryString["action"];
                    string page = Request.QueryString["pageNow"];

                    if (part == null)
                    {
                        account_info.Style.Add("display", "block");
                        first.Visible = true;
                        personinfo.Visible = true;
                        //初始化用户信息
                        initPersonInfo(name);
                    }
                    else if (part.Equals("1"))
                    {
                        account_info.Style.Add("display", "block");
                        first.Visible = true;

                        if (action.Equals("personinfo"))
                        {
                            personinfo.Visible = true;
                            //初始化用户信息
                            initPersonInfo(name);
                        }
                        else if (action.Equals("password"))
                        {
                            password.Visible = true;

                        }

                    }
                    else if (part.Equals("2"))
                    {
                        addressInfo.Style.Add("display", "block");
                        second.Visible = true;
                        if (action.Equals("send"))
                        {
                            //初始化收件人、发件人信息列表
                            send.Visible = true;

                            if (page == null)
                            {
                                address_record_count = new AddressDAO().getSendAddressCount(name);
                                address_page_now = 1;
                                address_page_count = new AddressDAO().getAddresPageCount(address_record_count, address_page_size);
                                send_address.DataSource = createSendTable(name, address_page_now, address_page_size);
                                send_address.DataBind();
                                initNoticeInfo(send_address, "img_del");
                            }
                            else
                            {
                                address_page_now = Convert.ToInt32(page);
                                send_address.DataSource = createSendTable(name, address_page_now, address_page_size);
                                send_address.DataBind();
                                initNoticeInfo(send_address, "img_del");
                            }

                        }
                        else if (action.Equals("receive"))
                        {
                            receive.Visible = true;

                            if (page == null)
                            {
                                address_record_count = new AddressDAO().getReceiveAddressCount(name);
                                address_page_now = 1;
                                address_page_count = new AddressDAO().getAddresPageCount(address_record_count, address_page_size);
                                receive_address.DataSource = createReceiveTable(name, address_page_now, address_page_size);
                                receive_address.DataBind();
                                initNoticeInfo(receive_address, "img_del");
                            }
                            else
                            {
                                address_page_now = Convert.ToInt32(page);
                                receive_address.DataSource = createReceiveTable(name, address_page_now, address_page_size);
                                receive_address.DataBind();
                                initNoticeInfo(receive_address, "img_del");
                            }
                        }

                    }
                    else if (part.Equals("3"))
                    {
                        orderInfo.Style.Add("display", "block");
                        if (action == "time")
                        {
                            third.Visible = true;
                            query_by_time.Visible = true;
                            //默认显示前20条订单信息
                            if (page == null)
                            {
                                txt_from.Text = "";
                                txt_to.Text = "";
                                pageNow = 0;
                                record_count = 0;
                                page_count = 0;
                                orders = new OrderDAO().getOrders(Session["name"].ToString(), "success", pageSize);
                            }
                            else if (start_time == "")
                            {
                                pageNow = Convert.ToInt32(page);
                                orders = new OrderDAO().getOrders(Session["name"].ToString(), "success", pageSize, pageNow);
                            }
                            else if (start_time != "")
                            {
                                txt_from.Text = start_time;
                                txt_to.Text = end_time;
                                pageNow = Convert.ToInt32(page);
                                orders = new OrderDAO().getOrders(start_time, end_time, Session["name"].ToString(), "success", pageNow, pageSize);
                            }

                        }
                        else if (action == "order_number")
                        {
                            third.Visible = true;
                            query_by_order.Visible = true;
                            orders = new ArrayList();
                            message = "";
                        }

                    }
                    else if (part.Equals("4"))
                    {
                        chargeInfo.Style.Add("display", "block");
                        forth.Visible = true;
                    }
                    else if (part.Equals("5"))
                    {
                        labelInfo.Style.Add("display", "block");
                        fifth.Visible = true;
                    }
                }

            }
        }


        //////////////////////////////////////////////////////////////////////////
        //登陆的实现

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
                    Session["name"] = name;
                    Response.Redirect("../views/my-account-old.aspx");

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


        //////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////
        //第一部分实现代码
        /// <summary>
        /// 初始化用户信息
        /// </summary>
        /// <param name="name">用户名</param>
        public void initPersonInfo(string name)
        {
            user = new UserDAO().getUser(name);
            txt_username.Text = user.Name;
            txt_email.Text = user.Email;
            txt_recommendUser.Text = user.RecommandUser;
            txt_telephone.Text = user.Telephone;
            txt_website.Text = user.Website;
            txt_companyName.Text = user.CompanyName;
        }

        //修改用户信息的实现
        protected void btn_modify_Click(object sender, EventArgs e)
        {

            user.Telephone = txt_telephone.Text.ToString();
            user.Website = txt_website.Text.ToString();
            user.CompanyName = txt_companyName.Text.ToString();

            if (new UserDAO().updateUser(user))
            {
                txt_username.Text = user.Name;
                txt_email.Text = user.Email;
                txt_recommendUser.Text = user.RecommandUser;
                txt_telephone.Text = user.Telephone;
                txt_website.Text = user.Website;
                txt_companyName.Text = user.CompanyName;
                alert("修改成功！");
            }
        }



        //修改密码的实现
        protected void btn_moddify_password_Click(object sender, EventArgs e)
        {
            string oldpwd = Request.Form["txt_oldpassword"].ToString();
            string newpwd = Request.Form["txt_newpassword"].ToString();
            string name = Session["name"].ToString();

            if (new UserDAO().checkUser(name, oldpwd) == 1)
            {
                if (new UserDAO().resetPassword(Session["name"].ToString(), newpwd))
                {

                    alert("Change password success!");
                }
                else
                {
                    alert("修改失败！！");
                }
            }
            else
            {
                alert("Old password wrong!");
            }

        }


        //弹出提示信息
        public void alert(string message)
        {
            Response.Write(string.Format("<script language='javascript'>alert('{0}');</script>", message));
        }

        //////////////////////////////////////////////////////////////////////////
        //第二部分的实现

        /// <summary>
        /// 添加新的发件地址
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_addsendAddress_Click(object sender, EventArgs e)
        {
            send_part_edit_address.Visible = true;

            flag = "1";
            //显示编辑发件地址
            edit_addressInfo.Text = "编辑发件地址";
            init(1);
        }

        /// <summary>
        /// 添加收件地址
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_addreceiveAddress_Click(object sender, EventArgs e)
        {
            send_part_edit_address.Visible = true;

            flag = "2";

            edit_addressInfo.Text = "编辑收件地址";

            init(2);
        }


        //响应发件地址信息 DataList 列表中的事件
        protected void send_address_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName.Equals("edit"))
            {
                string addr_id = e.CommandArgument.ToString();

                for (int i = 0; i < tb_send.Rows.Count; i++)
                {
                    if (tb_send.Rows[i]["addr_id"].ToString().Equals(addr_id))
                    {
                        Address send = new Address();
                        send.User_name = Session["name"].ToString();
                        send.Addr_id = Convert.ToInt32(tb_send.Rows[i]["addr_id"].ToString());
                        send.Addr_contact = tb_send.Rows[i]["addr_contact"].ToString();
                        send.Company_name = tb_send.Rows[i]["company_name"].ToString();
                        send.Addr_type = "S";
                        send.Addr_line1 = tb_send.Rows[i]["addr_line1"].ToString();
                        send.Addr_line2 = tb_send.Rows[i]["addr_line2"].ToString();
                        send.Addr_line3 = tb_send.Rows[i]["addr_line3"].ToString();
                        send.City = tb_send.Rows[i]["city"].ToString();
                        send.Post_code = tb_send.Rows[i]["post_code"].ToString();
                        send.Country = tb_send.Rows[i]["country"].ToString();
                        send.Phone = tb_send.Rows[i]["phone"].ToString();
                        send.Email = tb_send.Rows[i]["email"].ToString();
                        send.Is_default = tb_send.Rows[i]["is_default"].ToString();

                        send_part_edit_address.Visible = true;
                        flag = "1";
                        edit_addressInfo.Text = "修改发件地址";
                        initAlterAddress(send);
                        return;

                    }
                }

            }
            else if (e.CommandName.Equals("del"))
            {
                string addr_id = e.CommandArgument.ToString();

                if (new AddressDAO().deleteAddress(Convert.ToInt32(addr_id)))
                {
                    address_page_now = 1;
                    address_record_count = new AddressDAO().getSendAddressCount(name);
                    send_address.DataSource = createSendTable(Session["name"].ToString(), address_page_now, address_page_size);
                    send_address.DataBind();
                    initNoticeInfo(send_address, "img_del");
                    alert("删除成功");
                }
                else
                {
                    alert("删除失败");
                }
            }
            else if (e.CommandName.Equals("set"))
            {
                int addr_id = Convert.ToInt32(e.CommandArgument.ToString());

                if (new AddressDAO().setDefaultAddress(addr_id, Session["name"].ToString()))
                {
                    address_page_now = 1;
                    address_record_count = new AddressDAO().getSendAddressCount(name);
                    send_address.DataSource = createSendTable(Session["name"].ToString(), address_page_now, address_page_size);
                    send_address.DataBind();
                    initNoticeInfo(send_address, "img_del");
                    alert("设置成功！");
                }
                else
                {
                    alert("设置失败！");
                }
            }
        }

        //响应收件地址信息 DataList 列表中的事件
        protected void receive_address_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName.Equals("edit"))
            {
                string addr_id = e.CommandArgument.ToString();

                for (int i = 0; i < tb_receive.Rows.Count; i++)
                {
                    if (tb_receive.Rows[i]["addr_id"].ToString().Equals(addr_id))
                    {
                        Address receive = new Address();
                        receive.Addr_id = Convert.ToInt32(tb_receive.Rows[i]["addr_id"].ToString());

                        receive.Is_default = tb_receive.Rows[i]["is_default"].ToString();

                        send_part_edit_address.Visible = true;
                        flag = "2";
                        edit_addressInfo.Text = "修改收件地址";
                        return;

                    }
                }

            }
            else if (e.CommandName.Equals("del"))
            {
                string addr_id = e.CommandArgument.ToString();

                if (new AddressDAO().deleteAddress(Convert.ToInt32(addr_id)))
                {
                    address_page_now = 1;
                    address_record_count = new AddressDAO().getReceiveAddressCount(name);
                    address_page_count = new AddressDAO().getAddresPageCount(address_record_count, address_page_size);
                    receive_address.DataSource = createReceiveTable(Session["name"].ToString(), address_page_now, address_page_size);
                    receive_address.DataBind();
                    initNoticeInfo(receive_address, "img_del");
                    alert("删除成功！");
                }

            }
            else if (e.CommandName.Equals("set"))
            {
                int addr_id = Convert.ToInt32(e.CommandArgument.ToString());

                if (new AddressDAO().setDefaultAddress(addr_id, Session["name"].ToString()))
                {
                    address_page_now = 1;
                    address_record_count = new AddressDAO().getReceiveAddressCount(name);
                    address_page_count = new AddressDAO().getAddresPageCount(address_record_count, address_page_size);
                    receive_address.DataSource = createReceiveTable(Session["name"].ToString(), address_page_now, address_page_size);
                    receive_address.DataBind();
                    initNoticeInfo(receive_address, "img_del");
                    alert("设置成功！");
                }
                else
                {
                    alert("设置失败！");
                }
            }
        }

        /// <summary>
        /// 创建发件人地址绑定表
        /// </summary>
        /// <param name="name">会员名</param>
        /// <returns></returns>
        private DataTable createSendTable(string name, int pageNow, int pageSize)
        {
            DataTable table = new DataTable();
            DataColumn dc = new DataColumn("addr_id", typeof(int));
            table.Columns.Add(dc);

            dc = new DataColumn("addressInfo", typeof(string));
            table.Columns.Add(dc);

            tb_send = new AddressDAO().getSendAddressTable(name, pageNow, pageSize);

            for (int i = 0; i < tb_send.Rows.Count; i++)
            {
                DataRow dr = table.NewRow();
                dr["addr_id"] = Convert.ToInt32(tb_send.Rows[i]["addr_id"].ToString());
                dr["addressInfo"] = tb_send.Rows[i]["addr_contact"].ToString() + tb_send.Rows[i]["country"].ToString() + tb_send.Rows[i]["city"].ToString() + tb_send.Rows[i]["addr_line3"].ToString() + tb_send.Rows[i]["addr_line2"].ToString() + tb_send.Rows[i]["addr_line1"].ToString() +
                                    tb_send.Rows[i]["company_name"].ToString() + tb_send.Rows[i]["phone"].ToString();

                table.Rows.Add(dr);
            }

            return table;
        }

        /// <summary>
        /// 创建收件人地址绑定表
        /// </summary>
        /// <param name="name">会员名</param>
        /// <returns></returns>
        private DataTable createReceiveTable(string name, int pageNow, int pageSize)
        {
            DataTable table = new DataTable();
            DataColumn dc = new DataColumn("addr_id", typeof(int));
            table.Columns.Add(dc);

            dc = new DataColumn("addressInfo", typeof(string));
            table.Columns.Add(dc);

            tb_receive = new AddressDAO().getReceiveAddressTable(name, pageNow, pageSize);

            for (int i = 0; i < tb_receive.Rows.Count; i++)
            {
                DataRow dr = table.NewRow();
                dr["addr_id"] = Convert.ToInt32(tb_receive.Rows[i]["addr_id"].ToString());
                dr["addressInfo"] = tb_receive.Rows[i]["addr_contact"].ToString() + tb_receive.Rows[i]["country"].ToString() + tb_receive.Rows[i]["city"].ToString() + tb_receive.Rows[i]["addr_line3"].ToString() + tb_receive.Rows[i]["addr_line2"].ToString() + tb_receive.Rows[i]["addr_line1"].ToString() +
                                    tb_receive.Rows[i]["company_name"].ToString() + tb_receive.Rows[i]["phone"].ToString();

                table.Rows.Add(dr);
            }


            return table;
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

        /// <summary>
        /// 保存会员所填写的新地址
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_save_Click(object sender, EventArgs e)
        {
            Address address = new Address();

            address.User_name = Session["name"].ToString();
            address.Company_name = txt_addr_company_name.Text;
            address.Addr_contact = txt_addr_contact.Text;
            address.Addr_line1 = txt_addr_line1.Text;
            address.Addr_line2 = txt_addr_line2.Text;
            address.Addr_line3 = txt_addr_line3.Text;
            address.City = txt_addr_city.Text;
            address.Post_code = txt_addr_postcode.Text;
            address.Country = txt_addr_country.Text;
            address.Phone = txt_addr_phone.Text;
            address.Email = txt_addr_email.Text;
            address.Time = DateTime.Now;

            if (ck_default.Checked == true)
            {
                address.Is_default = "1";
            }
            else
            {
                address.Is_default = "0";
            }

            if (flag.Equals("1"))
            {
                //编辑的为发件地址

                string addr_id = lb_addr_id.Text.ToString();

                // S代表发件地址
                address.Addr_type = "S";

                if (addr_id == "")
                {
                    if (new AddressDAO().addAddress(address))
                    {
                        address_page_now = 1;
                        address_record_count = new AddressDAO().getSendAddressCount(name);
                        send_address.DataSource = createSendTable(Session["name"].ToString(), address_page_now, address_page_size);
                        send_address.DataBind();
                        initNoticeInfo(send_address, "img_del");
                        send_part_edit_address.Visible = false;
                        alert("添加成功！");

                    }
                    else
                    {
                        alert("添加失败！");
                    }
                }
                else
                {
                    address.Addr_id = Convert.ToInt32(addr_id);

                    if (new AddressDAO().updateAddress(address))
                    {
                        address_page_now = 1;
                        address_record_count = new AddressDAO().getSendAddressCount(name);
                        send_address.DataSource = createSendTable(Session["name"].ToString(), address_page_now, address_page_size);
                        send_address.DataBind();
                        initNoticeInfo(send_address, "img_del");
                        send_part_edit_address.Visible = false;
                        alert("修改成功！");
                    }
                    else
                    {
                        alert("修改失败！");
                    }
                }

            }
            else if (flag.Equals("2"))
            {
                //编辑的为收件地址
                string adrr_id = lb_addr_id.Text.ToString();

                // R代表收件地址
                address.Addr_type = "R";

                if (adrr_id == "")
                {
                    if (new AddressDAO().addAddress(address))
                    {
                        address_page_now = 1;
                        address_record_count = new AddressDAO().getReceiveAddressCount(name);
                        address_page_count = new AddressDAO().getAddresPageCount(address_record_count, address_page_size);
                        receive_address.DataSource = createReceiveTable(Session["name"].ToString(), address_page_now, address_page_size);
                        receive_address.DataBind();
                        initNoticeInfo(receive_address, "img_del");
                        send_part_edit_address.Visible = false;
                        alert("添加成功！");

                    }
                    else
                    {
                        alert("添加失败！");
                    }
                }
                else
                {
                    address.Addr_id = Convert.ToInt32(adrr_id);

                    if (new AddressDAO().updateAddress(address))
                    {

                        address_page_now = 1;
                        address_record_count = new AddressDAO().getReceiveAddressCount(name);
                        address_page_count = new AddressDAO().getAddresPageCount(address_record_count, address_page_size);
                        receive_address.DataSource = createReceiveTable(Session["name"].ToString(), address_page_now, address_page_size);
                        receive_address.DataBind();
                        initNoticeInfo(receive_address, "img_del");
                        send_part_edit_address.Visible = false;
                        alert("修改成功！");
                    }
                    else
                    {
                        alert("修改失败！");
                    }
                }

            }

        }



        //初始化添加地址信息列表
        private void init(int flag)
        {

            lb_addr_id.Text = "";
            txt_addr_contact.Text = "";
            txt_companyName.Text = "";
            txt_addr_line1.Text = "";
            txt_addr_line2.Text = "";
            txt_addr_line3.Text = "";
            txt_addr_city.Text = "";
            txt_addr_postcode.Text = "";

            //发件国家为 UK
            if (flag == 1)
            {
                txt_addr_country.Text = "UK";
                txt_addr_country.Attributes.Add("ReadOnly", "true");
            }
            else
            {

            }


            txt_addr_phone.Text = "";
            txt_addr_email.Text = "";
        }

        /// <summary>
        /// 当用户修改发件地址信息时，初始化
        /// </summary>
        /// <param name="send">发件地址信息对象</param>
        private void initAlterAddress(Address address)
        {
            lb_addr_id.Text = address.Addr_id.ToString();
            txt_addr_contact.Text = address.Addr_contact;
            txt_companyName.Text = address.Company_name;
            txt_addr_line1.Text = address.Addr_line1;
            txt_addr_line2.Text = address.Addr_line2;
            txt_addr_line3.Text = address.Addr_line3;
            txt_addr_city.Text = address.City;
            txt_addr_postcode.Text = address.Post_code;
            txt_addr_country.Text = address.Country;
            txt_addr_phone.Text = address.Phone;
            txt_addr_email.Text = address.Email;

            if (address.Is_default.Equals("1"))
            {
                ck_default.Checked = true;
            }
            else
            {
                ck_default.Checked = false;
            }

        }




        //////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////
        //第三部分订单管理部分

        /// <summary>
        /// 订单查询的实现
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_query_Click(object sender, EventArgs e)
        {
            start_time = txt_from.Text.ToString();
            end_time = txt_to.Text.ToString();
            pageNow = 1;
            record_count = new OrderDAO().getRecordCount(start_time, end_time, Session["name"].ToString(), "success");
            page_count = new OrderDAO().getPageCount(record_count, pageSize);
            orders = new OrderDAO().getOrders(start_time, end_time, Session["name"].ToString(), "success", pageNow, pageSize);

        }

        /// <summary>
        /// 查询所有订单的实现
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_query_all_Click(object sender, EventArgs e)
        {
            txt_from.Text = start_time = "";
            txt_to.Text = end_time = "";
            record_count = new OrderDAO().getRecordCount(Session["name"].ToString(), "success");
            page_count = new OrderDAO().getPageCount(record_count, 20);
            pageNow = 1;
            orders = new OrderDAO().getOrders(Session["name"].ToString(), "success", pageSize);


        }


        /// <summary>
        /// 按订单好查找订单信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_query_by_order_number_Click(object sender, EventArgs e)
        {
            string orderNumbers = Request.Form["txt_order_number"];
            string[] order_number_array = orderNumbers.Split(',');

            orders = new ArrayList();

            for (int i = 0; i < order_number_array.Length; i++)
            {
                string order_number = order_number_array[i].Trim();

                Order order = new OrderDAO().getOrder(order_number);
                if (order.Order_number != null)
                {
                    orders.Add(order);
                }

            }
            if (orders.Count == 0)
            {
                message = "没有符合您查询条件的订单！！！";
            }
            pageNow = 0;
            page_count = 0;
            record_count = 0;
        }


        //下载选中的实现
        protected void btn_download_select_Click(object sender, EventArgs e)
        {
            string checks = Request["checkbox"];

            string[] ordernumbers = checks.Split(',');

            ArrayList order_array = new ArrayList();

            for (int i = 0; i < ordernumbers.Length; i++)
            {
                string order_number = ordernumbers[i];

                for (int k = 0; k < orders.Count; k++)
                {
                    Order order = (Order)orders[k];
                    if (order.Order_number.Equals(order_number))
                    {
                        order_array.Add(order);
                    }
                }
            }


            Session["orders"] = order_array;

            Response.Write("<script language='javascript'>window.open('../views/order-detail-info.aspx','_blank')</script>");

        }




        ///// <summary>
        ///// 创建绑定订单信息的数据表
        ///// </summary>
        ///// <param name="arrays">订单信息</param>
        ///// <returns>返回存放有订单信息的Table</returns>
        //private DataTable createTable(ArrayList arrays)
        //{
        //    DataTable table = new DataTable();
        //    DataColumn dc = new DataColumn("order_number", typeof(string));
        //    table.Columns.Add(dc);

        //    dc = new DataColumn("good_sender", typeof(string));
        //    table.Columns.Add(dc);

        //    dc = new DataColumn("good_receiver", typeof(string));
        //    table.Columns.Add(dc);

        //    dc = new DataColumn("good_count", typeof(string));
        //    table.Columns.Add(dc);

        //    dc = new DataColumn("freight", typeof(float));
        //    table.Columns.Add(dc);

        //    dc = new DataColumn("postway", typeof(string));
        //    table.Columns.Add(dc);

        //    dc = new DataColumn("order_time", typeof(string));
        //    table.Columns.Add(dc);

        //    for (int i = 0; i < arrays.Count; i++)
        //    {
        //        Order order = (Order)arrays[i];

        //        DataRow dr = table.NewRow();
        //        dr["order_number"] = order.Order_number;
        //        dr["good_sender"] = order.Post_way;
        //        dr["good_receiver"] = order.Pay_way;
        //        dr["good_count"] = order.Wp_track_no;
        //        dr["freight"] = order.Post_way;
        //        dr["postway"] = order.Post_way;
        //        dr["order_time"] = order.Order_time.ToShortDateString();

        //        table.Rows.Add(dr);
        //    }

        //    return table;
        //}







    }
}