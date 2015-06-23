using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using TD.Common.Data.Exceptions;
using TD.CTS.Data.Entities;
using TD.CTS.Data.Filters;
using TD.CTS.WebUI.Models;

namespace TD.CTS.WebUI.Controllers
{
    public class SchedulesPlanningController : BaseController
    {
        public ActionResult Index(int? year, int? month, int? PatientCode)
        {
            ViewBag.Title = "Планирование визитов";
            var patients = DataProvider.GetList(new PatientDataFilter());
            ViewBag.PatientCode_Data = new SelectList(patients, "Id", "FullName");
            var calend = new ScheduleCalend(year, month);
            ViewBag.Calend = calend;
            var filter = new SchedulePlaningVisitDataFilter { MonthYearDate = calend.MonthYearDate, PatientCode = PatientCode };
            return View(filter);
        }

        public ActionResult GetVisits([DataSourceRequest]DataSourceRequest request, SchedulePlaningVisitDataFilter dataFilter)
        {
            var response = DataProvider.GetList(dataFilter ?? new SchedulePlaningVisitDataFilter());

            return Json(response.ToDataSourceResult(request));
        }
        #region ScheduleVist
      
        public ActionResult UpdateScheduleVisit([DataSourceRequest] DataSourceRequest request, ScheduleVisit scheduleVisit)
        {
            if (scheduleVisit != null && ModelState.IsValid)
            {
                if (!scheduleVisit.ScheduleDate.HasValue)
                    throw new DataException("Дата планирования не задана");
                
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
        
    }

  
}