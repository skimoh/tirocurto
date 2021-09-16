//***CODE BEHIND - BY RODOLFO.FONSECA***//

using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Azure.Storage.Blobs;

namespace CodeBehind.TiroCurto.Azure.Funcao
{
    public static class FuncYoutubeGatilho
    {
        [FunctionName("FuncYoutubeGatilho")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string name = req.Query["name"];

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic obj = JsonConvert.DeserializeObject(requestBody);
            name = name ?? obj?.name;

            var nomeArquivo = string.Format("log_{0:yyyyMMddhhmm}.txt", DateTime.Now);

            string con = Environment.GetEnvironmentVariable("AzureWebJobsStorage");
            var blobClient = new BlobClient(con, "pasta", nomeArquivo);

            byte[] data = System.Text.Encoding.ASCII.GetBytes($"Ola Mundo {name}");

            using (var stream = new MemoryStream(data))
            {
                blobClient.Upload(stream);
            }

            return new OkObjectResult(true);
        }
    }
}
