<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="Admin_status.aspx.cs" Inherits="Admin_status" %>

<%@ Register Assembly="System.Web.DataVisualization"
Namespace="System.Web.UI.DataVisualization.Charting"
TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<center>

<h2>Cyber Attack Monitoring Dashboard</h2>

<br /><br />

<asp:Chart ID="ChartAttackTypes" runat="server" Width="600px" Height="300px"> <Series>
<asp:Series Name="AttackTypes" ChartType="Column"></asp:Series> </Series> <ChartAreas>
<asp:ChartArea Name="ChartArea1"></asp:ChartArea> </ChartAreas>
</asp:Chart>

<br /><br />

<asp:Chart ID="ChartTimeline" runat="server" Width="600px" Height="300px"> <Series>
<asp:Series Name="Timeline" ChartType="Line"></asp:Series> </Series> <ChartAreas>
<asp:ChartArea Name="ChartArea2"></asp:ChartArea> </ChartAreas>
</asp:Chart>

<br /><br />

<h3>Top Attacker IP Addresses</h3>

<asp:Chart ID="ChartTopIPs" runat="server" Width="600px" Height="300px"> <Series>
<asp:Series Name="IPAttacks" ChartType="Bar"></asp:Series> </Series> <ChartAreas>
<asp:ChartArea Name="ChartArea3"></asp:ChartArea> </ChartAreas>
</asp:Chart>

</center>

</asp:Content>
