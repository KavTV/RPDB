<%@ Page Title="Projekt" Language="C#" MasterPageFile="~/MasterPage/Master.Master" AutoEventWireup="true" CodeBehind="Project.aspx.cs" Inherits="SKPpDB.WatchProject" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <section id="Box" class="box">
        <header id="top-title" class="title"></header>
        <article class="MiddleBox">
            <form runat="server">
                <asp:Button runat="server" CssClass="col-4 ButtonLook" Text="Rediger" OnClick="Redirect_Click" />
                <asp:Button runat="server" ID="DeleteBTN" CssClass="col-4 ButtonLook" Text="Slet" OnClick="DeleteBTN_Click" />
            </form>
        </article>
        <article class="Content">
            <header>
                <h1>Projekt Navn</h1>
                <span id="title"></span>
            </header>
            <header>
                <h1>Projekt Leder</h1>
                <span id="Projectmanager"></span>
            </header>
            <header>
                <h1>Projekt Beskrivelse</h1>
                <span id="description"></span>
            </header>
            <header>
                <h1>Start Dato</h1>
                <span id="startdate"></span>
            </header>
            <header>
                <h1>Slut Dato</h1>
                <span id="enddate"></span>
            </header>
            <header>
                <h1>Medarbejder</h1>
                <span id="students"></span>
            </header>
        </article>
    </section>
    <script type="module" src="../JavaScript/Main/ProjectPage_Main.js"></script>
</asp:Content>