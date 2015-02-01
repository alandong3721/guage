using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using WM_Project.control;

namespace WM_Project.views.inter_express
{
    public partial class simple_batch_uk_pick_up : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["name"] == null)
            {
                Response.Redirect("user-login.aspx");
            }
            else
            {
                uk_trans_list.DataSource = createTable();
                uk_trans_list.DataBind();
            }
        }


        /// <summary>
        /// DataList响应事件
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        protected void uk_trans_list_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "buy")
            {
                string collection_way = e.CommandArgument.ToString();
                Session["delivery_way"] = collection_way;
                Response.Redirect("simple-batch-purchase-process.aspx");
            }
        }

        private DataTable createTable()
        {
            DataTable table = new DataTable();

            DataColumn dc = new DataColumn("imagePath", typeof(string));
            table.Columns.Add(dc);

            dc = new DataColumn("note", typeof(string));
            table.Columns.Add(dc);

            dc = new DataColumn("money", typeof(float));
            table.Columns.Add(dc);

            dc = new DataColumn("postname", typeof(string));
            table.Columns.Add(dc);

            DataTable uk_trans = new PosCalculate().getPostWays("UK");

            for (int i = 0; i < uk_trans.Rows.Count; i++)
            {
                DataRow dr = table.NewRow();

                dr["imagePath"] = "../../image/image/" + uk_trans.Rows[i]["image_path"];
                dr["money"] = 2.0;
                dr["note"] = uk_trans.Rows[i]["note"];
                dr["postname"] = uk_trans.Rows[i]["post_way"];

                table.Rows.Add(dr);
            }

            return table;
        }
    }
}