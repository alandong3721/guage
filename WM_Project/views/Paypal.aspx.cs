using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Payment2
{
    public partial class Paypal : System.Web.UI.Page
    {
        public string urlFailed     = "";
        public string urlSuccess    = "";
        public string username      = "";
        public float amount         = 0.0f;
        public string email         = "";
        public string payMethod = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            username = (string)Session["pay_username"];
            email = (string)Session["pay_email"];
            amount = (float)Session["pay_amount"];
            payMethod = Session["pay_method"].ToString();
            string code = Session["success_code"].ToString();
            

            urlSuccess = "http://postnl.wm-global-express.com/views/pay-success.aspx?username=" + username + "&amount=" + amount + "&email=" + email + "&paymethod=" + payMethod+"&code="+code;

            urlFailed = "http://postnl.wm-global-express.com/views/repeat-pay.aspx?username=" + username+"&code="+code;
   
        }
    }
}