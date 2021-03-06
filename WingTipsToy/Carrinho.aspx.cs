using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WingTipsToy;
using WingTipsToy.Logic;
using WingTipsToy.Models;
using System.Collections.Specialized;
using System.Collections;
using System.Web.ModelBinding;

namespace WingTipsToy
{
    public partial class Carrinho : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            var usuarioCarrinhoCompra = new CarrinhoActions();
            double totalCarrinho = 0;
            totalCarrinho = usuarioCarrinhoCompra.GetTotal();

            if (totalCarrinho > 0)
            {
                lblTotal.Text = string.Format("{0:c}", totalCarrinho);
            }
            else
            {
                LabelTotalText.Text = "";
                lblTotal.Text = "";
                CarrinhoTitulo.InnerHtml = "O carrinho de compras está vazio";
            }

        }

        public List<CarrinhoItem> GetCarrinhoItens()
        {
            var action = new CarrinhoActions();
            return action.GetCarrinhoItems();
        }

        protected void btnAtualizar_Click(object sender, EventArgs e)
        {
            AtualizaItensCarrinho();
        }

        public List<CarrinhoItem> AtualizaItensCarrinho()
        {
            var usuariosCarrinho = new CarrinhoActions();
            string carrinhoId = usuariosCarrinho.GetCarrinhoId();

            int total = CarrinhoLista.Rows.Count;

            var carrinhoAtualiza  = new CarrinhoActions.CarrinhoAtualiza[total];
                        
            for (int i = 0; i < total; i++)
            {
                IOrderedDictionary rowValues = new OrderedDictionary();
                rowValues = GetValues(CarrinhoLista.Rows[i]);
                carrinhoAtualiza[i].ProdutoId = Convert.ToInt32(rowValues["ProdutoID"]);

                CheckBox cbRemover = new CheckBox();
                cbRemover = (CheckBox)CarrinhoLista.Rows[i].FindControl("Remove");
                carrinhoAtualiza[i].RemoveItem = cbRemover.Checked;

                TextBox quantidadeTextBox = new TextBox();
                quantidadeTextBox = (TextBox)CarrinhoLista.Rows[i].FindControl("QuantidadeComprada");
                carrinhoAtualiza[i].QuantidadeComprada = Convert.ToInt16(quantidadeTextBox.Text);
            }

            usuariosCarrinho.AtualizarCarrinhoBD(carrinhoId, carrinhoAtualiza);
            CarrinhoLista.DataBind();
            lblTotal.Text = string.Format("{0:c}", usuariosCarrinho.GetTotal());

            return usuariosCarrinho.GetCarrinhoItems();
        }

        public static IOrderedDictionary GetValues(GridViewRow row)
        {
            IOrderedDictionary values = new OrderedDictionary();
            foreach (DataControlFieldCell cell in row.Cells)
            {
                if(cell.Visible)
                {
                    cell.ContainingField.ExtractValuesFromCell(values, cell, row.RowState, true);
                }
            }

            return values;
        }

    }
}