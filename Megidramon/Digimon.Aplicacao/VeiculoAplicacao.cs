using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repositorio;
using Digimon.Dominio;
using System.Data.SqlClient;

namespace Digimon.Aplicacao
{
    public class VeiculoAplicacao
    {
        private Contexto contexto;

        private void Inserir(Veiculo veiculo)
        {
            var strQuery = "";
            strQuery += " INSERT INTO VEICULO(IDTRANSPORTADOR,PLACA, RENAVAM, ANODEFABRIC, TIPO, MODELO, MARCA, NUMEIXOS, TARA, CMT, PBT, CIDADE, UF)";
            strQuery += string.Format("VALUES({0},'{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}')", veiculo.IdTransportador, veiculo.Placa,
                veiculo.Renavam, veiculo.AnoDeFabrica, veiculo.Tipo, veiculo.Modelo, veiculo.Marca, veiculo.NumEixos, veiculo.Tara, veiculo.CMT, veiculo.PBT, veiculo.Cidade, veiculo.UF);


            using (contexto = new Contexto())
            {
                contexto.ExecutaGravacao(strQuery);
            }
        }
        private void Alterar(Veiculo veiculo)
        {
            var strQuery = "";

            strQuery += "DECLARE @IdVeiculo int";
            strQuery += string.Format("SET @IdVeiculo = (SELECT IDVEICULO FROM MOTORISTA WHERE PLACA = '{0}')", veiculo.Placa);
            strQuery += "UPDATE VEICULO SET";
            strQuery += string.Format("PLACA = '{0}', RENAVAM = '{1}', ANODEFABRIC = '{2}', TIPO = '{3}', MODELO = '{4}', MARCA = '{5}', NUMEIXOS = '{6}', TARA = '{7}', CMT = '{8}', PBT = '{9}', CIDADE = '{10}', UF = '{11}'"
                , veiculo.Placa, veiculo.Renavam, veiculo.AnoDeFabrica, veiculo.Tipo, veiculo.Modelo, veiculo.Marca, veiculo.NumEixos, veiculo.Tara, veiculo.CMT, veiculo.PBT, veiculo.Cidade, veiculo.UF);

            using (contexto = new Contexto())
            {
                contexto.ExecutaGravacao(strQuery);
            }
        }
        public void Salvar(Veiculo veiculo)
        {
            if (veiculo.IdVeiculo > 0)
                Alterar(veiculo);
            else
                Inserir(veiculo);

        }
        public List<TransportadorEmpresa> ListarTransportador()
        {
            using (contexto = new Contexto())
            {
                //var strQuery = "SELECT T.IDTRANSPORTADOR, CASE WHEN T.TIPOPESSOA = 'F' THEN F.NOME ELSE J.NOMEFANTASIA END AS NOME_TRANSPORTADOR FROM TRANSPORTADOR T INNER JOIN PESSOAFISICA F ON T.IDPESSOAFISICA = F.IDPESSOAFISICA INNER JOIN PESSOAJURIDICA J ON T.IDPESSOA = J.IDPESSOAJURIDICA";
                StringBuilder sql = new StringBuilder();

                sql.Append("SELECT T.IDTRANSPORTADOR, CASE WHEN F.NOME IS NULL THEN J.NOMEFANTASIA ELSE F.NOME ");
                sql.Append("END AS NOME_TRANSPORTADOR FROM TRANSPORTADOR T ");
                sql.Append("LEFT JOIN PESSOAFISICA F ON F.IDPESSOAFISICA = T.IDPESSOA AND T.TIPOPESSOA = 'F' ");
                sql.Append("LEFT JOIN PESSOAJURIDICA J ON J.IDPESSOAJURIDICA = T.IDPESSOA AND T.TIPOPESSOA = 'J' ");

                var retorno = contexto.ExecutaLeitura(sql.ToString());
                return TransformaReaderEmLista(retorno);
            }
        }
        private List<TransportadorEmpresa> TransformaReaderEmLista(SqlDataReader reader)
        {
            var transportador = new List<TransportadorEmpresa>();
            while (reader.Read())
            {
                var temObjeto = new TransportadorEmpresa
                {
                    IdTransportador = int.Parse(reader["IDTRANSPORTADOR"].ToString()),
                    Nome = reader["NOME_TRANSPORTADOR"].ToString()
                };
                transportador.Add(temObjeto);
            }
            reader.Close();
            reader.Dispose();
            return transportador;
        }
    }
}
