<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/reception-stage/batch.Master" AutoEventWireup="true"
    CodeBehind="supply-check-out.aspx.cs" Inherits="WM_Project.views.supply_checkout" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../style/wssh.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        select
        {
            padding: 1px;
            border: 1px solid rgb(204, 204, 204);
        }
        
        option
        {
            font-weight: normal;
            display: block;
            white-space: pre;
            min-height: 1.2em;
        }
    </style>
    <script type="text/javascript">
        function checkNums() {
            var totalPackage = 0;
            var packageType4 = document.getElementById('packageType4');
            var packageType6 = document.getElementById('packageType6');
            var packageTypeMore = document.getElementById('packageTypeMore');
            var packageTypeClue = document.getElementById('packageTypeClue');

            var selectOptions = packageTypeClue.options;
            var length = selectOptions.length;

            totalPackage = parseInt(packageType4.value) + parseInt(packageType6.value) + parseInt(packageTypeMore.value);
            
            for(var i = 0; i < length; i++)
            {
                packageTypeClue.removeChild(selectOptions[0]);
            }

            for (var i = 0; i <= totalPackage; i++) { 
                var option = document.createElement("option");
                option.text=i;
                option.id=i;
                packageTypeClue.appendChild(option);
            }
            if (totalPackage > 0) {
                packageTypeClue.disabled = false;
            } else {
                packageTypeClue.disabled = true;
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="center" runat="server">
    <div>
        <div style="clear: both; height: 19px;">
            &nbsp;</div>
        <div style="margin-right: 30px; margin-bottom: 12px; margin-left: 24px; float: left;
            background: #f4f4f4; border: 1px solid rgb(234, 234, 234);">
            <div class="int-results-box-header">
                请选择购买产品和数量</div>
            <div class="int-results-box-wrapper">
                <div class="int-results-details-wrapper">
                    <div class="int-results-Service-Name" style="margin-left: 20px">
                        25个专业4桶奶粉箱（29厘米 x 32厘米 x 25厘米）
                        <p>
                            <span class="international-qq-results-2nd-line-text"></span><span class="international-qq-results-warning-msg">
                            </span>
                        </p>
                        <p style="color: #FF0000; font-size: smaller;">
                        </p>
                        <p>
                        </p>
                    </div>
                    <div class="int-results-Price-Box-Product">
                        <strong>单价：£45.00</strong> <span class="international-qq-results-vat"></span>
                    </div>
                    <div class="int-results-Price-Box-Product">
                        数量：<select name="packageType4" onchange="checkNums();" id="packageType4" style="width: 50px;">
                            <option selected="selected" value="0">0</option>
                            <option value="1">1</option>
                            <option value="2">2</option>
                            <option value="3">3</option>
                            <option value="4">4</option>
                            <option value="5">5</option>
                            <option value="6">6</option>
                            <option value="7">7</option>
                            <option value="8">8</option>
                            <option value="9">9</option>
                            <option value="10">10</option>
                        </select>
                    </div>
                    <div class="clear">
                    </div>
                    <img src="../wsshimages/h-line.gif" style="height: 1px; width: 960px; border-width: 0px;">
                </div>
                <div class="clear">
                </div>
                <div class="int-results-details-wrapper">
                    <div class="int-results-Service-Name" style="margin-left: 20px">
                        25个专业6桶奶粉箱（42厘米 x 31厘米 x 25厘米）
                        <p>
                            <span class="international-qq-results-2nd-line-text"></span><span class="international-qq-results-warning-msg">
                            </span>
                        </p>
                        <p style="color: #FF0000; font-size: smaller;">
                        </p>
                        <p>
                        </p>
                    </div>
                    <div class="int-results-Price-Box-Product">
                        <strong>单价：£50.00</strong> <span class="international-qq-results-vat"></span>
                    </div>
                    <div class="int-results-Price-Box-Product">
                        数量：<select name="packageType6" onchange="checkNums();" id="packageType6" style="width: 50px;">
                            <option selected="selected" value="0">0</option>
                            <option value="1">1</option>
                            <option value="2">2</option>
                            <option value="3">3</option>
                            <option value="4">4</option>
                            <option value="5">5</option>
                            <option value="6">6</option>
                            <option value="7">7</option>
                            <option value="8">8</option>
                            <option value="9">9</option>
                            <option value="10">10</option>
                        </select>
                    </div>
                    <div class="clear">
                    </div>
                    <img src="../wsshimages/h-line.gif" style="height: 1px; width: 960px; border-width: 0px;" alt="" />
                </div>
                <div class="clear">
                </div>
                <div class="int-results-details-wrapper">
                    <div class="int-results-Service-Name" style="margin-left: 20px">
                        巨型泡泡膜（100米）
                        <p>
                            <span class="international-qq-results-2nd-line-text"></span><span class="international-qq-results-warning-msg">
                            </span>
                        </p>
                        <p style="color: #FF0000; font-size: smaller;">
                        </p>
                        <p>
                        </p>
                    </div>
                    <div class="int-results-Price-Box-Product">
                        <strong>单价：£20.00</strong> <span class="international-qq-results-vat"></span>
                    </div>
                    <div class="int-results-Price-Box-Product">
                        数量：<select name="packageTypeMore" onchange="checkNums();" id="packageTypeMore"
                            style="width: 50px;">
                            <option selected="selected" value="0">0</option>
                            <option value="1">1</option>
                            <option value="2">2</option>
                            <option value="3">3</option>
                            <option value="4">4</option>
                            <option value="5">5</option>
                            <option value="6">6</option>
                            <option value="7">7</option>
                            <option value="8">8</option>
                            <option value="9">9</option>
                            <option value="10">10</option>
                        </select>
                    </div>
                    <div class="clear">
                    </div>
                    <img src="../wsshimages/h-line.gif" style="height: 1px; width: 960px; border-width: 0px;" alt="">
                </div>
                <div class="clear">
                </div>
                <div class="int-results-details-wrapper">
                    <div class="int-results-Service-Name" style="margin-left: 20px">
                        胶带
                        <p>
                            <span class="international-qq-results-2nd-line-text"></span><span class="international-qq-results-warning-msg">
                            </span>
                        </p>
                        <p style="color: #FF0000; font-size: smaller;">
                        </p>
                        <p>
                        </p>
                    </div>
                    <div class="int-results-Price-Box-Product">
                        <strong>免费（单价价值£2.00）</strong> <span class="international-qq-results-vat"></span>
                    </div>
                    <div class="int-results-Price-Box-Product">
                        数量：<select name="packageTypeClue" id="packageTypeClue" disabled="disabled" style="width: 50px;">
                            <option selected="selected" value="0">0</option>
                        </select>
                    </div>
                    <div class="clear">
                    </div>
                    <img src="../wsshimages/h-line.gif" style="height: 1px; width: 960px; border-width: 0px;" alt="">
                </div>
                <div class="clear">
                </div>
            </div>
            <div class="int-results-box-footer" style="height: 16px;">
            </div>
            <div style="float: right;width:960px">
                <asp:ImageButton ID="packageBuyNow" ImageUrl="../wsshimages/int-quote-buy.gif" Style="border-width: 0px;"
                    runat="server" OnClick="packageBuyNow_Click" />
            </div>
        </div>
        <div style="clear: both; height: 19px;">
            &nbsp;</div>
    </div>
</asp:Content>
