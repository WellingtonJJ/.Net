using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Digimon.Dominio;
using Repositorio;

namespace Digimon.Aplicacao
{
    public class MotoristaAplicacao
    {
        private Contexto contexto;

        private void Inserir(Motorista motorista)
        {   //Inserir Contato
            var strQuery = "";
            strQuery += " INSERT INTO CONTATO(TELEFONE, CELULAR, EMAIL) ";
            strQuery += string.Format(" VALUES('{0}','{1}','{2}')", motorista.Telefone, motorista.Celular,
                motorista.Email);
            //Inserir Endereço
            strQuery += " INSERT INTO ENDERECO(LOGRADOURO, NUMERO, COMPLEMENTO, CEP, BAIRRO, CIDADE, UF)";
            strQuery += string.Format(" VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", motorista.Logradouro,
                motorista.Numero, motorista.Complemento, motorista.Cep, motorista.Bairro, motorista.Cidade, motorista.Uf);
            strQuery += " Declare @IdEndereco int " +
                        "SET @IdEndereco = (SELECT IDENT_CURRENT('ENDERECO')) " +
                        "Declare @IdContato int " +
                        "SET @IdContato = (SELECT IDENT_CURRENT('CONTATO')) ";
            //Inserir Pessoa Fisíca
            strQuery += " INSERT INTO PESSOAFISICA(IDENDERECO, IDCONTATO, NOME, CPF, DATANASCIMENTO, RG, UF_PF, ORGAOEMISSOR, SEXO)";
            strQuery += string.Format("VALUES(@IdEndereco,@IdContato,'{0}','{1}','{2}','{3}','{4}','{5}','{6}') ",
                motorista.Nome, motorista.Cpf, motorista.DataNascimento, motorista.Rg, motorista.Uf, motorista.Orgao,
                motorista.Sexo);
            strQuery += "Declare @IdPessoaFisica int " +
                        "SET @IdPessoaFisica = (SELECT IDENT_CURRENT('PESSOAFISICA')) ";
            strQuery += " INSERT INTO MOTORISTA(IDPESSOAFISICA, IDTRANSPORTADOR, IDENDERECO, CNH)";
            strQuery += string.Format("VALUES (@IdPessoaFisica,5,@IdEndereco,'{0}') ", motorista.Cnh);

            using (contexto = new Contexto())
            {
                contexto.ExecutaGravacao(strQuery);
            }
        }

        private void Alterar(Motorista motorista)
        {    //Alterar Endereço
            var strQuery = "";
            strQuery += string.Format("DECLARE @IdEndereco int SET @IdEndereco = (SELECT IDENDERECO FROM MOTORISTA WHERE CNH = '{0}') ", motorista.Cnh);
            strQuery += "UPDATE ENDERECO SET ";
            strQuery += string.Format(" LOGRADOURO = '{0}', ", motorista.Logradouro);
            strQuery += string.Format(" NUMERO = '{0}', ", motorista.Numero);
            strQuery += string.Format(" COMPLEMENTO = '{0}', ", motorista.Complemento);
            strQuery += string.Format(" CEP = '{0}', ", motorista.Cep);
            strQuery += string.Format(" BAIRRO = '{0}', ", motorista.Bairro);
            strQuery += string.Format(" CIDADE = '{0}', ", motorista.Cidade);
            strQuery += string.Format(" UF = '{0}' ", motorista.Uf);
            strQuery += " WHERE IDENDERECO = @IdEndereco; ";
            //Alterar Pessoa Fisíca
            strQuery += string.Format("DECLARE @IdPessoaFisica int SET @IdPessoaFisica = (SELECT IDPESSOAFISICA FROM MOTORISTA WHERE CNH = '{0}') ",
                motorista.Cnh);
            strQuery += " UPDATE PESSOAFISICA SET ";
            strQuery += string.Format(" NOME = '{0}', ", motorista.Nome);
            strQuery += string.Format(" CPF = '{0}', ", motorista.Cpf);
            strQuery += string.Format(" DATANASCIMENTO = '{0}', ", motorista.DataNascimento);
            strQuery += string.Format(" RG = '{0}', ", motorista.Rg);
            strQuery += string.Format(" UF_PF = '{0}', ", motorista.UfRg);
            strQuery += string.Format(" ORGAOEMISSOR = '{0}', ", motorista.Orgao);
            strQuery += string.Format(" SEXO = '{0}' ", motorista.Sexo);
            strQuery += " WHERE IDPESSOAFISICA = @IdPessoaFisica ;";
            strQuery += " UPDATE MOTORISTA SET ";
            strQuery += string.Format(" CNH = '{0}' ", motorista.Cnh);
            strQuery += string.Format(" WHERE CNH = '{0}';", motorista.Cnh);
            //Alterar Contato
            strQuery += "DECLARE @IdContato int SET @IdContato = (SELECT IDCONTATO FROM PESSOAFISICA WHERE IDPESSOAFISICA = @IdPessoaFisica)";
            strQuery += "UPDATE CONTATO SET ";
            strQuery += string.Format(" TELEFONE = '{0}', ", motorista.Telefone);
            strQuery += string.Format(" CELULAR = '{0}', ", motorista.Celular);
            strQuery += string.Format(" EMAIL = '{0}' ", motorista.Email);
            strQuery += " WHERE IDCONTATO = @IdContato";

            using (contexto = new Contexto())
            {
                contexto.ExecutaGravacao(strQuery);
            }
        }

        public void Salvar(Motorista motorista)
        {
            if (motorista.IdMotorista > 0)
                Alterar(motorista);
            else
                Inserir(motorista);

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
        public List<Motorista> ListarTodos()
        {
            using (contexto = new Contexto())
            {
                var strQuery = "SELECT * FROM MOTORISTA INNER JOIN PESSOAFISICA ON MOTORISTA.IDMOTORISTA = PESSOAFISICA.IDPESSOAFISICA INNER JOIN ENDERECO ON MOTORISTA.IDMOTORISTA = ENDERECO.IDENDERECO " +
                    "INNER JOIN CONTATO ON MOTORISTA.IDMOTORISTA = CONTATO.IDCONTATO";
                var retorno = contexto.ExecutaLeitura(strQuery);
                return ListarObjeto(retorno);
            }
        }

        public Motorista ListarMotorista(int idMotorista)
        {

            using (contexto = new Contexto())
            {
                var strQuery = "SELECT * FROM MOTORISTA INNER JOIN PESSOAFISICA ON MOTORISTA.IDMOTORISTA = PESSOAFISICA.IDPESSOAFISICA INNER JOIN ENDERECO ON MOTORISTA.IDMOTORISTA = ENDERECO.IDENDERECO " +
                    "INNER JOIN CONTATO ON MOTORISTA.IDMOTORISTA = CONTATO.IDCONTATO ";
                strQuery += string.Format("WHERE IDMOTORISTA = '{0}'", idMotorista);
                var retorno = contexto.ExecutaLeitura(strQuery);
                return ListarObjeto(retorno).FirstOrDefault();
            }
        }

        private List<Motorista> ListarObjeto(SqlDataReader reader)
        {
            var motorista = new List<Motorista>();
            while (reader.Read())
            {
                var temObjeto = new Motorista()
                {
                    IdMotorista = int.Parse(reader["IdMotorista"].ToString()),
                    Nome = reader["NOME"].ToString(),
                    Cpf = reader["CPF"].ToString(),
                    DataNascimento = DateTime.Parse(reader["DATANASCIMENTO"].ToString()),
                    Sexo = reader["SEXO"].ToString(),
                    Orgao = reader["ORGAOEMISSOR"].ToString(),
                    Rg = reader["RG"].ToString(),
                    Cnh = long.Parse(reader["CNH"].ToString()),
                    UfRg = reader["UFRG"].ToString(),
                    Telefone = reader["TELEFONE"].ToString(),
                    Celular = reader["CELULAR"].ToString(),
                    Email = reader["EMAIL"].ToString(),
                    Logradouro = reader["LOGRADOURO"].ToString(),
                    Bairro = reader["BAIRRO"].ToString(),
                    Numero = reader["NUMERO"].ToString(),
                    Complemento = reader["COMPLEMENTO"].ToString(),
                    Cep = reader["CEP"].ToString(),
                    Cidade = reader["CIDADE"].ToString(),
                    Uf = reader["UF"].ToString()
                };
                motorista.Add(temObjeto);
            }
            reader.Close();
            reader.Dispose();
            return motorista;

        }
    }
}
