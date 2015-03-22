using System;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using TD.CTS.Data.Entities;
using TD.CTS.Data.Filters;

namespace TD.CTS.WebUI.Controllers
{
    public class SchedulesController : BaseController
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Расписания";

            ViewBag.Users = DataProvider.GetList(new UserDataFilter());

            return View();
        }

        #region Schedule
        public ActionResult GetSchedules([DataSourceRequest]DataSourceRequest request, ScheduleDataFilter dataFilter)
        {
            var response = DataProvider.GetList(dataFilter ?? new ScheduleDataFilter());

            return Json(response.ToDataSourceResult(request));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult DeleteSchedule([DataSourceRequest] DataSourceRequest request, Schedule schedule)
        {
            if (schedule != null)
            {
                DataProvider.Delete(schedule);
            }

            return Json(new[] { schedule }.ToDataSourceResult(request, ModelState));
        }


        public ActionResult Edit(int? Id)
        {
            ViewBag.Title = "Управление расписанием";

            Schedule schedule;
            if (!Id.HasValue)
            {
                ViewBag.IsNew = true;
                schedule = new Schedule {BeginDate = DateTime.Today};
            }
            else
            {
                schedule = DataProvider.GetItem(new ScheduleDataFilter { ScheduleID = Id });
                if (schedule == null)
                    throw new ApplicationException("Расписание с кодом '" + Id + "' не найдено");
                ViewBag.IsNew = false;
            }

            var users = DataProvider.GetList(new UserDataFilter());
            //Получаем пациентов
            var patients = DataProvider.GetList(new PatientDataFilter());
            //Получаем список исследований
            //var trials = DataProvider.GetList(new TrialDataFilter());
            //Получаем список исследовательских центров
            var trialCenters = DataProvider.GetList(new TrialCenterDataFilter());

            ViewBag.Users = users;
            ViewBag.PatientCode_Data = new SelectList(patients, "Id", "FullName");
            ViewBag.TrialCenterID_Data = new SelectList(trialCenters, "Id", "Number");
            //ViewBag.TrialCode_Data = new SelectList(trials, "Code", "Name");
            //ViewBag.Hospitals = DataProvider.GetList(new HospitalDataFilter());

            //ViewBag.Materials = DataProvider.GetList(new MaterialDataFilter());

            //ViewBag.Procedures = DataProvider.GetList(new ProcedureDataFilter());

            //ViewBag.Visits = DataProvider.GetList(new TrialVisitDataFilter { TrialCode = code });

            return View(schedule);
        }



        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult AddSchedule([DataSourceRequest] DataSourceRequest request, Schedule schedule)
        {
            if (schedule != null && ModelState.IsValid)
            {
                DataProvider.Add(schedule);
            }

            return Json(new[] { schedule }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult UpdateSchedule([DataSourceRequest] DataSourceRequest request, Schedule schedule)
        {
            if (schedule != null && ModelState.IsValid)
            {
                DataProvider.Update(schedule);
            }

            return Json(new[] { schedule }.ToDataSourceResult(request, ModelState));
        }
        #endregion

        #region ScheduleVist
        public ActionResult GetScheduleVisits([DataSourceRequest]DataSourceRequest request, ScheduleVisitDataFilter dataFilter)
        {
            var response = DataProvider.GetList(dataFilter ?? new ScheduleVisitDataFilter());

            return Json(response.ToDataSourceResult(request));
        }
        public ActionResult UpdateScheduleVisit([DataSourceRequest] DataSourceRequest request, ScheduleVisit scheduleVisit)
        {
            if (scheduleVisit != null && ModelState.IsValid)
            {
                DataProvider.Update(scheduleVisit);
            }

            return Json(new[] { scheduleVisit }.ToDataSourceResult(request, ModelState));
        }
        #endregion
    }
}