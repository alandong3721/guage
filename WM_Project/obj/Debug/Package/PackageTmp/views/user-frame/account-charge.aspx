<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="account-charge.aspx.cs"
    Inherits="WM_Project.views.user_frame.account_charge" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../stylesheets/bootstrap.css" rel="stylesheet" type="text/css" />
    <link href="../../stylesheets/bootstrap-theme.css" rel="stylesheet" type="text/css" />
    <script src="../../javascripts/bootstrap.js" type="text/javascript"></script>
    <script src="../../javascripts/jquery-1.11.1.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="panel panel-primary" style="width: 780px">
        <div class="panel-heading">
            <h5 class="panel-title">
                账户充值</h5>
        </div>
        <div class="panel-body">
            <div class="form-group" style="height: 35px; clear: both">
                <div style="width: 195px; float: left;text-align:right;">
                    <label class="control-label" style="text-align: right; padding-top: 5px">
                        充值账户</label></div>
                <div style="width: 500px; float: left">
                    <asp:TextBox ID="charge_account" runat="Server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                </div>
            </div>
            <div class="form-group" style="height: 35px;clear:both">
                <div style="width:195px;float:left;text-align:right">
                <label class="control-label" style="text-align: right; padding-top: 5px">
                    充值金额</label></div>
                <div style="width:500px;float:left">
                    <input type="text" class="form-control" name="charge_amount" />
                </div>
            </div>
            <div class="form-group" style="text-align: center; height: 35px;clear:both">
                <asp:Button ID="btn_charge_now" runat="Server" Text="充值" CssClass="btn btn-info"
                    Width="120px" OnClick="btn_charge_now_Click" OnClientClick="return isChargeAccount()" />
            </div>
        </div>
        <div class="panel-footer">
            <p style="color: #FF0000">
                *&nbsp;自己只能给自己的账户充值,不能给别人的账户充值</p>
        </div>
    </div>
    </form>
</body>
</html>
