using System;
using System.Threading;
using System.Threading.Tasks;

namespace com.movistar.ratemovies.core.Interface.MessageBroker

{
    public interface IMessageBrokerService
    {
        string Host { get; }
        string Username { get;}
        string Password { get; }
        int Port { get; }
        Task ConsumeMessagesAsync(CancellationToken cancellationToken);
    }
}
