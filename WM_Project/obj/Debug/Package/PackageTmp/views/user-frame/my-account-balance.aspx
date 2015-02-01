<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="my-account-balance.aspx.cs"
    Inherits="WM_Project.views.user_frame.my_account_balance" %>

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
                账户余额</h5>
        </div>
        <div class="panel-body">
            <div class="form-group" style="clear:both;height:40px">
                <div style="width:180px;text-align:right;float:left;padding-right:20px">
                    <label style="text-align: right; padding-top: 5px;">
                        账户名</label>
                </div>
                <div style="padding-left: 0px; padding-right: 0px;width:460px;float:left">
                    <input type="text" class="form-control" readonly="readonly" value="<%=myaccount.Name %>" /></div>
            </div>
            <div class="form-group" style="height:40px;clear:both">
                <div style="width:180px;float:left;text-align:right;padding-right:20px">
                    <label style="text-align: right; padding-top: 5px">
                        余额&nbsp;£</label>
                </div>
                <div style="width:460px;float:left">
                    <input type="text" class="form-control" readonly="readonly" value="<%=myaccount.Balance %>" /></div>
            </div>
        </div>
        <div class="panel-footer">
        </div>
    </div>
    </form>
</body>
</html>
