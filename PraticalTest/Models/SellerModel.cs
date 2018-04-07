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
        public int UserRoleId { get; set; }
        public static SellerModel BuscaUnicaSeller(int id)
        {

            var ret = new SellerModel();
            
            using (var comando = new SqlCommand())
            {
                comando.Connection = Conexao.connection;

                comando.CommandText = string.Format(
                    "select * from UserSys where id = '{0}'",id);
                Conexao.Conectar();
                var reader = comando.ExecuteReader();
                while (reader.Read())
                {

                    ret.Id = (int)reader["Id"];
                    ret.Name = (string)reader["Login"];
                    ret.UserRoleId = (int)reader["UserRoleId"];

                }
                Conexao.Desconectar();
            }

            return ret;

        }
        public static SellerModel BuscaPorEmailSeller(string email)
        {

            var ret = new SellerModel();

            using (var comando = new SqlCommand())
            {
                comando.Connection = Conexao.connection;

                comando.CommandText = string.Format(
                    "select * from UserSys where email = '{0}'", email);
                Conexao.Conectar();
                var reader = comando.ExecuteReader();
                while (reader.Read())
                {

                    ret.Id = (int)reader["Id"];
                    ret.Name = (string)reader["Login"];
                    ret.UserRoleId = (int)reader["UserRoleId"];

                }
                Conexao.Desconectar();
            }

            return ret;

        }
        public static List<SellerModel> BuscaSeller(string email)
        {
            var ret = new List<SellerModel>();
    
            SellerModel Seller = BuscaPorEmailSeller(email);

            using (var comando = new SqlCommand())
            {
                comando.Connection = Conexao.connection;

                if (Seller.UserRoleId == 1)
                {
                    comando.CommandText = string.Format(
                    "select * from UserSys ");
                }
                else
                {
                    comando.CommandText = string.Format(
                    "select * from UserSys where id = '{0}'",Seller.Id);
                }
                
                Conexao.Conectar();
                var reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    ret.Add(new SellerModel
                    {
                        Id = (int)reader["Id"],
                        Name = (string)reader["Login"]

                    });
                }
                Conexao.Desconectar();
            }
            
            return ret;

        }
    
    }
}