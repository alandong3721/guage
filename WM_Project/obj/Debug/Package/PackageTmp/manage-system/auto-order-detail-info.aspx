<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/back-stage/home.Master" AutoEventWireup="true"
    CodeBehind="auto-order-detail-info.aspx.cs" Inherits="WM_Project.manage_system.auto_order_detail_info" %>

<%@ Import Namespace="WM_Project.logical.common" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="center" runat="server">
    <div class="panel panel-primary" style="margin-left:30px;margin-right:30px">
        <div class="panel-heading">
            <h3 class="panel-title">
                自动单<%=auto_no %>详情</h3>
        </div>
        <div class="panel-body">
            <div style="height: 2px; background: #DADADA; margin-top: 16px">
            </div>
            <%if (packages != null && packages.Count > 0)
              { %>
            <table class="table table-striped " id="package" width="100%">
                <thead>
                    <tr>
                        <th style="width: 20%; text-align: center">
                            订单号
                        </th>
                        <th style="width: 14%; text-align: center">
                            发件人
                        </th>
                        <th style="width: 14%; text-align: center">
                            收件人
                        </th>
                        <th style="width: 8%; text-align: center">
                            重量
                        </th>
                        <th style="width: 16%; text-align: center">
                            下单时间
                        </th>
                        <th style="width: 12%; text-align: center">
                            付款金额
                        </th>
                        <th style="width: 8%; text-align: center">
                            详情
                        </th>
                        <th style="width: 8%; text-align: center">
                            下载
                        </th>
                    </tr>
                </thead>
                <%for (int i = 0; i < packages.Count; i++)
                  {
                      AutoOrderList package = (AutoOrderList)packages[i];
                %>
                <tr>
                    <td style="width: 20%; text-align: center" valign="middle">
                        <%=package.Order_no%>
                    </td>
                    <td style="width: 14%; text-align: center" valign="middle">
                        <%=package.CollectionContactName%>
                    </td>
                    <td style="width: 14%; text-align: center" valign="middle">
                        <%=package.RecipientContactName%>
                    </td>
                    <td style="width: 8%; text-align: center" valign="middle">
                        <%=package.Weight%>kg
                    </td>
                    <td style="width: 16%; text-align: center" valign="middle">
                        <%=package.Pay_time%>
                    </td>
                    <td style="width: 12%; text-align: center" valign="middle">
                        £<%=package.Pay_after_discount%>
                    </td>
                    <td style="width: 8%; text-align: center" valign="middle">
                        <a target="_blank" href="check-order-detail-info.aspx?type=detail&order_number=<%=package.Order_no %>">
                            详情</a>
                    </td>
                    <td style="width: 8%; text-align: center" valign="middle">
                        <a target="_blank" href="check-order-detail-info.aspx?type=download&order_number=<%=package.Order_no %>">
                            下载</a>
                    </td>
                </tr>
                <%} %>
                <tr>
                    <td colspan="7" style="text-align: right">
                        <%if (record_count > pageSize)
                          {
                        %>
                        每页<%=pageSize%>条&nbsp;&nbsp;&nbsp;总共<%=record_count%>条&nbsp;&nbsp;&nbsp;当前第<%=pageNow%>页&nbsp;&nbsp;&nbsp;
                        <%if (pageNow != 1)
                          {%>
                        <a href="auto-order-detail-info.aspx?pageNow=1">首页</a>&nbsp;&nbsp;&nbsp; <a href="auto-order-detail-info.aspx?pageNow=<%=pageNow-1 %>">
                            上一页</a>&nbsp;&nbsp;&nbsp;
                        <%} %>
                        <% if (pageNow != page_count)
                           {
                        %><a href="auto-order-detail-info.aspx?pageNow=<%=pageNow+1 %>">下一页</a>&nbsp;&nbsp;&nbsp;
                        <a href="auto-order-detail-info.aspx?pageNow=<%=page_count %>">尾页</a>&nbsp;&nbsp;&nbsp;
                        <%} %>
                        <%
                          } %>
                    </td>
                </tr>
            </table>
            <%}
            %>
        </div>
    </div>
</asp:Content>
