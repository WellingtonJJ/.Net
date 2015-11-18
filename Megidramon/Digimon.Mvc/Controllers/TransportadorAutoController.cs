using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Digimon.Dominio;
using Digimon.Aplicacao;

namespace Digimon.Mvc.Controllers
{
    public class transportadorautoController : Controller
    {
        //
        // GET: /TransportadorAuto/
        public ActionResult TransportadorAuto()
        {
            
            var idusuario = Request.Cookies["userId"].Value;
            var permissao = Request.Cookies["permissao"].Value;

            if (string.IsNullOrEmpty(idusuario))
            {
                Response.Redirect("http://www.projetodigimon.com.br/ui002login.jsp");
            }

            if (!String.IsNullOrEmpty(permissao))
            {
                if ((permissao != "3") && (permissao != "5"))
                {
                    Response.Redirect("http://www.projetodigimon.com.br/pagina-de-redirecionamento.jsp");
                }
            }
             
             

            return View();
        }
        
        [HttpPost]
        public ActionResult TransportadorAuto(TransportadorAutonomo Transportador)
        {

            
            var idusuario = Request.Cookies["userId"].Value;
            var permissao = Request.Cookies["permissao"].Value;

            if (string.IsNullOrEmpty(idusuario))
            {
                Response.Redirect("http://www.projetodigimon.com.br/ui002login.jsp");
            }

            if (!String.IsNullOrEmpty(permissao))
            {
                if ((permissao != "3") && (permissao != "5"))
                {
                    Response.Redirect("http://www.projetodigimon.com.br/pagina-de-redirecionamento.jsp");
                }
            }
             
             

            if(ModelState.IsValid)
            {
            TransportadorAutoAplicacao transportador = new TransportadorAutoAplicacao();
                transportador.Inserir(Transportador);
            return RedirectToAction("Index");
            }
            return View();
        }

        /* public ActionResult AlterarTransportador()
          {
              TransportadorAutoAplicacao transpordor = new TransportadorAutoAplicacao();
              var listaDeTransportadores = transpordor.ListarTodos();
              return View(transpordor);
          }
          [HttpPost]
          public ActionResult AlterarTransportador()
          {
              return View();
          }*/
    }
}
