using System;
using System.Data.SqlClient;
using Digimon.Aplicacao;
using Digimon.Dominio;
using Digimon.Repositorio;

namespace Teste.DOS
{
    class Program
    {
        static void Main(string[] args)
        {
            var contexto = new Contexto();

            Console.Write("Digite o nome do motorista: ");
            string nome = Console.ReadLine();

            Console.Write("Digite o CPF do motorista: ");
            string cpf = Console.ReadLine();

            Console.Write("Digite a data de nascimento (00/00/0000) do motorista: ");
            string dataNascimento = Console.ReadLine();

            Console.Write("Digite o Sexo do motorista: ");
            string sexo = Console.ReadLine();

            Console.Write("Digite o RG e Orgao Expeditor do motorista: ");
            string rg = Console.ReadLine();
            string orgao = Console.ReadLine();

            Console.Write("Digite o Telefone do motorista: ");
            string telefone = Console.ReadLine();

            Console.Write("Digite o Celular do motorista: ");
            string celular = Console.ReadLine();

            Console.Write("Digite o Email do motorista: ");
            string email = Console.ReadLine();

            Console.Write("Digite o Logradouro do motorista: ");
            string logradouro = Console.ReadLine();

            Console.Write("Digite o Bairro do motorista: ");
            string bairro = Console.ReadLine();

            Console.Write("Digite o Numero do motorista: ");
            string numero = Console.ReadLine();

            Console.Write("Digite o Complemento do motorista: ");
            string complemento = Console.ReadLine();

            Console.Write("Digite o Cep do motorista: ");
            string cep = Console.ReadLine();

            Console.Write("Digite a Cidade do motorista: ");
            string cidade = Console.ReadLine();

            Console.Write("Digite a UF do RG do motorista: ");
            string ufRg = Console.ReadLine();

            Console.Write("Digite o Estado do Endereço do motorista: ");
            string uf = Console.ReadLine();

            Console.Write("Digite a CNH do motorista: ");
            string cnh = Console.ReadLine();

            var motorista = new ClasseMotorista
                                    {
                                        Nome = nome,
                                        Cpf = cpf,
                                        DataNascimento = DateTime.Parse(dataNascimento),
                                        Sexo = sexo,
                                        Rg = rg,
                                        Orgao = orgao,
                                        Telefone = telefone,
                                        Celular = celular,
                                        Email = email,
                                        Logradouro = logradouro,
                                        Bairro = bairro,
                                        Numero = numero,
                                        Complemento = complemento,
                                        Cep = cep,
                                        Cidade = cidade,
                                        Uf = uf,
                                        UfRg = ufRg,
                                        Cnh = Convert.ToInt64(cnh)

                                    };
            new MotoristaAplicacao().Salvar(motorista);

            string strQuerySelect = "Select * FROM MOTORISTA";

            SqlDataReader dados = contexto.ExecutaLeitura(strQuerySelect);

            while (dados.Read())
            {
                Console.WriteLine("IdMotorista:{0}, IdPessoaFisica:{1}, IdTransportador:{2}, IdEndereco:{3}, CNH:{4} ", 
                    dados["IDMOTORISTA"], dados["IDPESSOAFISICA"], dados["IDTRANSPORTADOR"], dados["IDENDERECO"], dados["CNH"]);
            }
        }
    }
}
