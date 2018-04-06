using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PraticalTest.Models
{
    public class ClassificationModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public static List<ClassificationModel> BuscaClasssification()
        {
            var ret = new List<ClassificationModel>();

            using (var conexao = new SqlConnection())
            {
                conexao.ConnectionString = "Data Source=MATHEUS-PC;Initial Catalog=GerenciadorDeContatos;Integrated Security=True";
                conexao.Open();

                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;

                    comando.CommandText = string.Format(
                        "select * from Classification ");
                    var reader = comando.ExecuteReader();
                    while (reader.Read())
                    {
                        ret.Add(new ClassificationModel
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