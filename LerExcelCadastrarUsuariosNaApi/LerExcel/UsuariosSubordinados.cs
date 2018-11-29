using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LerExcel
{
    public class UsuariosSubordinados
    {
        public int CodigoRepres { get; set; }
        public string Fantasia { get; set; }
        public string NomeSubordinado { get; set; }
        public List<UsuariosSubordinados> ListaSubordinados { get; set; }
    }
}
