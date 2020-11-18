<%@ Page Title="Projekt" Language="C#" MasterPageFile="~/MasterPage/Master.Master" AutoEventWireup="true" CodeBehind="Project.aspx.cs" Inherits="SKPpDB.WatchProject" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <section class="box">
        <header id="top-title" class="title"></header>
        <article class="MiddleBox">
            <form runat="server">
                <asp:Button runat="server" CssClass="col-4 ButtonLook" Text="Rediger" OnClick="Redirect_Click" />
                                
                <asp:Button runat="server" ID="DeleteBTN" CssClass="col-4 ButtonLook" Text="Slet" OnClick="DeleteBTN_Click" />
            </form>
        </article>
        <article class="Content">
            <h1>Projekt Navn</h1>
            <header id="title"></header>
            <h1>Projekt Leder</h1>
            <header id="Projectmanager"></header>
            <h1>Projekt Beskrivelse</h1>
            <header id="description"></header>
        </article>
    </section>
    <script type="module" src="../JavaScript/Main/ProjectPage_Main.js"></script>
</asp:Content>