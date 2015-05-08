using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
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
        public ActionResult GetVisits([DataSourceRequest]DataSourceRequest request, SchedulePlaningVisitDataFilter dataFilter)
        {
            var response = DataProvider.GetList(dataFilter ?? new SchedulePlaningVisitDataFilter());

            return Json(response.ToDataSourceResult(request));
        }
        
    }

  
}