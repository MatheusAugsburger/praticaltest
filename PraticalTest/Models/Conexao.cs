using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PraticalTest.Models
{
    public class Conexao
    {
        public static string conectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConexaoSqlServer"].ConnectionString;
        public static SqlConnection connection = new SqlConnection(conectionString);
        public static void Conectar()
        {

            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }

        }
        public static void Desconectar()
        {

            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
        }
    }
}