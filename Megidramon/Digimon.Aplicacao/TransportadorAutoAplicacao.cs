using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Digimon.Dominio;
using Repositorio;

namespace Digimon.Aplicacao
{
    public class TransportadorAutoAplicacao
    {
        private Contexto contexto;

        public void Inserir(TransportadorAutonomo transportador)
        {
            var strQuery = "";
            strQuery += "INSERT INTO CONTATO (TELEFONE, CELULAR, EMAIL) ";
            strQuery += string.Format("VALUES ('{0}','{1}','{2}') ", transportador.Telefone, transportador.Celular,
                transportador.Email);
            strQuery += "DECLARE @IdContato int SET @IdContato = (SELECT IDENT_CURRENT('CONTATO')) ";
            strQuery += "INSERT INTO ACESSO (USUARIO, SENHA, TIPOPESSOA, TIPOUSUARIO, PERGUNTA, RESPOSTA, IDCONTATO) ";
            strQuery += string.Format("VALUES ('{0}', '{1}', 'J', 'A', '{2}', '{3}', @IdContato) ",
                transportador.Usuario, transportador.Senha, transportador.Pergunta, transportador.Resposta);
            strQuery += "DECLARE @IdAcesso int SET @IdAcesso = (SELECT IDENT_CURRENT('ACESSO')) ";
            strQuery += "INSERT INTO ENDERECO (LOGRADOURO, NUMERO, COMPLEMENTO, CEP, BAIRRO, CIDADE, UF)";
            strQuery += string.Format(" VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}') ",
                transportador.Logradouro, transportador.Numero, transportador.Complemento, transportador.Cep,
                transportador.Bairro, transportador.Cidade, transportador.Uf);
            strQuery += "DECLARE @IdEndereco int SET @IdEndereco = (SELECT IDENT_CURRENT('ENDERECO')) ";
            strQuery += "INSERT INTO PESSOAFISICA (IDCONTATO, IDENDERECO, NOME, CPF, DATANASCIMENTO, RG, UF_PF, ORGAOEMISSOR, SEXO) ";
            strQuery += string.Format("VALUES (@IdContato, @IdEndereco,  '{0}', '{1}', '{2}','{3}','{4}','{5}','{6}') ", transportador.Nome,
                transportador.CPF, transportador.DataNascimento, transportador.RG, transportador.UF_PF, transportador.OrgaoEmissor, transportador.Sexo);
            strQuery += "DECLARE @IdPessoaF int SET @IdPessoaF = (SELECT IDENT_CURRENT('PESSOAJU')) ";
            strQuery += " UPDATE ACESSO SET IDPESSOA = @IdPessoaJ WHERE IDACESSO = @IdAcesso ";
            strQuery += "INSERT INTO TRANSPORTADOR (IDPESSOA,IDENDERECO, RNTRC, TIPOPESSOA) ";
            strQuery += string.Format("VALUES (@IdPessoaJ, @IdEndereco, '{0}', 'J') ", transportador.Rtnrc);

            using (contexto = new Contexto())
            {
                contexto.ExecutaGravacao(strQuery);
            }
        }
        public void Desativar(string Cnh)
        {
            var strQuery = "";
            strQuery += string.Format("UPDATE MOTORISTA SET SITUACAO = 1 WHERE CNH = '{0}'", Cnh);
            strQuery += string.Format("DECLARE @IdPessoaFisica int SET @IdPessoaFisica = (SELECT IDPESSOAFISICA FROM MOTORISTA WHERE CNH = '{0}')", Cnh);
            strQuery += "UPDATE PESSOAFISICA SET SITUACAO = 1 WHERE IDPESSOAFISICA = @IdPessoaFisica";

            using (contexto = new Contexto())
            {
                contexto.ExecutaGravacao(strQuery);
            }
        }
        public List<TransportadorAutonomo> ListarTodos()
        {
            using (contexto = new Contexto())
            {
                var strQuery = "SELECT *, ACESSO.TIPOPESSOA AS TIPOPESSOA_USER FROM TRANSPORTADOR INNER JOIN ENDERECO ON TRANSPORTADOR.IDENDERECO = ENDERECO.IDENDERECO INNER JOIN PESSOAFISICA" +
                "ON TRANSPORTADOR.IDPESSOA = PESSOAJURIDICA.IDPESSOAFISICA INNER JOIN CONTATO ON  PESSOAFISICA.IDCONTATO = CONTATO.IDCONTATO " +
                "INNER JOIN ACESSO ON PESSOAFISICA.IDPESSOAFISICA = ACESSO.IDPESSOA";
                var retorno = contexto.ExecutaLeitura(strQuery);
                return ListarObjeto(retorno);
            }
        }
        private List<TransportadorAutonomo> ListarObjeto(SqlDataReader reader)
        {
            var transportadores = new List<TransportadorAutonomo>();
            while (reader.Read())
            {
                var temObjeto = new TransportadorAutonomo()
                {
                    //Transportador
                    IdTransportador = int.Parse(reader["IDTRANSPORTADOR"].ToString()),
                    Rtnrc = reader["RNTRC"].ToString(),
                    TipoPessoa = reader["TIPOPESSOA"].ToString(),
                    Nome = reader["NOME"].ToString(),
                    DataNascimento = DateTime.Parse(reader["DATANASCIMENTO"].ToString()),
                    RG = reader["RG"].ToString(),
                    CPF = reader["CPF"].ToString(),
                    UF_PF = reader["UF_PF"].ToString(),
                    OrgaoEmissor = reader["ORGAOEMISSOR"].ToString(),
                    Sexo = reader["SEXO"].ToString(),
                    //Acesso
                    Usuario = reader["USUARIO"].ToString(),
                    Senha = reader["SENHA"].ToString(),
                    TipoUsuario = reader["TIPOUSUARIO"].ToString(),
                    TipoPessoaF = reader["TIPOPESSOA_USER"].ToString(),
                    Pergunta = reader["PERGUNTA"].ToString(),
                    Resposta = reader["RESPOSTA"].ToString(),
                    //Contato
                    Telefone = reader["TELEFONE"].ToString(),
                    Celular = reader["CELULAR"].ToString(),
                    Email = reader["EMAIL"].ToString(),
                    //Endereço
                    Logradouro = reader["LOGRADOURO"].ToString(),
                    Bairro = reader["BAIRRO"].ToString(),
                    Numero = reader["NUMERO"].ToString(),
                    Complemento = reader["COMPLEMENTO"].ToString(),
                    Cep = reader["CEP"].ToString(),
                    Cidade = reader["CIDADE"].ToString(),
                    Uf = reader["UF"].ToString()
                };
                transportadores.Add(temObjeto);
            }
            reader.Close();
            reader.Dispose();
            return transportadores;
        }
    }
}

