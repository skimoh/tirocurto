using CodeBehind.TiroCurto.PendureFogo.Models;
using Hangfire;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CodeBehind.TiroCurto.PendureFogo.Controllers
{
    [Route("api/[controller]")]
    public class ServicoController : Controller
    {
        private readonly ILogger<ServicoController> _logger;

        public ServicoController(ILogger<ServicoController> logger)
        {
            _logger = logger;
        }

        [HttpGet("RodaUmaVez")]
        //Os trabalhos de despedir e esquecer são executados apenas uma vez e quase imediatamente após a criação.
        public IActionResult RodaUmaVez()
        {
            var jobFireForget = BackgroundJob.Enqueue(() => Acao.RegistrarMensagem("RodaUmaVez"));

            return Ok();
        }


        [HttpGet("RodarAposTempo")]
        //Os trabalhos atrasados ​​também são executados apenas uma vez, mas não imediatamente, após um determinado intervalo de tempo.
        public IActionResult RodarAposTempo()
        {
            var jobDelayed = BackgroundJob.Schedule(() => Acao.RegistrarMensagem("RodarAposTempo"), TimeSpan.FromSeconds(10));

            return Ok();
        }

        [HttpGet("RodarAposTempoContinuo")]
        //As continuações são executadas quando seu trabalho pai foi concluído.
        public IActionResult RodarAposTempoContinuo()
        {
            var jobDelayed = BackgroundJob.Schedule(() => Acao.RegistrarMensagem("RodaUmaVez"), TimeSpan.FromSeconds(10));

            BackgroundJob.ContinueJobWith(jobDelayed, () => Acao.RegistrarMensagem("RodarAposTempoContinuo"));

            return Ok();
        }

        [HttpGet("RodarSempre")]
        //Trabalhos recorrentes são acionados muitas vezes no agendamento CRON especificado.
        public IActionResult RodarSempre()
        {
            RecurringJob.AddOrUpdate(() => Acao.RegistrarMensagem("RodarSempre"), Cron.Minutely);

            return Ok();
        }

        
    }
}