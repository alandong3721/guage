<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/reception-stage/batch.Master" AutoEventWireup="true" CodeBehind="milkpowder-sells.aspx.cs" Inherits="WM_Project.views.milkpowder_sells" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<style type="text/css">
        
        body {
            /* background: url("images/bg.jpg") repeat; */
            background: #dadada;
            color: #444;
            line-height: 1.6em;
            font-family: '\5FAE\8F6F\96C5\9ED1', Arial, Verdana, sans-serif;
            font-size: 1em;
        }
        #MilkPowerSells_body {
            width: 989px;
            margin-left: auto;
            margin-right: auto;
        }
        
        #imgMilkPowerSellsBanner {
            width: 989px;
        }
        
        #MilkPowerSells_Countdown {
            margin-top: 27px;
            margin-bottom: 28px;
        }
        
        #MilkPowerSells_Countdown_body {
            width: 483px;
            height: 148px;
            background-color: rgb(115,201,250);
            color: rgb(1,124,191);
            margin-left: auto;
            margin-right: auto;
            box-sizing: border-box;
            text-align: center;
            padding-top: 1px;
            text-align: center;
            border-radius: 13px;
        }
        table {
            display: table;
            border-collapse: separate;
            border-spacing: 2px;
            border-color: gray;
        }
        #table.wb-counter-down {
            width: 400px;
            height: 70px;
            /* border-style: ridge; */
            border-width: 3px;
            /* border-color: #666666; */
            background-color: white;
            margin-left: auto;
            margin-right: auto;
            margin-top: 0px;
            /* color: #007dc3; */
            border-radius: 15px;
        }
        
        #table.wb-counter-down .numbers {
            padding: 0px;
            /* width: 45px; */
            text-align: center;
            font-family: Arial;
            font-size: 28px;
            font-weight: bold;
            font-style: normal;
            color: #007dc3;
            display: inline-block;
            line-height: 51px;
        }
        tr {
            display: table-row;
            vertical-align: inherit;
            border-color: inherit;
        }
        table#table td {
            width: 40px;
        }
        td, th {
            display: table-cell;
            vertical-align: inherit;
        }
        img {
            border: 0;
            border-style: none;
        }
        #MilkPowerSells_Select
        {
            text-align:center;
         }
         
         .MilkPowerSells_Select_button {
            margin-top: 30px;
            width: 273px;
            height: 330px;
            display: inline-block;
            margin-right: 15px;
            margin-left: 15px;
          }
          
          .wb-MilkPowerSells-button {
            margin-top: 2px;
            width: 273px;
            height: 297px;
            cursor: pointer;
            background-repeat: no-repeat;
            border:0 none;
          }
          p{margin:0;padding:0;}
          .wb-btn-lvl1.wb-MilkPowerSells-button {
            background-image: url("../wsshimages/imglvl1.jpg");
          }
        .wb-MilkPowerSells-number {
            text-align: right;
            font-size: 12px;
          }
          
          .wb-btn-lvl2.wb-MilkPowerSells-button {
            background-image: url("../wsshimages/imglvl2.jpg");
          }
          .wb-btn-lvl3.wb-MilkPowerSells-button {
            background-image: url("../wsshimages/imglvl3.jpg");
          }
          
          .productDesc {
            clear: both;
            font-family: 微软雅黑,Arial,Verdana,sans-serif;
            font-size: 15px;
            line-height: 24px;
            color: #444;
            margin: 0px 0px;
          }
          
          .productDesc ul li {
            list-style-type: disc;
            display: list-item;
            margin-left: 1em;
            margin-top: 1em;
            list-style: outside;
            overflow: visible;
            list-style:none;
          }
    </style>
<link href="../style/wssh.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="center" runat="server">
<div style="clear: both; height: 19px;">
            &nbsp;</div>

            <%--MilkPowerSells_body start--%>
        <div id="MilkPowerSells_body">
            <div id="MilkPowerSells_Banner">
                <img id="imgMilkPowerSellsBanner" src="../wsshimages/milkpowerLogo.jpg" alt=""/>
            </div>
            <div id="MilkPowerSells_Countdown">
                <div id="MilkPowerSells_Countdown_body">
                    <p style="font-size:18px;">
                        距离本轮结束还有</p>
                    <div>
                        <table id="table" border="0" class="wb-counter-down">
                            <tbody>
                                <tr id="spacer0" class="count_down_blank" style="height:7px;">
                                    <td colspan="6">
                                        <div class="numbers" id="count2" style="display: none;">
                                        </div>
                                    </td>
                                </tr>
                                <tr id="spacer1" style="height:51px;">
                                    <td>
                                        <div class="numbers">
                                        </div>
                                        <div class="title">
                                        </div>
                                    </td>
                                    <td>
                                        <div class="numbers" id="dday" style="display:inline;">
                                            02</div>
                                        <div class="title" id="days" style="display:inline;font-size:10px;">
                                            天
                                        </div>
                                    </td>
                                    <td>
                                        <div class="numbers" id="dhour" style="display:inline;">
                                            12</div>
                                        <div class="title" id="hours" style="display:inline;font-size:10px;">
                                            小时</div>
                                    </td>
                                    <td>
                                        <div class="numbers" id="dmin" style="display:inline;">
                                            23</div>
                                        <div class="title" id="minutes" style="display:inline;font-size:10px;">
                                            分</div>
                                    </td>
                                    <td>
                                        <div class="numbers" id="dsec" style="display:inline;">
                                            07</div>
                                        <div class="title" id="seconds" style="display:inline;font-size:10px;">
                                            秒</div>
                                    </td>
                                    <td>
                                        <div class="numbers">
                                        </div>
                                        <div class="title">
                                        </div>
                                    </td>
                                </tr>
                                <tr id="spacer2" class="count_down_blank" style="height:7px;">
                                    <td colspan="6">
                                        <div class="numbers" id="count2_1" style="display: none;">
                                        </div>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                    <p id="lblNextRound" style="color: red; font-size: 16px; line-height: 30px;">
                    </p>
                </div>
            </div>
            <div id="MilkPowerSells_Select">
                <div class="MilkPowerSells_Select_button">
                    <p style="font-size:18px;">
                        我要团2箱奶粉</p>
                    <input type="submit" name="ctl00$Content$MilkPowderSells1$btnMilkPowerSells1" value=""
                        id="ctl00_Content_MilkPowderSells1_btnMilkPowerSells1" class="wb-MilkPowerSells-button wb-btn-lvl1" />
                    <p id="lblLvl1Select" class="wb-MilkPowerSells-number">
                        已有<span id="ctl00_Content_MilkPowderSells1_lblLvl1PersonSelect">160</span>人团购</p>
                </div>
                <div class="MilkPowerSells_Select_button">
                    <p style="font-size:18px;">
                        我要团6箱奶粉</p>
                    <input type="submit" name="ctl00$Content$MilkPowderSells1$btnMilkPowerSells2" value=""
                        id="ctl00_Content_MilkPowderSells1_btnMilkPowerSells2" class="wb-MilkPowerSells-button wb-btn-lvl2" />
                    <p id="lblLvl2Select" class="wb-MilkPowerSells-number">
                        已有<span id="ctl00_Content_MilkPowderSells1_lblLvl2PersonSelect">63</span>人团购</p>
                </div>
                <div class="MilkPowerSells_Select_button">
                    <p style="font-size:18px;">
                        我要团12箱奶粉</p>
                    <input type="submit" name="ctl00$Content$MilkPowderSells1$btnMilkPowerSells3" value=""
                        id="ctl00_Content_MilkPowderSells1_btnMilkPowerSells3" class="wb-MilkPowerSells-button wb-btn-lvl3" />
                    <p id="lblLvl3Select" class="wb-MilkPowerSells-number">
                        已有<span id="ctl00_Content_MilkPowderSells1_lblLvl3PersonSelect">49</span>人团购</p>
                </div>
            </div>
            <div id="MilkPowerSells_Introduce" class="productDesc">
                <p>
                    <span style="color: #ff0000; font-family: 微软雅黑, arial, verdana, sans-serif; font-size: 20px;
                        text-align: center;">&nbsp; ▍</span><span style="font-weight: bold;">奶粉团购规则：</span>
                </p>
                <ul>
                    <li>•团购开放时间为4天：每周五00:00开始，持续到周一24:00结束（即周五、周六、周日、周一）。其他时间无法参与团购。 </li>
                    <li>•每箱奶粉必须同品牌同段数，但同一订单内，不同箱之间可以混合。（例如团购6箱奶粉，可以选择1箱爱1，2箱爱3，3箱牛4）。 </li>
                    <li>•团购价格包括：奶粉原价+国际运费+包装费+人工费（不包含任何清关产生的费用）。 </li>
                    <li>•快递路线：只发英国皇家邮政ParcelForce Economy，不能选择路线。 </li>
                    <li>•快递时效：默认7-12工作日送达，但个别省份会清关缓慢，逢节假日、网购高峰缓慢。 </li>
                    <li>•奶粉包装：3层包装，保鲜袋+小口径泡泡膜+大口径泡泡膜。 </li>
                    <li></li>
                </ul>
                <p>
                    <span style="color: #ff0000; font-family: 微软雅黑, arial, verdana, sans-serif; font-size: 20px;
                        text-align: center;">&nbsp; ▍</span><span style="font-weight: bold;">售后标准</span>：
                </p>
                <ul>
                    <li>•如果奶粉裂罐并漏到箱子里，按照爆罐处理，包赔。 </li>
                    <li>•如果只是锡纸破，但因为有保鲜袋缠绕，不影响食用，不赔。 </li>
                    <li>•包裹丢失（超过6周无更新），包赔。 </li>
                    <li>•因临近年底，个别地区可能会长期不到，此时无延时赔偿。 </li>
                    <li>•同一收件人同一地址，如果只买了一箱，被海关退运，英超物流负责处理。 </li>
                    <li>•同一收件人同一地址下≥2单时，可能导致包裹退回，责任客户自负。 </li>
                    <li></li>
                </ul>
            </div>
        </div>
            <%--MilkPowerSells_body end--%>
</asp:Content>
