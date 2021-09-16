//***CODE BEHIND - BY RODOLFO.FONSECA***//

using System;
using System.IO;
using Azure.Storage.Blobs;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace CodeBehind.TiroCurto.Azure.Funcao
{
    public static class FuncYoutubeTimer
    {
        /// <summary>
        /// 1x a cada 1 minuto
        /// </summary>        
        [FunctionName("FuncYoutubeTimer")]
        public static void Run([TimerTrigger("0 */10 * * * *")]TimerInfo myTimer, ILogger log)
        {
            log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");

            var nomeArquivo = string.Format("log_{0:yyyyMMddhhmm}.txt", DateTime.Now);

            string con = Environment.GetEnvironmentVariable("AzureWebJobsStorage");
            var blobClient = new BlobClient(con, "pasta", nomeArquivo);

            var texto = myTimer.ScheduleStatus.LastUpdated.ToLongTimeString().Replace("/","").Replace(":","");

            byte[] data = System.Text.Encoding.ASCII.GetBytes($"Ola Mundo {texto}");

            using (var stream = new MemoryStream(data))
            {
                blobClient.Upload(stream);
            }
        }
    }
}
