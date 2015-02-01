<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="add-rate-type-pf-ipe-depot.aspx.cs" Inherits="WM_Project.manage_system.super_admin_frame.add_rate_type_pf_ipe_depot" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../../stylesheets/bootstrap.css" rel="stylesheet" type="text/css" />
    <link href="../../stylesheets/bootstrap-theme.css" rel="stylesheet" type="text/css" />
    <script src="../../javascripts/bootstrap.js" type="text/javascript"></script>
    <script src="../../javascripts/jquery-1.11.1.js" type="text/javascript"></script>

    <script type="text/javascript">

        function isFreightRight() {
            var freights = document.getElementsByName("freight");

            for (i = 0; i < freights.length; i++) {
                if (freights[i].value.trim() == "") {
                    alert("价格不能为空！！");
                    return false;
                } else if (!isUnsignedNumeric(freights[i].value)) {
                    alert("邮费必须为数字！！");
                    return false;
                }
            }
            return true;
        }


        /*
        *	验证是否是正实数,不包括 0 
        */
        function isUnsignedNumeric(strNumber) {
            if (strNumber.trim() != 0) {
                var newPar = /^\d+(\.\d+)?$/;
                return newPar.test(strNumber.trim());
            }
            else {
                return false;
            }

        }
    </script>

    <style type="text/css">
        td,th{text-align:center}
        input{margin:0px;text-align:center;}
    </style>

</head>
<body>
    <form id="form1" runat="server">
    <div style="width: 700px;">
        <div class="panel panel-primary">
            <div class="panel-heading">
                <h3 class="panel-title">
                    设置 PF-IPE-Depot Drop Off 各类型的邮费</h3>
            </div>
            <div class="panel-body">
                <div class="form-group" style="margin-top: 10px; height: 40px; clear: both">
                    <div style="width: 120px; float: left; text-align: right">
                        <label class="control-label" style="padding-top: 5px; padding-right: 20px">
                            邮费类型名</label></div>
                    <div style="width: 500px; float: left">
                        <asp:DropDownList runat="server" ID="rate_list" AutoPostBack="true" CssClass="form-control"
                            OnSelectedIndexChanged="rate_list_SelectedIndexChanged">
                            <asp:ListItem Selected="true" Value="rate1">rate1</asp:ListItem>
                            <asp:ListItem Value="rate2">rate2</asp:ListItem>
                            <asp:ListItem Value="rate3">rate3</asp:ListItem>
                            <asp:ListItem Value="rate4">rate4</asp:ListItem>
                            <asp:ListItem Value="rate5">rate5</asp:ListItem>
                            <asp:ListItem Value="rate6">rate6</asp:ListItem>
                            <asp:ListItem Value="rate7">rate7</asp:ListItem>
                            <asp:ListItem Value="rate8">rate8</asp:ListItem>
                            <asp:ListItem Value="rate9">rate9</asp:ListItem>
                            <asp:ListItem Value="rate10">rate10</asp:ListItem>
                            <asp:ListItem Value="rate11">rate11</asp:ListItem>
                            <asp:ListItem Value="rate12">rate12</asp:ListItem>
                            <asp:ListItem Value="rate13">rate13</asp:ListItem>
                            <asp:ListItem Value="rate14">rate14</asp:ListItem>
                            <asp:ListItem Value="rate15">rate15</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div style="color: #FF0000; padding-left: 10px; padding-top: 10px; width: 40px; float: left">
                        &nbsp;</div>
                </div>
                <div style="height: 10px;">
                    &nbsp;</div>
                <div class="form-group">
                    <table border="1" cellspacing="0" cellpadding="0" width="100%">
                        <tr>
                            <th style="width: 75px;">
                                重量(kg)
                            </th>
                            <td style="width: 75px;  font-weight: 600">
                                0.5
                            </td>
                            <td style="width: 75px;  font-weight: 600">
                                1.0
                            </td>
                            <td style="width: 75px;  font-weight: 600">
                                1.5
                            </td>
                            <td style="width: 75px;  font-weight: 600">
                                2.0
                            </td>
                            <td style="width: 75px;  font-weight: 600">
                                2.5
                            </td>
                            <td style="width: 75px;  font-weight: 600">
                                3.0
                            </td>
                            <td style="width: 75px; font-weight: 600">
                                3.5
                            </td>
                            <td style="width: 75px; font-weight: 600">
                                4.0
                            </td>
                        </tr>
                        <tr>
                            <th style="width: 75px;">
                                邮费(£)
                            </th>
                            <td style="width: 75px;">
                                <input type="text" name="freight" class="form-control"  value="<%=current_rate[0].ToString() %>" />
                            </td>
                            <td style="width: 75px;">
                                <input type="text" name="freight" class="form-control"  value="<%=current_rate[1].ToString() %>" />
                            </td>
                            <td style="width: 75px;">
                                <input type="text" name="freight" class="form-control"  value="<%=current_rate[2].ToString() %>" />
                            </td>
                            <td style="width: 75px; ">
                                <input type="text" name="freight" class="form-control"  value="<%=current_rate[3].ToString() %>" />
                            </td>
                            <td style="width: 75px;">
                                <input type="text" name="freight" class="form-control" " value="<%=current_rate[4].ToString() %>" />
                            </td>
                            <td style="width: 75px;">
                                <input type="text" name="freight" class="form-control"  value="<%=current_rate[5].ToString() %>" />
                            </td>
                            <td style="width: 75px;">
                                <input type="text" name="freight" class="form-control"  value="<%=current_rate[6].ToString() %>" />
                            </td>
                            <td style="width: 75px;">
                                <input type="text" name="freight" class="form-control"  value="<%=current_rate[7].ToString() %>" />
                            </td>
                        </tr>
                        <tr>
                            <th style="width: 75px; ">
                                重量(kg)
                            </th>
                            <td style="width: 75px; font-weight: 600">
                                4.5
                            </td>
                            <td style="width: 75px;  font-weight: 600">
                                5.0
                            </td>
                            <td style="width: 75px;font-weight: 600">
                                5.5
                            </td>
                            <td style="width: 75px; font-weight: 600">
                                6.0
                            </td>
                            <td style="width: 75px; font-weight: 600">
                                6.5
                            </td>
                            <td style="width: 75px; font-weight: 600">
                                7.0
                            </td>
                            <td style="width: 75px; font-weight: 600">
                                7.5
                            </td>
                            <td style="width: 75px;font-weight: 600">
                                8.0
                            </td>
                        </tr>
                        <tr>
                            <th style="width: 75px;">
                                邮费(£)
                            </th>
                            <td style="width: 75px;">
                                <input type="text" name="freight" class="form-control"  value="<%=current_rate[8].ToString() %>" />
                            </td>
                            <td style="width: 75px;">
                                <input type="text" name="freight" class="form-control"  value="<%=current_rate[9].ToString() %>" />
                            </td>
                            <td style="width: 75px;">
                                <input type="text" name="freight" class="form-control"  value="<%=current_rate[10].ToString() %>" />
                            </td>
                            <td style="width: 75px;">
                                <input type="text" name="freight" class="form-control" value="<%=current_rate[11].ToString() %>" />
                            </td>
                            <td style="width: 75px;">
                                <input type="text" name="freight" class="form-control"  value="<%=current_rate[12].ToString() %>" />
                            </td>
                            <td style="width: 75px;">
                                <input type="text" name="freight" class="form-control" value="<%=current_rate[13].ToString() %>" />
                            </td>
                            <td style="width: 75px;">
                                <input type="text" name="freight" class="form-control"  value="<%=current_rate[14].ToString() %>" />
                            </td>
                            <td style="width: 75px;">
                                <input type="text" name="freight" class="form-control"  value="<%=current_rate[15].ToString() %>" />
                            </td>
                        </tr>
                        <tr>
                            <th style="width: 75px;">
                                重量(kg)
                            </th>
                            <td style="width: 75px;font-weight: 600">
                                8.5
                            </td>
                            <td style="width: 75px;font-weight: 600">
                                9.0
                            </td>
                            <td style="width: 75px;font-weight: 600">
                                9.5
                            </td>
                            <td style="width: 75px;font-weight: 600">
                                10.0
                            </td>
                            <td style="width: 75px;font-weight: 600">
                                10.5
                            </td>
                            <td style="width: 75px;font-weight: 600">
                                11.0
                            </td>
                            <td style="width: 75px;font-weight: 600">
                                11.5
                            </td>
                            <td style="width: 75px;font-weight: 600">
                                12.0
                            </td>
                        </tr>
                        <tr>
                            <th style="width: 75px;">
                                邮费(£)
                            </th>
                            <td style="width: 75px;">
                                <input type="text" name="freight" class="form-control" value="<%=current_rate[16].ToString() %>" />
                            </td>
                            <td style="width: 75px;">
                                <input type="text" name="freight" class="form-control" value="<%=current_rate[17].ToString() %>" />
                            </td>
                            <td style="width: 75px;">
                                <input type="text" name="freight" class="form-control"  value="<%=current_rate[18].ToString() %>" />
                            </td>
                            <td style="width: 75px;">
                                <input type="text" name="freight" class="form-control"  value="<%=current_rate[19].ToString() %>" />
                            </td>
                            <td style="width: 75px;">
                                <input type="text" name="freight" class="form-control"  value="<%=current_rate[20].ToString() %>" />
                            </td>
                            <td style="width: 75px;">
                                <input type="text" name="freight" class="form-control" value="<%=current_rate[21].ToString() %>" />
                            </td>
                            <td style="width: 75px;">
                                <input type="text" name="freight" class="form-control" value="<%=current_rate[22].ToString() %>" />
                            </td>
                            <td style="width: 75px;">
                                <input type="text" name="freight" class="form-control" value="<%=current_rate[23].ToString() %>" />
                            </td>
                        </tr>
                        <tr>
                            <th style="width: 75px;">
                                重量(kg)
                            </th>
                            <td style="width: 75px; font-weight: 600">
                                12.5
                            </td>
                            <td style="width: 75px;font-weight: 600">
                                13.0
                            </td>
                            <td style="width: 75px;font-weight: 600">
                                13.5
                            </td>
                            <td style="width: 75px; text-align: center; font-weight: 600">
                                14.0
                            </td>
                            <td style="width: 75px; text-align: center; font-weight: 600">
                                14.5
                            </td>
                            <td style="width: 75px; text-align: center; font-weight: 600">
                                15.0
                            </td>
                            <td style="width: 75px; text-align: center; font-weight: 600">
                                15.5
                            </td>
                            <td style="width: 75px; text-align: center; font-weight: 600">
                                16.0
                            </td>
                        </tr>
                        <tr>
                            <th style="width: 75px;">
                                邮费(£)
                            </th>
                            <td style="width: 75px;">
                                <input type="text" name="freight" class="form-control" value="<%=current_rate[24].ToString() %>" />
                            </td>
                            <td style="width: 75px;">
                                <input type="text" name="freight" class="form-control" value="<%=current_rate[25].ToString() %>" />
                            </td>
                            <td style="width: 75px;"> 
                                <input type="text" name="freight" class="form-control" value="<%=current_rate[26].ToString() %>" />
                            </td>
                            <td style="width: 75px;">
                                <input type="text" name="freight" class="form-control"  value="<%=current_rate[27].ToString() %>" />
                            </td>
                            <td style="width: 75px; ">
                                <input type="text" name="freight" class="form-control" value="<%=current_rate[28].ToString() %>" />
                            </td>
                            <td style="width: 75px; ">
                                <input type="text" name="freight" class="form-control" value="<%=current_rate[29].ToString() %>" />
                            </td>
                            <td style="width: 75px;">
                                <input type="text" name="freight" class="form-control" value="<%=current_rate[30].ToString() %>" />
                            </td>
                            <td style="width: 75px;">
                                <input type="text" name="freight" class="form-control" value="<%=current_rate[31].ToString() %>" />
                            </td>
                        </tr>
                        <tr>
                            <th style="width: 75px; text-align: center">
                                重量(kg)
                            </th>
                            <td style="width: 75px; text-align: center; font-weight: 600">
                                16.5
                            </td>
                            <td style="width: 75px; text-align: center; font-weight: 600">
                                17.0
                            </td>
                            <td style="width: 75px; text-align: center; font-weight: 600">
                                17.5
                            </td>
                            <td style="width: 75px; text-align: center; font-weight: 600">
                                18.0
                            </td>
                            <td style="width: 75px; text-align: center; font-weight: 600">
                                18.5
                            </td>
                            <td style="width: 75px; text-align: center; font-weight: 600">
                                19.0
                            </td>
                            <td style="width: 75px; text-align: center; font-weight: 600">
                                19.5
                            </td>
                            <td style="width: 75px; text-align: center; font-weight: 600">
                                20.0
                            </td>
                        </tr>
                        <tr>
                            <th style="width: 75px; text-align: center">
                                邮费(£)
                            </th>
                            <td style="width: 75px; text-align: center">
                                <input type="text" name="freight" class="form-control" value="<%=current_rate[32].ToString() %>" />
                            </td>
                            <td style="width: 75px; text-align: center">
                                <input type="text" name="freight" class="form-control"  value="<%=current_rate[33].ToString() %>" />
                            </td>
                            <td style="width: 75px; text-align: center">
                                <input type="text" name="freight" class="form-control" value="<%=current_rate[34].ToString() %>" />
                            </td>
                            <td style="width: 75px; text-align: center">
                                <input type="text" name="freight" class="form-control"  value="<%=current_rate[35].ToString() %>" />
                            </td>
                            <td style="width: 75px; text-align: center">
                                <input type="text" name="freight" class="form-control"  value="<%=current_rate[36].ToString() %>" />
                            </td>
                            <td style="width: 75px; text-align: center">
                                <input type="text" name="freight" class="form-control" value="<%=current_rate[37].ToString() %>" />
                            </td>
                            <td style="width: 75px; text-align: center">
                                <input type="text" name="freight" class="form-control" value="<%=current_rate[38].ToString() %>" />
                            </td>
                            <td style="width: 75px; text-align: center">
                                <input type="text" name="freight" class="form-control" value="<%=current_rate[39].ToString() %>" />
                            </td>
                        </tr>
                        <tr>
                            <th style="width: 75px; text-align: center">
                                重量(kg)
                            </th>
                            <td style="width: 75px; text-align: center; font-weight: 600">
                                20.5
                            </td>
                            <td style="width: 75px; text-align: center; font-weight: 600">
                                21.0
                            </td>
                            <td style="width: 75px; text-align: center; font-weight: 600">
                                21.5
                            </td>
                            <td style="width: 75px; text-align: center; font-weight: 600">
                                22.0
                            </td>
                            <td style="width: 75px; text-align: center; font-weight: 600">
                                22.5
                            </td>
                            <td style="width: 75px; text-align: center; font-weight: 600">
                                23.0
                            </td>
                            <td style="width: 75px; text-align: center; font-weight: 600">
                                23.5
                            </td>
                            <td style="width: 75px; text-align: center; font-weight: 600">
                                24.0
                            </td>
                        </tr>
                        <tr>
                            <th style="width: 75px; text-align: center">
                                邮费(£)
                            </th>
                            <td style="width: 75px; text-align: center">
                                <input type="text" name="freight" class="form-control" value="<%=current_rate[40].ToString() %>" />
                            </td>
                            <td style="width: 75px; text-align: center">
                                <input type="text" name="freight" class="form-control" value="<%=current_rate[41].ToString() %>" />
                            </td>
                            <td style="width: 75px; text-align: center">
                                <input type="text" name="freight" class="form-control" value="<%=current_rate[42].ToString() %>" />
                            </td>
                            <td style="width: 75px; text-align: center">
                                <input type="text" name="freight" class="form-control" value="<%=current_rate[43].ToString() %>" />
                            </td>
                            <td style="width: 75px; text-align: center">
                                <input type="text" name="freight" class="form-control" value="<%=current_rate[44].ToString() %>" />
                            </td>
                            <td style="width: 75px; text-align: center">
                                <input type="text" name="freight" class="form-control" value="<%=current_rate[45].ToString() %>" />
                            </td>
                            <td style="width: 75px; text-align: center">
                                <input type="text" name="freight" class="form-control" value="<%=current_rate[46].ToString() %>" />
                            </td>
                            <td style="width: 75px; text-align: center">
                                <input type="text" name="freight" class="form-control" value="<%=current_rate[47].ToString() %>" />
                            </td>
                        </tr>
                        <tr>
                            <th style="width: 75px; text-align: center">
                                重量(kg)
                            </th>
                            <td style="width: 75px; text-align: center; font-weight: 600">
                                24.5
                            </td>
                            <td style="width: 75px; text-align: center; font-weight: 600">
                                25.0
                            </td>
                            <td style="width: 75px; text-align: center; font-weight: 600">
                                25.5
                            </td>
                            <td style="width: 75px; text-align: center; font-weight: 600">
                                26.0
                            </td>
                            <td style="width: 75px; text-align: center; font-weight: 600">
                                26.5
                            </td>
                            <td style="width: 75px; text-align: center; font-weight: 600">
                                27.0
                            </td>
                            <td style="width: 75px; text-align: center; font-weight: 600">
                                27.5
                            </td>
                            <td style="width: 75px; text-align: center; font-weight: 600">
                                28.0
                            </td>
                        </tr>
                        <tr>
                            <th style="width: 75px; text-align: center">
                                邮费(£)
                            </th>
                            <td style="width: 75px; text-align: center">
                                <input type="text" name="freight" class="form-control" value="<%=current_rate[48].ToString() %>" />
                            </td>
                            <td style="width: 75px; text-align: center">
                                <input type="text" name="freight" class="form-control" value="<%=current_rate[49].ToString() %>" />
                            </td>
                            <td style="width: 75px; text-align: center">
                                <input type="text" name="freight" class="form-control" value="<%=current_rate[50].ToString() %>" />
                            </td>
                            <td style="width: 75px; text-align: center">
                                <input type="text" name="freight" class="form-control" value="<%=current_rate[51].ToString() %>" />
                            </td>
                            <td style="width: 75px; text-align: center">
                                <input type="text" name="freight" class="form-control" value="<%=current_rate[52].ToString() %>" />
                            </td>
                            <td style="width: 75px; text-align: center">
                                <input type="text" name="freight" class="form-control" value="<%=current_rate[53].ToString() %>" />
                            </td>
                            <td style="width: 75px; text-align: center">
                                <input type="text" name="freight" class="form-control" value="<%=current_rate[54].ToString() %>" />
                            </td>
                            <td style="width: 75px; text-align: center">
                                <input type="text" name="freight" class="form-control" value="<%=current_rate[55].ToString() %>" />
                            </td>
                        </tr>
                        <tr>
                            <th style="width: 75px; text-align: center">
                                重量(kg)
                            </th>
                            <td style="width: 75px; text-align: center; font-weight: 600">
                                28.5
                            </td>
                            <td style="width: 75px; text-align: center; font-weight: 600">
                                29.0
                            </td>
                            <td style="width: 75px; text-align: center; font-weight: 600">
                                29.5
                            </td>
                            <td style="width: 75px; text-align: center; font-weight: 600">
                                30.0
                            </td>
                            <td style="width: 75px; text-align: center; font-weight: 600">
                                &nbsp;
                            </td>
                            <td style="width: 75px; text-align: center; font-weight: 600">
                                &nbsp;
                            </td>
                            <td style="width: 75px; text-align: center; font-weight: 600">
                                &nbsp;
                            </td>
                            <td style="width: 75px; text-align: center; font-weight: 600">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <th style="width: 75px; text-align: center">
                                邮费(£)
                            </th>
                            <td style="width: 75px; text-align: center">
                                <input type="text" name="freight" class="form-control" value="<%=current_rate[56].ToString() %>" />
                            </td>
                            <td style="width: 75px; text-align: center">
                                <input type="text" name="freight" class="form-control" value="<%=current_rate[57].ToString() %>" />
                            </td>
                            <td style="width: 75px; text-align: center">
                                <input type="text" name="freight" class="form-control" value="<%=current_rate[58].ToString() %>" />
                            </td>
                            <td style="width: 75px; text-align: center">
                                <input type="text" name="freight" class="form-control" value="<%=current_rate[59].ToString() %>" />
                            </td>
                            <td style="width: 75px; text-align: center">
                                &nbsp;
                            </td>
                            <td style="width: 75px; text-align: center">
                                &nbsp;
                            </td>
                            <td style="width: 75px; text-align: center">
                                &nbsp;
                            </td>
                            <td style="width: 75px; text-align: center">
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="form-group" style="text-align: center">
                    <asp:Button ID="btn_pf_rate" runat="Server" Text="设置 PF-IPE-D 邮费类型" CssClass="btn btn-info" OnClientClick="return isFreightRight()"
                        Width="240px" OnClick="btn_pf_rate_Click" />
                </div>
            </div>
            <div class="panel-footer" style="color:#FF0000; font-weight:600">
                <p>*&nbsp;设置邮费时请注意，邮费必须从 rate1 到 rate10 递减，rate1 最高， rate10 最低， 否则将导致计算的邮费有误！！！</p>
            </div>
        </div>
        <div class="panel panel-primary">
            <div class="panel-heading">
                <h3 class="panel-title">
                    PF-IPE-Depot Drop Off 各类型的邮费信息如下</h3>
            </div>
            <div class="panel-body">
                <div class="form-group">

                     <table border="1" cellspacing="0" cellpadding="0" width="100%">
                    	<tr>
                    		<th style="text-align:center;width:63px;">重量(kg)</th>
                            <td style="text-align:center;width:50px;">0.5</td>
                            <td style="text-align:center;width:50px;">1.0</td>
                            <td style="text-align:center;width:50px;">1.5</td>
                            <td style="text-align:center;width:50px;">2.0</td>
                            <td style="text-align:center;width:50px;">2.5</td>
                            <td style="text-align:center;width:50px;">3.0</td>
                            <td style="text-align:center;width:50px;">3.5</td>
                            <td style="text-align:center;width:50px;">3.0</td>
                            <td style="text-align:center;width:50px;">4.5</td>
                            <td style="text-align:center;width:50px;">5.0</td>
                            <td style="text-align:center;width:50px;">5.5</td>
                            <td style="text-align:center;width:50px;">6.0</td>
                            <td style="text-align:center;width:50px;">6.5</td>
                    	</tr>
                        <tr>
                    		<th style="text-align:center;width:63px;">rate1(£)</th>
                            <td style="text-align:center;width:50px;"><%=rate1[0].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate1[1].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate1[2].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate1[3].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate1[4].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate1[5].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate1[6].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate1[7].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate1[8].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate1[9].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate1[10].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate1[11].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate1[12].ToString() %></td>
                    	</tr>
                        <tr>
                    		<th style="text-align:center;width:63px;">rate2(£)</th>
                            <td style="text-align:center;width:50px;"><%=rate2[0].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate2[1].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate2[2].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate2[3].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate2[4].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate2[5].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate2[6].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate2[7].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate2[8].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate2[9].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate2[10].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate2[11].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate2[12].ToString() %></td>
                    	</tr>
                        <tr>
                    		<th style="text-align:center;width:63px;">rate3(£)</th>
                            <td style="text-align:center;width:50px;"><%=rate3[0].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate3[1].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate3[2].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate3[3].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate3[4].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate3[5].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate3[6].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate3[7].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate3[8].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate3[9].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate3[10].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate3[11].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate3[12].ToString() %></td>
                    	</tr>
                        <tr>
                    		<th style="text-align:center;width:63px;">rate4(£)</th>
                            <td style="text-align:center;width:50px;"><%=rate4[0].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate4[1].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate4[2].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate4[3].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate4[4].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate4[5].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate4[6].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate4[7].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate4[8].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate4[9].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate4[10].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate4[11].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate4[12].ToString() %></td>
                    	</tr>
                        <tr>
                    		<th style="text-align:center;width:63px;">rate5(£)</th>
                            <td style="text-align:center;width:50px;"><%=rate5[0].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate5[1].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate5[2].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate5[3].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate5[4].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate5[5].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate5[6].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate5[7].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate5[8].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate5[9].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate5[10].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate5[11].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate5[12].ToString() %></td>
                    	</tr>
                        <tr>
                    		<th style="text-align:center;width:63px;">rate6(£)</th>
                            <td style="text-align:center;width:50px;"><%=rate6[0].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate6[1].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate6[2].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate6[3].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate6[4].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate6[5].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate6[6].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate6[7].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate6[8].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate6[9].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate6[10].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate6[11].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate6[12].ToString() %></td>
                    	</tr>
                        <tr>
                    		<th style="text-align:center;width:63px;">rate7(£)</th>
                            <td style="text-align:center;width:50px;"><%=rate7[0].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate7[1].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate7[2].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate7[3].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate7[4].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate7[5].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate7[6].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate7[7].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate7[8].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate7[9].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate7[10].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate7[11].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate7[12].ToString() %></td>
                    	</tr>
                        <tr>
                    		<th style="text-align:center;width:63px;">rate8(£)</th>
                            <td style="text-align:center;width:50px;"><%=rate8[0].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate8[1].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate8[2].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate8[3].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate8[4].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate8[5].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate8[6].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate8[7].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate8[8].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate8[9].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate8[10].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate8[11].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate8[12].ToString() %></td>
                    	</tr>
                        <tr>
                    		<th style="text-align:center;width:63px;">rate9(£)</th>
                            <td style="text-align:center;width:50px;"><%=rate9[0].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate9[1].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate9[2].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate9[3].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate9[4].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate9[5].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate9[6].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate9[7].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate9[8].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate9[9].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate9[10].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate9[11].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate9[12].ToString() %></td>
                    	</tr>
                        <tr>
                    		<th style="text-align:center;width:63px;">rate10(£)</th>
                            <td style="text-align:center;width:50px;"><%=rate10[0].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate10[1].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate10[2].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate10[3].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate10[4].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate10[5].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate10[6].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate10[7].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate10[8].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate10[9].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate10[10].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate10[11].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate10[12].ToString() %></td>
                    	</tr>
                        <tr>
                    		<th style="text-align:center;width:63px;">rate11(£)</th>
                            <td style="text-align:center;width:50px;"><%=rate11[0].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate11[1].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate11[2].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate11[3].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate11[4].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate11[5].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate11[6].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate11[7].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate11[8].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate11[9].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate11[10].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate11[11].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate11[12].ToString() %></td>
                    	</tr>
                        <tr>
                    		<th style="text-align:center;width:63px;">rate12(£)</th>
                            <td style="text-align:center;width:50px;"><%=rate12[0].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate12[1].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate12[2].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate12[3].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate12[4].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate12[5].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate12[6].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate12[7].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate12[8].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate12[9].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate12[10].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate12[11].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate12[12].ToString() %></td>
                    	</tr>
                        <tr>
                    		<th style="text-align:center;width:63px;">rate13(£)</th>
                            <td style="text-align:center;width:50px;"><%=rate13[0].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate13[1].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate13[2].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate13[3].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate13[4].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate13[5].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate13[6].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate13[7].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate13[8].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate13[9].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate13[10].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate13[11].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate13[12].ToString() %></td>
                    	</tr>
                        <tr>
                    		<th style="text-align:center;width:63px;">rate14(£)</th>
                            <td style="text-align:center;width:50px;"><%=rate14[0].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate14[1].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate14[2].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate14[3].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate14[4].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate14[5].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate14[6].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate14[7].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate14[8].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate14[9].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate14[10].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate14[11].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate14[12].ToString() %></td>
                    	</tr>
                        <tr>
                    		<th style="text-align:center;width:63px;">rate15(£)</th>
                            <td style="text-align:center;width:50px;"><%=rate15[0].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate15[1].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate15[2].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate15[3].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate15[4].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate15[5].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate15[6].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate15[7].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate15[8].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate15[9].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate15[10].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate15[11].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate15[12].ToString() %></td>
                    	</tr>
                        <tr style="height:10px;"><td colspan="14" style="height:10px;background:#DADADA"></td></tr>

                        <tr>
                    		<th style="text-align:center;width:63px;">重量(kg)</th>
                            <td style="text-align:center;width:50px;">7.0</td>
                            <td style="text-align:center;width:50px;">7.5</td>
                            <td style="text-align:center;width:50px;">8.0</td>
                            <td style="text-align:center;width:50px;">8.5</td>
                            <td style="text-align:center;width:50px;">9.0</td>
                            <td style="text-align:center;width:50px;">9.5</td>
                            <td style="text-align:center;width:50px;">10.0</td>
                            <td style="text-align:center;width:50px;">10.5</td>
                            <td style="text-align:center;width:50px;">11.0</td>
                            <td style="text-align:center;width:50px;">11.5</td>
                            <td style="text-align:center;width:50px;">12.0</td>
                            <td style="text-align:center;width:50px;">12.5</td>
                            <td style="text-align:center;width:50px;">13.0</td>
                    	</tr>
                        <tr>
                    		<th style="text-align:center;width:63px;">rate1(£)</th>
                            <td style="text-align:center;width:50px;"><%=rate1[13].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate1[14].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate1[15].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate1[16].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate1[17].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate1[18].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate1[19].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate1[20].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate1[21].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate1[22].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate1[23].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate1[24].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate1[25].ToString() %></td>
                    	</tr>
                        <tr>
                    		<th style="text-align:center;width:63px;">rate2(£)</th>
                            <td style="text-align:center;width:50px;"><%=rate2[13].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate2[14].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate2[15].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate2[16].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate2[17].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate2[18].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate2[19].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate2[20].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate2[21].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate2[22].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate2[23].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate2[24].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate2[25].ToString() %></td>
                    	</tr>
                        <tr>
                    		<th style="text-align:center;width:63px;">rate3(£)</th>
                            <td style="text-align:center;width:50px;"><%=rate3[13].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate3[14].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate3[15].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate3[16].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate3[17].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate3[18].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate3[19].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate3[20].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate3[21].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate3[22].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate3[23].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate3[24].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate3[25].ToString() %></td>
                    	</tr>
                        <tr>
                    		<th style="text-align:center;width:63px;">rate4(£)</th>
                            <td style="text-align:center;width:50px;"><%=rate4[13].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate4[14].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate4[15].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate4[16].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate4[17].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate4[18].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate4[19].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate4[20].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate4[21].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate4[22].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate4[23].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate4[24].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate4[25].ToString() %></td>
                    	</tr>
                        <tr>
                    		<th style="text-align:center;width:63px;">rate5(£)</th>
                            <td style="text-align:center;width:50px;"><%=rate5[13].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate5[14].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate5[15].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate5[16].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate5[17].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate5[18].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate5[19].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate5[20].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate5[21].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate5[22].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate5[23].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate5[24].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate5[25].ToString() %></td>
                    	</tr>
                        <tr>
                    		<th style="text-align:center;width:63px;">rate6(£)</th>
                            <td style="text-align:center;width:50px;"><%=rate6[13].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate6[14].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate6[15].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate6[16].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate6[17].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate6[18].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate6[19].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate6[20].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate6[21].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate6[22].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate6[23].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate6[24].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate6[25].ToString() %></td>
                    	</tr>
                        <tr>
                    		<th style="text-align:center;width:63px;">rate7(£)</th>
                            <td style="text-align:center;width:50px;"><%=rate7[13].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate7[14].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate7[15].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate7[16].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate7[17].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate7[18].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate7[19].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate7[20].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate7[21].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate7[22].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate7[23].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate7[24].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate7[25].ToString() %></td>
                    	</tr>
                        <tr>
                    		<th style="text-align:center;width:63px;">rate8(£)</th>
                            <td style="text-align:center;width:50px;"><%=rate8[13].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate8[14].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate8[15].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate8[16].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate8[17].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate8[18].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate8[19].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate8[20].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate8[21].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate8[22].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate8[23].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate8[24].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate8[25].ToString() %></td>
                    	</tr>
                        <tr>
                    		<th style="text-align:center;width:63px;">rate9(£)</th>
                            <td style="text-align:center;width:50px;"><%=rate9[13].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate9[14].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate9[15].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate9[16].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate9[17].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate9[18].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate9[19].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate9[20].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate9[21].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate9[22].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate9[23].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate9[24].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate9[25].ToString() %></td>
                    	</tr>
                        <tr>
                    		<th style="text-align:center;width:63px;">rate10(£)</th>
                            <td style="text-align:center;width:50px;"><%=rate10[13].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate10[14].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate10[15].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate10[16].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate10[17].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate10[18].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate10[19].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate10[20].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate10[21].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate10[22].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate10[23].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate10[24].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate10[25].ToString() %></td>
                    	</tr>
                        <tr>
                    		<th style="text-align:center;width:63px;">rate11(£)</th>
                            <td style="text-align:center;width:50px;"><%=rate11[13].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate11[14].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate11[15].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate11[16].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate11[17].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate11[18].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate11[19].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate11[20].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate11[21].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate11[22].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate11[23].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate11[24].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate11[25].ToString() %></td>
                    	</tr>
                        <tr>
                    		<th style="text-align:center;width:63px;">rate12(£)</th>
                            <td style="text-align:center;width:50px;"><%=rate12[13].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate12[14].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate12[15].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate12[16].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate12[17].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate12[18].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate12[19].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate12[20].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate12[21].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate12[22].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate12[23].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate12[24].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate12[25].ToString() %></td>
                    	</tr>
                        <tr>
                    		<th style="text-align:center;width:63px;">rate13(£)</th>
                            <td style="text-align:center;width:50px;"><%=rate13[13].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate13[14].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate13[15].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate13[16].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate13[17].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate13[18].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate13[19].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate13[20].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate13[21].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate13[22].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate13[23].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate13[24].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate13[25].ToString() %></td>
                    	</tr>
                        <tr>
                    		<th style="text-align:center;width:63px;">rate14(£)</th>
                            <td style="text-align:center;width:50px;"><%=rate14[13].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate14[14].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate14[15].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate14[16].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate14[17].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate14[18].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate14[19].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate14[20].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate14[21].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate14[22].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate14[23].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate14[24].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate14[25].ToString() %></td>
                    	</tr>
                        <tr>
                    		<th style="text-align:center;width:63px;">rate15(£)</th>
                            <td style="text-align:center;width:50px;"><%=rate15[13].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate15[14].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate15[15].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate15[16].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate15[17].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate15[18].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate15[19].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate15[20].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate15[21].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate15[22].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate15[23].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate15[24].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate15[25].ToString() %></td>
                    	</tr>
                        <tr style="height:10px;"><td colspan="14" style="height:10px;background:#DADADA"></td></tr>

                        <tr>
                    		<th style="text-align:center;width:63px;">重量(kg)</th>
                            
                            <td style="text-align:center;width:50px;">13.5</td>
                            <td style="text-align:center;width:50px;">14.0</td>
                            <td style="text-align:center;width:50px;">14.5</td>
                            <td style="text-align:center;width:50px;">15.0</td>
                            <td style="text-align:center;width:50px;">15.5</td>
                            <td style="text-align:center;width:50px;">16.0</td>
                            <td style="text-align:center;width:50px;">16.5</td>
                            <td style="text-align:center;width:50px;">17.0</td>
                            <td style="text-align:center;width:50px;">17.5</td>
                            <td style="text-align:center;width:50px;">18.0</td>
                            <td style="text-align:center;width:50px;">18.5</td>
                            <td style="text-align:center;width:50px;">19.0</td>
                            <td style="text-align:center;width:50px;">19.5</td>
                    	</tr>
                        <tr>
                    		<th style="text-align:center;width:63px;">rate1(£)</th>
                            <td style="text-align:center;width:50px;"><%=rate1[26].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate1[27].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate1[28].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate1[29].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate1[30].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate1[31].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate1[32].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate1[33].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate1[34].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate1[35].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate1[36].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate1[37].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate1[38].ToString() %></td>
                    	</tr>
                        <tr>
                    		<th style="text-align:center;width:63px;">rate2(£)</th>
                            <td style="text-align:center;width:50px;"><%=rate2[26].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate2[27].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate2[28].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate2[29].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate2[30].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate2[31].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate2[32].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate2[33].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate2[34].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate2[35].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate2[36].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate2[37].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate2[38].ToString() %></td>
                    	</tr>
                        <tr>
                    		<th style="text-align:center;width:63px;">rate3(£)</th>
                            <td style="text-align:center;width:50px;"><%=rate3[26].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate3[27].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate3[28].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate3[29].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate3[30].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate3[31].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate3[32].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate3[33].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate3[34].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate3[35].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate3[36].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate3[37].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate3[38].ToString() %></td>
                    	</tr>
                        <tr>
                    		<th style="text-align:center;width:63px;">rate4(£)</th>
                            <td style="text-align:center;width:50px;"><%=rate4[26].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate4[27].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate4[28].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate4[29].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate4[30].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate4[31].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate4[32].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate4[33].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate4[34].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate4[35].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate4[36].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate4[37].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate4[38].ToString() %></td>
                    	</tr>
                        <tr>
                    		<th style="text-align:center;width:63px;">rate5(£)</th>
                            <td style="text-align:center;width:50px;"><%=rate5[26].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate5[27].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate5[28].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate5[29].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate5[30].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate5[31].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate5[32].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate5[33].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate5[34].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate5[35].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate5[36].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate5[37].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate5[38].ToString() %></td>
                    	</tr>
                        <tr>
                    		<th style="text-align:center;width:63px;">rate6(£)</th>
                            <td style="text-align:center;width:50px;"><%=rate6[26].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate6[27].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate6[28].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate6[29].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate6[30].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate6[31].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate6[32].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate6[33].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate6[34].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate6[35].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate6[36].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate6[37].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate6[38].ToString() %></td>
                    	</tr>
                        <tr>
                    		<th style="text-align:center;width:63px;">rate7(£)</th>
                            <td style="text-align:center;width:50px;"><%=rate7[26].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate7[27].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate7[28].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate7[29].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate7[30].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate7[31].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate7[32].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate7[33].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate7[34].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate7[35].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate7[36].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate7[37].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate7[38].ToString() %></td>
                    	</tr>
                        <tr>
                    		<th style="text-align:center;width:63px;">rate8(£)</th>
                            <td style="text-align:center;width:50px;"><%=rate8[26].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate8[27].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate8[28].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate8[29].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate8[30].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate8[31].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate8[32].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate8[33].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate8[34].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate8[35].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate8[36].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate8[37].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate8[38].ToString() %></td>
                    	</tr>
                        <tr>
                    		<th style="text-align:center;width:63px;">rate9(£)</th>
                            <td style="text-align:center;width:50px;"><%=rate9[26].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate9[27].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate9[28].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate9[29].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate9[30].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate9[31].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate9[32].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate9[33].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate9[34].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate9[35].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate9[36].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate9[37].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate9[38].ToString() %></td>
                    	</tr>
                        <tr>
                    		<th style="text-align:center;width:63px;">rate10(£)</th>
                            <td style="text-align:center;width:50px;"><%=rate10[26].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate10[27].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate10[28].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate10[29].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate10[30].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate10[31].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate10[32].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate10[33].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate10[34].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate10[35].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate10[36].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate10[37].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate10[38].ToString() %></td>
                    	</tr>
                        <tr>
                    		<th style="text-align:center;width:63px;">rate11(£)</th>
                            <td style="text-align:center;width:50px;"><%=rate11[26].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate11[27].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate11[28].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate11[29].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate11[30].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate11[31].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate11[32].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate11[33].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate11[34].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate11[35].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate11[36].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate11[37].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate11[38].ToString() %></td>
                    	</tr>
                        <tr>
                    		<th style="text-align:center;width:63px;">rate12(£)</th>
                            <td style="text-align:center;width:50px;"><%=rate12[26].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate12[27].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate12[28].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate12[29].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate12[30].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate12[31].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate12[32].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate12[33].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate12[34].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate12[35].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate12[36].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate12[37].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate12[38].ToString() %></td>
                    	</tr>
                        <tr>
                    		<th style="text-align:center;width:63px;">rate13(£)</th>
                            <td style="text-align:center;width:50px;"><%=rate13[26].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate13[27].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate13[28].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate13[29].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate13[30].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate13[31].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate13[32].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate13[33].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate13[34].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate13[35].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate13[36].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate13[37].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate13[38].ToString() %></td>
                    	</tr>
                        <tr>
                    		<th style="text-align:center;width:63px;">rate14(£)</th>
                            <td style="text-align:center;width:50px;"><%=rate14[26].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate14[27].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate14[28].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate14[29].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate14[30].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate14[31].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate14[32].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate14[33].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate14[34].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate14[35].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate14[36].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate14[37].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate14[38].ToString() %></td>
                    	</tr>
                        <tr>
                    		<th style="text-align:center;width:63px;">rate15(£)</th>
                            <td style="text-align:center;width:50px;"><%=rate15[26].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate15[27].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate15[28].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate15[29].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate15[30].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate15[31].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate15[32].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate15[33].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate15[34].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate15[35].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate15[36].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate15[37].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate15[38].ToString() %></td>
                    	</tr>

                        <tr style="height:10px;"><td colspan="14" style="height:10px;background:#DADADA"></td></tr>

                        <tr>
                    		<th style="text-align:center;width:63px;">重量(kg)</th>
                            
                            <td style="text-align:center;width:50px;">20.0</td>
                            <td style="text-align:center;width:50px;">20.5</td>
                            <td style="text-align:center;width:50px;">21.0</td>
                            <td style="text-align:center;width:50px;">21.5</td>
                            <td style="text-align:center;width:50px;">22.0</td>
                            <td style="text-align:center;width:50px;">22.5</td>
                            <td style="text-align:center;width:50px;">23.0</td>
                            <td style="text-align:center;width:50px;">23.5</td>
                            <td style="text-align:center;width:50px;">24.0</td>
                            <td style="text-align:center;width:50px;">24.5</td>
                            <td style="text-align:center;width:50px;">25.0</td>
                            <td style="text-align:center;width:50px;">25.5</td>
                            <td style="text-align:center;width:50px;">26.0</td>
                    	</tr>
                        <tr>
                    		<th style="text-align:center;width:63px;">rate1(£)</th>
                            <td style="text-align:center;width:50px;"><%=rate1[39].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate1[40].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate1[41].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate1[42].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate1[43].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate1[44].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate1[45].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate1[46].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate1[47].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate1[48].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate1[49].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate1[50].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate1[51].ToString() %></td>
                    	</tr>
                        <tr>
                    		<th style="text-align:center;width:63px;">rate2(£)</th>
                            <td style="text-align:center;width:50px;"><%=rate2[39].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate2[40].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate2[41].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate2[42].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate2[43].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate2[44].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate2[45].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate2[46].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate2[47].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate2[48].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate2[49].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate2[50].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate2[51].ToString() %></td>
                    	</tr>
                        <tr>
                    		<th style="text-align:center;width:63px;">rate3(£)</th>
                            <td style="text-align:center;width:50px;"><%=rate3[39].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate3[40].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate3[41].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate3[42].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate3[43].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate3[44].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate3[45].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate3[46].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate3[47].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate3[48].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate3[49].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate3[50].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate3[51].ToString() %></td>
                    	</tr>
                        <tr>
                    		<th style="text-align:center;width:63px;">rate4(£)</th>
                            <td style="text-align:center;width:50px;"><%=rate4[39].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate4[40].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate4[41].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate4[42].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate4[43].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate4[44].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate4[45].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate4[46].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate4[47].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate4[48].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate4[49].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate4[50].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate4[51].ToString() %></td>
                    	</tr>
                        <tr>
                    		<th style="text-align:center;width:63px;">rate5(£)</th>
                            <td style="text-align:center;width:50px;"><%=rate5[39].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate5[40].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate5[41].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate5[42].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate5[43].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate5[44].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate5[45].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate5[46].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate5[47].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate5[48].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate5[49].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate5[50].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate5[51].ToString() %></td>
                    	</tr>
                        <tr>
                    		<th style="text-align:center;width:63px;">rate6(£)</th>
                            <td style="text-align:center;width:50px;"><%=rate6[39].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate6[40].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate6[41].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate6[42].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate6[43].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate6[44].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate6[45].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate6[46].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate6[47].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate6[48].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate6[49].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate6[50].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate6[51].ToString() %></td>
                    	</tr>
                        <tr>
                    		<th style="text-align:center;width:63px;">rate7(£)</th>
                            <td style="text-align:center;width:50px;"><%=rate7[39].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate7[40].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate7[41].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate7[42].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate7[43].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate7[44].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate7[45].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate7[46].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate7[47].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate7[48].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate7[49].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate7[50].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate7[51].ToString() %></td>
                    	</tr>
                        <tr>
                    		<th style="text-align:center;width:63px;">rate8(£)</th>
                            <td style="text-align:center;width:50px;"><%=rate8[39].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate8[40].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate8[41].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate8[42].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate8[43].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate8[44].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate8[45].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate8[46].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate8[47].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate8[48].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate8[49].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate8[50].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate8[51].ToString() %></td>
                    	</tr>
                        <tr>
                    		<th style="text-align:center;width:63px;">rate9(£)</th>
                            <td style="text-align:center;width:50px;"><%=rate9[39].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate9[40].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate9[41].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate9[42].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate9[43].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate9[44].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate9[45].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate9[46].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate9[47].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate9[48].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate9[49].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate9[50].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate9[51].ToString() %></td>
                    	</tr>
                        <tr>
                    		<th style="text-align:center;width:63px;">rate10(£)</th>
                            <td style="text-align:center;width:50px;"><%=rate10[39].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate10[40].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate10[41].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate10[42].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate10[43].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate10[44].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate10[45].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate10[46].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate10[47].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate10[48].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate10[49].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate10[50].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate10[51].ToString() %></td>
                    	</tr>
                        <tr>
                    		<th style="text-align:center;width:63px;">rate11(£)</th>
                            <td style="text-align:center;width:50px;"><%=rate11[39].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate11[40].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate11[41].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate11[42].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate11[43].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate11[44].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate11[45].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate11[46].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate11[47].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate11[48].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate11[49].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate11[50].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate11[51].ToString() %></td>
                    	</tr>
                        <tr>
                    		<th style="text-align:center;width:63px;">rate12(£)</th>
                            <td style="text-align:center;width:50px;"><%=rate12[39].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate12[40].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate12[41].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate12[42].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate12[43].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate12[44].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate12[45].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate12[46].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate12[47].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate12[48].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate12[49].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate12[50].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate12[51].ToString() %></td>
                    	</tr>
                        <tr>
                    		<th style="text-align:center;width:63px;">rate13(£)</th>
                            <td style="text-align:center;width:50px;"><%=rate13[39].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate13[40].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate13[41].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate13[42].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate13[43].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate13[44].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate13[45].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate13[46].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate13[47].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate13[48].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate13[49].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate13[50].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate13[51].ToString() %></td>
                    	</tr>
                        <tr>
                    		<th style="text-align:center;width:63px;">rate14(£)</th>
                            <td style="text-align:center;width:50px;"><%=rate14[39].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate14[40].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate14[41].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate14[42].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate14[43].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate14[44].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate14[45].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate14[46].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate14[47].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate14[48].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate14[49].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate14[50].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate14[51].ToString() %></td>
                    	</tr>
                        <tr>
                    		<th style="text-align:center;width:63px;">rate15(£)</th>
                            <td style="text-align:center;width:50px;"><%=rate15[39].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate15[40].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate15[41].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate15[42].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate15[43].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate15[44].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate15[45].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate15[46].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate15[47].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate15[48].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate15[49].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate15[50].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate15[51].ToString() %></td>
                    	</tr>
                        <tr style="height:10px;"><td colspan="14" style="height:10px;background:#DADADA"></td></tr>


                        <tr>
                    		<th style="text-align:center;width:63px;">重量(kg)</th>
                            
                            <td style="text-align:center;width:50px;">26.5</td>
                            <td style="text-align:center;width:50px;">27.0</td>
                            <td style="text-align:center;width:50px;">27.5</td>
                            <td style="text-align:center;width:50px;">28.0</td>
                            <td style="text-align:center;width:50px;">28.5</td>
                            <td style="text-align:center;width:50px;">29.0</td>
                            <td style="text-align:center;width:50px;">29.5</td>
                            <td style="text-align:center;width:50px;">30.0</td>
                            <td style="text-align:center;width:50px;">&nbsp;</td>
                            <td style="text-align:center;width:50px;">&nbsp;</td>
                            <td style="text-align:center;width:50px;">&nbsp;</td>
                            <td style="text-align:center;width:50px;">&nbsp;</td>
                            <td style="text-align:center;width:50px;">&nbsp;</td>
                    	</tr>
                        <tr>
                    		<th style="text-align:center;width:63px;">rate1(£)</th>
                            <td style="text-align:center;width:50px;"><%=rate1[52].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate1[53].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate1[54].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate1[55].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate1[56].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate1[57].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate1[58].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate1[59].ToString() %></td>
                            <td style="text-align:center;width:50px;">&nbsp;</td>
                            <td style="text-align:center;width:50px;">&nbsp;</td>
                            <td style="text-align:center;width:50px;">&nbsp;</td>
                            <td style="text-align:center;width:50px;">&nbsp;</td>
                            <td style="text-align:center;width:50px;">&nbsp;</td>
                    	</tr>
                        <tr>
                    		<th style="text-align:center;width:63px;">rate2(£)</th>
                            <td style="text-align:center;width:50px;"><%=rate2[52].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate2[53].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate2[54].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate2[55].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate2[56].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate2[57].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate2[58].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate2[59].ToString() %></td>
                            <td style="text-align:center;width:50px;">&nbsp;</td>
                            <td style="text-align:center;width:50px;">&nbsp;</td>
                            <td style="text-align:center;width:50px;">&nbsp;</td>
                            <td style="text-align:center;width:50px;">&nbsp;</td>
                            <td style="text-align:center;width:50px;">&nbsp;</td>
                    	</tr>
                        <tr>
                    		<th style="text-align:center;width:63px;">rate3(£)</th>
                            <td style="text-align:center;width:50px;"><%=rate3[52].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate3[53].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate3[54].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate3[55].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate3[56].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate3[57].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate3[58].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate3[59].ToString() %></td>
                            <td style="text-align:center;width:50px;">&nbsp;</td>
                            <td style="text-align:center;width:50px;">&nbsp;</td>
                            <td style="text-align:center;width:50px;">&nbsp;</td>
                            <td style="text-align:center;width:50px;">&nbsp;</td>
                            <td style="text-align:center;width:50px;">&nbsp;</td>
                    	</tr>
                        <tr>
                    		<th style="text-align:center;width:63px;">rate4(£)</th>
                            <td style="text-align:center;width:50px;"><%=rate4[52].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate4[53].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate4[54].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate4[55].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate4[56].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate4[57].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate4[58].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate4[59].ToString() %></td>
                            <td style="text-align:center;width:50px;">&nbsp;</td>
                            <td style="text-align:center;width:50px;">&nbsp;</td>
                            <td style="text-align:center;width:50px;">&nbsp;</td>
                            <td style="text-align:center;width:50px;">&nbsp;</td>
                            <td style="text-align:center;width:50px;">&nbsp;</td>
                    	</tr>
                        <tr>
                    		<th style="text-align:center;width:63px;">rate5(£)</th>
                            <td style="text-align:center;width:50px;"><%=rate5[52].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate5[53].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate5[54].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate5[55].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate5[56].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate5[57].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate5[58].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate5[59].ToString() %></td>
                            <td style="text-align:center;width:50px;">&nbsp;</td>
                            <td style="text-align:center;width:50px;">&nbsp;</td>
                            <td style="text-align:center;width:50px;">&nbsp;</td>
                            <td style="text-align:center;width:50px;">&nbsp;</td>
                            <td style="text-align:center;width:50px;">&nbsp;</td>
                    	</tr>
                        <tr>
                    		<th style="text-align:center;width:63px;">rate6(£)</th>
                            <td style="text-align:center;width:50px;"><%=rate6[52].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate6[53].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate6[54].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate6[55].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate6[56].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate6[57].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate6[58].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate6[59].ToString() %></td>
                            <td style="text-align:center;width:50px;">&nbsp;</td>
                            <td style="text-align:center;width:50px;">&nbsp;</td>
                            <td style="text-align:center;width:50px;">&nbsp;</td>
                            <td style="text-align:center;width:50px;">&nbsp;</td>
                            <td style="text-align:center;width:50px;">&nbsp;</td>
                    	</tr>
                        <tr>
                    		<th style="text-align:center;width:63px;">rate7(£)</th>
                            <td style="text-align:center;width:50px;"><%=rate7[52].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate7[53].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate7[54].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate7[55].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate7[56].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate7[57].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate7[58].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate7[59].ToString() %></td>
                            <td style="text-align:center;width:50px;">&nbsp;</td>
                            <td style="text-align:center;width:50px;">&nbsp;</td>
                            <td style="text-align:center;width:50px;">&nbsp;</td>
                            <td style="text-align:center;width:50px;">&nbsp;</td>
                            <td style="text-align:center;width:50px;">&nbsp;</td>
                    	</tr>
                        <tr>
                    		<th style="text-align:center;width:63px;">rate8(£)</th>
                            <td style="text-align:center;width:50px;"><%=rate8[52].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate8[53].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate8[54].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate8[55].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate8[56].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate8[57].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate8[58].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate8[59].ToString() %></td>
                            <td style="text-align:center;width:50px;">&nbsp;</td>
                            <td style="text-align:center;width:50px;">&nbsp;</td>
                            <td style="text-align:center;width:50px;">&nbsp;</td>
                            <td style="text-align:center;width:50px;">&nbsp;</td>
                            <td style="text-align:center;width:50px;">&nbsp;</td>
                    	</tr>
                        <tr>
                    		<th style="width:63px;">rate9(£)</th>
                            <td style="width:50px;"><%=rate9[52].ToString() %></td>
                            <td style="width:50px;"><%=rate9[53].ToString() %></td>
                            <td style="width:50px;"><%=rate9[54].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate9[55].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate9[56].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate9[57].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate9[58].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate9[59].ToString() %></td>
                            <td style="text-align:center;width:50px;">&nbsp;</td>
                            <td style="text-align:center;width:50px;">&nbsp;</td>
                            <td style="text-align:center;width:50px;">&nbsp;</td>
                            <td style="text-align:center;width:50px;">&nbsp;</td>
                            <td style="text-align:center;width:50px;">&nbsp;</td>
                    	</tr>
                        <tr>
                    		<th style="text-align:center;width:63px;">rate10(£)</th>
                            <td style="text-align:center;width:50px;"><%=rate10[52].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate10[53].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate10[54].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate10[55].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate10[56].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate10[57].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate10[58].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate10[59].ToString() %></td>
                            <td style="text-align:center;width:50px;">&nbsp;</td>
                            <td style="text-align:center;width:50px;">&nbsp;</td>
                            <td style="text-align:center;width:50px;">&nbsp;</td>
                            <td style="text-align:center;width:50px;">&nbsp;</td>
                            <td style="text-align:center;width:50px;">&nbsp;</td>
                    	</tr>
                        <tr>
                    		<th style="text-align:center;width:63px;">rate11(£)</th>
                            <td style="text-align:center;width:50px;"><%=rate11[52].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate11[53].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate11[54].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate11[55].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate11[56].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate11[57].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate11[58].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate11[59].ToString() %></td>
                            <td style="text-align:center;width:50px;">&nbsp;</td>
                            <td style="text-align:center;width:50px;">&nbsp;</td>
                            <td style="text-align:center;width:50px;">&nbsp;</td>
                            <td style="text-align:center;width:50px;">&nbsp;</td>
                            <td style="text-align:center;width:50px;">&nbsp;</td>
                    	</tr>
                        <tr>
                    		<th style="text-align:center;width:63px;">rate12(£)</th>
                            <td style="text-align:center;width:50px;"><%=rate12[52].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate12[53].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate12[54].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate12[55].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate12[56].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate12[57].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate12[58].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate12[59].ToString() %></td>
                            <td style="text-align:center;width:50px;">&nbsp;</td>
                            <td style="text-align:center;width:50px;">&nbsp;</td>
                            <td style="text-align:center;width:50px;">&nbsp;</td>
                            <td style="text-align:center;width:50px;">&nbsp;</td>
                            <td style="text-align:center;width:50px;">&nbsp;</td>
                    	</tr>
                        <tr>
                    		<th style="text-align:center;width:63px;">rate13(£)</th>
                            <td style="text-align:center;width:50px;"><%=rate13[52].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate13[53].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate13[54].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate13[55].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate13[56].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate13[57].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate13[58].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate13[59].ToString() %></td>
                            <td style="text-align:center;width:50px;">&nbsp;</td>
                            <td style="text-align:center;width:50px;">&nbsp;</td>
                            <td style="text-align:center;width:50px;">&nbsp;</td>
                            <td style="text-align:center;width:50px;">&nbsp;</td>
                            <td style="text-align:center;width:50px;">&nbsp;</td>
                    	</tr>
                        <tr>
                    		<th style="text-align:center;width:63px;">rate14(£)</th>
                            <td style="text-align:center;width:50px;"><%=rate14[52].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate14[53].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate14[54].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate14[55].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate14[56].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate14[57].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate14[58].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate14[59].ToString() %></td>
                            <td style="text-align:center;width:50px;">&nbsp;</td>
                            <td style="text-align:center;width:50px;">&nbsp;</td>
                            <td style="text-align:center;width:50px;">&nbsp;</td>
                            <td style="text-align:center;width:50px;">&nbsp;</td>
                            <td style="text-align:center;width:50px;">&nbsp;</td>
                    	</tr>
                        <tr>
                    		<th style="text-align:center;width:63px;">rate15(£)</th>
                            <td style="text-align:center;width:50px;"><%=rate15[52].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate15[53].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate15[54].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate15[55].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate15[56].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate15[57].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate15[58].ToString() %></td>
                            <td style="text-align:center;width:50px;"><%=rate15[59].ToString() %></td>
                            <td style="text-align:center;width:50px;">&nbsp;</td>
                            <td style="text-align:center;width:50px;">&nbsp;</td>
                            <td style="text-align:center;width:50px;">&nbsp;</td>
                            <td style="text-align:center;width:50px;">&nbsp;</td>
                            <td style="text-align:center;width:50px;">&nbsp;</td>
                    	</tr>
                        <tr style="height:10px;"><td colspan="14" style="height:10px;background:#DADADA"></td></tr>
                    </table>
                
                </div>
            </div>

            <div class="panel-footer">
                *如果某一种rate的值都为0，则表示还未为该 rate 设置值
            </div>
        </div>
    </div>
    </form>
</body>
</html>

