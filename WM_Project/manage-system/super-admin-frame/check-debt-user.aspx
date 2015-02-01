<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="check-debt-user.aspx.cs" Inherits="WM_Project.manage_system.super_admin_frame.check_debt_user" %>

<%@ Import Namespace="WM_Project.logical.user" %>

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
    <div class="panel panel-primary" style="width:700px" >
            <div class="panel-heading">
                <h3 class="panel-title">
                    欠款用户信息</h3>
            </div>
            <div class="panel-body">
                <div style="padding-top: 12px">
                    <div style="width: 560px; margin: 0 auto">
                        <% if (userdebts.Count > 0)
                           {%>
                        <table class="table table-striped " id="package" style="width: 600px;margin:0 auto">
                            <thead>
                                <tr>
                                    <th style="text-align: center;width:240px">
                                        用户名
                                    </th>
                                    <th style="text-align: center;width:240px">
                                        金额
                                    </th>
                                    <th style="text-align: center;width:120px">
                                        详情
                                    </th>
                                </tr>
                            </thead>
                            <tbody>
                                <% for (int i = 0; i < userdebts.Count; i++)
                                   {
                                       UserDebt userdebt = (UserDebt)userdebts[i];
                                %>
                                <tr>
                                    <td style="text-align: center">
                                        <%=userdebt.User_name %>
                                    </td>
                                    <td style="text-align: center">
                                        <%=userdebt.Amount %>
                                    </td>
                                    <td style="text-align: center">
                                        <a target="_blank" href="../user-debt-record-info.aspx?username=<%=userdebt.User_name %>" style=" text-decoration:underline">
                                            详情</a>
                                    </td>
                                </tr>
                                <%
                                   }
                                %>
                                <%if (debt_count > pageSize)
                                  {
                                %>
                                <tr>
                                    <td colspan="4" align="right">
                                        每页<%=pageSize%>条&nbsp;&nbsp;&nbsp;总共<%=debt_count%>条&nbsp;&nbsp;&nbsp;当前第<%=pageNow%>页&nbsp;&nbsp;&nbsp;
                                        <%if (pageNow != 1)
                                          {%>
                                        <a href="check-debt-user.aspx?pageNow=1">首页</a>&nbsp;&nbsp;&nbsp; <a
                                            href="check-debt-user.aspx?pageNow=<%=pageNow-1 %>">上一页</a>&nbsp;&nbsp;&nbsp;
                                        <%} %>
                                        <% if (pageNow != debt_page_count)
                                           {
                                        %><a href="check-debt-user.aspx?pageNow=<%=pageNow+1 %>">下一页</a>&nbsp;&nbsp;&nbsp;
                                        <a href="check-debt-user.aspx?pageNow=<%=debt_page_count %>">尾页</a>&nbsp;&nbsp;&nbsp;
                                        <%} %>
                                    </td>
                                </tr>
                                <%} %>
                            </tbody>
                        </table>
                        <%}
                           else
                           {
                        %>
                        <%
                           }
                        %>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
