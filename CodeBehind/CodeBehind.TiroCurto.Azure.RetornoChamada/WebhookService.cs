namespace CodeBehind.TiroCurto.Azure.RetornoChamada
{
    public interface IWebhookService
    {
        Task Handler(string message);
    }


    public class WebhookService : IWebhookService
    {
        private ILogger<WebhookService> _log;

        public void Subscribe(ILogger<WebhookService> log)
        {
            _log = log;
        }

        public async Task Handler(string message)
        {
            _log.LogInformation("Processando atualização");



        }
    }
}
