//***CODE BEHIND - BY RODOLFO.FONSECA***//
using Nancy.TinyIoc;
using Paramore.Brighter;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeBehind.MensageriaCoelho.Ouvir
{
    internal class TinyIoCMessageMapperFactory : IAmAMessageMapperFactory
    {
        private readonly TinyIoCContainer _container;

        public TinyIoCMessageMapperFactory(TinyIoCContainer container)
        {
            _container = container;
        }

        public IAmAMessageMapper Create(Type messageMapperType)
        {
            return (IAmAMessageMapper)_container.Resolve(messageMapperType);
        }
    }
}
