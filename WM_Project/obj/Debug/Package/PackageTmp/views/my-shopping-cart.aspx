<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/reception-stage/batch.Master" AutoEventWireup="true"
    CodeBehind="my-shopping-cart.aspx.cs" Inherits="WM_Project.views.my_shopping_cart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <%--此处写CSS、javascript代码--%>
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
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="center" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <%--购物车部分--%>
    <div class="row" style="margin:0 auto;">
        <div class="panel panel-primary" id="shooping_cart_user_login_part" runat="Server" visible="false" style="width:75%;margin:0 auto">
            <div class="panel-heading">
                <h3 class="panel-title">
                    User Login</h3>
            </div>
            <div class="panel-body">
                <div class="form-group" style="height:30px;margin-top:10px">
                    <label for="username" class="col-md-3 control-label" style="padding-top:6px;text-align:right">
                        User&nbsp;&nbsp;Name:</label>
                    <div class="col-md-7" style="padding-left:0px">
                        <input type="text" class="form-control" id="txt_username" name="txt_username" placeholder="please input user name" />
                    </div>
                    <div class="col-md-2" style="color: #FF0000;padding-top:10px">
                        *
                    </div>
                </div>
                <div class="form-group" style="height:30px">
                    <label for="password" class="col-md-3 control-label" style="padding-top:6px;text-align:right">
                        Password:</label>
                    <div class="col-md-7" style="padding-left:0px">
                        <input type="password" class="form-control" name="txt_password" id="txt_password"/>
                    </div>
                    <div class="col-md-2" style="color: #FF0000;padding-top:10px">
                        *
                    </div>
                </div>
                <div class="form-group" style="height:30px">
                    <label for="code" class="col-md-3 control-label" style="padding-top:6px;text-align:right">
                        Code:</label>
                    <div class="col-md-5" style="padding-left:0px">
                        <input type="text" class="form-control" name="txt_code" id="txt_code" />
                    </div>
                    <div class="col-md-2 " style="text-align:right"><img src="code.aspx" alt="" height="30px" onclick="this.src=this.src+'?'"/></div>
                    <div class="col-md-2" style="color: #FF0000;padding-top:10px">
                        *
                    </div>
                </div>
                
                <div class="form-group" style="height:30px;padding-top:20px">
                    <div style="text-align:center"><asp:Button ID="btn_login" runat="Server" Text="登陆" OnClientClick="return isNull();" 
                            CssClass="btn btn-info" onclick="btn_login_Click"/></div>
                </div>
            </div>
        </div>
    
    </div>
    <div class="row" runat="Server" id="shooping_cart_part">
        <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <div class="panel panel-primary" style="width: 990px; margin-left: 0px;font-size:12px">
                    <div class="panel-heading">
                        <h3 class="panel-title">
                            我的购物车</h3>
                    </div>
                    <div class="panel-body" style="padding-left: 0px; padding-right: 0px">
                        <div id="cart_part" runat="Server" style="border-bottom: 5px solid #E4E4E4; border-top: 5px solid #E4E4E4;
                            width: 990px">
                            <asp:DataList ID="my_cart_datalist" runat="Server" OnItemCommand="my_cart_ItemCommand">
                                <HeaderTemplate>
                                    <div style="width: 988px; padding-top: 5px; padding-bottom: 5px; height: 30px">
                                        <div style="width: 16%; float: left; font-weight: 600; text-align: center">
                                            订单号
                                        </div>
                                        <div style="width: 9%; float: left; font-weight: 600; text-align: center">
                                            发件人
                                        </div>
                                        <div style="width: 11%; float: left; font-weight: 600; text-align: center">
                                            收件人
                                        </div>
                                        <div style="width: 9%; float: left; font-weight: 600; text-align: center">
                                            收件电话
                                        </div>
                                        <div style="width: 6%; float: left; font-weight: 600; text-align: center">
                                            包裹个数
                                        </div>
                                        <div style="width: 7%; float: left; font-weight: 600; text-align: center">
                                            包裹重
                                        </div>
                                        <div style="width: 8%; float: left; font-weight: 600; text-align: center">
                                            付款金额
                                        </div>
                                        <div style="width: 14%; float: left; font-weight: 600; text-align: center">
                                            服务方式
                                        </div>
                                        <div style="width: 12%; float: left; font-weight: 600; text-align: center">
                                            下单时间
                                        </div>
                                        <div style="width: 4%; float: left; font-weight: 600; text-align: center">
                                            详情
                                        </div>
                                        <div style="width: 4%; float: left; font-weight: 600; text-align: center">
                                            删除
                                        </div>
                                    </div>
                                    <div style="background: #E4E4E4; height: 5px">
                                    </div>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <div style="clear: both; padding-top: 5px; padding-bottom: 5px; height: 30px">
                                        <div style="width: 16%; float: left; text-align: center">
                                            <asp:HiddenField ID="hidden" Value='<%#DataBinder.Eval(Container.DataItem,"order_number") %>'
                                                runat="Server" />
                                            <%#DataBinder.Eval(Container.DataItem,"order_number") %>
                                        </div>
                                        <div style="width: 9%; float: left; text-align: center">
                                            <%#DataBinder.Eval(Container.DataItem,"sender") %>
                                        </div>
                                        <div style="width: 11%; float: left; text-align: center">
                                            <%#DataBinder.Eval(Container.DataItem,"receiver") %>
                                        </div>
                                        <div style="width: 9%; float: left; text-align: center;color:#FF0000">
                                            <%#DataBinder.Eval(Container.DataItem,"phone") %>
                                        </div>
                                        <div style="width: 6%; float: left; text-align: center">
                                            <%#DataBinder.Eval(Container.DataItem,"quantity") %>
                                        </div>
                                        <div style="width: 7%; float: left; text-align: center">
                                            <%#DataBinder.Eval(Container.DataItem,"weight") %>
                                        </div>
                                        <div style="width: 8%; float: left; text-align: center">
                                            <asp:Label ID="item_money" runat="Server" Text='<%#DataBinder.Eval(Container.DataItem,"pay") %>'></asp:Label>
                                        </div>
                                        <div style="width: 14%; float: left; text-align: center">
                                            <%#DataBinder.Eval(Container.DataItem,"postway") %>
                                        </div>
                                        <div style="width: 12%; float: left; text-align: center">
                                            <%#DataBinder.Eval(Container.DataItem,"time") %>
                                        </div>
                                        <div style="width: 4%; float: left; text-align: center">
                                            <asp:ImageButton ID="detail" runat="Server" ImageUrl="../image/images/copy.gif" CommandName="detail"
                                                CommandArgument='<%#DataBinder.Eval(Container.DataItem,"order_number") %>' />
                                        </div>
                                        <div style="width: 4%; float: left; text-align: center">
                                            <asp:ImageButton ID="delete" runat="Server" ImageUrl="../image/images/del.jpg" CommandName="delete"
                                                CommandArgument='<%#DataBinder.Eval(Container.DataItem,"order_number") %>' />
                                        </div>
                                    </div>
                                </ItemTemplate>
                                <SeparatorTemplate>
                                    <div style="height: 5px; background: #E4E4E4">
                                    </div>
                                </SeparatorTemplate>
                                <FooterTemplate>
                                    <div style="height: 5px; background: #E4E4E4">
                                    </div>
                                </FooterTemplate>
                            </asp:DataList>
                            <div class="row">
                                <%--<div style="text-align: center; height: 30px; padding-right: 30px; font-weight: 600"
                                    class="col-md-3 col-md-offset-2">
                                    <font color="#3A83C2">取件包裹个数：</font><asp:Label ID="lb_delivery_count" runat="Server"></asp:Label></div>
                                

                                <div style="text-align: center; height: 30px; padding-right: 30px; font-weight: 600"
                                    class="col-md-3">
                                    <font color="#3A83C2">取件费用：</font>£<asp:Label ID="lb_delivery_money" runat="Server"></asp:Label></div>--%>


                                <div style="text-align: right; height: 30px; padding-right: 60px; font-weight: 600"
                                    class="col-md-8">
                                    <font color="#3A83C2">您总共需付款：</font>£<asp:Label ID="lb_money" runat="Server"></asp:Label></div>
                            </div>
                            <div class="form-group" style="background: #DADADA; height: 2px">
                            </div>
                            <div class="form-group" style="height: 45px">
                                <div class="col-md-6" style="padding-top: 16px; font-weight: 600; font-size: 20px">
                                    <a href="index.aspx" style="text-decoration:underline">继续下单</a></div>
                                <div style="text-align: right; padding-right: 20px; padding-top: 10px" class="col-md-6">
                                    <asp:Button ID="btn_pay" runat="Server" CssClass="btn btn-info" Text="付款" OnClick="btn_pay_Click" /></div>
                            </div>
                            <div class="form-group" style="height: 45px">
                                <div style="text-align: right; padding-right: 20px; text-align: center">
                                    <asp:Button ID="btn_clear_cart" runat="Server" CssClass="btn btn-info" Text="清空购物车"
                                        OnClick="btn_clear_cart_Click" /></div>
                            </div>
                        </div>
                        <div id="no_order" runat="Server" class="form-group" style="height: 200px" visible="false">
                            <div style="height: 170px; text-align: center; padding-top: 80px; font-weight: 600;
                                font-size: 20px; color: Red">
                                您好，您目前没有订单！！
                            </div>
                            <div style="height: 30px; padding-left: 30px; font-size: 20px; font-weight: 600">
                                <a href="index.aspx" style="text-decoration:underline">现在下单</a></div>
                        </div>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
