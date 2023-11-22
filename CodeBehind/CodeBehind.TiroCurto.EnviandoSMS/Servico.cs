using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twilio;

namespace CodeBehind.TiroCurto.EnviandoSMS
{
    public class Servico
    {
        public static void EnviarModem(string texto, string telefone)
        {
            using (var port = new System.IO.Ports.SerialPort())
            {
                port.PortName = "COM5";
                port.Open();
                port.DtrEnable = true;
                port.RtsEnable = true;
                port.Write("AT\r"); // iniciando a comunicação
                port.Write("AT+CMGF=1\r"); // setando a comunicação para o modo texto
                port.Write(string.Format("AT+CMGS=\"{0}\"\r", telefone)); // setando o número do destinatário
                port.Write(texto + char.ConvertFromUtf32(26)); // enviando a mensagem
            }
        }

        /// <summary>
        /// https://www.twilio.com/docs/messaging/quickstart/csharp-dotnet-framework
        /// </summary>
        /// <param name="texto"></param>
        /// <param name="telefone"></param>
        public void EnviarTwilio(string texto, string telefone)
        {
            var accountSID = "AC292cb4439ddea8e886f13eb1df0ae7af";
            var authToken = "55d5b4419087ab6e395cacca0c2f432d";

            TwilioClient.Init(accountSID, authToken);

            var resultado = Twilio.Rest.Api.V2010.Account.MessageResource.Create(
                to: new Twilio.Types.PhoneNumber(telefone),
                from: new Twilio.Types.PhoneNumber("+12564459982"),
                body: texto);

            Console.Write(resultado.Sid);
        }

        /// <summary>
        /// http://smsc.vianett.no/v3/cpa/cpawebservice.asmx
        /// Via Add Service Reference
        /// </summary>
        public async void EnviarViaNett(string texto, string telefone)
        {
            using (var vianett = new ViaNett.CPAWebServiceSoapClient(ViaNett.CPAWebServiceSoapClient.EndpointConfiguration.CPAWebServiceSoap))
            {
                var resultado = await vianett.SendSMS_Simple1Async(
                    "USER", "PWD",
                    Convert.ToInt64(telefone.Replace("+", string.Empty)),
                    texto);
            }
        }


        /// <summary>
        /// http://api.upsidewireless.com/soap/Authentication.asmx
        /// http://api.upsidewireless.com/soap/SMS.asmx
        /// </summary>
        private async void EnviarIpipi(string texto, string telefone)
        {
            using (var ipipiAuth = new IpipiAuth.AuthenticationSoapClient(IpipiAuth.AuthenticationSoapClient.EndpointConfiguration.AuthenticationSoap))
            using (var ipipi = new Ipipi.SMSSoapClient(Ipipi.SMSSoapClient.EndpointConfiguration.SMSSoap))
            {
                var authInfo = await ipipiAuth.GetParametersAsync(new IpipiAuth.GetParametersRequest("user", "pwd"));
                var request = new Ipipi.Send_PlainRequest()
                {
                    token = authInfo.GetParametersResult.Token,
                    signature = authInfo.GetParametersResult.Signature,
                    message = texto,
                    recipient = telefone,
                    encoding = Ipipi.SmsEncoding.Seven
                };
                var resultado = ipipi.Send_PlainAsync(request);
            }
        }

    }
}
