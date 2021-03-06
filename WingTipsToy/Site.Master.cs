using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WingTipsToy.Logic;
using WingTipsToy.Models;

namespace WingTipsToy
{
    public partial class SiteMaster : MasterPage
    {

        protected override void OnPreRender(EventArgs e)
        {
            //base.OnPreRender(e);
            var usuarioCarrinho = new CarrinhoActions();
            var carrinhoStr = string.Format("Cart ({0})", usuarioCarrinho.GetContador());
            carrinhoContador.InnerHtml = carrinhoStr;
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IQueryable<Categoria> GetCategorias()
        {
            ProdutoContexto contexto = new ProdutoContexto();
            return contexto.Categorias.AsQueryable();
        }
    }
}