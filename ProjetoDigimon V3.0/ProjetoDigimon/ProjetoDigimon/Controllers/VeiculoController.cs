using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Digimon.Dominio;
using Digimon.Aplicacao;
using Digimon.Aplicacao;
using Digimon.Dominio;
<<<<<<< HEAD
=======

>>>>>>> 0a26a787690f86e728ec87eb95030461a296763c

namespace ProjetoDigimon.Controllers
{
    public class VeiculoController : Controller
    {
        public ActionResult ui008cadastrarveiculo()
        {
<<<<<<< HEAD
            var veiculo = new VeiculoAplicacao();
            var ListaTransportador = veiculo.ListarTransportador();
            return View(ListaTransportador);
=======

            var veiculo = new VeiculoAplicacao();
            var ListaTransportador = veiculo.ListarTransportador();
            return View(ListaTransportador);

            var veiculo = new ClasseVeiculo
            {

            };
            return View();

>>>>>>> 0a26a787690f86e728ec87eb95030461a296763c
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
