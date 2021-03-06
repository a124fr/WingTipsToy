<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Carrinho.aspx.cs" Inherits="WingTipsToy.Carrinho" %>
<asp:Content ID="Content1" ContentPlaceHolderID="featureContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <br />

    <div class="row">
        <div id="CarrinhoTitulo" runat="server" class="ContentHead"><h1>Carrinho de Compras</h1></div>
        <asp:GridView ID="CarrinhoLista" runat="server" AutoGenerateColumns="False" ShowFooter="True" GridLines="Vertical" CellPadding="4"
            ItemType="WingTipsToy.Models.CarrinhoItem" CssClass="CarrinhoListaItem" SelectMethod="GetCarrinhoItens" Width="600">              
            <AlternatingRowStyle CssClass="CarrinhoListaItemAlt" />
            <Columns>
            <asp:BoundField DataField="ProdutoID" HeaderText="ID" SortExpression="ProduotID" />        
            <asp:BoundField DataField="Produto.ProdutoNome" HeaderText="Nome" SortExpression="ProdutoNome" />        
            <asp:BoundField DataField="Produto.PrecoUnitario" HeaderText="Preço (un.)" DataFormatString="{0:c}"/>     
            <asp:TemplateField   HeaderText="Quantidade">            
                    <ItemTemplate>
                        <asp:TextBox ID="QuantidadeComprada" Width="40" runat="server" Text="<%#: Item.Quantidade%>"></asp:TextBox> 
                    </ItemTemplate>        
            </asp:TemplateField>    
            <asp:TemplateField HeaderText="Total ">            
                    <ItemTemplate>
                        <%#: String.Format("{0:c}", ((Convert.ToDouble(Item.Quantidade)) * Convert.ToDouble(Item.Produto.PrecoUnitario)))%>
                    </ItemTemplate>        
            </asp:TemplateField> 
            <asp:TemplateField HeaderText="Remover Item">            
                    <ItemTemplate>
                        <asp:CheckBox id="Remove" runat="server"></asp:CheckBox>
                    </ItemTemplate>        
            </asp:TemplateField>    
            </Columns>    
            <FooterStyle CssClass="CarrinhoListaFooter"/>
            <HeaderStyle  CssClass="CarrinhoListaHead" />
        </asp:GridView>
        <div>
            <p></p>
            <strong>
                <asp:Label ID="LabelTotalText" runat="server" Text="Total Pedido: "></asp:Label>
                <asp:Label CssClass="NormalBold" id="lblTotal" runat="server" EnableViewState="false"></asp:Label>
            </strong> 
        </div>
        <br />
        <table>
            <tr>
                <td>
                    <asp:Button ID="btnAtualizar" runat="server" Text="Atualizar" OnClick="btnAtualizar_Click" />
                </td>
                <td>
                    <!-- Checkout Placeholder -->
                </td>
            </tr>

        </table>
    </div>
</asp:Content>
