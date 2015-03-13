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
    public class HospitalsController : BaseController
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Медицинские учереждения";

            ViewBag.Cities = DataProvider.GetList<City>(new CityDataFilter());

            return View();
        }

        public ActionResult GetHospitals([DataSourceRequest]DataSourceRequest request, HospitalDataFilter dataFilter)
        {
            var response = DataProvider.GetList<Hospital>(dataFilter ?? new HospitalDataFilter());

            return Json(response.ToDataSourceResult(request));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult AddHospital([DataSourceRequest] DataSourceRequest request, Hospital hospital)
        {
            if (hospital != null && ModelState.IsValid)
            {
                DataProvider.Add(hospital);
            }

            return Json(new[] { hospital }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult UpdateHospital([DataSourceRequest] DataSourceRequest request, Hospital hospital)
        {
            if (hospital != null && ModelState.IsValid)
            {
                DataProvider.Update(hospital);
            }

            return Json(new[] { hospital }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult DeleteHospital([DataSourceRequest] DataSourceRequest request, Hospital hospital)
        {
            if (hospital != null)
            {
                DataProvider.Delete(hospital);
            }

            return Json(new[] { hospital }.ToDataSourceResult(request, ModelState));
        }
    }
}