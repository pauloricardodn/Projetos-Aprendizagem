using SMN.Administracao.Dominio;
using SMN.Administracao.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Administracao.Web.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult Cadastrar()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                RepositorioUsuario rep = new RepositorioUsuario();
                Usuario usuarioRetorno = new Usuario();
                usuarioRetorno = rep.AutenticarUsuario(usuario.Login, usuario.Senha);
                if (usuarioRetorno.Nome == null)
                {
                    ModelState.AddModelError("erro", "Usuario não encontrado ou senha errada");
                    return View(usuario);
                }else
                {
                    
                    if (usuarioRetorno.Nome!=null)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }    
            }
             return View(usuario);
        }
    }
}