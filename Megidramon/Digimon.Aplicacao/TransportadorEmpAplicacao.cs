using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Digimon.Dominio;
using Repositorio;

namespace Digimon.Aplicacao
{
    public class TransportadorEmpAplicacao
    {
        private Contexto contexto;

        public void Inserir(TransportadorEmpresa transportador)
        {
            var strQuery = "";
            strQuery += "INSERT INTO CONTATO (TELEFONE, CELULAR, EMAIL) ";
            strQuery += string.Format("VALUES ('{0}','{1}','{2}') ", transportador.Telefone, transportador.Celular,
                transportador.Email);
            strQuery += "DECLARE @IdContato int SET @IdContato = (SELECT IDENT_CURRENT('CONTATO')) ";
            strQuery += "INSERT INTO ACESSO (USUARIO, SENHA, TIPOPESSOA, TIPOUSUARIO, PERGUNTA, RESPOSTA) ";
            strQuery += string.Format("VALUES ('{0}', '{1}', 0, 0, '{2}', '{3}') ",
                transportador.Usuario, transportador.Senha, transportador.Pergunta, transportador.Resposta);
            strQuery += "DECLARE @IdAcesso int SET @IdAcesso = (SELECT IDENT_CURRENT('ACESSO')) ";
            strQuery += "INSERT INTO ENDERECO (LOGRADOURO, NUMERO, COMPLEMENTO, CEP, BAIRRO, CIDADE, UF)";
            strQuery += string.Format(" VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}') ",
                transportador.Logradouro, transportador.Numero, transportador.Complemento, transportador.Cep,
                transportador.Bairro, transportador.Cidade, transportador.Uf);
            strQuery += "DECLARE @IdEndereco int SET @IdEndereco = (SELECT IDENT_CURRENT('ENDERECO')) ";
            strQuery += "INSERT INTO PESSOAJURIDICA (IDCONTATO, IDENDERECO, CNPJ, NOMEFANTASIA, RAZAOSOCIAL) ";
            strQuery += string.Format("VALUES (@IdContato, @IdEndereco,  '{0}', '{1}', '{2}') ", transportador.Cnpj,
                transportador.NomeFantasia, transportador.Razao);
            strQuery += "DECLARE @IdPessoaJ int SET @IdPessoaJ = (SELECT IDENT_CURRENT('PESSOAJURIDICA')) ";
            strQuery += " UPDATE ACESSO SET IDPESSOA = @IdPessoaJ WHERE IDACESSO = @IdAcesso ";
            strQuery += "INSERT INTO TRANSPORTADOR (IDPESSOA,IDENDERECO, RNTRC, TIPOPESSOA) ";
            strQuery += string.Format("VALUES (@IdPessoaJ, @IdEndereco, '{0}', 0) ", transportador.Rtnrc);

            using (contexto = new Contexto())
            {
                contexto.ExecutaGravacao(strQuery);
            }
        }

        //private void Alterar(Motorista motorista)
        //{    //Alterar Endereço
        //    var strQuery = "";
        //    strQuery += string.Format("DECLARE @IdEndereco int SET @IdEndereco = (SELECT IDENDERECO FROM MOTORISTA WHERE CNH = '{0}') ", motorista.Cnh);
        //    strQuery += "UPDATE ENDERECO SET ";
        //    strQuery += string.Format(" LOGRADOURO = '{0}', ", motorista.Logradouro);
        //    strQuery += string.Format(" NUMERO = '{0}', ", motorista.Numero);
        //    strQuery += string.Format(" COMPLEMENTO = '{0}', ", motorista.Complemento);
        //    strQuery += string.Format(" CEP = '{0}', ", motorista.Cep);
        //    strQuery += string.Format(" BAIRRO = '{0}', ", motorista.Bairro);
        //    strQuery += string.Format(" CIDADE = '{0}', ", motorista.Cidade);
        //    strQuery += string.Format(" UF = '{0}' ", motorista.Uf);
        //    strQuery += " WHERE IDENDERECO = @IdEndereco; ";
        //    //Alterar Pessoa Fisíca
        //    strQuery += string.Format("DECLARE @IdPessoaFisica int SET @IdPessoaFisica = (SELECT IDPESSOAFISICA FROM MOTORISTA WHERE CNH = '{0}') ",
        //        motorista.Cnh);
        //    strQuery += " UPDATE PESSOAFISICA SET ";
        //    strQuery += string.Format(" NOME = '{0}', ", motorista.Nome);
        //    strQuery += string.Format(" CPF = '{0}', ", motorista.Cpf);
        //    strQuery += string.Format(" DATANASCIMENTO = '{0}', ", motorista.DataNascimento);
        //    strQuery += string.Format(" RG = '{0}', ", motorista.Rg);
        //    strQuery += string.Format(" UF_PF = '{0}', ", motorista.UfRg);
        //    strQuery += string.Format(" ORGAOEMISSOR = '{0}', ", motorista.Orgao);
        //    strQuery += string.Format(" SEXO = '{0}' ", motorista.Sexo);
        //    strQuery += " WHERE IDPESSOAFISICA = @IdPessoaFisica ;";
        //    strQuery += " UPDATE MOTORISTA SET ";
        //    strQuery += string.Format(" CNH = '{0}' ", motorista.Cnh);
        //    strQuery += string.Format(" WHERE CNH = '{0}';", motorista.Cnh);
        //    //Alterar Contato
        //    strQuery += "DECLARE @IdContato int SET @IdContato = (SELECT IDCONTATO FROM PESSOAFISICA WHERE IDPESSOAFISICA = @IdPessoaFisica)";
        //    strQuery += "UPDATE CONTATO SET ";
        //    strQuery += string.Format(" TELEFONE = '{0}', ", motorista.Telefone);
        //    strQuery += string.Format(" CELULAR = '{0}', ", motorista.Celular);
        //    strQuery += string.Format(" EMAIL = '{0}' ", motorista.Email);
        //    strQuery += " WHERE IDCONTATO = @IdContato";

        //    using (contexto = new Contexto())
        //    {
        //        contexto.ExecutaGravacao(strQuery);
        //    }
        //}

        //public void Salvar(Motorista motorista)
        //{
        //    if (motorista.IdMotorista > 0)
        //        Alterar(motorista);
        //    else
        //        Inserir(motorista);

        //}

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
        public List<TransportadorEmpresa> ListarTodos()
        {
            using (contexto = new Contexto())
            {
                var strQuery = "SELECT *, ACESSO.TIPOPESSOA AS TIPOPESSOA_USER FROM TRANSPORTADOR INNER JOIN ENDERECO ON TRANSPORTADOR.IDENDERECO = ENDERECO.IDENDERECO INNER JOIN PESSOAJURIDICA " +
                "ON TRANSPORTADOR.IDPESSOA = PESSOAJURIDICA.IDPESSOAJURIDICA INNER JOIN CONTATO ON  PESSOAJURIDICA.IDCONTATO = CONTATO.IDCONTATO " +
                "INNER JOIN ACESSO ON PESSOAJURIDICA.IDPESSOAJURIDICA = ACESSO.IDPESSOA";
                var retorno = contexto.ExecutaLeitura(strQuery);
                return ListarObjeto(retorno);
            }
        }

        //public Motorista ListarMotorista(int idMotorista)
        //{

        //    using (contexto = new Contexto())
        //    {
        //        var strQuery = "SELECT * FROM MOTORISTA INNER JOIN PESSOAFISICA ON MOTORISTA.IDMOTORISTA = PESSOAFISICA.IDPESSOAFISICA INNER JOIN ENDERECO ON MOTORISTA.IDMOTORISTA = ENDERECO.IDENDERECO " +
        //            "INNER JOIN CONTATO ON MOTORISTA.IDMOTORISTA = CONTATO.IDCONTATO ";
        //        strQuery += string.Format("WHERE IDMOTORISTA = '{0}'", idMotorista);
        //        var retorno = contexto.ExecutaLeitura(strQuery);
        //        return ListarObjeto(retorno).FirstOrDefault();
        //    }
        //}

        private List<TransportadorEmpresa> ListarObjeto(SqlDataReader reader)
        {
            var transportadores = new List<TransportadorEmpresa>();
            while (reader.Read())
            {
                var temObjeto = new TransportadorEmpresa()
                {
                    //Transportador
                    IdTransportador = int.Parse(reader["IDTRANSPORTADOR"].ToString()),
                    Rtnrc = reader["RNTRC"].ToString(),
                    TipoPessoa = reader["TIPOPESSOA"].ToString(),
                    NomeFantasia = reader["NOMEFANTASIA"].ToString(),
                    Razao = reader["RAZAOSOCIAL"].ToString(),
                    Cnpj = reader["CNPJ"].ToString(),
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
