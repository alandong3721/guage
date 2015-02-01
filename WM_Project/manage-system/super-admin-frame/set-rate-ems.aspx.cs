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
    public partial class set_rate_ems : System.Web.UI.Page
    {
        public static int pageNow = 1;
        public static int pageSize = 20;
        public static int rate_count = 0;
        public static int rate_page_count = 0;
        public static string staffname = "";

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
                    if (Session["admin"] != null)
                    {
                        staffname = Session["admin"].ToString();
                    }
                    else
                    {
                        staffname = Session["manager"].ToString();
                    }

                    string page = Request.QueryString["pageNow"];
                    if (page == null)
                    {
                        pageNow = 1;
                        rate_count = new SetEMSRateForUserDAO().getUserRateCount();
                        rate_page_count = new SetEMSRateForUserDAO().getPageCount(rate_count, pageSize);
                        initUserHasDiscountDataList(pageNow, pageSize);
                    }
                    else
                    {
                        pageNow = Convert.ToInt32(page);
                        initUserHasDiscountDataList(pageNow, pageSize);
                    }
                }
                
            }
        }

        protected void btn_set_ems_rate_Click(object sender, EventArgs e)
        {
            string username = Request.Form["username"];
            string type = Request.Form["emsrate"];

            int flag = new SetEMSRateForUserDAO().setRateForUser(username, type, staffname);

            if (flag == 1)
            {
                alert("更新成功！！");
            }
            else if (flag == 2)
            {
                alert("更新失败!!");
            }
            else if (flag == 3)
            {
                alert("设置成功！！！");
            }
            else if (flag == 4)
            {
                alert("设置失败!!!");
            }

            pageNow = 1;
            rate_count = new SetEMSRateForUserDAO().getUserRateCount();
            initUserHasDiscountDataList(pageNow, pageSize);

        }



        //有优惠用户信息列表
        protected void user_has_discount_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName.Equals("delete"))
            {
                string name = e.CommandArgument.ToString();

                if (new SetEMSRateForUserDAO().deleteUserRate(name))
                {
                    alert("删除成功！！");
                    rate_count--;

                    if (rate_count < (pageNow - 1) * pageSize + 1)
                    {
                        pageNow--;
                    }
                    initUserHasDiscountDataList(pageNow, pageSize);

                }

            }
        }


        /// <summary>
        /// 初始化
        /// </summary>
        public void initUserHasDiscountDataList(int pageNow, int pageSize)
        {
            if (pageNow <= 0)
            {
                user_has_discount_div.Visible = false;
                user_has_no_discount_div.Visible = true;
            }
            else
            {
                DataTable temp = createUserRateTable(pageNow, pageSize);
                if (temp.Rows.Count > 0)
                {
                    user_has_discount_div.Visible = true;
                    user_has_no_discount_div.Visible = false;
                    user_has_discount.DataSource = temp;
                    user_has_discount.DataBind();
                    initNoticeInfo(user_has_discount, "delete");
                }
                else
                {
                    user_has_discount_div.Visible = false;
                    user_has_no_discount_div.Visible = true;
                }

            }


        }
        /// <summary>
        /// 分页创建 用户邮费表
        /// </summary>
        /// <param name="pageNow">当前页</param>
        /// <param name="pageSize">每页显示条数</param>
        /// <returns></returns>
        public DataTable createUserRateTable(int pageNow, int pageSize)
        {
            DataTable table = new DataTable();

            DataColumn dc = new DataColumn("name", typeof(string));
            table.Columns.Add(dc);

            dc = new DataColumn("type", typeof(string));
            table.Columns.Add(dc);

            dc = new DataColumn("seter", typeof(string));
            table.Columns.Add(dc);

            dc = new DataColumn("time", typeof(string));
            table.Columns.Add(dc);

            DataTable emsRateTable = new SetEMSRateForUserDAO().getUserRate(pageNow, pageSize);

            for (int i = 0; i < emsRateTable.Rows.Count; i++)
            {
                DataRow dr = table.NewRow();
                dr["name"] = emsRateTable.Rows[i]["username"].ToString();
                dr["type"] = emsRateTable.Rows[i]["ratetype"].ToString();
                dr["seter"] = emsRateTable.Rows[i]["setername"].ToString();
                dr["time"] = Convert.ToDateTime(emsRateTable.Rows[i]["settime"].ToString()).ToString("yyyy:MM:dd HH:mm");
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