using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PraticalTest.Models
{
    public class GenderModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public static List<GenderModel> BuscaGender()
        {
            var ret = new List<GenderModel>();

          

            using (var comando = new SqlCommand())
            {
                comando.Connection = Conexao.connection;

                comando.CommandText = string.Format(
                    "select * from Gender ");
                Conexao.Conectar();
                var reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    ret.Add(new GenderModel
                    {
                        Id = (int)reader["Id"],
                        Name = (string)reader["Name"]


                    });
                }
                Conexao.Desconectar();
            }
            
            return ret;

        }
    }
}