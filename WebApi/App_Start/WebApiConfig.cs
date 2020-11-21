using Microsoft.AspNetCore.Cors;
using System;
using System.Web.Http;
using WebApi.Controllers;

namespace WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //EnableCorsAttribute cors = new EnableCorsAttribute("*");
            //config.EnableCors();
            // Configuración y servicios de API web

            // Rutas de API web
            config.MapHttpAttributeRoutes();
            config.MessageHandlers.Add(new TokenValidationHandler());
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            config.Formatters.Add(config.Formatters.JsonFormatter);
            config.Formatters.Remove(config.Formatters.XmlFormatter);
        }
    }
}
