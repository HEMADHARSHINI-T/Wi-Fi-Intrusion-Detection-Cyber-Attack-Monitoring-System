<%@ Page Title="" Language="C#" MasterPageFile="~/Home.master" AutoEventWireup="true" CodeFile="Adminlogin.aspx.cs" Inherits="Adminlogin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div id="login-section" class="login-container">

<h2>Admin Login</h2>

<div class="login-group">
<label>UserName</label>
<asp:TextBox ID="TextBox3" runat="server" placeholder="Username"></asp:TextBox>
</div>

<div class="login-group">
<label>Password</label>
<asp:TextBox ID="TextBox4" runat="server" TextMode="Password" placeholder="Password"></asp:TextBox>
</div>

<asp:Button ID="Button2" runat="server" Text="LOGIN" CssClass="login-btn" OnClick="Button1_Click1"/>

</div>

</asp:Content>
