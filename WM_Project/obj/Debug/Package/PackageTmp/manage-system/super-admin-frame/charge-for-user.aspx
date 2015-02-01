<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="charge-for-user.aspx.cs"
    Inherits="WM_Project.manage_system.super_admin_frame.charge_for_user" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../stylesheets/bootstrap.css" rel="stylesheet" type="text/css" />
    <link href="../../stylesheets/bootstrap-theme.css" rel="stylesheet" type="text/css" />
    <script src="../../javascripts/bootstrap.js" type="text/javascript"></script>
    <script src="../../javascripts/jquery-1.11.1.js" type="text/javascript"></script>

    <script type="text/javascript">

        //充值时的验证
        function isChargeValidate() {
            var account = document.getElementsByName("charge_account");
            var money = document.getElementsByName("charge_money");

            if (account[0].value.trim() == "") {
                alert("充值账户不能为空！！");
                return false;
            } else if (money[0].value.trim() == "") {
                alert("充值金额不能为空！！");
                return false;
            } else if (!isUnsignedNumeric(money[0].value)) {
                alert("充值金额必须为数字！！");
                return false;
            }

            return true;
        }

        /*
        *	验证是否是正实数,不包括 0 
        */
        function isUnsignedNumeric(strNumber) {
            if (strNumber.trim() != 0) {
                var newPar = /^\d+(\.\d+)?$/;
                return newPar.test(strNumber.trim());
            }
            else {
                return false;
            }

        }
    
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <div class="panel panel-primary" style="width: 700px">
        <div class="panel-heading">
            <h3 class="panel-title">
                给用户充值</h3>
        </div>
        <div class="panel-body">
            <div class="form-group" style="margin-top: 10px; height: 40px; clear: both">
                <div style="width: 120px; float: left; text-align: right">
                    <label class="control-label" style="padding-top: 5px; padding-right: 20px">
                        充值账户</label></div>
                <div style="width: 500px; float: left">
                    <input type="text" class="form-control" name="charge_account" />
                </div>
                <div style="color: #FF0000; padding-left: 10px; padding-top: 10px; width: 40px; float: left">
                    *</div>
            </div>
            <div class="form-group" style="margin-top: 10px; height: 40px; clear: both">
                <div style="width: 120px; float: left; text-align: right">
                    <label class="control-label" style="padding-top: 5px; padding-right: 20px">
                        金额£</label>
                </div>
                <div style="width: 500px; float: left">
                    <input type="text" class="form-control" name="charge_money" />
                </div>
                <div style="color: #FF0000; padding-left: 10px; padding-top: 10px; width: 40px; float: left">
                    *</div>
            </div>
            <div class="form-group" style="text-align: center; height: 40px">
                <asp:Button ID="btn_affirm_charge" runat="server" CssClass="btn btn-info" Text="确认充值"
                    OnClick="btn_affirm_charge_Click" OnClientClick="return isChargeValidate()" /></div>
        </div>
        <div style="height: 30px">
            &nbsp;</div>
        <div class="panel-footer" style="color: #FF0000">
            * 充值前确认账户信息，充值账户必须是用户的登陆名，否则充值错误！！！</div>
    </div>
    </form>
</body>
</html>
