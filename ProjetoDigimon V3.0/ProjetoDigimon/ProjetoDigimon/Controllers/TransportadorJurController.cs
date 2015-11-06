using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Digimon.Aplicacao;
using Digimon.Dominio;

namespace ProjetoDigimon.Controllers
{
    public class TransportadorJurController : Controller
    {
        //
        // GET: /Transportador/
        //ui010 é a tela cadastrartransportador
        public ActionResult ui010cadastrartransportadorjur()
        {
            return View();
        }

    }
}
