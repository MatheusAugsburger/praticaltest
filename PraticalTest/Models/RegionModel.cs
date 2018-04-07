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

        public static List<RegionModel> BuscaRegion(int? CityId)
        {
            var ret = new List<RegionModel>();

           
            using (var comando = new SqlCommand())
            {
                comando.Connection = Conexao.connection;

                if (CityId > 0)
                {
                    comando.CommandText = string.Format(
                            "select * from Region " +
                            "INNER JOIN City on City.RegionId=Region.Id " +
                            "where City.id = '{0}' ", CityId);
                }
                else
                {
                    comando.CommandText = string.Format(
                            "select * from Region ");
                }
                Conexao.Conectar();
                var reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    ret.Add(new RegionModel
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