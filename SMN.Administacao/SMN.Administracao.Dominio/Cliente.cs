using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMN.Administracao.Dominio
{
    public class Cliente
    {
        public Cliente(int id, string nome)
        {
            IdCliente = id;
            Nome = nome;
        }
        public Cliente()
        {

        }

        public int IdCliente { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Celular { get; set; }
        public string Sexo { get; set; }
        public string Cpf { get; set; }        
        public DateTime DataNasc { get; set; }
        public DateTime DataCad { get; set; }
    }
}
