<%@ Page Title="" Language="C#" MasterPageFile="~/User.master" AutoEventWireup="true" CodeFile="user_disease.aspx.cs" Inherits="user_disease" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
    <center>
    <br />
    <br />

        <asp:GridView ID="GridView1" runat="server" BackColor="White" 
            BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3" 
            GridLines="Horizontal" Height="154px" Width="342px" AutoGenerateColumns="false">
            <AlternatingRowStyle BackColor="#F7F7F7" />
            <Columns>
            <asp:BoundField HeaderText="Filename" DataField="filename" />
            
                <asp:HyperLinkField DataNavigateUrlFields="filename,image" 
                    DataNavigateUrlFormatString="user_download2.aspx?name={0}&amp;img={1}" 
                    HeaderText="Select" Text="Choose" />
            </Columns>
            <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
            <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
            <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
            <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
            <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
            <SortedAscendingCellStyle BackColor="#F4F4FD" />
            <SortedAscendingHeaderStyle BackColor="#5A4C9D" />
            <SortedDescendingCellStyle BackColor="#D8D8F0" />
            <SortedDescendingHeaderStyle BackColor="#3E3277" />
        </asp:GridView>

    <br />
    <br />
    </center></div>
</asp:Content>

