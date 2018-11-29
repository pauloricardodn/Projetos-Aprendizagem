using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMN.Comum.Entity
{
    public abstract class SMNEntityAbstractConfig<TEntidade> : EntityTypeConfiguration<TEntidade>
        where TEntidade:class
    {
        public SMNEntityAbstractConfig()
        {
            ConfigurarNomeTabela();
            ComfigurarCamposTabela();
            ConfigurarChavePrimaria();
            ConfigurarChavesEstrangeiras();
        }

        protected abstract void ConfigurarChavesEstrangeiras();
        protected abstract void ConfigurarChavePrimaria();
        protected abstract void ComfigurarCamposTabela();
        protected abstract void ConfigurarNomeTabela();
        
    }
}
