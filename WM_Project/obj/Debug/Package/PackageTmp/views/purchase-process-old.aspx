<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/reception-stage/batch.Master" AutoEventWireup="true"
    CodeBehind="purchase-process-old.aspx.cs" Inherits="WM_Project.views.purchase_process_old" %>

<%@ Import Namespace="WM_Project.logical.common" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../script/jquery-1.11.1.js" type="text/javascript"></script>
    <script src="../script/jquery-1.4.2.min.js" type="text/javascript"></script>
    <script src="../script/Calendar3.js" type="text/javascript"></script>
    <style type="text/css">
        .select
        {
            word-break: break-all; /*支持IE，chrome，FF不支持*/
            word-wrap: break-word; /*支持IE，chrome，FF*/
        }
    </style>
    <%--jquery代码--%>
    <script type="text/javascript">


        $(document).ready(function () {

            var dd = new Date();
            dd.setDate(dd.getDate() + 1);
            var y = dd.getFullYear();
            var m = dd.getMonth() + 1;
            var d = dd.getDate();

            $("#delivery_date").val(y + "-" + m + "-" + d);


            $(".btn-xs").click(function () {

                var description = $(this).parent().parent().parent().parent().find(".description");

                var Allvalue = $(this).parent().parent().parent().parent().find(".Allvalue");
                for (var ii = 1; ii < description.length; ii++) {

                    description.eq(ii).val(description.eq(0).val());
                    Allvalue.eq(ii).val(Allvalue.eq(0).val());
                }

            });


            $(".delivery_way_select").change(function () {

                if ($(".delivery_way_select option:selected").val() == "Collection") {

                    text_date = $("#delivery_date")
                    text_date.removeAttr("disabled", "disabled");

                    var dd = new Date();
                    dd.setDate(dd.getDate() + 1);
                    var y = dd.getFullYear();
                    var m = dd.getMonth() + 1;
                    var d = dd.getDate();

                    text_date.val(y + "-" + m + "-" + d);

                    text_time = $("#delivery_time");
                    text_time.removeAttr("disabled", "disabled");
                }
                else {
                    text_date = $("#delivery_date");
                    text_date.val("");
                    text_date.attr("disabled", "disabled");

                    text_time = $("#delivery_time");
                    text_time.val("9:00-12:00");
                    text_time.attr("disabled", "disabled");
                }
            });

        });



    </script>
    <%--javascript代码--%>
    <script type="text/javascript">

        /*判断用户是否填写取件方式、包裹信息*/
        function isPageOneNull() {

            var way = document.getElementById("delivery_way").value;
            if (way == "") {
                alert("请选择取件方式！！");
                return false;
            }
            else if (way == "Collection") {
                var date = document.getElementById("delivery_date").value;
                if (date == "") {
                    alert("请填写取件日期!!");
                    return false;
                } else {
                    var time = document.getElementById("delivery_time").value;
                    if (time == "") {
                        alert("请选择取件时间！！");
                        return false;
                    }
                }
            }

            var contents = document.getElementsByName("content");
            var package_values = document.getElementsByName("package_value");

            for (i = 0; i < contents.length; i++) {

                if (contents[i].value == "") {
                    alert("包裹描述不能为空！！");
                    return false;
                }
            }

            for (j = 0; j < package_values.length; j++) {
                if(package_values[j].value==""){
                    alert("请填写包裹价值！！");
                    return false;
                }
                else if (!isUnsignedNumeric((package_values[j].value).trim())) {
                    alert("包裹价值请填写数字!!");
                    return false;
                }
            }

            return true;
        }


        /*
        *	验证是否是正实数,不包括 0 
        */
        function isUnsignedNumeric(strNumber) {
            if (strNumber != 0) {
                var newPar = /^\d+(\.\d+)?$/;
                return newPar.test(strNumber);
            }
            else {
                return false;
            }

        }


        /*判断用户在保存地址信息时是否填写了必填项*/
        //保存发件地址信息时的发件地址信息验证
        function isSendAddressWrite() {

            var contact = document.getElementById('<%=txt_send_addr_contact.ClientID %>').value;
            var company = document.getElementById('<%=txt_send_addr_company.ClientID %>').value;
            var addr_line = document.getElementById('<%=txt_send_addr_line1.ClientID %>').value;
            var city = document.getElementById('<%=txt_send_addr_city.ClientID %>').value;
            var postcode = document.getElementById('<%=txt_send_addr_postcode.ClientID %>').value;
            var country = document.getElementById('<%=txt_send_addr_country.ClientID %>').value;
            var phone = document.getElementById('<%=txt_send_addr_phone.ClientID %>').value;
            var email = document.getElementById('<%=txt_send_addr_email.ClientID %>').value;

            if (contact.trim() == "" || company.trim() == "" || addr_line.trim() == "" || city.trim() == "" || postcode.trim() == "" || country.trim() == "" || phone.trim() == "" || email.trim() == "") {
                alert("带 * 号的不能为空！！");
                return false;
            }

            return true;
        }

        //保存收件地址信息时的信息验证
        function isReceiveAddressWrite() {
            var contact = document.getElementById('<%=txt_receive_addr_contact.ClientID %>').value;
            var company = document.getElementById('<%=txt_receive_addr_company.ClientID %>').value;
            var addr_line = document.getElementById('<%=txt_receive_addr_line1.ClientID %>').value;
            var city = document.getElementById('<%=txt_receive_addr_city.ClientID %>').value;
            var postcode = document.getElementById('<%=txt_receive_addr_postcode.ClientID %>').value;
            var country = document.getElementById('<%=txt_receive_addr_country.ClientID %>').value;
            var phone = document.getElementById('<%=txt_receive_addr_phone.ClientID %>').value;
            var email = document.getElementById('<%=txt_receive_addr_email.ClientID %>').value;

            if (contact.trim() == "" || company.trim() == "" || addr_line.trim() == "" || city.trim() == "" || postcode.trim() == "" || country.trim() == "" || phone.trim() == "" || email.trim() == "") {
                alert("带 * 号的不能为空！！");
                return false;
            }

            return true;
        }



        /*判断用户是否同意服务条款*/
        function isTremsAgree() {

            var item1 = document.getElementById("checkbox_item_first");
            var item2 = document.getElementById("checkbox_item_second");

            if (item1.checked == false || item2.checked == false) {

                alert("请同意服务款，否则你将无法购买！！");
                return false;
            }

            return true;

        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="center" runat="server">
    <div runat="Server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <%--上门取件or自己投送  and 包裹详细信息--%>
        <div class="row" id="page_one" runat="Server" visible="false">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    <h5 class="panel-title">
                        请选择取件方式</h5>
                </div>
                <div class="panel-body" runat="server">
                    <div class="col-md-4">
                        取件方式：<select class="delivery_way_select" id="delivery_way" name="delivery_way">
                            <option value="Collection">Collection</option>
                            <option value="Delivery">Delivery</option>
                        </select></div>
                    <div class="col-md-4">
                        取件日期：<input type="text" id="delivery_date" class="delivery_date" name="delivery_date"
                            onclick="new Calendar().show(this);" /></div>
                    <div class="col-md-4">
                        取件时间：<select name="delivery_time" id="delivery_time">
                            <option>9:00-12:00</option>
                            <option>14:00-18:00</option>
                            <option>9:00-18:00</option>
                        </select></div>
                </div>
            </div>
            <div class="panel panel-primary">
                <div class="panel-heading">
                    <h3 class="panel-title">
                        请填写包裹的详细信息</h3>
                </div>
                <div class="panel-body">
                    <%for (int i = 0; i < good_arrays.Count; i++)
                      {
                          PackageMeasure good = (PackageMeasure)good_arrays[i];
                    %>
                    <table class="table table-striped ">
                        <tr style="text-align: left">
                            <td colspan="5" style="width: 100%; text-align: left">
                                <label class="col-md-8 control-label">
                                    包裹<%=i + 1%>:#<%=good.Count %>*<%=good.Weight %>*<%=good.Length %>*<%=good.Width %>*<%=good.Height %></label>
                                <span class="col-md-4" style="text-align:right"><input type="button" class="btn-danger btn-xs" style="height:30px;width:200px" value="将第一箱信息复制到其他箱"/></span>
                            </td>
                        </tr>
                        <%
                          for (int j = 0; j < good.Count; j++)
                          { %>
                        <tr>
                            <td class="panel-title" style="padding-left: 40px; width: 16%; text-align: left">
                                <label style="padding-top: 5px">
                                    第<%= j+1%>箱</label>
                            </td>
                            <td style="width: 8%; padding-right: 0px;text-align:right">
                                <label style="padding-top: 5px">
                                    描述：</label>
                            </td>
                            <td style="width: 40%; padding-left: 0px; text-align: left">
                                <input type="text" name="content" class="form-control description" />
                            </td>
                            <td style="width: 16%;text-align:right">
                                <label style="padding-top: 5px">
                                    总价值￡：</label>
                            </td>
                            <td style="width: 20%; padding-left: 0px; text-align: left">
                                <input type="text" name="package_value" class="form-control Allvalue" />
                            </td>
                        </tr>
                        <%} %>
                    </table>
                    <%} %>
                    <div class="form-group" style="text-align: center; margin-top: 10px">
                        <asp:Button ID="btn_next" runat="Server" Text="下一步" CssClass="btn btn-info" OnClientClick="return isPageOneNull()"
                            OnClick="btn_next_Click" />
                    </div>
                </div>
            </div>
        </div>
        <%--地址编辑部分--%>
        <div class="row" id="page_two" runat="Server" visible="false">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            <h5>
                                请选择发件地址及收件地址</h5>
                        </div>
                        <div class="panel-body">
                            <%--选择发件地址--%>
                            <div id="select_send" runat="Server" class="select">
                                <div class="form-group" style="height: 20px">
                                    <div class="col-md-6" style="height: 20px; font-size: 18px; font-weight: 700; padding-left: 0px;">
                                        发件地址</div>
                                    <div class="col-md-6">
                                    </div>
                                </div>
                                <div class="form-group" style="height: 2px; background: #DADADA">
                                </div>
                                <div class="form-group" style="clear: both; margin-top: 10px">
                                    <asp:DataList ID="sendaddressInfo" runat="Server" BorderWidth="0px" RepeatColumns="4"
                                        RepeatDirection="Horizontal" class="form-group" OnItemCommand="sendaddressInfo_ItemCommand">
                                        <ItemTemplate>
                                            <div style="border: 1px solid #DADADA; margin: 0; margin-bottom: 10px; margin-right: 10px;
                                                padding-left: 0px; padding-right: 0px; width: 237px">
                                                <table border="0" cellspacing="0" cellpadding="0" width="100%">
                                                    <tr style="height:20px;">
                                                        <td colspan="2" style="text-align: left; vertical-align: top; padding-left: 5px;
                                                            padding-right: 5px">
                                                            <%#DataBinder.Eval(Container.DataItem, "senderInfo")%>
                                                        </td>
                                                    </tr>
                                                    <tr style="height: 60px">
                                                        <td valign="top" colspan="2" style="text-align: left; vertical-align: top; padding-left: 5px;
                                                            padding-right: 5px">
                                                            <%#DataBinder.Eval(Container.DataItem,"detailInfo") %>
                                                        </td>
                                                    </tr>
                                                    <tr style="height: 20px">
                                                        <td style="width: 40%; text-align: left; padding-left: 5px">
                                                            <asp:LinkButton ID="lbtn_alter" runat="Server" Text="修改" CommandName="alter_info"
                                                                CommandArgument='<%#DataBinder.Eval(Container.DataItem,"addr_id") %>'></asp:LinkButton>
                                                        </td>
                                                        <td style="width: 60%; text-align: right; padding-right: 5px">
                                                            <asp:HiddenField ID="hidden" runat="Server" Value='<%#DataBinder.Eval(Container.DataItem,"addr_id") %>'>
                                                            </asp:HiddenField>
                                                            <asp:CheckBox ID="ck_Send" runat="Server" Text="选用" ForeColor="#000000" Font-Size="14px"
                                                                Font-Bold="false" CommandName="checkbox" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"addr_id") %>'
                                                                OnCheckedChanged="ck_Send_Click" AutoPostBack="True"></asp:CheckBox>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                    </asp:DataList>
                                    <table border="0" cellspacing="0" cellpadding="0" width="100%">
                                        <tr style="height: 2px">
                                            <td style="height: 2px; background: #DADADA">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: left; padding-top: 10px">
                                                <asp:Button ID="btn_OperateSendAddress" runat="Server" Text="显示更多地址" CssClass="btn btn-info"
                                                    OnClick="btn_OperateSendAddress_Click"></asp:Button>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </div>
                            <%--填写新的发件地址--%>
                            <div style="border: 2px solid #DADADA; width: 75%; margin-left: 12%; margin-top: 20px"
                                id="edit_send_address" runat="Server">
                                <div class="form-group" style="height: 30px; padding-top: 10px">
                                    <div class="col-md-3">
                                        <font color="#cc3399" style="font-weight: bold; font-size: 18px;">
                                            <asp:Label ID="edit_send_address_info" runat="Server" Text="新增发件地址"></asp:Label></font>
                                    </div>
                                    <div align="left" class="col-md-8">
                                        带*为必填项，其余可不填<asp:Label ID="lb_send_addr_id" runat="Server" Visible="false"></asp:Label>
                                    </div>
                                </div>
                                <div class="form-group" style="height: 2px; background: #DADADA">
                                </div>
                                <div class="form-group" style="height: 30px; padding-bottom: 10px;clear:both">
                                    <label class="col-md-3 control-label" style="padding-top: 10px; padding-left: 40px">
                                        发件人</label>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txt_send_addr_contact" class="form-control" runat="Server"></asp:TextBox>
                                    </div>
                                    <div class="col-md-1" style="color: Red; padding-top: 10px">
                                        *</div>
                                </div>
                                <div class="form-group" style="height: 30px; padding-bottom: 10px;clear:both">
                                    <label class="col-md-3 control-label" style="padding-top: 10px; padding-left: 40px">
                                        公司名</label>
                                    <div class="col-md-5">
                                        <asp:TextBox ID="txt_send_addr_company" class="form-control" runat="Server"></asp:TextBox>
                                    </div>
                                    <div class="col-md-4" style="color: Red; padding-top: 10px">
                                        * 如果不是公司请填写发件人</div>
                                </div>
                                <div class="form-group" style="height: 30px; padding-bottom: 10px;clear:both">
                                    <label class="col-md-3 control-label" style="padding-top: 10px; padding-left: 40px">
                                        地址1</label>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txt_send_addr_line1" class="form-control" runat="Server"></asp:TextBox>
                                    </div>
                                     <div class="col-md-1" style="color: Red; padding-top: 10px">
                                        *</div>
                                </div>
                                <div class="form-group" style="height: 30px; padding-bottom: 10px;clear:both">
                                    <label class="col-md-3 control-label" style="padding-top: 10px; padding-left: 40px">
                                        地址2</label>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txt_send_addr_line2" class="form-control" runat="Server"></asp:TextBox>
                                    </div>
                                    <div class="col-md-1" style="color: Red; padding-top: 10px">
                                        &nbsp;</div>
                                </div>
                                <div class="form-group" style="height: 30px; padding-bottom: 10px;clear:both">
                                    <label class="col-md-3 control-label" style="padding-top: 10px; padding-left: 40px">
                                        地址3</label>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txt_send_addr_line3" runat="Server" class="form-control"></asp:TextBox>
                                    </div>
                                    <div class="col-md-1" style="color: Red; padding-top: 10px">
                                        &nbsp;</div>
                                </div>
                                <div class="form-group" style="height: 30px; padding-bottom: 10px;clear:both">
                                    <label class="col-md-3 control-label" style="padding-top: 10px; padding-left: 40px">
                                        城市</label>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txt_send_addr_city" class="form-control" runat="Server"></asp:TextBox>
                                    </div>
                                    <div class="col-md-1" style="color: Red; padding-top: 10px">
                                        *</div>
                                </div>
                                <div class="form-group" style="height: 40px;clear:both">
                                    <label class="col-md-3 control-label" style="padding-top: 10px; padding-left: 40px">
                                        邮编</label>
                                    <div class="col-md-8">
                                        <asp:TextBox runat="Server" class="form-control" ID="txt_send_addr_postcode"></asp:TextBox>
                                    </div>
                                    <div class="col-md-1" style="color: Red; padding-top: 10px">
                                        *</div>
                                </div>
                                <div class="form-group" style="height: 40px;clear:both">
                                    <label class="col-md-3 control-label" style="padding-top: 10px; padding-left: 40px">
                                        国家</label>
                                    <div class="col-md-8">
                                        <asp:TextBox runat="Server" class="form-control" ID="txt_send_addr_country" ReadOnly="true" Text="UK"></asp:TextBox>
                                    </div>
                                    <div class="col-md-1" style="color: Red; padding-top: 10px">
                                        *</div>
                                </div>
                                <div class="form-group" style="height: 40px;clear:both">
                                    <label class="col-md-3 control-label" style="padding-top: 10px; padding-left: 40px">
                                        手机号码</label>
                                    <div class="col-md-8">
                                        <asp:TextBox runat="Server" class="form-control" ID="txt_send_addr_phone"></asp:TextBox>
                                    </div>
                                    <div class="col-md-1" style="color: Red; padding-top: 10px">
                                        *</div>
                                </div>
                                <div class="form-group" style="height: 40px;clear:both">
                                    <label class="col-md-3 control-label" style="padding-top: 10px; padding-left: 40px">
                                        邮箱</label>
                                    <div class="col-md-8">
                                        <asp:TextBox runat="Server" class="form-control" ID="txt_send_addr_email"></asp:TextBox>
                                    </div>
                                    <div class="col-md-1" style="color: Red; padding-top: 10px">
                                        *</div>
                                </div>
                                <div class="form-group" style="height: 40px; padding-bottom: 10px;clear:both">
                                    <div class="col-md-3" style="padding-top: 10px; padding-left: 40px">
                                        <asp:CheckBox ID="ck_send_default" runat="Server" Text="&nbsp;&nbsp;设为默认"></asp:CheckBox>
                                    </div>
                                    <div class="col-md-9">
                                        <div style="height: 25px; text-align: center;">
                                            <asp:Button ID="btn_send_save" runat="Server" Text="保存" CssClass="btn btn-info" OnClick="btn_send_save_Click" OnClientClick="return isSendAddressWrite()">
                                            </asp:Button>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <%--中间分隔--%>
                            <div style="height: 10px; background: #DADADA; margin-top: 20px; margin-bottom: 20px">
                            </div>
                            <%--选择收件地址--%>
                            <div id="select_receive" runat="Server" class="select" style="margin-bottom: 20px">
                                <div class="form-group" style="height: 20px">
                                    <div class="col-md-6" style="height: 20px; font-size: 18px; font-weight: 700; padding-left: 0px;">
                                        收件地址</div>
                                    <div class="col-md-6">
                                    </div>
                                </div>
                                <div class="form-group" style="height: 2px; background: #DADADA">
                                </div>
                                <div class="form-group" style="clear: both">
                                    <asp:DataList ID="receiveaddressInfo" runat="Server" BorderWidth="0px" RepeatColumns="4"
                                        RepeatDirection="Horizontal" OnItemCommand="receiveaddressInfo_ItemCommand">
                                        <ItemTemplate>
                                            <div id="receiveaddress_info" runat="Server" style="border: 1px solid #DADADA; margin: 0;
                                                margin-bottom: 10px; margin-right: 10px; padding-left: 0px; padding-right: 0px;
                                                width: 237px">
                                                <table border="0" cellspacing="0" cellpadding="0" width="100%">
                                                    <tr style="height: 20px">
                                                        <td style="text-align: left; vertical-align: top; padding-left: 5px; padding-right: 5px"
                                                            colspan="2">
                                                            <%#DataBinder.Eval(Container.DataItem, "receiverInfo")%>
                                                        </td>
                                                    </tr>
                                                    <tr style="height: 60px">
                                                        <td style="text-align: left; vertical-align: top; padding-left: 5px; padding-right: 5px"
                                                            colspan="2">
                                                            <%#DataBinder.Eval(Container.DataItem,"detailInfo") %>
                                                        </td>
                                                    </tr>
                                                    <tr style="height: 20px">
                                                        <td style="width: 40%; text-align: left; padding-left: 5px">
                                                            <asp:LinkButton ID="lbtn_alterReceive" runat="Server" Text="修改" CommandName="alter_info"
                                                                CommandArgument='<%#DataBinder.Eval(Container.DataItem,"addr_id") %>'></asp:LinkButton>
                                                        </td>
                                                        <td style="width: 60%; text-align: right; padding-right: 5px">
                                                            <asp:HiddenField ID="hidden" runat="Server" Value='<%#DataBinder.Eval(Container.DataItem,"addr_id") %>'>
                                                            </asp:HiddenField>
                                                            <asp:CheckBox ID="ck_Receive" runat="Server" Text="选用" CommandName="checkbox" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"addr_id") %>'
                                                                OnCheckedChanged="ck_Receive_Click" AutoPostBack="True"></asp:CheckBox>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                    </asp:DataList>
                                    <table border="0" cellspacing="0" cellpadding="0" width="100%">
                                        <tr style="height: 2px">
                                            <td style="height: 2px; border: 2px solid #DADADA;">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: left; padding-top: 10px">
                                                <asp:Button ID="btn_OperateReceiveAddress" runat="Server" Text="显示更多地址" CssClass="btn btn-info"
                                                    OnClick="btn_OperateReceiveAddress_Click"></asp:Button>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </div>
                            <%--填写新的收件地址--%>
                            <div style="border: 2px solid #DADADA; width: 75%; margin-left: 12%" id="edit_receive_address"
                                runat="Server">
                                <div class="form-group" style="height: 30px; padding-top: 10px">
                                    <div class="col-md-3">
                                        <font color="#cc3399" style="font-weight: bold; font-size: 18px;">
                                            <asp:Label ID="edit_receive_address_info" runat="Server" Text="新增收件地址"></asp:Label></font>
                                    </div>
                                    <div align="left" class="col-md-8">
                                        带*为必填项，其余可不填<asp:Label ID="lb_receive_addr_id" runat="Server" Visible="false"></asp:Label>
                                    </div>
                                </div>
                                <div class="form-group" style="height: 2px; background: #DADADA">
                                </div>
                                <div class="form-group" style="height: 30px; padding-bottom: 10px;clear:both">
                                    <label class="col-md-3 control-label" style="padding-top: 10px; padding-left: 40px">
                                        收件人</label>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txt_receive_addr_contact" class="form-control" runat="Server"></asp:TextBox>
                                    </div>
                                    <div class="col-md-1" style="color: Red; padding-top: 10px">
                                        *</div>
                                </div>
                                <div class="form-group" style="height: 30px; padding-bottom: 10px;clear:both">
                                    <label class="col-md-3 control-label" style="padding-top: 10px; padding-left: 40px">
                                        公司名</label>
                                    <div class="col-md-5">
                                        <asp:TextBox ID="txt_receive_addr_company" class="form-control" runat="Server"></asp:TextBox>
                                    </div>
                                    <div class="col-md-4" style="color: Red; padding-top: 10px">
                                        * 如果不是公司请填写收件人</div>
                                </div>
                                <div class="form-group" style="height: 30px; padding-bottom: 10px;clear:both">
                                    <label class="col-md-3 control-label" style="padding-top: 10px; padding-left: 40px">
                                        地址1</label>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txt_receive_addr_line1" class="form-control" runat="Server"></asp:TextBox>
                                    </div>
                                    <div class="col-md-1" style="color: Red; padding-top: 10px">
                                        *</div>
                                </div>
                                <div class="form-group" style="height: 30px; padding-bottom: 10px;clear:both">
                                    <label class="col-md-3 control-label" style="padding-top: 10px; padding-left: 40px">
                                        地址2</label>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txt_receive_addr_line2" class="form-control" runat="Server"></asp:TextBox>
                                    </div>
                                    <div class="col-md-1" style="color: Red; padding-top: 10px">
                                        &nbsp;</div>
                                </div>
                                <div class="form-group" style="height: 30px; padding-bottom: 10px;clear:both">
                                    <label class="col-md-3 control-label" style="padding-top: 10px; padding-left: 40px">
                                        地址3</label>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txt_receive_addr_line3" runat="Server" class="form-control"></asp:TextBox>
                                    </div>
                                    <div class="col-md-1" style="color: Red; padding-top: 10px">
                                        &nbsp;</div>
                                </div>
                                <div class="form-group" style="height: 30px; padding-bottom: 10px;clear:both">
                                    <label class="col-md-3 control-label" style="padding-top: 10px; padding-left: 40px">
                                        城市</label>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txt_receive_addr_city" class="form-control" runat="Server"></asp:TextBox>
                                    </div>
                                    <div class="col-md-1" style="color: Red; padding-top: 10px">
                                        *</div>
                                </div>
                                <div class="form-group" style="height: 40px;clear:both">
                                    <label class="col-md-3 control-label" style="padding-top: 10px; padding-left: 40px">
                                        邮编</label>
                                    <div class="col-md-8">
                                        <asp:TextBox runat="Server" class="form-control" ID="txt_receive_addr_postcode"></asp:TextBox>
                                    </div>
                                    <div class="col-md-1" style="color: Red; padding-top: 10px">
                                        *</div>
                                </div>
                                <div class="form-group" style="height: 40px;clear:both">
                                    <label class="col-md-3 control-label" style="padding-top: 10px; padding-left: 40px">
                                        国家</label>
                                    <div class="col-md-8">
                                        <asp:TextBox runat="Server" class="form-control" ID="txt_receive_addr_country"></asp:TextBox>
                                    </div>
                                    <div class="col-md-1" style="color: Red; padding-top: 10px">
                                        *</div>
                                </div>
                                <div class="form-group" style="height: 40px;clear:both">
                                    <label class="col-md-3 control-label" style="padding-top: 10px; padding-left: 40px">
                                        手机号码</label>
                                    <div class="col-md-8">
                                        <asp:TextBox runat="Server" class="form-control" ID="txt_receive_addr_phone"></asp:TextBox>
                                    </div>
                                    <div class="col-md-1" style="color: Red; padding-top: 10px">
                                        *</div>
                                </div>
                                <div class="form-group" style="height: 40px;clear:both">
                                    <label class="col-md-3 control-label" style="padding-top: 10px; padding-left: 40px">
                                        邮箱</label>
                                    <div class="col-md-8">
                                        <asp:TextBox runat="Server" class="form-control" ID="txt_receive_addr_email"></asp:TextBox>
                                    </div>
                                    <div class="col-md-1" style="color: Red; padding-top: 10px">
                                        *</div>
                                </div>
                                <div class="form-group" style="height: 40px;clear:both">
                                    <div class="col-md-3" style="padding-top: 10px; padding-left: 40px">
                                        <asp:CheckBox ID="ck_receive_default" runat="Server" Text="&nbsp;&nbsp;设为默认"></asp:CheckBox>
                                    </div>
                                    <div class="col-md-9">
                                        <div style="height: 25px; text-align: center;">
                                            <asp:Button ID="btn_receive_save" runat="Server" Text="保存" CssClass="btn btn-info"
                                                OnClick="btn_receive_save_Click" OnClientClick="return isReceiveAddressWrite()"></asp:Button>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
            <div class="panel panel-primary" style="margin-top: 30px;">
                <div class="panel-heading">
                    <h3 class="panel-title">
                        特别注意事项及服务条款</h3>
                </div>
                <div class="panel-body">
                    <div class="form-group" style="margin-top: 30px">
                        <p style="padding-left: 15px; padding-right: 10px; font-family: @Adobe 楷体 Std R;
                            font-size: 18px">
                            在您下单之前，您需要认证阅读并同意一下条款，确定您的快递物品没有违反国际运输相关条例 并且检查你所申报的物品是否符合相关保险条款。
                        </p>
                        <p style="padding-left: 15px; padding-right: 10px; margin-top: 20px">
                            <input type="checkbox" id="checkbox_item_first" />
                            I confirm that I have provided accurate weight(s) and dimension(s) of my parcel(s)
                            to my best knowledge. I agree that if the weight(s) and/or dimension(s) of my parcel(s)
                            is/are incorrect, addtional charges i.e.the postage difference and additional charges(150%
                            of the difference) will be applied to my card based on information provided by the
                            courier. Check here to confirm above details are correct*
                        </p>
                        <p style="padding-left: 15px; padding-right: 10px">
                            <input type="checkbox" id="checkbox_item_second" />
                            I agreed to the <a href="package-advice.aspx">terms and conditions</a> , privacy
                            policy and no-compensation basis carriage. I confirm that my parcel(s) do not contain
                            any prohibited or restricted items. *
                        </p>
                    </div>
                    <div class="form-group" style="text-align: right; padding-right: 20px">
                        <asp:Button ID="btn_step_two" runat="Server" CssClass="btn btn-info" Text="去购物车结算"
                            OnClientClick="return isTremsAgree()" OnClick="btn_step_two_Click" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
