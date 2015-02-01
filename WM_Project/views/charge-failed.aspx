<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/reception-stage/batch.Master" AutoEventWireup="true" CodeBehind="charge-failed.aspx.cs" Inherits="WM_Project.views.charge_failed" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="center" runat="server">
<div class="panel panel-primary">
    <div class="panel-heading">
        <h5 class="panel-title">充值失败</h5>
    </div>
    <div class="panel-body">
        <div class="form-group" style="height:100px;padding-top:60px;text-align:center;color:#FF0000"><%=username %>不好意思，您充值失败!!</div>

        <div class="form-group" style="text-align:center">
            <asp:Button ID="btn_go_my" runat="Server" Text="前往我的账户" CssClass="btn btn-info" 
                Width="120px" onclick="btn_go_my_Click" />
        </div>
    </div>
    <div class="panel-footer">
    </div>
</div>
</asp:Content>
