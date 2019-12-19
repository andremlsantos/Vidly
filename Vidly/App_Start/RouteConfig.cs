using System.Web.Mvc;
using System.Web.Routing;

namespace Vidly
{
    public class RouteConfig
    {
        /*
         * A ordem importa
         * Desde o mais especifico ate mais generico
         * Neste caso criamos um novo route q pode receber 2 argumentos embebidos no url
         */
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // enable attribute routing
            routes.MapMvcAttributeRoutes();


            // temos uma expressao regular para numero digitos mes e ano
            //routes.MapRoute(
            //    "MoviesByReleaseDate",
            //    "movies/released/{year}/{month}",
            //    new { controller = "Movies", action = "ByReleasedDate" },
            //    new { year = @"\d{4}", month = @"\d{2}" }
            //    );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
