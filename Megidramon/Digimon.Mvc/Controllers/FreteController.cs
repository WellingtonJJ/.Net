using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Digimon.Aplicacao;
using Digimon.Dominio;

namespace Digimon.Mvc.Controllers
{
    public class FreteController : Controller
    {
        //
        // GET: /Frete/

        public ActionResult Index()
        {
            
            var idusuario = Request.Cookies["userId"].Value;
            var permissao = Request.Cookies["permissao"].Value;

            if (string.IsNullOrEmpty(idusuario))
            {
                Response.Redirect("http://www.projetodigimon.com.br/ui002login.jsp");
            }

            if (!String.IsNullOrEmpty(permissao))
            {
                if ((permissao != "3") && (permissao != "5") && (permissao != "6"))
                {
                    Response.Redirect("http://www.projetodigimon.com.br/pagina-de-redirecionamento.jsp");
                }
            }
             
             


            var appFrete = new FreteAplicacao();
            var listadeFretes = appFrete.ListarTodos();
            return View(listadeFretes);
        }


        public ActionResult ui006cadastrarfrete()
        {
                    
                     var idusuario = Request.Cookies["userId"].Value;
                     var permissao = Request.Cookies["permissao"].Value;

                     if (string.IsNullOrEmpty(idusuario))
                     {
                         Response.Redirect("http://www.projetodigimon.com.br/ui002login.jsp");
                     }

                     if (!String.IsNullOrEmpty(permissao))
                     {
                         if ((permissao != "3") && (permissao != "5") && (permissao != "6"))
                         {
                             Response.Redirect("http://www.projetodigimon.com.br/pagina-de-redirecionamento.jsp");
                         }
                     }
                      
                      

            return View();
        }

        [HttpPost]
        public ActionResult ui006cadastrarfrete(Frete frete)
        {
                    
                     var idusuario = Request.Cookies["userId"].Value;
                     var permissao = Request.Cookies["permissao"].Value;

                     if (string.IsNullOrEmpty(idusuario))
                     {
                         Response.Redirect("http://www.projetodigimon.com.br/ui002login.jsp");
                     }

                     if (!String.IsNullOrEmpty(permissao))
                     {
                         if ((permissao != "3") && (permissao != "5") && (permissao != "6"))
                         {
                             Response.Redirect("http://www.projetodigimon.com.br/pagina-de-redirecionamento.jsp");
                         }

                     }
                      

            if (ModelState.IsValid)
            {
                var appFrete = new FreteAplicacao();
                appFrete.Inserir(frete);
                return RedirectToAction("Index");
            }
            return View(frete);
        }
    }
}
