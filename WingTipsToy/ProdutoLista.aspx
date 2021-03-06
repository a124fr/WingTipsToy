<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProdutoLista.aspx.cs" Inherits="WingTipsToy.ProdutoLista" %>
<asp:Content ID="Content1" ContentPlaceHolderID="featureContent" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<br />
<br />
<div class="row col">
      <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                <h1><%: Page.Title %></h1>
            </hgroup>
                 <section class="featured">
                    <ul> 
                        <asp:ListView ID="produtoLista" runat="server"  DataKeyNames="ProdutoID"
                            GroupItemCount="3" ItemType="WingTipsToy.Models.Produto" SelectMethod="GetProdutos">
                            <EmptyDataTemplate>      
                                <table id="Table1" runat="server">        
                                    <tr>          
                                        <td>Nenhum dado foi retornado.</td>        
                                    </tr>     
                                </table>  
                            </EmptyDataTemplate>  
                            <EmptyItemTemplate>     
                                <td id="Td1" runat="server" />  
                            </EmptyItemTemplate>  
                            <GroupTemplate>    
                                <tr ID="itemPlaceholderContainer" runat="server">      
                                    <td ID="itemPlaceholder" runat="server"></td>    
                                </tr>  
                            </GroupTemplate>  
                            <ItemTemplate>    
                                <td id="Td2" runat="server">      
                                    <table>        
                                        <tr>          
                                            <td>&nbsp;</td>          
                                            <td>
                                                <a href="ProduotDetalhes.aspx?produtoID=<%#:Item.ProdutoID%>">
                                                    <img src="/Catalog/Images/Thumbs/<%#:Item.CaminhoImagem%>" 
                                                        width="100" height="75" border="1"/></a> 
                                            </td>
                                            <td>
                                                <a href="ProdutoDetalhes.aspx?produtoID=<%#:Item.ProdutoID%>">
                                                    <span class="ProdutoNome">
                                                        <%#:Item.ProdutoNome%>
                                                    </span>
                                                </a>            
                                                <br />
                                                <span class="PrecoUnitario">           
                                                    <b>Preço : </b><%#:String.Format("{0:c}", Item.PrecoUnitario)%>
                                                </span>
                                                <br />                                                   
                                                <a href="/IncluirNoCarrinho.aspx?produtoId=<%#:Item.ProdutoID %>">              
                                                    <span class="ProdutoListaItem">
                                                        <b>Incluir no Carrinho<b>
                                                    </span>          
                                                </a>         
                                            </td>        
                                        </tr>      
                                    </table>    
                                </td>  
                            </ItemTemplate>  
                            <LayoutTemplate>    
                                <table id="Table2" runat="server">      
                                    <tr id="Tr1" runat="server">        
                                        <td id="Td3" runat="server">          
                                            <table ID="groupPlaceholderContainer" runat="server">            
                                                <tr ID="groupPlaceholder" runat="server"></tr>          
                                            </table>        
                                        </td>      
                                    </tr>      
                                    <tr id="Tr2" runat="server"><td id="Td4" runat="server"></td></tr>    
                                </table>  
                            </LayoutTemplate>
                        </asp:ListView>
                    </ul>
               </section>
        </div>
    </section>
</div>
</asp:Content>
