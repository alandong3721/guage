using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace WM_Project.views
{
    public partial class carseat_checkout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["CheckOutStep"] == "1" && Session["carseatsBuy"] != null)
            {
                this.CarsearCheckOut.Visible = false;
                this.ShipmentType.Visible = true;

                XmlDocument doc = new XmlDocument();
                string path = Server.MapPath("");
                path += "/Data/wsshcarseat.xml";
                doc.Load(path);

                float totalMilkPrice = 0;
                IDictionary<string, int> carseatsBuy = (IDictionary<string, int>)Session["carseatsBuy"];
                foreach (KeyValuePair<string, int> carseatBuy in carseatsBuy)
                {
                    XmlNode node = doc.SelectSingleNode("/carseats/carseat[id='" + carseatBuy.Key + "']");
                    totalMilkPrice += float.Parse(node["price_e"].InnerText.Trim()) * carseatBuy.Value;
                }
                this.anPostPrice.Text = "总价格： £" + (totalMilkPrice + 40);
            }
            else
            {
                this.CarsearCheckOut.Visible = true;
                this.ShipmentType.Visible = false;
            }
        }

        /// <summary>
        /// 保存买家买的座椅类型及个数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnNextTop_Click(object sender, EventArgs e)
        {
            IDictionary<string, int> carseatsBuy = new Dictionary<string, int>();
            carseatsBuy.Clear();

            string[] productIds = Request.Form["productId"].Split(',');

            foreach (string productId in productIds)
            {
                int num = Int32.Parse(Request.Form["quantity" + productId]);
                if (num > 0)
                {
                    carseatsBuy.Add(productId, num);
                }
            }
            Session["carseatsBuy"] = carseatsBuy;
            Response.Redirect("carseat-checkout.aspx?CheckOutStep=1");
        }

        protected void btnNextBottom_Click(object sender, EventArgs e)
        {
            IDictionary<string, int> carseatsBuy = new Dictionary<string, int>();
            carseatsBuy.Clear();

            string[] productIds = Request.Form["productId"].Split(',');

            foreach (string productId in productIds)
            {
                int num = Int32.Parse(Request.Form["quantity" + productId]);
                if (num > 0)
                {
                    carseatsBuy.Add(productId, num);
                }
            }
            Session["carseatsBuy"] = carseatsBuy;
            Response.Redirect("carset-checkout.aspx?CheckOutStep=1");
        }

        protected void anPostBuyNow_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("");
        }
    }
}