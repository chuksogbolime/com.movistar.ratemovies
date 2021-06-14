using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using com.movistar.ratemovies.core.Interface.Database.Command;
using com.movistar.ratemovies.core.Model;
using com.movistar.ratemovies.infrastructure.MessageBroker;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQ.Client.Exceptions;

namespace com.movistar.ratemovies.Service.Movie
{
    public class MovieRabbitMqMessageBrokerService : RabbitMqMessageBrokerService<MovieDto>
    {
        private readonly IMovieCommand command;
        private readonly IMapper mapper;

        public MovieRabbitMqMessageBrokerService(IMovieCommand command, IMapper mapper)
            :base(MovieRabbitMqMessageBrokerOption.VirtualPath, MovieRabbitMqMessageBrokerOption.QueueName,
                 MovieRabbitMqMessageBrokerOption.RouteKey,
                 MovieRabbitMqMessageBrokerOption.ExchangeName)
        {
            this.command = command;
            this.mapper = mapper;
        }

        public override async Task<bool> HandleMessageAsync(MovieDto movie, CancellationToken cancellationToken)
        {
            
            core.Entities.Movie entity = mapper.Map<core.Entities.Movie>(movie);
            var result = await command.AddAsync(entity, cancellationToken);
            return result.Flag;
        }
    }
}
