<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="order-number-error.aspx.cs" Inherits="WM_Project.views.exception.order_number_error" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../stylesheets/bootstrap.css" rel="stylesheet" type="text/css" />
    <link href="../../stylesheets/bootstrap-theme.css" rel="stylesheet" type="text/css" />
    <link href="../../stylesheets/style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="panel panel-primary">
        <div class="panel-heading">
            <h5 class="panel-title">非法查看订单</h5>
        </div>
        <div class="panel-body">
            <div class="form-group">
                <p style="text-align:center;color:#3C85C4">您非法查看订单，我们已经记录您本次的浏览记录！！</p>
            </div>
        </div>
        <div class="panel-footer"></div>    
    </div>
    </form>
</body>
</html>
