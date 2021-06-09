using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using com.movistar.ratemovies.core.Interface.Database.Command;
using com.movistar.ratemovies.core.Interface.Services;
using com.movistar.ratemovies.core.Model;

namespace com.movistar.ratemovies.Service.Movie
{
    public class MovieService : IMovieService
    {
        public MovieService(IMovieCommand command, IMapper mapper)
        {
            this.command = command;
            this.mapper = mapper;
        }

        private readonly IMovieCommand command;
        private readonly IMapper mapper;

        public async Task<(bool Flag, string Message)> AddAsync(MovieDto movie, CancellationToken cancellationToken)
        {
            core.Entities.Movie entity = mapper.Map<core.Entities.Movie>(movie);
            var result = await command.AddAsync(entity, cancellationToken);
            return result;
        }
    }
}
