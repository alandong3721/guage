<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/reception-stage/home.Master"
    AutoEventWireup="true" CodeBehind="postnl.aspx.cs" Inherits="WM_Project.views.inter_express.postnl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../../script/jquery-1.11.1.js" type="text/javascript"></script>
    <script src="../../script/jquery-1.4.2.min.js" type="text/javascript"></script>
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

        ///登陆前的验证

        function isNull() {
            var name = document.getElementById("txt_username").value;
            var password = document.getElementById("txt_password").value;

            if (name == "" || password == "") {
                alert("带*号的不能为空！");
                return false;
            }
            return true;
        }


    </script>  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="center_right" runat="server">
    <div class="row" id="login" runat="Server" visible="false" style="width: 80%;margin:0 auto;">
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
                        <input type="text" class="form-control" id="txt_username" name="txt_username" placeholder="please input user name" />
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
                <div class="form-group" style="height: 30px">
                    <div style="text-align: center">
                        <asp:Button ID="btn_login" runat="Server" Text="登陆" OnClientClick="return isNull();"
                            CssClass="btn btn-info" OnClick="btn_login_Click" /></div>
                </div>
            </div>
        </div>
    </div>
    
    <div id="page_one" runat="Server">
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
                                包裹个数
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
                <div id="Div1" style="text-align: right; width: 100%; padding-right: 8px" runat="Server">
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
        <div class="panel panel-primary">
            <div class="panel-heading">
                <h3 class="panel-title">
                    比利时邮政</h3>
            </div>
            <div class="panel-body">
                <div class="form-group">
                    <p style="font-weight: 800">
                        【简介】</p>
                    <p style="text-indent: 2em; line-height: 25px">
                        Bpost也被称为比利时邮政集团，Bpost是比利时最大的民用快递公司。它提供邮政，快递，银行，保险和电子服务。</p>
                    <p style="text-indent: 2em; line-height: 25px">
                        Bpost总部设在布鲁塞尔。使用Bpost邮政速递更快更安全，且价格优惠不少。可以享受包裹优先上飞机及优先清关等服务。目前，使用比利时Bpost快递的公司主要有欧洲国家，如德国，比利时，荷兰，英国，法国等。</p>
                    <p style="font-weight: 800; margin-top: 20px">
                        英国华盟快递是比利时邮政在英国的最大代理商之一，包裹从英国发出后7-10工作日内可完成配送。</p>
                    <p>
                        比利时邮政中文官网：<a href="http://www.bpostinternational.com/cn/int ">http://www.bpostinternational.com/cn/int
                        </a>
                    </p>
                    <p>
                        比利时邮政英文官网：<a href="http://www.bpost.be/en/ ">http://www.bpost.be/en/ </a>
                    </p>
                    <p style="margin-top: 20px; text-indent: 2em">
                        比利时邮政Bpost服务是英国到中国快递最快捷经济的选择，门到门空运直邮，邮政绿色通道，时效7-10工作日，中国国内对接EMS快递，全程在线追踪。</p>
                    <p style="margin-top: 30px; font-weight: 800">
                        【服务特点】</p>
                    <p>
                        1. 免费上门取件（8AM-6PM之间），或者自送华盟物流仓库。</p>
                    <p>
                        2. 绿色邮政清关，抽查关税，客户自理。</p>
                    <p>
                        3. 包裹首重0.5kg，单个包裹收费重量最大为30kg</p>
                    <p>
                        4. 华盟快递支持比利时邮政服务24小时自动出单，华盟快递承诺比利时邮政每天发货。</p>
                    <p>
                        5. 华盟快递所发出的比利时邮政包裹无需转单，出单后可凭唯一单号，全程在线追踪包裹。</p>
                    <p style="font-weight: 800; margin-top: 30px">
                        【如何追踪包裹】</p>
                    <p style="text-indent: 2em; line-height: 25px">
                        <b>英文追踪：</b>英国寄出的所有比利时邮件都已EA开头，BE结尾，只需要在这个网址输入，就可以查询。<a href="http://www.track-parcel.com/">http://www.track-parcel.com/</a></p>
                    <p style="text-indent: 2em; line-height: 25px">
                        <b>中文追踪：</b>当包裹发出3-5个工作日后，中国邮政EMS的系统会更新中文信息，此时可在EMS官网查到最新信息。<a href="http://www.ems.com.cn/">http://www.ems.com.cn/</a></p>
                    <p style="font-weight: 800; margin-top: 30px">
                        【注意事项】</p>
                    <p style="text-indent: 2em; line-height: 25px">
                        1. 一个订单只能包含一个包裹，每个包裹不超过30公斤 (6桶奶粉请务必最小填写1箱7公斤）。但是可以多个订单一次性一天发到华盟物流仓库。</p>
                    <p style="text-indent: 2em; line-height: 25px">
                        2. 您下单后，我们会立即提供国际EMS官网可查询单号条形码文件，报关单，请大家务必将相关文件打印好，平铺贴在箱子上面。</p>
                    <p style="text-indent: 2em; line-height: 25px">
                        3. 对于Citylink上门取货的订单，我们会同时提供CityLink英国境内取件条形码文件（从您的地址到我们英国仓库的英国境内运输条形码）。对于Parcelforce取件和自送邮局的订单，我们系统会在发给您附有Bpost条形码文件5分钟后，继续给您发一封附有ParcelForce和自送邮局的境内包裹条形码文件（从邮局到我们英国仓库的英国境内运输条形码）。</p>
                    <p style="text-indent: 2em; line-height: 25px">
                        4. 根据国际航空快件标准及承运公司规定，您所邮递的单箱包裹不得超过30公斤，并且体积重量：计算公式为（长（厘米） X 宽（厘米） X 高（厘米））/ 5000，不得超过30公斤。
                        我们的系统会自动计算出您的体积重量：(长 X 宽 X 高) / 5000，如果包裹的体积重量大于实际重量，运输费用将按照体积重量来计算。</p>
                    <p style="text-indent: 2em; line-height: 25px">
                        5. 请您仔细阅读违禁品说明，以免造成不必要的麻烦。</p>
                    <p style="text-indent: 2em; line-height: 25px">
                        6. 无包裹损坏和包裹延迟保险。丢失保险上限为50镑，没有保价保险。如果客户填报价格低于50镑，按客户填报价值赔付。受理赔付前客户应当自觉上传邮寄包裹内物品小票证明物品价值。</p>
                    <p style="margin-top: 30px; text-indent: 2em; line-height: 25px">
                        华盟快递做到的是真正的方便与快捷，您再也不需要为订单确认等上一天，只需几分钟您就能完成整个在线订单过程！</p>
                </div>
            </div>
        </div>
    </div>

    <div id="page_two" runat="Server">
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
                    <p style="line-height: 25px">
                        1、Parcelforce Priority 服务每单最多只能包括三个包裹；Parcelforce Economy服务每单只能包括一个包裹</p>
                    <p style="line-height: 25px">
                        2、Parcelforce Priority自带上限100镑保险，其他服务丢失保险金额上限50镑。</p>
                    <p style="line-height: 25px">
                        3、全部服务24/7即时出单，华盟快递网站上实时追踪您的包裹</p>
                    <p style="line-height: 25px">
                        4、为了您的包裹准时到达，请准确的计算您的包裹重量和尺寸</p>
                    <p style="line-height: 25px">
                        5、如果您选择Post NL Priority 或者China Post EMS 服务，我们为您提供多种英国境内物流方式帮助您将包裹发送到我们手上。</p>
                    <p style="line-height: 25px">
                        6、华盟快递提供市场最低价格，欢迎批量下单客户联系我们洽谈合作价格</p>
                    <p style="line-height: 25px">
                        7、批量导入，批量出单，批量打印功能方便大客户一键打印所有文档。</p>
                </div>
                <div class="panel-footer">
                    <p style="color: #3C85C4">
                        *&nbsp;国际快递服务方式选择</p>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
