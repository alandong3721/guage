<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="change-person-info.aspx.cs" Inherits="WM_Project.views.user_frame.change_person_info" %>

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
    <div class="panel panel-primary" style="width:780px">
        <div class="panel-heading">
            <h5 class="panel-title">我的个人信息</h5>
        </div>
        <div class="panel-body">
                <div class="form-group" style="margin-top: 10px; height: 40px; clear: both">
                    <div style="width: 180px; float: left; text-align: right;padding-right:20px;padding-top:5px;">
                        <label class="control-label">User Name</label>
                    </div>
                    <div style="width:460px;float:left;">
                        <asp:TextBox CssClass="form-control name" ID="username" runat="Server" ReadOnly="true"></asp:TextBox>
                    </div>
                    <div style="width:80px;float:left">
                        &nbsp;
                    </div>
                </div>
                <div class="form-group" style="margin-top: 10px; height: 40px; clear: both">
                    <div style="width: 180px; float: left; text-align: right;padding-right:20px;padding-top:5px;">
                        <label class="control-label">Email</label>
                    </div>
                    <div style="width:460px;float:left;">
                        <asp:TextBox CssClass="form-control email" ID="useremail" runat="Server" ReadOnly="true"></asp:TextBox>
                    </div>
                    <div style="width:80px;float:left;color:Red;padding-top:10px;padding-left:10px">
                        *
                    </div>
                </div>
                <div class="form-group" style="margin-top: 10px; height: 40px; clear: both">
                    <div style="width: 180px; float: left; text-align: right;padding-right:20px;padding-top:5px;">
                        <label class="control-label">Phone</label>
                    </div>
                    <div style="width:460px;float:left;">
                        <asp:TextBox CssClass="form-control phone" ID="userphone" runat="Server"></asp:TextBox>
                    </div>
                    <div style="width:80px;float:left;color:Red;padding-top:10px;padding-left:10px">
                        *
                    </div>
                </div>
                
                <div class="form-group" style="margin-top: 10px; height: 40px; clear: both">
                    <div style="width: 180px; float: left; text-align: right;padding-right:20px;padding-top:5px;">
                        <label class="control-label">Website</label>
                    </div>
                    <div style="width:460px;float:left;">
                        <asp:TextBox CssClass="form-control website" ID="userwebsite" runat="Server"></asp:TextBox>
                    </div>
                    <div style="width:80px;float:left;color:Red;padding-top:10px;padding-left:10px">
                        &nbsp;
                    </div>
                </div>
                <div class="form-group" style="margin-top: 10px; height: 40px; clear: both">
                    <div style="width: 180px; float: left; text-align: right;padding-right:20px;padding-top:5px;">
                        <label class="control-label">Company Name</label>
                    </div>
                    <div style="width:460px;float:left;">
                        <asp:TextBox CssClass="form-control company" ID="usercompanyname" runat="Server"></asp:TextBox>
                    </div>
                    <div style="width:80px;float:left;color:Red;padding-top:10px;padding-left:10px">
                        &nbsp;
                    </div>
                </div>
                <div class="form-group" style="margin-top: 10px; height: 40px; clear: both;text-align:center">
                    <asp:Button  runat="server" CssClass="btn btn-info updateuser" Text="修改" ID="btn_change" 
                        Width="120px" onclick="btn_change_Click"/>
                </div>
            </div>
        <div class="panel-footer"></div>
    </div>
    </form>
</body>
</html>
