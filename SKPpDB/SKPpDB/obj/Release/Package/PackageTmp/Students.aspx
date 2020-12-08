<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Master.Master" AutoEventWireup="true" CodeBehind="Students.aspx.cs" Inherits="SKPpDB.Students" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="TableContainer">
        <article class="TableOption">
            <button id="PUpdate">
                Opdater
            </button>
            <input id="searchbar" type="text" placeholder="Søg"/>
        </article>
        <table>
            <thead>
                <tr>
                    <th class="column1 columnStart">Navn</th>
                    <th class="column3">Uddannelse</th>
                    <th class="column2 columnEnd">Projekter</th>
                </tr>
            </thead>
            <tbody class="ScrollLook" id="TableList">
            </tbody>
        </table>
    </section>
    <script type="module" src="../JavaScript/Main/StudentsPage_Main.js"></script>
</asp:Content>