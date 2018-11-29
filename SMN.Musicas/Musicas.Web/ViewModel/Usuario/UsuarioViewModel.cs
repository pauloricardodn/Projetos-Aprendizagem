using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Musicas.Web.ViewModel.Usuario
{
    public class UsuarioViewModel
    {
        [Required (ErrorMessage ="Email é obrigatorio")]
        [MaxLength(30, ErrorMessage ="Maximo 30 Caracteres")]
        public string Email { get; set; }

        [Required(ErrorMessage ="Senha é pbrigatória")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }
    }
}