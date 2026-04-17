<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="Admin_request.aspx.cs" Inherits="Admin_request" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div><center>
    <br />
    <br />
    <br />
    <asp:GridView ID="GridView1" runat="server" BackColor="White" 
            BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" CellPadding="4" 
            GridLines="Horizontal" Width="359px">
            <Columns>
            <asp:HyperLinkField DataNavigateUrlFields="Id,loginid,Name,s_q,s_a" DataNavigateUrlFormatString="Admin_request2.aspx?Id={0}&loginid={1}&Name={2}&s_q={3}&s_a={4}" HeaderText="Select" Text="Accpect"/>
            </Columns>
            <FooterStyle BackColor="White" ForeColor="#333333" />
            <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="White" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F7F7F7" />
            <SortedAscendingHeaderStyle BackColor="#487575" />
            <SortedDescendingCellStyle BackColor="#E5E5E5" />
            <SortedDescendingHeaderStyle BackColor="#275353" />
        </asp:GridView><br />
    <br />
    <br />
    <br />
    <br />

</asp:Content>

