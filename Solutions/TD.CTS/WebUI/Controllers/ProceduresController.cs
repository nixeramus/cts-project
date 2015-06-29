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

            ViewBag.ProcedureGroups = DataProvider.GetList(new ProcedureGroupDataFilter());
            ViewBag.Roles = DataProvider.GetList(new RoleDataFilter());

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

        public ActionResult GetProcedureRoles([DataSourceRequest]DataSourceRequest request, ProcedureDefaultRoleDataFilter dataFilter)
        {
            var response = DataProvider.GetList<ProcedureDefaultRole>(dataFilter ?? new ProcedureDefaultRoleDataFilter());

            return Json(response.ToDataSourceResult(request));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult AddProcedureRole([DataSourceRequest] DataSourceRequest request, ProcedureDefaultRole procedureRole)
        {
            if (procedureRole != null && ModelState.IsValid)
            {
                DataProvider.Add(procedureRole);
            }

            return Json(new[] { procedureRole }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult DeleteProcedureRole([DataSourceRequest] DataSourceRequest request, ProcedureDefaultRole procedureRole)
        {
            if (procedureRole != null)
            {
                DataProvider.Delete(procedureRole);
            }

            return Json(new[] { procedureRole }.ToDataSourceResult(request, ModelState));
        }
    }
}