<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/reception-stage/batch.Master" AutoEventWireup="true"
    CodeBehind="order-label.aspx.cs" Inherits="WM_Project.views.user_frame.order_label" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script type="text/javascript" src="../../script/jquery-1.11.1.js"></script>
<script type="text/javascript" src="../../script/jquery-1.4.2.min.js"></script>
    
<script type="text/javascript" >
    var i = 1;
    var sum = 0;
    $(function () {

       
        if ($("#alertMsg").val() != "") {
            alert($("#alertMsg").val());
        }
    });

    function haha() {

        if (i <= 50) {
            var temp = (i++ / sum * 100).toFixed(0);
            $(".progress-bar").css("width", temp + "%");
        }
    }
</script>
  
  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="center" runat="server">
    <%--条码下载、打印--%>
    <div class="row" id="page_five" runat="Server">
        <div class="panel panel-primary" style="width: 1010px">
            <div class="panel-heading">
                <h3 class="panel-title">
                    订单条码下载及打印</h3>
            </div>
            <div class="panel-body" style="padding-left: 0px; padding-right: 0px">
                
                <div style="border-bottom: 5px solid #E4E4E4; border-top: 5px solid #E4E4E4; width: 1010px" id="has_label" runat="server">
                    <asp:DataList ID="bar_code" runat="Server" OnItemCommand="bar_code_ItemCommand">
                        <HeaderTemplate>
                            <div style="padding-top: 5px; padding-bottom: 5px; width: 1008px; height: 30px">
                                <div style="width: 21%; float: left; font-weight: 600; text-align: center">
                                    订单号
                                </div>
                                <div style="width: 8%; float: left; font-weight: 600; text-align: center">
                                    包裹重
                                </div>
                                <div style="width: 12%; float: left; font-weight: 600; text-align: center">
                                    发件人
                                </div>
                                <div style="width: 12%; float: left; font-weight: 600; text-align: center">
                                    收件人
                                </div>
                                <div style="width: 9%; float: left; font-weight: 600; text-align: center">
                                    付款金额
                                </div>
                                <div style="width: 10%; float: left; font-weight: 600; text-align: center">
                                    服务方式
                                </div>
                                <div style="width: 14%; float: left; font-weight: 600; text-align: center">
                                    付款时间
                                </div>
                                <div style="width: 5%; float: left; font-weight: 600; text-align: center">
                                    PDF
                                </div>
                                <div style="width: 8%; float: left; font-weight: 600; text-align: center">
                                    下载
                                </div>
                            </div>
                            <div style="background: #E4E4E4; height: 5px">
                            </div>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <div style="clear: both; padding-top: 5px; padding-bottom: 5px; width: 1008px; height: 30px">
                                <div style="width: 21%; float: left; text-align: center; padding-left: 20px">
                                    <%#DataBinder.Eval(Container.DataItem,"order_number") %>
                                </div>
                                <div style="width: 8%; float: left; text-align: center">
                                    <%#DataBinder.Eval(Container.DataItem,"weight") %>
                                </div>
                                <div style="width: 12%; float: left; text-align: center">
                                    <%#DataBinder.Eval(Container.DataItem,"sender") %>
                                </div>
                                <div style="width: 12%; float: left; text-align: center">
                                    <%#DataBinder.Eval(Container.DataItem,"receiver") %>
                                </div>
                                <div style="width: 9%; float: left; text-align: center">
                                    £<asp:Label ID="item_money" runat="Server" Text='<%#DataBinder.Eval(Container.DataItem,"pay") %>'></asp:Label>
                                </div>
                                <div style="width: 10%; float: left; text-align: center">
                                    <%#DataBinder.Eval(Container.DataItem,"postway") %>
                                </div>
                                <div style="width: 14%; float: left; text-align: center">
                                    <%#DataBinder.Eval(Container.DataItem,"time") %>
                                </div>
                                <div style="width: 5%; float: left; text-align: center">
                                    <asp:ImageButton ID="detail" runat="Server" ImageUrl="../../image/images/copy.gif" CommandName="PrintInWeb"
                                        CommandArgument='<%#DataBinder.Eval(Container.DataItem,"order_number") %>' />
                                </div>
                                <div style="width: 8%; float: left; text-align: center">
                                    <asp:Button runat="Server" ID="Button1" CssClass="download" CommandName="PrintByDownload"
                                        Height="25px" Text="下载" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"order_number") %>' />
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
                    <div class="form_group" style="padding-top: 5px; padding-bottom: 5px; text-align: right;
                        padding-right: 10px">
                        <asp:Button ID="btn_downAll" runat="Server" Text="下载全部" CssClass="btn btn-info" OnClick="btn_downAll_Click" />
                    </div>
                </div>

                <div id="has_no_label" runat="server" visible="false" class="form-group" style="height:200px;padding-top:100px">
                    <p style=" font-weight:600; text-align:center;color:red"><%=name %>&nbsp;您好，由于网络原因所有标签都下载失败，请您到“订单管理”—"需要重新获取运单标签的订单"中下载</p>
                </div>

            </div>

            <div class=" panel-footer" id="notice_undownload" runat="server" visible="false">
                <p style=" font-weight:600">有<%=un_download %>条标签下载失败,你可以在<font color="FF0000"> “订单管理”—“需要重新获取运单标签的订单”</font>中进行下载</p>
            </div>
            <div>
            <input type="hidden" id="alertMsg" value="<%=alertMsg%>"/>
            </div>
        </div>
    </div>

</asp:Content>
