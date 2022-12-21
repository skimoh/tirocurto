//***CODE BEHIND - BY RODOLFO.FONSECA***//
using StructureMap;
using StructureMap.Graph;

namespace CodeBehind.TiroCurto.Injecao.Estrutura.DependencyResolution {
    public static class IoC {
        public static IContainer Initialize() {
            ObjectFactory.Initialize(x =>
                        {
                            x.Scan(scan =>
                                    {
                                        scan.TheCallingAssembly();
                                        scan.WithDefaultConventions();
                                    });
                            x.For<IClasseInjetada>().Use<ClasseInjetada>();
                        });
            return ObjectFactory.Container;
        }
    }
}