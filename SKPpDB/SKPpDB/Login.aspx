<%@ Page Title="Login" Language="C#" MasterPageFile="~/MasterPage/Login.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SKPpDB.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <section class="cardcontainer">
        <section class="card">
            <article class="title">Login</article>


            <form runat="server" name="loginform">
                <section class="input-block">
                    <article class="block">
                        <i class="fas fa-user"></i>
                        <asp:TextBox ID="UsernameBox" runat="server" placeholder="Brugernavn" />
                    </article>

                    <article class="block">
                        <i class="fas fa-lock"></i>
                        <asp:TextBox ID="PasswordBox" runat="server" TextMode="Password" placeholder="Password" />
                    </article>

                    <asp:Button ID="SubmitBTN" runat="server" CssClass="button" Text="Login" OnClick="SubmitBTN_Click" />
                </section>
                <section class="link-block">
                    <article class="block">
                        <a href="ResetPage.aspx">Reset Password</a>
                        <%--<asp:Button ID="ResetBTN" runat="server" Text="Reset password" OnClick="ResetBTN_Click" />--%>
                    </article>
                    <article class="block">
                        <asp:Label ID="Label1" runat="server" CssClass="error"></asp:Label>
                    </article>

                </section>

            </form>

        </section>
    </section>


</asp:Content>
