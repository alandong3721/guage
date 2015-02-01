<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/back-stage/home.Master" AutoEventWireup="true"
    CodeBehind="user-debt-record-info.aspx.cs" Inherits="WM_Project.manage_system.user_debt_record_info" %>

<%@ Import Namespace="WM_Project.logical.user" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="center" runat="server">
    <div class="panel panel-primary" style="width:80%;margin:0 auto;margin-bottom:30px">
        <div class="panel-heading">
            <h5 class="panel-title">
                用户&nbsp;&nbsp;<%=username %>&nbsp;&nbsp;欠款详情</h5>
        </div>
        <div class="panel-body">
            <div class="form-group">
                <% if (userdebt_array.Count > 0)
                   {%>
                <table class="table table-striped " id="package" style="width: 100%">
                    <thead>
                        <tr>
                            <th style="text-align: center">
                                用户名
                            </th>
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
                        <% for (int i = 0; i < userdebt_array.Count; i++)
                           {
                               UserDebtTrans userdebttrans = (UserDebtTrans)userdebt_array[i];
                        %>
                        <tr>
                            <td style="text-align: center">
                                <%=userdebttrans.User_name%>
                            </td>
                            <td style="text-align: center">
                                £<%=userdebttrans.Amount%>
                            </td>
                            <td style="text-align: center">
                                <%=userdebttrans.Operation%>
                            </td>
                            <td style="text-align: center">
                                <%=userdebttrans.Operation_time.ToString("yyyy-MM-dd HH:mm:ss")%>
                            </td>
                        </tr>
                        <%
                           }%>
                    </tbody>
                </table>
                <%} %>
            </div>
        </div>
    </div>
</asp:Content>
