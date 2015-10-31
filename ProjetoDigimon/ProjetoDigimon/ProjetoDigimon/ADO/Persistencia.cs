using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using ProjetoDigimon.ADO;

namespace ProjetoDigimon.ADO
{
    public class Persistencia
    {
        public void Create()
        {
        
        }
        public void Read()
        {
            string strQuerySelect = "SELECT * FROM VEICULO";
            SqlCommand cmdRead = new SqlCommand(strQuerySelect, );
            SqlDataReader rd = cmdRead.ExecuteReader();
        }
        public void Update()
        { 
        string strQueryUpdate = "UPDATE
        }
        public void Delete()
        {
        
        }
    }
}