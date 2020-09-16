<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/DefaultMaster.Master" AutoEventWireup="true" CodeBehind="CreateProject.aspx.cs" Inherits="SKPpDB.CreateProject.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Style/Create.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
            <section class="CreateBox">
            <header>
                Tilføj Projekt
            </header>
            
            <article class="container-fluid">
                <p runat="server" id="text"></p>
                <h4>
                    Projekt navn:
                </h4>
                <input id="ProjectName" onchange="FillmentRequire()" class="col-md" type="text" placeholder="Projekt Navn">
                <h4>
                    Projekt Beskrivelse:
                </h4>
                <input id="ProjectDesription" onchange="FillmentRequire()" class="col-md" type="text" placeholder="Projekt Beskrivelse">
                <h4>
                    Dokumentions Link:
                </h4>
                <input id="ProjectDocumentation" class="col-md" type="text" placeholder="Dokumentions Link">
                <h4>
                    Elever:
                </h4>
                <article id="studentBox">
                    <select name="elever" id="Students">
                    </select>
                    <input type="submit" value="+" onclick="AddSelectedStudent(); FillmentRequire()">
                    <select class="ScrollLook" name="SelectedStudents" size="5" id="SelectedStudents">
                    </select>
                    <input type="submit" value="-" onclick="RemoveSelectedStudent(); FillmentRequire()">
                </article>
                <input id="CreateButton" type="button" onclick="createProject()" value="Opret Projekt" disabled/>
            </article>
        </section>
    <script src="../JavaScript/createProject.js"></script>
</asp:Content>
