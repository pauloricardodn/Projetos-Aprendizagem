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
using SMN.Repositorio.Comum;
using SMN.Musicas.Repositorio.Entity;
using AutoMapper;
using Musicas.Web.ViewModel.Musica;
using Musicas.Web.ViewModel.Album;

namespace Musicas.Web.Controllers
{
    [Authorize]
    public class MusicasController : Controller
    {
        //repositorio de musicas
        private IRepositorioGenerico<Musica, int> repositorioMusica
           = new MusicaRepositorio(new MusicasDbContext());

        //repositorio de album
        private IRepositorioGenerico<Album, int> repositorioAlbum
           = new AlbunsRepositorio(new MusicasDbContext());

        
      
        // GET: Musicas

        public ActionResult Index()
        {
            return View(Mapper.Map<List<Musica>,List<MusicaExibicaoViewModel>>(repositorioMusica.Selecionar()))                ;
        }

        // GET: Musicas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Musica musica = repositorioMusica.SelecionaPorID(id.Value);
            if (musica == null)
            {
                return HttpNotFound();
            }
            return View(Mapper.Map<Musica,MusicasViewModel>(musica));
        }

        // GET: Musicas/Create
        [Authorize(Roles = "ADMINISTRADOR")]
        public ActionResult Create()
        {
            List<AlbumIndexViewModel> album = Mapper.Map<List<Album>, List<AlbumIndexViewModel>>(repositorioAlbum.Selecionar());
            SelectList dropDownAlbum = new SelectList(album, "Id", "Nome");
            ViewBag.dropDownAlbum = dropDownAlbum; 

            return View();
        }

        // POST: Musicas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,IdAlbum")] MusicasViewModel musicavewmodel)
        {
            if (ModelState.IsValid)
            {
                Musica musica = Mapper.Map<MusicasViewModel, Musica>(musicavewmodel);
                repositorioMusica.Inserir(musica);
                
                return RedirectToAction("Index");
            }

            return View(musicavewmodel);
        }

        // GET: Musicas/Edit/5
        [Authorize(Roles = "ADMINISTRADOR")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Musica musica = repositorioMusica.SelecionaPorID(id.Value);
            if (musica == null)
            {
                return HttpNotFound();
            }
            List<AlbumIndexViewModel> album = Mapper.Map<List<Album>, List<AlbumIndexViewModel>>(repositorioAlbum.Selecionar());
            SelectList dropDownAlbum = new SelectList(album, "Id", "Nome");
            ViewBag.dropDownAlbum = dropDownAlbum;
            return View(Mapper.Map<Musica, MusicasViewModel>(musica));
        }

        // POST: Musicas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,IdAlbum")] MusicasViewModel musicasviewmodel)
        {
            if (ModelState.IsValid)
            {
                Musica musica = Mapper.Map<MusicasViewModel, Musica>(musicasviewmodel);
                repositorioMusica.Alterar(musica);
                //db.Entry(musica).State = EntityState.Modified;
                //db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(musicasviewmodel);
        }

        // GET: Musicas/Delete/5
        [Authorize(Roles = "ADMINISTRADOR")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Musica musica =repositorioMusica.SelecionaPorID(id.Value);
            if (musica == null)
            {
                return HttpNotFound();
            }
            return View(Mapper.Map<Musica, MusicaExibicaoViewModel>(musica));
        }

        // POST: Musicas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            
            repositorioMusica.ExcluirPorId(id);
            return RedirectToAction("Index");
        }

        
   }
}

