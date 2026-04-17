<%@ Page Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="AdminUnlock.aspx.cs" Inherits="AdminUnlock" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<h2 style="margin-bottom:20px;">Unlock Requests</h2>

<asp:GridView ID="GridViewUnlock" runat="server" AutoGenerateColumns="False"
    OnRowCommand="GridViewUnlock_RowCommand" Width="100%" BorderColor="#ccc" BorderWidth="1">

    <Columns>

        <asp:BoundField DataField="ip_address" HeaderText="IP Address" />
        <asp:BoundField DataField="browser" HeaderText="Browser" />
        <asp:BoundField DataField="os" HeaderText="OS" />
        <asp:BoundField DataField="request_time" HeaderText="Request Time" />
        <asp:BoundField DataField="status" HeaderText="Status" />

        <asp:TemplateField HeaderText="Action">
            <ItemTemplate>
                <asp:Button ID="btnUnlock" runat="server"
                    Text="Unlock"
                    CommandName="Unlock"
                    CommandArgument='<%# Eval("ip_address") %>'
                    style="background-color:green;color:white;padding:5px 10px;border:none;border-radius:4px;" />
            </ItemTemplate>
        </asp:TemplateField>

    </Columns>

</asp:GridView>

</asp:Content>