using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Administracao.Web.ViewModel.Funcionarios;
using Administracao.Web.ViewModel.Cliente;
using SMN.Administracao.Dominio;
using Administracao.Web.ViewModel.Produto;
using Administracao.Web.ViewModel.Venda;
using Administracao.Web.ViewModel.VendaItem;

namespace Administracao.Web.AutoMapper
{
    public class DominioParaViewModeProfile:Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<Funcionarios, FuncionariosExibicaoViewModel>();
            Mapper.CreateMap<Funcionarios, FuncionariosViewModel> ();
            Mapper.CreateMap<Cliente, ClienteExibicaoViewModel>();
            Mapper.CreateMap<Cliente, ClienteViewModel>();
            Mapper.CreateMap<Produto, ProdutoViewModel>();
            Mapper.CreateMap<Produto, ProdutoExibicaoViewModel>();
            Mapper.CreateMap<Venda, VendaViewModel>();           
            Mapper.CreateMap<VendaItem, VendaItemViewModel>();
        }
    }
}