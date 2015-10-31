using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoDigimon.Models
{
    public class ClasseMotorista
    {
        private int IDMOTORISTA;
        private int IDPESSOAFISICA;
        private int IDTRANSPORTADOR;
        private string Cnh;
        private Boolean SITUACAO;

        public Boolean Situacao
        {
            get { return SITUACAO; }
            set { SITUACAO = value; }
        }
        

        public string CNH
        {
            get { return Cnh; }
            set { Cnh = value; }
        }
        

        public int IdTransportador
        {
            get { return IDTRANSPORTADOR; }
            set { IDTRANSPORTADOR = value; }
        }
        

        public int IdPessoaFisica
        {
            get { return IDPESSOAFISICA; }
            set { IDPESSOAFISICA = value; }
        }
        

        public int IdMotorista
        {
            get { return IDMOTORISTA; }
            set { IDMOTORISTA = value; }
        }
        
    }
}