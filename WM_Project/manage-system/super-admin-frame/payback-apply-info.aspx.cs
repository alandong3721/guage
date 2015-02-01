using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using WM_Project.control;

namespace WM_Project.manage_system.super_admin_frame
{
    public partial class payback_apply_info : System.Web.UI.Page
    {

        public static int record_count = 0;
        public static int pageSize = 20;
        public static int page_count = 0;
        public static int pageNow = 1;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["admin"] == null)
                {
                    Response.Redirect("../error-page.aspx");
                }
                else
                {
                    string page = Request.QueryString["pageNow"];
                    if (page == null)
                    {
                        pageNow = 1;
                        DataTable source = createTable(pageNow, pageSize);
                        if (source.Rows.Count > 0)
                        {
                            has_apply_info.Visible = true;

                            record_count = new PayBackApplyDAO().getPayBackApplyCount();
                            page_count = new PayBackApplyDAO().getPayBackApplyPageCount(record_count, pageSize);
                            apply_info_datalist.DataSource = source;
                            apply_info_datalist.DataBind();
                        }
                        else
                        {
                            has_no_apply_info.Visible = true;
                            has_apply_info.Visible = false;
                        }

                    }
                    else
                    {
                        pageNow = Convert.ToInt32(page);
                        apply_info_datalist.DataSource = createTable(pageNow, pageSize);
                        apply_info_datalist.DataBind();
                    }
                }
            }
        }

        /// <summary>
        /// 分页创建表
        /// </summary>
        /// <param name="pageNow"></param>
        /// <param name="pageSize"></param>
        private DataTable createTable(int pageNow,int pageSize)
        {
            DataTable table = new DataTable();

            DataColumn dc = new DataColumn("id",typeof(int));
            table.Columns.Add(dc);

            dc = new DataColumn("name", typeof(string));
            table.Columns.Add(dc);
            
            dc = new DataColumn("amount", typeof(float));
            table.Columns.Add(dc);
            
            dc = new DataColumn("time", typeof(string));
            table.Columns.Add(dc);
            
            dc = new DataColumn("staff", typeof(string));
            table.Columns.Add(dc);

            DataTable temp = new PayBackApplyDAO().getPayBackApplyTable(pageNow,pageSize);

            for (int i = 0; i < temp.Rows.Count; i++)
            {
                DataRow dr = table.NewRow();
                dr["id"] = Convert.ToInt32(temp.Rows[i]["id"].ToString());
                dr["name"] = temp.Rows[i]["user_name"].ToString();
                dr["amount"] = Convert.ToSingle(temp.Rows[i]["amount"].ToString());
                dr["time"] = Convert.ToDateTime(temp.Rows[i]["operation_time"]).ToString("yyyyMMdd HH:mm:ss");
                dr["staff"] = temp.Rows[i]["staff_apply"].ToString();

                table.Rows.Add(dr);

            }

            return table;
        }

        protected void apply_info_datalist_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName.ToString().Equals("refresh"))
            {
                pageNow = 1;
                DataTable test = new PayBackApplyDAO().getPayBackApplyTable(pageNow, pageSize);
                if (test.Rows.Count > 0)
                {
                    has_apply_info.Visible = true;

                    record_count = new PayBackApplyDAO().getPayBackApplyCount();
                    page_count = new PayBackApplyDAO().getPayBackApplyPageCount(record_count, pageSize);
                    apply_info_datalist.DataSource = test;
                    apply_info_datalist.DataBind();
                }
                else
                {
                    has_no_apply_info.Visible = true;
                    has_apply_info.Visible = false;
                }
            }
            
        }
    }
}