<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ems-last-order-number-check.aspx.cs" Inherits="WM_Project.manage_system.frame.ems_last_order_number_check" %>

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
    <div class="panel panel-primary" style="width: 800px; font-size: 13px">
        <div class="panel-heading">
            <h5 class="panel-title">
                EMS 剩余单号查询</h5>
        </div>
        <div class="panel-body">
            <div class="form-group" style="height:100px;padding-top:40px">
                <div style="width:260px;float:left;text-align:right">
                    <label class="control-label" style="padding-top:8px;padding-right:20px">可用的EMS单号的个数：</label>
                </div>
                <div style="width:400px;float:left">
                    <asp:TextBox CssClass="form-control" ID="txt_order_last" runat="Server" ReadOnly="true"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="panel-footer">
            <p style="color:#FF0000; font-weight:600">*&nbsp;显示的是可用的 EMS 单号</p>
        </div>
    </div>
    </form>
</body>
</html>
