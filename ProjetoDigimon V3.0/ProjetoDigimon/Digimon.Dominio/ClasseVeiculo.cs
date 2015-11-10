using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Build.Framework;

namespace Digimon.Dominio
{
    public class ClasseVeiculo
    {
        private int IDVEICULO;
        private string uf;
        private string PLACA;
        private string RENAVAM;
        private string TIPO;
        private string MODELO;
        private string MARCA;
        private string ANO_DE_FABRICA;
        private string NUMEIXOS;
        private float TARA;
        private float cmt;
        private float pbt;
        private Boolean SITUACAO;
        private int IDTRANSPORTADOR;
        private string CIDADE;
        private string TRANSPORTADOR;

        public string Transportador
        {
            get { return TRANSPORTADOR; }
            set { TRANSPORTADOR = value; }
        }
        

        
        public int IdVeiculo
        {
            get { return IDVEICULO; }
            set { IDVEICULO = value; }
        }
        
        public string UF
        {
            get { return uf; }
            set { uf = value; }
        }
        
        public string Placa
        {
            get { return PLACA; }
            set { PLACA = value; }
        }
       
        public string Renavam
        {
            get { return RENAVAM; }
            set { RENAVAM = value; }
        }
        
        public string Tipo
        {
            get { return TIPO; }
            set { TIPO = value; }
        }
        
        public string Modelo
        {
            get { return MODELO; }
            set { MODELO = value; }
        }
        public string Marca
        {
            get { return MARCA; }
            set { MARCA = value; }
        }
        public string AnoDeFabrica
        {
            get { return ANO_DE_FABRICA; }
            set { ANO_DE_FABRICA = value; }
        }
        public string NumEixos
        {
            get { return NUMEIXOS; }
            set { NUMEIXOS = value; }
        }        
        public float Tara
        {
            get { return TARA; }
            set { TARA = value; }
        }
        public float CMT
        {
            get { return cmt; }
            set { cmt = value; }
        }
        public float PBT
        {
            get { return pbt; }
            set { pbt = value; }
        }
        public Boolean Situacao
        {
            get { return SITUACAO; }
            set { SITUACAO = value; }
        }        
        public int IdTransportador
        {
            get { return IDTRANSPORTADOR; }
            set { IDTRANSPORTADOR = value; }
        }
       
        public string Cidade
        {
            get { return CIDADE; }
            set { CIDADE = value; }
        }
    }
}