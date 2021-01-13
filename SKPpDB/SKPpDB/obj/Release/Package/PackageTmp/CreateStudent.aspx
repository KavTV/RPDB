<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Master.Master" AutoEventWireup="true" CodeBehind="CreateStudent.aspx.cs" Inherits="SKPpDB.CreateStudent" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <form runat="server">
        <header>Brugernavn(unilogin)</header>
        <asp:TextBox runat="server" ID="usernameBox"></asp:TextBox>
        <header>Uddannelse</header>
        <asp:DropDownList runat="server" ID="educationList">
            <asp:ListItem Text="Supporter" Value="1"></asp:ListItem>
            <asp:ListItem Text="Infrastruktur" Value="2"></asp:ListItem>
            <asp:ListItem Text="Programmering" Value="3"></asp:ListItem>
        </asp:DropDownList>
        <header>Fulde navn</header>
        <asp:TextBox runat="server" ID="fullnameBox"></asp:TextBox>
        <asp:Button runat="server" OnClick="CreateStudent_Click" Text="Opret Elev"/>
        <asp:Label runat="server" ID="errorLabel"></asp:Label>
    </form>

</asp:Content>
