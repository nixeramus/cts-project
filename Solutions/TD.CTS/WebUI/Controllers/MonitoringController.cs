﻿using Kendo.Mvc.UI;
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
    }
}