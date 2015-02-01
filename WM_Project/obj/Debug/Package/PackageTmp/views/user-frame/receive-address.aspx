<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="receive-address.aspx.cs"
    Inherits="WM_Project.views.user_frame.receive_address" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../stylesheets/bootstrap.css" rel="stylesheet" type="text/css" />
    <link href="../../stylesheets/bootstrap-theme.css" rel="stylesheet" type="text/css" />
    <script src="../../javascripts/bootstrap.js" type="text/javascript"></script>
    <script src="../../javascripts/jquery-1.11.1.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="panel panel-primary" style="width: 780px">
        <div class="panel-heading">
            <h5>
                收件地址管理</h5>
        </div>
        <div class="panel-body">
            <div class="form-group">
                <div style="height: 30px; padding-top: 10px; width: 360px; float: left; font-size: 18px;
                    font-weight: 700">
                    收件地址</div>
                <div style="text-align: right; height: 30px; width: 380px; float: left">
                    <asp:Button ID="btn_addreceiveAddress" runat="Server" Text="添加新地址" CssClass="btn btn-info"
                        OnClick="btn_addreceiveAddress_Click" /></div>
            </div>
            <div class="form-group" style="clear: both; padding-top: 10px">
                <div style="height: 2px; background: #DADADA">
                </div>
            </div>
            <div class="form-group">
                <asp:DataList ID="datalist_receive_address" runat="Server" OnItemCommand="receive_address_ItemCommand">
                    <ItemTemplate>
                        <div style="width: 740px">
                            <div style="text-align: left; width: 610px; float: left">
                                <%#DataBinder.Eval(Container.DataItem, "addressInfo")%>
                            </div>
                            <div style="text-align: right; width: 30px; float: left; padding: 0; margin: 0; float: left">
                                <asp:ImageButton ID="img_del" runat="Server" ImageUrl="../../image/images/del.jpg"
                                    CommandName="del" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"addr_id") %>' />
                            </div>
                            <div style="width: 30px; float: left; text-align: right; padding: 0; margin: 0; float: left">
                                <asp:ImageButton ID="img_edit" runat="Server" ImageUrl="../../image/images/copy.gif"
                                    CommandName="edit" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"addr_id") %>' />
                            </div>
                            <div style="width: 70px; float: left; text-align: right; padding: 0; margin: 0; float: left">
                                <asp:LinkButton ID="lbtn_set" runat="Server" Text="设为默认" CommandName="set" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"addr_id") %>'></asp:LinkButton>
                            </div>
                        </div>
                        </div>
                    </ItemTemplate>
                    <SeparatorTemplate>
                        <div>
                            <div style="margin-top: 10px; margin-bottom: 10px; height: 2px; background: #DADADA">
                            </div>
                        </div>
                    </SeparatorTemplate>
                    <FooterTemplate>
                        <div>
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
                        <a href="receive-address.aspx?pageNow=1">首页</a>&nbsp;&nbsp;&nbsp; <a href="receive-address.aspx?pageNow=<%=address_page_now-1 %>">
                            上一页</a>&nbsp;&nbsp;&nbsp;
                        <%} %>
                        <%if (address_page_now != address_page_count)
                          { %>
                        <a href="receive-address.aspx?part=2&action=receive&pageNow=<%=address_page_now+1 %>">
                            下一页</a>&nbsp;&nbsp;&nbsp; <a href="receive-address.aspx?part=2&action=receive&pageNow=<%=address_page_count %>">
                                尾页</a>&nbsp;&nbsp;&nbsp;
                        <%} %>
                        <%} %>
                    </p>
                </div>
                <%
                  } %>
            </div>
        </div>
        <div class="panel-footer">
        </div>
    </div>
    <div class="panel panel-primary" id="send_part_edit_address" runat="Server" visible="false" style="width: 780px;">
        <div class="panel-heading">
            <h5>
                编辑新地址</h5>
        </div>
        <div class="panel-body">
            <div class="form-group" style="height:25px">
                <div style="width: 120px; float: left">
                    <font color="#cc3399" style="font-weight: bold; font-size: 18px;">
                        <asp:Label ID="edit_addressInfo" runat="Server" Text="新增发件地址"></asp:Label></font>
                </div>
                <div align="left" style="width: 620px; float: left">
                    带<font color="#FF0000">*</font>为必填项，其余可不填<asp:Label ID="lb_addr_id" runat="Server"
                        Visible="false"></asp:Label>
                </div>
            </div>
            <div class="form-group" style="height: 2px; background: #DADADA">
            </div>
            <div class="form-group" style="height:30px;clear:both">
                <div style="width: 140px; float: left; text-align: right; padding-right: 20px; padding-top: 5px">
                    <label class="control-label">
                        联系人名</label></div>
                <div style="width: 500px; float: left">
                    <asp:TextBox ID="txt_addr_contact" class="form-control contact" runat="Server"></asp:TextBox>
                </div>
                <div style="color: Red; padding-top: 10px; float: left; width: 60px; padding-left: 10px">
                    *</div>
            </div>
            <div class="form-group" style="clear:both;height:30px">
                <div style="width: 140px; float: left; text-align: right; padding-right: 20px; padding-top: 5px">
                    <label class="control-label">
                        公司名</label></div>
                <div style="width: 300px; float: left">
                    <asp:TextBox ID="txt_addr_company_name" class="form-control company" runat="Server"></asp:TextBox>
                </div>
                <div style="float: left; color: Red; padding-top: 6px; width: 300px">
                    * 如果不是公司请填联系人</div>
            </div>
            <div class="form-group"  style="clear:both;height:30px">
                <div style="width: 140px; float: left; text-align: right; padding-right: 20px; padding-top: 5px">
                    <label class="control-label">
                        地址1</label></div>
                <div style="width: 500px; float: left">
                    <asp:TextBox ID="txt_addr_line1" class="form-control line1" runat="Server"></asp:TextBox>
                </div>
                <div style="color: Red; padding-top: 10px; float: left; width: 60px; padding-left: 10px">
                    *</div>
            </div>
            <div class="form-group"  style="clear:both;height:30px">
                <div style="width: 140px; float: left; text-align: right; padding-right: 20px; padding-top: 5px">
                    <label class="control-label">
                        地址2</label></div>
                <div style="width: 500px; float: left">
                    <asp:TextBox ID="txt_addr_line2" class="form-control line2" runat="Server"></asp:TextBox>
                </div>
                <div style="color: Red; padding-top: 10px; float: left; width: 60px; padding-left: 10px">
                    &nbsp;</div>
            </div>
            <div class="form-group"  style="clear:both;height:30px">
                <div style="width: 140px; float: left; text-align: right; padding-right: 20px; padding-top: 5px">
                    <label class="control-label">
                        地址3</label></div>
                <div style="width: 500px; float: left">
                    <asp:TextBox ID="txt_addr_line3" runat="Server" class="form-control line3"></asp:TextBox>
                </div>
                <div style="color: Red; padding-top: 10px; float: left; width: 60px; padding-left: 10px">
                    &nbsp;</div>
            </div>
            <div class="form-group"  style="clear:both;height:30px">
                <div style="width: 140px; float: left; text-align: right; padding-right: 20px; padding-top: 5px">
                    <label class="control-label">
                        城市</label></div>
                <div style="width: 500px; float: left">
                    <asp:TextBox ID="txt_addr_city" class="form-control city" runat="Server"></asp:TextBox>
                </div>
                <div style="color: Red; padding-top: 10px; float: left; width: 60px; padding-left: 10px">
                    *</div>
            </div>
            <div class="form-group" style="height: 30px;clear:both">
                <div style="width: 140px; float: left; text-align: right; padding-right: 20px; padding-top: 5px">
                    <label class="control-label">
                        邮编</label></div>
                <div style="width: 500px; float: left">
                    <asp:TextBox runat="Server" class="form-control postcode" ID="txt_addr_postcode"></asp:TextBox>
                </div>
                <div style="color: Red; padding-top: 10px; float: left; width: 60px; padding-left: 10px">
                    *</div>
            </div>
            <div class="form-group" style="height: 30px;clear:both">
                <div style="width: 140px; float: left; text-align: right; padding-right: 20px; padding-top: 5px">
                    <label class="control-label">
                        国家
                    </label>
                </div>
                <div style="width: 500px; float: left">
                    <asp:TextBox runat="Server" class="form-control country" ID="txt_addr_country"></asp:TextBox>
                </div>
                <div style="color: Red; padding-top: 10px; float: left; width: 60px; padding-left: 10px">
                    *</div>
            </div>
            <div class="form-group" style="height: 30px;clear:both">
                <div style="width: 140px; float: left; text-align: right; padding-right: 20px; padding-top: 5px">
                    <label class=" control-label">
                        手机号码</label></div>
                <div style="width: 500px; float: left">
                    <asp:TextBox ID="txt_addr_phone" runat="Server" class="form-control phone"></asp:TextBox>
                </div>
                <div style="color: Red; padding-top: 10px; float: left; width: 60px; padding-left: 10px">
                    *</div>
            </div>
            <div class="form-group" style="height: 30px;clear:both">
                <div style="width: 140px; float: left; text-align: right; padding-right: 20px; padding-top: 5px">
                    <label class="control-label">
                        邮箱</label></div>
                <div style="width: 500px; float: left">
                    <asp:TextBox runat="Server" class="form-control email" ID="txt_addr_email"></asp:TextBox>
                </div>
                <div style="color: Red; padding-top: 10px; float: left; width: 60px; padding-left: 10px">
                    *</div>
            </div>
            <div class="form-group" style="height: 30px;clear:both">
                <div style="height: 25px; text-align:center">
                    <asp:CheckBox ID="ck_default" runat="Server" Text="&nbsp;设为默认"></asp:CheckBox>&nbsp;&nbsp;
                    <asp:Button ID="btn_save" runat="Server" Text="保存" CssClass="btn btn-info save" OnClick="btn_save_Click">
                    </asp:Button>
                </div>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
