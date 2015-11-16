using System.Web.Mvc;
using Digimon.Aplicacao;
using Digimon.Dominio;

namespace Digimon.Mvc.Controllers
{
    public class MotoristaController : Controller
    {
        //
        // GET: /Motorista/

        public ActionResult Index()
        {
            var appMotorista = new MotoristaAplicacao();
            var listadeMotoristas = appMotorista.ListarTodos();
            return View(listadeMotoristas);
        }

        public ActionResult ui020cadastrarmotorista()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ui020cadastrarmotorista(Motorista motorista)
        {
            if (ModelState.IsValid)
            {
                var appMotorista = new MotoristaAplicacao();
                appMotorista.Salvar(motorista);
                return RedirectToAction("Index");
            }
            return View(motorista);
        }

        public ActionResult Alterar(int id)
        {
            var appMotorista = new MotoristaAplicacao();
            var motorista = appMotorista.ListarMotorista(id);

            if (motorista == null)
                HttpNotFound();

            return View(motorista);
        }

        [HttpPost]
        public ActionResult Alterar(Motorista motorista)
        {
            if (ModelState.IsValid)
            {
                var appMotorista = new MotoristaAplicacao();
                appMotorista.Salvar(motorista);
                return RedirectToAction("Index");
            }
            return View(motorista);
        }

        public ActionResult Detalhes(int id)
        {
            var appMotorista = new MotoristaAplicacao();
            var motorista = appMotorista.ListarMotorista(id);

            if (motorista == null)
                HttpNotFound();

            return View(motorista);
        }

    }
}
