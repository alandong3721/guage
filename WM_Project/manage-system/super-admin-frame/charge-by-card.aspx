<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="charge-by-card.aspx.cs" Inherits="WM_Project.views.super_admin_frame.charge_by_card" %>

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
    <div class="panel panel-primary" style="width:700px">
        <div class="panel-heading">
            <h5 class="panel-title">未对账的卡充值记录</h5>
        </div>
        <div class="panel-body">
            <div class="form-group">
            
                 <div style="width: 700px; margin: 0 auto; clear: both" id="record_has_not_check" runat="Server">
                    <asp:DataList ID="record_has_not_check_datalist" runat="Server" 
                         onitemcommand="record_has_not_check_datalist_ItemCommand">
                        <HeaderTemplate>
                            <table style="width: 670px; margin: 0 auto;">
                                <tr style="height: 2px">
                                    <td colspan="6" style="height: 2px; background: #DADADA">
                                    </td>
                                </tr>
                                <tr style="height: 35px">
                                    <th style="text-align: center; width: 120px">
                                        充值用户
                                    </th>
                                    <th style="text-align: center; width: 80px">
                                        充值金额
                                    </th>
                                    <th style="text-align: center; width: 80px">
                                        充值方式
                                    </th>
                                    <th style="text-align: center; width: 200px">
                                        充值时间
                                    </th>
                                    <th style="text-align: center; width: 120px">
                                        核对
                                    </th>
                                </tr>
                                <tr style="height: 2px">
                                    <td colspan="5" style="height: 2px; background: #DADADA">
                                    </td>
                                </tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr style="height: 30px">
                                
                                <td style="text-align: center">
                                    <%#DataBinder.Eval(Container.DataItem,"name") %>
                                </td>
                                <td style="text-align: center">
                                    <%#DataBinder.Eval(Container.DataItem,"amount") %>
                                </td>
                                <td style="text-align: center">
                                    <%#DataBinder.Eval(Container.DataItem,"charge_way") %>
                                </td>
                                <td style="text-align: center">
                                    <%#DataBinder.Eval(Container.DataItem,"time") %>
                                </td>
                                <td style="text-align: center">
                                    <asp:LinkButton ID="btn_audit" CommandName="checked" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"id") %>' style="color: #3D86C5; font-weight: 600; text-decoration: underline"  runat="Server" Text="【通过核对】"></asp:LinkButton>
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
                    <div style="text-align: right;padding-right:40px">
                        <%if (record_count > 0)
                          {
                        %>
                        每页<%=page_size%>条&nbsp;&nbsp;&nbsp;总共<%=record_count%>条&nbsp;&nbsp;&nbsp;当前第<%=page_now%>页&nbsp;&nbsp;&nbsp;
                        <%if (page_now != 1)
                          {%>
                        <a href="charge-by-card.aspx?unckeckpagenow=1">首页</a>&nbsp;&nbsp;&nbsp; <a href="charge-by-card.aspx?unckeckpagenow=<%=page_now-1 %>">
                            上一页</a>&nbsp;&nbsp;&nbsp;
                        <%} %>
                        <% if (page_now != page_count)
                           {
                        %><a href="charge-by-card.aspx?unckeckpagenow=<%=page_now+1 %>">下一页</a>&nbsp;&nbsp;&nbsp;
                        <a href="charge-by-card.aspx?unckeckpagenow=<%=page_count %>">尾页</a>&nbsp;&nbsp;&nbsp;
                        <%} %>
                        <% } %>
                    </div>
                </div>
                <div style="height: 80px; padding-top: 40px; text-align: center" runat="Server" id="has_unchecked_record"
                    visible="false">
                    <p style="font-size: 20px; font-weight: 600; color: #FF0000">
                        没有未审核的还款申请！！</p>
                </div>
            
            </div>
        </div>
        <div class="panel-footer">
            <p style="color:#FF0000; font-weight:600">*&nbsp;此上显示的是未对账的卡充值记录,如果银行卡上确实收到了该笔钱，即可点击对账进行对账！！</p>
        </div>
    </div>

     <div class="panel panel-primary" style="width:700px">
        <div class="panel-heading">
            <h5 class="panel-title">已对账的卡充值记录</h5>
        </div>
        <div class="panel-body">
            <div class="form-group">
            
                 <div style="width: 700px; margin: 0 auto; clear: both" id="record_has_check" runat="Server">
                    <asp:DataList ID="record_has_check_datalist" runat="Server">
                        <HeaderTemplate>
                            <table style="width: 670px; margin: 0 auto;">
                                <tr style="height: 2px">
                                    <td colspan="4" style="height: 2px; background: #DADADA">
                                    </td>
                                </tr>
                                <tr style="height: 35px">
                                    <th style="text-align: center; width: 120px">
                                        充值用户
                                    </th>
                                    <th style="text-align: center; width: 80px">
                                        充值金额
                                    </th>
                                    <th style="text-align: center; width: 80px">
                                        充值方式
                                    </th>
                                    <th style="text-align: center; width: 200px">
                                        充值时间
                                    </th>
                                </tr>
                                <tr style="height: 2px">
                                    <td colspan="4" style="height: 2px; background: #DADADA">
                                    </td>
                                </tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr style="height: 30px">
                                
                                <td style="text-align: center">
                                    <%#DataBinder.Eval(Container.DataItem,"name") %>
                                </td>
                                <td style="text-align: center">
                                    <%#DataBinder.Eval(Container.DataItem,"amount") %>
                                </td>
                                <td style="text-align: center">
                                    <%#DataBinder.Eval(Container.DataItem,"charge_way") %>
                                </td>
                                <td style="text-align: center">
                                    <%#DataBinder.Eval(Container.DataItem,"time") %>
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
                                <td colspan="4" style="height: 2px; background: #DADADA">
                                </td>
                            </tr>
                            </table></FooterTemplate>
                    </asp:DataList>
                    <div style="text-align: right;padding-right:40px">
                        <%if (checked_record_count > 0)
                          {
                        %>
                        每页<%=checked_page_size%>条&nbsp;&nbsp;&nbsp;总共<%=checked_record_count%>条&nbsp;&nbsp;&nbsp;当前第<%=checked_page_now%>页&nbsp;&nbsp;&nbsp;
                        <%if (checked_page_now != 1)
                          {%>
                        <a href="charge-by-card.aspx?checkpagenow=1">首页</a>&nbsp;&nbsp;&nbsp; <a href="charge-by-card.aspx?checkpagenow=<%=checked_page_now-1 %>">
                            上一页</a>&nbsp;&nbsp;&nbsp;
                        <%} %>
                        <% if (checked_page_now != checked_page_count)
                           {
                        %><a href="charge-by-card.aspx?checkpagenow=<%=checked_page_now+1 %>">下一页</a>&nbsp;&nbsp;&nbsp;
                        <a href="charge-by-card.aspx?checkpagenow=<%=checked_page_count %>">尾页</a>&nbsp;&nbsp;&nbsp;
                        <%} %>
                        <% } %>
                    </div>
                </div>
                <div style="height: 80px; padding-top: 40px; text-align: center" runat="Server" id="has_no_checked_record"
                    visible="false">
                    <p style="font-size: 20px; font-weight: 600; color: #FF0000">
                        没有通过核对的卡充值记录！！</p>
                </div>
            
            </div>
        </div>
        <div class="panel-footer">
            <p style="color:#FF0000; font-weight:600">*&nbsp;此上显示的是未对账的卡充值记录,如果银行卡上确实收到了该笔钱，即可点击对账进行对账！！</p>
        </div>
    </div>
    </form>
</body>
</html>
