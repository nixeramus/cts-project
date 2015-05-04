using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using TD.CTS.Data.Entities;
using TD.CTS.Data.Filters;
using TD.CTS.WebUI.Models;

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
            var systemRoles = DataProvider.GetList(new RoleDataFilter());
            ViewBag.Users = users;
            ViewBag.PatientCode_Data = new SelectList(patients, "Id", "FullName");
            ViewBag.TrialCenterID_Data = new SelectList(trialCenters, "Id", "Number");

            ViewBag.SystemRoles = systemRoles;

            //var statuses = new List<string>()
            //{
            //    "Новое",
            //    "В работе",
            //    "Завершено",
            //    "Прервано"
            //};

            ViewBag.ScheduleStatuses = ScheduleStatus.GetScheduleStatuses();

           // ViewBag.ScheduleStatuses = systemRoles;

            //ViewBag.TrialCode_Data = new SelectList(trials, "Code", "Name");
            //ViewBag.Hospitals = DataProvider.GetList(new HospitalDataFilter());

            //ViewBag.Materials = DataProvider.GetList(new MaterialDataFilter());

            //ViewBag.Procedures = DataProvider.GetList(new ProcedureDataFilter());

            //ViewBag.Visits = DataProvider.GetList(new TrialVisitDataFilter { TrialCode = code });
           // if (Id.HasValue)
            {

                /*var results = from p in persons
              group p.car by p.PersonId into g
              select new { PersonID = g.Key, Cars = g.ToList() };
                 procedureVisit.Select(p => new ScheduleProcedure {ProcedureCode = p.ProcedureCode, ScheduleId = p.ScheduleID, TrialCenterId = p.TrialCenterID, TrialCode = p.TrialCode, TrialVersionNo = p.TrialVersionNo}).ToList();
                 
                 */

                //foreach (var p in procedureVisit)
                //{
                  
                //    //var vis = procedureVisit.Where(r => r.ProcedureCode == p.ProcedureCode && r.ScheduleID=p.ScheduleID);
                //    var item = new ScheduleProcedure {ProcedureCode =p.ProcedureCode,ScheduleId = p.ScheduleID,TrialCenterId = p.TrialCenterID,TrialCode =p.TrialCode,TrialVersionNo = p.TrialVersionNo, VisitIds = new List<int>()};
                //    list.Add(item);
                //}

                
                ViewBag.Procedures = DataProvider.GetList(new ProcedureDataFilter());
                ViewBag.Visits = DataProvider.GetList(new ScheduleVisitDataFilter {ScheduleID = Id});
            }
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


        #region ScheduleProcedures

        public ActionResult GetScheduleProcedures([DataSourceRequest]DataSourceRequest request, int ScheduleId)
        {
            var procedureVisit = DataProvider.GetList(new ScheduleVisitProcedureDataFilter { ScheduleID = ScheduleId });


         
                //var list = new List<ScheduleProcedure>();
            var result =
                from proc in procedureVisit
                select
                    new ScheduleProcedure()
                    {
                        ProcedureCode = proc.ProcedureCode,
                        TrialCenterId = proc.TrialCenterID,
                        ScheduleID = proc.ScheduleID,
                        TrialCode = proc.TrialCode,
                        TrialVersionNo = proc.TrialVersionNo,
                        VisitIds = procedureVisit.Select(e => e.TrialVisitID).ToList()
                    };

                //var groupedCustomerList = procedureVisit.GroupBy(c => new { c.ProcedureCode, c.ScheduleID, c.TrialCenterID, c.TrialCode, c.TrialVersionNo,}).
                //    .ToList();


            var response = result.ToList();

            return Json(response.ToDataSourceResult(request));
        }
        #endregion ScheduleProcedures



        #region ScheduleEmployees
        public ActionResult GetScheduleEmployees([DataSourceRequest]DataSourceRequest request, ScheduleEmployeeDataFilter dataFilter)
        {
            var response = DataProvider.GetList(dataFilter ?? new ScheduleEmployeeDataFilter());
            return Json(response.ToDataSourceResult(request));
        }

        public ActionResult UpdateScheduleEmployee([DataSourceRequest] DataSourceRequest request, ScheduleEmployee scheduleEmployee)
        {
            if (scheduleEmployee != null && ModelState.IsValid)
            {
                DataProvider.Update(scheduleEmployee);
            }

            return Json(new[] { scheduleEmployee }.ToDataSourceResult(request, ModelState));
        }
        #endregion

        #region ProcedureEmployees
        public ActionResult GetProcedureEmployees([DataSourceRequest]DataSourceRequest request, ProcedureEmployeeDataFilter dataFilter)
        {
            var response = DataProvider.GetList(dataFilter ?? new ProcedureEmployeeDataFilter());
            return Json(response.ToDataSourceResult(request));
        }




        public ActionResult UpdateProcedureEmployee([DataSourceRequest] DataSourceRequest request, ProcedureEmployee procedureEmployee)
        {
            if (procedureEmployee != null && ModelState.IsValid)
            {
                DataProvider.Update(procedureEmployee);
            }

            return Json(new[] { procedureEmployee }.ToDataSourceResult(request, ModelState));
        }

       #endregion ScheduleProcedures
    }
}