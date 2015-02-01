<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/reception-stage/home.Master"
    AutoEventWireup="true" CodeBehind="parcelforce-economy.aspx.cs" Inherits="WM_Project.views.inter_express.parcelforce_economy" %>

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
    
    <div id="login" class="row" runat="Server" visible="false">
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
    
   
    <div class="row" id="page_one" runat="Server">
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
                    Parcelforce Economy</h3>
            </div>
            <div class="panel-body">
                <div class="form-group">
                    <p style="text-indent: 2em; line-height: 25px">
                        华盟快递全英首推ParcelForce Global Economy全新服务。新服务是英国皇家邮政专为英中线路新开辟的专属通道， 与ParcelForce Global
                        Priority相比同为英国直邮，统一单号全程追踪，不经第三国和第三方转运，包裹进入中国同属绿色清关，收税概率完全相同。</p>
                    <p style="text-indent: 2em; line-height: 25px; font-weight: 600">
                        我们仍然坚持全英价格最低，提供Price Match! 并为订单量多的客户提供折上折扣! 欢迎商家客户下单前联系客服咨询价格！</p>
                    <p style="line-height: 25px">
                        1. 提供24小时自动下单，一秒支付，即刻出单。</p>
                    <p style="line-height: 25px">
                        2. 一个订单只能发一个包裹。</p>
                    <p style="line-height: 25px">
                        3. 客户可以选择ParcelForce工作人员上门取货或是自送ParcelForce的Depot，后者将更为低廉，适合发货量大的客户（注意：此服务不能将包裹送到邮局Post
                        Office）。</p>
                    <p>
                        - 若您选择自送Depot，请您在以下链接查询距离您最近的ParcelForce Depot地址，下单后您需自行保存并打印条形码Label和报关单，贴好后即可直接将包裹送到离您最近的Depot。</p>
                    <p>
                        - 查询Depot地址：http://www.parcelforce.com/depot-finder，输入取件地址邮编即可获得离您最近Depot地址和联系方式。</p>
                    <p style="line-height: 25px">
                        4. 新服务上门取货选项的条形码将由司机带给客户（客户不能自己打印），自送Depot服务我们会把条形码发给客户，客户需要自备打印机，在箱子上贴好送到附近的Depot。</p>
                    <p style="line-height: 25px">
                        5. 包裹发出后到中国的时效为5-10个工作日（此时间不包括包裹被海关扣留的时间）。</p>
                    <p style="margin-top: 20px; line-height: 25px; font-weight: 600">
                        请特别注意：</p>
                    <p style="line-height: 25px">
                        1. 邮政线路不再受理任何理由包裹延误（即超过8工作日）的赔偿申请。</p>
                    <p style="line-height: 25px">
                        2. 客户需要特别注意包裹的包装，邮政线路不再受理代理客户包裹损坏的赔偿申请。</p>
                </div>
            </div>
            <div class="panel-footer">
                <p style="color:#3C85C4">*&nbsp;Parcelforce Economy 每个订单只能下一个包裹</p>
            </div>
        </div>
    </div>
    
    
    <div class="row" id="page_two" runat="Server" visible="false">
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
    
</asp:Content>
