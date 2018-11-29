
using AutoMapper;
using Musicas.Web.ViewModel.Album;
using Musicas.Web.ViewModel.Musica;
using SMN.Musicas.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Musicas.Web.AutoMapper
{
    public class ViewModelParaDominioProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<AlbumViewModel, Album>();
            Mapper.CreateMap<AlbumIndexViewModel, Album>();
            Mapper.CreateMap<MusicasViewModel, Musica>();
            Mapper.CreateMap<MusicaExibicaoViewModel, Musica>();
        }
    }
}