<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="check-local-order-by-time.aspx.cs"
    Inherits="WM_Project.views.user_frame.check_local_order_by_time" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../stylesheets/bootstrap.css" rel="stylesheet" type="text/css" />
    <link href="../../stylesheets/bootstrap-theme.css" rel="stylesheet" type="text/css" />
    <script src="../../javascripts/bootstrap.js" type="text/javascript"></script>
    <script src="../../javascripts/jquery-1.11.1.js" type="text/javascript"></script>
    <script src="../../javascripts/jquery-1.11.1.js" type="text/javascript"></script>

</head>
<body>
    <form id="form1" runat="server">
    <div class="panel panel-primary" style="width: 780px; font-size: 9px;padding-left:0px;padding-right:0px">
        <div class="panel-heading">
            <h5 class="panel-title">
                按时间查找本地订单</h5>
        </div>
        <div class="panel-body" style="padding-left:0px;padding-right:0px">
            <div class="form-group" style="margin-top: 10px; padding-left: 20px; padding-right: 20px;
                height: 40px" id="query_by_time">
                <div style="width: 40px; float: left; padding-right: 10px; text-align: right">
                    <label class="control-label" style="padding-top: 6px">
                        From:</label></div>
                <div style="padding-left: 0px; padding-right: 0px; width: 120px; float: left;">
                    <asp:TextBox ID="txt_from" runat="Server" CssClass="form-control" onclick="new Calendar().show(this);"></asp:TextBox>
                </div>
                <div style="width: 60px; float: left; padding-right: 10px; text-align: right">
                    <label class="control-label" style="padding-top: 6px; padding-right: 10px; text-align: right">
                        To:</label></div>
                <div style="width: 120px; float: left;">
                    <asp:TextBox ID="txt_to" runat="Server" CssClass="form-control" onclick="new Calendar().show(this);"></asp:TextBox></div>
                <div style="width: 140px; float: left; padding-left: 40px">
                    <asp:Button ID="btn_query" runat="Server" CssClass="btn btn-info" Text="查询订单" OnClick="btn_query_Click" /></div>
                <div style="text-align: right; width: 160px; float: left;">
                    <asp:Button ID="btn_query_all" runat="Server" CssClass="btn btn-info" Text="查询所有订单"
                        OnClick="btn_query_all_Click" />
                </div>
            </div>
            
            <div class="form-group" style="padding-left:0px;padding-right:0px">
                <div id="cart_part" runat="Server" style="border-bottom: 5px solid #E4E4E4; border-top: 5px solid #E4E4E4;
                    width: 780px">
                    <asp:DataList ID="my_local_datalist" runat="Server" OnItemCommand="my_cart_ItemCommand">
                        <HeaderTemplate>
                            <div style="padding-top: 5px; padding-bottom: 5px; height: 30px;width:780px">
                                <div style="width: 20%; float: left; font-weight: 600; text-align: center">
                                    订单号
                                </div>
                                <div style="width: 10%; float: left; font-weight: 600; text-align: center">
                                    发件人
                                </div>
                                <div style="width: 10%; float: left; font-weight: 600; text-align: center">
                                    收件人
                                </div>
                                <div style="width: 8%; float: left; font-weight: 600; text-align: center">
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
                                    下载
                                </div>
                            </div>
                            <div style="background: #E4E4E4; height: 5px">
                            </div>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <div style="clear: both; padding-top: 5px; padding-bottom: 5px; height: 30px">
                                <div style="width: 20%; float: left; text-align: center">
                                    <asp:HiddenField ID="hidden" Value='<%#DataBinder.Eval(Container.DataItem,"order_number") %>'
                                        runat="Server" />
                                    <%#DataBinder.Eval(Container.DataItem,"order_number") %>
                                </div>
                                <div style="width: 10%; float: left; text-align: center">
                                    <%#DataBinder.Eval(Container.DataItem,"sender") %>
                                </div>
                                <div style="width: 10%; float: left; text-align: center">
                                    <%#DataBinder.Eval(Container.DataItem,"receiver") %>
                                </div>
                                <div style="width: 8%; float: left; text-align: center">
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
                                    <asp:ImageButton ID="detail" runat="Server" ImageUrl="../../image/images/copy.gif"
                                        CommandName="detail" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"order_number") %>' />
                                </div>
                                <div style="width: 5%; float: left; text-align: center">
                                    <asp:ImageButton ID="delete" runat="Server" ImageUrl="../../image/images/del.jpg"
                                        CommandName="delete" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"order_number") %>' />
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
                </div>
            </div>
        </div>
        <div class="panel-footer">
        </div>
    </div>
    </form>
</body>
</html>
