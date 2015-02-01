<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/reception-stage/batch.Master"
    AutoEventWireup="true" CodeBehind="batch-import.aspx.cs" Inherits="WM_Project.views.inter_express.batch_import" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%--此处写CSS、javascript代码--%>
    <script type="text/javascript">

        ///登陆前的验证

        function isNull() {
            var name = document.getElementById("txt_username").value;
            var password = document.getElementById("txt_password").value;

            if (name == "" || password == "") {
                alert("带*号的不能为空！");
                return false;
            }
            return true;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="center" runat="server">
    <%--第一部分--%>
    <div class="row" id="page_one" runat="Server" visible="false" style="width: 80%;margin:0 auto;">
        <div class="panel panel-primary">
            <div class="panel-heading">
                <h3 class="panel-title">
                    User Login</h3>
            </div>
            <div class="panel-body">
                <div class="form-group" style="height: 30px; margin-top: 10px">
                    <label for="username" class="col-md-3 control-label" style="padding-top: 8px;text-align:right">
                        User&nbsp;&nbsp;Name:</label>
                    <div class="col-md-7" style="padding-left: 0px">
                        <input type="text" class="form-control" id="txt_username" name="txt_username" placeholder="please input user name" />
                    </div>
                    <div class="col-md-2" style="color: #FF0000; padding-top: 10px">
                        *
                    </div>
                </div>
                <div class="form-group" style="height: 30px">
                    <label for="password" class="col-md-3 control-label" style="padding-top: 8px;text-align:right">
                        Password:</label>
                    <div class="col-md-7" style="padding-left: 0px">
                        <input type="password" class="form-control" name="txt_password" id="txt_password" />
                    </div>
                    <div class="col-md-2" style="color: #FF0000; padding-top: 10px">
                        *
                    </div>
                </div>
                <div class="form-group" style="height: 30px">
                    <label for="code" class="col-md-3 control-label" style="padding-top: 8px;text-align:right">
                        Code:</label>
                    <div class="col-md-5" style="padding-left: 0px">
                        <input type="text" class="form-control" name="txt_code" id="txt_code" />
                    </div>
                    <div class="col-md-2 " style="text-align: right">
                        <img src="../code.aspx" alt="" height="30px" onclick="this.src=this.src+'?'" /></div>
                    <div class="col-md-2" style="color: #FF0000; padding-top: 10px">
                        *
                    </div>
                </div>
                <div class="form-group" style="height: 30px">
                    <div style="text-align: center">
                        <asp:Button ID="btn_login" runat="Server" Text="登陆" OnClientClick="return isNull();"
                            CssClass="btn btn-info" OnClick="btn_login_Click" /></div>
                </div>
            </div>
        </div>
    </div>
    <%--第二部分--%>
    <div id="page_two" runat="Server" visible="false" class="row" style="width: 96%;
        margin: 0 auto">
        <div class="panel panel-primary">
            <div class="panel-heading">
                <h3 class="panel-title">
                    批量上传出单，适用于Parcelforce，PostNL，China Post EMS</h3>
            </div>
            <div class="panel-body">
                <div class="form-group" style="height: 10px">
                </div>
                <div class="form-group">
                    <div style="height: 40px; background: #DADADA; padding-top: 10px; padding-left: 20px;
                        font-weight: 600">
                        Upload Order File上传批量下单Excel文件</div>
                    <div style="margin-top: 20px; height: 30px; margin-bottom: 10px">
                        <div class="col-md-5">
                            <label class="label-control">
                                Upload Excel File(上传EXCEL文)</label></div>
                        <div class="col-md-7">
                            <asp:FileUpload ID="upload_ems_excel" runat="server" /></div>
                    </div>
                    <div style="height: 40px; padding-top: 10px">
                        <div class="col-md-2 col-md-offset-10">
                            <asp:Button ID="btn_upload" runat="Server" CssClass="btn btn-info" Text="上传" Width="100%"
                                OnClick="btn_upload_Click" /></div>
                    </div>
                </div>
                <div style="margin-top: 0px; margin-bottom: 40px; height: 2px; background: #DADADA">
                </div>
                <div class="form-group">
                    <div style="height: 40px; background: #DADADA; padding-top: 10px; padding-left: 20px;
                        font-weight: 600">
                        Download Template with Examples 下载模板和示例
                    </div>
                    <div style="margin-top: 20px; height: 120px; margin-bottom: 10px;">
                        <p>
                            <a href="../excel-template/AUTPostNL.xls" style="text-decoration: underline; font-weight: 600">
                            Template for PostNL 荷兰邮政模板</a></p>
                        <p>
                            <a href="../excel-template/AUTPostNL.xls" style="text-decoration: underline; font-weight: 600">
                             Template for China Post EMS 华盟EMS专线模板</a></p>
                        <p>
                            <a href="../excel-template/PostPFofCollection.xls" style="text-decoration: underline;
                                font-weight: 600">Template for Parcelforce Collection 皇家邮政上门取件模板（表格中&nbsp;I&nbsp;栏&nbsp;china-ipe&nbsp;代表经济包，如需优先包，将他改为&nbsp;china-gpr&nbsp;即可）</a></p>
                        <p>
                            <a href="../excel-template/PostPFofDelivery.xls" style="text-decoration: underline;
                                font-weight: 600">Template for Parcelforce Drop Off 皇家邮政送投模板（表格中&nbsp;I&nbsp;栏&nbsp;china-ipe&nbsp;代表经济包，如需优先包，将他改为&nbsp;china-gpr&nbsp;即可）</a></p>
                    </div>
                </div>
                <div style="margin-top: 30px; margin-bottom: 30px; height: 2px; background: #DADADA">
                </div>
                <div class="from-group" style="margin-top: 20px">
                    <p style="line-height: 25px; font-weight: 600">
                        您好，感谢您使用&nbsp;&nbsp;Parcelforce，PostNL，China Post EMS&nbsp;&nbsp;批量上传服务。 我们的下单流程如下：</p>
                    <p style="line-height: 25px">
                        1.在我们官方网站&nbsp;http://wm-global-express.com/ &nbsp;<font color="#FF0000"><b>注册、登陆</b></font></p>
                    <p style="line-height: 25px">
                        2.<font color="#FF0000"><b>下载</b></font>‘所需要的&nbsp;批量上传服务对应的’&nbsp;Excel&nbsp;表格</p>
                    <p style="line-height: 25px">
                        3.<font color="#FF0000"><b>填写</b></font>‘&nbsp;所需要的&nbsp;批量上传服务对应的’&nbsp;Excel&nbsp;表格。</p>
                    <p>
                        (a)&nbsp;如果您需要我们提供上门取件服务，请您确保在同一张表格上的包裹都在同一取件地址。 假如您有10件包裹在取件地址A，20件包裹在取件地址B，请您分成表格A和表格B，分开两次上传</p>
                    <p>
                        (b)&nbsp;使用英文或者拼音填写表格</p>
                    <p>
                        (c)&nbsp;一行填写一个包裹信息</p>
                    <p>
                        (d)&nbsp;申报价值必须与购物小票面额一致，如因不一致造成海关退回，扣留等由您自己负责 包裹描述必须详细准确，如是婴儿奶粉，请填写‘baby milk’.
                    </p>
                    <p style="line-height: 25px">
                        4、<font color="#FF0000"><b>上传</b></font>‘&nbsp;所需要的&nbsp;批量上传服务对应的’ 点击‘选择文件’上传已经填写好的Excel表格后，点击‘submit’提交.</p>
                    <p>
                        5、 按屏幕提示进行<font color="#FF0000"><b>支付</b></font>.</p>
                    <p>
                        6、支付成功后，条形码自动生成。您可以自行进行保存、<font color="#FF0000"><b>打印</b></font>。</p>
                    <p>
                        7、然后送到华盟快递指定&nbsp;<font color="#FF0000"><b>Drop-off</b></font>&nbsp;地址 如果您需要我们提供<font
                            color="#FF0000"><b>上门取件</b></font>服务，请您将下面表格填好并发邮件到邮箱&nbsp;<span style="color: rgb(25, 38, 102);
                                font-family: verdana, sans-serif; font-size: 12px; font-style: normal; font-variant: normal;
                                font-weight: normal; letter-spacing: normal; line-height: 19.2000007629395px;
                                orphans: auto; text-align: start; text-indent: 0px; text-transform: none; white-space: normal;
                                widows: auto; word-spacing: 0px; -webkit-text-stroke-width: 0px; display: inline !important;
                                float: none; background-color: rgb(255, 255, 255);">wm5fenzhuang@gmail.com</span>请保证您的华盟快递预存款账号有充足余额
                        以便我们的工作人员进行取件费用的扣款和预定取件服务.
                    </p>
                    <p style="line-height: 30px; padding-top: 10px;">
                        <a href="../excel-template/collection.doc" style="font-weight: 600; font-size: 20px;
                            text-decoration: underline">Download Collection File（点击下载取件申请：PostNL取件申请）</a></p>
                </div>
            </div>
            <div class="panel-footer">
                <p style="color:#FF0000">*&nbsp;批量上传出单，适用于Parcelforce，PostNL，China Post EMS</p>
            </div>
        </div>
    </div>
</asp:Content>
