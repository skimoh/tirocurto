//***CODE BEHIND - BY RODOLFO.FONSECA***//

namespace CodeBehind.TiroCurto.ServicoNativo
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("O serviço está iniciando.");

            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Rodando: {time}", DateTimeOffset.Now);

                File.AppendAllText("c:\\temp\\log.txt", Environment.NewLine + $"Rodando: {DateTime.Now}");

                await Task.Delay(1000, stoppingToken);//1segundo
            }

            _logger.LogInformation("O serviço está parando.");
        }
    }
}