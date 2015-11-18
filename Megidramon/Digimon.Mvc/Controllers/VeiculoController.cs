using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Digimon.Aplicacao;
using Digimon.Dominio;

namespace Digimon.Mvc.Controllers
{
    public class VeiculoController : Controller
    {
        //
        // GET: /Veiculo/

        public ActionResult ui008cadastrarveiculo()
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
                      


            Veiculo veiculo = new Veiculo();
            VeiculoAplicacao veiculoApp = new VeiculoAplicacao();
            veiculo.Transportadores = veiculoApp.ListarTransportador();
            return View(veiculo);
        }
        [HttpPost]
        public ActionResult ui008cadastrarveiculo(Veiculo veiculo)
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
                     


            if(ModelState.IsValid)
            {
                var appVeiculo = new VeiculoAplicacao();
                appVeiculo.Salvar(veiculo);
                return RedirectToAction("ui008cadastrarveiculo");
            }
            return View();
        }
    }
}
