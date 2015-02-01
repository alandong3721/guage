<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/back-stage/home.Master" AutoEventWireup="true"
    CodeBehind="manager-login.aspx.cs" Inherits="WM_Project.manage_system.manager_login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%--此处写CSS、javascript代码--%>
    <script type="text/javascript">

        ///登陆前的验证

        function isNull() {
            var name = document.getElementById("txt_username").value;
            var password = document.getElementById("txt_password").value;
   
            if (name.trim() == "" || password.trim() == "") {
                alert("带*号的不能为空！");
                return false;
            }

            return true;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="center" runat="server">
    <div id="Div1" runat="Server" style="width: 70%; margin: 0 auto">
        <div class="panel panel-primary">
            <div class="panel-heading">
                <h3 class="panel-title">
                    Manager Login</h3>
            </div>
            <div class="panel-body">
                <div class="form-group" style="height: 30px; margin-top: 10px">
                    <label for="username" class="col-md-3 control-label" style="padding-top: 8px;text-align:right">
                        User&nbsp;&nbsp;Name:</label>
                    <div class="col-md-7" style="padding-left: 0px">
                        <input type="text" class="form-control" id="txt_username" name="txt_username" placeholder="please input user name" />
                    </div>
                    <div class="col-md-2" style="color: #FF0000; padding-top: 10px">
                        *
                    </div>
                </div>
                <div class="form-group" style="height: 30px; margin-top: 0px;">
                    <label for="password" class="col-md-3 control-label" style="padding-top: 8px;text-align:right">
                        Password:</label>
                    <div class="col-md-7" style="padding-left: 0px">
                        <input type="password" class="form-control" name="txt_password" id="txt_password" autocomplete="off" />
                    </div>
                    <div class="col-md-2" style="color: #FF0000; padding-top: 10px">
                        *
                    </div>
                </div>
                <div class="form-group" style="height: 30px; margin-top: 0px;">
                    <label for="password" class="col-md-3 control-label" style="padding-top: 8px;text-align:right">
                        Type:</label>
                    <div class="col-md-3" style="padding-left: 0px">
                        <select name="type" class="form-control">
                            <option>admin</option>
                            <option>manager</option>
                            <option>staff</option>
                        </select>
                    </div>
                    <div class="col-md-6" style="color: #FF0000; padding-top: 10px">
                        <p>
                            admin 代表管理员</p>
                    </div>
                </div>
                <div class="form-group" style="height: 30px; padding-top: 20px">
                    <div style="text-align: center">
                        <asp:Button ID="btn_login" runat="Server" Text="登陆" OnClientClick="return isNull();"
                            CssClass="btn btn-info" OnClick="btn_login_Click" /></div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
