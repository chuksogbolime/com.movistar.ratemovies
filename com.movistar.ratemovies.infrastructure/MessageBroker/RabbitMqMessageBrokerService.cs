using System;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using com.movistar.ratemovies.core.Interface.MessageBroker;
using com.movistar.ratemovies.core.Model;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQ.Client.Exceptions;

namespace com.movistar.ratemovies.infrastructure.MessageBroker
{
    public abstract class RabbitMqMessageBrokerService<T> : IRabbitMqMessageBrokerService<T>
    {
        public string Host { get; private set; }
        public string Username { get; private set; }
        public string Password { get; private set; }
        public int Port { get; private set; }

        public string VirtualPath { get; private set; }
        public string QueueName { get; private set; }
        public string RouteKey { get; private set; }
        public string ExchangeName { get; private set; }

        public IConnection Connection;
        public IModel Channel;

        public RabbitMqMessageBrokerService(string virtualPath, string queueName, string routeKey, string exchangeName)
        {
            Host = MessageBrokerOption.Host;
            Username = MessageBrokerOption.Username;
            Password = MessageBrokerOption.Password;
            Port = MessageBrokerOption.Port;

            VirtualPath = virtualPath;
            QueueName = queueName;
            RouteKey = routeKey;
            ExchangeName = exchangeName;

           
        }

        public IConnection CreateConnection()
        {
            try
            {
                
                if (Connection != null)
                {
                    return Connection;
                }
                var factory = new ConnectionFactory
                {
                    HostName = Host,
                    UserName = Username,
                    Password = Password,
                    Port = Port,
                    VirtualHost=VirtualPath
                };
                Connection = factory.CreateConnection();
                return Connection;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void CloseConnection()
        {
            if(Connection != null)
            {
                Connection.Close();
                Connection.Dispose();
            }
        }
      

        public virtual void SubscribeForMessages()
        {
            CreateConnection();
            Channel = Connection.CreateModel();
            Channel.ExchangeDeclare(exchange: ExchangeName, type: "direct", durable: true);
            Channel.QueueDeclare(queue: QueueName, durable: true, exclusive: false, autoDelete: false, arguments: null);
            Channel.QueueBind(queue: QueueName, exchange: ExchangeName, routingKey: RouteKey);
        }

        public virtual async Task ConsumeMessagesAsync(CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            SubscribeForMessages();

            var consumer = new AsyncEventingBasicConsumer(Channel);
            consumer.Received += async (c, e) =>
            {
                var content = Encoding.UTF8.GetString(e.Body.ToArray());
                try
                {
                    var data = JsonConvert.DeserializeObject<T>(content);

                    var result = await HandleMessageAsync(data, cancellationToken);
                    if(result)
                    Channel.BasicAck(e.DeliveryTag, false);
                }
                catch (Newtonsoft.Json.JsonException jEx)
                {
                    Channel.BasicNack(e.DeliveryTag, false, false);
                }
                catch (AlreadyClosedException aEx)
                {
                  
                }
                catch (Exception ex)
                {
                }
            };


            Channel.BasicConsume(MovieRabbitMqMessageBrokerOption.QueueName, false, consumer);

            await Task.CompletedTask;

        }

        public abstract Task<bool> HandleMessageAsync(T data, CancellationToken cancellationToken);
        

    }
}
