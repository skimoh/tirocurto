//***CODE BEHIND - BY RODOLFO.FONSECA***//

using Quartz;

namespace CodeBehind.TiroCurto.ServicoComRelogio
{
    [DisallowConcurrentExecution]
    public class ServicoAutonomoJob : IJob    
    {
        private readonly ILogger<ServicoAutonomoJob> _logger;
        public ServicoAutonomoJob(ILogger<ServicoAutonomoJob> logger)
        {
            _logger = logger;
        }

        public Task Execute(IJobExecutionContext context)
        {
            _logger.LogInformation("Rodando: {time}", DateTimeOffset.Now);

            File.AppendAllText("c:\\temp\\log.txt", Environment.NewLine + $"Rodando: {DateTime.Now}");

            return Task.CompletedTask;
        }
    }
}
