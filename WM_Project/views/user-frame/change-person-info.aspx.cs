using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using WM_Project.logical.user;
using WM_Project.control;

namespace WM_Project.views.user_frame
{
    public partial class change_person_info : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["name"] == null)
                {
                    Response.Redirect("../error-page.aspx");
                }
                else
                {
                    string name = Session["name"].ToString();
                    User user = new UserDAO().getUser(name);
                    username.Text = user.Name;
                    useremail.Text = user.Email;
                    userphone.Text = user.Telephone;
                    usercompanyname.Text = user.CompanyName;
                    userwebsite.Text = user.Website;
                }
            }
        }


        /// <summary>
        /// 会员修改个人信息的实现
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_change_Click(object sender, EventArgs e)
        {
            string name = username.Text;
            string email = useremail.Text;
            string phone = userphone.Text;
            string website = userwebsite.Text;
            string companyname = usercompanyname.Text;

            User user = new UserDAO().getUser(name);

            user.Email = email;
            user.Telephone = phone;
            user.Website = website;
            user.CompanyName = companyname;

            if (new UserDAO().updateUser(user))
            {
                alert("更新成功！！！");
            }

        }

        /// <summary>
        /// 弹出提示信息
        /// </summary>
        /// <param name="message"></param>
        private void alert(string message)
        {
            Response.Write(string.Format("<script language='javascript'>alert('{0}');</script>",message));
        }
    }
}