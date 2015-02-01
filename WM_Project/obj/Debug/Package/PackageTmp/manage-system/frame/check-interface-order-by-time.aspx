<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="check-interface-order-by-time.aspx.cs"
    Inherits="WM_Project.manage_system.frame.check_interface_order_by_time" %>

<%@ Import Namespace="WM_Project.logical.common" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../../stylesheets/bootstrap.css" rel="stylesheet" type="text/css" />
    <link href="../../stylesheets/bootstrap-theme.css" rel="stylesheet" type="text/css" />
    <script src="../../javascripts/bootstrap.js" type="text/javascript"></script>
    <script src="../../javascripts/jquery-1.11.1.js" type="text/javascript"></script>
    <script src="../../script/Calendar3.js" type="text/javascript"></script>
    <script type="text/javascript">
        
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="panel panel-primary" style="width: 800px; font-size: 13px">
        <div class="panel-heading">
            <h5 class="panel-title">
                按时间查找订单信息</h5>
        </div>
        <div class="panel-body">
            <div id="page_check_order" runat="Server" style="clear: both; margin: 0 auto; width: 100%;
                border: 2px solid #DADADA">
                <div class="form-group" style="margin-top: 10px; padding-left: 20px; padding-right: 20px;
                    height: 40px" id="query_by_time">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div style="width: 60px; float: left; padding-right: 10px; text-align: right">
                                <label class="control-label" style="padding-top: 6px">
                                    From:</label></div>
                            <div style="padding-left: 0px; padding-right: 0px; width: 120px; float: left;">
                                <asp:TextBox ID="txt_from" runat="Server" CssClass="form-control" onclick="new Calendar().show(this);"></asp:TextBox>
                            </div>
                            <div style="width: 70px; float: left; padding-right: 10px; text-align: right">
                                <label class="control-label" style="padding-top: 6px; padding-right: 10px; text-align: right">
                                    To:</label></div>
                            <div style="width: 120px; float: left;">
                                <asp:TextBox ID="txt_to" runat="Server" CssClass="form-control" onclick="new Calendar().show(this);"></asp:TextBox></div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <div style="width: 140px; float: left; padding-left: 40px">
                        <asp:Button ID="btn_query" runat="Server" CssClass="btn btn-info" Text="查询订单" OnClick="btn_query_Click" /></div>
                    <div style="text-align: right; width: 200px; float: left;">
                        <asp:Button ID="btn_query_all" runat="Server" CssClass="btn btn-info" Text="查询所有订单"
                            OnClick="btn_query_all_Click" />
                    </div>
                </div>
            <div style="height: 2px; background: #DADADA">
            </div>
            <div class="form-group">
                <%if (orders != null && orders.Count > 0)
                  { %>
                <table class="table table-striped " id="package" width="100%">
                    <thead>
                        <tr>
                            <th style="width: 20%; text-align: center">
                                订单号
                            </th>
                            <th style="width: 14%; text-align: center">
                                下单人
                            </th>
                            <th style="width: 9%; text-align: center">
                                包裹数
                            </th>
                            <th style="width: 16%; text-align: center">
                                付款时间
                            </th>
                            <th style="width: 15%; text-align: center">
                                付款方式
                            </th>
                            <th style="width: 12%; text-align: center">
                                付款金额
                            </th>
                            <th style="width: 6%; text-align: center">
                                详情
                            </th>
                            <th style="width: 8%; text-align: center">
                                下载
                            </th>
                        </tr>
                    </thead>
                    <%for (int i = 0; i < orders.Count; i++)
                      {
                          Order order = (Order)orders[i];
                    %>
                    <tr>
                        <td style="width: 20%; text-align: center" valign="middle">
                            <%=order.Order_number%>
                        </td>
                        <td style="width: 14%; text-align: center" valign="middle">
                            <%=order.Name%>
                        </td>
                        <td style="width: 9%; text-align: center" valign="middle">
                            <%=order.Quantity%>
                        </td>
                        <td style="width: 16%; text-align: center" valign="middle">
                            <%=order.Pay_time%>
                        </td>
                        <td style="width: 15%; text-align: center" valign="middle">
                            <%=order.Pay_way%>
                        </td>
                        <td style="width: 12%; text-align: center" valign="middle">
                            <%=order.Pay_after_discount%>
                        </td>
                        <td style="width: 6%; text-align: center" valign="middle">
                            <a target="_blank" href="../auto-order-detail-info.aspx?auto_no=<%=order.Order_number %>&type=detail">
                                详情</a>
                        </td>
                        <td style="width: 8%; text-align: center" valign="middle">
                            <a target="_blank" href="../order-detail-info.aspx?order_number=<%=order.Order_number %>&type=download">
                                下载</a>
                        </td>
                    </tr>
                    <%} %>
                    <tr>
                        <td colspan="8" style="text-align: right">
                            <%if (record_count > pageSize)
                              {
                            %>
                            每页<%=pageSize%>条&nbsp;&nbsp;&nbsp;总共<%=record_count%>条&nbsp;&nbsp;&nbsp;当前第<%=pageNow%>页&nbsp;&nbsp;&nbsp;
                            <%if (pageNow != 1)
                              {%>
                            <a href="check-interface-order-by-time.aspx?pageNow=1">首页</a>&nbsp;&nbsp;&nbsp;
                            <a href="check-interface-order-by-time.aspx?pageNow=<%=pageNow-1 %>">上一页</a>&nbsp;&nbsp;&nbsp;
                            <%} %>
                            <% if (pageNow != page_count)
                               {
                            %><a href="check-interface-order-by-time.aspx?pageNow=<%=pageNow+1 %>">下一页</a>&nbsp;&nbsp;&nbsp;
                            <a href="check-interface-order-by-time.aspx?pageNow=<%=page_count %>">尾页</a>&nbsp;&nbsp;&nbsp;
                            <%} %>
                            <%
                                  } %>
                        </td>
                    </tr>
                    <tr id="notice" runat="Server" visible="false">
                        <td colspan="8" style="background: #DADADA; height: 30px; color: #FF0000">
                            *&nbsp;默认显示当天下的最后20个订单
                        </td>
                    </tr>
                </table>
                <%}
                  else
                  {%>
                <div style="height: 200px; padding-top: 100px; text-align: center">
                    <p style="text-align: center; color: Red; font-size: 20px; font-weight: 600">
                        <%=message %></p>
                </div>
                <%} %>
            </div>
            </div>
        </div>
        <div class=" panel-footer">
            <p style="color: #FF0000; font-weight: 600">
                用户界面下单部分排在前面，Excel下单部分排在后面</p>
        </div>
    </div>
    </form>
</body>
</html>
