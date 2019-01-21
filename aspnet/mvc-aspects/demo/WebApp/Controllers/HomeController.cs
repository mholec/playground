using System;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;
using System.Web.Routing;
using WebApp.Attributes;
using WebApp.Facades;
using WebApp.Services;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly MyFacade facade;

        public HomeController(MyFacade facade)
        {
            this.facade = facade;
        }

        protected override IAsyncResult BeginExecute(RequestContext requestContext, AsyncCallback callback, object state)
        {
            return base.BeginExecute(requestContext, callback, state);
        }

        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);
        }

        protected override void OnAuthentication(AuthenticationContext filterContext)
        {
            base.OnAuthentication(filterContext);
        }

        protected override void OnAuthorization(AuthorizationContext filterContext)
        {
            base.OnAuthorization(filterContext);
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
        }

        [Route("")]
        [HttpGet]
        public ActionResult Index()
        {
            throw new Exception("test");
            var model = facade.GetHomepage();

            return View(model);
        }

        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);
        }
        protected override void OnException(ExceptionContext filterContext)
        {
            base.OnException(filterContext);
        }

        protected override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            base.OnResultExecuting(filterContext);
        }

        protected override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            base.OnResultExecuted(filterContext);
        }
    }
}
