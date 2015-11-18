using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Digimon.Mvc.Controllers
{
    public class relatorioController : Controller
    {
        //
        // GET: /relatorio/

        public ActionResult ui030relatorio()
        {


            var idusuario = Request.Cookies["userId"].Value;
            var permissao = Request.Cookies["permissao"].Value;

            if (string.IsNullOrEmpty(idusuario))
            {
                Response.Redirect("http://www.projetodigimon.com.br/ui002login.jsp");
            }

            if (!String.IsNullOrEmpty(permissao))
            {
                if ((permissao != "3"))
                {
                    Response.Redirect("http://www.projetodigimon.com.br/pagina-de-redirecionamento.jsp");
                }
            }

            return View();
        }

    }
}
