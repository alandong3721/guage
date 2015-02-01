<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/reception-stage/batch.Master" AutoEventWireup="true"
    CodeBehind="luggage-box.aspx.cs" Inherits="WM_Project.views.luggage_box" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../style/wssh.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        h1
        {
            display: block;
            font-size: 3em;
            -webkit-margin-before: 0.67em;
            -webkit-margin-after: 0.67em;
            -webkit-margin-start: 0px;
            -webkit-margin-end: 0px;
            font-weight: bold;
        }
        .productDesc
        {
            clear: both;
            font-family: 微软雅黑,Arial,Verdana,sans-serif;
            font-size: 15px;
            line-height: 24px;
            color: #444;
            margin: 0px 0px;
        }
    </style>
    <script type="text/javascript">
        function showPrice(obj) {
            var nums = obj.value;
            var spanPrice = document.getElementById('totalPrice');
            spanPrice.value = 11;
            alert(spanPrice);
            switch (nums) {
                case "0":
                    alert("0");
                    spanPrice.value = 0;
                    return;
                case "1":
                    spanPrice.value = 8;
                    return;
                case "2":
                    spanPrice.value = 11;
                    return;
                case "3":
                    spanPrice.value = 14;
                    return;
                case "4":
                    spanPrice.value = 17;
                    return;
                case "5":
                    spanPrice.value = 20;
                    return;
                case "6":
                    spanPrice.value = 23;
                    return;
                case "7":
                    spanPrice.value = '26';
                    return;
                case "8":
                    spanPrice.value = '29';
                    return;
                case "9":
                    spanPrice.value = '32';
                    return;
                case "10":
                    spanPrice.value = '35';
                    return;
            }
            alert(nums);
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="center" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div>
        <div style="clear: both;">
            &nbsp;</div>
        <div id="column-one">
            <div class="int-results-box-header">
                行李专用纸箱
            </div>
        </div>
        <div style="clear: both;">
            &nbsp;</div>
        <%--LuggageBox-body start--%>
        <div id="LuggageBox-body" class="wb-main-container">
            <div id="luggageSelect">
                <div class="wb-container-header" style="margin-top: 20px;">
                    <div id="wb-luggagebox-logo" class="wb-fl">
                        <p class="luggagePic wb-inlineBlock">
                            <img id="sideHead" class="wb-img-inbox" src="../wsshimages/S3.jpg" alt="" />
                        </p>
                    </div>
                    <div id="luggageBoxControl_page" class="wb-inbox-control wb-fr">
                        <h1 style="font-size: 20px; height: 33px; margin-bottom: 0px; margin-top: 8px;">
                            行李专用纸箱</h1>
                        <p style="margin-top: 0px; margin-bottom: 0px; height: 33px; display: block;">
                            购买数量
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <asp:DropDownList ID="luggageBox_count" runat="server" AutoPostBack="True" OnSelectedIndexChanged="luggageBox_count_SelectedIndexChanged" style="width:50px;">
                                    </asp:DropDownList>
                                    <strong style="display: inline;">总价格：£
                                        <asp:Label ID="showPrice" runat="server">0</asp:Label>.00
                                    </strong>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            <asp:ImageButton ID="luggageBoxBuyNow" CssClass="wb-fr wb-button-red" ImageUrl="../wsshimages/int-quote-buy.gif"
                                Style="border-width: 0px; float: right;" runat="server" 
                            onclick="luggageBoxBuyNow_Click" />
                        </p>
                        <p class="wb-main-i-message" style="margin-top: 0px; font-size: 13px;">
                            (此价格已包含英国境内送货费，请放心购买)</p>
                        <p>
                        </p>
                    </div>
                </div>
                <div class="clear" style="clear:both">&nbsp;</div>
                <div id="luggagebox_price" style="margin-top:20px">
                    <table>
                        <tbody>
                            <tr>
                                <td>
                                    数量
                                </td>
                                <td>
                                    1
                                </td>
                                <td>
                                    2
                                </td>
                                <td>
                                    3
                                </td>
                                <td>
                                    4
                                </td>
                                <td>
                                    5
                                </td>
                                <td>
                                    6
                                </td>
                                <td>
                                    7
                                </td>
                                <td>
                                    8
                                </td>
                                <td>
                                    9
                                </td>
                                <td>
                                    10
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    价格£
                                </td>
                                <td>
                                    8
                                </td>
                                <td>
                                    11
                                </td>
                                <td>
                                    14
                                </td>
                                <td>
                                    17
                                </td>
                                <td>
                                    20
                                </td>
                                <td>
                                    23
                                </td>
                                <td>
                                    26
                                </td>
                                <td>
                                    29
                                </td>
                                <td>
                                    32
                                </td>
                                <td>
                                    35
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
                <div id="luggageBox_desc" class="productDesc">
                    <img id="luggagebox_img" src="../wsshimages/luggagebox.jpg" alt="" />
                </div>
            </div>
            <div class="clear">
            </div>
        </div>
        <%--LuggageBox-body end  --%>
        <div style="clear: both;">
            &nbsp;</div>
    </div>
</asp:Content>
