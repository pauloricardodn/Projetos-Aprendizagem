using Musicas.Web.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Musicas.Web.ViewModel.Album
{
    public class AlbumViewModel
    {
        public int Id { get; set; }


        [Display(Name = "Nome do Album: ")]
        [Required(ErrorMessage ="Obrigatorio preencher o nome.")]
        [MaxLength(100,ErrorMessage ="Maxio 100 caracteres para o nome")]
        public string Nome { get; set; }


        [Display(Name = "Ano do Album: ")]
        [Required(ErrorMessage = "Obrigatorio preencher o ano.")]
        //[MaxLength(100, ErrorMessage = "Maximo 100 caracteres para o nome")]
        public int Ano { get; set; }


        [Display(Name = "Observações do Album: ")]
        [Required(ErrorMessage ="Obrigatorio preencher as observações")]
        [MaxLength(100, ErrorMessage = "Maximo 100 caracteres para o nome")]

        public string Observacoes { get; set; }


        [Display(Name = "Email para Contato: ")]
        [Required]
        [EmailSMNAtributes(ErrorMessage = "Obrigatorio email da smn")]
        public string Email { get; set; }
    }
}