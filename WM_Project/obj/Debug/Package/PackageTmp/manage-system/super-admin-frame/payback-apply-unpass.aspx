<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="payback-apply-unpass.aspx.cs" Inherits="WM_Project.manage_system.super_admin_frame.payback_apply_unpass" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../../stylesheets/bootstrap.css" rel="stylesheet" type="text/css" />
    <link href="../../stylesheets/bootstrap-theme.css" rel="stylesheet" type="text/css" />
    <script src="../../javascripts/bootstrap.js" type="text/javascript"></script>
    <script src="../../javascripts/jquery-1.11.1.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="panel panel-primary" style="width:700px">
        <div class="panel-heading">
            <h5 class="panel-title">审核未通过的还款申请</h5>
        </div>
        <div class="panel-body">
            <div class="form-group">
                <div style="width: 700px; margin: 0 auto; clear: both" id="has_apply_info" runat="Server">
                    <asp:DataList ID="apply_info_datalist" runat="Server">
                        <HeaderTemplate>
                            <table style="width: 670px; margin: 0 auto;">
                                <tr style="height: 30px">
                                    <td colspan="5" style="text-align: center; font-size: 20px; font-weight: 600; color: #3A83C2">
                                        审核未通过的还款申请
                                    </td>
                                </tr>
                                <tr style="height: 2px">
                                    <td colspan="5" style="height: 2px; background: #DADADA">
                                    </td>
                                </tr>
                                <tr style="height: 35px">
                                    <th style="text-align: center; width: 120px">
                                        申请用户
                                    </th>
                                    <th style="text-align: center; width: 80px">
                                        还款金额
                                    </th>
                                    <th style="text-align: center; width: 220px">
                                        申请时间
                                    </th>
                                    <th style="text-align: center; width: 120px">
                                        处理员工
                                    </th>
                                    <th style="text-align: center; width: 120px">
                                        审核状态
                                    </th>
                                </tr>
                                <tr style="height: 2px">
                                    <td colspan="5" style="height: 2px; background: #DADADA">
                                    </td>
                                </tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td style="text-align: center">
                                    <%#DataBinder.Eval(Container.DataItem,"name") %>
                                </td>
                                <td style="text-align: center">
                                    <%#DataBinder.Eval(Container.DataItem,"amount") %>
                                </td>
                                <td style="text-align: center">
                                    <%#DataBinder.Eval(Container.DataItem,"time") %>
                                </td>
                                <td style="text-align: center">
                                    <%#DataBinder.Eval(Container.DataItem,"staff") %>
                                </td>
                                <td style="text-align: center">
                                    未通过审核
                                </td>
                            </tr>
                        </ItemTemplate>
                        <SeparatorTemplate>
                            <tr style="height: 2px">
                                <td colspan="5" style="height: 2px; background: #DADADA">
                                </td>
                            </tr>
                        </SeparatorTemplate>
                        <FooterTemplate>
                            <tr style="height: 2px">
                                <td colspan="5" style="height: 2px; background: #DADADA">
                                </td>
                            </tr>
                            </table></FooterTemplate>
                    </asp:DataList>
                    <div style="text-align: right">
                        <%if (record_count > pageSize)
                          {
                        %>
                        每页<%=pageSize%>条&nbsp;&nbsp;&nbsp;总共<%=record_count%>条&nbsp;&nbsp;&nbsp;当前第<%=pageNow%>页&nbsp;&nbsp;&nbsp;
                        <%if (pageNow != 1)
                          {%>
                        <a href="payback-apply-unpass.aspx?pageNow=1">首页</a>&nbsp;&nbsp;&nbsp; <a href="payback-apply-unpass.aspx?pageNow=<%=pageNow-1 %>">
                            上一页</a>&nbsp;&nbsp;&nbsp;
                        <%} %>
                        <% if (pageNow != page_count)
                           {
                        %><a href="payback-apply-unpass.aspx?pageNow=<%=pageNow+1 %>">下一页</a>&nbsp;&nbsp;&nbsp;
                        <a href="payback-apply-unpass.aspx?pageNow=<%=page_count %>">尾页</a>&nbsp;&nbsp;&nbsp;
                        <%} %>
                        <% } %>
                    </div>
                </div>
                <div style="height: 80px; padding-top: 40px; text-align: center" runat="Server" id="has_no_apply_info"
                    visible="false">
                    <p style="font-size: 20px; font-weight: 600;color:#FF0000">
                        没有未通过审核的还款申请！！</p>
                </div>
            
            
            
            </div>
        </div>
        <div class="panel-footer"></div>
    
    </div>
    </form>
</body>
</html>
