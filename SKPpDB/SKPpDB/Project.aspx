<%@ Page Title="Projekt" Language="C#" MasterPageFile="~/MasterPage/DefaultMaster.Master" AutoEventWireup="true" CodeBehind="Project.aspx.cs" Inherits="SKPpDB.WatchProject" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <article class="Option container-fluid">
        <input type="button" value="Rediger" class="col-4">
        <input type="button" value="Slet" class="col-4">
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

     <script src="../JavaScript/ProjectPage.js"></script>
</asp:Content>
