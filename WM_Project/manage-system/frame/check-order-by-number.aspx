<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="check-order-by-number.aspx.cs"
    Inherits="WM_Project.manage_system.frame.check_order_by_number" %>

<%@ Import Namespace="WM_Project.logical.common" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../../stylesheets/bootstrap.css" rel="stylesheet" type="text/css" />
    <link href="../../stylesheets/bootstrap-theme.css" rel="stylesheet" type="text/css" />
    <script src="../../javascripts/bootstrap.js" type="text/javascript"></script>
    <script src="../../javascripts/jquery-1.11.1.js" type="text/javascript"></script>
 
    <script type="text/javascript">
        $(function () {
            $(".query-order").click(function () {
                var number = $(this).parent().parent().find(".number");
                if ($.trim(number.val()) == "") {
                    alert("订单号不能为空！！");
                    return false;
                }
            });

        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="panel panel-primary" style="width: 800px; font-size: 13px">
        <div class="panel-heading">
            <h5 class="panel-title">
                按订单号查找订单信息</h5>
        </div>
        <div class="panel-body">
            <div id="page_check_order" runat="Server" style="clear: both; margin: 0 auto; width: 100%;
                border: 2px solid #DADADA">
                <div class="form-group" style="margin-top: 10px; padding-left: 20px; padding-right: 20px;
                    height: 40px" id="query_by_number">
                    <div style="width: 100px; padding-right: 10px; text-align: right; float: left">
                        <label class="control-label" style="padding-top: 6px">
                            Number:</label></div>
                    <div style="padding-left: 0px; padding-right: 0px; width: 400px; float: left;">
                        <asp:TextBox ID="txt_number" runat="Server" CssClass="form-control number"></asp:TextBox></div>
                    <div style="text-align: right; width: 220px; float: left;">
                        <asp:Button ID="btn_query_order" runat="Server" CssClass="btn btn-info query-order" Text="查询订单"
                            OnClick="btn_query_order_Click" />
                    </div>
                </div>
                <div style="height: 2px; background: #DADADA">
                </div>
                <div class="form-group">
                    <%if (packages != null && packages.Count > 0)
                      { %>
                    <table class="table table-striped " id="package" width="100%">
                        <thead>
                            <tr>
                                <th style="width: 20%; text-align: center">
                                    追踪号
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
                                <%=package.Ea_track_no%>
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
                                <%=package.Pay_after_discount%>
                            </td>
                            <td style="width: 8%; text-align: center" valign="middle">
                                <a target="_blank" href="../check-order-detail-info.aspx?type=detail&order_number=<%=package.Order_no %>">
                                    详情</a>
                            </td>
                            <td style="width: 8%; text-align: center" valign="middle">
                                <a target="_blank" href="../check-order-detail-info.aspx?type=download&order_number=<%=package.Order_no %>">
                                    下载</a>
                            </td>
                        </tr>
                        <%} %>
                        
                    </table>
                    <%}
                    %>
                </div>
            </div>
        </div>
        <div class=" panel-footer">
            <p style="color: #FF0000; font-weight: 600; font-size: 16px;">
                * 输入的订单号是追踪号、EMS、PF、PostNL 的追踪号</p>
        </div>
    </div>
    </form>
</body>
</html>
