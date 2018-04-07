using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PraticalTest.Models
{
    public class UsuarioModel
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int UserRoleId { get; set; }


        public static bool ValidarUsuario(string email, string senha)
        {
            var ret = false;
            
            using(var comando = new SqlCommand())
            {
                comando.Connection = Conexao.connection;
                comando.CommandText = string.Format(
                    "select count(*) from UserSys where Email='{0}' and Password='{1}'", email, senha);
                Conexao.Conectar();
                ret = ((int)comando.ExecuteScalar() > 0);

            }
            Conexao.Desconectar();
            
            return ret;
        }
        public static UsuarioModel BuscaUsuario(string usuario)
        {
            var ret = new UsuarioModel();           

            using (var comando = new SqlCommand())
            {
                comando.Connection = Conexao.connection;

                comando.CommandText = string.Format(
                    "select * from UserSys where Login = '{0}' or Email = '{1}'", usuario, usuario); Conexao.Desconectar();
                Conexao.Desconectar();
                Conexao.Conectar();
                var reader = comando.ExecuteReader();
                while (reader.Read())
                {

                    ret.Id = (int)reader["Id"];
                    ret.Login = (string)reader["Login"];
                    ret.Email = (string)reader["Email"];
                    ret.UserRoleId = (int)reader["UserRoleId"];
                       
                }
                Conexao.Desconectar();
            }
            
            return ret;

        }
    }
}