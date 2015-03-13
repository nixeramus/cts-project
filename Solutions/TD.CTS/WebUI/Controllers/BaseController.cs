using TD.CTS.WebUI.Common;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using TD.CTS.Auth;
using TD.CTS.Data;
using TD.CTS.Data.Entities;
using TD.CTS.MockData;

namespace TD.CTS.WebUI.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
        protected IDataProvider DataProvider { get; private set; }

        protected User CurrentUser { get; private set; }

        protected UserSettings UserSettings { get; private set; }

        public BaseController()
        {
            UserSettings = ApplicationSettings.UserSettings;
        }

        protected override void OnAuthorization(AuthorizationContext filterContext)
        {
            Authenticator auth = ApplicationSettings.Authenticator;
            if (auth != null)
            {
                //DataProvider = auth.DataProvider;
                DataProvider = new MockDataProvider(auth.DataProvider);
                CurrentUser = auth.User;
                filterContext.HttpContext.User = new CtsPrincipal(new CtsIdentity(CurrentUser));
            }
            base.OnAuthorization(filterContext);
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            ViewBag.ShowMenu = true;

            ViewBag.Themes = ThemeManager.Themes;
            ViewBag.SelectedTheme = UserSettings.SelectedTheme.Name;
            ViewBag.CurrentUser = CurrentUser;
            //ViewBag.UserAccess = AccessManager.UserAccess;

            CultureInfo cultureInfo = new CultureInfo("ru-RU");
            Thread.CurrentThread.CurrentUICulture = cultureInfo;
            Thread.CurrentThread.CurrentCulture = cultureInfo;
            base.OnActionExecuting(filterContext);
        }

        protected override void OnException(ExceptionContext filterContext)
        {
            //if (filterContext == null)
            //    return;

            //filterContext.HttpContext.Response.TrySkipIisCustomErrors = true;

            //var exception = filterContext.Exception ?? new ApplicationException("Ошибка выполнения запроса");

            //var controllerName = (string)filterContext.RouteData.Values["controller"];
            //var actionName = (string)filterContext.RouteData.Values["action"];
            //var model = new HandleErrorInfo(exception, controllerName, actionName);

            //logger.WriteControllerException(exception, controllerName, actionName);

            //var result = new ViewResult
            //{
            //    ViewName = "Error",
            //    ViewData = new ViewDataDictionary<HandleErrorInfo>(model),
            //    TempData = filterContext.Controller.TempData
            //};

            //result.ViewBag.Title = "Ошибка";

            //filterContext.Result = result;

            //filterContext.ExceptionHandled = true;


            //if ((exception is UnauthorizedAccessException))
            //{
            //    result.ViewBag.ShowMenu = false;
            //    result.ViewBag.ShowDetails = false;
            //    result.ViewBag.Message = "Недостаточно прав для выполнения операции";
            //}
            //else
            //{
            //    result.ViewBag.ShowMenu = true;
            //    result.ViewBag.Message = exception is DBException ? exception.Message : "В процессе обработки запроса произошла ошибка";
            //    var user = AccessManager.UserAccess;
            //    result.ViewBag.UserAccess = user;
            //    result.ViewBag.ShowDetails = user.IsAdmin;
            //}
            base.OnException(filterContext);
        }

        
    }
}