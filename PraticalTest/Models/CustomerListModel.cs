using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PraticalTest.Models
{
    public class CustomerListModel
    {
        public int Id { get; set; }

        [Display(Name = "Name: ")]
        public string Name { get; set; }

        public string Phone { get; set; }

        [Display(Name = "Gender: ")]
        public int GenderId { get; set; }

        [Display(Name = "City: ")]
        public int CityId { get; set; }

        [Display(Name = "Region: ")]
        public int RegionId { get; set; }

        [Display(Name = "Seller: ")]
        public string SellerName { get; set; }

        
        public string ClassificationName { get; set; }

        public string CityName { get; set; }
        public string GenderName { get; set; }
        public string RegionName { get; set; }


        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{yyyy-MM-dd}")]
        public DateTime LastPurchase { get; set; }

        [Display(Name = "Classification: ")]
        public int ClassificationId { get; set; }

        public int UserId { get; set; }

        public static List<CustomerListModel> BuscaContatos(string Name, int? GenderId, int? CityId, int? RegionId, DateTime? LastPurchaseIni, DateTime? LastPurchaseFim, int? ClassificationId, int? SellerId, string login)
        {
            var ret = new List<CustomerListModel>();
            String Filtro = "";

            using (var comando = new SqlCommand())
            {
                comando.Connection = Conexao.connection;
                /*
                comando.CommandText = string.Format(
                    "select * from Customer where Name='{0}' and GenderId='{1}' and CityId='{2}' " +
                    "and RegionId='{3}' and LastPurchase>='{4}' and LastPurchase <='{5}' and ClassificationId='{6}'", Name, GenderId, CityId, RegionId, LastPurchaseIni, LastPurchaseFim, ClassificationId);
                */
                comando.CommandType = CommandType.Text;
                comando.CommandText = String.Format("select Customer.Id,Customer.Name,Customer.GenderId,Customer.CityId,Customer.RegionId,Customer.LastPurchase,Customer.ClassificationId,Customer.Phone,Customer.UserId,City.Name as Cidade,Classification.Name as Class,Region.Name as Regiao,Gender.Name as Sexo,UserSys.Login as Usuario " +
                                                    "from Customer " +
                                                    "INNER JOIN City  ON Customer.CityId=City.Id " +
                                                    "INNER JOIN Classification ON Customer.ClassificationId=Classification.Id " +
                                                    "INNER JOIN Gender ON Customer.GenderId=Gender.Id " +
                                                    "INNER JOIN Region  ON Customer.RegionId=Region.Id " +
                                                    "INNER JOIN UserSys ON Customer.UserId=UserSys.Id " +
                                                    "INNER JOIN UserRole ON UserSys.UserRoleId=UserRole.Id ");


                if (!String.IsNullOrEmpty(Name))
                {
                    if (String.IsNullOrEmpty(Filtro))
                    {
                        Filtro += String.Format("where Customer.Name LIKE '%{0}%'", Name);
                    }
                    else
                    {
                        Filtro += String.Format(" and Customer.Name LIKE '%{0}%'", Name);
                    }

                }

                if (GenderId.HasValue)
                {
                    if (String.IsNullOrEmpty(Filtro)) {
                        Filtro += String.Format("where Customer.GenderId = '{0}'", GenderId);
                    }
                    else {
                        Filtro += String.Format(" and Customer.GenderId = '{0}'", GenderId);
                    }
            
                }
                if (CityId.HasValue)
                {
                    if (String.IsNullOrEmpty(Filtro))
                    {
                        Filtro += String.Format("where Customer.CityId = '{0}'", CityId);
                    }
                    else
                    {
                        Filtro += String.Format(" and Customer.CityId = '{0}'", CityId);
                    }

                }
                if (RegionId.HasValue)
                {
                    if (String.IsNullOrEmpty(Filtro))
                    {
                        Filtro += String.Format("where Customer.RegionId = '{0}'", RegionId);
                    }
                    else
                    {
                        Filtro += String.Format(" and Customer.RegionId = '{0}'", RegionId);
                    }

                }
                if (LastPurchaseIni.HasValue)
                {
                    if (String.IsNullOrEmpty(Filtro))
                    {
                        Filtro += String.Format("where Customer.LastPurchase >= '{0}'", LastPurchaseIni);
                    }
                    else
                    {
                        Filtro += String.Format(" and Customer.LastPurchase >= '{0}'", LastPurchaseIni);
                    }

                }
                if (LastPurchaseFim.HasValue)
                {
                    if (String.IsNullOrEmpty(Filtro))
                    {
                        Filtro += String.Format("where Customer.LastPurchase <= '{0}'", LastPurchaseFim);
                    }
                    else
                    {
                        Filtro += String.Format(" and Customer.LastPurchase <= '{0}'", LastPurchaseFim);
                    }

                }
                    
                if (ClassificationId.HasValue)
                {
                    if (String.IsNullOrEmpty(Filtro))
                    {
                        Filtro += String.Format("where Customer.ClassificationId = '{0}'", ClassificationId);
                    }
                    else
                    {
                        Filtro += String.Format(" and Customer.ClassificationId = '{0}'", ClassificationId);
                    }

                }
                if (SellerId.HasValue && SellerId > 1)
                {
                    if (String.IsNullOrEmpty(Filtro))
                    {
                        Filtro += String.Format("where Customer.UserId = '{0}'", SellerId);
                    }
                    else
                    {
                        Filtro += String.Format(" and Customer.UserId = '{0}'", SellerId);
                    }

                }

                if (!String.IsNullOrEmpty(login))
                {
                    UsuarioModel Usuario = UsuarioModel.BuscaUsuario(login);
                    if (Usuario != null && Usuario.UserRoleId > 1)
                    {
                        Filtro += String.Format(" and Customer.UserId = '{0}'", Usuario.UserRoleId);
                    }
                        

                }
                    

                comando.CommandText += Filtro;
                Conexao.Conectar();
                var reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    ret.Add(new CustomerListModel
                    {
                        Id = (int)reader["Id"],
                        Name = (string)reader["Name"],
                        GenderId = (int)reader["GenderId"],
                        CityId = (int)reader["CityId"],
                        RegionId = (int)reader["RegionId"],
                        LastPurchase = (DateTime)reader["LastPurchase"],
                        ClassificationId = (int)reader["ClassificationId"],
                        Phone = (string)reader["Phone"],
                        UserId = (int)reader["UserId"],
                        CityName = (string)reader["Cidade"],
                        ClassificationName = (string)reader["Class"],
                        RegionName = (string)reader["Regiao"],
                        GenderName = (string)reader["Sexo"],
                        SellerName = (string)reader["Usuario"]
                    });
                }
                Conexao.Desconectar();
            }
            
            return ret;

        }

    }
}