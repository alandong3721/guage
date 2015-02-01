using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using WM_Project.logical.user;
using WM_Project.control;

namespace WM_Project.manage_system.frame
{
    public partial class check_user_info : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["admin"] == null && Session["manager"]==null && Session["staff"] == null)
            {
                Response.Redirect("../error-page.aspx");
            }
 
        }


        /// <summary>
        /// 查询用户信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_check_info_Click(object sender, EventArgs e)
        {
            string name = txt_userName.Text;
            
            User user = new UserDAO().getUser(name);

            if (user != null)
            {
                user_info.Visible = true;
                txt_Name.Text = user.Name;
                txt_phone.Text = user.Telephone;
                txt_email.Text = user.Email;
            }
            else
            {
                alert("不存在该用户！！");
            }
            

        }

        /// <summary>
        /// 弹出提示信息
        /// </summary>
        /// <param name="message"></param>
        private void alert(string message)
        {
            Response.Write(string.Format("<script language='javascript'>alert('{0}');</script>", message));
        }
    }
}