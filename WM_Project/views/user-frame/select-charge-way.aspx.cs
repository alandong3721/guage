using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using WM_Project.control;
using WM_Project.logical.user;

namespace WM_Project.views.user_frame
{
    public partial class select_charge_way1 : System.Web.UI.Page
    {

        public static string name = "";
        public static float money = 0;
        public static MyAccount myaccount; 

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    name = Session["name"].ToString();
                    money = Convert.ToSingle(Session["charge_money"].ToString());

                }
                catch (Exception ex)
                {
                    Response.Redirect("error-page.aspx");
                }
            }

        }

         // 确认支付的实现
        protected void btn_Submit(object sender, EventArgs e)
        {

            string username = Session["name"].ToString();

            string email = new UserDAO().getUser(username).Email;

            string paymethod = Request["pay_method"];

            float amount = Convert.ToSingle(money);

            Session["charge_username"] = username;
            Session["charge_email"] = email;

            //生成支付成功码
            string success_code1 = (new Random().Next(1000000, 10000000)).ToString();
            string success_code2 = (new Random().Next(10000000, 100000000)).ToString();
            string success_code3 = (new Random().Next(100000000, 1000000000)).ToString();
            string success_code = success_code1 + success_code2 + success_code3;
            //将成功码插入到用户表中，支付成功是进行验证
            new UserDAO().updateChargeCode(username, success_code,amount);
            Session["chargecode"] = success_code;

           
            if (paymethod == "pay_card")
            {
                String card_type = Request["card_type"];

                if (card_type == "VISA Credit")
                {
                    amount = amount + amount * 0.025f;

                    amount = (float)Math.Round(amount, 2);

                }
                else if (card_type == "Mastercard Credit")
                {
                    amount = amount + amount * 0.025f;

                    amount = (float)Math.Round(amount, 2);


                }
                else if (card_type == "VISA Debit")
                {
                    amount = amount + 0.40f;

                    amount = (float)Math.Round(amount, 2);

                }
                else if (card_type == "UK Maestro")
                {
                    amount = amount + 0.25f;

                    amount = (float)Math.Round(amount, 2);

                }
                else if (card_type == "Non EU Cards")
                {
                    amount = amount + amount * 0.35f;

                    amount = (float)Math.Round(amount, 2);
                }

                Session["charge_amount"] = amount;

                Session["charge_method"] = card_type;

                Response.Write("<script language='javascript'>parent.location='../paycard-charge.aspx'</script>");
                //Response.Redirect("paycard-charge.aspx");

            }
            else if (paymethod.Equals("pay_paypal"))
            {

                amount = amount * 1.05f;
                amount = (float)Math.Round(amount, 2);

                Session["charge_amount"] = amount;
                Session["charge_method"] = "paypal";

                Response.Write("<script language='javascript'>parent.location='../paypal-charge.aspx'</script>");
                //Response.Redirect("paypal-charge.aspx");

            }
        }

        private void MessageBox(String message)
        {
            Response.Write("<script>alert('" + message + "');</script>");
        }

    }
}