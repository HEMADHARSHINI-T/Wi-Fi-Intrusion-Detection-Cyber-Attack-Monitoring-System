<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AdminAttackLogs.aspx.cs" Inherits="AdminAttackLogs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Attack Monitoring Dashboard</title>
</head>
<body>
    <form id="form1" runat="server">
    
    <center>
        <h2>Decoy Attack Monitoring Dashboard</h2>
        <br />

        <asp:GridView ID="GridView1" runat="server"
            AutoGenerateColumns="true"
            Width="800px"
            BorderColor="Black"
            BorderWidth="1px"
            HeaderStyle-BackColor="#003366"
            HeaderStyle-ForeColor="White"
            RowStyle-BackColor="#F2F2F2">
        </asp:GridView>

    </center>

    </form>
</body>
</html>