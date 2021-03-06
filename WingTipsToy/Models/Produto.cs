using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WingTipsToy.Models
{
    public class Produto
    {
        [ScaffoldColumn(false)]
        public int ProdutoID { get; set; }

        [Required, StringLength(100), Display(Name = "Nome")]
        public string ProdutoNome { get; set; }

        [Required, StringLength(10000), Display(Name= "Descrição Produto"), DataType(DataType.MultilineText)]
        public string Descricao { get; set; }

        public string CaminhoImagem { get; set; }

        [Display(Name= "Preço")]
        public double? PrecoUnitario { get; set; }

        public int CategoriaID { get; set; }

        public virtual Categoria Categoria { get; set; } 
    }
}