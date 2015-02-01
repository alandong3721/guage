<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="send-addr-pop.aspx.cs"
    Inherits="WM_Project.views.inter_express.send_addr_pop" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../stylesheets/bootstrap.css" rel="stylesheet" type="text/css" />
    <link href="../../stylesheets/bootstrap-theme.css" rel="stylesheet" type="text/css" />
    <script src="../../javascripts/bootstrap.js" type="text/javascript"></script>
    <script src="../../javascripts/jquery-1.11.1.js" type="text/javascript"></script>

    <script type="text/javascript">
        function isSendAddrValidate() {

            // 判断发件地址是否为空
            var contact = document.getElementById('<%=txt_send_addr_contact.ClientID %>').value;
            var company = document.getElementById('<%=txt_send_addr_company.ClientID %>').value;
            var addr_line = document.getElementById('<%=txt_send_addr_line1.ClientID %>').value;
            var city = document.getElementById('<%=txt_send_addr_city.ClientID %>').value;
            var postcode = document.getElementById('<%=txt_send_addr_postcode.ClientID %>').value;
            var country = document.getElementById('<%=txt_send_addr_country.ClientID %>').value;
            var phone = document.getElementById('<%=txt_send_addr_phone.ClientID %>').value;

            if (contact.trim() == "" || company.trim() == "" || addr_line.trim() == "" || city.trim() == "" || postcode.trim() == "" || country.trim() == "" || phone.trim() == "") {
                alert("发件地址中带 * 号的不能为空！！");
                return false;
            }
        
        }
    
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <div class="panel panel-primary" style="font-size: 14px;width:600px;margin:0 auto;">
        <div class="panel-heading">
            <h6 class="panel-title">
                发件人地址信息&nbsp;
                <asp:CheckBox ID="send_addr" runat="server" Text="保存到地址簿" Checked="true" Font-Size="14px" />
            </h6>
        </div>
        <div class="panel-body">
            <div class="form-group" style="height:20px;clear:both">
                <div style="width:120px;float:left"><label class="control-label">
                    从地址簿中选取</label></div>
                <div style="width:360px;float:left">
                    <asp:DropDownList ID="send_addr_dropdown_list" runat="Server" CssClass="form-control"
                        Style="padding-top: 0px; padding-bottom: 0px; height: 25px;" OnSelectedIndexChanged="send_addr_dropdown_list_SelectedIndexChanged"
                        AutoPostBack="true">
                    </asp:DropDownList>
                </div>
            </div>
            <div class="form-group" style="clear: both;height:20px">
               <div style="width:120px;float:left;text-align:right;padding-right:20px;"> <label class="control-label" style="text-align: right">
                    收件人</label></div>
                <div style="width:360px;float:left">
                    <asp:TextBox ID="txt_send_addr_contact" CssClass="form-control" Style="padding-top: 0px;
                        padding-bottom: 0px; height: 25px;" runat="Server"></asp:TextBox>
                </div>
                <div style="color: Red; padding-top: 5px;width:60px;float:left;">
                    *</div>
            </div>
            <div class="form-group" style="clear: both;height:20px">
                <div style="width:120px;float:left;text-align:right;padding-right:20px;"><label class="control-label" style="text-align: right">
                    公司名</label></div>
                <div style="width:180px;float:left">
                    <asp:TextBox ID="txt_send_addr_company" CssClass="form-control" Style="padding-top: 0px;
                        padding-bottom: 0px; height: 25px;" runat="Server"></asp:TextBox>
                </div>
                <div style="width:180px;float:left;color: Red;">
                    * 如果不是公司请填写收件人</div>
            </div>
            <div class="form-group" style="clear: both;height:20px">
                <div style="width:120px;float:left;text-align:right;padding-right:20px;"><label class="control-label" style="padding-top: 6px; text-align: right">
                    地址1</label></div>
                <div style="width:360px;float:left">
                    <asp:TextBox ID="txt_send_addr_line1" Style="padding-top: 0px; padding-bottom: 0px;
                        height: 25px;" class="form-control" runat="Server"></asp:TextBox>
                </div>
                <div style="width:60px;float:left;color: Red; padding-top: 5px">
                    *</div>
            </div>
            <div class="form-group" style="clear: both;height:20px">
                <div style="width:120px;float:left;text-align:right;padding-right:20px;"><label class="control-label" style="text-align: right">
                    地址2</label></div>
                <div style="width:360px;float:left">
                    <asp:TextBox ID="txt_send_addr_line2" Style="padding-top: 0px; padding-bottom: 0px;
                        height: 25px;" class="form-control" runat="Server"></asp:TextBox>
                </div>
                <div style="width:60px;float:left;color: Red; padding-top: 5px">
                    &nbsp;</div>
            </div>
            <div class="form-group" style="clear: both;height:20px">
                <div style="width:120px;float:left;text-align:right;padding-right:20px;"><label class="control-label" style="text-align: right">
                    地址3</label></div>
                <div style="width:360px;float:left">
                    <asp:TextBox ID="txt_send_addr_line3" Style="padding-top: 0px; padding-bottom: 0px;
                        height: 25px;" runat="Server" class="form-control"></asp:TextBox>
                </div>
                <div style="width:60px;float:left;color: Red; padding-top: 5px">
                    &nbsp;</div>
            </div>
            <div class="form-group" style="clear: both;height:20px">
                <div style="width:120px;float:left;text-align:right;padding-right:20px;"><label class="control-label" style="text-align: right">
                    城市</label></div>
                <div style="width:360px;float:left">
                    <asp:TextBox ID="txt_send_addr_city" Style="padding-top: 0px; padding-bottom: 0px;
                        height: 25px;" class="form-control" runat="Server"></asp:TextBox>
                </div>
                <div style="width:60px;float:left;color: Red; padding-top: 5px">
                    *</div>
            </div>
            <div class="form-group" style="clear: both;height:20px">
               <div style="width:120px;float:left;text-align:right;padding-right:20px;"> <label class="control-label" style="text-align: right">
                    邮编</label></div>
                <div style="width:360px;float:left">
                    <asp:TextBox runat="Server" Style="padding-top: 0px; padding-bottom: 0px; height: 25px;"
                        class="form-control" ID="txt_send_addr_postcode"></asp:TextBox>
                </div>
                <div style="width:60px;float:left;color: Red; padding-top: 5px">
                    *</div>
            </div>
            <div class="form-group" style="clear: both;height:20px">
                <div style="width:120px;float:left;text-align:right;padding-right:20px;"><label class="control-label" style="text-align: right">
                    国家</label></div>
                <div style="width:360px;float:left">
                    <asp:TextBox runat="Server" ReadOnly="true" Style="padding-top: 0px; padding-bottom: 0px;
                        height: 25px;" class="form-control" ID="txt_send_addr_country"></asp:TextBox>
                </div>
                <div  style="width:60px;float:left;color: Red; padding-top: 5px">
                    *</div>
            </div>
            <div class="form-group" style="clear: both;height:20px">
                <div style="width:120px;float:left;text-align:right;padding-right:20px;"><label class="control-label" style="text-align: right">
                    手机号码</label></div>
                <div style="width:360px;float:left">
                    <asp:TextBox runat="Server" Style="padding-top: 0px; padding-bottom: 0px; height: 25px;"
                        class="form-control" ID="txt_send_addr_phone"></asp:TextBox>
                </div>
                <div style="width:60px;float:left;color: Red; padding-top: 5px">
                    *</div>
            </div>
            <div class="form-group" style="clear: both;height:20px">
                <div style="width:120px;float:left;text-align:right;padding-right:20px;"><label class="control-label" style="text-align: right">
                    邮箱</label></div>
                <div style="width:360px;float:left">
                    <asp:TextBox runat="Server" Style="padding-top: 0px; padding-bottom: 0px; height: 25px;"
                        class="form-control" ID="txt_send_addr_email"></asp:TextBox>
                </div>
                <div style="width:60px;float:left;color: Red; padding-top: 5px">
                    &nbsp;</div>
            </div>
            <div class="form-group" style="text-align:center;height:30px">
                
                <asp:Button ID="btn_get_send" Text="确定" runat="Server" CssClass="btn btn-info" style="padding-top:0px;padding-bottom:0px;height:30px" OnClientClick="return isSendAddrValidate()" 
                    onclick="btn_get_send_Click"/>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
