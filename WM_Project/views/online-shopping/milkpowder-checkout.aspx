<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/reception-stage/batch.Master" AutoEventWireup="true" CodeBehind="milkpowder-checkout.aspx.cs" Inherits="WM_Project.views.online_shopping.milkpowder_checkout" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

<%@ Import Namespace="System.Xml" %>
<link href="../../style/wssh.css" rel="stylesheet" type="text/css" />
    <script src="../../script/jquery-1.11.1.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
        });
    </script>
    <script type="text/javascript">
        function checkText(obj) {
            var num = obj.value;
            if (num.match(/^[1-9]\d*$/g) == null && num != "0") {
                obj.value = "0";
            } else if (parseInt(obj.value) < 0) {
                obj.value = "0";
            }
        }

        function upNumber(obj) {
            var id = "quantity".concat(obj.id.substring(10));
            var txtNum = document.getElementById(id);

            txtNum.value = parseInt(txtNum.value) + 1;
        }

        function downNumber(obj) {
            var id = "quantity".concat(obj.id.substring(12));
            var txtNum = document.getElementById(id);

            if (parseInt(txtNum.value) <= 0) {
                txtNum.value = "0";
            } else {
                txtNum.value = parseInt(txtNum.value) - 1;
            }
        }

        function matchBoxType(boxType) {
            var nTotal = 0;
            var inputs = document.getElementsByTagName('input');
            for (var i = 0; i < inputs.length; i++) {
                if (inputs[i].type == "text") {
                    nTotal += parseInt(inputs[i].value);
                }
            }
            if (nTotal <= 0) {
                alert('请选择奶粉数量！');
                return false;
            }
            else if (((nTotal % boxType) > 0)) {
                alert('您选择的是' + boxType + '桶装箱子，但是您选择的奶粉总数量不是' + boxType + '的倍数，请修改您的奶粉数量');
                return false;
            }
            else
                return true;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="center" runat="server">
    <div id="MilkPowderPackageType" runat="server">
        <div style="clear: both;">
            &nbsp;</div>
        <!--milkbody start-->
        <div class="milkbody">
            <div class="milkdescribe" style="width: 750px;">
                <p style="margin: 0; padding: 0; font-size: large;">
                    请选择奶粉包装箱</p>
            </div>
            <!--milkpack1 start-->
            <div class="milkPack" id="milkpack1" style="display: inline; width: 226px; height: 370px;
                float: left; margin-right: 14px; margin-left: 14px;">
                <p class="milkPackImg" style="width: 200px; height: 200px; background-color: Gray;
                    margin: 13px; background-image: url('../../image/wsshimages/box_with_2milk.png');">
                </p>
                <p class="milkPackDesc" style="margin: 13px; height: 80px; width: 200px; margin-left: 50px;
                    font-size: 13px;">
                    <span class="bullpoint" style="font-size: 16px;">•</span> 包税，包清关，零爆罐。<br />
                    <span class="bullpoint" style="font-size: 16px;">•</span> 价格惊喜，超值优惠。<br />
                    <span class="bullpoint" style="font-size: 16px;">•</span> 全程EMS追踪，伦敦始发。
                </p>
                <p class="milkPackBut" style="width: 200px; margin: 13px;">
                    <asp:Button ID="count_2" Text="  选择  " Style="margin-left: 48px; border: none; padding: 7px 30px;
                        background: #007dc3; color: #FFFFFF; font-size: 14px; font-weight: bold; font-family: '\5FAE\8F6F\96C5\9ED1', Arial, Verdana, Sans-Serif;"
                        runat="server" OnClick="count_2_Click" />
                </p>
            </div>
            <!--milkpack1 end-->
            <!--milkpack2 start-->
            <div class="milkPack" id="milkpack2" style="display: inline; width: 226px; height: 370px;
                float: left; margin-right: 14px; margin-left: 14px;">
                <p class="milkPackImg" style="width: 200px; height: 200px; background-color: Gray;
                    margin: 13px; background-image: url('../../image/wsshimages/box_with_4milk.png');">
                </p>
                <p class="milkPackDesc" style="margin: 13px; height: 80px; width: 200px; margin-left: 50px;
                    font-size: 13px;">
                    <span class="bullpoint" style="font-size: 16px;">•</span> 每个箱子4桶奶粉。<br />
                    <span class="bullpoint" style="font-size: 16px;">•</span> 多种服务可选。<br />
                    <span class="bullpoint" style="font-size: 16px;">•</span> 气柱包装，爆罐包赔。
                </p>
                <p class="milkPackBut" style="height: 18px; width: 200px; margin: 13px;">
                    <asp:Button ID="count_4" Text="  选择　" Style="margin-left: 48px; border: none; padding: 7px 30px;
                        background: #007dc3; color: #FFFFFF; font-size: 14px; font-weight: bold; font-family: '\5FAE\8F6F\96C5\9ED1', Arial, Verdana, Sans-Serif;"
                        runat="server" OnClick="count_4_Click" />
                </p>
            </div>
            <!--milkpack2 end-->
            <!--milkpack3 start-->
            <div class="milkPack" id="milkpack3" style="display: inline; width: 226px; height: 370px;
                float: left; margin-right: 14px; margin-left: 14px;">
                <p class="milkPackImg" style="width: 200px; height: 200px; background-color: Gray;
                    margin: 13px; background-image: url('../../image/wsshimages/box_with_6milk.png');">
                </p>
                <p class="milkPackDesc" style="margin: 13px; height: 80px; width: 200px; margin-left: 50px;
                    font-size: 13px;">
                    <span class="bullpoint" style="font-size: 16px;">•</span> 每个箱子6桶奶粉。<br />
                    <span class="bullpoint" style="font-size: 16px;">•</span> 气柱包装，爆罐包赔。<br />
                    <span class="bullpoint" style="font-size: 16px;">•</span> 多种快递选择，经济实惠。
                </p>
                <p class="milkPackBut" style="height: 18px; width: 200px; margin: 13px;">
                    <asp:Button ID="count_6" Text="  选择  " Style="margin-left: 48px; border: none; padding: 7px 30px;
                        background: #007dc3; color: #FFFFFF; font-size: 14px; font-weight: bold; font-family: '\5FAE\8F6F\96C5\9ED1', Arial, Verdana, Sans-Serif;"
                        runat="server" OnClick="count_6_Click" />
                </p>
            </div>
            <!--milkpack3 end-->
            <div id="bannerb" style="float: left; width: 700px; overflow: hidden; height: 80px;
                margin-left: 34px; margin-bottom: 20px; margin-top: 20px;">
                <p class="milkPackBut" style="margin-left: 99px; float: right; height: 18px; width: 200px;">
                    <asp:Button ID="count_more" Text="奶粉批量下单" Style="margin-left: 48px; border: none;
                        padding: 7px 30px; background: #007dc3; color: #FFFFFF; font-size: 14px; font-weight: bold;
                        font-family: '\5FAE\8F6F\96C5\9ED1', Arial, Verdana, Sans-Serif;" runat="server"
                        OnClick="count_more_Click" />
                </p>
                <p class="milkPackDesc" style="height: 88px; width: 280px; margin-left: 50px; font-size: 13px;
                    float: left;">
                    批量奶粉下单入口，多服务，多地址，多单同下，即时出单，24小时发货</p>
            </div>
        </div>
        <!--milkbody end-->
        <div style="clear: both">
        </div>
    </div>
    <div id="MilkPowderNums" runat="server">
        <div style="clear: both;">
            &nbsp;</div>
        <%--column-one start--%>
        <div id="column-one" style="margin-left: 10px; margin-right: 30px; float: left; margin-bottom: 12px;
            font-weight: bold !important">
            <div class="int-results-box-header">
                网上商城</div>
            <div class="nextLabel" style="margin: 20px; width: 960px; font-size: 14px;">
                <p class="milkPackSelect" id="milk_power_message" style="display: block; width: 65%;">
                    <span class="font_red" style="display: block; color: #F00; font-size: 15px;"><strong
                        style="font-weight: bold !important;">厂家包装更换中，为避免混淆，请按照年龄挑选奶粉</strong></span>
                    <asp:Label ID="PackageTypeDesciption" Style="display: block; font-weight: bold !important"
                        runat="server"></asp:Label>
                </p>
                <asp:Button ID="btnNextTop" Text="下一步" CssClass="milkOrderNext normalbutton milkpower_buy_topbutton"
                    runat="server" Style="margin-top: -33px; width: 115px; height: 30px; background-color: #007DC3;
                    color: #ffffff; float: right; margin-right: 40px; border: 1px solid #0f72ac;
                    padding: 0 10px;" OnClick="btnNextTop_Click" />
            </div>
            <%--int-results-box-wrapper-unlimit start--%>
            <div class="int-results-box-wrapper-unlimit" id="results_box_wrapper" runat="server">
                <%
       
                    XmlDocument doc = new XmlDocument();
                    string path = Server.MapPath("~/views");
                    path += "/Data/wssh.xml";

                    doc.Load(path);

                    XmlElement root = doc.DocumentElement;

                    XmlNodeList listNodes = null;
                    listNodes = root.SelectNodes("/milks/milk");
                    foreach (XmlNode node in listNodes)
                    {
                %>
                <div class="box_small roundedbox milk">
                    <div class="content milk">
                        <input type="hidden" name="productId" value="<%=node["id"].InnerText %>" />
                        <div class="milkImage">
                            <img src="<%=node["image"].InnerText %>" style="border-width: 0px;" /><br />
                        </div>
                        <div class="milkLabel">
                            <p class="milkLabelLBL">
                                <span id="span1">
                                    <%=node["label"].InnerText %></span>
                            </p>
                            <p class="milkLabelDEC">
                                <span id="span2">
                                    <%=node["desc"].InnerText %></span>
                            </p>
                        </div>
                        <div class="milkNumber">
                            <div class="milkNumberdesc">
                                <p class="describe" style="width: 80px; height: 19px; margin-top: 10px;">
                                    数量</p>
                                <div class="selectItemMilk">
                                    <div class="numberSelect">
                                        <p class="numberSelectTxt" style="width: 80px; height: 27px;">
                                            <input type="text" name="quantity<%=node["id"].InnerText %>" id="quantity<%=node["id"].InnerText %>"
                                                value="0" class="numberSelectTxtIn" style="width: 48px; height: 27px; float: left"
                                                onchange="checkText(this)" />
                                            <input type="image" id="imageBtnUp<%=node["id"].InnerText %>" name="imageBtnUp<%=node["id"].InnerText %>"
                                                src="../../image/wsshimages/button_add.png" style="border-width: 0px;" onclick="upNumber(this);return false;" />
                                            <input type="image" id="imageBtnDown<%=node["id"].InnerText %>" name="imageBtnDown<%=node["id"].InnerText %>"
                                                src="../../image/wsshimages/button_remove.png" style="border-width: 0px; margin-top: 1px;"
                                                onclick="downNumber(this);return false;" />
                                        </p>
                                    </div>
                                </div>
                            </div>
                            <div class="milkPrice">
                                <p class="describe" style="margin-top: 10px; margin-left: 5px;">
                                    每桶价格</p>
                                <p class="checkPrice">
                                    £<span id="Span1"><%=node["price_e"].InnerText %></span> /￥<span id="Span2"><%=node["price_c"].InnerText %></span></p>
                            </div>
                            <div class="milkState">
                                <p style="margin: 1em 10px;">
                                    <%=node["state"].InnerText %></p>
                            </div>
                        </div>
                    </div>
                </div>
                <%
            }  
                %>
            </div>
            <%--int-results-box-wrapper-unlimit end--%>
            <div class="nextLabel">
                <asp:Button ID="btnNextBottom" Text="下一步" CssClass="milkOrderNext normalbutton milkpower_buy_topbutton"
                    Style="border: 1px solid #0f72ac;" runat="server" OnClick="btnNextBottom_Click" />
            </div>
        </div>
        <%--column-one end--%>
        <div style="clear: both;">
            &nbsp;</div>
    </div>

    <div id="MilkPowderShipmentType" runat="server">
        <div style="clear: both;">
            &nbsp;</div>
        <div id="column" style="margin-left: 10px; margin-right: 30px; float: left; margin-bottom: 12px;background:#f4f4f4;border: 1px solid rgb(234, 234, 234);
            font-weight: bold !important">
            <div class="int-results-box-header">
                <asp:Label ID="productBuyDesc" runat="server"></asp:Label>
            </div>
            <div>
                <table cellspacing="0" border="0" id="priceList" style="width: 100%;
                    border-collapse: collapse;">
                    <tbody>
                        <tr>
                            <th scope="col">
                            </th>
                        </tr>
                        <tr>
                            <td>
                                <div class="int-results-box-wrapper">
                                    <div class="int-results-hero-logo-box">
                                        <img src="../../image/wsshimages/bpost-large.png"
                                            style="height: 50px; border-width: 0px;"/>
                                    </div>
                                    <div class="int-results-details-wrapper">
                                        <div class="int-results-Service-Name">
                                            <span>比利时邮政 Bpost（5至12天）<br/>
                                                免关税，包清关，邮政绿色通道</span>
                                            <p>
                                                <span class="international-qq-results-2nd-line-text"></span><span class="international-qq-results-warning-msg">
                                                </span>
                                            </p>
                                            <p style="color: #FF0000; font-size: smaller;">
                                            </p>
                                            <p>
                                            </p>
                                        </div>
                                        <div class="int-results-Price-Box">
                                            <strong style="font-weight:bold !important">
                                                <asp:Label ID="bPostPrice" runat="server"></asp:Label>
                                            </strong>
                                            <span class="international-qq-results-vat"></span>
                                        </div>
                                        <div class="int-results-Buy-Box">
                                            <asp:ImageButton ID="bPostBuyNow" ImageUrl="../../image/wsshimages/int-quote-buy.gif" 
                                                style="border-width: 0px;" runat="server" onclick="bPostBuyNow_Click" />
                                        </div>
                                        <div class="clear">
                                        </div>
                                        <div class="int-results-Printer-Required">
                                        </div>
                                        <div>
                                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                <tbody>
                                                    <tr>
                                                        <td style="padding-top: 5px; color: rgb(102, 102, 102);" width="100%">
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </div>
                                    </div>
                                    <div class="clear">
                                    </div>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div class="int-results-box-wrapper">
                                    <div class="int-results-hero-logo-box">
                                        <img  src="../../image/wsshimages/ucs-large.png"
                                            style="height: 50px; border-width: 0px; margin-top: 13px;"/>
                                    </div>
                                    <div class="int-results-details-wrapper">
                                        <div class="int-results-Service-Name">
                                            <span>EMS直通车（5至14天）<br/>
                                                免关税，包清关，全程EMS跟踪<br/>
                                                <span class="warnningMSG">需要提供收件人身份信息。</span></span>
                                            <p>
                                                <span class="international-qq-results-2nd-line-text"></span><span class="international-qq-results-warning-msg">
                                                </span>
                                            </p>
                                            <p style="color: #FF0000; font-size: smaller;">
                                            </p>
                                            <p>
                                            </p>
                                        </div>
                                        <div class="int-results-Price-Box">
                                            <strong><asp:Label ID="emsPrice" runat="server"></asp:Label></strong>
                                            <span class="international-qq-results-vat"></span>
                                        </div>
                                        <div class="int-results-Buy-Box">
                                            <asp:ImageButton ID="emsBuyNow" ImageUrl="../../image/wsshimages/int-quote-buy.gif" 
                                                style="border-width: 0px;" runat="server" onclick="emsBuyNow_Click" />
                                        </div>
                                        <div class="clear">
                                        </div>
                                        <div class="int-results-Printer-Required">
                                        </div>
                                        <div>
                                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                <tbody>
                                                    <tr>
                                                        <td style="padding-top: 5px; color: rgb(102, 102, 102);" width="100%">
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </div>
                                    </div>
                                    <div class="clear">
                                    </div>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div class="int-results-box-wrapper">
                                    <div class="int-results-hero-logo-box">
                                        <img src="../../image/wsshimages/51parcel-large.png"
                                            style="height: 50px; border-width: 0px;"/>
                                    </div>
                                    <div class="int-results-details-wrapper">
                                        <div class="int-results-Service-Name">
                                            <span id="ctl00_Content_ctl00_gvPriceList_ctl04_lblServiceProviderName">英超专线 Premium（5至12天）<br/>
                                                免关税，包清关，邮政绿色通道</span>
                                            <p>
                                                <span class="international-qq-results-2nd-line-text"></span><span class="international-qq-results-warning-msg">
                                                </span>
                                            </p>
                                            <p style="color: #FF0000; font-size: smaller;">
                                            </p>
                                            <p>
                                            </p>
                                        </div>
                                        <div class="int-results-Price-Box">
                                            <strong><asp:Label ID="parcelPrice" runat="server"></asp:Label></strong>
                                            <span class="international-qq-results-vat"></span>
                                        </div>
                                        <div class="int-results-Buy-Box">
                                        <asp:ImageButton ID="parcelBuyNow" ImageUrl="../../image/wsshimages/int-quote-buy.gif" 
                                                style="border-width: 0px;" runat="server" onclick="parcelBuyNow_Click" />
                                        </div>
                                        <div class="clear">
                                        </div>
                                        <div class="int-results-Printer-Required">
                                        </div>
                                        <div>
                                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                <tbody>
                                                    <tr>
                                                        <td style="padding-top: 5px; color: rgb(102, 102, 102);" width="100%">
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </div>
                                    </div>
                                    <div class="clear">
                                    </div>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div class="int-results-box-wrapper">
                                    <p style="font-size: 15px; font-weight: normal; margin-left: 25px; padding-bottom: 20px;text-align:left;">
                                        温馨提示<br/>
                                        <br/>
                                        1、所有服务包含丢失和破损保险(破锡,掉扣除外),如有问题请在收到货物48小时内联系客服<br/>
                                        2、建议客户使用选择2罐奶粉箱子,无任何海关和关税问题<br/>
                                        3、1罐900克奶粉的关税为18元,如果您的包裹被抽查到关税,您只需正常支付即可<br/>
                                        4、建议同一个收件地址每次最多购买6罐奶粉,以降低被收税概率<br/>
                                    </p>
                                    <div id="luggageWMSG" style="margin-bottom:20px;text-align:left;">
                                        <p id="luggageWMSG_head">
                                            EMS直通车重要通知：</p>
                                        <div id="luggageWMSG_body">
                                            <p>
                                                1. 如果您使用的是英超EMS服务线路，请务必付款后查收您下单时填写的收件人邮箱或通知收件人查收其邮箱（包括垃圾邮件）。</p>
                                            <p>
                                                2. 选择标题为“【邮政身份通】提醒您：需要身份认证”的邮件。</p>
                                            <p>
                                                3. 点击邮件内容中链接向11185id邮政身份通上传身份证正反面 。</p>
                                            <p>
                                                4. 英超物流只有在EMS服务身份验证通过，方可发货，终身只需验证一次。</p>
                                        </div>
                                    </div>
                                </div>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
            <div class="int-results-box-footer">
            </div>
        </div>
        <div style="clear: both;">
            &nbsp;</div>
    </div>
</asp:Content>
