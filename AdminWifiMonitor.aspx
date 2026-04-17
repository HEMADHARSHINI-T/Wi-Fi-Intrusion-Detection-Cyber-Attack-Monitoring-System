<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="AdminWifiMonitor.aspx.cs" Inherits="AdminWifiMonitor" %>

<%@ Register Assembly="System.Web.DataVisualization" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div style="width:900px;margin:auto;background:white;padding:20px;border-radius:8px;box-shadow:0px 0px 10px #ccc;">

<h2>Connected Devices</h2>

<asp:GridView ID="GridViewDevices" runat="server" AutoGenerateColumns="true" Width="100%" />

<br /><br />

<h2>Suspicious Devices</h2>

<asp:GridView ID="GridViewSuspicious" runat="server" AutoGenerateColumns="true" Width="100%" />

<br /><br />

<h2>Connection Logs</h2>

<asp:GridView ID="GridViewLogs" runat="server" AutoGenerateColumns="true" Width="100%" />

<br /><br />

<h2>URL Scan Logs</h2>

<asp:GridView ID="GridViewUrlScan" runat="server" AutoGenerateColumns="true" Width="100%" />

<br /><br />

<h2>Total Attacks Detected</h2>

<asp:Label ID="lblAttackCount" runat="server" Font-Size="Large" ForeColor="Red"></asp:Label>

<br /><br />

<h2>Attack Activity Graph</h2>

<asp:Chart ID="AttackChart" runat="server" Width="700px" Height="350px">

<Series>
<asp:Series Name="Attacks" ChartType="Column"></asp:Series>
</Series>

<ChartAreas>
<asp:ChartArea Name="ChartArea1"></asp:ChartArea>
</ChartAreas>

</asp:Chart>

</div>

</asp:Content>