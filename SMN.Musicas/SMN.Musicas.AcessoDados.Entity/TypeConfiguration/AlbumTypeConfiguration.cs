using SMN.Comum.Entity;
using SMN.Musicas.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMN.Musicas.AcessoDados.Entity.TypeConfiguration
{
    class AlbumTypeConfiguration : SMNEntityAbstractConfig<Album>
    {
        protected override void ComfigurarCamposTabela()
        {
            Property(p => p.Id)
                .IsRequired()
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)
                .HasColumnName("ALB_ID");

            Property(P => P.Nome)
                .IsRequired()
                .HasColumnName("ALB_NOME");

            Property(p => p.Ano)
                .IsRequired()
                .HasColumnName("ALB_ANO");

            Property(P => P.Observacoes)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("ALB_OBSERVACOES");

            Property(p => p.Email)
                .IsRequired()
                .HasColumnName("ALB_EMAIL")
                .HasMaxLength(50);

        }

        protected override void ConfigurarChavePrimaria()
        {
            HasKey(p => p.Id);
        }

        protected override void ConfigurarChavesEstrangeiras()
        {
           
        }

        protected override void ConfigurarNomeTabela()
        {
            ToTable("ALB_ALBUNS");
        }
    }
}
