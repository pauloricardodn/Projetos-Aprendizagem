using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Administracao.Web.ViewModel.Funcionarios
{
    public class FuncionariosExibicaoViewModel
    {
        [Display(Name = "Codigo")]
        public int IdFuncionario { get; set; }

        [Display(Name = "Nome do FUncinario")]
        public string Nome { get; set; }

        public string Endereco { get; set; }

        public string Sexo { get; set; }

        [Display(Name = "Data de Nascimento")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataNasc { get; set; }
    }
}