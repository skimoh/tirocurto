using Nancy.TinyIoc;
using Paramore.Brighter;
using Paramore.Brighter.MessagingGateway.RMQ;
using Paramore.Brighter.ServiceActivator;
using Polly;
using Polly.Registry;
using System;
using Topshelf;

namespace CodeBehind.MensageriaCoelho.Ouvir
{
    internal class PersonService : ServiceControl
    {
        private Dispatcher _dispatcher;

        public PersonService()
        {
            log4net.Config.XmlConfigurator.Configure();

            //injecao de dependencia
            var container = new TinyIoCContainer();
            var handlerFactory = new TinyIocHandlerFactory(container);
            
            var messageMapperFactory = new TinyIoCMessageMapperFactory(container);
            container.Register<IHandleRequests<EventoPersonalisado>, PersonEventHandler>();

            var subscriberRegistry = new SubscriberRegistry();
            subscriberRegistry.Register<EventoPersonalisado, PersonEventHandler>();

            //create policies
            var retryPolicy = Policy.Handle<Exception>().WaitAndRetry(new[]
            {
                TimeSpan.FromMilliseconds(50), TimeSpan.FromMilliseconds(100), TimeSpan.FromMilliseconds(150)
            });

            var circuitBreakerPolicy = Policy.Handle<Exception>().CircuitBreaker(1, TimeSpan.FromMilliseconds(500));
            var policyRegistry = new PolicyRegistry
            {
                { CommandProcessor.RETRYPOLICY, retryPolicy },
                { CommandProcessor.CIRCUITBREAKER, circuitBreakerPolicy }
            };

            //mapeando objetos
            var messageMapperRegistry = new MessageMapperRegistry(messageMapperFactory)
            {
                { typeof(EventoPersonalisado), typeof(PersonEventMessageMapper) }
            };

            //gateway de conexao
            var rmqConnnection = new RmqMessagingGatewayConnection
            {
                AmpqUri = new AmqpUriSpecification(new Uri("amqp://guest:guest@localhost:5672/%2f")),
                Exchange = new Exchange("paramore.brighter.exchange"),
            };

            var rmqMessageConsumerFactory = new RmqMessageConsumerFactory(rmqConnnection);

            _dispatcher = DispatchBuilder.With()
                .CommandProcessor(CommandProcessorBuilder.With()
                    .Handlers(new HandlerConfiguration(subscriberRegistry, handlerFactory))
                    .Policies(policyRegistry)
                    .NoTaskQueues()
                    .RequestContextFactory(new InMemoryRequestContextFactory())
                    .Build())
                .MessageMappers(messageMapperRegistry)
                .DefaultChannelFactory(new ChannelFactory(rmqMessageConsumerFactory))
                .Connections(new[]
                {
                    new Connection<EventoPersonalisado>(
                        new ConnectionName("paramore.example.Person"),
                        new ChannelName("order"),
                        new RoutingKey("order"),
                        timeoutInMilliseconds : 200)
                }).Build();
        }

        public bool Start(HostControl hostControl)
        {
            _dispatcher.Receive();
            return true;
        }
        public bool Stop(HostControl hostControl)
        {
            _dispatcher.End().Wait();
            _dispatcher = null;
            return false;
        }
        public void Shutdown(HostControl hostcontrol)
        {
            _dispatcher?.End();
        }
    }
}
