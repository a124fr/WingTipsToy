using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WingTipsToy.Logic;
using WingTipsToy.Models;

namespace WingTipsToy
{
    public partial class IncluirNoCarrinho : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string rawId = Request.QueryString["ProdutoId"];
            int produtoId;

            if(!string.IsNullOrEmpty(rawId) && int.TryParse(rawId, out produtoId))
            {
                var usuariosCarrinhoCompras = new CarrinhoActions();
                usuariosCarrinhoCompras.IncluirNoCarrinho(Convert.ToInt16(rawId));
            }
            else
            {
                Debug.Fail("ERROR: Falta o produtoId para chamar IncluirNoCarrinho.aspx");
                throw new Exception("ERROR: Não se pode carregar IncluirNoCarrinho.aspx sem definir um ProdutoId.");
            }

            Response.Redirect("Carrinho.aspx");
        }
    }
}