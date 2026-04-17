<%@ Page Language="C#" AutoEventWireup="true" CodeFile="VerifyOTP.aspx.cs" Inherits="VerifyOTP" %>

<!DOCTYPE html>
<html>
<head id="Head1" runat="server">
    <title>Verify OTP</title>
</head>
<body>

<form id="form1" runat="server">

    <div style="text-align:center; margin-top:50px;">

        <h2>Enter OTP</h2>

        <!-- ✅ ASP.NET TEXTBOX -->
        <asp:TextBox ID="txtOtp" runat="server" Width="200px"></asp:TextBox>

        <br /><br />

        <!-- ✅ ASP.NET BUTTON -->
        <asp:Button ID="btnVerify" runat="server"
            Text="Verify"
            OnClick="btnVerify_Click"
            style="padding:8px 20px;background:green;color:white;border:none;border-radius:5px;" />

        <br /><br />

        <!-- ✅ MESSAGE LABEL -->
        <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label>

    </div>

</form>

</body>
</html>