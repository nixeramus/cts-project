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
    public class TrialsController : BaseController
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

        public ActionResult Edit(string code)
        {
            ViewBag.Title = "Описание исследования";

            Trial trial;
            if (string.IsNullOrEmpty(code))
            {
                ViewBag.IsNew = true;
                trial = new Trial();
            }
            else
            {
                trial = DataProvider.GetItem(new TrialDataFilter { Code = code });
                if (trial == null)
                    throw new ApplicationException("Исследование с кодом '" + code + "' не найдено");
                ViewBag.IsNew = false;
            }

            var users = DataProvider.GetList(new UserDataFilter());

            ViewBag.Users = users;
            ViewBag.AdministratorLogin_Data = new SelectList(users, "Login", "FullName");

            ViewBag.Hospitals = DataProvider.GetList(new HospitalDataFilter());

            ViewBag.Materials = DataProvider.GetList(new MaterialDataFilter());

            ViewBag.Procedures = DataProvider.GetList(new ProcedureDataFilter());

            ViewBag.Visits = DataProvider.GetList(new TrialVisitDataFilter { TrialCode = code }).OrderBy(v => v.Days);

            return View(trial);
        }

        #region TrialCenters
        public ActionResult GetTrialCenters([DataSourceRequest]DataSourceRequest request, string trialCode)
        {
            var response = string.IsNullOrEmpty(trialCode) ? new List<TrialCenter>() : DataProvider.GetList(new TrialCenterDataFilter { TrialCode = trialCode });

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

        public ActionResult GetTrialMaterials([DataSourceRequest]DataSourceRequest request, string trialCode)
        {
            var response = DataProvider.GetList(new TrialMaterialDataFilter { TrialCode = trialCode });

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

        public ActionResult GetTrialProcedures([DataSourceRequest]DataSourceRequest request, string trialCode)
        {
            var response = DataProvider.GetList(new TrialProcedureDataFilter { TrialCode = trialCode });

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
        public ActionResult UpdateTrialProcedure([DataSourceRequest] DataSourceRequest request, TrialProcedure trialProcedure)
        {
            if (trialProcedure != null && ModelState.IsValid)
            {
                DataProvider.Update(trialProcedure);
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

        public JsonResult GetProcedures(string trialCode, int trialProcedureId)
        {
            var exists = DataProvider.GetList(new TrialProcedureDataFilter { TrialCode = trialCode })
                .Where(p => p.Id != trialProcedureId)
                .Select(p => p.ProcedureCode)
                .ToList();

            var procedures = DataProvider.GetList(new ProcedureDataFilter())
                .Where(p => !exists.Contains(p.Code));

            return Json(procedures, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region TrialVisits

        public ActionResult GetVisitEditor(int? id, string trialCode)
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
                visit = new TrialVisit { TrialCode = trialCode };
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

            return GetProceduresEditor(trialVisit.TrialCode);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult UpdateTrailVisit(TrialVisit trialVisit)
        {
            if (trialVisit != null && ModelState.IsValid)
            {
                DataProvider.Update(trialVisit);
            }

            return GetProceduresEditor(trialVisit.TrialCode);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult DeleteTrailVisit(TrialVisit trialVisit)
        {
            DataProvider.Delete(trialVisit);
            
            return GetProceduresEditor(trialVisit.TrialCode);
        }

        public ActionResult GetProceduresEditor(string trialCode)
        {
            //var trial = DataProvider.GetItem(new TrialDataFilter { Code = trialCode });

            ViewBag.Procedures = DataProvider.GetList(new ProcedureDataFilter());

            ViewBag.Visits = DataProvider.GetList(new TrialVisitDataFilter { TrialCode = trialCode }).OrderBy(v => v.Days);

            return PartialView("EditorTemplates/ProceduresEditor", trialCode);
        }

        #endregion

        #region TrialVisitMaterials

        public ActionResult GetTrialVisitMaterials([DataSourceRequest]DataSourceRequest request, int trialProcedureId, int trialVisitId)
        {
            var list = DataProvider.GetList(new TrialVisitMaterialDataFilter { TrialProcedureId = trialProcedureId, TrialVisitId = trialVisitId });

            return Json(list.ToDataSourceResult(request));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult AddTrialVisitMaterial([DataSourceRequest] DataSourceRequest request, TrialVisitMaterial trialVisitMaterial)
        {
            if (trialVisitMaterial != null && ModelState.IsValid)
            {
                DataProvider.Add(trialVisitMaterial);
            }

            return Json(new[] { trialVisitMaterial }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult UpdateTrialVisitMaterial([DataSourceRequest] DataSourceRequest request, TrialVisitMaterial trialVisitMaterial)
        {
            if (trialVisitMaterial != null && ModelState.IsValid)
            {
                DataProvider.Update(trialVisitMaterial);
            }

            return Json(new[] { trialVisitMaterial }.ToDataSourceResult(request, ModelState));
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

        public ActionResult GetTrialMaterialsDict(string trialCode)
        {
            var trialMaterials = DataProvider.GetList(new TrialMaterialDataFilter { TrialCode = trialCode });
            var materials = DataProvider.GetList(new MaterialDataFilter());
            var dict = trialMaterials.Join(materials, tm => tm.MaterialId, m => m.Id, (tm, m) => new { tm.Id, m.Name });

            return Json(dict);
        }

        #endregion
    }
}