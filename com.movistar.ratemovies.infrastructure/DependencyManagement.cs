using System;
using com.movistar.ratemovies.core.Interface.Database.Command;
using com.movistar.ratemovies.core.Interface.MessageBroker;
using com.movistar.ratemovies.core.Model;
using com.movistar.ratemovies.infrastructure.Database;
using com.movistar.ratemovies.infrastructure.Database.Commands;
using com.movistar.ratemovies.infrastructure.MessageBroker;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace com.movistar.ratemovies.infrastructure
{
    public static class DependencyManagement
    {
        private static string connectionString;
        public static IServiceCollection ConfigureInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            SetStaticConfigurationSettings(configuration);
            services.AddScoped<IMovieCommand, MovieCommand>();
            InitDatabaseContextForSQLServer(services, connectionString);

            return services;
        }
        private static void InitDatabaseContextForSQLServer(this IServiceCollection services, string connectionString)
        {
            services.AddDbContextPool<RateMovieDbContext>(optionBuilder =>
            {
                optionBuilder.UseSqlServer(connectionString);
            });
        }

        private static void SetStaticConfigurationSettings(IConfiguration configuration)
        {
            MessageBrokerOption.Host = configuration["com.movistar.ratemovies.EventBrokerOption.Host"];
            MessageBrokerOption.Password = configuration["com.movistar.ratemovies.EventBrokerOption.Password"];
            MessageBrokerOption.Port = Convert.ToInt16(configuration["com.movistar.ratemovies.EventBrokerOption.Port"]);
            MessageBrokerOption.Username = configuration["com.movistar.ratemovies.EventBrokerOption.Username"];
            connectionString = configuration["com.movistar.ratemovies.SqlServer.Connection"];
        }
    }
}
