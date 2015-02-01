using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using WM_Project.logical.common;
using WM_Project.control;

namespace WM_Project.manage_system.manager_frame
{
    public partial class change_person_info : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["manager"] == null)
                {
                    Response.Redirect("../error-page.aspx");
                }
                else
                {
                    string name = Session["manager"].ToString();
                    Staff staff = new StaffDAO().getStaff(name, "manager");
                    staffname.Text = staff.Name;
                    staffphone.Text = staff.Phone;
                    staffemail.Text = staff.Email;
                }

            }
        }

        protected void btn_change_Click(object sender, EventArgs e)
        {
            string name = staffname.Text;
            string phone = staffphone.Text;
            string email = staffemail.Text;

            if (new StaffDAO().updateStaff(name, phone, email, "manager"))
            {
                alert("更新成功！！");
            }
            else
            {
                alert("更新失败!!");
            }

        }

        /// <summary>
        /// 弹出提示信息
        /// </summary>
        /// <param name="message"></param>
        private void alert(string message)
        {
            Response.Write(string.Format("<script language='javascript'>alert('{0}')</script>", message));
        }
    }
}