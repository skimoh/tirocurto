//***CODE BEHIND - BY RODOLFO.FONSECA***//

using CodeBehind.TiroCurto.Seguranca.Models;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace CodeBehind.TiroCurto.Seguranca.Core
{
    public class GoogleCaptchaService
    {
        public readonly GoogleCaptchaConfig _config;

        public GoogleCaptchaService(IOptions<GoogleCaptchaConfig> config)
        {            
            _config = config.Value;

        }
        public async Task<bool> Verificar(string token)
        {
			try
			{
                var url = $"https://www.google.com/recaptcha/api/siteverify?secret={_config.SecretKey}&response={token}";
                using (var client = new HttpClient())
                {
                    var result = await client.GetAsync(url);
                    if(result.StatusCode != System.Net.HttpStatusCode.OK)
                    {
                        return false;
                    }

                    var response = await result.Content.ReadAsStringAsync();
                    var responseGoogle = JsonConvert.DeserializeObject<GoogleCaptchaResponse>(response);

                    return responseGoogle.success && responseGoogle.score > 0.5;
                }

            }
			catch (Exception ex)
			{
				return false;
			}
        }
    }
}
