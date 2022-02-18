using CodeBehind.TiroCurto.ServicoComRelogio;
//***CODE BEHIND - BY RODOLFO.FONSECA***//

using Quartz;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        services.AddQuartz(q =>
        {
            q.UseMicrosoftDependencyInjectionScopedJobFactory();
            q.AddJobAndTrigger<ServicoAutonomoJob>(hostContext.Configuration);            
        });

        services.AddQuartzHostedService(q => q.WaitForJobsToComplete = true);
    })
    .UseWindowsService()
    .Build();

await host.RunAsync();

//sc create servicowindows binPath=C:\temp\servicowindows.exe
