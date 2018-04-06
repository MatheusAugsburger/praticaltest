using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PraticalTest.Models
{
    public class SellerModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsAdmin { get; set; }
        public static List<SellerModel> BuscaSeller()
        {
            var ret = new List<SellerModel>();

            using (var conexao = new SqlConnection())
            {
                conexao.ConnectionString = "Data Source=MATHEUS-PC;Initial Catalog=GerenciadorDeContatos;Integrated Security=True";
                conexao.Open();

                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;

                    comando.CommandText = string.Format(
                        "select * from UserRole ");
                    var reader = comando.ExecuteReader();
                    while (reader.Read())
                    {
                        ret.Add(new SellerModel
                        {
                            Id = (int)reader["Id"],
                            Name = (string)reader["Name"],
                            IsAdmin = (bool)reader["IsAdmin"]

                        });
                    }
                }
            }
            return ret;

        }
    
    }
}