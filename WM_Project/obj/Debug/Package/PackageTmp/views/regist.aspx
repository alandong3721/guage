<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/reception-stage/home.Master" AutoEventWireup="true"
    CodeBehind="regist.aspx.cs" Inherits="WM_Project.views.regist" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%--javascript代码--%>
    <script type="text/javascript">

        //    验证输入是否合理
        function isLegal() {

            var name = document.getElementById("txt_userName").value;
            var e_mail = document.getElementById("txt_email").value;
            var recuser = document.getElementById("txt_recommendUser").value;
            var website = document.getElementById("txt_website").value;
            var phone = document.getElementById("txt_telephone").value;
            var pass = document.getElementById("txt_password").value;
            var repass = document.getElementById("txt_repwd").value;
            var code = document.getElementById("txt_code").value;

            if (isNull(name) ||isNull(phone) || isNull(pass) || isNull(code)) {
                alert("带*的不能为空！");
                return false;
            }
            if (!isEmail(e_mail)) {

                alert("邮箱格式错误！");
                return false;
            }

            if (pass != repass) {
                alert("两次密码不一致");
                return false;
            }

            return true;
        }

        //验证是否为空
        function isNull(obj) {
            if (obj == "")
                return true;
            else
                return false;
        }

        //验证邮箱
        function isEmail(mail) {
            return (new RegExp(/^\w+((-\w+)|(\.\w+))*\@[A-Za-z0-9]+((\.|-)[A-Za-z0-9]+)*\.[A-Za-z0-9]+$/).test(mail));
        }


        function isNNN() {
            alert("dfdf");
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="center_right" runat="server">
    <div class="form-horizontal">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="row" runat="Server" id="first">
        <div class="panel panel-primary">
            <div class="panel-heading">
                <h3 class="panel-title">
                    会员注册</h3>
            </div>
            <div class="panel-body">
                <div class="form-group">
                    <label for="firstname" class="col-md-3 control-label">
                        username:</label>
                    <div class="col-md-8">
                        <input type="text" class="form-control" id="txt_userName" name="txt_userName" placeholder="please input username" />
                    </div>
                    <div class="col-md-1" style="color: #FF0000; padding-top: 10px; padding-left: 0;">
                        *</div>
                </div>
                <div class="form-group">
                    <label for="email" class="col-md-3 control-label">
                        email:</label>
                    <div class="col-md-8">
                        <input type="email" id="txt_email" name="txt_email" class="form-control" />
                    </div>
                    <div class="col-md-1" style="color: #FF0000; padding-top: 10px; padding-left: 0;">
                        *</div>
                </div>
                <div class="form-group">
                    <label for="recommend user" class="col-md-3 control-label">
                        recommend user:</label>
                    <div class="col-md-8">
                        <input type="text" id="txt_recommendUser" name="txt_recommendUser" class="form-control" />
                    </div>
                </div>
                
                <div class="form-group">
                    <label for="website" class="col-md-3 control-label">
                        website:</label>
                    <div class="col-md-8">
                        <input type="url" class="form-control" id="txt_website" name="txt_website" />
                    </div>
                </div>
                <div class="form-group">
                    <label for="company name" class="col-md-3 control-label">
                        company name:</label>
                    <div class="col-md-8">
                        <input type="text" class="form-control" id="txt_companyName" name="txt_companyName"/>
                    </div>
                </div>
                <div class="form-group">
                    <label for="tel" class="col-md-3 control-label">
                        telephone:</label>
                    <div class="col-md-8">
                        <input type="tel" class="form-control" id="txt_telephone" name="txt_telephone"/>
                    </div>
                    <div class="col-md-1" style="color: #FF0000; padding-top: 10px; padding-left: 0;">
                        *</div>
                </div>
                <div class="form-group">
                    <label for="password" class="col-md-3 control-label">
                        password:</label>
                    <div class="col-md-8">
                        <input type="password" class="form-control" id="txt_password" name="txt_password"/>
                    </div>
                    <div class="col-md-1" style="color: #FF0000; padding-top: 10px; padding-left: 0;">
                        *</div>
                </div>
                <div class="form-group">
                    <label for="confirm password" class="col-md-3 control-label">
                        confirm password:</label>
                    <div class="col-md-8">
                        <input type="password" class="form-control" id="txt_repwd" name="txt_repwd" />
                    </div>
                    <div class="col-md-1" style="color: #FF0000; padding-top: 10px; padding-left: 0;">
                        *</div>
                </div>
                <div class="form-group">
                    <label for="verification" class="col-md-3 control-label">
                        verification:</label>
                    <div class="col-md-5">
                        <input type="text" class="form-control" id="txt_code" name="txt_code" />
                    </div>
                    <div class="col-md-3">
                        <img id="getcode" alt="看不清" src="code.aspx" width="90px" height="32px" onclick="this.src=this.src+'?'" />
                    </div>
                    <div class="col-md-1" style="color: #FF0000; padding-top: 10px; padding-left: 0;">
                        *</div>
                </div>
                <hr />
                <div class="form-group">
                    <div class="col-md-2 col-md-offset-5">
                        <asp:Button ID="btn_regist" runat="Server" class="form-control btn-info" Text="注册"
                            OnClientClick="return isLegal()" OnClick="btn_regist_Click" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div id="second" runat="Server" class="row">
        <div class="panel panel-primary">
            <div class="panel-heading">
                <h3 class="panel-title">
                    注册成功</h3>
            </div>
            <div class="panel-body" style="text-align: center;height:200px;padding-top:40px;background:#FFFFFF">
                <p style="font-size: 16px; font-family: 'Times New Roman', Times, serif; font-weight: bold;
                    font-style: inherit; font-variant: small-caps; color: #800000">
                    恭喜你注册成功，成为WM Express华盟快递的用户
                </p>
                <p>即将为你跳转到会员首页</p>
            </div>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:Timer ID="Timer1" runat="server" Interval="1000" OnTick="Timer1_Tick">
                    </asp:Timer>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
    </div>
</asp:Content>
