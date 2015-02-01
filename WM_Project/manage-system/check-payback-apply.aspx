<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/back-stage/home.Master" AutoEventWireup="true" CodeBehind="check-payback-apply.aspx.cs" Inherits="WM_Project.manage_system.check_payback_apply" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="center" runat="server">
    <div class=" panel panel-primary" style="width: 700px;margin:0 auto; ">
        <div class="panel-heading">
            <h5 class="panel-title">
                为用户还款</h5>
        </div>
        <div class="panel-body">
            <div class="form-group" style="clear:both;height:40px">
                <div style="padding-top: 5px; width: 120px;float:left;padding-left:40px">
                    <label class="control-label">
                        还款账户</label>
                </div>
                <div style="width: 500px;float:left">
                    <asp:TextBox ID="user_account" runat="Server" CssClass="form-control account_repay"></asp:TextBox>
                </div>

            </div>
            <div class="form-group" style="clear:both;height:40px">
                <div style="padding-top: 5px; width: 120px;float:left;padding-left:40px">
                    <label class="control-label">
                        金额£</label>
                </div>
                <div style="width: 500px;float:left">
                    <input type="text" class="form-control" name="repay_money" value="<%=payback.Amount %>" />
                </div>
                
            </div>
            <div class="form-group" style="clear:both;height:120px">
                <div style="padding-top: 40px; width: 120px;float:left;padding-left:40px">
                    <label class="control-label">
                        备注</label>
                </div>
                <div style="width:520px;float:left">
                    <asp:TextBox ID="txt_note" runat="Server" TextMode="MultiLine" style="resize:none;width:520px;height:100px"></asp:TextBox>
                </div>
                
            </div>
            <div class="form-group" style="clear:both;height:400px">
                <div style="padding-top: 5px; width: 120px;float:left;padding-top:180px;padding-left:40px">
                    <label class="control-label">
                        凭证</label>
                </div>
                <div style="width:500px;float:left;height:400px;border:1px solid #DADADA">
                   <img src='<%=payback.Image %>' alt="" width="400px" height="400px" />
                </div>
               
            </div>
            <div class="form-group" style="text-align:center;height:40px">
                <div style="width:300px;text-align:right;float:left">
                    <asp:Button ID="btn_pass" runat="server" CssClass="btn btn-info repay"
                        Text="审核通过" Width="120px" onclick="btn_pass_Click" />
                </div>
                <div style="width:350px;float:left">
                    <asp:Button ID="btn_unPass" runat="server" CssClass="btn btn-danger"
                        Text="审核不通过"  Width="120px" onclick="btn_unPass_Click" />
                </div>
                    
            </div>
            <div style="height: 10px">
                &nbsp;</div>
        </div>
        <div class="panel-footer" style="color: #FF0000"></div>
    </div>

</asp:Content>
