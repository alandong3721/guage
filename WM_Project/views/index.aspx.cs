using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using WM_Project.control;
using WM_Project.logical.common;


namespace WM_Project.views
{
    public partial class index : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            string step = Request.QueryString["step"];

            if (!IsPostBack)
            {
                if (step != null)
                {
                    if (step.Equals("2"))
                    {
                        first.Visible = false;
                        second.Visible = true;

                        //初始化包裹信息
                        if (Session["name"] == null)
                        {
                            string name = "";
                            initPackageInfo(name);
                        }
                        else
                        {
                            string name = Session["name"].ToString();
                            initPackageInfo(name);
                        }
                        

                    }
                }
                else
                {

                    first.Visible = true;
                    second.Visible = false;

                }
            }

        }


        /// <summary>
        /// 弹出提示信息 message
        /// </summary>
        /// <param name="message"></param>
        private void alert(string message)
        {
            Response.Write(string.Format("<script language='javascript'>alert('{0}')</script>", message));
        }



        /// <summary>
        /// DataList控件的事件相应函数
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        protected void postwaydata_ItemCommand(object source, DataListCommandEventArgs e)
        {
            //若命令名为购买
            if (e.CommandName.ToString().Equals("buy"))
            {
                for (int i = 0; i < postwaydata.Items.Count; i++)
                {
                    HiddenField hiden = (HiddenField)postwaydata.Items[i].FindControl("hidden");

                    string eid = e.CommandArgument.ToString();

                    if (hiden.Value.ToString().Equals(e.CommandArgument.ToString()))
                    {

                        Session["postname"] = hiden.Value.ToString();
                        Label lab = (Label)postwaydata.Items[i].FindControl("lb_money");
                        break;

                    }
                }
                if (Session["name"] == null)
                {
                    alert("请先登录");
                    Response.Redirect("../views/user-Login.aspx");
                }
                else
                {
                    if (Session["postname"].ToString().ToLower() == "ems" || Session["postname"].ToString().ToLower() == "postnl")
                    {
                        Response.Redirect("uk-land-transport.aspx");
                    }
                    else
                    {
                        Response.Redirect("purchase-process.aspx");
                    }
                    
                }
            }
        }


        /// <summary>
        /// 通过快件的起始国家、终止国家、重量、长度、宽度、高度 来查找数据库得到 邮费 然后创建 table
        /// </summary>
        /// <param name="startcountry">起始国家</param>
        /// <param name="endcountry">终止国家</param>
        /// <param name="weight">重量</param>
        /// <param name="length">长度</param>
        /// <param name="width">宽度</param>
        /// <param name="height">高度</param>
        /// <returns>将所需要的数据存放在 DataTable中</returns>
        private DataTable createDataTable(string name, string destination, ArrayList goods)
        {

            //计算总共的包裹数
            int package_count = 0;

            for (int i = 0; i < goods.Count; i++)
            {
                PackageMeasure temp_package = (PackageMeasure)goods[i];
                package_count += temp_package.Count;
            }

            DataTable dt = new DataTable("postways");
            //为表添加列
            DataColumn dc = new DataColumn("id", typeof(int));
            dc.AutoIncrement = true;
            dt.Columns.Add(dc);

            dc = new DataColumn("postname", typeof(string));
            dt.Columns.Add(dc);

            dc = new DataColumn("imagePath", typeof(string));
            dt.Columns.Add(dc);

            dc = new DataColumn("note", typeof(string));
            dt.Columns.Add(dc);

            dc = new DataColumn("money", typeof(string));
            dt.Columns.Add(dc);


            //tb_postways 里面存放了 postname、note信息
            DataTable tb_postways = new PosCalculate().getPostWays(destination);

            foreach (DataRow tempdr in tb_postways.Rows)
            {
                float total = 0;
                
                if (package_count <= 1)
                {
                    DataRow dr = dt.NewRow();
                    string post_way = tempdr["post_way"].ToString();
                    dr["postname"] = post_way;
                    dr["imagePath"] = "../image/image/" + tempdr["image_path"].ToString(); 
                    dr["note"] = tempdr["note"].ToString();

                    for (int i = 0; i < goods.Count; i++)
                    {
                        PackageMeasure good = (PackageMeasure)goods[i];

                        total += good.Count * new InterFaceQuote().getQuote(name, destination, good.Weight, good.Length, good.Width, good.Height, post_way);
                    }

                    total = (int)(total * 100) / 100.0f;

                    dr["money"] ="£"+ total.ToString();
                    dt.Rows.Add(dr);
                }
                else if(package_count<=3)
                {
                    DataRow dr = dt.NewRow();
                    string post_way = tempdr["post_way"].ToString();

                    if (!post_way.Contains("PF-IPE"))
                    {
                        dr["postname"] = post_way;
                        dr["imagePath"] = "../image/image/" + tempdr["image_path"].ToString(); 
                        dr["note"] = tempdr["note"].ToString();

                        for (int i = 0; i < goods.Count; i++)
                        {
                            PackageMeasure good = (PackageMeasure)goods[i];

                            total += good.Count * new InterFaceQuote().getQuote(destination,destination, good.Weight, good.Length, good.Width, good.Height, post_way);
                        }

                        total = (int)(total * 100) / 100.0f;

                        total = (float)Math.Round(total, 2);

                        dr["money"] = total;
                        dt.Rows.Add(dr);
                    }
                    
                }
                else
                {
                    DataRow dr = dt.NewRow();
                    string post_way = tempdr["post_way"].ToString();

                    if (!post_way.Contains("PF-IPE")&&!post_way.Contains("PF-GPR"))
                    {
                        dr["postname"] = post_way;
                        dr["imagePath"] = "../image/image/" + tempdr["image_path"].ToString(); 
                        dr["note"] = tempdr["note"].ToString();

                        for (int i = 0; i < goods.Count; i++)
                        {
                            PackageMeasure good = (PackageMeasure)goods[i];

                            total += good.Count * new InterFaceQuote().getQuote(name,destination,good.Weight, good.Length, good.Width, good.Height, post_way);
                        }

                        total = (int)(total * 100) / 100.0f;

                        dr["money"] = total;
                        dt.Rows.Add(dr);
                    }
                }
                
            }

            return dt;
        }


        //初始化包裹信息
        protected void initPackageInfo(string name)
        {
            
            string destination = Session["to"].ToString();
            ArrayList goods = (ArrayList)Session["package_array"];

            postwaydata.DataSource = createDataTable(name, destination, goods);
            postwaydata.DataBind();

        }

        protected void btn_price_query_Click(object sender, EventArgs e)
        {
            string end_country = Request.Form["to"].ToString();

            string counts = Request.Form["count"].ToString();
            string weights = Request.Form["weight"].ToString();
            string lengths = Request.Form["length"].ToString();
            string widths = Request.Form["width"].ToString();
            string heights = Request.Form["height"].ToString();

            string[] count_array = counts.Split(',');
            string[] weight_array = weights.Split(',');
            string[] length_array = lengths.Split(',');
            string[] width_array = widths.Split(',');
            string[] height_array = heights.Split(',');

            ArrayList goods = new ArrayList();

            for (int i = 0; i < weight_array.Length; i++)
            {
                PackageMeasure good = new PackageMeasure();
                good.Count = int.Parse(count_array[i].ToString());
                good.Weight = float.Parse(weight_array[i].ToString());
                good.Length = float.Parse(length_array[i].ToString());
                good.Width = float.Parse(width_array[i].ToString());
                good.Height = float.Parse(height_array[i].ToString());

                goods.Add(good);

            }

            Session["package_array"] = goods;
            Session["to"] = end_country;

            Response.Redirect("../views/index.aspx?step=2");
        }

    }
}