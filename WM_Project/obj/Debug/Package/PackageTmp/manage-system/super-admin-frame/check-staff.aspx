<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="check-staff.aspx.cs" Inherits="WM_Project.manage_system.super_admin_frame.check_staff" %>

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
    <div class=" panel panel-primary" style="width: 700px;">
        <div class="panel-heading">
            <h5 class="panel-title">
                现有员工信息</h5>
        </div>
        <div class="panel-body">
            <div class="form-group" id="staff_info_now" runat="server" style="margin-top: 20px;
                clear: both">
                <div style="width: 700px; margin: 0 auto; clear: both" id="has_staff" runat="Server">
                    <asp:DataList ID="staff_datalist" runat="Server" OnItemCommand="staff_datalist_ItemCommand">
                        <HeaderTemplate>
                            <table style="width: 670px; margin: 0 auto;">
                                <tr style="height: 30px">
                                    <td colspan="4" style="text-align: center; font-size: 20px; font-weight: 600; color: #3A83C2">
                                        现有员工信息
                                    </td>
                                </tr>
                                <tr style="height: 2px">
                                    <td colspan="4" style="height: 2px; background: #DADADA">
                                    </td>
                                </tr>
                                <tr style="height: 30px">
                                    <th style="text-align: center; width: 180px">
                                        员工姓名
                                    </th>
                                    <th style="text-align: center; width: 200px">
                                        联系方式
                                    </th>
                                    <th style="text-align: center; width: 230px">
                                        进入公司时间
                                    </th>
                                    <th style="text-align: center; width: 60px">
                                        删除
                                    </th>
                                </tr>
                                <tr style="height: 2px">
                                    <td colspan="8" style="height: 2px; background: #DADADA">
                                    </td>
                                </tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td style="text-align: center">
                                    <%#DataBinder.Eval(Container.DataItem,"name") %>
                                </td>
                                <td style="text-align: center">
                                    <%#DataBinder.Eval(Container.DataItem,"phone") %>
                                </td>
                                <td style="text-align: center">
                                    <%#DataBinder.Eval(Container.DataItem,"time") %>
                                </td>
                                <td style="text-align: center">
                                    <asp:ImageButton ID="delete" runat="Server" ImageUrl="../../image/images/del.jpg" CommandName="delete"
                                        CommandArgument='<%#DataBinder.Eval(Container.DataItem,"id") %>' />
                                </td>
                            </tr>
                        </ItemTemplate>
                        <SeparatorTemplate>
                            <tr style="height: 2px">
                                <td colspan="4" style="height: 2px; background: #DADADA">
                                </td>
                            </tr>
                        </SeparatorTemplate>
                        <FooterTemplate>
                            <tr style="height: 2px">
                                <td colspan="8" style="height: 2px; background: #DADADA">
                                </td>
                            </tr>
                            </table></FooterTemplate>
                    </asp:DataList>
                    <div style="text-align: right">
                        <%if (staff_count > pageSize)
                          {
                        %>
                        每页<%=pageSize%>条&nbsp;&nbsp;&nbsp;总共<%=staff_count%>条&nbsp;&nbsp;&nbsp;当前第<%=pageNow%>页&nbsp;&nbsp;&nbsp;
                        <%if (pageNow != 1)
                          {%>
                        <a href="check-staff.aspx?pageNow=1&action=staff">首页</a>&nbsp;&nbsp;&nbsp; <a href="check-staff.aspx?pageNow=<%=pageNow-1 %>&action=staff">
                            上一页</a>&nbsp;&nbsp;&nbsp;
                        <%} %>
                        <% if (pageNow != staff_page_count)
                           {
                        %><a href="check-staff.aspx?pageNow=<%=pageNow+1 %>&action=staff">下一页</a>&nbsp;&nbsp;&nbsp;
                        <a href="check-staff.aspx?pageNow=<%=staff_page_count %>&action=staff">尾页</a>&nbsp;&nbsp;&nbsp;
                        <%} %>
                        <% } %>
                    </div>
                </div>
                <div style="height: 80px; padding-top: 40px; text-align: center" runat="Server" id="has_no_sataff"
                    visible="false">
                    <p style="font-size: 20px; font-weight: 600">
                        没有员工信息</p>
                </div>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
