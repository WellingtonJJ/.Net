using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Digimon.Aplicacao;
using Digimon.Dominio;

namespace ProjetoDigimon.Controllers
{
    public class MotoristaController : Controller
    {  
         public ActionResult ui020cadastrarmotorista()
         {
             return View();
         }


        [HttpPost]
         public ActionResult ui020cadastrarmotorista(ClasseMotorista motorista)
        {
            if (ModelState.IsValid)
            {
                var appMotorista = new MotoristaAplicacao();
                appMotorista.Salvar(motorista);
                return RedirectToAction("ui020cadastrarmotorista");
            }
            return View(motorista);
        }


    }
}
