//***CODE BEHIND - BY RODOLFO.FONSECA***//
using System.Linq;
using System.Web.Http;
using System.Web.Mvc;

namespace CodeBehind.TiroCurto.Injecao.Ninja
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                "Default",
                "{controller}/{action}/{id}",
                new { controller = "Cliente", action = "Get", id = UrlParameter.Optional }
            );

            var appXmlType = config.Formatters.XmlFormatter.SupportedMediaTypes.FirstOrDefault(t => t.MediaType == "application/xml");
            config.Formatters.XmlFormatter.SupportedMediaTypes.Remove(appXmlType);
        }
    }
}
