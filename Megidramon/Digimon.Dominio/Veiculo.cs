using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digimon.Dominio
{
     public class Veiculo
    {
    private int IDVEICULO;
        public int IdVeiculo
        {
            get { return IDVEICULO; }
            set { IDVEICULO = value; }
        }

        private string uf;
        public string UF
        {
            get { return uf; }
            set { uf = value; }
        }

        private string PLACA;
        public string Placa
        {
            get { return PLACA; }
            set { PLACA = value; }
        }
        
        private string RENAVAM;
        public string Renavam
        {
            get { return RENAVAM; }
            set { RENAVAM = value; }
        }
        
        private string TIPO;
        public string Tipo
        {
            get { return TIPO; }
            set { TIPO = value; }
        }
        
        private string MODELO;
        public string Modelo
        {
            get { return MODELO; }
            set { MODELO = value; }
        }        
        
        private string MARCA;
        public string Marca
        {
            get { return MARCA; }
            set { MARCA = value; }
        }        
        
        private string ANO_DE_FABRICA;
        public string AnoDeFabrica
        {
            get { return ANO_DE_FABRICA; }
            set { ANO_DE_FABRICA = value; }
        }        
        
        private string NUMEIXOS;
        public string NumEixos
        {
            get { return NUMEIXOS; }
            set { NUMEIXOS = value; }
        }
        
        private float TARA;
        public float Tara
        {
            get { return TARA; }
            set { TARA = value; }
        }

        private float cmt;
        public float CMT
        {
            get { return cmt; }
            set { cmt = value; }
        }        
        
        private float pbt;
        public float PBT
        {
            get { return pbt; }
            set { pbt = value; }
        }
        
        private Boolean SITUACAO;
        public Boolean Situacao
        {
            get { return SITUACAO; }
            set { SITUACAO = value; }
        }
        
        
        private string CIDADE;
        
        public string Cidade
        {
            get { return CIDADE; }
            set { CIDADE = value; }
        }
        private int IDTRANSPORTADOR;

        public int IdTransportador
        {
            get { return IDTRANSPORTADOR; }
            set { IDTRANSPORTADOR = value; }
        }
        private string TRANSPORTADOR;

        public string Transportador
        {
            get { return TRANSPORTADOR; }
            set { TRANSPORTADOR = value; }
        }

        private IEnumerable<TransportadorEmpresa> transportadores;

        public IEnumerable<TransportadorEmpresa> Transportadores
        {
            get { return transportadores; }
            set { transportadores = value; }
        }

        public Veiculo()
        {
            this.transportadores = new List<TransportadorEmpresa>();
        }
    }
}
