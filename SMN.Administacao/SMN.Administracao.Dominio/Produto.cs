﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMN.Administracao.Dominio
{
    public class Produto
    {
        public Produto()
        {
                
        }
        public Produto(int idProduto, string nomeProduto)
        {
            IdProduto = idProduto;
            NomeProduto = nomeProduto;
        }
        public int IdProduto { get; set; }
        public string NomeProduto { get; set; }
        public decimal QtdEstoque { get; set; }
        public decimal ValorCompra { get; set; }
        public decimal ValorVenda { get; set; }
    }
}
