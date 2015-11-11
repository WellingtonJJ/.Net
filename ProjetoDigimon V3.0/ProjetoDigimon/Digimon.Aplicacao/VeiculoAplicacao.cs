using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Digimon.Dominio;
using Digimon.Repositorio;
using System.Data;
using System.Data.SqlClient;

namespace Digimon.Aplicacao
{
    public class VeiculoAplicacao
    {
        private Contexto contexto;

        private void Inserir(ClasseVeiculo veiculo)
        {
            var strQuery = "";

            strQuery += " INSERT INTO VEICULO(PLACA, RENAVAM, ANODEFABRIC, TIPO, MODELO, MARCA, NUMEIXOS, TARA, CMT, PBT, CIDADE, UF)";
            strQuery += string.Format("VALUES(@IdTransportador,'{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}')", veiculo.Placa,
                veiculo.Renavam, veiculo.AnoDeFabrica, veiculo.Tipo, veiculo.Modelo, veiculo.Marca, veiculo.NumEixos, veiculo.Tara, veiculo.CMT, veiculo.PBT, veiculo.Cidade, veiculo.UF);

            using (contexto = new Contexto())
            {
                contexto.ExecutaGravacao(strQuery);
            }
        }
        private void Alterar(ClasseVeiculo veiculo)
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
        public void Salvar(ClasseVeiculo veiculo)
        {
            if (veiculo.IdVeiculo > 0)
                Alterar(veiculo);
            else
                Inserir(veiculo);

        }
        public List<ClasseVeiculo> ListarTransportador()
        {
            using (contexto = new Contexto())
            {
                var strQuery = "SELECT T.IDTRANSPORTADOR, CASE WHEN T.TIPOPESSOA = 'F' THEN F.NOME ELSE J.NOMEFANTASIA END AS NOME_TRANSPORTADOR FROM TRANSPORTADOR T INNER JOIN PESSOAFISICA F ON T.IDPESSOAFISICA = F.IDPESSOAFISICA INNER JOIN PESSOAJURIDICA J ON T.IDPESSOA = J.IDPESSOAJURIDICA";
                var retorno = contexto.ExecutaLeitura(strQuery);
                return TransformaReaderEmLista(retorno);
            }
        }
        private List<ClasseVeiculo> TransformaReaderEmLista(SqlDataReader reader)
        {
            var transportador = new List<ClasseVeiculo>();
            while (reader.Read())
            {
                var temObjeto = new ClasseVeiculo
                {
                    IdTransportador = int.Parse(reader["IDTRANSPORTADOR"].ToString()),
                    Transportador = reader["NOME_TRANSPORTADOR"].ToString()
                };
                transportador.Add(temObjeto);
            }
            reader.Close();
            reader.Dispose();
            return transportador;
        }
    }
}
