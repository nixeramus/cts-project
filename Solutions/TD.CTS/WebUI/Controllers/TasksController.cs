﻿using Kendo.Mvc.UI;
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

namespace TD.CTS.WebUI.Controllers
{
    public class TasksController : BaseController
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Запланированные процедуры";

            return View();
        }

        public ActionResult GetTasks([DataSourceRequest]DataSourceRequest request, TaskDataFilter dataFilter)
        {
            var response = DataProvider.GetList<Task>(dataFilter ?? new TaskDataFilter()).GroupBy(t => t.VisitDate).Select(g => new TaskSchedulerEvent(g.Key, g));

            return Json(response.ToDataSourceResult(request));
        }

        public ActionResult Details(int id)
        {
            ViewBag.Title = "Информация о процедуре";

            var task = DataProvider.GetItem(new TaskDataFilter { Id = id });
            if(task == null)
                throw new ApplicationException("Процедура с кодом '" + id + "' не найдена");

            var trial = DataProvider.GetItem(new TrialDataFilter{ Code = task.TrialCode });
            var procedure = DataProvider.GetItem(new ProcedureDataFilter { Code = task.ProcedureCode });

            ViewBag.Roles = DataProvider.GetList(new RoleDataFilter());
            ViewBag.Users = DataProvider.GetList(new UserDataFilter());

            return View(TaskViewModel.Create(task, trial.Name, procedure.Name));
        }

        [HttpPost]
        public ActionResult ExecuteTask(Task task)
        {
            DataProvider.Update(task);

            return Json(new { });
        }
    }
}