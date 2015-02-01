<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/reception-stage/batch.Master" AutoEventWireup="true" CodeBehind="my-account.aspx.cs" Inherits="WM_Project.views.my_account" %>




<asp:Content ID="Content2" ContentPlaceHolderID="center" runat="server">

<div id="magagerbody" style="margin-left:-15px;margin-right:-25px;">
        <div id="navleft" style="display: inline;float:left">
            <div style="padding: 0px; margin: 0px;width:190px;">
                <div class="panel panel-primary" style="padding-left: 0px">
                    <div class="panel-heading">
                        <h5 class="panel-title">
                            站内导航</h5>
                    </div>
                    <div class="panel-body" style="padding-left: 0px; padding-right: 0px;">
                        <div id="firstpane" style="width: 100%">
                            <p class="menu_head"><a href="user-frame/order-need-to-get-label.aspx" target="content">获取运单标签</a></p>
                            <p class="menu_head">个人信息管理</p>
                            <div id="person_info" class="menu_body" runat="Server" style="display:none">
                                <a href="user-frame/change-person-info.aspx" target="content" style=" text-decoration:none">修改个人信息</a> 
                                <a href="user-frame/change-password.aspx" target="content" style=" text-decoration:none">修改密码</a>
                            </div>
                            <p class="menu_head">账户信息管理</p>
                            <div id="account_info_management" class="menu_body" runat="Server" style="display:none">
                                <a href="user-frame/account-charge.aspx" target="content" style=" text-decoration:none">账户充值</a>
                                <a href="user-frame/my-account-balance.aspx" target="content" style=" text-decoration:none">账户余额</a>
                                <a href="user-frame/my-account-trans.aspx" target="content" style=" text-decoration:none">账户交易明细</a>
                            </div>
                            <p class="menu_head">地址信息管理</p>
                            <div id="address_info_management" class="menu_body" runat="Server" style="display:none">
                                <a href="user-frame/send-address.aspx" target="content" style=" text-decoration:none">发件地址</a> 
                                <a href="user-frame/receive-address.aspx" target="content" style=" text-decoration:none">收件地址</a>
                            </div>
                            
                            <p class="menu_head">
                                国际订单管理</p>
                            <div id="charge_repay_management" class="menu_body" runat="server" style="display: none">
                                <a href="user-frame/check-order-by-time.aspx" target="content" style=" text-decoration:none">历史订单</a> 
                                <a href="user-frame/check-order-by-number.aspx" target="content" style=" text-decoration:none">按订单号查询</a>
                            </div>
                            <p class="menu_head">
                                本地订单管理</p>
                            <div id="add_rate_type" class="menu_body" runat="server" style="display: none">
                                <a href="user-frame/order-local-pick-up.aspx" target="content" style=" text-decoration:none">本地下单</a>
                                <a href="user-frame/check-inner-order-by-time.aspx" target="content" style=" text-decoration:none">历史订单</a> 
                                <a href="user-frame/check-inner-order-by-number.aspx" target="content" style=" text-decoration:none">按订单号查询</a>  
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div id="contentright" style="display: inline;float:left">
            <iframe name="content" id="content" style="margin-left: 20px; margin-top: 0px;" width="800px;"
                src="user-frame/order-need-to-get-label.aspx" frameborder="no" border="0" marginwidth="0"
                marginheight="0" scrolling="no" allowtransparency="yes" onload="iFrameHeight()">
                您的浏览器不支持次插件. 请更新浏览器或者访问旧版</iframe>
            <script type="text/javascript" language="javascript">
                function iFrameHeight() {
                    var ifm = document.getElementById("content");
                    var subWeb = document.frames ? document.frames["content"].document : ifm.contentDocument;
                    if (ifm != null && subWeb != null) {
                        ifm.height = subWeb.body.scrollHeight;
                    }
                } 
            </script>
        </div>
    </div>


</asp:Content>




<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .menu_list
        {
            margin: 10px auto;
            width: 100%;
        }
        .menu_head
        {
            width: 100%;
            height: 47px;
            line-height: 47px;
            text-align:center;
            font-size: 14px;
            color: #525252;
            cursor: pointer;
            border: 1px solid #e1e1e1;
            position: relative;
            font-weight: bold;
            background: #f1f1f1 center right no-repeat;
            margin: 0;
        }
        .menu_list .current
        {
            background: #f1f1f1 center right no-repeat;
        }
        .menu_body
        {
            width: 100%;
            height: auto;
            overflow: hidden;
            line-height: 40px;
            border-left: 1px solid #e1e1e1;
            background: #fff;
            border-right: 1px solid #e1e1e1;
        }
        .menu_body a
        {
            display: block;
            width: 100%;
            height: 40px;
            line-height: 38px;
            text-align:center;
            color: #777777;
            background: #fff;
            text-decoration: none;
            border-bottom: 1px solid #e1e1e1;
        }
        .menu_body a:hover
        {
            text-decoration: none;
        }
    </style>
    <script src="../javascripts/jquery-1.11.1.js" type="text/javascript"></script>
    <script type="text/javascript">

        $(document).ready(function () {

            $("#firstpane p.menu_head").click(function () {
                $(this).addClass("current").next("div.menu_body").slideToggle(300).siblings("div.menu_body").slideUp("slow");
                $(this).siblings().removeClass("current");
            });
        });

    </script>

</asp:Content>
