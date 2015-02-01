using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using WM_Project.control;
using WM_Project.logical.user;
using WM_Project.logical.common;

namespace WM_Project.manage_system.staff_frame
{
    public partial class repay_apply : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["staff"] == null&&Session["manager"]==null)
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
            string path = uplaod_image.FileName;


            if (path == "")
            {
                alert("请选择图片");
            }
            else
            {
                //首先判断该用户是否欠
                UserDebt user_debt = new UserDebtDAO().getUserDebt(account);

                if (user_debt != null)
                {
                    if (user_debt.Amount >= Convert.ToSingle(money_str))
                    {
                        //申请返款
                        PayBackApply payback = new PayBackApply();
                        payback.User_name = account;
                        payback.Amount = Convert.ToSingle(money_str);
                        payback.Operation = "申请还款";
                        payback.Staff_apply = Session["staff"].ToString();
                        payback.Note = note;
                        payback.Operation_time = DateTime.Now;
                        payback.Is_aggree = 0;

                        payback.Image = saveUploadFile(account);

                        if (new PayBackApplyDAO().addPayBackApply(payback))
                        {
                            //还款成功
                            // 记录交易信息
                            alert("申请成功！！");
                        }
                        else
                        {
                            alert("申请失败！！");
                        }
                    }
                    else
                    {
                        alert("用户欠款金额为：" + user_debt.Amount + " ；还款金额为：" + money_str + "，无法进行还款申请！！");
                    }


                }
                else
                {
                    alert("该用户不欠款，请确认用户信息！！");
                }

            }
            
        }



        /// <summary>
        /// 保存上传的文件
        /// </summary>
        /// <returns>返回文件的路径</returns>
        private string saveUploadFile(string account)
        {

            string file = Path.GetFileName(this.uplaod_image.PostedFile.FileName);//用于保存到数据库中的上传文件URL路径
            
            string fileName = account + DateTime.Now.ToString("yyyyMMddHHmmss") + file;
            string pathFile = Server.MapPath("~/manage-system/super-admin-frame/paybackimage/" + fileName);

            this.uplaod_image.PostedFile.SaveAs(pathFile); //文件上传保存 
            return fileName;

        }


        //弹出提示信息框
        private void alert(string message)
        {
            Response.Write(string.Format("<script language='javascript'>alert('{0}');</script>", message));
        }
    }
}