<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/DefaultMaster.Master" AutoEventWireup="true" CodeBehind="DefaultV2.aspx.cs" Inherits="SKPpDB.DefaultV2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <article class="Option container-fluid">
        <input id="PUpdate" type="button" value="Opdater" class="col-2">
        <input id="searchbar" type="text" placeholder="Search Project" class="col-5">
        <input type="button" onclick="window.location.href = 'CreateProject.aspx';" value="Tilføj Projekt" class="col-2">
        <input type="button" value="Filter" class="col-2">
    </article>
    <!--DataBase Table-->
    <section class="Table container-fluid">
        <article class="TableHead row">
            <header class="col-md-2 rightBorderGreen">Projekt navn</header>
            <header class="col-md-6 rightBorderGreen">Projekt beskrivelse</header>
            <header class="col-md-2 rightBorderGreen">Udviklings dokument</header>
            <header class="col-md-2">Medarbejdere</header>
        </article>
        <section id="TableList" class="TableRowBox ScrollLook" onload="LoadTable()">
            <img src="Style/Image/loadingIcon.png" class="loading" alt="Loading ..." />
            <h6 style="text-align: center;">Loading ...</h6>
        </section>
    </section>
    <script type="module" src="../JavaScript/Main/ProjectsPage_Main.js"></script>
</asp:Content>