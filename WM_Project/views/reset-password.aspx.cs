using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using WM_Project.control;
using WM_Project.logical.common;
using WM_Project.logical.user;

namespace WM_Project.views
{
    public partial class reset_password : System.Web.UI.Page
    {
        public static string code="";
        public static string name = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                string flag = Request.QueryString["flag"];
                if (flag != null)
                {
                    if (flag.Equals("1"))
                    {
                        first.Visible = false;
                        second.Visible = true;
                        try
                        {
                            name = Session["name"].ToString();

                        }
                        catch (Exception)
                        {
                            second.Visible = false;
                        }

                    }
                    else if (flag.Equals("2"))
                    {
                        alert("重置失败");

                    }
                    else
                    {
                        first.Visible = true;
                        second.Visible = false;
                    }

                }
                else
                {
                    first.Visible = true;
                }
            }
                    
        }


        //获取验证码的实现
        protected void btn_getcode_Click(object sender, EventArgs e)
        {
            string name = Request.Form["txt_username"].ToString().Trim();

            if (name != "")
            {
                User user = new UserDAO().getUser(name);
                if (user != null)
                {
                    code = new Random().Next(100000, 1000000).ToString();

                    new SendEmail().sendmail(user.Email, "验证码", code);

                    lb_noticeInfo.Text = "验证码已发至你邮箱" + user.Email;
                }
            }
            else
            {
                alert("用户名不能为空！！");
            }
        }


        //重置密码的具体实现
        protected void btn_resetPassword_Click(object sender, EventArgs e)
        {
            string userName = Request.Form["txt_username"].ToString().Trim();
            string password = Request.Form["txt_password"].ToString().Trim();

            string checkCode = Request.Form["txt_code"].ToString().Trim();
            
            if (new UserDAO().resetPassword(userName, password))
            {

                string flag = "1";
                Session["name"] = userName;
                Response.Redirect("reset-password.aspx?flag=" + flag);

            }
            else
            {
                string flag = "2";
                Session["name"] = userName;
                Response.Redirect("reset-password.aspx?flag=" + flag);
            }
            
        }

        //////////////////////////////////////////////////////////////////////////
        //实现页面自动跳转

        /// <summary>
        /// 定义在线考试总时间变量index,
        /// 并设置读写属性
        /// </summary>
        private int index
        {
            get
            {
                object o = ViewState["index "];
                return (o == null) ? 10 : (int)o;
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
                Session["name"] = name;
                Response.Redirect("index.aspx");
            }
            this.index--;
        }

        //弹出提示信息
        private void alert(string message)
        {
            Response.Write(string.Format("<script>alert('{0}')</script>", message));

        }
    }
}