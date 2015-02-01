using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WM_Project.logical.user;
using WM_Project.control;
using System.Data;

namespace WM_Project.views.inter_express
{
    public partial class receive_addr_pop : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                //绑定收件地址
                receive_addr_dropdown_list.DataSource = createReceiveAddrTable(Session["name"].ToString());
                receive_addr_dropdown_list.DataTextField = "address";
                receive_addr_dropdown_list.DataValueField = "addr_id";
                receive_addr_dropdown_list.DataBind();

                //初始化收件地址
                initReceiveAddrNull();
            }
        }

        protected void btn_receive_addr_Click(object sender, EventArgs e)
        {
            Address address = new Address();
            
            address.Addr_contact = txt_receive_addr_contact.Text;
            address.Company_name = txt_receive_addr_contact.Text;
            address.Addr_line1 = txt_receive_addr_line1.Text;
            address.Addr_line2 = txt_receive_addr_line2.Text;
            address.Addr_line3 = txt_receive_addr_line3.Text;
            address.City = txt_receive_addr_city.Text;
            address.Post_code = txt_receive_addr_postcode.Text;
            address.Country = txt_receive_addr_country.Text;
            address.Phone = txt_receive_addr_phone.Text;
            address.Email = txt_receive_addr_email.Text;

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
            if (receive_addr_dropdown_list.SelectedValue == "-1" && receive_addr.Checked==true)
            {
                address.Addr_type = "R";
                address.User_name = Session["name"].ToString();
                address.Is_default = "0";
                address.Time = DateTime.Now;

                new AddressDAO().addAddress(address);
            }

            //txt_receive_addr_contact.Text = Hz2Py.Convert(txt_receive_addr_contact.Text);
            //txt_receive_addr_company.Text = Hz2Py.Convert(txt_receive_addr_company.Text);
            //txt_receive_addr_line1.Text = Hz2Py.Convert(txt_receive_addr_line1.Text);
            //txt_receive_addr_line2.Text = Hz2Py.Convert(txt_receive_addr_line2.Text);
            //txt_receive_addr_line3.Text = Hz2Py.Convert(txt_receive_addr_line3.Text);
            //txt_receive_addr_city.Text = Hz2Py.Convert(txt_receive_addr_city.Text);
            //txt_receive_addr_postcode.Text = Hz2Py.Convert(txt_receive_addr_postcode.Text);
            //txt_receive_addr_country.Text = Hz2Py.Convert(txt_receive_addr_country.Text);
            //txt_receive_addr_phone.Text = Hz2Py.Convert(txt_receive_addr_phone.Text);
            //txt_receive_addr_email.Text = Hz2Py.Convert(txt_receive_addr_email.Text);


            Session["address"] = address;


            ClientScript.RegisterStartupScript(Page.GetType(), "", " <script src='../../script/jquery.js' type='text/javascript'></script><script type='text/javascript'>  $(function () {"
          + "var index = parent.layer.getFrameIndex(window.name);parent.$('#flag').val('true');parent.layer.autoArea(index);parent.layer.close(index);   }); </script>   ");
            ClientScript.RegisterStartupScript(Page.GetType(), "", "<script language=javascript>window.opener=null;window.open('','_self');window.close();</script>");

        }

        protected void btn_to_pinyin_Click(object sender, EventArgs e)
        {
            txt_receive_addr_contact.Text = Hz2Py.Convert(txt_receive_addr_contact.Text);

            txt_receive_addr_contact.Text = Hz2Py.Convert(txt_receive_addr_contact.Text);
            txt_receive_addr_company.Text = Hz2Py.Convert(txt_receive_addr_company.Text);
            txt_receive_addr_line1.Text = Hz2Py.Convert(txt_receive_addr_line1.Text);
            txt_receive_addr_line2.Text = Hz2Py.Convert(txt_receive_addr_line2.Text);
            txt_receive_addr_line3.Text = Hz2Py.Convert(txt_receive_addr_line3.Text);
            txt_receive_addr_city.Text = Hz2Py.Convert(txt_receive_addr_city.Text);
            txt_receive_addr_postcode.Text = Hz2Py.Convert(txt_receive_addr_postcode.Text);
            txt_receive_addr_country.Text = Hz2Py.Convert(txt_receive_addr_country.Text);
            txt_receive_addr_phone.Text = Hz2Py.Convert(txt_receive_addr_phone.Text);
            txt_receive_addr_email.Text = Hz2Py.Convert(txt_receive_addr_email.Text);
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

        private void initReceiveAddr(Address address)
        {
            txt_receive_addr_contact.Text = address.Addr_contact;
            txt_receive_addr_company.Text = address.Company_name;
            txt_receive_addr_line1.Text = address.Addr_line1;
            txt_receive_addr_line2.Text = address.Addr_line2;
            txt_receive_addr_line3.Text = address.Addr_line3;
            txt_receive_addr_city.Text = address.City;
            txt_receive_addr_postcode.Text = address.Post_code;
            txt_receive_addr_country.Text = address.Country;
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
            txt_receive_addr_country.Text = "";
            txt_receive_addr_phone.Text = "";
            txt_receive_addr_email.Text = "";
        }
    }
}