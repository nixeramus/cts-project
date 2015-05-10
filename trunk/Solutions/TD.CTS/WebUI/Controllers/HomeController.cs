using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TD.CTS.WebUI.Common;

namespace TD.CTS.WebUI.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Бета версия";

            return View();
        }

        public ActionResult UnderConstruction()
        {
            ViewBag.Title = "Функционал разрабатывается";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult ChangeTheme(string theme, string url)
        {
            UserSettings.SelectedTheme = ThemeManager.GetTheme(theme);

            return Redirect(url);
        }
    }
}
