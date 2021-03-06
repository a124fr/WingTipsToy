<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProdutoDetalhes.aspx.cs" Inherits="WingTipsToy.ProdutoDetalhes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="featureContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:FormView ID="produtoDetalhes" runat="server" ItemType="WingTipsToy.Models.Produto" SelectMethod="GetProduto" RenderOuterTable="false">
        <ItemTemplate>
            <div>
                <h1><%#:Item.ProdutoNome%></h1>
            </div>
            <br />
            <table>
                <tr>
                    <td>
                        <img src="/Catalog/Images/<%#:Item.CaminhoImagem%>" border="1" alt="<%#:Item.ProdutoNome%>" height="300" />
                    </td>
                    <td style="vertical-align: top">
                        <b>Descrição:</b><br /><%#:Item.Descricao%>
                        <br />
                        <span><b>Preço:</b>&nbsp;<%#: String.Format("{0:c}", Item.PrecoUnitario)%></span>
                        <br />
                        <span><b>No. do Produto:</b>&nbsp;<%#:Item.ProdutoID%></span>
                        <br />                        
                         <a href="/IncluirNoCarrinho.aspx?produtoID=<%#:Item.ProdutoID %>">              
                                <span class="ProdutoListaItem">
                                    <b>Incluir no Carrinho<b>
                                </span>          
                        </a>
                    </td>
                </tr>
            </table>
        </ItemTemplate>
    </asp:FormView>
</asp:Content>
