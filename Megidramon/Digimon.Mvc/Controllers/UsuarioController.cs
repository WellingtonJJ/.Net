using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Digimon.Dominio;
using Digimon.Aplicacao;

namespace Digimon.Mvc.Controllers
{
    public class UsuarioController : Controller
    {
        //
        // GET: /Usuario/

        public ActionResult ui012cadastrarusuario()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ui012cadastrarusuario(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                var appUsuario = new UsuarioAplicacao();
                appUsuario.Inserir(usuario);
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
