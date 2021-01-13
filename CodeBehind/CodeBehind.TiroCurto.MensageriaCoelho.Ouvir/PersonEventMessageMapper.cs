using Newtonsoft.Json;
using Paramore.Brighter;

namespace CodeBehind.MensageriaCoelho.Ouvir
{
    public class PersonEventMessageMapper : IAmAMessageMapper<EventoPersonalisado>
    {
        /// <summary>
        /// Mapeando o objeto personalizado para um objeto Message do Paramore.Brighter
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Message MapToMessage(EventoPersonalisado request)
        {
            var header = new MessageHeader(messageId: request.Id, topic: "Person.event", messageType: MessageType.MT_EVENT);
            var body = new MessageBody(JsonConvert.SerializeObject(request));
            var message = new Message(header, body);
            return message;
        }

        /// <summary>
        /// Mapeando o objeto  Message do Paramore.Brighter para um objeto personalizado
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public EventoPersonalisado MapToRequest(Message message)
        {
            var PersonCommand = JsonConvert.DeserializeObject<EventoPersonalisado>(message.Body.Value);
            return PersonCommand;
        }
    }
}
