using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Digimon.Dominio
{
    public class ClasseMotorista
    {
        public int IdMotorista { get; set; }
        
        //Pessoa Física

        public string Nome { get; set; }

        public string Cpf { get; set; }

        public DateTime DataNascimento { get; set; }

        public string Sexo { get; set; }

        public string Orgao { get; set; }

        public string Rg { get; set; }

        public long Cnh { get; set; }

        public string UfRg { get; set; }

        //Contato

        public string Telefone { get; set; }

        public string Celular { get; set; }

        public string Email { get; set; }

        //Endereco

        public string Logradouro { get; set; }

        public string Bairro { get; set; }

        public string Numero { get; set; }

        public string Complemento { get; set; }

        public string Cep { get; set; }

        public string Cidade { get; set; }

        public string Uf { get; set; }

        
    }
}