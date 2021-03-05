using System.Web.Http;

namespace MongoMVC
//clase definida statica y necesaria para el API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            #region Configuracion API Web y Rutas
            // Configuración y servicios de API web

            // Rutas de API web
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );



            #endregion
        }
    }
}
