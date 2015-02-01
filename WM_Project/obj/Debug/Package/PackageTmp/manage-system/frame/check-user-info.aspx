<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="check-user-info.aspx.cs" Inherits="WM_Project.manage_system.frame.check_user_info" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../stylesheets/bootstrap.css" rel="stylesheet" type="text/css" />
    <link href="../../stylesheets/bootstrap-theme.css" rel="stylesheet" type="text/css" />
    <script src="../../javascripts/bootstrap.js" type="text/javascript"></script>
    <script src="../../javascripts/jquery-1.11.1.js" type="text/javascript"></script>

    <script type="text/javascript">
        $(function () {

            $(".checkuserinfo").click(function () {
                var name = $(this).parent().parent().find(".username");

                if ($.trim(name.val()) == "") {
                    alert("用户名不能为空！！！");
                    return false;
                }
            });

        });
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <div class="panel panel-primary" style="width:700px;">
        <div class="panel-heading">
            <h5 class="panel-title">查找用户信息</h5>
        </div>
        <div class="panel-body">
            <div class="form-group" style="height:40px">
                <div style="width:160px;text-align:right;padding-right:10px;float:left;padding-top:6px">
                    <label class="control-label">User Name</label>
                </div>
                <div style="width:300px;float:left">
                    <asp:TextBox ID="txt_userName" runat="Server" CssClass="form-control username"></asp:TextBox>
                </div>
                <div style="width:100px;float:left;text-align:right;">
                    <asp:Button Text="查询" ID="btn_check_info" runat="Server" 
                        CssClass="btn btn-info checkuserinfo" onclick="btn_check_info_Click" />
                </div>
            </div>

            <div id="user_info" runat="Server" style="margin-top:40px" visible="false">
                <div class="form-group" style="clear:both;height:40px">
                    <div style="width:160px;text-align:right;padding-right:10px;padding-top:6px;float:left"><label class="control-label">UserName</label></div>
                    <div style="width:400px;float:left"><asp:TextBox ID="txt_Name" runat="Server" CssClass="form-control" ReadOnly="true"></asp:TextBox></div>
                </div>
                <div class="form-group" style="height:40px;clear:both">
                    <div style="width:160px;text-align:right;padding-right:10px;padding-top:6px;float:left">
                        <label class="control-label">Phone</label>
                    </div>
                    <div style="width:400px;float:left"><asp:TextBox ID="txt_phone" runat="Server" CssClass="form-control" ReadOnly="true"></asp:TextBox></div>
                </div>
                <div class="form-group" style="height:40px;clear:both">
                    <div style="width:160px;text-align:right;padding-right:10px;padding-top:6px;float:left">
                        <label class="control-label">Email</label>
                    </div>
                    <div style="width:400px;float:left"><asp:TextBox ID="txt_email" runat="Server" CssClass="form-control" ReadOnly="true"></asp:TextBox></div>
                </div>
            </div>
        </div>
        <div class="panel-footer"></div>
    </div>
    </form>
</body>
</html>
