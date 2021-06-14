using System;
using System.Threading;
using System.Threading.Tasks;

namespace com.movistar.ratemovies.core.Interface.MessageBroker
{
    public interface IRabbitMqMessageBrokerService<T>: IMessageBrokerService
    {
        string VirtualPath { get; }
        string QueueName { get; }
        string RouteKey { get; }
        string ExchangeName { get;}


        Task<bool> HandleMessageAsync(T data, CancellationToken cancellationToken);
    }
}
