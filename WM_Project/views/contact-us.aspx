<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/reception-stage/home.Master"
    AutoEventWireup="true" CodeBehind="contact-us.aspx.cs" Inherits="WM_Project.views.contact_us" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%--此处写CSS、javascript代码--%>
    <script type="text/javascript">

        function checkInfo() {

            var name = document.getElementById("name").value;
            var tel = document.getElementById("telephone").value;
            var mail = document.getElementById("e_mail").value;
            var detail = document.getElementById("detail_info").value;

            if (name == "" || tel == "" || mail == "" || detail_info == "") {

                alert("带*号的不能为空！");
                return false;
            }

            return true;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="center_right" runat="server">
    <%--此处写内容部分代码--%>
    <div class="row">
        <div class="panel panel-primary">
            <div class="panel-heading">
                <p class="panel-title" style="font-weight: 800; font-size: 20px">
                    Contact Us 联系我们</p>
            </div>
            <div class="panel-body">
                <div class="form-group" style="margin-bottom: 30px">
                    <p>
                        <b>Contact Number</b>&nbsp;&nbsp;英国客服电话：（+44）7428630888；（+44）1212885118</p>
                    <p style="margin-left: 120px">
                        中国客户电话：（+86）18305416800</p>
                    <p>
                        <b>QQLivechat</b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;客服&nbsp;QQ：1944631472；2259698537</p>
                    <p>
                        <b>Opening Hours </b>&nbsp;&nbsp;工作时间:</p>
                    <p style="margin-left: 90px; text-indent: 2em">
                        英国时间：周一至周五 9:30 - 16:00</p>
                    <p style="margin-left: 90px; text-indent: 2em">
                        中国时间：周一至周五 14:00 - 22:00</p>
                </div>
                <div class="form-group" style="margin-top: 20px;">
                    <p>
                    </p>
                </div>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="panel panel-primary">
            <div class="panel-heading">
                <p class="panel-title" style="font-weight: 800; font-size: 20px">
                    Enquire Form 给我们留言</p>
            </div>
            <div class="panel-body">
                <div class="form-group">
                    <p style="font-weight: 800">
                        请您填写以下表单，我们将尽快联联系您</p>
                    <table border="0" cellspacing="0" cellpadding="0" width="100%" class="table table-striped">
                        <tr>
                            <td style="width: 20%; text-align: right">
                                <label class="label-control" style="padding-top: 8px;">
                                    您的尊称：</label>
                            </td>
                            <td style="width: 70%">
                                <input type="text" name="name" id="name" class="form-control" />
                            </td>
                            <td style="color: #FF0000; padding-top: 16px; text-align: left">
                                *
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 20%; text-align: right">
                                <label class="label-control" style="padding-top: 8px; text-align: right">
                                    联系方式：</label>
                            </td>
                            <td style="width: 70%">
                                <input type="text" name="telephone" id="telephone" class="form-control" />
                            </td>
                            <td style="color: #FF0000; padding-top: 16px; text-align: left">
                                *
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 20%; text-align: right">
                                <label class="label-control" style="padding-top: 8px; text-align: right">
                                    邮箱：</label>
                            </td>
                            <td style="width: 70%">
                                <input type="text" name="e_mail" class="form-control" id="e_mail" />
                            </td>
                            <td style="color: #FF0000; padding-top: 16px; text-align: left">
                                *
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 20%; text-align: right">
                                <label class="label-control" style="padding-top: 30px; text-align: right">
                                    详细信息：</label>
                            </td>
                            <td style="width: 70%">
                                <textarea rows="4" class="form-control" name="detail_info" id="detail_info" cols="50"
                                    style="resize: none"></textarea>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3" style="text-align: center">
                                <asp:Button ID="btn_submit" runat="Server" Text="提交" CssClass="btn btn-info" OnClientClick="return checkInfo()"
                                    OnClick="btn_submit_Click" />
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
            <div class="panel-footer">
                <p style="color: #3C85C4">
                    *&nbsp;有什么疑问随时可以跟我们留言，我们将在第一时间为您解答</p>
            </div>
        </div>
    </div>
</asp:Content>
