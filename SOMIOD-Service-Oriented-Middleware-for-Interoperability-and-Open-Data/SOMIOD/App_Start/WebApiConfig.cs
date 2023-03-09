using System.Web.Http;
using System.Web.Http.Dispatcher;

namespace SOMIOD
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();
            
            config.Formatters.XmlFormatter.UseXmlSerializer = true;
            
            config.Routes.MapHttpRoute(
                name: "SomiodApi",
                routeTemplate: "api/somiod/applications/{applicationName}/modules/{moduleName}/data|subscriptions/{dataId|subscriptionName}",
                defaults: new { 
                    applicationName = RouteParameter.Optional, 
                    moduleName = RouteParameter.Optional, 
                    subscriptionName = RouteParameter.Optional, 
                    dataId = RouteParameter.Optional,
                }
            );
            /*
            config.Routes.MapHttpRoute(
                name: "Api",
                routeTemplate: "api/somiod/{action=Get}/{applicationName}",
                defaults: new { controller = "ApplicationController" }
            );
            config.Routes.MapHttpRoute(
                name: "GetApplication",
                routeTemplate: "api/somiod/{applicationName}",
                defaults: new { controller = "ApplicationController" },
                constraints: HttpMethod.Get
            );
            */
            /*
                        config.Routes.MapHttpRoute(
                            name: "ApplicationRoute",
                            routeTemplate: "api/somiod/{applicationName}/{moduleName}",
                            defaults: new { controller = "ApplicationController" }
                        );
                        config.Routes.MapHttpRoute(
                            name: "ModuleRoute",
                            routeTemplate: "api/somiod/{applicationName}/{moduleName}",
                            defaults: new { controller = "ModuleController" }
                        );
                        /*
                        config.Routes.MapHttpRoute(
                            name: "DataRoute",
                            routeTemplate: "api/somiod/{applicationName}/{moduleName}/{res_type}",
                            defaults: new { controller = "DataController" },
                            constraints: new { res_type = "data" }
                        );
            */

            config.Services.Replace(typeof(IHttpControllerSelector), new CustomHttpControllerSelector(config));
        }
    }
}

