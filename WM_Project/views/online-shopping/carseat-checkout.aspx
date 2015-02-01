<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/reception-stage/batch.Master" AutoEventWireup="true"
    CodeBehind="carseat-checkout.aspx.cs" Inherits="WM_Project.views.carseat_checkout" %>

<%@ Import Namespace="System.Xml" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../style/wssh.css" rel="stylesheet" type="text/css" />
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
            else
                return true;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="center" runat="server">
    <div id="CarsearCheckOut" runat="server">
        <div style="clear: both;">
            &nbsp;</div>
        <%--column-one start--%>
        <div id="column-one" style="width: 626px; margin-left: 24px; margin-right: 30px;
            float: left; margin-bottom: 12px; font-weight: bold !important">
            <div class="int-results-box-header">
                网上商城</div>
            <div class="nextLabel" style="margin: 20px; width: 960px; font-size: 14px;">
                <p class="milkPackSelect" style="display: inline">
                    <span>请选择您需要的商品种类和数量，然后点击下一步</span></p>
                <asp:Button ID="btnNextTop" Text="下一步" CssClass="milkOrderNext normalbutton" runat="server"
                    Style="border: 1px solid #0f72ac;" OnClientClick="return matchBoxType();" OnClick="btnNextTop_Click" />
            </div>
            <div class="int-results-box-wrapper-unlimit">
                <%
       
                    XmlDocument doc = new XmlDocument();
                    
                    string path = Server.MapPath("");
                    
                    path += "/Data/wsshcarseat.xml";
                    doc.Load(path);

                    XmlElement root = doc.DocumentElement;

                    XmlNodeList listNodes = null;
                    listNodes = root.SelectNodes("/carseats/carseat");
                    foreach (XmlNode node in listNodes)
                    { 
                %>
                <div class="box_small roundedbox milk">
                    <div class="content milk">
                        <input type="hidden" name="productId" value="<%=node["id"].InnerText %>" />
                        <div class="milkImage">
                            <img src="<%=node["image"].InnerText %>" style="border-width: 0px;" alt="" /><br />
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
                                                src="../wsshimages/button_add.png" style="border-width: 0px;" onclick="upNumber(this);return false;" />
                                            <input type="image" id="imageBtnDown<%=node["id"].InnerText %>" name="imageBtnDown<%=node["id"].InnerText %>"
                                                src="../wsshimages/button_remove.png" style="border-width: 0px; margin-top: 1px;"
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
                        </div>
                    </div>
                </div>
                <%
                 }
                %>
            </div>
            <div class="nextLabel">
                <asp:Button ID="btnNextBottom" Text="下一步" CssClass="milkOrderNext normalbutton" runat="server"
                    Style="border: 1px solid #0f72ac;" OnClientClick="return matchBoxType();" OnClick="btnNextBottom_Click" />
            </div>
        </div>
        <%--column-one end--%>
        <div style="clear: both;">
            &nbsp;</div>
    </div>
    <div id="ShipmentType" runat="server">
        <div style="clear: both;">
            &nbsp;</div>
        <div id="column" style="margin-left: 10px; margin-right: 30px; float: left; margin-bottom: 12px;background:#f4f4f4;border: 1px solid rgb(234, 234, 234);
            font-weight: bold !important">
            <div class="int-results-box-header">
                <span>请选择国际快递服务 (价格包含安全座椅，采购，包装，运输等费用)</span>
            </div>
            <div>
                <table cellspacing="0" border="0" style="width: 100%;
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
                                        <img src="../wsshimages/anpost-large.png" alt=""
                                            style="height: 50px; border-width: 0px;" />
                                    </div>
                                    <div class="int-results-details-wrapper">
                                        <div class="int-results-Service-Name">
                                            <span>爱尔兰邮政 Anpost（5至12天）<br />
                                                邮政绿色通道，海关抽查关税</span>
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
                                            <strong>
                                              <asp:Label ID="anPostPrice" runat="server"></asp:Label>
                                            </strong>
                                            <span class="international-qq-results-vat"></span>
                                        </div>
                                        <div class="int-results-Buy-Box">
                                        <asp:ImageButton ID="anPostBuyNow" ImageUrl="../wsshimages/int-quote-buy.gif" 
                                                style="border-width: 0px;" runat="server" onclick="anPostBuyNow_Click" />
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
                                        1、所有服务包含丢失和破损保险(外包装破损但物品完好除外),如有问题请在收到货物48小时内联系客服<br/>
                                    </p>
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
