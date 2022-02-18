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
        //fire and forget - executa apenas uma vez
        public IActionResult RodaUmaVez()
        {
            var jobFireForget = BackgroundJob.Enqueue(() => Acao.RegistrarMensagem("RodaUmaVez"));

            return Ok();
        }


        [HttpGet("RodarAposTempo")]
        //delayed depois de 30seg
        public IActionResult RodarAposTempo()
        {
            var jobDelayed = BackgroundJob.Schedule(() => Acao.RegistrarMensagem("RodarAposTempo"), TimeSpan.FromSeconds(30));

            return Ok();
        }

        [HttpGet("RodarAposTempoContinuo")]
        //aguarda e roda
        public IActionResult RodarAposTempoContinuo()
        {
            var jobDelayed = BackgroundJob.Schedule(() => Acao.RegistrarMensagem("RodaUmaVez"), TimeSpan.FromSeconds(30));

            BackgroundJob.ContinueWith(jobDelayed, () => Acao.RegistrarMensagem("RodarAposTempoContinuo"));

            return Ok();
        }

        [HttpGet("RodarSempre")]
        //continuo a cada minuno
        public IActionResult RodarSempre()
        {
            RecurringJob.AddOrUpdate(() => Acao.RegistrarMensagem("RodarSempre"), Cron.Minutely);

            return Ok();
        }

        
    }
}