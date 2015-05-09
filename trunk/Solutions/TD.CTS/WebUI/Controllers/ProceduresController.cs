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
    public class ProceduresController : BaseController
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Процедуры";

            return View();
        }

        public ActionResult GetProcedures([DataSourceRequest]DataSourceRequest request, ProcedureDataFilter dataFilter)
        {
            var response = DataProvider.GetList<Procedure>(dataFilter ?? new ProcedureDataFilter());

            return Json(response.ToDataSourceResult(request));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult AddProcedure([DataSourceRequest] DataSourceRequest request, Procedure procedure)
        {
            if (procedure != null && ModelState.IsValid)
            {
                DataProvider.Add(procedure);
            }

            return Json(new[] { procedure }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult UpdateProcedure([DataSourceRequest] DataSourceRequest request, Procedure procedure)
        {
            if (procedure != null && ModelState.IsValid)
            {
                DataProvider.Update(procedure);
            }

            return Json(new[] { procedure }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult DeleteProcedure([DataSourceRequest] DataSourceRequest request, Procedure procedure)
        {
            if (procedure != null)
            {
                DataProvider.Delete(procedure);
            }

            return Json(new[] { procedure }.ToDataSourceResult(request, ModelState));
        }
    }
}