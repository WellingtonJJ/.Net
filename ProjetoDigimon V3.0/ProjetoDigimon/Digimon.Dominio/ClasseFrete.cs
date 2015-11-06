using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Digimon.Dominio
{
    public class ClasseFrete
    {
        private int IDFRETE;
        private int IDMOTORISTA;
        private int IDVEICULO;
        private int IDTRANSPORTADOR;
        private string TIPO;
        private Boolean SITUACAO;

        public Boolean Situacao
        {
            get { return SITUACAO; }
            set { SITUACAO = value; }
        }
        

        public string Tipo
        {
            get { return TIPO; }
            set { TIPO = value; }
        }
        

        public int IdTransportador
        {
            get { return IDTRANSPORTADOR; }
            set { IDTRANSPORTADOR = value; }
        }
        

        public int IdVeiculo
        {
            get { return IDVEICULO; }
            set { IDVEICULO = value; }
        }
        

        public int IdMotorista
        {
            get { return IDMOTORISTA; }
            set { IDMOTORISTA = value; }
        }
        
        
        public int IdFrete
        {
            get { return IDFRETE; }
            set { IDFRETE = value; }
        }
        
    }
}