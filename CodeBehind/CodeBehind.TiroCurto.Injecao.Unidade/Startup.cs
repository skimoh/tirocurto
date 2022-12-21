//***CODE BEHIND - BY RODOLFO.FONSECA***//
using CodeBehind.TiroCurto.Injecao.Unidade.App_Start;
using Owin;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Http;
using System.Web.Mvc;
using Unity;
using Unity.WebApi;

namespace CodeBehind.TiroCurto.Injecao.Unidade
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {            
            HttpConfiguration config = new HttpConfiguration();            
            
            Register(config);

            app.UseWebApi(config);
        }

        public static void Register(HttpConfiguration config)
        {
            var container = new UnityContainer();
            container.RegisterType<IClasseInjetada, ClasseInjetada>();
            config.DependencyResolver = new UnityResolver(container);

            //this
            config.DependencyResolver = new UnityDependencyResolver(container);

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