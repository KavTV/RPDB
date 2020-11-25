<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/DefaultMaster.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SKPpDB.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <form runat="server" name="loginform">
        <table>
            <tr>
                <td>Brugernavn</td>
                <td>
                    <asp:TextBox ID="UsernameBox" runat="server"/>
                </td>
            </tr>
            <tr>
                <td>Password</td>
                <td>
                    <asp:TextBox ID="PasswordBox" runat="server" TextMode="Password"/>
                    
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="SubmitBTN" runat="server" Text="Submit" OnClick="SubmitBTN_Click"/>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="ResetBTN" runat="server" Text="Reset password" OnClick="ResetBTN_Click"/>
                </td>
            </tr>
        </table>
        <asp:Label ID="Label1" runat="server"></asp:Label>
    </form>

</asp:Content>
