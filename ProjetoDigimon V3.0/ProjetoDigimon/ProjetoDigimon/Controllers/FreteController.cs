using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Digimon.Aplicacao;
using Digimon.Dominio;

namespace ProjetoDigimon.Controllers
{
    public class FreteController : Controller
    {
        //
        // GET: /Frete/

        public ActionResult ui006cadastrarfrete()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ui006cadastrarfrete(ClasseFrete frete)
        {
            if (ModelState.IsValid)
            {
                var appFrete = new FreteAplicacao();
                appFrete.Salvar(frete);
                return RedirectToAction("ui006cadastrarfrete");
            }
            return View(frete);
        }
    }
}
