<%@ Page Title="Projekt" Language="C#" MasterPageFile="~/MasterPage/Master.Master" AutoEventWireup="true" CodeBehind="Project.aspx.cs" Inherits="SKPpDB.WatchProject" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <form runat="server">
        <section style="max-width: 1200px;" id="Box" class="box">

            <header id="top-title" class="title"></header>
            <article class="Content">
                <header class="inline textbox">
                    <h1>Projekt Status</h1>
                    <span id="status" class="MiddleBox"></span>
                </header>
                <header class="inline textbox">
                    <h1>Projekt Leder</h1>
                    <span id="Projectmanager" class="MiddleBox"></span>
                </header>
                <header class="inline right textbox">
                    <h1>Slut Dato</h1>
                    <span id="enddate" class="MiddleBox"></span>
                </header>
                <header class="inline right textbox">
                    <h1>Start Dato</h1>
                    <span id="startdate" class="MiddleBox"></span>
                </header>
                <header class="textbox">
                    <h1>Projekt Beskrivelse</h1>
                    <span id="description"></span>
                </header>
                <header class="textbox">
                    <h1>Medarbejder</h1>
                    <span id="students"></span>
                </header>
            </article>
            <article class="MiddleBox">
                <asp:Button runat="server" ID="EditBTN" CssClass="col-4 ButtonLook" Text="Rediger" Visible="false" OnClick="Redirect_Click" />
                <asp:Button runat="server" ID="DeleteBTN" CssClass="col-4 ButtonLook" Text="Slet" Visible="false" OnClick="DeleteBTN_Click" />
            </article>
        </section>
        <section style="max-width: 1200px; margin-top: 10px;" class="box comment">
            <article>
                <header class="title">Kommentarer</header>

                <asp:ListView runat="server" ID="commentList">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="userLabel" Font-Size="Large" Text='<%# Eval("Fullname") %>'></asp:Label>
                        <asp:TextBox runat="server" TextMode="MultiLine" Font-Size="Medium" Width="80%" ID="commentBox" ReadOnly="true" Text='<%# Eval("Msg") %>'></asp:TextBox>
                    </ItemTemplate>
                </asp:ListView>
                <article>
                    <hr style="margin: 10px"/>
                    <asp:TextBox runat="server" style="display:block; " TextMode="MultiLine" Width="40%" ID="createCommentBox"></asp:TextBox>
                    <asp:Label runat="server" ID="errorLabel"></asp:Label>
                    <asp:Button runat="server" ID="createCommentBTN" CssClass="" Text="Skriv kommentar" OnClick="CreateComment" />
                </article>
            </article>
        </section>
    </form>
    <script type="module" src="../JavaScript/Main/ProjectPage_Main.js"></script>
</asp:Content>
