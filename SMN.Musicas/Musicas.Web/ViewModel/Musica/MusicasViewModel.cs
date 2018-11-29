using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Musicas.Web.ViewModel.Musica
{
    public class MusicasViewModel
    {
        [Required(ErrorMessage ="Obrigatorio o  id")]
        public int Id { get; set; }

        [Display(Name = "Nome da Musica")]
        [Required(ErrorMessage ="Nome Odrigatorio")]
        public string Nome { get; set; }

        [Required(ErrorMessage ="Selecione um Album Válido")]
        public int IdAlbum { get; set; }
    }
}