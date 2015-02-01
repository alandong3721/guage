using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using WM_Project.control;

namespace WM_Project.manage_system.frame
{
    public partial class ems_last_order_number_check : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int count = new EMSOrderNoDAO().getEMSOrderNoLast();
                txt_order_last.Text = count.ToString();
            }
        }
    }
}