//***CODE BEHIND - BY RODOLFO.FONSECA***//
using RestSharp;
using System;

namespace CodeBehind.TiroCurto.InvokeApi
{
    class Program
    {
        static void Main(string[] args)
        {
            //InvocarGet();
            InvocarPost();
        }

        private static void InvocarPost()
        {
            var client = new RestClient($"https://run.mocky.io/v3/73f60d83-f20d-4724-8d54-f98be085dd1d");

            RestRequest request = new RestRequest("", Method.Post);
            request.AddJsonBody(new { Id = 5 });
            var response = client.ExecuteAsync(request).GetAwaiter().GetResult();
            if(response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                Console.WriteLine(response.Content);
            }
            else
            {
                Console.WriteLine(response.ErrorMessage);
            }
            Console.ReadKey();
        }

        private static void InvocarGet()
        {
            string cep = "37130031";

            var client = new RestClient($"https://viacep.com.br/ws/{cep}/json/");
            RestRequest request = new RestRequest("", Method.Get);
            var response = client.ExecuteAsync(request).GetAwaiter().GetResult(); 

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
                Console.WriteLine(response.Content);
            else
            {
                Console.WriteLine(response.ErrorMessage);
            }
            Console.ReadKey();
        }
    }

    public class correio
    {
        public string cep { get; set; }
        public string logradouro { get; set; }
        public string complemento { get; set; }
        public string bairro { get; set; }
        public string localidade { get; set; }
        public string uf { get; set; }
        public string ibge { get; set; }
        public string gia { get; set; }
        public string ddd { get; set; }
        public string siafi { get; set; }
    }
}
