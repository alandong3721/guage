<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="change-person-info.aspx.cs" Inherits="WM_Project.manage_system.manager_frame.change_person_info" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../../stylesheets/bootstrap.css" rel="stylesheet" type="text/css" />
    <link href="../../stylesheets/bootstrap-theme.css" rel="stylesheet" type="text/css" />
    <script src="../../javascripts/bootstrap.js" type="text/javascript"></script>
    <script src="../../javascripts/jquery-1.11.1.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {

            $(".updatestaff").click(function () {

                var phone = $(this).parent().parent().find(".phone");
                var email = $(this).parent().parent().find(".email");

                if ($.trim(phone.val()) == "") {
                    alert("电话号码不能为空！！");
                    return false;
                }
                else if ($.trim(email.val()) == "") {
                    alert("电话号码不能为空！！");
                    return false;
                }
                return true;
            });
        });
    
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div style="width: 700px;">
        <div class="panel panel-primary">
            <div class="panel-heading">
                <h3 class="panel-title">
                    修改个人信息</h3>
            </div>
            <div class="panel-body">
                <div class="form-group" style="margin-top: 10px; height: 40px; clear: both">
                    <div style="width: 110px; float: left; text-align: right;padding-right:20px;padding-top:5px;">
                        <label class="control-label">User Name</label>
                    </div>
                    <div style="width:500px;float:left;">
                        <asp:TextBox CssClass="form-control name" ID="staffname" runat="Server" ReadOnly="true"></asp:TextBox>
                    </div>
                    <div style="width:40px;float:left">
                        &nbsp;
                    </div>
                </div>
                <div class="form-group" style="margin-top: 10px; height: 40px; clear: both">
                    <div style="width: 110px; float: left; text-align: right;padding-right:20px;padding-top:5px;">
                        <label class="control-label">Phone</label>
                    </div>
                    <div style="width:500px;float:left;">
                        <asp:TextBox CssClass="form-control phone" ID="staffphone" runat="Server"></asp:TextBox>
                    </div>
                    <div style="width:40px;float:left;color:Red;padding-top:10px;padding-left:10px">
                        *
                    </div>
                </div>
                <div class="form-group" style="margin-top: 10px; height: 40px; clear: both">
                    <div style="width: 110px; float: left; text-align: right;padding-right:20px;padding-top:5px;">
                        <label class="control-label">Email</label>
                    </div>
                    <div style="width:500px;float:left;">
                        <asp:TextBox CssClass="form-control email" ID="staffemail" runat="Server"></asp:TextBox>
                    </div>
                    <div style="width:40px;float:left;color:Red;padding-top:10px;padding-left:10px">
                        *
                    </div>
                </div>
                <div class="form-group" style="margin-top: 10px; height: 40px; clear: both;text-align:center">
                    <asp:Button  runat="server" CssClass="btn btn-info updatestaff" Text="修改" ID="btn_change" 
                        Width="120px" onclick="btn_change_Click"/>
                </div>
            </div>
            <div class="panel-footer"></div>
        </div>
    </div>
    </form>
</body>
</html>
