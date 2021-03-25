//***CODE BEHIND - BY RODOLFO.FONSECA***//
using CodeBehind.TiroCurto.Servico.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;
using System.Threading.Tasks;
using Topshelf;

namespace CodeBehind.TiroCurto.Servico
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = new HostBuilder()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .ConfigureServices((hostBuilderContext, services) =>
                {
                    services.AddSingleton(typeof(Ciclo));
                });

            var rc = HostFactory.Run(x =>
            {
                x.Service<Ciclo>(sc =>
                {
                    sc.ConstructUsing(s =>
                    host.Build().Services.GetRequiredService<Ciclo>());
                    sc.WhenStarted((s, c) => s.Start(c));
                    sc.WhenStopped((s, c) => s.Stop(c));
                });
                x.RunAsLocalSystem()
                  .DependsOnEventLog()
                 .StartAutomatically()
                 .EnableServiceRecovery(rc => rc.RestartService(1));
                x.SetDescription("Code Behind Servico");
                x.SetDisplayName("CBB-Servico");
                x.SetServiceName("CBB-Servico");
            });
            await Task.CompletedTask;
        }

        //public static void Main()
        //{
        //    var rc = HostFactory.Run(x =>
        //    {
        //        x.Service<CicloAlternativo>(s =>
        //        {
        //            s.ConstructUsing(name => new CicloAlternativo());
        //            s.WhenStarted(tc => tc.Start());
        //            s.WhenStopped(tc => tc.Stop());
        //        });
        //        x.RunAsLocalSystem();

        //        x.SetDescription("Sample Topshelf Host");
        //        x.SetDisplayName("Stuff");
        //        x.SetServiceName("Stuff");
        //    });

        //    var exitCode = (int)Convert.ChangeType(rc, rc.GetTypeCode());
        //    Environment.ExitCode = exitCode;
        //}
    }
}

/*
 PARA INSTALAR BASTA RODAR EM MODO RELEASE
IR NA PASTA VIA PROMPT DE COMANDO
E RODAR "CodeBehind.TiroCurto.Servico.exe install"
 
 */
