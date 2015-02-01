<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="charge-repay-record.aspx.cs" Inherits="WM_Project.manage_system.super_admin_frame.charge_repay_record" %>

<%@ Import Namespace="WM_Project.logical.user" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../stylesheets/bootstrap.css" rel="stylesheet" type="text/css" />
    <link href="../../stylesheets/bootstrap-theme.css" rel="stylesheet" type="text/css" />
    <script src="../../javascripts/bootstrap.js" type="text/javascript"></script>
    <script src="../../javascripts/jquery-1.11.1.js" type="text/javascript"></script>
    <style type="text/css">
      td
        {
            word-break: break-all; /*支持IE，chrome，FF不支持*/
            word-wrap: break-word; /*支持IE，chrome，FF*/
        }
    </style>
    
</head>
<body>
    <form id="form1" runat="server">
    <div class="panel panel-primary" style="width:700px">
            <div class="panel-heading">
                <h3 class="panel-title">
                    充值还款记录</h3>
            </div>
            <div class="panel-body">
                <div style="padding-top: 12px">
                    <div style="width: 100%; margin: 0 auto">
                        <% if (chargerecords.Count > 0)
                           {%>
                        <table class="table table-striped " id="Table1" style="width: 100%">
                            <thead>
                                <tr>
                                    <th style="text-align: center;width:120px">
                                        用户名
                                    </th>
                                    <th style="text-align: center;width:90px">
                                        金额
                                    </th>
                                    <th style="text-align: center;width:80px">
                                        操作类型
                                    </th>
                                    <th style="text-align: center;width:130px">
                                        操作时间
                                    </th>
                                    <th style="text-align: center;width:240px">
                                        备注
                                    </th>
                                </tr>
                            </thead>
                            <tbody>
                                <% for (int i = 0; i < chargerecords.Count; i++)
                                   {
                                       UserDebtTrans record = (UserDebtTrans)chargerecords[i];
                                %>
                                <tr style="height:40px">
                                    <td valign="middle" style="text-align: center;width:120px">
                                        <a target="_blank" href="../user-detail-info.aspx?username=<%=record.User_name%>">
                                            <%=record.User_name%></a>
                                    </td>
                                    <td valign="middle" style="text-align: center;width:90px">
                                        <%=record.Amount%>
                                    </td>
                                    <td valign="middle" style="text-align: center;width:80px">
                                        <%=record.Operation%>
                                    </td>
                                    <td valign="middle" style="text-align: center;width:130px">
                                        <%=record.Operation_time.ToString("yyyy-MM-dd HH:mm") %>
                                    </td>
                                    <td valign="middle" style="text-align: center;width:240px">
                                        <%=record.Note %>
                                    </td>
                                </tr>
                                <%
                                   }%>
                                <%if (record_count > pageSize)
                                  {
                                %>
                                <tr>
                                    <td colspan="5" align="right">
                                        每页<%=pageSize%>条&nbsp;&nbsp;&nbsp;总共<%=record_count%>条&nbsp;&nbsp;&nbsp;当前第<%=pageNow%>页&nbsp;&nbsp;&nbsp;
                                        <%if (pageNow != 1)
                                          {%>
                                        <a href="charge-repay-record.aspx?pageNow=1">首页</a>&nbsp;&nbsp;&nbsp;
                                        <a href="charge-repay-record.aspx?pageNow=<%=pageNow-1 %>">上一页</a>&nbsp;&nbsp;&nbsp;
                                        <%} %>
                                        <% if (pageNow != record_page_count)
                                           {
                                        %><a href="charge-repay-record.aspx?pageNow=<%=pageNow+1 %>">下一页</a>&nbsp;&nbsp;&nbsp;
                                        <a href="charge-repay-record.aspx?pageNow=<%=record_page_count %>">尾页</a>&nbsp;&nbsp;&nbsp;
                                        <%} %>
                                    </td>
                                </tr>
                                <% } %>
                            </tbody>
                        </table>
                        <%}
                           else
                           {%>
                        <div style="height: 200px; padding-top: 100px; text-align: center">
                            目前没有任何充值记录！！</div>
                        <%}
                        %>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
