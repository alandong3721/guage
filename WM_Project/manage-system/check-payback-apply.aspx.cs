using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using WM_Project.control;
using WM_Project.logical.common;
using WM_Project.logical.user;



namespace WM_Project.manage_system
{
    public partial class check_payback_apply : System.Web.UI.Page
    {
        public static PayBackApply payback = new PayBackApply();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["admin"] != null)
                {
                    string str = Request.QueryString["record_id"];
                    try
                    {
                        int id = Convert.ToInt32(str);

                        payback = new PayBackApplyDAO().getPayBackApply(id);
                        payback.Image = "super-admin-frame/paybackimage/" + payback.Image;
                        user_account.Text = payback.User_name;
                        txt_note.Text = payback.Note;
                    }
                    catch (System.Exception ex)
                    {
                        Response.Redirect("error-page.aspx");
                    }
                }
                else
                {
                    Response.Redirect("error-page.spx");
                }


            }
        }


        //审核通过
        protected void btn_pass_Click(object sender, EventArgs e)
        {
            int id = payback.Id;
            if (new PayBackApplyDAO().agreePayBack(id))
            {
                //跟新用户的债务表
                UserDebt userdebt = new UserDebt();
                userdebt = new UserDebtDAO().getUserDebt(payback.User_name);
                userdebt.Amount = userdebt.Amount - payback.Amount;
                new UserDebtDAO().updateUserDebt(userdebt);

                //向用户债务交易记录表中添加交易记录
                UserDebtTrans userdebttrans = new UserDebtTrans();
                userdebttrans.Amount = -payback.Amount;
                userdebttrans.Operation_time = DateTime.Now;
                userdebttrans.Operation = "还款";
                userdebttrans.Note = payback.Note;
                userdebttrans.User_name = payback.User_name;

                new UserDebtTransDAO().addUserDebtTrans(userdebttrans);

                alert("通过申请！！");
            }
            else
            {
                alert("系统繁忙，请稍后再提交!!");
            }

        }


        //审核不通过
        protected void btn_unPass_Click(object sender, EventArgs e)
        {
            int id = payback.Id;
            if (new PayBackApplyDAO().unAgreePayBack(id))
            {
                alert("审核不通过！！");
            }
            else
            {
                alert("系统繁忙，请稍后在提交！！");
            }
        }
        
        /// <summary>
        /// 弹出提示信息框
        /// </summary>
        /// <param name="message"></param>
        private void alert(string message) 
        {
            Response.Write(string.Format("<script language='javascript'>alert('{0}');</script>", message));
        }
    }
}