<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/reception-stage/home.Master" AutoEventWireup="true"
    CodeBehind="order-tracking.aspx.cs" Inherits="WM_Project.views.order_tracking" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%--此处写CSS、javascript代码--%>
    <script type="text/javascript">

        function isNull() {
            var track = document.getElementById("txt_track_no").value;
            if (track == "") {
                alert("请输入订单号！");
                return false;
            }
            return true;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="center_right" runat="server">
    <%--追踪号输入部分--%>
    <div class="row" id="page_one" runat="Server" visible="false">
        <div class="panel panel-primary">
            <div class="panel-heading">
                <h3 class="panel-title">
                    订单追踪</h3>
            </div>
            <div class="panel panel-body">
                <div class="panel-group" style="margin-top: 20px">
                    <label class="col-md-2 control-label" style="padding-top: 8px;text-align:right">
                        追踪号：</label>
                    <div class="col-md-8">
                        <input type="text" name="txt_track_no" id="txt_track_no" class="form-control" />
                    </div>
                    <div class="col-md-2">
                        <asp:Button ID="btn_track" runat="Server" CssClass="btn btn-info" Text="追踪" OnClick="btn_track_Click"
                            OnClientClick="return isNull();" />
                    </div>
                </div>
            </div>
        </div>
    </div>

    <%--快件信息显示部分--%>
    <div class="row" id="page_two" runat="Server" visible="false">
        <div class="panel panel-primary">
            <div class="panel-heading">
                <h3 class="panel-title">
                    您的快件信息</h3>
            </div>
            <div class="panel panel-body" style="height:200px;padding-top:80px">
                <p style="text-align:center;color:#3C85C4">追踪号：<%=track_no %></p>
                <p style="text-align:center;color:#3C85C4">您好该部分功能目前还不能使用！！</p>
            </div>
        </div>
    </div>
</asp:Content>
