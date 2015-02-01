<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/reception-stage/batch.Master"
    AutoEventWireup="true" CodeBehind="simple-batch-purchase-process.aspx.cs" Inherits="WM_Project.views.inter_express.simple_batch_purchase_process" %>

<%@ Import Namespace="WM_Project.logical.common" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%--此处写CSS、Javascript代码--%>
    <script src="../../script/Calendar3.js" type="text/javascript"></script>
    <script src="../../script/jquery-1.11.1.js" type="text/javascript"></script>
     <link href="../../script/layer-v1.8.5/layer/skin/layer.css" rel="stylesheet" type="text/css" />
    <script src="../../script/layer-v1.8.5/layer/layer.min.js" type="text/javascript"></script>
    <script type="text/javascript">

        $(document).ready(function ($) {

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




            $(".reciver-address").on("click", function () {
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

        
        //判断页面填写信息是否有效
        function isPageInfoValidate() {

            //首先判断地址是否填写
            var send = document.getElementsByName("txt_send_addr");
            var receive = document.getElementsByName("receiveAddr");
            if (send[0].value.trim() == "") {
                alert("请添加发件地址！！");
                return false;
            } else {
                for (i = 0; i < receive.length; i++) {
                    if (receive[i].value.trim()=="") {
                        alert("请添加收件地址！！");
                        return false;
                    }
                }
            }

            // 判断取件时间是否填写
            var collectiontime = document.getElementsByName("collection_date");
            for (j = 0; j < collectiontime.length; j++) {
                if (collectiontime[j].value.trim() == "") {
                    alert("请选择取件时间！！");
                    return false;
                }
            }

            //判断是否正确填写包裹的价值
            var packagevalue = document.getElementsByName("value");
            for (k = 0; k < packagevalue.length; k++) {
                if(!isUnsignedNumeric(packagevalue[k].value.trim()))
                {
                    alert("包裹价值请填写数字！！");
                    return false;
                }

            }

            //判断是否同意服务条款
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
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
     <input id="flag" type="hidden" value=""/>
    <%--第一部分包裹信息及取件方式填写--%>
    <div class="row" id="page_one" runat="Server">
        <div class="panel panel-primary">
            <div class="panel-heading">
                <h3 class="panel-title">
                    填写包裹详细信息</h3>
            </div>
            <div class="panel-body">
                <div class="form-group" style="height:20px;margin-bottom:10px">
                    <div class="col-md-2 col-md-offset-2" style="text-align:left"><input type="button" class="btn btn-info sender-address" style="padding-top:0px;padding-bottom:0px;height:25px" value="添加发件地址" /></div>
                    <div class="col-md-6"><input type="text" name="txt_send_addr" class="form-control" readonly="readonly" style="padding-top:0px;padding-bottom:0px;height:25px" /></div>
                </div>
                <div style="padding-top:10px" class="form-group">
                    <%for (int i = 0; i < batchOrders.Count; i++)
                      {
                          BatchOrder order = (BatchOrder)batchOrders[i];
                    %>
                    <table class="table table-striped">
                        <tr style="height: 30px">
                            <td colspan="5" style="text-align: left">
                                <div class="col-md-5"><label class="control-label" style="padding-top: 2px; font-size: 16px; text-align: left">
                                    <font color="#FF0000">订单<%=i+1 %>：&nbsp;&nbsp;</font> <%=order.Departure %>—&nbsp;&nbsp;<%=order.Destination %>&nbsp;&nbsp;—<%=order.PostWay %>
                                </label></div>
                                <div class="col-md-2" style="text-align:right"><input type="button" name="add_receiveAddr" class="btn btn-info reciver-address" value="添加收件地址" style="width:120px;padding-top:0px;padding-bottom:0px;height:25px" /></div>
                                <div class="col-md-5" style="text-align:left"><input type="text" class="form-control" name="receiveAddr" readonly="readonly" style="padding-top:0px;padding-bottom:0px;height:25px" /></div>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="5">
                                <div class="col-md-4" style="padding-right: 0px">
                                        <b>是否购买保险：</b><select name="insurance_select">
                                        <option value="0">自带£20包裹丢失赔偿</option>
                                        <%--<option value="5">购买5英镑是保500英镑</option>
                                        <option value="10">购买10英镑是保1000英镑</option>
                                        <option value="15">购买15英镑是保1500英镑</option>
                                        <option value="20">购买20英镑是保2000英镑</option>--%>
                                    </select></div>
                                <div class="col-md-4" style="text-align: right">
                                    <b>取件时间：</b><input type="text" style="width: 120px" name="collection_date" onclick="new Calendar().show(this)" /></div>
                                <div class="col-md-4" style="text-align: right">
                                    <input type="button" class="btn-danger btn-xs" style="height: 30px; width: 200px"
                                        value="将第一箱信息复制到其他箱" />
                                </div>
                            </td>
                        </tr>
                        
                        <%
 
                          for (int j = 0; j < order.Count; j++)
                          {
                        
                        %>
                        <tr>
                            <td class="panel-title" style="padding-left: 40px; width: 16%; text-align: left">
                                <label>
                                    包裹<%=(j+1) %></label>
                            </td>
                            <td style="width: 8%; padding-right: 0px; text-align: right">
                                <label>
                                    描述：</label>
                            </td>
                            <td style="width: 40%; padding-left: 0px; text-align: left">
                                <select name="content" class="form-control" style="width:360px;padding-top: 0px; padding-bottom: 0px;
                                    height: 25px">
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
                            <td style="width: 11%; text-align: right">
                                <label>
                                    总价值&pound;：</label>
                            </td>
                            <td style="width: 23%;text-align: left">
                                <input type="text" name="value" class="form-control" style="width:200px;padding-top: 0px;
                                    padding-bottom: 0px; height: 25px;" />
                            </td>
                        </tr>
                        <%} %>
                        <tr style="height: 2px">
                            <td colspan="5" style="height: 2px; background: #DADADA">
                            </td>
                        </tr>
                    </table>
                    <%} %>

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
                        <asp:Button ID="btn_toMyShoopingCart" runat="Server" Text="去购物车结算" CssClass="btn btn-info"
                            OnClientClick="return isPageInfoValidate()" OnClick="btn_toMyShoopingCart_Click" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
