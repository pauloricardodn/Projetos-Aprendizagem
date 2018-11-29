using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Administracao.Web.ViewModel.Produto
{
    public class ProdutoViewModel
    {
       

        [Display(Name = "Codigo")]
        public int IdProduto { get; set; }
        [Display(Name = "Nome do Produto")]
        public string NomeProduto { get; set; }
        [Display(Name = "Estoque")]
        public decimal QtdEstoque { get; set; }
        [Display(Name = "Valor de Compra")]
        public decimal ValorCompra { get; set; }
        [Display(Name = "Valor de Venda")]
        public decimal ValorVenda { get; set; }


        
    }
}