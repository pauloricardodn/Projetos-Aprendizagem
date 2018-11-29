using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Musicas.Web.ViewModel.Musica
{
    public class MusicaExibicaoViewModel
    {
        public int Id { get; set; }

        [Display (Name="Nome da Musica") ]
        public string Nome { get; set; }

        [Display(Name = "Nome do Album")]
        public string NomeAlbum { get; set; }



    }
}