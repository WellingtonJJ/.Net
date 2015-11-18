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

                
                    var idusuario = Request.Cookies["userId"].Value;
                    var permissao = Request.Cookies["permissao"].Value;

                    if (string.IsNullOrEmpty(idusuario))
                    {
                        Response.Redirect("http://www.projetodigimon.com.br/ui002login.jsp");
                    }

                    if (!String.IsNullOrEmpty(permissao))
                    {
                        if ((permissao != "3") && (permissao != "1"))
                        {
                            Response.Redirect("http://www.projetodigimon.com.br/pagina-de-redirecionamento.jsp");
                        }
                    }
                 
                 


            var appTransportador = new TransportadorEmpAplicacao();
            var listadeTransportadores = appTransportador.ListarTodos();
            return View(listadeTransportadores);
        }

        public ActionResult CadastrarTransportadorEmp()
        {
            
                var idusuario = Request.Cookies["userId"].Value;
                var permissao = Request.Cookies["permissao"].Value;

                if (string.IsNullOrEmpty(idusuario))
                {
                    Response.Redirect("http://www.projetodigimon.com.br/ui002login.jsp");
                }

                if (!String.IsNullOrEmpty(permissao))
                {
                    if ((permissao != "3") && (permissao != "1"))
                    {
                        Response.Redirect("http://www.projetodigimon.com.br/pagina-de-redirecionamento.jsp");
                    }
                }
             
             
            return View();
        }

        [HttpPost]
        public ActionResult CadastrarTransportadorEmp(TransportadorEmpresa transportador)
        {
            
            var idusuario = Request.Cookies["userId"].Value;
            var permissao = Request.Cookies["permissao"].Value;

            if (string.IsNullOrEmpty(idusuario))
            {
                Response.Redirect("http://www.projetodigimon.com.br/ui002login.jsp");
            }

            if (!String.IsNullOrEmpty(permissao))
            {
                if ((permissao != "3") && (permissao != "1"))
                {
                    Response.Redirect("http://www.projetodigimon.com.br/pagina-de-redirecionamento.jsp");
                }
            }
             
             

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
