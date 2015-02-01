<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/back-stage/home.Master" AutoEventWireup="true"
    CodeBehind="user-detail-info.aspx.cs" Inherits="WM_Project.manage_system.user_detail_info" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="center" runat="server">
    <div class="panel panel-primary" style="width: 80%; margin: 0 auto;
        margin-bottom: 30px">
        <div class="panel-heading">
            <h5 class="panel-title">
                用户&nbsp;&nbsp;<%=user.Name %>详细信息</h5>
        </div>
        <div class="panel-body">
            <div class="form-group">
                <label class="col-md-2 col-md-offset-1 control-label">
                    用户名</label>
                <div class="col-md-9">
                    <input class="form-control" type="text" readonly="readonly" value="<%=user.Name %>" /></div>
            </div>
            <div class="form-group">
                <label class="col-md-2 col-md-offset-1 control-label">
                    电子邮箱</label>
                <div class="col-md-9">
                    <input class="form-control" type="text" readonly="readonly" value="<%=user.Email %>" /></div>
            </div>
            <div class="form-group">
                <label class="col-md-2 col-md-offset-1 control-label">
                    电话号码</label>
                <div class="col-md-9">
                    <input class="form-control" type="text" readonly="readonly" value="<%=user.Telephone %>" /></div>
            </div>
        </div>
    </div>
</asp:Content>
