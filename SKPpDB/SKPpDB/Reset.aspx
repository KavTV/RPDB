<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/DefaultMaster.Master" AutoEventWireup="true" CodeBehind="Reset.aspx.cs" Inherits="SKPpDB.Reset" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <form runat="server" name="ResetForm">
        <asp:TextBox ID="PasswordBox" runat="server" TextMode="Password" />
        <asp:Button ID="ResetBTN" runat="server" Text="Reset" OnClick="ResetBTN_Click"/>
        <asp:Label ID="ErrorLabel" runat="server" />
    </form>
</asp:Content>
