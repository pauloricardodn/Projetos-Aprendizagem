
using SMN.Comum.Entity;
using SMN.Musicas.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMN.Musicas.AcessoDados.Entity.TypeConfiguration
{
    public class MusicaTypeConfiguration : SMNEntityAbstractConfig<Musica>
    {
        protected override void ComfigurarCamposTabela()
        {
            Property(p=>p.Id)
                .IsRequired()
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)
                .HasColumnName("MSC_ID");
            Property(p => p.Nome)
                .IsRequired()
                .HasColumnName("MSC_NOME");
            Property(p => p.IdAlbum)
                .IsRequired()
                .HasColumnName("ALB_ID");
        }

        protected override void ConfigurarChavePrimaria()
        {
            HasKey(p => p.Id);
                
        }
          

        protected override void ConfigurarChavesEstrangeiras()
        {
            HasRequired(p => p.Album)
                .WithMany(p => p.Musicas)
                .HasForeignKey(p => p.IdAlbum);
        }

        protected override void ConfigurarNomeTabela()
        {
            ToTable("MUS_MUSICA");
        }
    }
}
