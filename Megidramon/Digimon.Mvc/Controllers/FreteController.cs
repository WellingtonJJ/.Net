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
            /* remover comentario aqui
            HttpCookie cookie = new HttpCookie("Usuario");
            cookie.Value = "3";		                         //VALOR FICTICIO PARA SIMULAR PERMISSÃO DO USUARIO LOGADO EM SISTEMA/ depois precisa criar uma ado aqui para buscar a permissão do usaurio no banco
            Response.Cookies.Add(cookie);
            var permissao = Request.Cookies["Usuario"].Value;

            if (string.IsNullOrEmpty(permissao))            // se cookie estiver vazio ou nullo, usuario nao está logado e será redirecionado para pagina de logim
            {	                                            //USUARIO NAO ESTÀ LOGADO // neste exemplo usuario será desviado para site g1, substiruir pagina por pagina logim
                Response.Redirect("http://g1.globo.com/index.html");
            }

            if (!String.IsNullOrEmpty(permissao))
            {
                if ((permissao != "3") && (permissao != "5") && (permissao != "6")) // unicas permissões permitida para este usuario, se for diferente de  3, 5 ou 6, usuario nao pode acessar
                {                                                                    // USUARIO NAO TEM PERMISSAO PARA ACESSAR ESTA PAGINA, será redirecionado para google, substituir para uma tela padrão de nao permitido
                    Response.Redirect("https://www.google.com.br/webhp?hl=pt-BR");
                }
            }


            /*  OBS SE USUARIO PASSAR POR CONDIUÇÕES ACIMA, ELE TEM PERMISSÃO PARA ACESSAR A PAGINA, ENTAO ABAIXO DESTE COMENTARIO
             *  SISTEMA SEGUE NORMALMENTE     remover comentario aqui */

            return View();
        }

        [HttpPost]
        public ActionResult ui006cadastrarfrete(Frete frete)
        {
            /*
            HttpCookie cookie = new HttpCookie("Usuario");
            cookie.Value = "3";	                            //VALOR FICTICIO PARA SIMULAR PERMISSÃO DO USUARIO LOGADO EM SISTEMA/ depois precisa criar uma ado aqui para buscar a permissão do usaurio no banco
            Response.Cookies.Add(cookie);
            var permissao = Request.Cookies["Usuario"].Value;


            if (string.IsNullOrEmpty(permissao))                // se cookie estiver vazio ou nullo, usuario nao está logado e será redirecionado para pagina de logim
            {	//USUARIO NAO ESTÀ LOGADO                       //USUARIO NAO ESTÀ LOGADO // neste exemplo usuario será desviado para site g1, substiruir pagina por pagina logim
                Response.Redirect("http://g1.globo.com/index.html");
            }

            if (!String.IsNullOrEmpty(permissao))
            {
                if ((permissao != "3") && (permissao != "5") && (permissao != "6")) // unicas permissões permitida para este usuario, se for diferente de  3, 5 ou 6, usuario nao pode acessar
                {                                                                    // USUARIO NAO TEM PERMISSAO PARA ACESSAR ESTA PAGINA / // USUARIO NAO TEM PERMISSAO PARA ACESSAR ESTA PAGINA, será redirecionado para google, substituir para uma tela padrão de nao permitido
                    Response.Redirect("https://www.google.com.br/webhp?hl=pt-BR");
                }
            }

            /*  OBS SE USUARIO PASSAR POR CONDIUÇÕES ACIMA, ELE TEM PERMISSÃO PARA ACESSAR A PAGINA, ENTAO ABAIXO DESTE COMENTARIO
             *  SISTEMA SEGUE NORMALMENTE */

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
