using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjetoDigimon.Models
{
    public class ModelVeiculo
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


        [Required(ErrorMessage = " * Campo Obrigatório")]
        public int IdVeiculo
        {
            get { return IDVEICULO; }
            set { IDVEICULO = value; }
        }
        [Required(ErrorMessage = " * Campo Obrigatório")]
        public string UF
        {
            get { return uf; }
            set { uf = value; }
        }
        [MaxLength(7)]
        [MinLength(7)]
        [Required(ErrorMessage = " * Campo Obrigatório")]
        public string Placa
        {
            get { return PLACA; }
            set { PLACA = value; }
        }
        [Required(ErrorMessage = " * Campo Obrigatório")]
        public string Renavam
        {
            get { return RENAVAM; }
            set { RENAVAM = value; }
        }
        [Required(ErrorMessage = " * Campo Obrigatório")]
        public string Tipo
        {
            get { return TIPO; }
            set { TIPO = value; }
        }
        [Required(ErrorMessage = " * Campo Obrigatório")]
        public string Modelo
        {
            get { return MODELO; }
            set { MODELO = value; }
        }
        [Required(ErrorMessage = " * Campo Obrigatório")]
        public string Marca
        {
            get { return MARCA; }
            set { MARCA = value; }
        }
        [Required(ErrorMessage = " * Campo Obrigatório")]
        public string AnoDeFabrica
        {
            get { return ANO_DE_FABRICA; }
            set { ANO_DE_FABRICA = value; }
        }
        [MaxLength(9)]
        [MinLength(2)]
        [Required(ErrorMessage = " * Campo Obrigatório")]
        public string NumEixos
        {
            get { return NUMEIXOS; }
            set { NUMEIXOS = value; }
        }
        [Required(ErrorMessage = " * Campo Obrigatório")]
        public float Tara
        {
            get { return TARA; }
            set { TARA = value; }
        }

        [Required(ErrorMessage = " * Campo Obrigatório")]
        public float CMT
        {
            get { return cmt; }
            set { cmt = value; }
        }

        [Required(ErrorMessage = " * Campo Obrigatório")]
        public float PBT
        {
            get { return pbt; }
            set { pbt = value; }
        }

        [Required(ErrorMessage = " * Campo Obrigatório")]
        public Boolean Situacao
        {
            get { return SITUACAO; }
            set { SITUACAO = value; }
        }



        [Required(ErrorMessage = " * Campo Obrigatório")]
        public int IdTransportador
        {
            get { return IDTRANSPORTADOR; }
            set { IDTRANSPORTADOR = value; }
        }
        [Required(ErrorMessage = " * Campo Obrigatório")]
        public string Cidade
        {
            get { return CIDADE; }
            set { CIDADE = value; }
        }
    }
}