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
        public ActionResult ui020cadastrarmotorista(Motorista motorista)
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
                var appMotorista = new MotoristaAplicacao();
                appMotorista.Salvar(motorista);
                return RedirectToAction("Index");
            }
            return View(motorista);
        }

        public ActionResult Alterar(int id)
        {
                /* cookie = new HttpCookie("Usuario");
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
                }    */   


            var appMotorista = new MotoristaAplicacao();
            var motorista = appMotorista.ListarMotorista(id);

            if (motorista == null)
                HttpNotFound();

            return View(motorista);
        }

        [HttpPost]
        public ActionResult Alterar(Motorista motorista)
        {

                    /*HttpCookie cookie = new HttpCookie("Usuario");
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
                        var appMotorista = new MotoristaAplicacao();
                        appMotorista.Salvar(motorista);
                        return RedirectToAction("Index");
                    }
            return View(motorista);
        }

        public ActionResult Detalhes(int id)
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
                    }*/

            var appMotorista = new MotoristaAplicacao();
            var motorista = appMotorista.ListarMotorista(id);

            if (motorista == null)
                HttpNotFound();

            return View(motorista);
        }

    }
}
