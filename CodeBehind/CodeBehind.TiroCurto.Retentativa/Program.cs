//***CODE BEHIND - BY RODOLFO.FONSECA***//

using CodeBehind.TiroCurto.Retentativa;
using Polly;
using Polly.Timeout;
using System.Net;

Console.WriteLine("Bem vindo ao polly");


//#Retry---------------------------------------------
Console.WriteLine("Retentativa simples");
var regra01 = Policy
    .HandleResult<Task<HttpResponseMessage>>(r => r.Result.StatusCode == HttpStatusCode.NotFound)
    .Retry(3, onRetry: (exception, retryCount, context) =>
    {
        Console.WriteLine($"Logica 01 - Passou {retryCount}");
    });

regra01.Execute(() => Logica01.ChamadaApi("xxxxxxxxxxxxxxxxxxxxxxxx"));

//##Wait and retry----------------------------------
Console.WriteLine("Retentativa com espera");
var regra02 = Policy
  .Handle<DominioExcecao>(x => x.Codigo == "02")
  .WaitAndRetry(new[]
  {
    TimeSpan.FromSeconds(1),
    TimeSpan.FromSeconds(2),
    TimeSpan.FromSeconds(3)
  }, (exception, timeSpan, retryCount, context) =>
  {
      Console.WriteLine($"Logica 02 - Passou {retryCount}");
  });

regra02.Execute(() => Logica02.EnviarArquivo());


//####Fallback-------------------------------------
Console.WriteLine("Retentativa com troca de valores");
var cli = new Cliente() { Id = 1, Celular = "11988885555" };

var regra03 = Policy<Cliente>
   .Handle<DominioExcecao>(x => x.Codigo == "03")
   .Fallback<Cliente>(cli, onFallback: (exception, context) =>
   {
       cli.Celular = "11955552222";
       //tentar dinovo ou mover para outro processamento
       Logica03.EnviarSMS(cli);

       Console.WriteLine($"Logica 03 - Passou");
   });

regra03.Execute(() => Logica03.EnviarSMS(cli));

//Rate-limit
//Bulkhead Isolation
//Circuit Breaker
//TimeoutPolicy
//CachePolicy
//PolicyWrap

Console.WriteLine("Fim");
Console.ReadLine();