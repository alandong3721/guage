<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/reception-stage/home.Master" AutoEventWireup="true"
    CodeBehind="custom-point.aspx.cs" Inherits="WM_Project.views.custom_point" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%--此处写CSS、javascript代码--%>
    <%--CSS代码--%>
    <style type="text/css"></style>
    <%--javascript代码--%>
    <script type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="center_right" runat="server">
    <%--客户积分--%>
    <div class="row" runat="Server">
        <div class="panel panel-primary">
            <div class="panel-heading">
                <h3 class="panel-title">
                    客户积分</h3>
            </div>
            <div class="panel-body">
                <div class="form-group">
                    <p style="text-indent: 2em; line-height: 25px">
                        华盟快递客户积分计划是对网站注册用户的奖励，客户可在网站通过各种营销渠道获取积分，比如注册积分，消费积分，分享积分，推荐积分和盟友积分。 积分可兑换到充值帐户后在本网站当钱使用。在帐户信息里有详细的积分历史记录，方便查询您的积分明细。
                    </p>
                    <p style="text-align: center">
                        <img src="../image/how-to-reward-points.png" alt="" /></p>
                    <p style="text-align: center; font-size: 24px; font-weight: 800; color: #FF0000;
                        font-family: @Adobe 黑体 Std R">
                        在华盟积分真的可以当钱花！！</p>
                    <p style="margin-top: 20px; font-weight: 600; line-height: 25px">
                        如何获得积分</p>
                    <p class="glyphicon glyphicon-hand-right" style="margin-top: 10px; line-height: 25px;">
                        &nbsp;<font color="#FF000">注册积分：</font>注册成为华盟快递会员将立即获得<font color="#FF000">100积分</font>！</p>
                    <p class="glyphicon glyphicon-hand-right" style="margin-top: 10px; line-height: 25px;">
                        &nbsp;<font color="#FF000">消费积分：</font>每张下单成功的国际快递订单和海淘转运都可自动获得消费积分，获得的积分以订单提交时的金额为准，每消费1英镑积1分，订单仅限整数部分积分！</p>
                    <p class="glyphicon glyphicon-hand-right" style="margin-top: 10px; line-height: 25px;">
                        &nbsp;<font color="#FF000">分享积分：</font>购买过华盟快递的服务，撰写您对服务的评价，可获得<font color="#FF000">500积分奖励</font>。联系客服后积分会即时充入您的积分账户里！</p>
                    <p class="glyphicon glyphicon-hand-right" style="margin-top: 10px; line-height: 25px;">
                        &nbsp;<font color="#FF000">推荐积分：</font>每推荐一位新客户在华盟快递成功下单并在包裹被取走后，都将获得<font color="#FF000">首次300积分奖励</font>，完全不受人数限制，推荐的多赚的多！</p>
                    <p class="glyphicon glyphicon-hand-right" style="margin-top: 10px; line-height: 25px;">
                        &nbsp;<font color="#FF000">盟友积分：</font>当您推荐的客户首次下单成功，之后此客户每成功下单后您都将获得他<font color="#FF000">消费积分中10%的积分奖励</font>，更激动人心的是，当您推荐的客户再推荐其它客户后，您将再获得新推荐客户的消费积分中的一定数量作为奖励，以此类推，无穷无尽，详情见盟友计划！</p>
                    <p style="margin-top: 20px; text-indent: 2em">
                        华盟快递还会不定期推出各类积分加速与积分推广活动，，比如每消费1英镑积2分等，用户参与各种营销活动均可赚取更多积分。详情请关注我们的官方微博和微信及时获得最新最热的活动公告。
                    </p>
                    <p style="margin: 20px; font-weight: 600">
                        积分换算公式</p>
                    <p style="text-indent: 2em">
                        <font color="#FF0000">100积分 = 1英镑 </font>（或：1点积分 = 0.01英镑）</p>
                    <p style="text-indent: 2em; line-height: 25px">
                        华盟快递还会不定期将积分升值，比如100积分 = 3英镑。详情请关注我们的官方微博和微信及时获得最新最热的活动公告。</p>
                    <p style="font-weight: 600; margin-top: 20px">
                        查看与兑换积分</p>
                    <p style="text-indent: 2em; line-height: 25px;">
                        在您的帐户信息里有详细的积分历史记录，方便查询您的积分明细。在盟友积分记录里可以查看所有盟友的订单号和对应金额给您带来的积分奖励明细，方便您了解所有盟友为您创造的积分奖励。</p>
                    <p style="text-indent: 2em; line-height: 25px;">
                        华盟快递采用积分月和兑换月方式，客户在第一个月的所有积分可在第二个月开始兑换，在第二个月的所有积分可在第三个月开始兑换，以此类推。</p>
                    <p style="text-indent: 2em; line-height: 25px;">
                        在帐户信息的积分历史记录里，您可以把积分兑换到充值帐户后在华盟快递网站当钱使用。客户在华盟快递网站里的积分为本网站的营销工具，所以不能转换为现金给客户。</p>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
