<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/DefaultMaster.Master" AutoEventWireup="true" CodeBehind="EditProject.aspx.cs" Inherits="SKPpDB.EditProject" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Style/Create.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="CreateBox">
        <header>
            Rediger Projekt
        </header>

        <article class="container-fluid">
            <h4>Projekt navn:
            </h4>
            <input runat="server" id="HeadlineText" class="col-md" type="text" placeholder="Projekt Navn">
            <h4>Projekt Beskrivelse:
            </h4>
            <input runat="server" id="DescriptionText" class="col-md" type="text" placeholder="Projekt Beskrivelse">
            <h4>Dokumentions Link:
            </h4>
            <input runat="server" id="DocumentationText" class="col-md" type="text" placeholder="Dokumentions Link">
            <h4>Elever:
            </h4>
            <article id="studentBox" >
                

                    <select name="elever" id="Students">
                    </select>
                    <input type="submit" value="+" onclick="AddSelectedStudent()">
                
                
                    <select class="ScrollLook" name="Selected Elever" size="5" id="SelectedStudents">
                    </select>

                    <input type="submit" value="-" onclick="RemoveSelectedStudent()">
                
            </article>
            <form runat="server">
                <asp:Button ID="EditButton" Text="Gem" runat="server" OnClick="EditButton_Click" />
            </form>
        </article>
    </section>
    <script src="../JavaScript/createProject.js"></script>
    <script src="JavaScript/EditPage.js"></script>
</asp:Content>
