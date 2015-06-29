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
    public class PatientsController : BaseController
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Пациенты";

            ViewBag.Hospitals = DataProvider.GetList(new HospitalDataFilter());
            ViewBag.Referals = DataProvider.GetList(new ReferalDataFilter());

            ViewBag.SorceTypes = Patient.SourceTypes;

            return View();
        }

        public ActionResult GetPatients([DataSourceRequest]DataSourceRequest request, PatientDataFilter dataFilter)
        {
            var response = DataProvider.GetList(dataFilter ?? new PatientDataFilter());

            return Json(response.ToDataSourceResult(request));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult AddPatient([DataSourceRequest] DataSourceRequest request, Patient patient)
        {
            if (patient != null && ModelState.IsValid)
            {
                DataProvider.Add(patient);
            }

            return Json(new[] { patient }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult UpdatePatient([DataSourceRequest] DataSourceRequest request, Patient patient)
        {
            if (patient != null && ModelState.IsValid)
            {
                DataProvider.Update(patient);
            }

            return Json(new[] { patient }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult DeletePatient([DataSourceRequest] DataSourceRequest request, Patient patient)
        {
            if (patient != null)
            {
                DataProvider.Delete(patient);
            }

            return Json(new[] { patient }.ToDataSourceResult(request, ModelState));
        }

        public ActionResult GetPatientTrials([DataSourceRequest]DataSourceRequest request, PatientTrialDataFilter dataFilter)
        {
            var response = DataProvider.GetList(dataFilter);

            return Json(response.ToDataSourceResult(request));
        }
    }
}