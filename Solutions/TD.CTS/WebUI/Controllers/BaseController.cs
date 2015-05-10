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
using NLog;
using TD.Common.Data.Exceptions;

namespace TD.CTS.WebUI.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

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
            SeViewBagValues(ViewBag);

            CultureInfo cultureInfo = new CultureInfo("ru-RU");
            Thread.CurrentThread.CurrentUICulture = cultureInfo;
            Thread.CurrentThread.CurrentCulture = cultureInfo;
            base.OnActionExecuting(filterContext);
        }

        private void SeViewBagValues(dynamic viewBag, bool showMenu = true)
        {
            viewBag.ShowMenu = showMenu;

            viewBag.Themes = ThemeManager.Themes;
            viewBag.SelectedTheme = UserSettings.SelectedTheme.Name;
            viewBag.CurrentUser = CurrentUser;
            //viewBag.UserAccess = AccessManager.UserAccess;
        }


        protected override void OnException(ExceptionContext filterContext)
        {
            if (filterContext == null)
                return;

            //filterContext.HttpContext.Response.TrySkipIisCustomErrors = true;

            var exception = filterContext.Exception ?? new ApplicationException("Неизвестная ошибка");

            var controllerName = (string)filterContext.RouteData.Values["controller"];
            var actionName = (string)filterContext.RouteData.Values["action"];
            var model = new HandleErrorInfo(exception, controllerName, actionName);

            logger.Error(string.Format("Controller: {0}; Action: {1}", controllerName, actionName), exception);

            var result = new ViewResult
            {
                ViewName = "Error",
                ViewData = new ViewDataDictionary<HandleErrorInfo>(model),
                TempData = filterContext.Controller.TempData
            };

            result.ViewBag.Title = "";

            filterContext.Result = result;

            filterContext.ExceptionHandled = true;

            if (filterContext.HttpContext.Response.StatusCode == 200)
                filterContext.HttpContext.Response.StatusCode = 500;

            result.ViewBag.IsAjax = Request.IsAjaxRequest();

            if ((exception is UnauthorizedAccessException))
            {
                SeViewBagValues(result.ViewBag, false);
                result.ViewBag.ShowDetails = false;
                result.ViewBag.Message = "Недостаточно прав для выполнения операции";
            }
            else
            {
                SeViewBagValues(result.ViewBag);
                result.ViewBag.ShowDetails = true;//user.IsAdmin;
                result.ViewBag.Message = exception is DataException ? exception.Message : "В процессе обработки запроса произошла ошибка";
                //var user = AccessManager.UserAccess;
                //result.ViewBag.UserAccess = user;

            }
        }

        
    }
}