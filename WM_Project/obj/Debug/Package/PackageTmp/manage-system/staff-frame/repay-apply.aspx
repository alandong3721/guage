<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="repay-apply.aspx.cs" Inherits="WM_Project.manage_system.staff_frame.repay_apply" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../../stylesheets/bootstrap.css" rel="stylesheet" type="text/css" />
    <link href="../../stylesheets/bootstrap-theme.css" rel="stylesheet" type="text/css" />
    <script src="../../javascripts/bootstrap.js" type="text/javascript"></script>
    <script src="../../javascripts/jquery-1.11.1.js" type="text/javascript"></script>

    <script type="text/javascript">
        $(document).ready(function ($) {

            function isUnsignedNumber(strNumber) {
                if (strNumber.trim() != 0) {
                    var newPar = /^\d+(\.\d+)?$/;
                    return newPar.test(strNumber.trim());
                }
                else {
                    return false;
                }

            }

            $(".repay").click(function () {

                var account = $(this).parent().parent().parent().find(".account_repay");

                var money = $(this).parent().parent().parent().find(".money_repay");

                var pwd = $(this).parent().parent().parent().find(".your-password");

                if (account.eq(0).val().trim() == "") {
                    alert("还款账户不能为空！！");
                    return false;
                } else if (money.eq(0).val().trim() == "") {
                    alert("还款金额不能为空！！");
                    return false;
                } else if (!isUnsignedNumber(money.eq(0).val())) {
                    alert("还款金额必须为数字！！");
                    return false;
                }

                return true;

            });

        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class=" panel panel-primary" style="width: 700px; ">
        <div class="panel-heading">
            <h5 class="panel-title">
                为用户还款</h5>
        </div>
        <div class="panel-body">
            <div class="form-group" style="clear:both;height:40px">
                <div style="padding-top: 5px; width: 120px;float:left;padding-left:40px">
                    <label class="control-label">
                        还款账户</label>
                </div>
                <div style="width: 500px;float:left">
                    <asp:TextBox ID="user_account" runat="Server" CssClass="form-control account_repay"></asp:TextBox>
                </div>
                <div style="color: #FF0000; width: 40px; padding-top: 10px;float:left;text-align:center">
                    *</div>
            </div>
            <div class="form-group" style="clear:both;height:40px">
                <div style="padding-top: 5px; width: 120px;float:left;padding-left:40px">
                    <label class="control-label">
                        金额£</label>
                </div>
                <div style="width: 500px;float:left">
                    <input type="text" class="form-control money_repay" name="repay_money" />
                </div>
                <div style="color: #FF0000; width: 40px; padding-top: 10px;float:left;text-align:center">
                    *</div>
            </div>
            <div class="form-group" style="clear:both;height:120px">
                <div style="padding-top: 40px; width: 120px;float:left;padding-left:40px">
                    <label class="control-label">
                        备注</label>
                </div>
                <div style="width:500px;float:left">
                    <textarea class="form-control note_repay" name="note_repay" rows="4" cols="40" style="resize:none;width:500px"></textarea>
                </div>
                <div style="color: #FF0000;width:40px;float:left">
                    &nbsp;</div>
            </div>
            <div class="form-group" style="clear:both;height:40px">
                <div style="padding-top: 5px; width: 120px;float:left;padding-left:40px">
                    <label class="control-label">
                        上传凭证</label>
                </div>
                <div style="width:500px;float:left">
                    <asp:FileUpload ID="uplaod_image" runat="server" Width="240px" />
                </div>
                <div style="color: #FF0000;width:40px;float:left">
                    &nbsp;</div>
            </div>
            <div class="form-group" style="text-align:center;height:40px">
                    <asp:Button ID="btn_user_repay_right" runat="server" CssClass="btn btn-info repay"
                        Text="申请还款" OnClick="btn_user_repay_right_Click" Width="120px" />
            </div>
            <div style="height: 10px">
                &nbsp;</div>
        </div>
        <div class="panel-footer" style="color: #FF0000">
            *用户必须在欠华盟快递的钱的前提下，才能为用户还款，如果用户只华盟快递 £2000，而该用户向华盟快递转了£3000，那么管理员应该先为该用户还款£2000，再为用户充值£1000，再又为用户还款£1000
            <br />
            * 还款前请确认账户信息，还款账户必须是用户的登陆名，还款金额必须小于等于欠款金额！！！</div>
    </div>
    
    </form>
</body>
</html>

