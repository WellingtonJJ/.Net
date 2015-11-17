using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Digimon.Dominio;
using Repositorio;

namespace Digimon.Aplicacao
{
    public class UsuarioAplicacao
    {
        private Contexto contexto;

        public void Inserir(Usuario usuario)
        {
            var strQuery = "";
    
            //CONTATO INSERÇÃO
            strQuery += "INSERT INTO CONTATO(TELEFONE, CELULAR, EMAIL)";
            strQuery += string.Format("VALUES('{0}','{1}','{2}',)", usuario.Telefone, usuario.Celular, usuario.Email);
            strQuery +="DECLARE @IdContato int SET @IdContato = (SELECT IDENT_CURRENT('CONTATO')) ";
            //PESSOA FISICA
            strQuery += "DECLARE @IdAcesso int SET @IdAcesso = (SELECT IDENT_CURRENT('ACESSO')) ";
            strQuery += "INSERT INTO PESSOAFISICA (IDCONTATO, NOME, CPF, DATANASCIMENTO, RG, UF_PF, ORGAOEMISSOR, SEXO)";
            strQuery += string.Format("VALUES (@IdContato,  '{0}', '{1}', '{2}','{3}','{4}','{5}','{6}') ", usuario.Nome, usuario.CPF,
                                      usuario.DataNascimento, usuario.RG, usuario.UF_PF, usuario.OrgaoEmissor);
            //ACESSO
            strQuery += "INSERT INTO ACESSO (USUARIO, SENHA, TIPOPESSOA, TIPOUSUARIO, PERGUNTA, RESPOSTA, IDCONTATO)";
            strQuery += string.Format("VALUES ('{0}', '{1}', 'J', 'A', '{2}', '{3}', @IdContato)", usuario.User, usuario.Senha, usuario.TipoPessoa,
                                     usuario.TipoUsuario, usuario.Pergunta, usuario.Resposta);
            strQuery += "DECLARE @IdPessoaF int SET @IdPessoaF = (SELECT IDENT_CURRENT('PESSOAFISICA')) ";
            strQuery += " UPDATE ACESSO SET IDPESSOA = @IdPessoa WHERE IDACESSO = @IdAcesso ";

            using (contexto = new Contexto())
            {
                contexto.ExecutaGravacao(strQuery);
            
            }
        }
    }
}
