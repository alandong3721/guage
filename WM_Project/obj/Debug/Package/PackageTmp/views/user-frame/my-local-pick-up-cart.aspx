<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/reception-stage/batch.Master"
    AutoEventWireup="true" CodeBehind="my-local-pick-up-cart.aspx.cs" Inherits="WM_Project.views.user_frame.my_local_pick_up_cart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="center" runat="server">
    <div class="panel panel-primary" style="margin-left:-15px;margin-right:-15px">
        <div class="panel-heading">
            <h5 class="panel-title">
                我的本地取件购物车</h5>
        </div>
        <div class="panel-body">
            <div id="cart_part" runat="Server" style="border-bottom: 5px solid #E4E4E4; border-top: 5px solid #E4E4E4;
                width: 990px">
                <asp:DataList ID="my_cart_datalist" runat="Server" OnItemCommand="my_cart_ItemCommand">
                    <HeaderTemplate>
                        <div style="width: 988px; padding-top: 5px; padding-bottom: 5px; height: 30px">
                            <div style="width: 18%; float: left; font-weight: 600; text-align: center">
                                订单号
                            </div>
                            <div style="width: 12%; float: left; font-weight: 600; text-align: center">
                                发件人
                            </div>
                            <div style="width: 12%; float: left; font-weight: 600; text-align: center">
                                收件人
                            </div>
                            <div style="width: 6%; float: left; font-weight: 600; text-align: center">
                                包裹个数
                            </div>
                            <div style="width: 7%; float: left; font-weight: 600; text-align: center">
                                包裹重
                            </div>
                            <div style="width: 7%; float: left; font-weight: 600; text-align: center">
                                付款金额
                            </div>
                            <div style="width: 14%; float: left; font-weight: 600; text-align: center">
                                服务方式
                            </div>
                            <div style="width: 14%; float: left; font-weight: 600; text-align: center">
                                下单时间
                            </div>
                            <div style="width: 5%; float: left; font-weight: 600; text-align: center">
                                详情
                            </div>
                            <div style="width: 5%; float: left; font-weight: 600; text-align: center">
                                删除
                            </div>
                        </div>
                        <div style="background: #E4E4E4; height: 5px">
                        </div>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <div style="clear: both; padding-top: 5px; padding-bottom: 5px; height: 30px">
                            <div style="width: 18%; float: left; text-align: center">
                                <asp:HiddenField ID="hidden" Value='<%#DataBinder.Eval(Container.DataItem,"order_number") %>'
                                    runat="Server" />
                                <%#DataBinder.Eval(Container.DataItem,"order_number") %>
                            </div>
                            <div style="width: 12%; float: left; text-align: center">
                                <%#DataBinder.Eval(Container.DataItem,"sender") %>
                            </div>
                            <div style="width: 12%; float: left; text-align: center">
                                <%#DataBinder.Eval(Container.DataItem,"receiver") %>
                            </div>
                            <div style="width: 6%; float: left; text-align: center">
                                <%#DataBinder.Eval(Container.DataItem,"quantity") %>
                            </div>
                            <div style="width: 7%; float: left; text-align: center">
                                <%#DataBinder.Eval(Container.DataItem,"weight") %>
                            </div>
                            <div style="width: 7%; float: left; text-align: center">
                                <asp:Label ID="item_money" runat="Server" Text='<%#DataBinder.Eval(Container.DataItem,"pay") %>'></asp:Label>
                            </div>
                            <div style="width: 14%; float: left; text-align: center">
                                <%#DataBinder.Eval(Container.DataItem,"postway") %>
                            </div>
                            <div style="width: 14%; float: left; text-align: center">
                                <%#DataBinder.Eval(Container.DataItem,"time") %>
                            </div>
                            <div style="width: 5%; float: left; text-align: center">
                                <asp:ImageButton ID="detail" runat="Server" ImageUrl="../../image/images/copy.gif" CommandName="detail"
                                    CommandArgument='<%#DataBinder.Eval(Container.DataItem,"order_number") %>' />
                            </div>
                            <div style="width: 5%; float: left; text-align: center">
                                <asp:ImageButton ID="delete" runat="Server" ImageUrl="../../image/images/del.jpg" CommandName="delete"
                                    CommandArgument='<%#DataBinder.Eval(Container.DataItem,"order_number") %>' />
                            </div>
                        </div>
                    </ItemTemplate>
                    <SeparatorTemplate>
                        <div style="height: 5px; background: #E4E4E4">
                        </div>
                    </SeparatorTemplate>
                    <FooterTemplate>
                        <div style="height: 5px; background: #E4E4E4">
                        </div>
                    </FooterTemplate>
                </asp:DataList>
                <div class="row">
                    <div style="text-align: right; height: 30px; padding-right: 60px; font-weight: 600"
                        class="col-md-8">
                        <font color="#3A83C2">您总共需付款：</font>£<asp:Label ID="lb_money" runat="Server"></asp:Label></div>
                </div>
                <div class="form-group" style="background: #DADADA; height: 2px">
                </div>
                <div class="form-group" style="height: 45px">
                    <div class="col-md-6" style="text-align:center;">
                        <asp:Button ID="btn_clear_cart" runat="Server" CssClass="btn btn-info" Text="清空购物车"
                            OnClick="btn_clear_cart_Click" />
                    </div>
                    <div style="text-align: right; padding-right: 20px; padding-top: 10px" class="col-md-6">
                        <asp:Button ID="btn_pay" runat="Server" CssClass="btn btn-info" Text="付款" OnClick="btn_pay_Click" /></div>
                </div>
                
            </div>

            <div id="no_local_order" runat="Server" class="form-group" style="height:200px;padding-top:80px;text-align:center" visible="false">
                <p> 您好，您的购物车已经清空！！</p>
            
            </div>

        </div>
        <div class="panel-footer">
        </div>
    </div>
</asp:Content>
