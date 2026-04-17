<%@ Page Language="C#" MasterPageFile="~/Home.master" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

<script>
    window.onload = function () {

        var langElement = document.getElementById("lblLanguage");
        var screenElement = document.getElementById("lblScreen");

        if (langElement)
            langElement.innerText = navigator.language;

        if (screenElement)
            screenElement.innerText = window.screen.width + " x " + window.screen.height;
    };
</script>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div style="height:50px;"></div>

</asp:Content>