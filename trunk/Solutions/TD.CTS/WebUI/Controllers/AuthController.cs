using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TD.CTS.Auth;
using TD.CTS.WebUI.Common;

namespace TD.CTS.WebUI.Controllers
{
    public class AuthController : Controller
    {
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            //return View(new Credentials { Username = "cts", Password = "cts_" });
            return View();
        }

        [HttpPost]
        public ActionResult Login(Credentials credentials, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var authenticator = new Authenticator();

                if (authenticator.Authenticate(credentials))
                {
                    ApplicationSettings.Authenticator = authenticator;
                    if (authenticator.NeedChangePassword)
                    {
                        return RedirectToAction("ChangePassword", new { returnUrl = returnUrl });
                    }

                    return RedirectToLocal(returnUrl);
                }

                ModelState.AddModelError("", "Пользователь с таким сочетанием логина и пароля не найден");
            }

            return View(credentials);
        }

        public ActionResult Logout()
        {
            ApplicationSettings.Clear();
            return RedirectToAction("Login");
        }

        public ActionResult ChangePassword(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        public ActionResult ChangePassword(ChangePassword data, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var authenticator = ApplicationSettings.Authenticator;
                if (authenticator == null)
                {
                    return RedirectToAction("Login", new { returnUrl = returnUrl });
                }

                if (authenticator.ChangePassword(data))
                {
                    ApplicationSettings.Authenticator = authenticator;
                    return RedirectToLocal(returnUrl);
                }

                ModelState.AddModelError("", "Ошибка смены пароля. Проверьте корректность ввода текущего пароля");
            }

            return View(data);
        }

        [HttpPost]
        public ActionResult CancelChangePassword(string returnUrl)
        {
            var authenticator = ApplicationSettings.Authenticator;
            if (authenticator != null && !authenticator.NeedChangePassword)
                return RedirectToLocal(returnUrl);

            return Logout();
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            returnUrl = returnUrl.Replace("&amp;", "&");
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}