﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/reception-stage/batch.Master"
    AutoEventWireup="true" CodeBehind="my-cart-order-detail-info.aspx.cs" Inherits="WM_Project.views.my_cart_order_detail_info" %>

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

                var weights = temp.find(".weight");
                var lengths = temp.find(".length");
                var widths = temp.find(".width");
                var heights = temp.find(".height");
                var descriptions = temp.find(".description");
                var values = temp.find(".value");


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
    <div class="panel panel-primary">
        <div class="panel-heading">
            <h3 class="panel-title">
                订单详情</h3>
        </div>
        <div id="Div1" class="panel-body" runat="Server">
            <div class="form-group" id="has_addr_id" runat="server" visible="false">
                <div style="font-weight: 600; font-size: 20px">
                    订单<%=order_number %>的详情<input type="hidden" name="order_number" value="<%=order_number %>" /></div>
                <%--发件地址--%>
                <div style="border: 2px solid #DADADA; width: 49%; margin-top: 20px; float: left"
                    id="edit_send_address" runat="Server">
                    <div class="form-group" style="height: 30px; padding-top: 10px; clear: both">
                        <div class="col-md-3">
                            <font color="#cc3399" style="font-weight: bold; font-size: 18px;">
                                <asp:Label ID="edit_send_address_info" runat="Server" Text="发件地址"></asp:Label></font>
                        </div>
                        <div align="left" class="col-md-8">
                            带*为必填项，其余可不填<asp:Label ID="lb_which_first" runat="Server" Visible="false"></asp:Label>
                        </div>
                    </div>
                    <div class="form-group" style="height: 2px; background: #DADADA">
                    </div>
                    <div class="form-group" style="height: 30px; padding-bottom: 10px; clear: both">
                        <label class="col-md-3 control-label" style="padding-top: 10px; padding-left: 40px">
                            联系人名</label>
                        <div class="col-md-8">
                            <asp:TextBox ID="txt_send_addr_contact" class="form-control contactsend" runat="Server"></asp:TextBox>
                        </div>
                        <div class="col-md-1" style="color: Red; padding-top: 10px">
                            *</div>
                    </div>
                    <div class="form-group" style="height: 30px; padding-bottom: 10px; clear: both">
                        <label class="col-md-3 control-label" style="padding-top: 10px; padding-left: 40px">
                            公司名</label>
                        <div class="col-md-8">
                            <asp:TextBox ID="txt_send_addr_company" class="form-control companysend" runat="Server"></asp:TextBox>
                        </div>
                        <div class="col-md-1" style="color: Red; padding-top: 10px">
                            *</div>
                    </div>
                    <div class="form-group" style="height: 30px; padding-bottom: 10px; clear: both">
                        <label class="col-md-3 control-label" style="padding-top: 10px; padding-left: 40px">
                            地址1</label>
                        <div class="col-md-8">
                            <asp:TextBox ID="txt_send_addr_line1" class="form-control linesend" runat="Server"></asp:TextBox>
                        </div>
                        <div class="col-md-1" style="color: Red; padding-top: 10px">
                            *</div>
                    </div>
                    <div class="form-group" style="height: 30px; padding-bottom: 10px; clear: both">
                        <label class="col-md-3 control-label" style="padding-top: 10px; padding-left: 40px">
                            地址2</label>
                        <div class="col-md-8">
                            <asp:TextBox ID="txt_send_addr_line2" class="form-control" runat="Server"></asp:TextBox>
                        </div>
                        <div class="col-md-1" style="color: Red; padding-top: 10px">
                            &nbsp;</div>
                    </div>
                    <div class="form-group" style="height: 30px; padding-bottom: 10px; clear: both">
                        <label class="col-md-3 control-label" style="padding-top: 10px; padding-left: 40px">
                            地址3</label>
                        <div class="col-md-8">
                            <asp:TextBox ID="txt_send_addr_line3" runat="Server" class="form-control"></asp:TextBox>
                        </div>
                        <div class="col-md-1" style="color: Red; padding-top: 10px">
                            &nbsp;</div>
                    </div>
                    <div class="form-group" style="height: 30px; padding-bottom: 10px; clear: both">
                        <label class="col-md-3 control-label" style="padding-top: 10px; padding-left: 40px">
                            城市</label>
                        <div class="col-md-8">
                            <asp:TextBox ID="txt_send_addr_city" class="form-control citysend" runat="Server"></asp:TextBox>
                        </div>
                        <div class="col-md-1" style="color: Red; padding-top: 10px">
                            *</div>
                    </div>
                    <div class="form-group" style="height: 40px; clear: both">
                        <label class="col-md-3 control-label" style="padding-top: 10px; padding-left: 40px">
                            邮编</label>
                        <div class="col-md-8">
                            <asp:TextBox runat="Server" class="form-control postcodesend" ID="txt_send_addr_postcode"></asp:TextBox>
                        </div>
                        <div class="col-md-1" style="color: Red; padding-top: 10px">
                            *</div>
                    </div>
                    <div class="form-group" style="height: 40px; clear: both">
                        <label class="col-md-3 control-label" style="padding-top: 10px; padding-left: 40px">
                            国家</label>
                        <div class="col-md-8">
                            <asp:TextBox runat="Server" class="form-control countrysend" ID="txt_send_addr_country"
                                ReadOnly="true"></asp:TextBox>
                        </div>
                        <div class="col-md-1" style="color: Red; padding-top: 10px">
                            *</div>
                    </div>
                    <div class="form-group" style="height: 40px; clear: both">
                        <label class="col-md-3 control-label" style="padding-top: 10px; padding-left: 40px">
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
                        <label class="col-md-3 control-label" style="padding-top: 10px; padding-left: 40px">
                            收件人</label>
                        <div class="col-md-8">
                            <asp:TextBox ID="txt_receive_addr_contact" class="form-control contactreceive" runat="Server"></asp:TextBox>
                        </div>
                        <div class="col-md-1" style="color: Red; padding-top: 10px">
                            *</div>
                    </div>
                    <div class="form-group" style="height: 30px; padding-bottom: 10px; clear: both">
                        <label class="col-md-3 control-label" style="padding-top: 10px; padding-left: 40px">
                            公司名</label>
                        <div class="col-md-8">
                            <asp:TextBox ID="txt_receive_addr_company" class="form-control companyreceive" runat="Server"></asp:TextBox>
                        </div>
                        <div class="col-md-1" style="color: Red; padding-top: 10px">
                            *</div>
                    </div>
                    <div class="form-group" style="height: 30px; padding-bottom: 10px; clear: both">
                        <label class="col-md-3 control-label" style="padding-top: 10px; padding-left: 40px">
                            地址1</label>
                        <div class="col-md-8">
                            <asp:TextBox ID="txt_receive_addr_line1" class="form-control linereceive" runat="Server"></asp:TextBox>
                        </div>
                        <div class="col-md-1" style="color: Red; padding-top: 10px">
                            *</div>
                    </div>
                    <div class="form-group" style="height: 30px; padding-bottom: 10px; clear: both">
                        <label class="col-md-3 control-label" style="padding-top: 10px; padding-left: 40px">
                            地址2</label>
                        <div class="col-md-8">
                            <asp:TextBox ID="txt_receive_addr_line2" class="form-control" runat="Server"></asp:TextBox>
                        </div>
                        <div class="col-md-1" style="color: Red; padding-top: 10px">
                        </div>
                    </div>
                    <div class="form-group" style="height: 30px; padding-bottom: 10px; clear: both">
                        <label class="col-md-3 control-label" style="padding-top: 10px; padding-left: 40px">
                            地址3</label>
                        <div class="col-md-8">
                            <asp:TextBox ID="txt_receive_addr_line3" runat="Server" class="form-control"></asp:TextBox>
                        </div>
                        <div class="col-md-1" style="color: Red; padding-top: 10px">
                        </div>
                    </div>
                    <div class="form-group" style="height: 30px; padding-bottom: 10px; clear: both">
                        <label class="col-md-3 control-label" style="padding-top: 10px; padding-left: 40px">
                            城市</label>
                        <div class="col-md-8">
                            <asp:TextBox ID="txt_receive_addr_city" class="form-control cityreceive" runat="Server"></asp:TextBox>
                        </div>
                        <div class="col-md-1" style="color: Red; padding-top: 10px">
                            *</div>
                    </div>
                    <div class="form-group" style="height: 40px; clear: both">
                        <label class="col-md-3 control-label" style="padding-top: 10px; padding-left: 40px">
                            邮编</label>
                        <div class="col-md-8">
                            <asp:TextBox runat="Server" class="form-control postcodereceive" ID="txt_receive_addr_postcode"></asp:TextBox>
                        </div>
                        <div class="col-md-1" style="color: Red; padding-top: 10px">
                            *</div>
                    </div>
                    <div class="form-group" style="height: 40px; clear: both">
                        <label class="col-md-3 control-label" style="padding-top: 10px; padding-left: 40px">
                            国家</label>
                        <div class="col-md-8">
                            <asp:TextBox runat="Server" class="form-control countryreceive" ID="txt_receive_addr_country"
                                ReadOnly="true"></asp:TextBox>
                        </div>
                        <div class="col-md-1" style="color: Red; padding-top: 10px">
                            *</div>
                    </div>
                    <div class="form-group" style="height: 40px; clear: both">
                        <label class="col-md-3 control-label" style="padding-top: 10px; padding-left: 40px">
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
            <div class="form-group">
                <%for (int i = 0; i < package_array.Count; i++)
                  {
                      PackageCartInfo package = (PackageCartInfo)package_array[i];
                      
                %>
                <div style="border: 2px solid #DADADA; margin-top: 20px; margin-left: 1%; width: 32%;
                    float: left; padding-top: 10px">
                    <div style="padding-bottom: 10px; font-weight: 600; padding-left: 20px; color: #FF0000">
                        包裹<%=(i+1) %>
                        <input name="package_id" type="hidden" value="<%=package.Package_id %>" />
                    </div>
                    <table class="table table-striped ">
                        <tr style="height: 25px">
                            <td style="width: 35%; text-align: center">
                                <label class="control-label" style="padding-top: 5px">
                                    Weight:</label>
                            </td>
                            <td style="width: 55%">
                                <input type="text" name="weight" class="form-control weight" value="<%=(package.Weight) %>" />
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
                                <input type="text" name="length" class="form-control length" value="<%=(package.Length) %>" />
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
                                <input type="text" name="width" class="form-control width" value="<%=(package.Width) %>" />
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
                                <input type="text" name="height" class="form-control height" value="<%=(package.Height) %>" />
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
                                <input type="text" name="description" class="form-control description" value="<%=(package.Description) %>" />
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
                                <input type="text" name="value" class="form-control value" value="<%=(package.Value) %>" />
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
            <div class="form-group" style="clear: both; height: 30px; padding-top: 20px;" id="unpay_operation"
                runat="Server" visible="false">
                <div class="col-md-6" style="text-align: left">
                    <asp:Button ID="btn_back" runat="Server" Text="返回购物车" CssClass="btn btn-info" OnClick="btn_back_Click" />
                </div>
                <div class="col-md-6" style="text-align: right">
                    <asp:Button ID="btn_update" runat="Server" Text="更&nbsp;&nbsp;新" CssClass="btn btn-info update"
                        Width="120px" OnClick="btn_update_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
