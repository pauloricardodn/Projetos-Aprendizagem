﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Musicas.Web.ViewModel.Album
{
    public class AlbumIndexViewModel
    {
       
        public int Id { get; set; }


        [Display(Name = "Nome do Album: ")]
        public string Nome { get; set; }


        [Display(Name = "Ano do Album: ")]        
        public int Ano { get; set; }


        [Display(Name = "Observações do Alnum: ")]        
        public string Observacoes { get; set; }


        [Display(Name = "Email para Contato: ")]        
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}