
using Administracao.Web.ViewModel.Funcionarios;
using Administracao.Web.ViewModel.Cliente;
using SMN.Administracao.Dominio;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Administracao.Web.ViewModel.Produto;
using Administracao.Web.ViewModel.Venda;
using Administracao.Web.ViewModel.VendaItem;

namespace Administracao.Web.AutoMapper
{
    public class ViewModelParaDominioProfile:Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<FuncionariosExibicaoViewModel, Funcionarios>();
            Mapper.CreateMap<FuncionariosViewModel, Funcionarios>();
            Mapper.CreateMap<ClienteExibicaoViewModel, Cliente>();
            Mapper.CreateMap<ClienteViewModel, Cliente>();
            Mapper.CreateMap<ProdutoViewModel, Produto>();
            Mapper.CreateMap<ProdutoExibicaoViewModel, Produto>();
            Mapper.CreateMap<VendaViewModel, Venda>();            
            Mapper.CreateMap<VendaItemViewModel, VendaItem>();
        }

    }
}