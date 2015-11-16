using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Digimon.Aplicacao;
using Digimon.Dominio;

namespace TesteDOS
{
    class Program
    {
        static void Main(string[] args)
        {
            var appMotorista = new MotoristaAplicacao();

            Console.Write("Nome:");
            string nome = Console.ReadLine();

            Console.Write("Data:");
            string data = Console.ReadLine();

            var motorista = new MotoristaClasse
            {
                Nome = nome,
                DataNascimento = DateTime.Parse(data)
            };

            appMotorista.Inserir(motorista);

            var dados = appMotorista.ListarTodos();

            foreach (var motorista0 in dados)
            {
                Console.WriteLine("Id:{0}, Nome:{1}, DataNascimento:{2} ", motorista0.IdMotorista, motorista0.Nome, motorista0.DataNascimento);
            }
        }

        
    }
}
