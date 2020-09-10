<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/DefaultMaster.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SKPpDB.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="Mainbox">
        <article class="Option container-fluid">
            <input type="button" value="Opdater" class="col-2">
            <input type="text" placeholder="Search Project" class="col-5">
            <input type="button" value="Tilføj Projekt" class="col-2">
            <input type="button" value="Filter" class="col-2">
        </article>
        <!--DataBase Table-->
        <section class="Table container-fluid">
            <article class="TableHead row">
                <header class="col-md-2 rightBorderGreen">Projekt navn</header>
                <header class="col-md-6 rightBorderGreen">Projekt beskrivelse</header>
                <header class="col-md-2 rightBorderGreen">Udviklings dokument</header>
                <header class="col-md-2">Medarbejder</header>
            </article>
            <asp:section x:Name="ProjectList" class="TableRowBox ScrollLook">
                <article class="TableBody row">
                    <header class="col-md-2">Lorem ipsum dolor sit amet.</header>
                    <header class="col-md-6 ScrollLook">Lorem ipsum dolor sit amet. Lorem ipsum dolor sit amet.Lorem ipsum dolor sit amet.Lorem ipsum dolor sit amet.Lorem ipsum dolor sit amet.Lorem ipsum dolor sit amet.Lorem ipsum dolor sit amet.Lorem ipsum dolor sit amet.</header>
                    <header class="col-md-2">Lorem ipsum dolor sit amet.</header>
                    <header class="col-md-2">Lorem ipsum dolor sit amet.</header>
                </article>
            </asp:section>
        </section>
    </section>
</asp:Content>
