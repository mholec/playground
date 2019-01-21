using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using WebApp.Attributes;

namespace WebApp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Init(object sender, EventArgs e)
        {
        }

        protected void Application_Start(object sender, EventArgs e)
        {
            GlobalFilters.Filters.Add(new AuthorizationFilter());
            GlobalFilters.Filters.Add(new ActionFilter());
            GlobalFilters.Filters.Add(new ResultFilter());
            GlobalFilters.Filters.Add(new ExceptionFilter());
            GlobalFilters.Filters.Add(new ActionFilterAttr());

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        // Request processing is starting
        protected void Application_BeginRequest(object sender, EventArgs e)
        {
        }

        // User has been identified
        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {
        }

        // User authorization has been verified
        protected void Application_AuthorizeRequest(object sender, EventArgs e)
        {
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            Exception error = Server.GetLastError();
        }
        
        protected void Session_Start(object sender, EventArgs e)
        {
        }

        // Request processing is finished
        protected void Application_EndRequest(object sender, EventArgs e)
        {
        }

        protected void Session_End(object sender, EventArgs e)
        {
        }

        protected void Application_End(object sender, EventArgs e)
        {
        }
    }
}
