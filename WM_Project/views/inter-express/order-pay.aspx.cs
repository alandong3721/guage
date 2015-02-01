using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


using WM_Project.control;
using WM_Project.logical.user;


namespace WM_Project.views.inter_express
{
    public partial class order_pay : System.Web.UI.Page
    {

        public  string name = "";
        public  float money = 0;
        public  MyAccount myaccount; 

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                try
                {
                    name = Session["name"].ToString();
                    money = Convert.ToSingle(Session["money_pay"].ToString());
                    
                    //获取用户的账户余额
                    myaccount = new MyAccountDAO().getMyAccount(name);
                    if (myaccount == null)
                    {
                        myaccount = new MyAccount();
                        myaccount.Name = name;
                        myaccount.Balance = 0;
                        way_one.Visible = false;
                        only_for_read.Visible = true;
                    }
                    else
                    {
                        if (myaccount.Balance < money)
                        {
                            way_one.Visible = false;
                            only_for_read.Visible = true;
                        }
                    }

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

            money = Convert.ToSingle(Session["money_pay"].ToString());
            float amount = Convert.ToSingle(money);

            Session["pay_username"] = username;
            Session["pay_email"] = email;

            //生成支付成功码
            string success_code1 = (new Random().Next(1000000, 10000000)).ToString();
            string success_code2 = (new Random().Next(10000000, 100000000)).ToString();
            string success_code3 = (new Random().Next(100000000, 1000000000)).ToString();
            string success_code = success_code1 + success_code2+success_code3;
            //将成功码插入到用户表中，支付成功是进行验证
            new UserDAO().updateSuccessCode(username,success_code);
            Session["success_code"] = success_code;

            if(paymethod=="wm-account")
            {

                name = Session["name"].ToString();
                string code = Session["success_code"].ToString();
                //更新我的账户表

                if (new MyAccountDAO().userPayUseMyAccount(name, amount))
                {
                    Response.Redirect("pay-success.aspx?username=" + name + "&code=" + code + "&paymethod=my-account");
                }
                else
                {
                    Response.Redirect("repeat-pay.aspx?username=" + name + "&code=" + code);
                }



                Response.Redirect("pay-by-wm-account.aspx");
            }
            else if (paymethod == "pay_card")
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

                Session["pay_amount"] = amount;

                Session["pay_method"] = card_type;


                Response.Redirect("Paycard.aspx");

            }
            else if (paymethod.Equals("pay_paypal"))
            {

                amount = amount * 1.05f;
                amount = (float)Math.Round(amount, 2);

                Session["pay_amount"] = amount;
                Session["pay_method"] = "paypal";
                
                Response.Redirect("Paypal.aspx");

            }
        }

        private void MessageBox(String message)
        {
            Response.Write("<script>alert('" + message + "');</script>");
        }

        protected void btn_next_step_Click(object sender, EventArgs e)
        {
          
            Response.Redirect("order-label.aspx");
        }

       
    }
}