using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Administracao.Web.ViewModel.Funcionarios;
using SMN.Administracao.Dominio;
using SMN.Administracao.Repositorio;
using AutoMapper;
using System.Net;

namespace Administracao.Web.Controllers
{
    public class FuncionariosController : Controller
    {
       
       
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(FuncionariosViewModel funcionarioViewModel)
        {
            if (ModelState.IsValid)
            {
                var funcionario = new Funcionarios
                {
                    Nome=funcionarioViewModel.Nome,
                    Endereco=funcionarioViewModel.Endereco,
                    Sexo=funcionarioViewModel.Sexo,
                    DataNasc=funcionarioViewModel.DataNasc
                };
                RepositorioFuncionario rep = new RepositorioFuncionario();
                rep.InserirUsuario(funcionario);
                return RedirectToAction("Index");
            }

            return View(funcionarioViewModel);

            //return View();
        }

        // GET: Funcionarios
        
        public ActionResult Index()
        {
            RepositorioFuncionario rep = new RepositorioFuncionario();
            var funcionario = rep.ListarUsuario().ToList();
            var funcionarioViewModel = funcionario.Select(x => new FuncionariosExibicaoViewModel
            {
                IdFuncionario=x.IdFuncionario,
                Nome=x.Nome,
                Endereco=x.Endereco,
                Sexo=x.Sexo,
                DataNasc=x.DataNasc
            });
            return View(funcionarioViewModel);
        }
        public ActionResult Exibir()
        {
            RepositorioFuncionario rep = new RepositorioFuncionario();
            var funcionario = rep.ListarUsuario().ToList();
            var funcionarioViewModel = funcionario.Select(x => new FuncionariosExibicaoViewModel
            {
                IdFuncionario = x.IdFuncionario,
                Nome = x.Nome,
                Endereco = x.Endereco,
                Sexo = x.Sexo,
                DataNasc = x.DataNasc
            });
            return View(funcionarioViewModel);
        }
      
        public ActionResult Edit(int id)
        {
            RepositorioFuncionario rep = new RepositorioFuncionario();
            Funcionarios funcionario = rep.ListarUsuarioPorId(id);

            if (funcionario == null)
            {
                return HttpNotFound();
            }
            var funcionarioViewModel = new FuncionariosViewModel
            {
                IdFuncionario=funcionario.IdFuncionario,
                Nome=funcionario.Nome,
                Endereco=funcionario.Endereco,
                Sexo=funcionario.Sexo,
                DataNasc=funcionario.DataNasc
                
            };
            return View(funcionarioViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( FuncionariosViewModel funcionarioViewModel)
        {
            if (ModelState.IsValid)
            {
                RepositorioFuncionario rep = new RepositorioFuncionario();
                var funcionario = new Funcionarios
                {
                    Nome = funcionarioViewModel.Nome,
                    Endereco = funcionarioViewModel.Endereco,
                    Sexo = funcionarioViewModel.Sexo,
                    DataNasc = funcionarioViewModel.DataNasc
                };
                rep.EditarUsuario(funcionario);

                return RedirectToAction("Index");
            }

            return View(funcionarioViewModel);
        }

        // POST: Musicas/Delete/5
        [HttpGet]        
        public ActionResult Delete(int id)
        {
            RepositorioFuncionario rep = new RepositorioFuncionario();
            rep.Deletar(id);
           return RedirectToAction("Exibir");
        }



    }
}