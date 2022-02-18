//***CODE BEHIND - BY RODOLFO.FONSECA***//

using CodeBehind.TiroCurto.ServicoNativo;

IHost host = Host.CreateDefaultBuilder(args)
     .UseWindowsService()
    .ConfigureServices(services =>
    {
        services.AddHostedService<Worker>();        
    })
    .Build();

await host.RunAsync();

//sc create servicowindows binPath=C:\temp\servicowindows.exe
