<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/reception-stage/home.Master" AutoEventWireup="true"
    CodeBehind="batch-import-old.aspx.cs" Inherits="WM_Project.views.inter_express.batch_import_old" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%--此处写CSS、javascript代码--%>
    <script type="text/javascript">

        ///登陆前的验证

        function isNull() {
            var name = document.getElementById("txt_username").value;
            var password = document.getElementById("txt_password").value;
            var code = document.getElementById("txt_code").value;

            if (name == "" || password == "" || code == "") {
                alert("带*号的不能为空！");
                return false;
            }

            return true;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="center_right" runat="server">
    <%--第一部分--%>
    <div class="row" id="page_one" runat="Server" visible="false" style="width: 100%;
        margin: 0 auto">
        <div class="panel panel-primary">
            <div class="panel-heading">
                <h3 class="panel-title">
                    User Login</h3>
            </div>
            <div class="panel-body">
                <div class="form-group" style="height: 30px; margin-top: 10px">
                    <label for="username" class="col-md-3 control-label" style="padding-top: 8px;">
                        User&nbsp;&nbsp;Name:</label>
                    <div class="col-md-7" style="padding-left: 0px">
                        <input type="text" class="form-control" id="txt_username" name="txt_username" placeholder="please input user name" />
                    </div>
                    <div class="col-md-2" style="color: #FF0000; padding-top: 10px">
                        *
                    </div>
                </div>
                <div class="form-group" style="height: 30px">
                    <label for="password" class="col-md-3 control-label" style="padding-top: 8px">
                        Password:</label>
                    <div class="col-md-7" style="padding-left: 0px">
                        <input type="password" class="form-control" name="txt_password" id="txt_password" />
                    </div>
                    <div class="col-md-2" style="color: #FF0000; padding-top: 10px">
                        *
                    </div>
                </div>
                <div class="form-group" style="height: 30px">
                    <label for="code" class="col-md-3 control-label" style="padding-top: 8px">
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
    <div id="page_two" runat="Server" class="row" visible="false">
        <div class="panel panel-primary">
            <div class="panel-heading">
                <h3 class="panel-title">
                    批量导入</h3>
            </div>
            <div class="panel-body">
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
                    <div style="height: 30px">
                        <div class="col-md-5 ">
                            <label class="label-control" style="padding-top: 5px">
                                Coupon Number（优惠码）:
                            </label>
                        </div>
                        <div class="col-md-5" style="padding-left: 0px">
                            <input class="form-control" name="coupon_number" /></div>
                        <div class="col-md-2">
                            <asp:Button ID="btn_upload" runat="Server" CssClass="btn btn-info" Text="上传" 
                                Width="100%" onclick="btn_upload_Click" /></div>
                    </div>
                </div>
                <div style="margin-top: 30px; margin-bottom: 30px; height: 2px; background: #DADADA">
                </div>
                <div class="form-group">
                    <div style="height: 40px; background: #DADADA; padding-top: 10px; padding-left: 20px;
                        font-weight: 600">
                        Download Blank Order File(下载批量下单文件例子)</div>
                    <div style="margin-top: 20px; height: 30px; margin-bottom: 10px;padding-left:20px">
                        <a href="excel-template/AUTEMS.xls" style="text-decoration:underline">Download Order File Example（点击下载EXCEL文件例子：EMS绿色专线以China-ems作为收件国家）</a>
                        
                    </div>
                    <div style="margin-top: 20px; height: 30px; margin-bottom: 10px;padding-left:20px">
                        <a href="excel-template/AUT-Priority.xls" style="text-decoration:underline">Download Order File Example（点击下载EXCEL文件例子:Parcelforce priority auto以China作为收件国家）</a>
                        
                    </div>
                    <div style="margin-top: 20px; height: 30px; margin-bottom: 10px;padding-left:20px">
                        <a href="excel-template/AUT-economy.xls" style="text-decoration:underline">Download Order File Example（点击下载EXCEL文件例子:Parcelforce economy以China-PFE作为收件国家）</a>
                        
                    </div>
                </div>
                <div style="margin-top: 30px; margin-bottom: 30px; height: 2px; background: #DADADA">
                </div>
                <div class="from-group" style="margin-top:20px">
                    <p style="line-height: 25px; font-weight: 600">
                        您好，感谢您使用EMS特快专线。 我们的下单流程如下：</p>
                    <p style="line-height: 25px">
                        1.在我们官方网站www.wm-global-express注册，登陆</p>
                    <p style="line-height: 25px">
                        2.下载‘EMS特快专线’Excel表格</p>
                    <p style="line-height: 25px">
                        3.填写‘EMS特快专线’Excel表格。</p>
                    <p style="line-height: 25px">
                        (a)&nbsp;如果您需要我们提供上门取件服务，请您确保在同一张表格上的包裹都在同一取件地址。 假如您有10件包裹在取件地址A，20件包裹在取件地址B，请您分成表格A和表格B，分开两次上传</p>
                    <p style="line-height: 25px">
                        (b)&nbsp;使用英文或者拼音填写表格</p>
                    <p style="line-height: 25px">
                        (c)&nbsp;一行填写一个包裹信息</p>
                    <p style="line-height: 25px">
                        (d)&nbsp;申报价值必须与购物小票面额一致，如因不一致造成海关退回，扣留等由您自己负责 包裹描述必须详细准确，如是婴儿奶粉，请填写‘baby milk’
                        点击首页‘EMS特快专线’ 点击‘选择文件’上传已经填写好的Excel表格后，点击‘submit’提交 按屏幕提示进行支付 支付成功后，EMS条形码自动生成。您可以自行进行保存、打印。然后送到华盟指定Drop-off地址
                        如果您需要我们提供上门取件服务，请您将下面表格填好并发邮件到邮箱 wm5fenzhuang@gmail.com 请保证您的华盟预存款账号有充足余额 以便我们的工作人员进行取件费用的扣款和预定取件服务.
                    </p>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
