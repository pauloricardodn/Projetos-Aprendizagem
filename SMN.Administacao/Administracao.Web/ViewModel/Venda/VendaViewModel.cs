using Administracao.Web.ViewModel.Cliente;
using Administracao.Web.ViewModel.Produto;
using Administracao.Web.ViewModel.VendaItem;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Administracao.Web.ViewModel.Venda
{
    public class VendaViewModel
    {

        
        public VendaViewModel()
        {
            ProdutoVenda = new SelectList(Enumerable.Empty<object>());
            ClienteVenda = new SelectList(Enumerable.Empty<object>());
        }
       


        [Display(Name = "Produto")]
        public int IdProduto { get; set; }
        [Display(Name = "Venda")]
        public int IdVenda { get; set; }
        [Display(Name = "Cliente")]
        public int IdCliente { get; set; }
        public DateTime DataVenda { get; set; }
        public DateTime DataPagamento { get; set; }
        public decimal ValorTotalVenda { get; set; }

        public SelectList ProdutoVenda { get; set; }
        public SelectList ClienteVenda { get; set; }

        public IEnumerable<VendaItemViewModel> VendaItem { get; set;}
        public IEnumerable<VendaItemViewModel> ItemDeletar { get; set; }

        public ClienteViewModel Cliente { get; set; }

    }
}