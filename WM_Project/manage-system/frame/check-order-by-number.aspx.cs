using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using WM_Project.control;
using WM_Project.logical.common;

namespace WM_Project.manage_system.frame
{
    public partial class check_order_by_number : System.Web.UI.Page
    {
        public  ArrayList packages = new ArrayList();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["staff"] == null && Session["admin"] == null&&Session["manager"]==null)
                {
                    Response.Redirect("../error-page.aspx");
                }
                
            }
        }

        /// <summary>
        /// 弹出提示信息
        /// </summary>
        /// <param name="message">提示信息</param>
        private void alert(string message)
        {
            Response.Write(string.Format("<script language='javascript'>alert('{0}');</script>", message));
        }



        /// <summary>
        /// 根据订单号查找订单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_query_order_Click(object sender, EventArgs e)
        {
            string track_no = txt_number.Text;

            // 首先查找 Excel 下单的订单
            AutoOrderList autolist = new AutoOrderList();
            autolist = new AutoOrderListDAO().getAutoOrderListByTrackNo(track_no);

            if (autolist.Ea_track_no != track_no)
            {
                Package package = new PackageDAO().getPackageByTrackNo(track_no);
                
                if (package.Ea_track_no != track_no)
                {
                    alert("不存在该订单！！");
                }
                else
                {
                    Order order = new OrderDAO().getOrder(package.Order_number);
                    autolist.Order_no = package.Wp_track_no;
                    autolist.Ea_track_no = track_no;
                    autolist.CollectionContactName = order.CollectionContactName;
                    autolist.RecipientContactName = order.RecipientContactName;
                    autolist.Weight = package.Weight;
                    autolist.Pay_after_discount = package.Pay;
                    autolist.Pay_time = order.Pay_time;

                    packages.Add(autolist);
                }

            }
            else
            {
                packages.Add(autolist);
            }     
            

        }
    }
}