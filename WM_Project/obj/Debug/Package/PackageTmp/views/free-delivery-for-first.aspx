<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/reception-stage/home.Master" AutoEventWireup="true"
    CodeBehind="free-delivery-for-first.aspx.cs" Inherits="WM_Project.views.free_delivery_for_first" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%--此处写CSS、javascript代码--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="center_right" runat="server">
    <%--首包裹免费寄--%>
    <div class="row">
        <div class="panel panel-primary">
            <div class="panel-heading">
                <h3 class="panel-title">
                    首包裹免费寄</h3>
            </div>
            <div class="panel-body">
                <div>
                    <p style="text-align: center; margin-top: 30px">
                        <img src="../image/free-for-first-package.jpg" alt="" /></p>
                    <p style="margin-top: 20px; font-weight: 600; font-size: 19px" class="glyphicon glyphicon-hand-right">
                        参与资格 <font color="#107DE6" size="3">&nbsp;<b>①新注册用户; ②一次性充值满100英镑</b></font></p>
                    <p style="margin-top: 20px">
                        请按照您的实际情况，点击以下两个按钮了解活动详情：</p>
                </div>
                <div class="form-group" style="height: 130px;">
                    <div class="col-md-6" style="text-align: center">
                        <a href="#">
                            <img src="../image/free-package-from-uk.jpg" alt="" /></a></div>
                    <div class="col-md-6" style="text-align: center">
                        <a href="#">
                            <img src="../image/free-package-from-china.jpg" alt="" /></a></div>
                </div>
                <div style="margin-top: 20px">
                    <p style="font-size: 19px; font-weight: 600" class="glyphicon glyphicon-hand-right">
                        参与方法</p>
                    <p style="text-indent: 2em">
                        ① 注册:<a href="#">http://wm-global-express.com/views/regist.aspx</a></p>
                    <p style="text-indent: 2em">
                        ② 充值:<a href="#">http://wm-global-express.com/views/my-account.aspx</a></p>
                    <p style="text-indent: 2em">
                        ③ 下单:<a href="#">http://wm-global-express.com/views/index.aspx</a></p>
                </div>
                <div style="margin-top: 20px">
                    <p style="font-size: 19px; font-weight: 600" class="glyphicon glyphicon-hand-right">
                        提醒</p>
                    <p style="text-indent: 2em; line-height: 25px">
                        ① 免费只针对第一单，第二单无效</p>
                    <p style="text-indent: 2em; line-height: 25px">
                        ② 如果不是新用户，可以重新注册一个号，并充值</p>
                    <p style="font-size: 19px; font-weight: 600; margin-top: 20px" class="glyphicon glyphicon-hand-right">
                        基本常识</p>
                    <p style="text-indent: 2em; line-height: 25px">
                        “充值”是指您在华盟快递网站注册后，为您的华盟英超账户进行充值。一旦充值您便可以用我们的网站币付款，非常方便只需一秒钟，并且您的网站币账户流水（消费和充值记录）都会记录在您的帐户信息里，方便您轻松理财，且充值金额永久有效。</p>
                    <p style="text-indent: 2em; line-height: 25px;margin-top:20px;color:#FF0000">
                        一次性充值满100英镑免费寄首个包裹回国的优惠，国际快递用户最高可省59.64英镑（含国际运费和英国境内取件费），海淘转运至少可省55.83英镑（含国际运费和打包加固等费用）！</p>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
