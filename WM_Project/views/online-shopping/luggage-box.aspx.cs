using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WM_Project.views
{
    public partial class luggage_box : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) 
            {
                luggageBox_count.DataSource = createTable();
                luggageBox_count.DataTextField = "count";
                luggageBox_count.DataBind();
            }
            
        }

        /// <summary>
        /// 根据选择的个数显示总价格
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void luggageBox_count_SelectedIndexChanged(object sender, EventArgs e)
        {
            string count = luggageBox_count.SelectedValue;

            switch (count)
            { 
                case "0":
                    showPrice.Text = "0";
                    return;
                case "1":
                    showPrice.Text = "8";
                    return;
                case "2":
                    showPrice.Text = "11";
                    return;
                case "3":
                    showPrice.Text = "14";
                    return;
                case "4":
                    showPrice.Text = "17";
                    return;
                case "5":
                    showPrice.Text = "20";
                    return;
                case "6":
                    showPrice.Text = "23";
                    return;
                case "7":
                    showPrice.Text = "26";
                    return;
                case "8":
                    showPrice.Text = "29";
                    return;
                case "9":
                    showPrice.Text = "32";
                    return;
                case "10":
                    showPrice.Text = "35";
                    return;
            }
        }


        /// <summary>
        /// 创建绑定数据表
        /// </summary>
        /// <returns></returns>
        private DataTable createTable()
        {
            DataTable table = new DataTable();

            DataColumn dc = new DataColumn("count",typeof(int));
            table.Columns.Add(dc);

            for(int i=0;i<11;i++){
                DataRow dr = table.NewRow();
                dr["count"] = i;

                table.Rows.Add(dr);
            }

            return table;

        }

        /// <summary>
        /// 下单并保存购买的包装盒个数到Session中
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void luggageBoxBuyNow_Click(object sender, ImageClickEventArgs e)
        {
            Session["luaggeBoxNums"] = luggageBox_count.SelectedValue;
            Response.Redirect("");
        }
    }
}