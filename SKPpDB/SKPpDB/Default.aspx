<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/DefaultMaster.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SKPpDB.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <article class="Option container-fluid">
            <input type="button" value="Opdater" onclick="RefeshProjects()" class="col-2">
            <input type="text" placeholder="Search Project" class="col-5">
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
                <img src="Style/Image/loadingIcon.png" class="loading" alt="Loading ..."/>
                <h6 style="text-align:center;">Loading ...</h6>
                <%--<article class="TableBody row">
                    <header class="col-md-2">Lorem ipsum dolor sit amet.</header>
                    <header class="col-md-6 ScrollLook">Lorem ipsum dolor sit amet. Lorem ipsum dolor sit amet.Lorem ipsum dolor sit amet.Lorem ipsum dolor sit amet.Lorem ipsum dolor sit amet.Lorem ipsum dolor sit amet.Lorem ipsum dolor sit amet.Lorem ipsum dolor sit amet.</header>
                    <header class="col-md-2">Lorem ipsum dolor sit amet.</header>
                    <header class="col-md-2">Lorem ipsum dolor sit amet.</header>
                </article>--%>
            </section>
        </section>
    <script src="../JavaScript/FrontPageJS.js"></script>
</asp:Content>
