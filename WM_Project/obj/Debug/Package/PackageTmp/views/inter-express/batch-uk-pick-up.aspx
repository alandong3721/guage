<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/reception-stage/batch.Master" AutoEventWireup="true" CodeBehind="batch-uk-pick-up.aspx.cs" Inherits="WM_Project.views.inter_express.batch_uk_pick_up" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="center" runat="server">
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
                        <td valign="middle" style="width: 500px; padding-right: 0; text-align: left;padding-left:10px">
                            <%#DataBinder.Eval(Container.DataItem,"note") %><asp:HiddenField ID="hidden" runat="Server"
                                Value='<%#DataBinder.Eval(Container.DataItem,"postname") %>' />
                        </td>
                        <td align="right" valign="middle" style="width: 240px; text-align: center; padding-right: 0">
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
                1、Parcelforce economy 服务每次最多只能下单一个包裹
            </p>
            <p style="line-height: 25px">
                2、Parcelforce priority auto 服务每次最多只能下单三个包裹
            </p>
            <p style="line-height: 25px">
                3、全部服务即时出单，华盟快递网站上实时追踪您的包裹
            </p>
            <p style="line-height: 25px">
                4、为了您的包裹准时到达，请准确的计算您的包裹重量和尺寸
            </p>
            <p style="line-height: 25px">
                5、Premium服务包含破损，丢失，延时赔偿上限50镑</p>
            <p style="line-height: 25px">
                6、华盟快递提供市场最低价格，欢迎批量下单客户联系我们洽谈合作价格
            </p>
            <p style="line-height: 25px">
                7、万件齐发，批量导入功能支持多单同下。批量打印功能一键打印所有文档。
            </p>
        </div>
        <div class="panel-footer">
            <p style="color:#3C85C4">
                *&nbsp;英国境内取件服务的选择,CollectionPlus 需要下载PDF、 UKMail一个地址只有一个Track number</p>
        </div>
    </div>
</asp:Content>
