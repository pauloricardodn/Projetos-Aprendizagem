using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SMN.Administracao.Dominio
{
    public class Venda
    {
        public Venda(int id, int idCliente, string nomeCliente, DateTime dataVenda, decimal valorTotal)
        {
            IdVenda = id;
            IdCliente = idCliente;
            Cliente = new Cliente(idCliente, nomeCliente);
            DataVenda = dataVenda;
            ValorTotalVenda = valorTotal;
        }
        public Venda()
        {

        }
        public int IdProduto { get; set; }
        public int IdVenda{ get; set; }
        public int IdCliente { get; set; }
        public DateTime DataVenda { get; set; }
        public DateTime DataPagamento { get; set; }
        public decimal ValorTotalVenda { get; set; }
        public IEnumerable<VendaItem> VendaItem { get; set; }
        public IEnumerable<VendaItem> ItemDeletar { get; set; }
        public Cliente Cliente { get; set; }

    }
}
