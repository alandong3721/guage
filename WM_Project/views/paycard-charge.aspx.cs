using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WM_Project.views
{
    public partial class paycard_charge : System.Web.UI.Page
    {
        public string urlFailed = "";
        public string urlSuccess = "";
        public string username = "";
        public float amount1 = 0.0f;
        public string amount = "";
        public string email = "";
        public string payMethod = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            username = (string)Session["charge_username"];

            email = (string)Session["charge_email"];

            amount1 = (float)Session["charge_amount"];

            amount = amount1.ToString("0.00");

            payMethod = Session["charge_method"].ToString();
            string code = Session["chargecode"].ToString();

            urlSuccess = "http://postnl.wm-global-express.com/views/charge-success.aspx?username=" + username + "&amount=" + amount + "&email=" + email + "&chargemethod=" + payMethod + "&code=" + code;

            urlFailed = "http://postnl.wm-global-express.com/views/charge-failed.aspx?username=" + username + "&code=" + code;

        }
    }
}