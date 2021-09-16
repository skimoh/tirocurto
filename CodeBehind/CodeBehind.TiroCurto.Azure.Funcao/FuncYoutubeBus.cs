//***CODE BEHIND - BY RODOLFO.FONSECA***//

using System;
using System.IO;
using Azure.Storage.Blobs;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace CodeBehind.TiroCurto.Azure.Funcao
{
    public static class FuncYoutubeBus
    {
        [FunctionName("FuncYoutubeBus")]
        public static void Run([ServiceBusTrigger("fila-youtube", Connection = "Conexao")] string myQueueItem, ILogger log)
        {
            log.LogInformation($"C# ServiceBus queue trigger function processed message: {myQueueItem}");

            var obj = JsonConvert.DeserializeObject<Cliente>(myQueueItem);

            var nomeArquivo = string.Format("log_{0:yyyyMMddhhmm}.txt", DateTime.Now);

            string con = Environment.GetEnvironmentVariable("AzureWebJobsStorage");
            var blobClient = new BlobClient(con, "pasta", nomeArquivo);

            byte[] data = System.Text.Encoding.ASCII.GetBytes($"Ola Mundo {obj.Nome}");

            using (var stream = new MemoryStream(data))
            {
                blobClient.Upload(stream);
            }
        }
    }
}
