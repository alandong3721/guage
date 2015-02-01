using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


using WM_Project.control;

namespace WM_Project.manage_system.super_admin_frame
{
    public partial class add_staff : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["admin"] == null&&Session["manager"]==null)
                {
                    Response.Redirect("../error-page.aspx");
                }
            }
        }

        protected void btn_add_staff_right_Click(object sender, EventArgs e)
        {
            string name = Request.Form["staffname"].ToString();
            string password = Request.Form["password"].ToString();
            string phone = Request.Form["staffphone"].ToString();
            string email = Request.Form["staffemail"].ToString();
            string type = Request.Form["type"].ToString();

            string has = "select * from tb_staff where name='" + name + "' and type='"+type+"'";

            DataTable table = new DBOperateCommon().excuteQuery(has);
            if (table.Rows.Count > 0)
            {
                alert("该员工已经存在，不能重复添加！！");
            }
            else
            {
                string sql = "insert into tb_staff values('" + name + "','"+phone+"','"+email+"','" + password + "','"+type+"','" + DateTime.Now.ToString() + "')";

                if (new DBOperateCommon().excuteNoQuery(sql))
                {

                    alert("添加成功！！！");

                }
                else
                {
                    alert("添加失败");
                }
            }
        }

        //弹出提示信息框
        private void alert(string message)
        {
            Response.Write(string.Format("<script language='javascript'>alert('{0}');</script>", message));
        }
    }
}