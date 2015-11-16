using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Digimon.Aplicacao;
using Digimon.Dominio;

namespace Digimon.Mvc.Controllers
{
    public class FreteController : Controller
    {
        //
        // GET: /Frete/

        public ActionResult Index()
        {
            var appFrete = new FreteAplicacao();
            var listadeFretes = appFrete.ListarTodos();
            return View(listadeFretes);
        }


        public ActionResult ui006cadastrarfrete()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ui006cadastrarfrete(Frete frete)
        {
            if (ModelState.IsValid)
            {
                var appFrete = new FreteAplicacao();
                appFrete.Inserir(frete);
                return RedirectToAction("Index");
            }
            return View(frete);
        }
    }
}
