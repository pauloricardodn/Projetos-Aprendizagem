
using SMN.Musicas.AcessoDados.Entity.TypeConfiguration;
using SMN.Musicas.Dominio;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMN.Musicas.AcessoDados.Entity.Context
{
    public class MusicasDbContext :DbContext
    {
        public DbSet<Album> Albuns { get; set; }
        public DbSet<Musica> Musicas { get; set; }
        public MusicasDbContext()
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Musica>().HasKey(t => t.Id);
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new AlbumTypeConfiguration());
            modelBuilder.Configurations.Add(new MusicaTypeConfiguration());
        }
        //{
        //    modelBuilder.Configurations.Add(new AlbumTypeConfiguration());
        //    modelBuilder.Configurations.Add(new MusicaTypeConfiguration());
        //}

    }
}
