<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="add-staff.aspx.cs" Inherits="WM_Project.manage_system.super_admin_frame.add_staff" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title></title>
    <link href="../../stylesheets/bootstrap.css" rel="stylesheet" type="text/css" />
    <link href="../../stylesheets/bootstrap-theme.css" rel="stylesheet" type="text/css" />
    <script src="../../javascripts/bootstrap.js" type="text/javascript"></script>
    <script src="../../javascripts/jquery-1.11.1.js" type="text/javascript"></script>
    <script type="text/javascript">
        //添加员工信息时 信息是否为空
        function isStaffInfoNull() {

            var name = document.getElementsByName("staffname");
            var phone = document.getElementsByName("staffphone");
            var email = document.getElementsByName("staffemail");
            var pwd = document.getElementsByName("password");

            if (name[0].value.trim() == "") {
                alert("员工姓名不能为空！！"); 
                return false;
            } else if (phone[0].value.trim() == "") {
                alert("联系方式不能为空！！！");
                return false;
            }else if(email[0].value.trim()==""){
                alert("Email 不能为空！！");
                return false;
            }
            else if (pwd[0].value.trim() == "") {
                alert("员工密码不能为空！！");
                return false;
            }

            return true;
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div style="width: 700px;">
        <div class="panel panel-primary">
            <div class="panel-heading">
                <h3 class="panel-title">
                    添加工作人员</h3>
            </div>
            <div class="panel-body">
                <div class="form-group" style="margin-top: 10px; height: 40px; clear: both">
                    <div style="width: 120px; float: left; text-align: right">
                        <label class="control-label" style="padding-top: 5px; padding-right: 20px">
                            用户名</label></div>
                    <div style="width: 500px; float: left">
                        <input type="text" class="form-control" name="staffname" />
                    </div>
                    <div style="color: #FF0000; padding-left: 10px; padding-top: 10px; width: 40px; float: left">
                        *</div>
                </div>
                <div class="form-group" style="margin-top: 10px; height: 40px; clear: both">
                    <div style="width: 120px; float: left; text-align: right">
                        <label class="control-label" style="padding-top: 5px; text-align: right; padding-right: 20px">
                            联系方式</label>
                    </div>
                    <div style="width: 500px; float: left;">
                        <input type="text" class="form-control" name="staffphone" />
                    </div>
                    <div style="color: #FF0000; padding-left: 10px; padding-top: 10px; width: 40px; float: left">
                        *</div>
                </div>
                <div class="form-group" style="margin-top: 10px; height: 40px; clear: both">
                    <div style="width: 120px; float: left; text-align: right">
                        <label class="control-label" style="padding-top: 5px; text-align: right; padding-right: 20px">
                            邮箱</label>
                    </div>
                    <div style="width: 500px; float: left;">
                        <input type="text" class="form-control" name="staffemail" />
                    </div>
                    <div style="color: #FF0000; padding-left: 10px; padding-top: 10px; width: 40px; float: left">
                        *</div>
                </div>
                <div class="form-group" style="height: 40px; clear: both">
                    <div style="width: 120px; float: left; text-align: right">
                        <label class="control-label" style="padding-top: 5px; padding-right: 20px">
                            密码</label>
                    </div>
                    <div style="width: 500px; float: left">
                        <input type="password" class="form-control" name="password" />
                    </div>
                    <div style="color: #FF0000; padding-left: 10px; padding-top: 10px; width: 40px; float: left">
                        *</div>
                </div>
                <div class="form-group" style="height: 40px; clear: both">
                    <div style="width: 120px; float: left; text-align: right">
                        <label class="control-label" style="padding-top: 5px; padding-right: 20px">
                            类别</label>
                    </div>
                    <div style="width: 500px; float: left">
                        <select name="type" class="form-control">
                            <option>manager</option>
                            <option>staff</option>
                        </select>
                    </div>
                    <div style="color: #FF0000; padding-left: 10px; padding-top: 10px; width: 40px; float: left">
                        *</div>
                </div>
                <div class="form-group" style="text-align: center; height: 40px">
                    <asp:Button ID="btn_add_staff_right" runat="server" CssClass="btn btn-info" Text="添加员工"
                        OnClientClick="return isStaffInfoNull()" OnClick="btn_add_staff_right_Click" />
                </div>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
