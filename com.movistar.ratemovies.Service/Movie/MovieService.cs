using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using com.movistar.ratemovies.core.Interface.Database.Command;
using com.movistar.ratemovies.core.Interface.MessageBroker;
using com.movistar.ratemovies.core.Interface.Services;
using com.movistar.ratemovies.core.Model;

namespace com.movistar.ratemovies.Service.Movie
{
    public class MovieService : IMovieService
    {
        public MovieService(IMovieCommand command, IMapper mapper, IMessageBrokerService brokerService)
        {
            this.command = command;
            this.mapper = mapper;
            this.brokerService = brokerService;
        }

        private readonly IMovieCommand command;
        private readonly IMapper mapper;
        private readonly IMessageBrokerService brokerService;

        public async Task<(bool Flag, string Message)> AddAsync(MovieDto movie, CancellationToken cancellationToken)
        {
            core.Entities.Movie entity = mapper.Map<core.Entities.Movie>(movie);
            var result = await command.AddAsync(entity, cancellationToken);
            return result;
        }

        public async Task ProcessMoviesFromEventBroker(CancellationToken cancellationToken)
        {
            await brokerService.ConsumeMessagesAsync(cancellationToken);
        }
    }
}
