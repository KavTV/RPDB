<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/DefaultMaster.Master" AutoEventWireup="true" CodeBehind="Student.aspx.cs" Inherits="SKPpDB.Student" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="Table container-fluid">
        <article class="TableHead row">
            <header class="col-md-3 rightBorderGreen">Navn</header>
            <header class="col-md-6 rightBorderGreen">Projekter</header>
            <header class="col-md-3">Uddannelse</header>
        </article>
        <section id="TableList" class="TableRowBox ScrollLook">
            
        </section>
    </section>
    <script src="../JavaScript/StudentPage.js"></script>
</asp:Content>
