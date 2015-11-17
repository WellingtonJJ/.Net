using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digimon.Dominio
{
    public class Usuario
    {
        //PESSOA FÍSICA
        public int IdPessoaFisica { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public DateTime DataNascimento { get; set; }
        public string RG { get; set; }
        public string UF_PF { get; set; }
        public string OrgaoEmissor { get; set; }
        public string Sexo { get; set; }
        public Boolean Situacao { get; set; }
        //CONTATO
        public int IdContato { get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }
        //ACESSO
        public int IdAcesso { get; set; }
        public string User { get; set; }
        public string Senha { get; set; }
        public int TipoUsuario { get; set; }
        public Boolean SITUACAO { get; set; }
        public int TipoPessoa { get; set; }
        public int IdPessoa { get; set; }
        public string Resposta { get; set; }
        public int Pergunta { get; set; }
    }
}
