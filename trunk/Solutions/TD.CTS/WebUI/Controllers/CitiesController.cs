using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TD.CTS.Data.Entities;
using TD.CTS.Data.Filters;
using TD.CTS.WebUI.Common;

namespace TD.CTS.WebUI.Controllers
{
    public class CitiesController : BaseController
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Города";

            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult GetCities([DataSourceRequest]DataSourceRequest request, CityDataFilter dataFilter)
        {
            var response = DataProvider.GetList(dataFilter ?? new CityDataFilter());

            return Json(response.ToDataSourceResult(request));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult AddCity([DataSourceRequest] DataSourceRequest request, City city)
        {
            if (city != null && ModelState.IsValid)
            {
                DataProvider.Add(city);
            }

            return Json(new[] { city }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult UpdateCity([DataSourceRequest] DataSourceRequest request, City city)
        {
            if (city != null && ModelState.IsValid)
            {
                DataProvider.Update(city);
            }

            return Json(new[] { city }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult DeleteCity([DataSourceRequest] DataSourceRequest request, City city)
        {
            if (city != null)
            {
                DataProvider.Delete(city);
            }

            return Json(new[] { city }.ToDataSourceResult(request, ModelState));
        }
    }
}