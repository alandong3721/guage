<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="set-rate-postnl.aspx.cs" Inherits="WM_Project.manage_system.super_admin_frame.set_rate_postnl" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../stylesheets/bootstrap.css" rel="stylesheet" type="text/css" />
    <link href="../../stylesheets/bootstrap-theme.css" rel="stylesheet" type="text/css" />
    <script src="../../javascripts/bootstrap.js" type="text/javascript"></script>
    <script src="../../javascripts/jquery-1.11.1.js" type="text/javascript"></script>

    <script type="text/javascript">
        function isNameNULL() {
            var name=document.getElementsByName("username");

            if(name[0].value.trim()==""){
                alert("用户名不能为空！！");
                return false;
            }

            return true;
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
     <div style="width: 700px;">
        <div class="panel panel-primary">
            <div class="panel-heading">
                <h3 class="panel-title">
                    设置 PostNL Rate</h3>
            </div>
            <div class="panel-body">
                <div class="form-group" style="margin-top: 10px; height: 40px; clear: both">
                    <div style="width: 120px; float: left; text-align: right">
                        <label class="control-label" style="padding-top: 5px; padding-right: 20px">
                            用户名</label></div>
                    <div style="width: 500px; float: left">
                        <input type="text" class="form-control" name="username" />
                    </div>
                    <div style="color: #FF0000; padding-left: 10px; padding-top: 10px; width: 40px; float: left">
                        *</div>
                </div>
                <div class="form-group" style="margin-top: 10px; height: 40px; clear: both">
                    <div style="width: 120px; float: left; text-align: right">
                        <label class="control-label" style="padding-top: 5px; text-align: right; padding-right: 20px">
                            邮费类型</label>
                    </div>
                    <div style="width: 500px; float: left;">
                        <select class="form-control" name="postnlrate">
                            <option>rate22</option>
                            <option>rate21</option>
                            <option>rate20</option>
                            <option>rate19</option>
                            <option>rate18</option>
                            <option>rate17</option>
                            <option>rate16</option>
                            <option>rate15</option>
                            <option>rate14</option>
                            <option>rate13</option>
                            <option>rate12</option>
                            <option>rate11</option>
                            <option>rate10</option>
                            <option>rate9</option>
                            <option>rate8</option>
                            <option>rate7</option>
                            <option>rate6</option>
                            <option>rate5</option>
                            <option>rate4</option>
                            <option>rate3</option>
                            <option>rate2</option>
                            <option>rate1</option>
                        </select>
                    </div>
                    <div style="color: #FF0000; padding-left: 10px; padding-top: 10px; width: 40px; float: left">
                        *</div>
                </div>
                <div class="form-group" style="margin-top: 10px; height: 40px; clear: both;text-align:center">
                    <asp:Button ID="btn_set_postnl_rate" Text="设置 PostNL Rate" runat="Server" 
                        CssClass="btn btn-info" onclick="btn_set_postnl_rate_Click" OnClientClick="return isNameNULL()"/>
                </div>
            </div>
            <div class="panel-footer"></div>
        </div>


        <div class=" panel panel-primary" style="width: 700px;">
            <div class="panel-heading">
                <h5 class="panel-title">
                    有优惠的用户 PostNL 邮费类别</h5>
            </div>
            <div class="panel-body">
                <div id="user_has_discount_div" runat="Server">
                    <asp:DataList ID="user_has_discount" runat="Server" OnItemCommand="user_has_discount_ItemCommand">
                        <HeaderTemplate>
                            <table style="width: 660px; margin: 0 auto; border: 2ps solid #DADADA">
                                <tr style="height: 2px">
                                    <td colspan="8" style="height: 2px; background: #DADADA">
                                    </td>
                                </tr>
                                <tr style="height: 25px">
                                    <th style="text-align: center; width: 180px">
                                        用户名
                                    </th>
                                    <th style="text-align: center; width: 100px">
                                        邮费类别
                                    </th>
                                    <th style="text-align: center; width: 120px">
                                        设置人
                                    </th>
                                    <th style="text-align: center; width: 180px">
                                        设置时间
                                    </th>
                                    <th style="text-align: center; width: 80px">
                                        删除
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
                                    <%#DataBinder.Eval(Container.DataItem,"type") %>
                                </td>
                                <td style="text-align: center">
                                    <%#DataBinder.Eval(Container.DataItem,"seter") %>
                                </td>
                                <td style="text-align: center">
                                    <%#DataBinder.Eval(Container.DataItem,"time") %>
                                </td>
                                <td style="text-align: center">
                                    <asp:ImageButton ID="delete" runat="Server" ImageUrl="../../image/images/del.jpg" CommandName="delete"
                                        CommandArgument='<%#DataBinder.Eval(Container.DataItem,"name") %>' />
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
                        <%if (rate_count > pageSize)
                          {
                        %>
                        每页<%=pageSize%>条&nbsp;&nbsp;&nbsp;总共<%=rate_count%>条&nbsp;&nbsp;&nbsp;当前第<%=pageNow%>页&nbsp;&nbsp;&nbsp;
                        <%if (pageNow != 1)
                          {%>
                        <a href="set-rate-postnl.aspx?pageNow=1">首页</a>&nbsp;&nbsp;&nbsp; <a
                            href="set-rate-postnl.aspx?pageNow=<%=pageNow-1 %>">上一页</a>&nbsp;&nbsp;&nbsp;
                        <%} %>
                        <% if (pageNow != rate_page_count)
                           {
                        %><a href="set-rate-postnl.aspx?pageNow=<%=pageNow+1 %>">下一页</a>&nbsp;&nbsp;&nbsp;
                        <a href="set-rate-postnl.aspx?pageNow=<%=rate_page_count %>">尾页</a>&nbsp;&nbsp;&nbsp;
                        <%} %>
                        <% } %>
                    </div>
                    <div style="height: 20px; background: #FFFFFF">
                    </div>
                </div>
                <div style="height: 140px; padding-top: 50px; font-size: 20px; font-weight: 600;
                    text-align: center; color: #FF0000" id="user_has_no_discount_div" runat="Server"
                    visible="false">
                    <p>
                        目前没有有优惠的用户!!</p>
                </div>
            </div>
            <div class="panel-footer"></div>
        </div>



    </div>
    </form>
</body>
</html>
