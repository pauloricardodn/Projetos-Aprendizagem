using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SMN.Musicas.AcessoDados.Entity.Context;
using SMN.Musicas.Dominio;
using AutoMapper;
using Musicas.Web.ViewModel.Album;
using SMN.Repositorio.Comum;
using SMN.Musicas.Repositorio.Entity;

namespace Musicas.Web.Controllers
{
    [Authorize]
    public class AlbumsController : Controller
    {
        
        private IRepositorioGenerico<Album, int> repositorioAlbum
            =new AlbunsRepositorio(new MusicasDbContext());


        public ActionResult FiltrarPorAlbum(string pesquisa)
        {
            List<Album> albuns = repositorioAlbum.Selecionar().Where(a=>a.Nome.Contains(pesquisa)).ToList();
            List<AlbumIndexViewModel> viewmodel = Mapper.Map<List<Album>, List<AlbumIndexViewModel>>(albuns);
            return Json(viewmodel, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Index()
        {
            return View(Mapper.Map<List<Album>,List<AlbumIndexViewModel>>(repositorioAlbum.Selecionar()));
        }

        // GET: Albums/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            Album album = repositorioAlbum.SelecionaPorID(id.Value);

            if (album == null)
            {
                return HttpNotFound();
            }
            return View(Mapper.Map<Album,AlbumIndexViewModel>(album));
        }

        // GET: Albums/Create
        [Authorize(Roles ="ADMINISTRADOR")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Albums/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,Ano,Observacoes,Email")] AlbumViewModel ViewModel)
        {
            if (ModelState.IsValid)
            {
                Album album = Mapper.Map<AlbumViewModel,Album>(ViewModel);
                repositorioAlbum.Inserir(album);
               
                return RedirectToAction("Index");
            }

            return View(ViewModel);
        }

        // GET: Albums/Edit/5
        [Authorize(Roles = "ADMINISTRADOR")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Album album = repositorioAlbum.SelecionaPorID(id.Value);
            if (album == null)
            {
                return HttpNotFound();
            }

            return View(Mapper.Map<Album,AlbumViewModel>(album));
        }

        // POST: Albums/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Ano,Observacoes,Email")] AlbumViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Album album = Mapper.Map<AlbumViewModel,Album>(viewModel);
                repositorioAlbum.Alterar(album);
                
                return RedirectToAction("Index");
            }
            return View(viewModel);
        }

        // GET: Albums/Delete/5
        [Authorize(Roles = "ADMINISTRADOR")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Album album = repositorioAlbum.SelecionaPorID(id.Value);
            if (album == null)
            {
                return HttpNotFound();
            }
            return View(Mapper.Map<Album,AlbumIndexViewModel> (album));
        }

        // POST: Albums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Album album = repositorioAlbum.SelecionaPorID(id);
            repositorioAlbum.Excluir(album);
            return RedirectToAction("Index");
        }

        
    }
}
