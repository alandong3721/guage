<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="add-rate-type-postnl.aspx.cs" Inherits="WM_Project.manage_system.super_admin_frame.add_rate_type_postnl" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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
        input{margin:0px;text-align:center}
        td,th{text-align:center;;height:30px}
    </style>
   
</head>
<body>
    <form id="form1" runat="server">
       <div style="width: 700px;">
        <div class="panel panel-primary">
            <div class="panel-heading">
                <h3 class="panel-title">
                    设置 PostNL 各类型的邮费</h3>
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
                            <asp:ListItem Value="rate16">rate16</asp:ListItem>
                            <asp:ListItem Value="rate17">rate17</asp:ListItem>
                            <asp:ListItem Value="rate18">rate18</asp:ListItem>
                            <asp:ListItem Value="rate19">rate19</asp:ListItem>
                            <asp:ListItem Value="rate20">rate20</asp:ListItem>
                            <asp:ListItem Value="rate21">rate21</asp:ListItem>
                            <asp:ListItem Value="rate22">rate22</asp:ListItem>

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
                            <th style="width: 75px; text-align: center">
                                重量(kg)
                            </th>
                            <td style="width: 75px; text-align: center; font-weight: 600">
                                1.0
                            </td>
                            <td style="width: 75px; text-align: center; font-weight: 600">
                                2.0
                            </td>
                            <td style="width: 75px; text-align: center; font-weight: 600">
                                3.0
                            </td>
                            <td style="width: 75px; text-align: center; font-weight: 600">
                                4.0
                            </td>
                            <td style="width: 75px; text-align: center; font-weight: 600">
                                5.0
                            </td>
                            <td style="width: 75px; text-align: center; font-weight: 600">
                                6.0
                            </td>
                            <td style="width: 75px; text-align: center; font-weight: 600">
                                6.5
                            </td>
                            <td style="width: 75px; text-align: center; font-weight: 600;">
                                <font color="#FF0000"><b>7.0</b></font>
                            </td>
                        </tr>
                        <tr>
                            <th style="width: 75px; text-align: center">
                                邮费(£)
                            </th>
                            <td style="width: 75px; text-align: center;padding:0px">
                                <input type="text" name="freight" class="form-control"  value="<%=current_rate[0].ToString() %>" />
                            </td>
                            <td style="width: 75px; text-align: center">
                                <input type="text" name="freight" class="form-control"  value="<%=current_rate[1].ToString() %>" />
                            </td>
                            <td style="width: 75px; text-align: center">
                                <input type="text" name="freight" class="form-control"  value="<%=current_rate[2].ToString() %>" />
                            </td>
                            <td style="width: 75px; text-align: center">
                                <input type="text" name="freight" class="form-control"  value="<%=current_rate[3].ToString() %>" />
                            </td>
                            <td style="width: 75px; text-align: center">
                                <input type="text" name="freight" class="form-control"  value="<%=current_rate[4].ToString() %>" />
                            </td>
                            <td style="width: 75px; text-align: center">
                                <input type="text" name="freight" class="form-control"  value="<%=current_rate[5].ToString() %>" />
                            </td>
                            <td style="width: 75px; text-align: center;">
                                <input type="text" name="freight" class="form-control"  value="<%=current_rate[6].ToString() %>" />
                            </td>
                            <td style="width: 75px; text-align: center">
                                <input type="text" name="freight" class="form-control" style="font-weight:600;color:#FF0000"  value="<%=current_rate[7].ToString() %>" />
                            </td>
                        </tr>
                        <tr>
                            <th style="width: 75px; text-align: center">
                                重量(kg)
                            </th>
                            <td style="width: 75px; text-align: center; font-weight: 600">
                                7.5
                            </td>
                            <td style="width: 75px; text-align: center; font-weight: 600">
                                8.0
                            </td>
                            <td style="width: 75px; text-align: center; font-weight: 600">
                                9.0
                            </td>
                            <td style="width: 75px; text-align: center; font-weight: 600">
                                10.0
                            </td>
                            <td style="width: 75px; text-align: center; font-weight: 600">
                                11.0
                            </td>
                            <td style="width: 75px; text-align: center; font-weight: 600">
                                12.0
                            </td>
                            <td style="width: 75px; text-align: center; font-weight: 600">
                                13.0
                            </td>
                            <td style="width: 75px; text-align: center; font-weight: 600">
                                14.0
                            </td>
                            
                        </tr>
                        <tr>
                            <th style="width: 75px; text-align: center">
                                邮费(£)
                            </th>
                            <td style="width: 75px; text-align: center">
                                <input type="text" name="freight" class="form-control"  value="<%=current_rate[8].ToString() %>" />
                            </td>
                            <td style="width: 75px; text-align: center">
                                <input type="text" name="freight" class="form-control"  value="<%=current_rate[9].ToString() %>" />
                            </td>
                            <td style="width: 75px; text-align: center">
                                <input type="text" name="freight" class="form-control"  value="<%=current_rate[10].ToString() %>" />
                            </td>
                            <td style="width: 75px; text-align: center">
                                <input type="text" name="freight" class="form-control" value="<%=current_rate[11].ToString() %>" />
                            </td>
                            <td style="width: 75px; text-align: center">
                                <input type="text" name="freight" class="form-control"  value="<%=current_rate[12].ToString() %>" />
                            </td>
                            <td style="width: 75px; text-align: center">
                                <input type="text" name="freight" class="form-control" value="<%=current_rate[13].ToString() %>" />
                            </td>
                            <td style="width: 75px; text-align: center">
                                <input type="text" name="freight" class="form-control"  value="<%=current_rate[14].ToString() %>" />
                            </td>
                            <td style="width: 75px; text-align: center">
                                <input type="text" name="freight" class="form-control"  value="<%=current_rate[15].ToString() %>" />
                            </td>
                        </tr>
                        <tr>
                            <th style="width: 75px; text-align: center">
                                重量(kg)
                            </th>
                             <td style="width: 75px; text-align: center; font-weight: 600">
                                15.0
                            </td>
                            <td style="width: 75px; text-align: center; font-weight: 600">
                                16.0
                            </td>
                            <td style="width: 75px; text-align: center; font-weight: 600">
                               17.0
                            </td>
                            <td style="width: 75px; text-align: center; font-weight: 600">
                                18.0
                            </td>
                            <td style="width: 75px; text-align: center; font-weight: 600">
                                19.0
                            </td>
                            <td style="width: 75px; text-align: center; font-weight: 600">
                                20.0
                            </td>
                            <td style="width: 75px; text-align: center; font-weight: 600">
                                21.0
                            </td>
                            <td style="width: 75px; text-align: center; font-weight: 600">
                                22.0
                            </td>
                            
                        </tr>
                        <tr>
                            <th style="width: 75px; text-align: center">
                                邮费(£)
                            </th>
                            <td style="width: 75px; text-align: center">
                                <input type="text" name="freight" class="form-control" value="<%=current_rate[16].ToString() %>" />
                            </td>
                            <td style="width: 75px; text-align: center">
                                <input type="text" name="freight" class="form-control" value="<%=current_rate[17].ToString() %>" />
                            </td>
                            <td style="width: 75px; text-align: center">
                                <input type="text" name="freight" class="form-control"  value="<%=current_rate[18].ToString() %>" />
                            </td>
                            <td style="width: 75px; text-align: center">
                                <input type="text" name="freight" class="form-control"  value="<%=current_rate[19].ToString() %>" />
                            </td>
                            <td style="width: 75px; text-align: center">
                                <input type="text" name="freight" class="form-control"  value="<%=current_rate[20].ToString() %>" />
                            </td>
                            <td style="width: 75px; text-align: center">
                                <input type="text" name="freight" class="form-control" value="<%=current_rate[21].ToString() %>" />
                            </td>
                            <td style="width: 75px; text-align: center">
                                <input type="text" name="freight" class="form-control" value="<%=current_rate[22].ToString() %>" />
                            </td>
                            <td style="width: 75px; text-align: center">
                                <input type="text" name="freight" class="form-control" value="<%=current_rate[23].ToString() %>" />
                            </td>
                        </tr>
                        <tr>
                            <th style="width: 75px; text-align: center">
                                重量(kg)
                            </th>
                             <td style="width: 75px; text-align: center; font-weight: 600">
                                23.0
                            </td>
                            <td style="width: 75px; text-align: center; font-weight: 600">
                                24.0
                            </td>
                            <td style="width: 75px; text-align: center; font-weight: 600">
                                25.0
                            </td>
                            <td style="width: 75px; text-align: center; font-weight: 600">
                                26.0
                            </td>
                            <td style="width: 75px; text-align: center; font-weight: 600">
                                27.0
                            </td>
                            <td style="width: 75px; text-align: center; font-weight: 600">
                                28.0
                            </td>
                            <td style="width: 75px; text-align: center; font-weight: 600">
                                29.0
                            </td>
                            <td style="width: 75px; text-align: center; font-weight: 600">
                                30.0
                            </td>
                        </tr>
                        <tr>
                            <th style="width: 75px; text-align: center">
                                邮费(£)
                            </th>
                            <td style="width: 75px; text-align: center">
                                <input type="text" name="freight" class="form-control" value="<%=current_rate[24].ToString() %>" />
                            </td>
                            <td style="width: 75px; text-align: center">
                                <input type="text" name="freight" class="form-control" value="<%=current_rate[25].ToString() %>" />
                            </td>
                            <td style="width: 75px; text-align: center"> 
                                <input type="text" name="freight" class="form-control" value="<%=current_rate[26].ToString() %>" />
                            </td>
                            <td style="width: 75px; text-align: center">
                                <input type="text" name="freight" class="form-control"  value="<%=current_rate[27].ToString() %>" />
                            </td>
                            <td style="width: 75px; text-align: center">
                                <input type="text" name="freight" class="form-control" value="<%=current_rate[28].ToString() %>" />
                            </td>
                            <td style="width: 75px; text-align: center">
                                <input type="text" name="freight" class="form-control" value="<%=current_rate[29].ToString() %>" />
                            </td>
                            <td style="width: 75px; text-align: center">
                                <input type="text" name="freight" class="form-control" value="<%=current_rate[30].ToString() %>" />
                            </td>
                            <td style="width: 75px; text-align: center">
                                <input type="text" name="freight" class="form-control" value="<%=current_rate[31].ToString() %>" />
                            </td>
                        </tr>
                    </table>
                    
                </div>
                <div class="form-group" style="text-align: center">
                    <asp:Button ID="btn_postnl_rate" runat="Server" Text="设置 PostNL 邮费类型" CssClass="btn btn-info" OnClientClick="return isFreightRight()"
                        Width="240px" OnClick="btn_postnl_rate_Click" />
                </div>
            </div>
            <div class="panel-footer" style="color:#FF0000; font-weight:600">
                <p>*&nbsp;设置邮费时请注意，邮费必须从 rate22 到 rate1 递减，rate22 最高， rate1 最低， 否则将导致计算的邮费有误！！！</p>
            </div>
        </div>
        <div class="panel panel-primary">
            <div class="panel-heading">
                <h3 class="panel-title">
                    PostNL 各类型的邮费信息如下</h3>
            </div>
            <div class="panel-body">
                <div class="form-group">
 
                     <table border="1" cellspacing="0" cellpadding="0" width="100%">
                    	<tr>
                    		<th style="width:63px;">重量(kg)</th>
                            <td style="width:50px;">1.0</td>
                            <td style="width:50px;">2.0</td>  
                            <td style="width:50px;">3.0</td>
                            <td style="width:50px;">4.0</td>
                            <td style="width:50px;">5.0</td>
                            <td style="width:50px;">6.0</td>
                            <td style="width:50px;">6.5</td>
                            <td style="width:50px;"><font color="#FF0000"><b>7.0</b></font></td>
                            <td style="width:50px;">7.5</td>
                            <td style="width:50px;">8.0</td>
                            <td style="width:50px;">9.0</td>
                            <td style="width:50px;">10.0</td>
                            <td style="width:50px;">11.0</td>
                            
                    	</tr>
                        <tr>
                    		<th>rate1(£)</th>
                            <td ><%=rate1[0].ToString() %></td>
                            <td ><%=rate1[1].ToString() %></td>
                            <td ><%=rate1[2].ToString() %></td>
                            <td ><%=rate1[3].ToString() %></td>
                            <td ><%=rate1[4].ToString() %></td>
                            <td ><%=rate1[5].ToString() %></td>
                            <td ><%=rate1[6].ToString() %></td>
                            <td ><font color="#FF0000"><b><%=rate1[7].ToString() %></b></font></td>
                            <td ><%=rate1[8].ToString() %></td>
                            <td ><%=rate1[9].ToString() %></td>
                            <td ><%=rate1[10].ToString() %></td>
                            <td ><%=rate1[11].ToString() %></td>
                            <td ><%=rate1[12].ToString() %></td>
                    	</tr>
                        <tr>
                            <th>
                                rate2(£)
                            </th>
                            <td>
                                <%=rate2[0].ToString() %>
                            </td>
                            <td>
                                <%=rate2[1].ToString() %>
                            </td>
                            <td>
                                <%=rate2[2].ToString() %>
                            </td>
                            <td>
                                <%=rate2[3].ToString() %>
                            </td>
                            <td> <%=rate2[4].ToString() %> </td>
                            <td>
                                <%=rate2[5].ToString() %>
                            </td>
                            <td>
                                <%=rate2[6].ToString() %>
                            </td>
                            <td >
                                <font color="#FF0000"><b><%=rate2[7].ToString() %></b></font>
                            </td>
                            <td>
                                <%=rate2[8].ToString() %>
                            </td>
                            <td>
                                <%=rate2[9].ToString() %>
                            </td>
                            <td>
                                <%=rate2[10].ToString() %>
                            </td>
                            <td>
                                <%=rate2[11].ToString() %>
                            </td>
                            <td>
                                <%=rate2[12].ToString() %>
                            </td>
                    	</tr>
                        <tr>
                    		<th>rate3(£)</th>
                            <td ><%=rate3[0].ToString() %></td>
                            <td ><%=rate3[1].ToString() %></td>
                            <td ><%=rate3[2].ToString() %></td>
                            <td ><%=rate3[3].ToString() %></td>
                            <td ><%=rate3[4].ToString() %></td>
                            <td ><%=rate3[5].ToString() %></td>
                            <td ><%=rate3[6].ToString() %></td>
                            <td ><font color="#FF0000"><b><%=rate3[7].ToString() %></b></font></td>
                            <td ><%=rate3[8].ToString() %></td>
                            <td ><%=rate3[9].ToString() %></td>
                            <td ><%=rate3[10].ToString() %></td>
                            <td ><%=rate3[11].ToString() %></td>
                            <td ><%=rate3[12].ToString() %></td>
                    	</tr>
                        <tr>
                    		<th>rate4(£)</th>
                            <td ><%=rate4[0].ToString() %></td>
                            <td ><%=rate4[1].ToString() %></td>
                            <td ><%=rate4[2].ToString() %></td>
                            <td ><%=rate4[3].ToString() %></td>
                            <td ><%=rate4[4].ToString() %></td>
                            <td ><%=rate4[5].ToString() %></td>
                            <td ><%=rate4[6].ToString() %></td>
                            <td ><font color="#FF0000"><b><%=rate4[7].ToString() %></b></font></td>
                            <td ><%=rate4[8].ToString() %></td>
                            <td ><%=rate4[9].ToString() %></td>
                            <td ><%=rate4[10].ToString() %></td>
                            <td ><%=rate4[11].ToString() %></td>
                            <td ><%=rate4[12].ToString() %></td>
                    	</tr>
                        <tr>
                    		<th>rate5(£)</th>
                            <td ><%=rate5[0].ToString() %></td>
                            <td ><%=rate5[1].ToString() %></td>
                            <td ><%=rate5[2].ToString() %></td>
                            <td ><%=rate5[3].ToString() %></td>
                            <td ><%=rate5[4].ToString() %></td>
                            <td ><%=rate5[5].ToString() %></td>
                            <td ><%=rate5[6].ToString() %></td>
                            <td ><font color="#FF0000"><b><%=rate5[7].ToString() %></b></font></td>
                            <td ><%=rate5[8].ToString() %></td>
                            <td ><%=rate5[9].ToString() %></td>
                            <td ><%=rate5[10].ToString() %></td>
                            <td ><%=rate5[11].ToString() %></td>
                            <td ><%=rate5[12].ToString() %></td>
                    	</tr>
                        <tr>
                    		<th>rate6(£)</th>
                            <td ><%=rate6[0].ToString() %></td>
                            <td ><%=rate6[1].ToString() %></td>
                            <td ><%=rate6[2].ToString() %></td>
                            <td ><%=rate6[3].ToString() %></td>
                            <td ><%=rate6[4].ToString() %></td>
                            <td ><%=rate6[5].ToString() %></td>
                            <td ><%=rate6[6].ToString() %></td>
                            <td ><font color="#FF0000"><b><%=rate6[7].ToString() %></b></font></td>
                            <td ><%=rate6[8].ToString() %></td>
                            <td ><%=rate6[9].ToString() %></td>
                            <td ><%=rate6[10].ToString() %></td>
                            <td ><%=rate6[11].ToString() %></td>
                            <td ><%=rate6[12].ToString() %></td>
                    	</tr>
                        <tr>
                    		<th>rate7(£)</th>
                            <td ><%=rate7[0].ToString() %></td>
                            <td ><%=rate7[1].ToString() %></td>
                            <td ><%=rate7[2].ToString() %></td>
                            <td ><%=rate7[3].ToString() %></td>
                            <td ><%=rate7[4].ToString() %></td>
                            <td ><%=rate7[5].ToString() %></td>
                            <td ><%=rate7[6].ToString() %></td>
                            <td ><font color="#FF0000"><b><%=rate7[7].ToString() %></b></font></td>
                            <td ><%=rate7[8].ToString() %></td>
                            <td ><%=rate7[9].ToString() %></td>
                            <td ><%=rate7[10].ToString() %></td>
                            <td ><%=rate7[11].ToString() %></td>
                            <td ><%=rate7[12].ToString() %></td>
                    	</tr>
                        <tr>
                    		<th>rate8(£)</th>
                            <td ><%=rate8[0].ToString() %></td>
                            <td ><%=rate8[1].ToString() %></td>
                            <td ><%=rate8[2].ToString() %></td>
                            <td ><%=rate8[3].ToString() %></td>
                            <td ><%=rate8[4].ToString() %></td>
                            <td ><%=rate8[5].ToString() %></td>
                            <td ><%=rate8[6].ToString() %></td>
                            <td ><font color="#FF0000"><b><%=rate8[7].ToString() %></b></font></td>
                            <td ><%=rate8[8].ToString() %></td>
                            <td ><%=rate8[9].ToString() %></td>
                            <td ><%=rate8[10].ToString() %></td>
                            <td ><%=rate8[11].ToString() %></td>
                            <td ><%=rate8[12].ToString() %></td>
                    	</tr>
                        <tr>
                    		<th>rate9(£)</th>
                            <td ><%=rate9[0].ToString() %></td>
                            <td ><%=rate9[1].ToString() %></td>
                            <td ><%=rate9[2].ToString() %></td>
                            <td ><%=rate9[3].ToString() %></td>
                            <td ><%=rate9[4].ToString() %></td>
                            <td ><%=rate9[5].ToString() %></td>
                            <td ><%=rate9[6].ToString() %></td>
                            <td ><font color="#FF0000"><b><%=rate9[7].ToString() %></b></font></td>
                            <td ><%=rate9[8].ToString() %></td>
                            <td ><%=rate9[9].ToString() %></td>
                            <td ><%=rate9[10].ToString() %></td>
                            <td ><%=rate9[11].ToString() %></td>
                            <td ><%=rate9[12].ToString() %></td>
                    	</tr>
                        <tr>
                    		<th>rate10(£)</th>
                            <td ><%=rate10[0].ToString() %></td>
                            <td ><%=rate10[1].ToString() %></td>
                            <td ><%=rate10[2].ToString() %></td>
                            <td ><%=rate10[3].ToString() %></td>
                            <td ><%=rate10[4].ToString() %></td>
                            <td ><%=rate10[5].ToString() %></td>
                            <td ><%=rate10[6].ToString() %></td>
                            <td ><font color="#FF0000"><b><%=rate10[7].ToString() %></b></font></td>
                            <td ><%=rate10[8].ToString() %></td>
                            <td ><%=rate10[9].ToString() %></td>
                            <td ><%=rate10[10].ToString() %></td>
                            <td ><%=rate10[11].ToString() %></td>
                            <td ><%=rate10[12].ToString() %></td>
                    	</tr>
                        <tr>
                    		<th>rate11(£)</th>
                            <td ><%=rate11[0].ToString() %></td>
                            <td ><%=rate11[1].ToString() %></td>
                            <td ><%=rate11[2].ToString() %></td>
                            <td ><%=rate11[3].ToString() %></td>
                            <td ><%=rate11[4].ToString() %></td>
                            <td ><%=rate11[5].ToString() %></td>
                            <td ><%=rate11[6].ToString() %></td>
                            <td ><font color="#FF0000"><b><%=rate11[7].ToString() %></b></font></td>
                            <td ><%=rate11[8].ToString() %></td>
                            <td ><%=rate11[9].ToString() %></td>
                            <td ><%=rate11[10].ToString() %></td>
                            <td ><%=rate11[11].ToString() %></td>
                            <td ><%=rate11[12].ToString() %></td>
                    	</tr>
                        <tr>
                            <th>
                                rate12(£)
                            </th>
                            <td>
                                <%=rate12[0].ToString() %>
                            </td>
                            <td>
                                <%=rate12[1].ToString() %>
                            </td>
                            <td>
                                <%=rate12[2].ToString() %>
                            </td>
                            <td>
                                <%=rate12[3].ToString() %>
                            </td>
                            <td> <%=rate12[4].ToString() %> </td>
                            <td>
                                <%=rate12[5].ToString() %>
                            </td>
                            <td>
                                <%=rate12[6].ToString() %>
                            </td>
                            <td>
                                <font color="#FF0000"><b><%=rate12[7].ToString() %></b></font>
                            </td>
                            <td>
                                <%=rate12[8].ToString() %>
                            </td>
                            <td>
                                <%=rate12[9].ToString() %>
                            </td>
                            <td>
                                <%=rate12[10].ToString() %>
                            </td>
                            <td>
                                <%=rate12[11].ToString() %>
                            </td>
                            <td>
                                <%=rate12[12].ToString() %>
                            </td>
                    	</tr>
                        <tr>
                    		<th>rate13(£)</th>
                            <td ><%=rate13[0].ToString() %></td>
                            <td ><%=rate13[1].ToString() %></td>
                            <td ><%=rate13[2].ToString() %></td>
                            <td ><%=rate13[3].ToString() %></td>
                            <td ><%=rate13[4].ToString() %></td>
                            <td ><%=rate13[5].ToString() %></td>
                            <td ><%=rate13[6].ToString() %></td>
                            <td ><font color="#FF0000"><b><%=rate13[7].ToString() %></b></font></td>
                            <td ><%=rate13[8].ToString() %></td>
                            <td ><%=rate13[9].ToString() %></td>
                            <td ><%=rate13[10].ToString() %></td>
                            <td ><%=rate13[11].ToString() %></td>
                            <td ><%=rate13[12].ToString() %></td>
                    	</tr>
                        <tr>
                    		<th>rate14(£)</th>
                            <td ><%=rate14[0].ToString() %></td>
                            <td ><%=rate14[1].ToString() %></td>
                            <td ><%=rate14[2].ToString() %></td>
                            <td ><%=rate14[3].ToString() %></td>
                            <td ><%=rate14[4].ToString() %></td>
                            <td ><%=rate14[5].ToString() %></td>
                            <td ><%=rate14[6].ToString() %></td>
                            <td ><font color="#FF0000"><b><%=rate14[7].ToString() %></b></font></td>
                            <td ><%=rate14[8].ToString() %></td>
                            <td ><%=rate14[9].ToString() %></td>
                            <td ><%=rate14[10].ToString() %></td>
                            <td ><%=rate14[11].ToString() %></td>
                            <td ><%=rate14[12].ToString() %></td>
                    	</tr>
                        <tr>
                    		<th>rate15(£)</th>
                            <td ><%=rate15[0].ToString() %></td>
                            <td ><%=rate15[1].ToString() %></td>
                            <td ><%=rate15[2].ToString() %></td>
                            <td ><%=rate15[3].ToString() %></td>
                            <td ><%=rate15[4].ToString() %></td>
                            <td ><%=rate15[5].ToString() %></td>
                            <td ><%=rate15[6].ToString() %></td>
                            <td ><font color="#FF0000"><b><%=rate15[7].ToString() %></b></font></td>
                            <td ><%=rate15[8].ToString() %></td>
                            <td ><%=rate15[9].ToString() %></td>
                            <td ><%=rate15[10].ToString() %></td>
                            <td ><%=rate15[11].ToString() %></td>
                            <td ><%=rate15[12].ToString() %></td>
                    	</tr>
                        <tr>
                    		<th>rate16(£)</th>
                            <td ><%=rate16[0].ToString() %></td>
                            <td ><%=rate16[1].ToString() %></td>
                            <td ><%=rate16[2].ToString() %></td>
                            <td ><%=rate16[3].ToString() %></td>
                            <td ><%=rate16[4].ToString() %></td>
                            <td ><%=rate16[5].ToString() %></td>
                            <td ><%=rate16[6].ToString() %></td>
                            <td ><font color="#FF0000"><b><%=rate16[7].ToString() %></b></font></td>
                            <td ><%=rate16[8].ToString() %></td>
                            <td ><%=rate16[9].ToString() %></td>
                            <td ><%=rate16[10].ToString() %></td>
                            <td ><%=rate16[11].ToString() %></td>
                            <td ><%=rate16[12].ToString() %></td>
                    	</tr>
                        <tr>
                    		<th>rate17(£)</th>
                            <td ><%=rate17[0].ToString() %></td>
                            <td ><%=rate17[1].ToString() %></td>
                            <td ><%=rate17[2].ToString() %></td>
                            <td ><%=rate17[3].ToString() %></td>
                            <td ><%=rate17[4].ToString() %></td>
                            <td ><%=rate17[5].ToString() %></td>
                            <td ><%=rate17[6].ToString() %></td>
                            <td ><font color="#FF0000"><b><%=rate17[7].ToString() %></b></font></td>
                            <td ><%=rate17[8].ToString() %></td>
                            <td ><%=rate17[9].ToString() %></td>
                            <td ><%=rate17[10].ToString() %></td>
                            <td ><%=rate17[11].ToString() %></td>
                            <td ><%=rate17[12].ToString() %></td>
                    	</tr>
                        <tr>
                    		<th>rate18(£)</th>
                            <td ><%=rate18[0].ToString() %></td>
                            <td ><%=rate18[1].ToString() %></td>
                            <td ><%=rate18[2].ToString() %></td>
                            <td ><%=rate18[3].ToString() %></td>
                            <td ><%=rate18[4].ToString() %></td>
                            <td ><%=rate18[5].ToString() %></td>
                            <td ><%=rate18[6].ToString() %></td>
                            <td ><font color="#FF0000"><b><%=rate18[7].ToString() %></b></font></td>
                            <td ><%=rate18[8].ToString() %></td>
                            <td ><%=rate18[9].ToString() %></td>
                            <td ><%=rate18[10].ToString() %></td>
                            <td ><%=rate18[11].ToString() %></td>
                            <td ><%=rate18[12].ToString() %></td>
                    	</tr>
                        <tr>
                    		<th>rate19(£)</th>
                            <td ><%=rate19[0].ToString() %></td>
                            <td ><%=rate19[1].ToString() %></td>
                            <td ><%=rate19[2].ToString() %></td>
                            <td ><%=rate19[3].ToString() %></td>
                            <td ><%=rate19[4].ToString() %></td>
                            <td ><%=rate19[5].ToString() %></td>
                            <td ><%=rate19[6].ToString() %></td>
                            <td ><font color="#FF0000"><b><%=rate19[7].ToString() %></b></font></td>
                            <td ><%=rate19[8].ToString() %></td>
                            <td ><%=rate19[9].ToString() %></td>
                            <td ><%=rate19[10].ToString() %></td>
                            <td ><%=rate19[11].ToString() %></td>
                            <td ><%=rate19[12].ToString() %></td>
                    	</tr>
                        <tr>
                    		<th>rate20(£)</th>
                            <td ><%=rate20[0].ToString() %></td>
                            <td ><%=rate20[1].ToString() %></td>
                            <td ><%=rate20[2].ToString() %></td>
                            <td ><%=rate20[3].ToString() %></td>
                            <td ><%=rate20[4].ToString() %></td>
                            <td ><%=rate20[5].ToString() %></td>
                            <td ><%=rate20[6].ToString() %></td>
                            <td ><font color="#FF0000"><b><%=rate20[7].ToString() %></b></font></td>
                            <td ><%=rate20[8].ToString() %></td>
                            <td ><%=rate20[9].ToString() %></td>
                            <td ><%=rate20[10].ToString() %></td>
                            <td ><%=rate20[11].ToString() %></td>
                            <td ><%=rate20[12].ToString() %></td>
                    	</tr>
                        <tr>
                    		<th>rate21(£)</th>
                            <td ><%=rate21[0].ToString() %></td>
                            <td ><%=rate21[1].ToString() %></td>
                            <td ><%=rate21[2].ToString() %></td>
                            <td ><%=rate21[3].ToString() %></td>
                            <td ><%=rate21[4].ToString() %></td>
                            <td ><%=rate21[5].ToString() %></td>
                            <td ><%=rate21[6].ToString() %></td>
                            <td ><font color="#FF0000"><b><%=rate21[7].ToString() %></b></font></td>
                            <td ><%=rate21[8].ToString() %></td>
                            <td ><%=rate21[9].ToString() %></td>
                            <td ><%=rate21[10].ToString() %></td>
                            <td ><%=rate21[11].ToString() %></td>
                            <td ><%=rate21[12].ToString() %></td>
                    	</tr>
                        <tr>
                    		<th>rate22(£)</th>
                            <td ><%=rate22[0].ToString() %></td>
                            <td ><%=rate22[1].ToString() %></td>
                            <td ><%=rate22[2].ToString() %></td>
                            <td ><%=rate22[3].ToString() %></td>
                            <td ><%=rate22[4].ToString() %></td>
                            <td ><%=rate22[5].ToString() %></td>
                            <td ><%=rate22[6].ToString() %></td>
                            <td ><font color="#FF0000"><b><%=rate22[7].ToString() %></b></font></td>
                            <td ><%=rate22[8].ToString() %></td>
                            <td ><%=rate22[9].ToString() %></td>
                            <td ><%=rate22[10].ToString() %></td>
                            <td ><%=rate22[11].ToString() %></td>
                            <td ><%=rate22[12].ToString() %></td>
                    	</tr>
                        <tr style="height:10px;"><td colspan="14" style="height:10px;background:#DADADA"></td></tr>

                        <tr>
                    		<th >重量(kg)</th>
                           
                            <td >12.0</td>
                            <td >13.0</td>
                            <td >14.0</td>
                            <td >15.0</td>
                            <td >16.0</td>
                            <td >17.0</td>
                            <td >18.0</td>
                            <td >19.0</td>
                            <td >20.0</td>
                            <td >21.0</td>
                            <td >22.0</td>
                            <td >23.0</td>
                            <td >24.0</td>
                    	</tr>
                        <tr>
                    		<th >rate1(£)</th>
                            <td ><%=rate1[13].ToString() %></td>
                            <td ><%=rate1[14].ToString() %></td>
                            <td ><%=rate1[15].ToString() %></td>
                            <td ><%=rate1[16].ToString() %></td>
                            <td ><%=rate1[17].ToString() %></td>
                            <td ><%=rate1[18].ToString() %></td>
                            <td ><%=rate1[19].ToString() %></td>
                            <td ><%=rate1[20].ToString() %></td>
                            <td ><%=rate1[21].ToString() %></td>
                            <td ><%=rate1[22].ToString() %></td>
                            <td ><%=rate1[23].ToString() %></td>
                            <td ><%=rate1[24].ToString() %></td>
                            <td ><%=rate1[25].ToString() %></td>
                    	</tr>
                        <tr>
                    		<th >rate2(£)</th>
                            <td ><%=rate2[13].ToString() %></td>
                            <td ><%=rate2[14].ToString() %></td>
                            <td ><%=rate2[15].ToString() %></td>
                            <td ><%=rate2[16].ToString() %></td>
                            <td ><%=rate2[17].ToString() %></td>
                            <td ><%=rate2[18].ToString() %></td>
                            <td ><%=rate2[19].ToString() %></td>
                            <td ><%=rate2[20].ToString() %></td>
                            <td ><%=rate2[21].ToString() %></td>
                            <td ><%=rate2[22].ToString() %></td>
                            <td ><%=rate2[23].ToString() %></td>
                            <td ><%=rate2[24].ToString() %></td>
                            <td ><%=rate2[25].ToString() %></td>
                    	</tr>
                        <tr>
                    		<th style="text-align:center;width:63px;">rate3(£)</th>
                            <td ><%=rate3[13].ToString() %></td>
                            <td ><%=rate3[14].ToString() %></td>
                            <td ><%=rate3[15].ToString() %></td>
                            <td ><%=rate3[16].ToString() %></td>
                            <td ><%=rate3[17].ToString() %></td>
                            <td ><%=rate3[18].ToString() %></td>
                            <td ><%=rate3[19].ToString() %></td>
                            <td ><%=rate3[20].ToString() %></td>
                            <td ><%=rate3[21].ToString() %></td>
                            <td ><%=rate3[22].ToString() %></td>
                            <td ><%=rate3[23].ToString() %></td>
                            <td ><%=rate3[24].ToString() %></td>
                            <td ><%=rate3[25].ToString() %></td>
                    	</tr>
                        <tr>
                    		<th style="text-align:center;width:63px;">rate4(£)</th>
                            <td ><%=rate4[13].ToString() %></td>
                            <td ><%=rate4[14].ToString() %></td>
                            <td ><%=rate4[15].ToString() %></td>
                            <td ><%=rate4[16].ToString() %></td>
                            <td ><%=rate4[17].ToString() %></td>
                            <td ><%=rate4[18].ToString() %></td>
                            <td ><%=rate4[19].ToString() %></td>
                            <td ><%=rate4[20].ToString() %></td>
                            <td ><%=rate4[21].ToString() %></td>
                            <td ><%=rate4[22].ToString() %></td>
                            <td ><%=rate4[23].ToString() %></td>
                            <td ><%=rate4[24].ToString() %></td>
                            <td ><%=rate4[25].ToString() %></td>
                    	</tr>
                        <tr>
                    		<th style="text-align:center;width:63px;">rate5(£)</th>
                            <td ><%=rate5[13].ToString() %></td>
                            <td ><%=rate5[14].ToString() %></td>
                            <td ><%=rate5[15].ToString() %></td>
                            <td ><%=rate5[16].ToString() %></td>
                            <td ><%=rate5[17].ToString() %></td>
                            <td ><%=rate5[18].ToString() %></td>
                            <td ><%=rate5[19].ToString() %></td>
                            <td ><%=rate5[20].ToString() %></td>
                            <td ><%=rate5[21].ToString() %></td>
                            <td ><%=rate5[22].ToString() %></td>
                            <td ><%=rate5[23].ToString() %></td>
                            <td ><%=rate5[24].ToString() %></td>
                            <td ><%=rate5[25].ToString() %></td>
                    	</tr>
                        <tr>
                    		<th style="text-align:center;width:63px;">rate6(£)</th>
                            <td ><%=rate6[13].ToString() %></td>
                            <td ><%=rate6[14].ToString() %></td>
                            <td ><%=rate6[15].ToString() %></td>
                            <td ><%=rate6[16].ToString() %></td>
                            <td ><%=rate6[17].ToString() %></td>
                            <td ><%=rate6[18].ToString() %></td>
                            <td ><%=rate6[19].ToString() %></td>
                            <td ><%=rate6[20].ToString() %></td>
                            <td ><%=rate6[21].ToString() %></td>
                            <td ><%=rate6[22].ToString() %></td>
                            <td ><%=rate6[23].ToString() %></td>
                            <td ><%=rate6[24].ToString() %></td>
                            <td ><%=rate6[25].ToString() %></td>
                    	</tr>
                        <tr>
                    		<th style="text-align:center;width:63px;">rate7(£)</th>
                            <td ><%=rate7[13].ToString() %></td>
                            <td ><%=rate7[14].ToString() %></td>
                            <td ><%=rate7[15].ToString() %></td>
                            <td ><%=rate7[16].ToString() %></td>
                            <td ><%=rate7[17].ToString() %></td>
                            <td ><%=rate7[18].ToString() %></td>
                            <td ><%=rate7[19].ToString() %></td>
                            <td ><%=rate7[20].ToString() %></td>
                            <td ><%=rate7[21].ToString() %></td>
                            <td ><%=rate7[22].ToString() %></td>
                            <td ><%=rate7[23].ToString() %></td>
                            <td ><%=rate7[24].ToString() %></td>
                            <td ><%=rate7[25].ToString() %></td>
                    	</tr>
                        <tr>
                    		<th style="text-align:center;width:63px;">rate8(£)</th>
                            <td ><%=rate8[13].ToString() %></td>
                            <td ><%=rate8[14].ToString() %></td>
                            <td ><%=rate8[15].ToString() %></td>
                            <td ><%=rate8[16].ToString() %></td>
                            <td ><%=rate8[17].ToString() %></td>
                            <td ><%=rate8[18].ToString() %></td>
                            <td ><%=rate8[19].ToString() %></td>
                            <td ><%=rate8[20].ToString() %></td>
                            <td ><%=rate8[21].ToString() %></td>
                            <td ><%=rate8[22].ToString() %></td>
                            <td ><%=rate8[23].ToString() %></td>
                            <td ><%=rate8[24].ToString() %></td>
                            <td ><%=rate8[25].ToString() %></td>
                    	</tr>
                        <tr>
                    		<th style="text-align:center;width:63px;">rate9(£)</th>
                            <td ><%=rate9[13].ToString() %></td>
                            <td ><%=rate9[14].ToString() %></td>
                            <td ><%=rate9[15].ToString() %></td>
                            <td ><%=rate9[16].ToString() %></td>
                            <td ><%=rate9[17].ToString() %></td>
                            <td ><%=rate9[18].ToString() %></td>
                            <td ><%=rate9[19].ToString() %></td>
                            <td ><%=rate9[20].ToString() %></td>
                            <td ><%=rate9[21].ToString() %></td>
                            <td ><%=rate9[22].ToString() %></td>
                            <td ><%=rate9[23].ToString() %></td>
                            <td ><%=rate9[24].ToString() %></td>
                            <td ><%=rate9[25].ToString() %></td>
                    	</tr>
                        <tr>
                    		<th style="text-align:center;width:63px;">rate10(£)</th>
                            <td ><%=rate10[13].ToString() %></td>
                            <td ><%=rate10[14].ToString() %></td>
                            <td ><%=rate10[15].ToString() %></td>
                            <td ><%=rate10[16].ToString() %></td>
                            <td ><%=rate10[17].ToString() %></td>
                            <td ><%=rate10[18].ToString() %></td>
                            <td ><%=rate10[19].ToString() %></td>
                            <td ><%=rate10[20].ToString() %></td>
                            <td ><%=rate10[21].ToString() %></td>
                            <td ><%=rate10[22].ToString() %></td>
                            <td ><%=rate10[23].ToString() %></td>
                            <td ><%=rate10[24].ToString() %></td>
                            <td ><%=rate10[25].ToString() %></td>
                    	</tr>
                        <tr>
                    		<th >rate11(£)</th>
                            <td ><%=rate11[13].ToString() %></td>
                            <td ><%=rate11[14].ToString() %></td>
                            <td ><%=rate11[15].ToString() %></td>
                            <td ><%=rate11[16].ToString() %></td>
                            <td ><%=rate11[17].ToString() %></td>
                            <td ><%=rate11[18].ToString() %></td>
                            <td ><%=rate11[19].ToString() %></td>
                            <td ><%=rate11[20].ToString() %></td>
                            <td ><%=rate11[21].ToString() %></td>
                            <td ><%=rate11[22].ToString() %></td>
                            <td ><%=rate11[23].ToString() %></td>
                            <td ><%=rate11[24].ToString() %></td>
                            <td ><%=rate11[25].ToString() %></td>
                    	</tr>
                        <tr>
                    		<th >rate12(£)</th>
                            <td ><%=rate12[13].ToString() %></td>
                            <td ><%=rate12[14].ToString() %></td>
                            <td ><%=rate12[15].ToString() %></td>
                            <td ><%=rate12[16].ToString() %></td>
                            <td ><%=rate12[17].ToString() %></td>
                            <td ><%=rate12[18].ToString() %></td>
                            <td ><%=rate12[19].ToString() %></td>
                            <td ><%=rate12[20].ToString() %></td>
                            <td ><%=rate12[21].ToString() %></td>
                            <td ><%=rate12[22].ToString() %></td>
                            <td ><%=rate12[23].ToString() %></td>
                            <td ><%=rate12[24].ToString() %></td>
                            <td ><%=rate12[25].ToString() %></td>
                    	</tr>
                        <tr>
                    		<th style="text-align:center;width:63px;">rate13(£)</th>
                            <td ><%=rate13[13].ToString() %></td>
                            <td ><%=rate13[14].ToString() %></td>
                            <td ><%=rate13[15].ToString() %></td>
                            <td ><%=rate13[16].ToString() %></td>
                            <td ><%=rate13[17].ToString() %></td>
                            <td ><%=rate13[18].ToString() %></td>
                            <td ><%=rate13[19].ToString() %></td>
                            <td ><%=rate13[20].ToString() %></td>
                            <td ><%=rate13[21].ToString() %></td>
                            <td ><%=rate13[22].ToString() %></td>
                            <td ><%=rate13[23].ToString() %></td>
                            <td ><%=rate13[24].ToString() %></td>
                            <td ><%=rate13[25].ToString() %></td>
                    	</tr>
                        <tr>
                    		<th >rate14(£)</th>
                            <td ><%=rate14[13].ToString() %></td>
                            <td ><%=rate14[14].ToString() %></td>
                            <td ><%=rate14[15].ToString() %></td>
                            <td ><%=rate14[16].ToString() %></td>
                            <td ><%=rate14[17].ToString() %></td>
                            <td ><%=rate14[18].ToString() %></td>
                            <td ><%=rate14[19].ToString() %></td>
                            <td ><%=rate14[20].ToString() %></td>
                            <td ><%=rate14[21].ToString() %></td>
                            <td ><%=rate14[22].ToString() %></td>
                            <td ><%=rate14[23].ToString() %></td>
                            <td ><%=rate14[24].ToString() %></td>
                            <td ><%=rate14[25].ToString() %></td>
                    	</tr>
                        <tr>
                    		<th >rate15(£)</th>
                            <td ><%=rate15[13].ToString() %></td>
                            <td ><%=rate15[14].ToString() %></td>
                            <td ><%=rate15[15].ToString() %></td>
                            <td ><%=rate15[16].ToString() %></td>
                            <td ><%=rate15[17].ToString() %></td>
                            <td ><%=rate15[18].ToString() %></td>
                            <td ><%=rate15[19].ToString() %></td>
                            <td ><%=rate15[20].ToString() %></td>
                            <td ><%=rate15[21].ToString() %></td>
                            <td ><%=rate15[22].ToString() %></td>
                            <td ><%=rate15[23].ToString() %></td>
                            <td ><%=rate15[24].ToString() %></td>
                            <td ><%=rate15[25].ToString() %></td>
                    	</tr>
                        <tr>
                    		<th >rate16(£)</th>
                            <td ><%=rate16[13].ToString() %></td>
                            <td ><%=rate16[14].ToString() %></td>
                            <td ><%=rate16[15].ToString() %></td>
                            <td ><%=rate16[16].ToString() %></td>
                            <td ><%=rate16[17].ToString() %></td>
                            <td ><%=rate16[18].ToString() %></td>
                            <td ><%=rate16[19].ToString() %></td>
                            <td ><%=rate16[20].ToString() %></td>
                            <td ><%=rate16[21].ToString() %></td>
                            <td ><%=rate16[22].ToString() %></td>
                            <td ><%=rate16[23].ToString() %></td>
                            <td ><%=rate16[24].ToString() %></td>
                            <td ><%=rate16[25].ToString() %></td>
                    	</tr>
                        <tr>
                    		<th style="text-align:center;width:63px;">rate17(£)</th>
                            <td ><%=rate17[13].ToString() %></td>
                            <td ><%=rate17[14].ToString() %></td>
                            <td ><%=rate17[15].ToString() %></td>
                            <td ><%=rate17[16].ToString() %></td>
                            <td ><%=rate17[17].ToString() %></td>
                            <td ><%=rate17[18].ToString() %></td>
                            <td ><%=rate17[19].ToString() %></td>
                            <td ><%=rate17[20].ToString() %></td>
                            <td ><%=rate17[21].ToString() %></td>
                            <td ><%=rate17[22].ToString() %></td>
                            <td ><%=rate17[23].ToString() %></td>
                            <td ><%=rate17[24].ToString() %></td>
                            <td ><%=rate17[25].ToString() %></td>
                    	</tr>
                        <tr>
                    		<th >rate18(£)</th>
                            <td ><%=rate18[13].ToString() %></td>
                            <td ><%=rate18[14].ToString() %></td>
                            <td ><%=rate18[15].ToString() %></td>
                            <td ><%=rate18[16].ToString() %></td>
                            <td ><%=rate18[17].ToString() %></td>
                            <td ><%=rate18[18].ToString() %></td>
                            <td ><%=rate18[19].ToString() %></td>
                            <td ><%=rate18[20].ToString() %></td>
                            <td ><%=rate18[21].ToString() %></td>
                            <td ><%=rate18[22].ToString() %></td>
                            <td ><%=rate18[23].ToString() %></td>
                            <td ><%=rate18[24].ToString() %></td>
                            <td ><%=rate18[25].ToString() %></td>
                    	</tr>
                        <tr>
                    		<th >rate19(£)</th>
                            <td ><%=rate19[13].ToString() %></td>
                            <td ><%=rate19[14].ToString() %></td>
                            <td ><%=rate19[15].ToString() %></td>
                            <td ><%=rate19[16].ToString() %></td>
                            <td ><%=rate19[17].ToString() %></td>
                            <td ><%=rate19[18].ToString() %></td>
                            <td ><%=rate19[19].ToString() %></td>
                            <td ><%=rate19[20].ToString() %></td>
                            <td ><%=rate19[21].ToString() %></td>
                            <td ><%=rate19[22].ToString() %></td>
                            <td ><%=rate19[23].ToString() %></td>
                            <td ><%=rate19[24].ToString() %></td>
                            <td ><%=rate19[25].ToString() %></td>
                    	</tr>
                        <tr>
                    		<th >rate20(£)</th>
                            <td ><%=rate20[13].ToString() %></td>
                            <td ><%=rate20[14].ToString() %></td>
                            <td ><%=rate20[15].ToString() %></td>
                            <td ><%=rate20[16].ToString() %></td>
                            <td ><%=rate20[17].ToString() %></td>
                            <td ><%=rate20[18].ToString() %></td>
                            <td ><%=rate20[19].ToString() %></td>
                            <td ><%=rate20[20].ToString() %></td>
                            <td ><%=rate20[21].ToString() %></td>
                            <td ><%=rate20[22].ToString() %></td>
                            <td ><%=rate20[23].ToString() %></td>
                            <td ><%=rate20[24].ToString() %></td>
                            <td ><%=rate20[25].ToString() %></td>
                    	</tr>
                        <tr>
                    		<th >rate21(£)</th>
                            <td ><%=rate21[13].ToString() %></td>
                            <td ><%=rate21[14].ToString() %></td>
                            <td ><%=rate21[15].ToString() %></td>
                            <td ><%=rate21[16].ToString() %></td>
                            <td ><%=rate21[17].ToString() %></td>
                            <td ><%=rate21[18].ToString() %></td>
                            <td ><%=rate21[19].ToString() %></td>
                            <td ><%=rate21[20].ToString() %></td>
                            <td ><%=rate21[21].ToString() %></td>
                            <td ><%=rate21[22].ToString() %></td>
                            <td ><%=rate21[23].ToString() %></td>
                            <td ><%=rate21[24].ToString() %></td>
                            <td ><%=rate21[25].ToString() %></td>
                    	</tr>
                        <tr>
                    		<th >rate22(£)</th>
                            <td ><%=rate22[13].ToString() %></td>
                            <td ><%=rate22[14].ToString() %></td>
                            <td ><%=rate22[15].ToString() %></td>
                            <td ><%=rate22[16].ToString() %></td>
                            <td ><%=rate22[17].ToString() %></td>
                            <td ><%=rate22[18].ToString() %></td>
                            <td ><%=rate22[19].ToString() %></td>
                            <td ><%=rate22[20].ToString() %></td>
                            <td ><%=rate22[21].ToString() %></td>
                            <td ><%=rate22[22].ToString() %></td>
                            <td ><%=rate22[23].ToString() %></td>
                            <td ><%=rate22[24].ToString() %></td>
                            <td ><%=rate22[25].ToString() %></td>
                    	</tr>
                        <tr style="height:10px;"><td colspan="14" style="height:10px;background:#DADADA"></td></tr>

                        <tr>
                    		<th>重量(kg)</th>
                            <td >25.0</td>
                            <td >26.0</td>
                            <td >27.0</td>
                            <td >28.0</td>
                            <td >29.0</td>
                            <td >30.0</td>
                            <td >&nbsp;</td>
                            <td >&nbsp;</td>
                            <td >&nbsp;</td>
                            <td >&nbsp;</td>
                            <td >&nbsp;</td>
                            <td >&nbsp;</td>
                            <td >&nbsp;</td>
                    	</tr>
                        <tr>
                    		<th >rate1(£)</th>
                            <td ><%=rate1[26].ToString() %></td>
                            <td ><%=rate1[27].ToString() %></td>
                            <td ><%=rate1[28].ToString() %></td>
                            <td ><%=rate1[29].ToString() %></td>
                            <td ><%=rate1[30].ToString() %></td>
                            <td ><%=rate1[31].ToString() %></td>
                            <td >&nbsp;</td>
                            <td >&nbsp;</td>
                            <td >&nbsp;</td>
                            <td >&nbsp;</td>
                            <td >&nbsp;</td>
                            <td >&nbsp;</td>
                            <td >&nbsp;</td> 
                    	</tr>
                        <tr>
                    		<th >rate2(£)</th>
                            <td ><%=rate2[26].ToString() %></td>
                            <td ><%=rate2[27].ToString() %></td>
                            <td ><%=rate2[28].ToString() %></td>
                            <td ><%=rate2[29].ToString() %></td>
                            <td ><%=rate2[30].ToString() %></td>
                            <td ><%=rate2[31].ToString() %></td>
                            <td >&nbsp;</td>
                            <td >&nbsp;</td>
                            <td >&nbsp;</td>
                            <td >&nbsp;</td>
                            <td >&nbsp;</td>
                            <td >&nbsp;</td>
                            <td >&nbsp;</td>
                            
                    	</tr>
                        <tr>
                    		<th >rate3(£)</th>
                            <td ><%=rate3[26].ToString() %></td>
                            <td ><%=rate3[27].ToString() %></td>
                            <td ><%=rate3[28].ToString() %></td>
                            <td ><%=rate3[29].ToString() %></td>
                            <td ><%=rate3[30].ToString() %></td>
                            <td ><%=rate3[31].ToString() %></td>
                           <td >&nbsp;</td>
                            <td >&nbsp;</td>
                            <td >&nbsp;</td>
                            <td >&nbsp;</td>
                            <td >&nbsp;</td>
                            <td >&nbsp;</td>
                            <td >&nbsp;</td>
                    	</tr>
                        <tr>
                    		<th >rate4(£)</th>
                            <td ><%=rate4[26].ToString() %></td>
                            <td ><%=rate4[27].ToString() %></td>
                            <td ><%=rate4[28].ToString() %></td>
                            <td ><%=rate4[29].ToString() %></td>
                            <td ><%=rate4[30].ToString() %></td>
                            <td ><%=rate4[31].ToString() %></td>
                            <td >&nbsp;</td>
                            <td >&nbsp;</td>
                            <td >&nbsp;</td>
                            <td >&nbsp;</td>
                            <td >&nbsp;</td>
                            <td >&nbsp;</td>
                            <td >&nbsp;</td>
                    	</tr>
                        <tr>
                    		<th >rate5(£)</th>
                            <td ><%=rate5[26].ToString() %></td>
                            <td ><%=rate5[27].ToString() %></td>
                            <td ><%=rate5[28].ToString() %></td>
                            <td ><%=rate5[29].ToString() %></td>
                            <td ><%=rate5[30].ToString() %></td>
                            <td ><%=rate5[31].ToString() %></td>
                           
                            <td >&nbsp;</td>
                            <td >&nbsp;</td>
                            <td >&nbsp;</td>
                            <td >&nbsp;</td>
                            <td >&nbsp;</td>
                            <td >&nbsp;</td>
                            <td >&nbsp;</td>
         
                    	</tr>
                        <tr>
                    		<th >rate6(£)</th>
                            <td ><%=rate6[26].ToString() %></td>
                            <td ><%=rate6[27].ToString() %></td>
                            <td ><%=rate6[28].ToString() %></td>
                            <td ><%=rate6[29].ToString() %></td>
                            <td ><%=rate6[30].ToString() %></td>
                            <td ><%=rate6[31].ToString() %></td>
                           
                            <td >&nbsp;</td>
                            <td >&nbsp;</td>
                            <td >&nbsp;</td>
                            <td >&nbsp;</td>
                            <td >&nbsp;</td>
                            <td >&nbsp;</td>
                            <td >&nbsp;</td>
                            
                    	</tr>
                        <tr>
                    		<th>rate7(£)</th>
                            <td ><%=rate7[26].ToString() %></td>
                            <td ><%=rate7[27].ToString() %></td>
                            <td ><%=rate7[28].ToString() %></td>
                            <td ><%=rate7[29].ToString() %></td>
                            <td ><%=rate7[30].ToString() %></td>
                            <td ><%=rate7[31].ToString() %></td>
                           
                            <td >&nbsp;</td>
                            <td >&nbsp;</td>
                            <td >&nbsp;</td>
                            <td >&nbsp;</td>
                            <td >&nbsp;</td>
                            <td >&nbsp;</td>
                            <td >&nbsp;</td>
                    	</tr>
                        <tr>
                    		<th>rate8(£)</th>
                            <td ><%=rate8[26].ToString() %></td>
                            <td ><%=rate8[27].ToString() %></td>
                            <td ><%=rate8[28].ToString() %></td>
                            <td ><%=rate8[29].ToString() %></td>
                            <td ><%=rate8[30].ToString() %></td>
                            <td ><%=rate8[31].ToString() %></td>
                           
                           <td >&nbsp;</td>
                            <td >&nbsp;</td>
                            <td >&nbsp;</td>
                            <td >&nbsp;</td>
                            <td >&nbsp;</td>
                            <td >&nbsp;</td>
                            <td >&nbsp;</td>
                    	</tr>
                        <tr>
                    		<th>rate9(£)</th>
                            <td ><%=rate9[26].ToString() %></td>
                            <td ><%=rate9[27].ToString() %></td>
                            <td ><%=rate9[28].ToString() %></td>
                            <td ><%=rate9[29].ToString() %></td>
                            <td ><%=rate9[30].ToString() %></td>
                            <td ><%=rate9[31].ToString() %></td>
                           
                            <td >&nbsp;</td>
                            <td >&nbsp;</td>
                            <td >&nbsp;</td>
                            <td >&nbsp;</td>
                            <td >&nbsp;</td>
                            <td >&nbsp;</td>
                            <td >&nbsp;</td>
                            
                    	</tr>
                        <tr>
                    		<th>rate10(£)</th>
                            <td ><%=rate10[26].ToString() %></td>
                            <td ><%=rate10[27].ToString() %></td>
                            <td ><%=rate10[28].ToString() %></td>
                            <td ><%=rate10[29].ToString() %></td>
                            <td ><%=rate10[30].ToString() %></td>
                            <td ><%=rate10[31].ToString() %></td>
                            
                            <td >&nbsp;</td>
                            <td >&nbsp;</td>
                            <td >&nbsp;</td>
                            <td >&nbsp;</td>
                            <td >&nbsp;</td>
                            <td >&nbsp;</td>
                            <td >&nbsp;</td>
                    	</tr>
                        
                        <tr>
                    		<th >rate11(£)</th>
                            <td ><%=rate11[26].ToString() %></td>
                            <td ><%=rate11[27].ToString() %></td>
                            <td ><%=rate11[28].ToString() %></td>
                            <td ><%=rate11[29].ToString() %></td>
                            <td ><%=rate11[30].ToString() %></td>
                            <td ><%=rate11[31].ToString() %></td>
                            <td >&nbsp;</td>
                            <td >&nbsp;</td>
                            <td >&nbsp;</td>
                            <td >&nbsp;</td>
                            <td >&nbsp;</td>
                            <td >&nbsp;</td>
                            <td >&nbsp;</td>
                         
                    	</tr>
                        <tr>
                    		<th >rate12(£)</th>
                            <td ><%=rate12[26].ToString() %></td>
                            <td ><%=rate12[27].ToString() %></td>
                            <td ><%=rate12[28].ToString() %></td>
                            <td ><%=rate12[29].ToString() %></td>
                            <td ><%=rate12[30].ToString() %></td>
                            <td ><%=rate12[31].ToString() %></td>
                            <td >&nbsp;</td>
                            <td >&nbsp;</td>
                            <td >&nbsp;</td>
                            <td >&nbsp;</td>
                            <td >&nbsp;</td>
                            <td >&nbsp;</td>
                            <td >&nbsp;</td>
                            
                    	</tr>
                        <tr>
                    		<th >rate13(£)</th>
                            <td ><%=rate13[26].ToString() %></td>
                            <td ><%=rate13[27].ToString() %></td>
                            <td ><%=rate13[28].ToString() %></td>
                            <td ><%=rate13[29].ToString() %></td>
                            <td ><%=rate13[30].ToString() %></td>
                            <td ><%=rate13[31].ToString() %></td>
                            <td >&nbsp;</td>
                            <td >&nbsp;</td>
                            <td >&nbsp;</td>
                            <td >&nbsp;</td>
                            <td >&nbsp;</td>
                            <td >&nbsp;</td>
                            <td >&nbsp;</td>
                    	</tr>
                        <tr>
                    		<th >rate14(£)</th>
                            <td ><%=rate14[26].ToString() %></td>
                            <td ><%=rate14[27].ToString() %></td>
                            <td ><%=rate14[28].ToString() %></td>
                            <td ><%=rate14[29].ToString() %></td>
                            <td ><%=rate14[30].ToString() %></td>
                            <td ><%=rate14[31].ToString() %></td>
                            <td >&nbsp;</td>
                            <td >&nbsp;</td>
                            <td >&nbsp;</td>
                            <td >&nbsp;</td>
                            <td >&nbsp;</td>
                            <td >&nbsp;</td>
                            <td >&nbsp;</td>
                    	</tr>
                        <tr>
                    		<th >rate15(£)</th>
                            <td ><%=rate15[26].ToString() %></td>
                            <td ><%=rate15[27].ToString() %></td>
                            <td ><%=rate15[28].ToString() %></td>
                            <td ><%=rate15[29].ToString() %></td>
                            <td ><%=rate15[30].ToString() %></td>
                            <td ><%=rate15[31].ToString() %></td>
                            <td >&nbsp;</td>
                            <td >&nbsp;</td>
                            <td >&nbsp;</td>
                            <td >&nbsp;</td>
                            <td >&nbsp;</td>
                            <td >&nbsp;</td>
                            <td >&nbsp;</td>
                            
                    	</tr>
                        <tr>
                    		<th >rate16(£)</th>
                            <td ><%=rate16[26].ToString() %></td>
                            <td ><%=rate16[27].ToString() %></td>
                            <td ><%=rate16[28].ToString() %></td>
                            <td ><%=rate16[29].ToString() %></td>
                            <td ><%=rate16[30].ToString() %></td>
                           <td ><%=rate16[31].ToString() %></td>
                            <td >&nbsp;</td>
                            <td >&nbsp;</td>
                            <td >&nbsp;</td>
                            <td >&nbsp;</td>
                            <td >&nbsp;</td>
                            <td >&nbsp;</td>
                            <td >&nbsp;</td>
                    	</tr>
                        <tr>
                    		<th>rate17(£)</th>
                            <td ><%=rate17[26].ToString() %></td>
                            <td ><%=rate17[27].ToString() %></td>
                            <td ><%=rate17[28].ToString() %></td>
                            <td ><%=rate17[29].ToString() %></td>
                            <td ><%=rate17[30].ToString() %></td>
                           <td ><%=rate17[31].ToString() %></td>
                            <td >&nbsp;</td>
                            <td >&nbsp;</td>
                            <td >&nbsp;</td>
                            <td >&nbsp;</td>
                            <td >&nbsp;</td>
                            <td >&nbsp;</td>
                            <td >&nbsp;</td>
                    	</tr>
                        <tr>
                    		<th>rate18(£)</th>
                            <td ><%=rate18[26].ToString() %></td>
                            <td ><%=rate18[27].ToString() %></td>
                            <td ><%=rate18[28].ToString() %></td>
                            <td ><%=rate18[29].ToString() %></td>
                            <td ><%=rate18[30].ToString() %></td>
                            <td ><%=rate18[31].ToString() %></td>
                            <td >&nbsp;</td>
                            <td >&nbsp;</td>
                            <td >&nbsp;</td>
                            <td >&nbsp;</td>
                            <td >&nbsp;</td>
                            <td >&nbsp;</td>
                            <td >&nbsp;</td>
                    	</tr>
                        <tr>
                    		<th>rate19(£)</th>
                            <td ><%=rate19[26].ToString() %></td>
                            <td ><%=rate19[27].ToString() %></td>
                            <td ><%=rate19[28].ToString() %></td>
                            <td ><%=rate19[29].ToString() %></td>
                            <td ><%=rate19[30].ToString() %></td>
                            <td ><%=rate19[31].ToString() %></td>
                            <td >&nbsp;</td>
                            <td >&nbsp;</td>
                            <td >&nbsp;</td>
                            <td >&nbsp;</td>
                            <td >&nbsp;</td>
                            <td >&nbsp;</td>
                            <td >&nbsp;</td>
                    	</tr>
                        <tr>
                    		<th>rate20(£)</th>
                            <td ><%=rate20[26].ToString() %></td>
                            <td ><%=rate20[27].ToString() %></td>
                            <td ><%=rate20[28].ToString() %></td>
                            <td ><%=rate20[29].ToString() %></td>
                            <td ><%=rate20[30].ToString() %></td>
                            <td ><%=rate20[31].ToString() %></td>
                            <td >&nbsp;</td>
                            <td >&nbsp;</td>
                            <td >&nbsp;</td>
                            <td >&nbsp;</td>
                            <td >&nbsp;</td>
                            <td >&nbsp;</td>
                            <td >&nbsp;</td>
                    	</tr>
                        <tr>
                    		<th>rate21(£)</th>
                            <td ><%=rate21[26].ToString() %></td>
                            <td ><%=rate21[27].ToString() %></td>
                            <td ><%=rate21[28].ToString() %></td>
                            <td ><%=rate21[29].ToString() %></td>
                            <td ><%=rate21[30].ToString() %></td>
                            <td ><%=rate21[31].ToString() %></td>
                            <td >&nbsp;</td>
                            <td >&nbsp;</td>
                            <td >&nbsp;</td>
                            <td >&nbsp;</td>
                            <td >&nbsp;</td>
                            <td >&nbsp;</td>
                            <td >&nbsp;</td>
                    	</tr>
                        <tr>
                    		<th>rate22(£)</th>
                            <td ><%=rate22[26].ToString() %></td>
                            <td ><%=rate22[27].ToString() %></td>
                            <td ><%=rate22[28].ToString() %></td>
                            <td ><%=rate22[29].ToString() %></td>
                            <td ><%=rate22[30].ToString() %></td>
                            <td ><%=rate22[31].ToString() %></td>
                            <td >&nbsp;</td>
                            <td >&nbsp;</td>
                            <td >&nbsp;</td>
                            <td >&nbsp;</td>
                            <td >&nbsp;</td>
                            <td >&nbsp;</td>
                            <td >&nbsp;</td>
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
