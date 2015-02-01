<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="check-order-by-number.aspx.cs"
    Inherits="WM_Project.views.user_frame.check_order_by_number" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../stylesheets/bootstrap.css" rel="stylesheet" type="text/css" />
    <link href="../../stylesheets/bootstrap-theme.css" rel="stylesheet" type="text/css" />
    <script src="../../javascripts/bootstrap.js" type="text/javascript"></script>
    <script src="../../javascripts/jquery-1.11.1.js" type="text/javascript"></script>
    <script type="text/javascript">

        //订单号不能为空
        function isOrderNull() {
            var order = document.getElementsByName("order_number");
            if (order[0].value.trim() == "") {
                alert("订单号不能为空！！");
                return false;
            }
            return true;
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="panel panel-primary" style="width: 800px; ">
        <div class="panel-heading">
            <h5 class="panel-title">
                按订单号查找订单</h5>
        </div>
        <div class="panel-body" style="padding-left: 0px; padding-right: 0px">
            <div class="form-group" style="height: 40px">
                <div style="width: 120px; float: left">
                    <label class="control-label" style="text-align: left; padding-top: 6px; padding-left: 10px">
                        按订单号查找</label>
                </div>
                <div style="width: 320px; float: left">
                    <input type="text" name="order_number" class="form-control" /></div>
                <div style="padding-top: 5px; color: #FF0000; width: 200px; float: left; padding-left: 10px">
                    输入以"AU"、"WP"开头的单号</div>
                <div style="text-align: right; width: 120px; float: left">
                    <asp:Button ID="btn_check_by_order" runat="Server" Text="查询" Width="120px" CssClass="btn btn-info"
                        OnClick="btn_check_by_order_Click" OnClientClick="return isOrderNull()" /></div>
            </div>
            <div class="form-group" style="height: 10px; background: #DADADA">
            </div>
            <div id="has_orders" runat="Server" style="font-size: 12px">
                <div class="form-group">
                    <asp:DataList ID="bar_code" runat="Server" OnItemCommand="bar_code_ItemCommand" Style="margin-bottom: 0px">
                        <HeaderTemplate>
                            <div style="padding-top: 5px; padding-bottom: 5px; width: 800px; height: 30px">
                                <div style="width: 22%; float: left; font-weight: 600; text-align: center">
                                    订单号
                                </div>
                                <div style="width: 8%; float: left; font-weight: 600; text-align: center">
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
                                <div style="width: 10%; float: left; font-weight: 600; text-align: center">
                                    服务方式
                                </div>
                                <div style="width: 14%; float: left; font-weight: 600; text-align: center">
                                    付款时间
                                </div>
                                <div style="width: 5%; float: left; font-weight: 600; text-align: center">
                                    PDF
                                </div>
                                <div style="width: 7%; float: left; font-weight: 600; text-align: center">
                                    下载
                                </div>
                            </div>
                            <div style="background: #E4E4E4; height: 5px">
                            </div>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <div style="clear: both; padding-top: 5px; padding-bottom: 5px; width: 800px; height: 30px">
                                <div style="width: 22%; float: left; text-align: center; padding-left: 0px">
                                    <%#DataBinder.Eval(Container.DataItem,"order_number") %>
                                </div>
                                <div style="width: 8%; float: left; text-align: center">
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
                                <div style="width: 10%; float: left; text-align: center">
                                    <%#DataBinder.Eval(Container.DataItem,"postway") %>
                                </div>
                                <div style="width: 14%; float: left; text-align: center">
                                    <%#DataBinder.Eval(Container.DataItem,"time") %>
                                </div>
                                <div style="width: 5%; float: left; text-align: center">
                                    <asp:ImageButton ID="detail" runat="Server" ImageUrl="../../image/images/copy.gif" CommandName="PrintInWeb"
                                        CommandArgument='<%#DataBinder.Eval(Container.DataItem,"order_number") %>' />
                                </div>
                                <div style="width: 7%; float: left; text-align: center">
                                    <asp:Button runat="Server" ID="Button1" CssClass="download" CommandName="PrintByDownload"
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
            </div>
            <div id="no_orders" visible="false" runat="Server" style="height:200px;padding-top:80px;text-align:center">
                <p style="font-size:600;color:#FF0000"><%=message%></p>
            </div>
        </div>
        <div class="panel-footer">
        </div>
    </div>
    </form>
</body>
</html>
