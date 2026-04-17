<%@ Page Title="" Language="C#" MasterPageFile="~/Home.master" AutoEventWireup="true" CodeFile="Userlogin.aspx.cs" Inherits="Userlogin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

<style>

/* LOGIN UI IMPROVEMENT */

.login-container{
width:350px;
margin:80px auto;
padding:30px;
background:#111827;
border-radius:10px;
box-shadow:0 0 20px rgba(0,0,0,0.7);
text-align:center;
}

.login-container h2,
.login-container h3{
color:#00eaff;
margin-bottom:20px;
}

.login-group{
margin-bottom:15px;
text-align:left;
}

.login-group label{
display:block;
margin-bottom:5px;
font-size:14px;
color:#ccc;
}

.login-group input{
width:100%;
padding:10px;
border:none;
border-radius:6px;
background:#1f2937;
color:white;
}

.login-btn{
width:100%;
padding:12px;
background:#00eaff;
border:none;
border-radius:6px;
font-weight:bold;
cursor:pointer;
transition:0.3s;
}

.login-btn:hover{
background:#00c4d4;
}

</style>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<!-- ✅ ADD THIS WRAPPER (IMPORTANT FOR SCROLL) -->

<div id="login-section">

<!-- LOGIN PANEL -->

<asp:Panel ID="Panel1" runat="server">

<div class="login-container"  class="login-container">

<h2>User Login</h2>

<div class="login-group">
<label>UserName</label>
<asp:TextBox ID="TextBox1" runat="server" placeholder="Username"></asp:TextBox>
</div>

<div class="login-group">
<label>Password</label>
<asp:TextBox ID="TextBox2" runat="server" TextMode="Password" placeholder="Password"></asp:TextBox>
</div>

<!-- 🔥 HONEYPOT FIELD -->

<asp:TextBox ID="username_confirm" runat="server" Style="display:none;"></asp:TextBox>

<asp:Button ID="Button2" runat="server" Text="LOGIN" CssClass="login-btn" OnClick="Button1_Click1"/>

<br /><br />

<asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click1">
Sign Up Here
</asp:LinkButton>

</div>

</asp:Panel>

<!-- SECURITY QUESTION PANEL -->

<asp:Panel ID="Panel2" runat="server" Visible="False">

<div class="login-container">

<h3>Security Verification</h3>

<div class="login-group">
<label>Security Question</label>
<asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
</div>

<div class="login-group">
<label>Security Answer</label>
<asp:TextBox ID="TextBox4" runat="server" TextMode="Password"></asp:TextBox>
</div>

<asp:Button ID="Button3" runat="server" Text="Check" CssClass="login-btn" OnClick="Button3_Click"/>

</div>

</asp:Panel>

</div>

</asp:Content>
