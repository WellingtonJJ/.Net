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

            /*
            var idusuario = Request.Cookies["userId"].Value;
            var permissao = Request.Cookies["permissao"].Value;

            if (string.IsNullOrEmpty(idusuario))
            {
                Response.Redirect("http://www.projetodigimon.com.br/ui002login.jsp");
            }

            if (!String.IsNullOrEmpty(permissao))
            {
                if ((permissao != "3") && (permissao != "1") && (permissao != "2") && (permissao != "4") && (permissao != "6"))
                {
                    Response.Redirect("http://www.projetodigimon.com.br/pagina-de-redirecionamento.jsp");
                }
            }
            */

            return View();
        }
        [HttpPost]
        public ActionResult ui012cadastrarusuario(Usuario usuario)
        {

                /*
               var idusuario = Request.Cookies["userId"].Value;
               var permissao = Request.Cookies["permissao"].Value;

               if (string.IsNullOrEmpty(idusuario))
               {
                   Response.Redirect("http://www.projetodigimon.com.br/ui002login.jsp");
               }

               if (!String.IsNullOrEmpty(permissao))
               {
                   if ((permissao != "3") && (permissao != "1") && (permissao != "2") && (permissao != "4") && (permissao != "6"))
                   {
                       Response.Redirect("http://www.projetodigimon.com.br/pagina-de-redirecionamento.jsp");
                   }
               }
               */




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
