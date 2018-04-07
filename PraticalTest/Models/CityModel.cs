using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PraticalTest.Models
{
    public class CityModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int RegionId { get; set; }
        public static List<CityModel> BuscaCitys()
        {
            var ret = new List<CityModel>();

      
            /*
            conexao.ConnectionString = "Data Source=MATHEUS-PC;Initial Catalog=GerenciadorDeContatos;Integrated Security=True";
            conexao.Open();
            */
            using (var comando = new SqlCommand())
            {

                comando.Connection = Conexao.connection;
     
                /*
                comando.CommandText = string.Format(
                    "select * from Customer where Name='{0}' and GenderId='{1}' and CityId='{2}' " +
                    "and RegionId='{3}' and LastPurchase>='{4}' and LastPurchase <='{5}' and ClassificationId='{6}'", Name, GenderId, CityId, RegionId, LastPurchaseIni, LastPurchaseFim, ClassificationId);
                */
                comando.CommandText = string.Format(
                    "select * from City ");
                Conexao.Conectar();
                var reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    ret.Add(new CityModel
                    {
                        Id = (int)reader["Id"],
                        Name = (string)reader["Name"],
                        RegionId = (int)reader["RegionId"]
                            
                    });
                }
                Conexao.Desconectar();
            }
            
            return ret;

        }
    }
}