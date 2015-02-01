<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="order-need-to-get-label.aspx.cs" Inherits="WM_Project.views.user_frame.order_need_to_get_label" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../stylesheets/bootstrap.css" rel="stylesheet" type="text/css" />
    <link href="../../stylesheets/bootstrap-theme.css" rel="stylesheet" type="text/css" />
    <script src="../../javascripts/bootstrap.js" type="text/javascript"></script>
    <script src="../../javascripts/jquery-1.11.1.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">

        <%--条码下载、打印--%>
    <div style="width:800px">
        <div class="panel panel-primary">
            <div class="panel-heading">
                <h3 class="panel-title">
                    您有如下订单需要重新获取运单标签</h3>
            </div>
            <div class="panel-body" style="padding-left: 0px; padding-right: 0px;font-size:12px">
                <div style="border-bottom: 5px solid #E4E4E4; border-top: 5px solid #E4E4E4; width: 798px"
                    id="has_order" runat="Server">
                    <asp:DataList ID="bar_code" runat="Server" OnItemCommand="bar_code_ItemCommand">
                        <HeaderTemplate>
                            <div style="padding-top: 5px; padding-bottom: 5px; width: 798px; height: 30px">
                                <div style="width: 22%; float: left; font-weight: 600; text-align: center">
                                    订单号
                                </div>
                                <div style="width: 8%; float: left; font-weight: 600; text-align: center">
                                    包裹重
                                </div>
                                <div style="width: 13%; float: left; font-weight: 600; text-align: center">
                                    发件人
                                </div>
                                <div style="width: 13%; float: left; font-weight: 600; text-align: center">
                                    收件人
                                </div>
                                <div style="width: 9%; float: left; font-weight: 600; text-align: center">
                                    付款金额
                                </div>
                                <div style="width: 12%; float: left; font-weight: 600; text-align: center">
                                    服务方式
                                </div>
                                <div style="width: 15%; float: left; font-weight: 600; text-align: center">
                                    付款时间
                                </div>
                                <div style="width: 8%; float: left; font-weight: 600; text-align: center">
                                    下载
                                </div>
                            </div>
                            <div style="background: #E4E4E4; height: 5px">
                            </div>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <div style="clear: both; padding-top: 5px; padding-bottom: 5px; width: 798px; height: 35px">
                                <div style="width: 22%; float: left; text-align: center; padding-left: 2px">
                                    <%#DataBinder.Eval(Container.DataItem,"order_number") %>
                                </div>
                                <div style="width: 8%; float: left; text-align: center">
                                    <%#DataBinder.Eval(Container.DataItem,"weight") %>
                                </div>
                                <div style="width: 13%; float: left; text-align: center">
                                    <%#DataBinder.Eval(Container.DataItem,"sender") %>
                                </div>
                                <div style="width: 13%; float: left; text-align: center">
                                    <%#DataBinder.Eval(Container.DataItem,"receiver") %>
                                </div>
                                <div style="width: 9%; float: left; text-align: center">
                                    £<asp:Label ID="item_money" runat="Server" Text='<%#DataBinder.Eval(Container.DataItem,"pay") %>'></asp:Label>
                                </div>
                                <div style="width: 12%; float: left; text-align: center">
                                    <%#DataBinder.Eval(Container.DataItem,"postway") %>
                                </div>
                                <div style="width: 15%; float: left; text-align: center">
                                    <%#DataBinder.Eval(Container.DataItem,"time") %>
                                </div>
                                <div style="width: 8%; float: left; text-align: center">
                                    <asp:Button runat="Server" ID="download" CssClass="download" CommandName="PrintByDownload"
                                        Height="25px" Text="下载" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"order_number") %>' />
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
                <div id="has_not_order" runat="Server" visible="false" style="height: 200px; padding-top: 80px;
                    text-align: center">
                    <p style="font-weight: 600; font-size: 20px; color: #FF0000">
                        您好，您没有未获取Label的订单!!</p>
                </div>
            </div>
        </div>
    </div>


    </form>
</body>
</html>
