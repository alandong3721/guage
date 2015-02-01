using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WM_Project.logical.user;
using System.Web.SessionState;

namespace WM_Project.views.inter_express
{
    /// <summary>
    /// ReceiveAdress 的摘要说明
    /// </summary>
    public class ReceiveAdress : IHttpHandler,IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            Address address =(Address)(context.Session["address"]);
            string str = address.Addr_contact + ";" + address.Company_name + ";" + address.Addr_line1 + address.Addr_line2 + address.Addr_line3 + ";" + address.City + ";" + address.Post_code + ";" + address.Country + ";" + address.Phone;
            context.Response.Write(str);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}