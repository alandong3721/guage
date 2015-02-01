using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using WM_Project.control;
using WM_Project.logical.user;


namespace WM_Project.views
{
    public partial class charge_success : System.Web.UI.Page
    {
        public static string name = "";

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                name = Request.QueryString["username"];
                string code = Request.QueryString["code"];
                string pay_way = Request.QueryString["chargemethod"];

                if (Session["name"] == null && name != null)
                {
                    Session["name"]=name;
                }

                if (Session["name"] != null && code != null)
                {
                    if (new UserDAO().isCodeRight(Session["name"].ToString(), code))
                    {

                        User user = new UserDAO().getUser(Session["name"].ToString());
                        float charge_amount = user.Charge_amount;

                        //生成支付成功码
                        string success_code1 = (new Random().Next(100000000, 1000000000)).ToString();
                        string success_code2 = (new Random().Next(1000000, 10000000)).ToString();
                        string success_code3 = (new Random().Next(10000000, 100000000)).ToString();
                        string success_code = success_code1 + success_code2 + success_code3;
                        //将成功码插入到用户表中，支付成功是进行验证
                        new UserDAO().updateChargeCode(Session["name"].ToString(), success_code,0);
                        //确实付款成功
                        //更新我的账户
                        MyAccount myaccount = new MyAccountDAO().getMyAccount(Session["name"].ToString());
                        
                        if (myaccount == null)
                        {
                            myaccount = new MyAccount();
                            myaccount.Name = Session["name"].ToString();
                            myaccount.Balance = charge_amount;
                            new MyAccountDAO().addMyAccount(myaccount);
                        }
                        else
                        {
                            myaccount.Balance = myaccount.Balance + charge_amount;
                            new MyAccountDAO().updateMyAccount(myaccount.Name, myaccount.Balance);
                        }
                        

                        //添加账户交易信息
                        MyAccountTrans myaccounttrans = new MyAccountTrans();
                        myaccounttrans.Amout = charge_amount;
                        myaccounttrans.Charge_way = pay_way;
                        myaccounttrans.Operation = "自己给账户充值";
                        myaccounttrans.User_name = Session["name"].ToString();
                        myaccounttrans.Time = DateTime.Now;

                        new MyAccountTransDAO().addMyAccountTrans(myaccounttrans);


                    }
                    else
                    {
                        Response.Redirect("error-page.aspx");
                    }
                }
                else
                {
                    Response.Redirect("error-page.aspx");
                }
            }
        }


        //跳转倒计时
        private int index
        {
            get
            {
                object o = ViewState["index "];
                return (o == null) ? 3 : (int)o;
            }
            set
            {
                ViewState["index "] = value;
            }
        }
        protected void Timer1_Tick(object sender, EventArgs e)
        {

            if (this.index == 0) //考试时间到了
            {
                this.Timer1.Enabled = false;//设置Timer控件不可见
                Response.Redirect("my-account.aspx");
            }
            this.index--;
        }
    }
}