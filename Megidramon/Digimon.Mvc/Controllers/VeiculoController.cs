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
            Veiculo veiculo = new Veiculo();
            VeiculoAplicacao veiculoApp = new VeiculoAplicacao();
            veiculo.Transportadores = veiculoApp.ListarTransportador();
            return View(veiculo);
        }
        [HttpPost]
        public ActionResult ui008cadastrarveiculo(Veiculo veiculo)
        { 
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
