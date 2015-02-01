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
    public partial class check_staff : System.Web.UI.Page
    {
        public static int pageSize = 20;
        public static int pageNow = 0;
        public static int staff_count = 0;
        public static int staff_page_count = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                if (Session["admin"] == null&&Session["manager"]==null)
                {
                    Response.Redirect("../error-page.aspx");
                }
                else
                {
                    string page = Request.QueryString["pageNow"];

                    if (page == null)
                    {
                        pageNow = 1;
                        staff_count = new StaffDAO().getStaffCount();
                        staff_page_count = new StaffDAO().getPageCount(staff_count, pageSize);
                        initStaffDataList(pageNow, pageSize);
                    }
                    else
                    {
                        pageNow = Convert.ToInt32(page);
                        staff_page_count = new StaffDAO().getPageCount(staff_count, pageSize);
                        initStaffDataList(pageNow, pageSize);
                    }
                }

            }
        }


        //员工DataList中事件的响应
        protected void staff_datalist_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName.Equals("delete"))
            {
                string staff_name = e.CommandArgument.ToString();
                int staff_id = Convert.ToInt32(e.CommandArgument.ToString());

                //删除员工
                if (new StaffDAO().deleteStaff(staff_id))
                {
                    alert("删除成功！！");
                    staff_count -= 1;
                    if (staff_count < (pageNow - 1) * pageSize + 1)
                    {
                        pageNow -= 1;
                    }
                    initStaffDataList(pageNow, pageSize);
                }
            }
        }


        public void initStaffDataList(int pageNow, int pageSize)
        {
            if (pageNow <= 0)
            {
                has_staff.Visible = false;
                has_no_sataff.Visible = true;
            }
            else
            {
                DataTable  stafftable = createTable(pageNow, pageSize);

                if (stafftable.Rows.Count > 0)
                {
                    has_staff.Visible = true;
                    has_no_sataff.Visible = false;
                    staff_datalist.DataSource = stafftable;
                    staff_datalist.DataBind();
                    initNoticeInfo(staff_datalist, "delete");
                }
                else
                {
                    has_staff.Visible = false;
                    has_no_sataff.Visible = true;
                }
            }


        }

        //创建员工信息表
        private DataTable createTable(int pageNow, int pageSize)
        {
            DataTable table = new DataTable();

            DataColumn dc = new DataColumn("name", typeof(string));
            table.Columns.Add(dc);

            dc = new DataColumn("id", typeof(int));
            table.Columns.Add(dc);

            dc = new DataColumn("phone", typeof(string));
            table.Columns.Add(dc);

            dc = new DataColumn("time", typeof(string));
            table.Columns.Add(dc);

            DataTable stafftable = new StaffDAO().getStaffs(pageNow, pageSize);

            for (int i = 0; i < stafftable.Rows.Count; i++)
            {
                DataRow dr = table.NewRow();
                dr["id"] = Convert.ToInt32(stafftable.Rows[i]["staff_id"].ToString());
                dr["name"] = stafftable.Rows[i]["name"].ToString();
                dr["phone"] = stafftable.Rows[i]["phone"].ToString();
                dr["time"] = Convert.ToDateTime(stafftable.Rows[i]["time"]).ToString("yyyy-MM-dd HH:mm:ss");
                table.Rows.Add(dr);
            }


            return table;
        }


        /// <summary>
        /// 初始化DataList删除时弹出确认框
        /// </summary>
        /// <param name="datalist"></param>
        /// <param name="control_id"></param>
        private void initNoticeInfo(DataList datalist, string control_id)
        {
            foreach (DataListItem item in datalist.Items)
            {
                ((ImageButton)item.FindControl(control_id)).Attributes["OnClick"] = "return confirm('您确定删除吗？')";
            }
        }


        //弹出提示信息框
        private void alert(string message)
        {
            Response.Write(string.Format("<script language='javascript'>alert('{0}');</script>", message));
        }
    }
}