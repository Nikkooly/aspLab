using Ninject;
using Ninject.Modules;
using Ninject.Web.Mvc;
using NinjectModules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;

namespace mvcBuiko.App_Start
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Formatters.JsonFormatter.SupportedMediaTypes
            .Add(new MediaTypeHeaderValue("text/html"));

            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "TS/{id}",
                defaults: new { controller = "WebApi", id = RouteParameter.Optional }
            );
        }
    }
}