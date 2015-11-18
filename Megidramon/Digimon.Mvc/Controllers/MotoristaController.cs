using System.Web.Mvc;
using Digimon.Aplicacao;
using Digimon.Dominio;
using System.Web;
using System;

namespace Digimon.Mvc.Controllers
{
    public class MotoristaController : Controller
    {
        //
        // GET: /Motorista/

        public ActionResult Index()
        {
            var appMotorista = new MotoristaAplicacao();
            var listadeMotoristas = appMotorista.ListarTodos();
            return View(listadeMotoristas);
        }

        public ActionResult ui020cadastrarmotorista()
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
                            if ((permissao != "3") && (permissao != "5") && (permissao != "6"))
                            {
                                Response.Redirect("http://www.projetodigimon.com.br/pagina-de-redirecionamento.jsp");
                            }
                        }
            */

            return View();
        }

        [HttpPost]
        public ActionResult ui020cadastrarmotorista(Motorista motorista)
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
                            if ((permissao != "3") && (permissao != "5") && (permissao != "6"))
                            {
                                Response.Redirect("http://www.projetodigimon.com.br/pagina-de-redirecionamento.jsp");
                            }
                        }
            */

            if (ModelState.IsValid)
            {
                var appMotorista = new MotoristaAplicacao();
                appMotorista.Salvar(motorista);
                return RedirectToAction("Index");
            }
            return View(motorista);
        }

        public ActionResult Alterar(int id)
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
                       if ((permissao != "3") && (permissao != "5") && (permissao != "6"))
                       {
                           Response.Redirect("http://www.projetodigimon.com.br/pagina-de-redirecionamento.jsp");
                       }
                   }
       */


            var appMotorista = new MotoristaAplicacao();
            var motorista = appMotorista.ListarMotorista(id);

            if (motorista == null)
                HttpNotFound();

            return View(motorista);
        }

        [HttpPost]
        public ActionResult Alterar(Motorista motorista)
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
                            if ((permissao != "3") && (permissao != "5") && (permissao != "6"))
                            {
                                Response.Redirect("http://www.projetodigimon.com.br/pagina-de-redirecionamento.jsp");
                            }
                        }
            */

                    if (ModelState.IsValid)
                    {
                        var appMotorista = new MotoristaAplicacao();
                        appMotorista.Salvar(motorista);
                        return RedirectToAction("Index");
                    }
            return View(motorista);
        }

        public ActionResult Detalhes(int id)
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
                             if ((permissao != "3") && (permissao != "5") && (permissao != "6"))
                             {
                                 Response.Redirect("http://www.projetodigimon.com.br/pagina-de-redirecionamento.jsp");
                             }
                         }
             */
            var appMotorista = new MotoristaAplicacao();
            var motorista = appMotorista.ListarMotorista(id);

            if (motorista == null)
                HttpNotFound();

            return View(motorista);
        }

    }
}
