<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Master.Master" AutoEventWireup="true" CodeBehind="Student.aspx.cs" Inherits="SKPpDB.Student" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section style="max-width: 700px;" id="Box" class="box">
        <header id="top-name" class="title"></header>
        <article class="Content">
            <article class="MiddleBox">
                <header class="textbox inline">
                    <h1 style="text-align: center;">Studentere</h1>
                    <span id="education" class="MiddleBox"></span>
                </header>
                <header class="textbox inline">
                    <h1 style="text-align: center;">Uni-Login</h1>
                    <span id="username" class="MiddleBox"></span>
                </header>
                <header class="textbox inline">
                    <h1 style="text-align: center;">Mail</h1>
                    <span id="mail" class="MiddleBox"></span>
                </header>
            </article>
            <header class="textbox MiddleBox">
                <h1 style="text-align: center;">Projekter</h1>
                <span id="projects" style="display: block; text-align: center;"></span>
            </header>
        </article>
    </section>
    <script type="module" src="../JavaScript/Main/StudentPage_Main.js"></script>
</asp:Content>