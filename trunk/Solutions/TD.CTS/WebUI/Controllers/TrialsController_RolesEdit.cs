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
using TD.CTS.WebUI.Models;

namespace TD.CTS.WebUI.Controllers
{
    public partial class TrialsController
    {
        public ActionResult RolesEdit(string id)
        {
            ViewBag.Title = "Роли исследования";

            ViewBag.TrialCenters = DataProvider.GetList(new TrialCenterDataFilter { TrialCode = id });
            ViewBag.Roles = DataProvider.GetList(new RoleDataFilter());

            return View(new Trial { Code = id, Version = 1 });
        }
        
        #region TrialCenterProcedureRole

        public ActionResult GetTrialCenterProcedureRoles([DataSourceRequest]DataSourceRequest request, TrialCenterProcedureRoleDataFilter dataFilter)
        {
            var trialRoles = DataProvider.GetList(dataFilter);
            var response = DataProvider.GetList(new TrialProcedureDataFilter
            {
                TrialCode = dataFilter.TrialCode,
                TrialVersion = dataFilter.TrialVersion
            })
                .Select(p => TrialProcedureRolesViewModel.Create(p, trialRoles));

            return Json(response.ToDataSourceResult(request));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult AddTrialCenterProcedureRole([DataSourceRequest] DataSourceRequest request, TrialCenterProcedureRole role)
        {
            if (role != null && ModelState.IsValid)
            {
                DataProvider.Add(role);
            }

            return Json(role);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult DeleteTrialCenterProcedureRole([DataSourceRequest] DataSourceRequest request, TrialCenterProcedureRole role)
        {
            if (role != null)
            {
                DataProvider.Delete(role);
            }

            return Json(role);
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