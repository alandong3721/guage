using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using WM_Project.control;

namespace WM_Project.manage_system.super_admin_frame
{
    public partial class add_rate_type_postnl : System.Web.UI.Page
    {
        public static ArrayList current_rate = new ArrayList();

        public static ArrayList rate1 = new ArrayList();
        public static ArrayList rate2 = new ArrayList();
        public static ArrayList rate3 = new ArrayList();
        public static ArrayList rate4 = new ArrayList();
        public static ArrayList rate5 = new ArrayList();
        public static ArrayList rate6 = new ArrayList();
        public static ArrayList rate7 = new ArrayList();
        public static ArrayList rate8 = new ArrayList();
        public static ArrayList rate9 = new ArrayList();
        public static ArrayList rate10 = new ArrayList();
        public static ArrayList rate11 = new ArrayList();
        public static ArrayList rate12 = new ArrayList();
        public static ArrayList rate13 = new ArrayList();
        public static ArrayList rate14 = new ArrayList();
        public static ArrayList rate15 = new ArrayList();
        public static ArrayList rate16 = new ArrayList();
        public static ArrayList rate17 = new ArrayList();
        public static ArrayList rate18 = new ArrayList();
        public static ArrayList rate19 = new ArrayList();
        public static ArrayList rate20 = new ArrayList();
        public static ArrayList rate21 = new ArrayList();
        public static ArrayList rate22 = new ArrayList();



        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                if (Session["admin"] == null && Session["manager"] == null)
                {
                    Response.Redirect("../error-page.aspx");
                }
                else
                {
                    initRateArray();
                    string type = rate_list.SelectedValue;
                    string sql = "select " + type + " from tb_rate_postnl";
                    DataTable table = new DBOperateCommon().excuteQuery(sql);
                    current_rate.Clear();

                    for (int i = 0; i < table.Rows.Count; i++)
                    {
                        current_rate.Add(Math.Round(Convert.ToSingle(table.Rows[i][0].ToString()), 2));
                    }
                }
            }
        }


        /// <summary>
        /// 下拉列表事件响应
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void rate_list_SelectedIndexChanged(object sender, EventArgs e)
        {
            string type = rate_list.SelectedValue;
            string sql = "select " + type + " from tb_rate_postnl";
            DataTable table = new DBOperateCommon().excuteQuery(sql);
            current_rate.Clear();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                current_rate.Add(Math.Round(Convert.ToSingle(table.Rows[i][0].ToString()), 2));
            }

        }

        protected void btn_postnl_rate_Click(object sender, EventArgs e)
        {
            string ratetype = rate_list.SelectedValue;
            string freights = Request.Form["freight"];

            string[] freight_array = freights.Split(',');

            for (int i = 0; i < freight_array.Length; i++)
            {
                float money = Convert.ToSingle(freight_array[i].ToString());

                string up_str = "update tb_rate_postnl set " + ratetype + "=" + money + " where id=" + (i + 1);

                new DBOperateCommon().excuteNoQuery(up_str);
            }

            initRateArray();

        }

        private void initRateArray()
        {
            rate1.Clear();
            rate2.Clear();
            rate3.Clear();
            rate4.Clear();
            rate5.Clear();
            rate6.Clear();
            rate7.Clear();
            rate8.Clear();
            rate9.Clear();
            rate10.Clear();
            rate11.Clear();
            rate12.Clear();
            rate13.Clear();
            rate14.Clear();
            rate15.Clear();
            rate16.Clear();
            rate17.Clear();
            rate18.Clear();
            rate19.Clear();
            rate20.Clear();
            rate21.Clear();
            rate22.Clear();

            string sql = "select * from tb_rate_postnl";
            DataTable table = new DBOperateCommon().excuteQuery(sql);

            for (int i = 0; i < table.Rows.Count;i++ )
            {
                rate1.Add(Math.Round(Convert.ToSingle(table.Rows[i]["rate1"].ToString()),2));
                rate2.Add(Math.Round(Convert.ToSingle(table.Rows[i]["rate2"].ToString()), 2));
                rate3.Add(Math.Round(Convert.ToSingle(table.Rows[i]["rate3"].ToString()), 2));
                rate4.Add(Math.Round(Convert.ToSingle(table.Rows[i]["rate4"].ToString()), 2));
                rate5.Add(Math.Round(Convert.ToSingle(table.Rows[i]["rate5"].ToString()), 2));
                rate6.Add(Math.Round(Convert.ToSingle(table.Rows[i]["rate6"].ToString()), 2));
                rate7.Add(Math.Round(Convert.ToSingle(table.Rows[i]["rate7"].ToString()), 2));
                rate8.Add(Math.Round(Convert.ToSingle(table.Rows[i]["rate8"].ToString()), 2));
                rate9.Add(Math.Round(Convert.ToSingle(table.Rows[i]["rate9"].ToString()), 2));
                rate10.Add(Math.Round(Convert.ToSingle(table.Rows[i]["rate10"].ToString()), 2));
                rate11.Add(Math.Round(Convert.ToSingle(table.Rows[i]["rate11"].ToString()), 2));
                rate12.Add(Math.Round(Convert.ToSingle(table.Rows[i]["rate12"].ToString()), 2));
                rate13.Add(Math.Round(Convert.ToSingle(table.Rows[i]["rate13"].ToString()), 2));
                rate14.Add(Math.Round(Convert.ToSingle(table.Rows[i]["rate14"].ToString()), 2));
                rate15.Add(Math.Round(Convert.ToSingle(table.Rows[i]["rate15"].ToString()), 2));
                rate16.Add(Math.Round(Convert.ToSingle(table.Rows[i]["rate16"].ToString()), 2));
                rate17.Add(Math.Round(Convert.ToSingle(table.Rows[i]["rate17"].ToString()), 2));
                rate18.Add(Math.Round(Convert.ToSingle(table.Rows[i]["rate18"].ToString()), 2));
                rate19.Add(Math.Round(Convert.ToSingle(table.Rows[i]["rate19"].ToString()), 2));
                rate20.Add(Math.Round(Convert.ToSingle(table.Rows[i]["rate20"].ToString()), 2));
                rate21.Add(Math.Round(Convert.ToSingle(table.Rows[i]["rate21"].ToString()), 2));
                rate22.Add(Math.Round(Convert.ToSingle(table.Rows[i]["rate22"].ToString()), 2));
            }
        }

       
    }
}