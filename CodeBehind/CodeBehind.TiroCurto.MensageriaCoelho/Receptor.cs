//***CODE BEHIND - BY RODOLFO.FONSECA***//
using RabbitMQ.Client;
using System;
using System.Text;

namespace CodeBehind.MensageriaCoelho
{
    public class Receptor
    {
        public void Consumir()
        {

            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue: "order",
                                         durable: false,
                                         exclusive: false,
                                         autoDelete: false,
                                         arguments: null);

                    var data = channel.BasicGet("order", true);
                    var json = Encoding.UTF8.GetString(data.Body.ToArray());

                    var obj = Newtonsoft.Json.JsonConvert.DeserializeObject<ObjetoPersonalisado>(json);

                    Console.WriteLine(obj.Mensagem);
                }
            }
        }
    }
}
