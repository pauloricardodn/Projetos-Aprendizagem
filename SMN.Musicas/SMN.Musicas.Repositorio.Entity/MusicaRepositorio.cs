
using SMN.Repositorio.Comum.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using SMN.Musicas.AcessoDados.Entity.Context;
using SMN.Musicas.Dominio;

namespace SMN.Musicas.Repositorio.Entity
{
    public class MusicaRepositorio : RepositorioComumEntity<Musica, int>
    {
        public MusicaRepositorio(MusicasDbContext contexto) 
            : base(contexto)
        {
        }

        public override List<Musica> Selecionar()
        {
            return _conterto.Set<Musica>().Include(p => p.Album).ToList();
        }

        public override Musica SelecionaPorID(int id)
        {
            return _conterto.Set<Musica>().Include(p=> p.Album).SingleOrDefault(m=> m.Id==id);
        }

    }
}
