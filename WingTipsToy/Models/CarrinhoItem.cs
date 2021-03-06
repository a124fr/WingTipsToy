using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WingTipsToy.Models
{
    /*
     * A classe carrinhoItem contém o esquema que vai definir cada produto que o usuário adiciona ao carrinho de compras.         
    */
    public class CarrinhoItem
    {
        [Key]
        public string ItemId { get; set; }

        //A propriedade CarrinhoId especifica o ID do usuário que está associado com o item para comprar.
        public string CarrinhoId { get; set; }

        public int Quantidade { get; set; }

        public DateTime DataCriacao { get; set; }

        public int ProdutoId { get; set; }

        public virtual Produto Produto { get; set; }
    }
}