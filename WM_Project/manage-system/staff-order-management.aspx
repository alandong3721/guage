<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/back-stage/staff.Master" AutoEventWireup="true" CodeBehind="staff-order-management.aspx.cs" Inherits="WM_Project.manage_system.staff_order_management" %>
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
<asp:Content ID="Content2" ContentPlaceHolderID="center" runat="server">
    <div id="magagerbody" style="margin-left:-15px;margin-right:-15px">
        <div id="navleft" style="display: inline;">
            <div class="col-md-2" style="padding: 0px; margin: 0px">
                <div class="panel panel-primary" style="padding-left: 0px">
                    <div class="panel-heading">
                        <h5 class="panel-title">
                            站内导航</h5>
                    </div>
                    <div class="panel-body" style="padding-left: 0px; padding-right: 0px">
                        <div id="firstpane" style="width: 100%">
                            <p class="menu_head" style="text-align:center">国际订单管理</p>
                            <div id="order_management" class="menu_body" runat="server" style="display: none">
                                <a href="frame/check-order-by-time.aspx" target="content" style=" text-decoration:none">按时间查看</a>
                                <a href="frame/check-order-by-name.aspx" target="content" style="text-decoration:none">按用户名查看</a>
                                <a href="frame/check-order-by-number.aspx" target="content" style="text-decoration:none">按订单号查看</a>
                            </div>
                            <p class="menu_head">本地订单管理</p>
                            <div id="local_order_management" class="menu_body" runat="server" style="display: none">
                                <a href="frame/check-local-order-by-time.aspx" target="content" style=" text-decoration:none">按时间查看</a>
                                <a href="frame/check-local-order-by-number.aspx" target="content" style=" text-decoration:none">按订单号查看</a>
                                <a href="frame/check-local-order-by-name.aspx" target="content" style=" text-decoration:none">按用户名查看</a>
                            </div>

                            <p class="menu_head">EMS订单管理</p>
                            <div id="ems_order_management" class="menu_body" runat="server" style="display: none">
                                <a href="frame/ems-last-order-number-check.aspx" target="content" style=" text-decoration:none">EMS剩余单号查询</a>
                                <a href="frame/import-ems-order-number.aspx" target="content" style=" text-decoration:none">EMS单号导入</a>
                                <a href="frame/import-ems-track-info.aspx" target="content" style=" text-decoration:none">EMS追踪信息导入</a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div id="contentright" style="display: inline;">
            <iframe name="content" id="content" style="margin-left: 20px; margin-top: 0px;" width="800px;"
                src="frame/check-order-by-time.aspx" frameborder="no" border="0" marginwidth="0"
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
