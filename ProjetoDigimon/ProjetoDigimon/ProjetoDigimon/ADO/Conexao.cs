using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace ProjetoDigimon.ADO
{
    public class Conexao
    {
        SqlConnection con;
       
        public void AbrirConexao()
        {
            
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConnection"].ConnectionString);
            con.Open();

        }
        public void FecharConexao()
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConnection"].ConnectionString);
            con.Close();
        }
    }
}