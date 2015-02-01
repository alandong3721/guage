<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/reception-stage/home.Master"
    AutoEventWireup="true" CodeBehind="ems-direct.aspx.cs" Inherits="WM_Project.views.inter_express.ems_direct" %>

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
                    Parcelforce economy最多只能下一个包裹，Parcelforce priority最多可以下单三个包裹，华盟EMS专线、荷兰邮政优先包 不限</h6>
                <h6 style="color: red">
                    上述包裹运往同一个地址，并且每箱包裹不能超过30公斤，点击加号添加更多包裹</h6>
            </div>
        </div>
        <div class="panel panel-primary">
            <div class="panel-heading">
                <h3 class="panel-title">
                    EMS直通车</h3>
            </div>
            <div class="panel-body">
                <div class="group-form">
                    <p style="text-indent: 2em; line-height: 25px;">
                        EMS直通车是英国华盟快递和中国邮政快递联合推出的英中国际快件线路，主要服务对象英国境内发货的跨境电商。</p>
                    <p style="font-weight: 600; margin-top: 20px">
                        申请开通EMS直通车服务需要满足以下条件：</p>
                    <p style="text-indent: 2em; line-height: 25px">
                        1. 是英国或者中国的合法注册公司(需提供营业执照)。</p>
                    <p style="text-indent: 2em; line-height: 25px">
                        2. 有自己的电商网站，或者为天猫国际等B2C电商平台的注册商家(需提供网址链接)。</p>
                    <p style="text-indent: 2em; line-height: 25px">
                        3. 保证如实申报货品品名，价值，数量。若夹带任何物品也需要如实申报。</p>
                    <p style="text-indent: 2em; line-height: 25px">
                        4. 需交纳押金，停止使用时退还。</p>
                    <p style="text-indent: 2em; line-height: 25px">
                        5. 如条件不满足，任意客户可使用英超物流代购代发业务EMS直通车线路，华盟快递已在海关备案。</p>
                    <p style="font-weight: 600; margin-top: 20px">
                        EMS直通车申请方法：</p>
                    <p style="text-indent: 2em; line-height: 25px">
                        将您的注册用户名，电话，您的网店或购物网站网址发送至seafreight@wm-global-express.com申请开通，我们工作人员会和您联系。或直接拨打客服电话
                        07428630888(英国) 进行咨询。</p>
                    <p style="font-weight: 600; margin-top: 20px">
                        EMS直通车服务介绍：</p>
                    <p style="text-indent: 2em; line-height: 25px">
                        1. 英超物流伦敦仓库发货后3-8个工作日到门服务。</p>
                    <p style="text-indent: 2em; line-height: 25px">
                        2. 自带免费50英镑保险，可选保价额度。</p>
                    <p style="text-indent: 2em; line-height: 25px">
                        3. 付款后出单前需要向邮政商务通id11183.com上传收件人身份证照片进行身份验证，终身只需验证一次。</p>
                    <p style="text-indent: 2em; line-height: 25px">
                        4. 如需交纳关税，收件人人民币网上支付(DDU)。发货人可以替客户代缴关税(DDP)。</p>
                    <p style="text-indent: 2em; line-height: 25px">
                        5. 国际运单，报关单，中文地址三合一，省纸省墨省事。</p>
                    <p style="text-indent: 2em; line-height: 25px">
                        6. 全程单号统一，EMS官网全程追踪，显示从伦敦始发。</p>
                    <p style="text-indent: 2em; line-height: 25px">
                        7. 国内24小时客服，客户遇关税物流等问题可直接联系国内客服。</p>
                    <p style="font-weight: 600; margin-top: 20px">
                        中国海关行邮税介绍：</p>
                    <p style="text-indent: 2em; line-height: 25px">
                        2012年起中国海关针对个人消费者在境外网站购买自用商品开始实行个人行邮税(关税)政策， 代替以往的关税，增值税，消费税，总税率下降40%左右。中国海关鼓励中国消费者通过合法方式进行
                        境外网站购物。行邮税的计算方法是，行邮税=商品的完税价格x商品税率。如果一个包裹/商品计算出来 的行邮税低于50元人民币，则免去行邮税(免税)，直接放行。每种商品的完税价格和税率都不同，具体请
                        参考海关总署公告： <a href="http://www.customs.gov.cn/publish/portal0/tab3889/module1188/info362458.htm">
                            http://www.customs.gov.cn/publish/portal0/tab3889/module1188/info362458.htm</a></p>
                    <p style="font-weight: 600; margin-top: 20px">
                        下单流程图：</p>
                    
                    <p style="text-indent: 2em; line-height: 25px; margin-top: 10px">
                        客户中文填写订单时必填省份和收件人邮箱（非发件人），付款后华盟系统生成EMS可查单号。如果收件人身份未验证，订单状态变为身份验证，中国收件人邮箱收到邮政身份通官方邮件令其上传身份证（验证身份证姓名与订单姓名是否匹配），上传成功1-8小时后，订单状态改为下单成功，发件人邮箱收到EMS
                        Label（条形码）。当身份验证通过后，同一姓名和邮箱终身无需再次上传。</p>
                    
                    <p style="font-weight: 600; margin-top: 20px">
                        EMS直通车注意事项：</p>
                    <p style="text-indent: 2em; line-height: 25px;">
                        1. 首重0.5 公斤，每0.5公斤价格不同。</p>
                    <p style="text-indent: 2em; line-height: 25px;">
                        2. 一个订单一个包裹，重量没有累计优惠。</p>
                    <p style="text-indent: 2em; line-height: 25px;">
                        3. 发货人需要严格帖子发货品类，数量和单价。</p>
                    <p style="text-indent: 2em; line-height: 25px;">
                        4. 必须下单时正确填写收件人省份和邮箱，如果身份需要验证，收件人邮箱将收到邮政身份通邮件，收件人根据邮件指示上传身份证照片进行验证(很简单)。</p>
                    <p style="text-indent: 2em; line-height: 25px;">
                        5. 订单中填写的收件人需要与身份证至少姓氏匹配，实际收件人可以不同。</p>
                    <p style="text-indent: 2em; line-height: 25px;">
                        6. 每次发货一个地址限制一箱。
                    </p>
                    <p style="font-weight: 600; margin-top: 20px">
                        单张A4纸贴单说明：</p>
                    <p style="text-indent: 2em; line-height: 25px;">
                        下单成功后客户会收到三份文件(如果自送华盟仓库则为一份)：,一份国际运单label，一份英国境内取件Label，一份英国境内取件Receipt。国际EMS label
                        为中文，此份文件集合了中文地址，EMS条形码和报关单。此张A4纸分为上下两半（完全一样），客户需要中间裁开，一半贴在箱子上，一半放在透明袋中，条形码外露。</p>
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
