using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WM_Project.views
{
    public partial class supply_checkout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void packageBuyNow_Click(object sender, ImageClickEventArgs e)
        {
            int packageType4 = Int32.Parse(Request.Form["packageType4"]);
            int packageType6 = Int32.Parse(Request.Form["packageType6"]);
            int packageTypeMore = Int32.Parse(Request.Form["packageTypeMore"]);
            int packageTypeClue = Int32.Parse(Request.Form["packageTypeClue"] == null ? "0" : Request.Form["packageTypeClue"]);

            if ((packageType4 + packageType6 + packageTypeMore) <= 0)
            {
                Response.Redirect("supply_checkout.aspx");
            }
            int[] packageNums = {packageType4,packageType6,packageTypeMore,packageTypeClue};
            Session["packageNum"] = packageNums;
            Response.Redirect("");
        }
    }
}