using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjetoDigimon.Models;

namespace ProjetoDigimon.Controllers
{
    public class VeiculoController : Controller
    {
        public ActionResult ui008cadastrarveiculo()
        {
            var veiculo = new ClasseVeiculo
            {

            };
            return View();
        }
        [HttpPost]
        public ActionResult ui008cadastrarveiculo(ClasseVeiculo veiculo)
        {
            return View();
        }
    }
}
