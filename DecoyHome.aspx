<%@ Page Title="" Language="C#" MasterPageFile="~/Home.master" AutoEventWireup="true" CodeFile="DecoyHome.aspx.cs" Inherits="DecoyHome" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<center>

    <h2>User Dashboard</h2>

    <asp:Label ID="lblUser" runat="server" Font-Size="18px"></asp:Label>

    <br /><br />

    <asp:Button ID="btnViewProfile" runat="server" 
        Text="View Profile" OnClick="LogAction"
        style="padding:10px;width:200px;" />

    <br /><br />

    <asp:Button ID="btnDownload" runat="server" 
        Text="Download Data" OnClick="LogAction"
        style="padding:10px;width:200px;" />

    <br /><br />

    <asp:Button ID="btnSettings" runat="server" 
        Text="Account Settings" OnClick="LogAction"
        style="padding:10px;width:200px;" />

    <br /><br />

    <!-- OPTIONAL: EXTRA TRAP BUTTON -->
    <asp:Button ID="btnAdmin" runat="server"
        Text="Admin Panel Access"
        OnClick="LogAction"
        style="padding:10px;width:200px;background:red;color:white;" />

</center>

</asp:Content>