using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WM_Project.views
{
    public partial class paypal_charge : System.Web.UI.Page
    {
        public string urlFailed = "";
        public string urlSuccess = "";
        public string username = "";
        public float amount = 0.0f;
        public string email = "";
        public string payMethod = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            username = (string)Session["charge_username"];

            email = (string)Session["charge_email"];

            amount = (float)Session["charge_amount"];

            payMethod = Session["charge_method"].ToString();
            string code = Session["chargecode"].ToString();

            urlSuccess = "http://postnl.wm-global-express.com/views/charge-success.aspx?username=" + username + "&amount=" + amount + "&email=" + email + "&chargemethod=" + payMethod + "&code=" + code;

            urlFailed = "http://postnl.wm-global-express.com/views/charge-failed.aspx?username=" + username + "&code=" + code;

        }
    }
}