using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMN.Administracao.Dominio
{
    public class Funcionarios
    {
        public int IdFuncionario { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Sexo { get; set; }
        public DateTime DataNasc { get; set; }
    }
}
