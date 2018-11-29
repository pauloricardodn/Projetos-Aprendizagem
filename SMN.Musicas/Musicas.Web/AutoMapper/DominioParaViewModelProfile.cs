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
    public class DominioParaViewModelProfile:Profile
    {
        protected override void Configure()
        {
            //Album
            Mapper.CreateMap<Album, AlbumIndexViewModel>();
            Mapper.CreateMap<Album, AlbumViewModel>();
            //Musica
            Mapper.CreateMap<Musica, MusicaExibicaoViewModel>()
                .ForMember(p=>p.NomeAlbum, opt=>
                {
                    opt.MapFrom(src =>
                     src.Album.Nome
                    );
                }
                );
            Mapper.CreateMap<Musica, MusicasViewModel>();            

            
        }
    }
}