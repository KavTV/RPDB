<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Master.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SKPpDB.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="TableContainer">
        <article class="TableOption">
            <form runat="server">
                <button id="PUpdate">
                    Opdater
                </button>
                <input id="searchbar" type="text" placeholder="Søg" />
                <asp:Button runat="server" Text="Tilføj Projekt" OnClick="CreateProject_Click"/>
                <asp:Button runat="server" ID="CreateStudentBTN" Text="Tilføj Elev" Visible="false" OnClick="CreateStudent_Click" />
            </form>
        </article>
        <table>
            <thead>
                <tr>
                    <th class="column1 columnStart">Projekt Navn</th>
                    <th class="column2">Projekt Beskrivelse</th>
                    <th class="column3">Dokumentation Link</th>
                    <th class="column4 columnEnd">Medarbejdere</th>
                </tr>
            </thead>
            <tbody class="ScrollLook" id="TableList">
            </tbody>
        </table>
    </section>
    <script type="module" src="../JavaScript/Main/ProjectsPage_Main.js"></script>
</asp:Content>
