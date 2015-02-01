<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="user-account-trans-info.aspx.cs" Inherits="WM_Project.manage_system.super_admin_frame.user_account_trans_info" %>
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
    <div class="panel panel-primary" id="page_my_account_trans_info" runat="Server" style="width:700px;">
                <div class="panel-heading">
                    <h5 class="panel-title">
                        账户交易明细
                    </h5>
                </div>
                <div class="panel-body">
                    <div class="form-group">
                        <% if (transarray.Count > 0)
                           {%>
                        <table class="table table-striped " id="Table1" style="width: 100%">
                            <thead>
                                <tr>
                                    <th style="text-align: center">
                                        金额
                                    </th>
                                    <th style="text-align: center">
                                        操作类型
                                    </th>
                                    <th style="text-align: center">
                                        操作时间
                                    </th>
                                </tr>
                            </thead>
                            <tbody>
                                <% for (int i = 0; i < transarray.Count; i++)
                                   {
                                       MyAccountTrans myaccounttrans = (MyAccountTrans)transarray[i];
                                %>
                                <tr>
                                    <td style="text-align: center">
                                        £<%=myaccounttrans.Amout%>
                                    </td>
                                    <td style="text-align: center">
                                        <%=myaccounttrans.Operation%>
                                    </td>
                                    <td style="text-align: center">
                                        <%=myaccounttrans.Time.ToString("yyyy-MM-dd HH:mm:ss")%>
                                    </td>
                                </tr>
                                <%
                                   }%>
                                <%if (record_count > pageSize)
                                  {
                                %>
                                <tr>
                                    <td colspan="3" style="text-align: right">
                                        每页<%=pageSize%>条&nbsp;&nbsp;&nbsp;总共<%=record_count%>条&nbsp;&nbsp;&nbsp;当前第<%=pageNow%>页&nbsp;&nbsp;&nbsp;
                                        <%if (pageNow != 1)
                                          {%>
                                        <a href="user-account-trans-info.aspx?name=<%=name %>&pageNow=1">首页</a>&nbsp;&nbsp;&nbsp; <a href="user-account-trans-info.aspx?name=<%=name %>&pageNow=<%=pageNow-1 %>">
                                            上一页</a>&nbsp;&nbsp;&nbsp;
                                        <%} %>
                                        <% if (pageNow != page_count)
                                           {
                                        %><a href="user-account-trans-info.aspx?name=<%=name %>&pageNow=<%=pageNow+1 %>">下一页</a>&nbsp;&nbsp;&nbsp; <a
                                            href="user-account-trans-info.aspx?name=<%=name %>&pageNow=<%=page_count %>">尾页</a>&nbsp;&nbsp;&nbsp;
                                        <%} %>
                                    </td>
                                </tr>
                                <% } %>
                            </tbody>
                        </table>
                        <%}
                           else
                           {%>
                        <div style="height: 200px; padding-top: 100px; text-align: center; color: #FF0000;
                            font-weight: 600">
                            目前没有您的任何账户交易记录！！</div>
                        <%}
                        %>
                    </div>
                </div>
            </div>

    </form>
</body>
</html>
