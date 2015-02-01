<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="error-page.aspx.cs" Inherits="WM_Project.views.exception.error_page" %>

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
    <div class="panel panel-primary" style="width: 700px; margin: 0 auto; margin-top: 60px;">
        <div class="panel-heading">
            <h5 class="panel-title">
                错误操作</h5>
        </div>
        <div class="panel-body" style="height:400px">
            <div class="form-group">
                <%=message %>
            </div>
        </div>
        <div class="panel-footer">
        </div>
    </div>
    </form>
</body>
</html>
