using Paramore.Brighter;
using System;
using System.Collections.Generic;
using System.Text;

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
