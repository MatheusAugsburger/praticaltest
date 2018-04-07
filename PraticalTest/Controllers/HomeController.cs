using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using PraticalTest.Models;

namespace PraticalTest.Controllers
{
    public class HomeController : Controller
    {
        [AllowAnonymous]
        public ActionResult CustomerList( string Name, int? Gender, int? City, int? Region, DateTime? LastPurchaseIni, DateTime? LastPurchaseFim, int? Classification, int? Seller)
        {
            var login = Session["Login"];
           
            if (login == null)
            {
                FormsAuthentication.SignOut();
                return RedirectToAction("Login", "Conta");
            }
            var model = new CustomerListViewModel();
            
            
            model.Contatos = CustomerListModel.BuscaContatos(Name, Gender, City, Region, LastPurchaseIni, LastPurchaseFim, Classification, Seller, login.ToString());
            model.Gender = GenderModel.BuscaGender();
            model.City = CityModel.BuscaCitys();
            model.Classification = ClassificationModel.BuscaClasssification();
            model.Seller = SellerModel.BuscaSeller(login.ToString());
            model.Region = RegionModel.BuscaRegion(City);
            ViewBag.Contatos = new CustomerListViewModel();
            return View(model);
        }


    }
}