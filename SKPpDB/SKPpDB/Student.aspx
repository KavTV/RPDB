<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Master.Master" AutoEventWireup="true" CodeBehind="Student.aspx.cs" Inherits="SKPpDB.Student" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section id="Box" class="box">
        <header id="top-name" class="title"></header>
        <article class="Content">
            <header>
                <h1>Navn</h1>
                <span id="name"></span>
            </header>
            <header>
                <h1>Studentere</h1>
                <span id="education"></span>
            </header>
            <header>
                <h1>Uni-Login</h1>
                <span id="username"></span>
            </header>
            <header>
                <h1>Projekter</h1>
                <span id="projects"></span>
            </header>
        </article>
    </section>
    <script type="module" src="../JavaScript/Main/StudentPage_Main.js"></script>
</asp:Content>