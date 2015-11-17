namespace Digimon.Dominio
{
    public class TransportadorEmpresa
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

        //Pessoa Juridica
        public string Cnpj { get; set; }

        public string NomeFantasia { get; set; }

        public string Razao { get; set; }

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
        //Para a combobox
        public string Nome { get; set; }
    }
}
