<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/reception-stage/batch.Master"
    AutoEventWireup="true" CodeBehind="local-order-process.aspx.cs" Inherits="WM_Project.views.inter_express.local_order_process" %>

<%@ Import Namespace="WM_Project.logical.common" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../../javascripts/jquery-1.11.1.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {

            $(".gotocart").click(function () {
                var contact = $(this).parent().parent().find(".contactsend");
                var company = $(this).parent().parent().find(".companysend");
                var addr_line = $(this).parent().parent().find(".linesend");
                var city = $(this).parent().parent().find(".citysend");
                var postcode = $(this).parent().parent().find(".postcodesend");
                var phone = $(this).parent().parent().find(".phonesend");
                var shippdate = $(this).parent().parent().find(".shipdate");

                if ($.trim(contact.val()) == "" || $.trim(company.val()) == "" || $.trim(addr_line.val()) == "" || $.trim(city.val()) == "" || $.trim(postcode.val()) == "" || $.trim(phone.val()) == "" || $.trim(shippdate.val()) == "") {
                    alert("带*号的不能为空！！");
                    return false;
                }


            });


        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="center" runat="server">
    <div class="panel panel-primary" id="part_one" runat="Server" style="width: 88%; margin: 0 auto; margin-bottom: 30px">
        <div class="panel-heading">
            <h5 class="panel-title">
                可供您选择的本地取件方式</h5>
        </div>
        <div class="panel-body">
            <asp:DataList ID="local_postway" runat="Server" 
                onitemcommand="local_postway_ItemCommand">
                <HeaderTemplate><table style="width:100%"></HeaderTemplate>
                <ItemTemplate>
                    <tr style="height:50px;margin-top:10px">
                        <td style="width:200px;text-align:left"><img alt="picture" src='<%#DataBinder.Eval(Container.DataItem,"image") %>' width="100px" height="50px" /></td>
                        <td style="width:450px;text-align:left"><%#DataBinder.Eval(Container.DataItem,"note") %></td>
                        <td style="width:100px;text-align:left"><%#DataBinder.Eval(Container.DataItem,"money") %></td>
                        <td style="width:100px;text-align:right"><asp:LinkButton ID="btn_linkbutton" runat="Server" CommandName="buy" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"postway") %>' Text="购买" Font-Bold="true"></asp:LinkButton></td>
                    </tr>
                </ItemTemplate>
                <SeparatorTemplate><tr style="height:20px;"><td colspan="4" style="height:20px">&nbsp;</td></tr></SeparatorTemplate>
                <FooterTemplate></table></FooterTemplate>
            </asp:DataList>
        </div>
    </div>
    <div class="panel panel-primary" style="width: 80%; margin: 0 auto; margin-bottom: 30px"
        id="part_two" runat="Server">
        <div class="panel-heading">
            <h5 class="panel-title">
                本地取件发件地址编辑</h5>
        </div>
        <div class="panel-body">
            <div class="form-group" style="height: 30px; padding-top: 10px; clear: both">
                <div class="col-md-3">
                    <font color="#cc3399" style="font-weight: bold; font-size: 18px;">
                        <asp:Label ID="edit_send_address_info" runat="Server" Text="编辑发件地址"></asp:Label></font>
                </div>
                <div align="left" class="col-md-8">
                    带*为必填项，其余可不填
                </div>
            </div>
            <div class="form-group" style="height: 2px; background: #DADADA">
            </div>
            <div class="form-group" style="height: 30px; padding-bottom: 10px; clear: both">
                <label class="col-md-3 control-label" style="padding-top: 10px; padding-right: 20px;
                    text-align: right">
                    联系人名</label>
                <div class="col-md-7">
                    <asp:TextBox ID="txt_send_addr_contact" class="form-control contactsend" runat="Server"></asp:TextBox>
                </div>
                <div class="col-md-2" style="color: Red; padding-top: 10px">
                    *</div>
            </div>
            <div class="form-group" style="height: 30px; padding-bottom: 10px; clear: both">
                <label class="col-md-3 control-label" style="padding-top: 10px; padding-right: 20px;
                    text-align: right">
                    公司名</label>
                <div class="col-md-7">
                    <asp:TextBox ID="txt_send_addr_company" class="form-control companysend" runat="Server"></asp:TextBox>
                </div>
                <div class="col-md-2" style="color: Red; padding-top: 10px">
                    *</div>
            </div>
            <div class="form-group" style="height: 30px; padding-bottom: 10px; clear: both">
                <label class="col-md-3 control-label" style="padding-top: 10px; padding-right: 20px;
                    text-align: right">
                    地址1</label>
                <div class="col-md-7">
                    <asp:TextBox ID="txt_send_addr_line1" class="form-control linesend" runat="Server"></asp:TextBox>
                </div>
                <div class="col-md-2" style="color: Red; padding-top: 10px">
                    *</div>
            </div>
            <div class="form-group" style="height: 30px; padding-bottom: 10px; clear: both">
                <label class="col-md-3 control-label" style="padding-top: 10px; padding-right: 20px;
                    text-align: right">
                    地址2</label>
                <div class="col-md-7">
                    <asp:TextBox ID="txt_send_addr_line2" class="form-control" runat="Server"></asp:TextBox>
                </div>
                <div class="col-md-2" style="color: Red; padding-top: 10px">
                    &nbsp;</div>
            </div>
            <div class="form-group" style="height: 30px; padding-bottom: 10px; clear: both">
                <label class="col-md-3 control-label" style="padding-top: 10px; padding-firhg: 20px;
                    text-align: right">
                    地址3</label>
                <div class="col-md-7">
                    <asp:TextBox ID="txt_send_addr_line3" runat="Server" class="form-control"></asp:TextBox>
                </div>
                <div class="col-md-2" style="color: Red; padding-top: 10px">
                    &nbsp;</div>
            </div>
            <div class="form-group" style="height: 30px; padding-bottom: 10px; clear: both">
                <label class="col-md-3 control-label" style="padding-top: 10px; padding-right: 20px;
                    text-align: right">
                    城市</label>
                <div class="col-md-7">
                    <asp:TextBox ID="txt_send_addr_city" class="form-control citysend" runat="Server"></asp:TextBox>
                </div>
                <div class="col-md-2" style="color: Red; padding-top: 10px">
                    *</div>
            </div>
            <div class="form-group" style="height: 30px; clear: both">
                <label class="col-md-3 control-label" style="padding-top: 10px; padding-right: 20px;
                    text-align: right">
                    邮编</label>
                <div class="col-md-7">
                    <asp:TextBox runat="Server" class="form-control postcodesend" ID="txt_send_addr_postcode"></asp:TextBox>
                </div>
                <div class="col-md-2" style="color: Red; padding-top: 10px">
                    *</div>
            </div>
            <div class="form-group" style="height: 30px; clear: both">
                <label class="col-md-3 control-label" style="padding-top: 10px; padding-right: 20px;
                    text-align: right">
                    国家</label>
                <div class="col-md-7">
                    <asp:TextBox runat="Server" class="form-control countrysend" ID="txt_send_addr_country"
                        ReadOnly="true"></asp:TextBox>
                </div>
                <div class="col-md-2" style="color: Red; padding-top: 10px">
                    *</div>
            </div>
            <div class="form-group" style="height: 30px; clear: both; padding-bottom: 10px">
                <label class="col-md-3 control-label" style="padding-top: 10px; padding-right: 20px;
                    text-align: right">
                    手机号码</label>
                <div class="col-md-7">
                    <asp:TextBox runat="Server" class="form-control phonesend" ID="txt_send_addr_phone"></asp:TextBox>
                </div>
                <div class="col-md-2" style="color: Red; padding-top: 10px">
                    *</div>
            </div>
            <div class="form-group" style="height: 30px; clear: both">
                <label class="col-md-3 control-label" style="padding-top: 10px; padding-right: 20px;
                    text-align: right">
                    取件日期</label>
                <div class="col-md-7">
                    <asp:TextBox runat="Server" class="form-control shipdate" ID="txt_shipdate"></asp:TextBox>
                </div>
                <div class="col-md-2" style="color: Red; padding-top: 10px">
                    *</div>
            </div>
            <div class="form-group" style="text-align: center; margin-top: 20px">
                <asp:Button CssClass="btn btn-info gotocart" Text="去结算" ID="btn_goto_cart" runat="Server"
                    Style="text-align: center" OnClick="btn_goto_cart_Click" />
            </div>
        </div>
        <div class="panel-footer">
            <p style="color: #FF0000">
                *&nbsp;以上是默认地址，如果不用默认地址可以直接在以上地址栏中编辑新地址！！</p>
        </div>
    </div>
</asp:Content>
