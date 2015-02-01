<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/reception-stage/batch.Master" AutoEventWireup="true"
    CodeBehind="repeat-pay.aspx.cs" Inherits="PostNL.views.repeat_pay" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="center" runat="server">
    <div class="panel panel-primary" style="width:80%;margin:0 auto;">
        <div class="panel-heading">
            <h3 class="panel-title">
                重新付款</h3>
        </div>
        <div class="panel-body" style="padding-left: 0px; padding-right: 0px" id="international_order" runat="Server">
            <div class="form-group" style="height:200px;padding-top:100px">
                <p style="text-align:center; font-size:20px; font-weight:600"><%=name %>您好，您付款失败!!</p>
                <p style="margin-top:60px;padding-left:20px; font-weight:600; font-size:20px"><a href="my-shopping-cart.aspx">去购物车再次结算</a></p>
            </div>
        </div>
        <div class="panel-body" style="padding-left: 0px; padding-right: 0px" id="local_order" runat="Server">
            <div class="form-group" style="height:200px;padding-top:100px">
                <p style="text-align:center; font-size:20px; font-weight:600"><%=name %>您好，您付款失败!!</p>
                <p style="margin-top:60px;padding-left:20px; font-weight:600; font-size:20px"><a href="my-local-pick-up-cart.aspx">去购物车再次结算</a></p>
            </div>
        </div>
        <div class="panel-footer"></div>
    </div>
</asp:Content>
