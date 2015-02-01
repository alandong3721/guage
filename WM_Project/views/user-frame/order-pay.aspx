<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/reception-stage/batch.Master" AutoEventWireup="true"
    CodeBehind="order-pay.aspx.cs" Inherits="WM_Project.views.user_frame.order_pay" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="center" runat="server">
    <%--付款部分--%>
    <div id="page_four" runat="Server" style="width:88%;margin:0 auto;">
        <div class="panel panel-primary">
            <div class="panel-heading">
                <h3 class="panel-title">
                    付款页面</h3>
            </div>
            <div class="panel-body">
                <div class="form-group" style="height: 40px; text-align: center; padding-top: 20px;">
                    <p style="color: #107DE6; font-size: 18px; font-weight: 600; text-align: center;
                        line-height: 25px">
                        尊敬的<%=name%>先生(女士),您的订单总金额为£<%=money%>,请您选择下面的支付方式进行付款，谢谢您的合作</p>
                </div>
                <div class="form-group">
                    <div class="col-md-8 col-md-offset-4">
                        <p style="line-height: 20px;">
                            <font color="red"><b>支付方式:&nbsp;&nbsp;&nbsp;</b></font></p>
                        <div style="padding-left: 20px; padding-top: 10px;" id="way_two" runat="Server">
                            <p class="glyphicon glyphicon-hand-right" style="font-weight: 600">
                                &nbsp;信用卡Credit/Debit Card付款</p>
                            <p style="line-height: 20px; text-indent: 2em">
                                <input type="radio" name="pay_method" value="pay_card" checked="checked" />
                                信用卡Credit/DebitCard付款&nbsp;&nbsp;&nbsp;<font color="#FF0000"><b>£<%=money %></b></font></p>
                            <p style="line-height: 20px; text-indent: 2em">
                                请选择信用卡种类(注意部分卡需要收取卡费):</p>
                            <p style="text-indent: 2em">
                                <select name="card_type" id="card_type">
                                    <option value="VISA Credit">VISA Credit - Pay&nbsp;&nbsp; £
                                        <%=Math.Round(money*1.025,2) %>
                                    </option>
                                    <option value="Mastercard Credit">Mastercard Credit - Pay&nbsp;&nbsp; £
                                        <%=Math.Round(money*1.025,2) %>
                                    </option>
                                    <option value="VISA Debit">VISA Debit - Pay&nbsp;&nbsp;£
                                        <%=Math.Round(money+0.4,2) %>
                                    </option>
                                    <option value="UK Maestro">UK Maestro - Pay&nbsp;&nbsp;£
                                        <%=Math.Round(money+0.25,2) %>
                                    </option>
                                    <option value="Non EU Cards">Non EU Cards - Pay&nbsp;&nbsp;£
                                        <%=Math.Round(money*1.35,2) %>
                                    </option>
                                </select></p>
                        </div>
                        <div style="padding-left: 20px; padding-top: 10px;" id="way_three" runat="Server">
                            <p class="glyphicon glyphicon-hand-right" style="font-weight: 600">
                                &nbsp;Paypal支付</p>
                            <p style="line-height: 20px; text-indent: 2em;padding-bottom:10px">
                                <input type="radio" name="pay_method" value="pay_paypal" />PayPal-付款&nbsp;&nbsp;£
                                <%=Math.Round(money*1.05,2) %></p>
                        </div>
                        <div style="padding-left: 20px; " id="way_one" runat="Server">
                            <p class="glyphicon glyphicon-hand-right" style="font-weight: 600">
                                &nbsp;华盟账户支付</p>
                            <p style="line-height: 20px; text-indent: 2em">
                                账户名：<%=myaccount.Name %>&nbsp;&nbsp;&nbsp;&nbsp;账户余额：<font color="#FF0000"><b>£<%=myaccount.Balance %></b></font></p>
                            <p style="line-height: 20px; text-indent: 2em;padding-bottom:10px">
                                <input type="radio" name="pay_method" value="wm-account" />
                                使用华盟账户支付&nbsp;&nbsp;&nbsp;<font color="#FF0000"><b>£<%=money %></b></font></p>
                        </div>
                        <div style="padding-left: 20px; " id="only_for_read" runat="Server" visible="false">
                            <p class="glyphicon glyphicon-hand-right" style="font-weight: 600">
                                &nbsp;华盟账户</p>
                            <p style="line-height: 20px; text-indent: 2em">
                                账户名：<%=myaccount.Name %>&nbsp;&nbsp;&nbsp;&nbsp;账户余额：<font color="#FF0000"><b>£<%=myaccount.Balance %></b></font></p>
                        </div>
                    </div>
                </div>
                <div class="form-group" style="clear:both;height:2px;background:#DADADA;width:50%;margin:0 auto;margin-top:10px">
                   
                </div>
                <div class="form-group" style="height:10px"></div>
                <div style="text-align: center;" class="form-group">
                    <asp:Button ID="submit" name="submit" runat="server" Text="确认付款" OnClick="btn_Submit"
                        CssClass="btn btn-info" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
