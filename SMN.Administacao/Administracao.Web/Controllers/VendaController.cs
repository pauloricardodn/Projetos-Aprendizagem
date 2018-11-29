using Administracao.Web.ViewModel.Cliente;
using Administracao.Web.ViewModel.Funcionarios;
using Administracao.Web.ViewModel.Produto;
using Administracao.Web.ViewModel.Venda;
using Administracao.Web.ViewModel.VendaItem;
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
    public class VendaController : Controller
    {
       
        RepositorioProduto repProduto = new RepositorioProduto();
        RepositorioCliente repCliente = new RepositorioCliente();
        RepositorioVenda repVenda = new RepositorioVenda();


        // GET: Venda
        public ActionResult Venda()
        {
            var produto = repProduto.SelecionarProduto().ToList();
            var produtoViewModel = produto.Select(x => new ProdutoViewModel {
                IdProduto=x.IdProduto,
                NomeProduto=x.NomeProduto
            });
            var cliente = repCliente.ListarCliente().ToList();
            var clienteViewModel = cliente.Select(x => new ClienteViewModel {
                IdCliente=x.IdCliente,
                Nome=x.Nome
            });
            var model = new VendaViewModel();

            model.ProdutoVenda = new SelectList(produtoViewModel, "IdProduto", "NomeProduto");
            model.ClienteVenda = new SelectList(clienteViewModel, "IdCliente", "Nome");

            return View("Venda", model);
        }
        [HttpPost]
        public ActionResult Venda(VendaViewModel vendaViewModel)
        {  
            var venda = new Venda
            {
                IdVenda = vendaViewModel.IdVenda,
                IdCliente = vendaViewModel.IdCliente,
                VendaItem = vendaViewModel.VendaItem.Select(x => new VendaItem
                {
                    IdVenda = x.IdVendaItem,
                    IdProduto = x.IdProduto,
                    Qtd = x.Qtd,
                    ValorUnitario = x.ValorUnitario
                })
            };
            venda.DataVenda = DateTime.Now;
            repVenda.RealizarVenda(venda);
            return RedirectToAction("Exibir", "Venda");       
        }
        [HttpPost]
        public ActionResult EditarVenda(VendaViewModel vendaViewModel)
        {
            var venda = new Venda
            {
                IdVenda = vendaViewModel.IdVenda,
                IdCliente=vendaViewModel.IdCliente                   
            };
            if (vendaViewModel.VendaItem != null)
            {
                venda.VendaItem = vendaViewModel.VendaItem.Select(x => new VendaItem
                {
                    IdVendaItem = x.IdVendaItem,
                    IdVenda = x.IdVenda,
                    IdProduto = x.IdProduto,
                    Qtd = x.Qtd,
                    ValorUnitario = x.ValorUnitario
                });
            };
            if (vendaViewModel.ItemDeletar != null)
            {
                venda.ItemDeletar = vendaViewModel.ItemDeletar.Select(x => new VendaItem
                {
                    IdVendaItem = x.IdVendaItem
                });
            };

            repVenda.EditarVenda(venda);
            return RedirectToAction("Exibir");
        }
        public ActionResult Exibir()
        {
            var venda = repVenda.ListarVenda().ToList();

            var vendaViewModel = venda.Select(x => new VendaViewModel
            {
                IdVenda=x.IdVenda,
                Cliente=new ClienteViewModel
                {
                    IdCliente=x.Cliente.IdCliente,
                    Nome=x.Cliente.Nome
                },
                DataVenda=x.DataVenda,
                ValorTotalVenda=x.ValorTotalVenda
            });

            return View(vendaViewModel);
            
        }
        public ActionResult Detalhes(int id)
        {
            
            Venda venda = repVenda.BuscarVenda(id);
            if (venda == null)
            {
                return HttpNotFound();
            }
            var vendaViewModel = new VendaViewModel
            {
                IdVenda = venda.IdVenda,
                IdCliente = venda.IdCliente,
                Cliente= new ClienteViewModel
                {
                    IdCliente=venda.Cliente.IdCliente,
                    Nome=venda.Cliente.Nome
                 },
                VendaItem=venda.VendaItem.Select(x=> new VendaItemViewModel {
                    Produto= new ProdutoViewModel
                    {
                        IdProduto=x.Produto.IdProduto,
                        NomeProduto=x.Produto.NomeProduto
                    },
                    IdVenda=x.IdVenda,
                    IdProduto=x.IdProduto,
                    Qtd=x.Qtd,
                    ValorUnitario=x.ValorUnitario
                }),
                ValorTotalVenda=venda.ValorTotalVenda                
            };
            return View(vendaViewModel);
        }
        [HttpGet]
        public ActionResult EditarVenda(int id)
        {

            Venda venda = repVenda.BuscarVenda(id);
            var vendaViewModel = new VendaViewModel
            {
                IdVenda = venda.IdVenda,
                IdCliente = venda.IdCliente,
                Cliente = new ClienteViewModel
                {
                    IdCliente = venda.Cliente.IdCliente,
                    Nome = venda.Cliente.Nome
                },
                VendaItem = venda.VendaItem.Select(x => new VendaItemViewModel
                {
                    Produto = new ProdutoViewModel
                    {
                        IdProduto = x.Produto.IdProduto,
                        NomeProduto = x.Produto.NomeProduto
                    },
                    IdVenda = x.IdVenda,
                    IdProduto = x.IdProduto,
                    Qtd = x.Qtd,
                    ValorUnitario = x.ValorUnitario,
                    ValorTotalItem=x.ValorTotalItem
                }),
                ValorTotalVenda = venda.ValorTotalVenda
            };

            var produto = repProduto.SelecionarProduto().ToList();
            var produtoViewModel = produto.Select(x => new ProdutoViewModel
            {
                IdProduto = x.IdProduto,
                NomeProduto = x.NomeProduto
            });
            var cliente = repCliente.ListarCliente().ToList();
            var clienteViewModel = cliente.Select(x => new ClienteViewModel
            {
                IdCliente = x.IdCliente,
                Nome = x.Nome
            });
            var model = new VendaViewModel();
            model = vendaViewModel;
            model.ProdutoVenda = new SelectList(produtoViewModel, "IdProduto", "NomeProduto");
            model.ClienteVenda = new SelectList(clienteViewModel, "IdCliente", "Nome");
            
            if (venda == null)
            {
                return HttpNotFound();
            }
            return View("EditarVenda", model);
        }
    }
}