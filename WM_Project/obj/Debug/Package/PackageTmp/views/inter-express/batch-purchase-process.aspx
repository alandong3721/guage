<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/reception-stage/batch.Master"
    AutoEventWireup="true" CodeBehind="batch-purchase-process.aspx.cs" Inherits="WM_Project.views.inter_express.batch_purchase_process" %>

<%@ Import Namespace="WM_Project.logical.common" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%--此处写CSS、Javascript代码--%>
    <script src="../../script/Calendar3.js" type="text/javascript"></script>
    <script src="../../script/jquery-1.11.1.js" type="text/javascript"></script>
    <link href="../../script/layer-v1.8.5/layer/skin/layer.css" rel="stylesheet" type="text/css" />
    <script src="../../script/layer-v1.8.5/layer/layer.min.js" type="text/javascript"></script>
    <script type="text/javascript">

        $(document).ready(function ($) {

            $(".reciver-address").on("click", function () {
                var adress_appear = $(this).parent().next().find(".form-control");

                var pagei = $.layer({
                    type: 2,
                    title: '收件人地址选择',
                    shadeClose: true,
                    title: false,
                    closeBtn: [0, true],
                    shade: [0.8, '#000'],
                    border: [0],
                    offset: ['50px', ''],
                    btn: ['OK', 'Canel'],
                    area: ['602px', ($(window).height() - 150) + 'px'],
                    iframe: { src: '../inter-express/receive-addr-pop.aspx' },
                    end: function () {
                        if ($("#flag").val() == "true") {
                            $("#flag").val("");
                            $.post("ReceiveAdress.ashx", function (data, statusCode) {
                                if (statusCode == "success") {
                                    adress_appear.val(data);
                                }
                            });
                        }
                    }
                });

            });

            $(".sender-address").on("click", function () {
                var adress_appear = $(this).parent().next().find(".form-control");

                var pagei = $.layer({
                    type: 2,
                    title: '发件人地址选择',
                    shadeClose: true,
                    title: false,
                    closeBtn: [0, true],
                    shade: [0.8, '#000'],
                    border: [0],
                    offset: ['50px', ''],
                    btn: ['OK', 'Canel'],
                    area: ['602px', ($(window).height() - 270) + 'px'],
                    iframe: { src: '../inter-express/send-addr-pop.aspx' },
                    end: function () {
                        if ($("#flag").val() == "true") {
                            $("#flag").val("");
                            $.post("ReceiveAdress.ashx", function (data, statusCode) {
                                if (statusCode == "success") {
                                    adress_appear.val(data);
                                }
                            });
                        }
                    }
                });

            });


        });
    </script>
    <script type="text/javascript">

        /*
        *	验证是否是正实数,不包括 0 
        */
        function isUnsignedNumeric(strNumber) {
            if (strNumber != 0) {
                var newPar = /^\d+(\.\d+)?$/;
                return newPar.test(strNumber);
            }
            else {
                return false;
            }

        }

        //判断页面信息是否真确填写
        function isPageInfoValidate() {

            //判断地址信息是否真确填写
            var send = document.getElementsByName("txt_send");
            var receive = document.getElementsByName("txt_receive");
            //判断是否填写取件日期
            var collectiontime = document.getElementsByName("collection_date");

            for (i = 0; i < send.length; i++) {
                   
                    if (send[i].value.trim() == "") {
                        alert("第" + (i + 1) + "个订单的发件地址为空，请填写！！");
                        return false;
                    } else if (receive[i].value.trim() == "") {
                        alert("第" + (i + 1) + "个订单的收件地址为空，请填写！！");
                        return false;
                    } else if (collectiontime[i].value.trim() == "") {
                        alert("第" + (i + 1) + "订单的取件日期为空，请填写！！");
                        return false;
                    }
                }


            //判断是否填写包裹价值
            var packagevalue = document.getElementsByName("value");

            for (j = 0; j < packagevalue.length; j++) {
                if (!isUnsignedNumeric(packagevalue[j].value.trim())) {
                    alert("包裹的价值只能是数字，请准确填写！！");
                    return false;
                }
            }

            /*判断用户是否同意服务条款*/
            var item1 = document.getElementById("checkbox_item_first");
            var item2 = document.getElementById("checkbox_item_second");
            if (item1.checked == false || item2.checked == false) {

                alert("请同意服务款，否则你将无法购买！！");
                return false;
            }

            return true;

        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="center" runat="server">
    <%--第一部分填写包裹详细信息--%>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <input id="flag" type="hidden" value="" />
    <div class="row" id="page_one" runat="Server">
        <div class="panel panel-primary">
            <div class="panel-heading">
                <h3 class="panel-title">
                    填写包裹详细信息及取件方式</h3>
            </div>
            <div class="panel-body">
                <%for (int i = 0; i < packages_to_SameAddress.Count; i++)
                  {
                      PackagesToSameAddress package = (PackagesToSameAddress)packages_to_SameAddress[i];
                      ArrayList package_measure_array = package.Package_Array;
                %>
                <div style="border: 2px solid #DADADA; margin-top: 10px; margin-bottom: 10px">
                    <div class="panel-group" style="height: 20px">
                        <label class="control-label" style="padding-top: 6px; font-size: 16px">
                            <font color="#FF0000">地址<%=i+1 %>&nbsp;&nbsp;</font> 发件地址：<%=package.Departure%>&nbsp;&nbsp;收件地址：<%=package.Destination%>&nbsp;&nbsp;邮寄方式：<%=package.Postway%></label>
                    </div>
                    <table class="table table-striped ">
                        <tr style="height: 20px">
                            <td colspan="5" style="height: 20px;">
                                <div class="col-md-2" style="text-align: right;">
                                    <input type="button" class="btn btn-info sender-address" style="padding-top: 0px;
                                        padding-bottom: 0px; height: 25px" value="添加发件地址" /></div>
                                <div class="col-md-4" style="padding-left: 0px">
                                    <input type="text" name="txt_send" class="form-control" readonly="readonly" style="padding-top: 0px;
                                        padding-bottom: 0px; height: 25px" /></div>
                                <div class="col-md-2" style="text-align: right">
                                    <input type="button" class="btn btn-info reciver-address" style="padding-top: 0px;
                                        padding-bottom: 0px; height: 25px" value="添加收件地址" /></div>
                                <div class="col-md-4" style="padding-left: 0px">
                                    <input type="text" name="txt_receive" class="form-control" readonly="readonly" style="padding-top: 0px;
                                        padding-bottom: 0px; height: 25px" /></div>
                            </td>
                        </tr>
                        <tr style="height: 20px">
                            <td colspan="5" style="height: 20px">
                                <div class="col-md-6" style="padding-top: 0px; padding-bottom: 0px; margin-top: 0px;
                                    margin-bottom: 0px">
                                    <label class="col-md-3" style="text-align: right; padding-right: 0px;">
                                        是否购买保险</label>
                                    <div class="col-md-7" style="padding-left: 30px">
                                        <select class="form-control" name="insurance_select" style="padding-top: 0px;
                                            padding-bottom: 0px; height: 25px">
                                            <option value="0">自带£20包裹丢失赔偿</option>
                                            <option value="5">购买5英镑是保500英镑</option>
                                            <option value="10">购买10英镑是保1000英镑</option>
                                            <option value="15">购买15英镑是保1500英镑</option>
                                            <option value="20">购买20英镑是保2000英镑</option>
                                        </select>
                                    </div>
                                </div>
                                <div class="col-md-6" style="padding-top: 0px; padding-bottom: 0px; margin-top: 0px;
                                    margin-bottom: 0px">
                                    <label class="col-md-5" style="text-align: right; padding-right: 0px;">
                                        取件日期：</label>
                                    <div class="col-md-7">
                                        <input type="text" class="form-control" name="collection_date" style="padding-top: 0px;
                                            padding-bottom: 0px; height: 25px; padding-right: 0px" onclick="new Calendar().show(this);" /></div>
                                </div>
                            </td>
                        </tr>
                        <%
                      for (int j = 0; j < package_measure_array.Count; j++)
                      {
                          PackageMeasure package_measure = (PackageMeasure)package_measure_array[j];
                        %>
                        <colgroup>
                            <tr style="text-align: left; height: 20px; margin-top: 0px; margin-bottom: 0px; padding-top: 0px;
                                padding-bottom: 0px">
                                <td colspan="5" style="width: 100%; text-align: left; height: 20px; margin-top: 0px;
                                    margin-bottom: 0px">
                                    <label class="col-md-8 control-label">
                                        <font color="#FF0000">第<%=j + 1%>种尺寸&nbsp;&nbsp;&nbsp;</font>包裹规格：#<%=package_measure.Count%>*<%=package_measure.Weight%>*<%=package_measure.Length%>*<%=package_measure.Width%>*<%=package_measure.Height%>
                                    </label>
                                    <span class="col-md-4" style="text-align: right">
                                        <input type="button" class="btn-danger btn-xs" style="height: 30px; width: 240px"
                                            value="将第一个包裹箱信息复制到其他包裹" />
                                    </span>
                                </td>
                            </tr>
                            <%
                          
                          for (int k = 0; k < package_measure.Count; k++)
                          { %>
                            <tr style="height: 20px">
                                <td class="panel-title" style="padding-left: 40px; width: 16%; text-align: left">
                                    <label>
                                        第<%= k + 1%>个包裹</label>
                                </td>
                                <td style="width: 8%; padding-right: 0px; text-align: right">
                                    <label>
                                        描述：</label>
                                </td>
                                <td style="width: 40%; padding-left: 0px; text-align: left">
                                    <select name="content" class="form-control" style="width: 360px; padding-top: 0px;
                                        padding-bottom: 0px; height: 25px">
                                        <option value="婴儿奶粉">婴儿奶粉</option>
                                        <option value="婴儿食品">婴儿食品</option>
                                        <option value="成人奶粉">成人奶粉</option>
                                        <option value="婴儿推车">婴儿推车</option>
                                        <option value="婴儿汽车座椅">婴儿汽车座椅</option>
                                        <option value="婴儿用品">婴儿用品</option>
                                        <option value="食品">食品</option>
                                        <option value="保健品">保健品</option>
                                        <option value="服装服饰">服装服饰</option>
                                        <option value="服饰配件">服饰配件</option>
                                        <option value="箱包">箱包</option>
                                        <option value="鞋靴">鞋靴</option>
                                        <option value="钟表">钟表</option>
                                        <option value="钟表配件">钟表配件</option>
                                        <option value="化妆品">化妆品</option>
                                        <option value="护肤品">护肤品</option>
                                        <option value="洗漱用品">洗漱用品</option>
                                        <option value="厨卫用品">厨卫用品</option>
                                        <option value="小家电">小家电</option>
                                        <option value="家具">家具</option>
                                        <option value="大家电">大家电</option>
                                        <option value="医疗用品">医疗用品</option>
                                        <option value="影音设备">影音设备</option>
                                        <option value="手机">手机</option>
                                        <option value="手机配件">手机配件</option>
                                        <option value="计算机">计算机</option>
                                        <option value="计算机设备">计算机设备</option>
                                        <option value="书报">书报</option>
                                        <option value="音响制品">音响制品</option>
                                        <option value="文具">文具</option>
                                        <option value="玩具">玩具</option>
                                        <option value="教育用品">教育用品</option>
                                        <option value="体育用品">体育用品</option>
                                        <option value="户外用品">户外用品</option>
                                        <option value="邮票">邮票</option>
                                        <option value="乐器">乐器</option>
                                        <option value="其他">其他</option>
                                    </select>
                                </td>
                                <td style="width: 16%; text-align: right">
                                    <label>
                                        总价值£：</label>
                                </td>
                                <td style="width: 20%; padding-left: 0px; text-align: left">
                                    <input type="text" name="value" class="form-control Allvalue" style="padding-top: 0px;
                                        padding-bottom: 0px; height: 25px;" />
                                </td>
                            </tr>
                        </colgroup>
                        <%} %>
                        <%} %>
                    </table>
                </div>
                <% } %>
                <div class="form-group">
                    <p style="font-family: @Adobe 楷体 Std R; font-size: 16px;color:#3C85C4">
                        在您下单之前，您需要认证阅读并同意一下条款，确定您的快递物品没有违反国际运输相关条例 并且检查你所申报的物品是否符合相关保险条款。
                    </p>
                    <p style="margin-top: 10px">
                        <input type="checkbox" id="checkbox_item_first" />
                        I confirm that I have provided accurate weight(s) and dimension(s) of my parcel(s)
                        to my best knowledge. I agree that if the weight(s) and/or dimension(s) of my parcel(s)
                        is/are incorrect, addtional charges i.e.the postage difference and additional charges(150%
                        of the difference) will be applied to my card based on information provided by the
                        courier. Check here to confirm above details are correct*
                    </p>
                    <p>
                        <input type="checkbox" id="checkbox_item_second" />
                        I agreed to the <a href="../package-advice.aspx">terms and conditions</a> , privacy
                        policy and no-compensation basis carriage. I confirm that my parcel(s) do not contain
                        any prohibited or restricted items. *
                    </p>
                </div>
                <div class="form-group" style="text-align: right">
                    <asp:Button ID="btn_next_step" runat="Server" Text="去购物车结算" CssClass="btn btn-info packageInfo"
                        Width="120px" OnClick="btn_next_step_Click" OnClientClick="return isPageInfoValidate()" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
