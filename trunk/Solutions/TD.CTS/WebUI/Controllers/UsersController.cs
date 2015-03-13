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
    public class UsersController : BaseController
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Сотрудники";

            ViewBag.Hospitals = DataProvider.GetList<Hospital>(new HospitalDataFilter());
            ViewBag.RolesList = DataProvider.GetList<Role>(new RoleDataFilter());

            return View();
        }

        public ActionResult GetUsers([DataSourceRequest]DataSourceRequest request, UserDataFilter dataFilter)
        {
            var response = DataProvider.GetList<User>(dataFilter ?? new UserDataFilter());

            return Json(response.ToDataSourceResult(request));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult AddUser([DataSourceRequest] DataSourceRequest request, User user)
        {
            if (user != null && ModelState.IsValid)
            {
                DataProvider.Add(user);
            }

            return Json(new[] { user }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult UpdateUser([DataSourceRequest] DataSourceRequest request, User user)
        {
            if (user != null && ModelState.IsValid)
            {
                DataProvider.Update(user);
            }

            return Json(new[] { user }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult DeleteUser([DataSourceRequest] DataSourceRequest request, User user)
        {
            if (user != null)
            {
                DataProvider.Delete(user);
            }

            return Json(new[] { user }.ToDataSourceResult(request, ModelState));
        }
    }
}