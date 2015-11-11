using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Digimon.Dominio;
using Digimon.Aplicacao;
using Digimon.Aplicacao;
using Digimon.Dominio;

namespace ProjetoDigimon.Controllers
{
    public class VeiculoController : Controller
    {
        public ActionResult ui008cadastrarveiculo()
        {
            var veiculo = new VeiculoAplicacao();
            var ListaTransportador = veiculo.ListarTransportador();
            return View(ListaTransportador);
        }
        [HttpPost]
        public ActionResult ui008cadastrarveiculo(ClasseVeiculo veiculo)
        {
            if(ModelState.IsValid)
            {
                var appVeiculo = new VeiculoAplicacao();
                appVeiculo.Salvar(veiculo);
                return RedirectToAction("ui020cadastrarmotorista");
            }
            return View();
        }
    }
}
