using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PraticalTest.Models
{
    public class ContatosModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Phone { get; set; }

        public int GenderId { get; set; }

        public int CityId { get; set; }

        public int RegionId { get; set; }
        public int SellerId { get; set; }

        public DateTime LastPurchase { get; set; }

        public int ClassificationId { get; set; }

        public int UserId { get; set; }

        public static List<ContatosModel> BuscaContatos(string Name, int? GenderId, int? CityId, int? RegionId, DateTime? LastPurchaseIni, DateTime? LastPurchaseFim, int? ClassificationId, int? SellerId)
        {
            var ret = new List<ContatosModel>();

            using (var conexao = new SqlConnection())
            {
                conexao.ConnectionString = "Data Source=MATHEUS-PC;Initial Catalog=GerenciadorDeContatos;Integrated Security=True";
                conexao.Open();

                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;
                    /*
                    comando.CommandText = string.Format(
                        "select * from Customer where Name='{0}' and GenderId='{1}' and CityId='{2}' " +
                        "and RegionId='{3}' and LastPurchase>='{4}' and LastPurchase <='{5}' and ClassificationId='{6}'", Name, GenderId, CityId, RegionId, LastPurchaseIni, LastPurchaseFim, ClassificationId);
                    */
                    comando.CommandText = string.Format(
                        "select * from Customer ");
                    var reader = comando.ExecuteReader();
                    while (reader.Read())
                    {
                        ret.Add(new ContatosModel
                        {
                            Id = (int)reader["Id"],
                            Name = (string)reader["Name"],
                            GenderId = (int)reader["GenderId"],
                            CityId = (int)reader["CityId"],
                            RegionId = (int)reader["RegionId"],
                            LastPurchase = (DateTime)reader["LastPurchase"],
                            ClassificationId = (int)reader["ClassificationId"]

                        });
                    }
                }
            }
            return ret;

        }

    }
}