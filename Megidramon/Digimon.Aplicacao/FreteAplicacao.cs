using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Digimon.Dominio;
using Repositorio;

namespace Digimon.Aplicacao
{
    public class FreteAplicacao
    {
        private Contexto contexto;

        public void Inserir(Frete frete)
        {   //Inserir Contato
            var strQuery = "";
            strQuery += string.Format("DECLARE @IdMotorista int SET @IdMotorista = (SELECT IDMOTORISTA FROM MOTORISTA WHERE CNH = '{0}') ", frete.Cnh);
            strQuery += string.Format("DECLARE @IdTransportador int SET @IdTransportador = (SELECT IDTRANSPORTADOR FROM TRANSPORTADOR WHERE RNTRC = '{0}') ",
                    frete.Rtnrc);
            strQuery += string.Format("DECLARE @IdVeiculo int SET @IdVeiculo = (SELECT IDVEICULO FROM VEICULO WHERE PLACA = '{0}') ",
                    frete.Placa);
            strQuery += "INSERT INTO FRETE (IDMOTORISTA, IDTRANSPORTADOR, IDVEICULO,  TIPO, DATASAIDA, DATAENTREGA) ";
            strQuery += string.Format("VALUES (@IdMotorista, @IdTransportador, @IdVeiculo, '{0}', '{1}', '{2}') ",
                frete.Tipo, frete.DataSaida, frete.DataEntrega);
            strQuery += "DECLARE @IdFrete int SET @IdFrete = (SELECT IDENT_CURRENT('FRETE')) ";
            strQuery += "INSERT INTO ENDERECO (LOGRADOURO, NUMERO, COMPLEMENTO, CEP, BAIRRO, CIDADE, UF) ";
            strQuery += string.Format("VALUES('{0}','{1}','{2}', '{3}', '{4}', '{5}', '{6}') ", frete.RLogradouro,
                frete.RNumero, frete.RComplemento, frete.RCep, frete.RBairro, frete.RCidade, frete.RUf);
            strQuery += "DECLARE @Origem int SET @Origem = (SELECT IDENT_CURRENT('ENDERECO')) ";
            strQuery += "INSERT INTO ENDERECO (LOGRADOURO, NUMERO, COMPLEMENTO, CEP, BAIRRO, CIDADE, UF) ";
            strQuery += string.Format("VALUES ('{0}','{1}','{2}', '{3}', '{4}', '{5}', '{6}') ", frete.DLogradouro,
                frete.DNumero, frete.DComplemento, frete.DCep, frete.DBairro, frete.DCidade, frete.DUf);
            strQuery += "DECLARE @Destino int SET @Destino = (SELECT IDENT_CURRENT('ENDERECO')) ";
            strQuery += "INSERT INTO CARGA (TIPO, REMETENTE, DESTINATARIO, ORIGEM, DESTINO, IDFRETE) ";
            strQuery += string.Format("VALUES ('{0}', '{1}', '{2}', @Origem, @Destino, @IdFrete) ", frete.TipoCarga, frete.Remetente, frete.Destinatario);

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
        //    strQuery += string.Format(" UFRG = '{0}', ", motorista.UfRg);
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
        //public void Desativar(string Cnh)
        //{
        //    var strQuery = "";
        //    strQuery += string.Format("UPDATE MOTORISTA SET SITUACAO = 1 WHERE CNH = '{0}'", Cnh);
        //    strQuery += string.Format("DECLARE @IdPessoaFisica int SET @IdPessoaFisica = (SELECT IDPESSOAFISICA FROM MOTORISTA WHERE CNH = '{0}')", Cnh);
        //    strQuery += "UPDATE PESSOAFISICA SET SITUACAO = 1 WHERE IDPESSOAFISICA = @IdPessoaFisica";

        //    using (contexto = new Contexto())
        //    {
        //        contexto.ExecutaGravacao(strQuery);
        //    }
        //}
        public List<Frete> ListarTodos()
        {
            using (contexto = new Contexto())
            {
                var strQuery = "" +
                "SELECT C.IDFRETE, C.IDCARGA, C.TIPO AS TIPO_CARGA, C.REMETENTE, " +
                "O.LOGRADOURO AS RUAO, O.NUMERO AS NUMEROO, O.CEP AS CEPO, O.COMPLEMENTO AS COMPLEMENTOO, O.BAIRRO AS BAIRROO, O.CIDADE AS CIDADEO," +
                " O.UF AS UFO, C.DESTINATARIO," +
                " D.LOGRADOURO AS RUAD, D.NUMERO AS NUMEROD, D.CEP AS CEPD, D.COMPLEMENTO AS COMPLEMENTOD, D.BAIRRO AS BAIRROD, D.CIDADE AS CIDADED," +
                "D.UF AS UFD FROM CARGA C INNER JOIN ENDERECO O ON C.ORIGEM=O.IDENDERECO INNER JOIN ENDERECO D ON C.DESTINO=D.IDENDERECO";

                var retorno = contexto.ExecutaLeitura(strQuery);
                return ListarObjeto(retorno);
            }
        }

        public Frete ListarFrete(int idFrete)
        {

            using (contexto = new Contexto())
            {
                var strQuery = "SELECT * FROM FRETE INNER JOIN CARGA ON FRETE.IDFRETE = CARGA.IDCARGA INNER JOIN MOTORISTA ON FRETE.IDMOTORISTA = MOTORISTA.IDMOTORISTA " +
                               "INNER JOIN TRANSPORTADOR ON FRETE.IDTRANSPORTADOR = TRANSPORTADOR.IDTRANSPORTADOR INNER JOIN VEICULO ON FRETE.IDVEICULO = VEICULO.IDVEICULO";
                strQuery += string.Format("WHERE IDFRETE = '{0}'", idFrete);
                var retorno = contexto.ExecutaLeitura(strQuery);
                return ListarObjeto(retorno).FirstOrDefault();
            }
        }

        private List<Frete> ListarObjeto(SqlDataReader reader)
        {
            var fretes = new List<Frete>();
            while (reader.Read())
            {
                var temObjeto = new Frete()
                {
                    IdFrete = int.Parse(reader["IDFRETE"].ToString()),
                    //Placa = reader["PLACA"].ToString(),
                    //Cnh = reader["CNH"].ToString(),
                    //Tipo = reader["TIPO"].ToString(),
                    //  DataEntrega  = DateTime.Parse(reader["DATAENTREGA"].ToString()),
                    //  DataSaida  = DateTime.Parse(reader["DATASAIDA"].ToString()),
                    //  Rtnrc   = reader["RNTRC"].ToString(),
                    //  TipoCarga  = reader["TIPOCARGA"].ToString(),
                    //  Remetente = reader["REMETENTE"].ToString(),
                    //  Destinatario  = reader["DESTINATARIO"].ToString(),
                    RLogradouro = reader["RUAO"].ToString(),
                    RNumero = reader["NUMEROO"].ToString(),
                    RComplemento = reader["COMPLEMENTOO"].ToString(),
                    RCep = reader["CEPO"].ToString(),
                    RBairro = reader["BAIRROO"].ToString(),
                    RCidade = reader["CIDADEO"].ToString(),
                    RUf = reader["UFO"].ToString(),
                    DLogradouro = reader["RUAD"].ToString(),
                    DNumero = reader["NUMEROD"].ToString(),
                    DComplemento = reader["COMPLEMENTOD"].ToString(),
                    DCep = reader["CEPD"].ToString(),
                    DBairro = reader["BAIRROD"].ToString(),
                    DCidade = reader["CIDADED"].ToString(),
                    DUf = reader["UFD"].ToString()
                };
                fretes.Add(temObjeto);
            }
            reader.Close();
            reader.Dispose();
            return fretes;

        }

    }
}
