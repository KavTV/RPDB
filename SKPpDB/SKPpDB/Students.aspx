<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/DefaultMaster.Master" AutoEventWireup="true" CodeBehind="Students.aspx.cs" Inherits="SKPpDB.Students" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <article class="Option container-fluid">
        <input id="searchbar" type="text" placeholder="Search Project" onchange="SearchStudents()" class="col-5">
        <input type="button" value="Filter" class="col-2">
    </article>
    <section class="Table container-fluid">
        <article class="TableHead row">
            <header class="col-md-3 rightBorderGreen">Navn</header>
            <header class="col-md-6 rightBorderGreen">Projekter</header>
            <header class="col-md-3">Uddannelse</header>
        </article>
        <section id="TableList" class="TableRowBox ScrollLook">
        </section>
    </section>

    <script src="../JavaScript/StudentsPage.js"></script>
</asp:Content>