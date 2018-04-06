using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using PraticalTest.Models;

namespace PraticalTest.Controllers
{
    public class ContaController : Controller
    {
        [AllowAnonymous]
        // GET: Conta
        public ActionResult Login( string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(LoginViewModel login, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(login);
            }
            var achou = (UsuarioModel.ValidarUsuario(login.Usuario, login.Senha));

            if (achou)
            {
                FormsAuthentication.SetAuthCookie(login.Usuario, login.LembrarMe);
                if (Url.IsLocalUrl(returnUrl))
                {
                    return Redirect(returnUrl);
                }
                else
                {
                    return RedirectToAction("Contatos", "Home");
                }
            }
            else
            {
                ModelState.AddModelError("","Login Inválido.");
            }
            return View(login);
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Conta");
        }
    }
}