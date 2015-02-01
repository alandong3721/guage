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


namespace WM_Project.manage_system
{
    public partial class check_order_detail_info : System.Web.UI.Page
    {
        public static string order_number = null;
        public static int pacakge_count = 0;
        public static AutoOrderList order = new AutoOrderList();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {

                if (Session["admin"] == null&&Session["manager"]==null&&Session["staff"]==null)
                {
                    Response.Redirect("error-page.aspx");
                }
                else
                {
                    string type = Request.QueryString["type"];
                    order_number = Request.QueryString["order_number"];

                    if (order_number == null || type == null)
                    {
                        Response.Redirect("error-page.aspx");

                    }
                    else
                    {
                        if (type == "detail")
                        {
                            order = new AutoOrderListDAO().getAutoOrderList(order_number);
                            has_addr_id.Visible = true;

                            //初始化发件地址
                            txt_send_addr_contact.Text = order.CollectionContactName;
                            txt_send_addr_company.Text = order.CollectionCompanyName;
                            txt_send_addr_line1.Text = order.CollectionAddressLine;
                            txt_send_addr_city.Text = order.CollectionTown;
                            txt_send_addr_postcode.Text = order.CollectionPostCode;
                            txt_send_addr_country.Text = order.CollectionCountry;
                            txt_send_addr_phone.Text = order.CollectionPhone;
                            //初始化收件地址
                            txt_receive_addr_contact.Text = order.RecipientContactName;
                            txt_receive_addr_company.Text = order.RecipientCompanyName;
                            txt_receive_addr_line1.Text = order.RecipientAddressLine;
                            txt_receive_addr_city.Text = order.RecipientTown;
                            txt_receive_addr_postcode.Text = order.RecipeintPostCode;
                            txt_receive_addr_country.Text = order.RecipientCountry;
                            txt_receive_addr_phone.Text = order.RecipientPhone;
                        
                        }
                        else if(type=="download")
                        {
                            string filename = Server.MapPath("\\views\\pdf\\" + order_number + "2.pdf");
                            HttpContext.Current.Response.AddHeader("content-disposition", "attachment;filename=" + order_number + ".pdf");

                            HttpContext.Current.Response.WriteFile(filename);
                            HttpContext.Current.Response.Flush();
                            HttpContext.Current.Response.Close();
                        }

                    }
                }

            }

        }


    }
}