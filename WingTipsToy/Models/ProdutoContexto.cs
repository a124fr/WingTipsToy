using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WingTipsToy.Models
{
    public class ProdutoContexto : DbContext
    {
        public ProdutoContexto()
            : base("WingtipToys")
        {
            //Para inicializar os modelos de dados quando o aplicativo for iniciado.
            Database.SetInitializer(new ProdutoDataBaseInitializer());
        }

        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<CarrinhoItem> CarrinhoItems { get; set; }

    }
}