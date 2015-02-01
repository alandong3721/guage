<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="admin-change-password.aspx.cs"
    Inherits="WM_Project.manage_system.super_admin_frame.admin_change_password" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../stylesheets/bootstrap.css" rel="stylesheet" type="text/css" />
    <link href="../../stylesheets/bootstrap-theme.css" rel="stylesheet" type="text/css" />
    <script src="../../javascripts/bootstrap.js" type="text/javascript"></script>
    <script src="../../javascripts/jquery-1.11.1.js" type="text/javascript"></script>
    <script type="text/javascript">
        function isnull() {

            var old = document.getElementById("oldpwd").value;
            var newpwd = document.getElementById("newpwd").value;
            var repeat = document.getElementById("repeat").value;

            if (old == "" || newpwd == "" || repeat == "") {
                alert("带 * 号的不能为空！！");
                return false;
            }
            else if (newpwd != repeat) {
                alert("两次密码不一致");
                return false;
            }

            return true;
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="panel panel-primary" style="width: 700px">
        <div class="panel-heading">
            <h5 class="panel-title">
                修改密码</h5>
        </div>
        <div class="panel-body">
            <div class="form-group" style="height: 40px;clear:both">
                <div style="width: 160px;float:left;padding-left:40px;">
                    <label class="control-label" style="text-align: right;padding-top:5px;">
                        Old Password</label>
                </div>
                <div style="width: 460px;float:left">
                    <input type="password" name="oldpwd" id="oldpwd" class="form-control" /></div>
                <div style="width: 40px; color: #FF0000;float:left;padding-top:10px;">
                    *</div>
            </div>
            <div class="form-group" style="height: 40px;clear:both">
                <div style="width: 160px;float:left;padding-left:40px;">
                    <label class="control-label" style="text-align: right;padding-top:5px">
                        New Password</label>
                </div>
                <div style="width: 460px;float:left">
                    <input type="password" name="newpwd" id="newpwd" class="form-control" /></div>
                <div style="color: #FF0000; width: 40px;float:left;padding-top:10px;">
                    *</div>
            </div>
            <div class="form-group" style="height: 40px;clear:both">
                <div style="width: 160px;float:left;padding-left:40px">
                    <label class="control-label" style="text-align: right;padding-top:5px">
                        Repeat</label>
                </div>
                <div style="width: 460px;float:left">
                    <input type="password" name="repeat" id="repeat" class="form-control" /></div>
                <div style="color: #FF0000; width: 40px;float:left;padding-top:10px;">
                    *</div>
            </div>
            <div class="form-group" style="padding-top: 10px; text-align: center;clear:both">
                <asp:Button ID="btn_change_pwd" CssClass="btn btn-info" Text="修改密码" runat="server" OnClick="btn_change_pwd_Click"
                    OnClientClick="return isnull()" /></div>
        </div>
        <div class="footer">
        </div>
    </div>
    </form>
</body>
</html>
