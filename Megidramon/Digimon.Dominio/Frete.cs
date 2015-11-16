using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digimon.Dominio
{
    public class Frete
    {
        public int IdFrete { get; set; }

        public string Placa { get; set; }

        public string Cnh { get; set; }

        public string Tipo { get; set; }

        public DateTime DataEntrega { get; set; }

        public DateTime DataSaida { get; set; }

        public string Rtnrc { get; set; }

        public string TipoCarga { get; set; }

        public string Remetente { get; set; }

        public string Destinatario { get; set; }

        public string RLogradouro { get; set; }

        public string RNumero { get; set; }

        public string RComplemento { get; set; }

        public string RCep { get; set; }

        public string RBairro { get; set; }

        public string RCidade { get; set; }

        public string RUf { get; set; }

        public string DLogradouro { get; set; }

        public string DNumero { get; set; }

        public string DComplemento { get; set; }

        public string DCep { get; set; }

        public string DBairro { get; set; }

        public string DCidade { get; set; }

        public string DUf { get; set; }
    }
}
