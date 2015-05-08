using System.Web.Mvc;
using TD.CTS.Data.Filters;

namespace TD.CTS.WebUI.Controllers
{
    public class SchedulesPlanningController : BaseController
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Планирование визитов";

            //ViewBag.Users = DataProvider.GetList(new UserDataFilter());

            return View();
        }
    }

  
}