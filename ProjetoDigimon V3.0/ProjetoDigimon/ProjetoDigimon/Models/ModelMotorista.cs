using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoDigimon.Models
{
    public class ModelMotorista
    {
        private int IDMOTORISTA;

        public int IdMotorista
        {
            get { return IDMOTORISTA; }
            set { IDMOTORISTA = value; }
        }

        private string NOME;

        public string Nome
        {
            get { return NOME; }
            set { NOME = value; }
        }

        private string CPF;

        public string Cpf
        {
            get { return CPF; }
            set { CPF = value; }
        }

        private string DATANASCIMENTO;

        public string DataNascimento
        {
            get { return DATANASCIMENTO; }
            set { DATANASCIMENTO = value; }
        }


        private string SEXO;

        public string Sexo
        {
            get { return SEXO; }
            set { SEXO = value; }
        }


        private string ORGAO;

        public string Orgao
        {
            get { return ORGAO; }
            set { ORGAO = value; }
        }

        private string TELEFONE;

        public string Telefone
        {
            get { return TELEFONE; }
            set { TELEFONE = value; }
        }

        private string CELULAR;

        public string Celular
        {
            get { return CELULAR; }
            set { CELULAR = value; }
        }

        private string EMAIL;

        public string Email
        {
            get { return EMAIL; }
            set { EMAIL = value; }
        }

        private string LOGRADOURO;

        public string Logradouro
        {
            get { return LOGRADOURO; }
            set { LOGRADOURO = value; }
        }

        private string BAIRRO;

        public string Bairro
        {
            get { return BAIRRO; }
            set { BAIRRO = value; }
        }
        private string NUMERO;

        public string Numero
        {
            get { return NUMERO; }
            set { NUMERO = value; }
        }

        private string COMPLEMENTO;

        public string Complemento
        {
            get { return COMPLEMENTO; }
            set { COMPLEMENTO = value; }
        }

        private string CEP;

        public string Cep
        {
            get { return CEP; }
            set { CEP = value; }
        }

        private string CIDADE;

        public string Cidade
        {
            get { return CIDADE; }
            set { CIDADE = value; }
        }

        private string UF;

        public string Uf
        {
            get { return UF; }
            set { UF = value; }
        }
       
    }
}