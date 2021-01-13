using Paramore.Brighter;
using System;

namespace CodeBehind.MensageriaCoelho.Ouvir
{
    public class EventoPersonalisado : Event
    {
        public EventoPersonalisado() : base(Guid.NewGuid()) { }

        public EventoPersonalisado(string mensagem) : base(Guid.NewGuid())
        {
            Mensagem = mensagem;
        }

        public string Mensagem { get; set; }
    }
}
