<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="user-account-balance-check.aspx.cs" Inherits="WM_Project.views.super_admin_frame.user_account_balance_check" %>
<%@ Import Namespace="WM_Project.logical.user" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../stylesheets/bootstrap.css" rel="stylesheet" type="text/css" />
    <link href="../../stylesheets/bootstrap-theme.css" rel="stylesheet" type="text/css" />
    <script src="../../javascripts/bootstrap.js" type="text/javascript"></script>
    <script src="../../javascripts/jquery-1.11.1.js" type="text/javascript"></script>

    <script type="text/javascript">

        function isAccountNull() {


            var account = document.getElementsByName("txt_username");
            
            if (account[0].value.trim() == "") {
                alert("账户名不能为空！！");
                return false;
            }

            return true;
        }
    
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <div class="panel panel-primary" style="width:700px">
        <div class="panel-heading">
            <h5 class="panel-title">用户余额查询</h5>
        </div>
        <div class="panel-body">
            <div class="form-group" style="height:40px">
                <div style="width:160px;text-align:right;float:left;padding-top:6px;padding-right:20px">
                    <label class="control-label">请输入用户名</label>
                </div>
                <div style="width:320px;float:left">
                    <input type="text" class="form-control" name="txt_username"/>
                </div>
                <div style="width:160px;float:left;text-align:left;padding-left:60px">
                    <asp:Button ID="btn_check_balance" runat="Server" CssClass="btn btn-info" 
                        Text="查询" onclick="btn_check_balance_Click" OnClientClick="return isAccountNull()" />
                </div>
            </div>
            <div class="form-group" style="height:2px;background:#DADADA"></div>

            <div class="form-group" id="sdkf" runat="Server">
                 <div style="padding-top: 12px">
                    <div style="width: 660px; margin: 0 auto">
                        <% if (my_account_array.Count > 0)
                           {%>
                        <table class="table table-striped " id="package" style="width: 600px;margin:0 auto">
                            <thead>
                                <tr>
                                    <th style="text-align: center;width:240px">
                                        用户名
                                    </th>
                                    <th style="text-align: center;width:240px">
                                        余额
                                    </th>
                                    <th style="text-align: center;width:120px">
                                        交易明细
                                    </th>
                                </tr>
                            </thead>
                            <tbody>
                                <% for (int i = 0; i < my_account_array.Count; i++)
                                   {
                                       MyAccount myaccount = (MyAccount)my_account_array[i];
                                %>
                                <tr>
                                    <td style="text-align: center">
                                        <%=myaccount.Name%>
                                    </td>
                                    <td style="text-align: center">
                                        <%=myaccount.Balance%>
                                    </td>
                                    <td style="text-align: center">
                                        <a target="content" href="user-account-trans-info.aspx?name=<%=myaccount.Name %>" style=" text-decoration:underline">
                                            交易明细</a>
                                    </td>
                                </tr>
                                <%
                                   }
                                %>
                                <%if (record_count > 0)
                                  {
                                %>
                                <tr>
                                    <td colspan="4" align="right">
                                        每页<%=page_size%>条&nbsp;&nbsp;&nbsp;总共<%=record_count%>条&nbsp;&nbsp;&nbsp;当前第<%=page_now%>页&nbsp;&nbsp;&nbsp;
                                        <%if (page_now != 1)
                                          {%>
                                        <a href="user-account-balance-check.aspx?pageNow=1">首页</a>&nbsp;&nbsp;&nbsp; <a
                                            href="user-account-balance-check.aspx?pageNow=<%=page_now-1 %>">上一页</a>&nbsp;&nbsp;&nbsp;
                                        <%} %>
                                        <% if (page_now != page_count)
                                           {
                                        %><a href="user-account-balance-check.aspxx?pageNow=<%=page_now+1 %>">下一页</a>&nbsp;&nbsp;&nbsp;
                                        <a href="user-account-balance-check.aspx?pageNow=<%=page_count %>">尾页</a>&nbsp;&nbsp;&nbsp;
                                        <%} %>
                                    </td>
                                </tr>
                                <%} %>
                            </tbody>
                        </table>
                        <%} %>
                    </div>
                </div>
            
            </div>

        </div>
        <div class="panel-footer">
            <p style="color:#FF0000; font-weight:600">用户账户余额浏览,还可以通过用户名查找用户的余额</p>
        </div>
    </div>
    </form>
</body>
</html>
