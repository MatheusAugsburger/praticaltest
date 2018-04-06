using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PraticalTest.Models
{
    public class ContatosViewModel
    {
        public List<CityModel> City { get; set; }
        public List<ClassificationModel> Classification { get; set; }
        public List<GenderModel> Gender { get; set; }
        public List<RegionModel> Region { get; set; }
        public List<SellerModel> Seller { get; set; }
        public List<ContatosModel> Contatos { get; set; }      


        

    }
}