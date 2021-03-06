using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;
using WingTipsToy.Models;

namespace WingTipsToy
{
    public partial class ProdutoDetalhes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IQueryable<Produto> GetProduto([QueryString("produtoID")] int? produtoId)
        {
            if(produtoId.HasValue && produtoId > 0)
            {
                ProdutoContexto contexto = new ProdutoContexto();
                return contexto.Produtos.Where(p => p.ProdutoID == produtoId).AsQueryable();
            }

            return null;
        }

    }
}