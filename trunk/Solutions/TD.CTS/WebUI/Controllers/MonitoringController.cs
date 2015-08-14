using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TD.CTS.Data.Entities;
using TD.CTS.Data.Filters;
using Kendo.Mvc.Extensions;
using TD.CTS.WebUI.Models;

namespace TD.CTS.WebUI.Controllers
{
    public class MonitoringController : BaseController
    {
        public ActionResult SchedulerState()
        {
            ViewBag.Title = "Общее состояние расписаний";

            return View();
        }

        public ActionResult GetTasks([DataSourceRequest]DataSourceRequest request, TaskDataFilter dataFilter, string viewMode)
        {
            IEnumerable<ISchedulerEvent> response;
            if (viewMode == "procedure")
            {
                var procedureCountFilter = dataFilter == null ? new ProcedureCountDataFilter() : new ProcedureCountDataFilter
                {
                    VisitDateBegin = dataFilter.VisitDateBegin,
                    VisitDateEnd = dataFilter.VisitDateEnd
                };

                response = DataProvider.GetList(procedureCountFilter).GroupBy(t => t.VisitDate).Select(g => new ProcedureCountSchedulerEvent(g.Key, g));
            }
            else
            {
                if (dataFilter == null)
                    dataFilter = new TaskDataFilter { AllUsers = true };
                else
                    dataFilter.AllUsers = true;
                response = DataProvider.GetList(dataFilter).GroupBy(t => t.VisitDate).Select(g => new TaskSchedulerEvent(g.Key, g));
            }

            return Json(response.ToDataSourceResult(request));
        }

        public ActionResult VisitListByDay(DateTime? date)
        {
            var dataFilter = date.HasValue ? new TrialVisitReportDataFilter(date.Value) : new TrialVisitReportDataFilter();
            TempData["DataFilter"] = dataFilter;
            return RedirectToAction("VisitList");
        }

        public ActionResult VisitList(TrialVisitReportDataFilter dataFilter)
        {
            ViewBag.Title = "Форма списка визитов";
            if (TempData["DataFilter"] != null)
                dataFilter = (TrialVisitReportDataFilter)TempData["DataFilter"];
            return View(dataFilter ?? new TrialVisitReportDataFilter());
        }

        public ActionResult GetVisits([DataSourceRequest]DataSourceRequest request, TrialVisitReportDataFilter dataFilter)
        {
            if (dataFilter == null)
                dataFilter = new TrialVisitReportDataFilter();
            var response = DataProvider.GetList(dataFilter);            
            return Json(response.ToDataSourceResult(request));
        }

        public ActionResult GetVisitProcedures([DataSourceRequest]DataSourceRequest request, TrialVisitProcedureReportDataFilter dataFilter)
        {
            var response = DataProvider.GetList(dataFilter ?? new TrialVisitProcedureReportDataFilter());

            return Json(response.ToDataSourceResult(request));
        }
    }
}