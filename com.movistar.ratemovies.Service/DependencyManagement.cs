using System;
using com.movistar.ratemovies.core.Enums;
using com.movistar.ratemovies.core.Interface.MessageBroker;
using com.movistar.ratemovies.core.Interface.Services;
using com.movistar.ratemovies.core.Model;
using com.movistar.ratemovies.Service.Movie;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace com.movistar.ratemovies.Service
{
    public static class DependencyManagement
    {
        public static IServiceCollection ConfigureApplicationServices(this IServiceCollection services, IConfiguration configuration, EventBrokerType type)
        {
            SetStaticConfigurationSettings(configuration);
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddScoped<IMovieService, MovieService>();
            services.ConfigureEventBrokerService(type);

            return services;
        }

        private static void ConfigureEventBrokerService(this IServiceCollection services, EventBrokerType type)
        {
            switch (type)
            {
                case EventBrokerType.RabbitMQ:
                    services.AddScoped<IMessageBrokerService, MovieRabbitMqMessageBrokerService>();
                    break;
            }
        }

        private static void SetStaticConfigurationSettings(IConfiguration configuration)
        {
            MovieRabbitMqMessageBrokerOption.QueueName = configuration["com.movistar.ratemovies.MovieRabbitMqOption.QueueName"];
            MovieRabbitMqMessageBrokerOption.RouteKey = configuration["com.movistar.ratemovies.MovieRabbitMqOption.RouteKey"];
            MovieRabbitMqMessageBrokerOption.VirtualPath = configuration["com.movistar.ratemovies.MovieRabbitMqOption.VirtualPath"];
        }

    }
}
