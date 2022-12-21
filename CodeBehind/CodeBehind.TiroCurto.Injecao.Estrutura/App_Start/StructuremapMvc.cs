//***CODE BEHIND - BY RODOLFO.FONSECA***//
using System.Web.Http;
using System.Web.Mvc;
using StructureMap;
using CodeBehind.TiroCurto.Injecao.Estrutura.DependencyResolution;

[assembly: WebActivator.PreApplicationStartMethod(typeof(CodeBehind.TiroCurto.Injecao.Estrutura.App_Start.StructuremapMvc), "Start")]

namespace CodeBehind.TiroCurto.Injecao.Estrutura.App_Start {
    public static class StructuremapMvc {
        public static void Start() {
			IContainer container = IoC.Initialize();
            DependencyResolver.SetResolver(new StructureMapDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new StructureMapDependencyResolver(container);
        }
    }
}