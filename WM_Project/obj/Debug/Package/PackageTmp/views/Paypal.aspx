<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Paypal.aspx.cs" Inherits="Payment2.Paypal" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="../javascripts/jquery-1.6.1.min.js" type="text/javascript"></script>
</head>
<body>
    <form name="frmpaypal" action="https://www.paypal.com/cgi-bin/webscr" method="post"
    id="target">
    <input type="hidden" name="cmd" value="_cart" />
    <input type="hidden" name="upload" value="1" />
    <input type="hidden" name="rm" value="2" />
    <input type="hidden" name="return" value='<%=urlSuccess %>' />
    <input type="hidden" name="cancel_return" value='<%=urlFailed %>' />
    <input type="hidden" name="business" value="admin@wm-global-express.com" />
    <input type="hidden" name="address_override" value="0" />
    <input type="hidden" name="firstname" value="" />
    <input type="hidden" name="address1" value="" />
    <input type="hidden" name="address2" value="" />
    <input type="hidden" name="city" value="" />
    <input type="hidden" name="zip" value="" />
    <input type="hidden" name="country" value="GB" />
    <input type="hidden" name="no_shipping" value="1" />
    <input type="hidden" name="item_name_1" value="Shipping solution service: Payment" />
    <input type="hidden" name="quantity_1" value="1" />
    <input type="hidden" name="amount_1" value='<%=amount %>' />
    <input type="hidden" name="custom" value='<%=400000%>'>
    <input type="hidden" name="currency_code" value="GBP">
    </form>
    <script language="javascript" type="text/javascript">
        document.frmpaypal.submit();
    </script>
</body>
</html>
