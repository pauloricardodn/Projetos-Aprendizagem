using Administracao.Web.ViewModel.Produto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Administracao.Web.ViewModel.VendaItem
{
    public class VendaItemViewModel
    {
        
        public int IdVendaItem { get; set; }
        public int IdVenda { get; set; }
        public int IdProduto { get; set; }
        public decimal Qtd { get; set; }
        public decimal ValorUnitario { get; set; }
        public decimal ValorTotalItem { get; set; }
        public ProdutoViewModel Produto { get; set; }

    }
}