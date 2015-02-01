<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/reception-stage/batch.Master" AutoEventWireup="true"
    CodeBehind="charge-success.aspx.cs" Inherits="WM_Project.views.charge_success" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="center" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="panel panel-primary">
        <div class="panel-heading">
            <h5 class="panel-title">
                充值成功</h5>
        </div>
        <div class="panel-body">
            <div class="form-group" style="height: 200px; padding-top: 85px; text-align: center; font-weight:600;
                color: #FF0000">
                充值成功，即将为您跳转至我的账户!!</div>
            <div class="form-group">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:Timer ID="Timer1" runat="server" Interval="1000" OnTick="Timer1_Tick">
                        </asp:Timer>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
        <div class="panel-footer">
        </div>
    </div>
</asp:Content>
