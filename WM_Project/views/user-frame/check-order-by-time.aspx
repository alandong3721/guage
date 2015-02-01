<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="check-order-by-time.aspx.cs"
    Inherits="WM_Project.views.user_frame.check_order_by_time" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../stylesheets/bootstrap.css" rel="stylesheet" type="text/css" />
    <link href="../../stylesheets/bootstrap-theme.css" rel="stylesheet" type="text/css" />
    <script src="../../javascripts/bootstrap.js" type="text/javascript"></script>
    <script src="../../javascripts/jquery-1.11.1.js" type="text/javascript"></script>
     <script src="../../script/Calendar3.js" type="text/javascript"></script>
  
</head>
<body>
    <form id="form1" runat="server">
    <div class="panel panel-primary" style="width: 800px; font-size: 12px">
        <div class="panel-heading">
            <h3 class="panel-title">
                我的国际历史订单</h3>
        </div>
        <div class="panel-body" style="padding-left: 0px; padding-right: 0px">
            <div id="has_orders" runat="Server" style="border-bottom: 5px solid #E4E4E4; border-top: 5px solid #E4E4E4;
                width: 800px">
                <%--<div class="form-group" style="clear:both;height:40px;margin-top:10px">
                    <div class="control-label" style="width: 120px; float: left;padding-left:10px">
                        <label style="text-align: left; padding-top: 6px; width: 130px">
                            按时间段查找</label>
                    </div>
                    <div style="width: 40px; float: left">
                        <label class="control-label" style="padding-top: 6px">
                            From</label>
                    </div>
                    <div class="190px" style="padding-left: 0px; float: left">
                        <asp:TextBox ID="txt_from" runat="Server" CssClass="form-control txt_from" onclick="new Calendar().show(this);" /></div>
                    <div style="width: 60px; float: left; text-align: right">
                        <label class="control-label" style="text-align: right; padding-top: 6px; padding-right: 10px">
                            To</label>
                    </div>
                    <div style="width: 190px; float: left">
                        <asp:TextBox ID="txt_to" runat="Server" CssClass="form-control txt_to" onclick="new Calendar().show(this);"></asp:TextBox></div>
                    <div style="text-align: right; padding-left: 0px; width: 180px; float: left">
                        <asp:Button ID="btn_check_by_time" runat="Server" Text="查询" Width="120px" CssClass="btn btn-info check_by_time"
                            OnClick="btn_check_by_time_Click" OnClientClick="return isTimeNull()" /></div>
                </div>--%>
                <div class="form-group" style="height:10px;background:#DADADA"></div>
                <div class="form-group" style="clear:both">
                    <asp:DataList ID="bar_code" runat="Server" OnItemCommand="bar_code_ItemCommand" Style="margin-bottom: 0px">
                        <HeaderTemplate>
                            <div style="padding-top: 5px; padding-bottom: 5px; width: 780px; height: 30px">
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
                <div class="form-group">
                    <p style="text-align: right">
                        <%if (record_count > pageSize)
                          {
                        %>
                        每页<%=pageSize%>条&nbsp;&nbsp;&nbsp;总共<%=record_count%>条&nbsp;&nbsp;&nbsp;当前第<%=pageNow%>页&nbsp;&nbsp;&nbsp;
                        <%if (pageNow != 1)
                          {%>
                        <a href="check-order-by-time.aspx?pageNow=1">首页</a>&nbsp;&nbsp;&nbsp; <a href="check-order-by-time.aspx?pageNow=<%=pageNow-1 %>">
                            上一页</a>&nbsp;&nbsp;&nbsp;
                        <%} %>
                        <% if (pageNow != page_count)
                           {
                        %><a href="check-order-by-time.aspx?pageNow=<%=pageNow+1 %>">下一页</a>&nbsp;&nbsp;&nbsp;
                        <a href="check-order-by-time.aspx?pageNow=<%=page_count %>">尾页</a>&nbsp;&nbsp;&nbsp;
                        <%} %>
                        <%
                          } %>
                    </p>
                </div>
                <div class="form-group" style="height: 35px; padding-bottom: 5px; margin-top: 0px;
                    padding-right: 10px">
                    <div style="text-align: right">
                        <asp:Button ID="btn_downAll" runat="Server" Text="下载此页" CssClass="btn btn-info" OnClick="btn_downAll_Click" /></div>
                </div>
            </div>
            <div id="has_no_orders" runat="Server" visible="false" style="height: 240px">
                <div style="height: 200px; padding-top: 80px;">
                    <p style="text-align: center; font-weight: 600; font-size: 20px">
                        您好，您还没有下过单，没有您的订单信息!!</p>
                    <%--<p style="font-size: 20px; font-weight: 600; padding-left: 40px; padding-top: 60px;">
                        <a href="../../batch-import.aspx" style="text-decoration: underline">我要下单</a></p>--%>
                </div>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
