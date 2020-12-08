﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/DefaultMaster.Master" AutoEventWireup="true" CodeBehind="CreateProject.aspx.cs" Inherits="SKPpDB.CreateProject.Default" %>

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
            <h4>Projekt navn:
            </h4>
            <input id="ProjectName" onchange="FillmentRequire()" class="col-md" type="text" placeholder="Projekt Navn">
            <h4>Projekt Beskrivelse:
            </h4>
            <textarea class="ScrollLook" id="ProjectDesription" onchange="FillmentRequire()" class="col-md" rows="5" placeholder="Projekt Beskrivelse"></textarea>
            <%--<h4>Dokumentions Link:
            </h4>
            <input id="ProjectDocumentation" onchange="FillmentRequire()" class="col-md" type="text" placeholder="Link til teams mappe">--%>
            <h4>Status</h4>
            <select name="status" id="StatusId">
                <option value="1">Færdig</option>
                <option value="2">Aktiv</option>
                <option value="3">Mangler folk</option>
                <option value="4">Standby</option>
                <option value="5">Ikke startet</option>
            </select>
            <h4>Start Dato:</h4>
            <input type="date" id="StartDate" />
            <h4>Slut Dato:</h4>
            <input type="date" id="EndDate" />
            <h4>Projekt Leder</h4>
            <select name="projektleder" id="ProjectManager">
            </select>
            <h4>Elever:
            </h4>
            <article id="studentBox">
                <select name="elever" id="Students">
                </select>
                <input type="submit" value="" class="ButtonImage" style="background-image: url('Style/Image/plusIcon.png')" onclick="AddSelectedStudent(); FillmentRequire()">
                <select class="ScrollLook" name="SelectedStudents" size="5" id="SelectedStudents">
                </select>
                <input type="submit" value="" class="ButtonImage" style="background-image: url('Style/Image/deleteIcon.png')" onclick="RemoveSelectedStudent(); FillmentRequire()">
            </article>
            <input id="CreateButton" type="button" onclick="createProject()" value="Opret Projekt" disabled />
        </article>
    </section>
    <script src="../JavaScript/createProject.js"></script>
</asp:Content>