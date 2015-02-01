<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/reception-stage/batch.Master" AutoEventWireup="true"
    CodeBehind="my-account-old.aspx.cs" Inherits="WM_Project.views.my_account_old" %>

<%@ Import Namespace="WM_Project.logical.user" %>
<%@ Import Namespace="WM_Project.logical.common" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" src="../script/jquery-1.11.1.js"></script>
    <style type="text/css">
        .menu_list
        {
            margin: 10px auto;
            width: 220px;
        }
        .menu_head
        {
            width: 220px;
            height: 47px;
            line-height: 47px;
            padding-left: 38px;
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
            width: 220px;
            height: auto;
            overflow: hidden;
            line-height: 38px;
            border-left: 1px solid #e1e1e1;
            backguound: #fff;
            border-right: 1px solid #e1e1e1;
        }
        .menu_body a
        {
            display: block;
            width: 223px;
            height: 38px;
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
    <script type="text/javascript">

        $(document).ready(function () {

            //$("#firstpane .menu_body:eq(1)").show();
            $("#firstpane p.menu_head").click(function () {
                $(this).addClass("current").next("div.menu_body").slideToggle(300).siblings("div.menu_body").slideUp("slow");
                $(this).siblings().removeClass("current");
            });

            //保存地址时的验证
            $(".save").click(function () {

                var address = $(this).parent().parent().parent().parent();

                var contact = address.find(".contact");
                var company = address.find(".company");
                var line = address.find(".line1");
                var city = address.find(".city");
                var postcode = address.find(".postcode");
                var country = address.find(".country");
                var phone = address.find(".phone");
                var email = address.find(".email");

                if (contact.val() == "" || company.val() == "" || line.val() == "" || city.val() == "" || postcode.val() == "" || country.val() == "" || phone.val() == "" || email.val() == "") {
                    alert("带 * 号的不能为空！！");
                    return false;

                }

                return true;

            });

        });

    
    </script>
    <%--javascript代码--%>
    <script type="text/javascript">
        ///登陆前的验证

        function isNull() {
            var name = document.getElementById("txt_username").value;
            var password = document.getElementById("txt_password").value;
            var code = document.getElementById("txt_code").value;

            if (name == "" || password == "" || code == "") {
                alert("带*号的不能为空！");
                return false;
            }

            return true;
        }

        //    修改个人信息的验证
        function personInfoVerification() {

            var street = document.getElementById("txt_streetAddress").value;
            alert(street);

        }

        //修改密码时的验证
        function passwordVerification() {

            var old = document.getElementById("txt_oldpassword").value;
            var newpassword = document.getElementById("txt_newpassword").value;
            var renew = document.getElementById("txt_renewpassword").value;

            if (old == "" || newpassword == "" || renew == "") {
                alert("带*不能为空");
                return false;
            }
            else if (newpassword != renew) {
                alert("两次密码不一致！");
                return false;
            }

            return true;
        }

        //textbox全选的实现
        function quanxuan(obj) {

            var checks = document.getElementsByName("checkbox");

            for (i = 0; i < checks.length; i++) {
                checks[i].checked = obj.checked;
            }
        }

        //订单号不能为空的验证
        function isTextAreaNull() {
            var textarea = document.getElementById("txt_order_number").value;
            if (textarea == "") {
                alert("订单号不能为空！！");
                return false;
            }

            return true;
        }

    </script>
    <%--jquery代码--%>
    <script src="../script/jquery-1.11.1.js" type="text/javascript"></script>
    <script src="../script/jquery-1.4.2.min.js" type="text/javascript"></script>
    <script src="../script/Calendar3.js" type="text/javascript"></script>
    <script type="text/javascript">
        
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="center" runat="server">
    <%--如果没有登录，先登录--%>
    <div class="row" id="login_first" runat="Server" visible="false" style="width: 70%;
        margin: 0 auto">
        <div class="panel panel-primary">
            <div class="panel-heading">
                <h3 class="panel-title">
                    User Login</h3>
            </div>
            <div class="panel-body">
                <div class="form-group" style="height: 30px; margin-top: 10px">
                    <label for="username" class="col-md-3 control-label" style="padding-top: 8px;">
                        User&nbsp;&nbsp;Name:</label>
                    <div class="col-md-7" style="padding-left: 0px">
                        <input type="text" class="form-control" id="Text1" name="txt_username" placeholder="please input user name" />
                    </div>
                    <div class="col-md-2" style="color: #FF0000; padding-top: 10px">
                        *
                    </div>
                </div>
                <div class="form-group" style="height: 30px">
                    <label for="password" class="col-md-3 control-label" style="padding-top: 8px">
                        Password:</label>
                    <div class="col-md-7" style="padding-left: 0px">
                        <input type="password" class="form-control" name="txt_password" id="txt_password" />
                    </div>
                    <div class="col-md-2" style="color: #FF0000; padding-top: 10px">
                        *
                    </div>
                </div>
                <div class="form-group" style="height: 30px">
                    <label for="code" class="col-md-3 control-label" style="padding-top: 8px">
                        Code:</label>
                    <div class="col-md-5" style="padding-left: 0px">
                        <input type="text" class="form-control" name="txt_code" id="txt_code" />
                    </div>
                    <div class="col-md-2 " style="text-align: right">
                        <img src="code.aspx" alt="" height="30px" onclick="this.src=this.src+'?'" /></div>
                    <div class="col-md-2" style="color: #FF0000; padding-top: 10px">
                        *
                    </div>
                </div>
                <div class="form-group" style="height: 30px; padding-top: 20px">
                    <div style="text-align: center">
                        <asp:Button ID="btn_login" runat="Server" Text="登陆" OnClientClick="return isNull();"
                            CssClass="btn btn-info" OnClick="btn_login_Click" /></div>
                </div>
            </div>
        </div>
    </div>
    <%--登陆之后显示的界面--%>
    <div class="form-horizontal" id="after_login" runat="Server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="row" style="padding: 0px;">
            <div class="col-md-3" style="padding: 0px; margin: 0px">
                <div class="panel panel-primary">
                    <div class="panel-heading">
                        <h5>
                            站内导航</h5>
                    </div>
                    <div class="panel-body">
                        <div id="firstpane" class="menu_list">
                            <p class="menu_head">
                                个人信息管理</p>
                            <div id="account_info" class="menu_body" runat="server" style="display: none">
                                <a href="my-account-old.aspx?part=1&action=personinfo">修改个人信息</a> <a href="my-account-old.aspx?part=1&action=password">
                                    修改密码</a>
                            </div>
                            <p class="menu_head">
                                地址信息管理</p>
                            <div id="addressInfo" class="menu_body" runat="server" style="display: none">
                                <a href="my-account-old.aspx?part=2&action=send">发件地址信息管理</a> <a href="my-account-old.aspx?part=2&action=receive">
                                    收件地址信息管理</a>
                            </div>
                            <p class="menu_head">
                                订单管理</p>
                            <div id="orderInfo" class="menu_body" runat="server" style="display: none">
                                <a href="my-account-old.aspx?part=3&action=order_number">按订单号查询订单</a> <a href="my-account-old.aspx?part=3&action=time">
                                    按时间查询订单</a>
                            </div>
                            <p class="menu_head">
                                账号管理</p>
                            <div id="chargeInfo" class="menu_body" runat="server" style="display: none">
                                <a href="my-account-old.aspx?part=4&action=charge">账户充值</a> <a href='my-account-old.aspx?part=4&action=bonus">
                                    我的红包</a> <a href="my-account-old.aspx?part=4&action=point">我的积分</a>
                            </div>
                            <p class="menu_head">
                                条码管理</p>
                            <div id="labelInfo" class="menu_body" runat="server" style="display: none">
                                <a href="my-account-old.aspx?part=5">条码下载</a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <%--第一部分 个人信息--%>
            <div id="first" runat="Server" visible="false">
                <div class="col-md-9" style="padding-right: 0px">
                    <div class="panel panel-primary" id="personinfo" runat="Server"
                        visible="false">
                        <div class="panel-heading">
                            <h5>
                                个人信息管理</h5>
                        </div>
                        <div class="panel-body">
                            <div class="form-group">
                                <label for="firstname" class="col-md-3 control-label">
                                    username:</label>
                                <div class="col-md-7">
                                    <asp:TextBox ID="txt_username" runat="Server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="email" class="col-md-3 control-label">
                                    email:</label>
                                <div class="col-md-7">
                                    <asp:TextBox ID="txt_email" runat="Server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="email" class="col-md-3 control-label">
                                    recommend user:</label>
                                <div class="col-md-7">
                                    <asp:TextBox ID="txt_recommendUser" runat="Server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="website" class="col-md-3 control-label">
                                    website:</label>
                                <div class="col-md-7">
                                    <asp:TextBox ID="txt_website" runat="Server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="company name" class="col-md-3 control-label">
                                    company name:</label>
                                <div class="col-md-7">
                                    <asp:TextBox ID="txt_companyName" runat="Server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="tel" class="col-md-3 control-label">
                                    telephone:</label>
                                <div class="col-md-7">
                                    <asp:TextBox ID="txt_telephone" runat="Server" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="col-md-2" style="color: Red">
                                    *</div>
                            </div>
                            <div class="form-group">
                                <div class="col-md-2 col-md-offset-5" style="text-align: center">
                                    <asp:Button ID="btn_modify" CssClass="btn btn-info" runat="Server" Text="修改" OnClientClick="return personInfoVerification()"
                                        OnClick="btn_modify_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="panel panel-primary" id="password" runat="Server"
                        visible="false">
                        <div class="panel-heading">
                            <h5>
                                修改密码</h5>
                        </div>
                        <div class="panel-body">
                            <div class="form-group">
                                <label for="old password" class="col-md-3 control-label">
                                    old password:</label>
                                <div class="col-md-7">
                                    <input type="password" id="txt_oldpassword" name="txt_oldpassword" class="form-control" />
                                </div>
                                <div class="col-md-2" style="color: Red">
                                    *</div>
                            </div>
                            <div class="form-group">
                                <label for="new password" class="col-md-3 control-label">
                                    new password:</label>
                                <div class="col-md-7">
                                    <input type="password" name="txt_newpassword" id="txt_newpassword" class="form-control" />
                                </div>
                                <div class="col-md-2" style="color: Red">
                                    *</div>
                            </div>
                            <div class="form-group">
                                <label for="renew password" class="col-md-3 control-label">
                                    repeat :</label>
                                <div class="col-md-7">
                                    <input type="password" id="txt_renewpassword" name="txt_renewpassword" class="form-control" />
                                </div>
                                <div class="col-md-2" style="color: Red">
                                    *</div>
                            </div>
                            <div class="form-group">
                                <div class="col-md-2 col-md-offset-5" style="text-align: center">
                                    <asp:Button ID="btn_moddify_password" runat="Server" CssClass="btn btn-info" Text="修改密码"
                                        OnClick="btn_moddify_password_Click" OnClientClick="return passwordVerification()" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <%--第二部分 地址编辑--%>
            <div id="second" runat="Server" visible="false">
                <div class="col-md-9" style="padding-right: 0px">
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            <h5>
                                地址管理</h5>
                        </div>
                        <div class="panel-body">
                            <%--发件地址部分--%>
                            <div id="send" runat="Server" visible="false">
                                <div class="form-group" style="margin-top: 10px">
                                    <div class="col-md-6" style="height: 30px; padding-top: 10px; font-size: 18px; font-weight: 700">
                                        发件地址</div>
                                    <div class="col-md-6" style="text-align: right; height: 30px;">
                                        <asp:Button ID="btn_addsendAddress" runat="Server" Text="添加新地址" CssClass="btn btn-info"
                                            OnClick="btn_addsendAddress_Click" /></div>
                                </div>
                                <div class="form-group" style="padding-left: 12px; padding-right: 12px">
                                    <div style="height: 2px; background: #DADADA">
                                    </div>
                                </div>
                                <div class="form-group">
                                    <asp:DataList ID="send_address" runat="Server" OnItemCommand="send_address_ItemCommand">
                                        <ItemTemplate>
                                            <div style="width: 740px">
                                                <div class="col-md-9" style="text-align: left;">
                                                    <%#DataBinder.Eval(Container.DataItem, "addressInfo")%>
                                                </div>
                                                <div class="col-md-3">
                                                    <div class="col-md-3" style="text-align: right; padding: 0; margin: 0">
                                                        <asp:ImageButton ID="img_del" runat="Server" ImageUrl="../image/images/del.jpg" CommandName="del"
                                                            CommandArgument='<%#DataBinder.Eval(Container.DataItem,"addr_id") %>' />
                                                    </div>
                                                    <div class="col-md-3" style="text-align: right; padding: 0; margin: 0">
                                                        <asp:ImageButton ID="img_edit" runat="Server" ImageUrl="../image/images/copy.gif" CommandName="edit"
                                                            CommandArgument='<%#DataBinder.Eval(Container.DataItem,"addr_id") %>' />
                                                    </div>
                                                    <div class="col-md-6" style="text-align: right; padding: 0; margin: 0">
                                                        <asp:LinkButton ID="lbtn_set" runat="Server" Text="设为默认" CommandName="set" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"addr_id") %>'></asp:LinkButton>
                                                    </div>
                                                </div>
                                            </div>
                                        </ItemTemplate>
                                        <SeparatorTemplate>
                                            <div style="padding-left: 12px; padding-right: 12px; margin-top: 10px; margin-bottom: 10px">
                                                <div style="height: 2px; background: #DADADA">
                                                </div>
                                            </div>
                                        </SeparatorTemplate>
                                        <FooterTemplate>
                                            <div style="padding-left: 12px; padding-right: 12px">
                                                <div style="margin-top: 10px; margin-bottom: 10px; height: 2px; background: #DADADA">
                                                </div>
                                            </div>
                                        </FooterTemplate>
                                    </asp:DataList>
                                    <%if (address_record_count > 0)
                                      {
                                    %>
                                    <div style="text-align: right">
                                        <p style="text-align: right">
                                            总共<%=address_record_count %>条&nbsp;&nbsp;&nbsp;
                                            <%if (address_record_count > address_page_size)
                                              { %>
                                            每页<%=address_page_size%>条&nbsp;&nbsp;&nbsp;当前第<%=address_page_now%>页&nbsp;&nbsp;&nbsp;
                                            <%if (address_page_now != 1)
                                              {%>
                                            <a href="my-account-old.aspx?part=2&action=send&pageNow=1">首页</a>&nbsp;&nbsp;&nbsp;
                                            <a href="my-account-old.aspx?part=2&action=send&pageNow=<%=address_page_now-1 %>">上一页</a>&nbsp;&nbsp;&nbsp;
                                            <%} %>
                                            <%if (address_page_now != address_page_count)
                                              { %>
                                            <a href="my-account-old.aspx?part=2&action=send&pageNow=<%=address_page_now+1 %>">下一页</a>&nbsp;&nbsp;&nbsp;
                                            <a href="my-account-old.aspx?part=2&action=send&pageNow=<%=address_page_count %>">尾页</a>&nbsp;&nbsp;&nbsp;
                                            <%} %>
                                            <%} %>
                                        </p>
                                    </div>
                                    <%
                                      } %>
                                </div>
                            </div>
                            <%--收件地址部分--%>
                            <div id="receive" runat="Server" visible="false">
                                <div class="form-group">
                                    <div class="col-md-6" style="height: 30px; padding-top: 10px; font-size: 18px; font-weight: 700">
                                        收件地址</div>
                                    <div class="col-md-6" style="text-align: right; height: 30px;">
                                        <asp:Button ID="btn_addreceiveAddress" runat="Server" Text="添加新地址" CssClass="btn btn-info"
                                            OnClick="btn_addreceiveAddress_Click" /></div>
                                </div>
                                <div class="form-group" style="padding-left: 12px; padding-right: 12px">
                                    <div style="height: 2px; background: #DADADA">
                                    </div>
                                </div>
                                <div class="form-group">
                                    <asp:DataList ID="receive_address" runat="Server" OnItemCommand="receive_address_ItemCommand">
                                        <ItemTemplate>
                                            <div style="width: 740px">
                                                <div class="col-md-9" style="text-align: left;">
                                                    <%#DataBinder.Eval(Container.DataItem, "addressInfo")%>
                                                </div>
                                                <div class="col-md-3">
                                                    <div class="col-md-3" style="text-align: right; padding: 0; margin: 0">
                                                        <asp:ImageButton ID="img_del" runat="Server" ImageUrl="../image/images/del.jpg" CommandName="del"
                                                            CommandArgument='<%#DataBinder.Eval(Container.DataItem,"addr_id") %>' />
                                                    </div>
                                                    <div class="col-md-3" style="text-align: right; padding: 0; margin: 0">
                                                        <asp:ImageButton ID="img_edit" runat="Server" ImageUrl="../image/images/copy.gif" CommandName="edit"
                                                            CommandArgument='<%#DataBinder.Eval(Container.DataItem,"addr_id") %>' />
                                                    </div>
                                                    <div class="col-md-6" style="text-align: right; padding: 0; margin: 0">
                                                        <asp:LinkButton ID="lbtn_set" runat="Server" Text="设为默认" CommandName="set" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"addr_id") %>'></asp:LinkButton>
                                                    </div>
                                                </div>
                                            </div>
                                        </ItemTemplate>
                                        <SeparatorTemplate>
                                            <div style="padding-left: 12px; padding-right: 12px;">
                                                <div style="margin-top: 10px; margin-bottom: 10px; height: 2px; background: #DADADA">
                                                </div>
                                            </div>
                                        </SeparatorTemplate>
                                        <FooterTemplate>
                                            <div style="padding-left: 12px; padding-right: 12px;">
                                                <div style="margin-top: 10px; margin-bottom: 10px; height: 2px; background: #DADADA">
                                                </div>
                                            </div>
                                        </FooterTemplate>
                                    </asp:DataList>
                                    <%if (address_record_count > 0)
                                      {
                                    %>
                                    <div style="text-align: right">
                                        <p style="text-align: right">
                                            总共<%=address_record_count %>条&nbsp;&nbsp;&nbsp;
                                            <%if (address_record_count > address_page_size)
                                              { %>
                                            每页<%=address_page_size%>条&nbsp;&nbsp;&nbsp;当前第<%=address_page_now%>页&nbsp;&nbsp;&nbsp;
                                            <%if (address_page_now != 1)
                                              {%>
                                            <a href="my-account-old.aspx?part=2&action=receive&pageNow=1">首页</a>&nbsp;&nbsp;&nbsp;
                                            <a href="my-account-old.aspx?part=2&action=receive&pageNow=<%=address_page_now-1 %>">上一页</a>&nbsp;&nbsp;&nbsp;
                                            <%} %>
                                            <%if (address_page_now != address_page_count)
                                              { %>
                                            <a href="my-account-old.aspx?part=2&action=receive&pageNow=<%=address_page_now+1 %>">下一页</a>&nbsp;&nbsp;&nbsp;
                                            <a href="my-account-old.aspx?part=2&action=receive&pageNow=<%=address_page_count %>">尾页</a>&nbsp;&nbsp;&nbsp;
                                            <%} %>
                                            <%} %>
                                        </p>
                                    </div>
                                    <%
                                      } %>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <%--第二部分中的地址操作部分--%>
                <%--编辑地址--%>
                <div class="col-md-9 col-md-offset-3" style="padding-right: 0" runat="Server" id="send_part_edit_address"
                    visible="false">
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            <h5>
                                编辑新地址</h5>
                        </div>
                        <div class="panel-body">
                            <div class="form-group">
                                <div class="col-md-3">
                                    <font color="#cc3399" style="font-weight: bold; font-size: 18px;">
                                        <asp:Label ID="edit_addressInfo" runat="Server" Text="新增发件地址"></asp:Label></font>
                                </div>
                                <div align="left" class="col-md-9">
                                    带<font color="#FF0000">*</font>为必填项，其余可不填<asp:Label ID="lb_addr_id" runat="Server"
                                        Visible="false"></asp:Label>
                                </div>
                            </div>
                            <div class="form-group" style="height: 2px; background: #DADADA">
                            </div>
                            <div class="form-group">
                                <label class="col-md-2 control-label">
                                    联系人名</label>
                                <div class="col-md-9">
                                    <asp:TextBox ID="txt_addr_contact" class="form-control contact" runat="Server"></asp:TextBox>
                                </div>
                                <div class="col-md-1" style="color:Red;padding-top:10px">*</div>
                            </div>
                            <div class="form-group">
                                <label class="col-md-2 control-label">
                                    公司名</label>
                                <div class="col-md-6">
                                    <asp:TextBox ID="txt_addr_company_name" class="form-control company" runat="Server"></asp:TextBox>
                                </div>
                                <div class="col-md-4" style="color:Red;padding-top:6px">* 如果不是公司请填联系人</div>
                            </div>
                            <div class="form-group">
                                <label class="col-md-2 control-label">
                                    地址1</label>
                                <div class="col-md-9">
                                    <asp:TextBox ID="txt_addr_line1" class="form-control line1" runat="Server"></asp:TextBox>
                                </div>
                                <div class="col-md-1" style="color:Red;padding-top:10px">*</div>
                            </div>
                            <div class="form-group">
                                <label class="col-md-2 control-label">
                                    地址2</label>
                                <div class="col-md-9">
                                    <asp:TextBox ID="txt_addr_line2" class="form-control line2" runat="Server"></asp:TextBox>
                                </div>
                                <div class="col-md-1" style="color:Red;padding-top:10px">&nbsp;</div>
                            </div>
                            <div class="form-group">
                                <label class="col-md-2 control-label">
                                    地址3</label>
                                <div class="col-md-9">
                                    <asp:TextBox ID="txt_addr_line3" runat="Server" class="form-control line3"></asp:TextBox>
                                </div>
                                <div class="col-md-1" style="color:Red;padding-top:10px">&nbsp;</div>
                            </div>
                            <div class="form-group">
                                <label class="col-md-2 control-label">
                                    城市</label>
                                <div class="col-md-9">
                                    <asp:TextBox ID="txt_addr_city" class="form-control city" runat="Server"></asp:TextBox>
                                </div>
                                <div class="col-md-1" style="color:Red;padding-top:10px">*</div>
                            </div>
                            <div class="form-group" style="height: 40px">
                                <label class="col-md-2 control-label">
                                    邮编</label>
                                <div class="col-md-9">
                                    <asp:TextBox runat="Server" class="form-control postcode" ID="txt_addr_postcode"></asp:TextBox>
                                </div>
                                <div class="col-md-1" style="color:Red;padding-top:10px">*</div>
                            </div>
                            <div class="form-group" style="height: 40px">
                                <label class="col-md-2 control-label">
                                    国家
                                </label>
                                <div class="col-md-9">
                                    <asp:TextBox runat="Server" class="form-control country" ID="txt_addr_country" ></asp:TextBox>
                                </div>
                                <div class="col-md-1" style="color:Red;padding-top:10px">*</div>
                            </div>
                            <div class="form-group" style="height: 40px">
                                <label class="col-md-2 control-label">
                                    手机号码</label>
                                <div class="col-md-9">
                                    <asp:TextBox ID="txt_addr_phone" runat="Server" class="form-control phone"></asp:TextBox>
                                </div>
                                <div class="col-md-1" style="color:Red;padding-top:10px">*</div>
                            </div>
                            <div class="form-group" style="height: 40px">
                                <label class="col-md-2 control-label">
                                    邮箱</label>
                                <div class="col-md-9">
                                    <asp:TextBox runat="Server" class="form-control email" ID="txt_addr_email"></asp:TextBox>
                                </div>
                                <div class="col-md-1" style="color:Red;padding-top:10px">*</div>
                            </div>
                            <div class="form-group">
                                <div class="col-md-2">
                                </div>
                                <div class="col-md-10">
                                    <div style="height: 25px; padding-left: 30px">
                                        <asp:CheckBox ID="ck_default" runat="Server" Text="&nbsp;设为默认"></asp:CheckBox>&nbsp;&nbsp;
                                        <asp:Button ID="btn_save" runat="Server" Text="保存" CssClass="btn btn-info save" OnClick="btn_save_Click">
                                        </asp:Button>
                                    </div>
                                </div>
                                
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <%--第三部分 订单查询--%>
            <div id="third" runat="Server" visible="false">
                <div class="col-md-9" style="padding-right: 0px">
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            <h5>
                                订单管理</h5>
                        </div>
                        <div class="row" style="margin-top: 20px; padding-left: 20px; padding-right: 20px"
                            id="query_by_time" runat="Server" visible="false">
                            <label class="col-md-1 control-label" style="vertical-align: middle">
                                From:</label>
                            <div class="col-md-2" style="padding-left: 0px; padding-right: 0px">
                                <asp:TextBox ID="txt_from" runat="Server" CssClass="form-control" onclick="new Calendar().show(this);"></asp:TextBox></div>
                            <label class="col-md-1 control-label" style="vertical-align: middle">
                                To:</label>
                            <div class="col-md-2" style="padding-left: 0px; padding-right: 0px">
                                <asp:TextBox ID="txt_to" runat="Server" CssClass="form-control" onclick="new Calendar().show(this);"></asp:TextBox></div>
                            <div class="col-md-2">
                                <asp:Button ID="btn_query" runat="Server" CssClass="btn btn-info" Text="查询订单" OnClick="btn_query_Click" /></div>
                            <div class="col-md-4" style="text-align: right">
                                <asp:Button ID="btn_query_all" runat="Server" CssClass="btn btn-info" Text="查询所有订单"
                                    OnClick="btn_query_all_Click" />
                            </div>
                        </div>
                        <div class="row" style="margin-top: 20px; padding-left: 20px; padding-right: 20px"
                            id="query_by_order" runat="Server" visible="false">
                            <div class="col-md-2" style="height: 160px; text-align: center; padding-top: 65px">
                                <label class="control-label" style="vertical-align: middle">
                                    订单号：</label>
                            </div>
                            <div class="col-md-8" style="height: 160px">
                                <p style="text-align: center">
                                    下面的输入框中可以输入多个订单号，订单号之间请用<font color="red">逗号(“，”)</font>隔开</p>
                                <textarea id="txt_order_number" name="txt_order_number" cols="40" rows="6" style="width: 100%;
                                    height: 140px; resize: none"></textarea>
                            </div>
                            <div class="col-md-2" style="height: 160px; padding-top: 65px">
                                <asp:Button ID="btn_query_by_order_number" runat="Server" Width="100%" Text="查询"
                                    OnClientClick="return isTextAreaNull()" CssClass="btn btn-info" OnClick="btn_query_by_order_number_Click" />
                            </div>
                        </div>
                        <div class="panel-body">
                            <%if (orders.Count > 0)
                              { %>
                            <table class="table table-striped " id="package" width="100%">
                                <thead>
                                    <tr>
                                        <th style="width: 8%; text-align: center">
                                            选择
                                        </th>
                                        <th style="width: 22%; text-align: center">
                                            订单号
                                        </th>
                                        <th style="width: 18%; text-align: center">
                                            收件人
                                        </th>
                                        <th style="width: 10%; text-align: center">
                                            包裹数
                                        </th>
                                        <th style="width: 14%; text-align: center">
                                            下单时间
                                        </th>
                                        <th style="width: 12%; text-align: center">
                                            付款金额
                                        </th>
                                        <th style="width: 8%; text-align: center">
                                            详情
                                        </th>
                                        <th style="width: 8%; text-align: center">
                                            下载
                                        </th>
                                    </tr>
                                </thead>
                                <%for (int i = 0; i < orders.Count; i++)
                                  {
                                      Order order = (Order)orders[i];
                                %>
                                <tr>
                                    <td style="width: 8%; text-align: center" valign="middle">
                                        <input type="checkbox" name="checkbox" value="<%=order.Order_number%>" />
                                    </td>
                                    <td style="width: 22%; text-align: center" valign="middle">
                                        <%=order.Order_number%>
                                    </td>
                                    <td style="width: 18%; text-align: center" valign="middle">
                                        <%=order.RecipientContactName%>
                                    </td>
                                    <td style="width: 10%; text-align: center" valign="middle">
                                        <%=order.Quantity%>
                                    </td>
                                    <td style="width: 14%; text-align: center" valign="middle">
                                        <%=order.Order_time.ToString("yyyy-MM-dd")%>
                                    </td>
                                    <td style="width: 12%; text-align: center" valign="middle">
                                        <%=order.Pay_after_discount%>
                                    </td>
                                    <td style="width: 8%; text-align: center" valign="middle">
                                        <%--<a target="_blank" href="order-detail-info.aspx?order_number=<%=order.Order_number %>&type=detail">
                                            详情</a>--%>
                                        <a href="my-order-detail-info.aspx?status=pay&order_number=<%=order.Order_number %>">
                                            详情</a>
                                    </td>
                                    <td style="width: 8%; text-align: center" valign="middle">
                                        <a target="_blank" href="order-detail-info.aspx?order_number=<%=order.Order_number %>&type=download">
                                            下载</a>
                                    </td>
                                </tr>
                                <%} %>
                                <tr>
                                    <td colspan="2" style="text-align: left">
                                        <input type="checkbox" id="select_all" name="select_all" onclick="quanxuan(this)"
                                            style="margin-left: 9px; margin-top: 10px" />全选
                                    </td>
                                    <td colspan="6" style="text-align: right">
                                        <%if (record_count > pageSize)
                                          {
                                        %>
                                        每页<%=pageSize%>条&nbsp;&nbsp;&nbsp;总共<%=record_count%>条&nbsp;&nbsp;&nbsp;当前第<%=pageNow%>页&nbsp;&nbsp;&nbsp;
                                        <%if (pageNow != 1)
                                          {%>
                                        <a href="my-account-old.aspx?part=3&action=query&pageNow=1">首页</a>&nbsp;&nbsp;&nbsp;
                                        <a href="my-account-old.aspx?part=3&action=query&pageNow=<%=pageNow-1 %>">上一页</a>&nbsp;&nbsp;&nbsp;
                                        <%} %>
                                        <% if (pageNow != page_count)
                                           {
                                        %><a href="my-account-old.aspx?part=3&action=time&pageNow=<%=pageNow+1 %>">下一页</a>&nbsp;&nbsp;&nbsp;
                                        <a href="my-account-old.aspx?part=3&action=time&pageNow=<%=page_count %>">尾页</a>&nbsp;&nbsp;&nbsp;
                                        <%} %>
                                        <%
                                          } %>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="8" style="text-align: right">
                                        <asp:Button ID="btn_download_select" runat="Server" CssClass="btn btn-info" Text="下载选中"
                                            OnClick="btn_download_select_Click" />
                                    </td>
                                </tr>
                            </table>
                            <%}
                              else
                              {%>
                            <p style="text-align: center; color: Red">
                                <%=message %></p>
                            <%} %>
                        </div>
                    </div>
                </div>
            </div>
            <%--第四部分 账户充值--%>
            <div id="forth" runat="Server" visible="false">
                <div class="col-md-9" style="padding-right: 0px">
                    <div calss="panel panel-primary" style="border-color: #E4E4E4" id="bonus" runat="server"
                        visible="false">
                        <div class="panel-heading">
                            <h5>
                                我的红包</h5>
                        </div>
                        <div class="panel-body">
                            <div>
                                情输入红包编号，领取红包</div>
                            <div>
                                <input type="text" /><input type="button" value="领取红包" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <%--第五部分 条码下载--%>
            <div id="fifth" runat="Server">
            </div>
        </div>
    </div>
</asp:Content>
