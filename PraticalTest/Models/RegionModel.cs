using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PraticalTest.Models
{
    public class RegionModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public static List<RegionModel> BuscaRegion()
        {
            var ret = new List<RegionModel>();

            using (var conexao = new SqlConnection())
            {
                conexao.ConnectionString = "Data Source=MATHEUS-PC;Initial Catalog=GerenciadorDeContatos;Integrated Security=True";
                conexao.Open();

                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;

                    comando.CommandText = string.Format(
                        "select * from Region ");
                    var reader = comando.ExecuteReader();
                    while (reader.Read())
                    {
                        ret.Add(new RegionModel
                        {
                            Id = (int)reader["Id"],
                            Name = (string)reader["Name"]


                        });
                    }
                }
            }
            return ret;

        }
    }
}