<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="import-ems-order-number.aspx.cs"
    Inherits="WM_Project.manage_system.frame.import_ems_order_number" %>

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
                EMS 单号导入</h5>
        </div>
        <div class="panel-body">
            <div class="form-group" style="height: 100px; padding-top: 40px;">
                <div style="width:200px;text-align:right;float:left">
                    <label class="control-label" style="text-align: right">请选择 Excel 文件</label>
                </div>
                
                <div style="text-align: left;float:left;width:360px;padding-left:60px">
                    <asp:FileUpload ID="ems_order_file" runat="Server" /></div>
                <div style="text-align: center;width:180px;float:left">
                    <asp:Button ID="btn_order_file_upload" runat="Server" CssClass="btn btn-info" 
                        Text="EMS 单号导入" onclick="btn_order_file_upload_Click" />
                </div>
            </div>
        </div>
        <div class="panel-footer">
            <p style="color:#FF0000; font-weight:600">导入 EMS 单号的 Excel 中 EMS 单号所在列的列名为 "ems_no"</p>
        </div>
    </div>
    </form>
</body>
</html>
