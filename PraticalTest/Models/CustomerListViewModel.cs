using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PraticalTest.Models
{
    public class CustomerListViewModel
    {
        public List<CityModel> City { get; set; }
        public List<ClassificationModel> Classification { get; set; }
        public List<GenderModel> Gender { get; set; }
        public List<RegionModel> Region { get; set; }
        public List<SellerModel> Seller { get; set; }
        public List<CustomerListModel> Contatos { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime LastPurchaseIni { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime LastPurchaseFim { get; set; }




    }
}