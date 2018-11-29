using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web.Configuration;

namespace SMN.Repositorio.Comum.Entity
{
    public class RepositorioComumEntity<TEntidade, TChave> : IRepositorioGenerico<TEntidade, TChave>
        where TEntidade : class
    {
        protected DbContext _conterto;

        public RepositorioComumEntity(DbContext contexto)
        {
            _conterto = contexto;
        }


        
        public void Alterar(TEntidade entidade)
        {
            _conterto.Set<TEntidade>().Attach(entidade);
            _conterto.Entry(entidade).State = EntityState.Modified;
            _conterto.SaveChanges();
            
        }
        
        public void Excluir(TEntidade entidade)
        {
            _conterto.Set<TEntidade>().Attach(entidade);
            _conterto.Entry(entidade).State = EntityState.Deleted;
            _conterto.SaveChanges();
        }

        public void ExcluirPorId(TChave Id)
        {
            TEntidade entidade = SelecionaPorID(Id);
            Excluir(entidade);
        }

        public void Inserir(TEntidade entidade)
        {
           _conterto.Set<TEntidade>().Add(entidade);
            _conterto.SaveChanges(); 
        }

        public virtual TEntidade SelecionaPorID(TChave Id)
        {
            return _conterto.Set<TEntidade>().Find(Id);
        }

        public virtual List<TEntidade> Selecionar()
        {
            return _conterto.Set<TEntidade>().ToList();
        }
    }
}