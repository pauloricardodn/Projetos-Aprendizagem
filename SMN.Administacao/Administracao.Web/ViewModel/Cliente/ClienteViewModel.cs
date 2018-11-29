using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Administracao.Web.ViewModel.Cliente
{
    public class ClienteViewModel
    {
        public ClienteViewModel(int idCliente, string nomeCliente)
        {
            IdCliente = idCliente;
            Nome = nomeCliente;
        }
        public ClienteViewModel()
        {

        }
        public int IdCliente { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Celular { get; set; }
        public string Sexo { get; set; }
        public string Cpf { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataNasc { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataCad { get; set; }

       
    }
}