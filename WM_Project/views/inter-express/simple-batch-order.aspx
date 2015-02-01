<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/reception-stage/batch.Master" AutoEventWireup="true"
    CodeBehind="simple-batch-order.aspx.cs" Inherits="WM_Project.views.inter_express.simple_batch_order" %>

<%@ Import Namespace="WM_Project.logical.common" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%--此处写CSS、javascript代码--%>
    <script src="../../script/jquery-1.4.2.min.js" type="text/javascript"></script>
    <%--jquery代码--%>
    <script type="text/javascript">

        $(function ($) {

            $(".Postway").live("change", function () {
                var packageCount = $(this).parent().next().find(".packageCount");

                if ($(this).val() == "PF-IPE-Collection" || $(this).val() == "PF-IPE-Depot" || $(this).val() == "PF-IPE-Pol") {

                    packageCount.empty();
                    packageCount.append("<option>" + 1 + "</option>");
                }
                if ($(this).val() == "PF-GPR-Collection" || $(this).val() == "PF-GPR-Delivery") {

                    packageCount.empty();
                    for (var i = 1; i < 4; i++) {
                        packageCount.append("<option>" + i + "</option>");
                    }
                }
                if ($(this).val() == "EMS") {

                    packageCount.empty();
                    for (var i = 1; i < 21; i++) {
                        packageCount.append("<option>" + i + "</option>");
                    }
                }
                if ($(this).val() == "PostNL") {

                    packageCount.empty();
                    for (var i = 1; i < 21; i++) {
                        packageCount.append("<option>" + i + "</option>");
                    }
                }

            });

            //添加一行(tr)
            var temphtml = $("#first").html();
            temphtml = "<tr>" + temphtml + "</tr>";

            //添加(div)
            var divhtml = $(".address").html();
            divhtml = "<div class='address' style='border:2px solid #DADADA;margin-top:20px'>" + divhtml + "</div>";

            //添加一行的具体实现
            $(".glyphicon-plus-sign").live("click", function () {

                var temp = $(temphtml);
                var tbodylength = $(this).parent().parent().parent().children().length;

                temp.children().eq(0).text("订单" + tbodylength + "：");

                $(this).parent().parent().before(temp);

            }).hover(function () {

                $(this).addClass('change-cursor');
            }, function () {
                $(this).removeClass('change-cursor');
            });


            //删除一行的具体实现
            $(".glyphicon-minus-sign").live("click", function () {

                var tbodylength = $(this).parent().parent().parent().children().length;

                $(this).parent().children().eq(2).children().eq(0).attr("value", tbodylength - 2);

                if (tbodylength > 2) {
                    $(this).parent().parent().parent().children().eq(tbodylength - 2).remove();
                }
            }).hover(function () {

                $(this).addClass('change-cursor');
            }, function () {
                $(this).removeClass('change-cursor');
            });


            //添加新的发件地址
            $("#add-another-address").click(function () {
                var div_html = $(divhtml);

                var length = $(this).parent().parent().children().length;
                div_html.children().eq(0).children().eq(0).find(".control-label").text("地址" + (length - 1) + "：");

                $(this).parent().before(div_html);

            }).hover(function () {

                $(this).addClass('change-cursor');
            }, function () {
                $(this).removeClass('change-cursor');
            });

            //删除一个发件地址
            $("#minus-another-address").click(function () {

                var div_html = $(divhtml);

                var length = $(this).parent().parent().children().length;

                if (length > 2) {
                    $(this).parent().parent().children().eq(length - 3).remove();
                }
            }).hover(function () {

                $(this).addClass('change-cursor');
            }, function () {
                $(this).removeClass('change-cursor');
            });


        });
    </script>
    <%--javascript代码--%>
    <script type="text/javascript">

        ///登陆前的验证

        function isNull() {
            var name = document.getElementById("txt_username").value;
            var password = document.getElementById("txt_password").value;
            var code = document.getElementById("txt_code").value;

            if (name == "" || password == "" || code == "") {
                alert("带*号的不能为空！");
                return false;
            }

            return true;
        }

        //验证地址、包裹信息是否填写
        function isValidate() {

            var weights = document.getElementsByName("weight");
            var lengths = document.getElementsByName("length");
            var widths = document.getElementsByName("width");
            var heights = document.getElementsByName("height");

            for (j = 0; j < weights.length; j++) {

                if (!isUnsignedNumeric(weights[j].value) || !isUnsignedNumeric(lengths[j].value) || !isUnsignedNumeric(widths[j].value) || !isUnsignedNumeric(heights[j].value)) {
                    alert("请填写正确的重量、长、宽、高信息！")
                    return false;
                }
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="center" runat="server">
    <%--只有用户登陆才能进行批量下单--%>
    <%--如果没有登录，先登录--%>
    <div class="row" id="login_first" runat="Server" visible="false" style="width: 70%;
        margin: 0 auto">
        <div class="panel panel-primary">
            <div class="panel-heading">
                <h3 class="panel-title">
                    User Login</h3>
            </div>
            <div class="panel-body">
                <div class="form-group" style="height: 30px; margin-top: 10px">
                    <label for="username" class="col-md-3 control-label" style="padding-top: 8px;text-align:right">
                        User&nbsp;&nbsp;Name:</label>
                    <div class="col-md-7" style="padding-left: 0px">
                        <input type="text" class="form-control" id="Text1" name="txt_username" placeholder="please input user name" />
                    </div>
                    <div class="col-md-2" style="color: #FF0000; padding-top: 10px">
                        *
                    </div>
                </div>
                <div class="form-group" style="height: 30px; margin-top: 0px;">
                    <label for="password" class="col-md-3 control-label" style="padding-top: 8px;text-align:right">
                        Password:</label>
                    <div class="col-md-7" style="padding-left: 0px">
                        <input type="password" class="form-control" name="txt_password" id="txt_password" />
                    </div>
                    <div class="col-md-2" style="color: #FF0000; padding-top: 10px">
                        *
                    </div>
                </div>
                <div class="form-group" style="height: 30px">
                    <label for="code" class="col-md-3 control-label" style="padding-top: 8px;text-align:right">
                        Code:</label>
                    <div class="col-md-5" style="padding-left: 0px">
                        <input type="text" class="form-control" name="txt_code" id="txt_code" />
                    </div>
                    <div class="col-md-2 " style="text-align: right">
                        <img src="../code.aspx" alt="" height="30px" onclick="this.src=this.src+'?'" /></div>
                    <div class="col-md-2" style="color: #FF0000; padding-top: 10px">
                        *
                    </div>
                </div>
                <div class="form-group" style="height: 30px;padding-top:20px">
                    <div style="text-align: center">
                        <asp:Button ID="btn_login" runat="Server" Text="登陆" OnClientClick="return isNull();"
                            CssClass="btn btn-info" OnClick="btn_login_Click" /></div>
                </div>
            </div>
        </div>
    </div>
    <%--批量下单部分--%>
    <div class="row" id="page_one" runat="Server">
        <div class="panel panel-primary">
            <div class="panel-heading">
                <h3 class="panel-title">
                    同一个发件地址不同收件地址(每一个订单中的包裹必须是发往同一地址的)</h3>
            </div>
            <div class="panel-body">
                <table class="table table-striped " id="package">
                    <thead>
                        <tr>
                            <th style="width: 12%; text-align: center">
                                订单编号
                            </th>
                            <th style="width: 10%; text-align: center">
                                From
                            </th>
                            <th style="width: 10%; text-align: center">
                                To
                            </th>
                            <th style="width: 15%; text-align: center">
                                服务方式
                            </th>
                            <th style="width: 11%; text-align: center">
                                包裹个数
                            </th>
                            <th style="width: 12%; text-align: center">
                                重量
                            </th>
                            <th style="width: 10%; text-align: center">
                                长度
                            </th>
                            <th style="width: 10%; text-align: center">
                                宽度
                            </th>
                            <th style="width: 10%; text-align: center">
                                高度
                            </th>
                            
                        </tr>
                    </thead>
                    <tbody>
                        <tr id="first">
                            <td style="width: 10%; text-align: center; padding-top: 15px">
                                订单1:
                            </td>
                            <td style="width: 10%; text-align: center">
                                <select class="form-control" name="departure">
                                    <option>UK</option>
                                </select>
                            </td>
                            <td style="width: 10%; text-align: center">
                                <select class="form-control" name="destination" style="padding:0px">
                                    <option>China</option>
                                    <%--<option>HongKong</option>
                                    <option>TaiWan</option>
                                    <option>UK</option>--%>
                                </select>
                            </td>
                            <td style="width: 17%; text-align: center">
                                <select class="form-control Postway" name="postway" style="padding:0px">
                                    <option value="EMS">华盟EMS专线</option>
                                    <option value="PF-GPR-Collection">皇家邮政优先包(上门取件)</option>
                                    <option value="PF-GPR-Delivery">皇家邮政优先包(自行送投至邮局或Depot)</option>
                                    <option value="PF-IPE-Collection">皇家邮政经济包（上门取件）</option>
                                    <option value="PF-IPE-Depot">皇家邮政经济包（自行送投至Depot）</option>
                                    <option value="PF-IPE-Pol">皇家邮政经济包（自行送投至邮局）</option>
                                    <option value="PostNL">荷兰邮政优先包</option>
                                </select>
                            </td>
                            <td style="width: 11%; text-align: center">
                                <select class="form-control packageCount" name="count" style="padding:0px">
                                    <option>1</option>
                                    <option>2</option>
                                    <option>3</option>
                                    <option>4</option>
                                    <option>5</option>
                                    <option>6</option>
                                    <option>7</option>
                                    <option>8</option>
                                    <option>9</option>
                                    <option>10</option>
                                    <option>11</option>
                                    <option>12</option>
                                    <option>13</option>
                                    <option>14</option>
                                    <option>15</option>
                                    <option>16</option>
                                    <option>17</option>
                                    <option>18</option>
                                    <option>19</option>
                                    <option>20</option>
                                </select>
                            </td>
                            <td style="width: 12%; text-align: center">
                                <input type="text" class="form-control" name="weight" />
                            </td>
                            <td style="width: 10%; text-align: center">
                                <input type="text" class="form-control" name="length" />
                            </td>
                            <td style="width: 10%; text-align: center">
                                <input type="text" class="form-control" name="width" />
                            </td>
                            <td style="width: 10%; text-align: center">
                                <input type="text" class="form-control" name="height" />
                            </td>
                            
                        </tr>
                        <tr id="last">
                            <td colspan="9" style="text-align: center">
                                <span id="add-another-order" class="glyphicon glyphicon-plus-sign "></span>&nbsp;&nbsp;<span
                                    id="minus-another-order" class="glyphicon glyphicon-minus-sign"></span>
                            </td>
                        </tr>
                    </tbody>
                </table>
                <div>
                    <p style="text-align: right">
                        <asp:Button ID="btn_checkPrice" runat="Server" Text="快速询价" CssClass="btn btn-info"
                            OnClick="btn_checkPrice_Click" OnClientClick="return isValidate()" /></p>
                </div>
            </div>

            <div class="panel-footer" style="color:#107DE6">
                <h6>* 请注意每一个包裹的重量不要超过 <font color="red">30kg </font>，每个订单中的包裹必须是同一发件、收件地址</h6>
                <h6>* 若使用“皇家邮政经济包”( Parcelforce Economy )服务方式每一订单中包裹数不能超过 <font color="red">1</font>，若使用“皇家邮政优先包” Parcelforce priority auto 服务方式每个订单中包裹数不能超过 <font color="red">3</font>, 否则无法正常完成下单。</h6>
            </div>
        </div>
    </div>
    <div id="page_two" runat="Server" class="row" visible="false">
        <div class="panel panel-primary">
            <div class="panel-heading">
                <h3 class="panel-title">
                    邮费预览</h3>
            </div>
            <div class="panel-body">
                <div class="form-group">
                    <table class="table table-striped ">
                        <%for (int i = 0; i < orders.Count; i++)
                          {
                              BatchOrder order = (BatchOrder)orders[i];
                        %>
                        <tr>
                            <td style="width: 10%; text-align: left; padding-top: 15px; font-weight: 600; color: #3A83C2">
                                订单<%=i+1 %>：
                            </td>
                            <td style="width: 35%; text-align: left; padding-top: 15px">
                                包裹个数：<%=order.Count %>&nbsp;&nbsp;&nbsp;&nbsp;尺寸(长*宽*高):<%=order.Weight %>*<%=order.Length %>*<%=order.Width %>*<%=order.Height %>
                            </td>
                            <td style="width: 35%; text-align: center; padding-top: 15px">
                                <%=order.PostWay %>
                            </td>
                            <td style="width: 20%; text-align: right;">
                                <input type="text" name="money" readonly="readonly" value='&pound;<%=postages[i] %>' class="form-control"
                                    style="border-style: solid; text-align: center; font-weight: 600" />
                            </td>
                        </tr>
                        <%
                          } %>
                        <%if (postages.Length > 0)
                          {
                              float total = 0;

                              for (int i = 0; i < postages.Length; i++)
                              {
                                  total += postages[i];
                              }
                        %>
                        <tr>
                            <td colspan="4">
                                <span class="col-md-3" style="font-weight: 600; color: #3A83C2; text-align: right;
                                    padding-top: 6px; padding-right: 2px">总金额：</span> <span class="col-md-2" style="padding-left: 0px;">
                                        <input type="text" name="total" readonly="readonly" value='&pound;<%=total %>' class="form-control" /></span>
                                <span class="col-md-5 col-md-offset-2" style="text-align: right">
                                    <asp:Button ID="btn_BuyNow" runat="Server" Text="购买" Style="width: 100px" CssClass="btn btn-info"
                                        OnClick="btn_BuyNow_Click" /></span>
                            </td>
                        </tr>
                        <%} %>
                    </table>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
