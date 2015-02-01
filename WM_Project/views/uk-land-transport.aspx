<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/reception-stage/home.Master"
    AutoEventWireup="true" CodeBehind="uk-land-transport.aspx.cs" Inherits="WM_Project.views.uk_land_transport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="center_right" runat="server">
    <div class="panel panel-primary">
        <div class="panel-heading">
            <h5 class="panel-title">
                请选择 UK 境内取件服务</h5>
        </div>
        <div class="panel-body">
            <asp:DataList ID="uk_trans_list" runat="Server" onitemcommand="uk_trans_list_ItemCommand">
                <%--头模板--%>
                <HeaderTemplate>
                    <table style="width: 100%; padding-left: 0; padding-right: 0;">
                </HeaderTemplate>
                <%--项模板--%>
                <ItemTemplate>
                    <tr style="height: 70px;">
                        <td valign="middle" align="left" style="width: 110px; text-align:right;">
                            <asp:Image runat="Server" ID="image" Width="100px" Height="45px" ImageUrl='<%#DataBinder.Eval(Container.DataItem,"imagePath") %>' />
                        </td>
                        <td valign="middle" style="width: 300px; padding-right: 0; text-align: left;padding-left:10px">
                            <%#DataBinder.Eval(Container.DataItem,"note") %><asp:HiddenField ID="hidden" runat="Server"
                                Value='<%#DataBinder.Eval(Container.DataItem,"postname") %>' />
                        </td>
                        <td align="right" valign="middle" style="width: 120px; text-align: center; padding-right: 0">
                            &pound;<asp:Label runat="Server" ForeColor="#3C85C4" ID="lb_money" Text='<%#DataBinder.Eval(Container.DataItem,"money") %>'></asp:Label>
                        </td>
                        <td align="right" valign="middle" style="width:80px; padding-right: 0; text-align: right">
                            <asp:LinkButton runat="Server" ID="buy" Font-Underline="false" CommandName="buy"
                                CommandArgument='<%#DataBinder.Eval(Container.DataItem,"postname") %>'>购买</asp:LinkButton>
                        </td>
                    </tr>
                </ItemTemplate>
                <%--分割模板--%>
                <SeparatorTemplate>
                </SeparatorTemplate>
                <%--脚模板--%>
                <FooterTemplate>
                    </table></FooterTemplate>
            </asp:DataList>
        </div>
        <div class="panel-body">
            <div style="height: 2px; background: #DADADA; margin-bottom: 20px">
            </div>
            <p style="font-weight: 600">
                温馨提示
            </p>
            <p style="line-height: 25px">
                1. 选择Collect+服务，2-3天包裹到达我们手中。你无需在家等待取件司机，可以携带Collect+ pdf条码送投至遍布英国5500多间便利店。点击这里查找距离你最近的便利店<a href="http://www.collectplus.co.uk/orders/new">http://www.collectplus.co.uk/orders/new</a>
            </p>
            <p style="line-height: 25px">
                2. 选择UKmail服务，1-2天包裹到达我们手中。取件司机携带条码（含tracking number）上门服务，多包裹无需捆绑在一起。
            </p>
        </div>
        <div class="panel-footer">
        </div>
    </div>
</asp:Content>
