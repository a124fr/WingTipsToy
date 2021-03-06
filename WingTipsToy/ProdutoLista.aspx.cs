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
    public partial class ProdutoLista : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IQueryable<Produto> GetProdutos([QueryString("id")]int? categoriaId)
        {
            ProdutoContexto contexto = new ProdutoContexto();

            if (categoriaId.HasValue && categoriaId > 0) 
            {
                return contexto.Produtos.Where(p => p.CategoriaID == categoriaId).AsQueryable();
            }

            return contexto.Produtos.AsQueryable();
        }
    }
}