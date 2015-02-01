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
using CollectionPlus;

namespace WM_Project
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }


        //快速询价实现
        protected void btn_price_query_Click(object sender, EventArgs e)
        {

            //CollectionPlusLabel collectionplus = new CollectionPlusLabel("SanFeng Zhang", "18888881", "", "06/01/2015");
            //collectionplus.makeCollectionPlusLabel("D:\\CollectionPlus.pdf");
             
        
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

            Response.Redirect("views/index.aspx?step=2");
        }
    }
}