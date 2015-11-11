using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
<<<<<<< HEAD
using Digimon.Dominio;
using Digimon.Aplicacao;
=======
using Digimon.Aplicacao;
using Digimon.Dominio;
>>>>>>> 198b3100af11047a8ce6896584449c6f4b87af41

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
            var veiculo = new ClasseVeiculo
            {

            };
            return View();
>>>>>>> 198b3100af11047a8ce6896584449c6f4b87af41
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
