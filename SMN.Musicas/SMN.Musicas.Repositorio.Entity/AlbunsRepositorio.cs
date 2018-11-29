
using SMN.Repositorio.Comum.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using SMN.Musicas.AcessoDados.Entity.Context;
using SMN.Musicas.Dominio;

namespace SMN.Musicas.Repositorio.Entity
{
    public class AlbunsRepositorio : RepositorioComumEntity<Album, int>
        
    {
        public AlbunsRepositorio(MusicasDbContext contexto)
            : base(contexto)
        {

        }
        public override List<Album> Selecionar()
        {
            return _conterto.Set<Album>().Include(p=>p.Musicas).ToList();
        }

        public override Album SelecionaPorID(int Id)
        {
            return _conterto.Set<Album>().Include(p=>p.Musicas).SingleOrDefault(a=>a.Id==Id);
        }

    }
}
