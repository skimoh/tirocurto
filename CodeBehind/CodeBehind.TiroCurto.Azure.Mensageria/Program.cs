//***CODE BEHIND - BY RODOLFO.FONSECA***//
using Microsoft.Azure.ServiceBus;
using Newtonsoft.Json;
using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CodeBehind.TiroCurto.Azure.Mensageria
{
    class Program
    {
        static IQueueClient queueClient;
        private const string _fila = "nome-fila";
        private const string _conexaoAzureBus = "Endpoint=xxxxxx";

        static void Main(string[] args)
        {
            Task.Run(async () =>
            {
                await ReceberMensagem();
            });
            Console.WriteLine("Fim");
            Console.Read();
        }

        private static async Task EnviarFila()
        {
            try
            {
                var obj = new ObjetoDto
                {
                    Id = new Random().Next(1, 99),
                    Conteudo = "Ola Mundo",
                    DataOcorrencia = DateTime.Now
                };


                IQueueClient queueClient = new QueueClient(_conexaoAzureBus, _fila);
                var orderMessage = new Message(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(obj)))
                {
                    MessageId = Guid.NewGuid().ToString(),
                    ContentType = "application/json"
                };
                Console.WriteLine("Enviando para Fila");
                await queueClient.SendAsync(orderMessage).ConfigureAwait(false);
                Console.WriteLine("Enviado para fila");

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public static async Task EnviarTopico()
        {
            {
                try
                {
                    var obj = new ObjetoDto
                    {
                        Id = new Random().Next(1, 99),
                        Conteudo = "Ola Mundo",
                        DataOcorrencia = DateTime.Now
                    };

                    //FILTERS
                    var message = new Message(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(obj)));
                    message.UserProperties["Cabecalho"] = "Aprovado";

                    var topicClient = new TopicClient(_conexaoAzureBus, "nome-topico");
                    Console.WriteLine("Enviando para o topico");
                    await topicClient.SendAsync(message);
                    Console.WriteLine("Enviado par ao topico");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }

        public static async Task ReceberMensagem()
        {
            queueClient = new QueueClient(_conexaoAzureBus, _fila);

            var messageHandlerOptions = new MessageHandlerOptions(ExceptionReceivedHandler)
            {
                MaxConcurrentCalls = 10,
                AutoComplete = false
            };
            queueClient.RegisterMessageHandler(ProcessMessagesAsync, messageHandlerOptions);

            await Task.FromResult(true);
        }

        static async Task ProcessMessagesAsync(Message message, CancellationToken token)
        {
            Console.WriteLine($"Recebendo mensagem: SequenceNumber:{message.SystemProperties.SequenceNumber} Body:{Encoding.UTF8.GetString(message.Body)}");

            var obj = JsonConvert.DeserializeObject<ObjetoDto>(Encoding.UTF8.GetString(message.Body));
            if (obj.Id == 1)
                Console.WriteLine("Limao Suico");
            else Console.WriteLine("Abacate mexicano");

            await queueClient.CompleteAsync(message.SystemProperties.LockToken);
        }

        static Task ExceptionReceivedHandler(ExceptionReceivedEventArgs exceptionReceivedEventArgs)
        {
            Console.WriteLine($"Message handler encountered an exception {exceptionReceivedEventArgs.Exception}.");
            var context = exceptionReceivedEventArgs.ExceptionReceivedContext;
            Console.WriteLine("Exception context for troubleshooting:");
            Console.WriteLine($"- Endpoint: {context.Endpoint}");
            Console.WriteLine($"- Entity Path: {context.EntityPath}");
            Console.WriteLine($"- Executing Action: {context.Action}");
            return Task.CompletedTask;
        }
    }
}
