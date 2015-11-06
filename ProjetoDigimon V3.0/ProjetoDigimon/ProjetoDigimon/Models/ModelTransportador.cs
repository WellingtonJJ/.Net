using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoDigimon.Models
{
    public class ModelTransportador
    {
        private int IDTRANSPORTADOR;
        private int IDENDERECO;
        private string rntrc;
        private Boolean TIPODEPESSOA;
        private int IDPESSOA;
        private Boolean SITUACAO;

        public Boolean Stiuacao
        {
            get { return SITUACAO; }
            set { SITUACAO = value; }
        }
        

        public int IdPessoa
        {
            get { return IDPESSOA; }
            set { IDPESSOA = value; }
        }
        

        public Boolean TipeDePessoa
        {
            get { return TIPODEPESSOA; }
            set { TIPODEPESSOA = value; }
        }
        

        public string RNTRC
        {
            get { return rntrc; }
            set { rntrc = value; }
        }
        

        public int IdEndereco
        {
            get { return IDENDERECO; }
            set { IDENDERECO = value; }
        }
        

        public int IdTransportador
        {
            get { return IDTRANSPORTADOR; }
            set { IDTRANSPORTADOR = value; }
        }
        
    }
}