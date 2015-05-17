using System;
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
        public ActionResult Index(int? year,int? month)
        {
            ViewBag.Title = "Планирование визитов";

            //DateTime defaultDate;
            //if (year.HasValue && month.HasValue)
            //{
            //    defaultDate = new DateTime(year.Value, month.Value, 1);
               
            //}
            //else
            //{
            //    defaultDate = DateTime.Today;
            //}

            ////var datestart=defaultDate.
            //var firstDayOfMonth = new DateTime(defaultDate.Year, defaultDate.Month, 1);
            //var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);

            //ViewBag.Users = DataProvider.GetList(new UserDataFilter());
            //var datestart = new DateTime(2015, 05, 01);
            //var dateend = new DateTime(2015, 06, 01);



            //var calend = new ScheduleCalend(firstDayOfMonth, lastDayOfMonth);
            var calend = new ScheduleCalend(year, month);
            ViewBag.Calend = calend;
            return View();
        }







        public ActionResult GetVisits([DataSourceRequest]DataSourceRequest request, SchedulePlaningVisitDataFilter dataFilter)
        {
            var response = DataProvider.GetList(dataFilter ?? new SchedulePlaningVisitDataFilter());

            return Json(response.ToDataSourceResult(request));
        }
        #region ScheduleVist
        //public ActionResult GetScheduleVisits([DataSourceRequest]DataSourceRequest request, ScheduleVisitDataFilter dataFilter)
        //{
        //    var response = DataProvider.GetList(dataFilter ?? new ScheduleVisitDataFilter());

        //    return Json(response.ToDataSourceResult(request));
        //}
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