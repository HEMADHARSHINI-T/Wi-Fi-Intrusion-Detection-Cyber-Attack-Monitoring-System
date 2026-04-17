<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Captcha.aspx.cs" Inherits="Captcha" %>

<!DOCTYPE html>

<html>
<head id="Head1" runat="server">
    <title>Captcha Verification</title>
</head>

<body>

<form id="form1" runat="server">

<center>

<h2>Security Verification</h2>

<br />

<asp:Label ID="lblCaptcha" runat="server" Font-Size="Large"></asp:Label>

<br /><br />

<asp:TextBox ID="txtCaptcha" runat="server"></asp:TextBox>

<br /><br />

<asp:Button ID="btnVerify" runat="server" Text="Verify CAPTCHA" OnClick="btnVerify_Click" />

</center>

</form>

</body>
</html>