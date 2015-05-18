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
using TD.Common.Data;
using TD.CTS.Data.Enums;

namespace TD.CTS.WebUI.Controllers
{
    public partial class TrialsController
    {
        public ActionResult Edit(string id, int? versionId, TrialTab? tab)
        {
            ViewBag.Tab = tab;

            Trial trial;
            if (string.IsNullOrEmpty(id))
            {
                ViewBag.IsNew = true;
                trial = new Trial { Version = 1 };
                //ViewBag.Versions = new[] { new { Id = 1, Name = "1 (Новая)" } };
                ViewBag.Title = "Создание исследования";
            }
            else
            {
                trial = DataProvider.GetItem(new TrialDataFilter { Code = id });
                trial.Version = versionId.HasValue ? versionId.Value : 1;
                if (trial == null)
                    throw new ApplicationException("Исследование с кодом '" + id + "' не найдено");
                ViewBag.IsNew = false;
                //ViewBag.Versions = DataProvider.GetList(new TrialVersionDataFilter()).Select(v => new { Id = v.Id, Name = string.Format("{0} ({1})", v.Id, v.VersionStatus) });
                ViewBag.Versions = new[] { new { Id = 1, Name = "1 (Новая)" } };
                ViewBag.Title = "Описание исследования";
            }

            switch (tab)
            {
                case TrialTab.Main:
                case null:
                    ViewBag.Statuses = EnumExtensions.GetDictionary(typeof(TrialStatus)).Where(x => x.Key >= (int)trial.Status);
                    
                    var users = DataProvider.GetList(new UserDataFilter());
                    ViewBag.Users = users;
                    ViewBag.AdministratorLogin_Data = new SelectList(users, "Login", "FullName");
                    ViewBag.Hospitals = DataProvider.GetList(new HospitalDataFilter());
                    break;
                case TrialTab.Visits:
                    ViewBag.Procedures = DataProvider.GetList(new ProcedureDataFilter());
                    ViewBag.Visits = DataProvider
                        .GetList(new TrialVisitDataFilter { TrialCode = trial.Code, TrialVersion = trial.Version  })
                        .OrderBy(v => v.Days);
                    break;
                case TrialTab.Roles:
                    ViewBag.Procedures = DataProvider.GetList(new ProcedureDataFilter());
                    ViewBag.TrialCenters = DataProvider.GetList(new TrialCenterDataFilter { TrialCode = id });
                    ViewBag.Roles = DataProvider.GetList(new RoleDataFilter());
                    break;
            }

            return View(trial);
        }

        #region TrialCenters
        public ActionResult GetTrialCenters([DataSourceRequest]DataSourceRequest request, TrialCenterDataFilter dataFilter)
        {
            var response = DataProvider.GetList(dataFilter);

            return Json(response.ToDataSourceResult(request));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult AddTrialCenter([DataSourceRequest] DataSourceRequest request, TrialCenter trialCenter)
        {
            if (trialCenter != null && ModelState.IsValid)
            {
                DataProvider.Add(trialCenter);
            }

            return Json(new[] { trialCenter }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult UpdateTrialCenter([DataSourceRequest] DataSourceRequest request, TrialCenter trialCenter)
        {
            if (trialCenter != null && ModelState.IsValid)
            {
                DataProvider.Update(trialCenter);
            }

            return Json(new[] { trialCenter }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult DeleteTrialCenter([DataSourceRequest] DataSourceRequest request, TrialCenter trialCenter)
        {
            if (trialCenter != null)
            {
                DataProvider.Delete(trialCenter);
            }

            return Json(new[] { trialCenter }.ToDataSourceResult(request, ModelState));
        }

        #endregion

        #region TrialMaterials

        public ActionResult GetTrialMaterials([DataSourceRequest]DataSourceRequest request, TrialMaterialDataFilter dataFilter)
        {
            var response = DataProvider.GetList(dataFilter);

            return Json(response.ToDataSourceResult(request));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult AddTrialMaterial([DataSourceRequest] DataSourceRequest request, TrialMaterial trialMaterial)
        {
            if (trialMaterial != null && ModelState.IsValid)
            {
                DataProvider.Add(trialMaterial);
            }

            return Json(new[] { trialMaterial }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult UpdateTrialMaterial([DataSourceRequest] DataSourceRequest request, TrialMaterial trialMaterial)
        {
            if (trialMaterial != null && ModelState.IsValid)
            {
                DataProvider.Update(trialMaterial);
            }

            return Json(new[] { trialMaterial }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult DeleteTrialMaterial([DataSourceRequest] DataSourceRequest request, TrialMaterial trialMaterial)
        {
            if (trialMaterial != null)
            {
                DataProvider.Delete(trialMaterial);
            }

            return Json(new[] { trialMaterial }.ToDataSourceResult(request, ModelState));
        }

        #endregion

        #region TrialProcedures

        public ActionResult GetTrialProcedures([DataSourceRequest]DataSourceRequest request, TrialProcedureDataFilter dataFilter)
        {
            var visits = DataProvider.GetList(new TrialProcedureVisitDataFilter 
            { 
                TrialCode = dataFilter.TrialCode, 
                TrialVersion = dataFilter.TrialVersion 
            });
            var response = DataProvider.GetList(dataFilter).Select(p => TrialProcedureViewModel.Create(p, visits));

            return Json(response.ToDataSourceResult(request));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult AddTrialProcedure([DataSourceRequest] DataSourceRequest request, TrialProcedure trialProcedure)
        {
            if (trialProcedure != null && ModelState.IsValid)
            {
                DataProvider.Add(trialProcedure);
            }

            return Json(new[] { trialProcedure }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult DeleteTrialProcedure([DataSourceRequest] DataSourceRequest request, TrialProcedure trialProcedure)
        {
            if (trialProcedure != null)
            {
                DataProvider.Delete(trialProcedure);
            }

            return Json(new[] { trialProcedure }.ToDataSourceResult(request, ModelState));
        }

        public ActionResult GetProceduresEditor(string trialCode, int trialVersion)
        {
            ViewBag.Versions = new[] { new { Id = 1, Name = "1 (Новая)" } };
            
            ViewBag.Procedures = DataProvider.GetList(new ProcedureDataFilter());

            ViewBag.Visits = DataProvider.GetList(new TrialVisitDataFilter { TrialCode = trialCode, TrialVersion = trialVersion })
                .OrderBy(v => v.Days);

            return PartialView("EditorTemplates/ProceduresEditor", new Trial { Code = trialCode, Version = trialVersion });
        }

        public JsonResult GetProcedures(TrialProcedureDataFilter dataFilter)
        {
            var exists = DataProvider.GetList(dataFilter)
                .Select(p => p.ProcedureCode)
                .ToList();

            var procedures = DataProvider.GetList(new ProcedureDataFilter())
                .Where(p => !exists.Contains(p.Code));

            return Json(procedures, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region TrialVisits

        public ActionResult GetVisitEditor(int? id, string trialCode, int trialVersion)
        {
            TrialVisit visit;
            if (id.HasValue)
            {
                visit = DataProvider.GetItem(new TrialVisitDataFilter { Id = id });
                if (visit == null)
                    throw new ApplicationException("Визит не найден");
                ViewBag.IsNew = false;
            }
            else
            {
                visit = new TrialVisit { TrialCode = trialCode, TrialVersion = trialVersion };
                ViewBag.IsNew = true;
            }

            return PartialView("EditorTemplates/VisitEditor", visit);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult AddTrailVisit(TrialVisit trialVisit)
        {
            if (trialVisit != null && ModelState.IsValid)
            {
                DataProvider.Add(trialVisit);
            }

            return GetProceduresEditor(trialVisit.TrialCode, trialVisit.TrialVersion);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult UpdateTrailVisit(TrialVisit trialVisit)
        {
            if (trialVisit != null && ModelState.IsValid)
            {
                DataProvider.Update(trialVisit);
            }

            return GetProceduresEditor(trialVisit.TrialCode, trialVisit.TrialVersion);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult DeleteTrailVisit(TrialVisit trialVisit)
        {
            DataProvider.Delete(trialVisit);

            return GetProceduresEditor(trialVisit.TrialCode, trialVisit.TrialVersion);
        }

        public ActionResult GetTrialVisits([DataSourceRequest]DataSourceRequest request, TrialVisitDataFilter dataFilter)
        {
            var response = DataProvider.GetList(dataFilter).OrderBy(v => v.Days);

            return Json(response.ToDataSourceResult(request));
        }

        #endregion

        #region TrialProcedureVisit

        public ActionResult AddTrialProcedureVisit(TrialProcedureVisit visit)
        { 
            DataProvider.Add(visit);

            return Json(visit);
        }

        public ActionResult DeleteTrialProcedureVisit(TrialProcedureVisit visit)
        {
            DataProvider.Delete(visit);

            return Json(visit);
        }

        #endregion

        #region TrialVisitMaterials

        public ActionResult GetTrialVisitMaterials([DataSourceRequest]DataSourceRequest request, TrialVisitMaterialDataFilter dataFilter)
        {
            var list = DataProvider.GetList(dataFilter)
                .Join(DataProvider.GetList(new TrialMaterialDataFilter{ TrialCode = dataFilter.TrialCode}), 
                    vm => vm.TrialMaterialId, m => m.Id,
                    (vm, m) => TrialVisitMaterialViewModel.Create(vm, m.Name));

            return Json(list.ToDataSourceResult(request));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult AddTrialVisitMaterial([DataSourceRequest] DataSourceRequest request, TrialVisitMaterial trialVisitMaterial)
        {
            if (trialVisitMaterial != null && ModelState.IsValid)
            {
                DataProvider.Add(trialVisitMaterial);
            }

            var material = DataProvider.GetItem(new TrialMaterialDataFilter { Id = trialVisitMaterial.TrialMaterialId });

            return Json(new[] { TrialVisitMaterialViewModel.Create(trialVisitMaterial, material == null ? null : material.Name )}
                .ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult DeleteTrialVisitMaterial([DataSourceRequest] DataSourceRequest request, TrialVisitMaterial trialVisitMaterial)
        {
            if (trialVisitMaterial != null)
            {
                DataProvider.Delete(trialVisitMaterial);
            }

            return Json(new[] { trialVisitMaterial }.ToDataSourceResult(request, ModelState));
        }

        public ActionResult GetTrialMaterialsDict(TrialMaterialDataFilter dataFilter)
        {
            var trialMaterials = DataProvider.GetList(dataFilter);
            
            return Json(trialMaterials);
        }

        #endregion
    }
}