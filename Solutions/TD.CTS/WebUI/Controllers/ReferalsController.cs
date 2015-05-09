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
    public class ReferalsController : BaseController
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Рефералы";

            ViewBag.Hospitals = DataProvider.GetList(new HospitalDataFilter());
            ViewBag.Cities = DataProvider.GetList(new CityDataFilter());

            return View();
        }

        public ActionResult GetReferals([DataSourceRequest]DataSourceRequest request, ReferalDataFilter dataFilter)
        {
            var response = DataProvider.GetList(dataFilter ?? new ReferalDataFilter());

            return Json(response.ToDataSourceResult(request));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult AddReferal([DataSourceRequest] DataSourceRequest request, Referal referal)
        {
            if (referal != null && ModelState.IsValid)
            {
                DataProvider.Add(referal);
            }

            return Json(new[] { referal }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult UpdateReferal([DataSourceRequest] DataSourceRequest request, Referal referal)
        {
            if (referal != null && ModelState.IsValid)
            {
                DataProvider.Update(referal);
            }

            return Json(new[] { referal }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult DeleteReferal([DataSourceRequest] DataSourceRequest request, Referal referal)
        {
            if (referal != null)
            {
                DataProvider.Delete(referal);
            }

            return Json(new[] { referal }.ToDataSourceResult(request, ModelState));
        }
    }
}