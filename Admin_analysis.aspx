<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="Admin_analysis.aspx.cs" Inherits="Admin_analysis" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div><center>
    <br />
    <br />

        <asp:GridView ID="GridView1" runat="server" BackColor="White" 
            BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" CellPadding="4" 
            GridLines="Horizontal" Width="359px">
            <Columns>
                <asp:TemplateField>
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Image ID="Image1" runat="server" Height="63px" 
                    ImageUrl='<%# Bind("image") %>' Width="64px" />
                    </ItemTemplate>
                </asp:TemplateField>
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
        </asp:GridView>

    <br />
    <br />
    </center></div>
</asp:Content>

