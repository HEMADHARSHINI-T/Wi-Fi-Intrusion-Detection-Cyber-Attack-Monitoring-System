<%@ Page Title="" Language="C#" MasterPageFile="~/Home.master" AutoEventWireup="true" CodeFile="register.aspx.cs" Inherits="register" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style3
        {
            width: 196px;
        }
        .style5
        {
            width: 188px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <center>
    
        <br />
        <table style="width:100%;">
            <tr>
                <td class="style5">
                    User Particulars</td>
        <td class="style3">
            <asp:Label ID="Label4" runat="server" Text="Login ID"></asp:Label>
            </td>
        <td style="margin-left: 40px">
            <asp:TextBox ID="loginid" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                ControlToValidate="loginid" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
            &nbsp;</td>
            </tr>
            <tr>
                <td class="style5">
                    &nbsp;</td>
        <td class="style3">
            <asp:Label ID="Label5" runat="server" Text="Password"></asp:Label>
            </td>
        <td style="margin-left: 40px">
            <asp:TextBox ID="password" runat="server" TextMode="Password"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                ControlToValidate="password" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
            </tr>
            <tr>
                <td class="style5">
                    &nbsp;</td>
        <td class="style3">
            <asp:Label ID="Label7" runat="server" Text="Conform Password"></asp:Label>
                </td>
        <td style="margin-left: 40px">
            <asp:TextBox ID="cpassword" runat="server" TextMode="Password"></asp:TextBox>
            <asp:CompareValidator ID="CompareValidator1" runat="server" 
                ControlToCompare="password" ControlToValidate="cpassword" ErrorMessage="Not Match" 
                ForeColor="Red"></asp:CompareValidator>
                </td>
            </tr>
            <tr>
                <td class="style5">
                    &nbsp;</td>
        <td class="style3">
            <asp:Label ID="Label1" runat="server" Text="Name"></asp:Label>
                </td>
        <td style="margin-left: 40px">
            <asp:TextBox ID="fname" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                ControlToValidate="fname" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style5">
                    &nbsp;</td>
        <td class="style3">
            <asp:Label ID="Label15" runat="server" Text="Gender"></asp:Label>
                </td>
        <td style="margin-left: 40px">
            <asp:DropDownList ID="gender" runat="server">
                <asp:ListItem>--Select--</asp:ListItem>
                <asp:ListItem>Male</asp:ListItem>
                <asp:ListItem>Female</asp:ListItem>
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                ControlToValidate="gender" ErrorMessage="*" ForeColor="Red" 
                InitialValue="--Select--"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style5">
                    &nbsp;</td>
        <td class="style3">
            <asp:Label ID="Label16" runat="server" Text="Date OF Birth"></asp:Label>
                </td>
        <td style="margin-left: 40px">
            <asp:TextBox ID="dob" runat="server"></asp:TextBox>
            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" 
                TargetControlID="dob">
            </cc1:CalendarExtender>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" 
                ControlToValidate="dob" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style5">
                    &nbsp;</td>
        <td class="style3">
            <asp:Label ID="Label9" runat="server" Text="Country"></asp:Label>
                </td>
        <td style="margin-left: 40px">
            <asp:DropDownList ID="country" runat="server">
                <asp:ListItem>--Select--</asp:ListItem>
                <asp:ListItem>India</asp:ListItem>
                <asp:ListItem>America</asp:ListItem>
                <asp:ListItem>China</asp:ListItem>
                <asp:ListItem>Japan</asp:ListItem>
                <asp:ListItem>London</asp:ListItem>
                <asp:ListItem>Erop</asp:ListItem>
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
                ControlToValidate="country" ErrorMessage="*" ForeColor="Red" 
                InitialValue="--Select--"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style5">
                    &nbsp;</td>
        <td class="style3">
            <asp:Label ID="Label17" runat="server" Text="Address"></asp:Label>
                </td>
        <td style="margin-left: 40px">
            <asp:TextBox ID="address" runat="server" TextMode="MultiLine"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" 
                ControlToValidate="address" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style5">
                    &nbsp;</td>
        <td class="style3">
            <asp:Label ID="Label3" runat="server" Text="Mail ID"></asp:Label>
                </td>
        <td style="margin-left: 40px">
            <asp:TextBox ID="mailid" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                ControlToValidate="mailid" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server"
		ControlToValidate="mailid" ErrorMessage="*" 
                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                ForeColor="Red"></asp:RegularExpressionValidator></td>
            </tr>
            <tr>
                <td class="style5">
                    &nbsp;</td>
        <td class="style3">
            <asp:Label ID="Label10" runat="server" Text="Mobile Number"></asp:Label>
                </td>
        <td style="margin-left: 40px">
            <asp:TextBox ID="mobile" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" 
                ControlToValidate="mobile" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" 
                runat="server" ControlToValidate="mobile" ErrorMessage="Mobile No Should be 10 Digit"
        ValidationExpression="((\d{5})+(\d{5}))$" ForeColor="Red"></asp:RegularExpressionValidator></td>
            </tr>
            <tr>
                <td class="style5">
                    &nbsp;</td>
        <td class="style3">
            <asp:Label ID="Label18" runat="server" Text="Security Question"></asp:Label>
                </td>
        <td style="margin-left: 40px">
            <asp:TextBox ID="s_q" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" 
                ControlToValidate="s_q" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style5">
                    &nbsp;</td>
        <td class="style3">
            <asp:Label ID="Label19" runat="server" Text="Security Answer "></asp:Label>
                </td>
        <td style="margin-left: 40px">
            <asp:TextBox ID="s_a" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" 
                ControlToValidate="s_a" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style5">
                    &nbsp;</td>
        <td class="style3">
            &nbsp;</td>
        <td style="margin-left: 40px">
            &nbsp;</td>
            </tr>
            </table>
        <br />
            <asp:Button ID="Button1" runat="server" 
                Text="Register" Width="282px" onclick="Button1_Click" Height="50px" />
            <br />
        <br />
        <asp:Label ID="Label6" runat="server"></asp:Label>
        <br />
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <br />
        <br />
    
    </center>
</asp:Content>

