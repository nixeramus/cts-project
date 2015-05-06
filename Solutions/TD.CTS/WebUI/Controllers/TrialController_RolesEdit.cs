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
    public partial class TrialsController
    {
        public ActionResult RolesEdit(string id)
        {
            ViewBag.Title = "Роли исследования";

            ViewBag.Procedures = DataProvider.GetList(new ProcedureDataFilter());

            return View((object)id);
        }
    }
}