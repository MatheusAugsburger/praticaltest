using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PraticalTest.Models;

namespace PraticalTest.Controllers
{
    public class HomeController : Controller
    {
        [AllowAnonymous]
        public ActionResult Contatos(string Name, int? GenderId, int? CityId, int? RegionId, DateTime? LastPurchaseIni, DateTime? LastPurchaseFim, int? ClassificationId, int? SellerId)
        {
            var model = new ContatosViewModel();
            model.Contatos = ContatosModel.BuscaContatos(Name, GenderId, CityId, RegionId, LastPurchaseIni, LastPurchaseFim, ClassificationId, SellerId);
            model.Gender = GenderModel.BuscaGender();
            model.City = CityModel.BuscaCitys();
            model.Classification = ClassificationModel.BuscaClasssification();
            model.Seller = SellerModel.BuscaSeller();
            model.Region = RegionModel.BuscaRegion();
            ViewBag.Contatos = new ContatosViewModel();
            return View(model);
        }


    }
}