using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Repositorio
{
    public class Contexto : IDisposable
    {
        private readonly SqlConnection minhaConexao;

        public Contexto()
        {
            minhaConexao = new SqlConnection(ConfigurationManager.ConnectionStrings["DigimonConfig"].ConnectionString);
            minhaConexao.Open();
        }

        public void ExecutaGravacao(string strQuery)
        {
            var cmdComando = new SqlCommand
            {
                CommandType = CommandType.Text,
                CommandText = strQuery,
                Connection = minhaConexao
            };
            cmdComando.ExecuteNonQuery();
        }

        public SqlDataReader ExecutaLeitura(string strQuery)
        {
            var cmdComando = new SqlCommand(strQuery, minhaConexao);
            return cmdComando.ExecuteReader();
        }

        public void Dispose()
        {
            if(minhaConexao.State == ConnectionState.Open)
                minhaConexao.Close();
        }
    }
}
