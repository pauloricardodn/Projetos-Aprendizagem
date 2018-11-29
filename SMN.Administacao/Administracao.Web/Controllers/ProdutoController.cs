using Administracao.Web.ViewModel.Produto;
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
    public class ProdutoController : Controller
    {
        // GET: Protuto
        public ActionResult Index()
        {
            RepositorioProduto rep = new RepositorioProduto();
            var produto = rep.SelecionarProduto().ToList();
            var produtoViewModel = produto.Select(x => new ProdutoExibicaoViewModel
            {
                IdProduto=x.IdProduto,
                NomeProduto=x.NomeProduto,
                QtdEstoque=x.QtdEstoque,
                ValorCompra=x.ValorCompra,
                ValorVenda=x.ValorVenda
            });
            return View(produtoViewModel);

        }
        public ActionResult Exibir()
        {
            RepositorioProduto rep = new RepositorioProduto();
            var produto = rep.SelecionarProduto().ToList();
            var produtoViewModel = produto.Select(x => new ProdutoExibicaoViewModel
            {
                IdProduto = x.IdProduto,
                NomeProduto = x.NomeProduto,
                QtdEstoque = x.QtdEstoque,
                ValorCompra = x.ValorCompra,
                ValorVenda = x.ValorVenda
            });
            return View(produtoViewModel);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(ProdutoViewModel produtoViewModel)
        {
            if (ModelState.IsValid)
            {                
                var produto = new Produto
                {
                    NomeProduto=produtoViewModel.NomeProduto,
                    QtdEstoque=produtoViewModel.QtdEstoque,
                    ValorCompra=produtoViewModel.ValorCompra,
                    ValorVenda=produtoViewModel.ValorVenda
                };
                RepositorioProduto rep = new RepositorioProduto();
               
                rep.InserirProduto(produto);
                return RedirectToAction("Index");
            }
            return View(produtoViewModel);            
        }
        public ActionResult Edit(int id)
        {
            RepositorioProduto rep = new RepositorioProduto();
            Produto produto = rep.BuscarProduto(id);
            
            if (produto == null)
            {
                return HttpNotFound();
            }
            var produtoViewModel = new ProdutoViewModel
            {
                IdProduto = produto.IdProduto,
                NomeProduto = produto.NomeProduto,
                QtdEstoque = produto.QtdEstoque,
                ValorCompra=produto.ValorCompra,
                ValorVenda=produto.ValorVenda
            };
            return View(produtoViewModel);
        }
        public ActionResult BuscarProduto(int id)
        {
            RepositorioProduto rep = new RepositorioProduto();
            Produto produto = rep.BuscarProduto(id);

            if (produto == null)
            {
                return HttpNotFound();
            }
            var produtoViewModel = new ProdutoViewModel
            {
                IdProduto = produto.IdProduto,
                NomeProduto = produto.NomeProduto,
                QtdEstoque = produto.QtdEstoque,
                ValorCompra = produto.ValorCompra,
                ValorVenda = produto.ValorVenda
            };
            return View( produtoViewModel);
        }
        public ActionResult BuscarProdutoId(int id)
        {
            RepositorioProduto rep = new RepositorioProduto();
            Produto produto = rep.BuscarProduto(id);

            if (produto == null)
            {
                return HttpNotFound();
            }
            var produtoViewModel = new ProdutoViewModel
            {
                IdProduto = produto.IdProduto,
                NomeProduto = produto.NomeProduto,
                QtdEstoque = produto.QtdEstoque,
                ValorCompra = produto.ValorCompra,
                ValorVenda = produto.ValorVenda
            };
            return Json(produtoViewModel, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult Edit(ProdutoViewModel produtoViewModel)
        {
            if (ModelState.IsValid)
            {                
                var produto = new Produto
                {
                    IdProduto=produtoViewModel.IdProduto,
                    NomeProduto = produtoViewModel.NomeProduto,
                    QtdEstoque = produtoViewModel.QtdEstoque,
                    ValorCompra = produtoViewModel.ValorCompra,
                    ValorVenda = produtoViewModel.ValorVenda
                };
                RepositorioProduto rep = new RepositorioProduto();
                rep.AlterarProduto(produto);
                return RedirectToAction("Index");
            }
            return View(produtoViewModel);
        }

        public ActionResult Delete(int id)
        {
            RepositorioProduto rep = new RepositorioProduto();
            rep.DeletarProduto(id);
            return RedirectToAction("Exibir");
        }
    }
}