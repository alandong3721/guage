using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using WM_Project.logical.user;
using WM_Project.control;


namespace WM_Project.views
{
    public partial class regist : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string step = Request.QueryString["step"];
            if (step != null)
            {
                if (step.Equals("2"))
                {
                    first.Visible = false;
                    second.Visible = true;
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
                second.Visible = false;
            }
            
        }

        protected void btn_regist_Click(object sender, EventArgs e)
        {
            string code = Session["code"].ToString();
            string name = Request.Form["txt_userName"].ToString();
            string e_mail = Request.Form["txt_email"].ToString();
            string recommendUser = Request.Form["txt_recommendUser"].ToString();
           
            string website = Request.Form["txt_website"].ToString();
            string companyName = Request.Form["txt_companyName"].ToString();
            
            string telephone = Request.Form["txt_telephone"].ToString();
            string password = Request.Form["txt_password"].ToString();
            string txt_code = Request.Form["txt_code"].ToString();
            //验证验证码是否正确
            if (!(txt_code.ToLower().Equals(code.ToLower())))
            {
                alert("验证码错误！");
            }
            else
            {
                User user = new User();
                user.Name = name;
                user.Email = e_mail;
                user.RecommandUser = recommendUser;
                user.CompanyName = companyName;
                user.Website = website;
                user.Telephone = telephone;
                user.Password = password;
                user.Regist_time = DateTime.Now;

                if (new UserDAO().isUserExist(name))
                {
                    alert("该用户名已存在");
                }
                else
                {
                    if (new UserDAO().addUser(user))
                    {
                        //添加成功
                        Session["name"] = name;
                        Response.Redirect("regist.aspx?step=2");
                    }
                }
            }

        }


        //跳转倒计时
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
                Response.Redirect("index.aspx");
            }
            this.index--;
        }
        //弹出提示信息框
        private void alert(string message)
        {
            Response.Write(string.Format("<script language='javascript'>alert('{0}');</script>", message));
        }
    }
}