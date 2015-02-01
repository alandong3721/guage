using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WM_Project.views.inter_express
{
    public partial class paycard : System.Web.UI.Page
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
            username = (string)Session["pay_username"];
            email = (string)Session["pay_email"];
            amount1 = (float)Session["pay_amount"];
            amount = amount1.ToString("0.00");
            payMethod = Session["pay_method"].ToString();
            string code = Session["success_code"].ToString();
            string type = Session["type"].ToString();

            urlSuccess = "http://postnl.wm-global-express.com/views/pay-success.aspx?username=" + username + "&amount=" + amount + "&email=" + email + "&paymethod=" + payMethod + "&code=" + code + "&type=" + type;

            urlFailed = "http://postnl.wm-global-express.com/views/repeat-pay.aspx?username=" + username + "&code=" + code + "&type=" + type;

        }
    }
}