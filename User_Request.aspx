<%@ Page Title="" Language="C#" MasterPageFile="~/Home.master" AutoEventWireup="true" CodeFile="User_Request.aspx.cs" Inherits="User_Request" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Panel ID="Panel2" runat="server" Height="157px" Width="573px">
            <br />
            <br />
            <asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Italic="False" 
                Font-Names="Maiandra GD" Font-Size="15pt" ForeColor="#0000CC" 
                Text="Enter Your Security Question"></asp:Label>
            &nbsp;&nbsp;&nbsp; &nbsp;
            <asp:TextBox ID="TextBox3" runat="server" Font-Bold="True" 
                Font-Names="Maiandra GD" ForeColor="#FF6600" placeholder="Username"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label6" runat="server" Font-Bold="True" Font-Names="Maiandra GD" 
                Font-Size="15pt" ForeColor="#0000CC" Text="Enter Your Security Answer"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
            <asp:TextBox ID="TextBox4" runat="server" Font-Bold="True" 
                Font-Names="Maiandra GD" ForeColor="#FF6600" placeholder="Password" 
                TextMode="Password"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="Button3" runat="server" onclick="Button3_Click" Text="Sent Request"  style=" margin-left:256px; height:31px; width: 126px"/>
            <br />
        </asp:Panel>
</asp:Content>

