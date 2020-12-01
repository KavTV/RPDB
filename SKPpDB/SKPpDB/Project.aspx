<%@ Page Title="Projekt" Language="C#" MasterPageFile="~/MasterPage/Master.Master" AutoEventWireup="true" CodeBehind="Project.aspx.cs" Inherits="SKPpDB.WatchProject" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <section style="max-width: 1200px;" id="Box" class="box">
        <header id="top-title" class="title"></header>
        <article class="Content">
            <header class="inline textbox">
                <h1>Projekt Status</h1>
                <span id="status" class="MiddleBox"></span>
            </header>
            <header class="inline textbox">
                <h1>Projekt Leder</h1>
                <span id="Projectmanager" class="MiddleBox"></span>
            </header>
            <header class="inline right textbox">
                <h1>Slut Dato</h1>
                <span id="enddate" class="MiddleBox"></span>
            </header>
            <header class="inline right textbox">
                <h1>Start Dato</h1>
                <span id="startdate" class="MiddleBox"></span>
            </header>
            <header class="textbox">
                <h1>Projekt Beskrivelse</h1>
                <span id="description"></span>
            </header>
            <header class="textbox">
                <h1>Medarbejder</h1>
                <span id="students"></span>
            </header>
        </article>
        <article class="MiddleBox">
            <form runat="server">
                <asp:Button runat="server" CssClass="col-4 ButtonLook" Text="Rediger" OnClick="Redirect_Click" />  
                <asp:Button runat="server" ID="DeleteBTN" CssClass="col-4 ButtonLook" Text="Slet" Visible="false" OnClick="DeleteBTN_Click" />
            </form>
        </article>
    </section>
    <script type="module" src="../JavaScript/Main/ProjectPage_Main.js"></script>
</asp:Content>