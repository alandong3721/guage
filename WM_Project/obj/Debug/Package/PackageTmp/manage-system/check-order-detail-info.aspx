<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/back-stage/home.Master" AutoEventWireup="true" CodeBehind="check-order-detail-info.aspx.cs" Inherits="WM_Project.manage_system.check_order_detail_info" %>
<%@ Import Namespace="WM_Project.logical.common" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" src="../script/jquery-1.11.1.js"></script>
    <script type="text/javascript">

        $(document).ready(function () {


            var isUnsignedNumeric = function (strNumber) {
                if (strNumber != 0) {
                    var newPar = /^\d+(\.\d+)?$/;

                    return newPar.test(strNumber);
                }
                else {
                    return false;
                }
            }

            $(".update").click(function () {

                var address = $(this).parent().parent().parent();

                var contact = address.find(".contactsend");
                var company = address.find(".companysend");
                var line = address.find(".linesend");
                var city = address.find(".citysend");
                var postcode = address.find(".postcodesend");
                var country = address.find(".countrysend");
                var phone = address.find(".phonesend");

                if (contact.val() == "" || company.val() == "" || line.val() == "" || city.val() == "" || postcode.val() == "" || country.val() == "" || phone.val() == "") {
                    alert("发件地址中带 * 号的不能为空！！");
                    return false;

                }

                var contact2 = address.find(".contactreceive");
                var company2 = address.find(".companyreceive");
                var line2 = address.find(".linereceive");
                var city2 = address.find(".cityreceive");
                var postcode2 = address.find(".postcodereceive");
                var country2 = address.find(".countryreceive");
                var phone2 = address.find(".phonereceive");

                if (contact2.val() == "" || company2.val() == "" || line2.val() == "" || city2.val() == "" || postcode2.val() == "" || country2.val() == "" || phone2.val() == "") {
                    alert("收件地址中带 * 号的不能为空！！");
                    return false;

                }

                var weights = address.find(".weight");
                var lengths = address.find(".length");
                var widths = address.find(".width");
                var heights = address.find(".height");
                var descriptions = address.find(".description");
                var values = address.find(".value");

                for (var j = 0; j < descriptions.length; j++) {

                    if (jQuery.trim(weights.eq(j).val()) == "" || jQuery.trim(lengths.eq(j).val()) == "" || jQuery.trim(widths.eq(j).val()) == "" || jQuery.trim(heights.eq(j).val()) == "") {

                        alert("包裹的 weight、length、width、height 不能为空！！！");
                        return false;
                    }
                    if (!isUnsignedNumeric(jQuery.trim(weights.eq(j).val())) || !isUnsignedNumeric(jQuery.trim(lengths.eq(j).val())) || !isUnsignedNumeric(jQuery.trim(widths.eq(j).val())) || !isUnsignedNumeric(jQuery.trim(heights.eq(j).val()))) {
                        alert("包裹的 weight、length、width、height 必须为数字！！！");
                        return false;

                    }
                    if (jQuery.trim(descriptions.eq(j).val()) == "") {
                        alert("包裹的描述不能为空！！！");
                        return false;
                    }
                    if (jQuery.trim(values.eq(j).val()) == "") {
                        alert("包裹的价值不能为空！！！");
                        return false;
                    }
                    if (!isUnsignedNumeric(jQuery.trim(values.eq(j).val()))) {
                        alert("包裹的价值必须位数字！！");
                        return false;
                    }

                }

                return true;

            });

            $(".continue").click(function () {
                var temp = $(this).parent().parent().parent();

                var sendaddress = temp.find(".txt_area_send_address");
                var receiveaddress = temp.find(".txt_area_receive_address");

                var weights = temp.find(".weight");
                var lengths = temp.find(".length");
                var widths = temp.find(".width");
                var heights = temp.find(".height");
                var descriptions = temp.find(".description");
                var values = temp.find(".value");
                var insurances = temp.find(".insurance")

                if (jQuery.trim(sendaddress.val()) == "") {

                    alert("发件地址不能为空！！");
                    return false;
                } else if (jQuery.trim(receiveaddress.val()) == "") {
                    alert("收件地址不能为空！！");
                    return false;
                }

                for (var j = 0; j < descriptions.length; j++) {

                    if (jQuery.trim(weights.eq(j).val()) == "" || jQuery.trim(lengths.eq(j).val()) == "" || jQuery.trim(widths.eq(j).val()) == "" || jQuery.trim(heights.eq(j).val()) == "") {

                        alert("包裹的 weight、length、width、height 不能为空！！！");
                        return false;
                    }
                    if (!isUnsignedNumeric(jQuery.trim(weights.eq(j).val())) || !isUnsignedNumeric(jQuery.trim(lengths.eq(j).val())) || !isUnsignedNumeric(jQuery.trim(widths.eq(j).val())) || !isUnsignedNumeric(jQuery.trim(heights.eq(j).val()))) {
                        alert("包裹的 weight、length、width、height 必须为数字！！！");
                        return false;

                    }
                    if (jQuery.trim(descriptions.eq(j).val()) == "") {
                        alert("包裹的描述不能为空！！！");
                        return false;
                    }
                    if (jQuery.trim(values.eq(j).val()) == "") {
                        alert("包裹的价值不能为空！！！");
                        return false;
                    }
                    if (!isUnsignedNumeric(jQuery.trim(values.eq(j).val()))) {
                        alert("包裹的价值必须位数字！！");
                        return false;
                    }

                }

                return true;

            });

        });


    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="center" runat="server">
    <div class="panel panel-primary" style="margin-left:30px;margin-right:30px">
        <div class="panel-heading">
            <h3 class="panel-title">
                订单详情</h3>
        </div>
        <div id="Div1" class="panel-body" runat="Server">
            <div class="form-group" id="has_addr_id" runat="server" visible="false">
                <div style="font-weight: 600; font-size: 20px">
                    订单<%=order.Order_no %>的详情<input type="hidden" name="order_number" value="<%=order.Order_no %>" /></div>
                <%--发件地址--%>
                <div style="border: 2px solid #DADADA; width: 49%; margin-top: 20px; float: left"
                    id="edit_send_address" runat="Server">
                    <div class="form-group" style="height: 30px; padding-top: 10px; clear: both">
                        <div class="col-md-3">
                            <font color="#cc3399" style="font-weight: bold; font-size: 18px;">
                                <asp:Label ID="edit_send_address_info" runat="Server" Text="发件地址"></asp:Label></font>
                        </div>
                        <div align="left" class="col-md-8">
                            带*为必填项，其余可不填
                        </div>
                    </div>
                    <div class="form-group" style="height: 2px; background: #DADADA">
                    </div>
                    <div class="form-group" style="height: 30px; padding-bottom: 10px; clear: both">
                        <label class="col-md-3 control-label" style="padding-top: 10px; padding-left: 20px">
                            联系人名</label>
                        <div class="col-md-8">
                            <asp:TextBox ID="txt_send_addr_contact" class="form-control contactsend" runat="Server"></asp:TextBox>
                        </div>
                        <div class="col-md-1" style="color: Red; padding-top: 10px">
                            *</div>
                    </div>
                    <div class="form-group" style="height: 30px; padding-bottom: 10px; clear: both">
                        <label class="col-md-3 control-label" style="padding-top: 10px; padding-left: 20px">
                            公司名</label>
                        <div class="col-md-8">
                            <asp:TextBox ID="txt_send_addr_company" class="form-control companysend" runat="Server"></asp:TextBox>
                        </div>
                        <div class="col-md-1" style="color: Red; padding-top: 10px">
                            *</div>
                    </div>
                    <div class="form-group" style="height: 30px; padding-bottom: 10px; clear: both">
                        <label class="col-md-3 control-label" style="padding-top: 10px; padding-left: 20px">
                            地址1</label>
                        <div class="col-md-8">
                            <asp:TextBox ID="txt_send_addr_line1" class="form-control linesend" runat="Server"></asp:TextBox>
                        </div>
                        <div class="col-md-1" style="color: Red; padding-top: 10px">
                            *</div>
                    </div>
                    <div class="form-group" style="height: 30px; padding-bottom: 10px; clear: both">
                        <label class="col-md-3 control-label" style="padding-top: 10px; padding-left: 20px">
                            地址2</label>
                        <div class="col-md-8">
                            <asp:TextBox ID="txt_send_addr_line2" class="form-control" runat="Server"></asp:TextBox>
                        </div>
                        <div class="col-md-1" style="color: Red; padding-top: 10px">
                            &nbsp;</div>
                    </div>
                    <div class="form-group" style="height: 30px; padding-bottom: 10px; clear: both">
                        <label class="col-md-3 control-label" style="padding-top: 10px; padding-left:20px">
                            地址3</label>
                        <div class="col-md-8">
                            <asp:TextBox ID="txt_send_addr_line3" runat="Server" class="form-control"></asp:TextBox>
                        </div>
                        <div class="col-md-1" style="color: Red; padding-top: 10px">
                            &nbsp;</div>
                    </div>
                    <div class="form-group" style="height: 30px; padding-bottom: 10px; clear: both">
                        <label class="col-md-3 control-label" style="padding-top: 10px; padding-left: 20px">
                            城市</label>
                        <div class="col-md-8">
                            <asp:TextBox ID="txt_send_addr_city" class="form-control citysend" runat="Server"></asp:TextBox>
                        </div>
                        <div class="col-md-1" style="color: Red; padding-top: 10px">
                            *</div>
                    </div>
                    <div class="form-group" style="height: 40px; clear: both">
                        <label class="col-md-3 control-label" style="padding-top: 10px; padding-left: 20px">
                            邮编</label>
                        <div class="col-md-8">
                            <asp:TextBox runat="Server" class="form-control postcodesend" ID="txt_send_addr_postcode"></asp:TextBox>
                        </div>
                        <div class="col-md-1" style="color: Red; padding-top: 10px">
                            *</div>
                    </div>
                    <div class="form-group" style="height: 40px; clear: both">
                        <label class="col-md-3 control-label" style="padding-top: 10px; padding-left: 20px">
                            国家</label>
                        <div class="col-md-8">
                            <asp:TextBox runat="Server" class="form-control countrysend" ID="txt_send_addr_country" ReadOnly="true"></asp:TextBox>
                        </div>
                        <div class="col-md-1" style="color: Red; padding-top: 10px">
                            *</div>
                    </div>
                    <div class="form-group" style="height: 40px; clear: both">
                        <label class="col-md-3 control-label" style="padding-top: 10px; padding-left: 20px">
                            手机号码</label>
                        <div class="col-md-8">
                            <asp:TextBox runat="Server" class="form-control phonesend" ID="txt_send_addr_phone"></asp:TextBox>
                        </div>
                        <div class="col-md-1" style="color: Red; padding-top: 10px">
                            *</div>
                    </div>
                </div>
                <%--收件地址--%>
                <div style="border: 2px solid #DADADA; width: 49%; float: right; margin-top: 20px"
                    id="edit_receive_address" runat="Server">
                    <div class="form-group" style="height: 30px; padding-top: 10px">
                        <div class="col-md-3">
                            <font color="#cc3399" style="font-weight: bold; font-size: 18px;">
                                <asp:Label ID="edit_receive_address_info" runat="Server" Text="收件地址"></asp:Label></font>
                        </div>
                        <div align="left" class="col-md-8">
                            带*为必填项，其余可不填
                        </div>
                    </div>
                    <div class="form-group" style="height: 2px; background: #DADADA">
                    </div>
                    <div class="form-group" style="height: 30px; padding-bottom: 10px; clear: both">
                        <label class="col-md-3 control-label" style="padding-top: 10px; padding-left: 20px">
                            收件人</label>
                        <div class="col-md-8">
                            <asp:TextBox ID="txt_receive_addr_contact" class="form-control contactreceive" runat="Server"></asp:TextBox>
                        </div>
                        <div class="col-md-1" style="color: Red; padding-top: 10px">
                            *</div>
                    </div>
                    <div class="form-group" style="height: 30px; padding-bottom: 10px; clear: both">
                        <label class="col-md-3 control-label" style="padding-top: 10px; padding-left: 20px">
                            公司名</label>
                        <div class="col-md-8">
                            <asp:TextBox ID="txt_receive_addr_company" class="form-control companyreceive" runat="Server"></asp:TextBox>
                        </div>
                        <div class="col-md-1" style="color: Red; padding-top: 10px">
                            *</div>
                    </div>
                    <div class="form-group" style="height: 30px; padding-bottom: 10px; clear: both">
                        <label class="col-md-3 control-label" style="padding-top: 10px; padding-left: 20px">
                            地址1</label>
                        <div class="col-md-8">
                            <asp:TextBox ID="txt_receive_addr_line1" class="form-control linereceive" runat="Server"></asp:TextBox>
                        </div>
                        <div class="col-md-1" style="color: Red; padding-top: 10px">
                            *</div>
                    </div>
                    <div class="form-group" style="height: 30px; padding-bottom: 10px; clear: both">
                        <label class="col-md-3 control-label" style="padding-top: 10px; padding-left: 20px">
                            地址2</label>
                        <div class="col-md-8">
                            <asp:TextBox ID="txt_receive_addr_line2" class="form-control" runat="Server"></asp:TextBox>
                        </div>
                        <div class="col-md-1" style="color: Red; padding-top: 10px">
                        </div>
                    </div>
                    <div class="form-group" style="height: 30px; padding-bottom: 10px; clear: both">
                        <label class="col-md-3 control-label" style="padding-top: 10px; padding-left: 20px">
                            地址3</label>
                        <div class="col-md-8">
                            <asp:TextBox ID="txt_receive_addr_line3" runat="Server" class="form-control"></asp:TextBox>
                        </div>
                        <div class="col-md-1" style="color: Red; padding-top: 10px">
                        </div>
                    </div>
                    <div class="form-group" style="height: 30px; padding-bottom: 10px; clear: both">
                        <label class="col-md-3 control-label" style="padding-top: 10px; padding-left: 20px">
                            城市</label>
                        <div class="col-md-8">
                            <asp:TextBox ID="txt_receive_addr_city" class="form-control cityreceive" runat="Server"></asp:TextBox>
                        </div>
                        <div class="col-md-1" style="color: Red; padding-top: 10px">
                            *</div>
                    </div>
                    <div class="form-group" style="height: 40px; clear: both">
                        <label class="col-md-3 control-label" style="padding-top: 10px; padding-left: 20px">
                            邮编</label>
                        <div class="col-md-8">
                            <asp:TextBox runat="Server" class="form-control postcodereceive" ID="txt_receive_addr_postcode"></asp:TextBox>
                        </div>
                        <div class="col-md-1" style="color: Red; padding-top: 10px">
                            *</div>
                    </div>
                    <div class="form-group" style="height: 40px; clear: both">
                        <label class="col-md-3 control-label" style="padding-top: 10px; padding-left: 20px">
                            国家</label>
                        <div class="col-md-8">
                            <asp:TextBox runat="Server" class="form-control countryreceive" ID="txt_receive_addr_country" ReadOnly="true"></asp:TextBox>
                        </div>
                        <div class="col-md-1" style="color: Red; padding-top: 10px">
                            *</div>
                    </div>
                    <div class="form-group" style="height: 40px; clear: both">
                        <label class="col-md-3 control-label" style="padding-top: 10px; padding-left: 20px">
                            手机号码</label>
                        <div class="col-md-8">
                            <asp:TextBox runat="Server" class="form-control phonereceive" ID="txt_receive_addr_phone"></asp:TextBox>
                        </div>
                        <div class="col-md-1" style="color: Red; padding-top: 10px">
                            *</div>
                    </div> 
                </div>
                <div style="clear: both; height: 30px;">
                </div>
            </div>
            
            <div style="height: 2px; background: #DADADA">
            </div>
            <div class="form-group" style="padding-top:20px;">
                <%
                  if(order.Order_no!=""){    
                %>
                <div style="border: 2px solid #DADADA; margin-top: 20px; margin:0 auto; width: 50%;
                    float: left; padding-top: 10px">
                    <div style="padding-bottom: 10px; font-weight: 600; padding-left: 20px; color: #FF0000">
                        包裹规格 
                        <input name="package_id" type="hidden" value="<%=order.Order_no%>" />
                    </div>
                    <table class="table table-striped ">
                        <tr style="height: 25px">
                            <td style="width: 35%; text-align: center">
                                <label class="control-label" style="padding-top: 5px">
                                    Weight:</label>
                            </td>
                            <td style="width: 55%">
                                <input type="text" name="weight" class="form-control weight" value="<%=(order.Weight) %>" />
                            </td>
                            <td style="width: 10%; color: Red">
                                *
                            </td>
                        </tr>
                        <tr style="height: 25px">
                            <td style="width: 35%; text-align: center">
                                <label class="control-label" style="padding-top: 5px">
                                    Length:</label>
                            </td>
                            <td style="width: 55%">
                                <input type="text" name="length" class="form-control length" value="<%=(order.Length) %>" />
                            </td>
                            <td style="width: 10%; color: Red">
                                *
                            </td>
                        </tr>
                        <tr style="height: 25px">
                            <td style="width: 35%; text-align: center">
                                <label class="control-label" style="padding-top: 5px">
                                    Width:</label>
                            </td>
                            <td style="width: 55%">
                                <input type="text" name="width" class="form-control width" value="<%=(order.Width) %>" />
                            </td>
                            <td style="width: 10%; color: Red">
                                *
                            </td>
                        </tr>
                        <tr style="height: 25px">
                            <td style="width: 35%; text-align: center">
                                <label class="control-label" style="padding-top: 5px">
                                    Height:</label>
                            </td>
                            <td style="width: 55%">
                                <input type="text" name="height" class="form-control height" value="<%=(order.Height) %>" />
                            </td>
                            <td style="width: 10%; color: Red">
                                *
                            </td>
                        </tr>
                        <tr style="height: 25px">
                            <td style="width: 35%; text-align: center">
                                <label class="control-label" style="padding-top: 5px">
                                    Insurance:</label>
                            </td>
                            <td style="width: 55%">
                                <input type="text" name="insurance" class="form-control insurance" value="<%=(order.Insurance) %>" />
                            </td>
                            <td style="width: 10%; color: Red">
                                *
                            </td>
                        </tr>
                        <tr style="height: 25px">
                            <td style="width: 35%; text-align: center">
                                <label class="control-label" style="padding-top: 5px">
                                    包裹描述:</label>
                            </td>
                            <td style="width: 55%">
                                <input type="text" name="description" class="form-control description" value="<%=order.PackageDescription %>" />
                            </td>
                            <td style="width: 10%; color: Red">
                                *
                            </td>
                        </tr>
                        <tr style="height: 25px">
                            <td style="width: 35%; text-align: center">
                                <label class="control-label" style="padding-top: 5px">
                                    价值:</label>
                            </td>
                            <td style="width: 55%">
                                <input type="text" name="value" class="form-control value" value="<%=order.PackageValue %>" />
                            </td>
                            <td style="width: 10%; color: Red">
                                *
                            </td>
                        </tr>
                    </table>
                </div>
                <%
                  } %>
            </div>
            
        </div>
    </div>
</asp:Content>
