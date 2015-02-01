<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/reception-stage/batch.Master" AutoEventWireup="true"
    CodeBehind="batch-order.aspx.cs" Inherits="WM_Project.views.inter_express.batch_order" %>

<%@ Import Namespace="System.Collections" %>
<%@ Import Namespace="WM_Project.logical.common" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%--此处写CSS、javascript代码--%>
    <style type="text/css">
        table input{text-align:center;}
    </style>


    <script src="../../script/jquery-1.4.2.min.js" type="text/javascript"></script>
    <%--jquery代码--%>
    <script type="text/javascript">
        $(function ($) {

            $(".postway").live("change", function () {
                var packageCount = $(this).parent().parent().parent().next().find(".packageCount");

                if ($(this).val() == "PF-IPE-Collection" || $(this).val() == "PF-IPE-Depot" || $(this).val() == "PF-GPR-Pol") {
                    
                    packageCount.empty();
                    packageCount.append("<option>" + 1 + "</option>");
                }
                if ($(this).val() == "PF-GPR-Collection" || $(this).val() == "PF-GPR-Delivery" ) {

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
            var temphtml = $(".first").html();
            temphtml = "<tr class='first'>" + temphtml + "</tr>";

            //添加(div)
            var divhtml = $(".address").html();
            divhtml = "<div class='address' style='border:2px solid #DADADA;margin-top:20px'>" + divhtml + "</div>";

            //添加一行的具体实现
            $(".glyphicon-plus-sign").live("click", function () {

                var temp = $(temphtml);
                var tbodylength = $(this).parent().parent().parent().children().length;

                temp.children().eq(0).find(".label-control").text("尺寸" + tbodylength + "：");

                $(this).parent().children().eq(2).children().eq(0).attr("value", tbodylength);

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
                div_html.children().eq(1).children().eq(0).find(".control-label").text("地址" + (length - 1) + "：");

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

            var froms = document.getElementsByName("departure");
            var tos = document.getElementsByName("destination");
            var postways = document.getElementsByName("postway");
            var counts = document.getElementsByName("count");
            var weights = document.getElementsByName("weight");
            var lengths = document.getElementsByName("length");
            var widths = document.getElementsByName("width");
            var heights = document.getElementsByName("height");
            var hiddens = document.getElementsByName("hidden");


            for (j = 0; j < weights.length; j++) {

                if (!isUnsignedNumeric(weights[j].value) || !isUnsignedNumeric(lengths[j].value) || !isUnsignedNumeric(widths[j].value) || !isUnsignedNumeric(heights[j].value)) {
                    alert("请填写正确的重量、长、宽、高信息！")
                    return false;
                }
            }

            index = 0;

            for (k = 0; k < froms.length; k++) {

                packagecount = 0;

                if (postways[k].value == "PF-IPE-Collection" || postways[k].value == "PF-IPE-Depot" || postways[k].value == "PF-IPE-Pol") {

                    if (hiddens[k].value > 1) {
                        alert("同个地址中使用 “皇家邮政经济包” 服务的包裹数不能大于 1 ！！");
                        return false;
                    }
                    else {
                        index += 1;
                    }

                }
                else if (postways[k].value == "PF-GPR-Collection" || postways[k].value == "PF-IPE-Delivery") {
                    for (t = 0; t < parseInt(hiddens[k].value); t++) {
                        packagecount += parseInt(counts[index].value);
                        index++
                    }

                    if (packagecount > 3) {
                        alert("同个地址中使用 “皇家邮政优先包” 服务的包裹数不能大于 3 ！！");
                        return false;
                    }
                } else {
                    index += parseInt(hiddens[k].value);
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
                <div class="form-group" style="height: 30px">
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
                <div class="form-group" style="height: 30px; padding-top: 20px">
                    <div style="text-align: center">
                        <asp:Button ID="btn_login" runat="Server" Text="登陆" OnClientClick="return isNull();"
                            CssClass="btn btn-info" OnClick="btn_login_Click" /></div>
                </div>
            </div>
        </div>
    </div>
    <%--批量下单部分--%>
    <div class="row" id="page_one" runat="Server" visible="false">
        <div class="panel panel-primary">
            <div class="panel-heading">
                <h3 class="panel-title">
                    多个发件地址多个收件地址</h3>
            </div>
            <div class="panel-body">
                <div style="border: 2px solid #DADADA;" class="address">
                    <div class="panel-footer" style="height: 60px; padding-top: 0; margin-top: 0px; color: #EE0000">
                        <h6>
                            * 请注意当使用 "皇家邮政经济包" 服务方式时包裹个数不能超过 1，当使用 "皇家邮政优先包" 服务方式时包裹数不能超过
                            3</h6>
                        <h6>
                            * 该方框内的快件的发件地址为同一发件地址、收件地址也为同一地址</h6>
                    </div>
                    <div class="panel-form" style="margin-top: 10px; height: 30px">
                        <div class="col-md-1" style="padding-right: 0px; padding-top: 12px; color: Red">
                            <label class="control-label">
                                地址1：</label></div>
                        <div class="col-md-3 " style="padding-left: 0px">
                            <div class="col-md-4" style="padding-right: 0px; padding-top: 6px">
                                <label class=" control-label">
                                    发件地：</label>
                            </div>
                            <div class="col-md-7" style="padding-left: 0px; padding-top: 0px">
                                <select name="departure" class="form-control">
                                    <option>UK</option>
                                </select>
                            </div>
                        </div>
                        <div class="col-md-3" style="padding-left: 0px">
                            <div class="col-md-5" style="padding-right: 0px; padding-top: 6px; text-align: right">
                                <label class="control-label">
                                    收件地：</label>
                            </div>
                            <div class="col-md-7" style="padding-left: 0px; padding-top: 0px">
                                <select name="destination" class="form-control">
                                    <option>China</option>
                                </select></div>
                        </div>
                        <div class="col-md-5" style="padding-left: 0px">
                            <div class="col-md-4" style="padding-right: 0px; padding-top: 6px; text-align: right">
                                <label class="control-label">
                                    邮寄方式：</label>
                            </div>
                            <div class="col-md-8" style="padding-left: 0px; padding-top: 0px;padding-right:0px">
                                <select name="postway" class="form-control postway" style="padding-left:2px;padding-right:0px">
                                    <option value="EMS">华盟EMS专线</option>
                                    <option value="PF-GPR-Collection">皇家邮政优先包(上门取件)</option>
                                    <option value="PF-GPR-Delivery">皇家邮政优先包(自行送投至邮局或Depot)</option>
                                    <option value="PF-IPE-Collection">皇家邮政经济包（上门取件）</option>
                                    <option value="PF-IPE-Depot">皇家邮政经济包（自行送投至Depot）</option>
                                    <option value="PF-IPE-Pol">皇家邮政经济包（自行送投至邮局）</option>
                                    <option value="PostNL">荷兰邮政优先包</option>
                                </select></div>
                        </div>
                    </div>
                    <div class="panel-form" style="clear: both; margin-top: 10px; padding-top: 10px">
                        <table class="table table-striped " id="package">
                            <tbody>
                                <tr class="first">
                                    <td style="width: 8%; text-align: left;">
                                        <label class="label-control" style="padding-top:6px;">
                                            尺寸1：</label>
                                    </td>
                                    <td style="width: 10%; text-align: right;">
                                        <label class="label-control" style="padding-top:6px;">
                                            包裹个数：</label>
                                    </td>
                                    <td style="width: 10%; padding-left: 0px">
                                        <select style="width: 100%;text-align:center" class="form-control packageCount" name="count" id="count">
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
                                    <td style="width: 10%; text-align: right;">
                                        <label class="label-control" style="padding-top:6px;">
                                            重量(KG):</label>
                                    </td>
                                    <td style="width: 8%">
                                        <input type="text" style="width: 100%" name="weight" id="weight" class="form-control" />
                                    </td>
                                    <td style="width: 10%; text-align: right;">
                                        <label class="label-control" style="padding-top:6px;">
                                            长度(cm):</label>
                                    </td>
                                    <td style="width: 8%">
                                        <input type="text" style="width: 100%" name="length" id="length" class="form-control" />
                                    </td>
                                    <td style="width: 10%; text-align: right;">
                                        <label class="label-control" style="padding-top:6px;">
                                            宽度(cm):</label>
                                    </td>
                                    <td style="width: 8%">
                                        <input type="text" style="width: 100%" name="width" id="width" class="form-control"/>
                                    </td>
                                    <td style="width: 10%; text-align: right;">
                                        <label class="label-control" style="padding-top:6px;">
                                            高度(cm):</label>
                                    </td>
                                    <td style="width: 8%">
                                        <input type="text" style="width: 100%" name="height" id="height" class="form-control"/>
                                    </td>
                                </tr>
                                <tr class="last">
                                    <td colspan="11" style="text-align: center">
                                        <span class="glyphicon glyphicon-plus-sign"></span>&nbsp;&nbsp;&nbsp;&nbsp; <span
                                            class="glyphicon glyphicon-minus-sign"></span><span>
                                                <input type="hidden" name="hidden" value="1" /></span>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                </div>
                <div class="panel-form" style="height: 20px; margin-top: 10px; text-align: center;"
                    id="add-address">
                    <span class="glyphicon glyphicon-plus" id="add-another-address"></span>&nbsp;&nbsp;&nbsp;&nbsp;
                    <span class="glyphicon glyphicon-minus" id="minus-another-address"></span><span style="color: red">
                        &nbsp;&nbsp;&nbsp;&nbsp;(这两个按钮用来来添加发件、收件地址)</span>
                </div>
                <div class="panel-form" style="margin-top: 20px; text-align: right">
                    <asp:Button ID="btn_price_query" runat="Server" Text="快速询价" class="btn btn-info"
                        Style="width: 15%;" OnClick="btn_price_query_Click" OnClientClick="return isValidate()" />
                </div>
            </div>
            <div class="panel-footer">
                <h6 style="color: red">
                    上述包裹运往同一个地址，并且每箱包裹不能超过30公斤，点击加号添加更多包裹</h6>
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
                        <%for (int i = 0; i < packageTOSameAddress.Count; i++)
                          {
                              PackagesToSameAddress package_to_same_addr = (PackagesToSameAddress)packageTOSameAddress[i];
                        %>
                        <tr>
                            <td style="width: 10%; text-align: left; padding-top: 15px; font-weight: 600; color: #3A83C2">
                                地址<%=i+1 %>：
                            </td>
                            <td style="width:20px;text-align:right;padding-right:10px;padding-top:15px">服务方式:</td>
                            <td style="width: 50%; text-align: left; padding-top: 15px;padding-left:10px">
                                <%=package_to_same_addr.Postway %>
                            </td>
                            <td style="width: 20%; text-align: right;">
                                <input type="text" name="money" readonly="readonly" value='£<%=postages[i] %>' class="form-control"
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
                            <td colspan="5">
                                <span class="col-md-3" style="font-weight: 600; color: #3A83C2; text-align: right;
                                    padding-top: 6px; padding-right: 2px">总金额：</span> <span class="col-md-2" style="padding-left: 0px;">
                                        <input type="text" name="total" readonly="readonly" value='£<%=total %>' class="form-control" /></span>
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
