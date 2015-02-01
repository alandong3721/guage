using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Text;

namespace WM_Project.views.online_shopping
{
    public partial class milkpowder_checkout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string PackageType = Session["PackageType"] == null ? "0" : Session["PackageType"].ToString();
            //根据Session里是否有值判断买家下单的步骤
            if (Request.QueryString["CheckOutStep"] == "1" && (PackageType == "2" || PackageType == "4" || PackageType == "6"))
            {
                this.MilkPowderPackageType.Visible = false;
                this.MilkPowderNums.Visible = true;
                this.MilkPowderShipmentType.Visible = false;

                this.PackageTypeDesciption.Text = "您已经选择了" + PackageType + "桶一箱的服务。请选择您需要的奶粉种类和数量，然后点击下一步";
                this.btnNextTop.OnClientClick = "return matchBoxType('" + PackageType + "')";
                this.btnNextBottom.OnClientClick = "return matchBoxType('" + PackageType + "')";
            }
            else if (Request.QueryString["CheckOutStep"] == "2" && (PackageType == "2" || PackageType == "4" || PackageType == "6") && Session["productsBuy"] != null)
            {
                this.MilkPowderPackageType.Visible = false;
                this.MilkPowderNums.Visible = false;
                this.MilkPowderShipmentType.Visible = true;

                XmlDocument doc = new XmlDocument();
                string path = Server.MapPath("");
                path += "/Data/wssh.xml";
                doc.Load(path);

                int totalMilkPowders = 0;
                float totalMilkPrice = 0;
                IDictionary<string, int> productsBuy = (IDictionary<string, int>)Session["productsBuy"];
                foreach (KeyValuePair<string, int> productBuy in productsBuy)
                {
                    XmlNode node = doc.SelectSingleNode("/milks/milk[id='" + productBuy.Key + "']");
                    totalMilkPrice += float.Parse(node["price_e"].InnerText.Trim()) * productBuy.Value;
                    totalMilkPowders += productBuy.Value;
                }
                this.bPostPrice.Text = "总价格： £" + (totalMilkPrice + 30);
                this.emsPrice.Text = "总价格： £" + (totalMilkPrice + 20);
                this.parcelPrice.Text = "总价格： £" + (totalMilkPrice + 40);
                this.productBuyDesc.Text = "请选择国际快递服务－订单共" + (totalMilkPowders / Int32.Parse(PackageType)) +
                    "个包裹，每个包裹" + PackageType + "罐奶粉(价格包含奶粉，采购，包装，运输等费用)";
            }
            else
            {
                this.MilkPowderPackageType.Visible = true;
                this.MilkPowderNums.Visible = false;
                this.MilkPowderShipmentType.Visible = false;

            }
        }

        protected void count_2_Click(object sender, EventArgs e)
        {
            Session["PackageType"] = "2"; //保存买家选择的类型（2）
            Response.Redirect("milkpowder-checkout.aspx?CheckOutStep=1");
        }

        protected void count_4_Click(object sender, EventArgs e)
        {
            Session["PackageType"] = "4"; //保存买家选择的类型（4）
            Response.Redirect("milkpowder-checkout.aspx?CheckOutStep=1");
        }

        protected void count_6_Click(object sender, EventArgs e)
        {
            Session["PackageType"] = "6"; //保存买家选择的类型（6）
            Response.Redirect("milkpowder-checkout.aspx?CheckOutStep=1");
        }

        protected void count_more_Click(object sender, EventArgs e)
        {
            Response.Redirect(""); // 奶粉批量下单
        }

        /// <summary>
        /// 进入下个页面之前保存买家买的商品类型及相应个数到Session中
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnNextTop_Click(object sender, EventArgs e)
        {
            IDictionary<string, int> productsBuy = new Dictionary<string, int>();
            productsBuy.Clear();

            string[] productIds = Request.Form["productId"].Split(',');

            foreach (string productId in productIds)
            {
                int num = Int32.Parse(Request.Form["quantity" + productId]);
                if (num > 0)
                {
                    productsBuy.Add(productId, num);
                }
            }
            Session["productsBuy"] = productsBuy;
            Response.Redirect("milkpowder-checkout.aspx?CheckOutStep=2");
        }

        protected void btnNextBottom_Click(object sender, EventArgs e)
        {
            IDictionary<string, int> productsBuy = new Dictionary<string, int>();
            productsBuy.Clear();

            string[] productIds = Request.Form["productId"].Split(',');

            foreach (string productId in productIds)
            {
                int num = Int32.Parse(Request.Form["quantity" + productId]);
                if (num > 0)
                {
                    productsBuy.Add(productId, num);
                }
            }
            Session["productsBuy"] = productsBuy;
            Response.Redirect("milkpowder-checkout.aspx?CheckOutStep=2");
        }

        /// <summary>
        /// 选择邮寄的类型
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void bPostBuyNow_Click(object sender, ImageClickEventArgs e)
        {
            Session["shipType"] = "bpost";
            Response.Redirect("");
        }

        protected void emsBuyNow_Click(object sender, ImageClickEventArgs e)
        {
            Session["shipType"] = "ems";
            Response.Redirect("");
        }

        protected void parcelBuyNow_Click(object sender, ImageClickEventArgs e)
        {
            Session["shipType"] = "51parcel";
            Response.Redirect("");
        }
    }
}