using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoDigimon.Models
{
    public class ClasseUsuario
    {
        private int IDACESSO;
        private string USUARIO;
        private string SENHA;
        private string TIPOSUSUARIO;
        private string SITUACAO;
        private string TIPOPESSOA;
        private string IDPESSOA;
        private string RESPOSTA;

        public string Resposta
        {
            get { return RESPOSTA; }
            set { RESPOSTA = value; }
        }
        
        public string IdPessoa
        {
            get { return IDPESSOA; }
            set { IDPESSOA = value; }
        }
        
        public string TipoPessoa
        {
            get { return TIPOPESSOA; }
            set { TIPOPESSOA = value; }
        }
        
        public string Situacao
        {
            get { return SITUACAO; }
            set { SITUACAO = value; }
        }
        

        public string TipoUsuario
        {
            get { return TIPOSUSUARIO; }
            set { TIPOSUSUARIO = value; }
        }
        
        public string Senha
        {
            get { return SENHA; }
            set { SENHA = value; }
        }
        
        public string Usuario
        {
            get { return USUARIO; }
            set { USUARIO = value; }
        }
        
        public int IdAcesso
        {
            get { return IDACESSO; }
            set { IDACESSO = value; }
        }
        
    }
}