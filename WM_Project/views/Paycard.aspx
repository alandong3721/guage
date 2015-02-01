<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Paycard.aspx.cs" Inherits="Payment2.Paycard" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form name="frmpaycard" method="post" action="https://secure.totalwebsecure.com/paypage/clear.asp"
    id="target">
    <input type="hidden" name="customerid" value="57755278043">
    <input type="hidden" name="TransactionCurrency" value="826">
    <input type="hidden" name="CHCountry" value="GB">
    <input type="hidden" name="TransactionAmount" value="<%=amount %>">
    <input type="hidden" name="Notes" value="500000">
    <input type="hidden" name="CustomerEmail" value="<%=email %>">
    <input type="hidden" name="RedirectorSuccess" value="<%=urlSuccess %>">
    <input type="hidden" name="RedirectorFailed" value="<%=urlFailed %>">
    </form>
    <script>
        document.frmpaycard.submit();
    </script>
</body>
</html>
