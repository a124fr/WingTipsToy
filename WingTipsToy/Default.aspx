<%@ Page Title="Bem Vindo" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WingTipsToy._Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="featureContent" runat="server">
    <div class="jumbotron">
        <h1>ASP.NET</h1>
        <p class="lead">ASP.NET is a free web framework for building great Web sites and Web applications using HTML, CSS, and JavaScript.</p>
        <p><a href="http://www.asp.net" class="btn btn-primary btn-lg">Learn more &raquo;</a></p>
    </div>
    <%--  --%>
    <div class="row">
        <div class="col-md-4">
            <h2><%: Page.Title %></h2>
            <p class="lead">Wingtip Toys pode ajudá-lo a encontrar o presente perfeito.</p>.
            <p>
                Você pode encomendar qualquer um dos nosso brinquedos agora.
                Cada brinquedo listado possui informações detalhada que o ajuda
                a escolher o brinquedo certo.
            </p>
            <p>
                <a class="btn btn-default" href="http://go.microsoft.com/fwlink/?LinkId=301948">Learn more &raquo;</a>
            </p>
        </div>  
</asp:Content>    

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <section style="vertical-align:middle">
        </section>
    </div>
</asp:Content>
