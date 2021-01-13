//***CODE BEHIND - BY RODOLFO.FONSECA***//
using Nancy.TinyIoc;
using Paramore.Brighter;
using System;

namespace CodeBehind.MensageriaCoelho.Ouvir
{
    internal class TinyIocHandlerFactory : IAmAHandlerFactory
    {
        private readonly TinyIoCContainer _container;

        public TinyIocHandlerFactory(TinyIoCContainer container)
        {
            _container = container;
        }

        public IHandleRequests Create(Type handlerType)
        {
            return (IHandleRequests)_container.Resolve(handlerType);
        }

        public void Release(IHandleRequests handler)
        {
            var disposable = handler as IDisposable;
            if (disposable != null)
            {
                disposable.Dispose();
            }

            handler = null;
        }
    }
}
