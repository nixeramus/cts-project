using System;
using System.Linq;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using TD.Common.Data.Exceptions;
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

        public ActionResult Create()
        {
            //TODO:Можно переделать на EDIT сразу, но не нашел как таб
            ViewBag.Title = "Создание расписания";
            ViewBag.IsNew = true;
            var schedule = new Schedule {BeginDate = DateTime.Today};


            //получаем список пользователей
            //var users = DataProvider.GetList(new UserDataFilter());
            //Получаем список пациентов
            //var patients = DataProvider.GetList(new PatientDataFilter());
            //Получаем список исследований
            //var trials = DataProvider.GetList(new TrialDataFilter());
            //Получаем список исследовательских центров
            //var trialCenters = ;
            //получаем список ролей
            //var systemRoles = DataProvider.GetList(new RoleDataFilter());
            //ViewBag.Users = users;
            ViewBag.PatientCode_Data = new SelectList(DataProvider.GetList(new PatientDataFilter()), "Id", "FullName");
            ViewBag.TrialCenterID_Data = new SelectList(DataProvider.GetList(new TrialCenterDataFilter()), "Id", "Number");
            //ViewBag.SystemRoles = systemRoles;
            ViewBag.ScheduleStatuses = ScheduleStatus.GetScheduleStatuses();
            //ViewBag.Procedures = DataProvider.GetList(new ProcedureDataFilter());
            //ViewBag.Visits = DataProvider.GetList(new ScheduleVisitDataFilter { ScheduleID = id });
            return View(schedule);
        }




        public ActionResult Edit(int? id)
        {
            var isNew = !id.HasValue;
            ViewBag.Title = "Управление расписанием";
            ViewBag.IsNew = isNew;

            if (!id.HasValue)
            {
                return RedirectToAction("Index", "Schedules");
            }
           
             var schedule = DataProvider.GetItem(new ScheduleDataFilter { ScheduleID = id });
            if (schedule == null)
                    throw new ApplicationException("Расписание с кодом '" + id + "' не найдено");
            

            //получаем список пользователей
            var users = DataProvider.GetList(new UserDataFilter());
            //Получаем список пациентов
            var patients = DataProvider.GetList(new PatientDataFilter());
            //Получаем список исследований
            //var trials = DataProvider.GetList(new TrialDataFilter());
            //Получаем список исследовательских центров
            var trialCenters = DataProvider.GetList(new TrialCenterDataFilter());
            //получаем список ролей
            var systemRoles = DataProvider.GetList(new RoleDataFilter());
            ViewBag.Users = users;
            ViewBag.PatientCode_Data = new SelectList(patients, "Id", "FullName");
            ViewBag.TrialCenterID_Data = new SelectList(trialCenters, "Id", "Number");
            ViewBag.SystemRoles = systemRoles;
            ViewBag.ScheduleStatuses = ScheduleStatus.GetScheduleStatuses();
            //-------------------
            //ViewBag.Procedures = DataProvider.GetList(new ProcedureDataFilter());
            ViewBag.Visits = DataProvider.GetList(new ScheduleVisitDataFilter { ScheduleID = id });
            //----------------
            return View(schedule);
        }



        //public ActionResult Edit(int? id)
        //{
        //    var isNew = !id.HasValue;
        //    //ViewBag.Title = isNew ? "Создание расписания" : "Управление расписанием";
        //    ViewBag.Title = "Управление расписанием";
        //    ViewBag.IsNew = isNew;

        //    Schedule schedule;
        //    if (isNew)
        //    {
        //        schedule = new Schedule {BeginDate = DateTime.Today};
        //    }
        //    else
        //    {
        //        schedule = DataProvider.GetItem(new ScheduleDataFilter {ScheduleID = id});
        //        if (schedule == null)
        //            throw new ApplicationException("Расписание с кодом '" + id + "' не найдено");
        //    }

        //    //получаем список пользователей
        //    var users = DataProvider.GetList(new UserDataFilter());
        //    //Получаем список пациентов
        //    var patients = DataProvider.GetList(new PatientDataFilter());
        //    //Получаем список исследований
        //    //var trials = DataProvider.GetList(new TrialDataFilter());
        //    //Получаем список исследовательских центров
        //    var trialCenters = DataProvider.GetList(new TrialCenterDataFilter());
        //    //получаем список ролей
        //    var systemRoles = DataProvider.GetList(new RoleDataFilter());
        //    ViewBag.Users = users;
        //    ViewBag.PatientCode_Data = new SelectList(patients, "Id", "FullName");
        //    ViewBag.TrialCenterID_Data = new SelectList(trialCenters, "Id", "Number");
        //    ViewBag.SystemRoles = systemRoles;
        //    ViewBag.ScheduleStatuses = ScheduleStatus.GetScheduleStatuses();
        //    //-------------------
        //    //ViewBag.Procedures = DataProvider.GetList(new ProcedureDataFilter());
        //    ViewBag.Visits = DataProvider.GetList(new ScheduleVisitDataFilter {ScheduleID = id});
        //    //----------------
        //    return View(schedule);
        //}



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
                if (scheduleVisit.Id.HasValue)
                {
                    DataProvider.Update(scheduleVisit);
                }
                else
                {
                    DataProvider.Add(scheduleVisit);
                }
            }

            return Json(new[] { scheduleVisit }.ToDataSourceResult(request, ModelState));
        }


        public ActionResult DeleteScheduleVisit([DataSourceRequest] DataSourceRequest request, ScheduleVisit scheduleVisit)
        {
            if (scheduleVisit != null)
            {
                if (!scheduleVisit.Id.HasValue)
                    throw new DataException("Невозможно удалить дату у незапланированного визита ");
                DataProvider.Delete(scheduleVisit);
            }

            return Json(new[] { scheduleVisit }.ToDataSourceResult(request, ModelState));
        }


        #endregion


        #region ScheduleProcedures

        public ActionResult GetScheduleDetailContent(int ScheduleID)
        {
          var schedule = DataProvider.GetItem(new ScheduleDataFilter { ScheduleID = ScheduleID });
          ViewBag.Procedures = DataProvider.GetList(new ProcedureDataFilter());
          //Берем только запланированные визиты
          ViewBag.Visits = DataProvider.GetList(new ScheduleVisitDataFilter { ScheduleID = ScheduleID }).Where(e=>e.ScheduleDate.HasValue).ToList();
          return PartialView("EditorTemplates/ScheduleDetailEditor", schedule);
        }
        public ActionResult GetScheduleProcedures([DataSourceRequest]DataSourceRequest request, int ScheduleId)
        {
            var procedureVisit = DataProvider.GetList(new ScheduleVisitProcedureDataFilter { ScheduleID = ScheduleId });


         
                //var list = new List<ScheduleProcedure>();
            var result =
                from proc in procedureVisit
                select
                    new ScheduleProcedure
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



        public ActionResult DeleteScheduleEmployee([DataSourceRequest] DataSourceRequest request, ScheduleEmployee scheduleEmployee)
        {
            if (scheduleEmployee != null)
            {
                DataProvider.Delete(scheduleEmployee);
            }

            return Json(new[] { scheduleEmployee }.ToDataSourceResult(request, ModelState));
        }

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