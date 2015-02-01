using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using WM_Project.control;
using WM_Project.logical.common;
using WM_Project.logical.user;

namespace WM_Project.views.user_frame
{
    public partial class send_address : System.Web.UI.Page
    {
        public static int address_page_count = 0; //地址页数
        public static int address_record_count = 0; //地址记录条数
        public static int address_page_size = 16;    //地址每页显示的条数
        public static int address_page_now = 0;     //当前页

        public static DataTable tb_send = new DataTable();

        public static string name = "";
        public static string flag = "";     //标志是修改地址信息还是添加地址信息

        protected void Page_Load(object sender, EventArgs e)
        {
            Session["name"] = "yangwang";

            if (Session["name"] == null)
            {
                Response.Redirect("~/views/exception/error-page.aspx");
            }
            else
            {
                name = Session["name"].ToString();
                if (!IsPostBack)
                {
                    string page = Request.QueryString["pageNow"];
                    if (page == null)
                    {
                        address_record_count = new AddressDAO().getSendAddressCount(name);
                        address_page_now = 1;
                        address_page_count = new AddressDAO().getAddresPageCount(address_record_count, address_page_size);
                        datalist_send_address.DataSource = createSendTable(name, address_page_now, address_page_size);
                        datalist_send_address.DataBind();
                        initNoticeInfo(datalist_send_address, "img_del");

                    }
                    else
                    {
                        address_page_now = Convert.ToInt32(page);
                        datalist_send_address.DataSource = createSendTable(name, address_page_now, address_page_size);
                        datalist_send_address.DataBind();
                        initNoticeInfo(datalist_send_address, "img_del");

                    }
                }
            }

        }

        /// <summary>
        /// 添加新地址的实现
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
                    datalist_send_address.DataSource = createSendTable(Session["name"].ToString(), address_page_now, address_page_size);
                    datalist_send_address.DataBind();
                    initNoticeInfo(datalist_send_address, "img_del");
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
                    datalist_send_address.DataSource = createSendTable(Session["name"].ToString(), address_page_now, address_page_size);
                    datalist_send_address.DataBind();
                    initNoticeInfo(datalist_send_address, "img_del");
                    alert("设置成功！");
                }
                else
                {
                    alert("设置失败！");
                }
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
                    datalist_send_address.DataSource = createSendTable(Session["name"].ToString(), address_page_now, address_page_size);
                    datalist_send_address.DataBind();
                    initNoticeInfo(datalist_send_address, "img_del");
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
                    datalist_send_address.DataSource = createSendTable(Session["name"].ToString(), address_page_now, address_page_size);
                    datalist_send_address.DataBind();
                    initNoticeInfo(datalist_send_address, "img_del");
                    send_part_edit_address.Visible = false;
                    alert("修改成功！");
                }
                else
                {
                    alert("修改失败！");
                }
            }



        }



        /// <summary>
        /// 当用户修改发件地址信息时，初始化
        /// </summary>
        /// <param name="send">发件地址信息对象</param>
        private void initAlterAddress(Address address)
        {
            lb_addr_id.Text = address.Addr_id.ToString();
            txt_addr_contact.Text = address.Addr_contact;
            txt_addr_company_name.Text = address.Company_name;
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

        //初始化添加地址信息列表
        private void init(int flag)
        {

            lb_addr_id.Text = "";
            txt_addr_contact.Text = "";
            txt_addr_company_name.Text = "";
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
        /// 弹出提示信息框
        /// </summary>
        /// <param name="message">提示信息</param>
        private void alert(string message)
        {
            Response.Write(string.Format("<script language='javascript'>alert('{0}');</script>", message));
        }

        

    }
}