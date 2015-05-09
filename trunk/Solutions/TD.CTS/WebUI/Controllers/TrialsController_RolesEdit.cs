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
    public partial class TrialsController
    {
        public ActionResult RolesEdit(string id)
        {
            ViewBag.Title = "Роли исследования";

            ViewBag.Procedures = DataProvider.GetList(new ProcedureDataFilter());
            ViewBag.TrialCenters = DataProvider.GetList(new TrialCenterDataFilter { TrialCode = id });
            ViewBag.Roles = DataProvider.GetList(new RoleDataFilter());

            return View((object)id);
        }

        #region TrialCenterProcedureRole

        public ActionResult GetTrialCenterProcedureRoles([DataSourceRequest]DataSourceRequest request, int trialProcedureId)
        {
            var response = DataProvider.GetList(new TrialCenterProcedureRoleDataFilter { TrialProcedureId = trialProcedureId });

            return Json(response.ToDataSourceResult(request));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult AddTrialCenterProcedureRole([DataSourceRequest] DataSourceRequest request, TrialCenterProcedureRole role, int procedureId)
        {
            role.TrialProcedureId = procedureId;
            if (role != null && ModelState.IsValid)
            {
                DataProvider.Add(role);
            }

            return Json(new[] { role }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult UpdateTrialCenterProcedureRole([DataSourceRequest] DataSourceRequest request, TrialCenterProcedureRole role)
        {
            if (role != null && ModelState.IsValid)
            {
                DataProvider.Update(role);
            }

            return Json(new[] { role }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult DeleteTrialCenterProcedureRole([DataSourceRequest] DataSourceRequest request, TrialCenterProcedureRole role)
        {
            if (role != null)
            {
                DataProvider.Delete(role);
            }

            return Json(new[] { role }.ToDataSourceResult(request, ModelState));
        }

        #endregion

        #region TrialIncomeArticle

        public ActionResult GetTrialIncomeArticles([DataSourceRequest]DataSourceRequest request, string trialCode)
        {
            var response = DataProvider.GetList(new TrialIncomeArticleDataFilter { TrialCode = trialCode });

            return Json(response.ToDataSourceResult(request));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult AddTrialIncomeArticle([DataSourceRequest] DataSourceRequest request, TrialIncomeArticle article)
        {
            if (article != null && ModelState.IsValid)
            {
                DataProvider.Add(article);
            }

            return Json(new[] { article }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult UpdateTrialIncomeArticle([DataSourceRequest] DataSourceRequest request, TrialIncomeArticle article)
        {
            if (article != null && ModelState.IsValid)
            {
                DataProvider.Update(article);
            }

            return Json(new[] { article }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult DeleteTrialIncomeArticle([DataSourceRequest] DataSourceRequest request, TrialIncomeArticle article)
        {
            if (article != null)
            {
                DataProvider.Delete(article);
            }

            return Json(new[] { article }.ToDataSourceResult(request, ModelState));
        }

        #endregion
    }
}