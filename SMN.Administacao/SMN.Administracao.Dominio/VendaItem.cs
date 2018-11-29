using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMN.Administracao.Dominio
{
    public class VendaItem
    {
        public VendaItem( int idVendaItem,int idProduto, string nomeProduto, decimal qtd, decimal valorUnitario , decimal valorTotalItem)
        {
            IdVendaItem = idVendaItem;
            Produto = new Produto(idProduto, nomeProduto);
            Qtd = qtd;
            ValorUnitario = valorUnitario;
            ValorTotalItem = valorTotalItem;
        }
        public VendaItem()
        {

        }
        public int IdVendaItem { get; set; }
        public int IdVenda { get; set; }
        public int IdProduto { get; set; }
        public decimal Qtd { get; set; }
        public decimal ValorUnitario { get; set; }
        public decimal ValorTotalItem { get; set; }
        public Produto Produto { get; set; }
    }
}
