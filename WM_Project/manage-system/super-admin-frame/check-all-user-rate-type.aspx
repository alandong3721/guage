<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="check-all-user-rate-type.aspx.cs"
    Inherits="WM_Project.manage_system.super_admin_frame.check_all_user_rate_type" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../stylesheets/bootstrap.css" rel="stylesheet" type="text/css" />
    <link href="../../stylesheets/bootstrap-theme.css" rel="stylesheet" type="text/css" />
    <script src="../../javascripts/bootstrap.js" type="text/javascript"></script>
    <script src="../../javascripts/jquery-1.11.1.js" type="text/javascript"></script>
    <style type="text/css">
        th, td
        {
            text-align: center;
        }
    </style>
    <script type="text/javascript">
        function isNameNull() {

            var name = document.getElementsByName("username");
            if (name[0].value.trim() == "") {

                alert("用户名不能为空");
                return false;
            }

            return true;
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="panel panel-primary" style="width: 700px;">
        <div class="panel-heading">
            <h5 class="title">
                查询用户的所有类型的邮费</h5>
        </div>
        <div class="panel-body">
            <div class="form-group" style="height: 40px; clear: both">
                <div style="width: 120px; float: left; text-align: center; padding-top: 5px;">
                    <label class="control-label">
                        用户名</label></div>
                <div style="width: 360px; float: left">
                    <input type="text" name="username" class="form-control" /></div>
                <div style="width: 180px; text-align: center; float: left">
                    <asp:Button ID="check_rate" runat="Server" CssClass="btn btn-info" Text="查询" Width="80px"
                        OnClientClick="return isNameNull()" OnClick="check_rate_Click" /></div>
            </div>
            <div id="user_rate_info" runat="Server" visible="false">
                <div style="height: 40px; padding-top: 5px; background: #DADADA; width: 664px; margin: 0 auto;
                    margin-top: 20px; text-align: center; clear: both">
                    <p style="font-size: 20px; font-weight: 600">
                        用户<%=username %>各类邮费信息如下</p>
                </div>
                <div class="form-group" style="width: 664px; margin: 0 auto;">
                    <table border="1" width="664px">
                        <tr style="height: 30px">
                            <th style="width: 80px;">
                                &nbsp;
                            </th>
                            <th style="width: 80px">
                                重量(kg)
                            </th>
                            <th style="width: 42px">
                                0.5
                            </th>
                            <th style="width: 42px">
                                1.0
                            </th>
                            <th style="width: 42px">
                                1.5
                            </th>
                            <th style="width: 42px">
                                2.0
                            </th>
                            <th style="width: 42px">
                                2.5
                            </th>
                            <th style="width: 42px">
                                3.0
                            </th>
                            <th style="width: 42px">
                                3.5
                            </th>
                            <th style="width: 42px">
                                4.0
                            </th>
                            <th style="width: 42px">
                                4.5
                            </th>
                            <th style="width: 42px">
                                5.0
                            </th>
                            <th>
                                5.5
                            </th>
                            <th style="width: 42px">
                                6.0
                            </th>
                        </tr>
                        <tr style="height: 30px">
                            <th>
                                EMS
                            </th>
                            <th>
                                <%=type[0].ToString() %>
                            </th>
                            <td>
                                <%=emsArray[0].ToString() %>
                            </td>
                            <td>
                                <%=emsArray[1].ToString() %>
                            </td>
                            <td>
                                <%=emsArray[2].ToString() %>
                            </td>
                            <td>
                                <%=emsArray[3].ToString() %>
                            </td>
                            <td>
                                <%=emsArray[4].ToString() %>
                            </td>
                            <td>
                                <%=emsArray[5].ToString() %>
                            </td>
                            <td>
                                <%=emsArray[6].ToString() %>
                            </td>
                            <td>
                                <%=emsArray[7].ToString() %>
                            </td>
                            <td>
                                <%=emsArray[8].ToString() %>
                            </td>
                            <td>
                                <%=emsArray[9].ToString() %>
                            </td>
                            <td>
                                <%=emsArray[10].ToString() %>
                            </td>
                            <td>
                                <%=emsArray[11].ToString() %>
                            </td>
                        </tr>
                        <tr style="height: 30px">
                            <th>
                                PostNL
                            </th>
                            <th>
                                <%=type[1].ToString() %>
                            </th>
                            <td>
                                <%=postnlArray[0].ToString() %>
                            </td>
                            <td>
                                <%=postnlArray[0].ToString() %>
                            </td>
                            <td>
                                <%=postnlArray[1].ToString()%>
                            </td>
                            <td>
                                <%=postnlArray[1].ToString()%>
                            </td>
                            <td>
                                <%=postnlArray[2].ToString()%>
                            </td>
                            <td>
                                <%=postnlArray[2].ToString()%>
                            </td>
                            <td>
                                <%=postnlArray[3].ToString()%>
                            </td>
                            <td>
                                <%=postnlArray[3].ToString()%>
                            </td>
                            <td>
                                <%=postnlArray[4].ToString()%>
                            </td>
                            <td>
                                <%=postnlArray[4].ToString()%>
                            </td>
                            <td>
                                <%=postnlArray[5].ToString()%>
                                
                            </td>
                            <td>
                                <%=postnlArray[5].ToString()%>
                                
                            </td>
                        </tr>
                        <tr style="height: 30px">
                            <th>
                                PF-GPR-C
                            </th>
                            <th>
                                <%=type[2].ToString() %>
                            </th>
                            <td>
                                <%=pfgprcArray[0].ToString() %>
                            </td>
                            <td>
                                <%=pfgprcArray[1].ToString()%>
                            </td>
                            <td>
                                <%=pfgprcArray[2].ToString()%>
                            </td>
                            <td>
                                <%=pfgprcArray[3].ToString()%>
                            </td>
                            <td>
                                <%=pfgprcArray[4].ToString()%>
                            </td>
                            <td>
                                <%=pfgprcArray[5].ToString()%>
                            </td>
                            <td>
                                <%=pfgprcArray[6].ToString()%>
                            </td>
                            <td>
                                <%=pfgprcArray[7].ToString()%>
                            </td>
                            <td>
                                <%=pfgprcArray[8].ToString()%>
                            </td>
                            <td>
                                <%=pfgprcArray[9].ToString()%>
                            </td>
                            <td>
                                <%=pfgprcArray[10].ToString()%>
                            </td>
                            <td>
                                <%=pfgprcArray[11].ToString()%>
                            </td>
                        </tr>
                        <tr style="height: 30px">
                            <th>
                                PF-GPR-D
                            </th>
                            <th>
                                <%=type[3].ToString() %>
                            </th>
                            <td>
                                <%=pfgprdArray[0].ToString() %>
                            </td>
                            <td>
                                <%=pfgprdArray[1].ToString()%>
                            </td>
                            <td>
                                <%=pfgprdArray[2].ToString()%>
                            </td>
                            <td>
                                <%=pfgprdArray[3].ToString()%>
                            </td>
                            <td>
                                <%=pfgprdArray[4].ToString()%>
                            </td>
                            <td>
                                <%=pfgprdArray[5].ToString()%>
                            </td>
                            <td>
                                <%=pfgprdArray[6].ToString()%>
                            </td>
                            <td>
                                <%=pfgprdArray[7].ToString()%>
                            </td>
                            <td>
                                <%=pfgprdArray[8].ToString()%>
                            </td>
                            <td>
                                <%=pfgprdArray[9].ToString()%>
                            </td>
                            <td>
                                <%=pfgprdArray[10].ToString()%>
                            </td>
                            <td>
                                <%=pfgprdArray[11].ToString()%>
                            </td>
                        </tr>
                        <tr style="height: 30px">
                            <th>
                                PF-IPE-C
                            </th>
                            <th>
                                <%=type[4].ToString() %>
                            </th>
                            <td>
                                <%=pfipecArray[0].ToString() %>
                            </td>
                            <td>
                                <%=pfipecArray[1].ToString()%>
                            </td>
                            <td>
                                <%=pfipecArray[2].ToString()%>
                            </td>
                            <td>
                                <%=pfipecArray[3].ToString()%>
                            </td>
                            <td>
                                <%=pfipecArray[4].ToString()%>
                            </td>
                            <td>
                                <%=pfipecArray[5].ToString()%>
                            </td>
                            <td>
                                <%=pfipecArray[6].ToString()%>
                            </td>
                            <td>
                                <%=pfipecArray[7].ToString()%>
                            </td>
                            <td>
                                <%=pfipecArray[8].ToString()%>
                            </td>
                            <td>
                                <%=pfipecArray[9].ToString()%>
                            </td>
                            <td>
                                <%=pfipecArray[10].ToString()%>
                            </td>
                            <td>
                                <%=pfipecArray[11].ToString()%>
                            </td>
                        </tr>
                        <tr style="height: 30px">
                            <th>
                                PF-IPE-D
                            </th>
                            <th>
                                <%=type[5].ToString() %>
                            </th>
                            <td>
                                <%=pfipedArray[0].ToString() %>
                            </td>
                            <td>
                                <%=pfipedArray[1].ToString()%>
                            </td>
                            <td>
                                <%=pfipedArray[2].ToString()%>
                            </td>
                            <td>
                                <%=pfipedArray[3].ToString()%>
                            </td>
                            <td>
                                <%=pfipedArray[4].ToString()%>
                            </td>
                            <td>
                                <%=pfipedArray[5].ToString()%>
                            </td>
                            <td>
                                <%=pfipedArray[6].ToString()%>
                            </td>
                            <td>
                                <%=pfipedArray[7].ToString()%>
                            </td>
                            <td>
                                <%=pfipedArray[8].ToString()%>
                            </td>
                            <td>
                                <%=pfipedArray[9].ToString()%>
                            </td>
                            <td>
                                <%=pfipedArray[10].ToString()%>
                            </td>
                            <td>
                                <%=pfipedArray[11].ToString()%>
                            </td>
                        </tr>
                        <tr style="height: 30px">
                            <th>
                                PF-IPE-P
                            </th>
                            <th>
                                <%=type[6].ToString() %>
                            </th>
                            <td>
                                <%=pfipepArray[0].ToString() %>
                            </td>
                            <td>
                                <%=pfipepArray[1].ToString()%>
                            </td>
                            <td>
                                <%=pfipepArray[2].ToString()%>
                            </td>
                            <td>
                                <%=pfipepArray[3].ToString()%>
                            </td>
                            <td>
                                <%=pfipepArray[4].ToString()%>
                            </td>
                            <td>
                                <%=pfipepArray[5].ToString()%>
                            </td>
                            <td>
                                <%=pfipepArray[6].ToString()%>
                            </td>
                            <td>
                                <%=pfipepArray[7].ToString()%>
                            </td>
                            <td>
                                <%=pfipepArray[8].ToString()%>
                            </td>
                            <td>
                                <%=pfipepArray[9].ToString()%>
                            </td>
                            <td>
                                <%=pfipepArray[10].ToString()%>
                            </td>
                            <td>
                                <%=pfipepArray[11].ToString()%>
                            </td>
                        </tr>
                        <tr style="height: 30px">
                            <th>
                                PF-IPE-T
                            </th>
                            <th>
                                <%=type[7].ToString() %>
                            </th>
                            <td>
                                <%=pfipetArray[0].ToString() %>
                            </td>
                            <td>
                                <%=pfipetArray[1].ToString()%>
                            </td>
                            <td>
                                <%=pfipetArray[2].ToString()%>
                            </td>
                            <td>
                                <%=pfipetArray[3].ToString()%>
                            </td>
                            <td>
                                <%=pfipetArray[4].ToString()%>
                            </td>
                            <td>
                                <%=pfipetArray[5].ToString()%>
                            </td>
                            <td>
                                <%=pfipetArray[6].ToString()%>
                            </td>
                            <td>
                                <%=pfipetArray[7].ToString()%>
                            </td>
                            <td>
                                <%=pfipetArray[8].ToString()%>
                            </td>
                            <td>
                                <%=pfipetArray[9].ToString()%>
                            </td>
                            <td>
                                <%=pfipetArray[10].ToString()%>
                            </td>
                            <td>
                                <%=pfipetArray[11].ToString()%>
                            </td>
                        </tr>
                        <tr style="height: 10px;">
                            <td colspan="14" style="height: 10px; background: #DADADA">
                            </td>
                        </tr>
                        <tr style="height: 30px">
                            <th>
                                &nbsp;
                            </th>
                            <th>
                                重量(kg)
                            </th>
                            <th>
                                6.5
                            </th>
                            <th>
                                7.0
                            </th>
                            <th>
                                7.5
                            </th>
                            <th>
                                8.0
                            </th>
                            <th>
                                8.5
                            </th>
                            <th>
                                9.0
                            </th>
                            <th>
                                9.5
                            </th>
                            <th>
                                10.0
                            </th>
                            <th>
                                10.5
                            </th>
                            <th>
                                11.0
                            </th>
                            <th>
                                11.5
                            </th>
                            <th>
                                12.0
                            </th>
                        </tr>
                        <tr style="height: 30px">
                            <th>
                                EMS
                            </th>
                            <th>
                                <%=type[0].ToString() %>
                            </th>
                            <td>
                                <%=emsArray[12].ToString() %>
                            </td>
                            <td>
                                <%=emsArray[13].ToString() %>
                            </td>
                            <td>
                                <%=emsArray[14].ToString() %>
                            </td>
                            <td>
                                <%=emsArray[15].ToString() %>
                            </td>
                            <td>
                                <%=emsArray[16].ToString() %>
                            </td>
                            <td>
                                <%=emsArray[17].ToString() %>
                            </td>
                            <td>
                                <%=emsArray[18].ToString() %>
                            </td>
                            <td>
                                <%=emsArray[19].ToString() %>
                            </td>
                            <td>
                                <%=emsArray[20].ToString() %>
                            </td>
                            <td>
                                <%=emsArray[21].ToString() %>
                            </td>
                            <td>
                                <%=emsArray[22].ToString() %>
                            </td>
                            <td>
                                <%=emsArray[23].ToString() %>
                            </td>
                        </tr>
                        <tr style="height: 30px">
                            <th>
                                PostNL
                            </th>
                            <th>
                                <%=type[1].ToString() %>
                            </th>
                            <td>
                                <%=postnlArray[6].ToString() %>
                            </td>
                            <td>
                                <%=postnlArray[7].ToString()%>
                            </td>
                            <td>
                                <%=postnlArray[8].ToString()%>
                            </td>
                            <td>
                                <%=postnlArray[9].ToString()%>
                            </td>
                            <td>
                                <%=postnlArray[10].ToString()%>
                                
                            </td>
                            <td>
                                <%=postnlArray[10].ToString()%>
                            </td>
                            <td>
                                <%=postnlArray[11].ToString()%>
                            </td>
                            <td>
                                <%=postnlArray[11].ToString()%>
                            </td>
                            <td>
                                <%=postnlArray[12].ToString()%>
                            </td>
                            <td>
                                <%=postnlArray[12].ToString()%>
                            </td>
                            <td>
                                <%=postnlArray[13].ToString()%>
                            </td>
                            <td>
                                <%=postnlArray[13].ToString()%>
                            </td>
                        </tr>
                        <tr style="height: 30px">
                            <th>
                                PF-GPR-C
                            </th>
                            <th>
                                <%=type[2].ToString() %>
                            </th>
                            <td>
                                <%=pfgprcArray[12].ToString() %>
                            </td>
                            <td>
                                <%=pfgprcArray[13].ToString()%>
                            </td>
                            <td>
                                <%=pfgprcArray[14].ToString()%>
                            </td>
                            <td>
                                <%=pfgprcArray[15].ToString()%>
                            </td>
                            <td>
                                <%=pfgprcArray[16].ToString()%>
                            </td>
                            <td>
                                <%=pfgprcArray[17].ToString()%>
                            </td>
                            <td>
                                <%=pfgprcArray[18].ToString()%>
                            </td>
                            <td>
                                <%=pfgprcArray[19].ToString()%>
                            </td>
                            <td>
                                <%=pfgprcArray[20].ToString()%>
                            </td>
                            <td>
                                <%=pfgprcArray[21].ToString()%>
                            </td>
                            <td>
                                <%=pfgprcArray[22].ToString()%>
                            </td>
                            <td>
                                <%=pfgprcArray[23].ToString()%>
                            </td>
                        </tr>
                        <tr style="height: 30px">
                            <th>
                                PF-GPR-D
                            </th>
                            <th>
                                <%=type[3].ToString() %>
                            </th>
                            <td>
                                <%=pfgprdArray[12].ToString() %>
                            </td>
                            <td>
                                <%=pfgprdArray[13].ToString()%>
                            </td>
                            <td>
                                <%=pfgprdArray[14].ToString()%>
                            </td>
                            <td>
                                <%=pfgprdArray[15].ToString()%>
                            </td>
                            <td>
                                <%=pfgprdArray[16].ToString()%>
                            </td>
                            <td>
                                <%=pfgprdArray[17].ToString()%>
                            </td>
                            <td>
                                <%=pfgprdArray[18].ToString()%>
                            </td>
                            <td>
                                <%=pfgprdArray[19].ToString()%>
                            </td>
                            <td>
                                <%=pfgprdArray[20].ToString()%>
                            </td>
                            <td>
                                <%=pfgprdArray[21].ToString()%>
                            </td>
                            <td>
                                <%=pfgprdArray[22].ToString()%>
                            </td>
                            <td>
                                <%=pfgprdArray[23].ToString()%>
                            </td>
                        </tr>
                        <tr style="height: 30px">
                            <th>
                                PF-IPE-C
                            </th>
                            <th>
                                <%=type[4].ToString() %>
                            </th>
                            <td>
                                <%=pfipecArray[12].ToString() %>
                            </td>
                            <td>
                                <%=pfipecArray[13].ToString()%>
                            </td>
                            <td>
                                <%=pfipecArray[14].ToString()%>
                            </td>
                            <td>
                                <%=pfipecArray[15].ToString()%>
                            </td>
                            <td>
                                <%=pfipecArray[16].ToString()%>
                            </td>
                            <td>
                                <%=pfipecArray[17].ToString()%>
                            </td>
                            <td>
                                <%=pfipecArray[18].ToString()%>
                            </td>
                            <td>
                                <%=pfipecArray[19].ToString()%>
                            </td>
                            <td>
                                <%=pfipecArray[20].ToString()%>
                            </td>
                            <td>
                                <%=pfipecArray[21].ToString()%>
                            </td>
                            <td>
                                <%=pfipecArray[22].ToString()%>
                            </td>
                            <td>
                                <%=pfipecArray[23].ToString()%>
                            </td>
                        </tr>
                        <tr style="height: 30px">
                            <th>
                                PF-IPE-D
                            </th>
                            <th>
                                <%=type[5].ToString() %>
                            </th>
                            <td>
                                <%=pfipedArray[12].ToString() %>
                            </td>
                            <td>
                                <%=pfipedArray[13].ToString()%>
                            </td>
                            <td>
                                <%=pfipedArray[14].ToString()%>
                            </td>
                            <td>
                                <%=pfipedArray[15].ToString()%>
                            </td>
                            <td>
                                <%=pfipedArray[16].ToString()%>
                            </td>
                            <td>
                                <%=pfipedArray[17].ToString()%>
                            </td>
                            <td>
                                <%=pfipedArray[18].ToString()%>
                            </td>
                            <td>
                                <%=pfipedArray[19].ToString()%>
                            </td>
                            <td>
                                <%=pfipedArray[20].ToString()%>
                            </td>
                            <td>
                                <%=pfipedArray[21].ToString()%>
                            </td>
                            <td>
                                <%=pfipedArray[22].ToString()%>
                            </td>
                            <td>
                                <%=pfipedArray[23].ToString()%>
                            </td>
                        </tr>
                        <tr style="height: 30px">
                            <th>
                                PF-IPE-P
                            </th>
                            <th>
                                <%=type[6].ToString() %>
                            </th>
                            <td>
                                <%=pfipepArray[12].ToString() %>
                            </td>
                            <td>
                                <%=pfipepArray[13].ToString()%>
                            </td>
                            <td>
                                <%=pfipepArray[14].ToString()%>
                            </td>
                            <td>
                                <%=pfipepArray[15].ToString()%>
                            </td>
                            <td>
                                <%=pfipepArray[16].ToString()%>
                            </td>
                            <td>
                                <%=pfipepArray[17].ToString()%>
                            </td>
                            <td>
                                <%=pfipepArray[18].ToString()%>
                            </td>
                            <td>
                                <%=pfipepArray[19].ToString()%>
                            </td>
                            <td>
                                <%=pfipepArray[20].ToString()%>
                            </td>
                            <td>
                                <%=pfipepArray[21].ToString()%>
                            </td>
                            <td>
                                <%=pfipepArray[22].ToString()%>
                            </td>
                            <td>
                                <%=pfipepArray[23].ToString()%>
                            </td>
                        </tr>
                        <tr style="height: 30px">
                            <th>
                                PF-IPE-T
                            </th>
                            <th>
                                <%=type[7].ToString() %>
                            </th>
                            <td>
                                <%=pfipetArray[12].ToString()%>
                            </td>
                            <td>
                                <%=pfipetArray[13].ToString()%>
                            </td>
                            <td>
                                <%=pfipetArray[14].ToString()%>
                            </td>
                            <td>
                                <%=pfipetArray[15].ToString()%>
                            </td>
                            <td>
                                <%=pfipetArray[16].ToString()%>
                            </td>
                            <td>
                                <%=pfipetArray[17].ToString()%>
                            </td>
                            <td>
                                <%=pfipetArray[18].ToString()%>
                            </td>
                            <td>
                                <%=pfipetArray[19].ToString()%>
                            </td>
                            <td>
                                <%=pfipetArray[20].ToString()%>
                            </td>
                            <td>
                                <%=pfipetArray[21].ToString()%>
                            </td>
                            <td>
                                <%=pfipetArray[22].ToString()%>
                            </td>
                            <td>
                                <%=pfipetArray[23].ToString()%>
                            </td>
                        </tr>
                        <tr style="height: 10px;">
                            <td colspan="14" style="height: 10px; background: #DADADA">
                            </td>
                        </tr>
                        <tr style="height: 30px">
                            <th>
                                &nbsp;
                            </th>
                            <th>
                                重量(kg)
                            </th>
                            <th>
                                12.5
                            </th>
                            <th>
                                13.0
                            </th>
                            <th>
                                13.5
                            </th>
                            <th>
                                14.0
                            </th>
                            <th>
                                14.5
                            </th>
                            <th>
                                15.0
                            </th>
                            <th>
                                15.5
                            </th>
                            <th>
                                16.0
                            </th>
                            <th>
                                16.5
                            </th>
                            <th>
                                17.0
                            </th>
                            <th>
                                17.5
                            </th>
                            <th>
                                18.0
                            </th>
                        </tr>
                        <tr style="height: 30px">
                            <th>
                                EMS
                            </th>
                            <th>
                                <%=type[0].ToString() %>
                            </th>
                            <td>
                                <%=emsArray[24].ToString() %>
                            </td>
                            <td>
                                <%=emsArray[25].ToString() %>
                            </td>
                            <td>
                                <%=emsArray[26].ToString() %>
                            </td>
                            <td>
                                <%=emsArray[27].ToString() %>
                            </td>
                            <td>
                                <%=emsArray[28].ToString() %>
                            </td>
                            <td>
                                <%=emsArray[29].ToString() %>
                            </td>
                            <td>
                                <%=emsArray[30].ToString() %>
                            </td>
                            <td>
                                <%=emsArray[31].ToString() %>
                            </td>
                            <td>
                                <%=emsArray[32].ToString() %>
                            </td>
                            <td>
                                <%=emsArray[33].ToString() %>
                            </td>
                            <td>
                                <%=emsArray[34].ToString() %>
                            </td>
                            <td>
                                <%=emsArray[35].ToString() %>
                            </td>
                        </tr>
                        <tr style="height: 30px">
                            <th>
                                PostNL
                            </th>
                            <th>
                                <%=type[1].ToString() %>
                            </th>
                            <td>
                                <%=postnlArray[14].ToString() %>
                            </td>
                            <td>
                                <%=postnlArray[14].ToString()%>
                            </td>
                            <td>
                                <%=postnlArray[15].ToString()%>
                            </td>
                            <td>
                                <%=postnlArray[15].ToString()%>
                            </td>
                            <td>
                                <%=postnlArray[16].ToString()%>
                            </td>
                            <td>
                                <%=postnlArray[16].ToString()%>
                            </td>
                            <td>
                                <%=postnlArray[17].ToString()%>
                            </td>
                            <td>
                                <%=postnlArray[17].ToString()%>
                            </td>
                            <td>
                                <%=postnlArray[18].ToString()%>
                            </td>
                            <td>
                                <%=postnlArray[18].ToString()%>
                            </td>
                            <td>
                                <%=postnlArray[19].ToString()%>
                            </td>
                            <td>
                                <%=postnlArray[19].ToString()%>
                            </td>
                        </tr>
                        <tr style="height: 30px">
                            <th>
                                PF-GPR-C
                            </th>
                            <th>
                                <%=type[2].ToString() %>
                            </th>
                            <td>
                                <%=pfgprcArray[24].ToString()%>
                            </td>
                            <td>
                                <%=pfgprcArray[25].ToString()%>
                            </td>
                            <td>
                                <%=pfgprcArray[26].ToString()%>
                            </td>
                            <td>
                                <%=pfgprcArray[27].ToString()%>
                            </td>
                            <td>
                                <%=pfgprcArray[28].ToString()%>
                            </td>
                            <td>
                                <%=pfgprcArray[29].ToString()%>
                            </td>
                            <td>
                                <%=pfgprcArray[30].ToString()%>
                            </td>
                            <td>
                                <%=pfgprcArray[31].ToString()%>
                            </td>
                            <td>
                                <%=pfgprcArray[32].ToString()%>
                            </td>
                            <td>
                                <%=pfgprcArray[33].ToString()%>
                            </td>
                            <td>
                                <%=pfgprcArray[34].ToString()%>
                            </td>
                            <td>
                                <%=pfgprcArray[35].ToString()%>
                            </td>
                        </tr>
                        <tr style="height: 30px">
                            <th>
                                PF-GPR-D
                            </th>
                            <th>
                                <%=type[3].ToString() %>
                            </th>
                            <td>
                                <%=pfgprdArray[24].ToString()%>
                            </td>
                            <td>
                                <%=pfgprdArray[25].ToString()%>
                            </td>
                            <td>
                                <%=pfgprdArray[26].ToString()%>
                            </td>
                            <td>
                                <%=pfgprdArray[27].ToString()%>
                            </td>
                            <td>
                                <%=pfgprdArray[28].ToString()%>
                            </td>
                            <td>
                                <%=pfgprdArray[29].ToString()%>
                            </td>
                            <td>
                                <%=pfgprdArray[30].ToString()%>
                            </td>
                            <td>
                                <%=pfgprdArray[31].ToString()%>
                            </td>
                            <td>
                                <%=pfgprdArray[32].ToString()%>
                            </td>
                            <td>
                                <%=pfgprdArray[33].ToString()%>
                            </td>
                            <td>
                                <%=pfgprdArray[34].ToString()%>
                            </td>
                            <td>
                                <%=pfgprdArray[35].ToString()%>
                            </td>
                        </tr>
                        <tr style="height: 30px">
                            <th>
                                PF-IPE-C
                            </th>
                            <th>
                                <%=type[4].ToString() %>
                            </th>
                            <td>
                                <%=pfipecArray[24].ToString()%>
                            </td>
                            <td>
                                <%=pfipecArray[25].ToString()%>
                            </td>
                            <td>
                                <%=pfipecArray[26].ToString()%>
                            </td>
                            <td>
                                <%=pfipecArray[27].ToString()%>
                            </td>
                            <td>
                                <%=pfipecArray[28].ToString()%>
                            </td>
                            <td>
                                <%=pfipecArray[29].ToString()%>
                            </td>
                            <td>
                                <%=pfipecArray[30].ToString()%>
                            </td>
                            <td>
                                <%=pfipecArray[31].ToString()%>
                            </td>
                            <td>
                                <%=pfipecArray[32].ToString()%>
                            </td>
                            <td>
                                <%=pfipecArray[33].ToString()%>
                            </td>
                            <td>
                                <%=pfipecArray[34].ToString()%>
                            </td>
                            <td>
                                <%=pfipecArray[35].ToString()%>
                            </td>
                        </tr>
                        <tr style="height: 30px">
                            <th>
                                PF-IPE-D
                            </th>
                            <th>
                                <%=type[5].ToString() %>
                            </th>
                            <td>
                                <%=pfipedArray[24].ToString()%>
                            </td>
                            <td>
                                <%=pfipedArray[25].ToString()%>
                            </td>
                            <td>
                                <%=pfipedArray[26].ToString()%>
                            </td>
                            <td>
                                <%=pfipedArray[27].ToString()%>
                            </td>
                            <td>
                                <%=pfipedArray[28].ToString()%>
                            </td>
                            <td>
                                <%=pfipedArray[29].ToString()%>
                            </td>
                            <td>
                                <%=pfipedArray[30].ToString()%>
                            </td>
                            <td>
                                <%=pfipedArray[31].ToString()%>
                            </td>
                            <td>
                                <%=pfipedArray[32].ToString()%>
                            </td>
                            <td>
                                <%=pfipedArray[33].ToString()%>
                            </td>
                            <td>
                                <%=pfipedArray[34].ToString()%>
                            </td>
                            <td>
                                <%=pfipedArray[35].ToString()%>
                            </td>
                        </tr>
                        <tr style="height: 30px">
                            <th>
                                PF-IPE-P
                            </th>
                            <th>
                                <%=type[6].ToString() %>
                            </th>
                            <td>
                                <%=pfipepArray[24].ToString()%>
                            </td>
                            <td>
                                <%=pfipepArray[25].ToString()%>
                            </td>
                            <td>
                                <%=pfipepArray[26].ToString()%>
                            </td>
                            <td>
                                <%=pfipepArray[27].ToString()%>
                            </td>
                            <td>
                                <%=pfipepArray[28].ToString()%>
                            </td>
                            <td>
                                <%=pfipepArray[29].ToString()%>
                            </td>
                            <td>
                                <%=pfipepArray[30].ToString()%>
                            </td>
                            <td>
                                <%=pfipepArray[31].ToString()%>
                            </td>
                            <td>
                                <%=pfipepArray[32].ToString()%>
                            </td>
                            <td>
                                <%=pfipepArray[33].ToString()%>
                            </td>
                            <td>
                                <%=pfipepArray[34].ToString()%>
                            </td>
                            <td>
                                <%=pfipepArray[35].ToString()%>
                            </td>
                        </tr>
                        <tr style="height: 30px">
                            <th>
                                PF-IPE-T
                            </th>
                            <th>
                                <%=type[7].ToString() %>
                            </th>
                            <td>
                                <%=pfipetArray[24].ToString()%>
                            </td>
                            <td>
                                <%=pfipetArray[25].ToString()%>
                            </td>
                            <td>
                                <%=pfipetArray[26].ToString()%>
                            </td>
                            <td>
                                <%=pfipetArray[27].ToString()%>
                            </td>
                            <td>
                                <%=pfipetArray[28].ToString()%>
                            </td>
                            <td>
                                <%=pfipetArray[29].ToString()%>
                            </td>
                            <td>
                                <%=pfipetArray[30].ToString()%>
                            </td>
                            <td>
                                <%=pfipetArray[31].ToString()%>
                            </td>
                            <td>
                                <%=pfipetArray[32].ToString()%>
                            </td>
                            <td>
                                <%=pfipetArray[33].ToString()%>
                            </td>
                            <td>
                                <%=pfipetArray[34].ToString()%>
                            </td>
                            <td>
                                <%=pfipetArray[35].ToString()%>
                            </td>
                        </tr>
                        <tr style="height: 10px;">
                            <td colspan="14" style="height: 10px; background: #DADADA">
                            </td>
                        </tr>
                        <tr style="height: 30px">
                            <th>
                                &nbsp;
                            </th>
                            <th>
                                重量(kg)
                            </th>
                            <th>
                                18.5
                            </th>
                            <th>
                                19.0
                            </th>
                            <th>
                                19.5
                            </th>
                            <th>
                                20.0
                            </th>
                            <th>
                                20.5
                            </th>
                            <th>
                                21.0
                            </th>
                            <th>
                                21.5
                            </th>
                            <th>
                                22.0
                            </th>
                            <th>
                                22.5
                            </th>
                            <th>
                                23.0
                            </th>
                            <th>
                                23.5
                            </th>
                            <th>
                                24.0
                            </th>
                        </tr>
                        <tr style="height: 30px">
                            <th>
                                EMS
                            </th>
                            <th>
                                <%=type[0].ToString() %>
                            </th>
                            <td>
                                <%=emsArray[36].ToString() %>
                            </td>
                            <td>
                                <%=emsArray[37].ToString() %>
                            </td>
                            <td>
                                <%=emsArray[38].ToString() %>
                            </td>
                            <td>
                                <%=emsArray[39].ToString() %>
                            </td>
                            <td>
                                <%=emsArray[40].ToString() %>
                            </td>
                            <td>
                                <%=emsArray[41].ToString() %>
                            </td>
                            <td>
                                <%=emsArray[42].ToString() %>
                            </td>
                            <td>
                                <%=emsArray[43].ToString() %>
                            </td>
                            <td>
                                <%=emsArray[44].ToString() %>
                            </td>
                            <td>
                                <%=emsArray[45].ToString() %>
                            </td>
                            <td>
                                <%=emsArray[46].ToString() %>
                            </td>
                            <td>
                                <%=emsArray[47].ToString() %>
                            </td>
                        </tr>
                        <tr style="height: 30px">
                            <th>
                                PostNL
                            </th>
                            <th>
                                <%=type[1].ToString() %>
                            </th>
                            <td>
                                <%=postnlArray[20].ToString() %>
                            </td>
                            <td>
                                <%=postnlArray[20].ToString()%>
                            </td>
                            <td>
                                <%=postnlArray[21].ToString()%>
                            </td>
                            <td>
                                <%=postnlArray[21].ToString()%>
                            </td>
                            <td>
                                <%=postnlArray[22].ToString()%>
                            </td>
                            <td>
                                <%=postnlArray[22].ToString()%>
                            </td>
                            <td>
                                <%=postnlArray[23].ToString()%>
                            </td>
                            <td>
                                <%=postnlArray[23].ToString()%>
                            </td>
                            <td>
                                <%=postnlArray[24].ToString()%>
                            </td>
                            <td>
                                <%=postnlArray[24].ToString()%>
                            </td>
                            <td>
                                <%=postnlArray[25].ToString()%>
                            </td>
                            <td>
                                <%=postnlArray[25].ToString()%>
                            </td>
                        </tr>
                        <tr style="height: 30px">
                            <th>
                                PF-GPR-C
                            </th>
                            <th>
                                <%=type[2].ToString() %>
                            </th>
                            <td>
                                <%=pfgprcArray[36].ToString()%>
                            </td>
                            <td>
                                <%=pfgprcArray[37].ToString()%>
                            </td>
                            <td>
                                <%=pfgprcArray[38].ToString()%>
                            </td>
                            <td>
                                <%=pfgprcArray[39].ToString()%>
                            </td>
                            <td>
                                <%=pfgprcArray[40].ToString()%>
                            </td>
                            <td>
                                <%=pfgprcArray[41].ToString()%>
                            </td>
                            <td>
                                <%=pfgprcArray[42].ToString()%>
                            </td>
                            <td>
                                <%=pfgprcArray[43].ToString()%>
                            </td>
                            <td>
                                <%=pfgprcArray[44].ToString()%>
                            </td>
                            <td>
                                <%=pfgprcArray[45].ToString()%>
                            </td>
                            <td>
                                <%=pfgprcArray[46].ToString()%>
                            </td>
                            <td>
                                <%=pfgprcArray[47].ToString()%>
                            </td>
                        </tr>
                        <tr style="height: 30px">
                            <th>
                                PF-GPR-D
                            </th>
                            <th>
                                <%=type[3].ToString() %>
                            </th>
                            <td>
                                <%=pfgprdArray[36].ToString()%>
                            </td>
                            <td>
                                <%=pfgprdArray[37].ToString()%>
                            </td>
                            <td>
                                <%=pfgprdArray[38].ToString()%>
                            </td>
                            <td>
                                <%=pfgprdArray[39].ToString()%>
                            </td>
                            <td>
                                <%=pfgprdArray[40].ToString()%>
                            </td>
                            <td>
                                <%=pfgprdArray[41].ToString()%>
                            </td>
                            <td>
                                <%=pfgprdArray[42].ToString()%>
                            </td>
                            <td>
                                <%=pfgprdArray[43].ToString()%>
                            </td>
                            <td>
                                <%=pfgprdArray[44].ToString()%>
                            </td>
                            <td>
                                <%=pfgprdArray[45].ToString()%>
                            </td>
                            <td>
                                <%=pfgprdArray[46].ToString()%>
                            </td>
                            <td>
                                <%=pfgprdArray[47].ToString()%>
                            </td>
                        </tr>
                        <tr style="height: 30px">
                            <th>
                                PF-IPE-C
                            </th>
                            <th>
                                <%=type[4].ToString() %>
                            </th>
                            <td>
                                <%=pfipecArray[36].ToString()%>
                            </td>
                            <td>
                                <%=pfipecArray[37].ToString()%>
                            </td>
                            <td>
                                <%=pfipecArray[38].ToString()%>
                            </td>
                            <td>
                                <%=pfipecArray[39].ToString()%>
                            </td>
                            <td>
                                <%=pfipecArray[40].ToString()%>
                            </td>
                            <td>
                                <%=pfipecArray[41].ToString()%>
                            </td>
                            <td>
                                <%=pfipecArray[42].ToString()%>
                            </td>
                            <td>
                                <%=pfipecArray[43].ToString()%>
                            </td>
                            <td>
                                <%=pfipecArray[44].ToString()%>
                            </td>
                            <td>
                                <%=pfipecArray[45].ToString()%>
                            </td>
                            <td>
                                <%=pfipecArray[46].ToString()%>
                            </td>
                            <td>
                                <%=pfipecArray[47].ToString()%>
                            </td>
                        </tr>
                        <tr style="height: 30px">
                            <th>
                                PF-IPE-D
                            </th>
                            <th>
                                <%=type[5].ToString() %>
                            </th>
                            <td>
                                <%=pfipedArray[36].ToString()%>
                            </td>
                            <td>
                                <%=pfipedArray[37].ToString()%>
                            </td>
                            <td>
                                <%=pfipedArray[38].ToString()%>
                            </td>
                            <td>
                                <%=pfipedArray[39].ToString()%>
                            </td>
                            <td>
                                <%=pfipedArray[40].ToString()%>
                            </td>
                            <td>
                                <%=pfipedArray[41].ToString()%>
                            </td>
                            <td>
                                <%=pfipedArray[42].ToString()%>
                            </td>
                            <td>
                                <%=pfipedArray[43].ToString()%>
                            </td>
                            <td>
                                <%=pfipedArray[44].ToString()%>
                            </td>
                            <td>
                                <%=pfipedArray[45].ToString()%>
                            </td>
                            <td>
                                <%=pfipedArray[46].ToString()%>
                            </td>
                            <td>
                                <%=pfipedArray[47].ToString()%>
                            </td>
                        </tr>
                        <tr style="height: 30px">
                            <th>
                                PF-IPE-P
                            </th>
                            <th>
                                <%=type[6].ToString() %>
                            </th>
                            <td>
                                <%=pfipepArray[36].ToString()%>
                            </td>
                            <td>
                                <%=pfipepArray[37].ToString()%>
                            </td>
                            <td>
                                <%=pfipepArray[38].ToString()%>
                            </td>
                            <td>
                                <%=pfipepArray[39].ToString()%>
                            </td>
                            <td>
                                <%=pfipepArray[40].ToString()%>
                            </td>
                            <td>
                                <%=pfipepArray[41].ToString()%>
                            </td>
                            <td>
                                <%=pfipepArray[42].ToString()%>
                            </td>
                            <td>
                                <%=pfipepArray[43].ToString()%>
                            </td>
                            <td>
                                <%=pfipepArray[44].ToString()%>
                            </td>
                            <td>
                                <%=pfipepArray[45].ToString()%>
                            </td>
                            <td>
                                <%=pfipepArray[46].ToString()%>
                            </td>
                            <td>
                                <%=pfipepArray[47].ToString()%>
                            </td>
                        </tr>
                        <tr style="height: 30px">
                            <th>
                                PF-IPE-T
                            </th>
                            <th>
                                <%=type[7].ToString() %>
                            </th>
                            <td>
                                <%=pfipetArray[36].ToString()%>
                            </td>
                            <td>
                                <%=pfipetArray[37].ToString()%>
                            </td>
                            <td>
                                <%=pfipetArray[38].ToString()%>
                            </td>
                            <td>
                                <%=pfipetArray[39].ToString()%>
                            </td>
                            <td>
                                <%=pfipetArray[40].ToString()%>
                            </td>
                            <td>
                                <%=pfipetArray[41].ToString()%>
                            </td>
                            <td>
                                <%=pfipetArray[42].ToString()%>
                            </td>
                            <td>
                                <%=pfipetArray[43].ToString()%>
                            </td>
                            <td>
                                <%=pfipetArray[44].ToString()%>
                            </td>
                            <td>
                                <%=pfipetArray[45].ToString()%>
                            </td>
                            <td>
                                <%=pfipetArray[46].ToString()%>
                            </td>
                            <td>
                                <%=pfipetArray[47].ToString()%>
                            </td>
                        </tr>
                        <tr style="height: 10px;">
                            <td colspan="14" style="height: 10px; background: #DADADA">
                            </td>
                        </tr>
                        <tr style="height: 30px">
                            <th>
                                &nbsp;
                            </th>
                            <th>
                                重量(kg)
                            </th>
                            <th>
                                24.5
                            </th>
                            <th>
                                25.0
                            </th>
                            <th>
                                25.5
                            </th>
                            <th>
                                26.0
                            </th>
                            <th>
                                26.5
                            </th>
                            <th>
                                27.0
                            </th>
                            <th>
                                27.5
                            </th>
                            <th>
                                28.0
                            </th>
                            <th>
                                28.5
                            </th>
                            <th>
                                29.0
                            </th>
                            <th>
                                29.5
                            </th>
                            <th>
                                30.0
                            </th>
                        </tr>
                        <tr style="height: 30px">
                            <th>
                                EMS
                            </th>
                            <th>
                                <%=type[0].ToString() %>
                            </th>
                            <td>
                                <%=emsArray[48].ToString() %>
                            </td>
                            <td>
                                <%=emsArray[49].ToString() %>
                            </td>
                            <td>
                                <%=emsArray[50].ToString() %>
                            </td>
                            <td>
                                <%=emsArray[51].ToString() %>
                            </td>
                            <td>
                                <%=emsArray[52].ToString() %>
                            </td>
                            <td>
                                <%=emsArray[53].ToString() %>
                            </td>
                            <td>
                                <%=emsArray[54].ToString() %>
                            </td>
                            <td>
                                <%=emsArray[55].ToString() %>
                            </td>
                            <td>
                                <%=emsArray[56].ToString() %>
                            </td>
                            <td>
                                <%=emsArray[57].ToString() %>
                            </td>
                            <td>
                                <%=emsArray[58].ToString() %>
                            </td>
                            <td>
                                <%=emsArray[59].ToString() %>
                            </td>
                        </tr>
                        <tr style="height: 30px">
                            <th>
                                PostNL
                            </th>
                            <th>
                                <%=type[1].ToString() %>
                            </th>
                            <td>
                                <%=postnlArray[26].ToString() %>
                            </td>
                            <td>
                                <%=postnlArray[26].ToString()%>
                            </td>
                            <td>
                                <%=postnlArray[27].ToString()%>
                            </td>
                            <td>
                                <%=postnlArray[27].ToString()%>
                            </td>
                            <td>
                                <%=postnlArray[28].ToString()%>
                            </td>
                            <td>
                                <%=postnlArray[28].ToString()%>
                            </td>
                            <td>
                                <%=postnlArray[29].ToString()%>
                            </td>
                            <td>
                                <%=postnlArray[29].ToString()%>
                            </td>
                            <td>
                                <%=postnlArray[30].ToString()%>
                            </td>
                            <td>
                                <%=postnlArray[30].ToString()%>
                            </td>
                            <td>
                                <%=postnlArray[31].ToString()%>
                            </td>
                            <td>
                                <%=postnlArray[31].ToString()%>
                            </td>
                        </tr>
                        <tr style="height: 30px">
                            <th>
                                PF-GPR-C
                            </th>
                            <th>
                                <%=type[2].ToString() %>
                            </th>
                            <td>
                                <%=pfgprcArray[48].ToString()%>
                            </td>
                            <td>
                                <%=pfgprcArray[49].ToString()%>
                            </td>
                            <td>
                                <%=pfgprcArray[50].ToString()%>
                            </td>
                            <td>
                                <%=pfgprcArray[51].ToString()%>
                            </td>
                            <td>
                                <%=pfgprcArray[52].ToString()%>
                            </td>
                            <td>
                                <%=pfgprcArray[53].ToString()%>
                            </td>
                            <td>
                                <%=pfgprcArray[54].ToString()%>
                            </td>
                            <td>
                                <%=pfgprcArray[55].ToString()%>
                            </td>
                            <td>
                                <%=pfgprcArray[56].ToString()%>
                            </td>
                            <td>
                                <%=pfgprcArray[57].ToString()%>
                            </td>
                            <td>
                                <%=pfgprcArray[58].ToString()%>
                            </td>
                            <td>
                                <%=pfgprcArray[59].ToString()%>
                            </td>
                        </tr>
                        <tr style="height: 30px">
                            <th>
                                PF-GPR-D
                            </th>
                            <th>
                                <%=type[3].ToString() %>
                            </th>
                            <td>
                                <%=pfgprdArray[48].ToString()%>
                            </td>
                            <td>
                                <%=pfgprdArray[49].ToString()%>
                            </td>
                            <td>
                                <%=pfgprdArray[50].ToString()%>
                            </td>
                            <td>
                                <%=pfgprdArray[51].ToString()%>
                            </td>
                            <td>
                                <%=pfgprdArray[52].ToString()%>
                            </td>
                            <td>
                                <%=pfgprdArray[53].ToString()%>
                            </td>
                            <td>
                                <%=pfgprdArray[54].ToString()%>
                            </td>
                            <td>
                                <%=pfgprdArray[55].ToString()%>
                            </td>
                            <td>
                                <%=pfgprdArray[56].ToString()%>
                            </td>
                            <td>
                                <%=pfgprdArray[57].ToString()%>
                            </td>
                            <td>
                                <%=pfgprdArray[58].ToString()%>
                            </td>
                            <td>
                                <%=pfgprdArray[59].ToString()%>
                            </td>
                        </tr>
                        <tr style="height: 30px">
                            <th>
                                PF-IPE-C
                            </th>
                            <th>
                                <%=type[4].ToString() %>
                            </th>
                            <td>
                                <%=pfipecArray[48].ToString()%>
                            </td>
                            <td>
                                <%=pfipecArray[49].ToString()%>
                            </td>
                            <td>
                                <%=pfipecArray[50].ToString()%>
                            </td>
                            <td>
                                <%=pfipecArray[51].ToString()%>
                            </td>
                            <td>
                                <%=pfipecArray[52].ToString()%>
                            </td>
                            <td>
                                <%=pfipecArray[53].ToString()%>
                            </td>
                            <td>
                                <%=pfipecArray[54].ToString()%>
                            </td>
                            <td>
                                <%=pfipecArray[55].ToString()%>
                            </td>
                            <td>
                                <%=pfipecArray[56].ToString()%>
                            </td>
                            <td>
                                <%=pfipecArray[57].ToString()%>
                            </td>
                            <td>
                                <%=pfipecArray[58].ToString()%>
                            </td>
                            <td>
                                <%=pfipecArray[59].ToString()%>
                            </td>
                        </tr>
                        <tr style="height: 30px">
                            <th>
                                PF-IPE-D
                            </th>
                            <th>
                                <%=type[5].ToString() %>
                            </th>
                            <td>
                                <%=pfipedArray[48].ToString()%>
                            </td>
                            <td>
                                <%=pfipedArray[49].ToString()%>
                            </td>
                            <td>
                                <%=pfipedArray[50].ToString()%>
                            </td>
                            <td>
                                <%=pfipedArray[51].ToString()%>
                            </td>
                            <td>
                                <%=pfipedArray[52].ToString()%>
                            </td>
                            <td>
                                <%=pfipedArray[53].ToString()%>
                            </td>
                            <td>
                                <%=pfipedArray[54].ToString()%>
                            </td>
                            <td>
                                <%=pfipedArray[55].ToString()%>
                            </td>
                            <td>
                                <%=pfipedArray[56].ToString()%>
                            </td>
                            <td>
                                <%=pfipedArray[57].ToString()%>
                            </td>
                            <td>
                                <%=pfipedArray[58].ToString()%>
                            </td>
                            <td>
                                <%=pfipedArray[59].ToString()%>
                            </td>
                        </tr>
                        <tr style="height: 30px">
                            <th>
                                PF-IPE-P
                            </th>
                            <th>
                                <%=type[6].ToString() %>
                            </th>
                            <td>
                                <%=pfipepArray[48].ToString()%>
                            </td>
                            <td>
                                <%=pfipepArray[49].ToString()%>
                            </td>
                            <td>
                                <%=pfipepArray[50].ToString()%>
                            </td>
                            <td>
                                <%=pfipepArray[51].ToString()%>
                            </td>
                            <td>
                                <%=pfipepArray[52].ToString()%>
                            </td>
                            <td>
                                <%=pfipepArray[53].ToString()%>
                            </td>
                            <td>
                                <%=pfipepArray[54].ToString()%>
                            </td>
                            <td>
                                <%=pfipepArray[55].ToString()%>
                            </td>
                            <td>
                                <%=pfipepArray[56].ToString()%>
                            </td>
                            <td>
                                <%=pfipepArray[57].ToString()%>
                            </td>
                            <td>
                                <%=pfipepArray[58].ToString()%>
                            </td>
                            <td>
                                <%=pfipepArray[59].ToString()%>
                            </td>
                        </tr>
                        <tr style="height: 30px">
                            <th>
                                PF-IPE-T
                            </th>
                            <th>
                                <%=type[7].ToString() %>
                            </th>
                            <td>
                                <%=pfipetArray[48].ToString()%>
                            </td>
                            <td>
                                <%=pfipetArray[49].ToString()%>
                            </td>
                            <td>
                                <%=pfipetArray[50].ToString()%>
                            </td>
                            <td>
                                <%=pfipetArray[51].ToString()%>
                            </td>
                            <td>
                                <%=pfipetArray[52].ToString()%>
                            </td>
                            <td>
                                <%=pfipetArray[53].ToString()%>
                            </td>
                            <td>
                                <%=pfipetArray[54].ToString()%>
                            </td>
                            <td>
                                <%=pfipetArray[55].ToString()%>
                            </td>
                            <td>
                                <%=pfipetArray[56].ToString()%>
                            </td>
                            <td>
                                <%=pfipetArray[57].ToString()%>
                            </td>
                            <td>
                                <%=pfipetArray[58].ToString()%>
                            </td>
                            <td>
                                <%=pfipetArray[59].ToString()%>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
        <div class="panel-footer" style="color: #FF0000; font-weight: 600">
            <span>*PF-GPR-C&nbsp;:&nbsp;PF-GPR-Collection&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;PPF-GPR-D&nbsp;:&nbsp;PF-GPR-Delivery&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;PPF-IPE-C&nbsp;:&nbsp;PF-IPE-Collection</span>
            <p>
                *PF-IPE-D&nbsp;:&nbsp;PF-IPE-Depot Drop Off&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;PPF-IPE-P&nbsp;:&nbsp;PF-IPE-Pol
                Drop Off&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;PPF-IPE-T&nbsp;:&nbsp;PF-IPE-Trailer</p>
        </div>
    </div>
    </form>
</body>
</html>
