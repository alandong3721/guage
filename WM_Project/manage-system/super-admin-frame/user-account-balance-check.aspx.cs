using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using WM_Project.control;
using WM_Project.logical.user;

namespace WM_Project.views.super_admin_frame
{
    public partial class user_account_balance_check : System.Web.UI.Page
    {

        public int record_count = 0;
        public int page_count = 0;
        public int page_size = 20;
        public int page_now = 1;

        public ArrayList my_account_array = new ArrayList();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["admin"] == null)
                {
                    Response.Redirect("../error-page.aspx");
                }
                else
                {
                    string page = Request.QueryString["pageNow"];
                    if (page == null)
                    {
                        page_now = 1;
                        record_count = new MyAccountDAO().getMyAccountCount();
                        page_count = new MyAccountDAO().getMyAccountPageCount(record_count, page_size);
                        my_account_array = new MyAccountDAO().getMyAccountArray(page_now, page_size);
                    }
                    else
                    {
                        page_now = Convert.ToInt32(page);
                        record_count = new MyAccountDAO().getMyAccountCount();
                        page_count = new MyAccountDAO().getMyAccountPageCount(record_count, page_size);
                        my_account_array = new MyAccountDAO().getMyAccountArray(page_now, page_size);

                    }
                }
                
            }
        }


        /// <summary>
        /// 按用户名查找用户的账户余额
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_check_balance_Click(object sender, EventArgs e)
        {
            string name = Request.Form["txt_username"];
            MyAccount myaccount = new MyAccountDAO().getMyAccount(name);

            my_account_array.Clear();

            if (myaccount == null)
            {
                alert("该用户的余额为 0 ，并且该用户没有任何交易记录！！");
                page_now = 1;
                record_count = new MyAccountDAO().getMyAccountCount();
                page_count = new MyAccountDAO().getMyAccountPageCount(record_count, page_size);
                my_account_array = new MyAccountDAO().getMyAccountArray(page_now, page_size);
            }
            else
            {
                page_now = 1;
                record_count = 1;
                page_count = 1;
                my_account_array.Add(myaccount);
            }


        }

        /// <summary>
        /// 弹出提示信息
        /// </summary>
        /// <param name="message"></param>
        private void alert(string message)
        {
            Response.Write(string.Format("<script language='javascript'>alert('{0}');</script>", message));
        }

    }
}