//***CODE BEHIND - BY RODOLFO.FONSECA***//
using Paramore.Brighter;
using System;

namespace CodeBehind.MensageriaCoelho.Ouvir
{
    internal class PersonEventHandler : RequestHandler<EventoPersonalisado>
    {
        public override EventoPersonalisado Handle(EventoPersonalisado command)
        {            
            Console.WriteLine("----------------------------------");
            Console.WriteLine(command.Mensagem);
            Console.WriteLine("----------------------------------");
            
            return base.Handle(command);
        }
    }
}
