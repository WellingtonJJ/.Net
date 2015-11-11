using System.Text;
using System.Threading.Tasks;
using Digimon.Dominio;
using Digimon.Repositorio;
using System.Data;
using System.Data.SqlClient;

namespace Digimon.Aplicacao
{
   public class FreteAplicacao
    {
       private Contexto contexto;

       private void Inserir(ClasseFrete frete)
       {
           var strQuery = "";

           strQuery += "INSERT INTO FRETE(TIPO, SITUACAO)";
           strQuery += string.Format("VALUES('{O}', '{1}'})", frete.Tipo, frete.Situacao);
       
       }
   }
}
