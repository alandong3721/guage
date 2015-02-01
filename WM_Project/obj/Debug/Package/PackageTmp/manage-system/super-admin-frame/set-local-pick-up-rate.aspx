<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="set-local-pick-up-rate.aspx.cs"
    Inherits="WM_Project.manage_system.super_admin_frame.set_local_pick_up_rate" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../stylesheets/bootstrap.css" rel="stylesheet" type="text/css" />
    <link href="../../stylesheets/bootstrap-theme.css" rel="stylesheet" type="text/css" />
    <script src="../../javascripts/bootstrap.js" type="text/javascript"></script>
    <script src="../../javascripts/jquery-1.11.1.js" type="text/javascript"></script>
    <script type="text/javascript">

        function isLocalRateValidate() {
            var weight = document.getElementsByName("weight");
            var price = document.getElementsByName("money");
            var per_price = document.getElementsByName("more_money");

            if (weight[0].value.trim() == "") {
                alert("重量不能为空！！");
                return false;
            } else if (!isUnsignedNumeric(weight[0].value)) {
                alert("重量必须为数字！！");
                return false;
            }
            else if (price[0].value.trim() == "") {
                alert("价格不能为空！！");
                return false;
            } else if (!isUnsignedNumeric(price[0].value)) {
                alert("价格必须为数字!!");
                return false;
            }
            else if (per_price[0].value.trim() == "") {
                alert("超出部分价格不能为空！！");
                return false;
            } else if (!isUnsignedNumeric(per_price[0].value == "")) {
                alert("超出部分价格必须为数字！！");
                return false;
            }

            return true;

        }

        /*
        *	验证是否是正实数,不包括 0 
        */
        function isUnsignedNumeric(strNumber) {
            if (strNumber.trim() != 0) {
                var newPar = /^\d+(\.\d+)?$/;
                return newPar.test(strNumber.trim());
            }
            else {
                return false;
            }

        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class=" panel panel-primary" style="width: 700px;">
        <div class="panel-heading">
            <h5 class="title">
                设置本地取件的计费方式</h5>
        </div>
        <div class="panel-body">
            <div class="form-group" style="height: 40px; clear: both">
                <div style="width: 200px; margin-left: 40px; float: left; text-align: center">
                    <label class=" control-label" style="padding-top: 5px;">
                        重量(kg):</label>
                </div>
                <div style="width: 360px; float: left">
                    <input class="form-control" name="weight" type="text" />
                </div>
            </div>
            <div class="form-group" style="height: 40px; clear: both; text-align: center">
                <div style="width: 200px; margin-left: 40px; float: left">
                    <label class=" control-label" style="padding-top: 5px;">
                        价格(£):</label>
                </div>
                <div style="width: 360px; float: left">
                    <input class="form-control" name="money" type="text" />
                </div>
            </div>
            <div class="form-group" style="height: 40px; clear: both">
                <div style="width: 200px; margin-left: 40px; float: left; text-align: center">
                    <label class=" control-label" style="padding-top: 5px;">
                        超出上述重量后每kg价格(£):</label>
                </div>
                <div style="width: 360px; float: left">
                    <input class="form-control" name="more_money" type="text" />
                </div>
            </div>
            <div class="form-group" style="height: 40px; text-align: center">
                <asp:Button ID="btn_set_local_rate" runat="Server" Text="设置" OnClientClick="return isLocalRateValidate()"
                    CssClass="btn btn-info" Width="120px" OnClick="btn_set_local_rate_Click" />
            </div>
        </div>
        <div style="height: 40px; margin-top: 20px; background: #DADADA; padding-top: 12px">
            <p>
                本地取件费用一览表</p>
        </div>
        <div class="form-group" id="has_local_rate" runat="Server">
            <div style="width: 700px; margin: 0 auto; clear: both" id="has_staff" runat="Server">
                <asp:DataList ID="local_rate" runat="Server" OnItemCommand="local_rate_ItemCommand">
                    <HeaderTemplate>
                        <table style="width: 700px; margin: 0 auto;">
                            <tr style="height: 30px">
                                <td colspan="8" style="text-align: center; font-size: 20px; font-weight: 600; color: #3A83C2">
                                    现有本地取件邮费信息
                                </td>
                            </tr>
                            <tr style="height: 2px">
                                <td colspan="8" style="height: 2px; background: #DADADA">
                                </td>
                            </tr>
                            <tr style="height: 30px">
                                <th style="text-align: center; width: 180px">
                                    基准重量(KG)
                                </th>
                                <th style="text-align: center; width: 220px">
                                    基准重量对应的邮费(£)
                                </th>
                                <th style="text-align: center; width: 220px">
                                    超出基准每kg的价格(£)
                                </th>
                                <th style="text-align: center; width: 80px">
                                    删除
                                </th>
                            </tr>
                            <tr style="height: 2px">
                                <td colspan="4" style="height: 2px; background: #DADADA">
                                </td>
                            </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td style="text-align: center">
                                <%#DataBinder.Eval(Container.DataItem,"base_weight") %>
                            </td>
                            <td style="text-align: center">
                                <%#DataBinder.Eval(Container.DataItem,"base_money") %>
                            </td>
                            <td style="text-align: center">
                                <%#DataBinder.Eval(Container.DataItem,"per_money") %>
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
                            <td colspan="4" style="height: 2px; background: #DADADA">
                            </td>
                        </tr>
                        </table></FooterTemplate>
                </asp:DataList>
            </div>
            <div class="panel-footer">
            </div>
        </div>
        <div class="form-group" id="has_not_local_rate" runat="Server">
            <div style="height:160px;padding-top:65px;color:#FF0000; font-weight:600; font-size:20px;text-align:center">
                <p>您还没有设置本地取件邮费请设置！！</p>
            </div>

        </div>
    </div>
    </form>
</body>
</html>
