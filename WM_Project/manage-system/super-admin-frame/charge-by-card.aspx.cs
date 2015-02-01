using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WM_Project.control;

namespace WM_Project.views.super_admin_frame
{
    public partial class charge_by_card : System.Web.UI.Page
    {
        public int page_now = 1;
        public int page_size = 20;
        public int page_count = 0;
        public int record_count = 0;

        public int checked_page_now = 1;
        public int checked_page_size = 20;
        public int checked_page_count = 0;
        public int checked_record_count = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["admin"] == null && Session["manager"] == null && Session["staff"] == null)
                {
                    Response.Redirect("../error-page.aspx");
                    return;
                }

                string page = Request.QueryString["unckeckpagenow"];
                string checkedpage = Request.QueryString["checkpagenow"];

                if (page == null)
                {
                    //////////////////////////////////////////////////////////////////////////
                    // 未核对部分的绑定
                    page_now = 1;
                    record_count = new MyAccountTransDAO().getCardChargeCount(0);
                    page_count = new MyAccountTransDAO().getPageCount(record_count, page_size);
                    DataTable uncheckedtable = createUnCheckedTable(page_now, page_size);

                    if(uncheckedtable.Rows.Count>0)
                    {
                        record_has_not_check.Visible = true;
                        has_unchecked_record.Visible = false;

                        record_has_not_check_datalist.DataSource = uncheckedtable;
                        record_has_not_check_datalist.DataBind();
                    }
                    else
                    {
                        record_has_not_check.Visible = false;
                        has_unchecked_record.Visible = true;
                    }

                    


                }
                if(checkedpage == null)
                {
                    //////////////////////////////////////////////////////////////////////////
                    //已经核对部分的绑定
                    checked_page_now = 1;
                    checked_record_count = new MyAccountTransDAO().getCardChargeCount(1);
                    checked_page_count = new MyAccountTransDAO().getPageCount(checked_record_count, checked_page_size);
                    DataTable checkedtable = createCheckedTable(checked_page_now, checked_page_size);

                    if (checkedtable.Rows.Count > 0)
                    {
                        record_has_check.Visible = true;
                        has_no_checked_record.Visible = false;
                        record_has_check_datalist.DataSource = checkedtable;
                        record_has_check_datalist.DataBind();
                    }
                    else
                    {
                        record_has_check.Visible = false;
                        has_no_checked_record.Visible = true;
                    }
                }
                if (page != null)
                {
                    page_now = Convert.ToInt32(page);
                    record_count = new MyAccountTransDAO().getCardChargeCount(0);
                    page_count = new MyAccountTransDAO().getPageCount(record_count, page_size);
                    DataTable uncheckedtable = createUnCheckedTable(page_now, page_size);

                    if (uncheckedtable.Rows.Count > 0)
                    {
                        record_has_not_check.Visible = true;
                        has_unchecked_record.Visible = false;

                        record_has_not_check_datalist.DataSource = uncheckedtable;
                        record_has_not_check_datalist.DataBind();
                    }
                    else
                    {
                        record_has_not_check.Visible = false;
                        has_unchecked_record.Visible = true;
                    }

                    
                }
                if (checkedpage != null)
                {
                    checked_page_now = Convert.ToInt32(checkedpage);
                    checked_record_count = new MyAccountTransDAO().getCardChargeCount(1);
                    checked_page_count = new MyAccountTransDAO().getPageCount(checked_record_count, checked_page_size);
                    DataTable checkedtable = createCheckedTable(checked_page_now, checked_page_size);

                    if (checkedtable.Rows.Count > 0)
                    {
                        record_has_check.Visible = true;
                        has_no_checked_record.Visible = false;
                        record_has_check_datalist.DataSource = checkedtable;
                        record_has_check_datalist.DataBind();
                    }
                    else
                    {
                        record_has_check.Visible = false;
                        has_no_checked_record.Visible = true;
                    }

                    
                }
            }
        }

        /// <summary>
        /// 核对充值
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        protected void record_has_not_check_datalist_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName.Equals("checked"))
            {
                int id = Convert.ToInt32(e.CommandArgument.ToString());

                if (new MyAccountTransDAO().checkCardCharge(id))
                {

                    //////////////////////////////////////////////////////////////////////////
                    // 未核对部分的绑定
                    page_now = 1;
                    record_count = new MyAccountTransDAO().getCardChargeCount(0);
                    page_count = new MyAccountTransDAO().getPageCount(record_count, page_size);
                    DataTable uncheckedtable = createUnCheckedTable(page_now, page_size);

                    if (uncheckedtable.Rows.Count > 0)
                    {
                        record_has_not_check.Visible = true;
                        has_unchecked_record.Visible = false;

                        record_has_not_check_datalist.DataSource = uncheckedtable;
                        record_has_not_check_datalist.DataBind();
                    }
                    else
                    {
                        record_has_not_check.Visible = false;
                        has_unchecked_record.Visible = true;
                    }

                    //////////////////////////////////////////////////////////////////////////
                    //已经核对部分的绑定
                    checked_page_now = 1;
                    checked_record_count = new MyAccountTransDAO().getCardChargeCount(1);
                    checked_page_count = new MyAccountTransDAO().getPageCount(checked_record_count, checked_page_size);
                    DataTable checkedtable = createCheckedTable(checked_page_now, checked_page_size);

                    if (checkedtable.Rows.Count > 0)
                    {
                        record_has_check.Visible = true;
                        has_no_checked_record.Visible = false;
                        record_has_check_datalist.DataSource = checkedtable;
                        record_has_check_datalist.DataBind();
                    }
                    else
                    {
                        record_has_check.Visible = false;
                        has_no_checked_record.Visible = true;
                    }
                    
                    
                    alert("确认成功！！");
                }

            }
        }

        private DataTable createUnCheckedTable(int pageNow,int pageSize)
        {
            DataTable table = new DataTable();

            DataColumn dc = new DataColumn("id", typeof(int));
            table.Columns.Add(dc);
             
            dc = new DataColumn("name", typeof(string));
            table.Columns.Add(dc);


            dc = new DataColumn("amount", typeof(string));
            table.Columns.Add(dc);

            dc = new DataColumn("charge_way", typeof(string));
            table.Columns.Add(dc);

            dc = new DataColumn("time", typeof(string));
            table.Columns.Add(dc);

            DataTable temptable = new MyAccountTransDAO().getCardChargeRecordTable(0, pageNow, pageSize);

            for (int i = 0; i < temptable.Rows.Count; i++)
            {
                DataRow dr = table.NewRow();
                dr["id"] = Convert.ToInt32(temptable.Rows[i]["id"].ToString());
                dr["name"] = temptable.Rows[i]["user_name"].ToString();
                dr["amount"] = temptable.Rows[i]["amount"].ToString();
                dr["charge_way"] = temptable.Rows[i]["charge_way"].ToString();
                dr["time"] = Convert.ToDateTime(temptable.Rows[i]["trans_time"].ToString()).ToString("yyyy-MM-dd HH:mm");

                table.Rows.Add(dr);
            }

            return table;
        }

        private DataTable createCheckedTable(int pageNow,int pageSize)
        {
            DataTable table = new DataTable();

            DataColumn dc = new DataColumn("name",typeof(string));
            table.Columns.Add(dc);

            dc = new DataColumn("amount", typeof(string));
            table.Columns.Add(dc);

            dc = new DataColumn("charge_way", typeof(string));
            table.Columns.Add(dc);

            dc = new DataColumn("time", typeof(string));
            table.Columns.Add(dc);

            DataTable temptable = new MyAccountTransDAO().getCardChargeRecordTable(1, pageNow, pageSize);

            for (int i = 0; i < temptable.Rows.Count; i++)
            {
                DataRow dr = table.NewRow();

                dr["name"] = temptable.Rows[i]["user_name"].ToString();
                dr["amount"] = temptable.Rows[i]["amount"].ToString();
                dr["charge_way"] = temptable.Rows[i]["charge_way"].ToString();
                dr["time"] = Convert.ToDateTime(temptable.Rows[i]["trans_time"].ToString()).ToString("yyyy-MM-dd HH:mm");

                table.Rows.Add(dr);
            }

            return table;
        }

        private void alert(string message) 
        {
            Response.Write(string.Format("<script language='javascript'>alert('{0}');</script>", message));
        }
    }
}