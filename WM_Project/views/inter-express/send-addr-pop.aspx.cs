using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using WM_Project.control;
using WM_Project.logical.user;

namespace WM_Project.views.inter_express
{
    public partial class send_addr_pop : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["name"] = "yangwang-test";
                if (Session["name"] != null)
                {
                    // 绑定发件地址
                    send_addr_dropdown_list.DataSource = createSendAddrTable(Session["name"].ToString());
                    send_addr_dropdown_list.DataTextField = "address";
                    send_addr_dropdown_list.DataValueField = "addr_id";
                    send_addr_dropdown_list.DataBind();
                    initSendAddrNull();
                }
            }
            
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

        /// <summary>
        /// 创建发件人地址绑定表
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        private DataTable createSendAddrTable(string name)
        {
            DataTable table = new DataTable();

            DataColumn dc = new DataColumn("address", typeof(string));
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

        protected void btn_get_send_Click(object sender, EventArgs e)
        {
            Address address = new Address();

            address.Addr_contact = txt_send_addr_contact.Text;
            address.Company_name = txt_send_addr_company.Text;
            address.Addr_line1 = txt_send_addr_line1.Text;
            address.Addr_line2 = txt_send_addr_line2.Text;
            address.Addr_line3 = txt_send_addr_line3.Text;
            address.City = txt_send_addr_city.Text;
            address.Post_code = txt_send_addr_postcode.Text;
            address.Country = "UK";
            address.Phone = txt_send_addr_phone.Text;
            address.Email = txt_send_addr_email.Text;

            address.Addr_contact = address.Addr_contact.Replace(",", "");
            address.Company_name = address.Company_name.Replace(",", "");
            address.Addr_line1 = address.Addr_line1.Replace(",", "");
            address.Addr_line2 = address.Addr_line2.Replace(",", "");
            address.Addr_line3 = address.Addr_line3.Replace(",", "");
            address.City = address.City.Replace(",", "");
            address.Post_code = address.Post_code.Replace(",", "");
            address.Country = address.Country.Replace(",", "");
            address.Phone = address.Phone.Replace(",", "");

            address.Addr_contact = address.Addr_contact.Replace("'", "");
            address.Company_name = address.Company_name.Replace("'", "");
            address.Addr_line1 = address.Addr_line1.Replace("'", "");
            address.Addr_line2 = address.Addr_line2.Replace("'", "");
            address.Addr_line3 = address.Addr_line3.Replace("'", "");
            address.City = address.City.Replace("'", "");
            address.Post_code = address.Post_code.Replace("'", "");
            address.Country = address.Country.Replace("'", "");
            address.Phone = address.Phone.Replace("'", "");

            //添加到数据库
            if (send_addr_dropdown_list.SelectedValue == "-1" && send_addr.Checked == true)
            {
                address.Addr_type = "S";
                address.User_name = Session["name"].ToString();
                address.Is_default = "0";
                address.Time = DateTime.Now;

                new AddressDAO().addAddress(address);
            }

            Session["address"] = address;


            ClientScript.RegisterStartupScript(Page.GetType(), "", " <script src='../../script/jquery.js' type='text/javascript'></script><script type='text/javascript'>  $(function () {"
          + "var index = parent.layer.getFrameIndex(window.name);parent.$('#flag').val('true');parent.layer.autoArea(index);parent.layer.close(index);   }); </script>   ");
            ClientScript.RegisterStartupScript(Page.GetType(), "", "<script language=javascript>window.opener=null;window.open('','_self');window.close();</script>");
        }
    }
}