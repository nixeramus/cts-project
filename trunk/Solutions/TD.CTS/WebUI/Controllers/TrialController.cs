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
    public partial class TrialsController : BaseController
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Исследования";

            ViewBag.Users = DataProvider.GetList(new UserDataFilter());

            return View();
        }

        #region Trial

        public ActionResult GetTrials([DataSourceRequest]DataSourceRequest request, TrialDataFilter dataFilter)
        {
            var response = DataProvider.GetList(dataFilter ?? new TrialDataFilter());

            return Json(response.ToDataSourceResult(request));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult AddTrial([DataSourceRequest] DataSourceRequest request, Trial trial)
        {
            if (trial != null && ModelState.IsValid)
            {
                DataProvider.Add(trial);
            }

            return Json(new[] { trial }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult UpdateTrial([DataSourceRequest] DataSourceRequest request, Trial trial)
        {
            if (trial != null && ModelState.IsValid)
            {
                DataProvider.Update(trial);
            }

            return Json(new[] { trial }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult DeleteTrial([DataSourceRequest] DataSourceRequest request, Trial trial)
        {
            if (trial != null)
            {
                DataProvider.Delete(trial);
            }

            return Json(new[] { trial }.ToDataSourceResult(request, ModelState));
        }

        #endregion
    }
}