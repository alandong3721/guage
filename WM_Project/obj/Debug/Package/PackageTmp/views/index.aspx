<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/reception-stage/home.Master"
    AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="WM_Project.views.index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../script/jquery-1.11.1.js" type="text/javascript"></script>
    <script src="../script/jquery-1.4.2.min.js" type="text/javascript"></script>
    <%--CSS代码--%>
    <style type="text/css" rel="stylesheet">
        .panel-body td, th
        {
            width: 20%;
            text-align: center;
        }
        table
        {
            margin: 0px;
        }
    </style>
    <%--jquery代码--%>
    <script type="text/javascript">

        $(function () {
            $("#add-another-package").click(function () {
                var temp = '<tr>' +
						    '<td>' +
							    '<select class="form-control" name="count" id="count">' +
								    '<option>1</option>' +
								    '<option>2</option>' +
								    '<option>3</option>' +
                                    '<option>4</option>' +
								    '<option>5</option>' +
								    '<option>6</option>' +
                                    '<option>7</option>' +
								    '<option>8</option>' +
								    '<option>9</option>' +
                                    '<option>10</option>' +
								    '<option>11</option>' +
								    '<option>12</option>' +
                                    '<option>13</option>' +
								    '<option>14</option>' +
								    '<option>15</option>' +
                                    '<option>16</option>' +
                                    '<option>17</option>' +
								    '<option>18</option>' +
								    '<option>19</option>' +
                                    '<option>20</option>' +
							    '</select>' +
						    '</td>' +
						    '<td>' +
						    '<input type="text" class="form-control" name="weight" id="weight"/>' +
						    '</td>' +
						    '<td>' +
						    '<input type="text" class="form-control" name="length" id="length"/>' +
						    '</td>' +
						    '<td>' +
						    '<input type="text" class="form-control" name="width" id="width"/>' +
						    '</td>' +
						    '<td>' +
						    '<input type="text" class="form-control" name="height" id="height"/>' +
						    '</td>' +
					    '</tr>';
                $("#package tbody").append(temp);
            }).hover(function () {
                $(this).addClass('change-cursor');
            }, function () {
                $(this).removeClass('change-cursor');
            });
            $("#minus-another-package").click(function () {
                var $temp = $("#package tbody tr");
                if ($temp.length > 1) {
                    $temp.eq($temp.length - 1).remove();
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

        /*
        *	验证输入是否合理
        */
        function isValidate() {

            var weights = document.getElementsByName("weight");
            var lengths = document.getElementsByName("length");
            var widths = document.getElementsByName("width");
            var heights = document.getElementsByName("height");


            for (i = 0; i < weights.length; i++) {
                if (isUnsignedNumeric(weights[i].value) && isUnsignedNumeric(lengths[i].value) && isUnsignedNumeric(widths[i].value) && isUnsignedNumeric(heights[i].value)) {
                }
                else {
                    alert("please write right weight、length、with、height!");
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
<asp:Content ID="Content2" ContentPlaceHolderID="center_right" runat="server">
    <div id="first" runat="Server">
        <div class="row">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    <h5 class="panel-title">华盟公告</h5>
                </div>
                <div class="panel-body" style="height:200px;">
                
                </div>
            </div>
        </div>
        <div class="row">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    <h3 class="panel-title">
                        快速估算运费</h3>
                </div>
                <div class="row" style="margin-left: 10px; margin-top: 20px">
                    <div class="col-md-5 ">
                        <div class="row">
                            <div class="col-md-5" style="padding-right: 0px; padding-top: 6px;">
                                <label class="control-label">
                                    发件地：</label>
                            </div>
                            <div class="col-md-7" style="padding-left: 0px;">
                                <select name="from" class="form-control" id="select_from">
                                    <option>UK</option>
                                </select>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-5 col-md-offset-1">
                        <div class="row">
                            <div class="col-md-5" style="padding-right: 0px; padding-top: 6px;">
                                <label class="control-label">
                                    收件地：</label>
                            </div>
                            <div class="col-md-7" style="padding-left: 0px;">
                                <select name="to" class="form-control" id="select_to">
                                    <option>China</option>
                                    <option>HongKong</option>
                                    <option>TaiWan</option>
                                    <option>UK</option>
                                </select></div>
                        </div>
                    </div>
                </div>
                <div class="panel-body">
                    <table class="table table-striped " id="package">
                        <thead>
                            <tr>
                                <th style="text-align: center">
                                    Quantity
                                </th>
                                <th style="text-align: center">
                                    Weight(kg)
                                </th>
                                <th style="text-align: center">
                                    Length(cm)
                                </th>
                                <th style="text-align: center">
                                    Width(cm)
                                </th>
                                <th style="text-align: center">
                                    Height(cm)
                                </th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td>
                                    <select class="form-control" name="count">
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
                                <td>
                                    <input type="text" class="form-control" name="weight" />
                                </td>
                                <td>
                                    <input type="text" class="form-control" name="length" />
                                </td>
                                <td>
                                    <input type="text" class="form-control" name="width" />
                                </td>
                                <td>
                                    <input type="text" class="form-control" name="height" />
                                </td>
                            </tr>
                        </tbody>
                    </table>
                    <div style="text-align: center; width: 100%; padding: 0px; margin: 0px">
                        <span id="add-another-package" class="glyphicon glyphicon-plus-sign "></span>&nbsp;&nbsp;<span
                            id="minus-another-package" class="glyphicon glyphicon-minus-sign"></span>
                    </div>
                    <div id="qucik_check_price" style="text-align: right; width: 100%; padding-right: 8px" runat="Server">
                        <asp:Button ID="btn_price_query" Text="快速询价" runat="server" OnClientClick="return isValidate()"
                            CssClass="btn btn-info" Style="width: 15%;" OnClick="btn_price_query_Click" />
                    </div>
                </div>
                <div class="panel-footer">
                    <h6 style="color: red">
                        Parcelforce economy最多只能下一个包裹，Parcelforce priority auto最多可以下单三个包裹，EMS不限</h6>
                    <h6 style="color: red">
                        上述包裹运往同一个地址，并且每箱包裹不能超过30公斤，点击加号添加更多包裹 Quantity为包裹数</h6>
                </div>
            </div>
        </div>

        <div class="row">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    <p class="panel-title" style="font-weight: 800; font-size: 20px">
                        关于我们</p>
                </div>
                <div class="panel-body">
                    <div>
                        <p style="font-weight: 800; font-size: 20px">
                            公司简介</p>
                        <p style="text-indent: 2em; line-height: 30px">
                            华盟快递成立于2005年，是以物流方案咨询、空运进出口、国际快递、订单和财务管理、仓储转运为主营业务的互联网技术以及实体物流公司。华盟快递主要从事英国始发到其他国家的快递包裹和大宗空运服务，是英国唯一一家技术领先的全自动下单的华人物流公司。</p>
                        <p style="text-indent: 2em; line-height: 30px">
                            华盟快递可以满足英国华人邮寄个人物品、行李、婴儿用品等物品的快递运输，以及国内客户的海淘转运需求。总部设在英国商业中心Milton Keynes， 在全英多个城市配有大面积仓贮仓库和先进的内部网络管理系统，并且与ParcelForce,
                            DHL, TNT, UPS, EMS等国际物流巨头有着7年的合作经验。</p>
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    <p class="panel-title" style="font-weight: 800; font-size: 20px">
                        我们的合作伙伴</p>
                </div>
                <div class="panel-body">
                    <div style="height: 60px; margin-bottom: 20px">
                        <div class="col-md-2" style="margin-left:-10px">
                            <img src="../image/image/parcelforce-small.png" alt="parcelforce" style="width:100px;height:50px" /></div>
                        <div class="col-md-2" style="margin-left:20px">
                            <img src="../image/image/logo-postnl.png" alt="postnl" class="panel panel-info"  style="width:100px;height:50px;border:1px solid #3C85C4" /></div>
                        <div class="col-md-2" style="margin-left:20px">
                            <img src="../image/image/logo-ems.png" alt="parcelforce" style="width:100px;height:50px" /></div>
                        <div class="col-md-2" style="margin-left:20px">
                            <img src="../image/image/logo-collectplus.png" alt="parcelforce" style="width:100px;height:50px" /></div>
                        <div class="col-md-2" style="margin-left:20px">
                            <img src="../image/image/logo-ukmail.png" alt="parcelforce" class="panel panel-info" style="width:100px;height:50px;border:1px solid #3C85C4" /></div>
                    </div>
                    <div class="form-panel" style="margin-top: 20px">
                        <p style="text-align: center">
                            <a href="http://www.kuaidi100.com/">快递查询</a></p>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div id="second" runat="Server">
        <div class="row">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    <h3 class="panel-title">
                        可供您选择的邮寄方式</h3>
                </div>
                <div class="panel-body">
                    <asp:DataList ID="postwaydata" runat="Server" OnItemCommand="postwaydata_ItemCommand">
                        <%--头模板--%>
                        <HeaderTemplate>
                            <table style="width: 100%; padding-left: 0; padding-right: 0;">
                        </HeaderTemplate>
                        <%--项模板--%>
                        <ItemTemplate>
                            <tr style="height: 70px;">
                                <td valign="middle" align="left" style="width: 20%; padding-left: 0; padding-right: 0">
                                    <asp:Image runat="Server" ID="image" Width="100px" Height="45px" ImageUrl='<%#DataBinder.Eval(Container.DataItem,"imagePath") %>' />
                                </td>
                                <td valign="middle" style="width: 55%; padding-right: 0; text-align: left">
                                    <%#DataBinder.Eval(Container.DataItem,"note") %><asp:HiddenField ID="hidden" runat="Server"
                                        Value='<%#DataBinder.Eval(Container.DataItem,"postname") %>' />
                                </td>
                                <td align="right" valign="middle" style="width: 15%; text-align: center; padding-right: 0">
                                    <asp:Label runat="Server" ID="lb_money" Text='<%#DataBinder.Eval(Container.DataItem,"money") %>'></asp:Label>
                                </td>
                                <td align="right" valign="middle" style="width: 10%; padding-right: 0; text-align: right">
                                    <asp:LinkButton runat="Server" ID="buy" Font-Underline="false" CommandName="buy"
                                        CommandArgument='<%#DataBinder.Eval(Container.DataItem,"postname") %>'>购买</asp:LinkButton>
                                </td>
                            </tr>
                        </ItemTemplate>
                        <%--分割模板--%><SeparatorTemplate>
                        </SeparatorTemplate>
                        <%--脚模板--%>
                        <FooterTemplate>
                            </table></FooterTemplate>
                    </asp:DataList>
                </div>
                <div class="panel-body">
                    <div style="height: 2px; background: #DADADA; margin-bottom: 20px">
                    </div>
                    <p style="font-weight: 600">
                        温馨提示
                    </p>
                    <p style="line-height: 25px;color:#FF0000">
                        1、荷兰邮政优先包、华盟EMS专线，这两种服务后续需要购买英国境内物流服务，将包裹发送到我们手上（华盟仓库）</p>
                    <p style="line-height: 25px">
                        2、Parcelforce Priority 服务每单最多只能包括三个包裹；Parcelforce Economy服务每单只能包括一个包裹</p>
                    <p style="line-height: 25px">
                        3、Parcelforce Priority自带上限100镑保险，其他服务丢失保险金额上限50镑。</p>
                    <p style="line-height: 25px">
                        4、全部服务24/7即时出单，华盟快递网站上实时追踪您的包裹</p>
                    <p style="line-height: 25px">
                        5、为了您的包裹准时到达，请准确的计算您的包裹重量和尺寸</p>
                    <p style="line-height: 25px">
                        6、如果您选择Post NL Priority 或者China Post EMS 服务，我们为您提供多种英国境内物流方式帮助您将包裹发送到我们手上。</p>
                    <p style="line-height: 25px">
                        7、华盟快递提供市场最低价格，欢迎批量下单客户联系我们洽谈合作价格</p>
                    <p style="line-height: 25px">
                        8、批量导入，批量出单，批量打印功能方便大客户一键打印所有文档。</p>
                </div>
                <div class="panel-footer">
                    <p style="color:#3C85C4">
                        *&nbsp;国际快递服务方式选择</p>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
