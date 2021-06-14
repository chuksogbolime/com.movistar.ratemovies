using System;
namespace com.movistar.ratemovies.core.Model
{
    public static class MovieRabbitMqMessageBrokerOption
    {
        public static string VirtualPath { get; set; }
        public static string QueueName { get; set; }
        public static string RouteKey { get; set; }
        public static string ExchangeName { get; set; }
    }
}
