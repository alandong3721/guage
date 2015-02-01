<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="select-charge-way.aspx.cs" Inherits="WM_Project.views.user_frame.select_charge_way1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../stylesheets/bootstrap.css" rel="stylesheet" type="text/css" />
    <link href="../../stylesheets/bootstrap-theme.css" rel="stylesheet" type="text/css" />
    <script src="../../javascripts/bootstrap.js" type="text/javascript"></script>
    <script src="../../javascripts/jquery-1.11.1.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="panel panel-primary" style="width:780px">
            <div class="panel-heading">
                <h3 class="panel-title">
                    请选择充值方式</h3>
            </div>
            <div class="panel-body">
                <div class="form-group">
                    <div style="width:780px;padding-left:200px">
                        <p style="line-height: 30px;">
                            <font color="red"><b>充值方式:&nbsp;&nbsp;&nbsp;</b></font></p>
                        <div style="padding-left: 20px; padding-top: 10px;" id="way_two" runat="Server">
                            <p class="glyphicon glyphicon-hand-right" style="font-weight: 600;line-height:25px">
                                &nbsp;信用卡Credit/Debit Card充值</p>
                            <p style="line-height: 25px; text-indent: 2em">
                                <input type="radio" name="pay_method" value="pay_card" checked="checked" />
                                信用卡Credit/DebitCard充值&nbsp;&nbsp;&nbsp;<font color="#FF0000"><b>£<%=money %></b></font></p>
                            <p style="line-height: 20px; text-indent: 2em">
                                请选择信用卡种类(注意部分卡需要收取卡费):</p>
                            <p style="text-indent: 2em">
                                <select name="card_type" id="card_type">
                                    <option value="VISA Credit">VISA Credit - Pay&nbsp;&nbsp; £
                                        <%=Math.Round(money*1.025,2) %>
                                    </option>
                                    <option value="Mastercard Credit">Mastercard Credit - Pay&nbsp;&nbsp; £
                                        <%=Math.Round(money*1.025,2) %>
                                    </option>
                                    <option value="VISA Debit">VISA Debit - Pay&nbsp;&nbsp;£
                                        <%=Math.Round(money+0.4,2) %>
                                    </option>
                                    <option value="UK Maestro">UK Maestro - Pay&nbsp;&nbsp;£
                                        <%=Math.Round(money+0.25,2) %>
                                    </option>
                                    <option value="Non EU Cards">Non EU Cards - Pay&nbsp;&nbsp;£
                                        <%=Math.Round(money*1.35,2) %>
                                    </option>
                                </select></p>
                        </div>
                        <div style="padding-left: 20px; padding-top: 20px;" id="way_three" runat="Server">
                            <p class="glyphicon glyphicon-hand-right" style="font-weight: 600;line-height:25px">
                                &nbsp;Paypal充值</p>
                            <p style="line-height: 20px; text-indent: 2em;padding-bottom:10px">
                                <input type="radio" name="pay_method" value="pay_paypal" />PayPal-充值&nbsp;&nbsp;£
                                <%=Math.Round(money*1.05,2) %></p>
                        </div>
                        
                    </div>
                </div>
                <div class="form-group" style="clear:both;height:2px;background:#DADADA;width:50%;margin:0 auto;margin-top:10px">
                   
                </div>
                <div class="form-group" style="height:16px"></div>
                <div style="text-align: center;" class="form-group">
                    <asp:Button ID="submit" name="submit" runat="server" Text="确认充值" OnClick="btn_Submit"
                        CssClass="btn btn-info" />
                </div>
            </div>
        </div>

    </form>
</body>
</html>
