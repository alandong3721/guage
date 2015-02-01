<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/reception-stage/home.Master" AutoEventWireup="true" CodeBehind="custom-red-packet.aspx.cs" Inherits="WM_Project.views.activity_area.custom_red_packet" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<%--此处写CSS、javascript代码--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="center_right" runat="server">
 <%--客户红包--%>
    <div id="Div1" class="row" runat="Server">
        <div class="panel panel-primary">
            <div class="panel-heading">
                <h3 class="panel-title">
                    客户红包</h3>
            </div>
            <div class="panel-body">
                <div class="form-group">
                    <p style="text-indent: 2em; line-height: 25px">
                        华盟快递红包计划是针对网站注册用户的不定期奖励。客户可以通过输入红包编码，通常为字母和数字的组合，领取不同金额的红包，即可在下单的时候抵用相应的金额。</p>
                    <p style="text-indent: 2em; line-height: 25px; margin-top: 20px; font-weight: 600">
                        【如何获得红包（红包编码）】</p>
                    <p style="text-indent: 2em; line-height: 25px;">
                        您可以通过参与我们举行的各种活动，比如海淘晒单以及论坛盖楼等活动获得红包。有时我们也会不定期进行红包大派送，您可以登陆我们网站的“活动专区”， 或者通过关注我们的新浪微博（微博账号：英国华盟快递）和微信（微信号：WM-Express），随时了解我们的最新活动。</p>
                    <p style="text-align: center">
                        <img src="../../image/image/how-to-get-red-packet.png" alt="" /></p>
                    <p style="text-indent: 2em; line-height: 25px; margin-top: 30px; font-weight: 600">
                        【如何领取红包】</p>
                    <p style="text-indent: 2em; line-height: 25px">
                        当您获得红包编码以后，请注册并登录，点击右上角“账户信息”，即可在左侧看见“我的红包”专区。然后请点击“+领取红包”按钮，在方框里输入已经获得的红包编码。输入红包编码后再点击红色“领取红包”按钮（如图下图所示）即可领取红包。
                        请注意：红包编码通常为数字和字母的组合，不区分大小写，不包含任何符号。</p>
                    <p style="text-indent: 2em; margin-top: 30px">
                        所有已经获得的红包都将在右侧“我的红包”中显示，如下图所示:</p>
                    <p style="text-align: center;">
                        <img src="../../image/image/how-to-receive-red-packet.png" alt="" /></p>
                    <p style="text-indent: 2em; font-weight: 600; margin-top: 40px">
                        【如何使用红包】</p>
                    <p style="text-indent: 2em; line-height: 25px;">
                        成功领取红包以后，每当您下单成功进入付款页面的时候，都会在右下角看见“请选择红包”下拉菜单，在这里您可以选择想要使用的红包金额。 请注意：每个红包只能使用一次，每次下单只能使用一个红包，且没有最低消费额度限制。
                        如图下图所示，所需支付金额为50镑，如果您选择使用10镑红包，待支付金额从原来的50镑变为40镑，红包使用成功。接下来只需要选择任何一种支付方式进行支付即可。付款成功以后，这个10镑的红包将会失效。</p>
                        <p style="text-align:center"><img src="../../image/image/how-to-use-red-packet.png" alt="" /></p>
                        <p style="color:#FF0000;text-indent:2em;margin-top:20px">如果您还有什么疑问请与我们的客服联系。</p>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
