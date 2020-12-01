<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ResetPage.aspx.cs" Inherits="SKPpDB.ResetPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Label runat="server" ID="ErrorLabel" Text=""/>
        <label>Brugernavn</label>
        <asp:TextBox runat="server" ID="UsernameBox" />
        <asp:Button runat="server" Text="Send Link" OnClick="Submit_Click" />
    </form>
</body>
</html>
