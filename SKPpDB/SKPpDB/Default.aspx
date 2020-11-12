<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Master.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SKPpDB.DefaultV2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="TableContainer">
        <article class="TableOption">
            <button id="PUpdate">
                Opdater
            </button>
            <input id="searchbar" type="text" placeholder="Søg"/>
            <button onclick="window.location.href = 'CreateProject.aspx';">
                Tilføj Projekt
            </button>
        </article>
        <table>
            <thead>
                <tr>
                    <th class="column1">Projekt Navn</th>
                    <th class="column2">Projekt Beskrivelse</th>
                    <th class="column3">Dokumention Link</th>
                    <th class="column4">Medarbejdere</th>
                </tr>
            </thead>
            <tbody class="ScrollLook" id="TableList">
            </tbody>
        </table>
    </section>
    <script type="module" src="../JavaScript/Main/ProjectsPage_Main.js"></script>
</asp:Content>