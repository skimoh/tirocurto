using System.Web.Http;

namespace CodeBehind.TiroCurto.Injecao.Ninja
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {            
            GlobalConfiguration.Configure(WebApiConfig.Register);        

            /*
             
            INJETADO VIA CONSOLE APLICATION 

            StandardKernel kernal = new StandardKernel();
            kernal.Load(Assembly.GetExecutingAssembly());
            IClasseInjetada classe = kernal.Get<IClasseInjetada>();
            var retorno classe.Metodo(1);

            */
        }

    }
}
