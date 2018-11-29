using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LerExcel
{
    public class Usuarios
    {
        public Usuarios(int codigo, string nome, string logon, List<Usuarios> usuariosSubordinados)
        {
            Codigo = codigo;
            Nome = nome;
            Logon = logon;
            UsuariosSubordinados = usuariosSubordinados;
        }

        public int Codigo { get; set; }
        public string Nome { get; set; }
        public string Logon { get; set; }
        public List<Usuarios> UsuariosSubordinados { get; set; }
    }
}
