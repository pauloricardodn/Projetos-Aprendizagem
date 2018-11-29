using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Administracao.Web.ViewModel.Funcionarios
{
    public class FuncionariosViewModel
    {
        public int IdFuncionario { get; set; }

        [Display(Name = "Nome: ")]
        [Required(ErrorMessage = "Nome Obrigatorio")]
        public string Nome { get; set; }
        [Display(Name = "Endereço: ")]
        [Required(ErrorMessage = "Endereço Obrigatorio")]
        public string Endereco { get; set; }
        [Display(Name = "Sexo: ")]
        [Required(ErrorMessage = "Sexo Odrigatorio")]
        public string Sexo { get; set; }

        [Display(Name = "Data de Nascimento")]
        [Required(ErrorMessage = "Data de Nacimento Obrigatoria")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataNasc { get; set; }
    }
}