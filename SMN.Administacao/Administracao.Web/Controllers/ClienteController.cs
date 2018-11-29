using Administracao.Web.ViewModel.Cliente;
using AutoMapper;
using SMN.Administracao.Dominio;
using SMN.Administracao.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Administracao.Web.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente
        public ActionResult Index()
        {
            RepositorioCliente rep = new RepositorioCliente();
            var cliente = rep.ListarCliente().ToList();
            var clienteViewModel = cliente.Select(x => new ClienteExibicaoViewModel
            {
                IdCliente = x.IdCliente,
                Nome = x.Nome,
                Endereco = x.Endereco,
                Celular = x.Celular,
                Cpf = x.Cpf,
                DataCad = x.DataCad,
                DataNasc = x.DataNasc,
                Sexo = x.Sexo
            });

            return View(clienteViewModel);
        }
        public ActionResult Exibir()
        {
            RepositorioCliente rep = new RepositorioCliente();
            var cliente = rep.ListarCliente().ToList();
            var clienteViewModel = cliente.Select(x => new ClienteExibicaoViewModel
            {
                IdCliente = x.IdCliente,
                Nome = x.Nome,
                Endereco = x.Endereco,
                Celular = x.Celular,
                Cpf = x.Cpf,
                DataCad=x.DataCad,
                DataNasc=x.DataNasc,
                Sexo=x.Sexo
            });

            return View(clienteViewModel);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(ClienteViewModel clienteViewModel)
        {
            if (ModelState.IsValid)
            {
                
                var cliente = new Cliente
                {
                    Nome = clienteViewModel.Nome,
                    Endereco = clienteViewModel.Endereco,
                    Celular=clienteViewModel.Celular,
                    Sexo=clienteViewModel.Sexo,
                    DataNasc=clienteViewModel.DataNasc,
                    Cpf=clienteViewModel.Cpf
                };
                RepositorioCliente rep = new RepositorioCliente();
                cliente.DataCad = DateTime.Now;
                //cliente.Cpf=cliente.Cpf.Replace(".", "").Replace("-", ""); 
                rep.InserirCLiente(cliente);
                return RedirectToAction("Index");
            }

            return View(clienteViewModel);

            //return View();
        }

        public ActionResult Edit(int id)
        {
            RepositorioCliente rep = new RepositorioCliente();
            Cliente cliente = rep.ListarClientePorId(id);

            if (cliente == null)
            {
                return HttpNotFound();
            }
            var clienteViewModel = new ClienteViewModel
            {
                IdCliente=cliente.IdCliente,
                Nome = cliente.Nome,
                Endereco = cliente.Endereco,
                Celular = cliente.Celular,
                Sexo = cliente.Sexo,
                DataNasc = cliente.DataNasc,
                Cpf = cliente.Cpf,
                DataCad=cliente.DataCad
            };
            return View(clienteViewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ClienteViewModel clienteViewModel)
        {
            if (ModelState.IsValid)
            {
                var cliente = new Cliente
                {
                    Nome = clienteViewModel.Nome,
                    Endereco = clienteViewModel.Endereco,
                    Celular = clienteViewModel.Celular,
                    Sexo = clienteViewModel.Sexo,
                    DataNasc = clienteViewModel.DataNasc,
                    Cpf = clienteViewModel.Cpf
                };                
                RepositorioCliente rep = new RepositorioCliente();
                rep.EditarCLiente(cliente);

                return RedirectToAction("Index");
            }

            return View(clienteViewModel);
        }
        public ActionResult Delete(int id)
        {
            RepositorioCliente rep = new RepositorioCliente();
            rep.Deletar(id);
            return RedirectToAction("Exibir");
        }
    }
}