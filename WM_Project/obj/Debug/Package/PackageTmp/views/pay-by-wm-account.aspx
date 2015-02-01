<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/reception-stage/batch.Master" AutoEventWireup="true" CodeBehind="pay-by-wm-account.aspx.cs" Inherits="WM_Project.views.pay_by_wm_account" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="center" runat="server">
    <div class="panel panel-primary" style="width:80%;margin:0 auto;margin-bottom:30px">
        <div class="panel-heading">
            <h5 class="panel-title">使用华盟账户支付</h5>
        </div>
        <div class="panel-body">
            <div class="form-group" style="clear:both;margin-top:26px;height:40px">
                <label class="col-md-4 control-label" style="text-align:right;padding-top:5px">账户名：</label>
                <div class="col-md-6"><input type="text" class="form-control" readonly="readonly" value="<%=name %>" /></div>
            </div>
            <div class="form-group" style="clear:both;margin-top:26px;height:40px">
                <label class="col-md-4 control-label" style="text-align:right;padding-top:5px">账户余额：£</label>
                <div class="col-md-6"><input type="text" class="form-control" readonly="readonly" value="<%=myaccount.Balance %>" /></div>
            </div>
            <div class="form-group" style="clear:both;height:40px">
                <label class="col-md-4 control-label" style="text-align:right;padding-top:5px">支付金额：£</label>
                <div class="col-md-6"><input type="text" class="form-control" readonly="readonly" value="<%=money %>" /></div>
            </div>
            <div class="form-group" style="clear:both;height:40px">
                <label class="col-md-4 control-label" style="text-align:right;padding-top:5px">支付后余额：£</label>
                <div class="col-md-6"><input type="text" class="form-control" readonly="readonly" value="<%=myaccount.Balance-money %>" /></div>
            </div>
            <div class="form-group" style="clear:both;text-align:center;padding-top:20px">
                <asp:Button ID="btn_pay" runat="Server" Text="确认支付" CssClass="btn btn-info" 
                    onclick="btn_pay_Click" />
            </div>
            <div class="form-group" style="height:8px"></div>
        </div>
    
    </div>
</asp:Content>
