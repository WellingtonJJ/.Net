using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Digimon.Dominio;
using Digimon.Aplicacao;

namespace Digimon.Mvc.Controllers
{
    public class TransportadorAutoController : Controller
    {
        //
        // GET: /TransportadorAuto/
        public ActionResult TransportadorAuto()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult TransportadorAuto(TransportadorAutonomo Transportador)
        {
            if(ModelState.IsValid)
            {
            TransportadorAutoAplicacao transportador = new TransportadorAutoAplicacao();
                transportador.Inserir(Transportador);
            return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult AlterarTransportador()
        {
            TransportadorAutoAplicacao transpordor = new TransportadorAutoAplicacao();
            var listaDeTransportadores = transpordor.ListarTodos();
            return View(transpordor);
        }
        [HttpPost]
        public ActionResult AlterarTransportador()
        {
            return View();
        }
        }
}
