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

    }
}
