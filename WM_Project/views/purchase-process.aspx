<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/reception-stage/home.Master"
    AutoEventWireup="true" CodeBehind="purchase-process.aspx.cs" Inherits="WM_Project.views.purchase_process" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
    <style type="text/css">
        
    </style>
    <script src="../script/Calendar3.js" type="text/javascript"></script>


     <script src="../../script/Calendar3.js" type="text/javascript"></script>
    <script src="../../script/jquery-1.11.1.js" type="text/javascript"></script>
    <link href="../../script/layer-v1.8.5/layer/skin/layer.css" rel="stylesheet" type="text/css" />
    <script src="../../script/layer-v1.8.5/layer/layer.min.js" type="text/javascript"></script>
    <script type="text/javascript">

        $(document).ready(function () {
            var mydate = new Date();
           
            if (mydate.getDay() < 5) {
                mydate.setDate(mydate.getDate()+1);
            }
            else if (mydate.getDay() == 5) {
                mydate.setDate(mydate.getDate() +3);
            }
           else  if (mydate.getDay() ==6) {
                mydate.setDate(mydate.getDate() + 2);
            }
            var year = mydate.getFullYear();
            var month = mydate.getMonth() + 1;
            var day = mydate.getDate();
            $(".recive-Date").val(year + "-" + month + "-" + day);
            $(".btn-xs").click(function () {
                var Allvalue = $(this).parent().parent().parent().parent().find(".Allvalue");
                for (var ii = 1; ii < Allvalue.length; ii++) {
                    Allvalue.eq(ii).val(Allvalue.eq(0).val());
                }
            });
        });
    </script>
    <script type="text/javascript">

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


        function isPageInfoValidate() {

            //判断包裹价值是否正确填写
            var packagevalue = document.getElementsByName("package_value");

            for(i=0;i<packagevalue.length;i++){
                if (!isUnsignedNumeric(packagevalue[0].value)) {
                    alert("包裹价值必须为数字！！");
                    return false;
                }
            }


            // 判断发件地址是否为空
            var contact = document.getElementById('<%=txt_send_addr_contact.ClientID %>').value;
            var company = document.getElementById('<%=txt_send_addr_company.ClientID %>').value;
            var addr_line = document.getElementById('<%=txt_send_addr_line1.ClientID %>').value;
            var city = document.getElementById('<%=txt_send_addr_city.ClientID %>').value;
            var postcode = document.getElementById('<%=txt_send_addr_postcode.ClientID %>').value;
            var country = document.getElementById('<%=txt_send_addr_country.ClientID %>').value;
            var phone = document.getElementById('<%=txt_send_addr_phone.ClientID %>').value;
            //  var email = document.getElementById('<%=txt_send_addr_email.ClientID %>').value;

            if (contact.trim() == "" || company.trim() == "" || addr_line.trim() == "" || city.trim() == "" || postcode.trim() == "" || country.trim() == "" || phone.trim() == "") {
                alert("发件地址中带 * 号的不能为空！！");
                return false;
            }

            //收件地址信息判断

            var contact = document.getElementById('<%=txt_receive_addr_contact.ClientID %>').value;
            var company = document.getElementById('<%=txt_receive_addr_company.ClientID %>').value;
            var addr_line = document.getElementById('<%=txt_receive_addr_line1.ClientID %>').value;
            var city = document.getElementById('<%=txt_receive_addr_city.ClientID %>').value;
            var postcode = document.getElementById('<%=txt_receive_addr_postcode.ClientID %>').value;
            var country = document.getElementById('<%=txt_receive_addr_country.ClientID %>').value;
            var phone = document.getElementById('<%=txt_receive_addr_phone.ClientID %>').value;
            //            var email = document.getElementById('<%=txt_receive_addr_email.ClientID %>').value;

            if (contact.trim() == "" || company.trim() == "" || addr_line.trim() == "" || city.trim() == "" || postcode.trim() == "" || country.trim() == "" || phone.trim() == "") {
                alert("收件地址中带 * 号的不能为空！！");
                return false;
            }
            /*判断用户是否同意服务条款*/

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
<asp:Content ID="Content2" ContentPlaceHolderID="center_right" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="panel panel-primary" style="margin-left: -20px; margin-right: -20px">
        <div class="panel-heading">
            <h5 class="panel-title">
                填写邮寄详细信息</h5>
        </div>
        <div class="panel-body">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <div class="panel panel-primary" style="font-size: 14px">
                        <div class="panel-heading">
                            <h6 class="panel-title">
                                包裹取件方式选择</h6>
                        </div>
                        <div class="panel-body">
                            <div class="form-group" style="height: 26px;">
                                <label class="col-md-3 control-label" style="text-align: right;">
                                    购买保险</label>
                                <div class="col-md-8">
                                    <select name="select_insurance" class="form-control" style="height: 25px;padding-top:0px;padding-bottom:0px">
                                        <option value="0">自带£20包裹丢失赔偿</option>
                                        <%--<option value="5">购买5英镑是保500英镑</option>
                                        <option value="10">购买10英镑是保1000英镑</option>
                                        <option value="15">购买15英镑是保1500英镑</option>
                                        <option value="20">购买20英镑是保2000英镑</option>--%>
                                    </select>
                                </div>
                            </div>
                            <div class="form-group" style="height: 26px;">
                                <label class="col-md-3 control-label" style="text-align: right;">
                                    取件时间</label>
                                <div class="col-md-8">
                                    <input type="text" name="collection_time" style="padding-top:0px;padding-bottom:0px;height:25px" class="form-control recive-Date" onclick="new Calendar().show(this)" />
                                </div>
                            </div>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
            <div class="panel panel-primary" style="font-size: 14px">
                <div class="panel-heading">
                    <h6 class="panel-title">
                        物品信息填写</h6>
                </div>
                <div class="panel-body">
                    <%
                        package_array = (ArrayList)Session["package_array"];

                        for (int i = 0; i < package_array.Count; i++)
                        {

                            WM_Project.logical.common.PackageMeasure good = (WM_Project.logical.common.PackageMeasure)package_array[i];
                    %>
                    <table class="table table-striped ">
                        <tr style="text-align: left">
                            <td colspan="5" style="width: 100%; text-align: left">
                                <label class="col-md-8 control-label" style="padding-left:0px;padding-right:0px;font-size:13px">
                                    第<%=i + 1%>中规格:&nbsp;&nbsp;包裹个数：<%=good.Count %>&nbsp;&nbsp;尺寸(长*宽*高)：<%=good.Weight %>*<%=good.Length %>*<%=good.Width %>*<%=good.Height %></label><span
                                        class="col-md-4" style="text-align: right"><input type="button" class="btn-danger btn-xs"
                                            style="height: 30px; width: 120px" value="复制到其他包裹" /></span>
                            </td>
                        </tr>
                        <%
                            for (int j = 0; j < good.Count; j++)
                            { %>
                        <tr>
                            <td class="panel-title" style="padding-left: 20px; width: 20%; text-align: left">
                                <label>
                                    第<%= j+1%>个包裹：</label>
                            </td>
                            <td style="width: 12%; padding-right: 0px; text-align: right">
                                <label>
                                    描述：</label>
                            </td>
                            <td style="width: 40%; padding-left: 0px; text-align: left;">
                                <select name="description" class="form-control" style="padding-top:0px;padding-bottom:0px;height:25px">
                                    <option value="婴儿奶粉">婴儿奶粉</option>
                                    <option value="婴儿食品">婴儿食品</option>
                                    <option value="成人奶粉">成人奶粉</option>
                                    <option value="婴儿推车">婴儿推车</option>
                                    <option value="婴儿汽车座椅">婴儿汽车座椅</option>
                                    <option value="婴儿用品">婴儿用品</option>
                                    <option value="食品">食品</option>
                                    <option value="保健品">保健品</option>
                                    <option value="服装服饰">服装服饰</option>
                                    <option value="服饰配件">服饰配件</option>
                                    <option value="箱包">箱包</option>
                                    <option value="鞋靴">鞋靴</option>
                                    <option value="钟表">钟表</option>
                                    <option value="钟表配件">钟表配件</option>
                                    <option value="化妆品">化妆品</option>
                                    <option value="护肤品">护肤品</option>
                                    <option value="洗漱用品">洗漱用品</option>
                                    <option value="厨卫用品">厨卫用品</option>
                                    <option value="小家电">小家电</option>
                                    <option value="家具">家具</option>
                                    <option value="大家电">大家电</option>
                                    <option value="医疗用品">医疗用品</option>
                                    <option value="影音设备">影音设备</option>
                                    <option value="手机">手机</option>
                                    <option value="手机配件">手机配件</option>
                                    <option value="计算机">计算机</option>
                                    <option value="计算机设备">计算机设备</option>
                                    <option value="书报">书报</option>
                                    <option value="音响制品">音响制品</option>
                                    <option value="文具">文具</option>
                                    <option value="玩具">玩具</option>
                                    <option value="教育用品">教育用品</option>
                                    <option value="体育用品">体育用品</option>
                                    <option value="户外用品">户外用品</option>
                                    <option value="邮票">邮票</option>
                                    <option value="乐器">乐器</option>
                                    <option value="其他">其他</option>
                                </select>
                            </td>
                            <td style="width: 16%; text-align: right">
                                <label>
                                    总价值&pound;：</label>
                            </td>
                            <td style="width: 20%; padding-left: 0px; text-align: left">
                                <input type="text" name="package_value" class="form-control Allvalue" style="padding-top:0px;padding-bottom:0px;height:25px" />
                            </td>
                        </tr>
                        <%} %>
                    </table>
                    <%} %>
                </div>
            </div>
            <%--发件人地址信息部分--%>
            <asp:UpdatePanel ID="update_panel2" runat="Server" UpdateMode="Conditional">
                <ContentTemplate>
                    <div class="panel panel-primary" style="font-size: 14px">
                        <div class="panel-heading">
                            <h6 class="panel-title">
                                发件人地址信息&nbsp;
                                <asp:CheckBox ID="send_addr" runat="server" Text="保存到地址簿" Checked="true" Font-Size="14px" />
                            </h6>
                        </div>
                        <div class="panel-body">
                            <div class="form-goup">
                                <label class="col-md-3 control-label">
                                    从地址簿中选取</label>
                                <div class="col-md-8">
                                    <asp:DropDownList ID="send_addr_dropdown_list" runat="Server" CssClass="form-control" style="padding-top:0px;padding-bottom:0px;height:25px;"
                                        OnSelectedIndexChanged="send_addr_dropdown_list_SelectedIndexChanged" AutoPostBack="true">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group" style="clear: both">
                                <label class="col-md-2 control-label" style=" text-align: right">
                                    发件人名</label>
                                <div class="col-md-9">
                                    <asp:TextBox ID="txt_send_addr_contact" CssClass="form-control" style="padding-top:0px;padding-bottom:0px;height:25px;" runat="Server"></asp:TextBox>
                                </div>
                                <div class="col-md-1" style="color: Red; padding-top: 5px">
                                    *</div>
                            </div>
                            <div class="form-group" style="clear: both">
                                <label class="col-md-2 control-label" style="text-align: right">
                                    公司名</label>
                                <div class="col-md-5">
                                    <asp:TextBox ID="txt_send_addr_company" CssClass="form-control" style="padding-top:0px;padding-bottom:0px;height:25px;" runat="Server"></asp:TextBox>
                                </div>
                                <div class="col-md-5" style="color: Red;">
                                    * 如果不是公司请填写收件人</div>
                            </div>
                            <div class="form-group" style="clear: both">
                                <label class="col-md-2 control-label" style="padding-top: 6px; text-align: right">
                                    地址1</label>
                                <div class="col-md-9">
                                    <asp:TextBox ID="txt_send_addr_line1" style="padding-top:0px;padding-bottom:0px;height:25px;" class="form-control" runat="Server"></asp:TextBox>
                                </div>
                                <div class="col-md-1" style="color: Red; padding-top: 10px">
                                    *</div>
                            </div>
                            <div class="form-group" style="clear: both">
                                <label class="col-md-2 control-label" style="text-align: right">
                                    地址2</label>
                                <div class="col-md-9">
                                    <asp:TextBox ID="txt_send_addr_line2" style="padding-top:0px;padding-bottom:0px;height:25px;" class="form-control" runat="Server"></asp:TextBox>
                                </div>
                                <div class="col-md-1" style="color: Red; padding-top: 5px">
                                    &nbsp;</div>
                            </div>
                            <div class="form-group" style="clear: both">
                                <label class="col-md-2 control-label" style="text-align: right">
                                    地址3</label>
                                <div class="col-md-9">
                                    <asp:TextBox ID="txt_send_addr_line3" style="padding-top:0px;padding-bottom:0px;height:25px;" runat="Server" class="form-control"></asp:TextBox>
                                </div>
                                <div class="col-md-1" style="color: Red; padding-top: 5px">
                                    &nbsp;</div>
                            </div>
                            <div class="form-group" style="clear: both">
                                <label class="col-md-2 control-label" style="text-align: right">
                                    城市</label>
                                <div class="col-md-9">
                                    <asp:TextBox ID="txt_send_addr_city" style="padding-top:0px;padding-bottom:0px;height:25px;" class="form-control" runat="Server"></asp:TextBox>
                                </div>
                                <div class="col-md-1" style="color: Red; padding-top: 5px">
                                    *</div>
                            </div>
                            <div class="form-group" style="clear: both">
                                <label class="col-md-2 control-label" style="text-align: right">
                                    邮编</label>
                                <div class="col-md-9">
                                    <asp:TextBox runat="Server" style="padding-top:0px;padding-bottom:0px;height:25px;" class="form-control" ID="txt_send_addr_postcode"></asp:TextBox>
                                </div>
                                <div class="col-md-1" style="color: Red; padding-top: 5px">
                                    *</div>
                            </div>
                            <div class="form-group" style="clear: both">
                                <label class="col-md-2 control-label"  style="text-align: right">
                                    国家</label>
                                <div class="col-md-9">
                                    <asp:TextBox runat="Server" ReadOnly="true" style="padding-top:0px;padding-bottom:0px;height:25px;" class="form-control" ID="txt_send_addr_country"></asp:TextBox>
                                </div>
                                <div class="col-md-1" style="color: Red; padding-top: 5px">
                                    *</div>
                            </div>
                            <div class="form-group" style="clear: both">
                                <label class="col-md-2 control-label" style="text-align: right">
                                    手机号码</label>
                                <div class="col-md-9">
                                    <asp:TextBox runat="Server" style="padding-top:0px;padding-bottom:0px;height:25px;" class="form-control" ID="txt_send_addr_phone"></asp:TextBox>
                                </div>
                                <div class="col-md-1" style="color: Red; padding-top: 5px">
                                    *</div>
                            </div>
                            <div class="form-group" style="clear: both">
                                <label class="col-md-2 control-label" style="text-align: right">
                                    邮箱</label>
                                <div class="col-md-9">
                                    <asp:TextBox runat="Server" style="padding-top:0px;padding-bottom:0px;height:25px;" class="form-control" ID="txt_send_addr_email"></asp:TextBox>
                                </div>
                                <div class="col-md-1" style="color: Red; padding-top: 5px">
                                    &nbsp;</div>
                            </div>
                        </div>
                    </div>
                    <div class="panel panel-primary" style="font-size: 14px">
                        <div class="panel-heading">
                            <h6 class="panel-title">
                                收件人地址信息&nbsp;
                                <asp:CheckBox ID="receive_addr" runat="server" Text="保存到地址簿" Checked="true" Font-Size="14px" />
                            </h6>
                        </div>
                        <div class="panel-body">
                            <div class="form-goup">
                                <label class="col-md-3 control-label">
                                    从地址簿中选取</label>
                                <div class="col-md-8">
                                    <asp:DropDownList ID="receive_addr_dropdown_list" runat="Server" CssClass="form-control" style="padding-top:0px;padding-bottom:0px;height:25px;"
                                        OnSelectedIndexChanged="receive_addr_dropdown_list_SelectedIndexChanged" AutoPostBack="true">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group" style="clear: both">
                                <label class="col-md-2 control-label" style="text-align: right">
                                    收件人名</label>
                                <div class="col-md-9">
                                    <asp:TextBox ID="txt_receive_addr_contact" style="padding-top:0px;padding-bottom:0px;height:25px;" class="form-control" runat="Server"></asp:TextBox>
                                </div>
                                <div class="col-md-1" style="color: Red; padding-top: 5px">
                                    *</div>
                            </div>
                            <div class="form-group" style="clear: both">
                                <label class="col-md-2 control-label" style="text-align: right">
                                    公司名</label>
                                <div class="col-md-5">
                                    <asp:TextBox ID="txt_receive_addr_company" style="padding-top:0px;padding-bottom:0px;height:25px;" class="form-control" runat="Server"></asp:TextBox>
                                </div>
                                <div class="col-md-5" style="color: Red;">
                                    * 如果不是公司请填写收件人名</div>
                            </div>
                            <div class="form-group" style="clear: both">
                                <label class="col-md-2 control-label" style="text-align: right">
                                    地址1</label>
                                <div class="col-md-9">
                                    <asp:TextBox ID="txt_receive_addr_line1" style="padding-top:0px;padding-bottom:0px;height:25px;" class="form-control" runat="Server"></asp:TextBox>
                                </div>
                                <div class="col-md-1" style="color: Red; padding-top: 5px">
                                    *</div>
                            </div>
                            <div class="form-group" style="clear: both">
                                <label class="col-md-2 control-label" style="text-align: right">
                                    地址2</label>
                                <div class="col-md-9">
                                    <asp:TextBox ID="txt_receive_addr_line2" style="padding-top:0px;padding-bottom:0px;height:25px;" class="form-control" runat="Server"></asp:TextBox>
                                </div>
                                <div class="col-md-1" style="color: Red; padding-top: 5px">
                                    &nbsp;</div>
                            </div>
                            <div class="form-group" style="clear: both">
                                <label class="col-md-2 control-label" style="text-align: right">
                                    地址3</label>
                                <div class="col-md-9">
                                    <asp:TextBox ID="txt_receive_addr_line3" style="padding-top:0px;padding-bottom:0px;height:25px;" runat="Server" class="form-control"></asp:TextBox>
                                </div>
                                <div class="col-md-1" style="color: Red; padding-top: 5px">
                                    &nbsp;</div>
                            </div>
                            <div class="form-group" style="clear: both">
                                <label class="col-md-2 control-label" style="text-align: right">
                                    城市</label>
                                <div class="col-md-9">
                                    <asp:TextBox ID="txt_receive_addr_city" style="padding-top:0px;padding-bottom:0px;height:25px;" class="form-control" runat="Server"></asp:TextBox>
                                </div>
                                <div class="col-md-1" style="color: Red; padding-top: 5px">
                                    *</div>
                            </div>
                            <div class="form-group" style="clear: both">
                                <label class="col-md-2 control-label" style="text-align: right">
                                    邮编</label>
                                <div class="col-md-9">
                                    <asp:TextBox runat="Server" style="padding-top:0px;padding-bottom:0px;height:25px;" class="form-control" ID="txt_receive_addr_postcode"></asp:TextBox>
                                </div>
                                <div class="col-md-1" style="color: Red; padding-top: 5px">
                                    *</div>
                            </div>
                            <div class="form-group" style="clear: both">
                                <label class="col-md-2 control-label" style="text-align: right">
                                    国家</label>
                                <div class="col-md-9">
                                    <asp:TextBox runat="Server" ReadOnly="true" style="padding-top:0px;padding-bottom:0px;height:25px;" class="form-control" ID="txt_receive_addr_country"></asp:TextBox>
                                </div>
                                <div class="col-md-1" style="color: Red; padding-top: 5px">
                                    *</div>
                            </div>
                            <div class="form-group" style=" clear: both">
                                <label class="col-md-2 control-label" style=" text-align: right">
                                    手机号码</label>
                                <div class="col-md-9">
                                    <asp:TextBox runat="Server" class="form-control" style="padding-top:0px;padding-bottom:0px;height:25px;" ID="txt_receive_addr_phone"></asp:TextBox>
                                </div>
                                <div class="col-md-1" style="color: Red; padding-top: 5px">
                                    *</div>
                            </div>
                            <div class="form-group" style="clear: both">
                                <label class="col-md-2 control-label" style="text-align: right">
                                    邮箱</label>
                                <div class="col-md-9">
                                    <asp:TextBox runat="Server" class="form-control" style="padding-top:0px;padding-bottom:0px;height:25px;" ID="txt_receive_addr_email"></asp:TextBox>
                                </div>
                                <div class="col-md-1" style="color: Red; padding-top: 5px">
                                    &nbsp;</div>
                            </div>
                            <div class="form-group" style="clear: both">
                                <label class="col-md-2 control-label" style="text-align: right;color:#FF0000">
                                    身份证号</label>
                                <div class="col-md-5">
                                    <asp:TextBox runat="Server" class="form-control" style="padding-top:0px;padding-bottom:0px;height:25px;" ID="txt_id_number"></asp:TextBox>
                                </div>
                                <div class="col-md-5" style="padding-left:0px;padding-right:0px"><p style="color:#FF0000;padding-top:2px">准确填写身份证号，通关更顺畅</p></div>
                                
                            </div>
                            <div class="form-group" style="clear: both" id="parcelforce" runat="Server" visible="false">
                                <label class="col-md-9" style="text-align: left;color:#3C85C4; font-size:8px;padding-right:0px;padding-top:2px">
                                    由于Parcelforce不支持中文，请点击右边按钮将中文地址转换为拼音</label>
                                <div class="col-md-2" style="padding-left:0px">
                                    <asp:Button ID="btn_to_pinyin" runat="Server" CssClass="btn btn-info" 
                                        Text="转为拼音" style="padding-top:0px" Height="25px" 
                                        onclick="btn_to_pinyin_Click" />
                                </div>
                                <div class="col-md-1" style="color: Red; padding-top: 5px">
                                    &nbsp;</div>
                            </div>
                        </div>
                        <div class="panel-footer">
                            
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
            <%--第四部分--%>
            <div class="panel panel-primary">
                <div class="panel-heading">
                    <h5 class="panel-title">
                        特别注意事项及服务条款</h5>
                </div>
                <div class="panel-body">
                    <div class="form-group" style="margin-top: 10px">
                        <p style="font-family: @Adobe 楷体 Std R; font-size: 18px">
                            在您下单之前，您需要认证阅读并同意一下条款，确定您的快递物品没有违反国际运输相关条例 并且检查你所申报的物品是否符合相关保险条款。
                        </p>
                        <p style="margin-top: 10px">
                            <input type="checkbox" id="checkbox_item_first" />
                            I confirm that I have provided accurate weight(s) and dimension(s) of my parcel(s)
                            to my best knowledge. I agree that if the weight(s) and/or dimension(s) of my parcel(s)
                            is/are incorrect, addtional charges i.e.the postage difference and additional charges(150%
                            of the difference) will be applied to my card based on information provided by the
                            courier. Check here to confirm above details are correct*
                        </p>
                        <p>
                            <input type="checkbox" id="checkbox_item_second" />
                            I agreed to the <a href="package-advice.aspx">terms and conditions</a> , privacy
                            policy and no-compensation basis carriage. I confirm that my parcel(s) do not contain
                            any prohibited or restricted items. *
                        </p>
                    </div>
                    <div class="form-group" style="text-align: center;">
                        <asp:Button ID="btn_step_two" runat="Server" CssClass="btn btn-info" Width="160px"
                            Text="去购物车结算" OnClientClick="return isPageInfoValidate()" OnClick="btn_step_two_Click" />
                    </div>
                </div>
                <div class="panel-footer" style="color: #FF0000">
                    *&nbsp;只有同意服务条款可能购买</div>
            </div>
        </div>
    </div>
</asp:Content>
