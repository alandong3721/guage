using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using WM_Project.logical.user;
using WM_Project.control;

namespace WM_Project.manage_system.super_admin_frame
{
    public partial class repayment_for_user : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["admin"] == null)
                {
                    Response.Redirect("../error-page.aspx");

                }
            }
        }

        //用户还款的具体实现
        protected void btn_user_repay_right_Click(object sender, EventArgs e)
        {
            string account = user_account.Text;
            string money_str = Request.Form["repay_money"];
            string note = Request.Form["note_repay"];

            //首先判断该用户是否欠
            UserDebt user_debt = new UserDebtDAO().getUserDebt(account);

            if (user_debt != null)
            {
                if (user_debt.Amount >= Convert.ToSingle(money_str))
                {
                    // 跟新用户的 欠款表
                    UserDebt userdebt = new UserDebt();
                    userdebt.Amount = -Convert.ToSingle(money_str);
                    userdebt.User_name = account;
                    if (new UserDebtDAO().updateUserDebt(userdebt))
                    {
                        //还款成功
                        // 记录交易信息
                        UserDebtTrans userdebttrans = new UserDebtTrans();
                        userdebttrans.Operation = "还款";
                        userdebttrans.Operation_time = DateTime.Now;
                        userdebttrans.User_name = account;
                        userdebttrans.Amount = -Convert.ToSingle(money_str);
                        userdebttrans.Note = note;
                        new UserDebtTransDAO().addUserDebtTrans(userdebttrans);

                        alert("还款成功！！");
                    }
                    else
                    {
                        alert("还款失败！！");
                    }
                }
                else
                {
                    alert("用户欠款金额为：" + user_debt.Amount + " ；还款金额为：" + money_str + "，无法进行还款！！");
                }


            }
            else
            {
                alert("该用户不欠款，请确认用户信息！！");
            }

        }


        //弹出提示信息框
        private void alert(string message)
        {
            Response.Write(string.Format("<script language='javascript'>alert('{0}');</script>", message));
        }
    }
}