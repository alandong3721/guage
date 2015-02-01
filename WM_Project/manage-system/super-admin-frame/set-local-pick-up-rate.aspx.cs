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
    public partial class set_local_pick_up_rate : System.Web.UI.Page
    {
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
                    initDataList();
                }
                
            }
        }

        /// <summary>
        /// 设置本地取件邮费
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_set_local_rate_Click(object sender, EventArgs e)
        {
            string weight = Request.Form["weight"];
            string price = Request.Form["money"];
            string per_price = Request.Form["more_money"];

            if (new LocalPickRateDAO().setLocalRate(Convert.ToSingle(weight),Convert.ToSingle(price),Convert.ToSingle(per_price)))
            {
                alert("设置成功！！");
                initDataList();
            }

        }

        protected void local_rate_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName.ToString().Equals("delete"))
            {
                int id = Convert.ToInt32(e.CommandArgument.ToString());
                if (new LocalPickRateDAO().deleteLocalRate(id))
                {
                    alert("删除成功！！");
                    initDataList();
                }

            }
        }

        //创建数据绑定表
        private DataTable createTable()
        {
            DataTable table = new DataTable();

            DataColumn dc = new DataColumn("id", typeof(int));
            table.Columns.Add(dc);
            
            dc = new DataColumn("base_weight",typeof(string));
            table.Columns.Add(dc);

            dc = new DataColumn("base_money", typeof(string));
            table.Columns.Add(dc);

            dc = new DataColumn("per_money", typeof(string));
            table.Columns.Add(dc);

            DataTable temp = new LocalPickRateDAO().getLocalRateInfoTable();
            for (int i = 0; i < temp.Rows.Count; i++)
            {
                DataRow dr = table.NewRow();
                dr["id"] = Convert.ToInt32(temp.Rows[i]["id"].ToString());
                dr["base_weight"] = Convert.ToSingle(temp.Rows[i]["kg"].ToString());
                dr["base_money"] = Convert.ToSingle(temp.Rows[i]["base_price"].ToString());
                dr["per_money"] = Convert.ToSingle(temp.Rows[i]["up_per_kg"].ToString());

                table.Rows.Add(dr);
            }

            return table;
        }


        private void initDataList()
        {
            DataTable temp = createTable();
            if (temp.Rows.Count > 0)
            {
                has_local_rate.Visible = true;
                has_not_local_rate.Visible = false;
                local_rate.DataSource = temp;
                local_rate.DataBind();
                initNoticeInfo(local_rate, "delete");
            }
            else
            {
                has_local_rate.Visible = false;
                has_not_local_rate.Visible = true;
            }
            
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
        public void alert(string message)
        {
            Response.Write(string.Format("<script language='javascript'>alert('{0}');</script>", message));
        }
    }
}