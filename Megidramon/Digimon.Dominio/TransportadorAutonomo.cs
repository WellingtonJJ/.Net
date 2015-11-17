using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digimon.Dominio
{
    public class TransportadorAutonomo
    {
        //Transportador
        public int IdTransportador { get; set; }

        public string Rtnrc { get; set; }

        public string TipoPessoa { get; set; }

        //Endereço
        public string Logradouro { get; set; }

        public string Numero { get; set; }

        public string Complemento { get; set; }

        public string Cep { get; set; }

        public string Bairro { get; set; }

        public string Cidade { get; set; }

        public string Uf { get; set; }

        //Pessoa Contato
        public string Telefone { get; set; }

        public string Celular { get; set; }

        public string Email { get; set; }

        //Acesso
        public string Usuario { get; set; }

        public string Senha { get; set; }

        public string TipoUsuario { get; set; }

        public string TipoPessoaF { get; set; }

        public string Pergunta { get; set; }

        public string Resposta { get; set; }

        //Pessoa Física 
        public string Nome { get; set; }

        public string CPF { get; set; }

        public DateTime DataNascimento { get; set; }

        public string RG { get; set; }

        public string UF_PF { get; set; }

        public string OrgaoEmissor { get; set; }

        public string Sexo { get; set; }

        public Boolean Situacao { get; set; }
    }
}
