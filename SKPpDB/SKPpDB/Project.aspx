<%@ Page Title="Projekt" Language="C#" MasterPageFile="~/MasterPage/DefaultMaster.Master" AutoEventWireup="true" CodeBehind="Project.aspx.cs" Inherits="SKPpDB.WatchProject" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <article class="Option container-fluid">
        <%--<input type="button" value="Slet" class="col-4">--%>
        <form runat="server">
            <asp:Button runat="server" CssClass="col-4 ButtonLook" Text="Rediger" OnClick="Redirect_Click" />
            <asp:Button runat="server" ID="DeleteBTN" CssClass="col-4 ButtonLook" Text="Slet" OnClick="DeleteBTN_Click" />
        </form>
    </article>
    <section class="Table container-fluid">
        <article class="TableHead row">
            <header class="col-md-2 rightBorderGreen">Projekt navn</header>
            <header class="col-md-6 rightBorderGreen">Projekt beskrivelse</header>
            <header class="col-md-2 rightBorderGreen">Udviklings dokument</header>
            <header class="col-md-2">Medarbejder</header>
        </article>
        <section id="TableList" class="TableRowBox ScrollLook">
        </section>
    </section>
    <script type="module" src="../JavaScript/Main/ProjectPage_Main.js"></script>
</asp:Content>