using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Digimon.Aplicacao;
using Digimon.Dominio;

namespace Digimon.Mvc.Controllers
{
    public class TransportadorEmpController : Controller
    {
        //
        // GET: /TransportadorEmp/

        public ActionResult Index()
        {
            var appTransportador = new TransportadorEmpAplicacao();
            var listadeTransportadores = appTransportador.ListarTodos();
            return View(listadeTransportadores);
        }

        public ActionResult CadastrarTransportadorEmp()
        {
            /*
            HttpCookie cookie = new HttpCookie("Usuario");
            cookie.Value = "";
            Response.Cookies.Add(cookie);
            var permissao = Request.Cookies["Usuario"].Value;

            if (string.IsNullOrEmpty(permissao))
            {	//USUARIO NAO ESTÀ LOGADO
                Response.Redirect("http://g1.globo.com/index.html");
            }

            if (!String.IsNullOrEmpty(permissao))
            {
                if ((permissao != "3") && (permissao != "5") && (permissao != "6"))
                {  // USUARIO NAO TEM PERMISSAO PARA ACESSAR ESTA PAGINA
                    Response.Redirect("https://www.google.com.br/webhp?hl=pt-BR");
                }
            }*/
            return View();
        }

        [HttpPost]
        public ActionResult CadastrarTransportadorEmp(TransportadorEmpresa transportador)
        {

            /* HttpCookie cookie = new HttpCookie("Usuario");
             cookie.Value = "";
             Response.Cookies.Add(cookie);
             var permissao = Request.Cookies["Usuario"].Value;

             if (string.IsNullOrEmpty(permissao))
             {	//USUARIO NAO ESTÀ LOGADO
                 Response.Redirect("http://g1.globo.com/index.html");
             }

             if (!String.IsNullOrEmpty(permissao))
             {
                 if ((permissao != "3") && (permissao != "5") && (permissao != "6"))
                 {  // USUARIO NAO TEM PERMISSAO PARA ACESSAR ESTA PAGINA
                     Response.Redirect("https://www.google.com.br/webhp?hl=pt-BR");
                 }
             } */

            if (ModelState.IsValid)
            {
                var appTransportador = new TransportadorEmpAplicacao();
                appTransportador.Inserir(transportador);
                return RedirectToAction("Index");
            }
            return View(transportador);
        }

    }
}
