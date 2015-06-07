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
    public class ProcedureGroupsController : BaseController
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Группы процедур";

            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult GetProcedureGroups([DataSourceRequest]DataSourceRequest request, ProcedureGroupDataFilter dataFilter)
        {
            var response = DataProvider.GetList(dataFilter ?? new ProcedureGroupDataFilter());

            return Json(response.ToDataSourceResult(request));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult AddProcedureGroup([DataSourceRequest] DataSourceRequest request, ProcedureGroup procedureGroup)
        {
            if (procedureGroup != null && ModelState.IsValid)
            {
                DataProvider.Add(procedureGroup);
            }

            return Json(new[] { procedureGroup }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult UpdateProcedureGroup([DataSourceRequest] DataSourceRequest request, ProcedureGroup procedureGroup)
        {
            if (procedureGroup != null && ModelState.IsValid)
            {
                DataProvider.Update(procedureGroup);
            }

            return Json(new[] { procedureGroup }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult DeleteProcedureGroup([DataSourceRequest] DataSourceRequest request, ProcedureGroup procedureGroup)
        {
            if (procedureGroup != null)
            {
                DataProvider.Delete(procedureGroup);
            }

            return Json(new[] { procedureGroup }.ToDataSourceResult(request, ModelState));
        }
    }
}