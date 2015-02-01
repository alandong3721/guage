<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/reception-stage/home.Master" AutoEventWireup="true"
    CodeBehind="reset-password.aspx.cs" Inherits="WM_Project.views.reset_password" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="center_right" runat="server">
    
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="row" id="first" runat="Server">
        <div class="panel panel-danger">
            <div class="panel-heading">
                <h3 class="panel-title">
                    Reset Password</h3>
            </div>
            <div class="panel-body">
                <div class="form-horizontal">
                    <div class="form-group">
                        <label for="username" class="col-md-3 control-label">
                            username:</label>
                        <div class="col-md-9">
                            <input type="text" class="form-control" id="txt_username" name="txt_username" placeholder="please input username" />
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="code" class="col-md-3 control-label">
                            code:</label>
                        <div class="col-md-4">
                            <input type="text" class="form-control" id="txt_code" name="txt_code"/>
                        </div>
                        <div class="col-md-2">
                            <asp:Button ID="btn_getcode" runat="Server" CssClass="form-control btn-danger btn-xs"
                                Text="获取激活码" OnClick="btn_getcode_Click" />
                        </div>
                        <div class="col-md-3">
                            <asp:Label ID="lb_noticeInfo" runat="Server" Font-Size="12px"></asp:Label>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="password" class="col-md-3 control-label">
                            new password:</label>
                        <div class="col-md-9">
                            <input type="password" class="form-control" id="txt_password" name="txt_password" />
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="confirm" class="col-md-3 control-label">
                            repeat:</label>
                        <div class="col-md-9">
                            <input type="password" class="form-control" id="txt_repwd" name="txt_repwd"/>
                        </div>
                    </div>
                    <div class="form-group" style="text-align: center">
                        <div class="col-md-2 col-md-offset-5">
                            <asp:Button ID="btn_resetPassword" runat="Server" Text="重置" CssClass="form-control btn-info"
                                OnClick="btn_resetPassword_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    
    <%--密码重置成功提示--%>
    <div class="row" id="second" runat="Server" visible="false">
        <div class="panel panel-primary">
            <div class="panel-heading">
                <h3 class="panel-title">
                    Reset Success</h3>
            </div>
            <div class="panel-body" style="text-align: center;height:200px;padding-top:40px;background:#FFFFFF">
                <p style="font-size: 16px; font-family: 'Times New Roman', Times, serif; font-weight: bold;
                    font-style: inherit; font-variant: small-caps; color: #800000">
                    恭喜你，密码重置成功！
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
    
</asp:Content>
