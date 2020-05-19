using ICM.JHB.Utility.Ninject;
using MusicLibrary.WebAPI.Ioc;
using Ninject.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace MusicLibrary.WebAPI
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Ninject_IOC.Container.Load(new IModule[] { new MusicLibraryModule() });
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        public void Application_BeginRequest(object sender, EventArgs e)
        {
            string httpOrigin = Request.Params["HTTP_ORIGIN"];
            if (httpOrigin == null) httpOrigin = "*";
            HttpContext.Current.Response.AddHeader("Access-Control-Allow-Origin", httpOrigin);
            HttpContext.Current.Response.AddHeader("Access-Control-Allow-Methods", "GET, POST, PUT, DELETE, OPTIONS");
            HttpContext.Current.Response.AddHeader("Access-Control-Allow-Headers", "Origin, X-Requested-With, Content-Type, Accept, X-Token");
            HttpContext.Current.Response.AddHeader("Access-Control-Allow-Credentials", "true");

            if (Request.HttpMethod == "OPTIONS")
            {
                HttpContext.Current.Response.StatusCode = 200;
                var httpApplication = sender as HttpApplication;
                httpApplication.CompleteRequest();
            }
        }
    }
}
