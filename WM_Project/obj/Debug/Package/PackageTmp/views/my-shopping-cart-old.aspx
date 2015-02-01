<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/reception-stage/batch.Master" AutoEventWireup="true"
    CodeBehind="my-shopping-cart-old.aspx.cs" Inherits="WM_Project.views.my_shopping_cart_old" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="center" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <%--购物车部分--%>
    <div class="row" runat="Server" id="page_three">
        <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <div class="panel panel-primary" style="width: 1010px">
                    <div class="panel-heading">
                        <h3 class="panel-title">
                            我的购物车</h3>
                    </div>
                    <div class="panel-body" style="padding-left: 0px; padding-right: 0px">
                        <div style="border-bottom: 5px solid #E4E4E4; border-top: 5px solid #E4E4E4; width: 1010px">
                            <asp:DataList ID="my_cart" runat="Server" OnItemCommand="my_cart_ItemCommand">
                                <HeaderTemplate>
                                    <div style="width: 1008px; padding-top: 5px; padding-bottom: 5px; height: 30px">
                                        <div style="width: 4%; float: left; font-weight: 600">
                                            &nbsp;
                                        </div>
                                        <div style="width: 16%; float: left; font-weight: 600; text-align: center">
                                            订单号
                                        </div>
                                        <div style="width: 7%; float: left; font-weight: 600; text-align: center">
                                            包裹数
                                        </div>
                                        <div style="width: 12%; float: left; font-weight: 600; text-align: center">
                                            发件人
                                        </div>
                                        <div style="width: 12%; float: left; font-weight: 600; text-align: center">
                                            收件人
                                        </div>
                                        <div style="width: 9%; float: left; font-weight: 600; text-align: center">
                                            付款金额
                                        </div>
                                        <div style="width: 16%; float: left; font-weight: 600; text-align: center">
                                            服务方式
                                        </div>
                                        <div style="width: 15%; float: left; font-weight: 600; text-align: center">
                                            下单时间
                                        </div>
                                        <div style="width: 4%; float: left; font-weight: 600; text-align: center">
                                            详情
                                        </div>
                                        <div style="width: 4%; float: left; font-weight: 600; text-align: center">
                                            删除
                                        </div>
                                    </div>
                                    <div style="background: #E4E4E4; height: 5px">
                                    </div>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <div style="clear: both; padding-top: 5px; padding-bottom: 5px; height: 30px">
                                        <div style="width: 4%; float: left; text-align: center">
                                            <asp:CheckBox ID="checkbox" runat="Server" AutoPostBack="true" Checked="true" OnCheckedChanged="checkbox_CheckChanged" />
                                            <asp:HiddenField ID="hidden" Value='<%#DataBinder.Eval(Container.DataItem,"order_number") %>'
                                                runat="Server" />
                                        </div>
                                        <div style="width: 16%; float: left; text-align: center">
                                            <%#DataBinder.Eval(Container.DataItem,"order_number") %>
                                        </div>
                                        <div style="width: 7%; float: left; text-align: center">
                                            <%#DataBinder.Eval(Container.DataItem,"quantity") %>
                                        </div>
                                        <div style="width: 12%; float: left; text-align: center">
                                            <%#DataBinder.Eval(Container.DataItem,"sender") %>
                                        </div>
                                        <div style="width: 12%; float: left; text-align: center">
                                            <%#DataBinder.Eval(Container.DataItem,"receiver") %>
                                        </div>
                                        <div style="width: 9%; float: left; text-align: center">
                                            £<asp:Label ID="item_money" runat="Server" Text='<%#DataBinder.Eval(Container.DataItem,"pay") %>'></asp:Label>
                                        </div>
                                        <div style="width: 16%; float: left; text-align: center">
                                            <%#DataBinder.Eval(Container.DataItem,"postway") %>
                                        </div>
                                        <div style="width: 15%; float: left; text-align: center">
                                            <%#DataBinder.Eval(Container.DataItem,"time") %>
                                        </div>
                                        <div style="width: 4%; float: left; text-align: center">
                                            <asp:ImageButton ID="detail" runat="Server" ImageUrl="../image/images/copy.gif" CommandName="detail"
                                                CommandArgument='<%#DataBinder.Eval(Container.DataItem,"order_number") %>' />
                                        </div>
                                        <div style="width: 4%; float: left; text-align: center">
                                            <asp:ImageButton ID="delete" runat="Server" ImageUrl="../image/images/del.jpg" CommandName="delete"
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
                                <div style="padding-left: 28px" class="col-md-3">
                                    <asp:CheckBox ID="select_all" runat="Server" Text="&nbsp;全选" Checked="true" AutoPostBack="true"
                                        OnCheckedChanged="checked_All" /></div>
                                <div style="text-align: center" class="col-md-5 col-md-offset-4">
                                    <font color="#3A83C2">您总共需付款：</font>£<asp:Label ID="lb_money" runat="Server"></asp:Label></div>
                            </div>
                            <div class="form-group" style="background: #DADADA; height: 2px">
                            </div>
                            <div class="form-group">
                                <div style="height: 33px; padding-left: 20px">
                                    请输入优惠码：
                                    <input type="text" name="txt_promotion_code" style="height: 33px; width: 240px" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:Button Text="确定" CssClass="btn btn-info" Height="33px" runat="Server" ID="btn_confirm"
                                        OnClick="btn_confirm_Click" />
                                    <asp:Label ID="lb_money_discount" runat="Server" style="margin-left:30px"></asp:Label>
                                    <asp:Label ID="lb_money_after_discount" runat="Server" style="margin-left:30px"></asp:Label>
                                </div>
                            </div>
                            <div style="height: 2px; background: #DADADA">
                            </div>
                            <div class="form-group" style="height: 40px">
                                <div style="text-align: right; padding-right: 20px" class="col-md-3">
                                    <asp:Button ID="btn_pay" runat="Server" CssClass="btn btn-info" Text="付款" OnClick="btn_pay_Click" /></div>
                            </div>
                        </div>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
