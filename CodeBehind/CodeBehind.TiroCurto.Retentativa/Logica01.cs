using System.Net.Http.Headers;

namespace CodeBehind.TiroCurto.Retentativa
{
    public static class Logica01
    {
        public static Task<HttpResponseMessage> ChamadaApi(string cep)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://viacep.com.br/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //cep funcional 01001000
                var retorno= client.GetAsync("$ws/{cep}/json/").GetAwaiter().GetResult();
                return Task.FromResult(retorno);
            }
        }
    }
}
