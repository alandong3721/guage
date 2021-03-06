﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/back-stage/manager.Master" AutoEventWireup="true" CodeBehind="manager-home.aspx.cs" Inherits="WM_Project.manage_system.manager_home" %>
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
            padding-left: 40px;
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
            padding-left: 38px;
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
<asp:Content ID="Content2" ContentPlaceHolderID="center" runat="server">
    <div id="magagerbody" style="margin-left:-15px;margin-right:-15px">
        <div id="navleft" style="display: inline;">
            <div class="col-md-3" style="padding: 0px; margin: 0px">
                <div class="panel panel-primary" style="padding-left: 0px">
                    <div class="panel-heading">
                        <h5 class="panel-title">
                            站内导航</h5>
                    </div>
                    <div class="panel-body" style="padding-left: 0px; padding-right: 0px">
                        <div id="firstpane" style="width: 100%">
                            <p class="menu_head">
                                充值还款管理</p>
                            <div id="charge_repay_management" class="menu_body" runat="server" style="display: none">
                                <a href="staff-frame/repay-apply.aspx" target="content" style=" text-decoration:none">为用户还款</a> 
                                <a href="super-admin-frame/check-debt-user.aspx" target="content" style=" text-decoration:none">欠款用户查询</a>
                                <a href="super-admin-frame/charge-repay-record.aspx" target="content" style=" text-decoration:none">充值还款记录查询</a>
                            </div>


                            <p class="menu_head">
                                添加邮费类别</p>
                            <div id="add_rate_type" class="menu_body" runat="server" style="display: none">
                                <a href="super-admin-frame/add-rate-type-ems.aspx" target="content" style=" text-decoration:none">添加&nbsp;EMS&nbsp;邮费类别</a> 
                                <a href="super-admin-frame/add-rate-type-postnl.aspx" target="content" style=" text-decoration:none">添加&nbsp;PostNL&nbsp;邮费类别</a>
                                <a href="super-admin-frame/add-rate-type-pf-gpr-collection.aspx" target="content" style=" text-decoration:none">添加&nbsp;GPR-C&nbsp;邮费类别</a>
                                <a href="super-admin-frame/add-rate-type-pf-gpr-delivery.aspx" target="content" style=" text-decoration:none">添加&nbsp;GPR-D&nbsp;邮费类别</a>
                                <a href="super-admin-frame/add-rate-type-pf-ipe-collection.aspx" target="content" style=" text-decoration:none">添加&nbsp;IPE-COLLECTION&nbsp;类别</a>
                                <a href="super-admin-frame/add-rate-type-pf-ipe-depot.aspx" target="content" style=" text-decoration:none">添加&nbsp;IPE-DEPOT&nbsp;邮费类别</a>
                                <a href="super-admin-frame/add-rate-type-pf-ipe-pol.aspx" target="content" style=" text-decoration:none">添加&nbsp;IPE-POL&nbsp;邮费类别</a>
                                <a href="super-admin-frame/add-rate-type-pf-ipe-trailer.aspx" target="content" style=" text-decoration:none">添加&nbsp;IPE-TRAILER&nbsp;邮费类别</a>
                            </div>
                            <p class="menu_head">
                                给用户设置邮费类型</p>
                            <div id="account_info" class="menu_body" runat="server" style="display: none">
                                <a href="super-admin-frame/set-rate-postnl.aspx" target="content" style=" text-decoration:none">设置&nbsp;PostNL&nbsp;邮费</a>
                                <a href="super-admin-frame/set-rate-ems.aspx" target="content" style=" text-decoration:none">设置&nbsp;EMS&nbsp;邮费</a>
                                <a href="super-admin-frame/set-rate-pf-gpr-collection.aspx" target="content" style=" text-decoration:none">设置&nbsp;PF-GPR-C&nbsp;邮费</a>
                                <a href="super-admin-frame/set-rate-pf-gpr-delivery.aspx" target="content" style=" text-decoration:none">设置&nbsp;PF-GPR-D&nbsp;邮费</a>
                                <a href="super-admin-frame/set-rate-pf-ipe-collection.aspx" target="content" style=" text-decoration:none">设置&nbsp;PF-IPE-Collection&nbsp;邮费</a>
                                <a href="super-admin-frame/set-rate-pf-ipe-depot.aspx" target="content" style=" text-decoration:none">设置&nbsp;PF-IPE-Depot&nbsp;邮费</a>
                                <a href="super-admin-frame/set-rate-pf-ipe-pol.aspx" target="content" style=" text-decoration:none">设置&nbsp;PF-IPE-Pol&nbsp;邮费</a>
                                <a href="super-admin-frame/set-rate-pf-ipe-trailer.aspx" target="content" style=" text-decoration:none">设置&nbsp;PF-IPE-Trailer&nbsp;邮费</a>
                            </div>

                            <p class="menu_head" style="color: #525252; text-decoration: none">
                                用户邮费类别查询</p>
                            <div id="emsType" class="menu_body" runat="server" style="display: none">
                                <a href="super-admin-frame/check-all-user-rate-type.aspx" target="content" style=" text-decoration:none">查询用户所有服务方式的邮费</a> 
                            </div>
                            
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div id="contentright" style="display: inline;">
            <iframe name="content" id="content" style="margin-left: 20px; margin-top: 0px;" width="700px;"
                src="staff-frame/repay-apply.aspx" frameborder="no" border="0" marginwidth="0"
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
